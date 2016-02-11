
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using BAL.InterfaceDefinition;
using Services.AdminInterfae;

namespace Services.AdminServices
{
     
    public class AdminServices : IAdminServices
    {
         

        public AdminServices()
        {
             
        }


        public string validateUser(string data)
        {     

            throw new NotImplementedException();
        }

        public string addNewUser(string data)
        {
            throw new NotImplementedException();
        }

        public string editUser(string data)
        {
            throw new NotImplementedException();
        }

        public string deleteUser(string data)
        {
            throw new NotImplementedException();
        }
    }
}
