using CmsA.Service.Inteface;
using CmsA.Service.Inteface.Cms;

using Microsoft.AspNetCore.Mvc;

namespace CmsA.Web.Areas.admin.Controllers
{
    [Area("admin")]
    public class HomeController : Controller
    {
        private readonly IMission _missionService;
        private readonly IVideo _videoService;
        private readonly ISiteSetting _siteSetttingService;

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Video()
        {
            return View();
        }

        public IActionResult MissionVission()
        {
            return View();
        }

        public IActionResult Setting()
        {
            return View();
        }
    }
}
