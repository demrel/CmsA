using CmsA.Data.Data;
using CmsA.Data.Model.Cms;
using CmsA.Service.Inteface.Cms;
using CmsA.Service.Model.Cms;
using CmsA.Service.Services.BaseServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CmsA.Service.Services.Cms;

public class BannerService : BaseServiceWithImage<Banner>,IBanner
{
    public BannerService(AppDBContext context) : base(context)
    {
    }

    public IEnumerable<LBanner> GetLocalizedAll(string cultureCode)
    {
        throw new NotImplementedException();
    }

    public Task<LBanner> GetLocalizedById(string id, string cultureCode)
    {
        throw new NotImplementedException();
    }

    public Task<LBanner> GetLocalizedByName(string id, string cultureCode)
    {
        throw new NotImplementedException();
    }
}

