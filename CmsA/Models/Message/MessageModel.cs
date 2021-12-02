namespace CmsA.Web.Models.Message
{
    public class MessageModel : BaseModel
    {
        public string Content { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string FullName { get; set; }
        public bool IsRead { get; set; }
    }
}
