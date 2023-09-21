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
        static bool AreChangeSongButtonsShown => GetSettingState("ShowChangeSongButtons");

        static int refreshIntervalForMediaState = 500; //ms
        
        static int waitTimeAfterClickToRefresh = 3000; //ms

        static int waitTimeRemaining = 0;

        static bool dontShowSkipWhilePaused = GetSettingState("DontShowSkipWhilePaused");



        static readonly Action<bool> restartAction = (b) => Application.Restart();

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Create system tray icons
            NotifyIcon previousIcon = new NotifyIcon();
            NotifyIcon playIcon = new NotifyIcon();
            NotifyIcon nextIcon = new NotifyIcon();
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
            //Setup nextIcon
            nextIcon.Icon = IsDarkModeOn ? Properties.Resources.ForwardDark : Properties.Resources.Forward;
            nextIcon.Text = "Next";
            nextIcon.Visible = AreChangeSongButtonsShown;
            nextIcon.MouseClick += new MouseEventHandler(nextIcon_MouseClick);
            nextIcon.ContextMenu = contextMenu;
            //Setup playIcon
            playIcon.Icon = IsDarkModeOn ? Properties.Resources.PlayDark : Properties.Resources.Play;
            playIcon.Text = "Play / Pause";
            playIcon.Visible = true;
            playIcon.MouseClick += new MouseEventHandler(playIcon_MouseClick);
            playIcon.ContextMenu = contextMenu;
            //Setup previousIcon
            previousIcon.Icon = IsDarkModeOn ? Properties.Resources.BackwardDark : Properties.Resources.Backward;
            previousIcon.Text = "Previous";
            previousIcon.Visible = AreChangeSongButtonsShown;
            previousIcon.MouseClick += new MouseEventHandler(previousIcon_MouseClick);
            previousIcon.ContextMenu = contextMenu;


            var sessionManager = GlobalSystemMediaTransportControlsSessionManager.RequestAsync().AsTask().Result;

            //have mediaStateChange() run every 500 ms

            var timer = new System.Threading.Timer((e) =>
            {
                mediaStateChange(sessionManager, playIcon, refreshIntervalForMediaState);
            }, null, TimeSpan.Zero, TimeSpan.FromMilliseconds(refreshIntervalForMediaState));







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

                // Get the Play-button
                var playIcon = (NotifyIcon)sender;

                if (_isMusicPlaying == false)
                {
                    // Start playing music and show the pause-icon
                    playIcon.Icon = IsDarkModeOn ? Properties.Resources.PauseDark : Properties.Resources.Pause;
                    _isMusicPlaying = true;
                }
                else
                {
                    // Pause the music and display the Play-icon
                    playIcon.Icon = IsDarkModeOn ? Properties.Resources.PlayDark : Properties.Resources.Play;
                    _isMusicPlaying = false;
                }
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
        public static void updatePlayingIcon(bool playing, NotifyIcon playIcon)
        {
            if (playing == true)
            {
                // Start playing music and show the pause-icon
                playIcon.Icon = IsDarkModeOn ? Properties.Resources.PauseDark : Properties.Resources.Pause;
                _isMusicPlaying = true;
            }
            else
            {
                // Pause the music and display the Play-icon
                playIcon.Icon = IsDarkModeOn ? Properties.Resources.PlayDark : Properties.Resources.Play;
                _isMusicPlaying = false;
            }
            waitTimeRemaining = waitTimeAfterClickToRefresh;
        }

        private static void contextMenuSettings_Click(object sender, System.EventArgs e)
        {
            //Show Settings form
            var settingsForm = new SettingsForm(IsDarkModeOn, AreChangeSongButtonsShown, restartAction);
            settingsForm.ShowDialog();
        }

        private static void contextMenuExit_Click(object sender, System.EventArgs e)
        {
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
                    updatePlayingIcon(true, playIcon);
                    return;
                }
                else
                {
                    updatePlayingIcon(false, playIcon);
                }
            }





           
            
            
            
        }



        private static bool GetSettingState(string settingName)
        {
            var subKey = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Taskplay");

            var keyValue = subKey.GetValue(settingName);

            if (keyValue == null)
            {
                subKey.SetValue(settingName, 0);
                return false;
            }

            return (int)keyValue == 1;
        }

        [DllImport("user32.dll", SetLastError = true)]
        public static extern void keybd_event(byte virtualKey, byte scanCode, uint flags, IntPtr extraInfo);
    }
}
