using CmsA.Data.Data;
using CmsA.Data.Model.Localization;
using CmsA.Service.Inteface.Localizations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CmsA.Service.Services.Localizations;

    public class CultureService: ICulture
    {
       private readonly AppDBContext _context;

        public CultureService(AppDBContext context)
        {
            _context = context;
        }

        public IEnumerable<Culture> GetAll()
        {
            return _context.Cultures.OrderBy(c => c.Name).ToList();
        }
    }

