using CmsA.Data.Data;
using CmsA.Data.Model.Localization;
using CmsA.Service.Inteface.Localizations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CmsA.Service.Services.Localizations;

   public  class LocalizationSetService :ILocalizationSet
    {
        private readonly AppDBContext _context;

        public LocalizationSetService(AppDBContext context)
        {
            _context = context;
        }

        public LocalizationSet GetById(int id)
        {
            return _context.LocalizationSets
              .Include(ls => ls.Localizations)
              .FirstOrDefault(ls => ls.Id == id);
        }

        public void Create(LocalizationSet localizationSet)
        {
            _context.LocalizationSets.Add(localizationSet);
            _context.SaveChanges();
        }
    }

