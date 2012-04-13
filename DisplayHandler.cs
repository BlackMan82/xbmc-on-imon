using System;
using System.Collections.Generic;
using System.ComponentModel;

using iMon.DisplayApi;
using iMon.XBMC.Properties;
using System.Threading;
using System.Timers;

namespace iMon.XBMC
{
    internal partial class DisplayHandler : BackgroundWorker
    {
        #region Private variables

        private Semaphore semReady;
        private Semaphore semWork;

        private iMonWrapperApi imon;
        private bool lcd;
        private bool vfd;
        private object displayLock = new object();

        private object queueLock = new object();
        private List<Text> queue;
        private int position;

        private Dictionary<iMonLcdIcons, bool> icons;

        private System.Timers.Timer discRotation;

        private const int DefaultDelay = 1000;

        private const string LoggingArea = "Display Handler";
        private const bool LogDisplayingIcons = false;
        private const bool LogDisplayingDiscIcons = false;

        #endregion

        #region Public variables

        #endregion

        #region Constructor

        public DisplayHandler(iMonWrapperApi imon)
        {
            if (imon == null)
            {
                throw new ArgumentNullException("imon");
            }

            this.imon = imon;
            this.imon.StateChanged += stateChanged;
            this.queue = new List<Text>();

            this.icons = new Dictionary<iMonLcdIcons, bool>(Enum.GetValues(typeof(iMonLcdIcons)).Length);
            foreach (iMonLcdIcons icon in Enum.GetValues(typeof(iMonLcdIcons)))
            {
                this.icons.Add(icon, false);
            }

            this.discRotation = new System.Timers.Timer();
            this.discRotation.AutoReset = true;
            this.discRotation.Interval = 300;
            this.discRotation.Elapsed += discRotationElapsed;

            this.WorkerReportsProgress = false;
            this.WorkerSupportsCancellation = true;

            this.semReady = new Semaphore(0, 1);
            this.semWork = new Semaphore(0, 1);
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

                if (this.lcd)
                {
                    foreach (KeyValuePair<iMonLcdIcons, bool> icon in this.icons)
                    {
                        this.imon.LCD.Icons.Set(icon.Key, icon.Value);
                    }
                }

                if (this.queue.Count > 0)
                {
                    this.display(this.queue[0]);

                    if (this.queue.Count > 1)
                    {
                        this.position = 1;
                    }
                }

                while (!this.CancellationPending && (this.lcd || this.vfd))
                {
                    this.semWork.WaitOne();

                    lock (this.queueLock)
                    {
                        if (this.position >= this.queue.Count) 
                        {
                            this.position = 0;
                        }

                        this.display(this.queue[this.position]);

                        if (this.queue.Count > this.position + 1)
                        {
                            this.position += 1;
                        }
                    }
                }

                Logging.Log(LoggingArea, "Stop working");
            }

            Logging.Log(LoggingArea, "Cancelled");

            this.imon.LCD.ScrollFinished -= lcdScrollFinished;
        }

        #endregion

        #region Public functions

        public void SetText(string text)
        {
            this.SetText(text, text, string.Empty, DefaultDelay);
        }

        public void SetText(string text, int delay)
        {
            // TODO: Indroduce line breaker to be able to correctly (as desired) display 2 lines on VFD displays
            this.SetText(text, text, string.Empty, delay);
        }

        public void SetText(string lcd, string vfdUpper, string vfdLower)
        {
            this.SetText(lcd, vfdUpper, vfdLower, DefaultDelay);
        }

        public void SetText(string lcd, string vfdUpper, string vfdLower, int delay)
        {
            lock (this.queueLock)
            {
                Logging.Log(LoggingArea, "DisplayHandler.SetText(" + lcd + ", " + vfdUpper + ", " + vfdLower + ", " + delay.ToString() + ")");

                this.queue.Clear();
                this.queue.Add(new Text(lcd, vfdUpper, vfdLower, delay));
                this.position = 0;

                this.update();
            }
        }

        public void AddText(string text)
        {
            this.AddText(text, text, string.Empty, DefaultDelay);
        }

        public void AddText(string text, int delay)
        {
            this.AddText(text, text, string.Empty, delay);
        }

        public void AddText(string lcd, string vfdUpper, string vfdLower)
        {
            this.AddText(lcd, vfdUpper, vfdLower, DefaultDelay);
        }

        public void AddText(string lcd, string vfdUpper, string vfdLower, int delay)
        {
            lock (this.queueLock)
            {
                Logging.Log(LoggingArea, "Adding text \"" + lcd + "\" to the queue with delay " + delay.ToString());

                this.queue.Add(new Text(lcd, vfdUpper, vfdLower, delay));

                Logging.Log(LoggingArea, "Queue length after addition: " + this.queue.Count.ToString());

                if (this.queue.Count == 1)
                {
                    this.update();
                }
            }
        }

        public void SetProgress(int position, int total)
        {
            //Logging.Log(LoggingArea, "Trying to set the progress bar to " + position.ToString() + "/" + total.ToString());

            if (this.lcd)
            {
                Logging.Log(LoggingArea, "Setting the progress bar to " + position.ToString() + "/" + total.ToString());

                this.imon.LCD.SetProgress(position, total);
            }
        }

        public void SetProgress(TimeSpan position, TimeSpan total)
        {
            //this.imon.LCD.SetProgress(Convert.ToInt32(position.TotalMilliseconds), Convert.ToInt32(total.TotalMilliseconds));
            this.SetProgress(Convert.ToInt32(position.TotalSeconds), Convert.ToInt32(total.TotalSeconds));
        }

        public void SetIcon(iMonLcdIcons icon, bool show)
        {
            if (LogDisplayingIcons)
                Logging.Log(LoggingArea, "Trying to set LCD icon " + icon + " to " + show);

            this.icons[icon] = show;

            if (this.lcd)
            {
                if (LogDisplayingIcons)
                    Logging.Log(LoggingArea, "Setting LCD icon " + icon + " to " + show); 
                
                this.imon.LCD.Icons.Set(icon, show);
            }
        }

        public void SetIcons(IEnumerable<iMonLcdIcons> iconList, bool show)
        {
            foreach (iMonLcdIcons icon in iconList)
            {
                if (LogDisplayingIcons)
                    Logging.Log(LoggingArea, "Trying to set LCD icon " + icon + " to " + show);

                if (this.lcd) 
                {
                    if (LogDisplayingIcons)
                        Logging.Log(LoggingArea, "Setting LCD icon " + icon + " to " + show);
                }

                this.icons[icon] = show;
            }

            if (this.lcd)
            {
                this.imon.LCD.Icons.Set(iconList, show);
            }
        }

        public void HideAllIcons()
        {
            if (LogDisplayingIcons)
                Logging.Log(LoggingArea, "Trying to hide all LCD icons");

            foreach (iMonLcdIcons icon in Enum.GetValues(typeof(iMonLcdIcons)))
            {
                this.icons[icon] = false;
            }

            if (this.lcd)
            {
                if (LogDisplayingIcons)
                    Logging.Log(LoggingArea, "Hiding all LCD icons");

                this.imon.LCD.Icons.HideAll();
            }
        }

        public void ShowDisc(bool bottomCircle)
        {
            this.PauseDisc();

            List<iMonLcdIcons> iconList = new List<iMonLcdIcons>() { iMonLcdIcons.DiscBottomLeft, iMonLcdIcons.DiscBottomCenter,
                                                                     iMonLcdIcons.DiscBottomRight, iMonLcdIcons.DiscMiddleLeft,
                                                                     iMonLcdIcons.DiscMiddleRight, iMonLcdIcons.DiscTopLeft,
                                                                     iMonLcdIcons.DiscTopCenter, iMonLcdIcons.DiscTopRight };
            if (bottomCircle)
            {
                iconList.Add(iMonLcdIcons.DiscCircle);
            }

            this.SetIcons(iconList, true);
        }

        public void HideDisc()
        {
            this.PauseDisc();

            List<iMonLcdIcons> iconList = new List<iMonLcdIcons>() { iMonLcdIcons.DiscBottomLeft, iMonLcdIcons.DiscBottomCenter,
                                                                     iMonLcdIcons.DiscBottomRight, iMonLcdIcons.DiscMiddleLeft,
                                                                     iMonLcdIcons.DiscMiddleRight, iMonLcdIcons.DiscTopLeft,
                                                                     iMonLcdIcons.DiscTopCenter, iMonLcdIcons.DiscTopRight,
                                                                     iMonLcdIcons.DiscCircle };

            this.SetIcons(iconList, false);
        }

        public void RotateDisc(bool bottomCircle)
        {
            this.HideDisc();

            List<iMonLcdIcons> iconList = new List<iMonLcdIcons>() { iMonLcdIcons.DiscBottomLeft, iMonLcdIcons.DiscBottomRight, 
                                                                     iMonLcdIcons.DiscTopRight, iMonLcdIcons.DiscTopLeft };
            if (bottomCircle)
            {
                iconList.Add(iMonLcdIcons.DiscCircle);
            }

            this.SetIcons(iconList, true);

            this.discRotation.Start();
        }

        public void PauseDisc()
        {
            this.discRotation.Stop();
        }

        #endregion

        #region Event handlers

        private void update()
        {
            if (!this.imon.IsInitialized)
            {
                Logging.Error(LoggingArea, "iMON not initialized.");
                return;
            }
            
            try
            {
                this.semWork.Release();
            }
            catch (SemaphoreFullException)
            {
                Logging.Error(LoggingArea, "Error: 'SemaphoreFullException' for semWork in DisplayHandler.update()");
            }
        }

        private void stateChanged(object sender, iMonStateChangedEventArgs e)
        {
            lock (this.displayLock)
            {
                if (e.IsInitialized)
                {
                    iMonDisplayType display = this.imon.DisplayType;
                    if ((display & iMonDisplayType.LCD) == iMonDisplayType.LCD)
                    {
                        this.imon.LCD.ScrollFinished += lcdScrollFinished;
                        this.lcd = true;
                    }
                    if ((display & iMonDisplayType.VFD) == iMonDisplayType.VFD)
                    {
                        this.vfd = true;
                    }

                    try
                    {
                        this.semReady.Release();
                    }
                    catch (SemaphoreFullException)
                    {
                        Logging.Error(LoggingArea, "Error: 'SemaphoreFullException' for semReady in DisplayHandler.stateChanged()");
                    }
                }
                else
                {
                    this.lcd = false;
                    this.vfd = false;

                    this.update();
                }
            }
        }

        private void lcdScrollFinished(object sender, EventArgs e)
        {
            Thread.Sleep(Settings.Default.ImonLcdScrollingDelay);

            Logging.Log(LoggingArea, "Scrolling finished");

            lock (this.queueLock)
            {
                if (this.position >= this.queue.Count)
                {
                    this.position = 0;
                }

                if (this.queue.Count == 0)
                {
                    return;
                }

                this.update();
            }
        }

        private void discRotationElapsed(object sender, ElapsedEventArgs e)
        {
            List<iMonLcdIcons> hideIcons = new List<iMonLcdIcons>();
            List<iMonLcdIcons> showIcons = new List<iMonLcdIcons>();
            if (this.icons[iMonLcdIcons.DiscBottomLeft])
            {
                hideIcons.AddRange(new iMonLcdIcons[] { iMonLcdIcons.DiscBottomLeft, iMonLcdIcons.DiscBottomRight, 
                                                        iMonLcdIcons.DiscTopRight, iMonLcdIcons.DiscTopLeft });
                showIcons.AddRange(new iMonLcdIcons[] { iMonLcdIcons.DiscBottomCenter, iMonLcdIcons.DiscMiddleRight, 
                                                        iMonLcdIcons.DiscTopCenter, iMonLcdIcons.DiscMiddleLeft });
            }
            else
            {
                hideIcons.AddRange(new iMonLcdIcons[] { iMonLcdIcons.DiscBottomCenter, iMonLcdIcons.DiscMiddleRight, 
                                                        iMonLcdIcons.DiscTopCenter, iMonLcdIcons.DiscMiddleLeft });
                showIcons.AddRange(new iMonLcdIcons[] { iMonLcdIcons.DiscBottomLeft, iMonLcdIcons.DiscBottomRight, 
                                                        iMonLcdIcons.DiscTopRight, iMonLcdIcons.DiscTopLeft });
            }

            this.SetIcons(hideIcons, false);
            this.SetIcons(showIcons, true);
        }

        #endregion

        #region Private functions

        private void display(Text text)
        {
            bool shown = false;

            Logging.Log(LoggingArea, "Trying to display a text");

            lock (this.displayLock)
            {
                if (this.lcd)
                {
                    Logging.Log(LoggingArea, "LCD.SetText: " + text.Lcd);

                    shown = this.imon.LCD.SetText(text.Lcd.Substring(0, text.Lcd.Length <= 256 ? text.Lcd.Length : 256));
                }
                if (this.vfd)
                {
                    Logging.Log(LoggingArea, "VFD.SetText: " + text.VfdUpper + "; " + text.VfdLower);
                    
                    shown = this.imon.VFD.SetText(text.VfdUpper, text.VfdLower);
                }

                if (shown)
                {
                    if (text.Delay > 0)
                    {
                        Logging.Log(LoggingArea, "Showing text for " + text.Delay + "ms");

                        Thread.Sleep(text.Delay);
                    }
                }
                else
                {
                    Logging.Error(LoggingArea, "The text was not displayed succesfully");
                }

            }
        }

        #endregion
    }
}
