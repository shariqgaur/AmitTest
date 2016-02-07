using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Admin
{
    public class UserManagementDAL : BASEDAL
    {
        UserMangement userManagementEntity = null;

        public UserManagementDAL()
        {
            userManagementEntity = new UserMangement();
        }

        public bool addNewuserDAL(string data)
        {
            try
            {
                //Deserialize object
                var tblData = _serializer.Deserialize<UserManagementModel>(data);

                //Model data assign to entity
                userManagementEntity.LoginName = tblData.LoginName;
                userManagementEntity.Password = tblData.Password;

                //Save to database
                _dataContext.UserMangements.InsertOnSubmit(userManagementEntity);
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
