using CmsA.Data.Enums;
using CmsA.Web.Models.Localizations;

namespace CmsA.Web.Models.Pages;

public class PageModel : BaseModelWithImage
{
    public  List<LocalizationModel> Title { get; set; }
    public  List<LocalizationModel> Description { get; set; }
    public  List<LocalizationModel> Content { get; set; }
    public PostType PostType { get; set; }
    public bool ShowInMain { get; set; }
}

