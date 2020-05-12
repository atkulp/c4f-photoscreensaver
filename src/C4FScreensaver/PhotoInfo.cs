namespace Screensaver
{
    using System;
    using System.Diagnostics;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Drawing.Imaging;
    using System.IO;
    using System.Text;
    using System.Xml;

    public class PhotoInfo
    {
        private string _caption;
        private string _filename;
        private WeakReference _sourceBitmap = new WeakReference(null);
        private WeakReference _workingBitmap = new WeakReference(null);

        public PhotoInfo(string filename)
        {
            this._filename = filename;
        }

        public static Bitmap ConstrainSize(Bitmap sourcePhoto, int width, int height, bool cropToFit)
        {
            int num = sourcePhoto.Width;
            int num2 = sourcePhoto.Height;
            int x = 0;
            int y = 0;
            float num5 = 0f;
            float num6 = 0f;
            float num7 = 0f;
            num6 = ((float) width) / ((float) num);
            num7 = ((float) height) / ((float) num2);
            if ((num7 > num6) && cropToFit)
            {
                num5 = num7;
                x = (short) ((width - (num * num5)) / 2f);
            }
            else
            {
                num5 = num6;
                y = (short) ((height - (num2 * num5)) / 2f);
            }
            int num8 = (int) (num * num5);
            int num9 = (int) (num2 * num5);
            Bitmap image = new Bitmap(width, height, PixelFormat.Format24bppRgb);
            using (Graphics graphics = Graphics.FromImage(image))
            {
                SetDrawingQuality(graphics);
                graphics.Clear(sourcePhoto.GetPixel(0, 0));
                graphics.DrawImage(sourcePhoto, new Rectangle(x, y, num8, num9), new Rectangle(0, 0, num, num2), GraphicsUnit.Pixel);
            }
            return image;
        }

        private void ExtractXMPProperties(string xmpXmlDoc)
        {
            XmlDocument document = new XmlDocument();
            try
            {
                document.LoadXml(xmpXmlDoc);
            }
            catch (Exception exception)
            {
                throw new ApplicationException("An error occured while loading XML metadata from image. The error was: " + exception.Message);
            }
            try
            {
                try
                {
                    document.LoadXml(xmpXmlDoc);
                    XmlNamespaceManager nsmgr = new XmlNamespaceManager(document.NameTable);
                    nsmgr.AddNamespace("rdf", "http://www.w3.org/1999/02/22-rdf-syntax-ns#");
                    nsmgr.AddNamespace("exif", "http://ns.adobe.com/exif/1.0/");
                    nsmgr.AddNamespace("x", "adobe:ns:meta/");
                    nsmgr.AddNamespace("xap", "http://ns.adobe.com/xap/1.0/");
                    nsmgr.AddNamespace("tiff", "http://ns.adobe.com/tiff/1.0/");
                    nsmgr.AddNamespace("dc", "http://purl.org/dc/elements/1.1/");
                    XmlNode node = document.SelectSingleNode("/rdf:RDF/rdf:Description/dc:title/rdf:Alt", nsmgr);
                    if (node == null)
                    {
                        node = document.SelectSingleNode("/rdf:RDF/rdf:Description/dc:description/rdf:Alt", nsmgr);
                    }
                    if (node != null)
                    {
                        this._caption = node.ChildNodes[0].InnerText;
                    }
                }
                catch
                {
                }
            }
            finally
            {
                document = null;
            }
        }

        private void GetPhotoCaption()
        {/*
            if (this._sourceBitmap.IsAlive)
            {
                Bitmap target = (Bitmap) this._sourceBitmap.Target;
                this._caption = ExifSupport.GetExifString(target, 800);
                if (string.IsNullOrEmpty(this._caption))
                {
                    this._caption = ExifSupport.GetExifString(target, 270);
                }
                if (string.IsNullOrEmpty(this._caption))
                {
                    this._caption = ExifSupport.GetExifString(target, 0x9c9b);
                }
                if (string.IsNullOrEmpty(this._caption))
                {
                    this._caption = ExifSupport.GetExifString(target, 0x9286);
                }
            }*/
            if (string.IsNullOrEmpty(this._caption))
            {
                int startIndex = this._filename.LastIndexOf(@"\") + 1;
                int num2 = this._filename.LastIndexOf(".");
                if (((startIndex > -1) && (startIndex < num2)) && (num2 > -1))
                {
                    this._caption = this._filename.Substring(startIndex, num2 - startIndex);
                }
            }
        }

        private Bitmap ReadImage()
        {
            FileStream stream = new FileInfo(this._filename).OpenRead();
            int length = (int) stream.Length;
            byte[] buffer = new byte[length];
            stream.Read(buffer, 0, length);
            stream.Close();
            MemoryStream stream2 = new MemoryStream(buffer);
            Bitmap bitmap = (Bitmap) Image.FromStream(stream2);
            stream2.Close();
            this._sourceBitmap.Target = bitmap;
            if (string.IsNullOrEmpty(this._caption))
            {
                Encoding unicode = Encoding.Unicode;
                this.ReadXMPCaption(unicode.GetString(buffer, 0, length));
            }
            return bitmap;
        }

        public void ReadXMPCaption(string fileData)
        {
            string str2 = "<rdf:RDF";
            string str3 = "</rdf:RDF>";
            int index = fileData.IndexOf(str2, 0);
            int num2 = fileData.IndexOf(str3, 0);
            if (((index != -1) && (num2 != -1)) && (index <= num2))
            {
                string xmpXmlDoc = fileData.Substring(index, (num2 - index) + str3.Length);
                this.ExtractXMPProperties(xmpXmlDoc);
            }
        }

        private void ReplaceBitmapWeakReference(WeakReference weakRef, Bitmap newBitmap)
        {
            if (weakRef.IsAlive)
            {
                ((Bitmap) weakRef.Target).Dispose();
            }
            weakRef.Target = newBitmap;
        }

        public static void SetDrawingQuality(Graphics g)
        {
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.CompositingQuality = CompositingQuality.HighQuality;
        }

        public string Caption
        {
            get
            {
                if (this._caption == null)
                {
                    this.GetPhotoCaption();
                }
                return this._caption;
            }
            set
            {
                this._caption = value;
            }
        }

        public string Filename
        {
            get
            {
                return this._filename;
            }
            set
            {
                this._filename = value;
            }
        }

        public Bitmap SourceBitmap
        {
            get
            {
                if (!this._sourceBitmap.IsAlive)
                {
                    try
                    {
                        return this.ReadImage();
                    }
                    catch (Exception exception)
                    {
                        if (Debugger.IsAttached)
                        {
                            Bitmap bitmap = new Bitmap(240, 240);
                            this._sourceBitmap.Target = bitmap;
                            using (Graphics graphics = Graphics.FromImage((Bitmap) this._sourceBitmap.Target))
                            {
                                graphics.Clear(Color.LightPink);
                                graphics.DrawString(this._filename, new Font("Times New Roman", 8f), Brushes.Black, (float) 0f, (float) 120f);
                                graphics.DrawString(exception.ToString(), new Font("Times New Roman", 8f), Brushes.Black, (float) 0f, (float) 130f);
                            }
                            return bitmap;
                        }
                        return null;
                    }
                }
                return (Bitmap) this._sourceBitmap.Target;
            }
            set
            {
                this.ReplaceBitmapWeakReference(this._sourceBitmap, value);
            }
        }

        public Bitmap WorkingBitmap
        {
            get
            {
                if (!this._workingBitmap.IsAlive)
                {
                    return null;
                }
                return (Bitmap) this._workingBitmap.Target;
            }
            set
            {
                this.ReplaceBitmapWeakReference(this._workingBitmap, value);
            }
        }
    }
}

