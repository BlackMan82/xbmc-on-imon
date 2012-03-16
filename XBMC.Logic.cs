using System;
using System.Windows.Forms;
using System.IO;
using System.Reflection;

using iMon.XBMC.Properties;

using iMon.DisplayApi;
using XBMC.JsonRpc;
using Microsoft.Win32;

namespace iMon.XBMC
{
    public partial class XBMC
    {
        #region Variables

        private const string AutostartRegistry = @"Software\Microsoft\Windows\CurrentVersion\Run";

        private bool closing;

        private iMonWrapperApi imon;
        private DisplayHandler displayHandler;
        private XbmcJsonRpcConnection xbmc;
        private XbmcHandler xbmcHandler;

        private delegate bool XbmcConnectingDelegate(bool auto);
        XbmcConnectingDelegate xbmcConnectingDeletage;
        private Timer xbmcConnectionTimer;

        #endregion

        #region General functions

        private void constructor()
        {
            // GUI initialization
            this.tbXbmcMovieSingleText.Suggestions.Add("%title%");
            this.tbXbmcMovieSingleText.Suggestions.Add("%year%");
            this.tbXbmcMovieSingleText.Suggestions.Add("%rating%");
            this.tbXbmcMovieSingleText.Suggestions.Add("%genre%");
            this.tbXbmcMovieSingleText.Suggestions.Add("%duration%");
            this.tbXbmcMovieSingleText.Suggestions.Add("%mpaa%");
            this.tbXbmcMovieSingleText.Suggestions.Add("%tagline%");
            this.tbXbmcMovieSingleText.Suggestions.Add("%studio%");
            this.tbXbmcMovieSingleText.Suggestions.Add("%director%");
            this.tbXbmcMovieSingleText.Suggestions.Add("%writer%");
            this.tbXbmcMovieSingleText.Suggestions.Add("%outline%");
            this.tbXbmcMovieSingleText.Suggestions.Add("%plot%");

            this.tbXbmcTvSingleText.Suggestions.Add("%title%");
            this.tbXbmcTvSingleText.Suggestions.Add("%episode%");
            this.tbXbmcTvSingleText.Suggestions.Add("%season%");
            this.tbXbmcTvSingleText.Suggestions.Add("%show%");
            this.tbXbmcTvSingleText.Suggestions.Add("%year%");
            this.tbXbmcTvSingleText.Suggestions.Add("%rating%");
            this.tbXbmcTvSingleText.Suggestions.Add("%duration%");
            this.tbXbmcTvSingleText.Suggestions.Add("%mpaa%");
            this.tbXbmcTvSingleText.Suggestions.Add("%studio%");
            this.tbXbmcTvSingleText.Suggestions.Add("%director%");
            this.tbXbmcTvSingleText.Suggestions.Add("%writer%");
            this.tbXbmcTvSingleText.Suggestions.Add("%plot%");

            this.tbXbmcMusicSingleText.Suggestions.Add("%title%");
            this.tbXbmcMusicSingleText.Suggestions.Add("%artist%");
            this.tbXbmcMusicSingleText.Suggestions.Add("%album%");
            this.tbXbmcMusicSingleText.Suggestions.Add("%track%");
            this.tbXbmcMusicSingleText.Suggestions.Add("%year%");
            this.tbXbmcMusicSingleText.Suggestions.Add("%rating%");
            this.tbXbmcMusicSingleText.Suggestions.Add("%genre%");
            this.tbXbmcMusicSingleText.Suggestions.Add("%duration%");
            this.tbXbmcMusicSingleText.Suggestions.Add("%disc%");
            this.tbXbmcMusicSingleText.Suggestions.Add("%lyrics%");

            this.tbXbmcMusicVideoSingleText.Suggestions.Add("%title%");
            this.tbXbmcMusicVideoSingleText.Suggestions.Add("%artist%");
            this.tbXbmcMusicVideoSingleText.Suggestions.Add("%album%");
            this.tbXbmcMusicVideoSingleText.Suggestions.Add("%year%");
            this.tbXbmcMusicVideoSingleText.Suggestions.Add("%rating%");
            this.tbXbmcMusicVideoSingleText.Suggestions.Add("%genre%");
            this.tbXbmcMusicVideoSingleText.Suggestions.Add("%duration%");
            this.tbXbmcMusicVideoSingleText.Suggestions.Add("%studio%");
            this.tbXbmcMusicVideoSingleText.Suggestions.Add("%director%");
            this.tbXbmcMusicVideoSingleText.Suggestions.Add("%plot%");

            try
            {
                //if (File.Exists(Logging.ErrorLog))
                //{
                //    if (File.Exists(Logging.ErrorLog + Logging.OldLog))
                //    {
                //        File.Delete(Logging.ErrorLog + Logging.OldLog);
                //    }
                //    File.Move(Logging.ErrorLog, Logging.ErrorLog + Logging.OldLog);
                //}
                if (File.Exists(Logging.DebugLog))
                {
                    if (File.Exists(Logging.DebugLog + Logging.OldLog))
                    {
                        File.Delete(Logging.DebugLog + Logging.OldLog);
                    }
                    File.Move(Logging.DebugLog, Logging.DebugLog + Logging.OldLog);
                }
            }
            catch (Exception)
            { }

            Logging.Log("Current version of XbmcOniMon: " + Assembly.GetExecutingAssembly().GetName().Version.ToString());

            this.xbmcConnectionTimer = new Timer();
            this.xbmcConnectionTimer.Tick += xbmcTryConnect;


            // Check for update
            if (Settings.Default.GeneralCheckForUpdateOnStart)
                Updating.update(true);

            // Check if this is a newer version. If so, do settings update
            if (Settings.Default.CallUpgrade)
            {
                Logging.Log("Trying to upgrade settings");
                Settings.Default.Upgrade();
                Settings.Default.CallUpgrade = false;
                Settings.Default.Save();
                Settings.Default.Reload();
                //this.settingsUpdate();
                Logging.Log("Settings upgraded");
                MessageBox.Show("Settings upgraded from the previous version");
            }

            this.settingsUpdate();
            this.setupSettingsChanges(this.tabOptions);

            // Setting up iMON
            Logging.Log("Setting up iMON");
            this.imon = new iMonWrapperApi();
            this.imon.StateChanged += wrapperApi_StateChanged;
            this.imon.Error += wrapperApi_Error;
            this.imon.LogError += wrapperApiIMonLogError;
            if (Settings.Default.GeneralDebugEnable)
            {
                this.imon.Log += wrapperApiIMonLog;
            }

            this.displayHandler = new DisplayHandler(this.imon);
            this.displayHandler.RunWorkerAsync();

            // Setting up XBMC
            this.xbmcConnectingDeletage = new XbmcConnectingDelegate(xbmcConnecting);
            this.xbmcSetup();
        }

        private void show()
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new MethodInvoker(delegate() { this.show(); }));
                return;
            }

            this.Show();
            this.WindowState = FormWindowState.Normal;
        }

        private void close(bool force)
        {
            if (!force && Settings.Default.GeneralTrayEnabled && Settings.Default.GeneralTrayHideOnClose)
            {
                this.Hide();
                return;
            }

            Logging.Log("Closing the application...");

            this.closing = true;

            Logging.Log("Cancelling the display handler...");
            this.displayHandler.CancelAsync();
            this.iMonUninitialize();

            Logging.Log("Cancelling the XBMC handler...");
            this.xbmcHandler.CancelAsync();
            this.xbmcDisconnect(true);

            this.Close();
        }

        private void setupSettingsChanges(Control control)
        {
            foreach (Control ctrl in control.Controls)
            {
                if (ctrl is CheckBox)
                {
                    ((CheckBox)ctrl).CheckedChanged += settingsChanged;
                }
                else if (ctrl is RadioButton)
                {
                    ((RadioButton)ctrl).CheckedChanged += settingsChanged;
                }
                else if (ctrl is ComboBox)
                {
                    ((ComboBox)ctrl).SelectedValueChanged += settingsChanged;
                }
                else if (ctrl is TextBox)
                {
                    ctrl.Leave += settingsChanged;
                }
                else if (ctrl is NumericUpDown)
                {
                    ((NumericUpDown)ctrl).ValueChanged += settingsChanged;
                }
                else if (ctrl.Controls.Count > 0)
                {
                    this.setupSettingsChanges(ctrl);
                }
            }
        }

        private void showBalloonTip(string text, ToolTipIcon icon)
        {
            if (Settings.Default.GeneralTrayDisableBalloonTips)
            {
                return;
            }

            this.trayIcon.ShowBalloonTip(5000, "XBMC on iMON", text, icon);
        }

        #endregion

        #region Settings functions

        private void settingsChanged(object sender, EventArgs e)
        {
            this.settingsSave();
        }

        private void settingsUpdate()
        {
            // General settings
            this.cbGeneralStartupAuto.Checked = Settings.Default.GeneralStartupAuto;
            this.cbGeneralStartupConnect.Checked = Settings.Default.GeneralStartupConnect;
            this.cbGeneralCheckForUpdateOnStart.Checked = Settings.Default.GeneralCheckForUpdateOnStart;

            this.cbGeneralTrayEnabled.Checked = Settings.Default.GeneralTrayEnabled;
            this.cbGeneralTrayStartMinimized.Checked = Settings.Default.GeneralTrayStartMinimized;
            this.cbGeneralTrayHideOnMinimize.Checked = Settings.Default.GeneralTrayHideOnMinimize;
            this.cbGeneralTrayHideOnClose.Checked = Settings.Default.GeneralTrayHideOnClose;
            this.cbGeneralTrayDisableBalloonTips.Checked = Settings.Default.GeneralTrayDisableBalloonTips;

            this.cbGeneralDebugEnable.Checked = Settings.Default.GeneralDebugEnable;

            // iMON settings
            this.cbImonGeneralAutoInitialize.Checked = Settings.Default.ImonAutoInitialize;
            this.cbImonGeneralUninitializeOnError.Checked = Settings.Default.ImonUninitializeOnError;

            this.nudImonLcdScrollingDelay.Value = Settings.Default.ImonLcdScrollingDelay;

            this.cbImonSoundSystemEnable.Checked = Settings.Default.ImonSoundSystemEnable;
            this.cbImonSoundSystem.SelectedIndex = Settings.Default.ImonSoundSystem;
            this.cbImonSoundSystemSPDIF.Checked = Settings.Default.ImonSoundSystemSPDIF;

            // XBMC settings
            this.tbXbmcConnectionIp.Text = Settings.Default.XbmcIp;
            this.tbXbmcConnectionPort.Text = Settings.Default.XbmcPort.ToString();
            this.tbXbmcTcpPort.Text = Settings.Default.XbmcTcpPort.ToString();
            this.tbXbmcConnectionUsername.Text = Settings.Default.XbmcUsername;
            this.tbXbmcConnectionPassword.Text = Settings.Default.XbmcPassword;
            this.nudXbmcConnectionInterval.Value = Settings.Default.XbmcConnectionInterval;

            this.rbXbmcIdleStaticTextEnable.Checked = Settings.Default.XbmcIdleStaticTextEnable;
            this.tbXbmcIdleStaticText.Text = Settings.Default.XbmcIdleStaticText;
            this.rbXbmcIdleTime.Checked = !Settings.Default.XbmcIdleStaticTextEnable;
            this.cbXbmcIdleShowSeconds.Checked = Settings.Default.XbmcIdleTimeShowSeconds;

            this.cbXbmcControlModeEnable.Checked = Settings.Default.XbmcControlModeEnable;
            this.cbXbmcControlModeDisableDuringPlayback.Checked = Settings.Default.XbmcControlModeDisableDuringPlayback;
            this.cbXbmcControlModeRemoveBrackets.Checked = Settings.Default.XbmcControlModeRemoveBrackets;
            this.cbXbmcControlModeShowWindow.Checked = Settings.Default.XbmcControlModeDisplayWindowName;

            this.nudXbmcIconsUpdateInterval.Value = Settings.Default.XbmcGeneralUpdateInterval;
            this.cbXbmcIconsVolEnable.Checked = Settings.Default.XbmcGeneralShowVolume;

            this.cbXbmcPlayingShowProgress.Checked = Settings.Default.XbmcIconsPlaybackProgress;
            this.cbXbmcPlayingShowMediaType.Checked = Settings.Default.XbmcIconsPlaybackMediaType;
            this.cbXbmcPlayingVideoCodecs.Checked = Settings.Default.XbmcIconsPlaybackVideoCodecs;
            this.cbXbmcPlayingAudioCodecs.Checked = Settings.Default.XbmcIconsPlaybackAudioCodecs;
            this.cbXbmcPlayingDiscEnable.Checked = Settings.Default.XbmcIconsPlaybackDiscEnable;
            this.cbXbmcPlayingDiscRotate.Checked = Settings.Default.XbmcIconsPlaybackDiscRotate;
            this.cbXbmcPlayingDiscBottomCircle.Checked = Settings.Default.XbmcIconsPlaybackDiscBottomCircle;

            this.rbXbmcMovieStayIdle.Checked = !Settings.Default.XbmcMovieSingleTextEnable;
            this.rbXbmcMovieSingleText.Checked = Settings.Default.XbmcMovieSingleTextEnable;
            this.tbXbmcMovieSingleText.Text = Settings.Default.XbmcMovieSingleText;

            this.cbXbmcTvMediaTypeIcon.Checked = Settings.Default.XbmcTvShowTvMediaTypeIcon;
            this.cbXbmcTvShowTvHdtvIcon.Checked = Settings.Default.XbmcTvShowTvHdtvIcon;
            this.rbXbmcTvStayIdle.Checked = !Settings.Default.XbmcTvSingleTextEnable;
            this.rbXbmcTvSingleText.Checked = Settings.Default.XbmcTvSingleTextEnable;
            this.tbXbmcTvSingleText.Text = Settings.Default.XbmcTvSingleText;

            this.rbXbmcMusicStayIdle.Checked = !Settings.Default.XbmcMusicSingleTextEnable;
            this.rbXbmcMusicSingleText.Checked = Settings.Default.XbmcMusicSingleTextEnable;
            this.tbXbmcMusicSingleText.Text = Settings.Default.XbmcMusicSingleText;

            this.rbXbmcMusicVideoStayIdle.Checked = !Settings.Default.XbmcMusicVideoSingleTextEnable;
            this.rbXbmcMusicVideoSingleText.Checked = Settings.Default.XbmcMusicVideoSingleTextEnable;
            this.tbXbmcMusicVideoSingleText.Text = Settings.Default.XbmcMusicVideoSingleText;

            // Actions
            this.trayIcon.Visible = Settings.Default.GeneralTrayEnabled;
            this.xbmcConnectionTimer.Interval = Settings.Default.XbmcConnectionInterval * 1000;

            Logging.Log("Settings successfully applied to the GUI");

            if (Settings.Default.ImonAutoInitialize &&  this.imon != null && 
                !this.imon.IsInitialized && this.xbmc != null && this.xbmc.IsAlive)
            {
                Logging.Log("Auto-initializing iMON");
                this.iMonInitialize();
            }
        }

        private void settingsSave()
        {
            bool xbmcConnectionChanged = false;

            if (Settings.Default.GeneralStartupAuto != this.cbGeneralStartupAuto.Checked)
            {
                // Handle auto start with windows
                RegistryKey key = Registry.CurrentUser.CreateSubKey(AutostartRegistry);
                RegistryKey check = Registry.CurrentUser.OpenSubKey(AutostartRegistry);
                if (this.cbGeneralStartupAuto.Checked)
                {
                    Logging.Log("Adding Windows Registry entry for autostart on windows start...");
                    key.SetValue(Application.ProductName, Application.ExecutablePath);
                }
                else if (check != null && !string.IsNullOrEmpty((string)check.GetValue(Application.ProductName)))
                {
                    Logging.Log("Removing Windows Registry entry for autostart on windows start...");
                    key.DeleteValue(Application.ProductName);
                }
            }
            if (Settings.Default.GeneralStartupConnect != this.cbGeneralStartupConnect.Checked)
            {
                if (this.cbGeneralStartupConnect.Checked && !this.xbmc.IsAlive)
                {
                    Logging.Log("Auto-connecting to XBMC");
                    this.xbmcConnect(true);
                }
                else if (!this.cbGeneralStartupConnect.Checked && this.xbmcConnectionTimer.Enabled)
                {
                    Logging.Log("Stopping XBMC auto-connection interval");
                    this.xbmcConnectionTimer.Stop();
                }
            }
            if (Settings.Default.XbmcIp != this.tbXbmcConnectionIp.Text || Settings.Default.XbmcPort != Convert.ToInt32(this.tbXbmcConnectionPort.Text) ||
                Settings.Default.XbmcUsername != this.tbXbmcConnectionUsername.Text || Settings.Default.XbmcPassword != this.tbXbmcConnectionPassword.Text ||
                Settings.Default.XbmcTcpPort != Convert.ToInt32(this.tbXbmcTcpPort.Text))
            {
                xbmcConnectionChanged = true;

                this.xbmcHandler.CancelAsync();
                this.xbmcHandler.Dispose();

                if (this.xbmc.IsAlive)
                {
                    this.xbmcDisconnect(true);
                    this.xbmc.System.Hibernating -= xbmcShutdown;
                    this.xbmc.System.ShuttingDown -= xbmcShutdown;
                    this.xbmc.System.Rebooting -= xbmcShutdown;
                    this.xbmc.System.Sleeping -= xbmcShutdown;
                    this.xbmc.System.Suspending -= xbmcShutdown;
                    this.xbmc.Aborted -= xbmcShutdown;
                    this.xbmc.LogError -= wrapperApiXbmcLogError;
                    if (Settings.Default.GeneralDebugEnable)
                    {
                        this.xbmc.Log -= wrapperApiXbmcLog;
                    }
                    this.xbmc.Dispose();
                }
            }
            if (Settings.Default.XbmcConnectionInterval != Convert.ToInt32(this.nudXbmcConnectionInterval.Value)) 
            {
                this.xbmcConnectionTimer.Interval = Convert.ToInt32(this.nudXbmcConnectionInterval.Value) * 1000;
            }
            if (Settings.Default.GeneralDebugEnable != this.cbGeneralDebugEnable.Checked)
            {
                if (this.cbGeneralDebugEnable.Checked)
                {
                    this.imon.Log += wrapperApiIMonLog;
                    this.xbmc.Log += wrapperApiXbmcLog;
                }
                else
                {
                    this.imon.Log -= wrapperApiIMonLog;
                    this.xbmc.Log -= wrapperApiXbmcLog;
                }
            }

            // General settings
            Settings.Default.GeneralStartupAuto = this.cbGeneralStartupAuto.Checked;
            Settings.Default.GeneralStartupConnect = this.cbGeneralStartupConnect.Checked;
            Settings.Default.GeneralCheckForUpdateOnStart = this.cbGeneralCheckForUpdateOnStart.Checked;

            Settings.Default.GeneralTrayEnabled = this.cbGeneralTrayEnabled.Checked;
            Settings.Default.GeneralTrayStartMinimized = this.cbGeneralTrayStartMinimized.Checked;
            Settings.Default.GeneralTrayHideOnMinimize = this.cbGeneralTrayHideOnMinimize.Checked;
            Settings.Default.GeneralTrayHideOnClose = this.cbGeneralTrayHideOnClose.Checked;
            Settings.Default.GeneralTrayDisableBalloonTips = this.cbGeneralTrayDisableBalloonTips.Checked;

            Settings.Default.GeneralDebugEnable = this.cbGeneralDebugEnable.Checked;

            // iMON settings
            Settings.Default.ImonAutoInitialize = this.cbImonGeneralAutoInitialize.Checked;
            Settings.Default.ImonUninitializeOnError = this.cbImonGeneralUninitializeOnError.Checked;

            Settings.Default.ImonLcdScrollingDelay = Convert.ToInt32(this.nudImonLcdScrollingDelay.Value);

            Settings.Default.ImonSoundSystemEnable = this.cbImonSoundSystemEnable.Checked;
            Settings.Default.ImonSoundSystem = this.cbImonSoundSystem.SelectedIndex;
            Settings.Default.ImonSoundSystemSPDIF = this.cbImonSoundSystemSPDIF.Checked;

            // XBMC settings
            Settings.Default.XbmcIp = this.tbXbmcConnectionIp.Text;
            Settings.Default.XbmcPort = Int32.Parse(this.tbXbmcConnectionPort.Text);
            Settings.Default.XbmcTcpPort = Int32.Parse(this.tbXbmcTcpPort.Text);
            Settings.Default.XbmcUsername = this.tbXbmcConnectionUsername.Text;
            Settings.Default.XbmcPassword = this.tbXbmcConnectionPassword.Text;
            Settings.Default.XbmcConnectionInterval = Convert.ToInt32(this.nudXbmcConnectionInterval.Value);

            Settings.Default.XbmcIdleStaticTextEnable = this.rbXbmcIdleStaticTextEnable.Checked;
            Settings.Default.XbmcIdleStaticText = this.tbXbmcIdleStaticText.Text;
            Settings.Default.XbmcIdleTimeShowSeconds = this.cbXbmcIdleShowSeconds.Checked;

            Settings.Default.XbmcControlModeEnable = this.cbXbmcControlModeEnable.Checked;
            Settings.Default.XbmcControlModeDisableDuringPlayback = this.cbXbmcControlModeDisableDuringPlayback.Checked;
            Settings.Default.XbmcControlModeRemoveBrackets = this.cbXbmcControlModeRemoveBrackets.Checked;
            Settings.Default.XbmcControlModeDisplayWindowName = this.cbXbmcControlModeShowWindow.Checked;

            Settings.Default.XbmcGeneralUpdateInterval = Convert.ToInt32(this.nudXbmcIconsUpdateInterval.Value);
            Settings.Default.XbmcGeneralShowVolume = this.cbXbmcIconsVolEnable.Checked;

            Settings.Default.XbmcIconsPlaybackProgress = this.cbXbmcPlayingShowProgress.Checked;
            Settings.Default.XbmcIconsPlaybackMediaType = this.cbXbmcPlayingShowMediaType.Checked;
            Settings.Default.XbmcIconsPlaybackVideoCodecs = this.cbXbmcPlayingVideoCodecs.Checked;
            Settings.Default.XbmcIconsPlaybackAudioCodecs = this.cbXbmcPlayingAudioCodecs.Checked;
            Settings.Default.XbmcIconsPlaybackDiscEnable = this.cbXbmcPlayingDiscEnable.Checked;
            Settings.Default.XbmcIconsPlaybackDiscRotate = this.cbXbmcPlayingDiscRotate.Checked;
            Settings.Default.XbmcIconsPlaybackDiscBottomCircle = this.cbXbmcPlayingDiscBottomCircle.Checked;

            Settings.Default.XbmcMovieSingleTextEnable = this.rbXbmcMovieSingleText.Checked;
            Settings.Default.XbmcMovieSingleText = this.tbXbmcMovieSingleText.Text;

            Settings.Default.XbmcTvShowTvMediaTypeIcon = this.cbXbmcTvMediaTypeIcon.Checked;
            Settings.Default.XbmcTvShowTvHdtvIcon = this.cbXbmcTvShowTvHdtvIcon.Checked;
            Settings.Default.XbmcTvSingleTextEnable = this.rbXbmcTvSingleText.Checked;
            Settings.Default.XbmcTvSingleText = this.tbXbmcTvSingleText.Text;

            Settings.Default.XbmcMusicSingleTextEnable = this.rbXbmcMusicSingleText.Checked;
            Settings.Default.XbmcMusicSingleText = this.tbXbmcMusicSingleText.Text;

            Settings.Default.XbmcMusicVideoSingleTextEnable = this.rbXbmcMusicVideoSingleText.Checked;
            Settings.Default.XbmcMusicVideoSingleText = this.tbXbmcMusicVideoSingleText.Text;

            Settings.Default.Save();
            Logging.Log("Settings saved");

            //Logging.deinitialize();
            //Logging.initialize(FileMode.Append);

            if (xbmcConnectionChanged)
            {
                this.xbmcSetup();
            }

            this.xbmcHandler.Update();

            this.trayIcon.Visible = Settings.Default.GeneralTrayEnabled;
        }

        #endregion

        #region iMON functions

        private void iMonInitialize()
        {
            Logging.Log("Initializing iMON");
            this.imon.Initialize();
        }

        private void iMonUninitialize()
        {
            if (this.imon != null && this.imon.IsInitialized)
            {
                Logging.Log("Uninitializing iMON");
                this.imon.Uninitialize();
            }
        }

        private void iMonStateChanged(bool isInitialized)
        {
            this.miImonInitialize.Enabled = !isInitialized;
            this.miImonUninitialize.Enabled = isInitialized;

            if (isInitialized)
            {
                string display = string.Empty;

                if ((this.imon.DisplayType & iMonDisplayType.LCD) == iMonDisplayType.LCD)
                {
                    display = "LCD";
                }
                if ((this.imon.DisplayType & iMonDisplayType.VFD) == iMonDisplayType.VFD)
                { 
                    if (string.IsNullOrEmpty(display))
                    {
                        display = "VFD";
                    }
                    else 
                    {
                        display += " & VFD";
                    }
                }

                Logging.Log("iMON " + display + " initialized");

                this.trayIcon.Text = "XBMC on iMON" + Environment.NewLine + "Running";
                this.showBalloonTip("Connected to XBMC at " + Settings.Default.XbmcIp + ":" + Settings.Default.XbmcPort +
                                    Environment.NewLine + "iMON " + display + " initialized", ToolTipIcon.Info);

                this.trayMenuImon.Text = "iMON: Uninitialize"; 
            }
            else
            {
                Logging.Log("iMON uninitialized");

                this.trayIcon.Text = "XBMC on iMON" + Environment.NewLine + "Connected";
                this.showBalloonTip("iMON uninitialized", ToolTipIcon.Warning);

                this.trayMenuImon.Text = "iMON: Initialize";
            }
        }

        private void iMonError(iMonErrorType error)
        {
            Logging.Error("iMON reports an error of type " + error);

            switch (error)
            {
                case iMonErrorType.Unknown:
                    this.showBalloonTip("Unknown error in iMON", ToolTipIcon.Error);
                    break;

                case iMonErrorType.OutOfMemory:
                    this.showBalloonTip("iMON is out of memory!" + Environment.NewLine +
                                        "Please restart XBMC on iMON.", ToolTipIcon.Warning);
                    break;

                case iMonErrorType.InvalidPointer:
                case iMonErrorType.InvalidArguments:
                    this.showBalloonTip("Invalid arguments in a call to iMON", ToolTipIcon.Warning);
                    break;

                case iMonErrorType.ApiNotInitialized:
                case iMonErrorType.NotInitialized:
                    this.showBalloonTip("Invalid operation because" + Environment.NewLine + 
                                        "iMON is not initialized.", ToolTipIcon.Error);
                    break;

                case iMonErrorType.NotInPluginMode:
                    this.showBalloonTip("Invalid operation because" + Environment.NewLine + 
                                        "iMON is not in plugin mode.", ToolTipIcon.Error);
                    break;

                case iMonErrorType.iMonClosed:
                    this.showBalloonTip("iMON Manager has been closed.", ToolTipIcon.Info);
                    break;

                case iMonErrorType.HardwareDisconnected:
                    this.showBalloonTip("The iMON Display has been disconnected.", ToolTipIcon.Warning);
                    break;

                case iMonErrorType.PluginModeAlreadyInUse:
                    this.showBalloonTip("Cannot use iMON Display because it" + Environment.NewLine + 
                                        "is already used by another application.", ToolTipIcon.Error);
                    break;

                case iMonErrorType.HardwareNotConnected:
                    this.showBalloonTip("Cannot use iMON Display because" + Environment.NewLine +
                                        "it is not connected.", ToolTipIcon.Error);
                    break;

                case iMonErrorType.HardwareNotSupported:
                    this.showBalloonTip("Cannot use iMON Display because" + Environment.NewLine +
                                        "this hardware is not supported.", ToolTipIcon.Error);
                    break;

                case iMonErrorType.PluginModeDisabled:
                    this.showBalloonTip("Plugin mode must be" + Environment.NewLine +
                                        "enabled in iMON Manager.", ToolTipIcon.Error);
                    break;

                case iMonErrorType.iMonNotResponding:
                    this.showBalloonTip("iMON is not responding." + Environment.NewLine +
                                        "Please restart iMON Manager.", ToolTipIcon.Error);
                    break;
            }

            if (Settings.Default.ImonUninitializeOnError)
            {
                this.iMonUninitialize();
            }
        }

        #endregion

        #region XBMC functions

        private void xbmcSetup()
        {
            Logging.Log("Setting up XBMC connection to " + Settings.Default.XbmcIp + ":" + Settings.Default.XbmcPort);
            this.xbmc = new XbmcJsonRpcConnection(Settings.Default.XbmcIp, Settings.Default.XbmcPort,
                                                  Settings.Default.XbmcUsername, Settings.Default.XbmcPassword);
            this.xbmc.System.Hibernating += xbmcShutdown;
            this.xbmc.System.ShuttingDown += xbmcShutdown;
            this.xbmc.System.Rebooting += xbmcShutdown;
            this.xbmc.System.Sleeping += xbmcShutdown;
            this.xbmc.System.Suspending += xbmcShutdown;
            this.xbmc.Aborted += xbmcShutdown;
            this.xbmc.LogError += wrapperApiXbmcLogError;
            if (Settings.Default.GeneralDebugEnable)
            {
                this.xbmc.Log += wrapperApiXbmcLog;
            }

            this.xbmcHandler = new XbmcHandler(this.xbmc, this.displayHandler);
            this.xbmcHandler.RunWorkerAsync();

            if (Settings.Default.GeneralStartupConnect)
            {
                Logging.Log("Auto-connecting to XBMC at startup");
                this.xbmcConnect(true);
            }
        }

        private void xbmcTryConnect(object sender, EventArgs e)
        {
            this.xbmcConnectionTimer.Stop();

            Logging.Log("Trying to auto-connect with XBMC");
            this.xbmcConnect(true);
        }

        private void xbmcConnect(bool auto)
        {
            if (!this.xbmc.IsAlive)
            {
                Logging.Log("Asynchronous starting to connect with XBMC");
                this.xbmcConnectingDeletage.BeginInvoke(auto, xbmcConnectingFinished, auto);
            }
        }

        private bool xbmcConnecting(bool auto) 
        {
            return this.xbmc.Open(Settings.Default.XbmcTcpPort);
        }

        private void xbmcConnectingFinished(IAsyncResult ar)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new MethodInvoker(delegate() { this.xbmcConnectingFinished(ar); }));
                return;
            }

            bool auto = (bool)ar.AsyncState;

            if (this.xbmcConnectingDeletage.EndInvoke(ar) && this.xbmc.IsAlive)
            {
                Logging.Log("Connection with XBMC established");

                this.trayIcon.Text = "XBMC on iMON" + Environment.NewLine + "Connected";
                if (!Settings.Default.ImonAutoInitialize)
                {
                    this.showBalloonTip("Connected to XBMC at " + Settings.Default.XbmcIp + ":" + 
                                        Settings.Default.XbmcPort, ToolTipIcon.Info);
                }

                this.miXbmcConnect.Enabled = false;
                this.miXbmcDisconnect.Enabled = true;
                this.miXbmcInfo.Text = "Build " + this.xbmc.Xbmc.BuildVersion + " (" + this.xbmc.Xbmc.BuildDate.ToShortDateString() + ")";

                this.miImon.Enabled = true;
                this.miImonInitialize.Enabled = true;
                this.miImonUninitialize.Enabled = false;

                this.trayMenuXBMC.Text = "XBMC: Disconnect";
                this.trayMenuImon.Text = "iMON: Initialize";
                this.trayMenuImon.Enabled = true;

                if (Settings.Default.ImonAutoInitialize)
                {
                    this.iMonInitialize();
                }
            }
            else if (!auto)
            {
                Logging.Log("Connection with XBMC failed");

                if (MessageBox.Show("Cannot connect to XBMC at" + Environment.NewLine + Settings.Default.XbmcIp + ":" + Settings.Default.XbmcPort, "XBMC Connection",
                                MessageBoxButtons.RetryCancel, MessageBoxIcon.Error) == DialogResult.Retry)
                {
                    this.xbmcConnect(false);
                }
            }
            else
            {
                Logging.Log("Connection with XBMC failed");

                this.xbmcConnectionTimer.Start();
            }
        }

        private void xbmcDisconnect(bool forceClose)
        {
            this.iMonUninitialize();
            if (forceClose)
            {
                Logging.Log("Disconnecting from XBMC");
                this.xbmc.Close();
            }
            else
            {
                this.trayIcon.Text = "XBMC on iMON" + Environment.NewLine + "Disconnected";
                this.showBalloonTip("XBMC disconnected", ToolTipIcon.Warning);
            }

            this.miXbmcConnect.Enabled = true;
            this.miXbmcDisconnect.Enabled = false;
            this.miXbmcInfo.Text = "Build unknown";

            this.miImon.Enabled = false;

            this.trayMenuXBMC.Text = "XBMC: Connect";
            this.trayMenuImon.Text = "iMON: Initialize";
            this.trayMenuImon.Enabled = false;

            if (Settings.Default.GeneralStartupConnect && !forceClose)
            {
                this.xbmcConnectionTimer.Start();
            }
        }

        private void xbmcShutdown(object sender, EventArgs args)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new MethodInvoker(delegate() { this.xbmcShutdown(sender, args); }));
                return;
            }

            Logging.Log("XBMC has been closed");

            this.displayHandler.SetText("XBMC Shutdown", "XBMC", "Shutdown");
            System.Threading.Thread.Sleep(2000);
            this.xbmcDisconnect(false);
        }

        #endregion
    }
}