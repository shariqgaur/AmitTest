using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Web.Script.Serialization;
using BAL.Admin;
using BAL.Business;
using Models;
using Models.TransportModel;
namespace Services.AdminServices
{
    public class AdminServices : IAdminServices
    {

        LoginModel loginModel = null;
        LoginBAL loginBal = null;
        TLoginData tLoginData = null;

        JavaScriptSerializer _serializer = null;

        UserMangementModel userMangementModel = null;
        UserMangementBAL userMangementBAL = null;
        TUserManegementData tuserMangementData = null;

        public AdminServices()
        {
            loginModel = new LoginModel();
            loginBal = new LoginBAL();
            tLoginData = new TLoginData();

            _serializer = new JavaScriptSerializer();

            userMangementModel = new UserMangementModel();
            userMangementBAL = new UserMangementBAL();
            tuserMangementData = new TUserManegementData();


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
                tLoginData.ErrorCode = "SERVICE_ERROR";
                tLoginData.ErrorMessage = "validateUser: " + exp.InnerException.ToString();
                return tLoginData;
            }
        }


        public TUserManegementData createUser(string data)
        {
            try
            {
                userMangementModel = _serializer.Deserialize<UserMangementModel>(data);
                tuserMangementData = userMangementBAL.createUser(userMangementModel);
                return tuserMangementData;
            }
            catch (Exception exp)
            {
                tuserMangementData.ErrorCode = "SERVICE_ERROR";
                tuserMangementData.ErrorMessage = "createUser:" + exp.InnerException.ToString();
                return tuserMangementData;
            }




        }
    }
}