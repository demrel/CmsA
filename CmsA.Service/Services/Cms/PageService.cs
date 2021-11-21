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

public class PageService : BaseServiceWithImage<Page> ,IPage
{
    public PageService(AppDBContext context) : base(context)
    {
    }

    public IEnumerable<LPage> GetLocalizedAll(string cultureCode)
    {
        throw new NotImplementedException();
    }

    public Task<LPage> GetLocalizedById(string id, string cultureCode)
    {
        throw new NotImplementedException();
    }

    public Task<LPage> GetLocalizedByName(string id, string cultureCode)
    {
        throw new NotImplementedException();
    }
}

