using CmsA.Data.Data;
using CmsA.Data.Model;
using CmsA.Service.Helper;
using CmsA.Service.Inteface;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CmsA.Service.Services;

    public class ImageFileService : IImageFile
    {
    private readonly AppDBContext _context;
    public ImageFileService(AppDBContext context)
    {
        _context = context;
    }
    public AppImage Add(IFormFile formFile, string path)
    {
        AppImage file = AddImage(formFile, path);
        if (file != null)
        {
          
            _context.Add(file);
            _context.SaveChanges();
            return file;
        }
        return null;
    }



    public List<AppImage> AddAll(List<IFormFile> formFiles, string path)
    {
        List<AppImage> files = new();
        foreach (var item in formFiles)
        {
            files.Add(AddImage(item, path));
        }
        _context.Images.AddRange(files);
        //   _context.SaveChanges();
        return files;
    }


    private static AppImage AddImage(IFormFile formFile, string path)
    {
        if (formFile != null)
        {
            string fileName = Guid.NewGuid().ToString().RemoveNoneAlphaNumerics() + Path.GetExtension(formFile.FileName);

            var p = Path.Combine(path);
            if (!Directory.Exists(p))
            {
                Directory.CreateDirectory(p);
            }

            using (var fileStream = new FileStream(Path.Combine(p, fileName), FileMode.Create))
            {

                formFile.CopyTo(fileStream);
            }
            var imagFile = new AppImage { Name = fileName, Url = path };
            return imagFile;
        }
        return null;
    }



    public void Delete(int id)
    { 
        var image = GetById(id);

        if (image == null)
        {

            return;
        }
        var imagePath = image.Url + image.Name;
        if (File.Exists(imagePath))
        {
            File.Delete(imagePath);

        }
        _context.Images.Remove(image);
        _context.SaveChanges();

    }

    public void Edit(AppImage item) => _context.Update(item);

    public AppImage GetById(int id) => _context.Images.Find(id);


    public void SaveChanges()
    {
        _context.SaveChanges();
    }

    public AppImage Edit(IFormFile formFile, string path, int id)
    {
        var oldImage =  _context.Images.FirstOrDefault(i => i.Id == id);
        AppImage file =  AddImage(formFile, path);
        if (file != null)
        {
            if (oldImage != null)
                RemoveImage(oldImage.Url + oldImage.Name);
            else
                oldImage = new AppImage();
            

            oldImage.Name = file.Name;
            oldImage.Url = file.Url;
            _context.Update(oldImage);
             _context.SaveChanges();


        }
        return oldImage;
    }

    public void DeleteRange(List<AppImage> images)
    {
        foreach (var item in images)
        {
            Delete(item);
        }
    }

    private void Delete(AppImage img)
    {
        var imagePath = img.Url + img.Name;
        RemoveImage(imagePath);
        _context.Images.Remove(img);
    }

    private static void RemoveImage(string path)
    {
        if (File.Exists(path))
            File.Delete(path);
        
    }
}

