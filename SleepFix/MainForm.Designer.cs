namespace Coffee_FF
{
    partial class MainForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.refreshTimer = new System.Windows.Forms.Timer(this.components);
			this.lblUpload = new System.Windows.Forms.Label();
			this.lblDownload = new System.Windows.Forms.Label();
			this.nicComboBox = new System.Windows.Forms.ComboBox();
			this.trayIcon = new System.Windows.Forms.NotifyIcon(this.components);
			this.trayIconMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.showToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.lblOP = new System.Windows.Forms.Label();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.downloadUpDn = new System.Windows.Forms.NumericUpDown();
			this.label1 = new System.Windows.Forms.Label();
			this.sleepBlockBtn = new System.Windows.Forms.Button();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.mainPage = new System.Windows.Forms.TabPage();
			this.groupBox8 = new System.Windows.Forms.GroupBox();
			this.blockSleepBtn = new System.Windows.Forms.Button();
			this.label7 = new System.Windows.Forms.Label();
			this.blockDurationUpDn = new System.Windows.Forms.NumericUpDown();
			this.groupBox7 = new System.Windows.Forms.GroupBox();
			this.preventDisplayStandbyCheck = new System.Windows.Forms.CheckBox();
			this.closeBtn = new System.Windows.Forms.Button();
			this.groupBox6 = new System.Windows.Forms.GroupBox();
			this.label5 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.keypressIntervalUpDn = new System.Windows.Forms.NumericUpDown();
			this.keypressEnableCheckBox = new System.Windows.Forms.CheckBox();
			this.groupBox5 = new System.Windows.Forms.GroupBox();
			this.Delay = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.removeDelayUpDn = new System.Windows.Forms.NumericUpDown();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.label2 = new System.Windows.Forms.Label();
			this.uploadUpDn = new System.Windows.Forms.NumericUpDown();
			this.programsPage = new System.Windows.Forms.TabPage();
			this.XXPrograms = new System.Windows.Forms.Label();
			this.refreshProgBtn = new System.Windows.Forms.Button();
			this.clbProcess = new System.Windows.Forms.CheckedListBox();
			this.extraPage = new System.Windows.Forms.TabPage();
			this.gotoWebBtn = new System.Windows.Forms.Button();
			this.donateBtn = new System.Windows.Forms.Button();
			this.runWithWinBtn = new System.Windows.Forms.Button();
			this.trayIconMenuStrip.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.downloadUpDn)).BeginInit();
			this.tabControl1.SuspendLayout();
			this.mainPage.SuspendLayout();
			this.groupBox8.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.blockDurationUpDn)).BeginInit();
			this.groupBox7.SuspendLayout();
			this.groupBox6.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.keypressIntervalUpDn)).BeginInit();
			this.groupBox5.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.removeDelayUpDn)).BeginInit();
			this.groupBox4.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.uploadUpDn)).BeginInit();
			this.programsPage.SuspendLayout();
			this.extraPage.SuspendLayout();
			this.SuspendLayout();
			// 
			// refreshTimer
			// 
			this.refreshTimer.Interval = 1000;
			this.refreshTimer.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// lblUpload
			// 
			this.lblUpload.AutoSize = true;
			this.lblUpload.Location = new System.Drawing.Point(175, 21);
			this.lblUpload.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lblUpload.Name = "lblUpload";
			this.lblUpload.Size = new System.Drawing.Size(48, 15);
			this.lblUpload.TabIndex = 3;
			this.lblUpload.Text = "Upload:";
			// 
			// lblDownload
			// 
			this.lblDownload.AutoSize = true;
			this.lblDownload.Location = new System.Drawing.Point(8, 21);
			this.lblDownload.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lblDownload.Name = "lblDownload";
			this.lblDownload.Size = new System.Drawing.Size(64, 15);
			this.lblDownload.TabIndex = 4;
			this.lblDownload.Text = "Download:";
			// 
			// nicComboBox
			// 
			this.nicComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.nicComboBox.FormattingEnabled = true;
			this.nicComboBox.Location = new System.Drawing.Point(10, 20);
			this.nicComboBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.nicComboBox.Name = "nicComboBox";
			this.nicComboBox.Size = new System.Drawing.Size(318, 23);
			this.nicComboBox.TabIndex = 5;
			// 
			// trayIcon
			// 
			this.trayIcon.ContextMenuStrip = this.trayIconMenuStrip;
			this.trayIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("trayIcon.Icon")));
			this.trayIcon.Text = "Coffee";
			this.trayIcon.DoubleClick += new System.EventHandler(this.notifyIcon1_DoubleClick);
			// 
			// trayIconMenuStrip
			// 
			this.trayIconMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showToolStripMenuItem,
            this.exitToolStripMenuItem});
			this.trayIconMenuStrip.Name = "contextMenuStrip1";
			this.trayIconMenuStrip.Size = new System.Drawing.Size(104, 48);
			// 
			// showToolStripMenuItem
			// 
			this.showToolStripMenuItem.Name = "showToolStripMenuItem";
			this.showToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
			this.showToolStripMenuItem.Text = "Show";
			this.showToolStripMenuItem.Click += new System.EventHandler(this.showToolStripMenuItem_Click);
			// 
			// exitToolStripMenuItem
			// 
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
			this.exitToolStripMenuItem.Text = "Exit";
			this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.lblOP);
			this.groupBox1.Controls.Add(this.nicComboBox);
			this.groupBox1.Location = new System.Drawing.Point(7, 7);
			this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.groupBox1.Size = new System.Drawing.Size(336, 85);
			this.groupBox1.TabIndex = 9;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Network Adaptor";
			// 
			// lblOP
			// 
			this.lblOP.AutoSize = true;
			this.lblOP.Location = new System.Drawing.Point(9, 55);
			this.lblOP.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lblOP.Name = "lblOP";
			this.lblOP.Size = new System.Drawing.Size(87, 15);
			this.lblOP.TabIndex = 5;
			this.lblOP.Text = "Adapter Status:";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.lblDownload);
			this.groupBox2.Controls.Add(this.lblUpload);
			this.groupBox2.Location = new System.Drawing.Point(9, 102);
			this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.groupBox2.Size = new System.Drawing.Size(335, 46);
			this.groupBox2.TabIndex = 10;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Current Speeds";
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.downloadUpDn);
			this.groupBox3.Controls.Add(this.label1);
			this.groupBox3.Location = new System.Drawing.Point(8, 152);
			this.groupBox3.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.groupBox3.Size = new System.Drawing.Size(164, 62);
			this.groupBox3.TabIndex = 11;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Download Threshold";
			// 
			// downloadUpDn
			// 
			this.downloadUpDn.Location = new System.Drawing.Point(13, 28);
			this.downloadUpDn.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.downloadUpDn.Maximum = new decimal(new int[] {
            200000,
            0,
            0,
            0});
			this.downloadUpDn.Name = "downloadUpDn";
			this.downloadUpDn.Size = new System.Drawing.Size(96, 23);
			this.downloadUpDn.TabIndex = 14;
			this.downloadUpDn.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
			this.downloadUpDn.Leave += new System.EventHandler(this.numericUpDown1_Leave);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(115, 36);
			this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(31, 15);
			this.label1.TabIndex = 13;
			this.label1.Text = "KB/s";
			// 
			// sleepBlockBtn
			// 
			this.sleepBlockBtn.Location = new System.Drawing.Point(103, 82);
			this.sleepBlockBtn.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.sleepBlockBtn.Name = "sleepBlockBtn";
			this.sleepBlockBtn.Size = new System.Drawing.Size(149, 27);
			this.sleepBlockBtn.TabIndex = 12;
			this.sleepBlockBtn.Text = "Sleep Blockers";
			this.sleepBlockBtn.UseVisualStyleBackColor = true;
			this.sleepBlockBtn.Click += new System.EventHandler(this.sleepBlockBtnClick);
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.mainPage);
			this.tabControl1.Controls.Add(this.programsPage);
			this.tabControl1.Controls.Add(this.extraPage);
			this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl1.ItemSize = new System.Drawing.Size(42, 18);
			this.tabControl1.Location = new System.Drawing.Point(0, 0);
			this.tabControl1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(362, 505);
			this.tabControl1.TabIndex = 13;
			// 
			// mainPage
			// 
			this.mainPage.Controls.Add(this.groupBox8);
			this.mainPage.Controls.Add(this.groupBox7);
			this.mainPage.Controls.Add(this.closeBtn);
			this.mainPage.Controls.Add(this.groupBox6);
			this.mainPage.Controls.Add(this.groupBox5);
			this.mainPage.Controls.Add(this.groupBox4);
			this.mainPage.Controls.Add(this.groupBox1);
			this.mainPage.Controls.Add(this.groupBox3);
			this.mainPage.Controls.Add(this.groupBox2);
			this.mainPage.Location = new System.Drawing.Point(4, 22);
			this.mainPage.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.mainPage.Name = "mainPage";
			this.mainPage.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.mainPage.Size = new System.Drawing.Size(354, 479);
			this.mainPage.TabIndex = 0;
			this.mainPage.Text = "Main";
			this.mainPage.UseVisualStyleBackColor = true;
			// 
			// groupBox8
			// 
			this.groupBox8.Controls.Add(this.blockSleepBtn);
			this.groupBox8.Controls.Add(this.label7);
			this.groupBox8.Controls.Add(this.blockDurationUpDn);
			this.groupBox8.Location = new System.Drawing.Point(8, 351);
			this.groupBox8.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.groupBox8.Name = "groupBox8";
			this.groupBox8.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.groupBox8.Size = new System.Drawing.Size(141, 117);
			this.groupBox8.TabIndex = 17;
			this.groupBox8.TabStop = false;
			this.groupBox8.Text = "Timer. Block sleep for X minutes.";
			// 
			// blockSleepBtn
			// 
			this.blockSleepBtn.Location = new System.Drawing.Point(19, 74);
			this.blockSleepBtn.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.blockSleepBtn.Name = "blockSleepBtn";
			this.blockSleepBtn.Size = new System.Drawing.Size(104, 28);
			this.blockSleepBtn.TabIndex = 18;
			this.blockSleepBtn.TabStop = false;
			this.blockSleepBtn.Text = "Start";
			this.blockSleepBtn.UseVisualStyleBackColor = true;
			this.blockSleepBtn.Click += new System.EventHandler(this.blockSleepBtnClick);
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(82, 39);
			this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(50, 15);
			this.label7.TabIndex = 15;
			this.label7.Text = "Minutes";
			// 
			// blockDurationUpDn
			// 
			this.blockDurationUpDn.Location = new System.Drawing.Point(10, 37);
			this.blockDurationUpDn.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.blockDurationUpDn.Maximum = new decimal(new int[] {
            200000,
            0,
            0,
            0});
			this.blockDurationUpDn.Name = "blockDurationUpDn";
			this.blockDurationUpDn.Size = new System.Drawing.Size(64, 23);
			this.blockDurationUpDn.TabIndex = 0;
			// 
			// groupBox7
			// 
			this.groupBox7.Controls.Add(this.preventDisplayStandbyCheck);
			this.groupBox7.Location = new System.Drawing.Point(158, 318);
			this.groupBox7.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.groupBox7.Name = "groupBox7";
			this.groupBox7.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.groupBox7.Size = new System.Drawing.Size(188, 57);
			this.groupBox7.TabIndex = 15;
			this.groupBox7.TabStop = false;
			this.groupBox7.Text = "Prevent display standby";
			// 
			// preventDisplayStandbyCheck
			// 
			this.preventDisplayStandbyCheck.AutoSize = true;
			this.preventDisplayStandbyCheck.Location = new System.Drawing.Point(7, 22);
			this.preventDisplayStandbyCheck.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.preventDisplayStandbyCheck.Name = "preventDisplayStandbyCheck";
			this.preventDisplayStandbyCheck.Size = new System.Drawing.Size(111, 19);
			this.preventDisplayStandbyCheck.TabIndex = 17;
			this.preventDisplayStandbyCheck.Text = "Check to Enable";
			this.preventDisplayStandbyCheck.UseVisualStyleBackColor = true;
			this.preventDisplayStandbyCheck.CheckedChanged += new System.EventHandler(this.preventDisplayStandbyCheckCheckedChanged);
			// 
			// closeBtn
			// 
			this.closeBtn.Location = new System.Drawing.Point(158, 406);
			this.closeBtn.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.closeBtn.Name = "closeBtn";
			this.closeBtn.Size = new System.Drawing.Size(188, 37);
			this.closeBtn.TabIndex = 14;
			this.closeBtn.TabStop = false;
			this.closeBtn.Text = "Minimize to System Tray";
			this.closeBtn.UseVisualStyleBackColor = true;
			this.closeBtn.Click += new System.EventHandler(this.closeBtnClick);
			// 
			// groupBox6
			// 
			this.groupBox6.Controls.Add(this.label5);
			this.groupBox6.Controls.Add(this.label4);
			this.groupBox6.Controls.Add(this.keypressIntervalUpDn);
			this.groupBox6.Controls.Add(this.keypressEnableCheckBox);
			this.groupBox6.Location = new System.Drawing.Point(156, 222);
			this.groupBox6.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.groupBox6.Name = "groupBox6";
			this.groupBox6.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.groupBox6.Size = new System.Drawing.Size(188, 93);
			this.groupBox6.TabIndex = 14;
			this.groupBox6.TabStop = false;
			this.groupBox6.Text = "Simulate Keypress";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(79, 66);
			this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(50, 15);
			this.label5.TabIndex = 20;
			this.label5.Text = "Minutes";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(7, 45);
			this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(151, 15);
			this.label4.TabIndex = 19;
			this.label4.Text = "Send virtual key press every";
			// 
			// keypressIntervalUpDn
			// 
			this.keypressIntervalUpDn.Location = new System.Drawing.Point(7, 63);
			this.keypressIntervalUpDn.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.keypressIntervalUpDn.Maximum = new decimal(new int[] {
            200000,
            0,
            0,
            0});
			this.keypressIntervalUpDn.Name = "keypressIntervalUpDn";
			this.keypressIntervalUpDn.Size = new System.Drawing.Size(64, 23);
			this.keypressIntervalUpDn.TabIndex = 18;
			// 
			// keypressEnableCheckBox
			// 
			this.keypressEnableCheckBox.AutoSize = true;
			this.keypressEnableCheckBox.Location = new System.Drawing.Point(7, 22);
			this.keypressEnableCheckBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.keypressEnableCheckBox.Name = "keypressEnableCheckBox";
			this.keypressEnableCheckBox.Size = new System.Drawing.Size(111, 19);
			this.keypressEnableCheckBox.TabIndex = 17;
			this.keypressEnableCheckBox.Text = "Check to Enable";
			this.keypressEnableCheckBox.UseVisualStyleBackColor = true;
			this.keypressEnableCheckBox.CheckedChanged += new System.EventHandler(this.keypressEnableCheckedChanged);
			// 
			// groupBox5
			// 
			this.groupBox5.Controls.Add(this.Delay);
			this.groupBox5.Controls.Add(this.label3);
			this.groupBox5.Controls.Add(this.removeDelayUpDn);
			this.groupBox5.Location = new System.Drawing.Point(8, 222);
			this.groupBox5.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.groupBox5.Name = "groupBox5";
			this.groupBox5.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.groupBox5.Size = new System.Drawing.Size(141, 117);
			this.groupBox5.TabIndex = 13;
			this.groupBox5.TabStop = false;
			this.groupBox5.Text = "Delay To Remove Sleep Block ";
			// 
			// Delay
			// 
			this.Delay.AutoSize = true;
			this.Delay.Location = new System.Drawing.Point(0, 74);
			this.Delay.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.Delay.Name = "Delay";
			this.Delay.Size = new System.Drawing.Size(139, 15);
			this.Delay.TabIndex = 16;
			this.Delay.Text = "Delay will be removed at:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(82, 39);
			this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(50, 15);
			this.label3.TabIndex = 15;
			this.label3.Text = "Minutes";
			// 
			// removeDelayUpDn
			// 
			this.removeDelayUpDn.Location = new System.Drawing.Point(10, 37);
			this.removeDelayUpDn.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.removeDelayUpDn.Maximum = new decimal(new int[] {
            200000,
            0,
            0,
            0});
			this.removeDelayUpDn.Name = "removeDelayUpDn";
			this.removeDelayUpDn.Size = new System.Drawing.Size(64, 23);
			this.removeDelayUpDn.TabIndex = 0;
			// 
			// groupBox4
			// 
			this.groupBox4.Controls.Add(this.label2);
			this.groupBox4.Controls.Add(this.uploadUpDn);
			this.groupBox4.Location = new System.Drawing.Point(180, 152);
			this.groupBox4.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.groupBox4.Size = new System.Drawing.Size(164, 62);
			this.groupBox4.TabIndex = 12;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Upload Threshold";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(114, 33);
			this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(31, 15);
			this.label2.TabIndex = 15;
			this.label2.Text = "KB/s";
			// 
			// uploadUpDn
			// 
			this.uploadUpDn.Location = new System.Drawing.Point(8, 25);
			this.uploadUpDn.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.uploadUpDn.Maximum = new decimal(new int[] {
            200000,
            0,
            0,
            0});
			this.uploadUpDn.Name = "uploadUpDn";
			this.uploadUpDn.Size = new System.Drawing.Size(99, 23);
			this.uploadUpDn.TabIndex = 0;
			// 
			// programsPage
			// 
			this.programsPage.Controls.Add(this.XXPrograms);
			this.programsPage.Controls.Add(this.refreshProgBtn);
			this.programsPage.Controls.Add(this.clbProcess);
			this.programsPage.Location = new System.Drawing.Point(4, 22);
			this.programsPage.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.programsPage.Name = "programsPage";
			this.programsPage.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.programsPage.Size = new System.Drawing.Size(354, 479);
			this.programsPage.TabIndex = 2;
			this.programsPage.Text = "Programs";
			this.programsPage.UseVisualStyleBackColor = true;
			this.programsPage.Enter += new System.EventHandler(this.programsPage_Enter);
			// 
			// XXPrograms
			// 
			this.XXPrograms.AutoSize = true;
			this.XXPrograms.Location = new System.Drawing.Point(249, 438);
			this.XXPrograms.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.XXPrograms.Name = "XXPrograms";
			this.XXPrograms.Size = new System.Drawing.Size(75, 15);
			this.XXPrograms.TabIndex = 3;
			this.XXPrograms.Text = "XX Programs";
			// 
			// refreshProgBtn
			// 
			this.refreshProgBtn.Location = new System.Drawing.Point(8, 431);
			this.refreshProgBtn.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.refreshProgBtn.Name = "refreshProgBtn";
			this.refreshProgBtn.Size = new System.Drawing.Size(233, 28);
			this.refreshProgBtn.TabIndex = 2;
			this.refreshProgBtn.Text = "Refresh Programs List";
			this.refreshProgBtn.UseVisualStyleBackColor = true;
			this.refreshProgBtn.Click += new System.EventHandler(this.refreshProgBtnClick);
			// 
			// clbProcess
			// 
			this.clbProcess.BackColor = System.Drawing.SystemColors.Window;
			this.clbProcess.CheckOnClick = true;
			this.clbProcess.FormattingEnabled = true;
			this.clbProcess.Location = new System.Drawing.Point(8, 7);
			this.clbProcess.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.clbProcess.Name = "clbProcess";
			this.clbProcess.Size = new System.Drawing.Size(339, 418);
			this.clbProcess.Sorted = true;
			this.clbProcess.TabIndex = 1;
			// 
			// extraPage
			// 
			this.extraPage.Controls.Add(this.gotoWebBtn);
			this.extraPage.Controls.Add(this.donateBtn);
			this.extraPage.Controls.Add(this.runWithWinBtn);
			this.extraPage.Controls.Add(this.sleepBlockBtn);
			this.extraPage.Location = new System.Drawing.Point(4, 22);
			this.extraPage.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.extraPage.Name = "extraPage";
			this.extraPage.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.extraPage.Size = new System.Drawing.Size(354, 479);
			this.extraPage.TabIndex = 1;
			this.extraPage.Text = "Extra";
			this.extraPage.UseVisualStyleBackColor = true;
			// 
			// gotoWebBtn
			// 
			this.gotoWebBtn.Location = new System.Drawing.Point(103, 175);
			this.gotoWebBtn.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.gotoWebBtn.Name = "gotoWebBtn";
			this.gotoWebBtn.Size = new System.Drawing.Size(149, 27);
			this.gotoWebBtn.TabIndex = 17;
			this.gotoWebBtn.Text = "FireFly\'s Coffee Website";
			this.gotoWebBtn.UseVisualStyleBackColor = true;
			this.gotoWebBtn.Click += new System.EventHandler(this.gotoWebBtnClick);
			// 
			// donateBtn
			// 
			this.donateBtn.Location = new System.Drawing.Point(103, 130);
			this.donateBtn.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.donateBtn.Name = "donateBtn";
			this.donateBtn.Size = new System.Drawing.Size(149, 27);
			this.donateBtn.TabIndex = 16;
			this.donateBtn.Text = "Donate to Steven";
			this.donateBtn.UseVisualStyleBackColor = true;
			this.donateBtn.Click += new System.EventHandler(this.donateBtnClick);
			// 
			// runWithWinBtn
			// 
			this.runWithWinBtn.Location = new System.Drawing.Point(103, 31);
			this.runWithWinBtn.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.runWithWinBtn.Name = "runWithWinBtn";
			this.runWithWinBtn.Size = new System.Drawing.Size(149, 27);
			this.runWithWinBtn.TabIndex = 13;
			this.runWithWinBtn.Text = "Run with Windows";
			this.runWithWinBtn.UseVisualStyleBackColor = true;
			this.runWithWinBtn.Click += new System.EventHandler(this.runWithWinBtnClick);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(362, 505);
			this.Controls.Add(this.tabControl1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Coffee_FF";
			this.trayIconMenuStrip.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.downloadUpDn)).EndInit();
			this.tabControl1.ResumeLayout(false);
			this.mainPage.ResumeLayout(false);
			this.groupBox8.ResumeLayout(false);
			this.groupBox8.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.blockDurationUpDn)).EndInit();
			this.groupBox7.ResumeLayout(false);
			this.groupBox7.PerformLayout();
			this.groupBox6.ResumeLayout(false);
			this.groupBox6.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.keypressIntervalUpDn)).EndInit();
			this.groupBox5.ResumeLayout(false);
			this.groupBox5.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.removeDelayUpDn)).EndInit();
			this.groupBox4.ResumeLayout(false);
			this.groupBox4.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.uploadUpDn)).EndInit();
			this.programsPage.ResumeLayout(false);
			this.programsPage.PerformLayout();
			this.extraPage.ResumeLayout(false);
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer refreshTimer;
        private System.Windows.Forms.Label lblUpload;
        private System.Windows.Forms.Label lblDownload;
        private System.Windows.Forms.ComboBox nicComboBox;
        private System.Windows.Forms.NotifyIcon trayIcon;
        private System.Windows.Forms.ContextMenuStrip trayIconMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button sleepBlockBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown downloadUpDn;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage mainPage;
        private System.Windows.Forms.TabPage extraPage;
        private System.Windows.Forms.Button runWithWinBtn;
        private System.Windows.Forms.Button donateBtn;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown uploadUpDn;
        private System.Windows.Forms.TabPage programsPage;
        private System.Windows.Forms.CheckedListBox clbProcess;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.CheckBox keypressEnableCheckBox;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown removeDelayUpDn;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown keypressIntervalUpDn;
        private System.Windows.Forms.Button gotoWebBtn;
        private System.Windows.Forms.Label Delay;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.CheckBox preventDisplayStandbyCheck;
        private System.Windows.Forms.Button closeBtn;
        private System.Windows.Forms.Label lblOP;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown blockDurationUpDn;
        private System.Windows.Forms.Button blockSleepBtn;
        private System.Windows.Forms.Button refreshProgBtn;
        private System.Windows.Forms.Label XXPrograms;

    }
}

