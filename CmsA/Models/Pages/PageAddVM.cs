namespace CmsA.Web.Models.Pages
{
    public class PageAddVM : BaseAddVM
    {
        public PageModel Add { get; set; }
        public IFormFile Image { get; set; }
    }
}
