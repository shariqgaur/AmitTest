using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BAL.InterfaceBAL;
using Models;
using Models.TransportModel;
using DAL.Admin;

namespace BAL.Admin
{
    public class LoginBAL : IBal
    {
        LoginDAL loginDal = null;
        TLoginData tloginData = null;
        LoginModel loginModel = null;

        public LoginBAL()
        {
            loginDal = new LoginDAL();
            loginModel = new LoginModel();
            tloginData = new TLoginData();
        }

        public TLoginData validateUser(IModel model)
        {
            try
            {
                tloginData = loginDal.validateUser(model);
                return tloginData;
            }

            catch (Exception exp)
            {
                tloginData.ErrorCode = "BUSINESS_LOGIC_ERROR";
                tloginData.ErrorMessage = "validateUser: " + exp.InnerException;
                return tloginData;
            }
        }
    }
}
