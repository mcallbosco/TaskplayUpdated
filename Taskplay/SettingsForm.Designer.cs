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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.metroTabControl1 = new MetroFramework.Controls.MetroTabControl();
            this.metroTabPage1 = new MetroFramework.Controls.MetroTabPage();
            this.checkBoxShowSongChangeButtonsWhilePaused = new MetroFramework.Controls.MetroCheckBox();
            this.checkBoxShowPrevSong = new MetroFramework.Controls.MetroCheckBox();
            this.checkBoxDarkMode = new MetroFramework.Controls.MetroCheckBox();
            this.checkBoxShowNextButton = new MetroFramework.Controls.MetroCheckBox();
            this.checkBoxAutorun = new MetroFramework.Controls.MetroCheckBox();
            this.metroStyleManager1 = new MetroFramework.Components.MetroStyleManager();
            this.metroTabPage2 = new MetroFramework.Controls.MetroTabPage();
            this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.checkBoxPlaybackSync = new MetroFramework.Controls.MetroCheckBox();
            this.numericUpDownWaitAfterClickSync = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownSyncInterval = new System.Windows.Forms.NumericUpDown();
            this.metroTabPage3 = new MetroFramework.Controls.MetroTabPage();
            this.metroLink1 = new MetroFramework.Controls.MetroLink();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.labelVersion = new MetroFramework.Controls.MetroLabel();
            this.labelContribute = new System.Windows.Forms.Label();
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            this.metroButton2 = new MetroFramework.Controls.MetroButton();
            this.metroTabControl1.SuspendLayout();
            this.metroTabPage1.SuspendLayout();
            this.metroTabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownWaitAfterClickSync)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSyncInterval)).BeginInit();
            this.metroTabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // metroTabControl1
            // 
            this.metroTabControl1.Controls.Add(this.metroTabPage1);
            this.metroTabControl1.Controls.Add(this.metroTabPage2);
            this.metroTabControl1.Controls.Add(this.metroTabPage3);
            this.metroTabControl1.CustomBackground = false;
            this.metroTabControl1.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.metroTabControl1.FontSize = MetroFramework.MetroTabControlSize.Medium;
            this.metroTabControl1.FontWeight = MetroFramework.MetroTabControlWeight.Light;
            this.metroTabControl1.Location = new System.Drawing.Point(12, 12);
            this.metroTabControl1.Name = "metroTabControl1";
            this.metroTabControl1.SelectedIndex = 2;
            this.metroTabControl1.Size = new System.Drawing.Size(336, 411);
            this.metroTabControl1.Style = MetroFramework.MetroColorStyle.Red;
            this.metroTabControl1.StyleManager = this.metroStyleManager1;
            this.metroTabControl1.TabIndex = 4;
            this.metroTabControl1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.metroTabControl1.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroTabControl1.UseStyleColors = false;
            // 
            // metroTabPage1
            // 
            this.metroTabPage1.Controls.Add(this.checkBoxShowSongChangeButtonsWhilePaused);
            this.metroTabPage1.Controls.Add(this.checkBoxShowPrevSong);
            this.metroTabPage1.Controls.Add(this.checkBoxDarkMode);
            this.metroTabPage1.Controls.Add(this.checkBoxShowNextButton);
            this.metroTabPage1.Controls.Add(this.checkBoxAutorun);
            this.metroTabPage1.CustomBackground = false;
            this.metroTabPage1.HorizontalScrollbar = false;
            this.metroTabPage1.HorizontalScrollbarBarColor = true;
            this.metroTabPage1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroTabPage1.HorizontalScrollbarSize = 10;
            this.metroTabPage1.Location = new System.Drawing.Point(4, 39);
            this.metroTabPage1.Name = "metroTabPage1";
            this.metroTabPage1.Size = new System.Drawing.Size(328, 368);
            this.metroTabPage1.Style = MetroFramework.MetroColorStyle.Red;
            this.metroTabPage1.StyleManager = this.metroStyleManager1;
            this.metroTabPage1.TabIndex = 0;
            this.metroTabPage1.Text = "General";
            this.metroTabPage1.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroTabPage1.VerticalScrollbar = false;
            this.metroTabPage1.VerticalScrollbarBarColor = true;
            this.metroTabPage1.VerticalScrollbarHighlightOnWheel = false;
            this.metroTabPage1.VerticalScrollbarSize = 10;
            // 
            // checkBoxShowSongChangeButtonsWhilePaused
            // 
            this.checkBoxShowSongChangeButtonsWhilePaused.AutoSize = true;
            this.checkBoxShowSongChangeButtonsWhilePaused.CustomBackground = false;
            this.checkBoxShowSongChangeButtonsWhilePaused.FontSize = MetroFramework.MetroLinkSize.Small;
            this.checkBoxShowSongChangeButtonsWhilePaused.FontWeight = MetroFramework.MetroLinkWeight.Regular;
            this.checkBoxShowSongChangeButtonsWhilePaused.Location = new System.Drawing.Point(4, 112);
            this.checkBoxShowSongChangeButtonsWhilePaused.Name = "checkBoxShowSongChangeButtonsWhilePaused";
            this.checkBoxShowSongChangeButtonsWhilePaused.Size = new System.Drawing.Size(235, 15);
            this.checkBoxShowSongChangeButtonsWhilePaused.Style = MetroFramework.MetroColorStyle.Blue;
            this.checkBoxShowSongChangeButtonsWhilePaused.StyleManager = null;
            this.checkBoxShowSongChangeButtonsWhilePaused.TabIndex = 16;
            this.checkBoxShowSongChangeButtonsWhilePaused.Text = "Hide song change buttons while paused";
            this.checkBoxShowSongChangeButtonsWhilePaused.Theme = MetroFramework.MetroThemeStyle.Light;
            this.checkBoxShowSongChangeButtonsWhilePaused.UseStyleColors = false;
            this.checkBoxShowSongChangeButtonsWhilePaused.UseVisualStyleBackColor = true;
            // 
            // checkBoxShowPrevSong
            // 
            this.checkBoxShowPrevSong.AutoSize = true;
            this.checkBoxShowPrevSong.CustomBackground = false;
            this.checkBoxShowPrevSong.FontSize = MetroFramework.MetroLinkSize.Small;
            this.checkBoxShowPrevSong.FontWeight = MetroFramework.MetroLinkWeight.Regular;
            this.checkBoxShowPrevSong.Location = new System.Drawing.Point(4, 91);
            this.checkBoxShowPrevSong.Name = "checkBoxShowPrevSong";
            this.checkBoxShowPrevSong.Size = new System.Drawing.Size(168, 15);
            this.checkBoxShowPrevSong.Style = MetroFramework.MetroColorStyle.Blue;
            this.checkBoxShowPrevSong.StyleManager = null;
            this.checkBoxShowPrevSong.TabIndex = 15;
            this.checkBoxShowPrevSong.Text = "Show previous song button";
            this.checkBoxShowPrevSong.Theme = MetroFramework.MetroThemeStyle.Light;
            this.checkBoxShowPrevSong.UseStyleColors = false;
            this.checkBoxShowPrevSong.UseVisualStyleBackColor = true;
            this.checkBoxShowPrevSong.CheckedChanged += new System.EventHandler(this.metroCheckBox3_CheckedChanged);
            // 
            // checkBoxDarkMode
            // 
            this.checkBoxDarkMode.AutoSize = true;
            this.checkBoxDarkMode.CustomBackground = false;
            this.checkBoxDarkMode.FontSize = MetroFramework.MetroLinkSize.Small;
            this.checkBoxDarkMode.FontWeight = MetroFramework.MetroLinkWeight.Regular;
            this.checkBoxDarkMode.Location = new System.Drawing.Point(4, 49);
            this.checkBoxDarkMode.Name = "checkBoxDarkMode";
            this.checkBoxDarkMode.Size = new System.Drawing.Size(120, 15);
            this.checkBoxDarkMode.Style = MetroFramework.MetroColorStyle.Blue;
            this.checkBoxDarkMode.StyleManager = null;
            this.checkBoxDarkMode.TabIndex = 14;
            this.checkBoxDarkMode.Text = "Dark Taskbar Icons";
            this.checkBoxDarkMode.Theme = MetroFramework.MetroThemeStyle.Light;
            this.checkBoxDarkMode.UseStyleColors = false;
            this.checkBoxDarkMode.UseVisualStyleBackColor = true;
            // 
            // checkBoxShowNextButton
            // 
            this.checkBoxShowNextButton.AutoSize = true;
            this.checkBoxShowNextButton.CustomBackground = false;
            this.checkBoxShowNextButton.FontSize = MetroFramework.MetroLinkSize.Small;
            this.checkBoxShowNextButton.FontWeight = MetroFramework.MetroLinkWeight.Regular;
            this.checkBoxShowNextButton.Location = new System.Drawing.Point(4, 70);
            this.checkBoxShowNextButton.Name = "checkBoxShowNextButton";
            this.checkBoxShowNextButton.Size = new System.Drawing.Size(146, 15);
            this.checkBoxShowNextButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.checkBoxShowNextButton.StyleManager = null;
            this.checkBoxShowNextButton.TabIndex = 13;
            this.checkBoxShowNextButton.Text = "Show next song button";
            this.checkBoxShowNextButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.checkBoxShowNextButton.UseStyleColors = false;
            this.checkBoxShowNextButton.UseVisualStyleBackColor = true;
            // 
            // checkBoxAutorun
            // 
            this.checkBoxAutorun.AutoSize = true;
            this.checkBoxAutorun.CustomBackground = false;
            this.checkBoxAutorun.FontSize = MetroFramework.MetroLinkSize.Small;
            this.checkBoxAutorun.FontWeight = MetroFramework.MetroLinkWeight.Regular;
            this.checkBoxAutorun.Location = new System.Drawing.Point(4, 28);
            this.checkBoxAutorun.Name = "checkBoxAutorun";
            this.checkBoxAutorun.Size = new System.Drawing.Size(172, 15);
            this.checkBoxAutorun.Style = MetroFramework.MetroColorStyle.Blue;
            this.checkBoxAutorun.StyleManager = null;
            this.checkBoxAutorun.TabIndex = 12;
            this.checkBoxAutorun.Text = "Start Taskplay with Windows";
            this.checkBoxAutorun.Theme = MetroFramework.MetroThemeStyle.Light;
            this.checkBoxAutorun.UseStyleColors = false;
            this.checkBoxAutorun.UseVisualStyleBackColor = true;
            // 
            // metroStyleManager1
            // 
            this.metroStyleManager1.OwnerForm = this;
            this.metroStyleManager1.Style = MetroFramework.MetroColorStyle.Red;
            this.metroStyleManager1.Theme = MetroFramework.MetroThemeStyle.Light;
            // 
            // metroTabPage2
            // 
            this.metroTabPage2.Controls.Add(this.metroLabel5);
            this.metroTabPage2.Controls.Add(this.metroLabel4);
            this.metroTabPage2.Controls.Add(this.checkBoxPlaybackSync);
            this.metroTabPage2.Controls.Add(this.numericUpDownWaitAfterClickSync);
            this.metroTabPage2.Controls.Add(this.numericUpDownSyncInterval);
            this.metroTabPage2.CustomBackground = false;
            this.metroTabPage2.HorizontalScrollbar = false;
            this.metroTabPage2.HorizontalScrollbarBarColor = true;
            this.metroTabPage2.HorizontalScrollbarHighlightOnWheel = false;
            this.metroTabPage2.HorizontalScrollbarSize = 10;
            this.metroTabPage2.Location = new System.Drawing.Point(4, 39);
            this.metroTabPage2.Name = "metroTabPage2";
            this.metroTabPage2.Size = new System.Drawing.Size(328, 368);
            this.metroTabPage2.Style = MetroFramework.MetroColorStyle.Red;
            this.metroTabPage2.StyleManager = this.metroStyleManager1;
            this.metroTabPage2.TabIndex = 1;
            this.metroTabPage2.Text = "Sync";
            this.metroTabPage2.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroTabPage2.VerticalScrollbar = false;
            this.metroTabPage2.VerticalScrollbarBarColor = true;
            this.metroTabPage2.VerticalScrollbarHighlightOnWheel = false;
            this.metroTabPage2.VerticalScrollbarSize = 10;
            // 
            // metroLabel5
            // 
            this.metroLabel5.AutoSize = true;
            this.metroLabel5.CustomBackground = false;
            this.metroLabel5.FontSize = MetroFramework.MetroLabelSize.Medium;
            this.metroLabel5.FontWeight = MetroFramework.MetroLabelWeight.Light;
            this.metroLabel5.LabelMode = MetroFramework.Controls.MetroLabelMode.Default;
            this.metroLabel5.Location = new System.Drawing.Point(-4, 89);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(186, 19);
            this.metroLabel5.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroLabel5.StyleManager = null;
            this.metroLabel5.TabIndex = 16;
            this.metroLabel5.Text = "Time To Pause Sync After Click";
            this.metroLabel5.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroLabel5.UseStyleColors = false;
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.CustomBackground = false;
            this.metroLabel4.FontSize = MetroFramework.MetroLabelSize.Medium;
            this.metroLabel4.FontWeight = MetroFramework.MetroLabelWeight.Light;
            this.metroLabel4.LabelMode = MetroFramework.Controls.MetroLabelMode.Default;
            this.metroLabel4.Location = new System.Drawing.Point(-4, 53);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(146, 19);
            this.metroLabel4.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroLabel4.StyleManager = null;
            this.metroLabel4.TabIndex = 15;
            this.metroLabel4.Text = "Playback Check Interval";
            this.metroLabel4.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroLabel4.UseStyleColors = false;
            // 
            // checkBoxPlaybackSync
            // 
            this.checkBoxPlaybackSync.AutoSize = true;
            this.checkBoxPlaybackSync.CustomBackground = false;
            this.checkBoxPlaybackSync.FontSize = MetroFramework.MetroLinkSize.Small;
            this.checkBoxPlaybackSync.FontWeight = MetroFramework.MetroLinkWeight.Regular;
            this.checkBoxPlaybackSync.Location = new System.Drawing.Point(0, 24);
            this.checkBoxPlaybackSync.Name = "checkBoxPlaybackSync";
            this.checkBoxPlaybackSync.Size = new System.Drawing.Size(165, 15);
            this.checkBoxPlaybackSync.Style = MetroFramework.MetroColorStyle.Blue;
            this.checkBoxPlaybackSync.StyleManager = null;
            this.checkBoxPlaybackSync.TabIndex = 12;
            this.checkBoxPlaybackSync.Text = "Enable Playback State Sync";
            this.checkBoxPlaybackSync.Theme = MetroFramework.MetroThemeStyle.Light;
            this.checkBoxPlaybackSync.UseStyleColors = false;
            this.checkBoxPlaybackSync.UseVisualStyleBackColor = true;
            // 
            // numericUpDownWaitAfterClickSync
            // 
            this.numericUpDownWaitAfterClickSync.Location = new System.Drawing.Point(244, 79);
            this.numericUpDownWaitAfterClickSync.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDownWaitAfterClickSync.Name = "numericUpDownWaitAfterClickSync";
            this.numericUpDownWaitAfterClickSync.Size = new System.Drawing.Size(84, 29);
            this.numericUpDownWaitAfterClickSync.TabIndex = 11;
            // 
            // numericUpDownSyncInterval
            // 
            this.numericUpDownSyncInterval.Location = new System.Drawing.Point(242, 43);
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
            this.numericUpDownSyncInterval.TabIndex = 9;
            this.numericUpDownSyncInterval.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // metroTabPage3
            // 
            this.metroTabPage3.Controls.Add(this.metroLink1);
            this.metroTabPage3.Controls.Add(this.metroLabel3);
            this.metroTabPage3.Controls.Add(this.metroLabel2);
            this.metroTabPage3.Controls.Add(this.metroLabel1);
            this.metroTabPage3.Controls.Add(this.labelVersion);
            this.metroTabPage3.Controls.Add(this.labelContribute);
            this.metroTabPage3.CustomBackground = false;
            this.metroTabPage3.HorizontalScrollbar = false;
            this.metroTabPage3.HorizontalScrollbarBarColor = true;
            this.metroTabPage3.HorizontalScrollbarHighlightOnWheel = false;
            this.metroTabPage3.HorizontalScrollbarSize = 10;
            this.metroTabPage3.Location = new System.Drawing.Point(4, 39);
            this.metroTabPage3.Name = "metroTabPage3";
            this.metroTabPage3.Size = new System.Drawing.Size(328, 368);
            this.metroTabPage3.Style = MetroFramework.MetroColorStyle.Red;
            this.metroTabPage3.StyleManager = this.metroStyleManager1;
            this.metroTabPage3.TabIndex = 2;
            this.metroTabPage3.Text = "About";
            this.metroTabPage3.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroTabPage3.VerticalScrollbar = false;
            this.metroTabPage3.VerticalScrollbarBarColor = true;
            this.metroTabPage3.VerticalScrollbarHighlightOnWheel = false;
            this.metroTabPage3.VerticalScrollbarSize = 10;
            // 
            // metroLink1
            // 
            this.metroLink1.CustomBackground = false;
            this.metroLink1.FontSize = MetroFramework.MetroLinkSize.Small;
            this.metroLink1.FontWeight = MetroFramework.MetroLinkWeight.Bold;
            this.metroLink1.Location = new System.Drawing.Point(11, 143);
            this.metroLink1.Name = "metroLink1";
            this.metroLink1.Size = new System.Drawing.Size(75, 23);
            this.metroLink1.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroLink1.StyleManager = null;
            this.metroLink1.TabIndex = 18;
            this.metroLink1.Text = "GitHub";
            this.metroLink1.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroLink1.UseStyleColors = false;
            this.metroLink1.Click += new System.EventHandler(this.metroLink1_Click);
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.CustomBackground = false;
            this.metroLabel3.FontSize = MetroFramework.MetroLabelSize.Medium;
            this.metroLabel3.FontWeight = MetroFramework.MetroLabelWeight.Light;
            this.metroLabel3.LabelMode = MetroFramework.Controls.MetroLabelMode.Default;
            this.metroLabel3.Location = new System.Drawing.Point(9, 121);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(222, 19);
            this.metroLabel3.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroLabel3.StyleManager = null;
            this.metroLabel3.TabIndex = 17;
            this.metroLabel3.Text = "Feel free to contribute to the project";
            this.metroLabel3.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroLabel3.UseStyleColors = false;
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.CustomBackground = false;
            this.metroLabel2.FontSize = MetroFramework.MetroLabelSize.Medium;
            this.metroLabel2.FontWeight = MetroFramework.MetroLabelWeight.Light;
            this.metroLabel2.LabelMode = MetroFramework.Controls.MetroLabelMode.Default;
            this.metroLabel2.Location = new System.Drawing.Point(9, 98);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(206, 19);
            this.metroLabel2.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroLabel2.StyleManager = null;
            this.metroLabel2.TabIndex = 16;
            this.metroLabel2.Text = "Got a suggestion or found a bug?";
            this.metroLabel2.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroLabel2.UseStyleColors = false;
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.CustomBackground = false;
            this.metroLabel1.FontSize = MetroFramework.MetroLabelSize.Medium;
            this.metroLabel1.FontWeight = MetroFramework.MetroLabelWeight.Light;
            this.metroLabel1.LabelMode = MetroFramework.Controls.MetroLabelMode.Default;
            this.metroLabel1.Location = new System.Drawing.Point(9, 31);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(111, 19);
            this.metroLabel1.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroLabel1.StyleManager = null;
            this.metroLabel1.TabIndex = 15;
            this.metroLabel1.Text = "Taskplay Updated";
            this.metroLabel1.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroLabel1.UseStyleColors = false;
            // 
            // labelVersion
            // 
            this.labelVersion.AutoSize = true;
            this.labelVersion.CustomBackground = false;
            this.labelVersion.FontSize = MetroFramework.MetroLabelSize.Medium;
            this.labelVersion.FontWeight = MetroFramework.MetroLabelWeight.Light;
            this.labelVersion.LabelMode = MetroFramework.Controls.MetroLabelMode.Default;
            this.labelVersion.Location = new System.Drawing.Point(9, 50);
            this.labelVersion.Name = "labelVersion";
            this.labelVersion.Size = new System.Drawing.Size(70, 19);
            this.labelVersion.Style = MetroFramework.MetroColorStyle.Blue;
            this.labelVersion.StyleManager = null;
            this.labelVersion.TabIndex = 14;
            this.labelVersion.Text = "Version {0}";
            this.labelVersion.Theme = MetroFramework.MetroThemeStyle.Light;
            this.labelVersion.UseStyleColors = false;
            // 
            // labelContribute
            // 
            this.labelContribute.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelContribute.AutoSize = true;
            this.labelContribute.BackColor = System.Drawing.Color.White;
            this.labelContribute.Location = new System.Drawing.Point(7, 117);
            this.labelContribute.Name = "labelContribute";
            this.labelContribute.Size = new System.Drawing.Size(0, 23);
            this.labelContribute.TabIndex = 12;
            // 
            // metroButton1
            // 
            this.metroButton1.Highlight = false;
            this.metroButton1.Location = new System.Drawing.Point(12, 448);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(148, 28);
            this.metroButton1.Style = MetroFramework.MetroColorStyle.Red;
            this.metroButton1.StyleManager = this.metroStyleManager1;
            this.metroButton1.TabIndex = 5;
            this.metroButton1.Text = "OK";
            this.metroButton1.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroButton1.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // metroButton2
            // 
            this.metroButton2.Highlight = false;
            this.metroButton2.Location = new System.Drawing.Point(206, 448);
            this.metroButton2.Name = "metroButton2";
            this.metroButton2.Size = new System.Drawing.Size(146, 28);
            this.metroButton2.Style = MetroFramework.MetroColorStyle.Red;
            this.metroButton2.StyleManager = this.metroStyleManager1;
            this.metroButton2.TabIndex = 6;
            this.metroButton2.Text = "Cancel";
            this.metroButton2.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroButton2.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(364, 485);
            this.Controls.Add(this.metroButton2);
            this.Controls.Add(this.metroButton1);
            this.Controls.Add(this.metroTabControl1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.Text = "Taskplay Settings";
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            this.metroTabControl1.ResumeLayout(false);
            this.metroTabPage1.ResumeLayout(false);
            this.metroTabPage1.PerformLayout();
            this.metroTabPage2.ResumeLayout(false);
            this.metroTabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownWaitAfterClickSync)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSyncInterval)).EndInit();
            this.metroTabPage3.ResumeLayout(false);
            this.metroTabPage3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolTip toolTip1;
        private MetroFramework.Controls.MetroTabControl metroTabControl1;
        private MetroFramework.Controls.MetroTabPage metroTabPage1;
        private MetroFramework.Controls.MetroTabPage metroTabPage2;
        private System.Windows.Forms.NumericUpDown numericUpDownWaitAfterClickSync;
        private System.Windows.Forms.NumericUpDown numericUpDownSyncInterval;
        private MetroFramework.Controls.MetroTabPage metroTabPage3;
        private System.Windows.Forms.Label labelContribute;
        private MetroFramework.Components.MetroStyleManager metroStyleManager1;
        private MetroFramework.Controls.MetroButton metroButton1;
        private MetroFramework.Controls.MetroButton metroButton2;
        private MetroFramework.Controls.MetroCheckBox checkBoxAutorun;
        private MetroFramework.Controls.MetroCheckBox checkBoxShowSongChangeButtonsWhilePaused;
        private MetroFramework.Controls.MetroCheckBox checkBoxShowPrevSong;
        private MetroFramework.Controls.MetroCheckBox checkBoxDarkMode;
        private MetroFramework.Controls.MetroCheckBox checkBoxShowNextButton;
        private MetroFramework.Controls.MetroCheckBox checkBoxPlaybackSync;
        private MetroFramework.Controls.MetroLabel labelVersion;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroLabel metroLabel5;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroLink metroLink1;
    }
}