using AutoMapper;
using CmsA.Data.Model;
using CmsA.Data.Model.Cms;
using CmsA.Data.Model.Localization;
using CmsA.Web.Models;
using CmsA.Web.Models.Localizations;
using CmsA.Web.Models.Pages;

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
        }

        private void Page()
        {
            CreateMap<Page, PageModel>()
               .ForMember(c => c.VideoUrl, m => m.MapFrom(c => c.VideoUrl.Localizations))
               .ForMember(c => c.Title, m => m.MapFrom(c => c.Title.Localizations))
               .ForMember(c => c.Description, m => m.MapFrom(c => c.Description.Localizations))
               .ForMember(c => c.Content, m => m.MapFrom(c => c.Content.Localizations))
               .ForMember(c => c.Image, m => m.MapFrom(c => c.AppImage))
               ;



            CreateMap<PageModel, Page>()
              .ForPath(c => c.VideoUrl.Localizations, m => m.MapFrom(c => c.VideoUrl))
              .ForPath(c => c.Title.Localizations, m => m.MapFrom(c => c.Title))
              .ForPath(c => c.Description.Localizations, m => m.MapFrom(c => c.Description))
               .ForPath(c => c.Content.Localizations, m => m.MapFrom(c => c.Content));


        }

    }
}
