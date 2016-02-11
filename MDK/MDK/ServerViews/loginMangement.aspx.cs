using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;
using BAL.Admin;
using BAL.InterfaceDefinition;
using Models;
using Models.interfaces;

namespace MDK.ServerViews
{
    public partial class loginManagement : System.Web.UI.Page
    {
        JavaScriptSerializer _serializer=null;
        IBal bal;
        IMDKModel loginMangementModel;
         
        
        protected void Page_Load(object sender, EventArgs e)
        {

            bal = new AdminServicesBAL();
            loginMangementModel= new LoginMangementModel();
            
       

        }

        protected void ButtonLogin_Click(object sender, EventArgs e)
        {
             
            
      
            
        }
    }
}    
