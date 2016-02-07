using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MDK.ServerViews.Admin
{
    public partial class RoleMangement : System.Web.UI.Page
    {
        
    
    
        JavaScriptSerializer _serializer = null;
        RoleManagementModel roleManagementModel = null;
        AdminServicesNS.AdminServicesClient adminService = null; 


        public RoleMangement()
        {
            _serializer = new JavaScriptSerializer();
            roleManagementModel = new RoleManagementModel();
            adminService = new AdminServicesNS.AdminServicesClient();
        }



        protected void Page_Load(object sender, EventArgs e)
        {
            lblErrorMSG.Visible = false;
            lblSuccessMSG.Visible = false;
        }

        protected void BtnAdd_Click(object sender, EventArgs e)
        {

            roleManagementModel.RoleName = TextBoxRoleName.Text;
            string data = _serializer.Serialize(roleManagementModel);

            var result= adminService.addNewRole(data);

            if (result)
            {
                lblSuccessMSG.Visible = true;
            }

            else
            {
                lblErrorMSG.Visible = true;
            }
            

        }
    }
}
