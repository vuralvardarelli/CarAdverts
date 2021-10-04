using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adverts.Core.Entities
{
    /// <summary>
    /// For sending to RabbitMQ Queue
    /// </summary>
    public class AdvertVisits
    {
        public int advertId { get; set; }
        public string iPAdress { get; set; }
        public DateTime visitDate { get; set; }
    }
}
