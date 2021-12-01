namespace CmsA.Web.Models.Posts
{
    public class PostGalleryVM
    {
        public List<AppImageModel> Images { get; set; }
        public IFormFile Image { get; set; }
        public string PostId { get; set; }  
        public string PostName { get; set; }

    }
}
