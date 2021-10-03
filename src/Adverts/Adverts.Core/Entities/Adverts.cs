using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adverts.Core.Entities
{
    public class Adverts
    {
        public int id { get; set; }
        public string modelName { get; set; }
        public int year { get; set; }
        public int price { get; set; }
        public string title { get; set; }
        public DateTime date { get; set; }
        public string category { get; set; }
        public string km { get; set; }
        public string color { get; set; }
        public string gear { get; set; }
        public string fuel { get; set; }
        public string firstPhoto { get; set; }
    }
}
