    using System;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Runtime.CompilerServices;
    using System.Threading;
using Properties;

namespace Screensaver
{
    internal class PhotoshowScreenSaver : ScreenSaverBase
    {
        private Bitmap _desktopImage;
        private Bitmap _desktopPhotoPile;
        private PhotoQueue _photoSource;
        private Thread backroundThread;
        private StringFormat captionFormat = new StringFormat();
        private int delayInterval;
        private int imageBuffer = 20;
        private int imageHeight = 240;
        private int imageWidth = 240;
        private long lastResetTime;
        private int resetInterval;
        private Random rnd = new Random();
        private long shownTime;

        public override event EventHandler CurrentImageUpdated;

        public PhotoshowScreenSaver(Bitmap backgroundImage, PhotoQueue source)
        {
            this._desktopImage = backgroundImage;
            this._photoSource = source;
        }

        private void CreateSnapshotImage(PhotoInfo originalPhoto)
        {
            int height = (this.imageBuffer + this.imageHeight) + this.imageBuffer;
            int width = (this.imageBuffer + this.imageWidth) + this.imageBuffer;
            if (Settings.Default.RenderCaption)
            {
                height += this.imageBuffer * 3;
            }
            Bitmap bitmap = new Bitmap(width, height);
            Image image = PhotoInfo.ConstrainSize(originalPhoto.SourceBitmap, this.imageWidth, this.imageHeight, true);
            using (Graphics graphics = Graphics.FromImage(bitmap))
            {
                PhotoInfo.SetDrawingQuality(graphics);
                graphics.Clear(Color.FromArgb(240, 240, 240));
                graphics.DrawRectangle(new Pen(Brushes.Gray, 3f), 0, 0, bitmap.Width - 1, bitmap.Height - 1);
                switch (ExifSupport.GetExifShort(originalPhoto.SourceBitmap, 0x112, 1))
                {
                    case 3:
                        image.RotateFlip(RotateFlipType.Rotate180FlipNone);
                        break;

                    case 6:
                        image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                        break;

                    case 8:
                        image.RotateFlip(RotateFlipType.Rotate270FlipNone);
                        break;
                }
                graphics.DrawImage(image, this.imageBuffer, this.imageBuffer);
                graphics.DrawRectangle(Pens.LightGray, this.imageBuffer, this.imageBuffer, this.imageWidth - 1, this.imageHeight - 1);
                if (Settings.Default.RenderCaption)
                {
                    this.RenderCaption(originalPhoto, width, graphics);
                }
            }
            originalPhoto.SourceBitmap = null;
            originalPhoto.WorkingBitmap = bitmap;
        }

        private void DrawImageRotated(PhotoInfo photo)
        {
            int x = this.rnd.Next(this._desktopPhotoPile.Width - this.imageWidth);
            int y = this.rnd.Next(this._desktopPhotoPile.Height - this.imageHeight);
            float angle = this.rnd.Next(60) - 30;
            using (Graphics graphics = Graphics.FromImage(this._desktopPhotoPile))
            {
                PhotoInfo.SetDrawingQuality(graphics);
                graphics.RotateTransform(angle);
                CompositingMode compositingMode = graphics.CompositingMode;
                graphics.CompositingMode = CompositingMode.SourceOver;
                using (SolidBrush brush = new SolidBrush(Color.FromArgb(70, 30, 30, 30)))
                {
                    int i = 8;
                    //for (int i = 8; i > 0; i--)
                    {
                        graphics.FillRectangle(brush, (int) (x + i), (int) (y + i), (int) (photo.WorkingBitmap.Width - 1), (int) (photo.WorkingBitmap.Height - 1));
                    }
                }
                graphics.CompositingMode = compositingMode;
                graphics.DrawImageUnscaled(photo.WorkingBitmap, x, y);
            }
        }

        public override Bitmap GetCurrentImage()
        {
            return this._desktopPhotoPile;
        }

        public void ImageUpdater()
        {
            if (this.CurrentImageUpdated != null)
            {
                this.CurrentImageUpdated(this, null);
            }

            while (true)
            {
                using (Graphics graphics = Graphics.FromImage(this._desktopPhotoPile))
                {
                    if ((Environment.TickCount - this.lastResetTime) > this.resetInterval)
                    {
                        this._desktopPhotoPile = new Bitmap(this._desktopImage);
                        this.lastResetTime = Environment.TickCount;
                    }
                    PhotoInfo nextImage = this._photoSource.GetNextImage();
                    if (nextImage != null)
                    {
                        try
                        {
                            if (nextImage.WorkingBitmap == null)
                            {
                                this.CreateSnapshotImage(nextImage);
                            }
                            if (nextImage.WorkingBitmap != null)
                            {
                                this.DrawImageRotated(nextImage);
                                if (this.CurrentImageUpdated != null)
                                {
                                    this.CurrentImageUpdated(this, null);
                                }
                            }
                        }
                        catch
                        {
                        }
                    }
                }
                Thread.Sleep(this.delayInterval);
            }
        }

        public override void Init()
        {
            this.imageHeight = (int) (this._desktopImage.VerticalResolution * Settings.Default.ImageHeightInches);
            this.imageWidth = (int) (this._desktopImage.HorizontalResolution * Settings.Default.ImageWidthInches);
            this.imageBuffer = (int) (this.imageHeight * 0.08);
            this.captionFormat.Alignment = StringAlignment.Center;
            this.captionFormat.LineAlignment = StringAlignment.Center;
            this.captionFormat.Trimming = StringTrimming.EllipsisCharacter;
            this._desktopPhotoPile = new Bitmap(this._desktopImage);
            this.resetInterval = Settings.Default.ScreenClearInterval * 1000;
            this.delayInterval = Settings.Default.InterImageInterval * 1000;
            this.lastResetTime = Environment.TickCount;
            this.shownTime = Environment.TickCount;
            this.backroundThread = new Thread(new ThreadStart(this.ImageUpdater));
            this.backroundThread.IsBackground = true;
            this.backroundThread.Start();
        }

        private void RenderCaption(PhotoInfo originalPhoto, int trueImageWidth, Graphics g)
        {
            Font captionFont = Settings.Default.CaptionFont;
            Rectangle layoutRect = new Rectangle(2, this.imageHeight + (this.imageBuffer * 2), trueImageWidth - 4, (int) (this.imageBuffer * 2.5));
            GraphicsPath path = new GraphicsPath();
            path.AddString(originalPhoto.Caption, captionFont.FontFamily, (int) captionFont.Style, (float) captionFont.Height, layoutRect, this.captionFormat);
            g.FillPath(Brushes.Black, path);
        }
    }
}

