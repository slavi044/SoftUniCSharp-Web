namespace SIS.HTTP
{
    using System;
    using System.Threading.Tasks;

    public interface IHttpServer
    {
        Task StartAsync(int port);
    }
}
