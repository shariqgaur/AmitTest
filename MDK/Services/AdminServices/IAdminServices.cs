using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Services.AdminServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IAdminServices" in both code and config file together.
    [ServiceContract]
    public interface IAdminServices
    {
        [OperationContract]
        bool addNewRole(string data);

        [OperationContract]
        bool addNewUser(string data);
    }
}
