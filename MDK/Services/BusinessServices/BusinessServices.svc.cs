using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Hosting;
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

        BankBAL bankBAL = null;
        TBankData tBankData = null;

        TITInfoData tITInfoData = null;
        ITInfoBAL iTInfoBAL = null;

        TOtherInfoData tOtherInfoData = null;
        OtherInfoBAL otherInfoBAL = null;

        Random RandomPIN = new Random();
        public BusinessServices()
        {
            _serializer = new JavaScriptSerializer();

            personalInfoModel = new PersonalInfoModel();
            personalInfoBAL = new PersonalInfoBAL();

            tPersonalInfoData = new TPersonalInfoData();
            tBankData = new TBankData();

            lineDetailsBAL = new LineDetailsBAL();
            bankBAL = new BankBAL();

            tITInfoData = new TITInfoData();
            iTInfoBAL = new ITInfoBAL();

            tOtherInfoData = new TOtherInfoData();
            otherInfoBAL = new OtherInfoBAL();

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
            string path = HttpContext.Current.Server.MapPath(".");




            try
            {
                #region C O M E N T E D   C O D E
                //1 working for pdf and pics

                //using (var file = File.Create(path+"\\uploaded\\sairahem.pdf"))
                //{
                //    stream.CopyTo(file);
                //}
                #endregion

                // using parser
                var parser = new MultipartParser(stream);
                if (!parser.Success)
                    throw new ApplicationException("Error while parsing image file");


                using (var ms = new FileStream(path + "\\uploaded\\" + parser.Filename, FileMode.CreateNew, FileAccess.Write))
                {
                    ms.Write(parser.FileContents, 0, parser.FileContents.Length);
                }

                return SuccessCodes.FILE_UPLOAD_SUCCESS;


            }
            catch (Exception exp)
            {
                return exp.Message;
            }



        }

        public class MultipartParser
        {
            private byte[] requestData;
            public MultipartParser(Stream stream)
            {
                this.Parse(stream, Encoding.UTF8);
                ParseParameter(stream, Encoding.UTF8);
            }

            public MultipartParser(Stream stream, Encoding encoding)
            {
                this.Parse(stream, encoding);
            }

            private void Parse(Stream stream, Encoding encoding)
            {
                this.Success = false;

                // Read the stream into a byte array
                byte[] data = ToByteArray(stream);
                requestData = data;

                // Copy to a string for header parsing
                string content = encoding.GetString(data);

                // The first line should contain the delimiter
                int delimiterEndIndex = content.IndexOf("\r\n");

                if (delimiterEndIndex > -1)
                {
                    string delimiter = content.Substring(0, content.IndexOf("\r\n"));

                    // Look for Content-Type
                    Regex re = new Regex(@"(?<=Content\-Type:)(.*?)(?=\r\n\r\n)");
                    Match contentTypeMatch = re.Match(content);

                    // Look for filename
                    re = new Regex(@"(?<=filename\=\"")(.*?)(?=\"")");
                    Match filenameMatch = re.Match(content);

                    // Did we find the required values?
                    if (contentTypeMatch.Success && filenameMatch.Success)
                    {
                        // Set properties
                        this.ContentType = contentTypeMatch.Value.Trim();
                        this.Filename = filenameMatch.Value.Trim();

                        // Get the start & end indexes of the file contents
                        int startIndex = contentTypeMatch.Index + contentTypeMatch.Length + "\r\n\r\n".Length;

                        byte[] delimiterBytes = encoding.GetBytes("\r\n" + delimiter);
                        int endIndex = IndexOf(data, delimiterBytes, startIndex);

                        int contentLength = endIndex - startIndex;

                        // Extract the file contents from the byte array
                        byte[] fileData = new byte[contentLength];

                        Buffer.BlockCopy(data, startIndex, fileData, 0, contentLength);

                        this.FileContents = fileData;
                        this.Success = true;
                    }
                }
            }

            private void ParseParameter(Stream stream, Encoding encoding)
            {
                this.Success = false;

                // Read the stream into a byte array
                byte[] data;
                if (requestData.Length == 0)
                {
                    data = ToByteArray(stream);
                }
                else { data = requestData; }
                // Copy to a string for header parsing
                string content = encoding.GetString(data);

                // The first line should contain the delimiter
                int delimiterEndIndex = content.IndexOf("\r\n");

                if (delimiterEndIndex > -1)
                {
                    string delimiter = content.Substring(0, content.IndexOf("\r\n"));
                    string[] splitContents = content.Split(new[] { delimiter }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string t in splitContents)
                    {
                        // Look for Content-Type
                        Regex contentTypeRegex = new Regex(@"(?<=Content\-Type:)(.*?)(?=\r\n\r\n)");
                        Match contentTypeMatch = contentTypeRegex.Match(t);

                        // Look for name of parameter
                        Regex re = new Regex(@"(?<=name\=\"")(.*)");
                        Match name = re.Match(t);

                        // Look for filename
                        re = new Regex(@"(?<=filename\=\"")(.*?)(?=\"")");
                        Match filenameMatch = re.Match(t);



                        // Did we find the required values?
                        if (name.Success || filenameMatch.Success)
                        {
                            // Set properties
                            //this.ContentType = name.Value.Trim();
                            int startIndex;
                            if (filenameMatch.Success)
                            {
                                this.Filename = filenameMatch.Value.Trim();
                            }
                            if (contentTypeMatch.Success)
                            {
                                // Get the start & end indexes of the file contents
                                startIndex = contentTypeMatch.Index + contentTypeMatch.Length + "\r\n\r\n".Length;
                            }
                            else
                            {
                                startIndex = name.Index + name.Length + "\r\n\r\n".Length;
                            }

                            //byte[] delimiterBytes = encoding.GetBytes("\r\n" + delimiter);
                            //int endIndex = IndexOf(data, delimiterBytes, startIndex);

                            //int contentLength = t.Length - startIndex;
                            string propertyData = t.Substring(startIndex - 1, t.Length - startIndex);
                            // Extract the file contents from the byte array
                            //byte[] paramData = new byte[contentLength];

                            //Buffer.BlockCopy(data, startIndex, paramData, 0, contentLength);

                            MyContent myContent = new MyContent();
                            myContent.Data = encoding.GetBytes(propertyData);
                            myContent.StringData = propertyData;
                            myContent.PropertyName = name.Value.Trim();

                            if (MyContents == null)
                                MyContents = new List<MyContent>();

                            MyContents.Add(myContent);
                            this.Success = true;
                        }
                    }
                }
            }

            private int IndexOf(byte[] searchWithin, byte[] serachFor, int startIndex)
            {
                int index = 0;
                int startPos = Array.IndexOf(searchWithin, serachFor[0], startIndex);

                if (startPos != -1)
                {
                    while ((startPos + index) < searchWithin.Length)
                    {
                        if (searchWithin[startPos + index] == serachFor[index])
                        {
                            index++;
                            if (index == serachFor.Length)
                            {
                                return startPos;
                            }
                        }
                        else
                        {
                            startPos = Array.IndexOf<byte>(searchWithin, serachFor[0], startPos + index);
                            if (startPos == -1)
                            {
                                return -1;
                            }
                            index = 0;
                        }
                    }
                }

                return -1;
            }

            private byte[] ToByteArray(Stream stream)
            {
                byte[] buffer = new byte[32768];
                using (MemoryStream ms = new MemoryStream())
                {
                    while (true)
                    {
                        int read = stream.Read(buffer, 0, buffer.Length);
                        if (read <= 0)
                            return ms.ToArray();
                        ms.Write(buffer, 0, read);
                    }
                }
            }

            public List<MyContent> MyContents { get; set; }

            public bool Success
            {
                get;
                private set;
            }

            public string ContentType
            {
                get;
                private set;
            }

            public string Filename
            {
                get;
                set;
            }

            public byte[] FileContents
            {
                get;
                private set;
            }
        }

        public class MyContent
        {
            public byte[] Data { get; set; }
            public string PropertyName { get; set; }
            public string StringData { get; set; }
        }


        /// <summary>
        /// This method is used to upload files from client side
        /// All the files will be stored where wcf is hosted
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        public string uploadDocuments(Stream stream)
        {
            string basePath = HttpContext.Current.Server.MapPath(".");
            var parser = new MultipartParser(stream);

            IncomingWebRequestContext request = WebOperationContext.Current.IncomingRequest;
            var headers = request.Headers;

            string businessDataPath = basePath + "\\uploaded\\businessData\\";
            string businessId = headers["businessId"];
            string selectedYear = headers["selectedYear"];
            string selectedDocType = headers["selectedDocType"];
            string fullPath = businessDataPath + businessId + "\\" + selectedYear + "\\";

            try
            {

                if (!parser.Success)
                    throw new ApplicationException("Error while parsing image file");


                if (businessId != null || businessId == string.Empty)
                {
                    //parser.Filename=parser.Filename+"_"+ businessId + "_" + selectedDocType + "_" + selectedYear + "_" + RandomPIN.Next(0, 9999).ToString() + Path.GetExtension(parser.Filename);
                    parser.Filename = Path.GetFileNameWithoutExtension(parser.Filename) + "_" + selectedDocType + Path.GetExtension(parser.Filename);
                }

                if (!Directory.Exists(businessDataPath + businessId))
                {
                    Directory.CreateDirectory(businessDataPath + businessId);
                }

                //check selected year directory exists or not
                if (!Directory.Exists(fullPath))
                {
                    Directory.CreateDirectory(fullPath);
                }

                if (File.Exists(fullPath + parser.Filename))
                {
                    File.Delete(fullPath + parser.Filename);
                }

                using (var ms = new FileStream(fullPath + parser.Filename, FileMode.CreateNew, FileAccess.Write))
                {
                    ms.Write(parser.FileContents, 0, parser.FileContents.Length);
                }

            }
            catch (Exception exp)
            {
                return exp.StackTrace;
            }

            return SuccessCodes.FILE_UPLOAD_SUCCESS;
        }


        public TFileData getDocumentsToDownload(string data)
        {



            string basePath = HttpContext.Current.Server.MapPath(".");
            string businessDataPath = basePath + "\\uploaded\\businessData\\";
            string searchDirectory = null;
            string[] files;
            TFileData tFileData = new TFileData();
            tFileData.fileModel = new List<FileModel>();

            try
            {
                var fileDetails = _serializer.Deserialize<GetDownloadFileModel>(data);
                searchDirectory = businessDataPath + fileDetails.BusinessGUID + "\\" + fileDetails.SelectedYear + "\\";
                //files = Directory.GetFiles(searchDirectory, "*" + fileDetails.fileType + "*");
                files = Directory.GetFiles(searchDirectory);

                foreach (var file in files)
                {
                    tFileData.fileModel.Add(new FileModel()
                    {
                        BusinessGUID = fileDetails.BusinessGUID,
                        SelectedYear = fileDetails.SelectedYear,
                        FileName = Path.GetFileName(file)
                    });
                }


                tFileData.SuccessCode = SuccessCodes.FILE_LIST_RETRIEVED;
                tFileData.SuccessMessage = SuccessMessages.FILE_LIST_RETRIEVED_SUCCESSFULLY_MSG;
                return tFileData;

            }
            catch (Exception exp)
            {
                tFileData.ErrorCode = ErrorCodes.SERVICE_ERROR;
                tFileData.ErrorMessage = exp.StackTrace;
                return tFileData;
            }
        }

        public TBankData saveBankInformation(string data)
        {
            try
            {
                var bankData = _serializer.Deserialize<BankModel>(data);
                return bankBAL.saveBankInformation(bankData);

            }
            catch (Exception exp)
            {
                tBankData.ErrorCode = ErrorCodes.SERVICE_ERROR;
                tBankData.ErrorMessage = exp.StackTrace;

                return tBankData;
            }


        }


        public string uploadITACKN(Stream stream)
        {
            throw new NotImplementedException();
        }

        public TITInfoData saveITInfo(string data)
        {
            try
            {
                var ITInformationData = _serializer.Deserialize<ITInfoModel>(data);
                return iTInfoBAL.saveITInfo(ITInformationData);

            }

            catch (Exception exp)
            {
                tITInfoData.ErrorCode = ErrorCodes.SERVICE_ERROR;
                tITInfoData.ErrorMessage = exp.StackTrace;
                return tITInfoData;

            }
        }


        public TOtherInfoData saveOtherInfo(string data)
        {
            try
            {
                var otherInfoData = _serializer.Deserialize<OtherInfoModel>(data);
                return new OtherInfoBAL().saveOtherInfo(otherInfoData);

            }

            catch (Exception exp)
            {
                tOtherInfoData.ErrorCode = ErrorCodes.SERVICE_ERROR;
                tOtherInfoData.ErrorMessage = exp.StackTrace;

                return tOtherInfoData;
            }
        }


        public TBankData getBankDetails(string businessGUID)
        {
            return bankBAL.getBankDetails(businessGUID);
        }


        public TITInfoData getITDetails(string businessGUID)
        {
            return iTInfoBAL.getITDetails(businessGUID);
        }


        public TOtherInfoData getOtherDetails(string businessGUID)
        {
            
            return otherInfoBAL.getOtherDetails(businessGUID);
        }

       public string downloadFile(string filePath)
        {
            var serverPath = HostingEnvironment.MapPath("~/BusinessServices/uploaded/businessData");
            var fullpath = Path.Combine(serverPath, filePath);

            WebOperationContext.Current.OutgoingResponse.ContentType = "application/octet-stream";
            WebOperationContext.Current.OutgoingResponse.Headers.Add("content-disposition", "inline; filename=" + fullpath);  
          //  return File.OpenRead(fullpath);
            return fullpath;
        }
    }
}