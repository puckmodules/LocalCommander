using System.Diagnostics;
using System.Net;
using System.Net.Sockets;

namespace LC_LocalAutomation.Virtuals
{
    public class VirtualSystem
    {
        public string MachineName => System.Environment.MachineName;

        public bool IsOnline => System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable();

        public string IpAddress => GetLocalIpAddress();

        private static string GetLocalIpAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }

            return "0.0.0.0";
        }

        public static bool IsProcessRunning(string processName)
        {
            Process[] pname = Process.GetProcessesByName(processName);
            return pname.Length > 0;
        }

        //public static ControlledProcess GetProcess(string processName)
        //{
        //    var processes = Process.GetProcessesByName(processName);
        //    if (processes.Length > 0)
        //        return ControlledProcess.Empty();
        //    return new ControlledProcess(processes[0]);
        //}

        public void ShutDown()
        {
            var psi = new ProcessStartInfo("shutdown", "/s /t 0");
            psi.CreateNoWindow = true;
            psi.UseShellExecute = false;
            Process.Start(psi);
        }

        public void StartProcess(string processName)
        {
            Process.Start(processName);
        }
    }
}
