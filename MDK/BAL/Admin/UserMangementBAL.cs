using DAL.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Admin
{ 
    public class UserMangementBAL
        {
            UserManagementDAL userManagementDAL = null;

            public UserMangementBAL()
            {
                userManagementDAL = new UserManagementDAL();
            }


            public bool addNewUser(string data)
            {
                return userManagementDAL.addNewuserDAL(data);
            }
        }
    }

