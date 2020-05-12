namespace Screensaver
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public partial class ScreenSelectorForm : Form
    {
        private Screen _selectedScreen = null;

        public ScreenSelectorForm()
        {
            this.InitializeComponent();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            base.Close();
        }


        private void selectScreenButton_Click(object sender, EventArgs e)
        {
            this._selectedScreen = Screen.FromControl(this);
            base.Close();
        }

        public Screen SelectedScreen
        {
            get
            {
                return this._selectedScreen;
            }
            set
            {
                this._selectedScreen = value;
            }
        }

        private void optionsButton_Click(object sender, EventArgs e)
        {
            OptionsForm mainForm = new OptionsForm();
            mainForm.ShowDialog();
        }
    }
}

