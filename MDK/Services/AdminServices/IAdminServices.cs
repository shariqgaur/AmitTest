using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Models;
using Models.TransportModel;

namespace Services.AdminServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IAdminServices" in both code and config file together.
    [ServiceContract]
    public interface IAdminServices
    {
        [OperationContract]
        [WebInvoke(ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            Method = "POST")]
        TLoginData validateUser(string data);


        [OperationContract]
        [WebInvoke(ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            Method = "POST")]
        TUserManegementData createUser(string data);
    }
}
