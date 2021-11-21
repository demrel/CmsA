using CmsA.Data.Data;
using CmsA.Service.Inteface.Localizations;
using CmsA.Service.Services.Localizations;
using Identity.Users;
using Microsoft.AspNetCore.Identity;

namespace CmsA.Web.Dependency;

public static class AuthenticationExtension
{
    public static void AddAuth(this IServiceCollection services)
    {

        services.AddIdentity<AppUser, AppRole>(
       options =>
       {
           options.Stores.MaxLengthForKeys = 128;
           options.User.RequireUniqueEmail = false;
           options.Password.RequireNonAlphanumeric = false;
       }).AddEntityFrameworkStores<AppDBContext>().AddDefaultTokenProviders();



        services.ConfigureApplicationCookie(
                options =>
                {
                    options.Cookie.Name = "User";
                    options.LoginPath = new PathString("/Accaount/Login");
                    options.AccessDeniedPath = new PathString("/Accaount/AccessDenied");
                });


    }
}

