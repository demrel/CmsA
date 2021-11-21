using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CmsA.Data.Model.Base;

    public class BaseModelWithImage : BaseModel
    {
        public string AppImageId { get; set; }
        public AppImage AppImage { get; set; }
    }

