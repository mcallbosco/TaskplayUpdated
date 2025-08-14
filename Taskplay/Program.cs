using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Linq;
using System.Threading;
using Windows.Media.Control;

namespace Taskplay
{
    public class MyColorTable : ProfessionalColorTable
    {
        public override Color MenuBorder
        {
            get { return Color.Empty; }
        }
        public override Color ButtonSelectedHighlight
        {
            get { return Color.FromArgb(0, 69, 155); }
        }
    }
    static class Program
    {
        static bool windowsDarkMode = Microsoft.Win32.Registry.GetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Themes\Personalize", "AppsUseLightTheme", 1).ToString() == "0";
        static bool IsDarkModeOn => GetSettingState("DarkMode", !(Microsoft.Win32.Registry.GetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Themes\Personalize", "AppsUseLightTheme", 1).ToString() == "0"));
        static bool showNextButton => GetSettingState("ShowNextButton", true);
        static bool showPrevButton => GetSettingState("ShowPrevButton", true);
        static bool IsSyncEnabled => GetSettingState("SyncEnabled", true);
        static int SyncInterval => int.Parse(GetSettingStateString("SyncInterval", "500"));
        static int waitTimeAfterClickToRefresh => int.Parse(GetSettingStateString("PauseSyncAfterClick", "3000")); //ms
        static bool dontShowSkipWhilePaused => GetSettingState("DontShowSkipWhilePaused");

        static readonly Action<bool> restartAction = (b) => Application.Restart();

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var mutex = new Mutex(true, "Taskplay_SingleInstance", out bool isNew);
            try
            {
                if (!isNew)
                {
                    MessageBox.Show("Taskplay is already running", "Taskplay", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new TrayApplicationContext());
            }
            finally
            {
                try { if (isNew) mutex.ReleaseMutex(); } catch { }
                try { mutex.Dispose(); } catch { }
            }
        }

        private static void contextMenuSettings_Click(object sender, System.EventArgs e)
        {
            //Show Settings form
            var settingsForm = new SettingsForm(IsDarkModeOn, showNextButton, showPrevButton, restartAction, IsSyncEnabled, SyncInterval, waitTimeAfterClickToRefresh, dontShowSkipWhilePaused);
            settingsForm.ShowDialog();
        }

        private static void contextMenuExit_Click(object sender, System.EventArgs e)
        {
            Application.Exit();
        }

        private static bool GetSettingState(string settingName, bool defaultValueBool = false)
        {
            int defaultValue = defaultValueBool ? 1 : 0;
            var subKey = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Taskplay");

            var keyValue = subKey.GetValue(settingName);

            if (keyValue == null)
            {
                subKey.SetValue(settingName, defaultValue);
                return defaultValueBool;
            }

            return (int)keyValue == 1;
        }

        private static String GetSettingStateString(string settingName, string defaultValue)
        {
            var subKey = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Taskplay");

            var keyValue = subKey.GetValue(settingName);

            if (keyValue == null)
            {
                subKey.SetValue(settingName, defaultValue, Microsoft.Win32.RegistryValueKind.String);
                return defaultValue;
            }


            return keyValue.ToString();
        }

        private sealed class TrayApplicationContext : ApplicationContext
        {
            private readonly NotifyIcon playIcon = new NotifyIcon();
            private readonly NotifyIcon nextIcon = new NotifyIcon();
            private readonly NotifyIcon previousIcon = new NotifyIcon();
            private ContextMenuStrip contextMenuStrip;
            private GlobalSystemMediaTransportControlsSessionManager sessionManager;
            private bool isMusicPlaying;

            public TrayApplicationContext()
            {
                InitializeTray();
                InitializeMedia();
            }

            private void InitializeTray()
            {
                contextMenuStrip = new ContextMenuStrip();
                if (windowsDarkMode)
                {
                    contextMenuStrip.BackColor = Color.FromArgb(0, 0, 0);
                    contextMenuStrip.ForeColor = Color.FromArgb(255, 255, 255);
                }
                contextMenuStrip.Renderer = new ToolStripProfessionalRenderer(new MyColorTable());
                contextMenuStrip.ShowImageMargin = false;
                contextMenuStrip.Items.Add("Settings", null, contextMenuSettings_Click);
                contextMenuStrip.Items.Add("Exit", null, contextMenuExit_Click);

                // Play/Pause icon (initialize as not playing)
                playIcon.Icon = Program.IsDarkModeOn ? Properties.Resources.PlayDark : Properties.Resources.Play;
                playIcon.Text = "Play / Pause";
                playIcon.Visible = true;
                playIcon.MouseClick += PlayIcon_MouseClick;
                playIcon.ContextMenuStrip = contextMenuStrip;

                // Next icon
                nextIcon.Icon = Program.IsDarkModeOn ? Properties.Resources.ForwardDark : Properties.Resources.Forward;
                nextIcon.Text = "Next";
                nextIcon.Visible = Program.showNextButton;
                nextIcon.MouseClick += NextIcon_MouseClick;
                nextIcon.ContextMenuStrip = contextMenuStrip;

                // Previous icon
                previousIcon.Icon = Program.IsDarkModeOn ? Properties.Resources.BackwardDark : Properties.Resources.Backward;
                previousIcon.Text = "Previous";
                previousIcon.Visible = Program.showPrevButton;
                previousIcon.MouseClick += PreviousIcon_MouseClick;
                previousIcon.ContextMenuStrip = contextMenuStrip;

                UpdateSkipIconsVisibility();
            }

            private async void InitializeMedia()
            {
                sessionManager = await GlobalSystemMediaTransportControlsSessionManager.RequestAsync();
                sessionManager.SessionsChanged += (_, __) => WireUpSessions();
                sessionManager.CurrentSessionChanged += (_, __) => UpdateFromSessions();
                WireUpSessions();
            }

            private void WireUpSessions()
            {
                foreach (var session in sessionManager.GetSessions())
                {
                    try
                    {
                        session.PlaybackInfoChanged -= Session_PlaybackInfoChanged;
                        session.PlaybackInfoChanged += Session_PlaybackInfoChanged;
                    }
                    catch { }
                }
                UpdateFromSessions();
            }

            private void Session_PlaybackInfoChanged(GlobalSystemMediaTransportControlsSession sender, object args)
            {
                UpdateFromSessions();
            }

            private void UpdateFromSessions()
            {
                bool anyPlaying = false;
                try
                {
                    anyPlaying = sessionManager
                        .GetSessions()
                        .Any(s => s.GetPlaybackInfo()?.PlaybackStatus == GlobalSystemMediaTransportControlsSessionPlaybackStatus.Playing);
                }
                catch { }
                UpdatePlayingIcon(anyPlaying);
                UpdateSkipIconsVisibility();
            }

            private void UpdateSkipIconsVisibility()
            {
                bool showSkips = isMusicPlaying || !Program.dontShowSkipWhilePaused;
                nextIcon.Visible = Program.showNextButton && showSkips;
                previousIcon.Visible = Program.showPrevButton && showSkips;
            }

            private async void PlayIcon_MouseClick(object sender, MouseEventArgs e)
            {
                if (e.Button != MouseButtons.Left) return;
                try
                {
                    var current = sessionManager?.GetCurrentSession();
                    if (current != null)
                    {
                        await current.TryTogglePlayPauseAsync();
                    }
                }
                catch { }
            }

            private async void NextIcon_MouseClick(object sender, MouseEventArgs e)
            {
                if (e.Button != MouseButtons.Left) return;
                try
                {
                    var current = sessionManager?.GetCurrentSession();
                    if (current != null)
                    {
                        await current.TrySkipNextAsync();
                    }
                }
                catch { }
            }

            private async void PreviousIcon_MouseClick(object sender, MouseEventArgs e)
            {
                if (e.Button != MouseButtons.Left) return;
                try
                {
                    var current = sessionManager?.GetCurrentSession();
                    if (current != null)
                    {
                        await current.TrySkipPreviousAsync();
                    }
                }
                catch { }
            }

            private void UpdatePlayingIcon(bool playing)
            {
                if (isMusicPlaying == playing) return;
                isMusicPlaying = playing;
                if (playing)
                {
                    playIcon.Icon = Program.IsDarkModeOn ? Properties.Resources.PauseDark : Properties.Resources.Pause;
                    playIcon.Text = "Pause";
                }
                else
                {
                    playIcon.Icon = Program.IsDarkModeOn ? Properties.Resources.PlayDark : Properties.Resources.Play;
                    playIcon.Text = "Play";
                }
            }

            protected override void ExitThreadCore()
            {
                try { playIcon.Dispose(); } catch { }
                try { nextIcon.Dispose(); } catch { }
                try { previousIcon.Dispose(); } catch { }
                base.ExitThreadCore();
            }
        }
    }
}
