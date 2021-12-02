using CmsA.Data.Data;
using CmsA.Data.Model;
using CmsA.Data.Model.Cms;
using CmsA.Service.Inteface;
using CmsA.Service.Inteface.BaseInterface;
using CmsA.Service.Inteface.Cms;
using CmsA.Service.Model.Cms;
using CmsA.Service.Services.BaseServices;
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
        return from b in _context.Posts.Include(p => p.Gallery.Where(c => c.IsMain))
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

   
    public async Task<LPost> GetLocalizedByName(string name, string cultureCode)
    {
        var a = from b in _context.Posts.Include(p=>p.Gallery)
                join LTitle in _context.Localizations on b.TitleId equals LTitle.LocalizationSetId
                join LDescription in _context.Localizations on b.DescriptionId equals LDescription.LocalizationSetId
                join LContent in _context.Localizations on b.ContentId equals LContent.LocalizationSetId
                where b.Name == name && LTitle.CultureCode == cultureCode
                                   && LContent.CultureCode == cultureCode
                                   && LDescription.CultureCode == cultureCode
                select new LPost()
                {
                    Name = b.Name,
                    Title = LTitle.Value,
                    Description = LDescription.Value,
                    Content = LContent.Value,
                    PageName=b.Page.Title.Localizations.Where(p=>p.CultureCode==cultureCode).Select(l=>l.Value).FirstOrDefault(),
                    PageId=b.Page.Name,
                    Gallery=b.Gallery.Select(b=>b.Name).ToList(),
                    Image=b.Gallery.Where(c=>c.IsMain).Select(i=>i.Name).FirstOrDefault(),
                };
        return await a.FirstOrDefaultAsync();
    }

    public IEnumerable<LPost> GetLocalizedAllStaredByPage(string name, string cultureCode)
    {
        return from b in _context.Posts.Include(p=>p.Gallery.Where(c=>c.IsMain))
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
                    Image=b.Gallery.Select(c=>c.Name).FirstOrDefault(),
                };
     
    }

    public new async Task<List<Post>> GetAll() =>
           await _context.Posts.Include(b => b.Page).ToListAsync();

    public  async Task<List<AppImage>> GetGallery(string id)=>
      await  _context.Images.Where(i => i.PostId == id).ToListAsync();

    
    public  void AddImageToGallery(AppImage image, string PostId)
    {
        image.PostId=PostId;
        _context.Images.Update(image);
        _context.SaveChanges();
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

