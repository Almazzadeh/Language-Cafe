using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Language.Models;

namespace Language.ViewModel
{
    public class IndexVM
    {
        public Header header { get; set; }
        public About about { get; set; }
        public Conversation conversation { get; set; }
        public IEnumerable<Food> foodList { get; set; }
        public Setting setting { get; set; }
    }
}