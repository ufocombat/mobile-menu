﻿using System;
using System.ComponentModel.DataAnnotations;

namespace tele2.Models
{
    public class MenuItemClass
    {
        public string name { get; set; }
        public string description { get; set; }
        public string slug { get; set; }
        public string icon { get; set; }
        public string actionType { get; set; }
        
        public string actionObj { get; set; }
    }
}
