﻿using System;
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

        UserManagementModel userMangementModel = null;
        UserManagementBAL userManagementBAL = null;
        TUserManagementData tuserMangementData = null;

        public AdminServices()
        {
            loginModel = new LoginModel();
            loginBal = new LoginBAL();
            tLoginData = new TLoginData();

            _serializer = new JavaScriptSerializer();

            userMangementModel = new UserManagementModel();
            userManagementBAL = new UserManagementBAL();
            tuserMangementData = new TUserManagementData();


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
                tLoginData.ErrorCode = ErrorCodes.SERVICE_ERROR;
                tLoginData.ErrorMessage = "validateUser: " + exp.InnerException.ToString();
                return tLoginData;
            }
        }


        public TUserManagementData createUser(string data)
        {
            try
            {
                userMangementModel = _serializer.Deserialize<UserManagementModel>(data);
                tuserMangementData = userManagementBAL.createUser(userMangementModel);
                return tuserMangementData;
            }
            catch (Exception exp)
            {
                tuserMangementData.ErrorCode = ErrorCodes.SERVICE_ERROR;
                tuserMangementData.ErrorMessage = "createUser:" + exp.InnerException.ToString();
                return tuserMangementData;
            }

        }
    }
}