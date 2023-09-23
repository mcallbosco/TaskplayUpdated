using System;
using System.Net.Configuration;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Security.Policy;
using System.Windows.Forms;
using Windows.Media;
using Windows.Media.Control;
using Windows.Media.Streaming.Adaptive;

namespace Taskplay
{
    static class Program
    {
        static bool _isMusicPlaying = false;    // Bool to keep in check if the user is playing music

        static bool IsDarkModeOn => GetSettingState("DarkMode");
        static bool showNextButton => GetSettingState("ShowNextButton", true);

        static bool showPrevButton => GetSettingState("ShowPrevButton", true);

        static bool IsSyncEnabled => GetSettingState("SyncEnabled", true);

        static int SyncInterval => int.Parse(GetSettingStateString("SyncInterval", "500"));

        
        static int waitTimeAfterClickToRefresh = int.Parse(GetSettingStateString("PauseSyncAfterClick", "3000")); //ms

        static int waitTimeRemaining = 0;

        static bool dontShowSkipWhilePaused = GetSettingState("DontShowSkipWhilePaused");

        static NotifyIcon playIcon = new NotifyIcon();

        static NotifyIcon nextIcon = null;

        static NotifyIcon previousIcon = null;



        static readonly Action<bool> restartAction = (b) => Application.Restart();

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //check for already running
            if (System.Diagnostics.Process.GetProcessesByName(System.IO.Path.GetFileNameWithoutExtension(System.Reflection.Assembly.GetEntryAssembly().Location)).Length > 1)
            {
                MessageBox.Show("Taskplay is already running", "Taskplay", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Create the context menu and its items
            ContextMenu contextMenu = new ContextMenu();
            MenuItem contextItemSettings = new MenuItem();
            MenuItem contextItemExit = new MenuItem();
            //Setup the context menu items
            contextItemSettings.Text = "&Settings";
            contextItemExit.Text = "&Exit";
            contextItemSettings.Click += new EventHandler(contextMenuSettings_Click);
            contextItemExit.Click += new EventHandler(contextMenuExit_Click);
            //Add the context menu items to the context menu
            contextMenu.MenuItems.Add(contextItemSettings);
            contextMenu.MenuItems.Add(contextItemExit);
            nextIcon = spawnNextIcon(showNextButton);
            previousIcon = spawnPreviousIcon(showPrevButton);


            //Setup playIcon
            playIcon.Icon = IsDarkModeOn ? Properties.Resources.PlayDark : Properties.Resources.Play;
            playIcon.Text = "Play / Pause";
            playIcon.Visible = true;
            playIcon.MouseClick += new MouseEventHandler(playIcon_MouseClick);
            playIcon.ContextMenu = contextMenu;
            


            var sessionManager = GlobalSystemMediaTransportControlsSessionManager.RequestAsync().AsTask().Result;

            if (IsSyncEnabled) { 
                var timer = new System.Threading.Timer((e) =>
                {
                    mediaStateChange(sessionManager, playIcon, SyncInterval);
                }, null, TimeSpan.Zero, TimeSpan.FromMilliseconds(SyncInterval));
            }
            //Launch
            Application.Run();
        }

        private static void previousIcon_MouseClick(object sender, MouseEventArgs e)
        {
            //Send Media Key Previous Track
            if (e.Button == MouseButtons.Left)
            {
                keybd_event(0xB1, 0, 0x0001, IntPtr.Zero);
                keybd_event(0xB1, 0, 0x0002, IntPtr.Zero);
            }
        }

        private static void playIcon_MouseClick(object sender, MouseEventArgs e)
        {
            //Send Media Key Play
            if (e.Button == MouseButtons.Left)
            {
                keybd_event(0xB3, 0, 0x0001, IntPtr.Zero);
                keybd_event(0xB3, 0, 0x0002, IntPtr.Zero);

                updatePlayingIcon(!_isMusicPlaying);
            }

            
        }

        private static void nextIcon_MouseClick(object sender, MouseEventArgs e)
        {
            //Send Media Key Next Track
            if (e.Button == MouseButtons.Left)
            {
                keybd_event(0xB0, 0, 0x0001, IntPtr.Zero);
                keybd_event(0xB0, 0, 0x0002, IntPtr.Zero);
            }
        }

        private static NotifyIcon spawnNextIcon(bool doit)
        {
            if (!doit) return null;
            NotifyIcon newNextIcon = new NotifyIcon();
            //Setup nextIcon
            newNextIcon.Icon = IsDarkModeOn ? Properties.Resources.ForwardDark : Properties.Resources.Forward;
            newNextIcon.Text = "Next";
            newNextIcon.Visible = showNextButton;
            newNextIcon.MouseClick += new MouseEventHandler(nextIcon_MouseClick);
            return newNextIcon;
        }

        private static NotifyIcon spawnPreviousIcon(bool doIt)
        {
            if (!doIt) return null;
            NotifyIcon newPreviousIcon = new NotifyIcon();
            //Setup previousIcon
            newPreviousIcon.Icon = IsDarkModeOn ? Properties.Resources.BackwardDark : Properties.Resources.Backward;
            newPreviousIcon.Text = "Previous";
            newPreviousIcon.Visible = showPrevButton;
            newPreviousIcon.MouseClick += new MouseEventHandler(previousIcon_MouseClick);
            return newPreviousIcon;
        }


        public static void updatePlayingIcon(bool playing)
        {
            if (playing == true)
            {
                // Start playing music and show the pause-icon
                playIcon.Icon = IsDarkModeOn ? Properties.Resources.PauseDark : Properties.Resources.Pause;
                _isMusicPlaying = true;
                playIcon.Text = "Pause";
                if (dontShowSkipWhilePaused)
                {
                    if (nextIcon == null) nextIcon = spawnNextIcon(true);
                    if (previousIcon == null) previousIcon = spawnPreviousIcon(true);
                }
            }
            else
            {
                // Pause the music and display the Play-icon
                playIcon.Icon = IsDarkModeOn ? Properties.Resources.PlayDark : Properties.Resources.Play;
                _isMusicPlaying = false;
                playIcon.Text = "Play";
                if (dontShowSkipWhilePaused)
                {
                    if (nextIcon != null) nextIcon.Dispose();
                    nextIcon = null;
                    if (previousIcon != null) previousIcon.Dispose();
                    nextIcon = null;
                }
            }
            waitTimeRemaining = waitTimeAfterClickToRefresh;
        }

        private static void contextMenuSettings_Click(object sender, System.EventArgs e)
        {
            //Show Settings form
            var settingsForm = new SettingsForm(IsDarkModeOn, showNextButton, showPrevButton, restartAction, IsSyncEnabled, SyncInterval, waitTimeAfterClickToRefresh, dontShowSkipWhilePaused);
            settingsForm.ShowDialog();
        }

        private static void contextMenuExit_Click(object sender, System.EventArgs e)
        {
            hideIcons();

            //Exit the app
            Application.Exit();
        }

        

        //listener for media events
        private static void mediaStateChange(GlobalSystemMediaTransportControlsSessionManager sessionManager1, NotifyIcon playIcon, int refreshIntervalForMediaState)
        {
            
            if (waitTimeRemaining > 0)
            {
                waitTimeRemaining -= refreshIntervalForMediaState;
                return;
            } else
            {
                waitTimeRemaining = 0;
            }


            // check through all sessions to see if anything is playing
            var sessionManager = GlobalSystemMediaTransportControlsSessionManager.RequestAsync().AsTask().Result;

            for (int i = 0; i < sessionManager.GetSessions().Count; i++)
            {
                if (sessionManager.GetSessions()[i].GetPlaybackInfo().PlaybackStatus.ToString() == "Playing")
                {
                    updatePlayingIcon(true);
                    return;
                }
                else
                {
                    updatePlayingIcon(false);
                }
            }





           
            
            
            
        }



        private static bool GetSettingState(string settingName, bool defaultValueBool = false)
        {
            //for backwards compatibility with old settings
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

        public static void hideIcons()
        {
            playIcon?.Dispose();
            nextIcon?.Dispose();
            previousIcon?.Dispose();

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

        [DllImport("user32.dll", SetLastError = true)]
        public static extern void keybd_event(byte virtualKey, byte scanCode, uint flags, IntPtr extraInfo);
    }
}
