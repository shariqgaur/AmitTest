using BAL.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Services.AdminServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "AdminServices" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select AdminServices.svc or AdminServices.svc.cs at the Solution Explorer and start debugging.
    public class AdminServices : IAdminServices
    {
        RoleManagementBAL roleManagementBAL = null;
        UserMangementBAL userMangementBAL = null;

        public AdminServices()
        {
            roleManagementBAL = new RoleManagementBAL();
            userMangementBAL = new UserMangementBAL();
        }
        public bool addNewRole(string data)
        {
           return roleManagementBAL.addNewRoleBAL(data);
         
        }




        public bool addNewUser(string data)
        {
           return userMangementBAL.addNewUser(data);
        }
    }
}
