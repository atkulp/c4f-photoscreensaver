using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using Properties;

namespace Screensaver
{
    public partial class BaseScreenSaverForm : Form
    {
        private ScreenSaverBase _currentScreenSaver;
        private Screen _homeScreen;
        private Point mouseLocation;
        private EventHandler refreshHandler;

        public BaseScreenSaverForm(Screen homeScreen)
        {
            this.InitializeComponent();

            if (Program.RunningAsScreensaver)
            {
                base.KeyUp += new KeyEventHandler(this.BaseScreenSaverForm_KeyDown);
                base.MouseMove += new MouseEventHandler(this.BaseScreenSaverForm_MouseEvent);
                base.MouseDown += new MouseEventHandler(this.BaseScreenSaverForm_MouseEvent);
            }

            base.KeyDown += new KeyEventHandler(this.BaseScreenSaverForm_KeyDown);
            this._homeScreen = homeScreen;
            this.refreshHandler = new EventHandler(this.ScreenSaver_CurrentImageUpdated);
            this.SetupScreenSaver();
        }

        private void BaseScreenSaverForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (Program.RunningAsScreensaver || (e.KeyCode == Keys.Escape))
            {
                Application.Exit();
            }
        }

        private void BaseScreenSaverForm_MouseEvent(object sender, MouseEventArgs e)
        {
            if (!this.mouseLocation.IsEmpty)
            {
                if (this.mouseLocation != e.Location)
                {
                    Application.Exit();
                }
                if (e.Clicks > 0)
                {
                    Application.Exit();
                }
            }
            this.mouseLocation = e.Location;
        }

        public Bitmap GetBackgroundImage()
        {
            Bitmap image = null;
            Graphics graphics;
            Rectangle bounds = this._homeScreen.Bounds;
            if (Settings.Default.UseBackgroundColor)
            {
                image = new Bitmap(bounds.Width, bounds.Height, PixelFormat.Format32bppArgb);
                using (graphics = Graphics.FromImage(image))
                {
                    graphics.Clear(Settings.Default.BackgroundColor);
                }
                return image;
            }
            if (Settings.Default.UseBackgroundImage)
            {
                return PhotoInfo.ConstrainSize((Bitmap) Image.FromFile(Settings.Default.BackgroundImage), bounds.Width, bounds.Height, false);
            }
            image = new Bitmap(bounds.Width, bounds.Height, PixelFormat.Format32bppArgb);
            using (graphics = Graphics.FromImage(image))
            {
                graphics.CopyFromScreen(bounds.X, bounds.Y, 0, 0, bounds.Size, CopyPixelOperation.SourceCopy);
            }
            return image;
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            Bitmap currentImage = this._currentScreenSaver.GetCurrentImage();
            e.Graphics.DrawImage(currentImage, 0, 0, currentImage.Width, currentImage.Height);
        }

        private void ScreenSaver_CurrentImageUpdated(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(this.refreshHandler);
            }
            else
            {
                this.Refresh();
            }
        }

        private void SetupScreenSaver()
        {
            base.ControlBox = false;
            this.DoubleBuffered = true;
            base.FormBorderStyle = FormBorderStyle.None;
            base.ShowInTaskbar = false;
            base.TopMost = true;
            base.WindowState = FormWindowState.Normal;
            base.ShowIcon = false;
            base.StartPosition = FormStartPosition.Manual;
            base.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
            base.Capture = true;
            base.Bounds = this._homeScreen.Bounds;
            Cursor.Hide();
            if (Debugger.IsAttached)
            {
                base.Opacity = 0.8;
                base.TopMost = false;
            }
        }

        public ScreenSaverBase CurrentScreenSaver
        {
            get
            {
                return this._currentScreenSaver;
            }
            set
            {
                if (this._currentScreenSaver != null)
                {
                    this._currentScreenSaver.CurrentImageUpdated -= this.refreshHandler;
                }

                this._currentScreenSaver = value;

                if (this._currentScreenSaver != null)
                {
                    this._currentScreenSaver.CurrentImageUpdated += this.refreshHandler;
                }
            }
        }
    }
}

