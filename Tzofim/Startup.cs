using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Globalization;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Options;
using System.Linq;
using System.Threading.Tasks;

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
           services.AddLocalization(p => p.ResourcesPath = "Resource");

           services.AddControllersWithViews().AddViewLocalization();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            var supportLanguage = new[]
                {
                    new CultureInfo("ua"),
                    new CultureInfo("ru"),
                    new CultureInfo("en")
                };

          

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
