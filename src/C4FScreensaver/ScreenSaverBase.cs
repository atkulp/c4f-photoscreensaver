namespace Screensaver
{
    using System;
    using System.Drawing;
    using System.Runtime.CompilerServices;

    public abstract class ScreenSaverBase
    {
        public abstract event EventHandler CurrentImageUpdated;

        protected ScreenSaverBase()
        {
        }

        public abstract Bitmap GetCurrentImage();
        public abstract void Init();
    }
}

