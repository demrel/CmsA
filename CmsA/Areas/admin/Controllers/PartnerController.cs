using AutoMapper;
using CmsA.Data.Model;
using CmsA.Data.Model.Cms;
using CmsA.Service.Inteface;
using CmsA.Service.Inteface.Cms;
using CmsA.Web.Models.Partners;
using Microsoft.AspNetCore.Mvc;

namespace CmsA.Web.Areas.admin.Controllers
{
    public class PartnerController : BaseAdminController
    {

        private readonly IPartner _partnerService;

        public PartnerController(IMapper mapper, IImageFile imageService, IWebHostEnvironment env, IPartner partnerService) : base(mapper, imageService, env)
        {
            _partnerService = partnerService;
        }

        public async Task<IActionResult> Index()
        {
            var data = await _partnerService.GetAll();
            PartnerIndexVM model = new()
            {
                Partners = _mapper.Map<List<PartnerModel>>(data),
            };

            return View(model);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Add(PartnerAddVM model)
        {
            var data = _mapper.Map<Partner>(model.Add);
            AppImage img = _imageService.Add(model.Image, _env.WebRootPath + "/images/partner/");
             data.AppImage = img;
            _partnerService.Create(data);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Update(string id)
        {
            var data = await _partnerService.GetById(id);
            PartnerAddVM model = new()
            {
                Add = _mapper.Map<PartnerModel>(data),
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Update(PartnerAddVM model)
        {
            var data = _mapper.Map<Partner>(model.Add);
            AppImage img = _imageService.Edit(model.Image, _env.WebRootPath + "/images/partner/", model.Add.Image.Id);
            data.AppImage = img;
            _partnerService.Update(data);
            return RedirectToAction("Index");
        }


        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            var data = await _partnerService.GetById(id);
            if (data == null) return NotFound();

            _imageService.Delete(data.AppImageId);
            _partnerService.Delete(data);

            return RedirectToAction("Index");
        }
    }
}
