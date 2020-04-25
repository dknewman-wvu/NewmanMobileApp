﻿using System;
using System.Collections.Generic;
using System.Text;

namespace NewmanMobileApp.Models
{
    public enum MenuItemType
    {
        Browse,
        About, 
        Quiz
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}
