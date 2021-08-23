using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TimDemoApp.Core.Repositories.Tree;
using TimDemoApp.Core.Services.Tree;
using TimDemoApp.Infrastructure.Repositories;
using TimDemoApp.Web.Services;

namespace TimDemoApp.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            AddRepositoriesForDI(services);
            AddServicesForDI(services);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }

        private static void AddRepositoriesForDI(IServiceCollection services)
        {
            services.AddTransient<ITreeRepository, TreeRepository>();
        }

        private static void AddServicesForDI(IServiceCollection services)
        {
            services.AddTransient<ITreeViewService, TreeViewService>();
            services.AddTransient<IGetTreeService, GetTreeService>();
        }
    }
}
