using CmsA.Service.Model.Cms;

namespace CmsA.Web.Models.Front
{
    public class PostVM
    {
        public LPost Post { get; set; }
        public IEnumerable<LPost> ChildePosts { get; set; }
        public string PageName { get; set; }
    }
}
