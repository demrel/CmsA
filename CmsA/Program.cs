using CmsA.Data.Data;
using CmsA.Web.Dependency;
using CmsA.Web.Mapper;
using CmsA.Web.Resources;
using Identity.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);
builder.WebHost.ConfigureKestrel(op=>op.ListenLocalhost(5010));
// Add services to the container.
var services=builder.Services;
var conf=builder.Configuration;

services.AddLocalizationService();

services.AddDbContext<AppDBContext>(options =>
{
            options.UseNpgsql(conf.GetConnectionString("NpgSqlHeroku"));
});

services.AddAutoMapper(typeof(MappingProfile));
services.AddServices().AddAuth();

var app = builder.Build();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.AddLocalization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

    app.MapControllerRoute(
      name: "default",
      pattern: "{controller=Home}/{action=Index}/{id?}");
});
        


app.Run();

