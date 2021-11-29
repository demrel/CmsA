using CmsA.Data.Enums;
using CmsA.Service.Model.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CmsA.Service.Model.Cms
{
    public class LPage : LBase
    {
        public  string Title { get; set; }
        public  string Description { get; set; }
        public string  Content { get; set; }
        public string  VideoUrl { get; set; }
        public virtual IEnumerable<LPost> LPosts { get; set; }

        public PostType PostType { get; set; }

    }
}
