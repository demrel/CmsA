using CmsA.Data.Model.Localization;


namespace CmsA.Data.Model.Cms;

public class MissionVission
{
    public int Id { get; set; }
    public int MissionTitleId { get; set; }
    public virtual LocalizationSet MissionTitle { get; set; }
    public int MissionId { get; set; }
    public virtual LocalizationSet Mission { get; set; }
    public int VissionTitleId { get; set; }
    public virtual LocalizationSet VissionTitle { get; set; }
    public int VissionId { get; set; }
    public virtual LocalizationSet Vission { get; set; }
}

