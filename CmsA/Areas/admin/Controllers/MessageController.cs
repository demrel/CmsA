using AutoMapper;
using CmsA.Service.Inteface.Cms;
using CmsA.Web.Models.Message;
using Microsoft.AspNetCore.Mvc;

namespace CmsA.Web.Areas.admin.Controllers
{
    public class MessageController : BaseAdminController
    {
        private readonly IMessage _messageServie;

        public MessageController(IMapper mapper, IMessage messageServie) : base(mapper)
        {
            _messageServie = messageServie;
        }

        [HttpGet]
        public  async Task<IActionResult> Index(string type)
        {
            
          
            var data =await   _messageServie.GetAll(type);
            var total = await _messageServie.CountAllMessages();
            var unread = await _messageServie.CountUnreadedMessage();

            MessageIndexVM model = new MessageIndexVM()
            {
                Messages = _mapper.Map<List<MessageModel>>(data),
                UnRead = unread,
                Total = total
            };
            return View(model);
        }

        public async Task<IActionResult> ReadMessage(string id)
        {
           var message=await  _messageServie.ReadMessage(id);
            MessageModel model=_mapper.Map<MessageModel>(message);
            return View(model);
        }

        public async Task<IActionResult> DeleteMessage(string id)
        {
             await _messageServie.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
