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

        private readonly Pen _highlightPen;
        private readonly Pen _shadowPen;
        private readonly Brush _progressBackgroundBrush;

        private GameClientReader _clientReader;
        private PlayerState _playerState;
        private bool _isAttached;

        public StatusForm()
        {
            InitializeComponent();

            _highlightPen = new Pen(SystemColors.ControlDark);
            _shadowPen = new Pen(SystemColors.ControlDarkDark);

            _progressBackgroundBrush = new SolidBrush(Color.White);
        }

        private void updateTimer_Tick(object sender, EventArgs e)
        {
            if (IsDisposed || _clientReader == null || _playerState == null)
            {
                Text = "Status Window";
                return;
            }

            try
            {
                _playerState.Name = _clientReader.ReadCharacterName();
                _playerState.MapName = _clientReader.ReadMapName();
                _playerState.MapId = _clientReader.ReadMapId();
                _playerState.MapX = _clientReader.ReadMapX();
                _playerState.MapY = _clientReader.ReadMapY();
                _playerState.CurrentHealth = _clientReader.ReadCurrentHealth();
                _playerState.MaxHealth = _clientReader.ReadMaxHealth();
                _playerState.CurrentMana = _clientReader.ReadCurrentMana();
                _playerState.MaxMana = _clientReader.ReadMaxMana();

            }
            catch (Exception)
            {
                Text = Text + " (Invalid)";
                _isAttached = false;
                updateTimer.Enabled = false;
            }

            UpdateUI();
        }

        private void UpdateUI()
        {
            if (_playerState == null)
            {
                return;
            }

            if (!string.IsNullOrWhiteSpace(_playerState.Name))
                Text = $"{_playerState.Name} - Status";
            else
                Text = "Status Window";

            healthLabel.Text = $"{_playerState.CurrentHealth} / {_playerState.MaxHealth}";
            healthPercentLabel.Text = _playerState.HealthPercentage + " %";
            manaLabel.Text = $"{_playerState.CurrentMana} / {_playerState.MaxMana}";
            manaPercentLabel.Text = _playerState.ManaPercentage + " %";
            mapLabel.Text = $"{_playerState.MapName} ({_playerState.MapId})";
            mapXLabel.Text = _playerState.MapX.ToString();
            mapYLabel.Text = _playerState.MapY.ToString();

            // Force progress bars to redraw
            healthPictureBox.Refresh();
            manaPictureBox.Refresh();
        }

        private void healthPictureBox_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(Color.White);

            var clientRect = healthPictureBox.ClientRectangle;

            var currentHealth = _playerState != null ? _playerState.CurrentHealth : 0;
            var maxHealth = _playerState != null ? _playerState.MaxHealth : 0;

            DrawProgress(e.Graphics, clientRect, currentHealth, 0L, maxHealth,
                DefaultSegmentWidth, DefaultSegmentSpacing, false, ProgressPadding,
                HealthGradientStartColor, HealthGradientEndColor, LinearGradientMode.Vertical);

            DrawBorder(e.Graphics, clientRect, BorderStyle.Fixed3D);
        }

        private void manaPictureBox_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(Color.White);

            var clientRect = manaPictureBox.ClientRectangle;

            var currentMana = _playerState != null ? _playerState.CurrentMana : 0;
            var maxMana = _playerState != null ? _playerState.MaxMana : 0;

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

            g.DrawLine(_shadowPen, left, top, right, top);

            if (borderStyle.Equals(BorderStyle.Fixed3D))
            {
                g.DrawLine(_highlightPen, right, top, right, bottom);
                g.DrawLine(_highlightPen, right, bottom, left, bottom);
            }
            else
            {
                g.DrawLine(_shadowPen, right, top, right, bottom);
                g.DrawLine(_shadowPen, right, bottom, left, bottom);
            }
            g.DrawLine(_shadowPen, left, bottom, left, top);
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
                g.FillRectangle(_progressBackgroundBrush, rect.Left + index * segmentWidth + (index - 1) * segmentSpacing, rect.Top, segmentSpacing, rect.Height);
            }
        }

        private void form_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(GameClientWindow)))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }

        private void form_DragDrop(object sender, DragEventArgs e)
        {
            if (!e.Data.GetDataPresent(typeof(GameClientWindow)))
            {
                return;
            }

            if (_clientReader != null)
            {
                _clientReader.Dispose();
            }

            var gameClientWindow = (GameClientWindow)e.Data.GetData(typeof(GameClientWindow));

            try
            {
                _clientReader = new GameClientReader(gameClientWindow.ProcessId);
                _playerState = new PlayerState();
                _isAttached = true;

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
            if (_clientReader != null)
            {
                _clientReader.Dispose();
            }

            _highlightPen.Dispose();
            _shadowPen.Dispose();
            _progressBackgroundBrush.Dispose();
        }
    }
}