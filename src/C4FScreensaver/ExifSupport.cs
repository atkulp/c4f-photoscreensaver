namespace Screensaver
{
    using System;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.Text;

    public class ExifSupport
    {
        public static long GetExifLong(PropertyItem prop)
        {
            if (prop.Type != 4)
            {
                throw new ArgumentException("Not an EXIF long value");
            }
            return (long) (((prop.Value[0] | (prop.Value[1] << 8)) | (prop.Value[2] << 0x10)) | (prop.Value[3] << 0x18));
        }

        public static long GetExifLong(Bitmap bmp, int id, long defaultValue)
        {
            try
            {
                return GetExifLong(bmp.GetPropertyItem(id));
            }
            catch
            {
                return defaultValue;
            }
        }

        public static short GetExifShort(PropertyItem prop)
        {
            if (prop.Type != 3)
            {
                throw new ArgumentException("Not an EXIF short value");
            }
            return (short) (prop.Value[0] | (prop.Value[1] << 8));
        }

        public static short GetExifShort(Bitmap bmp, int id, short defaultValue)
        {
            try
            {
                return GetExifShort(bmp.GetPropertyItem(id));
            }
            catch
            {
                return defaultValue;
            }
        }

        public static string GetExifString(PropertyItem prop)
        {
            if (prop.Type != 2)
            {
                throw new ArgumentException("Not an EXIF string value");
            }
            Encoding aSCII = Encoding.ASCII;
            if (prop.Value == null)
            {
                return null;
            }
            return aSCII.GetString(prop.Value, 0, prop.Value.Length - 1).Trim();
        }

        public static string GetExifString(Bitmap bmp, int id)
        {
            try
            {
                return GetExifString(bmp.GetPropertyItem(id));
            }
            catch
            {
                return null;
            }
        }

        public static object GetExifValue(PropertyItem prop)
        {
            switch (prop.Type)
            {
                case 2:
                    return GetExifString(prop);

                case 3:
                    return GetExifShort(prop);

                case 4:
                    return GetExifLong(prop);
            }
            return null;
        }

        public static object GetExifValue(Bitmap bmp, int id)
        {
            try
            {
                return GetExifValue(bmp.GetPropertyItem(id));
            }
            catch
            {
                return null;
            }
        }
    }
}

