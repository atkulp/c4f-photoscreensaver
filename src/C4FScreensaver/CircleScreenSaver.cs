namespace Screensaver
{
    using System;
    using System.Drawing;
    using System.Runtime.CompilerServices;
    using System.Threading;

    internal class CircleScreenSaver : ScreenSaverBase
    {
        private Bitmap _displayImage;
        private Bitmap _workingImage;
        private Thread backgroundThread = null;
        private long lastResetTime;
        private long resetInterval = 0x4e20L;
        private Random rnd = new Random();
        private long shownTime;

        public override event EventHandler CurrentImageUpdated;

        public CircleScreenSaver(Bitmap backgroundImage)
        {
            this._displayImage = backgroundImage;
        }

        public override Bitmap GetCurrentImage()
        {
            return this._workingImage;
        }

        public void ImageUpdater()
        {
            while (true)
            {
                if ((Environment.TickCount - this.lastResetTime) > this.resetInterval)
                {
                    this._workingImage = new Bitmap(this._displayImage);
                    this.lastResetTime = Environment.TickCount;
                }
                this.UpdateWorkingImageBubbles();
                if (this.CurrentImageUpdated != null)
                {
                    this.CurrentImageUpdated(this, null);
                }
                Thread.Sleep(0x3e8);
            }
        }

        public override void Init()
        {
            this._workingImage = new Bitmap(this._displayImage);
            this.lastResetTime = Environment.TickCount;
            this.shownTime = Environment.TickCount;
            this.backgroundThread = new Thread(new ThreadStart(this.ImageUpdater));
            this.backgroundThread.IsBackground = true;
            this.backgroundThread.Start();
        }

        private void UpdateWorkingImageBubbles()
        {
            using (Graphics graphics = Graphics.FromImage(this._workingImage))
            {
                int width = this.rnd.Next(200);
                int x = this.rnd.Next(this._workingImage.Width - width);
                int y = this.rnd.Next(this._workingImage.Height - width);
                using (Brush brush = new SolidBrush(Color.FromArgb(0x80, this.rnd.Next(0xff), this.rnd.Next(0xff), this.rnd.Next(0xff))))
                {
                    graphics.FillEllipse(brush, x, y, width, width);
                }
            }
        }
    }
}

