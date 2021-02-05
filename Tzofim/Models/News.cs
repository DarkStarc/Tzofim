using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tzofim.Models
{
    public class News
    {
        public int NewsId{get;set;}
        public string Title { get; set; }
        public string NewsText { get; set; }
        public DateTime DateTime { get; set; }
        public CultureForNews CultureId { get; set; }
    }
}
