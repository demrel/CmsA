using CmsA.Data.Model.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CmsA.Data.Model.Cms;

public class Settings
{
    public int Id { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public string Map { get; set; }
    public LocalizationSet Address { get; set; }
}

