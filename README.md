# PumpControllerApp

Windows (x64) **WinForms** application built with **.NET 10** that controls a pump controller over **RS232 serial communication**.

It’s designed to connect the **pump-side RS232** to a **PC/Laptop** using either:
- a **USB-to-RS232 adapter** (most common), or
- a built-in **COM port** (if your machine has one)

---

## Features

- WinForms UI (Windows desktop)
- Serial communication using `System.IO.Ports`
- Pump command framing via a simple 10-byte protocol:
  - Set **Flow Rate**
  - Set **Min Pressure (PSI)**
  - Set **Max Pressure (PSI)**
  - **Start**
  - **Stop**
  - **Clean**

---

## Tech Stack

- **C#**
- **.NET 10** (`net10.0-windows`)
- **WinForms**
- **System.IO.Ports** for serial (COM) communication
- Target: **Windows x64**

---

## Requirements

### Software
- Windows 10/11 (x64)
- Visual Studio (recommended) with **.NET Desktop Development** workload
- .NET 10 SDK (to build from source)

### Hardware
- Pump controller with **RS232**
- One of:
  - USB-to-RS232 converter (creates a COM port in Windows), or
  - Native COM port on the PC

---

## How it Works (Protocol Overview)

This app builds and sends **10-byte frames** to the pump:

- Start byte: `0x28` (`(`)
- Address: `0x01`
- Command byte: `CMD`
- Reserved: `0x00`
- Data bytes: `DATA0..DATA3`
- Check byte: XOR of bytes `[0..6]`
- End byte: `0x29` (`)`)

The protocol builder is implemented in `PumpProtocol.cs`, and serial sending is handled by `PumpClient.cs`.

---

## Build & Run (Visual Studio)

1. Clone the repo
2. Open the solution:
   - `PumpControllerApp.slnx`
3. Select configuration:
   - `Release`
   - `x64` (recommended)
4. Run the project

---

## Usage

1. Connect the pump to your PC via RS232 (USB adapter or COM port)
2. Identify the COM port in Windows (Device Manager → Ports (COM & LPT))
3. Open the app and select/configure:
   - COM port (e.g., `COM3`)
   - Baud rate (as required by your pump controller)
4. Send commands:
   - Set flow
   - Set min/max pressure (PSI)
   - Start/Stop/Clean

---

## Project Structure (high level)

- `PumpControllerApp/`
  - `PumpControllerApp.csproj` (WinForms / net10.0-windows)
  - `MainForm2.cs` / `Form1.cs` (UI)
  - `PumpClient.cs` (SerialPort wrapper + async send)
  - `PumpProtocol.cs` (Frame builder + commands)

---

## Safety / Disclaimer

This project controls real hardware. Use at your own risk.
Always validate commands, wiring, and pressure/flow limits with your pump/controller documentation before operating.

---

## License

See `LICENSE.txt`.
