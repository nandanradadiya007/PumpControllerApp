namespace PumpControllerApp
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuExit;

        private System.Windows.Forms.ToolStripMenuItem connectionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuRefreshPorts;
        private System.Windows.Forms.ToolStripMenuItem menuConnect;
        private System.Windows.Forms.ToolStripMenuItem menuDisconnect;

        private System.Windows.Forms.ToolStripMenuItem commandsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuStart;
        private System.Windows.Forms.ToolStripMenuItem menuStop;
        private System.Windows.Forms.ToolStripMenuItem menuClean;

        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuExportLog;
        private System.Windows.Forms.ToolStripMenuItem menuClearLog;

        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuAbout;

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStatusConn;
        private System.Windows.Forms.ToolStripStatusLabel toolStatusLast;
        private System.Windows.Forms.ToolStripStatusLabel toolStatusError;

        private System.Windows.Forms.SplitContainer splitContainer1;

        // Left panel controls
        private System.Windows.Forms.GroupBox grpConnection;
        private System.Windows.Forms.Label lblPort;
        private System.Windows.Forms.ComboBox cmbPort;
        private System.Windows.Forms.Label lblBaud;
        private System.Windows.Forms.ComboBox cmbBaud;
        private System.Windows.Forms.Label lblInterval;
        private System.Windows.Forms.NumericUpDown nudIntervalMs;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btnDisconnect;

        private System.Windows.Forms.GroupBox grpPressure;
        private System.Windows.Forms.Label lblMaxPsi;
        private System.Windows.Forms.NumericUpDown nudMaxPsi;
        private System.Windows.Forms.Button btnSendMax;
        private System.Windows.Forms.Label lblMinPsi;
        private System.Windows.Forms.NumericUpDown nudMinPsi;
        private System.Windows.Forms.Button btnSendMin;

        private System.Windows.Forms.GroupBox grpFlow;
        private System.Windows.Forms.Label lblFlow;
        private System.Windows.Forms.NumericUpDown nudFlow;
        private System.Windows.Forms.Button btnSendFlow;

        private System.Windows.Forms.GroupBox grpActions;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnClean;

        // Right panel controls
        private System.Windows.Forms.Label lblPreview;
        private System.Windows.Forms.TextBox txtPreview;
        private System.Windows.Forms.TextBox txtLog;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            menuExit = new ToolStripMenuItem();
            connectionToolStripMenuItem = new ToolStripMenuItem();
            menuRefreshPorts = new ToolStripMenuItem();
            menuConnect = new ToolStripMenuItem();
            menuDisconnect = new ToolStripMenuItem();
            commandsToolStripMenuItem = new ToolStripMenuItem();
            menuStart = new ToolStripMenuItem();
            menuStop = new ToolStripMenuItem();
            menuClean = new ToolStripMenuItem();
            toolsToolStripMenuItem = new ToolStripMenuItem();
            menuExportLog = new ToolStripMenuItem();
            menuClearLog = new ToolStripMenuItem();
            helpToolStripMenuItem = new ToolStripMenuItem();
            menuAbout = new ToolStripMenuItem();
            statusStrip1 = new StatusStrip();
            toolStatusConn = new ToolStripStatusLabel();
            toolStatusLast = new ToolStripStatusLabel();
            toolStatusError = new ToolStripStatusLabel();
            splitContainer1 = new SplitContainer();
            grpActions = new GroupBox();
            btnStart = new Button();
            btnStop = new Button();
            btnClean = new Button();
            grpFlow = new GroupBox();
            lblFlow = new Label();
            nudFlow = new NumericUpDown();
            btnSendFlow = new Button();
            grpPressure = new GroupBox();
            lblMaxPsi = new Label();
            nudMaxPsi = new NumericUpDown();
            btnSendMax = new Button();
            lblMinPsi = new Label();
            nudMinPsi = new NumericUpDown();
            btnSendMin = new Button();
            grpConnection = new GroupBox();
            lblPort = new Label();
            cmbPort = new ComboBox();
            lblBaud = new Label();
            cmbBaud = new ComboBox();
            lblInterval = new Label();
            nudIntervalMs = new NumericUpDown();
            btnRefresh = new Button();
            btnConnect = new Button();
            btnDisconnect = new Button();
            txtLog = new TextBox();
            txtPreview = new TextBox();
            lblPreview = new Label();
            menuStrip1.SuspendLayout();
            statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            grpActions.SuspendLayout();
            grpFlow.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudFlow).BeginInit();
            grpPressure.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudMaxPsi).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudMinPsi).BeginInit();
            grpConnection.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudIntervalMs).BeginInit();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(24, 24);
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, connectionToolStripMenuItem, commandsToolStripMenuItem, toolsToolStripMenuItem, helpToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(9, 3, 0, 3);
            menuStrip1.Size = new Size(1068, 35);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { menuExit });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(54, 29);
            fileToolStripMenuItem.Text = "File";
            // 
            // menuExit
            // 
            menuExit.Name = "menuExit";
            menuExit.Size = new Size(141, 34);
            menuExit.Text = "Exit";
            menuExit.Click += menuExit_Click;
            // 
            // connectionToolStripMenuItem
            // 
            connectionToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { menuRefreshPorts, menuConnect, menuDisconnect });
            connectionToolStripMenuItem.Name = "connectionToolStripMenuItem";
            connectionToolStripMenuItem.Size = new Size(118, 29);
            connectionToolStripMenuItem.Text = "Connection";
            // 
            // menuRefreshPorts
            // 
            menuRefreshPorts.Name = "menuRefreshPorts";
            menuRefreshPorts.Size = new Size(217, 34);
            menuRefreshPorts.Text = "Refresh Ports";
            menuRefreshPorts.Click += menuRefreshPorts_Click;
            // 
            // menuConnect
            // 
            menuConnect.Name = "menuConnect";
            menuConnect.Size = new Size(217, 34);
            menuConnect.Text = "Connect";
            menuConnect.Click += menuConnect_Click;
            // 
            // menuDisconnect
            // 
            menuDisconnect.Name = "menuDisconnect";
            menuDisconnect.Size = new Size(217, 34);
            menuDisconnect.Text = "Disconnect";
            menuDisconnect.Click += menuDisconnect_Click;
            // 
            // commandsToolStripMenuItem
            // 
            commandsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { menuStart, menuStop, menuClean });
            commandsToolStripMenuItem.Name = "commandsToolStripMenuItem";
            commandsToolStripMenuItem.Size = new Size(120, 29);
            commandsToolStripMenuItem.Text = "Commands";
            // 
            // menuStart
            // 
            menuStart.Name = "menuStart";
            menuStart.Size = new Size(157, 34);
            menuStart.Text = "Start";
            menuStart.Click += menuStart_Click;
            // 
            // menuStop
            // 
            menuStop.Name = "menuStop";
            menuStop.Size = new Size(157, 34);
            menuStop.Text = "Stop";
            menuStop.Click += menuStop_Click;
            // 
            // menuClean
            // 
            menuClean.Name = "menuClean";
            menuClean.Size = new Size(157, 34);
            menuClean.Text = "Clean";
            menuClean.Click += menuClean_Click;
            // 
            // toolsToolStripMenuItem
            // 
            toolsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { menuExportLog, menuClearLog });
            toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            toolsToolStripMenuItem.Size = new Size(69, 29);
            toolsToolStripMenuItem.Text = "Tools";
            // 
            // menuExportLog
            // 
            menuExportLog.Name = "menuExportLog";
            menuExportLog.Size = new Size(212, 34);
            menuExportLog.Text = "Export Log...";
            menuExportLog.Click += menuExportLog_Click;
            // 
            // menuClearLog
            // 
            menuClearLog.Name = "menuClearLog";
            menuClearLog.Size = new Size(212, 34);
            menuClearLog.Text = "Clear Log";
            menuClearLog.Click += menuClearLog_Click;
            // 
            // helpToolStripMenuItem
            // 
            helpToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { menuAbout });
            helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            helpToolStripMenuItem.Size = new Size(65, 29);
            helpToolStripMenuItem.Text = "Help";
            // 
            // menuAbout
            // 
            menuAbout.Name = "menuAbout";
            menuAbout.Size = new Size(164, 34);
            menuAbout.Text = "About";
            menuAbout.Click += menuAbout_Click;
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new Size(24, 24);
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStatusConn, toolStatusLast, toolStatusError });
            statusStrip1.Location = new Point(0, 1018);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Padding = new Padding(1, 0, 20, 0);
            statusStrip1.Size = new Size(1068, 32);
            statusStrip1.TabIndex = 1;
            statusStrip1.Text = "statusStrip1";
            // 
            // toolStatusConn
            // 
            toolStatusConn.Name = "toolStatusConn";
            toolStatusConn.Size = new Size(119, 25);
            toolStatusConn.Text = "Disconnected";
            // 
            // toolStatusLast
            // 
            toolStatusLast.Name = "toolStatusLast";
            toolStatusLast.Size = new Size(70, 25);
            toolStatusLast.Text = "Last: —";
            // 
            // toolStatusError
            // 
            toolStatusError.Name = "toolStatusError";
            toolStatusError.Size = new Size(77, 25);
            toolStatusError.Text = "Error: —";
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 35);
            splitContainer1.Margin = new Padding(4, 5, 4, 5);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(grpActions);
            splitContainer1.Panel1.Controls.Add(grpFlow);
            splitContainer1.Panel1.Controls.Add(grpPressure);
            splitContainer1.Panel1.Controls.Add(grpConnection);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(txtLog);
            splitContainer1.Panel2.Controls.Add(txtPreview);
            splitContainer1.Panel2.Controls.Add(lblPreview);
            splitContainer1.Size = new Size(1068, 983);
            splitContainer1.SplitterDistance = 861;
            splitContainer1.SplitterWidth = 6;
            splitContainer1.TabIndex = 2;
            // 
            // grpActions
            // 
            grpActions.Controls.Add(btnStart);
            grpActions.Controls.Add(btnStop);
            grpActions.Controls.Add(btnClean);
            grpActions.Location = new Point(14, 817);
            grpActions.Margin = new Padding(4, 5, 4, 5);
            grpActions.Name = "grpActions";
            grpActions.Padding = new Padding(4, 5, 4, 5);
            grpActions.Size = new Size(486, 217);
            grpActions.TabIndex = 3;
            grpActions.TabStop = false;
            grpActions.Text = "Actions";
            // 
            // btnStart
            // 
            btnStart.Location = new Point(17, 50);
            btnStart.Margin = new Padding(4, 5, 4, 5);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(143, 67);
            btnStart.TabIndex = 0;
            btnStart.Text = "Start";
            btnStart.UseVisualStyleBackColor = true;
            btnStart.Click += btnStart_Click;
            // 
            // btnStop
            // 
            btnStop.Location = new Point(171, 50);
            btnStop.Margin = new Padding(4, 5, 4, 5);
            btnStop.Name = "btnStop";
            btnStop.Size = new Size(143, 67);
            btnStop.TabIndex = 1;
            btnStop.Text = "Stop";
            btnStop.UseVisualStyleBackColor = true;
            btnStop.Click += btnStop_Click;
            // 
            // btnClean
            // 
            btnClean.Location = new Point(326, 50);
            btnClean.Margin = new Padding(4, 5, 4, 5);
            btnClean.Name = "btnClean";
            btnClean.Size = new Size(143, 67);
            btnClean.TabIndex = 2;
            btnClean.Text = "Clean";
            btnClean.UseVisualStyleBackColor = true;
            btnClean.Click += btnClean_Click;
            // 
            // grpFlow
            // 
            grpFlow.Controls.Add(lblFlow);
            grpFlow.Controls.Add(nudFlow);
            grpFlow.Controls.Add(btnSendFlow);
            grpFlow.Location = new Point(14, 600);
            grpFlow.Margin = new Padding(4, 5, 4, 5);
            grpFlow.Name = "grpFlow";
            grpFlow.Padding = new Padding(4, 5, 4, 5);
            grpFlow.Size = new Size(486, 200);
            grpFlow.TabIndex = 2;
            grpFlow.TabStop = false;
            grpFlow.Text = "Flow Rate";
            // 
            // lblFlow
            // 
            lblFlow.AutoSize = true;
            lblFlow.Location = new Point(17, 53);
            lblFlow.Margin = new Padding(4, 0, 4, 0);
            lblFlow.Name = "lblFlow";
            lblFlow.Size = new Size(79, 25);
            lblFlow.TabIndex = 0;
            lblFlow.Text = "Flowrate";
            // 
            // nudFlow
            // 
            nudFlow.Location = new Point(157, 47);
            nudFlow.Margin = new Padding(4, 5, 4, 5);
            nudFlow.Name = "nudFlow";
            nudFlow.Size = new Size(300, 31);
            nudFlow.TabIndex = 1;
            // 
            // btnSendFlow
            // 
            btnSendFlow.Location = new Point(157, 100);
            btnSendFlow.Margin = new Padding(4, 5, 4, 5);
            btnSendFlow.Name = "btnSendFlow";
            btnSendFlow.Size = new Size(300, 47);
            btnSendFlow.TabIndex = 2;
            btnSendFlow.Text = "Send Flow";
            btnSendFlow.UseVisualStyleBackColor = true;
            btnSendFlow.Click += btnSendFlow_Click;
            // 
            // grpPressure
            // 
            grpPressure.Controls.Add(lblMaxPsi);
            grpPressure.Controls.Add(nudMaxPsi);
            grpPressure.Controls.Add(btnSendMax);
            grpPressure.Controls.Add(lblMinPsi);
            grpPressure.Controls.Add(nudMinPsi);
            grpPressure.Controls.Add(btnSendMin);
            grpPressure.Location = new Point(14, 317);
            grpPressure.Margin = new Padding(4, 5, 4, 5);
            grpPressure.Name = "grpPressure";
            grpPressure.Padding = new Padding(4, 5, 4, 5);
            grpPressure.Size = new Size(486, 267);
            grpPressure.TabIndex = 1;
            grpPressure.TabStop = false;
            grpPressure.Text = "Pressure Limits (PSI)";
            // 
            // lblMaxPsi
            // 
            lblMaxPsi.AutoSize = true;
            lblMaxPsi.Location = new Point(17, 50);
            lblMaxPsi.Margin = new Padding(4, 0, 4, 0);
            lblMaxPsi.Name = "lblMaxPsi";
            lblMaxPsi.Size = new Size(75, 25);
            lblMaxPsi.TabIndex = 0;
            lblMaxPsi.Text = "Max PSI";
            // 
            // nudMaxPsi
            // 
            nudMaxPsi.Location = new Point(157, 43);
            nudMaxPsi.Margin = new Padding(4, 5, 4, 5);
            nudMaxPsi.Name = "nudMaxPsi";
            nudMaxPsi.Size = new Size(300, 31);
            nudMaxPsi.TabIndex = 1;
            // 
            // btnSendMax
            // 
            btnSendMax.Location = new Point(157, 92);
            btnSendMax.Margin = new Padding(4, 5, 4, 5);
            btnSendMax.Name = "btnSendMax";
            btnSendMax.Size = new Size(300, 47);
            btnSendMax.TabIndex = 2;
            btnSendMax.Text = "Send Max";
            btnSendMax.UseVisualStyleBackColor = true;
            btnSendMax.Click += btnSendMax_Click;
            // 
            // lblMinPsi
            // 
            lblMinPsi.AutoSize = true;
            lblMinPsi.Location = new Point(17, 158);
            lblMinPsi.Margin = new Padding(4, 0, 4, 0);
            lblMinPsi.Name = "lblMinPsi";
            lblMinPsi.Size = new Size(72, 25);
            lblMinPsi.TabIndex = 3;
            lblMinPsi.Text = "Min PSI";
            // 
            // nudMinPsi
            // 
            nudMinPsi.Location = new Point(157, 152);
            nudMinPsi.Margin = new Padding(4, 5, 4, 5);
            nudMinPsi.Name = "nudMinPsi";
            nudMinPsi.Size = new Size(300, 31);
            nudMinPsi.TabIndex = 4;
            // 
            // btnSendMin
            // 
            btnSendMin.Location = new Point(157, 200);
            btnSendMin.Margin = new Padding(4, 5, 4, 5);
            btnSendMin.Name = "btnSendMin";
            btnSendMin.Size = new Size(300, 47);
            btnSendMin.TabIndex = 5;
            btnSendMin.Text = "Send Min";
            btnSendMin.UseVisualStyleBackColor = true;
            btnSendMin.Click += btnSendMin_Click;
            // 
            // grpConnection
            // 
            grpConnection.Controls.Add(lblPort);
            grpConnection.Controls.Add(cmbPort);
            grpConnection.Controls.Add(lblBaud);
            grpConnection.Controls.Add(cmbBaud);
            grpConnection.Controls.Add(lblInterval);
            grpConnection.Controls.Add(nudIntervalMs);
            grpConnection.Controls.Add(btnRefresh);
            grpConnection.Controls.Add(btnConnect);
            grpConnection.Controls.Add(btnDisconnect);
            grpConnection.Location = new Point(14, 16);
            grpConnection.Margin = new Padding(4, 5, 4, 5);
            grpConnection.Name = "grpConnection";
            grpConnection.Padding = new Padding(4, 5, 4, 5);
            grpConnection.Size = new Size(486, 283);
            grpConnection.TabIndex = 0;
            grpConnection.TabStop = false;
            grpConnection.Text = "Connection";
            // 
            // lblPort
            // 
            lblPort.AutoSize = true;
            lblPort.Location = new Point(17, 47);
            lblPort.Margin = new Padding(4, 0, 4, 0);
            lblPort.Name = "lblPort";
            lblPort.Size = new Size(90, 25);
            lblPort.TabIndex = 0;
            lblPort.Text = "COM Port";
            // 
            // cmbPort
            // 
            cmbPort.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPort.Location = new Point(157, 40);
            cmbPort.Margin = new Padding(4, 5, 4, 5);
            cmbPort.Name = "cmbPort";
            cmbPort.Size = new Size(298, 33);
            cmbPort.TabIndex = 1;
            // 
            // lblBaud
            // 
            lblBaud.AutoSize = true;
            lblBaud.Location = new Point(17, 100);
            lblBaud.Margin = new Padding(4, 0, 4, 0);
            lblBaud.Name = "lblBaud";
            lblBaud.Size = new Size(92, 25);
            lblBaud.TabIndex = 2;
            lblBaud.Text = "Baud Rate";
            // 
            // cmbBaud
            // 
            cmbBaud.Location = new Point(157, 93);
            cmbBaud.Margin = new Padding(4, 5, 4, 5);
            cmbBaud.Name = "cmbBaud";
            cmbBaud.Size = new Size(298, 33);
            cmbBaud.TabIndex = 3;
            // 
            // lblInterval
            // 
            lblInterval.AutoSize = true;
            lblInterval.Location = new Point(17, 153);
            lblInterval.Margin = new Padding(4, 0, 4, 0);
            lblInterval.Name = "lblInterval";
            lblInterval.Size = new Size(109, 25);
            lblInterval.TabIndex = 4;
            lblInterval.Text = "Interval (ms)";
            // 
            // nudIntervalMs
            // 
            nudIntervalMs.Location = new Point(157, 147);
            nudIntervalMs.Margin = new Padding(4, 5, 4, 5);
            nudIntervalMs.Name = "nudIntervalMs";
            nudIntervalMs.Size = new Size(300, 31);
            nudIntervalMs.TabIndex = 5;
            // 
            // btnRefresh
            // 
            btnRefresh.Location = new Point(17, 208);
            btnRefresh.Margin = new Padding(4, 5, 4, 5);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(136, 50);
            btnRefresh.TabIndex = 6;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // btnConnect
            // 
            btnConnect.Location = new Point(164, 208);
            btnConnect.Margin = new Padding(4, 5, 4, 5);
            btnConnect.Name = "btnConnect";
            btnConnect.Size = new Size(136, 50);
            btnConnect.TabIndex = 7;
            btnConnect.Text = "Connect";
            btnConnect.UseVisualStyleBackColor = true;
            btnConnect.Click += btnConnect_Click;
            // 
            // btnDisconnect
            // 
            btnDisconnect.Location = new Point(321, 208);
            btnDisconnect.Margin = new Padding(4, 5, 4, 5);
            btnDisconnect.Name = "btnDisconnect";
            btnDisconnect.Size = new Size(136, 50);
            btnDisconnect.TabIndex = 8;
            btnDisconnect.Text = "Disconnect";
            btnDisconnect.UseVisualStyleBackColor = true;
            btnDisconnect.Click += btnDisconnect_Click;
            // 
            // txtLog
            // 
            txtLog.Location = new Point(14, 108);
            txtLog.Margin = new Padding(4, 5, 4, 5);
            txtLog.Multiline = true;
            txtLog.Name = "txtLog";
            txtLog.ReadOnly = true;
            txtLog.ScrollBars = ScrollBars.Vertical;
            txtLog.Size = new Size(245, 922);
            txtLog.TabIndex = 1;
            // 
            // txtPreview
            // 
            txtPreview.Location = new Point(14, 50);
            txtPreview.Margin = new Padding(4, 5, 4, 5);
            txtPreview.Name = "txtPreview";
            txtPreview.ReadOnly = true;
            txtPreview.Size = new Size(927, 31);
            txtPreview.TabIndex = 0;
            // 
            // lblPreview
            // 
            lblPreview.AutoSize = true;
            lblPreview.Location = new Point(14, 17);
            lblPreview.Margin = new Padding(4, 0, 4, 0);
            lblPreview.Name = "lblPreview";
            lblPreview.Size = new Size(212, 25);
            lblPreview.TabIndex = 2;
            lblPreview.Text = "TX Preview (10 bytes hex)";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1068, 1050);
            Controls.Add(splitContainer1);
            Controls.Add(statusStrip1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Margin = new Padding(4, 5, 4, 5);
            Name = "Form1";
            Text = "Pump Controller";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            grpActions.ResumeLayout(false);
            grpFlow.ResumeLayout(false);
            grpFlow.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudFlow).EndInit();
            grpPressure.ResumeLayout(false);
            grpPressure.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudMaxPsi).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudMinPsi).EndInit();
            grpConnection.ResumeLayout(false);
            grpConnection.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudIntervalMs).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
    }
}