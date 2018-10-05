using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Language.Models;

namespace Language.ViewModel
{
    public class MenuVM
    {
        public List<Food_Category> category { get; set; }
        public List<Food> food { get; set; }
        public Setting setting { get; set; }
    }
}