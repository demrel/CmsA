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
    public  class VideoService : IVideo
    {
        private readonly AppDBContext _context;

        public VideoService(AppDBContext context)
        {
            _context = context;
        }

        public void Update(cmsData.Viedo video)
        {
            _context.Videos.Update(video);
            _context.SaveChangesAsync();
        }

        public LVideo GetLocalized()
        {
           // _context.Videos.Update();
            _context.SaveChangesAsync();
            return null;
        }

        public async Task<cmsData.Viedo> Get()=>
          await  _context.Videos
                .Include(v => v.VideoImage)
                .Include(v => v.URl)
                .Include(v => v.Title)
                .Include(v => v.Description).FirstOrDefaultAsync();


        
    }
}
