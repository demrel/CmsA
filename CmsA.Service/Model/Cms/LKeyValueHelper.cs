using CmsA.Service.Model.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CmsA.Service.Model.Cms
{
    public class LKeyValueHelper : LBase
    {
        public string Value { get; set; }
        public string PageId { get; set; }
        public string PageName { get; set; }
    }
}
