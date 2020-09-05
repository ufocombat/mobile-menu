using System;
using System.Collections.Generic;
using System.Text.Json;

namespace tele2.Models
{
    public class MenuClass
    {
        public string name { get; set; }
        public string description { get; set; }
        public string slug { get; set; }
        public string template { get; set; }
        
        public List<MenuItemClass> controls { get; set; }
}
}
