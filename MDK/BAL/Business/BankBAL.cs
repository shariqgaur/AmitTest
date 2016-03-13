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
    public class BankBAL
    {
        BankDAL bankDal;

        public BankBAL()
        {
            bankDal = new BankDAL();
        }
        public TBankData saveBankInformation(IModel model)
        {
            return bankDal.saveBankInformation(model);
        }

        public TBankData getBankDetails(string businessGUID)
        {
            return bankDal.getBankDetails(businessGUID);
        }
    }
}
