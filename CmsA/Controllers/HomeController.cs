using CmsA.Models;
using CmsA.Service.Inteface.Cms;
using CmsA.Web.Controllers;
using CmsA.Web.Models.Front;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CmsA.Controllers;

public class HomeController : BaseHomeController
{
    private readonly ILogger<HomeController> _logger;
    private readonly IBanner _bannerService;
    private readonly IPage _pageService;
    private readonly IPost _postService;

    public HomeController(ILogger<HomeController> logger, IBanner bannerService, IPost postService, IPage pageService)
    {
        _logger = logger;
        _bannerService = bannerService;
        _postService = postService;
        _pageService = pageService;
    }

    public async Task<IActionResult> Index()
    {
        var cultureCode = GetCulture();
       var banners= _bannerService.GetLocalizedAll(cultureCode);
        var service =await _pageService.GetLocalizedByName("service", cultureCode);
       service.LPosts=_postService.GetLocalizedByName
        HomeVM model = new()
        {
            Banners = banners,
            Service= service,
        };
        return View(model);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
