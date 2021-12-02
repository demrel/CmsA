using CmsA.Data.Data;
using CmsA.Data.Model.Base;
using CmsA.Data.Model.Localization;
using CmsA.Service.Helper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CmsA.Service.Services.BaseServices;

public  class BaseService<T> where T : BaseModel
{
    protected readonly AppDBContext _context;
    public BaseService(AppDBContext context)
    {
        _context = context;
    }

    public  void Create(T item)
    {
         item.Id = Guid.NewGuid().ToString().RemoveNoneAlphaNumerics();
         item.Time = DateTime.UtcNow.AddHours(4);
         _context.Add(item);
         _context.SaveChanges();
    }

    public  void Update(T item)
    {
        item.Time = DateTime.UtcNow;
        _context.Update(item);
         _context.SaveChanges();
    }

    public void Delete(T item)
    {
        _context.Remove(item);
        _context.SaveChanges();
    }

    public async Task Delete(string id)
    {
        var data = await GetById(id);
        if (data == null) return;

        Delete(data);
        _context.SaveChanges();
    }

 

    public async Task<List<T>> GetAll()
    {
        return await _context.Set<T>().ToListAsync();
    }

    public async Task<T> GetById(string id)
    {
        var type = typeof(T);
        var properties = type.GetProperties();
        var queryable = _context.Set<T>().Where(b => b.Id == id);
        foreach (var property in properties)
        {
            var isVirtual = property.GetGetMethod().IsVirtual;
            if (isVirtual  )
            {

                string propertyName = property.Name;
                propertyName += property.PropertyType.Name== "LocalizationSet" ? ".Localizations" : "";


                queryable = queryable.Include(propertyName);

                
            }
        }
        
      return  await queryable.FirstOrDefaultAsync();

    }

    public async Task<T> GetByName(string name) =>
       await _context.Set<T>().Where(b => b.Name == name).FirstOrDefaultAsync();
}

