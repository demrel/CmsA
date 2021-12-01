using AutoMapper;
using CmsA.Service.Inteface.Cms;
using Microsoft.AspNetCore.Mvc;

namespace CmsA.Web.Areas.admin.Controllers
{
    public class MessageController : BaseAdminController
    {
        private readonly IMessage _messageServie;

        public MessageController(IMapper mapper, IMessage messageServie) : base(mapper)
        {
            _messageServie = messageServie;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SeeMessage()
        {
            return View();
        }
    }
}
