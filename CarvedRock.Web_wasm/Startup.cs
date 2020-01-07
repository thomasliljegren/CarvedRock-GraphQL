using CarvedRock.Web.Configuration;
using Microsoft.AspNetCore.Components.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace CarvedRock.Web
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            IoCConfig.ConfigureServices(services);
        }

        public void Configure(IComponentsApplicationBuilder app)
        {
            app.AddComponent<App>("app");
        }
    }
}
