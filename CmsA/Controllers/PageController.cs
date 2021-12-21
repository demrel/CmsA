using CmsA.Service.Inteface.Cms;
using CmsA.Web.Models.Front;
using Microsoft.AspNetCore.Mvc;

namespace CmsA.Web.Controllers
{
    public class PageController : BaseHomeController
    {
        private readonly IPage _pageService;
        private readonly IPost _postService;

        public PageController(IPage pageService, IPost postService)
        {
            _pageService = pageService;
            _postService = postService;
        }

        [HttpGet("/{controller}/{name}")]
        public async Task<IActionResult> Index(string name)
        {
            var cultureCode = GetCulture();
            var page = await _pageService.GetLocalizedByName(name, cultureCode);
            if (page == null) return NotFound();
            page.LPosts = _postService.GetLocalizedAllByPage(name, cultureCode);
            PageVM model=new PageVM() { Page=page};
            return View(model);
        }

        [HttpGet("/{controller}/{pagename}/{name}")]
        public async Task<IActionResult> Post(string pagename, string name)
        {
            var cultureCode = GetCulture();
            var post = await _postService.GetLocalizedByName(name, cultureCode);
            if (post == null) return NotFound();

            var childePosts = _postService.GetChildePost(post.Id, cultureCode);
          
            PostVM model = new PostVM() { Post = post,PageName=pagename,ChildePosts=childePosts };
            return View(model);
        }
    }
}
