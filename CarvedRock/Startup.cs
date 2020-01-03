using CarvedRock.DataAccess.DAL;
using CarvedRock.DataAccess.Repositories;
using CarvedRock.GraphQL;
using GraphQL;
using GraphQL.Server;
using GraphQL.Server.Ui.Playground;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CarvedRock
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            Environment = env;

        }

        public IConfiguration Configuration { get; }
        private readonly IWebHostEnvironment Environment;

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.Configure<KestrelServerOptions>(options =>
            {
                options.AllowSynchronousIO = true;
            });

            services.AddControllers();

            services.AddDbContext<CarvedRockContext>(options => options.UseSqlServer(Configuration["ConnectionStrings:CarvedRock"]));


            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductReviewRepository, ProductReviewRepository>();

            // Links .NET service provider to GraphQL IDependencyResolver
            services.AddScoped<IDependencyResolver>(serviceProvider => new FuncDependencyResolver(serviceProvider.GetRequiredService));

            services.AddScoped<CarvedRockSchema>();

            services.AddGraphQL(o => { o.ExposeExceptions = Environment.IsDevelopment(); })
                .AddGraphTypes(ServiceLifetime.Scoped);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, CarvedRockContext context)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseGraphQL<CarvedRockSchema>();
            app.UseGraphQLPlayground(new GraphQLPlaygroundOptions());

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            context.Seed();

        }
    }
}
