using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CmsA.Service.Model
{
    public class PostFileModel
    {
        public string Local { get; set; }
        public IFormFile File { get; set; }
    }
}
