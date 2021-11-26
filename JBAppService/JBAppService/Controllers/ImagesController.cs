using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using JBAppService.Api.Dto.Images;
using JBAppService.Api.Service.Interface;
using JBAppService.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Net.Http.Headers;

namespace JBAppService.Controllers
{
   
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {



        

        private readonly JwtHelpers _jwt;

        private readonly IImagesService _imagesService;

        private readonly IConfiguration _configuration;

        public ImagesController(JwtHelpers JwtHelpers  , IImagesService imagesService  , IConfiguration configuration)
        {
            this._jwt = JwtHelpers;
            this._imagesService = imagesService;
            this._configuration = configuration;
        
        }


        /// <summary>
        /// https://docs.microsoft.com/en-us/aspnet/core/mvc/models/file-uploads?view=aspnetcore-3.1
        /// 照片上傳
        /// </summary>
        /// <param name="Images"> .jpeg, .png, .jpg</param>                                                                                                                                                                   
        /// <returns></returns>
        [HttpPost]
        [Route("AsyncUploadImages")]
        public async Task<IActionResult> AsyncUploadImages([FromForm]   ImagesFileDto Dto)
        {

            
            string message = "";
            int Count = 0;
            long size = 0; // Images.Sum(f => f.Length);
                           //限制檔案格式
            List<string> validExts = new List<string> { ".jpeg", ".png", ".jpg" };
            var fileName = string.Empty;

             
            string pathString = this._configuration.GetValue<string>("PathString");

            if (this._imagesService.AsyncUploadImages(Dto,  pathString))
            {
                foreach (var formFile in Dto.Images)
                {
                    if (formFile.Length > 0)
                    {
                        fileName = ContentDispositionHeaderValue.Parse(formFile.ContentDisposition).FileName.Trim().ToString();
                        //Getting file Extension
                        var FileExtension = Path.GetExtension(fileName);

                        //檢查副檔名
                        if (validExts.Contains(FileExtension))
                        {
                            Count++;
                            size += formFile.Length;
                        }
                    }
                }
            }




            return Ok(new { Count = Count, Size = size, Message = message });
        }



        /// <summary>
        /// 顯示打卡上傳照片
        /// </summary>
        /// <param name="Nobr">工號</param>
        /// <param name="ImageID">照片流水號</param>
        /// <returns></returns>
        [HttpGet]
        [Route("ShowImage/{Nobr}/{ImageID}")]
        public FileContentResult ShowImage(string Nobr,  string ImageID)
        {
			//1,091,899.36
            string Path = this._imagesService.GetImagePath(Nobr, ImageID);
            byte[] imageArray = System.IO.File.ReadAllBytes(Path);
            return new FileContentResult(imageArray, new MediaTypeHeaderValue("image/png"));
        }

    }
}
