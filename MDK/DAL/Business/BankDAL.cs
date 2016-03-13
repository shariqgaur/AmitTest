using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Models.TransportModel;

namespace DAL.Business
{
    public class BankDAL
    {
        BankModel bankModel;
        BankInfo bankEntity;
        MDKDBMLDataContext _dataContext;
        TBankData tbankData;
        public BankDAL()
        {
            bankModel = new BankModel();
            bankEntity = new BankInfo();
            tbankData = new TBankData();
            tbankData.bankModel = new BankModel();

            _dataContext = new MDKDBMLDataContext();
        }

        public TBankData saveBankInformation(IModel model)
        {
            try
            {
                bankModel = (BankModel)model;

                bankEntity.BusinessGUID = bankModel.BusinessGUID;
                bankEntity.BankName = bankModel.BankName;
                bankEntity.Branch = bankModel.BankBranch;
                bankEntity.AccountNo = bankModel.BankAccountNumber;
                bankEntity.IFSC_CODE = bankModel.IFSCCode;
                bankEntity.MICR_CODE = bankModel.MICRCode;

                _dataContext.BankInfos.InsertOnSubmit(bankEntity);
                _dataContext.SubmitChanges();

                tbankData.SuccessCode = SuccessCodes.RECORD_SAVED_SUCCESSFULLY;
                tbankData.SuccessMessage = SuccessMessages.RECORD_SAVED_SUCCESSFULLY_MSG;

                return tbankData;
            }

            catch (Exception exp)
            {
                tbankData.ErrorCode = ErrorCodes.DATA_ACCESS_ERROR;
                tbankData.ErrorMessage = exp.StackTrace;
                return tbankData;

            }


        }

        public TBankData getBankDetails(string businessGUID)
        { 
            try
            {

                var bankData = _dataContext.BankInfos.FirstOrDefault(x => x.BusinessGUID == businessGUID);

                if (bankData != null)
                {

                    tbankData.bankModel = new BankModel();
                    tbankData.bankModel.BankName = bankData.BankName;
                    tbankData.bankModel.BankBranch = bankData.Branch;
                    tbankData.bankModel.BankAccountNumber = bankData.AccountNo;
                    tbankData.bankModel.IFSCCode = bankData.IFSC_CODE;
                    tbankData.bankModel.MICRCode = bankData.MICR_CODE;
                    tbankData.bankModel.BusinessGUID = bankData.BusinessGUID;

                    tbankData.SuccessCode = SuccessCodes.RECORD_RETRIEVED_SUCCESSFULLY;

                    return tbankData;

                }
                else
                {
                    tbankData.SuccessCode = SuccessCodes.RECORD_NOT_FOUND;
                    tbankData.SuccessMessage = SuccessMessages.RECORD_NOT_FOUND;
                    tbankData.SuccessCode = businessGUID;


                    return tbankData;
                }
            }
            catch (Exception exp)
            {
                tbankData.ErrorCode = ErrorCodes.DATA_ACCESS_ERROR;
                tbankData.ErrorMessage = exp.Message;

                return tbankData;
            }
         }
    }
}
