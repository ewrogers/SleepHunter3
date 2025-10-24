using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using SleepHunter.Interop;
using SleepHunter.Interop.Keyboard;
using SleepHunter.Interop.Mouse;
using SleepHunter.Macro.Commands;
using SleepHunter.Models;

namespace SleepHunter.Macro
{
    public sealed class MacroExecutor : IMacroExecutor
    {
        private static readonly TimeSpan UpdateInterval = TimeSpan.FromMilliseconds(33); // Roughly 30 FPS

        private readonly SynchronizationContext syncContext;
        private readonly List<IMacroCommand> commands;
        private readonly PlayerState player;
        private readonly GameClientReader reader;
        private readonly CancellationTokenSource cancellationTokenSource;
        private readonly ManualResetEventSlim pauseEvent;
        private readonly ManualResetEventSlim debugStepEvent;
        private readonly MacroStructureCache structureCache;
        private readonly MacroContext context;

        private int nextCommandIndex;
        private Task executingTask;
        private bool debugStepEnabled;

        private DateTime lastUpdateTime;
        private bool isDisposed;

        public MacroRunState State { get; private set; }
        public MacroStopReason StopReason { get; private set; }

        public event Action<int> DebugStep;
        public event Action<MacroRunState> StateChanged;
        public event Action<Exception> Exception;

        public MacroExecutor(IEnumerable<IMacroCommand> commands, GameClientReader reader, IVirtualKeyboard keyboard,
            IVirtualMouse mouse, SynchronizationContext syncContext = null)
        {
            this.syncContext = syncContext ?? SynchronizationContext.Current;

            this.commands = commands.ToList();
            this.reader = reader;

            cancellationTokenSource = new CancellationTokenSource();
            pauseEvent = new ManualResetEventSlim(true);
            debugStepEvent = new ManualResetEventSlim(false);

            player = new PlayerState();
            structureCache = new MacroStructureCache(this.commands);

            context = new MacroContext(structureCache, player, keyboard, mouse, cancellationTokenSource.Token);
        }

        public void SetDebugStepEnabled(bool enabled)
        {
            debugStepEnabled = enabled;
        }

        public Task StartAsync()
        {
            if (executingTask != null)
            {
                throw new InvalidOperationException("Macro is already executing or has stopped");
            }

            executingTask = Task.Run(async () =>
            {
                SetState(MacroRunState.Running);

                var stopReason = MacroStopReason.Completed;
                while (!cancellationTokenSource.IsCancellationRequested)
                {
                    // Wait for resume if paused
                    pauseEvent.Wait(cancellationTokenSource.Token);

                    try
                    {
                        // Stop if the command list is empty or we've reached the end of the list
                        if (nextCommandIndex >= commands.Count)
                        {
                            stopReason = MacroStopReason.Completed;
                            break;
                        }

                        // Execute the next command
                        // Some commands will block the thread, so we need to execute them asynchronously
                        var commandIndex = Interlocked.Increment(ref nextCommandIndex) - 1;
                        var command = commands[commandIndex];

                        context.CurrentCommandIndex = commandIndex;

                        if (debugStepEnabled)
                        {
                            SetState(MacroRunState.Paused);
                            syncContext.Post(state => DebugStep?.Invoke(commandIndex), null);
                            debugStepEvent.Wait(cancellationTokenSource.Token);
                            debugStepEvent.Reset();
                        }
                        
                        // Update the player state before performing the next action
                        if (DateTime.Now - lastUpdateTime > UpdateInterval)
                        {
                            try
                            {
                                UpdatePlayerState();
                            }
                            catch
                            {
                                stopReason = MacroStopReason.ProcessNotFound;
                                break;
                            }
                        }
                        
                        var result = await command.ExecuteAsync(context);

                        // Check if pause requested
                        if (result.Action == MacroCommandResultAction.Pause)
                        {
                            pauseEvent.Reset();
                        }

                        // Check if stop requested
                        if (result.Action == MacroCommandResultAction.Stop)
                        {
                            stopReason = MacroStopReason.Command;
                            break;
                        }

                        // Check if jump requested
                        if (result.Action == MacroCommandResultAction.Jump)
                        {
                            if (result.JumpIndex.HasValue)
                            {
                                nextCommandIndex = result.JumpIndex.Value;
                            }
                            else if (!string.IsNullOrWhiteSpace(result.JumpLabel) &&
                                     structureCache.Labels.TryGetValue(result.JumpLabel, out var labelIndex))
                            {
                                nextCommandIndex = labelIndex;
                            }
                        }

                        await Task.Yield();
                    }
                    catch (OperationCanceledException)
                    {
                        break;
                    }
                    catch (Exception ex)
                    {
                        stopReason = MacroStopReason.Error;
                        syncContext.Post(state => Exception?.Invoke(ex), null);
                        break;
                    }
                }

                // Check if the user stopped the macro
                if (cancellationTokenSource.IsCancellationRequested)
                {
                    stopReason = MacroStopReason.UserStopped;
                }

                StopReason = stopReason;
                SetState(MacroRunState.Stopped);
            });

            return executingTask;
        }

        public void Pause()
        {
            if (State != MacroRunState.Running)
            {
                return;
            }

            pauseEvent.Reset(); // Pause the macro
            SetState(MacroRunState.Paused);
        }

        public void Resume()
        {
            if (State != MacroRunState.Paused)
            {
                return;
            }
            
            debugStepEvent.Set();
            pauseEvent.Set(); // Resume the macro
            SetState(MacroRunState.Running);
        }

        public async Task StopAsync()
        {
            if (executingTask == null)
            {
                return;
            }

            cancellationTokenSource?.Cancel();
            await executingTask;
        }

        private void SetState(MacroRunState state)
        {
            if (state == State)
            {
                return;
            }

            State = state;
            syncContext.Post(_ => StateChanged?.Invoke(state), null);
        }

        private void UpdatePlayerState()
        {
            player.Name = reader.ReadCharacterName();

            player.MapName = reader.ReadMapName();
            player.MapId = reader.ReadMapId();
            player.MapX = reader.ReadMapX();
            player.MapY = reader.ReadMapY();

            player.MaxHealth = reader.ReadMaxHealth();
            player.MaxMana = reader.ReadMaxMana();

            player.CurrentHealth = reader.ReadCurrentHealth();
            player.CurrentMana = reader.ReadCurrentMana();

            lastUpdateTime = DateTime.Now;
        }

        ~MacroExecutor() => Dispose(false);

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool isDisposing)
        {
            if (isDisposed)
            {
                return;
            }

            if (isDisposing)
            {
                cancellationTokenSource?.Cancel();
                cancellationTokenSource?.Dispose();
                pauseEvent?.Dispose();
            }

            isDisposed = true;
        }
    }
}
