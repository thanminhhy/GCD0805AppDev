using GCD0805AppDev.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GCD0805AppDev.ViewModels
{
    public class TodoCategoriesViewModel
    {
        public Todo Todo { get; set; }
        public List<Category> Categories { get; set; }
    }
}