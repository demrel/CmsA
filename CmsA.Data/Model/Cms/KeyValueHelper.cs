using CmsA.Data.Model.Base;
using CmsA.Data.Model.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CmsA.Data.Model.Cms;

public class KeyValueHelper : BaseModel
{
    public int ValueId { get; set; }
    public virtual LocalizationSet Value { get; set; }
    public string PageId { get; set; }
    public Page Page { get; set; }
}

