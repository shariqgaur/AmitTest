using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using Models;
using Models.TransportModel;

namespace DAL.Business
{
   public class LineDetailsDAL
    {
       MDKDBMLDataContext _dataContext = null;
       TLineDetails tLineDetails = null;
       PersonalInfoModel personalInfoModel = null;

       public LineDetailsDAL()
       {
           _dataContext = new MDKDBMLDataContext();
           tLineDetails = new TLineDetails();
           personalInfoModel = new PersonalInfoModel();
         
       }

       public TLineDetails getLineDetails(string businessGUID)
       {

           var record = _dataContext.PersonalInformations.SingleOrDefault(x => x.BusinessGUID == businessGUID);

           if (record != null)
           {

               personalInfoModel.FirstName = record.FirstName;
               personalInfoModel.MiddleName = record.MiddleName;
               personalInfoModel.LastName = record.LastName;
               personalInfoModel.BusinessName = record.BusinessName;
               personalInfoModel.BusinessType = record.BusinessType;
               personalInfoModel.BusinessAddress = record.Address;
               personalInfoModel.BusinessGUID = record.BusinessGUID;
               personalInfoModel.ContactNo = record.ContactNo;
               personalInfoModel.AlternateNumber = record.AlternateNo;
               personalInfoModel.EmailID = record.EmailID;
               personalInfoModel.DateOfBirth = record.DateOfBirth;

               tLineDetails.personalInfo = personalInfoModel;
               tLineDetails.SuccessCode = SuccessCodes.RECORD_RETRIEVED_SUCCESSFULLY;
           }

           else 
           {
               tLineDetails.SuccessCode = SuccessCodes.RECORD_NOT_FOUND;
               tLineDetails.SuccessMessage = SuccessMessages.RECORD_NOT_FOUND;
               tLineDetails.SuccessCode = businessGUID;
           }
          
           return tLineDetails;   
       }
    }
}
