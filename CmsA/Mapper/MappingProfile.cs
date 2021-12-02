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
                .ForMember(c => c.PageName, m => m.MapFrom(c => c.Page.Name))
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

        private void OtherSettings()
        {
            CreateMap<MissionVission, MissionVissionModel>()
                 .ForMember(c => c.Mission, m => m.MapFrom(c => c.Mission.Localizations))
                .ForMember(c => c.Vission, m => m.MapFrom(c => c.Vission.Localizations))
                .ForMember(c => c.MissionTitle, m => m.MapFrom(c => c.MissionTitle.Localizations))
                .ForMember(c => c.VissionTitle, m => m.MapFrom(c => c.VissionTitle.Localizations));


            CreateMap<MissionVissionModel, MissionVission>()
              .ForPath(c => c.Mission.Localizations, m => m.MapFrom(c => c.Mission))
              .ForPath(c => c.Vission.Localizations, m => m.MapFrom(c => c.Vission))
               .ForPath(c => c.MissionTitle.Localizations, m => m.MapFrom(c => c.MissionTitle))
                .ForPath(c => c.VissionTitle.Localizations, m => m.MapFrom(c => c.VissionTitle));

            CreateMap<Viedo, VideoModel>()
               .ForMember(c => c.URl, m => m.MapFrom(c => c.URl.Localizations))
              .ForMember(c => c.Title, m => m.MapFrom(c => c.Title.Localizations))
              .ForMember(c => c.Description, m => m.MapFrom(c => c.Description.Localizations))
                .ForMember(c => c.VideoImage, m => m.MapFrom(c => c.VideoImage)).ReverseMap();


            CreateMap<VideoModel, Viedo>()
              .ForPath(c => c.URl.Localizations, m => m.MapFrom(c => c.URl))
              .ForPath(c => c.Title.Localizations, m => m.MapFrom(c => c.Title))
               .ForPath(c => c.Description.Localizations, m => m.MapFrom(c => c.Description));

        }

    }
}
