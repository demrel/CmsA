using CmsA.Service.Inteface;
using CmsA.Service.Inteface.Cms;
using CmsA.Service.Inteface.Localizations;
using CmsA.Service.Services;
using CmsA.Service.Services.Cms;
using CmsA.Service.Services.Localizations;

namespace CmsA.Web.Dependency;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {

        services.AddScoped<ICulture, CultureService>();
        services.AddScoped<ILocalizationSet, LocalizationSetService>();
        services.AddScoped<ILocalization, LocalizationService>();

        services.AddScoped<IImageFile, ImageFileService>();

        services.AddScoped<IBanner, BannerService>();
        services.AddScoped<IPage, PageService>();
        services.AddScoped<IPost, PostService>();
        services.AddScoped<IPartner, PartnerService>();
        services.AddScoped<IKeyValueHelper, KeyValueHelperService>();
        services.AddScoped<IMessage, MessageService>();
        services.AddScoped<IVideo, VideoService>();
        services.AddScoped<IMission , MissionVissionService>();
        services.AddScoped<ISiteSetting, SettingService>();

        return services;   
    }


}

