namespace SIS.MvcFramework
{
    using SIS.HTTP;
    using System.Collections.Generic;

    public interface IMvcApplication
    {
        void ConfigureServices();

        void Configure(List<Route> routeTable);
    }
}
