using CmsA.Data.Data;
using CmsA.Data.Model.Localization;
using CmsA.Service.Inteface.Localizations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CmsA.Service.Services.Localizations;

    public class LocalizationService :  ILocalization
    {
        private readonly AppDBContext _context;

        public LocalizationService(AppDBContext context)
        {
            _context = context;
        }

        public void Create(Localization localization)
        {
            _context.Localizations.Add(localization);
            _context.SaveChanges();
        }

        public void Delete(IEnumerable<Localization> localizations)
        {
            _context.Localizations.RemoveRange(localizations);
            _context.SaveChanges();
        }
    }

