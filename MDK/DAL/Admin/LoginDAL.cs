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
        LoginModel modelEntity;
        MDKDBMLDataContext _dataContext;
        TLoginData tLoginData;
         

        public LoginDAL()
        {
            _dataContext = new MDKDBMLDataContext();
            tLoginData = new TLoginData();
      
        }

        public TLoginData validateUser(IModel model)
        {
            try
            {
                modelEntity = (LoginModel)model;

                var record = _dataContext.UserMangements.Where(x => x.LoginName == modelEntity.UserId && x.Password == modelEntity.Password).ToList();

                if (record.Count > 0)
                {
                    tLoginData.SuccessCode = ErrorCodes.VALID_USER;
                    modelEntity.UserId = record[0].LoginName;
                    modelEntity.Role = record[0].Role;
                    tLoginData.tLoginData = modelEntity;

                    return tLoginData;


                }
                else
                {
                    tLoginData.ErrorCode = ErrorCodes.INVALID_USER;
                    tLoginData.ErrorMessage = ErrorMessages.INVALID_USER_MSG;
                    return tLoginData;
                }
            }

            catch (Exception e)
            {
                tLoginData.ErrorCode = ErrorCodes.DATA_ACCESS_ERROR;
                tLoginData.ErrorMessage = "validateUser: " + e.InnerException.ToString();
                return tLoginData;
            }

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

        public List<IModel> getAllRecords()
        {
            throw new NotImplementedException();
        }
    }


}
