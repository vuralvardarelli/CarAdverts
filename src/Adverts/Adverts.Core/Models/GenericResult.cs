using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adverts.Core.Models
{
    public class GenericResult
    {
        public bool IsSuccess { get; set; }
        public int StatusCode { get; set; }
        public object Data { get; set; } = new object();
    }
}
