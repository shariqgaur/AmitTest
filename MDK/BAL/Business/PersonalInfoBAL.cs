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
 
                personalInfoModel.BusinessGUID = RandomStringOfLength(4) + "-" + System.Guid.NewGuid().ToString().Substring(0, 8);
                tPersonalInfoData = personalInfoDAL.createBusinessUser(personalInfoModel);
                tPersonalInfoData.tPersonalInfoData = new PersonalInfoModel();
                return tPersonalInfoData;

            }

            catch (Exception exp)
            {
                tPersonalInfoData.ErrorCode = ErrorCodes.BUSINESS_LOGIC_ERROR;
                tPersonalInfoData.ErrorMessage = exp.StackTrace;
                return tPersonalInfoData;
            }

        }

        private string RandomStringOfLength(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            var random = new Random();
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }


}
