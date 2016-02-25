using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.InterfaceDAL;
using Models;
using Models.TransportModel;

namespace DAL.Business
{
    public class PersonalInfoDAL : IDal
    {

        PersonalInfoModel personalInfoModel = null;
        MDKDBMLDataContext _dataContext = null;
        TPersonalInfoData tPersonalInfoData = null;
        PersonalInformation personalInfoEntity = null;

        public PersonalInfoDAL()
        {
            personalInfoModel = new PersonalInfoModel();
            _dataContext = new MDKDBMLDataContext();
            tPersonalInfoData = new TPersonalInfoData();
            personalInfoEntity = new PersonalInformation();
        }

        public Models.TransportModel.ITransport insertRecord(Models.IModel model)
        {
            throw new NotImplementedException();
        }

        public Models.TransportModel.ITransport deleteRecordById(int model)
        {
            throw new NotImplementedException();
        }

        public Models.TransportModel.ITransport editRecordById(int model)
        {
            throw new NotImplementedException();
        }

        public Models.TransportModel.ITransport updateRecordById(int id, Models.IModel newModel)
        {
            throw new NotImplementedException();
        }




        public TPersonalInfoData getAllBusinessLines()
        {
            try
            {
                var allLines = _dataContext.PersonalInformations;

                var allRecords = allLines.Select(item => new PersonalInfoModel()
                {
                    Pid = item.Pid,
                    FirstName = item.FirstName,
                    BusinessAddress = item.Address,
                    ContactNo = item.ContactNo,
                    AlternateNumber=item.AlternateNo,
                    DateOfBirth = item.DateOfBirth,
                    EmailID = item.EmailID,
                    LastName = item.LastName,
                    MiddleName = item.MiddleName,
                    BusinessGUID = item.BusinessGUID,
                    BusinessName = item.BusinessName,
                    BusinessType = item.BusinessType

                }).ToList();

                tPersonalInfoData.SuccessCode = "DATA_ACCESS_SUCCESS";
                tPersonalInfoData.allRecords = allRecords;
                return tPersonalInfoData;
            }
            catch (Exception exp)
            {
                tPersonalInfoData.ErrorCode = "DATA_ACCESS_ERROR";
                tPersonalInfoData.ErrorMessage = "getAllRecords: " + exp.InnerException.ToString();
                return tPersonalInfoData;
            }
        }

        public TPersonalInfoData createBusinessUser(IModel model)
        {
            try
            {
                //tPersonalInfoData.tPersonalInfoData = new PersonalInfoModel();
                personalInfoModel = (PersonalInfoModel)model;

                personalInfoEntity.FirstName = personalInfoModel.FirstName;
                personalInfoEntity.LastName = personalInfoModel.LastName;
                personalInfoEntity.MiddleName = personalInfoModel.MiddleName;
                personalInfoEntity.Pid = 0;
                personalInfoEntity.Address = personalInfoModel.BusinessAddress;
                personalInfoEntity.ContactNo = personalInfoModel.ContactNo;
                personalInfoEntity.EmailID = personalInfoModel.EmailID;
                personalInfoEntity.DateOfBirth = personalInfoModel.DateOfBirth;
                personalInfoEntity.BusinessGUID = personalInfoModel.BusinessGUID;
                personalInfoEntity.BusinessName = personalInfoModel.BusinessName;
                personalInfoEntity.BusinessType = personalInfoModel.BusinessType;

                _dataContext.PersonalInformations.InsertOnSubmit(personalInfoEntity);
                _dataContext.SubmitChanges();

                tPersonalInfoData.SuccessCode = SuccessCode.RECORD_SAVED_SUCCESSFULLY;

                return tPersonalInfoData;
 
            }

            catch (Exception exp)
            {
                tPersonalInfoData.ErrorCode = ErrorCodes.DATA_ACCESS_ERROR;
                tPersonalInfoData.ErrorMessage = exp.Message;
                return tPersonalInfoData;
            }
        }
    }
}
