using System.Net;
using System.Text;
using System.Threading;

namespace LocalCommander
{
    public class WebInterface
    {
        private static string _url;
        private static HttpListener _httpListener = new HttpListener();

        public WebInterface(int port = 5000, bool openSite = true)
        {
            StartServer(port);
            if (openSite)
                GoToSite(_url);
        }

        public static void GoToSite(string url)
        {
            System.Diagnostics.Process.Start(url);
        }

        private static void StartServer(int port)
        {
            _url = $"http://localhost:{port}/";
            _httpListener.Prefixes.Add(_url);
            _httpListener.Start();
            Thread responseThread = new Thread(ResponseThread);
            responseThread.Start();
        }

        private static void ResponseThread()
        {
            while (true)
            {
                HttpListenerContext context = _httpListener.GetContext(); // get a context
                // Now, you'll find the request URL in context.Request.Url
                byte[] responseArray = Encoding.UTF8.GetBytes("<html><head><title>Localhost server -- port 5000</title></head>" +
                                                               "<body>Welcome to the <strong>Localhost server</strong> -- <em>port 5000!</em></body></html>"); // get the bytes to response
                context.Response.OutputStream.Write(responseArray, 0, responseArray.Length); // write bytes to the output stream
                context.Response.KeepAlive = false; // set the KeepAlive bool to false
                context.Response.Close(); // close the connection
            }
        }
    }
}
