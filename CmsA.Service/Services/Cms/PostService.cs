﻿using CmsA.Data.Data;
using CmsA.Data.Model;
using CmsA.Data.Model.Cms;
using CmsA.Data.Model.Localization;
using CmsA.Service.Helper;
using CmsA.Service.Inteface;
using CmsA.Service.Inteface.BaseInterface;
using CmsA.Service.Inteface.Cms;
using CmsA.Service.Model;
using CmsA.Service.Model.Cms;
using CmsA.Service.Services.BaseServices;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CmsA.Service.Services.Cms;

public class PostService : BaseService<Post> ,IPost
{
  //  private readonly IImageFile _imageFileService;
    public PostService(AppDBContext context/*, IImageFile imageFileService*/) : base(context)
    {
       // _imageFileService = imageFileService;
    }

  
    public IEnumerable<LPost> GetLocalizedAllByPage(string name, string cultureCode)
    {
        return from b in _context.Posts.Where(p=>string.IsNullOrEmpty(p.ParentID)).Include(p => p.Gallery.Where(c => c.IsMain))
               join LTitle in _context.Localizations on b.TitleId equals LTitle.LocalizationSetId
               join LDescription in _context.Localizations on b.DescriptionId equals LDescription.LocalizationSetId
               join Lcontent in _context.Localizations on b.ContentId equals Lcontent.LocalizationSetId
               where b.Page.Name == name 
               && LTitle.CultureCode == cultureCode
               && LDescription.CultureCode == cultureCode
               && Lcontent.CultureCode == cultureCode

               select new LPost()
               {
                   Name = b.Name,
                   Title = LTitle.Value,
                   Description = LDescription.Value,
                   Content=Lcontent.Value,
                   Image = b.Gallery.Select(c => c.Name).FirstOrDefault(),
               };
    }

    public IEnumerable<LPostMenu> GetLocaliezedNameByPage(string name,string cultureCode)
    {
        var data= from b in _context.Posts.Where(c=>string.IsNullOrEmpty(c.ParentID))
               join LTitle in _context.Localizations on b.TitleId equals LTitle.LocalizationSetId
               where b.Page.Name == name
               && LTitle.CultureCode == cultureCode
               select new LPostMenu()
               {
                   Name = b.Name,
                   Title = LTitle.Value,
                   Menu=b.Children.Select(p=>new LPostMenu()
                   {
                       Name=p.Name,
                       Title=p.Title.Localizations.Where(c=>c.CultureCode==cultureCode).FirstOrDefault().Value
                   }).ToList()
                   
               };
        return data;
    }

    public async Task<Post> GetMinimal(string id)=>
      await  _context.Posts.Where(p=>p.Id==id).Select(p => new Post{Id = p.Id, PageId =p.PageId }).FirstOrDefaultAsync();
    
   
    public async Task<LPost> GetLocalizedByName(string name, string cultureCode)
    {
        var a = from b in _context.Posts.Include(p=>p.Gallery)
                join LTitle in _context.Localizations on b.TitleId equals LTitle.LocalizationSetId
                join LDescription in _context.Localizations on b.DescriptionId equals LDescription.LocalizationSetId
                join LContent in _context.Localizations on b.ContentId equals LContent.LocalizationSetId
                join LPdf in _context.Localizations on b.PdfId equals LPdf.LocalizationSetId
                where b.Name == name && LTitle.CultureCode == cultureCode
                                     && LContent.CultureCode == cultureCode
                                     && LDescription.CultureCode == cultureCode
                                     && LPdf.CultureCode == cultureCode

                select new LPost()
                {
                    Id= b.Id,
                    Name = b.Name,
                    Title = LTitle.Value,
                    Description = LDescription.Value,
                    Content = LContent.Value,
                    PDf=LPdf.Value,
                    PageName=b.Page.Title.Localizations.Where(p=>p.CultureCode==cultureCode).Select(l=>l.Value).FirstOrDefault(),
                    PageId=b.Page.Name,
                    Gallery=b.Gallery.Select(b=>b.Name).ToList(),
                    Image=b.Gallery.Where(c=>c.IsMain).Select(i=>i.Name).FirstOrDefault(),
                };
        return await a.FirstOrDefaultAsync();
    }

    public IEnumerable<LPost> GetChildePost(string id, string cultureCode)
    {
        return from b in _context.Posts
               join LTitle in _context.Localizations on b.TitleId equals LTitle.LocalizationSetId
               join LDescription in _context.Localizations on b.DescriptionId equals LDescription.LocalizationSetId
               where string.Equals(b.ParentID,id) && LTitle.CultureCode == cultureCode && LDescription.CultureCode == cultureCode
               select new LPost()
               {
                   Name = b.Name,
                   Title = LTitle.Value,
                   Description = LDescription.Value,
                   Image = b.Gallery.Where(c=>c.IsMain).Select(c => c.Name).FirstOrDefault(),
               };
    }

    public IEnumerable<LPost> GetLocalizedAllStaredByPage(string name, string cultureCode)
    {
        return from b in _context.Posts.Where(p=>string.IsNullOrEmpty(p.ParentID)).Include(p=>p.Gallery.Where(c=>c.IsMain))
                join LTitle in _context.Localizations on b.TitleId equals LTitle.LocalizationSetId
                join LDescription in _context.Localizations on b.DescriptionId equals LDescription.LocalizationSetId
                where b.Page.Name == name && b.Stared
                && LTitle.CultureCode == cultureCode
                && LDescription.CultureCode == cultureCode
                select new LPost()
                {
                    Name = b.Name,
                    Title = LTitle.Value,
                    Description = LDescription.Value,
                    Image=b.Gallery.Where(c => c.IsMain).Select(c=>c.Name).FirstOrDefault(),
                };
    }

    public new async Task<List<Post>> GetAll() =>
           await _context.Posts.Include(b=>b.Parent).Include(b => b.Page).ToListAsync();

    public  async Task<List<AppImage>> GetGallery(string id)=>
      await  _context.Images.Where(i => i.PostId == id).ToListAsync();

    
    public  void AddImageToGallery(AppImage image, string PostId)
    {
        image.PostId=PostId;
        _context.Images.Update(image);
        _context.SaveChanges();
    }

    public LocalizationSet AddFile(List<PostFileModel> files,string path)
    {
        LocalizationSet loc = new();
        List<Localization> localizations = new();
        foreach (var item in files)
        {
            localizations.Add(new Localization() { CultureCode = item.Local, Value = AddPdf(item.File, path) });
        }
        loc.Localizations = localizations;
        return loc;
    }


    public async Task<LocalizationSet> UpdateFile(List<PostFileModel> files, string path,string id)
    {
        LocalizationSet loc = new();
        List<Localization> localizations = new();
        int locsetId =await _context.Posts.Where(p => p.Id == id).Select(p => p.PdfId).FirstOrDefaultAsync();
        var oldpdf =await   _context.Localizations.Where(ls=>ls.LocalizationSetId== locsetId).ToDictionaryAsync(ls=>ls.CultureCode,ls=>ls.Value);
      //  var cultures =await _context.Cultures.ToDictionaryAsync(c=>c.Code,c=>c);
        foreach (var item in files)
        {
            if (item.File != null)
            {
                if (File.Exists(path+ oldpdf[item.Local])) File.Delete(path + oldpdf[item.Local]);
                localizations.Add(new Localization() { CultureCode = item.Local, Value = AddPdf(item.File, path)  });
            }
            else
            {
                localizations.Add(new Localization() { CultureCode = item.Local, Value = oldpdf[item.Local] });
            }
        }
        loc.Localizations = localizations;
        return loc;
    }

    private static string AddPdf(IFormFile formFile, string path)
    {
        if (formFile != null)
        {
            string fileName = Guid.NewGuid().ToString().RemoveNoneAlphaNumerics() + Path.GetExtension(formFile.FileName);

            var p = Path.Combine(path);

            if (!Directory.Exists(p))
                Directory.CreateDirectory(p);
            

            using (var fileStream = new FileStream(Path.Combine(p, fileName), FileMode.Create))
            {

                formFile.CopyTo(fileStream);
            }
         
            return fileName;
        }
        return "";
    }

    public async Task SetUnsetMain(int ImageId)
    {
       var image=await _context.Images.Where(i => i.Id == ImageId).FirstOrDefaultAsync();
        image.IsMain = !image.IsMain;
        _context.Images.Update(image);
        _context.SaveChanges();
    }

  

    //public new async Task Delete(string PostId)
    //{
    //  var post=  _context.Posts.Include(c => c.Gallery).FirstOrDefaultAsync();
    //}







}

