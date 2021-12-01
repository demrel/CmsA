using AutoMapper;
using CmsA.Service.Inteface;
using CmsA.Service.Inteface.Localizations;
using CmsA.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace CmsA.Web.Areas.admin.Controllers
{
 
    [Area("admin")]
    public class BaseAdminController: Controller
    {
       protected readonly IMapper _mapper;
       protected readonly IImageFile _imageService;
       protected readonly IWebHostEnvironment _env;
    
        public BaseAdminController(IMapper mapper, IImageFile imageService, IWebHostEnvironment env)
        {
            _mapper = mapper;
            _imageService = imageService;
            _env = env;
        }

        public BaseAdminController(IMapper mapper)
        {
            _mapper = mapper;

        }

      

     

    }
}
