namespace MyFirstAsyncApp
{
    using System;
    using System.IO;
    using System.Net;
    using System.Net.Sockets;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;

    class Program
    {
        const string NewLine = "\r\n";

        static async Task Main()
        {
            Console.OutputEncoding = Encoding.UTF8;

            TcpListener tcpListener = new TcpListener(IPAddress.Loopback, 12345);
            tcpListener.Start();

            while(true)
            {
                var client = tcpListener.AcceptTcpClient();

                Thread thread = new Thread(() =>
                {
                    using (Stream stream = client.GetStream())
                    {
                        byte[] buffer = new byte[100];

                        int lenght = stream.Read(buffer, 0, buffer.Length);

                        string html = $"<h1> Async Server 2020</h1>";

                        string response = "HTTP/1.1 200 OK" + NewLine +
                            "Server: AsyncServer 2020" + NewLine +
                            "Content-Type: text/html; charset=utf8" + NewLine +
                            "Content-Lenght: " + html.Length + NewLine +
                            NewLine +
                            html + NewLine;

                        byte[] responceBytes = Encoding.UTF8.GetBytes(response);

                        for (int i = 0; i < 10000000; i++)
                        {
                            Thread.Sleep(1000);
                            stream.Write(responceBytes);
                        }
                    }
                });

                thread.Start();
            }
        }
    }
}
