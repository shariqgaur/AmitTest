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
        LoginDAL loginDal;

        public ITransport validateUser(IModel model)
        {
            loginDal = new LoginDAL();

            /*Logic goes here and setting database response to ITransport*/

            return loginDal.validateUser(model);
        }
    }
}
