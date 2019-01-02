using System.Drawing;

namespace LC_LocalAutomation.Helper
{
    public static class ExtensionHelper
    {
        public static string Rect2String(this Rectangle rect)
        {
            return $"X:{rect.X}, Y:{rect.Y}, W:{rect.Width}, H:{rect.Height}";
        }
    }
}
