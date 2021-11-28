using CmsA.Data.Data;
using CmsA.Data.Model.Cms;
using CmsA.Service.Inteface.Cms;
using CmsA.Service.Model.Cms;
using CmsA.Service.Services.BaseServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CmsA.Service.Services.Cms;

public class BannerService : BaseServiceWithImage<Banner>,IBanner
{
    public BannerService(AppDBContext context) : base(context)
    {
    }

    public IEnumerable<LBanner> GetLocalizedAll(string cultureCode)
    {
        return from b in _context.Banners
               join Image in _context.Images on b.AppImageId equals Image.Id
               join LUrl in _context.Localizations on b.UrlId equals LUrl.LocalizationSetId
               join LTitle in _context.Localizations on b.TitleId equals LTitle.LocalizationSetId
               where  LUrl.CultureCode == cultureCode
                   && LTitle.CultureCode == cultureCode

               select new LBanner()
               {
                   Url = LUrl.Value,
                   Title = LTitle.Value,
                   Image = b.AppImage.Name
               };
    }

    public Task<LBanner> GetLocalizedById(string id, string cultureCode)
    {
        throw new NotImplementedException();
    }

    public Task<LBanner> GetLocalizedByName(string id, string cultureCode)
    {
        throw new NotImplementedException();
    }
}

