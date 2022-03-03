using Bll.Employee.Vdb;
using Bll.Files.Vdb;
using Bll.Tools;
using Dal.Dao.Employee;
using Dal.Dao.Files;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Portal
{
    /// <summary>
    /// Reply 的摘要描述
    /// </summary>
    public class Reply : IHttpHandler
    {
        public class MemoryPostedFile : HttpPostedFileBase
        {
            private readonly byte[] fileBytes;

            public MemoryPostedFile(byte[] fileBytes, string fileName = null, string contentType = null)
            {
                this.fileBytes = fileBytes;
                this.FileName = fileName;
                this.InputStream = new MemoryStream(fileBytes);
                this.ContentType = contentType;
            }

            public override string ContentType { get; }
            public override int ContentLength => this.fileBytes.Length;

            public override string FileName { get; }

            public override Stream InputStream { get; }
        }
        public void ProcessRequest(HttpContext context)
        {
            string FileInfo = "";
            if (context.Request.Params["FileInfo"] != null && context.Request.Params["FileInfo"] != "")
                FileInfo = context.Request.Params["FileInfo"];
            var _User = UnobtrusiveSession.Session["UserData"] as User;
            var CompanySetting = UnobtrusiveSession.Session["CompanySetting"] as Bll.Share.Vdb.CompanySettingRow;
            var oEncryptHepler = new EncryptHepler();
            var ReplySite = System.Web.Configuration.WebConfigurationManager.AppSettings["ReplySite"];
            var AccessToken = _User.AccessToken;
            var RefreshToken = _User.RefreshToken;
            var CompanyId =  "" ;
            if (CompanySetting != null)
                CompanyId = CompanySetting.AccountCode;
            var EmpId = _User.EmpId;
            var EmpName = _User.EmpName;
            var Role = 64;
            var Email = "";
            var Parameter = "";
            var FileTicket = Guid.NewGuid().ToString();
            var UserData = new List<string>();

            var ListEmpid = new List<string>();
            ListEmpid.Add(_User.EmpId);
            var oEmployeeInfoView = new EmployeeInfoViewDao();
            var EmployeeInfoViewCond = new EmployeeInfoViewConditions();
            EmployeeInfoViewCond.AccessToken = _User.AccessToken;
            EmployeeInfoViewCond.RefreshToken = _User.RefreshToken;
            EmployeeInfoViewCond.ListEmpId = ListEmpid;
            var EmployeeInfoViewResult = oEmployeeInfoView.GetData(EmployeeInfoViewCond);

            if (EmployeeInfoViewResult.Status)
            {
                if (EmployeeInfoViewResult.Data != null)
                {
                    var rs = EmployeeInfoViewResult.Data as List<EmployeeInfoViewRow>;
                    if (rs.Count != 0)
                    {
                        Email = rs[0].EMail;
                    }
                }
            }

            var bytes = Convert.FromBase64String(FileInfo);
            HttpPostedFileBase objFile = (HttpPostedFileBase)new MemoryPostedFile(bytes, "Pic", "application/pdf");
            
            //var oImportAttend = new ImportAttendExcelCoverDao();
            //var ImportAttendCond = new ImportAttendExcelCoverConditions();
            //ImportAttendCond.AccessToken = _User.AccessToken;
            //ImportAttendCond.RefreshToken = _User.RefreshToken;
            //ImportAttendCond.CompanySetting = CompanySetting;
            //ImportAttendCond.SheetName = ddlSheetName.Text;
            //ImportAttendCond.file = objFile;

            //var Result = oImportAttend.GetData(ImportAttendCond);
            var oUploadMultipleDao = new UploadMultipleInPostedFileBaseDao();
            var UploadMultipleCond = new UploadMultipleInPostedFileBaseConditions();
            UploadMultipleCond.AccessToken = _User.AccessToken;
            UploadMultipleCond.RefreshToken = _User.RefreshToken;
            UploadMultipleCond.CompanySetting = CompanySetting;
            UploadMultipleCond.FileTicket = FileTicket;
            UploadMultipleCond.files = objFile;
            var Result = oUploadMultipleDao.GetData(UploadMultipleCond);

            //if (Result.Status)
            //{

            //}
            //else
            //{
            //}

            if (_User.Role != null && (_User.Role.Contains("HR") || _User.Role.Contains("Hr")))
            {
                Role = 8;

                UserData.Add(AccessToken);
                UserData.Add(RefreshToken);
                UserData.Add(CompanyId);
                UserData.Add(EmpId);
                UserData.Add(EmpName);
                UserData.Add(Role.ToString());
                UserData.Add(FileTicket);
                UserData.Add(Email);
                //UserData.Add(System.Text.Encoding.UTF8.GetString(FileInfo));
                //UserData.Add(FileInfo);
                Parameter = JsonConvert.SerializeObject(UserData);
                //Response.Redirect(ReplySite + "?Param=" + Server.UrlEncode(oEncryptHepler.Encrypt(Parameter)));
            }
            else
            {
                UserData.Add(AccessToken);
                UserData.Add(RefreshToken);
                UserData.Add(CompanyId);
                UserData.Add(EmpId);
                UserData.Add(EmpName);
                UserData.Add(Role.ToString());
                UserData.Add(FileTicket);
                UserData.Add(Email);
                //UserData.Add(System.Text.Encoding.UTF8.GetString(FileInfo));
                //UserData.Add(FileInfo);
                Parameter = JsonConvert.SerializeObject(UserData);
                //Response.Redirect(ReplySite + "?Param=" + Server.UrlEncode(oEncryptHepler.Encrypt(Parameter)));
            }
            context.Response.Redirect(ReplySite + "?Param=" + context.Server.UrlEncode(oEncryptHepler.Encrypt(Parameter)));
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}