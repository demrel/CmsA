﻿using CmsA.Data.Model;
using CmsA.Data.Model.Cms;
using CmsA.Data.Model.Localization;
using CmsA.Service.Inteface.BaseInterface;
using CmsA.Service.Model;
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
        IEnumerable<LPostMenu> GetLocaliezedNameByPage(string name, string cultureCode);
        IEnumerable<LPostMenu> GetLocaliezedNameByParent(string parentID, string cultureCode);
        IEnumerable<LPost> GetChildePost(string id, string cultureCode);
        Task<Post> GetMinimal(string id);
        LocalizationSet AddFile(List<PostFileModel> files, string path);
        Task<LocalizationSet> UpdateFile(List<PostFileModel> files, string path, string id);
        IEnumerable<LPost> Search(string search, string cultureCode);
        Task Delete(string PostId, string path);
        Task<List<Post>> GetAll(string id);
        Task ClearUnusedIds();
    }
}
