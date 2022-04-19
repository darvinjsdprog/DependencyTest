using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyTest.Models
{
    /// <summary>
    /// Determines the result of each execution of a method
    /// </summary>
    public class Response
    {
        /// <summary>
        /// Indicate if the result was positive
        /// </summary>
        public bool IsSucces { get; set; }

        /// <summary>
        /// Response message
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Result object of the execution
        /// </summary>
        public object result { get; set; }
    }
}
