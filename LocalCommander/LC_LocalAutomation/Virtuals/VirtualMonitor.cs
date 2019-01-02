using System.Drawing;
using System.Windows.Forms;

namespace LC_LocalAutomation.Virtuals
{
    public class VirtualMonitor
    {
        private static VirtualMonitor _instance = null;

        public static int NumberOfScreens => Screen.AllScreens.Length;

        public Rectangle FullScreenSize => GetFullScreenSize();

        public int TotalWidth => SystemInformation.VirtualScreen.Width;

        public int TotalHeight => SystemInformation.VirtualScreen.Height;

        public static VirtualMonitor Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new VirtualMonitor();
                }
                return _instance;
            }
        }

        public Rectangle GetFullScreenSize()
        {
            return new Rectangle(SystemInformation.VirtualScreen.Left, SystemInformation.VirtualScreen.Top, SystemInformation.VirtualScreen.Width, SystemInformation.VirtualScreen.Height);
        }

        public bool IsCoordinateValid(Point p)
        {
            return FullScreenSize.Contains(p);
        }

        public Screen GetScreen(int s)
        {
            if (s >= NumberOfScreens) throw new LocalAutomationException(typeof(VirtualMonitor), LC_Diagnostics.Diagnostics.GetCurrentMethod(), "Input number is bigger than number of screens");
            if (s < 0) throw new LocalAutomationException(typeof(VirtualMonitor), LC_Diagnostics.Diagnostics.GetCurrentMethod(), "Input number is smaller than 0");

            return Screen.AllScreens[s];
        }

        public Screen[] GetAllScreens()
        {
            return Screen.AllScreens;
        }

        public Bitmap PrintFullScreen()
        {
            var bmp = new Bitmap(SystemInformation.VirtualScreen.Width, SystemInformation.VirtualScreen.Height);
            var gr = Graphics.FromImage(bmp);
            gr.CopyFromScreen(SystemInformation.VirtualScreen.Left, SystemInformation.VirtualScreen.Top, 0, 0, bmp.Size);
            return bmp;
        }

        public Bitmap PrintScreen(Point origin, Point destination)
        {
            var bmp = new Bitmap(destination.X - origin.X, destination.Y - origin.Y);
            var gr = Graphics.FromImage(bmp);
            gr.CopyFromScreen(origin.X, origin.Y, destination.X, destination.Y, bmp.Size);
            return bmp;
        }

        public Bitmap PrintScreen(Rectangle rect)
        {
            var bmp = new Bitmap(rect.Width, rect.Height);
            var gr = Graphics.FromImage(bmp);
            gr.CopyFromScreen(rect.X, rect.Y, 0, 0, bmp.Size);
            return bmp;
        }
    }
}
