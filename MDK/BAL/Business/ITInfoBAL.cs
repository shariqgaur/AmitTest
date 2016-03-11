using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Business;
using Models;
using Models.TransportModel;

namespace BAL.Business
{
   public class ITInfoBAL
    {
       ITInfoDAL iTInfoDal;
       TITInfoData tITInfoData;
       public ITInfoBAL()
       {
           iTInfoDal = new ITInfoDAL();
           tITInfoData = new TITInfoData();
       }

       public TITInfoData saveITInfo(IModel model)
       {
           try
           {
               return iTInfoDal.saveITInfo(model);
           }
           catch (Exception exp)
           {
               tITInfoData.ErrorCode = ErrorCodes.BUSINESS_LOGIC_ERROR;
               tITInfoData.ErrorMessage = exp.StackTrace;
             
           }
           return null;
       }
    }
}
