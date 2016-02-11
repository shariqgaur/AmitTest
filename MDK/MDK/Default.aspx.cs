using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;
using Models;

namespace MDK
{

    public partial class _Default : Page
    {
        JavaScriptSerializer _serializer = new JavaScriptSerializer();
      

        protected void Page_Load(object sender, EventArgs e)
        {

            var adminService = new AdminService.AdminServicesClient();

            LoginModel loginModel = new LoginModel();

            loginModel.UserID = "amit";
            loginModel.Password = "786";

            string jsonData=_serializer.Serialize(loginModel);

            adminService.validateUser(jsonData);




        }
    }
}