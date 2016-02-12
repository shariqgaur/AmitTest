using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Web.Script.Serialization;
using BAL.Admin;
using Models;
using Models.TransportModel;

namespace Services.AdminServices
{

    public class TestData
    {

        public string Id { get; set; }
        public string Name { get; set; }

    }

    public class AdminServices : IAdminServices
    {

        string transport;
        JavaScriptSerializer _serialize;




        public string validateUser(string data)
        {
            LoginModel loginModel = new LoginModel();
            _serialize = new JavaScriptSerializer();


            loginModel.UserID = "amit";
            loginModel.Password = "786";

            LoginBAL loginBal = new LoginBAL();

            //ToDo
            /*Return value here to UI*/
            transport = _serialize.Serialize((TransportData)loginBal.validateUser(loginModel));

            return transport;

        }


    }
}
