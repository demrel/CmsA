using AutoMapper;
using CmsA.Data.Model;
using CmsA.Data.Model.Cms;
using CmsA.Service.Inteface;
using CmsA.Service.Inteface.Cms;
using CmsA.Service.Inteface.Localizations;
using CmsA.Web.Models.OtherSitePref;
using Microsoft.AspNetCore.Mvc;

namespace CmsA.Web.Areas.admin.Controllers
{
    public class HomeController : BaseAdminController
    {
        private readonly IMission _missionService;
        private readonly IVideo _videoService;
        private readonly ISiteSetting _siteSetttingService;
        private readonly ICulture _cultureService;



        public HomeController(IMapper mapper, IImageFile imageService, IWebHostEnvironment env, ISiteSetting siteSetttingService, IMission missionService, IVideo videoService, ICulture cultureService)
            : base(mapper, imageService, env)
        {
            _siteSetttingService = siteSetttingService;
            _missionService = missionService;
            _videoService = videoService;
            _cultureService = cultureService;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Video()
        {
            var data = await _videoService.Get();
            var culture = _cultureService.GetAll();
            VideoModel model = new();
            if (data != null)
                model = _mapper.Map<VideoModel>(data);
            
            model.Cultures = culture;
            return View(model);
        }
        [HttpPost]
        public IActionResult UpdateVideo(VideoModel model)
        {
            var data = _mapper.Map<Viedo>(model);
            AppImage img = _imageService.Edit(model.Image, _env.WebRootPath + "/images/video/", model.VideoImage?.Id??0);
            data.VideoImage = img;
            _videoService.Update(data);

            return RedirectToAction("Video");
        }
        [HttpGet]
        public async Task<IActionResult> MissionVission()
        {
            var data = await _missionService.Get();
            var culture = _cultureService.GetAll();
            MissionVissionModel model = new();
            if (data!=null)
                model = _mapper.Map<MissionVissionModel>(data);
            
        
            model.Cultures = culture;
            return View(model);
        }

        [HttpPost]
        public IActionResult UpdateMissionVission(MissionVissionModel model)
        {
            var data=_mapper.Map<MissionVission>(model);
            _missionService.Update(data);
            return RedirectToAction("MissionVission");
        }
        [HttpGet]
        public IActionResult Setting()
        {
            return View();
        }

        [HttpPost]
        public IActionResult UpdateSetting()
        {
            return RedirectToAction("Setting");
        }
    }
}
