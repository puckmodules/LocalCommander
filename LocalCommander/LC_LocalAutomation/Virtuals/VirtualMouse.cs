using System.Drawing;

namespace LC_LocalAutomation.Virtuals
{
    public static class VirtualMouse
    {
        public static void ClickLeft(Point p)
        {
            ClickLeft(p.X, p.Y);
        }

        public static void ClickLeft(int x, int y)
        {
            AutoIt.AutoItX.MouseClick("LEFT", x, y, 1);
        }

        public static void ClickRight(Point p)
        {
            ClickRight(p.X, p.Y);
        }

        public static void ClickRight(int x, int y)
        {
            AutoIt.AutoItX.MouseClick("RIGHT", x, y, 1);
        }

        public static void ClickMiddle(Point p)
        {
            ClickMiddle(p.X, p.Y);
        }

        public static void ClickMiddle(int x, int y)
        {
            AutoIt.AutoItX.MouseClick("MIDDLE", x, y, 1);
        }

        public static void ClickAndDragLeft(Point p1, Point p2)
        {
            AutoIt.AutoItX.MouseClickDrag("LEFT", p1.X, p1.Y, p2.X, p2.Y);
        }
    }
}
