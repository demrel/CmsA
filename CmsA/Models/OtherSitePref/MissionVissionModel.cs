using CmsA.Web.Models.Localizations;

namespace CmsA.Web.Models.OtherSitePref
{
    public class MissionVissionModel : BaseAddVM
    {
        public int Id { get; set; }
        public List<LocalizationModel> MissionTitle { get; set; }
        public List<LocalizationModel> Mission { get; set; }
        public List<LocalizationModel> VissionTitle { get; set; }
        public List<LocalizationModel> Vission { get; set; }
    }
}
