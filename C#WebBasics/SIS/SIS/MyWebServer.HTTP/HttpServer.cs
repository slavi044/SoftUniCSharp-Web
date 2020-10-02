namespace MWS.HTTP
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Net;
    using System.Net.Sockets;
    using System.Text;
    using System.Threading.Tasks;

    public class HttpServer : IHttpServer
    {
        private const int BufferSize = 4096;
        private const string NewLine = "\r\n";

        IDictionary<string, Func<HttpRequest, HttpResponse>> routeTable =
            new Dictionary<string, Func<HttpRequest, HttpResponse>>();

        public void AddRoute(string path, Func<HttpRequest, HttpResponse> action)
        {
            if (routeTable.ContainsKey(path))
            {
                routeTable[path] = action;
            }
            else
            {
                routeTable.Add(path, action);
            }
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
            using (NetworkStream stream = tcpClient.GetStream())
            {
                int position = 0;
                byte[] buffer = new byte[BufferSize];
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
                Console.WriteLine(requestAsString);

                //TODO:Extract info requstAsString

                string responseHtml = "<h1>Welcome</h1>";
                byte[] responseBodyBytes = Encoding.UTF8.GetBytes(responseHtml);

                string responseHttp = "HTTP 1.1 200 OK" + NewLine +
                    "Server: MW Server 1.0 " + NewLine +
                    "Content-Type: text/html" + NewLine +
                    "Content-Length: " + responseBodyBytes.Length + NewLine +
                    NewLine;
                byte[] responseHeaderBytes = Encoding.UTF8.GetBytes(responseHttp);
                
                await stream.WriteAsync(responseHeaderBytes);//if throw err 0, rhb.Length
                await stream.WriteAsync(responseBodyBytes);//if throw err 0, rbb.Length
            }

            tcpClient.Close();
        }
    }
}
