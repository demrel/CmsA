
using CmsA.Web.Models.Localizations;

namespace CmsA.Web.Models.Posts;

    public class PostModel : BaseModelWithImage
    {
    public List<LocalizationModel> Title { get; set; }
    public List<LocalizationModel> Description { get; set; }
    public List<LocalizationModel> Content { get; set; }
    public List<AppImageModel> Gallery { get; set; }
  
    public List<LocalizationModel> Pdf { get; set; }
    public string ParentID { get; set; }
    public string PageId { get; set; }
    public string PageName { get; set; }

    public string ParentName { get; set; }
    public bool Stared { get; set; }
    public bool ShowInMenu { get; set; }
    public int MenuPosition { get; set; }


}

