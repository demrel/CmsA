using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;

namespace CmsA.Web.Controllers
{
    public class BaseHomeController : Controller
    {
        protected string GetCulture()
        {
            var rqf = Request.HttpContext.Features.Get<IRequestCultureFeature>();
            return rqf.RequestCulture.Culture.TwoLetterISOLanguageName;
        }
    }
}
