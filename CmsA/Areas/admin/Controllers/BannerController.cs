using AutoMapper;
using CmsA.Data.Model;
using CmsA.Data.Model.Cms;
using CmsA.Service.Inteface;
using CmsA.Service.Inteface.Cms;
using CmsA.Service.Inteface.Localizations;
using CmsA.Web.Models.Banner;
using Microsoft.AspNetCore.Mvc;

namespace CmsA.Web.Areas.admin.Controllers
{
    public class BannerController : BaseCulturalController<BanerAddVM>
    {
        private readonly IBanner _bannerService;
        public BannerController(IMapper mapper, IImageFile imageService, IWebHostEnvironment env, ICulture cultureService, IBanner bannerService) : base(mapper, imageService, env, cultureService)
        {
            _bannerService = bannerService;
        }

        public async Task<IActionResult> Index()
        {
            var data =await _bannerService.GetAll();
            var model = new BannerIndexVM()
            {
                Banners = _mapper.Map<List<BanerModel>>(data),
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Add(BanerAddVM model)
        {
            Banner data = _mapper.Map<Banner>(model.Add);
            AppImage img = _imageService.Add(model.Image, _env.WebRootPath + "/images/banner/");
            data.AppImage = img;
            _bannerService.Create(data);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Update(BanerAddVM model)
        {
            var data = _mapper.Map<Banner>(model.Add);
            AppImage img = _imageService.Edit(model.Image, _env.WebRootPath + "/images/banner/", model.Add.Image.Id);
            data.AppImage = img;
            _bannerService.Update(data);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Update(string id)
        {
            var data = await _bannerService.GetById(id);
            if (data == null) return NotFound();
            BanerAddVM model = new()
            {
                Add = _mapper.Map<BanerModel>(data),
                Cultures = _cultureService.GetAll(),
            };

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
             await _bannerService.Delete(id);
            return RedirectToAction("Index");
        }


    }
}
