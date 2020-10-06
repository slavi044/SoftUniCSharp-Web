namespace SIS.HTTP
{
    using System;
    using System.Text;
    using System.Collections.Generic;
    using System.Net;
    using System.Net.Sockets;
    using System.Threading.Tasks;
    using System.Linq;

    public class HttpServer : IHttpServer
    {
        List<Route> routeTable;

        public HttpServer(List<Route> routeTable)
        {
            this.routeTable = routeTable;
        }

        public async Task StartAsync(int port)
        {
            TcpListener tcpListener = new TcpListener(IPAddress.Loopback, port);
            tcpListener.Start();

            while (true)
            {
                TcpClient tcpClient = await tcpListener.AcceptTcpClientAsync();

                ProcessClientAsync(tcpClient);
            }
        }

        private async Task ProcessClientAsync(TcpClient tcpClient)
        {
            try
            {
                using (NetworkStream stream = tcpClient.GetStream())
                {
                    int position = 0;
                    byte[] buffer = new byte[HttpConstants.BufferSize];
                    List<byte> data = new List<byte>();

                    while (true)
                    {
                        int count = await stream.ReadAsync(buffer, 0, buffer.Length);

                        position += count;

                        if (count < buffer.Length)
                        {
                            byte[] partialBuffer = new byte[count];
                            Array.Copy(buffer, partialBuffer, count);

                            data.AddRange(partialBuffer);

                            break;
                        }
                        else
                        {
                            data.AddRange(buffer);
                        }
                    }

                    string requestAsString = Encoding.UTF8.GetString(data.ToArray());

                    HttpRequest request = new HttpRequest(requestAsString);
                    Console.WriteLine(requestAsString);

                    HttpResponse response;
                    Route route = this.routeTable.FirstOrDefault(x => string.Compare(x.Path, request.Path, true) == 0
                                                    && x.Method == request.Method);

                    if (route != null)
                    {
                        response = route.Action(request);
                    }
                    else
                    {
                        //Not Found 404
                        response = new HttpResponse("text/html", new byte[0], HttpStatusCode.NotFound);
                    }


                    response.Cookies.Add(new ResponseCookie("sid", Guid.NewGuid().ToString()) { HttpOnly = true, MaxAge = 60 * 24 * 60 * 60 });
                    response.Headers.Add(new Header("Server", "SIS Server 1.0"));

                    byte[] responseHeaderBytes = Encoding.UTF8.GetBytes(response.ToString());

                    await stream.WriteAsync(responseHeaderBytes, 0, responseHeaderBytes.Length);
                    await stream.WriteAsync(response.Body, 0, response.Body.Length);
                }

                tcpClient.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
