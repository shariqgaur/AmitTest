using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.TransportModel
{
    public class TransportData : ITransport
    {
        public string SuccessCode { get; set; }
        public string SuccessMessage { get; set; }
        public string ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
   }
}