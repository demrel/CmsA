using CmsA.Data.Model;
using Microsoft.AspNetCore.Http;

namespace CmsA.Service.Inteface
{
    public interface IImageFile
    {
        AppImage Add(IFormFile formFile, string path);
        List<AppImage> AddAll(List<IFormFile> formFiles, string path);
        void Delete(int id);
        AppImage Edit(IFormFile formFile, string path, int id);
        AppImage GetById(int id);
        void SaveChanges();
        void DeleteRange(List<AppImage> images);
    }
}
