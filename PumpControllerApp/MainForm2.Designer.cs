using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace PumpControllerApp
{
    partial class MainForm2
    {
        private IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private MenuStrip menuStrip1;
        private ToolStripMenuItem miFile;
        private ToolStripMenuItem miExit;
        private ToolStripMenuItem miCommands;
        private ToolStripMenuItem miStart;
        private ToolStripMenuItem miStop;
        private ToolStripMenuItem miClean;
        private ToolStripMenuItem miTools;
        private ToolStripMenuItem miExport;
        private ToolStripMenuItem miClearLog;
        private ToolStripMenuItem miHelp;
        private ToolStripMenuItem miAbout;

        private StatusStrip statusStrip1;
        private ToolStripStatusLabel toolConn;
        private ToolStripStatusLabel toolLast;
        private ToolStripStatusLabel toolErr;
        private ToolStripStatusLabel toolLed;

        private TableLayoutPanel root;

        private TableLayoutPanel connBar;
        private Label lblPort;
        private ComboBox cmbPorts;
        private Button btnRefreshPorts;
        private Label lblBaud;
        private NumericUpDown nudBaud;
        private Button btnConnect;
        private Button btnDisconnect;
        private CheckBox chkSimulate;

        private TableLayoutPanel topRow;
        private GroupBox grpPressure;
        private GroupBox grpFlow;
        private GroupBox grpActions;

        private TableLayoutPanel tlpPressure;
        private Label lblMax;
        private Label lblMin;
        private NumericUpDown nudMaxPsi;
        private NumericUpDown nudMinPsi;
        private Button btnSendMax;
        private Button btnSendMin;

        private TableLayoutPanel tlpFlow;
        private Label lblFlow;
        private NumericUpDown nudFlow;
        private Button btnSendFlow;

        private TableLayoutPanel tlpActions;
        private Button btnStart;
        private Button btnStop;
        private Button btnClean;

        private SplitContainer splitBottom;

        private GroupBox grpTx;
        private TextBox txtTxPreview;

        private TableLayoutPanel logPanel;
        private TableLayoutPanel logTop;
        private TextBox txtSearch;
        private Button btnExport;
        private Button btnClear;
        private DataGridView gridLog;
        private DataGridViewTextBoxColumn colTime;
        private DataGridViewTextBoxColumn colType;
        private DataGridViewTextBoxColumn colCmd;
        private DataGridViewTextBoxColumn colMeaning;
        private DataGridViewTextBoxColumn colHex;

        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            miFile = new ToolStripMenuItem();
            miExit = new ToolStripMenuItem();
            miCommands = new ToolStripMenuItem();
            miStart = new ToolStripMenuItem();
            miStop = new ToolStripMenuItem();
            miClean = new ToolStripMenuItem();
            miTools = new ToolStripMenuItem();
            miExport = new ToolStripMenuItem();
            miClearLog = new ToolStripMenuItem();
            miHelp = new ToolStripMenuItem();
            miAbout = new ToolStripMenuItem();
            statusStrip1 = new StatusStrip();
            toolConn = new ToolStripStatusLabel();
            toolLast = new ToolStripStatusLabel();
            toolErr = new ToolStripStatusLabel();
            toolLed = new ToolStripStatusLabel();
            root = new TableLayoutPanel();
            connBar = new TableLayoutPanel();
            lblPort = new Label();
            cmbPorts = new ComboBox();
            btnRefreshPorts = new Button();
            lblBaud = new Label();
            nudBaud = new NumericUpDown();
            btnConnect = new Button();
            btnDisconnect = new Button();
            chkSimulate = new CheckBox();
            topRow = new TableLayoutPanel();
            grpPressure = new GroupBox();
            tlpPressure = new TableLayoutPanel();
            lblMax = new Label();
            nudMaxPsi = new NumericUpDown();
            btnSendMax = new Button();
            lblMin = new Label();
            nudMinPsi = new NumericUpDown();
            btnSendMin = new Button();
            grpFlow = new GroupBox();
            tlpFlow = new TableLayoutPanel();
            lblFlow = new Label();
            nudFlow = new NumericUpDown();
            btnSendFlow = new Button();
            grpActions = new GroupBox();
            tlpActions = new TableLayoutPanel();
            btnStart = new Button();
            btnStop = new Button();
            btnClean = new Button();
            splitBottom = new SplitContainer();
            grpTx = new GroupBox();
            picLogo = new PictureBox();
            txtTxPreview = new TextBox();
            logPanel = new TableLayoutPanel();
            logTop = new TableLayoutPanel();
            txtSearch = new TextBox();
            btnExport = new Button();
            btnClear = new Button();
            gridLog = new DataGridView();
            colTime = new DataGridViewTextBoxColumn();
            colType = new DataGridViewTextBoxColumn();
            colCmd = new DataGridViewTextBoxColumn();
            colMeaning = new DataGridViewTextBoxColumn();
            colHex = new DataGridViewTextBoxColumn();
            menuStrip1.SuspendLayout();
            statusStrip1.SuspendLayout();
            root.SuspendLayout();
            connBar.SuspendLayout();
            ((ISupportInitialize)nudBaud).BeginInit();
            topRow.SuspendLayout();
            grpPressure.SuspendLayout();
            tlpPressure.SuspendLayout();
            ((ISupportInitialize)nudMaxPsi).BeginInit();
            ((ISupportInitialize)nudMinPsi).BeginInit();
            grpFlow.SuspendLayout();
            tlpFlow.SuspendLayout();
            ((ISupportInitialize)nudFlow).BeginInit();
            grpActions.SuspendLayout();
            tlpActions.SuspendLayout();
            ((ISupportInitialize)splitBottom).BeginInit();
            splitBottom.Panel1.SuspendLayout();
            splitBottom.Panel2.SuspendLayout();
            splitBottom.SuspendLayout();
            grpTx.SuspendLayout();
            ((ISupportInitialize)picLogo).BeginInit();
            logPanel.SuspendLayout();
            logTop.SuspendLayout();
            ((ISupportInitialize)gridLog).BeginInit();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(24, 24);
            menuStrip1.Items.AddRange(new ToolStripItem[] { miFile, miCommands, miTools, miHelp });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(980, 33);
            menuStrip1.TabIndex = 2;
            // 
            // miFile
            // 
            miFile.DropDownItems.AddRange(new ToolStripItem[] { miExit });
            miFile.Name = "miFile";
            miFile.Size = new Size(54, 29);
            miFile.Text = "File";
            // 
            // miExit
            // 
            miExit.Name = "miExit";
            miExit.Size = new Size(141, 34);
            miExit.Text = "Exit";
            // 
            // miCommands
            // 
            miCommands.DropDownItems.AddRange(new ToolStripItem[] { miStart, miStop, miClean });
            miCommands.Name = "miCommands";
            miCommands.Size = new Size(120, 29);
            miCommands.Text = "Commands";
            // 
            // miStart
            // 
            miStart.Name = "miStart";
            miStart.Size = new Size(157, 34);
            miStart.Text = "Start";
            // 
            // miStop
            // 
            miStop.Name = "miStop";
            miStop.Size = new Size(157, 34);
            miStop.Text = "Stop";
            // 
            // miClean
            // 
            miClean.Name = "miClean";
            miClean.Size = new Size(157, 34);
            miClean.Text = "Clean";
            // 
            // miTools
            // 
            miTools.DropDownItems.AddRange(new ToolStripItem[] { miExport, miClearLog });
            miTools.Name = "miTools";
            miTools.Size = new Size(69, 29);
            miTools.Text = "Tools";
            // 
            // miExport
            // 
            miExport.Name = "miExport";
            miExport.Size = new Size(202, 34);
            miExport.Text = "Export CSV";
            // 
            // miClearLog
            // 
            miClearLog.Name = "miClearLog";
            miClearLog.Size = new Size(202, 34);
            miClearLog.Text = "Clear Log";
            // 
            // miHelp
            // 
            miHelp.DropDownItems.AddRange(new ToolStripItem[] { miAbout });
            miHelp.Name = "miHelp";
            miHelp.Size = new Size(65, 29);
            miHelp.Text = "Help";
            // 
            // miAbout
            // 
            miAbout.Name = "miAbout";
            miAbout.Size = new Size(164, 34);
            miAbout.Text = "About";
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new Size(24, 24);
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolConn, toolLast, toolErr, toolLed });
            statusStrip1.Location = new Point(0, 598);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(980, 32);
            statusStrip1.TabIndex = 1;
            // 
            // toolConn
            // 
            toolConn.Name = "toolConn";
            toolConn.Size = new Size(119, 25);
            toolConn.Text = "Disconnected";
            // 
            // toolLast
            // 
            toolLast.Name = "toolLast";
            toolLast.Size = new Size(59, 25);
            toolLast.Text = "Last: -";
            // 
            // toolErr
            // 
            toolErr.Name = "toolErr";
            toolErr.Size = new Size(66, 25);
            toolErr.Text = "Error: -";
            // 
            // toolLed
            // 
            toolLed.Name = "toolLed";
            toolLed.Size = new Size(23, 25);
            toolLed.Text = "●";
            // 
            // root
            // 
            root.ColumnCount = 1;
            root.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            root.Controls.Add(connBar, 0, 0);
            root.Controls.Add(topRow, 0, 1);
            root.Controls.Add(splitBottom, 0, 2);
            root.Dock = DockStyle.Fill;
            root.Location = new Point(0, 33);
            root.Name = "root";
            root.RowCount = 3;
            root.RowStyles.Add(new RowStyle(SizeType.Absolute, 48F));
            root.RowStyles.Add(new RowStyle(SizeType.Absolute, 250F));
            root.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            root.Size = new Size(980, 565);
            root.TabIndex = 0;
            // 
            // connBar
            // 
            connBar.ColumnCount = 8;
            connBar.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 55F));
            connBar.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 140F));
            connBar.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100F));
            connBar.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 70F));
            connBar.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120F));
            connBar.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100F));
            connBar.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 115F));
            connBar.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            connBar.Controls.Add(lblPort, 0, 0);
            connBar.Controls.Add(cmbPorts, 1, 0);
            connBar.Controls.Add(btnRefreshPorts, 2, 0);
            connBar.Controls.Add(lblBaud, 3, 0);
            connBar.Controls.Add(nudBaud, 4, 0);
            connBar.Controls.Add(btnConnect, 5, 0);
            connBar.Controls.Add(btnDisconnect, 6, 0);
            connBar.Controls.Add(chkSimulate, 7, 0);
            connBar.Dock = DockStyle.Fill;
            connBar.Location = new Point(3, 3);
            connBar.Name = "connBar";
            connBar.RowCount = 1;
            connBar.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            connBar.Size = new Size(974, 42);
            connBar.TabIndex = 0;
            // 
            // lblPort
            // 
            lblPort.Dock = DockStyle.Fill;
            lblPort.Location = new Point(3, 0);
            lblPort.Name = "lblPort";
            lblPort.Size = new Size(49, 42);
            lblPort.TabIndex = 0;
            lblPort.Text = "Port:";
            lblPort.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // cmbPorts
            // 
            cmbPorts.Dock = DockStyle.Fill;
            cmbPorts.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPorts.Location = new Point(58, 3);
            cmbPorts.Name = "cmbPorts";
            cmbPorts.Size = new Size(134, 33);
            cmbPorts.TabIndex = 1;
            // 
            // btnRefreshPorts
            // 
            btnRefreshPorts.Dock = DockStyle.Fill;
            btnRefreshPorts.Location = new Point(198, 3);
            btnRefreshPorts.Name = "btnRefreshPorts";
            btnRefreshPorts.Size = new Size(94, 36);
            btnRefreshPorts.TabIndex = 2;
            btnRefreshPorts.Text = "Refresh";
            // 
            // lblBaud
            // 
            lblBaud.Dock = DockStyle.Fill;
            lblBaud.Location = new Point(298, 0);
            lblBaud.Name = "lblBaud";
            lblBaud.Size = new Size(64, 42);
            lblBaud.TabIndex = 3;
            lblBaud.Text = "Baud:";
            lblBaud.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // nudBaud
            // 
            nudBaud.Dock = DockStyle.Fill;
            nudBaud.Location = new Point(368, 3);
            nudBaud.Name = "nudBaud";
            nudBaud.Size = new Size(114, 31);
            nudBaud.TabIndex = 4;
            // 
            // btnConnect
            // 
            btnConnect.Dock = DockStyle.Fill;
            btnConnect.Location = new Point(488, 3);
            btnConnect.Name = "btnConnect";
            btnConnect.Size = new Size(94, 36);
            btnConnect.TabIndex = 5;
            btnConnect.Text = "Connect";
            // 
            // btnDisconnect
            // 
            btnDisconnect.Dock = DockStyle.Fill;
            btnDisconnect.Location = new Point(588, 3);
            btnDisconnect.Name = "btnDisconnect";
            btnDisconnect.Size = new Size(109, 36);
            btnDisconnect.TabIndex = 6;
            btnDisconnect.Text = "Disconnect";
            // 
            // chkSimulate
            // 
            chkSimulate.Dock = DockStyle.Fill;
            chkSimulate.Location = new Point(703, 3);
            chkSimulate.Name = "chkSimulate";
            chkSimulate.Size = new Size(268, 36);
            chkSimulate.TabIndex = 7;
            chkSimulate.Text = "Simulate (no serial)";
            chkSimulate.CheckedChanged += chkSimulate_CheckedChanged;
            // 
            // topRow
            // 
            topRow.ColumnCount = 3;
            topRow.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 45F));
            topRow.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            topRow.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            topRow.Controls.Add(grpPressure, 0, 0);
            topRow.Controls.Add(grpFlow, 1, 0);
            topRow.Controls.Add(grpActions, 2, 0);
            topRow.Dock = DockStyle.Fill;
            topRow.Location = new Point(3, 51);
            topRow.Name = "topRow";
            topRow.RowCount = 1;
            topRow.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            topRow.Size = new Size(974, 244);
            topRow.TabIndex = 1;
            // 
            // grpPressure
            // 
            grpPressure.Controls.Add(tlpPressure);
            grpPressure.Dock = DockStyle.Fill;
            grpPressure.Location = new Point(3, 3);
            grpPressure.Name = "grpPressure";
            grpPressure.Size = new Size(432, 238);
            grpPressure.TabIndex = 0;
            grpPressure.TabStop = false;
            grpPressure.Text = "Pressure";
            // 
            // tlpPressure
            // 
            tlpPressure.ColumnCount = 3;
            tlpPressure.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35F));
            tlpPressure.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 45F));
            tlpPressure.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tlpPressure.Controls.Add(lblMax, 0, 0);
            tlpPressure.Controls.Add(nudMaxPsi, 1, 0);
            tlpPressure.Controls.Add(btnSendMax, 2, 0);
            tlpPressure.Controls.Add(lblMin, 0, 1);
            tlpPressure.Controls.Add(nudMinPsi, 1, 1);
            tlpPressure.Controls.Add(btnSendMin, 2, 1);
            tlpPressure.Dock = DockStyle.Fill;
            tlpPressure.Location = new Point(3, 27);
            tlpPressure.Name = "tlpPressure";
            tlpPressure.Padding = new Padding(8);
            tlpPressure.RowCount = 2;
            tlpPressure.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tlpPressure.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tlpPressure.Size = new Size(426, 208);
            tlpPressure.TabIndex = 0;
            // 
            // lblMax
            // 
            lblMax.Dock = DockStyle.Fill;
            lblMax.Location = new Point(11, 8);
            lblMax.Name = "lblMax";
            lblMax.Size = new Size(137, 96);
            lblMax.TabIndex = 0;
            lblMax.Text = "Max PSI";
            lblMax.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // nudMaxPsi
            // 
            nudMaxPsi.Anchor = AnchorStyles.Left;
            nudMaxPsi.Location = new Point(154, 40);
            nudMaxPsi.Name = "nudMaxPsi";
            nudMaxPsi.Size = new Size(178, 31);
            nudMaxPsi.TabIndex = 1;
            // 
            // btnSendMax
            // 
            btnSendMax.Anchor = AnchorStyles.None;
            btnSendMax.AutoSize = true;
            btnSendMax.Location = new Point(338, 38);
            btnSendMax.Name = "btnSendMax";
            btnSendMax.Size = new Size(77, 35);
            btnSendMax.TabIndex = 2;
            btnSendMax.Text = "Send";
            // 
            // lblMin
            // 
            lblMin.Dock = DockStyle.Fill;
            lblMin.Location = new Point(11, 104);
            lblMin.Name = "lblMin";
            lblMin.Size = new Size(137, 96);
            lblMin.TabIndex = 3;
            lblMin.Text = "Min PSI";
            lblMin.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // nudMinPsi
            // 
            nudMinPsi.Anchor = AnchorStyles.Left;
            nudMinPsi.Location = new Point(154, 136);
            nudMinPsi.Name = "nudMinPsi";
            nudMinPsi.Size = new Size(178, 31);
            nudMinPsi.TabIndex = 4;
            // 
            // btnSendMin
            // 
            btnSendMin.Anchor = AnchorStyles.None;
            btnSendMin.AutoSize = true;
            btnSendMin.Location = new Point(338, 134);
            btnSendMin.Name = "btnSendMin";
            btnSendMin.Size = new Size(77, 35);
            btnSendMin.TabIndex = 5;
            btnSendMin.Text = "Send";
            // 
            // grpFlow
            // 
            grpFlow.Controls.Add(tlpFlow);
            grpFlow.Dock = DockStyle.Fill;
            grpFlow.Location = new Point(441, 3);
            grpFlow.Name = "grpFlow";
            grpFlow.Size = new Size(237, 238);
            grpFlow.TabIndex = 1;
            grpFlow.TabStop = false;
            grpFlow.Text = "Flow Rate";
            // 
            // tlpFlow
            // 
            tlpFlow.ColumnCount = 2;
            tlpFlow.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 45F));
            tlpFlow.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 55F));
            tlpFlow.Controls.Add(lblFlow, 0, 0);
            tlpFlow.Controls.Add(nudFlow, 1, 0);
            tlpFlow.Controls.Add(btnSendFlow, 1, 1);
            tlpFlow.Dock = DockStyle.Fill;
            tlpFlow.Location = new Point(3, 27);
            tlpFlow.Name = "tlpFlow";
            tlpFlow.Padding = new Padding(8);
            tlpFlow.RowCount = 2;
            tlpFlow.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tlpFlow.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpFlow.Size = new Size(231, 208);
            tlpFlow.TabIndex = 0;
            // 
            // lblFlow
            // 
            lblFlow.Dock = DockStyle.Fill;
            lblFlow.Location = new Point(11, 8);
            lblFlow.Name = "lblFlow";
            lblFlow.Size = new Size(90, 40);
            lblFlow.TabIndex = 0;
            lblFlow.Text = "Flow";
            lblFlow.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // nudFlow
            // 
            nudFlow.Dock = DockStyle.Fill;
            nudFlow.Location = new Point(107, 11);
            nudFlow.Name = "nudFlow";
            nudFlow.Size = new Size(113, 31);
            nudFlow.TabIndex = 1;
            // 
            // btnSendFlow
            // 
            btnSendFlow.Dock = DockStyle.Top;
            btnSendFlow.Location = new Point(107, 51);
            btnSendFlow.Name = "btnSendFlow";
            btnSendFlow.Size = new Size(113, 36);
            btnSendFlow.TabIndex = 2;
            btnSendFlow.Text = "Send";
            // 
            // grpActions
            // 
            grpActions.Controls.Add(tlpActions);
            grpActions.Dock = DockStyle.Fill;
            grpActions.Location = new Point(684, 3);
            grpActions.Name = "grpActions";
            grpActions.Size = new Size(287, 238);
            grpActions.TabIndex = 2;
            grpActions.TabStop = false;
            grpActions.Text = "Actions";
            // 
            // tlpActions
            // 
            tlpActions.ColumnCount = 3;
            tlpActions.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33F));
            tlpActions.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33F));
            tlpActions.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 34F));
            tlpActions.Controls.Add(btnStart, 0, 0);
            tlpActions.Controls.Add(btnStop, 1, 0);
            tlpActions.Controls.Add(btnClean, 2, 0);
            tlpActions.Dock = DockStyle.Fill;
            tlpActions.Location = new Point(3, 27);
            tlpActions.Name = "tlpActions";
            tlpActions.Padding = new Padding(8);
            tlpActions.RowCount = 1;
            tlpActions.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tlpActions.Size = new Size(281, 208);
            tlpActions.TabIndex = 0;
            // 
            // btnStart
            // 
            btnStart.Dock = DockStyle.Fill;
            btnStart.Location = new Point(11, 11);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(81, 186);
            btnStart.TabIndex = 0;
            btnStart.Text = "Start";
            // 
            // btnStop
            // 
            btnStop.Dock = DockStyle.Fill;
            btnStop.Location = new Point(98, 11);
            btnStop.Name = "btnStop";
            btnStop.Size = new Size(81, 186);
            btnStop.TabIndex = 1;
            btnStop.Text = "Stop";
            // 
            // btnClean
            // 
            btnClean.Dock = DockStyle.Fill;
            btnClean.Location = new Point(185, 11);
            btnClean.Name = "btnClean";
            btnClean.Size = new Size(85, 186);
            btnClean.TabIndex = 2;
            btnClean.Text = "Clean";
            // 
            // splitBottom
            // 
            splitBottom.Dock = DockStyle.Fill;
            splitBottom.Location = new Point(3, 301);
            splitBottom.Name = "splitBottom";
            // 
            // splitBottom.Panel1
            // 
            splitBottom.Panel1.Controls.Add(grpTx);
            // 
            // splitBottom.Panel2
            // 
            splitBottom.Panel2.Controls.Add(logPanel);
            splitBottom.Size = new Size(974, 261);
            splitBottom.SplitterDistance = 460;
            splitBottom.TabIndex = 2;
            // 
            // grpTx
            // 
            grpTx.Controls.Add(picLogo);
            grpTx.Controls.Add(txtTxPreview);
            grpTx.Dock = DockStyle.Fill;
            grpTx.Location = new Point(0, 0);
            grpTx.Name = "grpTx";
            grpTx.Size = new Size(460, 261);
            grpTx.TabIndex = 0;
            grpTx.TabStop = false;
            grpTx.Text = "TX Preview";
            // 
            // picLogo
            // 
            picLogo.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            picLogo.Image = Properties.Resources.Logo;
            picLogo.Location = new Point(0, 189);
            picLogo.Name = "picLogo";
            picLogo.Size = new Size(207, 75);
            picLogo.SizeMode = PictureBoxSizeMode.StretchImage;
            picLogo.TabIndex = 1;
            picLogo.TabStop = false;
            // 
            // txtTxPreview
            // 
            txtTxPreview.Dock = DockStyle.Fill;
            txtTxPreview.Location = new Point(3, 27);
            txtTxPreview.Name = "txtTxPreview";
            txtTxPreview.Size = new Size(454, 31);
            txtTxPreview.TabIndex = 0;
            // 
            // logPanel
            // 
            logPanel.ColumnCount = 1;
            logPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            logPanel.Controls.Add(logTop, 0, 0);
            logPanel.Controls.Add(gridLog, 0, 1);
            logPanel.Dock = DockStyle.Fill;
            logPanel.Location = new Point(0, 0);
            logPanel.Name = "logPanel";
            logPanel.RowCount = 2;
            logPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 46F));
            logPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            logPanel.Size = new Size(510, 261);
            logPanel.TabIndex = 0;
            // 
            // logTop
            // 
            logTop.ColumnCount = 3;
            logTop.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            logTop.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 110F));
            logTop.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 90F));
            logTop.Controls.Add(txtSearch, 0, 0);
            logTop.Controls.Add(btnExport, 1, 0);
            logTop.Controls.Add(btnClear, 2, 0);
            logTop.Dock = DockStyle.Fill;
            logTop.Location = new Point(3, 3);
            logTop.Name = "logTop";
            logTop.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            logTop.Size = new Size(504, 40);
            logTop.TabIndex = 0;
            // 
            // txtSearch
            // 
            txtSearch.Dock = DockStyle.Fill;
            txtSearch.Location = new Point(3, 3);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(298, 31);
            txtSearch.TabIndex = 0;
            // 
            // btnExport
            // 
            btnExport.Dock = DockStyle.Fill;
            btnExport.Location = new Point(307, 3);
            btnExport.Name = "btnExport";
            btnExport.Size = new Size(104, 34);
            btnExport.TabIndex = 1;
            btnExport.Text = "Export";
            // 
            // btnClear
            // 
            btnClear.Dock = DockStyle.Fill;
            btnClear.Location = new Point(417, 3);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(84, 34);
            btnClear.TabIndex = 2;
            btnClear.Text = "Clear";
            // 
            // gridLog
            // 
            gridLog.ColumnHeadersHeight = 34;
            gridLog.Columns.AddRange(new DataGridViewColumn[] { colTime, colType, colCmd, colMeaning, colHex });
            gridLog.Dock = DockStyle.Fill;
            gridLog.Location = new Point(3, 49);
            gridLog.Name = "gridLog";
            gridLog.RowHeadersWidth = 62;
            gridLog.Size = new Size(504, 209);
            gridLog.TabIndex = 1;
            // 
            // colTime
            // 
            colTime.HeaderText = "Time";
            colTime.MinimumWidth = 8;
            colTime.Name = "colTime";
            colTime.Width = 150;
            // 
            // colType
            // 
            colType.HeaderText = "Type";
            colType.MinimumWidth = 8;
            colType.Name = "colType";
            colType.Width = 150;
            // 
            // colCmd
            // 
            colCmd.HeaderText = "Command";
            colCmd.MinimumWidth = 8;
            colCmd.Name = "colCmd";
            colCmd.Width = 150;
            // 
            // colMeaning
            // 
            colMeaning.HeaderText = "Meaning";
            colMeaning.MinimumWidth = 8;
            colMeaning.Name = "colMeaning";
            colMeaning.Width = 150;
            // 
            // colHex
            // 
            colHex.HeaderText = "Hex Frame";
            colHex.MinimumWidth = 8;
            colHex.Name = "colHex";
            colHex.Width = 150;
            // 
            // MainForm2
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(980, 630);
            Controls.Add(root);
            Controls.Add(statusStrip1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "MainForm2";
            Text = "Pump Controller";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            root.ResumeLayout(false);
            connBar.ResumeLayout(false);
            ((ISupportInitialize)nudBaud).EndInit();
            topRow.ResumeLayout(false);
            grpPressure.ResumeLayout(false);
            tlpPressure.ResumeLayout(false);
            tlpPressure.PerformLayout();
            ((ISupportInitialize)nudMaxPsi).EndInit();
            ((ISupportInitialize)nudMinPsi).EndInit();
            grpFlow.ResumeLayout(false);
            tlpFlow.ResumeLayout(false);
            ((ISupportInitialize)nudFlow).EndInit();
            grpActions.ResumeLayout(false);
            tlpActions.ResumeLayout(false);
            splitBottom.Panel1.ResumeLayout(false);
            splitBottom.Panel2.ResumeLayout(false);
            ((ISupportInitialize)splitBottom).EndInit();
            splitBottom.ResumeLayout(false);
            grpTx.ResumeLayout(false);
            grpTx.PerformLayout();
            ((ISupportInitialize)picLogo).EndInit();
            logPanel.ResumeLayout(false);
            logTop.ResumeLayout(false);
            logTop.PerformLayout();
            ((ISupportInitialize)gridLog).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private PictureBox picLogo;
    }
}