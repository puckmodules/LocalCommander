using System;
using System.Windows.Forms;

namespace LocalCommander
{
    static class Program
    {
        public static MainForm MainForm { get; set; }
        private static WebInterface _webInterface;
        public static WebInterface WebInterface
        {
            get
            {
                if (_webInterface == null) _webInterface = new WebInterface();
                return _webInterface;
            }
        }

        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            MainForm = new MainForm();

            Application.Run(MainForm);
        }

        public static void EndApplication()
        {
            if (System.Windows.Forms.Application.MessageLoop)
                System.Windows.Forms.Application.Exit();
            else
                System.Environment.Exit(1);
        }
    }
}
