using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.TransportModel
{
    public class TransportData : ITransport
    {
        public UIData uiData { get; set; }
        public ErrorData errorData { get; set; }

        public TransportData()
        {
            uiData = new UIData();
            errorData = new ErrorData();
        }

    }


    public class UIData
    {
        public string ViewData { get; set; }
    }

    public class ErrorData
    {
        public string ErrorCode { get; set; }
        public string ErrorMessage { get; set; }

        public string getErrorMessageByErrorCode(string errorCode)
        {
            return string.Empty;
        }
    }

}
