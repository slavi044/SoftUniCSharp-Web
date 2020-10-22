using SUS.MvcFramework;
using System.Threading.Tasks;

namespace MySuls
{
    public class Program
    {
        static async Task Main()
        {
            await Host.CreateHostAsync(new Startup());
        }
    }
}
