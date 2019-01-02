namespace LC_LocalAutomation.Virtuals
{
    public static class VirtualKeyboard
    {
        public static void SendText(string text)
        {
            AutoIt.AutoItX.Send(text);
        }
    }
}
