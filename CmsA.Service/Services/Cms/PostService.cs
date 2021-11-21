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

public class PostService : BaseServiceWithImage<Post> ,IPost
{
    public PostService(AppDBContext context) : base(context)
    {
    }

    public IEnumerable<LPost> GetLocalizedAll(string cultureCode)
    {
        throw new NotImplementedException();
    }

    public Task<LPost> GetLocalizedById(string id, string cultureCode)
    {
        throw new NotImplementedException();
    }

    public Task<LPost> GetLocalizedByName(string id, string cultureCode)
    {
        throw new NotImplementedException();
    }
}

