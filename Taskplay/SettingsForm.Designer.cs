namespace Taskplay
{
    partial class SettingsForm
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
            System.Windows.Forms.TabPage tabPageSync;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.label1 = new System.Windows.Forms.Label();
            this.checkBoxPlaybackSync = new System.Windows.Forms.CheckBox();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPageGeneral = new System.Windows.Forms.TabPage();
            this.checkBoxShowNextButton = new System.Windows.Forms.CheckBox();
            this.checkBoxDarkMode = new System.Windows.Forms.CheckBox();
            this.checkBoxAutorun = new System.Windows.Forms.CheckBox();
            this.tabPageAbout = new System.Windows.Forms.TabPage();
            this.linkLabelGitHub = new System.Windows.Forms.LinkLabel();
            this.labelContribute = new System.Windows.Forms.Label();
            this.labelSuggestions = new System.Windows.Forms.Label();
            this.labelVersion = new System.Windows.Forms.Label();
            this.labelTaskplay = new System.Windows.Forms.Label();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOK = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.numericUpDownSyncInterval = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.numericUpDownWaitAfterClickSync = new System.Windows.Forms.NumericUpDown();
            this.checkBoxShowSongChangeButtonsWhilePaused = new System.Windows.Forms.CheckBox();
            this.checkBoxShowPrevSong = new System.Windows.Forms.CheckBox();
            tabPageSync = new System.Windows.Forms.TabPage();
            tabPageSync.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabPageGeneral.SuspendLayout();
            this.tabPageAbout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSyncInterval)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownWaitAfterClickSync)).BeginInit();
            this.SuspendLayout();
            // 
            // tabPageSync
            // 
            tabPageSync.Controls.Add(this.numericUpDownWaitAfterClickSync);
            tabPageSync.Controls.Add(this.label2);
            tabPageSync.Controls.Add(this.numericUpDownSyncInterval);
            tabPageSync.Controls.Add(this.label1);
            tabPageSync.Controls.Add(this.checkBoxPlaybackSync);
            tabPageSync.Location = new System.Drawing.Point(4, 32);
            tabPageSync.Name = "tabPageSync";
            tabPageSync.Padding = new System.Windows.Forms.Padding(3);
            tabPageSync.Size = new System.Drawing.Size(346, 404);
            tabPageSync.TabIndex = 2;
            tabPageSync.Text = "Sync";
            tabPageSync.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(189, 23);
            this.label1.TabIndex = 2;
            this.label1.Text = "Playback Check Interval";
            // 
            // checkBoxPlaybackSync
            // 
            this.checkBoxPlaybackSync.AutoSize = true;
            this.checkBoxPlaybackSync.Checked = true;
            this.checkBoxPlaybackSync.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxPlaybackSync.Location = new System.Drawing.Point(14, 15);
            this.checkBoxPlaybackSync.Name = "checkBoxPlaybackSync";
            this.checkBoxPlaybackSync.Size = new System.Drawing.Size(241, 27);
            this.checkBoxPlaybackSync.TabIndex = 0;
            this.checkBoxPlaybackSync.Text = "Enable Playback State Sync";
            this.checkBoxPlaybackSync.UseVisualStyleBackColor = true;
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Controls.Add(this.tabPageGeneral);
            this.tabControl.Controls.Add(tabPageSync);
            this.tabControl.Controls.Add(this.tabPageAbout);
            this.tabControl.Location = new System.Drawing.Point(6, 7);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(354, 440);
            this.tabControl.TabIndex = 0;
            // 
            // tabPageGeneral
            // 
            this.tabPageGeneral.Controls.Add(this.checkBoxShowPrevSong);
            this.tabPageGeneral.Controls.Add(this.checkBoxShowSongChangeButtonsWhilePaused);
            this.tabPageGeneral.Controls.Add(this.checkBoxShowNextButton);
            this.tabPageGeneral.Controls.Add(this.checkBoxDarkMode);
            this.tabPageGeneral.Controls.Add(this.checkBoxAutorun);
            this.tabPageGeneral.Location = new System.Drawing.Point(4, 32);
            this.tabPageGeneral.Name = "tabPageGeneral";
            this.tabPageGeneral.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageGeneral.Size = new System.Drawing.Size(346, 404);
            this.tabPageGeneral.TabIndex = 0;
            this.tabPageGeneral.Text = "General";
            this.tabPageGeneral.UseVisualStyleBackColor = true;
            // 
            // checkBoxShowNextButton
            // 
            this.checkBoxShowNextButton.AutoSize = true;
            this.checkBoxShowNextButton.Location = new System.Drawing.Point(6, 72);
            this.checkBoxShowNextButton.Name = "checkBoxShowNextButton";
            this.checkBoxShowNextButton.Size = new System.Drawing.Size(214, 27);
            this.checkBoxShowNextButton.TabIndex = 4;
            this.checkBoxShowNextButton.Text = "Show next song button";
            this.checkBoxShowNextButton.UseVisualStyleBackColor = true;
            // 
            // checkBoxDarkMode
            // 
            this.checkBoxDarkMode.AutoSize = true;
            this.checkBoxDarkMode.Location = new System.Drawing.Point(6, 39);
            this.checkBoxDarkMode.Name = "checkBoxDarkMode";
            this.checkBoxDarkMode.Size = new System.Drawing.Size(120, 27);
            this.checkBoxDarkMode.TabIndex = 1;
            this.checkBoxDarkMode.Text = "Dark mode";
            this.checkBoxDarkMode.UseVisualStyleBackColor = true;
            // 
            // checkBoxAutorun
            // 
            this.checkBoxAutorun.AutoSize = true;
            this.checkBoxAutorun.Location = new System.Drawing.Point(6, 6);
            this.checkBoxAutorun.Name = "checkBoxAutorun";
            this.checkBoxAutorun.Size = new System.Drawing.Size(249, 27);
            this.checkBoxAutorun.TabIndex = 0;
            this.checkBoxAutorun.Text = "Start Taskplay with Windows";
            this.checkBoxAutorun.UseVisualStyleBackColor = true;
            // 
            // tabPageAbout
            // 
            this.tabPageAbout.Controls.Add(this.linkLabelGitHub);
            this.tabPageAbout.Controls.Add(this.labelContribute);
            this.tabPageAbout.Controls.Add(this.labelSuggestions);
            this.tabPageAbout.Controls.Add(this.labelVersion);
            this.tabPageAbout.Controls.Add(this.labelTaskplay);
            this.tabPageAbout.Location = new System.Drawing.Point(4, 32);
            this.tabPageAbout.Name = "tabPageAbout";
            this.tabPageAbout.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageAbout.Size = new System.Drawing.Size(346, 404);
            this.tabPageAbout.TabIndex = 1;
            this.tabPageAbout.Text = "About";
            this.tabPageAbout.UseVisualStyleBackColor = true;
            // 
            // linkLabelGitHub
            // 
            this.linkLabelGitHub.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.linkLabelGitHub.AutoSize = true;
            this.linkLabelGitHub.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.linkLabelGitHub.Location = new System.Drawing.Point(214, 134);
            this.linkLabelGitHub.Name = "linkLabelGitHub";
            this.linkLabelGitHub.Size = new System.Drawing.Size(64, 23);
            this.linkLabelGitHub.TabIndex = 8;
            this.linkLabelGitHub.TabStop = true;
            this.linkLabelGitHub.Text = "GitHub";
            this.linkLabelGitHub.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelGitHub_LinkClicked);
            // 
            // labelContribute
            // 
            this.labelContribute.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelContribute.AutoSize = true;
            this.labelContribute.Location = new System.Drawing.Point(6, 134);
            this.labelContribute.Name = "labelContribute";
            this.labelContribute.Size = new System.Drawing.Size(318, 23);
            this.labelContribute.TabIndex = 7;
            this.labelContribute.Text = "Feel free to contribute to the project on ";
            // 
            // labelSuggestions
            // 
            this.labelSuggestions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelSuggestions.AutoSize = true;
            this.labelSuggestions.Location = new System.Drawing.Point(6, 117);
            this.labelSuggestions.Name = "labelSuggestions";
            this.labelSuggestions.Size = new System.Drawing.Size(268, 23);
            this.labelSuggestions.TabIndex = 5;
            this.labelSuggestions.Text = "Got a suggestion or found a bug?";
            // 
            // labelVersion
            // 
            this.labelVersion.AutoSize = true;
            this.labelVersion.Location = new System.Drawing.Point(6, 24);
            this.labelVersion.Name = "labelVersion";
            this.labelVersion.Size = new System.Drawing.Size(90, 23);
            this.labelVersion.TabIndex = 4;
            this.labelVersion.Text = "Version {0}";
            // 
            // labelTaskplay
            // 
            this.labelTaskplay.AutoSize = true;
            this.labelTaskplay.Location = new System.Drawing.Point(6, 7);
            this.labelTaskplay.Name = "labelTaskplay";
            this.labelTaskplay.Size = new System.Drawing.Size(72, 23);
            this.labelTaskplay.TabIndex = 2;
            this.labelTaskplay.Text = "Taskplay";
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(277, 453);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 2;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(196, 453);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 3;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // numericUpDownSyncInterval
            // 
            this.numericUpDownSyncInterval.Location = new System.Drawing.Point(256, 49);
            this.numericUpDownSyncInterval.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDownSyncInterval.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numericUpDownSyncInterval.Name = "numericUpDownSyncInterval";
            this.numericUpDownSyncInterval.Size = new System.Drawing.Size(86, 29);
            this.numericUpDownSyncInterval.TabIndex = 4;
            this.numericUpDownSyncInterval.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(240, 23);
            this.label2.TabIndex = 5;
            this.label2.Text = "Time To Pause Sync After Click";
            this.toolTip1.SetToolTip(this.label2, resources.GetString("label2.ToolTip"));
            // 
            // numericUpDownWaitAfterClickSync
            // 
            this.numericUpDownWaitAfterClickSync.Location = new System.Drawing.Point(256, 86);
            this.numericUpDownWaitAfterClickSync.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDownWaitAfterClickSync.Name = "numericUpDownWaitAfterClickSync";
            this.numericUpDownWaitAfterClickSync.Size = new System.Drawing.Size(84, 29);
            this.numericUpDownWaitAfterClickSync.TabIndex = 6;
            // 
            // checkBoxShowSongChangeButtonsWhilePaused
            // 
            this.checkBoxShowSongChangeButtonsWhilePaused.AutoSize = true;
            this.checkBoxShowSongChangeButtonsWhilePaused.Location = new System.Drawing.Point(8, 138);
            this.checkBoxShowSongChangeButtonsWhilePaused.Name = "checkBoxShowSongChangeButtonsWhilePaused";
            this.checkBoxShowSongChangeButtonsWhilePaused.Size = new System.Drawing.Size(342, 27);
            this.checkBoxShowSongChangeButtonsWhilePaused.TabIndex = 5;
            this.checkBoxShowSongChangeButtonsWhilePaused.Text = "Hide song change buttons while paused";
            this.checkBoxShowSongChangeButtonsWhilePaused.UseVisualStyleBackColor = true;
            // 
            // checkBoxShowPrevSong
            // 
            this.checkBoxShowPrevSong.AutoSize = true;
            this.checkBoxShowPrevSong.Location = new System.Drawing.Point(6, 105);
            this.checkBoxShowPrevSong.Name = "checkBoxShowPrevSong";
            this.checkBoxShowPrevSong.Size = new System.Drawing.Size(245, 27);
            this.checkBoxShowPrevSong.TabIndex = 6;
            this.checkBoxShowPrevSong.Text = "Show previous song button";
            this.checkBoxShowPrevSong.UseVisualStyleBackColor = true;
            // 
            // SettingsForm
            // 
            this.AcceptButton = this.buttonOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(364, 488);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.tabControl);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.Text = "Taskplay Settings";
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            tabPageSync.ResumeLayout(false);
            tabPageSync.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.tabPageGeneral.ResumeLayout(false);
            this.tabPageGeneral.PerformLayout();
            this.tabPageAbout.ResumeLayout(false);
            this.tabPageAbout.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSyncInterval)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownWaitAfterClickSync)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPageGeneral;
        private System.Windows.Forms.TabPage tabPageAbout;
        private System.Windows.Forms.CheckBox checkBoxAutorun;
        private System.Windows.Forms.Label labelTaskplay;
        private System.Windows.Forms.Label labelContribute;
        private System.Windows.Forms.Label labelSuggestions;
        private System.Windows.Forms.Label labelVersion;
        private System.Windows.Forms.LinkLabel linkLabelGitHub;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.CheckBox checkBoxDarkMode;
        private System.Windows.Forms.CheckBox checkBoxShowNextButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBoxPlaybackSync;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.NumericUpDown numericUpDownSyncInterval;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.NumericUpDown numericUpDownWaitAfterClickSync;
        private System.Windows.Forms.CheckBox checkBoxShowSongChangeButtonsWhilePaused;
        private System.Windows.Forms.CheckBox checkBoxShowPrevSong;
    }
}