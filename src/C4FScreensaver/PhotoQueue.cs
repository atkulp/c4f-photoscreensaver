using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Diagnostics;
using System.IO;
using System.Text;
using Properties;

namespace Screensaver
{
    public class PhotoQueue
    {
        private string imageExtensions = "*.bmp;*.gif;*.png;*.jpg;*.jpeg";
        private int lastShownIndex = -1;
        private string myPictures;
        private List<PhotoInfo> photos;
        private Random rnd = new Random();
        private FileSystemWatcher watcher = null;
        private static OleDbConnection wdsConn;

        static PhotoQueue()
        {
            try
            {
                wdsConn = new OleDbConnection("Provider=Search.CollatorDSO;Extended Properties='Application=Windows';");
                wdsConn.Open();
            }
            catch
            {
                wdsConn = null;
                Debug.Print("WDS is probably not installed");
            }
        }

        public PhotoQueue()
        {
            if (Settings.Default.UseWDS && WDSInstalled)
            {
                this.InitFileListWDS();
            }
            else
            {
                this.InitFileList();
            }
            this.lastShownIndex = -1;
        }

        private static string ConvertUrlToPath(string url)
        {
            string str = url;
            if (url.StartsWith("otfs://"))
            {
                int index = url.IndexOf("}/");
                str = url.Substring(index + 2);
                int length = str.IndexOf("/");
                str = str.Substring(0, length) + ":" + str.Substring(length);
            }
            else if (url.StartsWith("file:"))
            {
                str = url.Substring(5);
            }
            return str.Replace('/', '\\');
        }

        public PhotoInfo GetNextImage()
        {
            lock (this.photos)
            {
                if (this.photos.Count == 0)
                {
                    return null;
                }
                if (this.lastShownIndex >= (this.photos.Count - 1))
                {
                    this.ShuffleFiles();
                    this.lastShownIndex = -1;
                }
                return this.photos[++this.lastShownIndex];
            }
        }

        private void InitFileList()
        {
            this.photos = new List<PhotoInfo>();
            this.myPictures = Settings.Default.PhotoPath;
            if (string.IsNullOrEmpty(this.myPictures) || !Directory.Exists(this.myPictures))
            {
                this.myPictures = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            }

            SearchOption topDirectoryOnly = SearchOption.TopDirectoryOnly;
            if (Settings.Default.ScanSubdirectories)
            {
                topDirectoryOnly = SearchOption.AllDirectories;
            }
            foreach (string str in this.imageExtensions.Split(new char[] { ';' }))
            {
                string[] strArray = Directory.GetFiles(this.myPictures, str, topDirectoryOnly);
                foreach (string str2 in strArray)
                {
                    this.photos.Add(new PhotoInfo(str2));
                }
            }
            this.ShuffleFiles();
            if (Settings.Default.WatchPhotoPath)
            {
                this.watcher = new FileSystemWatcher(this.myPictures, "*.*");
                this.watcher.IncludeSubdirectories = Settings.Default.ScanSubdirectories;
                this.watcher.Created += new FileSystemEventHandler(this.watcher_Triggered);
                this.watcher.Deleted += new FileSystemEventHandler(this.watcher_Triggered);
                this.watcher.EnableRaisingEvents = true;
            }
        }

        private void InitFileListWDS()
        {
            StringBuilder builder = new StringBuilder();
            if (!string.IsNullOrEmpty(Settings.Default.WDSQuery))
            {
                string[] strArray = Settings.Default.WDSQuery.Split(new char[] { ' ', ',', '|', ';' });
                foreach (string str in strArray)
                {
                    if (builder.Length > 0)
                    {
                        builder.Append(" OR ");
                    }
                    builder.AppendFormat(" CONTAINS(*, '\"{0}\"') ", str);
                }
            }
            string str2 = "select TOP 100 System.ItemUrl, System.Title  from systemindex where CONTAINS(System.Kind, 'picture') AND System.Size > 5000 AND System.Size < 2500000";
            if (builder.Length > 0)
            {
                str2 = string.Format("{0} AND ({1})", str2, builder.ToString());
            }
            OleDbCommand command = new OleDbCommand();
            command.Connection = wdsConn;
            command.CommandText = str2;
            OleDbDataReader reader = command.ExecuteReader();
            this.photos = new List<PhotoInfo>();
            while (reader.Read())
            {
                PhotoInfo item = new PhotoInfo(ConvertUrlToPath(reader.GetString(0)));
                if (!reader.IsDBNull(1))
                {
                    item.Caption = reader.GetString(1).Trim();
                }
                this.photos.Add(item);
            }
            reader.Close();
            this.ShuffleFiles();
        }

        private void ShuffleFiles()
        {
            lock (this.photos)
            {
                int num = 0;
                for (int i = 0; i < (this.photos.Count - 1); i++)
                {
                    while (num == i)
                    {
                        num = this.rnd.Next(0, this.photos.Count);
                    }
                    PhotoInfo info = this.photos[i];
                    this.photos[i] = this.photos[num];
                    this.photos[num] = info;
                    num = i + 1;
                }
            }
        }

        private void watcher_Triggered(object sender, FileSystemEventArgs e)
        {
            FileInfo info = new FileInfo(e.FullPath);
            if (this.imageExtensions.IndexOf(info.Extension.ToLower()) != -1)
            {
                List<PhotoInfo> list;
                if (e.ChangeType == WatcherChangeTypes.Created)
                {
                    PhotoInfo item = new PhotoInfo(e.FullPath);
                    lock ((list = this.photos))
                    {
                        this.photos.Insert(this.photos.Count, item);
                    }
                }
                else if (e.ChangeType == WatcherChangeTypes.Deleted)
                {
                    lock ((list = this.photos))
                    {
                        PhotoInfo info3 = null;
                        foreach (PhotoInfo info2 in this.photos)
                        {
                            if (info2.Filename == e.FullPath)
                            {
                                info3 = info2;
                                break;
                            }
                        }
                        if (info3 != null)
                        {
                            this.photos.Remove(info3);
                        }
                    }
                }
            }
        }

        public static bool WDSInstalled
        {
            get
            {
                return (wdsConn != null);
            }
        }
    }
}

