namespace MyOwnHttpRequester
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Net.Sockets;
    using System.Text;

    public class Program
    {
        const string NewLine = "\r\n";

        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;
            
            TcpListener tcpListener = new TcpListener(IPAddress.Loopback, 12345);
            tcpListener.Start();

            while (true)
            {
                var client = tcpListener.AcceptTcpClient();

                using (Stream stream = client.GetStream())
                {
                    byte[] buffer = new byte[1000000];

                    int lenght = stream.Read(buffer, 0, buffer.Length);

                    string request = Encoding.UTF8.GetString(buffer, 0, lenght);
                    Console.WriteLine(request);

                    string lastRow = request
                        .Split(NewLine)
                        .Reverse()
                        .FirstOrDefault();

                    string html = string.Empty;
                    string response = string.Empty;

                    if (lastRow.StartsWith("username"))
                    {
                        string username = lastRow
                            .Split("&")
                            .FirstOrDefault()
                            .Split("=")
                            .LastOrDefault();

                        Console.WriteLine(username);

                        html = $"<h1>Hello {username}</h1>" +
                            $"<form method=\"get\" action=\"https://www.google.com/\"><button type=\"submit\">GoToGoogle</button></form>";


                        response = "HTTP/1.1 200 OK" + NewLine +
                            "Server Slavi 2020" + NewLine +
                            "Content-Type: text/html; charset=utf-8" + NewLine +
                            NewLine +
                            //body:
                            html + NewLine;
                    }
                    else
                    {
                        html = "<h1>Hello from SlaviServer</h1>" +
                        "<form action=/tweet method=post>" +
                        "<input name=username></input>" +
                        "<input name=password></input>" +
                        "<input type=submit ></input>" +
                        "</form>";

                        response = "HTTP/1.1 200 OK" + NewLine +
                            "Server Slavi 2020" + NewLine +
                            "Content-Type: text/html; charset=utf-8" + NewLine +
                            NewLine +
                            //body:
                            html + NewLine;
                    }

                    byte[] responceBytes = Encoding.UTF8.GetBytes(response);
                    stream.Write(responceBytes);

                    Console.WriteLine(new string('-', 70));
                }
            }
        }
    }
}