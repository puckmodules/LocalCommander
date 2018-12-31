using System.Net;
using System.Net.Sockets;

namespace LocalCommander.Local
{
    public class ControlledMachine
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
    }
}
