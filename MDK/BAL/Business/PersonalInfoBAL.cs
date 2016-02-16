using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BAL.InterfaceBAL;
using DAL.Business;
using Models.TransportModel;

namespace BAL.Business
{
   public class PersonalInfoBAL:IBal
    {
       PersonalInfoDAL personalInfoDAL = null;

       public PersonalInfoBAL()
       {
           personalInfoDAL = new PersonalInfoDAL();
       }

       public TPersonalInfoData getAllBusinessLines()
       {
           return null;
       }

    }
}
