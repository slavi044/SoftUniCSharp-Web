using SUS.MvcFramework;
using System.Threading.Tasks;

namespace MySuls
{
    class Program
    {
        static async Task Main()
        {
            await Host.CreateHostAsync(new Startup());
        }
    }
}
