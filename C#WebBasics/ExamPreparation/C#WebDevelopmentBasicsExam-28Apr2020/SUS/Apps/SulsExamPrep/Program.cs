using SUS.MvcFramework;
using System.Threading.Tasks;

namespace SulsExamPrep
{
    class Program
    {
        static async Task Main()
        {
            await Host.CreateHostAsync(new Startup());
        }
    }
}
