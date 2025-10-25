using System;
using System.Windows.Forms;
using SleepHunter.Interop.Hotkey;
using SleepHunter.Models;

namespace SleepHunter.Forms
{
    public partial class MacroForm
    {
        private void hotkeyCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (hotkey == null)
            {
                return;
            }

            hotkey.Enabled = hotkeyCheckBox.Checked;
        }

        private void hotkeyTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            var modifiers = HotkeyModifiers.None;
            if (e.Shift)
            {
                modifiers |= HotkeyModifiers.Shift;
            }
            if (e.Alt)
            {
                modifiers |= HotkeyModifiers.Alt;
            }
            if (e.Control)
            {
                modifiers |= HotkeyModifiers.Control;
            }

            if (e.KeyCode == Keys.Escape && modifiers == HotkeyModifiers.None)
            {
                ClearHotkey();
                return;
            }

            if (e.KeyCode == Keys.LWin || e.KeyCode == Keys.RWin ||
                e.KeyCode == Keys.LShiftKey || e.KeyCode == Keys.RShiftKey || e.KeyCode == Keys.ShiftKey ||
                e.KeyCode == Keys.Alt ||
                e.KeyCode == Keys.LControlKey || e.KeyCode == Keys.RControlKey || e.KeyCode == Keys.ControlKey)
            {
                return;
            }

            var key = (VirtualKeys)e.KeyCode;
            SetHotkey(key, modifiers);

            e.SuppressKeyPress = true;
        }

        private void SetHotkey(VirtualKeys key, HotkeyModifiers modifiers = HotkeyModifiers.None)
        {
            if (hotkey == null)
            {

                hotkey = new GlobalHotkey(Handle, key, modifiers)
                {
                    Enabled = hotkeyCheckBox.Enabled
                };

                hotkey.HotkeyPressed += OnHotkeyPressed;
            }
            else
            {
                if (hotkey.Key != key || hotkey.Modifiers != modifiers)
                {
                    hotkey.Rebind(key, modifiers);
                }
            }

            hotkeyTextBox.Text = hotkey.ToString();
        }

        private void ClearHotkey()
        {
            if (hotkey != null)
            {
                hotkey.HotkeyPressed -= OnHotkeyPressed;
                hotkey.Dispose();
            }

            hotkey = null;
            hotkeyTextBox.Text = string.Empty;
        }

        protected override void WndProc(ref Message m)
        {
            if (hotkey?.ProcessMessage(m.Msg, m.WParam, m.LParam) == true)
            {
                return;
            }
            
            base.WndProc(ref m);
        }

        private void OnHotkeyPressed(object sender, EventArgs e)
        {
            // Ignore hotkeys when hotkey text box has focus, in case someone trying to set hotkeys
            if (hotkeyTextBox.Focused)
            {
                return;
            }

            if (IsPaused)
            {
                ResumeMacro();
            }
            else if (IsRunning)
            {
                StopMacro(MacroStopReason.UserStopped);
            }
            else
            {
                StartMacro();
            }
        }
    }
}