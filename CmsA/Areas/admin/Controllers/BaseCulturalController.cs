using AutoMapper;
using CmsA.Service.Inteface;
using CmsA.Service.Inteface.Localizations;
using CmsA.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace CmsA.Web.Areas.admin.Controllers
{
    public class BaseCulturalController<T> : BaseAdminController   where T : BaseAddVM
    {
        protected readonly ICulture _cultureService;

        public BaseCulturalController(IMapper mapper, IImageFile imageService, IWebHostEnvironment env, ICulture cultureService) : base(mapper, imageService, env)
        {
            _cultureService = cultureService;
        }

        public BaseCulturalController(IMapper mapper, ICulture cultureService) : base(mapper)
        {
            
            _cultureService = cultureService;
        }

        [HttpGet]
        public virtual IActionResult Add()
        {
            var cultures = _cultureService.GetAll();
            T model = (T)Activator.CreateInstance(typeof(T));
            model.Cultures = cultures;
            return View(model);
        }
    }
}
