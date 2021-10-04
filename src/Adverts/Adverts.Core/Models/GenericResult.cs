using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adverts.Core.Models
{
    /// <summary>
    /// A result object for services return
    /// </summary>
    public class GenericResult
    {
        /// <summary>
        /// Process succeeded or not.
        /// </summary>
        public bool IsSuccess { get; set; }

        /// <summary>
        /// Status code for checking if 200,201,204,500
        /// </summary>
        public int StatusCode { get; set; }

        /// <summary>
        /// Data to send if process succeded.
        /// </summary>
        public object Data { get; set; } = new object();
    }
}
