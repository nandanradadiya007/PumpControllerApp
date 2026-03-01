// Form1.cs  (WinForms)
// This file is designed to match the Form1.Designer.cs I provided earlier.
// Namespace must be PumpControllerApp.

using System;
using System.IO.Ports;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace PumpControllerApp
{
    public partial class Form1 : Form
    {
        private PumpClient? _pump;
        private readonly StringBuilder _log = new();

        public Form1()
        {
            InitializeComponent();
            LoadUiDefaults();
            RefreshPorts();
            ClearError();
            UpdateUiState();
        }

        // ---------------- UI defaults ----------------
        private void LoadUiDefaults()
        {
            // Baud options (editable)
            cmbBaud.Items.Clear();
            cmbBaud.Items.AddRange(new object[] { "9600", "19200", "38400", "57600", "115200" });
            cmbBaud.Text = "9600";

            // Command interval (protocol default is 100ms)
            nudIntervalMs.Minimum = 0;
            nudIntervalMs.Maximum = 5000;
            nudIntervalMs.Value = 100;

            // PSI limits
            nudMaxPsi.Minimum = 0;
            nudMaxPsi.Maximum = 20000;
            nudMaxPsi.Value = 1000;

            nudMinPsi.Minimum = 0;
            nudMinPsi.Maximum = 20000;
            nudMinPsi.Value = 0;

            // Flow rate (decimal updown -> float)
            nudFlow.DecimalPlaces = 3;
            nudFlow.Minimum = 0;
            nudFlow.Maximum = 10000;
            nudFlow.Value = 1.500m;

            // Log and preview
            txtPreview.ReadOnly = true;
            txtLog.ReadOnly = true;
        }

        // ---------------- Port scan ----------------
        private void RefreshPorts()
        {
            string[] ports = SerialPort.GetPortNames();
            Array.Sort(ports);

            cmbPort.Items.Clear();
            cmbPort.Items.AddRange(ports);

            if (ports.Length > 0)
            {
                if (cmbPort.SelectedIndex < 0) cmbPort.SelectedIndex = 0;
                LogInfo("Ports found: " + string.Join(", ", ports));
            }
            else
            {
                LogInfo("Ports found: (none)");
            }
        }

        private int GetBaud()
        {
            if (int.TryParse(cmbBaud.Text, out int baud)) return baud;
            return 9600;
        }

        private int GetIntervalMs() => (int)nudIntervalMs.Value;

        // ---------------- UI state helpers ----------------
        private void UpdateUiState()
        {
            bool connected = _pump?.IsOpen == true;

            btnConnect.Enabled = !connected;
            btnDisconnect.Enabled = connected;

            btnSendMax.Enabled = connected;
            btnSendMin.Enabled = connected;
            btnSendFlow.Enabled = connected;

            btnStart.Enabled = connected;
            btnStop.Enabled = connected;
            btnClean.Enabled = connected;

            menuConnect.Enabled = !connected;
            menuDisconnect.Enabled = connected;

            menuStart.Enabled = connected;
            menuStop.Enabled = connected;
            menuClean.Enabled = connected;

            toolStatusConn.Text = connected ? $"Connected: {cmbPort.Text}" : "Disconnected";
        }

        private void ClearError()
        {
            toolStatusError.Text = "Error: —";
        }

        private void SetError(string message)
        {
            toolStatusError.Text = "Error: " + message;
            LogError(message);
        }

        // ---------------- Logging ----------------
        private void AppendLog(string tag, string message)
        {
            string line = $"{DateTime.Now:HH:mm:ss.fff} {tag}: {message}";
            _log.AppendLine(line);
            txtLog.Text = _log.ToString();
            txtLog.SelectionStart = txtLog.TextLength;
            txtLog.ScrollToCaret();
        }

        private void LogInfo(string msg) => AppendLog("INFO", msg);
        private void LogError(string msg) => AppendLog("ERR", msg);

        private void LogTx(byte[] frame)
        {
            AppendLog("TX", PumpProtocol.ToHex(frame));
        }

        private void PreviewFrame(byte[] frame)
        {
            txtPreview.Text = PumpProtocol.ToHex(frame);
        }

        // ---------------- Central send ----------------
        private async void SendFrame(byte[] frame, string label)
        {
            try
            {
                ClearError();

                // ALWAYS show preview + log
                PreviewFrame(frame);
                LogTx(frame);
                toolStatusLast.Text = "Last: " + label;

                // SIMULATION MODE
                if (_pump == null || !_pump.IsOpen)
                {
                    LogInfo("Simulation mode: Not connected. TX not sent to hardware.");
                    return;
                }

                await _pump.SendAsync(frame, GetIntervalMs());
            }
            catch (Exception ex)
            {
                SetError(ex.Message);
            }
        }

        // ---------------- Buttons ----------------
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshPorts();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                ClearError();

                if (string.IsNullOrWhiteSpace(cmbPort.Text))
                    throw new InvalidOperationException("Select a COM port.");

                // Recreate client each time to apply baud/port changes cleanly
                _pump?.Dispose();
                _pump = new PumpClient(cmbPort.Text, GetBaud());
                _pump.Open();

                LogInfo($"Connected to {cmbPort.Text} @ {GetBaud()} baud");
            }
            catch (Exception ex)
            {
                _pump?.Dispose();
                _pump = null;
                SetError(ex.Message);
            }
            finally
            {
                UpdateUiState();
            }
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            try
            {
                ClearError();
                _pump?.Dispose();
                _pump = null;
                LogInfo("Disconnected");
            }
            catch (Exception ex)
            {
                SetError(ex.Message);
            }
            finally
            {
                UpdateUiState();
            }
        }

        private void btnSendMax_Click(object sender, EventArgs e)
        {
            ushort maxPsi = (ushort)nudMaxPsi.Value;
            ushort minPsi = (ushort)nudMinPsi.Value;

            if (minPsi > maxPsi)
            {
                SetError("Min PSI cannot be greater than Max PSI.");
                return;
            }

            SendFrame(PumpProtocol.SetMaxPressurePsi(maxPsi), $"Set Max PSI = {maxPsi}");
        }

        private void btnSendMin_Click(object sender, EventArgs e)
        {
            ushort maxPsi = (ushort)nudMaxPsi.Value;
            ushort minPsi = (ushort)nudMinPsi.Value;

            if (minPsi > maxPsi)
            {
                SetError("Min PSI cannot be greater than Max PSI.");
                return;
            }

            SendFrame(PumpProtocol.SetMinPressurePsi(minPsi), $"Set Min PSI = {minPsi}");
        }

        private void btnSendFlow_Click(object sender, EventArgs e)
        {
            float flow = (float)nudFlow.Value;
            SendFrame(PumpProtocol.SetFlowRate(flow), $"Set Flow = {flow}");
        }

        private void btnStart_Click(object sender, EventArgs e) => SendFrame(PumpProtocol.Start(), "Start");
        private void btnStop_Click(object sender, EventArgs e) => SendFrame(PumpProtocol.Stop(), "Stop");
        private void btnClean_Click(object sender, EventArgs e) => SendFrame(PumpProtocol.Clean(), "Clean");

        // ---------------- Menu handlers ----------------
        private void menuExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void menuRefreshPorts_Click(object sender, EventArgs e)
        {
            RefreshPorts();
        }

        private void menuConnect_Click(object sender, EventArgs e)
        {
            btnConnect_Click(sender, e);
        }

        private void menuDisconnect_Click(object sender, EventArgs e)
        {
            btnDisconnect_Click(sender, e);
        }

        private void menuStart_Click(object sender, EventArgs e)
        {
            btnStart_Click(sender, e);
        }

        private void menuStop_Click(object sender, EventArgs e)
        {
            btnStop_Click(sender, e);
        }

        private void menuClean_Click(object sender, EventArgs e)
        {
            btnClean_Click(sender, e);
        }

        private void menuClearLog_Click(object sender, EventArgs e)
        {
            _log.Clear();
            txtLog.Clear();
            LogInfo("Log cleared");
        }

        private void menuExportLog_Click(object sender, EventArgs e)
        {
            using SaveFileDialog sfd = new SaveFileDialog
            {
                Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*",
                FileName = $"pump_log_{DateTime.Now:yyyyMMdd_HHmmss}.txt"
            };

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                System.IO.File.WriteAllText(sfd.FileName, _log.ToString());
                LogInfo("Log saved: " + sfd.FileName);
            }
        }

        private void menuAbout_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "Pump Controller App\n\n" +
                "Protocol: 10-byte frame [0x28 ... 0x29]\n" +
                "Checksum: XOR of bytes 0..6\n" +
                "Pressure: uint16 PSI, LSB first\n" +
                "Flow: IEEE754 float, big-endian",
                "About",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        // ---------------- Cleanup ----------------
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            try { _pump?.Dispose(); } catch { /* ignore */ }
            base.OnFormClosing(e);
        }
    }
}