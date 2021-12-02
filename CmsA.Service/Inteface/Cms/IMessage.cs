using CmsA.Data.Model.Cms;
using CmsA.Service.Inteface.BaseInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CmsA.Service.Inteface.Cms
{
    public interface IMessage : IBase<Message>
    {
        Task<Message> ReadMessage(string Id);
        Task<int> CountAllMessages();
        Task<int> CountUnreadedMessage();
        Task<List<Message>> GetAll(string type);
    }
}
