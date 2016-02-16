

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using Models;
using Models.TransportModel;


namespace MDK.ServerViews.Admin
{
    public partial class userMangement : System.Web.UI.Page
    {
        AdminServices.AdminServicesClient adminServices = null;
        UserMangementModel model = null;
        JavaScriptSerializer _serializer = null;
        TUserManegementData tUserManagementData = null;


        protected void BtnSave_Click(object sender, EventArgs e)
        {
            model = new UserMangementModel();
            _serializer = new JavaScriptSerializer();
            tUserManagementData = new TUserManegementData();



            model.LoginName = TextBoxUserName.Text;
            model.Password = TextBoxPass.Text;
            model.Role = DrpRoles.SelectedValue;

            string data = _serializer.Serialize(model);

            tUserManagementData = adminServices.createUser(data);


            if (tUserManagementData.ErrorCode != null)
            {
                lblErrorMSG.Visible = true;
                Response.Write("Recod is not save .............!");
            }
            else
            {
                lblSuccessMSG.Visible = true;
                Response.Write("Recod is save .............!");
            }

        }
    }
}