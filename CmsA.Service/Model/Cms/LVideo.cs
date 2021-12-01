using CmsA.Service.Model.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CmsA.Service.Model.Cms
{
    public class LVideo : LBaseImage
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string URl { get; set; }

    }
}
