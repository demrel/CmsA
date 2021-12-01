using CmsA.Data.Model.Cms;
using CmsA.Service.Model.Cms;
using CmsA.Web.Models.Partners;

namespace CmsA.Web.Models.Front
{
    public class HomeVM
    {
        public IEnumerable<LBanner> Banners { get; set; }
        public LPage Service { get; set; }
        public LPage Certificate { get; set; }
        public LPage Project { get; set; }
        public List<Partner> Partners { get; set; }
        public LMV MissionVission { get; set; }

        public LVideo Video { get; set; }

    }
}
