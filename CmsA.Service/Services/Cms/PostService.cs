using CmsA.Data.Data;
using CmsA.Data.Model;
using CmsA.Data.Model.Cms;
using CmsA.Service.Inteface;
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

    public IEnumerable<LPost> GetLocalizedAll(string cultureCode)
    {
        throw new NotImplementedException();
    }
    public IEnumerable<LPost> GetLocalizedAllByPage(string PageName,string cultureCode)
    {
        throw new NotImplementedException();
    }

    public Task<LPost> GetLocalizedById(string id, string cultureCode)
    {
        throw new NotImplementedException();
    }

    public Task<LPost> GetLocalizedByName(string name, string cultureCode)
    {
        throw new NotImplementedException();
    }

    public new async Task<List<Post>> GetAll() =>
           await _context.Posts.Include(b => b.Gallery).ToListAsync();

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

