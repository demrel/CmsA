using CmsA.Data.Model;
using CmsA.Data.Model.Cms;
using CmsA.Service.Inteface.BaseInterface;
using CmsA.Service.Model.Cms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CmsA.Service.Inteface.Cms
{
    public interface IPost : IBase<Post>
    {
        Task<List<AppImage>> GetGallery(string id);
        void AddImageToGallery(AppImage image, string PostId);
        Task SetUnsetMain(int ImageId);
        IEnumerable<LPost> GetLocalizedAllByPage(string name, string cultureCode);
        IEnumerable<LPost> GetLocalizedAllStaredByPage(string name, string cultureCode);
        Task<LPost> GetLocalizedByName(string name, string cultureCode);
    }
}
