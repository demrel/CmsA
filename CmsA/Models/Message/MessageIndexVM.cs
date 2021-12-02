namespace CmsA.Web.Models.Message
{
    public class MessageIndexVM
    {
        public List<MessageModel> Messages { get; set; }
        public int Total { get; set; }
        public int UnRead { get; set; }
    }
}
