using CmsA.Data.Model.Base;
using CmsA.Data.Model.Cms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CmsA.Data.Model;

public class AppImage
{ 
    public int Id { get; set; }
    public string Name { get; set; }
    public string Url { get; set; }
    public string Path { get; set; }
    public bool IsMain { get; set; }
    public string PostId { get; set; }
    public Post Post { get; set; }
}

