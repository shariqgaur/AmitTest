using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
using BAL.Business;
using Models;
using Models.TransportModel;

namespace Services.BusinessServices
{
    public class BusinessServices : IBusinessServices
    {
        JavaScriptSerializer _serializer = null;

        PersonalInfoModel personalInfoModel = null;
        PersonalInfoBAL personalInfoBAL = null;
        TPersonalInfoData tPersonalInfoData = null;

        LineDetailsBAL lineDetailsBAL = null;

        public BusinessServices()
        {
            _serializer = new JavaScriptSerializer();

            personalInfoModel = new PersonalInfoModel();
            personalInfoBAL = new PersonalInfoBAL();
            tPersonalInfoData = new TPersonalInfoData();

            lineDetailsBAL = new LineDetailsBAL();
        }


        public TPersonalInfoData getAllBusinessLines(string data)
        {
            try
            {
                tPersonalInfoData.allRecords = personalInfoBAL.getAllBusinessLines().allRecords;
                return tPersonalInfoData;
            }
            catch (Exception exp)
            {
                tPersonalInfoData.ErrorCode = ErrorCodes.SERVICE_ERROR;
                tPersonalInfoData.ErrorMessage = exp.InnerException.ToString();
                return tPersonalInfoData;

            }
        }


        public TPersonalInfoData createBusinessUser(string data)
        {
            try
            {

                personalInfoModel = _serializer.Deserialize<PersonalInfoModel>(data);
                tPersonalInfoData = personalInfoBAL.createBusinessUser(personalInfoModel);

                return tPersonalInfoData;

            }

            catch (Exception exp)
            {
                tPersonalInfoData.ErrorCode = ErrorCodes.SERVICE_ERROR;
                tPersonalInfoData.ErrorMessage = exp.StackTrace;
                return tPersonalInfoData;
            }
        }





        public TLineDetails getLineDetails(string data)
        {
            string deserialized = _serializer.Deserialize<string>(data);
            return lineDetailsBAL.getLineDetails(deserialized);
        }


        public string fileUpload(Stream stream)
        {
            string path=HttpContext.Current.Server.MapPath(".");

            //using (var fileStream = new FileStream(path+"\\uploaded\\sai", FileMode.Create, FileAccess.Write))
            //{
            //    stream.CopyTo(fileStream);
            //}


            //using (Stream output = new FileStream(path + "\\uploaded\\sainath", FileMode.Create, FileAccess.Write))
            //{
            //    byte[] buffer = new byte[32 * 1024];
            //    int read;

            //    while ((read = stream.Read(buffer, 0, buffer.Length)) > 0)
            //    {
            //        output.Write(buffer, 0, read);
            //    }
            //}


            //using (var output = File.Open(path + "\\uploaded\\sainath1.ico", FileMode.Create))
            //    stream.CopyTo(output);


            //var upload = new UploadedFile
            //{
            //    FilePath = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString())
            //};

            //int length = 0;
            //using (var writer = new FileStream(upload.FilePath, FileMode.Create))
            //{
            //    int readCount;
            //    var buffer = new byte[8192];
            //    while ((readCount = uploading.Read(buffer, 0, buffer.Length)) != 0)
            //    {
            //        writer.Write(buffer, 0, readCount);
            //        length += readCount;
            //    }
            //}

            //upload.FileLength = length;

            //return upload;

            return "sainath";
        }
    }
}
