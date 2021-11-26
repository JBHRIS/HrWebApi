using JBHRIS.Api.Dto;
using JBHRIS.Api.Service.Interface.ezEngineServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Flow_WebApi.Controllers.ezEngineServices
{
    [Route("api/[controller]")]
    [ApiController]
    public class CImageController : ControllerBase
    {

        private ICImageInterface _ICImageInterface;
        public CImageController(ICImageInterface cImageInterface)
        {
            this._ICImageInterface = cImageInterface;
        }

        /// <summary>
        /// 取得流程圖
        /// </summary>
        /// <param name="idProcess"></param>
        /// <returns>Image</returns>
        [HttpGet]
        [Route("FlowImageByIdProcess")]
        public ApiResult<string> FlowImageByIdProcess(int idProcess)
        {



            
            
             ApiResult<string> mapiResult = new ApiResult<string>();

            mapiResult.State = false;
            try
            {
                var Image = this._ICImageInterface.FlowImageByID(idProcess);
                var Buffer = this._ICImageInterface.ImageToBuffer(Image, System.Drawing.Imaging.ImageFormat.Jpeg);
                mapiResult.Result = Convert.ToBase64String(Buffer);
                mapiResult.State = true;

            }
            catch (Exception ex)
            {

                mapiResult.Message = ex.Message;
            }

            return mapiResult;
        }



        /// <summary>
        /// 取得流程圖
        /// </summary>
        /// <param name="idProcess"></param>
        /// <param name="x">水平起始位置</param>
        /// <param name="y">垂直起始位置</param>
        /// <param name="iWidth">圖片寬度</param>
        /// <param name="iHeight">圖片高度</param>
        /// <param name="bHeader">是否要表頭</param>
        /// <returns>Image</returns>
        [HttpGet]
        [Route("FlowImage")]
        public ApiResult<string> FlowImage(int idProcess, int x = 0, int y = 0, int iWidth = 600, int iHeight = 0, bool bHeader = true)
        {

            ApiResult<string> mapiResult = new ApiResult<string>();
            

            mapiResult.State = false;
            try
            {
                mapiResult.Result = "data:image/jpg;base64," + Convert.ToBase64String(this._ICImageInterface.ImageToBuffer(this._ICImageInterface.FlowImage(idProcess, x, y, iWidth, 0, true), System.Drawing.Imaging.ImageFormat.Jpeg)); 
                mapiResult.State = true;
                
            }
            catch (Exception ex)
            {

                mapiResult.Message = ex.Message;
            }

            return mapiResult;

        }



        



        
    }
}
