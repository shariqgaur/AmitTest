using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public static class SuccessCodes
    {
        public const string RECORD_SAVED_SUCCESSFULLY = "RECORD_SAVED_SUCCESSFULLY";
        public const string RECORD_RETRIEVED_SUCCESSFULLY = "RECORD_RETRIEVED_SUCCESSFULLY";
        public const string RECORD_NOT_FOUND = "RECORD_NOT_FOUND";
        public const string FILE_UPLOAD_SUCCESS = "FILE_UPLOAD_SUCCESS";
        public const string FILE_LIST_RETRIEVED = "FILE_LIST_RETRIEVED";
    }


    public static class SuccessMessages
    {
        public const string RECORD_SAVED_SUCCESSFULLY_MSG = "Record saved successfully !";
        public const string RECORD_NOT_FOUND = "Sorry, record not found !";
        public const string FILE_UPLOAD_SUCCESS_MSG = "File uploaded successfully !";
        public const string FILE_LIST_RETRIEVED_SUCCESSFULLY_MSG = "";
    }
}
