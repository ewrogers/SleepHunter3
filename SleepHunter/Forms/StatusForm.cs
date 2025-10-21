using SleepHunter.Interop;
using SleepHunter.Models;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace SleepHunter.Forms
{
    public partial class StatusForm : Form
    {
        private const int DefaultSegmentWidth = 3;
        private const int DefaultSegmentSpacing = 1;

        private static readonly Padding ProgressPadding = new Padding(1, 1, 1, 1);

        private static readonly Color HealthGradientStartColor = Color.FromArgb(0xFF, 0x64, 0x64); // #FF6464
        private static readonly Color HealthGradientEndColor = Color.FromArgb(0x96, 0, 0); // #960000
        private static readonly Color ManaGradientStartColor = Color.FromArgb(0x64, 0x64, 0xFF); // #6464FF
        private static readonly Color ManaGradientEndColor = Color.FromArgb(0, 0, 0x96); // #000096

        private readonly Pen highlightPen;
        private readonly Pen shadowPen;
        private readonly Brush progressBackgroundBrush;

        private GameClientReader clientReader;
        private PlayerState playerState;
        private bool isAttached;

        public StatusForm()
        {
            InitializeComponent();

            highlightPen = new Pen(SystemColors.ControlDark);
            shadowPen = new Pen(SystemColors.ControlDarkDark);

            progressBackgroundBrush = new SolidBrush(Color.White);
        }

        private void updateTimer_Tick(object sender, EventArgs e)
        {
            if (IsDisposed || clientReader == null || playerState == null)
            {
                Text = "Status Window";
                return;
            }

            try
            {
                playerState.Name = clientReader.ReadCharacterName();
                playerState.MapName = clientReader.ReadMapName();
                playerState.MapId = clientReader.ReadMapId();
                playerState.MapX = clientReader.ReadMapX();
                playerState.MapY = clientReader.ReadMapY();
                playerState.CurrentHealth = clientReader.ReadCurrentHealth();
                playerState.MaxHealth = clientReader.ReadMaxHealth();
                playerState.CurrentMana = clientReader.ReadCurrentMana();
                playerState.MaxMana = clientReader.ReadMaxMana();

            }
            catch (Exception)
            {
                Text += " (Invalid)";
                isAttached = false;
                updateTimer.Enabled = false;
            }

            UpdateUi();
        }

        private void UpdateUi()
        {
            if (playerState == null)
            {
                return;
            }

            if (!string.IsNullOrWhiteSpace(playerState.Name))
                Text = $"{playerState.Name} - Status";
            else
                Text = "Status Window";

            healthLabel.Text = $"{playerState.CurrentHealth} / {playerState.MaxHealth}";
            healthPercentLabel.Text = playerState.HealthPercentage + " %";
            manaLabel.Text = $"{playerState.CurrentMana} / {playerState.MaxMana}";
            manaPercentLabel.Text = playerState.ManaPercentage + " %";
            mapLabel.Text = $"{playerState.MapName} ({playerState.MapId})";
            mapXLabel.Text = playerState.MapX.ToString();
            mapYLabel.Text = playerState.MapY.ToString();

            // Force progress bars to redraw
            healthPictureBox.Refresh();
            manaPictureBox.Refresh();
        }

        private void healthPictureBox_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(Color.White);

            var clientRect = healthPictureBox.ClientRectangle;

            var currentHealth = playerState?.CurrentHealth ?? 0;
            var maxHealth = playerState?.MaxHealth ?? 0;

            DrawProgress(e.Graphics, clientRect, currentHealth, 0L, maxHealth,
                DefaultSegmentWidth, DefaultSegmentSpacing, false, ProgressPadding,
                HealthGradientStartColor, HealthGradientEndColor, LinearGradientMode.Vertical);

            DrawBorder(e.Graphics, clientRect, BorderStyle.Fixed3D);
        }

        private void manaPictureBox_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(Color.White);

            var clientRect = manaPictureBox.ClientRectangle;

            var currentMana = playerState?.CurrentMana ?? 0;
            var maxMana = playerState?.MaxMana ?? 0;

            DrawProgress(e.Graphics, clientRect, currentMana, 0L, maxMana,
                DefaultSegmentWidth, DefaultSegmentSpacing, false, ProgressPadding,
                ManaGradientStartColor, ManaGradientEndColor, LinearGradientMode.Vertical);

            DrawBorder(e.Graphics, clientRect, BorderStyle.Fixed3D);
        }

        private void DrawBorder(
          Graphics g,
          Rectangle clientRect,
          BorderStyle borderStyle)
        {
            clientRect.Inflate(-1, -1);
            clientRect.Offset(-1, -1);

            if (borderStyle.Equals(BorderStyle.None))
            {
                return;
            }

            var left = clientRect.Left;
            var top = clientRect.Top;
            var right = clientRect.Right;
            var bottom = clientRect.Bottom;

            g.DrawLine(shadowPen, left, top, right, top);

            if (borderStyle.Equals(BorderStyle.Fixed3D))
            {
                g.DrawLine(highlightPen, right, top, right, bottom);
                g.DrawLine(highlightPen, right, bottom, left, bottom);
            }
            else
            {
                g.DrawLine(shadowPen, right, top, right, bottom);
                g.DrawLine(shadowPen, right, bottom, left, bottom);
            }
            g.DrawLine(shadowPen, left, bottom, left, top);
        }

        private void DrawProgress(
          Graphics g,
          Rectangle clientRect,
          long value,
          long min,
          long max,
          int segmentWidth,
          int segmentSpacing,
          bool isSmoothFill,
          Padding padding,
          Color gradientColorA,
          Color gradientColorB,
          LinearGradientMode gradientMode)
        {
            if (value <= min)
            {
                return;
            }

            var ratio = (float)(value / Math.Max(1.0, max));
            if (ratio >= 1.0)
            {
                ratio = 1.0f;
            }

            var rect = new Rectangle(clientRect.X + 2 + padding.Left,
                clientRect.Y + 2 + padding.Top,
                (int)((double)(clientRect.Width - 5 - padding.Left - padding.Right) * ratio),
                clientRect.Height - 5 - (padding.Top + padding.Bottom));

            g.FillRectangle(new LinearGradientBrush(rect, gradientColorA, gradientColorB, gradientMode), rect);

            if (isSmoothFill)
            {
                return;
            }

            for (int index = 1; index < rect.Width / (segmentWidth + segmentSpacing) + 1; ++index)
            {
                g.FillRectangle(progressBackgroundBrush, rect.Left + index * segmentWidth + (index - 1) * segmentSpacing, rect.Top, segmentSpacing, rect.Height);
            }
        }

        private void form_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = e.Data.GetDataPresent(typeof(GameClientWindow)) 
                ? DragDropEffects.Copy 
                : DragDropEffects.None;
        }

        private void form_DragDrop(object sender, DragEventArgs e)
        {
            if (!e.Data.GetDataPresent(typeof(GameClientWindow)))
            {
                return;
            }

            clientReader?.Dispose();

            var gameClientWindow = (GameClientWindow)e.Data.GetData(typeof(GameClientWindow));

            try
            {
                clientReader = new GameClientReader(gameClientWindow.ProcessId);
                playerState = new PlayerState();
                isAttached = true;

                helpLabel.Visible = false;
                updateTimer.Enabled = true;
            }
            catch
            {
                updateTimer.Enabled = false;
                helpLabel.Visible = true;

                MessageBox.Show($"The process you have selected is invalid. (PID {gameClientWindow.ProcessId})", "Invalid Process,", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void form_Closed(object sender, FormClosedEventArgs e)
        {
            clientReader?.Dispose();

            highlightPen.Dispose();
            shadowPen.Dispose();
            progressBackgroundBrush.Dispose();
        }
    }
}