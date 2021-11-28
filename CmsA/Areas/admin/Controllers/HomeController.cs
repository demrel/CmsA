using Microsoft.AspNetCore.Mvc;

namespace CmsA.Web.Areas.admin.Controllers
{
    [Area("admin")]
    public class HomeController : Controller
    {
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
