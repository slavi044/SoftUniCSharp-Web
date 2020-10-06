namespace SIS.MvcFramework
{
    using SIS.HTTP;

    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Threading.Tasks;

    public static class Host
    {
        public static async Task CreateHostAsync(IMvcApplication application, int port)
        {
            List<Route> routeTable = new List<Route>();
            application.ConfigureServices();
            application.Configure(routeTable);

            IHttpServer server = new HttpServer(routeTable);

            Process.Start(@"C:\Program Files (x86)\Google\Chrome\Application\chrome.exe", "http://localhost/");

            await server.StartAsync(port);
        }
    }
}
