using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MDK.client
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var _dbcontext = new MDKLinkToSQLDataContext();

            var login = new Login();
         
            //Code for insert data into table

            //login.UserName = "Anand";
            //login.Password = "Bharne";
            //_dbcontext.Logins.InsertOnSubmit(login);
            //_dbcontext.SubmitChanges();

            var loginTable = _dbcontext.Logins;
             GridView1.DataSource = loginTable.ToList();
             GridView1.DataBind();


            
        }
    }
}