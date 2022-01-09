using CmsA.Data.Enums;
using CmsA.Service.Model.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CmsA.Service.Model.Cms
{
    public class LPost : LBaseImage
    {

        public string  Title { get; set; }
        public string  Description { get; set; }
        public string  Content { get; set; }
        public List<string> Gallery { get; set; }
        public string PDf { get; set; }

        public string PageId { get; set; }
        public string PageName { get; set; }
        public string PageTitle { get; set; }


        public bool Stared { get; set; }

    }
}
