using CmsA.Data.Data;
using CmsA.Data.Model.Cms;
using CmsA.Service.Inteface;
using CmsA.Service.Model.Cms;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CmsA.Service.Services.Cms
{
    public  class MissionVissionService :IMission
    {
        private readonly AppDBContext _context;

        public MissionVissionService(AppDBContext context)
        {
            _context = context;
        }

        public void Update(MissionVission data)
        {
            _context.MissionVissions.Update(data);
            _context.SaveChanges();
        }

        public async Task<LMV> GetLocalized(string cultureCode)
        {
            var a = from b in _context.MissionVissions
                    join LMission in _context.Localizations on b.MissionId equals LMission.LocalizationSetId
                    join LVission in _context.Localizations on b.VissionId equals LVission.LocalizationSetId
                    join LMissionTitle in _context.Localizations on b.MissionTitleId equals LMissionTitle.LocalizationSetId
                    join LVissionTitle in _context.Localizations on b.VissionTitleId equals LVissionTitle.LocalizationSetId
                    where LMission.CultureCode == cultureCode
                       && LVission.CultureCode == cultureCode
                       && LMissionTitle.CultureCode == cultureCode
                       && LVissionTitle.CultureCode == cultureCode

                    select new LMV()
                    {
                        Mission = LMission.Value,
                        Vission = LVission.Value,
                        VissionTitle = LVissionTitle.Value,
                        MissionTitle = LMissionTitle.Value
                    };
            return await a.FirstOrDefaultAsync();
           
        }

        public async Task<MissionVission> Get() =>
          await _context.MissionVissions
                .Include(v => v.MissionTitle).ThenInclude(s=>s.Localizations)
                .Include(v => v.Mission).ThenInclude(s => s.Localizations)
                .Include(v => v.VissionTitle).ThenInclude(s => s.Localizations)
                .Include(v => v.Vission).ThenInclude(s => s.Localizations)
            .FirstOrDefaultAsync();


    }
}
