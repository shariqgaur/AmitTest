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
            tITInfoData.itInfoModel = new ITInfoModel();

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

        public TITInfoData getITDetails(string businessGUID)
        {
            try
            {
                var itInfo = _dataContext.ITInfos.FirstOrDefault(x => x.BusinessGUID == businessGUID);

                if (itInfo != null)
                {
                    tITInfoData.itInfoModel.BusinessGUID = itInfo.BusinessGUID;
                    tITInfoData.itInfoModel.IncomeTax = itInfo.IncomeTax;
                    tITInfoData.itInfoModel.PAN_NO = itInfo.PAN_NO;
                    tITInfoData.itInfoModel.TAN_NO = itInfo.TAN_NO;
                    tITInfoData.itInfoModel.VAT_NO = itInfo.VAT_NO;
                    tITInfoData.itInfoModel.CST_NO = itInfo.CST_NO;
                    tITInfoData.itInfoModel.PTRC_NO = itInfo.PTRC_NO;
                    tITInfoData.itInfoModel.PTEC_NO = itInfo.PTEC_NO;
                    tITInfoData.itInfoModel.SalesTax = itInfo.SalesTax;

                    tITInfoData.SuccessCode = SuccessCodes.RECORD_RETRIEVED_SUCCESSFULLY;
                }

                else
                {
                    tITInfoData.SuccessCode = SuccessCodes.RECORD_NOT_FOUND;
                    tITInfoData.SuccessMessage = SuccessMessages.RECORD_NOT_FOUND;
                }

                return tITInfoData;
            }

            catch (Exception exp)
            {
                tITInfoData.ErrorCode = ErrorCodes.DATA_ACCESS_ERROR;
                tITInfoData.ErrorMessage = exp.StackTrace;

                return tITInfoData;
            }


        }
    }
}
