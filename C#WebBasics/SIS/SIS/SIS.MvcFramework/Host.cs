namespace SIS.MvcFramework
{
    using SIS.HTTP;

    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Threading.Tasks;

    public static class Host
    {
        public static async Task CreateHostAsync(List<Route> routeTable, int port)
        {
            IHttpServer server = new HttpServer(routeTable);

            Process.Start(@"C:\Program Files (x86)\Google\Chrome\Application\chrome.exe", "http://localhost/");

            await server.StartAsync(port);
        }
    }
}
