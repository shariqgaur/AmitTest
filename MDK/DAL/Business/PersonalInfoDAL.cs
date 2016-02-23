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
        ParsnalInfo personalInfoEntity = null;

        public PersonalInfoDAL()
        {
            personalInfoModel = new PersonalInfoModel();
            _dataContext = new MDKDBMLDataContext();
            tPersonalInfoData = new TPersonalInfoData();
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
                var allLines = _dataContext.ParsnalInfos;

                var allRecords = allLines.Select(item => new PersonalInfoModel()
                {
                    Pid = item.Pid,
                    FirstName = item.FirstName,
                    Address = item.Address,
                    ContactNo = item.ContactNo,
                    DateOfBirth = item.DateOfBirth,
                    EmailID = item.EmailID,
                    LastName = item.LastName,
                    MiddleName = item.MiddileName
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
                var modelData = (PersonalInfoModel)model;

                personalInfoEntity.FirstName = modelData.FirstName;
                personalInfoEntity.LastName = modelData.LastName;
                personalInfoEntity.MiddileName = modelData.MiddleName;
                personalInfoEntity.Pid = 0;
                personalInfoEntity.Address = modelData.Address;
                personalInfoEntity.ContactNo = modelData.ContactNo;
                personalInfoEntity.EmailID = modelData.EmailID;
                personalInfoEntity.DateOfBirth = modelData.DateOfBirth;

                _dataContext.ParsnalInfos.InsertOnSubmit(personalInfoEntity);
                _dataContext.SubmitChanges();

                tPersonalInfoData.SuccessCode = ErrorCodes.RECORD_SAVED_SUCCESSFULLY;

                return tPersonalInfoData;
            }

            catch (Exception exp)
            {
                tPersonalInfoData.ErrorCode = ErrorCodes.DATA_ACCESS_ERROR;
                tPersonalInfoData.ErrorMessage = exp.InnerException.ToString();
                return tPersonalInfoData;
            }
        }
    }
}
