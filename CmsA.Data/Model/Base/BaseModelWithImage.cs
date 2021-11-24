using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CmsA.Data.Model.Base;

    public class BaseModelWithImage : BaseModel
    {
        public int AppImageId { get; set; }
        public virtual AppImage AppImage { get; set; }
    }

