using CmsA.Web.Resources;
using CmsA.Web.Services;
using Microsoft.AspNetCore.Localization;
using System.Globalization;
using System.Reflection;

namespace CmsA.Web.Dependency
{
    public static class LocalizationExtension
    {
        public static void AddLocalizationService(this IServiceCollection services)
        {
            services.AddSingleton<LocService>();
            services.AddLocalization(options => options.ResourcesPath = "Resources");

            services.AddControllersWithViews().AddRazorRuntimeCompilation().AddViewLocalization()
            .AddDataAnnotationsLocalization(
                options =>
                  options.DataAnnotationLocalizerProvider = (type, factory) =>
                  {
                      var assemblyName = new AssemblyName(typeof(SharedResource).GetTypeInfo().Assembly.FullName);
                      return factory.Create("SharedResource", assemblyName.Name);
                  }
                );
        }

        public static void AddLocalization(this WebApplication app)
        {

            var supportedCultures = new[] { new CultureInfo("en"), new CultureInfo("ru"), new CultureInfo("az"), new CultureInfo("tr") };

            app.UseRequestLocalization(
              new RequestLocalizationOptions()
              {
                  DefaultRequestCulture = new RequestCulture("en"),
                  SupportedCultures = supportedCultures,
                  SupportedUICultures = supportedCultures
              }
            );
        }
    }
}
