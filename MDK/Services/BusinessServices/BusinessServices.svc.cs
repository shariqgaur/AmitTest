using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using BAL.Business;
using Models;
using Models.TransportModel;

namespace Services.BusinessServices
{
    public class BusinessServices : IBusinessServices
    {
        PersonalInfoModel personalInfoModel = null;
        PersonalInfoBAL personalInfoBAL = null;
        TPersonalInfoData tPersonalInfoData = null;

        public BusinessServices()
        {
            personalInfoModel = new PersonalInfoModel();
            personalInfoBAL = new PersonalInfoBAL();
            tPersonalInfoData = new TPersonalInfoData();
        }


        public TPersonalInfoData getAllBusinessLines(string data)
        {
            return personalInfoBAL.getAllBusinessLines();
        }

    }
}
