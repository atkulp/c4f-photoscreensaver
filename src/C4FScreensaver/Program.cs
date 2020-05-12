namespace Screensaver
{
    using System;
    using System.Windows.Forms;

    internal static class Program
    {
        private static bool _runningAsScreensaver;

        [STAThread]
        private static void Main(string[] args)
        {
            if (args.Length <= 0)
            {
                _runningAsScreensaver = Application.ExecutablePath.ToUpper().EndsWith(".SCR");
                if (RunningAsScreensaver)
                {
                    ShowScreenSaver();
                }
                else
                {
                    ShowDesktopApp();
                }
            }
            else
            {
                string str = args[0].ToLower().Trim().Substring(0, 2);
                switch (str)
                {
                    case "/c":
                        ShowOptions();
                        return;

                    case "/p":
                        return;

                    case "/d":
                        ShowDesktopApp();
                        return;

                    case "/s":
                        ShowScreenSaver();
                        return;
                }
                MessageBox.Show("Invalid command line argument :" + str, "Invalid Command Line Argument", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private static void ShowDesktopApp()
        {
            _runningAsScreensaver = false;

            Screen homeScreen = null;
            if (Screen.AllScreens.Length > 1)
            {
                ScreenSelectorForm form = new ScreenSelectorForm();
                if (form.ShowDialog() == DialogResult.OK)
                {
                    homeScreen = form.SelectedScreen;
                }
                else return;
            }
            else
            {
                homeScreen = Screen.PrimaryScreen;
            }

            if (homeScreen != null)
            {
                PhotoQueue source = new PhotoQueue();
                BaseScreenSaverForm mainForm = new BaseScreenSaverForm(homeScreen);
                ScreenSaverBase base2 = new PhotoshowScreenSaver(mainForm.GetBackgroundImage(), source);
                base2.Init();
                mainForm.CurrentScreenSaver = base2;
                Application.Run(mainForm);
            }
        }

        private static void ShowOptions()
        {
            OptionsForm mainForm = new OptionsForm();
            Application.Run(mainForm);
        }

        private static void ShowScreenSaver()
        {
            _runningAsScreensaver = true;
            PhotoQueue source = new PhotoQueue();
            foreach (Screen screen in Screen.AllScreens)
            {
                BaseScreenSaverForm form = new BaseScreenSaverForm(screen);
                ScreenSaverBase base2 = new PhotoshowScreenSaver(form.GetBackgroundImage(), source);
                base2.Init();
                form.CurrentScreenSaver = base2;
                form.Show();
            }
            Application.Run();
        }

        public static bool RunningAsScreensaver
        {
            get
            {
                return _runningAsScreensaver;
            }
        }
    }
}

