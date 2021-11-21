using CmsA.Data.Model.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CmsA.Data.Model;

    public class AppImage : BaseModel
    {
        public string Url { get; set; }
        public string Path { get; set; }
    }

