//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using DAL.InterfaceDAL;
//using Models;
//using Models.TransportModel;


//namespace DAL.Admin
//{
//    public class UserMangementDAL : IDal
//    {
//        UserMangementModel modelEntity;
//        MDKDBMLDataContext _dataContext;
//        TUserManegementData tUserManegementData;

//        public UserMangementDAL()
//        {
//            _dataContext = new MDKDBMLDataContext();
//            tUserManegementData = new TUserManegementData();

//        }

//        public TUserManegementData createUser(IModel model)
//        {
//            UserMangement userManagement = new UserMangement();

//            try
//            {
//                modelEntity = (UserMangementModel)model;

//                userManagement.LoginName = modelEntity.LoginName;
//                userManagement.Password = modelEntity.Password;
//                userManagement.Role = modelEntity.Role;

//                _dataContext.UserMangements.InsertOnSubmit(userManagement);
//                _dataContext.SubmitChanges();

//                tUserManegementData.SuccessCode = ErrorCodes.DATA_ACCESS_SUCCESS;

//                return tUserManegementData;
//            }

//            catch (Exception e)
//            {
//                tUserManegementData.ErrorCode = ErrorCodes.DATA_ACCESS_ERROR;
//                tUserManegementData.ErrorMessage = "createUser: " + e.InnerException.ToString();
//                return tUserManegementData;
//            }

//        }

//        public ITransport insertRecord(IModel model)
//        {
//            throw new NotImplementedException();
//        }

//        public ITransport deleteRecordById(int model)
//        {
//            throw new NotImplementedException();
//        }

//        public ITransport editRecordById(int model)
//        {
//            throw new NotImplementedException();
//        }

//        public ITransport updateRecordById(int id, IModel newModel)
//        {
//            throw new NotImplementedException();
//        }

//        public List<IModel> getAllRecords()
//        {
//            throw new NotImplementedException();
//        }
//    }


//}

