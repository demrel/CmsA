﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CmsA.Service.Model.Cms
{
    public class LPostMenu
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public List<LPostMenu> Menu{get;set;}

    }
}
