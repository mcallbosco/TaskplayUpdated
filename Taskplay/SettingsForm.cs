﻿using MetroFramework;
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Taskplay
{
    public struct ThemeSettings
    {
        public bool systemDarkMode;
    }

    public partial class SettingsForm : Form
    {
        Microsoft.Win32.RegistryKey autorun;
        Microsoft.Win32.RegistryKey settings;
        private readonly bool isDarkModeOn;
        private readonly bool showNextButton;
        private readonly bool showPrevButton;
        private readonly bool isSyncEnabled;
        private readonly int syncInterval;

        private readonly int waitAfterClickSync;
        private readonly bool showSongChangeButtonsWhilePaused;
        private readonly Action<bool> restartAction;
        
        private bool isRestartNeeded = false;

        public SettingsForm(bool isDarkModeOn, bool showNextButton, bool showPrevButton,
            Action<bool> restartAction, bool isSyncEnabled, 
            int syncInterval, int waitAfterClickSync, bool showSongChangeButtonsWhilePaused)
        {
            InitializeComponent();
            makeDarkMode();
            autorun = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true);
            settings = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Taskplay");
            this.isDarkModeOn = isDarkModeOn;
            this.restartAction = restartAction;
            this.showNextButton = showNextButton;
            this.showPrevButton = showPrevButton;
            this.isSyncEnabled = isSyncEnabled;
            this.syncInterval = syncInterval;
            this.waitAfterClickSync = waitAfterClickSync;
            this.showSongChangeButtonsWhilePaused = showSongChangeButtonsWhilePaused;
            //get system accent color using winUISettings
            var uiSettings = new Windows.UI.ViewManagement.UISettings();
            var accentColor = uiSettings.GetColorValue(Windows.UI.ViewManagement.UIColorType.Accent);
            //Figure out for later
            if (Microsoft.Win32.Registry.GetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Themes\Personalize", "AppsUseLightTheme", 1).ToString() == "0")
            {
                metroStyleManager1.Style = MetroFramework.MetroColorStyle.White;
            }
            else
            {
                metroStyleManager1.Style = MetroFramework.MetroColorStyle.Black;
            }
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            labelVersion.Text = String.Format("Version {0}", Application.ProductVersion);
            checkBoxAutorun.Checked = (autorun.GetValue("Taskplay") != null);
            checkBoxDarkMode.Checked = isDarkModeOn;
            checkBoxShowNextButton.Checked = showNextButton;
            checkBoxShowPrevSong.Checked = showPrevButton;
            checkBoxPlaybackSync.Checked = isSyncEnabled;
            numericUpDownSyncInterval.Value = syncInterval;
            numericUpDownWaitAfterClickSync.Value = waitAfterClickSync;
            checkBoxShowSongChangeButtonsWhilePaused.Checked = showSongChangeButtonsWhilePaused;


        }

        private void SaveSettings()
        {
            if (checkBoxAutorun.Checked)
                autorun.SetValue("Taskplay", Application.ExecutablePath);
            else
                autorun.DeleteValue("Taskplay", false);



            settings.SetValue("DarkMode", checkBoxDarkMode.Checked ? 1 : 0);
            settings.SetValue("ShowNextButton", checkBoxShowNextButton.Checked ? 1 : 0);
            settings.SetValue("ShowPrevButton", checkBoxShowPrevSong.Checked ? 1 : 0);
            settings.SetValue("SyncEnabled", checkBoxPlaybackSync.Checked ? 1 : 0);
            settings.SetValue("SyncInterval", numericUpDownSyncInterval.Value, Microsoft.Win32.RegistryValueKind.String);
            settings.SetValue("PauseSyncAfterClick", numericUpDownWaitAfterClickSync.Value, Microsoft.Win32.RegistryValueKind.String);
            settings.SetValue("DontShowSkipWhilePaused", checkBoxShowSongChangeButtonsWhilePaused.Checked ? 1 : 0);

            isRestartNeeded = true;

        }

        private void linkLabelGitHub_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/mcallbosco/TaskplayUpdated");
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            SaveSettings();
            Close();
            if (isRestartNeeded)
                Program.hideIcons();
                restartAction(true);
        }
        private void makeDarkMode()
        {
            bool windowsDarkMode = Microsoft.Win32.Registry.GetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Themes\Personalize", "AppsUseLightTheme", 1).ToString() == "0";

            if (windowsDarkMode)
            {
                metroStyleManager1.Theme = MetroFramework.MetroThemeStyle.Dark;
                this.BackColor = System.Drawing.Color.FromArgb(17, 17, 17);
                //change numericUpDowns
                numericUpDownSyncInterval.BackColor = System.Drawing.Color.FromArgb(17, 17, 17);
                numericUpDownSyncInterval.ForeColor = System.Drawing.Color.White;
                
                numericUpDownSyncInterval.BorderStyle = BorderStyle.FixedSingle;
                numericUpDownWaitAfterClickSync.BackColor = System.Drawing.Color.FromArgb(17, 17, 17);
                numericUpDownWaitAfterClickSync.ForeColor = System.Drawing.Color.White;
                numericUpDownWaitAfterClickSync.BorderStyle = BorderStyle.FixedSingle;

            }

        }

        private void metroCheckBox3_CheckedChanged(object sender, EventArgs e)
        {

        }

        //Title Bar Dark Mode
        [DllImport("DwmApi")] //System.Runtime.InteropServices
        private static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, int[] attrValue, int attrSize);

        protected override void OnHandleCreated(EventArgs e)
        {
            if (Microsoft.Win32.Registry.GetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Themes\Personalize", "AppsUseLightTheme", 1).ToString() == "0")
            {
                
                if (DwmSetWindowAttribute(Handle, 19, new[] { 1 }, 4) != 0)
                    DwmSetWindowAttribute(Handle, 20, new[] { 1 }, 4);
            }
        }

        private void metroLink1_Click(object sender, EventArgs e)
        {
            ProcessStartInfo sInfo = new ProcessStartInfo("https://github.com/mcallbosco/TaskplayUpdated");
            Process.Start(sInfo);



        }
    }

}
