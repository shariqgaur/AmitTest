using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
   public class BankModel:IModel
    {
        public string BusinessGUID { get; set; }
        public string BankName { get; set; }
        public string BankBranch { get; set; }
        public string BankAccountNumber { get; set; }
        public string IFSCCode { get; set; }
        public string MICRCode { get; set; }
    }
}
