using CmsA.Data.Data;
using CmsA.Data.Model.Cms;
using CmsA.Service.Inteface.Cms;
using CmsA.Service.Services.BaseServices;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CmsA.Service.Services.Cms
{
    public class MessageService : BaseService<Message>,IMessage
    {
        public MessageService(AppDBContext context) : base(context)
        {
        }

        public async Task<int> CountAllMessages()=>
           await _context.Messages.CountAsync();

        public async Task<int> CountUnreadedMessage() =>
          await _context.Messages.Where(b=>!b.IsRead).CountAsync();
        public  async Task<List<Message>> GetAll(string type)
        {
            var data = _context.Messages.Select(m => new Message()
            {
                Id = m.Id,
                Name = m.Name,
                Email = m.Email,
                IsRead = m.IsRead,
                Time = m.Time,
            });

            //Todo Switch feature C#
            if (type=="read")
                data = data.Where(c => c.IsRead);
            if (type == "unread")
                data = data.Where(c => !c.IsRead);

            return await data.ToListAsync();
        }

        public async Task<Message> ReadMessage(string Id)
        {
            var message=await GetById(Id);
            message.IsRead= true;
            _context.SaveChanges();
            return message;
        }
     
    }
}
