using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Admin
{
   public class RoleManagementDAL: BASEDAL
    {
       RoleMangemant roleManagementEntity = null;

       public RoleManagementDAL()
       {
           roleManagementEntity = new RoleMangemant();
       }

     public  bool addNewRoleDAL(string data)
       {
           try
           {
              //Deserialize object
               var tblData = _serializer.Deserialize<RoleManagementModel>(data);
                
               //Model data assign to entity
               roleManagementEntity.RoleName= tblData.RoleName;

               //Save to database
               _dataContext.RoleMangemants.InsertOnSubmit(roleManagementEntity);
               _dataContext.SubmitChanges();
               return true;
           }

           catch
           {
               return false;
           }

       }
    }
}
