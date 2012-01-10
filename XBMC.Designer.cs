﻿namespace iMon.XBMC
{
    partial class XBMC
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(XBMC));
            this.menu = new System.Windows.Forms.MenuStrip();
            this.miGeneral = new System.Windows.Forms.ToolStripMenuItem();
            this.miGeneralClose = new System.Windows.Forms.ToolStripMenuItem();
            this.miXbmc = new System.Windows.Forms.ToolStripMenuItem();
            this.miXbmcConnect = new System.Windows.Forms.ToolStripMenuItem();
            this.miXbmcDisconnect = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.miXbmcInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.miImon = new System.Windows.Forms.ToolStripMenuItem();
            this.miImonInitialize = new System.Windows.Forms.ToolStripMenuItem();
            this.miImonUninitialize = new System.Windows.Forms.ToolStripMenuItem();
            this.miAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.miAboutXbmcOniMon = new System.Windows.Forms.ToolStripMenuItem();
            this.splitter = new System.Windows.Forms.SplitContainer();
            this.pNavigation = new System.Windows.Forms.Panel();
            this.iLOptions = new System.Windows.Forms.ImageList(this.components);
            this.tabOptions = new System.Windows.Forms.TabControl();
            this.tpImon = new System.Windows.Forms.TabPage();
            this.groupBox14 = new System.Windows.Forms.GroupBox();
            this.cbImonSoundSystemSPDIF = new System.Windows.Forms.CheckBox();
            this.cbImonSoundSystem = new System.Windows.Forms.ComboBox();
            this.cbImonSoundSystemEnable = new System.Windows.Forms.CheckBox();
            this.groupBox13 = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.nudImonLcdScrollingDelay = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cbImonGeneralUninitializeOnError = new System.Windows.Forms.CheckBox();
            this.cbImonGeneralAutoInitialize = new System.Windows.Forms.CheckBox();
            this.tpGeneral = new System.Windows.Forms.TabPage();
            this.groupBox15 = new System.Windows.Forms.GroupBox();
            this.cbGeneralDebugEnable = new System.Windows.Forms.CheckBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.cbGeneralTrayDisableBalloonTips = new System.Windows.Forms.CheckBox();
            this.cbGeneralTrayHideOnMinimize = new System.Windows.Forms.CheckBox();
            this.cbGeneralTrayHideOnClose = new System.Windows.Forms.CheckBox();
            this.cbGeneralTrayStartMinimized = new System.Windows.Forms.CheckBox();
            this.cbGeneralTrayEnabled = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbGeneralStartupConnect = new System.Windows.Forms.CheckBox();
            this.cbGeneralStartupAuto = new System.Windows.Forms.CheckBox();
            this.tpXBMC = new System.Windows.Forms.TabPage();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.nudXbmcIconsUpdateInterval = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.cbXbmcIconsScreen = new System.Windows.Forms.CheckBox();
            this.cbXbmcIconsVolEnable = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.nudXbmcConnectionInterval = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.tbXbmcConnectionPassword = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbXbmcConnectionUsername = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbXbmcConnectionPort = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbXbmcConnectionIp = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.rbXbmcMovieStayIdle = new System.Windows.Forms.RadioButton();
            this.rbXbmcMovieSingleText = new System.Windows.Forms.RadioButton();
            this.groupBox16 = new System.Windows.Forms.GroupBox();
            this.cbXbmcControlModeShowWindow = new System.Windows.Forms.CheckBox();
            this.cbXbmcControlModeRemoveBrackets = new System.Windows.Forms.CheckBox();
            this.cbXbmcControlModeDisableDuringPlayback = new System.Windows.Forms.CheckBox();
            this.cbXbmcControlModeEnable = new System.Windows.Forms.CheckBox();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.rbXbmcTvStayIdle = new System.Windows.Forms.RadioButton();
            this.rbXbmcTvSingleText = new System.Windows.Forms.RadioButton();
            this.cbXbmcTvShowTvHdtvIcon = new System.Windows.Forms.CheckBox();
            this.cbXbmcTvMediaTypeIcon = new System.Windows.Forms.CheckBox();
            this.groupBox11 = new System.Windows.Forms.GroupBox();
            this.rbXbmcMusicVideoStayIdle = new System.Windows.Forms.RadioButton();
            this.rbXbmcMusicVideoSingleText = new System.Windows.Forms.RadioButton();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.rbXbmcMusicStayIdle = new System.Windows.Forms.RadioButton();
            this.rbXbmcMusicSingleText = new System.Windows.Forms.RadioButton();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.cbXbmcIdleShowSeconds = new System.Windows.Forms.CheckBox();
            this.rbXbmcIdleTime = new System.Windows.Forms.RadioButton();
            this.rbXbmcIdleStaticTextEnable = new System.Windows.Forms.RadioButton();
            this.tbXbmcIdleStaticText = new System.Windows.Forms.TextBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.cbXbmcPlayingDiscBottomCircle = new System.Windows.Forms.CheckBox();
            this.cbXbmcPlayingDiscRotate = new System.Windows.Forms.CheckBox();
            this.cbXbmcPlayingDiscEnable = new System.Windows.Forms.CheckBox();
            this.cbXbmcPlayingRepeatEnable = new System.Windows.Forms.CheckBox();
            this.cbXbmcPlayingShuffleEnable = new System.Windows.Forms.CheckBox();
            this.bXbmcPlayingAudioCodecs = new System.Windows.Forms.Button();
            this.bXbmcPlayingVideoCodecs = new System.Windows.Forms.Button();
            this.cbXbmcPlayingAudioCodecs = new System.Windows.Forms.CheckBox();
            this.cbXbmcPlayingVideoCodecs = new System.Windows.Forms.CheckBox();
            this.cbXbmcPlayingShowMediaType = new System.Windows.Forms.CheckBox();
            this.cbXbmcPlayingShowProgress = new System.Windows.Forms.CheckBox();
            this.trayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.trayMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.trayMenuOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.trayMenuXBMC = new System.Windows.Forms.ToolStripMenuItem();
            this.trayMenuImon = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.trayMenuClose = new System.Windows.Forms.ToolStripMenuItem();
            this.tbXbmcAnnouncementPort = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.bNavigationXbmc = new iMon.XBMC.NavigationButton();
            this.bNavigationImon = new iMon.XBMC.NavigationButton();
            this.bNavigationGeneral = new iMon.XBMC.NavigationButton();
            this.tbXbmcMovieSingleText = new iMon.XBMC.SuggestionBox();
            this.tbXbmcTvSingleText = new iMon.XBMC.SuggestionBox();
            this.tbXbmcMusicVideoSingleText = new iMon.XBMC.SuggestionBox();
            this.tbXbmcMusicSingleText = new iMon.XBMC.SuggestionBox();
            this.menu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize) (this.splitter)).BeginInit();
            this.splitter.Panel1.SuspendLayout();
            this.splitter.Panel2.SuspendLayout();
            this.splitter.SuspendLayout();
            this.pNavigation.SuspendLayout();
            this.tabOptions.SuspendLayout();
            this.tpImon.SuspendLayout();
            this.groupBox14.SuspendLayout();
            this.groupBox13.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize) (this.nudImonLcdScrollingDelay)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.tpGeneral.SuspendLayout();
            this.groupBox15.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tpXBMC.SuspendLayout();
            this.groupBox7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize) (this.nudXbmcIconsUpdateInterval)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize) (this.nudXbmcConnectionInterval)).BeginInit();
            this.groupBox8.SuspendLayout();
            this.groupBox16.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.groupBox11.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.trayMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // menu
            // 
            this.menu.BackColor = System.Drawing.Color.Transparent;
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miGeneral,
            this.miXbmc,
            this.miImon,
            this.miAbout});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(487, 24);
            this.menu.TabIndex = 0;
            this.menu.Text = "menuStrip1";
            // 
            // miGeneral
            // 
            this.miGeneral.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miGeneralClose});
            this.miGeneral.Name = "miGeneral";
            this.miGeneral.Size = new System.Drawing.Size(59, 20);
            this.miGeneral.Text = "General";
            // 
            // miGeneralClose
            // 
            this.miGeneralClose.Name = "miGeneralClose";
            this.miGeneralClose.ShortcutKeys = ((System.Windows.Forms.Keys) ((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.W)));
            this.miGeneralClose.Size = new System.Drawing.Size(148, 22);
            this.miGeneralClose.Text = "Close";
            this.miGeneralClose.Click += new System.EventHandler(this.miGeneralClose_Click);
            // 
            // miXbmc
            // 
            this.miXbmc.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miXbmcConnect,
            this.miXbmcDisconnect,
            this.toolStripSeparator2,
            this.miXbmcInfo});
            this.miXbmc.Name = "miXbmc";
            this.miXbmc.Size = new System.Drawing.Size(52, 20);
            this.miXbmc.Text = "XBMC";
            // 
            // miXbmcConnect
            // 
            this.miXbmcConnect.Name = "miXbmcConnect";
            this.miXbmcConnect.Size = new System.Drawing.Size(154, 22);
            this.miXbmcConnect.Text = "Connect";
            this.miXbmcConnect.Click += new System.EventHandler(this.miXbmcConnect_Click);
            // 
            // miXbmcDisconnect
            // 
            this.miXbmcDisconnect.Enabled = false;
            this.miXbmcDisconnect.Name = "miXbmcDisconnect";
            this.miXbmcDisconnect.Size = new System.Drawing.Size(154, 22);
            this.miXbmcDisconnect.Text = "Disconnect";
            this.miXbmcDisconnect.Click += new System.EventHandler(this.miXbmcDisconnect_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(151, 6);
            // 
            // miXbmcInfo
            // 
            this.miXbmcInfo.Enabled = false;
            this.miXbmcInfo.Name = "miXbmcInfo";
            this.miXbmcInfo.Size = new System.Drawing.Size(154, 22);
            this.miXbmcInfo.Text = "Build unknown";
            // 
            // miImon
            // 
            this.miImon.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miImonInitialize,
            this.miImonUninitialize});
            this.miImon.Enabled = false;
            this.miImon.Name = "miImon";
            this.miImon.Size = new System.Drawing.Size(51, 20);
            this.miImon.Text = "iMON";
            // 
            // miImonInitialize
            // 
            this.miImonInitialize.Name = "miImonInitialize";
            this.miImonInitialize.Size = new System.Drawing.Size(132, 22);
            this.miImonInitialize.Text = "Initialize";
            this.miImonInitialize.Click += new System.EventHandler(this.miImonInitialize_Click);
            // 
            // miImonUninitialize
            // 
            this.miImonUninitialize.Name = "miImonUninitialize";
            this.miImonUninitialize.Size = new System.Drawing.Size(132, 22);
            this.miImonUninitialize.Text = "Uninitialize";
            this.miImonUninitialize.Click += new System.EventHandler(this.miImonUninitialize_Click);
            // 
            // miAbout
            // 
            this.miAbout.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miAboutXbmcOniMon});
            this.miAbout.Name = "miAbout";
            this.miAbout.Size = new System.Drawing.Size(52, 20);
            this.miAbout.Text = "About";
            // 
            // miAboutXbmcOniMon
            // 
            this.miAboutXbmcOniMon.Name = "miAboutXbmcOniMon";
            this.miAboutXbmcOniMon.Size = new System.Drawing.Size(191, 22);
            this.miAboutXbmcOniMon.Text = "About XBMC on iMon";
            this.miAboutXbmcOniMon.Click += new System.EventHandler(this.miAboutXbmcOniMon_Click);
            // 
            // splitter
            // 
            this.splitter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitter.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitter.Location = new System.Drawing.Point(0, 24);
            this.splitter.Name = "splitter";
            // 
            // splitter.Panel1
            // 
            this.splitter.Panel1.Controls.Add(this.pNavigation);
            // 
            // splitter.Panel2
            // 
            this.splitter.Panel2.Controls.Add(this.tabOptions);
            this.splitter.Size = new System.Drawing.Size(487, 429);
            this.splitter.SplitterDistance = 83;
            this.splitter.TabIndex = 1;
            // 
            // pNavigation
            // 
            this.pNavigation.BackColor = System.Drawing.Color.White;
            this.pNavigation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pNavigation.Controls.Add(this.bNavigationXbmc);
            this.pNavigation.Controls.Add(this.bNavigationImon);
            this.pNavigation.Controls.Add(this.bNavigationGeneral);
            this.pNavigation.Location = new System.Drawing.Point(4, 4);
            this.pNavigation.Name = "pNavigation";
            this.pNavigation.Size = new System.Drawing.Size(76, 425);
            this.pNavigation.TabIndex = 0;
            // 
            // iLOptions
            // 
            this.iLOptions.ImageStream = ((System.Windows.Forms.ImageListStreamer) (resources.GetObject("iLOptions.ImageStream")));
            this.iLOptions.TransparentColor = System.Drawing.Color.Transparent;
            this.iLOptions.Images.SetKeyName(0, "General");
            this.iLOptions.Images.SetKeyName(1, "GeneralActive");
            this.iLOptions.Images.SetKeyName(2, "GeneralHover");
            this.iLOptions.Images.SetKeyName(3, "iMON");
            this.iLOptions.Images.SetKeyName(4, "iMONActive");
            this.iLOptions.Images.SetKeyName(5, "iMONHover");
            this.iLOptions.Images.SetKeyName(6, "XBMC");
            this.iLOptions.Images.SetKeyName(7, "XBMCActive");
            this.iLOptions.Images.SetKeyName(8, "XBMCHover");
            // 
            // tabOptions
            // 
            this.tabOptions.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.tabOptions.Controls.Add(this.tpImon);
            this.tabOptions.Controls.Add(this.tpGeneral);
            this.tabOptions.Controls.Add(this.tpXBMC);
            this.tabOptions.Location = new System.Drawing.Point(-11, -22);
            this.tabOptions.Name = "tabOptions";
            this.tabOptions.SelectedIndex = 0;
            this.tabOptions.Size = new System.Drawing.Size(416, 455);
            this.tabOptions.TabIndex = 0;
            // 
            // tpImon
            // 
            this.tpImon.BackColor = System.Drawing.SystemColors.Control;
            this.tpImon.Controls.Add(this.groupBox14);
            this.tpImon.Controls.Add(this.groupBox13);
            this.tpImon.Controls.Add(this.groupBox3);
            this.tpImon.Location = new System.Drawing.Point(4, 22);
            this.tpImon.Name = "tpImon";
            this.tpImon.Padding = new System.Windows.Forms.Padding(3);
            this.tpImon.Size = new System.Drawing.Size(408, 429);
            this.tpImon.TabIndex = 1;
            this.tpImon.Text = "iMON";
            // 
            // groupBox14
            // 
            this.groupBox14.Controls.Add(this.cbImonSoundSystemSPDIF);
            this.groupBox14.Controls.Add(this.cbImonSoundSystem);
            this.groupBox14.Controls.Add(this.cbImonSoundSystemEnable);
            this.groupBox14.Location = new System.Drawing.Point(11, 135);
            this.groupBox14.Name = "groupBox14";
            this.groupBox14.Size = new System.Drawing.Size(385, 74);
            this.groupBox14.TabIndex = 2;
            this.groupBox14.TabStop = false;
            this.groupBox14.Text = "Sound system";
            // 
            // cbImonSoundSystemSPDIF
            // 
            this.cbImonSoundSystemSPDIF.AutoSize = true;
            this.cbImonSoundSystemSPDIF.Location = new System.Drawing.Point(194, 46);
            this.cbImonSoundSystemSPDIF.Name = "cbImonSoundSystemSPDIF";
            this.cbImonSoundSystemSPDIF.Size = new System.Drawing.Size(62, 17);
            this.cbImonSoundSystemSPDIF.TabIndex = 5;
            this.cbImonSoundSystemSPDIF.Text = "S/PDIF";
            this.cbImonSoundSystemSPDIF.UseVisualStyleBackColor = true;
            // 
            // cbImonSoundSystem
            // 
            this.cbImonSoundSystem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbImonSoundSystem.FormattingEnabled = true;
            this.cbImonSoundSystem.Items.AddRange(new object[] {
            "1.0 Mono",
            "2.0 Stereo",
            "2.1 Stereo",
            "4.0 Quad",
            "5.0 Surround",
            "5.1 Surround",
            "5.1 Side",
            "7.1 Surround"});
            this.cbImonSoundSystem.Location = new System.Drawing.Point(36, 43);
            this.cbImonSoundSystem.Name = "cbImonSoundSystem";
            this.cbImonSoundSystem.Size = new System.Drawing.Size(121, 21);
            this.cbImonSoundSystem.TabIndex = 4;
            // 
            // cbImonSoundSystemEnable
            // 
            this.cbImonSoundSystemEnable.AutoSize = true;
            this.cbImonSoundSystemEnable.Location = new System.Drawing.Point(9, 19);
            this.cbImonSoundSystemEnable.Name = "cbImonSoundSystemEnable";
            this.cbImonSoundSystemEnable.Size = new System.Drawing.Size(120, 17);
            this.cbImonSoundSystemEnable.TabIndex = 3;
            this.cbImonSoundSystemEnable.Text = "Show sound system";
            this.cbImonSoundSystemEnable.UseVisualStyleBackColor = true;
            this.cbImonSoundSystemEnable.CheckedChanged += new System.EventHandler(this.cbImonSoundSystemEnable_CheckedChanged);
            // 
            // groupBox13
            // 
            this.groupBox13.Controls.Add(this.label12);
            this.groupBox13.Controls.Add(this.nudImonLcdScrollingDelay);
            this.groupBox13.Controls.Add(this.label8);
            this.groupBox13.Location = new System.Drawing.Point(10, 81);
            this.groupBox13.Name = "groupBox13";
            this.groupBox13.Size = new System.Drawing.Size(386, 47);
            this.groupBox13.TabIndex = 1;
            this.groupBox13.TabStop = false;
            this.groupBox13.Text = "LCD text scrolling";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(106, 21);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(63, 13);
            this.label12.TabIndex = 13;
            this.label12.Text = "milliseconds";
            // 
            // nudImonLcdScrollingDelay
            // 
            this.nudImonLcdScrollingDelay.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.nudImonLcdScrollingDelay.Location = new System.Drawing.Point(50, 19);
            this.nudImonLcdScrollingDelay.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.nudImonLcdScrollingDelay.Name = "nudImonLcdScrollingDelay";
            this.nudImonLcdScrollingDelay.Size = new System.Drawing.Size(50, 20);
            this.nudImonLcdScrollingDelay.TabIndex = 1;
            this.nudImonLcdScrollingDelay.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudImonLcdScrollingDelay.ThousandsSeparator = true;
            this.nudImonLcdScrollingDelay.Value = new decimal(new int[] {
            500,
            0,
            0,
            0});
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(7, 21);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(37, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Delay:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cbImonGeneralUninitializeOnError);
            this.groupBox3.Controls.Add(this.cbImonGeneralAutoInitialize);
            this.groupBox3.Location = new System.Drawing.Point(10, 6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(386, 68);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "General";
            // 
            // cbImonGeneralUninitializeOnError
            // 
            this.cbImonGeneralUninitializeOnError.AutoSize = true;
            this.cbImonGeneralUninitializeOnError.Location = new System.Drawing.Point(7, 44);
            this.cbImonGeneralUninitializeOnError.Name = "cbImonGeneralUninitializeOnError";
            this.cbImonGeneralUninitializeOnError.Size = new System.Drawing.Size(209, 17);
            this.cbImonGeneralUninitializeOnError.TabIndex = 1;
            this.cbImonGeneralUninitializeOnError.Text = "Uninitialize when iMON reports an error";
            this.cbImonGeneralUninitializeOnError.UseVisualStyleBackColor = true;
            // 
            // cbImonGeneralAutoInitialize
            // 
            this.cbImonGeneralAutoInitialize.AutoSize = true;
            this.cbImonGeneralAutoInitialize.Location = new System.Drawing.Point(7, 20);
            this.cbImonGeneralAutoInitialize.Name = "cbImonGeneralAutoInitialize";
            this.cbImonGeneralAutoInitialize.Size = new System.Drawing.Size(253, 17);
            this.cbImonGeneralAutoInitialize.TabIndex = 0;
            this.cbImonGeneralAutoInitialize.Text = "Automatically initialize when XBMC is connected";
            this.cbImonGeneralAutoInitialize.UseVisualStyleBackColor = true;
            // 
            // tpGeneral
            // 
            this.tpGeneral.BackColor = System.Drawing.SystemColors.Control;
            this.tpGeneral.Controls.Add(this.groupBox15);
            this.tpGeneral.Controls.Add(this.groupBox4);
            this.tpGeneral.Controls.Add(this.groupBox2);
            this.tpGeneral.Location = new System.Drawing.Point(4, 22);
            this.tpGeneral.Name = "tpGeneral";
            this.tpGeneral.Padding = new System.Windows.Forms.Padding(3);
            this.tpGeneral.Size = new System.Drawing.Size(408, 429);
            this.tpGeneral.TabIndex = 0;
            this.tpGeneral.Text = "General";
            // 
            // groupBox15
            // 
            this.groupBox15.Controls.Add(this.cbGeneralDebugEnable);
            this.groupBox15.Location = new System.Drawing.Point(10, 220);
            this.groupBox15.Name = "groupBox15";
            this.groupBox15.Size = new System.Drawing.Size(385, 45);
            this.groupBox15.TabIndex = 2;
            this.groupBox15.TabStop = false;
            this.groupBox15.Text = "Debugging";
            // 
            // cbGeneralDebugEnable
            // 
            this.cbGeneralDebugEnable.AutoSize = true;
            this.cbGeneralDebugEnable.Location = new System.Drawing.Point(6, 20);
            this.cbGeneralDebugEnable.Name = "cbGeneralDebugEnable";
            this.cbGeneralDebugEnable.Size = new System.Drawing.Size(206, 17);
            this.cbGeneralDebugEnable.TabIndex = 0;
            this.cbGeneralDebugEnable.Text = "Enable detailed logging into debug.log";
            this.cbGeneralDebugEnable.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.cbGeneralTrayDisableBalloonTips);
            this.groupBox4.Controls.Add(this.cbGeneralTrayHideOnMinimize);
            this.groupBox4.Controls.Add(this.cbGeneralTrayHideOnClose);
            this.groupBox4.Controls.Add(this.cbGeneralTrayStartMinimized);
            this.groupBox4.Controls.Add(this.cbGeneralTrayEnabled);
            this.groupBox4.Location = new System.Drawing.Point(10, 80);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(386, 134);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Tray Icon";
            // 
            // cbGeneralTrayDisableBalloonTips
            // 
            this.cbGeneralTrayDisableBalloonTips.AutoSize = true;
            this.cbGeneralTrayDisableBalloonTips.Location = new System.Drawing.Point(25, 112);
            this.cbGeneralTrayDisableBalloonTips.Name = "cbGeneralTrayDisableBalloonTips";
            this.cbGeneralTrayDisableBalloonTips.Size = new System.Drawing.Size(122, 17);
            this.cbGeneralTrayDisableBalloonTips.TabIndex = 4;
            this.cbGeneralTrayDisableBalloonTips.Text = "Disable Balloon Tips";
            this.cbGeneralTrayDisableBalloonTips.UseVisualStyleBackColor = true;
            // 
            // cbGeneralTrayHideOnMinimize
            // 
            this.cbGeneralTrayHideOnMinimize.AutoSize = true;
            this.cbGeneralTrayHideOnMinimize.Location = new System.Drawing.Point(25, 66);
            this.cbGeneralTrayHideOnMinimize.Name = "cbGeneralTrayHideOnMinimize";
            this.cbGeneralTrayHideOnMinimize.Size = new System.Drawing.Size(205, 17);
            this.cbGeneralTrayHideOnMinimize.TabIndex = 3;
            this.cbGeneralTrayHideOnMinimize.Text = "Hide in Windows tray when minimizing";
            this.cbGeneralTrayHideOnMinimize.UseVisualStyleBackColor = true;
            // 
            // cbGeneralTrayHideOnClose
            // 
            this.cbGeneralTrayHideOnClose.AutoSize = true;
            this.cbGeneralTrayHideOnClose.Location = new System.Drawing.Point(25, 89);
            this.cbGeneralTrayHideOnClose.Name = "cbGeneralTrayHideOnClose";
            this.cbGeneralTrayHideOnClose.Size = new System.Drawing.Size(191, 17);
            this.cbGeneralTrayHideOnClose.TabIndex = 2;
            this.cbGeneralTrayHideOnClose.Text = "Hide in Windows tray when closing";
            this.cbGeneralTrayHideOnClose.UseVisualStyleBackColor = true;
            // 
            // cbGeneralTrayStartMinimized
            // 
            this.cbGeneralTrayStartMinimized.AutoSize = true;
            this.cbGeneralTrayStartMinimized.Location = new System.Drawing.Point(25, 43);
            this.cbGeneralTrayStartMinimized.Name = "cbGeneralTrayStartMinimized";
            this.cbGeneralTrayStartMinimized.Size = new System.Drawing.Size(175, 17);
            this.cbGeneralTrayStartMinimized.TabIndex = 1;
            this.cbGeneralTrayStartMinimized.Text = "Start minimized to Windows tray";
            this.cbGeneralTrayStartMinimized.UseVisualStyleBackColor = true;
            // 
            // cbGeneralTrayEnabled
            // 
            this.cbGeneralTrayEnabled.AutoSize = true;
            this.cbGeneralTrayEnabled.Location = new System.Drawing.Point(7, 20);
            this.cbGeneralTrayEnabled.Name = "cbGeneralTrayEnabled";
            this.cbGeneralTrayEnabled.Size = new System.Drawing.Size(232, 17);
            this.cbGeneralTrayEnabled.TabIndex = 0;
            this.cbGeneralTrayEnabled.Text = "Show Windows tray icon with current status";
            this.cbGeneralTrayEnabled.UseVisualStyleBackColor = true;
            this.cbGeneralTrayEnabled.CheckedChanged += new System.EventHandler(this.cbGeneralTrayEnabled_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbGeneralStartupConnect);
            this.groupBox2.Controls.Add(this.cbGeneralStartupAuto);
            this.groupBox2.Location = new System.Drawing.Point(10, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(386, 68);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Startup";
            // 
            // cbGeneralStartupConnect
            // 
            this.cbGeneralStartupConnect.AutoSize = true;
            this.cbGeneralStartupConnect.Location = new System.Drawing.Point(7, 44);
            this.cbGeneralStartupConnect.Name = "cbGeneralStartupConnect";
            this.cbGeneralStartupConnect.Size = new System.Drawing.Size(171, 17);
            this.cbGeneralStartupConnect.TabIndex = 1;
            this.cbGeneralStartupConnect.Text = "Connect with XBMC on startup";
            this.cbGeneralStartupConnect.UseVisualStyleBackColor = true;
            // 
            // cbGeneralStartupAuto
            // 
            this.cbGeneralStartupAuto.AutoSize = true;
            this.cbGeneralStartupAuto.Location = new System.Drawing.Point(7, 20);
            this.cbGeneralStartupAuto.Name = "cbGeneralStartupAuto";
            this.cbGeneralStartupAuto.Size = new System.Drawing.Size(140, 17);
            this.cbGeneralStartupAuto.TabIndex = 0;
            this.cbGeneralStartupAuto.Text = "Auto start with Windows";
            this.cbGeneralStartupAuto.UseVisualStyleBackColor = true;
            // 
            // tpXBMC
            // 
            this.tpXBMC.AutoScroll = true;
            this.tpXBMC.BackColor = System.Drawing.SystemColors.Control;
            this.tpXBMC.Controls.Add(this.groupBox7);
            this.tpXBMC.Controls.Add(this.groupBox1);
            this.tpXBMC.Controls.Add(this.groupBox8);
            this.tpXBMC.Controls.Add(this.groupBox16);
            this.tpXBMC.Controls.Add(this.groupBox9);
            this.tpXBMC.Controls.Add(this.groupBox11);
            this.tpXBMC.Controls.Add(this.groupBox10);
            this.tpXBMC.Controls.Add(this.groupBox5);
            this.tpXBMC.Controls.Add(this.groupBox6);
            this.tpXBMC.Location = new System.Drawing.Point(4, 22);
            this.tpXBMC.Name = "tpXBMC";
            this.tpXBMC.Padding = new System.Windows.Forms.Padding(3);
            this.tpXBMC.Size = new System.Drawing.Size(408, 429);
            this.tpXBMC.TabIndex = 2;
            this.tpXBMC.Text = "XBMC";
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.label10);
            this.groupBox7.Controls.Add(this.nudXbmcIconsUpdateInterval);
            this.groupBox7.Controls.Add(this.label7);
            this.groupBox7.Controls.Add(this.cbXbmcIconsScreen);
            this.groupBox7.Controls.Add(this.cbXbmcIconsVolEnable);
            this.groupBox7.Enabled = false;
            this.groupBox7.Location = new System.Drawing.Point(10, 287);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(375, 70);
            this.groupBox7.TabIndex = 13;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "General icons";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(140, 23);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(47, 13);
            this.label10.TabIndex = 11;
            this.label10.Text = "seconds";
            // 
            // nudXbmcIconsUpdateInterval
            // 
            this.nudXbmcIconsUpdateInterval.Enabled = false;
            this.nudXbmcIconsUpdateInterval.Location = new System.Drawing.Point(94, 19);
            this.nudXbmcIconsUpdateInterval.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.nudXbmcIconsUpdateInterval.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudXbmcIconsUpdateInterval.Name = "nudXbmcIconsUpdateInterval";
            this.nudXbmcIconsUpdateInterval.Size = new System.Drawing.Size(40, 20);
            this.nudXbmcIconsUpdateInterval.TabIndex = 10;
            this.nudXbmcIconsUpdateInterval.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 23);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(82, 13);
            this.label7.TabIndex = 5;
            this.label7.Text = "Update interval:";
            // 
            // cbXbmcIconsScreen
            // 
            this.cbXbmcIconsScreen.AutoSize = true;
            this.cbXbmcIconsScreen.Enabled = false;
            this.cbXbmcIconsScreen.Location = new System.Drawing.Point(191, 45);
            this.cbXbmcIconsScreen.Name = "cbXbmcIconsScreen";
            this.cbXbmcIconsScreen.Size = new System.Drawing.Size(131, 17);
            this.cbXbmcIconsScreen.TabIndex = 4;
            this.cbXbmcIconsScreen.Text = "Show screen indicator";
            this.cbXbmcIconsScreen.UseVisualStyleBackColor = true;
            // 
            // cbXbmcIconsVolEnable
            // 
            this.cbXbmcIconsVolEnable.AutoSize = true;
            this.cbXbmcIconsVolEnable.Enabled = false;
            this.cbXbmcIconsVolEnable.Location = new System.Drawing.Point(6, 45);
            this.cbXbmcIconsVolEnable.Name = "cbXbmcIconsVolEnable";
            this.cbXbmcIconsVolEnable.Size = new System.Drawing.Size(135, 17);
            this.cbXbmcIconsVolEnable.TabIndex = 3;
            this.cbXbmcIconsVolEnable.Text = "Show VOL if not muted";
            this.cbXbmcIconsVolEnable.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbXbmcAnnouncementPort);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.nudXbmcConnectionInterval);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.tbXbmcConnectionPassword);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.tbXbmcConnectionUsername);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.tbXbmcConnectionPort);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.tbXbmcConnectionIp);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(10, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(375, 125);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Connection";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(140, 76);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "seconds";
            // 
            // nudXbmcConnectionInterval
            // 
            this.nudXbmcConnectionInterval.Location = new System.Drawing.Point(94, 73);
            this.nudXbmcConnectionInterval.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.nudXbmcConnectionInterval.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudXbmcConnectionInterval.Name = "nudXbmcConnectionInterval";
            this.nudXbmcConnectionInterval.Size = new System.Drawing.Size(40, 20);
            this.nudXbmcConnectionInterval.TabIndex = 9;
            this.nudXbmcConnectionInterval.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 76);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Retry interval:";
            // 
            // tbXbmcConnectionPassword
            // 
            this.tbXbmcConnectionPassword.Location = new System.Drawing.Point(251, 47);
            this.tbXbmcConnectionPassword.Name = "tbXbmcConnectionPassword";
            this.tbXbmcConnectionPassword.PasswordChar = '*';
            this.tbXbmcConnectionPassword.Size = new System.Drawing.Size(118, 20);
            this.tbXbmcConnectionPassword.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(189, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Password:";
            // 
            // tbXbmcConnectionUsername
            // 
            this.tbXbmcConnectionUsername.Location = new System.Drawing.Point(70, 47);
            this.tbXbmcConnectionUsername.Name = "tbXbmcConnectionUsername";
            this.tbXbmcConnectionUsername.Size = new System.Drawing.Size(113, 20);
            this.tbXbmcConnectionUsername.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Username:";
            // 
            // tbXbmcConnectionPort
            // 
            this.tbXbmcConnectionPort.Location = new System.Drawing.Point(296, 19);
            this.tbXbmcConnectionPort.Name = "tbXbmcConnectionPort";
            this.tbXbmcConnectionPort.Size = new System.Drawing.Size(73, 20);
            this.tbXbmcConnectionPort.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(255, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Port:";
            // 
            // tbXbmcConnectionIp
            // 
            this.tbXbmcConnectionIp.Location = new System.Drawing.Point(34, 20);
            this.tbXbmcConnectionIp.Name = "tbXbmcConnectionIp";
            this.tbXbmcConnectionIp.Size = new System.Drawing.Size(215, 20);
            this.tbXbmcConnectionIp.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "IP:";
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.rbXbmcMovieStayIdle);
            this.groupBox8.Controls.Add(this.tbXbmcMovieSingleText);
            this.groupBox8.Controls.Add(this.rbXbmcMovieSingleText);
            this.groupBox8.Location = new System.Drawing.Point(10, 535);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(375, 90);
            this.groupBox8.TabIndex = 14;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Playing a movie";
            // 
            // rbXbmcMovieStayIdle
            // 
            this.rbXbmcMovieStayIdle.AutoSize = true;
            this.rbXbmcMovieStayIdle.Location = new System.Drawing.Point(6, 66);
            this.rbXbmcMovieStayIdle.Name = "rbXbmcMovieStayIdle";
            this.rbXbmcMovieStayIdle.Size = new System.Drawing.Size(66, 17);
            this.rbXbmcMovieStayIdle.TabIndex = 6;
            this.rbXbmcMovieStayIdle.TabStop = true;
            this.rbXbmcMovieStayIdle.Text = "Stay Idle";
            this.rbXbmcMovieStayIdle.UseVisualStyleBackColor = true;
            // 
            // rbXbmcMovieSingleText
            // 
            this.rbXbmcMovieSingleText.AutoSize = true;
            this.rbXbmcMovieSingleText.Location = new System.Drawing.Point(6, 19);
            this.rbXbmcMovieSingleText.Name = "rbXbmcMovieSingleText";
            this.rbXbmcMovieSingleText.Size = new System.Drawing.Size(102, 17);
            this.rbXbmcMovieSingleText.TabIndex = 2;
            this.rbXbmcMovieSingleText.TabStop = true;
            this.rbXbmcMovieSingleText.Text = "Show single text";
            this.rbXbmcMovieSingleText.UseVisualStyleBackColor = true;
            this.rbXbmcMovieSingleText.CheckedChanged += new System.EventHandler(this.rbXbmcMovieSingleText_CheckedChanged);
            // 
            // groupBox16
            // 
            this.groupBox16.Controls.Add(this.cbXbmcControlModeShowWindow);
            this.groupBox16.Controls.Add(this.cbXbmcControlModeRemoveBrackets);
            this.groupBox16.Controls.Add(this.cbXbmcControlModeDisableDuringPlayback);
            this.groupBox16.Controls.Add(this.cbXbmcControlModeEnable);
            this.groupBox16.Location = new System.Drawing.Point(10, 189);
            this.groupBox16.Name = "groupBox16";
            this.groupBox16.Size = new System.Drawing.Size(375, 92);
            this.groupBox16.TabIndex = 19;
            this.groupBox16.TabStop = false;
            this.groupBox16.Text = "Control mode (highly experimental)";
            // 
            // cbXbmcControlModeShowWindow
            // 
            this.cbXbmcControlModeShowWindow.AutoSize = true;
            this.cbXbmcControlModeShowWindow.Enabled = false;
            this.cbXbmcControlModeShowWindow.Location = new System.Drawing.Point(192, 66);
            this.cbXbmcControlModeShowWindow.Name = "cbXbmcControlModeShowWindow";
            this.cbXbmcControlModeShowWindow.Size = new System.Drawing.Size(121, 17);
            this.cbXbmcControlModeShowWindow.TabIndex = 13;
            this.cbXbmcControlModeShowWindow.Text = "Show window name";
            this.cbXbmcControlModeShowWindow.UseVisualStyleBackColor = true;
            // 
            // cbXbmcControlModeRemoveBrackets
            // 
            this.cbXbmcControlModeRemoveBrackets.AutoSize = true;
            this.cbXbmcControlModeRemoveBrackets.Enabled = false;
            this.cbXbmcControlModeRemoveBrackets.Location = new System.Drawing.Point(36, 66);
            this.cbXbmcControlModeRemoveBrackets.Name = "cbXbmcControlModeRemoveBrackets";
            this.cbXbmcControlModeRemoveBrackets.Size = new System.Drawing.Size(122, 17);
            this.cbXbmcControlModeRemoveBrackets.TabIndex = 14;
            this.cbXbmcControlModeRemoveBrackets.Text = "Remove brackets [ ]";
            this.cbXbmcControlModeRemoveBrackets.UseVisualStyleBackColor = true;
            // 
            // cbXbmcControlModeDisableDuringPlayback
            // 
            this.cbXbmcControlModeDisableDuringPlayback.AutoSize = true;
            this.cbXbmcControlModeDisableDuringPlayback.Enabled = false;
            this.cbXbmcControlModeDisableDuringPlayback.Location = new System.Drawing.Point(36, 43);
            this.cbXbmcControlModeDisableDuringPlayback.Name = "cbXbmcControlModeDisableDuringPlayback";
            this.cbXbmcControlModeDisableDuringPlayback.Size = new System.Drawing.Size(139, 17);
            this.cbXbmcControlModeDisableDuringPlayback.TabIndex = 1;
            this.cbXbmcControlModeDisableDuringPlayback.Text = "Disable during playback";
            this.cbXbmcControlModeDisableDuringPlayback.UseVisualStyleBackColor = true;
            // 
            // cbXbmcControlModeEnable
            // 
            this.cbXbmcControlModeEnable.AutoSize = true;
            this.cbXbmcControlModeEnable.Location = new System.Drawing.Point(8, 20);
            this.cbXbmcControlModeEnable.Name = "cbXbmcControlModeEnable";
            this.cbXbmcControlModeEnable.Size = new System.Drawing.Size(59, 17);
            this.cbXbmcControlModeEnable.TabIndex = 0;
            this.cbXbmcControlModeEnable.Text = "Enable";
            this.cbXbmcControlModeEnable.UseVisualStyleBackColor = true;
            this.cbXbmcControlModeEnable.CheckedChanged += new System.EventHandler(this.cbXbmcControlModeEnable_CheckedChanged);
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.rbXbmcTvStayIdle);
            this.groupBox9.Controls.Add(this.tbXbmcTvSingleText);
            this.groupBox9.Controls.Add(this.rbXbmcTvSingleText);
            this.groupBox9.Controls.Add(this.cbXbmcTvShowTvHdtvIcon);
            this.groupBox9.Controls.Add(this.cbXbmcTvMediaTypeIcon);
            this.groupBox9.Location = new System.Drawing.Point(10, 631);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(375, 114);
            this.groupBox9.TabIndex = 15;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Playing a tv episode";
            // 
            // rbXbmcTvStayIdle
            // 
            this.rbXbmcTvStayIdle.AutoSize = true;
            this.rbXbmcTvStayIdle.Location = new System.Drawing.Point(6, 90);
            this.rbXbmcTvStayIdle.Name = "rbXbmcTvStayIdle";
            this.rbXbmcTvStayIdle.Size = new System.Drawing.Size(66, 17);
            this.rbXbmcTvStayIdle.TabIndex = 10;
            this.rbXbmcTvStayIdle.TabStop = true;
            this.rbXbmcTvStayIdle.Text = "Stay Idle";
            this.rbXbmcTvStayIdle.UseVisualStyleBackColor = true;
            // 
            // rbXbmcTvSingleText
            // 
            this.rbXbmcTvSingleText.AutoSize = true;
            this.rbXbmcTvSingleText.Location = new System.Drawing.Point(6, 43);
            this.rbXbmcTvSingleText.Name = "rbXbmcTvSingleText";
            this.rbXbmcTvSingleText.Size = new System.Drawing.Size(102, 17);
            this.rbXbmcTvSingleText.TabIndex = 6;
            this.rbXbmcTvSingleText.TabStop = true;
            this.rbXbmcTvSingleText.Text = "Show single text";
            this.rbXbmcTvSingleText.UseVisualStyleBackColor = true;
            this.rbXbmcTvSingleText.CheckedChanged += new System.EventHandler(this.rbXbmcTvSingleText_CheckedChanged);
            // 
            // cbXbmcTvShowTvHdtvIcon
            // 
            this.cbXbmcTvShowTvHdtvIcon.AutoSize = true;
            this.cbXbmcTvShowTvHdtvIcon.Location = new System.Drawing.Point(191, 20);
            this.cbXbmcTvShowTvHdtvIcon.Name = "cbXbmcTvShowTvHdtvIcon";
            this.cbXbmcTvShowTvHdtvIcon.Size = new System.Drawing.Size(134, 17);
            this.cbXbmcTvShowTvHdtvIcon.TabIndex = 1;
            this.cbXbmcTvShowTvHdtvIcon.Text = "Show TV / HDTV icon";
            this.cbXbmcTvShowTvHdtvIcon.UseVisualStyleBackColor = true;
            // 
            // cbXbmcTvMediaTypeIcon
            // 
            this.cbXbmcTvMediaTypeIcon.AutoSize = true;
            this.cbXbmcTvMediaTypeIcon.Location = new System.Drawing.Point(7, 20);
            this.cbXbmcTvMediaTypeIcon.Name = "cbXbmcTvMediaTypeIcon";
            this.cbXbmcTvMediaTypeIcon.Size = new System.Drawing.Size(147, 17);
            this.cbXbmcTvMediaTypeIcon.TabIndex = 0;
            this.cbXbmcTvMediaTypeIcon.Text = "Show TV media type icon";
            this.cbXbmcTvMediaTypeIcon.UseVisualStyleBackColor = true;
            // 
            // groupBox11
            // 
            this.groupBox11.Controls.Add(this.rbXbmcMusicVideoStayIdle);
            this.groupBox11.Controls.Add(this.tbXbmcMusicVideoSingleText);
            this.groupBox11.Controls.Add(this.rbXbmcMusicVideoSingleText);
            this.groupBox11.Location = new System.Drawing.Point(10, 847);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Size = new System.Drawing.Size(375, 90);
            this.groupBox11.TabIndex = 17;
            this.groupBox11.TabStop = false;
            this.groupBox11.Text = "Playing a music video";
            // 
            // rbXbmcMusicVideoStayIdle
            // 
            this.rbXbmcMusicVideoStayIdle.AutoSize = true;
            this.rbXbmcMusicVideoStayIdle.Location = new System.Drawing.Point(6, 66);
            this.rbXbmcMusicVideoStayIdle.Name = "rbXbmcMusicVideoStayIdle";
            this.rbXbmcMusicVideoStayIdle.Size = new System.Drawing.Size(66, 17);
            this.rbXbmcMusicVideoStayIdle.TabIndex = 10;
            this.rbXbmcMusicVideoStayIdle.TabStop = true;
            this.rbXbmcMusicVideoStayIdle.Text = "Stay Idle";
            this.rbXbmcMusicVideoStayIdle.UseVisualStyleBackColor = true;
            // 
            // rbXbmcMusicVideoSingleText
            // 
            this.rbXbmcMusicVideoSingleText.AutoSize = true;
            this.rbXbmcMusicVideoSingleText.Location = new System.Drawing.Point(6, 19);
            this.rbXbmcMusicVideoSingleText.Name = "rbXbmcMusicVideoSingleText";
            this.rbXbmcMusicVideoSingleText.Size = new System.Drawing.Size(102, 17);
            this.rbXbmcMusicVideoSingleText.TabIndex = 6;
            this.rbXbmcMusicVideoSingleText.TabStop = true;
            this.rbXbmcMusicVideoSingleText.Text = "Show single text";
            this.rbXbmcMusicVideoSingleText.UseVisualStyleBackColor = true;
            this.rbXbmcMusicVideoSingleText.CheckedChanged += new System.EventHandler(this.rbXbmcMusicVideoSingleText_CheckedChanged);
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.rbXbmcMusicStayIdle);
            this.groupBox10.Controls.Add(this.tbXbmcMusicSingleText);
            this.groupBox10.Controls.Add(this.rbXbmcMusicSingleText);
            this.groupBox10.Location = new System.Drawing.Point(10, 751);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(375, 90);
            this.groupBox10.TabIndex = 16;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "Playing a song";
            // 
            // rbXbmcMusicStayIdle
            // 
            this.rbXbmcMusicStayIdle.AutoSize = true;
            this.rbXbmcMusicStayIdle.Location = new System.Drawing.Point(6, 66);
            this.rbXbmcMusicStayIdle.Name = "rbXbmcMusicStayIdle";
            this.rbXbmcMusicStayIdle.Size = new System.Drawing.Size(66, 17);
            this.rbXbmcMusicStayIdle.TabIndex = 10;
            this.rbXbmcMusicStayIdle.TabStop = true;
            this.rbXbmcMusicStayIdle.Text = "Stay Idle";
            this.rbXbmcMusicStayIdle.UseVisualStyleBackColor = true;
            // 
            // rbXbmcMusicSingleText
            // 
            this.rbXbmcMusicSingleText.AutoSize = true;
            this.rbXbmcMusicSingleText.Location = new System.Drawing.Point(6, 19);
            this.rbXbmcMusicSingleText.Name = "rbXbmcMusicSingleText";
            this.rbXbmcMusicSingleText.Size = new System.Drawing.Size(102, 17);
            this.rbXbmcMusicSingleText.TabIndex = 6;
            this.rbXbmcMusicSingleText.TabStop = true;
            this.rbXbmcMusicSingleText.Text = "Show single text";
            this.rbXbmcMusicSingleText.UseVisualStyleBackColor = true;
            this.rbXbmcMusicSingleText.CheckedChanged += new System.EventHandler(this.rbXbmcMusicSingleText_CheckedChanged);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.cbXbmcIdleShowSeconds);
            this.groupBox5.Controls.Add(this.rbXbmcIdleTime);
            this.groupBox5.Controls.Add(this.rbXbmcIdleStaticTextEnable);
            this.groupBox5.Controls.Add(this.tbXbmcIdleStaticText);
            this.groupBox5.Location = new System.Drawing.Point(10, 112);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(375, 71);
            this.groupBox5.TabIndex = 11;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Idle";
            // 
            // cbXbmcIdleShowSeconds
            // 
            this.cbXbmcIdleShowSeconds.AutoSize = true;
            this.cbXbmcIdleShowSeconds.Enabled = false;
            this.cbXbmcIdleShowSeconds.Location = new System.Drawing.Point(219, 45);
            this.cbXbmcIdleShowSeconds.Name = "cbXbmcIdleShowSeconds";
            this.cbXbmcIdleShowSeconds.Size = new System.Drawing.Size(96, 17);
            this.cbXbmcIdleShowSeconds.TabIndex = 4;
            this.cbXbmcIdleShowSeconds.Text = "Show seconds";
            this.cbXbmcIdleShowSeconds.UseVisualStyleBackColor = true;
            // 
            // rbXbmcIdleTime
            // 
            this.rbXbmcIdleTime.AutoSize = true;
            this.rbXbmcIdleTime.Location = new System.Drawing.Point(192, 19);
            this.rbXbmcIdleTime.Name = "rbXbmcIdleTime";
            this.rbXbmcIdleTime.Size = new System.Drawing.Size(110, 17);
            this.rbXbmcIdleTime.TabIndex = 3;
            this.rbXbmcIdleTime.TabStop = true;
            this.rbXbmcIdleTime.Text = "Show current time";
            this.rbXbmcIdleTime.UseVisualStyleBackColor = true;
            this.rbXbmcIdleTime.CheckedChanged += new System.EventHandler(this.rbXbmcIdleTime_CheckedChanged);
            // 
            // rbXbmcIdleStaticTextEnable
            // 
            this.rbXbmcIdleStaticTextEnable.AutoSize = true;
            this.rbXbmcIdleStaticTextEnable.Location = new System.Drawing.Point(7, 19);
            this.rbXbmcIdleStaticTextEnable.Name = "rbXbmcIdleStaticTextEnable";
            this.rbXbmcIdleStaticTextEnable.Size = new System.Drawing.Size(100, 17);
            this.rbXbmcIdleStaticTextEnable.TabIndex = 1;
            this.rbXbmcIdleStaticTextEnable.TabStop = true;
            this.rbXbmcIdleStaticTextEnable.Text = "Show static text";
            this.rbXbmcIdleStaticTextEnable.UseVisualStyleBackColor = true;
            this.rbXbmcIdleStaticTextEnable.CheckedChanged += new System.EventHandler(this.rbXbmcIdleStaticTextEnable_CheckedChanged);
            // 
            // tbXbmcIdleStaticText
            // 
            this.tbXbmcIdleStaticText.Enabled = false;
            this.tbXbmcIdleStaticText.Location = new System.Drawing.Point(34, 43);
            this.tbXbmcIdleStaticText.Name = "tbXbmcIdleStaticText";
            this.tbXbmcIdleStaticText.Size = new System.Drawing.Size(149, 20);
            this.tbXbmcIdleStaticText.TabIndex = 2;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.cbXbmcPlayingDiscBottomCircle);
            this.groupBox6.Controls.Add(this.cbXbmcPlayingDiscRotate);
            this.groupBox6.Controls.Add(this.cbXbmcPlayingDiscEnable);
            this.groupBox6.Controls.Add(this.cbXbmcPlayingRepeatEnable);
            this.groupBox6.Controls.Add(this.cbXbmcPlayingShuffleEnable);
            this.groupBox6.Controls.Add(this.bXbmcPlayingAudioCodecs);
            this.groupBox6.Controls.Add(this.bXbmcPlayingVideoCodecs);
            this.groupBox6.Controls.Add(this.cbXbmcPlayingAudioCodecs);
            this.groupBox6.Controls.Add(this.cbXbmcPlayingVideoCodecs);
            this.groupBox6.Controls.Add(this.cbXbmcPlayingShowMediaType);
            this.groupBox6.Controls.Add(this.cbXbmcPlayingShowProgress);
            this.groupBox6.Location = new System.Drawing.Point(10, 363);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(375, 166);
            this.groupBox6.TabIndex = 12;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Icons during playback";
            // 
            // cbXbmcPlayingDiscBottomCircle
            // 
            this.cbXbmcPlayingDiscBottomCircle.AutoSize = true;
            this.cbXbmcPlayingDiscBottomCircle.Enabled = false;
            this.cbXbmcPlayingDiscBottomCircle.Location = new System.Drawing.Point(192, 143);
            this.cbXbmcPlayingDiscBottomCircle.Name = "cbXbmcPlayingDiscBottomCircle";
            this.cbXbmcPlayingDiscBottomCircle.Size = new System.Drawing.Size(116, 17);
            this.cbXbmcPlayingDiscBottomCircle.TabIndex = 10;
            this.cbXbmcPlayingDiscBottomCircle.Text = "Show bottom circle";
            this.cbXbmcPlayingDiscBottomCircle.UseVisualStyleBackColor = true;
            // 
            // cbXbmcPlayingDiscRotate
            // 
            this.cbXbmcPlayingDiscRotate.AutoSize = true;
            this.cbXbmcPlayingDiscRotate.Enabled = false;
            this.cbXbmcPlayingDiscRotate.Location = new System.Drawing.Point(33, 143);
            this.cbXbmcPlayingDiscRotate.Name = "cbXbmcPlayingDiscRotate";
            this.cbXbmcPlayingDiscRotate.Size = new System.Drawing.Size(58, 17);
            this.cbXbmcPlayingDiscRotate.TabIndex = 9;
            this.cbXbmcPlayingDiscRotate.Text = "Rotate";
            this.cbXbmcPlayingDiscRotate.UseVisualStyleBackColor = true;
            // 
            // cbXbmcPlayingDiscEnable
            // 
            this.cbXbmcPlayingDiscEnable.AutoSize = true;
            this.cbXbmcPlayingDiscEnable.Location = new System.Drawing.Point(7, 120);
            this.cbXbmcPlayingDiscEnable.Name = "cbXbmcPlayingDiscEnable";
            this.cbXbmcPlayingDiscEnable.Size = new System.Drawing.Size(77, 17);
            this.cbXbmcPlayingDiscEnable.TabIndex = 8;
            this.cbXbmcPlayingDiscEnable.Text = "Show Disc";
            this.cbXbmcPlayingDiscEnable.UseVisualStyleBackColor = true;
            this.cbXbmcPlayingDiscEnable.CheckedChanged += new System.EventHandler(this.cbXbmcPlayingDiscEnable_CheckedChanged);
            // 
            // cbXbmcPlayingRepeatEnable
            // 
            this.cbXbmcPlayingRepeatEnable.AutoSize = true;
            this.cbXbmcPlayingRepeatEnable.Enabled = false;
            this.cbXbmcPlayingRepeatEnable.Location = new System.Drawing.Point(192, 97);
            this.cbXbmcPlayingRepeatEnable.Name = "cbXbmcPlayingRepeatEnable";
            this.cbXbmcPlayingRepeatEnable.Size = new System.Drawing.Size(91, 17);
            this.cbXbmcPlayingRepeatEnable.TabIndex = 7;
            this.cbXbmcPlayingRepeatEnable.Text = "Show Repeat";
            this.cbXbmcPlayingRepeatEnable.UseVisualStyleBackColor = true;
            // 
            // cbXbmcPlayingShuffleEnable
            // 
            this.cbXbmcPlayingShuffleEnable.AutoSize = true;
            this.cbXbmcPlayingShuffleEnable.Enabled = false;
            this.cbXbmcPlayingShuffleEnable.Location = new System.Drawing.Point(7, 97);
            this.cbXbmcPlayingShuffleEnable.Name = "cbXbmcPlayingShuffleEnable";
            this.cbXbmcPlayingShuffleEnable.Size = new System.Drawing.Size(95, 17);
            this.cbXbmcPlayingShuffleEnable.TabIndex = 6;
            this.cbXbmcPlayingShuffleEnable.Text = "Show Shuffled";
            this.cbXbmcPlayingShuffleEnable.UseVisualStyleBackColor = true;
            // 
            // bXbmcPlayingAudioCodecs
            // 
            this.bXbmcPlayingAudioCodecs.Enabled = false;
            this.bXbmcPlayingAudioCodecs.Location = new System.Drawing.Point(219, 67);
            this.bXbmcPlayingAudioCodecs.Name = "bXbmcPlayingAudioCodecs";
            this.bXbmcPlayingAudioCodecs.Size = new System.Drawing.Size(100, 23);
            this.bXbmcPlayingAudioCodecs.TabIndex = 5;
            this.bXbmcPlayingAudioCodecs.Text = "Edit mapping ...";
            this.bXbmcPlayingAudioCodecs.UseVisualStyleBackColor = true;
            this.bXbmcPlayingAudioCodecs.Click += new System.EventHandler(this.bXbmcPlayingAudioCodecs_Click);
            // 
            // bXbmcPlayingVideoCodecs
            // 
            this.bXbmcPlayingVideoCodecs.Enabled = false;
            this.bXbmcPlayingVideoCodecs.Location = new System.Drawing.Point(34, 67);
            this.bXbmcPlayingVideoCodecs.Name = "bXbmcPlayingVideoCodecs";
            this.bXbmcPlayingVideoCodecs.Size = new System.Drawing.Size(100, 23);
            this.bXbmcPlayingVideoCodecs.TabIndex = 4;
            this.bXbmcPlayingVideoCodecs.Text = "Edit mapping ...";
            this.bXbmcPlayingVideoCodecs.UseVisualStyleBackColor = true;
            this.bXbmcPlayingVideoCodecs.Click += new System.EventHandler(this.bXbmcPlayingVideoCodecs_Click);
            // 
            // cbXbmcPlayingAudioCodecs
            // 
            this.cbXbmcPlayingAudioCodecs.AutoSize = true;
            this.cbXbmcPlayingAudioCodecs.Location = new System.Drawing.Point(192, 44);
            this.cbXbmcPlayingAudioCodecs.Name = "cbXbmcPlayingAudioCodecs";
            this.cbXbmcPlayingAudioCodecs.Size = new System.Drawing.Size(120, 17);
            this.cbXbmcPlayingAudioCodecs.TabIndex = 3;
            this.cbXbmcPlayingAudioCodecs.Text = "Show audio codecs";
            this.cbXbmcPlayingAudioCodecs.UseVisualStyleBackColor = true;
            this.cbXbmcPlayingAudioCodecs.CheckedChanged += new System.EventHandler(this.cbXbmcPlayingAudioCodecs_CheckedChanged);
            // 
            // cbXbmcPlayingVideoCodecs
            // 
            this.cbXbmcPlayingVideoCodecs.AutoSize = true;
            this.cbXbmcPlayingVideoCodecs.Location = new System.Drawing.Point(7, 44);
            this.cbXbmcPlayingVideoCodecs.Name = "cbXbmcPlayingVideoCodecs";
            this.cbXbmcPlayingVideoCodecs.Size = new System.Drawing.Size(120, 17);
            this.cbXbmcPlayingVideoCodecs.TabIndex = 2;
            this.cbXbmcPlayingVideoCodecs.Text = "Show video codecs";
            this.cbXbmcPlayingVideoCodecs.UseVisualStyleBackColor = true;
            this.cbXbmcPlayingVideoCodecs.CheckedChanged += new System.EventHandler(this.cbXbmcPlayingVideoCodecs_CheckedChanged);
            // 
            // cbXbmcPlayingShowMediaType
            // 
            this.cbXbmcPlayingShowMediaType.AutoSize = true;
            this.cbXbmcPlayingShowMediaType.Location = new System.Drawing.Point(192, 20);
            this.cbXbmcPlayingShowMediaType.Name = "cbXbmcPlayingShowMediaType";
            this.cbXbmcPlayingShowMediaType.Size = new System.Drawing.Size(107, 17);
            this.cbXbmcPlayingShowMediaType.TabIndex = 1;
            this.cbXbmcPlayingShowMediaType.Text = "Show media type";
            this.cbXbmcPlayingShowMediaType.UseVisualStyleBackColor = true;
            // 
            // cbXbmcPlayingShowProgress
            // 
            this.cbXbmcPlayingShowProgress.AutoSize = true;
            this.cbXbmcPlayingShowProgress.Enabled = false;
            this.cbXbmcPlayingShowProgress.Location = new System.Drawing.Point(7, 20);
            this.cbXbmcPlayingShowProgress.Name = "cbXbmcPlayingShowProgress";
            this.cbXbmcPlayingShowProgress.Size = new System.Drawing.Size(96, 17);
            this.cbXbmcPlayingShowProgress.TabIndex = 0;
            this.cbXbmcPlayingShowProgress.Text = "Show progress";
            this.cbXbmcPlayingShowProgress.UseVisualStyleBackColor = true;
            // 
            // trayIcon
            // 
            this.trayIcon.Icon = ((System.Drawing.Icon) (resources.GetObject("trayIcon.Icon")));
            this.trayIcon.Text = "XBMC on iMon\r\nDisconnected";
            this.trayIcon.DoubleClick += new System.EventHandler(this.trayIcon_DoubleClick);
            // 
            // trayMenu
            // 
            this.trayMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.trayMenuOpen,
            this.toolStripSeparator5,
            this.trayMenuXBMC,
            this.trayMenuImon,
            this.toolStripSeparator4,
            this.trayMenuClose});
            this.trayMenu.Name = "trayMenu";
            this.trayMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.trayMenu.Size = new System.Drawing.Size(159, 104);
            // 
            // trayMenuOpen
            // 
            this.trayMenuOpen.Name = "trayMenuOpen";
            this.trayMenuOpen.Size = new System.Drawing.Size(158, 22);
            this.trayMenuOpen.Text = "Open";
            this.trayMenuOpen.Click += new System.EventHandler(this.trayMenuOpen_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(155, 6);
            // 
            // trayMenuXBMC
            // 
            this.trayMenuXBMC.Name = "trayMenuXBMC";
            this.trayMenuXBMC.Size = new System.Drawing.Size(158, 22);
            this.trayMenuXBMC.Text = "XBMC: Connect";
            this.trayMenuXBMC.Click += new System.EventHandler(this.trayMenuXBMC_Click);
            // 
            // trayMenuImon
            // 
            this.trayMenuImon.Enabled = false;
            this.trayMenuImon.Name = "trayMenuImon";
            this.trayMenuImon.Size = new System.Drawing.Size(158, 22);
            this.trayMenuImon.Text = "iMON: Initialize";
            this.trayMenuImon.Click += new System.EventHandler(this.trayMenuImon_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(155, 6);
            // 
            // trayMenuClose
            // 
            this.trayMenuClose.Name = "trayMenuClose";
            this.trayMenuClose.Size = new System.Drawing.Size(158, 22);
            this.trayMenuClose.Text = "Close";
            this.trayMenuClose.Click += new System.EventHandler(this.trayMenuClose_Click);
            // 
            // tbXbmcAnnouncementPort
            // 
            this.tbXbmcAnnouncementPort.Location = new System.Drawing.Point(140, 100);
            this.tbXbmcAnnouncementPort.Name = "tbXbmcAnnouncementPort";
            this.tbXbmcAnnouncementPort.Size = new System.Drawing.Size(73, 20);
            this.tbXbmcAnnouncementPort.TabIndex = 12;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(6, 102);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(128, 13);
            this.label9.TabIndex = 11;
            this.label9.Text = "Announcement port:";
            // 
            // bNavigationXbmc
            // 
            this.bNavigationXbmc.ActiveImageIndex = 7;
            this.bNavigationXbmc.BackColor = System.Drawing.Color.Transparent;
            this.bNavigationXbmc.DefaultImageIndex = 6;
            this.bNavigationXbmc.FlatAppearance.BorderSize = 0;
            this.bNavigationXbmc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bNavigationXbmc.HoverImageIndex = 8;
            this.bNavigationXbmc.ImageIndex = 6;
            this.bNavigationXbmc.ImageList = this.iLOptions;
            this.bNavigationXbmc.Location = new System.Drawing.Point(-1, 147);
            this.bNavigationXbmc.Margin = new System.Windows.Forms.Padding(0);
            this.bNavigationXbmc.Name = "bNavigationXbmc";
            this.bNavigationXbmc.Size = new System.Drawing.Size(74, 74);
            this.bNavigationXbmc.TabIndex = 5;
            this.bNavigationXbmc.UseVisualStyleBackColor = false;
            this.bNavigationXbmc.Click += new System.EventHandler(this.bNavigationXbmc_Click);
            // 
            // bNavigationImon
            // 
            this.bNavigationImon.ActiveImageIndex = 4;
            this.bNavigationImon.BackColor = System.Drawing.Color.Transparent;
            this.bNavigationImon.DefaultImageIndex = 3;
            this.bNavigationImon.FlatAppearance.BorderSize = 0;
            this.bNavigationImon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bNavigationImon.HoverImageIndex = 5;
            this.bNavigationImon.ImageIndex = 3;
            this.bNavigationImon.ImageList = this.iLOptions;
            this.bNavigationImon.Location = new System.Drawing.Point(-1, 73);
            this.bNavigationImon.Margin = new System.Windows.Forms.Padding(0);
            this.bNavigationImon.Name = "bNavigationImon";
            this.bNavigationImon.Size = new System.Drawing.Size(74, 74);
            this.bNavigationImon.TabIndex = 4;
            this.bNavigationImon.UseVisualStyleBackColor = false;
            this.bNavigationImon.Click += new System.EventHandler(this.bNavigationImon_Click);
            // 
            // bNavigationGeneral
            // 
            this.bNavigationGeneral.ActiveImageIndex = 1;
            this.bNavigationGeneral.BackColor = System.Drawing.Color.Transparent;
            this.bNavigationGeneral.DefaultImageIndex = 0;
            this.bNavigationGeneral.FlatAppearance.BorderSize = 0;
            this.bNavigationGeneral.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bNavigationGeneral.HoverImageIndex = 2;
            this.bNavigationGeneral.ImageIndex = 0;
            this.bNavigationGeneral.ImageList = this.iLOptions;
            this.bNavigationGeneral.Location = new System.Drawing.Point(-1, -1);
            this.bNavigationGeneral.Margin = new System.Windows.Forms.Padding(0);
            this.bNavigationGeneral.Name = "bNavigationGeneral";
            this.bNavigationGeneral.Size = new System.Drawing.Size(74, 74);
            this.bNavigationGeneral.TabIndex = 3;
            this.bNavigationGeneral.UseVisualStyleBackColor = false;
            this.bNavigationGeneral.Click += new System.EventHandler(this.bNavigationGeneral_Click);
            // 
            // tbXbmcMovieSingleText
            // 
            this.tbXbmcMovieSingleText.Delimiter = "%";
            this.tbXbmcMovieSingleText.Enabled = false;
            this.tbXbmcMovieSingleText.Location = new System.Drawing.Point(33, 40);
            this.tbXbmcMovieSingleText.MaximumRows = 2;
            this.tbXbmcMovieSingleText.Name = "tbXbmcMovieSingleText";
            this.tbXbmcMovieSingleText.Size = new System.Drawing.Size(336, 20);
            this.tbXbmcMovieSingleText.StartAndEnd = true;
            this.tbXbmcMovieSingleText.TabIndex = 5;
            // 
            // tbXbmcTvSingleText
            // 
            this.tbXbmcTvSingleText.Delimiter = "%";
            this.tbXbmcTvSingleText.Enabled = false;
            this.tbXbmcTvSingleText.Location = new System.Drawing.Point(33, 64);
            this.tbXbmcTvSingleText.MaximumRows = 2;
            this.tbXbmcTvSingleText.Name = "tbXbmcTvSingleText";
            this.tbXbmcTvSingleText.Size = new System.Drawing.Size(336, 20);
            this.tbXbmcTvSingleText.StartAndEnd = true;
            this.tbXbmcTvSingleText.TabIndex = 9;
            // 
            // tbXbmcMusicVideoSingleText
            // 
            this.tbXbmcMusicVideoSingleText.Delimiter = "%";
            this.tbXbmcMusicVideoSingleText.Enabled = false;
            this.tbXbmcMusicVideoSingleText.Location = new System.Drawing.Point(33, 40);
            this.tbXbmcMusicVideoSingleText.MaximumRows = 2;
            this.tbXbmcMusicVideoSingleText.Name = "tbXbmcMusicVideoSingleText";
            this.tbXbmcMusicVideoSingleText.Size = new System.Drawing.Size(336, 20);
            this.tbXbmcMusicVideoSingleText.StartAndEnd = true;
            this.tbXbmcMusicVideoSingleText.TabIndex = 9;
            // 
            // tbXbmcMusicSingleText
            // 
            this.tbXbmcMusicSingleText.Delimiter = "%";
            this.tbXbmcMusicSingleText.Enabled = false;
            this.tbXbmcMusicSingleText.Location = new System.Drawing.Point(33, 40);
            this.tbXbmcMusicSingleText.MaximumRows = 2;
            this.tbXbmcMusicSingleText.Name = "tbXbmcMusicSingleText";
            this.tbXbmcMusicSingleText.Size = new System.Drawing.Size(336, 20);
            this.tbXbmcMusicSingleText.StartAndEnd = true;
            this.tbXbmcMusicSingleText.TabIndex = 9;
            // 
            // XBMC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(487, 453);
            this.Controls.Add(this.splitter);
            this.Controls.Add(this.menu);
            this.Icon = ((System.Drawing.Icon) (resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menu;
            this.MaximizeBox = false;
            this.Name = "XBMC";
            this.Text = "XBMC on iMON";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.xbmc_FormClosing);
            this.Load += new System.EventHandler(this.xbmc_Load);
            this.Resize += new System.EventHandler(this.xbmc_Resize);
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.splitter.Panel1.ResumeLayout(false);
            this.splitter.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize) (this.splitter)).EndInit();
            this.splitter.ResumeLayout(false);
            this.pNavigation.ResumeLayout(false);
            this.tabOptions.ResumeLayout(false);
            this.tpImon.ResumeLayout(false);
            this.groupBox14.ResumeLayout(false);
            this.groupBox14.PerformLayout();
            this.groupBox13.ResumeLayout(false);
            this.groupBox13.PerformLayout();
            ((System.ComponentModel.ISupportInitialize) (this.nudImonLcdScrollingDelay)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.tpGeneral.ResumeLayout(false);
            this.groupBox15.ResumeLayout(false);
            this.groupBox15.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tpXBMC.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize) (this.nudXbmcIconsUpdateInterval)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize) (this.nudXbmcConnectionInterval)).EndInit();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.groupBox16.ResumeLayout(false);
            this.groupBox16.PerformLayout();
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.groupBox11.ResumeLayout(false);
            this.groupBox11.PerformLayout();
            this.groupBox10.ResumeLayout(false);
            this.groupBox10.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.trayMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem miGeneral;
        private System.Windows.Forms.ToolStripMenuItem miXbmc;
        private System.Windows.Forms.ToolStripMenuItem miXbmcConnect;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem miXbmcInfo;
        private System.Windows.Forms.ToolStripMenuItem miAbout;
        private System.Windows.Forms.ToolStripMenuItem miAboutXbmcOniMon;
        private System.Windows.Forms.ToolStripMenuItem miGeneralClose;
        private System.Windows.Forms.ToolStripMenuItem miImon;
        private System.Windows.Forms.ToolStripMenuItem miImonInitialize;
        private System.Windows.Forms.ToolStripMenuItem miImonUninitialize;
        private System.Windows.Forms.SplitContainer splitter;
        private System.Windows.Forms.ImageList iLOptions;
        private System.Windows.Forms.TabControl tabOptions;
        private System.Windows.Forms.TabPage tpGeneral;
        private System.Windows.Forms.TabPage tpImon;
        private System.Windows.Forms.TabPage tpXBMC;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ToolStripMenuItem miXbmcDisconnect;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.CheckBox cbGeneralTrayStartMinimized;
        private System.Windows.Forms.CheckBox cbGeneralTrayEnabled;
        private System.Windows.Forms.CheckBox cbGeneralStartupConnect;
        private System.Windows.Forms.CheckBox cbGeneralStartupAuto;
        private System.Windows.Forms.CheckBox cbGeneralTrayHideOnClose;
        private System.Windows.Forms.NotifyIcon trayIcon;
        private System.Windows.Forms.ContextMenuStrip trayMenu;
        private System.Windows.Forms.ToolStripMenuItem trayMenuOpen;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem trayMenuXBMC;
        private System.Windows.Forms.ToolStripMenuItem trayMenuImon;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem trayMenuClose;
        private System.Windows.Forms.CheckBox cbGeneralTrayHideOnMinimize;
        private System.Windows.Forms.CheckBox cbImonGeneralUninitializeOnError;
        private System.Windows.Forms.CheckBox cbImonGeneralAutoInitialize;
        private System.Windows.Forms.Panel pNavigation;
        private NavigationButton bNavigationGeneral;
        private NavigationButton bNavigationXbmc;
        private NavigationButton bNavigationImon;
        private System.Windows.Forms.GroupBox groupBox13;
        private System.Windows.Forms.NumericUpDown nudImonLcdScrollingDelay;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox14;
        private System.Windows.Forms.CheckBox cbImonSoundSystemSPDIF;
        private System.Windows.Forms.ComboBox cbImonSoundSystem;
        private System.Windows.Forms.CheckBox cbImonSoundSystemEnable;
        private System.Windows.Forms.GroupBox groupBox15;
        private System.Windows.Forms.CheckBox cbGeneralDebugEnable;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown nudXbmcIconsUpdateInterval;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox cbXbmcIconsScreen;
        private System.Windows.Forms.CheckBox cbXbmcIconsVolEnable;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown nudXbmcConnectionInterval;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbXbmcConnectionPassword;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbXbmcConnectionUsername;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbXbmcConnectionPort;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbXbmcConnectionIp;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox11;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox tbXbmcIdleStaticText;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.CheckBox cbXbmcPlayingRepeatEnable;
        private System.Windows.Forms.CheckBox cbXbmcPlayingShuffleEnable;
        private System.Windows.Forms.Button bXbmcPlayingAudioCodecs;
        private System.Windows.Forms.Button bXbmcPlayingVideoCodecs;
        private System.Windows.Forms.CheckBox cbXbmcPlayingAudioCodecs;
        private System.Windows.Forms.CheckBox cbXbmcPlayingVideoCodecs;
        private System.Windows.Forms.CheckBox cbXbmcPlayingShowMediaType;
        private System.Windows.Forms.CheckBox cbXbmcPlayingShowProgress;
        private System.Windows.Forms.GroupBox groupBox10;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.RadioButton rbXbmcMovieSingleText;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.RadioButton rbXbmcTvSingleText;
        private System.Windows.Forms.CheckBox cbXbmcTvShowTvHdtvIcon;
        private System.Windows.Forms.CheckBox cbXbmcTvMediaTypeIcon;
        private System.Windows.Forms.GroupBox groupBox16;
        private System.Windows.Forms.CheckBox cbXbmcControlModeRemoveBrackets;
        private System.Windows.Forms.CheckBox cbXbmcControlModeShowWindow;
        private System.Windows.Forms.CheckBox cbXbmcControlModeDisableDuringPlayback;
        private System.Windows.Forms.CheckBox cbXbmcControlModeEnable;
        private System.Windows.Forms.CheckBox cbGeneralTrayDisableBalloonTips;
        private SuggestionBox tbXbmcMovieSingleText;
        private SuggestionBox tbXbmcTvSingleText;
        private SuggestionBox tbXbmcMusicSingleText;
        private System.Windows.Forms.RadioButton rbXbmcMusicSingleText;
        private SuggestionBox tbXbmcMusicVideoSingleText;
        private System.Windows.Forms.RadioButton rbXbmcMusicVideoSingleText;
        private System.Windows.Forms.CheckBox cbXbmcPlayingDiscBottomCircle;
        private System.Windows.Forms.CheckBox cbXbmcPlayingDiscRotate;
        private System.Windows.Forms.CheckBox cbXbmcPlayingDiscEnable;
        private System.Windows.Forms.RadioButton rbXbmcIdleTime;
        private System.Windows.Forms.RadioButton rbXbmcIdleStaticTextEnable;
        private System.Windows.Forms.RadioButton rbXbmcMusicStayIdle;
        private System.Windows.Forms.RadioButton rbXbmcMusicVideoStayIdle;
        private System.Windows.Forms.RadioButton rbXbmcTvStayIdle;
        private System.Windows.Forms.RadioButton rbXbmcMovieStayIdle;
        private System.Windows.Forms.CheckBox cbXbmcIdleShowSeconds;
        private System.Windows.Forms.TextBox tbXbmcAnnouncementPort;
        private System.Windows.Forms.Label label9;


    }
}

