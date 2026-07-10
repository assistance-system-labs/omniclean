using System;
using Microsoft.Win32;
using System.Diagnostics;

namespace UninstallTools.Junk.WindowsCleaner
{
    public static class TelemetryDisabler
    {
        public static void DisableTelemetry()
        {
            try
            {
                // Disable Connected User Experiences and Telemetry service
                var psi = new ProcessStartInfo("sc.exe", "config DiagTrack start= disabled")
                {
                    UseShellExecute = false,
                    CreateNoWindow = true
                };
                Process.Start(psi)?.WaitForExit();

                psi = new ProcessStartInfo("sc.exe", "stop DiagTrack")
                {
                    UseShellExecute = false,
                    CreateNoWindow = true
                };
                Process.Start(psi)?.WaitForExit();
                
                // Disable dmwappushservice
                psi = new ProcessStartInfo("sc.exe", "config dmwappushservice start= disabled")
                {
                    UseShellExecute = false,
                    CreateNoWindow = true
                };
                Process.Start(psi)?.WaitForExit();
            }
            catch { }

            try
            {
                // Registry tweaks
                using (var key = Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Policies\Microsoft\Windows\DataCollection"))
                {
                    key?.SetValue("AllowTelemetry", 0, RegistryValueKind.DWord);
                }
            }
            catch { }
        }
    }
}
