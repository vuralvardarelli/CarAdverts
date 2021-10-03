using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adverts.Core.Entities
{
    public class AdvertDetails
    {
        public int id { get; set; }
        public int memberId { get; set; }
        public string cityId { get; set; }
        public string CityName { get; set; }
        public string townId { get; set; }
        public string TownName { get; set; }
        public int modelId { get; set; }
        public string modelName { get; set; }
        public int year { get; set; }
        public int price { get; set; }
        public string title { get; set; }
        public DateTime date { get; set; }
        public int categoryId { get; set; }
        public string category { get; set; }
        public string km { get; set; }
        public string color { get; set; }
        public string gear { get; set; }
        public string fuel { get; set; }
        public string firstPhoto { get; set; }
        public string secondPhoto { get; set; }
        public string userInfo { get; set; }
        public float userPhone { get; set; }
        public string text { get; set; }
    }
}
