using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CmsA.Service.Inteface.BaseInterface;

public interface ITranslate<T>
{
    IEnumerable<T> GetLocalizedAll(string cultureCode);
    Task<T> GetLocalizedById(string id, string cultureCode);
    Task<T> GetLocalizedByName(string id, string cultureCode);
}
 

