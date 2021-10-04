using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Core.Entities
{
    /// <summary>
    /// AdvertVisits table columns.
    /// </summary>
    public class AdvertVisits
    {
        public int advertId { get; set; }
        public string iPAdress { get; set; }
        public DateTime visitDate { get; set; }
    }
}
