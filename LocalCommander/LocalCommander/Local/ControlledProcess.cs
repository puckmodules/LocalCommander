using System.Diagnostics;

namespace LocalCommander.Local
{
    public class ControlledProcess
    {
        public bool IsInvalidOrEmpty { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }

        public ControlledProcess()
        {
        }

        public ControlledProcess(Process process)
        {
            Id = process.Id;
            Name = process.ProcessName;
        }

        public static ControlledProcess Empty()
        {
            var result = new ControlledProcess();
            result.IsInvalidOrEmpty = true;
            return result;
        }
    }
}
