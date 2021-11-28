using CmsA.Service.Model.Cms;

namespace CmsA.Web.Models.Front
{
    public class HomeVM
    {
        public IEnumerable<LBanner> Banners { get; set; }
        public LPage Service { get; set; }


    }
}
