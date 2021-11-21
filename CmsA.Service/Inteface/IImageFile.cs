using CmsA.Data.Model;
using Microsoft.AspNetCore.Http;

namespace CmsA.Service.Inteface
{
    public interface IImageFile
    {
        AppImage Add(IFormFile formFile, string path);
        List<AppImage> AddAll(List<IFormFile> formFiles, string path);
        void Delete(string id);
        AppImage Edit(IFormFile formFile, string path, string id);
        AppImage GetById(string id);
        void SaveChanges();
        void DeleteRange(List<AppImage> images);
    }
}
