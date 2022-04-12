using JBHRIS.Api.Dto;
using JBHRIS.Api.Dto.System;
using JBHRIS.Api.Dto.Vdb;
using JBHRIS.Api.Service.Interface.System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Flow_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShareUploadController : ControllerBase
    {
        private readonly IShareUploadInterface _IShareUploadInterface;
        private IConfigurationRoot config;

        public ShareUploadController(IShareUploadInterface ShareUploadInterface)
        {
            this._IShareUploadInterface = ShareUploadInterface;
            var builder = new ConfigurationBuilder()
                                    .SetBasePath(Directory.GetCurrentDirectory())
                                    .AddJsonFile("appsettings.json");
            config = builder.Build();
        }


        /// <summary>
        /// 檔案上傳
        /// </summary>
        /// <returns></returns>
        /// 
        [HttpPost, DisableRequestSizeLimit]
        [Route("Save")]
        public ApiResult<bool> Save(IFormFile file, string Company, string Code, string InsertMan)
        {
            ApiResult<bool> result = new ApiResult<bool>();
            try
            {
                //string[] files;
                //int numFiles;
                //string dirFullPath = Server.MapPath("~/Upload/");
                //files = Directory.GetFiles(dirFullPath);
                //numFiles = files.Length;
                //numFiles = numFiles + 1;

                //string str_image = "";

                //foreach (string s in Files)
                //{
                //    FileStream File1 = Files[s];
                //    string fileName = file.FileName;
                //    string fileExtension = file.ContentType;

                //    if (!string.IsNullOrEmpty(fileName))
                //    {
                //        fileExtension = Path.GetExtension(fileName);
                //        str_image = "MyPHOTO_" + numFiles.ToString() + fileExtension;
                //        string pathToSave = HttpContext.Current.Server.MapPath("~/Upload/") + str_image;
                //        File1.CopyTo(pathToSave);
                //    }
                //}
                int numFiles = 0;

                if (file.Length > 0)
                {

                    var dirFullPath = config["Fileupload:Path"];
                    string[] files;
                    files = Directory.GetFiles(dirFullPath);
                    numFiles = files.Length;
                    numFiles = numFiles + 1;
                    dirFullPath = Path.Combine(dirFullPath, "Data" + numFiles.ToString());

                    using (var stream = new FileStream(dirFullPath, FileMode.Create))
                    {

                        file.CopyTo(stream);
                    }
                }

                var fileData = new ShareUploadDto();
                //fileData.Blob = file.OpenReadStream();
                fileData.Code = Code;
                fileData.CompanyId = Company;
                fileData.Size = Convert.ToInt32(file.Length);
                fileData.UploadName = file.FileName;
                fileData.ServerName = "Data" + numFiles.ToString();
                fileData.Type = file.ContentType;
                fileData.SystemCode = "Reply";
                fileData.Note = "";
                fileData.Key1 = "";
                fileData.Key2 = "";
                fileData.Key3 = "";
                fileData.SystemUse = true;
                fileData.Sort = 0;
                fileData.InsertMan = InsertMan;
                fileData.InsertDate = DateTime.Now;
                fileData.UpdateMan = InsertMan;
                fileData.UpdateDate = DateTime.Now;
                result.Result = this._IShareUploadInterface.Save(fileData);
                result.State = true;
            }
            catch (Exception ex)
            {

                result.Message = ex.Message;
            }
            return result;
        }
        /// <summary>
        /// 下載附件
        /// </summary>
        /// <param name="AutoKey"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("DownloadByAutoKey")]
        public async Task<IActionResult> DownloadByAutoKey(int AutoKey)
        {
            //ApiResult<IActionResult> result = new ApiResult<IActionResult>();

            try
            {
                var FileData = this._IShareUploadInterface.GetDataByKey(AutoKey);
                var FileName = FileData.ServerName;
                var dirFullPath = config["Fileupload:Path"];
                dirFullPath = Path.Combine(dirFullPath, FileName);
                var memoryStream = new MemoryStream();
                using (var stream = new FileStream(dirFullPath, FileMode.Open))
                {
                    await stream.CopyToAsync(memoryStream);
                }
                memoryStream.Seek(0, SeekOrigin.Begin);
                var ContentType = FileData.Type;
                FileName = FileData.UploadName;
                return File(memoryStream, ContentType, FileName);
                //result.State = true;
            }
            catch (Exception ex)
            {
                return Ok(new { State = false, Message = "下載失敗" });
                //result.Message = ex.Message;
            }

            //return result;
        }

        /// <summary>
        /// 刪除附件
        /// </summary>
        /// <param name="AutoKey"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("DeleteByAutoKey")]
        public ApiResult<bool> DeleteByAutoKey(int AutoKey)
        {
            ApiResult<bool> result = new ApiResult<bool>();

            try
            {
                var FilePath = config["Fileupload:Path"];
                var FileData = _IShareUploadInterface.GetDataByKey(AutoKey);
                if(FileData != null)
                    FilePath = Path.Combine(FilePath, FileData.ServerName);
                var FileInfo = new FileInfo(FilePath);
                if (FileInfo != null)
                {
                    FileInfo.Delete();
                    result.Result = _IShareUploadInterface.Delete(AutoKey);
                    result.State = true;
                }


                
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
            }

            return result;
        }

        /// <summary>
        /// 根據Code取得附件列表
        /// </summary>
        /// <param name="Code"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetFileListByCode")]
        public ApiResult<List<ShareUploadDto>> GetFileListByCode(string Code)
        {
            ApiResult<List<ShareUploadDto>> result = new ApiResult<List<ShareUploadDto>>();

            try
            {
                result.Result = this._IShareUploadInterface.GetFileListByCode(Code);

                result.State = true;
            }
            catch (Exception ex)
            {

                result.Message = ex.Message;
            }

            return result;
        }
    }
}
