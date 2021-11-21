using CmsA.Data.Model.Base;
using CmsA.Data.Model.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CmsA.Data.Model.Cms;

    public class Banner : BaseModelWithImage
    {

        public int UrlId { get; set; }
        public int TitleId { get; set; }
        public virtual LocalizationSet Url { get; set; }
        public virtual LocalizationSet Title { get; set; }
        public bool IsActive { get; set; }

    }

