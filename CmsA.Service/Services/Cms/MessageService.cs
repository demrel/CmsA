using CmsA.Data.Data;
using CmsA.Data.Model.Cms;
using CmsA.Service.Inteface.Cms;
using CmsA.Service.Services.BaseServices;
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

     
    }
}
