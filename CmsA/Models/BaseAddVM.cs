using CmsA.Data.Model.Localization;
using Microsoft.AspNetCore.Mvc;

namespace CmsA.Web.Models;

public class BaseAddVM
{
   public IEnumerable<Culture> Cultures { get; set; }
}

