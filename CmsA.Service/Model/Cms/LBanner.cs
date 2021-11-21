using CmsA.Service.Model.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CmsA.Service.Model.Cms
{
    public class LBanner : LBaseImage
    {
        public virtual string Url { get; set; }
        public virtual string Title { get; set; }
        public bool IsActive { get; set; }
    }
}
