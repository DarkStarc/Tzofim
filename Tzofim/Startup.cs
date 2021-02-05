using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Globalization;
using Microsoft.EntityFrameworkCore;
using Tzofim.Models;

namespace Tzofim
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
           string connectionString = Configuration.GetConnectionString("DefaultConnection");

           services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(connectionString));

           services.AddLocalization(p => p.ResourcesPath = "Resource");

           services.AddControllersWithViews().AddViewLocalization();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app,DatabaseContext context)
        {
            var supportLanguage = new[]
                {
                    new CultureInfo("ua"),
                    new CultureInfo("ru"),
                    new CultureInfo("en")
                };

            DbInitializer.Initialize(context);

            app.UseRequestLocalization(new RequestLocalizationOptions {
               DefaultRequestCulture = new Microsoft.AspNetCore.Localization.RequestCulture("ua-Ua"),
               SupportedCultures = supportLanguage,
              SupportedUICultures = supportLanguage,
            });

            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Main}/{action=Index}/{id?}");

            });
        }
    }
}
