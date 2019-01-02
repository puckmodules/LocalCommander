namespace LC_LocalAutomation
{
    public static class VirtualMouse
    {
        public static void ClickLeft(int x, int y)
        {
            AutoIt.AutoItX.MouseClick("LEFT", x, y, 1);
        }

        public static void ClickRight(int x, int y)
        {
            AutoIt.AutoItX.MouseClick("RIGHT", x, y, 1);
        }

        public static void ClickMiddle(int x, int y)
        {
            AutoIt.AutoItX.MouseClick("MIDDLE", x, y, 1);
        }
    }
}
