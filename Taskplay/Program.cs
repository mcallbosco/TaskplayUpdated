using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
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
        static bool _isMusicPlaying = true;    // Bool to keep in check if the user is playing music
        static bool IsDarkModeOn => GetSettingState("DarkMode", !(Microsoft.Win32.Registry.GetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Themes\Personalize", "AppsUseLightTheme", 1).ToString() == "0"));
        static bool showNextButton => GetSettingState("ShowNextButton", true);
        static bool showPrevButton => GetSettingState("ShowPrevButton", true);
        static bool IsSyncEnabled => GetSettingState("SyncEnabled", true);
        static int SyncInterval => int.Parse(GetSettingStateString("SyncInterval", "500"));
        static int waitTimeAfterClickToRefresh => int.Parse(GetSettingStateString("PauseSyncAfterClick", "3000")); //ms
        static int waitTimeRemaining = 0;
        static bool dontShowSkipWhilePaused => GetSettingState("DontShowSkipWhilePaused");

        static NotifyIcon playIcon = new NotifyIcon();

        static NotifyIcon nextIcon = null;

        static NotifyIcon previousIcon = null;

        static ContextMenu contextMenu = new ContextMenu();
        static ContextMenuStrip contextMenuStrip = new ContextMenuStrip();

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
                //sleep for 500 ms and then check again
                System.Threading.Thread.Sleep(500);
                if (System.Diagnostics.Process.GetProcessesByName(System.IO.Path.GetFileNameWithoutExtension(System.Reflection.Assembly.GetEntryAssembly().Location)).Length > 1)
                { MessageBox.Show("Taskplay is already running", "Taskplay", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
                }
            }

            Application.EnableVisualStyles();
            //Create the context menu and its items
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

            //set context menu background to dark if dark mode is on

            if (windowsDarkMode)
            {
                contextMenuStrip.BackColor = System.Drawing.Color.FromArgb(0, 0, 0);
                contextMenuStrip.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255);
                

            }

            //Setup the context menu strip items
            contextMenuStrip.Items.Add("Settings", null, contextMenuSettings_Click);
            contextMenuStrip.Items.Add("Exit", null, contextMenuExit_Click);
            contextMenuStrip.Renderer = new ToolStripProfessionalRenderer(new MyColorTable());
            contextMenuStrip.ShowImageMargin = false;




            //Setup next and prev icons



            //Setup playIcon
            updatePlayingIcon(_isMusicPlaying);
            playIcon.Text = "Play / Pause";
            playIcon.Visible = true;
            playIcon.MouseClick += new MouseEventHandler(playIcon_MouseClick);
            playIcon.ContextMenuStrip = contextMenuStrip;



            var sessionManager = GlobalSystemMediaTransportControlsSessionManager.RequestAsync().AsTask().Result;
            bool firstRun = true;
            updatePlayingIcon(_isMusicPlaying);

            if (IsSyncEnabled) {


                //run                         mediaStateChange(sessionManager, playIcon, SyncInterval); 
                //every SyncInterval ms

                Timer timer = new Timer();
                timer.Interval = SyncInterval;
                timer.Tick += (sender, args) => mediaStateChange(sessionManager, playIcon, SyncInterval);
                timer.Start();




            }




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
                waitTimeRemaining = waitTimeAfterClickToRefresh;
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
            newNextIcon.ContextMenu = contextMenu;
            return newNextIcon;
        }

        private static NotifyIcon spawnPreviousIcon(bool doIt)
        {
            if (!doIt) return null;
            NotifyIcon newPreviousIcon = new NotifyIcon();
            //Setup previousIcon
            newPreviousIcon.Icon = IsDarkModeOn ? Properties.Resources.BackwardDark : Properties.Resources.Backward;
            newPreviousIcon.Text = "Previous";
            newPreviousIcon.Visible = true;
            newPreviousIcon.MouseClick += new MouseEventHandler(previousIcon_MouseClick);
            newPreviousIcon.ContextMenu = contextMenu;
            return newPreviousIcon;
        }


        public static void updatePlayingIcon(bool playing)
        {
            if (playing == true)
            {
                if (_isMusicPlaying) return;
                // Start playing music and show the pause-icon
                playIcon.Icon = IsDarkModeOn ? Properties.Resources.PauseDark : Properties.Resources.Pause;
                _isMusicPlaying = true;
                playIcon.Text = "Pause";
                //Spawn the next and previous icons if they are not already spawned
                
                if (nextIcon == null) nextIcon = spawnNextIcon(showNextButton);
                if (previousIcon == null) previousIcon = spawnPreviousIcon(showPrevButton);
                
            }
            else
            {
                if (!_isMusicPlaying) return;
                // Pause the music and display the Play-icon
                playIcon.Icon = IsDarkModeOn ? Properties.Resources.PlayDark : Properties.Resources.Play;
                _isMusicPlaying = false;
                playIcon.Text = "Play";
                //Dispose the next and previous icons if we are not showing them while paused
                if (dontShowSkipWhilePaused)
                {
                    if (nextIcon != null) nextIcon.Dispose();
                    nextIcon = null;
                    if (previousIcon != null) previousIcon.Dispose();
                    previousIcon = null;
                }
                else
                {
                    if (nextIcon == null) nextIcon = spawnNextIcon(showNextButton);
                    if (previousIcon == null) previousIcon = spawnPreviousIcon(showPrevButton);
                }
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
            hideIcons();
            //sleep for 500 ms
            System.Threading.Thread.Sleep(500);


            //Exit the app
            Application.Exit();
        }

        

        //listener for media events
        private static void mediaStateChange(GlobalSystemMediaTransportControlsSessionManager sessionManager1, NotifyIcon playIcon, int refreshIntervalForMediaState)
        {
            //wait for the interval to pass
            if (waitTimeRemaining > 0)
            {
                waitTimeRemaining -= refreshIntervalForMediaState;
                return;
            } else
            {
                waitTimeRemaining = 0;
            }


            // check through all sessions to see if anything is playing
            //var sessionManager = GlobalSystemMediaTransportControlsSessionManager.RequestAsync().AsTask().Result;

            for (int i = 0; i < sessionManager1.GetSessions().Count; i++)
            {
                if (sessionManager1.GetSessions()[i].GetPlaybackInfo().PlaybackStatus.ToString() == "Playing")
                {
                    if (_isMusicPlaying == false) updatePlayingIcon(true);
                    return;
                }

            }
            if (_isMusicPlaying == true) updatePlayingIcon(false);

            

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
        public static void hideIcons()
        {
            playIcon?.Dispose();
            nextIcon?.Dispose();
            previousIcon?.Dispose();

        }


        [DllImport("user32.dll", SetLastError = true)]
        public static extern void keybd_event(byte virtualKey, byte scanCode, uint flags, IntPtr extraInfo);
    }
}
