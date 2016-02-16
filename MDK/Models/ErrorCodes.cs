using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public static class ErrorCodes
    {
        public const string INVALID_USER = "INVALID_USER";
        public const string VALID_USER = "VALID_USER";
        public const string DATA_ACCESS_ERROR = "DATA_ACCESS_ERROR";
        public const string BUSINESS_LOGIC_ERROR="BUSINESS_LOGIC_ERROR";
        public const string DATA_ACCESS_SUCCESS = "DATA_ACCESS_SUCCESS";
    }


    public static class ErrorMessages
    {
        public const string INVALID_USER_MSG = "Username or password is incorrect !";
    }
}
