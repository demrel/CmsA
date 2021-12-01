using AutoMapper;
using CmsA.Data.Model;
using CmsA.Data.Model.Cms;
using CmsA.Service.Inteface;
using CmsA.Service.Inteface.Cms;
using CmsA.Service.Inteface.Localizations;
using CmsA.Web.Models.Pages;
using Microsoft.AspNetCore.Mvc;

namespace CmsA.Web.Areas.admin.Controllers;

public class PageController : BaseCulturalController<PageAddVM>
{
    private readonly IPage _pageService;
    public PageController(IMapper mapper, IImageFile imageService, IWebHostEnvironment env, IPage pageService,ICulture _cultureService) : base(mapper, imageService, env,_cultureService)
    {
        _pageService = pageService;
    }

    public async Task<IActionResult> Index()
    {
        var data = await _pageService.GetAll();
        PageIndexVM model = new() {
            Pages = _mapper.Map<List<PageModel>>(data),
        };

        return View(model);
    }

    [HttpPost]
    public  IActionResult Add(PageAddVM model)
    {
        var data = _mapper.Map<Page>(model.Add);
      //  AppImage img = _imageService.Add(model.Image, _env.WebRootPath + "/images/page/");
    //    data.AppImage = img;
        _pageService.Create(data);
        return RedirectToAction("Index");
    }
    [HttpGet]
    public async Task<IActionResult> Update(string id)
    {
        var data =await _pageService.GetById(id);
        PageAddVM model = new()
        {
            Add = _mapper.Map<PageModel>(data),
            Cultures=_cultureService.GetAll(),
        };
      
        return View(model);
    }
    [HttpPost]
    public IActionResult Update(PageAddVM model)  
    {
        var data = _mapper.Map<Page>(model.Add);
    //    AppImage img = _imageService.Edit(model.Image, _env.WebRootPath + "/images/page/", model.Add.Image.Id);
    //    data.AppImage = img;
        _pageService.Update(data);
        return RedirectToAction("Index");
    }

}
        
