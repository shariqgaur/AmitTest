 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MDK.ServerViews.Admin
{
    public partial class ParsnalInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            errorMessage.Visible = false;
            successMessage.Visible = false;
        }


        protected void BtnSave_Click(object sender, EventArgs e)
        { 
        }
    }
}