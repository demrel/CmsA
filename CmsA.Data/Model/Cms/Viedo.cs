using CmsA.Data.Model.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CmsA.Data.Model.Cms;

public class Viedo
{
    public int Id { get; set; }
    public AppImage VideoImage { get; set; }
    public LocalizationSet URl { get; set; }
    public LocalizationSet Title { get; set; }
    public LocalizationSet Description { get; set; }

}

