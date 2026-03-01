using System;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Microsoft.Win32;
using System.Collections.Generic;

namespace PumpControllerApp
{
    public partial class MainForm2 : Form
    {
        private SerialPort? _port;

        public MainForm2()
        {
            InitializeComponent();
            InitUi();
            WireEvents();
            RefreshPorts();
            UpdateConnectionUi(false);
        }

        private void InitUi()
        {
            toolConn.Text = "Disconnected";
            toolLast.Text = "Last: -";
            toolErr.Text = "Error: -";
            toolLed.Text = "●";
            toolLed.ForeColor = Color.Red;

            txtTxPreview.ReadOnly = true;
            txtTxPreview.Font = new Font("Consolas", 10f);
            txtTxPreview.Multiline = true;
            txtTxPreview.ScrollBars = ScrollBars.Horizontal;

            gridLog.ReadOnly = true;
            gridLog.AllowUserToAddRows = false;
            gridLog.AllowUserToDeleteRows = false;
            gridLog.RowHeadersVisible = false;
            gridLog.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gridLog.MultiSelect = false;
            gridLog.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            nudMaxPsi.Minimum = 0; nudMaxPsi.Maximum = 50000; nudMaxPsi.Value = 1000;
            nudMinPsi.Minimum = 0; nudMinPsi.Maximum = 50000; nudMinPsi.Value = 0;

            nudFlow.Minimum = 0; nudFlow.Maximum = 50000;
            nudFlow.DecimalPlaces = 3; nudFlow.Value = 1.500m;

            nudBaud.Minimum = 1200;
            nudBaud.Maximum = 2000000;
            nudBaud.Value = 9600;

            chkSimulate.Checked = false; // test without device
        }

        private void WireEvents()
        {
            // Menu
            miExit.Click += (_, __) => Close();
            miAbout.Click += (_, __) => MessageBox.Show(
                "PumpControllerApp\n" +
                "Pump Serial Controller\n\n" +
                "Developed by: Nandan Radadiya\n" +
                "Email: nradadiya@perminc.com\n" +
                "Simulation: logs TX only\n" +
                "Connected: sends TX over COM and logs RX",
                "About", MessageBoxButtons.OK, MessageBoxIcon.Information);

            miStart.Click += (_, __) => DoStart();
            miStop.Click += (_, __) => DoStop();
            miClean.Click += (_, __) => DoClean();

            miExport.Click += (_, __) => ExportCsv();
            miClearLog.Click += (_, __) => ClearLog();

            // Connection bar
            btnRefreshPorts.Click += (_, __) => RefreshPorts();
            btnConnect.Click += (_, __) => ConnectSelected();
            btnDisconnect.Click += (_, __) => Disconnect();

            chkSimulate.CheckedChanged += (_, __) =>
                AddInfo(chkSimulate.Checked ? "Simulation ON (no serial TX/RX)." : "Simulation OFF (serial TX/RX enabled).");

            // Buttons
            btnSendMax.Click += (_, __) => DoSendMax();
            btnSendMin.Click += (_, __) => DoSendMin();
            btnSendFlow.Click += (_, __) => DoSendFlow();

            btnStart.Click += (_, __) => DoStart();
            btnStop.Click += (_, __) => DoStop();
            btnClean.Click += (_, __) => DoClean();

            btnExport.Click += (_, __) => ExportCsv();
            btnClear.Click += (_, __) => ClearLog();

            txtSearch.TextChanged += (_, __) => ApplySearch();

            FormClosing += (_, __) => SafeClosePort();
        }

        // ---------------- Connection ----------------

        private void RefreshPorts()
        {
            try
            {
                var ports = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

                // 1) Standard .NET enumeration
                foreach (var p in SerialPort.GetPortNames())
                    ports.Add(p);

                // 2) Registry enumeration (helps for many virtual drivers including com0com)
                try
                {
                    using var key = Registry.LocalMachine.OpenSubKey(@"HARDWARE\DEVICEMAP\SERIALCOMM");
                    if (key != null)
                    {
                        foreach (var name in key.GetValueNames())
                        {
                            var val = key.GetValue(name)?.ToString();
                            if (!string.IsNullOrWhiteSpace(val) &&
                                val.StartsWith("COM", StringComparison.OrdinalIgnoreCase))
                                ports.Add(val.Trim());
                        }
                    }
                }
                catch { /* ignore */ }

                var sorted = ports
                    .Select(p => new { Name = p, Num = ExtractComNumber(p) })
                    .OrderBy(x => x.Num)
                    .ThenBy(x => x.Name, StringComparer.OrdinalIgnoreCase)
                    .Select(x => x.Name)
                    .ToList();

                cmbPorts.BeginUpdate();
                cmbPorts.Items.Clear();

                if (sorted.Count == 0)
                {
                    cmbPorts.Items.Add("(no ports found)");
                    cmbPorts.SelectedIndex = 0;
                    cmbPorts.Enabled = false;
                }
                else
                {
                    foreach (var p in sorted) cmbPorts.Items.Add(p);
                    cmbPorts.SelectedIndex = 0;
                    cmbPorts.Enabled = true;
                }

                cmbPorts.EndUpdate();
                AddInfo($"Ports refreshed: {sorted.Count}");
            }
            catch (Exception ex)
            {
                SetError("RefreshPorts failed: " + ex.Message);
            }
        }

        private static int ExtractComNumber(string port)
        {
            if (string.IsNullOrWhiteSpace(port)) return int.MaxValue;
            port = port.Trim();
            if (!port.StartsWith("COM", StringComparison.OrdinalIgnoreCase)) return int.MaxValue;

            if (int.TryParse(port.Substring(3), out int n)) return n;
            return int.MaxValue;
        }

        private void ConnectSelected()
        {
            if (chkSimulate.Checked)
            {
                AddInfo("Simulation is ON. Turn it OFF to connect.");
                return;
            }

            if (!cmbPorts.Enabled || cmbPorts.SelectedItem == null)
            {
                SetError("No COM port available.");
                return;
            }

            string portName = cmbPorts.SelectedItem.ToString() ?? "";
            if (portName.StartsWith("("))
            {
                SetError("Select a real COM port.");
                return;
            }

            try
            {
                Disconnect();

                _port = new SerialPort(portName, (int)nudBaud.Value, Parity.None, 8, StopBits.One)
                {
                    Handshake = Handshake.None,
                    ReadTimeout = 500,
                    WriteTimeout = 500,
                    DtrEnable = true,
                    RtsEnable = true
                };

                _port.DataReceived += Port_DataReceived;
                _port.Open();

                UpdateConnectionUi(true);
                AddInfo($"Connected to {portName} @ {(int)nudBaud.Value}");
            }
            catch (Exception ex)
            {
                SetError("Connect failed: " + ex.Message);
                SafeClosePort();
                UpdateConnectionUi(false);
            }
        }

        private void Disconnect()
        {
            SafeClosePort();
            UpdateConnectionUi(false);
            AddInfo("Disconnected.");
        }

        private void SafeClosePort()
        {
            try
            {
                if (_port != null)
                {
                    _port.DataReceived -= Port_DataReceived;
                    if (_port.IsOpen) _port.Close();
                    _port.Dispose();
                    _port = null;
                }
            }
            catch { /* ignore */ }
        }

        private void UpdateConnectionUi(bool connected)
        {
            toolConn.Text = connected ? "Connected" : "Disconnected";
            toolLed.ForeColor = connected ? Color.LimeGreen : Color.Red;

            btnConnect.Enabled = !connected;
            btnDisconnect.Enabled = connected;
        }

        private void Port_DataReceived(object? sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                if (_port == null || !_port.IsOpen) return;

                int n = _port.BytesToRead;
                if (n <= 0) return;

                byte[] buf = new byte[n];
                int read = _port.Read(buf, 0, buf.Length);
                if (read <= 0) return;

                string hex = PumpProtocol.ToHex(buf);

                BeginInvoke(new Action(() =>
                {
                    gridLog.Rows.Add(DateTime.Now.ToString("HH:mm:ss.fff"), "RX", "-", "Received", hex);
                    toolLast.Text = $"Last: RX {read} bytes";
                    ApplySearch();
                }));
            }
            catch (Exception ex)
            {
                BeginInvoke(new Action(() => SetError("RX failed: " + ex.Message)));
            }
        }

        // ---------------- Protocol actions ----------------

        private void DoSendMax()
        {
            ushort maxPsi = (ushort)nudMaxPsi.Value;
            var frame = PumpProtocol.SetMaxPressurePsi(maxPsi);
            SendFrame("0x32 MaxPSI", $"Set MAX PSI={maxPsi}", frame);
        }

        private void DoSendMin()
        {
            ushort minPsi = (ushort)nudMinPsi.Value;
            var frame = PumpProtocol.SetMinPressurePsi(minPsi);
            SendFrame("0x33 MinPSI", $"Set MIN PSI={minPsi}", frame);
        }

        private void DoSendFlow()
        {
            float flow = (float)nudFlow.Value;
            var frame = PumpProtocol.SetFlowRate(flow);
            SendFrame("0x21 Flow", $"Set FLOW={flow:0.###}", frame);
        }

        private void DoStart()
        {
            var frame = PumpProtocol.Start();
            SendFrame("0x34 Action", "START", frame);
        }

        private void DoStop()
        {
            var frame = PumpProtocol.Stop();
            SendFrame("0x34 Action", "STOP", frame);
        }

        private void DoClean()
        {
            var frame = PumpProtocol.Clean();
            SendFrame("0x34 Action", "CLEAN", frame);
        }

        private void SendFrame(string cmd, string meaning, byte[] frame)
        {
            string hex = PumpProtocol.ToHex(frame);
            txtTxPreview.Text = hex;

            // Always log TX
            gridLog.Rows.Add(DateTime.Now.ToString("HH:mm:ss.fff"), "TX", cmd, meaning, hex);
            toolLast.Text = "Last: " + meaning;
            toolErr.Text = "Error: -";
            ApplySearch();

            // Simulation: do not send serial
            if (chkSimulate.Checked) return;

            if (_port == null || !_port.IsOpen)
            {
                SetError("Not connected (TX not sent).");
                return;
            }

            try
            {
                _port.Write(frame, 0, frame.Length);
                toolLast.Text = $"Last: TX sent ({frame.Length} bytes)";
            }
            catch (Exception ex)
            {
                SetError("TX failed: " + ex.Message);
            }
        }

        // ---------------- Log / Export / Search ----------------

        private void ClearLog()
        {
            gridLog.Rows.Clear();
            toolLast.Text = "Last: Log cleared";
        }

        private void ExportCsv()
        {
            using var sfd = new SaveFileDialog
            {
                Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*",
                FileName = $"pump_log_{DateTime.Now:yyyyMMdd_HHmmss}.csv"
            };
            if (sfd.ShowDialog(this) != DialogResult.OK) return;

            var sb = new StringBuilder();
            sb.AppendLine("Time,Type,Command,Meaning,HexFrame");

            foreach (DataGridViewRow r in gridLog.Rows)
            {
                if (r.IsNewRow) continue;
                string Esc(object? v) => "\"" + (v?.ToString() ?? "").Replace("\"", "\"\"") + "\"";
                sb.Append(Esc(r.Cells[0].Value)).Append(",");
                sb.Append(Esc(r.Cells[1].Value)).Append(",");
                sb.Append(Esc(r.Cells[2].Value)).Append(",");
                sb.Append(Esc(r.Cells[3].Value)).Append(",");
                sb.Append(Esc(r.Cells[4].Value)).AppendLine();
            }

            File.WriteAllText(sfd.FileName, sb.ToString(), Encoding.UTF8);
            toolLast.Text = "Last: Exported CSV";
        }

        private void ApplySearch()
        {
            string q = (txtSearch.Text ?? "").Trim();

            foreach (DataGridViewRow row in gridLog.Rows)
            {
                if (row.IsNewRow) continue;
                if (q.Length == 0) { row.Visible = true; continue; }

                string all = "";
                for (int i = 0; i < row.Cells.Count; i++)
                    all += (row.Cells[i].Value?.ToString() ?? "") + " ";

                row.Visible = all.IndexOf(q, StringComparison.OrdinalIgnoreCase) >= 0;
            }
        }

        private void AddInfo(string msg)
        {
            gridLog.Rows.Add(DateTime.Now.ToString("HH:mm:ss.fff"), "INFO", "-", msg, "-");
            toolLast.Text = "Last: " + msg;
            toolErr.Text = "Error: -";
            ApplySearch();
        }

        private void SetError(string msg)
        {
            toolErr.Text = "Error: " + msg;
            toolLed.ForeColor = Color.OrangeRed;
            gridLog.Rows.Add(DateTime.Now.ToString("HH:mm:ss.fff"), "ERR", "-", msg, "-");
            ApplySearch();
        }

        private void chkSimulate_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}