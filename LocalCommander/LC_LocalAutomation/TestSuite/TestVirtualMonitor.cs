using LC_LocalAutomation.Virtuals;

namespace LC_LocalAutomation.TestSuite
{
    class TestVirtualMonitor
    {
        public TestVirtualMonitor()
        {
            TestPrintFullScreen();
        }

        private static void TestPrintFullScreen()
        {
            var downloads = "C:\\Users\\138208\\Downloads\\";

            var bmp = VirtualMonitor.Instance.PrintFullScreen();
            bmp.Save(downloads + "printFullScreen.png");
        }
    }
}
