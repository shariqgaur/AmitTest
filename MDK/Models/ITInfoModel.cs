using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class ITInfoModel:IModel
    {
        public string IncomeTax { get; set; }
        public string PAN_NO { get; set; }
        public string TAN_NO { get; set; }
        public string VAT_NO { get; set; }
        public string CST_NO { get; set; }
        public string PTRC_NO { get; set; }
        public string PTEC_NO { get; set; }
        public string SalesTax { get; set; }
        public string BusinessGUID { get; set; }
    }
}
