using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.InterfaceDAL;
using Models;
using Models.TransportModel;

namespace DAL.Admin
{
    public class LoginDAL : IDal
    {
        public ITransport validateUser(IModel model)
        {
            var modelEntity = (LoginModel)model;
            /*Data access logic goes here */

            TestLogin test = new TestLogin();

            return test.getTestUser();
        }

        public ITransport insertRecord(IModel model)
        {
            throw new NotImplementedException();
        }

        public ITransport deleteRecordById(int model)
        {
            throw new NotImplementedException();
        }

        public ITransport editRecordById(int model)
        {
            throw new NotImplementedException();
        }

        public ITransport updateRecordById(int id, IModel newModel)
        {
            throw new NotImplementedException();
        }
    }



    /*Testing */
    public class TestLogin
    {
        TransportData test = null;

        public TestLogin()
        {
            test = new TransportData();
            test.uiData.ViewData = "UI Data from DAL";
            test.errorData.ErrorCode = "ERROR_CODE";
            test.errorData.ErrorMessage = "ErrorMessage";
        }

        public ITransport getTestUser()
        {
            return test;
        }

    }



}
