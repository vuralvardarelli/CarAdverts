using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBusRabbitMQ.Events
{
    public class AdvertVisitEvent
    {
        public Guid RequestId { get; set; }
        public int advertId { get; set; }
        public string iPAdress { get; set; }
        public DateTime visitDate { get; set; }
    }
}
