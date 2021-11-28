using CmsA.Data.Model.Localization;


namespace CmsA.Data.Model.Cms;

public class MissionVission
{
    public int Id { get; set; }
    public LocalizationSet MissionTitle { get; set; }
    public LocalizationSet Mission { get; set; }
    public LocalizationSet VissionTitle { get; set; }
    public LocalizationSet Vission { get; set; }
}

