using CmsA.Data.Model.Cms;
using CmsA.Service.Model.Cms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CmsA.Service.Inteface
{
    public interface IVideo
    {
        void Update(Viedo video);
        Task<LVideo> GetLocalized(string cultureCode);
        Task<Viedo> Get();
    }
}
