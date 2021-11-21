using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CmsA.Service.Inteface.BaseInterface;

public interface IBase<T>
{
    void Create(T item);
    void Update(T item);
    void Delete(T item);
    Task Delete(string id);
    Task<List<T>> GetAll();
    Task<T> GetById(string id);
    Task<T> GetByName(string id);
   
}


