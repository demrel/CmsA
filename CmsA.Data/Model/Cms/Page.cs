using CmsA.Data.Enums;
using CmsA.Data.Model.Base;
using CmsA.Data.Model.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CmsA.Data.Model.Cms;

public class Page : BaseModel
{
    public int TitleId { get; set; }
    public virtual LocalizationSet Title { get; set; }
    public int DescriptionId { get; set; }
    public virtual LocalizationSet Description { get; set; }
    public int ContentId { get; set; }
    public virtual LocalizationSet Content { get; set; }
    public int VideoUrlId { get; set; }
    public virtual List<KeyValueHelper> KeyValueHelpers { get; set; }
    public virtual List<Post> Posts { get; set; }
    public PostType PostType { get; set; }
 //   public bool ShowInMain { get; set; }
}

