using CmsA.Data.Data;
using CmsA.Data.Model.Base;
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
         _context.Add(item);
         _context.SaveChanges();
    }

    public  void Update(T item)
    {
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

    public async Task<T> GetById(string id) => 
        await _context.Set<T>().Where(b => b.Id == id).FirstOrDefaultAsync();

    public async Task<T> GetByName(string name) =>
       await _context.Set<T>().Where(b => b.Name == name).FirstOrDefaultAsync();
}

