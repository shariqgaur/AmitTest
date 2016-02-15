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
    public class AdminServices : IAdminServices
    {

        TLoginData tLoginData = null;
        LoginBAL loginBal = null;
        JavaScriptSerializer _serializer = null;
        LoginModel loginModel = null;

        public AdminServices()
        {
            tLoginData = new TLoginData();
            loginBal = new LoginBAL();
            _serializer = new JavaScriptSerializer();
            loginModel = new LoginModel();
        }

        public TLoginData validateUser(string data)
        {
            try
            {
                loginModel = _serializer.Deserialize<LoginModel>(data);
                tLoginData = loginBal.validateUser(loginModel);

                return tLoginData;

            }
            catch (Exception exp)
            {
                return null; //transport = e.InnerException.ToString();
            }
        }



       
    }
}
