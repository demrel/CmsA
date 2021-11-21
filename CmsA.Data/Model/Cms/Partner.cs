using CmsA.Data.Model.Base;
using CmsA.Data.Model.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CmsA.Data.Model.Cms;

public class Partner : BaseModelWithImage
{
    public string Url { get; set; }
    public int TitleId { get; set; }
    public virtual LocalizationSet Title { get; set; }   
}

