using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Properties;

namespace Screensaver
{
    public partial class OptionsForm : Form
    {

        public OptionsForm()
        {
            this.InitializeComponent();
            this.wdsRadioButton.Checked = Settings.Default.UseWDS;
            this.UpdateFontPreview();
        }

        private void aboutButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Coding 4 Fun - Photoshow screensaver");
        }

        private void acceptButton_Click(object sender, EventArgs e)
        {
            Settings.Default.Save();
            base.Close();
        }

        private void browseButton_Click(object sender, EventArgs e)
        {
            this.folderBrowserDialog1.SelectedPath = this.selectedPathTextBox.Text;
            if (this.folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                this.selectedPathTextBox.Text = this.folderBrowserDialog1.SelectedPath;
            }
        }

        private void fontBrowseButton_Click(object sender, EventArgs e)
        {
            this.captionFontDialog.Font = Settings.Default.CaptionFont;
            if (this.captionFontDialog.ShowDialog() == DialogResult.OK)
            {
                Settings.Default.CaptionFont = this.captionFontDialog.Font;
                this.UpdateFontPreview();
            }
        }



        private void radioButton_CheckedChanged(object sender, EventArgs e)
        {
            this.UpdateRadioSettings();
        }

        private void rejectButton_Click(object sender, EventArgs e)
        {
            base.Close();
        }

        private void UpdateFontPreview()
        {
            this.fontPreviewLabel.Font = Settings.Default.CaptionFont;
            this.fontPreviewLabel.Text = string.Format("{0}, {1}pt", Settings.Default.CaptionFont.Name, Settings.Default.CaptionFont.SizeInPoints);
        }

        private void UpdateRadioSettings()
        {
            if (!PhotoQueue.WDSInstalled)
            {
                this.folderRadioButton.Checked = true;
                this.wdsRadioButton.Enabled = false;
            }
            if (this.folderRadioButton.Checked)
            {
                Settings.Default.UseWDS = false;
                this.selectedPathTextBox.Enabled = true;
                this.subdirectoriesCheckbox.Enabled = true;
                this.watchChangesCheckBox.Enabled = true;
                this.browseButton.Enabled = true;
                this.wdsQueryTextBox.Enabled = false;
            }
            else
            {
                Settings.Default.UseWDS = true;
                this.selectedPathTextBox.Enabled = false;
                this.subdirectoriesCheckbox.Enabled = false;
                this.watchChangesCheckBox.Enabled = false;
                this.browseButton.Enabled = false;
                this.wdsQueryTextBox.Enabled = true;
            }
        }
    }
}

