using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BAL.InterfaceBAL;
using DAL.Business;
using Models;
using Models.TransportModel;

namespace BAL.Business
{
    public class PersonalInfoBAL : IBal
    {
        PersonalInfoDAL personalInfoDAL = null;
        PersonalInfoModel personalInfoModel = null;
        TPersonalInfoData tPersonalInfoData = null;

        public PersonalInfoBAL()
        {
            personalInfoDAL = new PersonalInfoDAL();
            personalInfoModel = new PersonalInfoModel();
            tPersonalInfoData = new TPersonalInfoData();
        }

        public TPersonalInfoData getAllBusinessLines()
        {
            return personalInfoDAL.getAllBusinessLines();
        }

        public TPersonalInfoData createBusinessUser(IModel data)
        {
            try
            {
                personalInfoModel = (PersonalInfoModel)data;
                tPersonalInfoData = personalInfoDAL.createBusinessUser(personalInfoModel);
                return tPersonalInfoData;
            }

            catch (Exception exp)
            {
                tPersonalInfoData.ErrorCode = ErrorCodes.BUSINESS_LOGIC_ERROR;
                tPersonalInfoData.ErrorMessage = exp.InnerException.ToString();
                return tPersonalInfoData;
            }

        }
    }
}
