
using CmsA.Web.Models.Pages;

namespace CmsA.Web.Models.Posts;

public class PostIndexVM
{
    public List<PostModel> Posts { get; set; }
    public string PageName { get; set; }
    public string PageId { get; set; }


}
