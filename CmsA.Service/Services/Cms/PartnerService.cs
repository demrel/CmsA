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

public class PartnerService : BaseServiceWithImage<Partner>,IPartner
{
    public PartnerService(AppDBContext context) : base(context)
    {
    }

    public IEnumerable<LPartner> GetLocalizedAll(string cultureCode)
    {
        throw new NotImplementedException();
    }

    public Task<LPartner> GetLocalizedById(string id, string cultureCode)
    {
        throw new NotImplementedException();
    }

    public Task<LPartner> GetLocalizedByName(string id, string cultureCode)
    {
        throw new NotImplementedException();
    }
}

