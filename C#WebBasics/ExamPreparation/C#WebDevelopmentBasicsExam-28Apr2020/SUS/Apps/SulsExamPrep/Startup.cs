using Microsoft.EntityFrameworkCore;
using SulsExamPrep.Data;
using SulsExamPrep.Services;
using SUS.HTTP;
using SUS.MvcFramework;
using System.Collections.Generic;

namespace SulsExamPrep
{
    public class Startup : IMvcApplication
    {
        public void Configure(List<Route> routeTable)
        {
            new ApplicationDbContext().Database.Migrate();
        }

        public void ConfigureServices(IServiceCollection serviceCollection)
        {
            serviceCollection.Add<IUserService, UserService>();
            serviceCollection.Add<IProblemService, ProblemService>();
            serviceCollection.Add<ISubmissionService, SubmissionService>();
        }
    }
}
