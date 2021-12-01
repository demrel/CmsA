using CmsA.Data.Data;
using CmsA.Data.Model.Cms;
using CmsA.Service.Inteface;
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
            _context.SaveChangesAsync();
        }

        public void GetLocalizedVideo()
        {
            // _context.Videos.Update();
            _context.SaveChangesAsync();
        }

        public async Task<MissionVission> GetVideo() =>
          await _context.MissionVissions
                .Include(v => v.MissionTitle)
                .Include(v => v.Mission)
                .Include(v => v.VissionTitle)
                .Include(v => v.Vission)
            .FirstOrDefaultAsync();


    }
}
