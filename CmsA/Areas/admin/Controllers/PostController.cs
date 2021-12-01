using AutoMapper;
using CmsA.Data.Model;
using CmsA.Data.Model.Cms;
using CmsA.Service.Inteface;
using CmsA.Service.Inteface.Cms;
using CmsA.Service.Inteface.Localizations;
using CmsA.Service.Model;
using CmsA.Web.Models.Posts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SelectListItem = CmsA.Service.Model.SelectListItem;

namespace CmsA.Web.Areas.admin.Controllers
{
    public class PostController : BaseAdminController
    {
        private readonly IPost _postService;
        private readonly IPage _pageService;
        protected readonly ICulture _cultureService;

        public PostController(IMapper mapper, IImageFile imageService, IWebHostEnvironment env, ICulture cultureService, IPost postService, IPage pageService) : base(mapper, imageService, env)
        {
            _postService = postService;
            _pageService = pageService;
            _cultureService = cultureService;
        }
        public async Task<IActionResult> Index()
        {
            var data = await _postService.GetAll();
            PostIndexVM model = new()
            {
                Posts = _mapper.Map<List<PostModel>>(data),
            };

            return View(model);
        }
        [HttpGet]
        public  async Task<IActionResult> Add()
        {

            var data = await _pageService.GetMinimal();
            PostAddVM model = new()
            {
                Pages = new SelectList(data, nameof(SelectListItem.Id), nameof(SelectListItem.Name)),
                Cultures = _cultureService.GetAll(),
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Add(PostAddVM model)
        {
            var data = _mapper.Map<Post>(model.Add);
            _postService.Create(data);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Update(string id)
        {
            var data = await _postService.GetById(id);
            PostAddVM model = new()
            {
                Add = _mapper.Map<PostModel>(data),
                Cultures = _cultureService.GetAll(),
            };

            return View(model);
        }
        [HttpPost]
        public IActionResult Update(PostAddVM model)
        {
            var data = _mapper.Map<Post>(model.Add);
            _postService.Update(data);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            var data = await _postService.GetById(id);
            if (data == null) return NotFound();

            //_imageService.Delete(data.AppImageId);
            _postService.Delete(data);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Gallery(string id)
        {
            var data = await _postService.GetGallery(id);

            return View(data);
        }

    }
}
