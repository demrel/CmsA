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

    public async Task<List<SelectListItem>> GetMinimal()=>
         await _context.Pages.Select(p => new SelectListItem(p.Id, p.Name)).ToListAsync();
       
    
}

