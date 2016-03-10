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
                bankEntity.IFSC_CODE=bankModel.IFSCCode;
                bankEntity.MICR_CODE=bankModel.MICRCode;

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
    }
}
