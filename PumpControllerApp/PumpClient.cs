using System;
using System.IO.Ports;
using System.Threading;
using System.Threading.Tasks;

namespace PumpControllerApp
{
    public sealed class PumpClient : IDisposable
    {
        private readonly SerialPort _sp;
        private readonly SemaphoreSlim _txLock = new(1, 1);

        public bool IsOpen => _sp.IsOpen;

        public PumpClient(string portName, int baudRate)
        {
            _sp = new SerialPort(portName, baudRate, Parity.None, 8, StopBits.One)
            {
                ReadTimeout = 500,
                WriteTimeout = 500
            };
        }

        public void Open()
        {
            if (!_sp.IsOpen) _sp.Open();
        }

        public void Close()
        {
            if (_sp.IsOpen) _sp.Close();
        }

        public async Task SendAsync(byte[] frame10, int intervalMs, CancellationToken ct = default)
        {
            if (frame10 == null || frame10.Length != 10)
                throw new ArgumentException("Frame must be exactly 10 bytes.");

            if (intervalMs < 0) intervalMs = 0;

            await _txLock.WaitAsync(ct);
            try
            {
                if (!_sp.IsOpen) throw new InvalidOperationException("Serial port is not open.");
                _sp.Write(frame10, 0, frame10.Length);
                await Task.Delay(intervalMs, ct);
            }
            finally
            {
                _txLock.Release();
            }
        }

        public void Dispose()
        {
            try { Close(); } catch { }
            _sp.Dispose();
            _txLock.Dispose();
        }
    }
}