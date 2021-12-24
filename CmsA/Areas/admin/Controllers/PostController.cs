using AutoMapper;
using CmsA.Data.Model;
using CmsA.Data.Model.Cms;
using CmsA.Service.Inteface;
using CmsA.Service.Inteface.Cms;
using CmsA.Service.Inteface.Localizations;
using CmsA.Service.Model;
using CmsA.Web.Models;
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
            data.Pdf = _postService.AddFile(model.Pdf, _env.WebRootPath + "/file/docs/");
            _postService.Create(data);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Update(string id)
        {
            var data = await _postService.GetById(id);
            var pagelist = await _pageService.GetMinimal();
            PostAddVM model = new()
            {
                Pages = new SelectList(pagelist, nameof(SelectListItem.Id), nameof(SelectListItem.Name),data.PageId),
                Add = _mapper.Map<PostModel>(data),
                Cultures = _cultureService.GetAll(),
            };

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Update(PostAddVM model)
        {
            var data = _mapper.Map<Post>(model.Add);
            data.Pdf =await _postService.UpdateFile(model.Pdf, _env.WebRootPath + "/file/docs/",data.Id);
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
            var post = await _postService.GetById(id);
            var data = await _postService.GetGallery(id);
            PostGalleryVM model = new()
            {
                Images = _mapper.Map<List<AppImageModel>>(data),
                PostId=id,
                PostName=post.Name,
            };
            return View(model);
        }

        [HttpPost]
        public  IActionResult AddImageToGallery(PostGalleryVM model)
        {
          var img=  _imageService.Add(model.Image, _env.WebRootPath + "/images/post/");
          _postService.AddImageToGallery(img, model.PostId);
          return RedirectToAction("Gallery", new { Id = model.PostId });
        }

        [HttpGet]
        public  IActionResult DeleteImage(int id,string postId)
        {
            _imageService.Delete(id);
            return RedirectToAction("Gallery", new { Id = postId });
        }

        [HttpGet]
        public async Task<IActionResult> SetUnsetMain(int id, string postId)
        {
            await _postService.SetUnsetMain(id);
            return RedirectToAction("Gallery", new { Id = postId });
        }

        [HttpGet]
        public async Task<IActionResult> AddChilde(string id)
        {
           var data =   await _postService.GetMinimal(id);
            if (data == null) return NotFound();
            PostAddVM model = new();
            model.Add = new ();
            model.Add.PageId = data.PageId;
            model.Add.ParentID = data.Id;
            model.Cultures = _cultureService.GetAll();
            return View(model);
        }

    }
}
