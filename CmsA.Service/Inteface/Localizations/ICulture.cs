using CmsA.Data.Model.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CmsA.Service.Inteface.Localizations;

    public interface ICulture
    {
        IEnumerable<Culture> GetAll();
    }

