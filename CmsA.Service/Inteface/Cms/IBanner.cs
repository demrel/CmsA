using CmsA.Data.Model.Cms;
using CmsA.Service.Inteface.BaseInterface;
using CmsA.Service.Model.Cms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CmsA.Service.Inteface.Cms;

    public interface IBanner : IBase<Banner>,ITranslate<LBanner>
    {
    }
