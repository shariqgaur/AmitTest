using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Web.Script.Serialization;
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
            try
            {
                tPersonalInfoData.allRecords = personalInfoBAL.getAllBusinessLines().allRecords;
                return tPersonalInfoData;
            }
            catch (Exception exp)
            {
                tPersonalInfoData.ErrorCode = ErrorCodes.SERVICE_ERROR;
                tPersonalInfoData.ErrorMessage = exp.InnerException.ToString();
                return tPersonalInfoData;

            }
        }





        public TPersonalInfoData createBusinessUser(string data)
        {
            try
            {
                JavaScriptSerializer _serializer = new JavaScriptSerializer();
                personalInfoModel = _serializer.Deserialize<PersonalInfoModel>(data);
                //tPersonalInfoData.tPersonalInfoData= personalInfoBAL.createBusinessUser(personalInfoModel);
                return tPersonalInfoData;

            }

            catch (Exception exp)
            {
                tPersonalInfoData.ErrorCode = ErrorCodes.SERVICE_ERROR;
                tPersonalInfoData.ErrorMessage =exp.InnerException.ToString();
                return tPersonalInfoData;
            }
        }
    }
}
