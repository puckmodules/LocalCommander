using System.Diagnostics;

namespace LocalCommander.Local
{
    public static class LocalApplications
    {
        public static bool IsProcessRunning(string processName)
        {
            Process[] pname = Process.GetProcessesByName(processName);
            return pname.Length > 0;
        }

        public static ControlledProcess GetProcess(string processName)
        {
            var processes = Process.GetProcessesByName(processName);
            if (processes.Length > 0)
                return ControlledProcess.Empty();
            return new ControlledProcess(processes[0]);
        }
    }
}
