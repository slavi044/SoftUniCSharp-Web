using Microsoft.EntityFrameworkCore;
using MySuls.Data;
using MySuls.Services;
using SUS.HTTP;
using SUS.MvcFramework;
using System.Collections.Generic;

namespace MySuls
{
    public class Startup : IMvcApplication
    {
        public void Configure(List<Route> routeTable)
        {
            new ApplicationDbContext().Database.Migrate();
        }

        public void ConfigureServices(IServiceCollection serviceCollection)
        {
            serviceCollection.Add<IUsersService, UsersService>();
            serviceCollection.Add<IProblemService, ProblemService>();
            serviceCollection.Add<ISubmissionService, SubmissionService>();
        }
    }
}
