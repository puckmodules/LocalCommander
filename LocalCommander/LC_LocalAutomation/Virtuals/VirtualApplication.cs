using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;

namespace LC_LocalAutomation.Virtuals
{
    public enum Placement
    {
        Hide = 0,
        Normal = 1,
        Minimized = 2,
        Maximized = 3,
    }

    public class VirtualApplication
    {
        public bool Invalid { get; set; }
        public Process Process { get; set; }
        public IntPtr Handle => Process.MainWindowHandle;
        private bool _isRectangleCalculated;
        private Rectangle _windowRectangle;
        public Rectangle WindowRectangle => GetWindowRectangle();
        public Placement Placement => GetPlacement();

        public VirtualApplication(int processId)
        {
            Process = Process.GetProcessById(processId);
        }

        public VirtualApplication(string processName)
        {
            var processes = Process.GetProcessesByName(processName);
            if (processes.Length > 0)
                Process = processes[0];
            else
                Invalid = true;
        }

        public Bitmap PrintScreen()
        {
            if (Invalid) return new Bitmap(0, 0);
            SetFocus();
            return VirtualMonitor.Instance.PrintScreen(WindowRectangle);
        }

        public void SendText(string text)
        {
            if (Invalid) return;
            SetFocus();
            VirtualKeyboard.SendText(text);
        }

        public void ClickLeft(Point p)
        {
            if (!IsValidPosition(p)) return;
            SetFocus();
            VirtualMouse.ClickLeft(p);
        }

        public void ClickAndDragLeft(Point p1, Point p2)
        {
            if (Invalid || !IsValidPosition(p1) || !IsValidPosition(p2)) return;
            SetFocus();
            VirtualMouse.ClickAndDragLeft(p1, p2);
        }

        public void SetFocus()
        {
            SetForegroundWindow(Handle);
        }

        public Placement GetPlacement()
        {
            WINDOWPLACEMENT placement = new WINDOWPLACEMENT();
            placement.length = Marshal.SizeOf(placement);
            GetWindowPlacement(Handle, ref placement);
            return placement.showPlacement;
        }

        public Rectangle GetWindowRectangle()
        {
            if (Invalid) return new Rectangle(0, 0, 0, 0);
            if (_isRectangleCalculated) return _windowRectangle;

            Rect rect = new Rect();
            GetWindowRect(Handle, ref rect);
            _windowRectangle = rect.ToRectangle();
            _isRectangleCalculated = true;

            return _windowRectangle;
        }

        [DllImport("user32.dll")]
        static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr FindWindow(string strClassName, string strWindowName);

        [DllImport("user32.dll")]
        public static extern bool GetWindowRect(IntPtr hwnd, ref Rect rectangle);

        private static WINDOWPLACEMENT GetPlacement(IntPtr hwnd)
        {
            WINDOWPLACEMENT placement = new WINDOWPLACEMENT();
            placement.length = Marshal.SizeOf(placement);
            GetWindowPlacement(hwnd, ref placement);
            return placement;
        }

        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool GetWindowPlacement(
            IntPtr hWnd, ref WINDOWPLACEMENT lpwndpl);

        public struct Rect
        {
            public int Left { get; set; }
            public int Top { get; set; }
            public int Right { get; set; }
            public int Bottom { get; set; }
            public Rectangle ToRectangle()
            {
                return new Rectangle(Left, Top, Right - Left, Bottom - Top);
            }
        }

        [Serializable]
        [StructLayout(LayoutKind.Sequential)]
        internal struct WINDOWPLACEMENT
        {
            public int length;
            public int flags;
            public Placement showPlacement;
            public System.Drawing.Point ptMinPosition;
            public System.Drawing.Point ptMaxPosition;
            public System.Drawing.Rectangle rcNormalPosition;
        }

        private bool IsValidPosition(Point p)
        {
            return WindowRectangle.Contains(p);
        }
    }
}
