namespace MyFirstMvcApp
{
    using MyFirstMvcApp.Data;
    using SIS.HTTP;
    using SIS.MvcFramework;

    using System.Collections.Generic;

    using Microsoft.EntityFrameworkCore;

    public class Startup : IMvcApplication
    {
        public void ConfigureServices()
        {
            
        }

        public void Configure(List<Route> routeTable)
        {
            new ApplicationDbContext().Database.MigrateAsync();
        }
    }
}
