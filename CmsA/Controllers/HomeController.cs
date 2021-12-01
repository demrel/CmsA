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
    private readonly IPartner _partnerService;


    public HomeController(ILogger<HomeController> logger, IBanner bannerService, IPost postService, IPage pageService, IPartner partnerService)
    {
        _logger = logger;
        _bannerService = bannerService;
        _postService = postService;
        _pageService = pageService;
        _partnerService = partnerService;
    }

    public async Task<IActionResult> Index()
    {
        var cultureCode = GetCulture();
        var banners = _bannerService.GetLocalizedAll(cultureCode);
     
        var service = await _pageService.GetLocalizedByName("service", cultureCode);
        service.LPosts = _postService.GetLocalizedAllStaredByPage("service", cultureCode);
     
        var certificate = await _pageService.GetLocalizedByName("certificate", cultureCode);
        certificate.LPosts = _postService.GetLocalizedAllStaredByPage("certificate", cultureCode);
     
        var project = await _pageService.GetLocalizedByName("project", cultureCode);
        project.LPosts = _postService.GetLocalizedAllStaredByPage("project", cultureCode);
        var partners =await _partnerService.GetAll();
        HomeVM model = new()
        {
            Banners = banners,
            Service = service,
            Certificate = certificate,
            Project = project,
            Partners= partners,
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
