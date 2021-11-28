using CmsA.Service.Inteface.Cms;
using Microsoft.AspNetCore.Mvc;

namespace CmsA.Web.Areas.admin.Controllers
{
    [Area("admin")]
    public class MessageController : Controller
    {
        private readonly IMessage _messageServie;

        public MessageController(IMessage messageServie)
        {
            _messageServie = messageServie;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult View()
        {
            return View();
        }
    }
}
