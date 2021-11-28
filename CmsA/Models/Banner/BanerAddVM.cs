using Microsoft.AspNetCore.Http;

namespace CmsA.Web.Models.Banner;

    public class BanerAddVM :BaseAddVM
    {
        public BanerModel Add { get; set; }
        public IFormFile Image { get; set; }

    }

