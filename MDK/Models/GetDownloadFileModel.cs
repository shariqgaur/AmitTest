using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
   public class GetDownloadFileModel
    {
        public string BusinessGUID { get; set; }
        public string SelectedYear { get; set; }
        public string fileType { get; set; }
    }
}
