using CmsA.Data.Data;
using CmsA.Data.Model.Cms;
using CmsA.Service.Inteface.Cms;
using CmsA.Service.Model;
using CmsA.Service.Model.Cms;
using CmsA.Service.Services.BaseServices;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CmsA.Service.Services.Cms;

public class PageService : BaseService<Page> ,IPage
{
    public PageService(AppDBContext context) : base(context)
    {
    }

    public IEnumerable<LPage> GetLocalizedAll(string cultureCode)
    {
        throw new NotImplementedException();
    }

    public Task<LPage> GetLocalizedById(string id, string cultureCode)
    {
        throw new NotImplementedException();
    }

    public async Task<LPage> GetLocalizedByName(string name, string cultureCode)
    {
        var a = from b in _context.Pages
                join LTitle in _context.Localizations on b.TitleId equals LTitle.LocalizationSetId
                join LDescription in _context.Localizations on b.DescriptionId equals LDescription.LocalizationSetId
                join LContent in _context.Localizations on b.ContentId equals LContent.LocalizationSetId
                where b.Name==name &&LTitle.CultureCode == cultureCode
                                   &&LContent.CultureCode==cultureCode
                                   &&LDescription.CultureCode==cultureCode   
                select  new LPage()
                {
                    Name = b.Name,
                    Title = LTitle.Value,
                    Description = LDescription.Value,
                    Content = LContent.Value,
                    PostType=b.PostType
                };
          return await a.FirstOrDefaultAsync();
    }

    public IEnumerable<LPageMenu> GetLocaliezedName(string cultureCode)
    {
        var data = from b in _context.Pages.OrderBy(c => c.Position).Where(c=>c.PostType!=Data.Enums.PostType.DontShowInMenu)
                   join LTitle in _context.Localizations on b.TitleId equals LTitle.LocalizationSetId
                   where  LTitle.CultureCode == cultureCode
                   select new LPageMenu()
                   {
                       Name = b.Name,
                       Title = LTitle.Value,

                   };
        return data;
    }

    public async Task<List<SelectListItem>> GetMinimal()=>
         await _context.Pages.Where(c => c.PostType != Data.Enums.PostType.DontShowInMenu).Select(p => new SelectListItem(p.Id, p.Name)).ToListAsync();

    public new  async Task Delete(string PostId)
    {

        var page = await _context.Pages.Where(c => c.Id == PostId)
            .Include(p => p.Posts)
            .Include(c => c.Title).ThenInclude(d => d.Localizations)
            .Include(c => c.Content).ThenInclude(d => d.Localizations)
            .Include(c => c.Description).ThenInclude(d => d.Localizations).FirstOrDefaultAsync();
        if (page == null) return;
       

        foreach (var item in page.Posts)
        {
            item.PageId = null;
        }

        _context.LocalizationSets.Remove(page.Title);
        _context.LocalizationSets.Remove(page.Description);
        _context.LocalizationSets.Remove(page.Content);

       
        _context.Remove(page);
        _context.SaveChanges();
    }

}

