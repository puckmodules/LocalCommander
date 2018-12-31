using LocalCommander.Properties;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace LocalCommander
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            this.Load += new EventHandler(OnLoad);
        }

        private void OnLoad(object sender, EventArgs e)
        {
            this.Size = new Size(0, 0);

            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.trayIcon_main.ContextMenuStrip = new System.Windows.Forms.ContextMenuStrip();
            this.trayIcon_main.ContextMenuStrip.Items.Add("Settings", Resources.settings.ToBitmap(), OnSettingsClicked);
            this.trayIcon_main.ContextMenuStrip.Items.Add("Exit", Resources.exit.ToBitmap(), OnExitClicked);
        }

        private void OnExitClicked(object sender, EventArgs e)
        {
            Program.EndApplication();
        }

        private void OnSettingsClicked(object sender, EventArgs e)
        {
            var x = Program.WebInterface;
        }
    }
}
