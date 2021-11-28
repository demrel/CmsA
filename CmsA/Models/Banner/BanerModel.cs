
using CmsA.Web.Models.Localizations;

namespace CmsA.Web.Models.Banner;

public class BanerModel : BaseModelWithImage
{
    public List<LocalizationModel> Title { get; set; }
    public List<LocalizationModel> Url { get; set; }
}

