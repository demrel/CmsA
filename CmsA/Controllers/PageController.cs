using Microsoft.AspNetCore.Mvc;

namespace CmsA.Web.Controllers
{
    public class PageController : BaseHomeController
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("/{controller}/{name}/{post}")]
        public IActionResult Post(string name,string post)
        {
            return View();
        }
    }
}
