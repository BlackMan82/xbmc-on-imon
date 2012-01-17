using System;
using System.Threading;
using System.Timers;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;

using Newtonsoft.Json;

using iMon.DisplayApi;
using XBMC.JsonRpc;
using iMon.XBMC.Properties;
using System.Text;

namespace iMon.XBMC
{
    internal partial class XbmcHandler : BackgroundWorker
    {
        #region Enums

        private enum PlayerState 
        {
            Stopped,
            Playing,
            Paused
        }

        #endregion

        #region Private variables

        // TODO: Implement ProgressUpdateInterval as an option within settings
        private const int ProgressUpdateInterval = 5000;
        private const int SystemTimeUpdateInterval = 1000;
        private const int DefaultTextDelay = 2000;
        private const int ControlModeUpdateInterval = 500;
        private const int ControlModeUnchangedDelay = 10000;
        private const string LoggingArea = "XBMC Handler";

        private Semaphore semReady;
        private Semaphore semWork;

        private bool connected;

        private XbmcJsonRpcConnection xbmc;
        private DisplayHandler display;

        private XbmcMediaPlayer player;
        private XbmcPlayable currentlyPlaying;
        private PlayerState playerState; 

        private TimeSpan length;
        private TimeSpan position;
        private System.Timers.Timer progressTimer;

        private DateTime systemTime;
        private bool showSystemTime;
        private bool validSystemTime;
        private System.Timers.Timer systemTimeTimer;

        private ControlState controlModeState;
        private System.Timers.Timer controlModeTimer;
        private int controlModeUnchanged;

        private static object connectionLocking = new object();

        #endregion

        #region Public variables

        #endregion

        #region Constructor

        public XbmcHandler(XbmcJsonRpcConnection xbmc, DisplayHandler display)
        {
            if (xbmc == null)
            {
                throw new ArgumentNullException("xbmc");
            }
            if (display == null)
            {
                throw new ArgumentNullException("display");
            }

            this.xbmc = xbmc;
            this.display = display;

            this.xbmc.Connected                     +=  this.xbmcConnected;
            this.xbmc.Aborted                       +=  this.xbmcAborted;
            this.xbmc.Player.PlaybackStarted        +=  this.xbmcPlaybackStarted;
            this.xbmc.Player.PlaybackPaused         +=  this.xbmcPlaybackPaused;
            //this.xbmc.Player.PlaybackResumed        +=  this.xbmcPlaybackResumed;
            this.xbmc.Player.PlaybackStopped        +=  this.xbmcPlaybackStopped;
            this.xbmc.Player.PlaybackEnded          +=  this.xbmcPlaybackEnded;
            this.xbmc.Player.PlaybackSeek           +=  this.xbmcPlaybackSeek;
            this.xbmc.Player.PlaybackSeekChapter    +=  this.xbmcPlaybackSeek;
            this.xbmc.Player.PlaybackSpeedChanged   +=  this.xbmcPlaybackSpeedChanged;

            this.progressTimer = new System.Timers.Timer();
            this.progressTimer.Interval = ProgressUpdateInterval;
            this.progressTimer.Elapsed += progressTimerUpdate;
            this.progressTimer.AutoReset = true;

            this.systemTimeTimer = new System.Timers.Timer();
            this.systemTimeTimer.Interval = SystemTimeUpdateInterval;
            this.systemTimeTimer.Elapsed += systemTimeTimerUpdate;
            this.systemTimeTimer.AutoReset = true;

            this.WorkerReportsProgress = false;
            this.WorkerSupportsCancellation = true;

            this.controlModeState = new ControlState();
            this.controlModeTimer = new System.Timers.Timer();
            this.controlModeTimer.Interval = ControlModeUpdateInterval;
            this.controlModeTimer.Elapsed += controlModeTimerUpdate;
            this.controlModeTimer.AutoReset = true;

            this.semReady = new Semaphore(0, 1);
            this.semWork = new Semaphore(0, 1);
        }

        #endregion

        #region Public functions

        public void Update()
        {
            Logging.Log(LoggingArea, "Update");
            if (!this.connected)
            {
                // No need to do anything as long as we are not connected with XBMC
                return;
            }

            this.updateIcons();

            this.showSystemTime = !Settings.Default.XbmcIdleStaticTextEnable && !Settings.Default.XbmcControlModeEnable;

            if (this.player != null)
            {
                this.updateCurrentlyPlaying();
            }
            else if (!Settings.Default.XbmcControlModeEnable)
            {
                this.displayIdle();
            }

            this.updateProgress();

            // Updating the control mode timer
            this.controlModeState.Window = null;
            this.controlModeState.Control = null;
            if (Settings.Default.XbmcControlModeEnable && !this.controlModeTimer.Enabled)
            {
                this.controlModeTimer.Start();
            }
            else if (!Settings.Default.XbmcControlModeEnable && this.controlModeTimer.Enabled)
            {
                this.controlModeTimer.Stop();
            }
        }

        #endregion

        #region Overrides of BackgroundWorker

        protected override void OnDoWork(DoWorkEventArgs e)
        {
            while (!this.CancellationPending)
            {
                // Wait until a connection has been established
                this.semReady.WaitOne();

                Logging.Log(LoggingArea, "Start working");

                if (Settings.Default.XbmcControlModeEnable)
                {
                    this.controlModeTimer.Start();
                }

                while (!this.CancellationPending && this.connected)
                {
                    this.semWork.WaitOne();

                    this.Update();
                }

                Logging.Log(LoggingArea, "Stop working");
            }

            Logging.Log(LoggingArea, "Cancelled");

            this.xbmc.Player.PlaybackStarted -= this.xbmcPlaybackStarted;
            this.xbmc.Player.PlaybackPaused -= this.xbmcPlaybackPaused;
            //this.xbmc.Player.PlaybackResumed -= this.xbmcPlaybackResumed;
            this.xbmc.Player.PlaybackStopped -= this.xbmcPlaybackStopped;
            this.xbmc.Player.PlaybackEnded -= this.xbmcPlaybackEnded;
            this.xbmc.Player.PlaybackSeek -= this.xbmcPlaybackSeek;
            this.xbmc.Player.PlaybackSeekChapter -= this.xbmcPlaybackSeek;
            this.xbmc.Player.PlaybackSpeedChanged -= this.xbmcPlaybackSpeedChanged;
        }

        #endregion

        #region Event handlers

        private void xbmcConnected(object sender, EventArgs e)
        {
            lock (connectionLocking)
            {
                this.connected = true;

                bool audio, video, pictures;
                int id;
                this.xbmc.Player.GetActivePlayers(out video, out audio, out pictures, out id);

                if (video)
                {
                    this.player = this.xbmc.Player.Video;
                }
                else if (audio)
                {
                    this.player = this.xbmc.Player.Audio;
                }
                else if (pictures)
                {
                    this.player = this.xbmc.Player.Pictures;
                }
            }

            this.semReady.Release();

            if (this.player != null)
            {
                this.getTime(out this.position, out this.length);
                this.progressTimer.Start();
            }

            try
            {
                IDictionary<string, string> time = this.xbmc.System.GetInfoLabels("System.Time(hh)",
                                                                                  "System.Time(mm)",
                                                                                  "System.Time(ss)");
                this.systemTime = DateTime.Now;
                this.systemTime -= this.systemTime.TimeOfDay;
                this.systemTime +=
                    TimeSpan.Parse(time["System.Time(hh)"] + ":" + time["System.Time(mm)"] + ":" +
                                   time["System.Time(ss)"]);
                this.validSystemTime = true;

                this.systemTimeTimer.Start();
            }
            catch (Exception ex)
            {
                this.validSystemTime = false;
                Logging.Error("XBMC", "Could not get current time", ex);
            }

            if (Settings.Default.XbmcOnConnectedText.CompareTo("") != 0)
            {
                this.display.SetText(Settings.Default.XbmcOnConnectedText, Settings.Default.XbmcOnEventTextDelayMS);
            }

            this.update();
        }

        private void xbmcAborted(object sender, EventArgs e)
        {
            lock (connectionLocking)
            {
                this.connected = false;
            }

            this.playbackStopped();
            this.update();
        }

        private void xbmcPlaybackStarted(object sender, XbmcPlayerPlaybackChangedEventArgs e)
        {
            if (e == null || e.Player == null)
            {
                return;
            }

            Logging.Log(LoggingArea, "Playback started");

            this.player = e.Player;
            this.playerState = PlayerState.Playing;

            this.getTime(out this.position, out this.length);
            Logging.Log(LoggingArea, "Position " + this.position.TotalSeconds + " of " + this.length.TotalSeconds + " [s]");
            this.progressTimer.Start();

            if (Settings.Default.XbmcOnPlayText.CompareTo("") != 0)
            {
                this.display.SetText(Settings.Default.XbmcOnPlayText, Settings.Default.XbmcOnEventTextDelayMS);
            }

            this.update();
        }

        private void xbmcPlaybackPaused(object sender, XbmcPlayerPlaybackPositionChangedEventArgs e)
        {
            if (e == null || e.Player == null)
            {
                return;
            }

            Logging.Log(LoggingArea, "Playback paused");

            this.playerState = PlayerState.Paused;

            this.progressTimer.Stop();
            this.position = e.Position;
            this.updateProgress();

            if (Settings.Default.XbmcOnPauseText.CompareTo("") != 0)
            {
                this.display.SetText(Settings.Default.XbmcOnPauseText, Settings.Default.XbmcOnPauseText, e.Position.ToString(), Settings.Default.XbmcOnEventTextDelayMS);
            }

            this.update();
        }

        //private void xbmcPlaybackResumed(object sender, XbmcPlayerPlaybackPositionChangedEventArgs e)
        //{
        //    if (e == null || e.Player == null)
        //    {
        //        return;
        //    }

        //    Logging.Log(LoggingArea, "Playback resumed");

        //    this.playerState = PlayerState.Playing;

        //    this.position = e.Position;
        //    this.updateProgress();
        //    this.progressTimer.Start();

        //    this.update();
        //}

        private void xbmcPlaybackStopped(object sender, EventArgs e)
        {
            Logging.Log(LoggingArea, "Playback stopped");

            this.playbackStopped();
            if (Settings.Default.XbmcOnStopText.CompareTo("") != 0)
            {
                this.display.SetText(Settings.Default.XbmcOnStopText, Settings.Default.XbmcOnEventTextDelayMS);
            }
            //this.display.SetText("STOP", "Playback", "stopped", DefaultTextDelay);

            this.update();
        }

        private void xbmcPlaybackEnded(object sender, EventArgs e)
        {
            Logging.Log(LoggingArea, "Playback ended");

            this.playbackStopped();
            if (Settings.Default.XbmcOnEndText.CompareTo("") != 0)
            {
                this.display.SetText(Settings.Default.XbmcOnEndText, Settings.Default.XbmcOnEventTextDelayMS);
            }
            //this.display.SetText("Playback ended", "Playback", "ended", DefaultTextDelay);

            this.update();
        }

        private void xbmcPlaybackSeek(object sender, XbmcPlayerPlaybackPositionChangedEventArgs e)
        {
            if (e == null || e.Player == null)
            {
                return;
            }

            Logging.Log(LoggingArea, "Playback seek");

            this.length = e.Length;
            this.position = e.Position;
            if (this.position.TotalMilliseconds < 0)
            {
                this.position = new TimeSpan();
            }

            this.updateProgress();
        }

        private void xbmcPlaybackSpeedChanged(object sender, XbmcPlayerPlaybackSpeedChangedEventArgs e)
        {
            if (e == null || e.Player == null)
            {
                return;
            }

            Logging.Log(LoggingArea, "Playback speed changed");

            this.position = e.Position;
            this.length = e.Length;
            this.updateProgress();

            if (e.Speed < 0)
            {
                this.display.SetText("Rewinding (" + (-e.Speed) + "x)", "Rewinding", (-e.Speed).ToString());

                this.progressTimer.Stop();
            }
            else if (e.Speed > 1)
            {
                this.display.SetText("Forwarding (" + e.Speed + "x)", "Rewinding", e.Speed.ToString());

                this.progressTimer.Stop();
            }
            else
            {
                this.update();

                this.progressTimer.Start();
            }
        }

        private void progressTimerUpdate(object sender, ElapsedEventArgs e) 
        {
            this.position += TimeSpan.FromMilliseconds(ProgressUpdateInterval);
            Logging.Log(LoggingArea, "Position updated to " + this.position.TotalSeconds + " of " + this.length.TotalSeconds + " [s]");
            this.updateProgress();
        }

        private void systemTimeTimerUpdate(object sender, ElapsedEventArgs e)
        {
            this.systemTime += TimeSpan.FromMilliseconds(SystemTimeUpdateInterval);

            if (this.showSystemTime && this.validSystemTime)
            {
                if (Settings.Default.XbmcIdleTimeShowSeconds)
                {
                    this.display.SetText(this.systemTime.ToLongTimeString());
                }
                else
                {
                    this.display.SetText(this.systemTime.ToShortTimeString());
                }
            }
        }

        private void controlModeTimerUpdate(object sender, ElapsedEventArgs e)
        {
            this.controlModeTimer.Stop();

            lock (connectionLocking)
            {
                if (!Settings.Default.XbmcControlModeEnable || !this.connected)
                {
                    this.controlModeTimer.Stop();
                
                    if (this.connected)
                    {
                        this.updateCurrentlyPlaying();
                    }

                    return;
                }
            }

            if (this.controlModeUnchanged >= 0)
            {
                this.controlModeUnchanged += Convert.ToInt32(this.controlModeTimer.Interval);
            }

            if (this.playerState != PlayerState.Stopped && Settings.Default.XbmcControlModeDisableDuringPlayback)
            {
                this.checkControlModeUnchanged();
                //return;
            }
            else
            {
                IDictionary<string, string> info = xbmc.System.GetInfoLabels("System.CurrentWindow", "System.CurrentControl");
                if (info.Count != 2 || string.IsNullOrEmpty(info["System.CurrentControl"]))
                {
                    this.checkControlModeUnchanged();
                    //return;
                }
                else
                {
                    string display = string.Empty;
                    if (Settings.Default.XbmcControlModeDisplayWindowName && !string.IsNullOrEmpty(info["System.CurrentWindow"]))
                    {
                        display = info["System.CurrentWindow"] + ": ";
                    }

                    string control = info["System.CurrentControl"];
                    if (Settings.Default.XbmcControlModeRemoveBrackets && control.StartsWith("[") && control.EndsWith("]"))
                    {
                        control = control.Remove(0, 1);
                        control = control.Remove(control.Length - 1, 1);
                    }

                    if (this.controlModeState.Window == info["System.CurrentWindow"] && this.controlModeState.Control == control)
                    {
                        this.checkControlModeUnchanged();
                        //return;
                    }
                    else
                    {
                        this.display.SetText(display + control);

                        this.controlModeState.Window = info["System.CurrentWindow"];
                        this.controlModeState.Control = control;
                        this.controlModeUnchanged = 0;
                    }
                }
            }

            this.controlModeTimer.Start();
        }

        #endregion

        #region Private functions

        private void update()
        {
            try
            {
                this.semWork.Release();
            }
            catch (SemaphoreFullException)
            { }
        }

        private void updateIcons()
        {
            Logging.Log(LoggingArea, "Updating icons");

            // Updating Speaker icons
            this.display.SetIcons(new List<iMonLcdIcons>()
            {
                iMonLcdIcons.SpeakerFrontLeft, 
                iMonLcdIcons.SpeakerCenter,
                iMonLcdIcons.SpeakerFrontRight,
                iMonLcdIcons.SpeakerSideLeft,
                iMonLcdIcons.SpeakerLFE,
                iMonLcdIcons.SpeakerSideRight,
                iMonLcdIcons.SpeakerRearLeft,
                iMonLcdIcons.SpeakerSPDIF,
                iMonLcdIcons.SpeakerRearRight,

                iMonLcdIcons.Music, 
                iMonLcdIcons.Movie, 
                iMonLcdIcons.Tv, 
                iMonLcdIcons.Photo, 
                iMonLcdIcons.Webcast, 
                iMonLcdIcons.NewsWeather,

                iMonLcdIcons.AudioMP3,
                iMonLcdIcons.AudioOGG,
                iMonLcdIcons.AudioWAV,
                iMonLcdIcons.AudioWMA,

                iMonLcdIcons.VideoAC3,
                iMonLcdIcons.VideoDTS,
                iMonLcdIcons.VideoMPGAudio,
                iMonLcdIcons.VideoWMA,
                iMonLcdIcons.VideoDivX,
                iMonLcdIcons.VideoXviD,
                iMonLcdIcons.VideoMPG,
                iMonLcdIcons.VideoWMV,

                iMonLcdIcons.AspectRatioTv,
                iMonLcdIcons.AspectRatioHDTV
            }, false);

            List<iMonLcdIcons> icons = new List<iMonLcdIcons>();
            if (Settings.Default.ImonSoundSystemEnable)
            {
                if (Settings.Default.ImonSoundSystemSPDIF)
                {
                    icons.Add(iMonLcdIcons.SpeakerSPDIF);
                }

                XbmcSoundSystems sound = (XbmcSoundSystems)Settings.Default.ImonSoundSystem;
                if (sound == XbmcSoundSystems.Mono_1_0)
                {
                    icons.Add(iMonLcdIcons.SpeakerCenter);
                }
                else
                {
                    icons.Add(iMonLcdIcons.SpeakerFrontLeft);
                    icons.Add(iMonLcdIcons.SpeakerFrontRight);

                    switch (sound)
                    {
                        case XbmcSoundSystems.Stereo_2_1:
                            icons.Add(iMonLcdIcons.SpeakerLFE);
                            break;

                        case XbmcSoundSystems.Quad_4_0:
                            icons.Add(iMonLcdIcons.SpeakerRearLeft);
                            icons.Add(iMonLcdIcons.SpeakerRearRight);
                            break;

                        case XbmcSoundSystems.Surround_5_0:
                            icons.Add(iMonLcdIcons.SpeakerRearLeft);
                            icons.Add(iMonLcdIcons.SpeakerRearRight);
                            icons.Add(iMonLcdIcons.SpeakerCenter);
                            break;

                        case XbmcSoundSystems.Surround_5_1:
                            icons.Add(iMonLcdIcons.SpeakerRearLeft);
                            icons.Add(iMonLcdIcons.SpeakerRearRight);
                            icons.Add(iMonLcdIcons.SpeakerCenter);
                            icons.Add(iMonLcdIcons.SpeakerLFE);
                            break;

                        case XbmcSoundSystems.Side_5_1:
                            icons.Add(iMonLcdIcons.SpeakerSideLeft);
                            icons.Add(iMonLcdIcons.SpeakerSideRight);
                            icons.Add(iMonLcdIcons.SpeakerCenter);
                            icons.Add(iMonLcdIcons.SpeakerLFE);
                            break;

                        case XbmcSoundSystems.Surround_7_1:
                            icons.Add(iMonLcdIcons.SpeakerSideLeft);
                            icons.Add(iMonLcdIcons.SpeakerSideRight);
                            icons.Add(iMonLcdIcons.SpeakerRearLeft);
                            icons.Add(iMonLcdIcons.SpeakerRearRight);
                            icons.Add(iMonLcdIcons.SpeakerCenter);
                            icons.Add(iMonLcdIcons.SpeakerLFE);
                            break;
                    }
                }
            }

            this.display.SetIcons(icons, true);

            if (Settings.Default.XbmcIconsPlaybackDiscEnable && this.playerState != PlayerState.Stopped)
            {
                if (Settings.Default.XbmcIconsPlaybackDiscRotate)
                {
                    if (this.playerState == PlayerState.Playing)
                    {
                        this.display.RotateDisc(Settings.Default.XbmcIconsPlaybackDiscBottomCircle);
                    }
                    else
                    {
                        this.display.PauseDisc();
                    }
                }
                else
                {
                    this.display.ShowDisc(Settings.Default.XbmcIconsPlaybackDiscBottomCircle);
                }
            }
            else
            {
                this.display.HideDisc();
            }

            // TODO: Updating VOL/REP/SFL/... icons
        }

        private void displayIdle()
        {
            Logging.Log(LoggingArea, "Displaying Idle");

            if (Settings.Default.XbmcIdleStaticTextEnable)
            {
                this.display.SetText(Settings.Default.XbmcIdleStaticText);
            }
        }

        private void updateProgress()
        {
            /* TODO: How to disable the progress indicator?
            if (!Settings.Default.XbmcIconsPlaybackProgress)
            {
                this.display.SetProgress(0, 0);
            }*/

            Logging.Log(LoggingArea, "Display handler: " + this.display.ToString());
            this.display.SetProgress(this.position, this.length);
        }

        private void playbackStopped()
        {
            this.playerState = PlayerState.Stopped;
            this.player = null;
            this.currentlyPlaying = null;

            this.progressTimer.Stop();
            this.position = new TimeSpan();
            this.length = new TimeSpan();

            this.Update();
        }

        private void updateCurrentlyPlaying()
        {
            if (this.player == null)
            {
                return;
            }

            Logging.Log(LoggingArea, "Updating currently playing file");

            // TODO: Show SFL this.display.SetIcon(iMonLcdIcons.Shuffle, this.player.Random);
            // TODO: Show REP this.display.SetIcon(iMonLcdIcons.Repeat, this.player.Repeat != XbmcRepeatTypes.Off);
            iMonLcdIcons icon;
            Logging.Log(LoggingArea, "Current player: " + this.player.ToString());
            if (this.player is XbmcAudioPlayer)
            {
                if (!Settings.Default.XbmcIdleStaticTextEnable)
                {
                    this.showSystemTime = !Settings.Default.XbmcMusicSingleTextEnable;
                }

                icon = iMonLcdIcons.Music;
                this.currentlyPlaying = this.xbmc.Playlist.Audio.GetCurrentItem();

                //Logging.Log(LoggingArea, "Current audio item: " + this.currentlyPlaying.);

                this.displaySong();
                this.displayAudioCodecs();
            }
            else if (this.player is XbmcPicturePlayer)
            {
                icon = iMonLcdIcons.Photo;
                if (!Settings.Default.XbmcIdleStaticTextEnable)
                {
                    this.displaySlideshow();
                }
            }
            else
            {
                icon = iMonLcdIcons.Movie;
                this.currentlyPlaying = this.xbmc.Playlist.Video.GetCurrentItem();

                if (this.currentlyPlaying is XbmcTvEpisode)
                {
                    if (!Settings.Default.XbmcIdleStaticTextEnable)
                    {
                        this.showSystemTime = !Settings.Default.XbmcTvSingleTextEnable;
                    }

                    if (Settings.Default.XbmcTvShowTvMediaTypeIcon)
                    {
                        icon = iMonLcdIcons.Tv;
                    }
                    if (Settings.Default.XbmcTvShowTvHdtvIcon)
                    {
                        string res = this.xbmc.System.GetInfoLabel("VideoPlayer.VideoResolution");
                        Logging.Log(LoggingArea, "Retrieved video resolution: " + res);
                        int resolution;
                        if (!string.IsNullOrEmpty(res) && Int32.TryParse(res, out resolution) && resolution >= 720)
                        {
                            this.display.SetIcon(iMonLcdIcons.AspectRatioHDTV, true);
                        }
                        else
                        {
                            this.display.SetIcon(iMonLcdIcons.AspectRatioTv, true);
                        }
                    }

                    this.displayTvEpisode();
                }
                else if (this.currentlyPlaying is XbmcMusicVideo)
                {
                    if (!Settings.Default.XbmcIdleStaticTextEnable)
                    {
                        this.showSystemTime = !Settings.Default.XbmcMusicVideoSingleTextEnable;
                    }

                    this.displayMusicVideo();
                }
                else
                {
                    if (!Settings.Default.XbmcIdleStaticTextEnable)
                    {
                        this.showSystemTime = !Settings.Default.XbmcMovieSingleTextEnable;
                    }

                    this.displayMovie();
                }

                this.displayVideoCodecs();
            }

            if (Settings.Default.XbmcIconsPlaybackMediaType)
            {
                this.display.SetIcon(icon, true);
            }
        }

        private void getTime(out TimeSpan position, out TimeSpan length)
        {
            position = new TimeSpan();
            length = new TimeSpan();

            XbmcPlayerState state = XbmcPlayerState.Unavailable;

            if (this.player is XbmcVideoPlayer)
            {
                state = ((XbmcVideoPlayer)this.player).GetTime(out this.position, out this.length);
            } 
            if (this.player is XbmcAudioPlayer)
            {
                state = ((XbmcAudioPlayer)this.player).GetTime(out this.position, out this.length);
            }

            switch (state)
            {
                case XbmcPlayerState.Playing:
                case XbmcPlayerState.PartyMode:
                    this.playerState = PlayerState.Playing;
                    break;

                case XbmcPlayerState.Paused:
                    this.playerState = PlayerState.Paused;
                    break;

                default:
                    this.playerState = PlayerState.Stopped;
                    break;
            }
        }

        private void checkControlModeUnchanged()
        {
            if (this.controlModeUnchanged >= ControlModeUnchangedDelay)
            {
                this.controlModeUnchanged = -1;
                this.updateCurrentlyPlaying();
            }
        }

        private void displayVideoCodec(string codec)
        {
            Logging.Log(LoggingArea, "Trying to display video codec " + codec);
            if (codec == "DivX")
            {
                this.display.SetIcon(iMonLcdIcons.VideoDivX, true);
            }
            if (codec == "XviD")
            {
                this.display.SetIcon(iMonLcdIcons.VideoXviD, true);
            }
            if (codec == "WMV")
            {
                this.display.SetIcon(iMonLcdIcons.VideoWMV, true);
            }
            if (codec == "MPG")
            {
                this.display.SetIcon(iMonLcdIcons.VideoMPG, true);
            }
        }

        private void displayAudioCodec(string codec, bool audio)
        {
            Logging.Log(LoggingArea, "Trying to display audio codec " + codec);
            if (codec == "MP3")
            {
                this.display.SetIcon(iMonLcdIcons.AudioMP3, true);
            }
            else if (codec == "OGG")
            {
                this.display.SetIcon(iMonLcdIcons.AudioOGG, true);
            }
            else if (codec == "WAV")
            {
                this.display.SetIcon(iMonLcdIcons.AudioWAV, true);
            }
            else if (codec == "AC3")
            {
                this.display.SetIcon(iMonLcdIcons.VideoAC3, true);
            }
            else if (codec == "DTS")
            {
                this.display.SetIcon(iMonLcdIcons.VideoDTS, true);
            }
            else if (codec == "MPG")
            {
                this.display.SetIcon(iMonLcdIcons.VideoMPGAudio, true);
            }
            else if (codec == "WMA")
            {
                if (audio)
                {
                    this.display.SetIcon(iMonLcdIcons.AudioWMA, true);
                }
                else
                {
                    this.display.SetIcon(iMonLcdIcons.VideoWMA, true);
                }
            }
        }

        private static bool listContains(IEnumerable<string> list, string value)
        {
            foreach (string val in list)
            {
                if (val.Equals(value, StringComparison.InvariantCultureIgnoreCase))
                {
                    return true;
                }
            }

            return false;
        }

        private void displayMovie()
        {
            List<string> texts = new List<string>();

            string[] patterns = null;
            if (Settings.Default.XbmcMovieSingleTextEnable)
            {
                patterns = new string[] { Settings.Default.XbmcMovieSingleText };
            }
            else
            {
                return;
            }

            if (this.currentlyPlaying != null)
            {
                texts = buildMovieInfo(patterns, (XbmcMovie)this.currentlyPlaying);
            }
            else
            {
                IDictionary<string, string> info = this.getVideoPlayerInfoLabels();
                if (info.Count > 0)
                {
                    Dictionary<string, string> data = new Dictionary<string, string>(info.Count);
                    if (info.ContainsKey("VideoPlayer.Title"))      { data.Add("title", info["VideoPlayer.Title"]); }
                    if (info.ContainsKey("VideoPlayer.Year"))       { data.Add("year", info["VideoPlayer.Year"]); }
                    if (info.ContainsKey("VideoPlayer.Rating"))     { data.Add("rating", info["VideoPlayer.Rating"]); }
                    if (info.ContainsKey("VideoPlayer.Genre"))      { data.Add("genre", info["VideoPlayer.Genre"]); }
                    try
                    {
                        if (info.ContainsKey("VideoPlayer.Duration")) { data.Add("duration", TimeSpan.Parse(info["VideoPlayer.Duration"]).TotalMinutes.ToString("0")); }
                    }
                    catch (FormatException)
                    { }
                    if (info.ContainsKey("VideoPlayer.mpaa"))       { data.Add("mpaa", info["VideoPlayer.mpaa"]); }
                    if (info.ContainsKey("VideoPlayer.Tagline"))    { data.Add("tagline", info["VideoPlayer.Tagline"]); }
                    if (info.ContainsKey("VideoPlayer.Studio"))     { data.Add("studio", info["VideoPlayer.Studio"]); }
                    if (info.ContainsKey("VideoPlayer.Director"))   { data.Add("director", info["VideoPlayer.Director"]); }
                    if (info.ContainsKey("VideoPlayer.Writer"))     { data.Add("writer", info["VideoPlayer.Writer"]); }
                    if (info.ContainsKey("VideoPlayer.PlotOutline")){ data.Add("outline", info["VideoPlayer.PlotOutline"]); }
                    if (info.ContainsKey("VideoPlayer.Plot"))       { data.Add("plot", info["VideoPlayer.Plot"]); }

                    texts = buildInfoText(patterns, data);
                }
            }

            this.displayNowPlaying(texts);
        }

        private void displayTvEpisode()
        {
            List<string> texts = new List<string>();

            string[] patterns = null;
            if (Settings.Default.XbmcMovieSingleTextEnable)
            {
                patterns = new string[] { Settings.Default.XbmcTvSingleText };
            }
            else
            {
                return;
            }

            if (this.currentlyPlaying != null)
            {
                texts = buildTvEpisodeInfo(patterns, (XbmcTvEpisode)this.currentlyPlaying);
            }
            else
            {
                IDictionary<string, string> info = this.getVideoPlayerInfoLabels();
                if (info.Count > 0)
                {
                    Dictionary<string, string> data = new Dictionary<string, string>(info.Count);
                    if (info.ContainsKey("VideoPlayer.Title"))          { data.Add("title", info["VideoPlayer.Title"]); }
                    if (info.ContainsKey("VideoPlayer.TVShowTitle"))    { data.Add("show", info["VideoPlayer.TVShowTitle"]); }
                    if (info.ContainsKey("VideoPlayer.Year"))           { data.Add("year", info["VideoPlayer.Year"]); }
                    if (info.ContainsKey("VideoPlayer.Rating"))         { data.Add("rating", info["VideoPlayer.Rating"]); }
                    try
                    {
                        if (info.ContainsKey("VideoPlayer.Duration"))   { data.Add("duration", TimeSpan.Parse(info["VideoPlayer.Duration"]).TotalMinutes.ToString("0")); }
                    }
                    catch (FormatException)
                    { }
                    if (info.ContainsKey("VideoPlayer.mpaa"))           { data.Add("mpaa", info["VideoPlayer.mpaa"]); }
                    if (info.ContainsKey("VideoPlayer.Studio"))         { data.Add("studio", info["VideoPlayer.Studio"]); }
                    if (info.ContainsKey("VideoPlayer.Director"))       { data.Add("director", info["VideoPlayer.Director"]); }
                    if (info.ContainsKey("VideoPlayer.Writer"))         { data.Add("writer", info["VideoPlayer.Writer"]); }
                    if (info.ContainsKey("VideoPlayer.Plot"))           { data.Add("plot", info["VideoPlayer.Plot"]); }

                    texts = buildInfoText(patterns, data);
                }
            }

            this.displayNowPlaying(texts);
        }

        private void displayMusicVideo()
        {
            List<string> texts = new List<string>();

            string[] patterns = null;
            if (Settings.Default.XbmcMusicVideoSingleTextEnable)
            {
                patterns = new string[] { Settings.Default.XbmcMusicVideoSingleText };
            }
            else
            {
                return;
            }

            if (this.currentlyPlaying != null)
            {
                texts = buildMusicVideoInfo(patterns, (XbmcMusicVideo)this.currentlyPlaying);
            }
            else
            {
                IDictionary<string, string> info = this.getVideoPlayerInfoLabels();
                if (info.Count > 0)
                {
                    Dictionary<string, string> data = new Dictionary<string, string>(info.Count);
                    if (info.ContainsKey("VideoPlayer.Title")) { data.Add("title", info["VideoPlayer.Title"]); }
                    if (info.ContainsKey("VideoPlayer.Artist")) { data.Add("artist", info["VideoPlayer.Artist"]); }
                    if (info.ContainsKey("VideoPlayer.Album")) { data.Add("album", info["VideoPlayer.Album"]); }
                    if (info.ContainsKey("VideoPlayer.Year")) { data.Add("year", info["VideoPlayer.Year"]); }
                    if (info.ContainsKey("VideoPlayer.Rating")) { data.Add("rating", info["VideoPlayer.Rating"]); }
                    if (info.ContainsKey("VideoPlayer.Genre")) { data.Add("genre", info["VideoPlayer.Genre"]); }
                    try
                    {
                        if (info.ContainsKey("VideoPlayer.Duration")) { data.Add("duration", TimeSpan.Parse(info["VideoPlayer.Duration"]).TotalMinutes.ToString("0")); }
                    }
                    catch (FormatException)
                    { }
                    if (info.ContainsKey("VideoPlayer.Studio")) { data.Add("studio", info["VideoPlayer.Studio"]); }
                    if (info.ContainsKey("VideoPlayer.Director")) { data.Add("director", info["VideoPlayer.Director"]); }
                    if (info.ContainsKey("VideoPlayer.Plot")) { data.Add("plot", info["VideoPlayer.Plot"]); }

                    texts = buildInfoText(patterns, data);
                }
            }

            this.displayNowPlaying(texts);
        }

        private void displaySong()
        {
            List<string> texts = new List<string>();

            string[] patterns = null;
            if (Settings.Default.XbmcMusicSingleTextEnable)
            {
                patterns = new string[] { Settings.Default.XbmcMusicSingleText };
            }
            else
            {
                return;
            }

            if (this.currentlyPlaying != null)
            {
                texts = buildMusicInfo(patterns, (XbmcSong)this.currentlyPlaying);
            }
            else
            {
                IDictionary<string, string> info = this.getAudioPlayerInfoLabels();
                if (info.Count > 0)
                {
                    Dictionary<string, string> data = new Dictionary<string, string>(info.Count);
                    if (info.ContainsKey("MusicPlayer.Title")) { data.Add("title", info["MusicPlayer.Title"]); }
                    if (info.ContainsKey("MusicPlayer.Artist")) { data.Add("artist", info["MusicPlayer.Artist"]); }
                    if (info.ContainsKey("MusicPlayer.Album")) { data.Add("album", info["MusicPlayer.Album"]); }
                    if (info.ContainsKey("MusicPlayer.Year")) { data.Add("year", info["MusicPlayer.Year"]); }
                    if (info.ContainsKey("MusicPlayer.Rating")) { data.Add("rating", info["MusicPlayer.Rating"]); }
                    if (info.ContainsKey("MusicPlayer.Genre")) { data.Add("genre", info["MusicPlayer.Genre"]); }
                    try
                    {
                        if (info.ContainsKey("MusicPlayer.Duration")) { data.Add("duration", TimeSpan.Parse(info["MusicPlayer.Duration"]).TotalMinutes.ToString("0")); }
                    }
                    catch (FormatException)
                    { }
                    if (info.ContainsKey("MusicPlayer.DiscNumber")) { data.Add("disc", info["MusicPlayer.DiscNumber"]); }
                    if (info.ContainsKey("MusicPlayer.TrackNumber")) { data.Add("track", info["MusicPlayer.TrackNumber"]); }

                    texts = buildInfoText(patterns, data);
                }
            }

            this.displayNowPlaying(texts);
        }

        private void displayNowPlaying(List<string> texts)
        {
            if (texts == null)
            {
                texts = new List<string>();
            }

            if (texts.Count == 0)
            {
                string path = this.xbmc.System.GetInfoLabel("Player.Filenameandpath");

                if (!string.IsNullOrEmpty(path))
                {
                    texts.Add(Path.GetFileNameWithoutExtension(path));
                }
            }

            if (texts.Count > 0)
            {
                this.display.SetText(texts[0]);

                for (int i = 1; i < texts.Count; i++)
                {
                    this.display.AddText(texts[i]);
                }

                return;
            }
        }

        private void displaySlideshow()
        {
            this.display.SetText("SLIDESHOW", "Picture", "Slideshow");
        }

        private void displayAudioCodecs()
        {
            bool set = false;
            string codec = ((XbmcAudioPlayer)this.player).Codec;
            Logging.Log(LoggingArea, "Retrieved audio codec: " + codec);
            if (!string.IsNullOrEmpty(codec))
            {
                Dictionary<string, List<string>> mapping = JsonConvert.DeserializeObject<Dictionary<string, List<string>>>(Settings.Default.XbmcIconsPlaybackAudioCodecsMappings);
                foreach (KeyValuePair<string, List<string>> map in mapping)
                {
                    if (listContains(map.Value, codec))
                    {
                        this.displayAudioCodec(map.Key, true);
                        set = true;
                        break;
                    }
                }
                if (set == true)
                {
                    Logging.Log(LoggingArea, "Audio codec " + codec + " supported by display");
                }
                else
                {
                    Logging.Log(LoggingArea, "Audio codec " + codec + " not supported by display");
                }
            }
        }

        private void displayVideoCodecs()
        {
            bool set = false;
            string codec = ((XbmcVideoPlayer)this.player).VideoCodec;
            Logging.Log(LoggingArea, "Retrieved video codec: " + codec);
            if (!string.IsNullOrEmpty(codec))
            {
                Dictionary<string, List<string>> mapping = JsonConvert.DeserializeObject<Dictionary<string, List<string>>>(Settings.Default.XbmcIconsPlaybackVideoCodecsMappings);
                foreach (KeyValuePair<string, List<string>> map in mapping)
                {
                    if (listContains(map.Value, codec))
                    {
                        this.displayVideoCodec(map.Key);
                        set = true;
                        break;
                    }
                }
                if (set == true)
                {
                    Logging.Log(LoggingArea, "Video codec " + codec + " supported by display");
                }
                else
                {
                    Logging.Log(LoggingArea, "Video codec " + codec + " not supported by display");
                }
            }

            set = false;
            codec = ((XbmcVideoPlayer)this.player).AudioCodec;
            Logging.Log(LoggingArea, "Retrieved audio codec: " + codec);
            if (!string.IsNullOrEmpty(codec))
            {
                Dictionary<string, List<string>> mapping = JsonConvert.DeserializeObject<Dictionary<string, List<string>>>(Settings.Default.XbmcIconsPlaybackAudioCodecsMappings);
                foreach (KeyValuePair<string, List<string>> map in mapping)
                {
                    if (listContains(map.Value, codec))
                    {
                        this.displayAudioCodec(map.Key, false);
                        set = true;
                        break;
                    }
                }
                if (set == true)
                {
                    Logging.Log(LoggingArea, "Audio codec " + codec + " supported by display");
                }
                else
                {
                    Logging.Log(LoggingArea, "Audio codec " + codec + " not supported by display");
                }
            }
        }

        private IDictionary<string, string> getVideoPlayerInfoLabels()
        {
            return this.xbmc.System.GetInfoLabels("VideoPlayer.Title", "VideoPlayer.Year", "VideoPlayer.Rating",
                                                  "VideoPlayer.Genre", "VideoPlayer.Duration", "VideoPlayer.mpaa",
                                                  "VideoPlayer.Tagline", "VideoPlayer.Studio", "VideoPlayer.Director",
                                                  "VideoPlayer.Writer", "VideoPlayer.PlotOutline", "VideoPlayer.Plot",
                                                  "VideoPlayer.TVShowTitle",
                                                  "VideoPlayer.Album", "VideoPlayer.Artist");
        }

        private IDictionary<string, string> getAudioPlayerInfoLabels()
        {
            return this.xbmc.System.GetInfoLabels("MusicPlayer.Title", "MusicPlayer.Year", "MusicPlayer.Rating",
                                                  "MusicPlayer.Genre", "MusicPlayer.Duration", "MusicPlayer.Artist",
                                                  "MusicPlayer.Album", "MusicPlayer.DiscNumber", "MusicPlayer.TrackNumber");
        }

        private static List<string> buildMovieInfo(ICollection<string> patterns, XbmcMovie movie)
        {
            Dictionary<string, string> data = new Dictionary<string, string>(12);
            data.Add("title", movie.Title);
            data.Add("year", movie.Year.ToString());
            data.Add("rating", movie.Rating.ToString("0.#"));
            data.Add("genre", movie.Genre);
            data.Add("duration", movie.Duration.TotalMinutes.ToString("0"));
            data.Add("mpaa", movie.Mpaa);
            data.Add("tagline", movie.Tagline);
            data.Add("studio", movie.Studio);
            data.Add("director", movie.Director);
            data.Add("writer", movie.Writer);
            data.Add("outline", movie.Outline);
            data.Add("plot", movie.Plot);

            return buildInfoText(patterns, data);
        }

        private static List<string> buildTvEpisodeInfo(ICollection<string> patterns, XbmcTvEpisode episode)
        {
            Dictionary<string, string> data = new Dictionary<string, string>(12);
            data.Add("title", episode.Title);
            data.Add("episode", episode.Episodes.ToString());
            data.Add("season", episode.Season.ToString());
            data.Add("show", episode.ShowTitle);
            data.Add("year", episode.Year.ToString());
            data.Add("rating", episode.Rating.ToString("0.#"));
            data.Add("duration", episode.Duration.TotalMinutes.ToString("0"));
            data.Add("mpaa", episode.Mpaa);
            data.Add("studio", episode.Studio);
            data.Add("director", episode.Director);
            data.Add("writer", episode.Writer);
            data.Add("plot", episode.Plot);

            return buildInfoText(patterns, data);
        }

        private static List<string> buildMusicVideoInfo(ICollection<string> patterns, XbmcMusicVideo musicVideo)
        {
            Dictionary<string, string> data = new Dictionary<string, string>(10);
            data.Add("title", musicVideo.Title);
            data.Add("artist", musicVideo.Artist);
            data.Add("album", musicVideo.Album);
            data.Add("year", musicVideo.Year.ToString());
            data.Add("rating", musicVideo.Rating.ToString("0.#"));
            data.Add("genre", musicVideo.Genre);
            data.Add("duration", musicVideo.Duration.Minutes.ToString("0") + ":" + musicVideo.Duration.Seconds.ToString("00"));
            data.Add("studio", musicVideo.Studio);
            data.Add("director", musicVideo.Director);
            data.Add("plot", musicVideo.Plot);

            return buildInfoText(patterns, data);
        }

        private static List<string> buildMusicInfo(ICollection<string> patterns, XbmcSong song)
        {
            Dictionary<string, string> data = new Dictionary<string, string>(10);
            data.Add("title", song.Title);
            data.Add("artist", song.Artist);
            data.Add("album", song.Album);
            data.Add("track", song.Track.ToString());
            data.Add("year", song.Year.ToString());
            data.Add("rating", song.Rating.ToString("0.#"));
            data.Add("genre", song.Genre);
            data.Add("duration", song.Duration.Minutes.ToString("0") + ":" + song.Duration.Seconds.ToString("00"));
            //data.Add("disc", song.Disc.ToString());
            data.Add("lyrics", song.Lyrics);

            return buildInfoText(patterns, data);
        }

        private static List<string> buildInfoText(ICollection<string> patterns, IDictionary<string, string> data)
        {
            if (patterns == null || data == null)
            {
                throw new ArgumentNullException();
            }

            List<string> output = new List<string>(patterns.Count);
            foreach (string pattern in patterns)
            {
                StringBuilder builder = new StringBuilder(pattern);
                string result = pattern;

                if (result.LastIndexOf("%", result.Length, result.Length) > 0)
                {
                    int count = 0;
                    int prevPosition = 0;

                    // Let's loop through all occurances of the delimiter
                    while (prevPosition >= 0 && prevPosition < result.Length)
                    {
                        int newPosition = result.IndexOf("%", prevPosition, result.Length - prevPosition);
                        // If the new position is smaller than the last one we reached the last delimiter
                        if (newPosition < prevPosition)
                        {
                            break;
                        }

                        // Delimiter found
                        count += 1;

                        // We have to check what's between the last two delimiters
                        if (count > 1)
                        {
                            // Last delimiter is used up
                            count -= 1;
                            string part = result.Substring(prevPosition, newPosition - prevPosition).ToLowerInvariant();
                            // If there is no space between the last two delimiters it's a suggestion match
                            if (!part.Contains(" "))
                            {
                                // Both delimiters are used up
                                count -= 1;

                                builder.Remove(prevPosition - 1, newPosition - prevPosition + 2);

                                // Handle special formatting information
                                bool fill = false;
                                int length = 0;
                                if (part.Contains(":"))
                                {
                                    int formatStart = part.IndexOf(":") + 1;
                                    string format = part.Substring(formatStart, part.Length - formatStart);
                                    part = part.Remove(formatStart - 1);
                                    if (Int32.TryParse(format, out length) && length > 0)
                                    {
                                        fill = true;
                                    }
                                }
                                
                                if (data.ContainsKey(part) && !string.IsNullOrEmpty(data[part])) 
                                {
                                    string actualData = data[part];
                                    if (fill && actualData.Length < length)
                                    {
                                        actualData = actualData.PadLeft(length, '0');
                                    }

                                    builder.Insert(prevPosition - 1, actualData);
                                    newPosition += data[part].Length;
                                }

                                result = builder.ToString();
                            }

                            newPosition -= part.Length + 2;
                        }

                        prevPosition = newPosition + 1;
                    }
                }

                if (builder.Length > 0)
                {
                    output.Add(builder.ToString());
                }
            }

            return output;
        }

        #endregion
    }
}
