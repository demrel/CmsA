using AutoMapper;
using CmsA.Data.Model;
using CmsA.Data.Model.Cms;
using CmsA.Data.Model.Localization;
using CmsA.Web.Models;
using CmsA.Web.Models.Banner;
using CmsA.Web.Models.Localizations;
using CmsA.Web.Models.Message;
using CmsA.Web.Models.OtherSitePref;
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
            OtherSettings();
            Message();

        }

        private void Message()
        {
            CreateMap<Message, MessageModel>().ReverseMap();

        }

        private void Page()
        {
            CreateMap<Page, PageModel>()
                    .ForMember(c => c.Title, m => m.MapFrom(c => c.Title.Localizations.OrderBy(c => c.CultureCode)))
                       .ForMember(c => c.Description, m => m.MapFrom(c => c.Description.Localizations.OrderBy(c => c.CultureCode)))
                    .ForMember(c => c.Content, m => m.MapFrom(c => c.Content.Localizations.OrderBy(c => c.CultureCode)));




            CreateMap<PageModel, Page>()
                   .ForPath(c => c.Title.Localizations, m => m.MapFrom(c => c.Title))
                   .ForPath(c => c.Description.Localizations, m => m.MapFrom(c => c.Description))
                    .ForPath(c => c.Content.Localizations, m => m.MapFrom(c => c.Content))

                      .ForPath(c => c.Title.Id, m => m.MapFrom(c => c.Title.FirstOrDefault().LocalizationSetId))
                      .ForPath(c => c.Description.Id, m => m.MapFrom(c => c.Description.FirstOrDefault().LocalizationSetId))
                      .ForPath(c => c.Content.Id, m => m.MapFrom(c => c.Content.FirstOrDefault().LocalizationSetId));


        }

        private void Banner()
        {
            CreateMap<Banner, BanerModel>()
                 .ForMember(c => c.Title, m => m.MapFrom(c => c.Title.Localizations.OrderBy(c => c.CultureCode)))
                  .ForMember(c => c.Url, m => m.MapFrom(c => c.Url.Localizations.OrderBy(c => c.CultureCode)))
                 .ForMember(c => c.Image, m => m.MapFrom(c => c.AppImage));

            CreateMap<BanerModel, Banner>()
                .ForPath(c => c.Title.Localizations, m => m.MapFrom(c => c.Title))
                .ForPath(c => c.Url.Localizations, m => m.MapFrom(c => c.Url))

                   .ForPath(c => c.Title.Id, m => m.MapFrom(c => c.Title.FirstOrDefault().LocalizationSetId))
                   .ForPath(c => c.Url.Id, m => m.MapFrom(c => c.Url.FirstOrDefault().LocalizationSetId));
        }

        private void Post()
        {
            CreateMap<Post, PostModel>()
                .ForMember(c => c.PageName, m => m.MapFrom(c => c.Page.Name))
                .ForMember(c => c.ParentName, m => m.MapFrom(c => c.Parent.Name))
                .ForMember(c => c.Title, m => m.MapFrom(c => c.Title.Localizations.OrderBy(c => c.CultureCode)))
                .ForMember(c => c.Description, m => m.MapFrom(c => c.Description.Localizations.OrderBy(c => c.CultureCode)))
                .ForMember(c => c.Pdf, m => m.MapFrom(c => c.Pdf.Localizations.OrderBy(c => c.CultureCode)))
                .ForMember(c => c.Content, m => m.MapFrom(c => c.Content.Localizations.OrderBy(c => c.CultureCode)));



            CreateMap<PostModel, Post>()
                   .ForPath(c => c.Title.Localizations, m => m.MapFrom(c => c.Title))
                   .ForPath(c => c.Description.Localizations, m => m.MapFrom(c => c.Description))
                   .ForPath(c => c.Pdf.Localizations, m => m.MapFrom(c => c.Pdf))
                   .ForPath(c => c.Content.Localizations, m => m.MapFrom(c => c.Content))

                       .ForPath(c => c.Content.Id, m => m.MapFrom(c => c.Content.FirstOrDefault().LocalizationSetId))
                       .ForPath(c => c.Title.Id, m => m.MapFrom(c => c.Title.FirstOrDefault().LocalizationSetId))
                       .ForPath(c => c.Pdf.Id, m => m.MapFrom(c => c.Pdf.FirstOrDefault().LocalizationSetId))
                       .ForPath(c => c.Description.Id, m => m.MapFrom(c => c.Description.FirstOrDefault().LocalizationSetId));
        }

        private void Partner()
        {
            CreateMap<Partner, PartnerModel>()
                .ForMember(c => c.Image, m => m.MapFrom(c => c.AppImage)).ReverseMap();
        }

        private void OtherSettings()
        {
            CreateMap<MissionVission, MissionVissionModel>()
                .ForMember(c => c.Mission, m => m.MapFrom(c => c.Mission.Localizations.OrderBy(c => c.CultureCode)))
                .ForMember(c => c.Vission, m => m.MapFrom(c => c.Vission.Localizations.OrderBy(c => c.CultureCode)))
                .ForMember(c => c.MissionTitle, m => m.MapFrom(c => c.MissionTitle.Localizations.OrderBy(c => c.CultureCode)))
                .ForMember(c => c.VissionTitle, m => m.MapFrom(c => c.VissionTitle.Localizations.OrderBy(c => c.CultureCode)));


            CreateMap<MissionVissionModel, MissionVission>()
              .ForPath(c => c.Mission.Localizations, m => m.MapFrom(c => c.Mission))
              .ForPath(c => c.Vission.Localizations, m => m.MapFrom(c => c.Vission))
              .ForPath(c => c.MissionTitle.Localizations, m => m.MapFrom(c => c.MissionTitle))
              .ForPath(c => c.VissionTitle.Localizations, m => m.MapFrom(c => c.VissionTitle))

                    .ForPath(c => c.Mission.Id, m => m.MapFrom(c => c.Mission.FirstOrDefault().LocalizationSetId))
                    .ForPath(c => c.Vission.Id, m => m.MapFrom(c => c.Vission.FirstOrDefault().LocalizationSetId))
                    .ForPath(c => c.MissionTitle.Id, m => m.MapFrom(c => c.MissionTitle.FirstOrDefault().LocalizationSetId))
                    .ForPath(c => c.VissionTitle.Id, m => m.MapFrom(c => c.VissionTitle.FirstOrDefault().LocalizationSetId));

            CreateMap<Viedo, VideoModel>()
               .ForMember(c => c.URl, m => m.MapFrom(c => c.URl.Localizations.OrderBy(c => c.CultureCode)))
              .ForMember(c => c.Title, m => m.MapFrom(c => c.Title.Localizations.OrderBy(c => c.CultureCode)))
              .ForMember(c => c.Description, m => m.MapFrom(c => c.Description.Localizations.OrderBy(c => c.CultureCode)))
                .ForMember(c => c.VideoImage, m => m.MapFrom(c => c.VideoImage)).ReverseMap();


            CreateMap<VideoModel, Viedo>()
              .ForPath(c => c.URl.Localizations, m => m.MapFrom(c => c.URl))
              .ForPath(c => c.Title.Localizations, m => m.MapFrom(c => c.Title))
               .ForPath(c => c.Description.Localizations, m => m.MapFrom(c => c.Description))

                  .ForPath(c => c.URl.Id, m => m.MapFrom(c => c.URl.FirstOrDefault().LocalizationSetId))
                  .ForPath(c => c.Title.Id, m => m.MapFrom(c => c.Title.FirstOrDefault().LocalizationSetId))
                  .ForPath(c => c.Description.Id, m => m.MapFrom(c => c.Description.FirstOrDefault().LocalizationSetId));
            ;

        }

    }
}
