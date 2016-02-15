using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Models;

namespace Services.BusinessServices
{
    public class BusinessServices : IBusinessServices
    {
        TLoginData tLoginData = null;
        LoginBAL loginBal = null;
        JavaScriptSerializer _serializer = null;
        LoginModel loginModel = null;

        public BusinessServices()
        {

        }
        public IEnumerable<PersonalInfo> getAllBusinessLines()
        {
            return null;
        }

    }
}
