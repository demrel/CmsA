using CmsA.Data.Model.Base;
using CmsA.Data.Model.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CmsA.Data.Model.Cms;

public class Post : BaseModelWithImage
{
    public int TitleId { get; set; }
    public virtual LocalizationSet Title { get; set; }
    public int DescriptionId { get; set; }
    public virtual LocalizationSet Description { get; set; }
    public int ContentId { get; set; }
    public virtual LocalizationSet Content { get; set; }
    public List<AppImage> Gallery { get; set; }

    public string PageId { get; set; }
    public Page Page { get; set; }
    public bool Stared { get; set; }

}

