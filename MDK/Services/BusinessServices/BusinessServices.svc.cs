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
        public BusinessServices()
        {

        }
        public IEnumerable<PersonalInfo> getAllBusinessLines()
        {
            return null;
        }

    }
}
