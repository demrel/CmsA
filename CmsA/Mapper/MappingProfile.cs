using AutoMapper;
using CmsA.Data.Model;
using CmsA.Data.Model.Cms;
using CmsA.Data.Model.Localization;
using CmsA.Web.Models;
using CmsA.Web.Models.Banner;
using CmsA.Web.Models.Localizations;
using CmsA.Web.Models.Pages;
using CmsA.Web.Models.Partners;
using CmsA.Web.Models.Posts;

namespace CmsA.Web.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<LocalizationModel, Localization>().ReverseMap();
            CreateMap<AppImage, AppImageModel>()
              .ForMember(c => c.Name, m => m.MapFrom(c => c.Name))
              .ForMember(c => c.Id, m => m.MapFrom(c => c.Id)).ReverseMap();
            Page();
            Banner();
            Post();
            Partner();
        }

        private void Page()
        {
            CreateMap<Page, PageModel>()
                    .ForMember(c => c.Title, m => m.MapFrom(c => c.Title.Localizations))
                       .ForMember(c => c.Description, m => m.MapFrom(c => c.Description.Localizations))
                    .ForMember(c => c.Content, m => m.MapFrom(c => c.Content.Localizations));




            CreateMap<PageModel, Page>()
                   .ForPath(c => c.Title.Localizations, m => m.MapFrom(c => c.Title))
                   .ForPath(c => c.Description.Localizations, m => m.MapFrom(c => c.Description))
                    .ForPath(c => c.Content.Localizations, m => m.MapFrom(c => c.Content));


        }

        private void Banner()
        {
            CreateMap<Banner, BanerModel>()
                 .ForMember(c => c.Title, m => m.MapFrom(c => c.Title.Localizations))
                  .ForMember(c => c.Url, m => m.MapFrom(c => c.Url.Localizations))
                 .ForMember(c => c.Image, m => m.MapFrom(c => c.AppImage));

            CreateMap<BanerModel, Banner>()
                .ForPath(c => c.Title.Localizations, m => m.MapFrom(c => c.Title))
                .ForPath(c => c.Url.Localizations, m => m.MapFrom(c => c.Url));
        }

        private void Post()
        {
            CreateMap<Post, PostModel>()
                .ForMember(c => c.Title, m => m.MapFrom(c => c.Title.Localizations))
                .ForMember(c => c.Description, m => m.MapFrom(c => c.Description.Localizations))
                .ForMember(c => c.Content, m => m.MapFrom(c => c.Content.Localizations));
               

            CreateMap<PostModel, Post>()
                   .ForPath(c => c.Title.Localizations, m => m.MapFrom(c => c.Title))
                   .ForPath(c => c.Description.Localizations, m => m.MapFrom(c => c.Description))
                    .ForPath(c => c.Content.Localizations, m => m.MapFrom(c => c.Content));
        }

        private void Partner()
        {
            CreateMap<Partner, PartnerModel>()
                .ForMember(c => c.Image, m => m.MapFrom(c => c.AppImage)).ReverseMap();

            
        }

    }
}
