using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Models.TransportModel;

namespace DAL.Business
{
    public class ITInfoDAL
    {
        MDKDBMLDataContext _dataContext;
        TITInfoData tITInfoData;
        ITInfo entity;
        ITInfoModel _model;


        public ITInfoDAL()
        {
            _dataContext = new MDKDBMLDataContext();
            tITInfoData = new TITInfoData();
            entity = new ITInfo();
        }


        public TITInfoData saveITInfo(IModel model)
        {
            try
            {
                _model = (ITInfoModel)model;

                entity.BusinessGUID = _model.BusinessGUID;
                entity.PAN_NO = _model.PAN_NO;
                entity.TAN_NO = _model.TAN_NO;
                entity.VAT_NO = _model.VAT_NO;
                entity.CST_NO = _model.CST_NO;
                entity.PTRC_NO = _model.PTRC_NO;
                entity.PTEC_NO = _model.PTEC_NO;
                entity.SalesTax = _model.SalesTax;
                entity.IncomeTax = _model.IncomeTax;

                _dataContext.ITInfos.InsertOnSubmit(entity);
                _dataContext.SubmitChanges();

                tITInfoData.SuccessCode = SuccessCodes.RECORD_SAVED_SUCCESSFULLY;
                tITInfoData.SuccessMessage = SuccessMessages.RECORD_SAVED_SUCCESSFULLY_MSG;

                return tITInfoData;
            }
            catch (Exception exp)
            {
                tITInfoData.ErrorCode = ErrorCodes.DATA_ACCESS_ERROR;
                tITInfoData.ErrorMessage = exp.StackTrace;
            }

            return null;
        }
    }
}
