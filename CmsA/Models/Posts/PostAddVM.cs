
using CmsA.Service.Model;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CmsA.Web.Models.Posts;

public class PostAddVM : BaseAddVM
{
    public PostModel Add { get; set; }

    public SelectList Pages { get; set; }
    public IFormFile Image { get; set; }
    public List<PostFileModel> Pdf { get; set; }

    //public List<IFormFile> Gallery { get; set; }

}





