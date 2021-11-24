using CmsA.Data.Data;
using CmsA.Data.Model.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CmsA.Service.Services.BaseServices
{
    public  class BaseServiceWithImage<T> : BaseService<T> where T : BaseModelWithImage
    {
        public BaseServiceWithImage(AppDBContext context) : base(context)
        {
        }

        public new async Task<List<T>> GetAll() =>
             await _context.Set<T>().Include(b => b.AppImage).ToListAsync();


        //public new  async Task<T> GetById(string id) =>
        //    await _context.Set<T>()
        //    .Where(b => b.Id == id).Include(b=>b.AppImage).FirstOrDefaultAsync();


    }
}
