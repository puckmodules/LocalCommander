using LC_LocalAutomation.Virtuals;
using System;
using System.Drawing;

namespace LC_LocalAutomation.TestSuite
{
    public class TestVirtualApplication
    {
        public TestVirtualApplication()
        {
            //CreateVirtAppPaint();
            //CreateVirtAppNotepad();
            CreateVirtPrintScreen();
            Console.WriteLine("END...");
            Console.ReadKey();
        }

        public void CreateVirtAppPaint()
        {
            var app = new VirtualApplication("mspaint");
            app.ClickAndDragLeft(new Point(-1500, 400), new Point(-1000, 600));
        }

        public void CreateVirtAppNotepad()
        {
            var app = new VirtualApplication("notepad");
            app.SendText("isto funciona!!!");
        }

        public void CreateVirtPrintScreen()
        {
            var downloads = "C:\\Users\\138208\\Downloads\\";

            var app = new VirtualApplication("mspaint");
            app.PrintScreen().Save(downloads + "paint.png");
        }
    }
}
