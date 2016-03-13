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
   public class OtherInfoBAL:IBal
    {
       public TOtherInfoData saveOtherInfo(IModel model)
        {   
            return new OtherInfoDAL().saveOtherInfo(model);
        }

       public TOtherInfoData getOtherDetails(string businessGUID)
       {
           return new OtherInfoDAL().getOtherDetails(businessGUID);
       }
    }
}
