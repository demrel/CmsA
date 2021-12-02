using CmsA.Web.Models.Localizations;
using Microsoft.AspNetCore.Http;

namespace CmsA.Web.Models.OtherSitePref
{
    public class VideoModel : BaseAddVM
    {
        public int Id { get; set; }
        public AppImageModel VideoImage { get; set; }
        public List<LocalizationModel> URl { get; set; }
        public List<LocalizationModel> Title { get; set; }
        public List<LocalizationModel> Description { get; set; }
        public IFormFile Image { get; set; }
    }
}
