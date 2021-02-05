using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Globalization;

namespace Tzofim.Models
{
    public class CultureForNews
    {
        public int CultureForNewsId {get;set;}
        public string Key { get; set; }
        public IEnumerable<News> News { get; set; }

        public CultureForNews() {
            News = new List<News>();
        }
    }
}
