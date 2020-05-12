namespace Screensaver
{
    partial class OptionsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.acceptButton = new System.Windows.Forms.Button();
            this.rejectButton = new System.Windows.Forms.Button();
            this.aboutButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.browseButton = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.captionFontDialog = new System.Windows.Forms.FontDialog();
            this.fontBrowseButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.fontPreviewLabel = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.wdsRadioButton = new System.Windows.Forms.RadioButton();
            this.folderRadioButton = new System.Windows.Forms.RadioButton();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.captionCheckBox = new System.Windows.Forms.CheckBox();
            this.watchChangesCheckBox = new System.Windows.Forms.CheckBox();
            this.wdsQueryTextBox = new System.Windows.Forms.TextBox();
            this.selectedPathTextBox = new System.Windows.Forms.TextBox();
            this.subdirectoriesCheckbox = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            base.SuspendLayout();
            //
            // acceptButton
            //
            this.acceptButton.Anchor = System.Windows.Forms.AnchorStyles.Right | System.Windows.Forms.AnchorStyles.Bottom;
            this.acceptButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.acceptButton.Location = new System.Drawing.Point(0x6d, 0x114);
            this.acceptButton.Name = "acceptButton";
            this.acceptButton.Size = new System.Drawing.Size(0x4b, 0x17);
            this.acceptButton.TabIndex = 0;
            this.acceptButton.Text = "&OK";
            this.acceptButton.UseVisualStyleBackColor = true;
            this.acceptButton.Click += new System.EventHandler(this.acceptButton_Click);
            //
            // rejectButton
            //
            this.rejectButton.Anchor = System.Windows.Forms.AnchorStyles.Right | System.Windows.Forms.AnchorStyles.Bottom;
            this.rejectButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.rejectButton.Location = new System.Drawing.Point(0xbf, 0x114);
            this.rejectButton.Name = "rejectButton";
            this.rejectButton.Size = new System.Drawing.Size(0x4b, 0x17);
            this.rejectButton.TabIndex = 1;
            this.rejectButton.Text = "&Cancel";
            this.rejectButton.UseVisualStyleBackColor = true;
            this.rejectButton.Click += new System.EventHandler(this.rejectButton_Click);
            //
            // aboutButton
            //
            this.aboutButton.Anchor = System.Windows.Forms.AnchorStyles.Right | System.Windows.Forms.AnchorStyles.Bottom;
            this.aboutButton.Location = new System.Drawing.Point(0x111, 0x114);
            this.aboutButton.Name = "aboutButton";
            this.aboutButton.Size = new System.Drawing.Size(0x4b, 0x17);
            this.aboutButton.TabIndex = 2;
            this.aboutButton.Text = "&About";
            this.aboutButton.UseVisualStyleBackColor = true;
            this.aboutButton.Click += new System.EventHandler(this.aboutButton_Click);
            //
            // label1
            //
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0x1d, 0x2d);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0x41, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Image folder";
            //
            // browseButton
            //
            this.browseButton.Anchor = System.Windows.Forms.AnchorStyles.Right | System.Windows.Forms.AnchorStyles.Top;
            this.browseButton.Location = new System.Drawing.Point(290, 40);
            this.browseButton.Name = "browseButton";
            this.browseButton.Size = new System.Drawing.Size(0x20, 0x17);
            this.browseButton.TabIndex = 5;
            this.browseButton.Text = "...";
            this.browseButton.UseVisualStyleBackColor = true;
            this.browseButton.Click += new System.EventHandler(this.browseButton_Click);
            //
            // fontBrowseButton
            //
            this.fontBrowseButton.Anchor = System.Windows.Forms.AnchorStyles.Right | System.Windows.Forms.AnchorStyles.Bottom;
            this.fontBrowseButton.Location = new System.Drawing.Point(0x126, 0x2f);
            this.fontBrowseButton.Name = "fontBrowseButton";
            this.fontBrowseButton.Size = new System.Drawing.Size(0x21, 0x17);
            this.fontBrowseButton.TabIndex = 7;
            this.fontBrowseButton.Text = "...";
            this.fontBrowseButton.UseVisualStyleBackColor = true;
            this.fontBrowseButton.Click += new System.EventHandler(this.fontBrowseButton_Click);
            //
            // label2
            //
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Bottom;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 0x35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0x40, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Caption font";
            //
            // fontPreviewLabel
            //
            this.fontPreviewLabel.Anchor = System.Windows.Forms.AnchorStyles.Right | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Bottom;
            this.fontPreviewLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.fontPreviewLabel.Location = new System.Drawing.Point(0x4f, 0x30);
            this.fontPreviewLabel.Name = "fontPreviewLabel";
            this.fontPreviewLabel.Size = new System.Drawing.Size(210, 0x29);
            this.fontPreviewLabel.TabIndex = 10;
            //
            // groupBox1
            //
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.Right | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Top;
            this.groupBox1.Controls.Add(this.watchChangesCheckBox);
            this.groupBox1.Controls.Add(this.wdsQueryTextBox);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.wdsRadioButton);
            this.groupBox1.Controls.Add(this.folderRadioButton);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.selectedPathTextBox);
            this.groupBox1.Controls.Add(this.browseButton);
            this.groupBox1.Controls.Add(this.subdirectoriesCheckbox);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(0x150, 0x94);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "How should photos be found?";
            //
            // label3
            //
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(0x20, 0x73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0x35, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Keywords";
            //
            // wdsRadioButton
            //
            this.wdsRadioButton.AutoSize = true;
            this.wdsRadioButton.Location = new System.Drawing.Point(13, 0x5b);
            this.wdsRadioButton.Name = "wdsRadioButton";
            this.wdsRadioButton.Size = new System.Drawing.Size(0x10a, 0x11);
            this.wdsRadioButton.TabIndex = 8;
            this.wdsRadioButton.Text = "Keyword search with Windows Search (if available)";
            this.wdsRadioButton.UseVisualStyleBackColor = true;
            //
            // folderRadioButton
            //
            this.folderRadioButton.AutoSize = true;
            this.folderRadioButton.Checked = true;
            this.folderRadioButton.Location = new System.Drawing.Point(13, 0x13);
            this.folderRadioButton.Name = "folderRadioButton";
            this.folderRadioButton.Size = new System.Drawing.Size(150, 0x11);
            this.folderRadioButton.TabIndex = 7;
            this.folderRadioButton.TabStop = true;
            this.folderRadioButton.Text = "All images in a given folder";
            this.folderRadioButton.UseVisualStyleBackColor = true;
            this.folderRadioButton.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            //
            // groupBox2
            //
            this.groupBox2.Anchor = System.Windows.Forms.AnchorStyles.Right | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Top;
            this.groupBox2.Controls.Add(this.captionCheckBox);
            this.groupBox2.Controls.Add(this.fontPreviewLabel);
            this.groupBox2.Controls.Add(this.fontBrowseButton);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(12, 0xa6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(0x150, 0x65);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Caption settings";
            //
            // captionCheckBox
            //
            this.captionCheckBox.AutoSize = true;
            this.captionCheckBox.Checked = Properties.Settings.Default.RenderCaption;
            this.captionCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.captionCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", Properties.Settings.Default, "RenderCaption", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.captionCheckBox.Location = new System.Drawing.Point(7, 0x13);
            this.captionCheckBox.Name = "captionCheckBox";
            this.captionCheckBox.Size = new System.Drawing.Size(0x68, 0x11);
            this.captionCheckBox.TabIndex = 11;
            this.captionCheckBox.Text = "Display caption?";
            this.captionCheckBox.UseVisualStyleBackColor = true;
            //
            // watchChangesCheckBox
            //
            this.watchChangesCheckBox.AutoSize = true;
            this.watchChangesCheckBox.Checked = Properties.Settings.Default.WatchPhotoPath;
            this.watchChangesCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.watchChangesCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", Properties.Settings.Default, "WatchPhotoPath", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.watchChangesCheckBox.Location = new System.Drawing.Point(0xcf, 0x44);
            this.watchChangesCheckBox.Name = "watchChangesCheckBox";
            this.watchChangesCheckBox.Size = new System.Drawing.Size(0x76, 0x11);
            this.watchChangesCheckBox.TabIndex = 11;
            this.watchChangesCheckBox.Text = "Watch for Changes";
            this.watchChangesCheckBox.UseVisualStyleBackColor = true;
            //
            // wdsQueryTextBox
            //
            this.wdsQueryTextBox.Anchor = System.Windows.Forms.AnchorStyles.Right | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Top;
            this.wdsQueryTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", Properties.Settings.Default, "WDSQuery", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.wdsQueryTextBox.Location = new System.Drawing.Point(0x62, 0x73);
            this.wdsQueryTextBox.Name = "wdsQueryTextBox";
            this.wdsQueryTextBox.Size = new System.Drawing.Size(0xe0, 20);
            this.wdsQueryTextBox.TabIndex = 10;
            this.wdsQueryTextBox.Text = Properties.Settings.Default.WDSQuery;
            //
            // toolTip1
            //
            this.toolTip1.SetToolTip(this.wdsQueryTextBox, "Enter keywords -- searches filename,  caption, keywords, etc.");
            //
            // selectedPathTextBox
            //
            this.selectedPathTextBox.Anchor = System.Windows.Forms.AnchorStyles.Right | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Top;
            this.selectedPathTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", Properties.Settings.Default, "PhotoPath", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.selectedPathTextBox.Location = new System.Drawing.Point(0x62, 0x2a);
            this.selectedPathTextBox.Name = "selectedPathTextBox";
            this.selectedPathTextBox.Size = new System.Drawing.Size(180, 20);
            this.selectedPathTextBox.TabIndex = 4;
            this.selectedPathTextBox.Text = Properties.Settings.Default.PhotoPath;
            // 
            // subdirectoriesCheckbox
            // 
            this.subdirectoriesCheckbox.AutoSize = true;
            this.subdirectoriesCheckbox.Checked = Properties.Settings.Default.ScanSubdirectories;
            this.subdirectoriesCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.subdirectoriesCheckbox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", Properties.Settings.Default, "ScanSubdirectories", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.subdirectoriesCheckbox.Location = new System.Drawing.Point(0x62, 0x44);
            this.subdirectoriesCheckbox.Name = "subdirectoriesCheckbox";
            this.subdirectoriesCheckbox.Size = new System.Drawing.Size(0x66, 0x11);
            this.subdirectoriesCheckbox.TabIndex = 6;
            this.subdirectoriesCheckbox.Text = "Scan subfolders";
            this.subdirectoriesCheckbox.UseVisualStyleBackColor = true;
            // 
            // OptionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(360, 0x137);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.aboutButton);
            this.Controls.Add(this.rejectButton);
            this.Controls.Add(this.acceptButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OptionsForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Coding 4 Fun Screensaver Settings";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            base.ResumeLayout(false);
        }
        
        #endregion

        private System.Windows.Forms.Button aboutButton;
        private System.Windows.Forms.Button acceptButton;
        private System.Windows.Forms.Button browseButton;
        private System.Windows.Forms.CheckBox captionCheckBox;
        private System.Windows.Forms.FontDialog captionFontDialog;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.RadioButton folderRadioButton;
        private System.Windows.Forms.Button fontBrowseButton;
        private System.Windows.Forms.Label fontPreviewLabel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button rejectButton;
        private System.Windows.Forms.TextBox selectedPathTextBox;
        private System.Windows.Forms.CheckBox subdirectoriesCheckbox;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.CheckBox watchChangesCheckBox;
        private System.Windows.Forms.TextBox wdsQueryTextBox;
        private System.Windows.Forms.RadioButton wdsRadioButton;
    }
}