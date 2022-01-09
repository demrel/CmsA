using CmsA.Data.Model.Cms;
using CmsA.Service.Inteface.Cms;
using CmsA.Web.Models.Front;
using Microsoft.AspNetCore.Mvc;

namespace CmsA.Web.Controllers
{
    public class ContactController : BaseHomeController
    {
        private readonly IPage _pageService;
        private readonly IPost _postService;
        private readonly IMessage _mesagService;

        public ContactController(IPage pageService, IPost postService, IMessage mesagService)
        {
            _pageService = pageService;
            _postService = postService;
            _mesagService = mesagService;
        }

        [HttpGet("page/contact")]
        public async Task<IActionResult> Index()
        {
            var cultureCode = GetCulture();
            var page = await _pageService.GetLocalizedByName("contact", cultureCode);
            if (page == null) return NotFound();
            page.LPosts = _postService.GetLocalizedAllByPage("contact", cultureCode);
            ContactVM model = new () { Page = page };
            return View(model);
        }

        public IActionResult SendMessage(ContactVM model)
        {
            _mesagService.Create(new Message() { Content=model.Message,Name=model.Title,Email=model.Email,FullName= model.FullName,PhoneNumber=model.Phone});
            return RedirectToAction("Index");
        }
    }
}
