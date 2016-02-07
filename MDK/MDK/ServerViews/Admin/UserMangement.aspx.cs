
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
    public partial class userMangement : System.Web.UI.Page
    {
        JavaScriptSerializer _serializer = null;
        UserManagementModel userManagementmodel = null;
        AdminServicesNS.AdminServicesClient adminService = null;

        public userMangement()
        {
            _serializer = new JavaScriptSerializer();
            userManagementmodel = new UserManagementModel();
            adminService = new AdminServicesNS.AdminServicesClient();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            lblErrorMSG.Visible = false;
            lblSuccessMSG.Visible = false;
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            userManagementmodel.LoginName = TextBoxUserName.Text;
            userManagementmodel.Password = TextBoxPass.Text;
            string data = _serializer.Serialize(userManagementmodel);

            var result = adminService.addNewUser(data);

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