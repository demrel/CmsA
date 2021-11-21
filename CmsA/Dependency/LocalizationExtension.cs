using CmsA.Web.Resources;
using Microsoft.AspNetCore.Localization;
using System.Globalization;

namespace CmsA.Web.Dependency
{
    public static class LocalizationExtension
    {
        public static void AddLocalizationService(this IServiceCollection services)
        {
            services.AddControllersWithViews().AddViewLocalization().AddDataAnnotationsLocalization()
            .AddDataAnnotationsLocalization(options => options.DataAnnotationLocalizerProvider = (t, f) => f.Create(typeof(SharedResource)));
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
