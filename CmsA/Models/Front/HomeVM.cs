using CmsA.Service.Model.Cms;

namespace CmsA.Web.Models.Front
{
    public class HomeVM
    {
        public IEnumerable<LBanner> Banners { get; set; }
        public LPage Service { get; set; }
        public LPage Certificate { get; set; }
        public LPage Project { get; set; }

    }
}
