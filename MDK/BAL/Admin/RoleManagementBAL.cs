using DAL.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Admin
{
    public class RoleManagementBAL
    {
        RoleManagementDAL roleManagementDAL = null;

        public RoleManagementBAL()
        {
            roleManagementDAL = new RoleManagementDAL();
        }


        public bool addNewRoleBAL(string data)
        {
            return roleManagementDAL.addNewRoleDAL(data);

        }
    }
}
