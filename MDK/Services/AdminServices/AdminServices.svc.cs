using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using BAL.Admin;
using Models;
using Models.TransportModel;

namespace Services.AdminServices
{

    public class AdminServices : IAdminServices
    {

        string transport;

     



       public string  validateUser(string data)
        {
            LoginModel loginModel = new LoginModel();

            loginModel.UserID = "amit";
            loginModel.Password = "786";

            LoginBAL loginBal = new LoginBAL();

            //ToDo
            /*Return value here to UI*/
            transport = ((TransportData)loginBal.validateUser(loginModel)).ToString() ;

            return transport;

        }
    }
}
