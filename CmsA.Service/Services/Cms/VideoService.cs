using CmsA.Data.Data;
using CmsA.Service.Inteface;
using CmsA.Service.Model.Cms;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cmsData = CmsA.Data.Model.Cms;

namespace CmsA.Service.Services.Cms
{
    public class VideoService : IVideo
    {
        private readonly AppDBContext _context;

        public VideoService(AppDBContext context)
        {
            _context = context;
        }

        public void Update(cmsData.Viedo video)
        {
            _context.Videos.Update(video);
            _context.SaveChanges();
        }

        public async Task<LVideo> GetLocalized(string cultureCode)
        {
            var a = from b in _context.Videos.Include(v=>v.VideoImage)
                    join LTitle in _context.Localizations on b.TitleId equals LTitle.LocalizationSetId
                    join LDescription in _context.Localizations on b.DescriptionId equals LDescription.LocalizationSetId
                    join LUrl in _context.Localizations on b.URlId equals LUrl.LocalizationSetId
                    where LTitle.CultureCode == cultureCode
                          && LUrl.CultureCode == cultureCode
                          && LDescription.CultureCode == cultureCode
                    select new LVideo()
                    {
                        Title = LTitle.Value,
                        Description = LDescription.Value,
                        URl=LUrl.Value,
                        Image=b.VideoImage.Name
                    };
            return await a.FirstOrDefaultAsync();
        }

        public async Task<cmsData.Viedo> Get() =>
          await _context.Videos
                .Include(v => v.VideoImage)
                .Include(v => v.URl).ThenInclude(s => s.Localizations)
                .Include(v => v.Title).ThenInclude(s => s.Localizations)
                .Include(v => v.Description).ThenInclude(s => s.Localizations)
            .FirstOrDefaultAsync();



    }
}
