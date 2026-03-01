using System;

namespace PumpControllerApp
{
    public static class PumpProtocol
    {
        // Frame: [0]=0x28 '(' , [1]=0x01, [2]=CMD, [3]=0x00,
        // [4..7]=DATA, [8]=XOR(0..6), [9]=0x29 ')'
        public static byte[] Build(byte cmd, byte d0, byte d1, byte d2, byte d3)
        {
            var f = new byte[10];
            f[0] = 0x28;
            f[1] = 0x01;
            f[2] = cmd;
            f[3] = 0x00;
            f[4] = d0;
            f[5] = d1;
            f[6] = d2;
            f[7] = d3;

            byte x = f[0];
            for (int i = 1; i <= 6; i++) x ^= f[i];
            f[8] = x;

            f[9] = 0x29;
            return f;
        }

        public static byte[] SetMaxPressurePsi(ushort psi)
        {
            // little-endian in data0..1
            byte lo = (byte)(psi & 0xFF);
            byte hi = (byte)((psi >> 8) & 0xFF);
            return Build(0x32, lo, hi, 0x00, 0x00);
        }

        public static byte[] SetMinPressurePsi(ushort psi)
        {
            byte lo = (byte)(psi & 0xFF);
            byte hi = (byte)((psi >> 8) & 0xFF);
            return Build(0x33, lo, hi, 0x00, 0x00);
        }

        public static byte[] SetFlowRate(float flow)
        {
            // big-endian float in data0..3
            byte[] b = BitConverter.GetBytes(flow);
            if (BitConverter.IsLittleEndian) Array.Reverse(b);
            return Build(0x21, b[0], b[1], b[2], b[3]);
        }

        public static byte[] Start() => Build(0x34, 0x01, 0x00, 0x00, 0x00);
        public static byte[] Stop() => Build(0x34, 0x00, 0x00, 0x00, 0x00);
        public static byte[] Clean() => Build(0x34, 0x02, 0x00, 0x00, 0x00);

        public static string ToHex(byte[] bytes)
        {
            if (bytes == null) return "";
            return BitConverter.ToString(bytes).Replace("-", " ");
        }
    }
}