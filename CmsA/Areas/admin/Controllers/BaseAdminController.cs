using AutoMapper;
using CmsA.Service.Inteface;
using CmsA.Service.Inteface.Localizations;
using CmsA.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace CmsA.Web.Areas.admin.Controllers
{
 
    [Area("admin")]
    public class BaseAdminController<T> : Controller where T : BaseAddVM 
    {
       protected readonly IMapper _mapper;
       protected readonly IImageFile _imageService;
       protected readonly IWebHostEnvironment _env;
       protected readonly ICulture _cultureService;
        public BaseAdminController(IMapper mapper, IImageFile imageService, IWebHostEnvironment env, ICulture cultureService)
        {
            _mapper = mapper;
            _imageService = imageService;
            _env = env;
            _cultureService = cultureService;
        }

        public BaseAdminController(IMapper mapper, ICulture cultureService)
        {
            _mapper = mapper;
            _cultureService = cultureService;
        }

        [HttpGet]
        public  IActionResult Add()
        {
           var cultures= _cultureService.GetAll();
            T model = (T)Activator.CreateInstance(typeof(T));
            model.Cultures = cultures;
            return View(model);
        }

     

    }
}
