using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Hangfire.Annotations;
using JBHRIS.Api.Dal.JBHR;
using JBHRIS.Api.Dto;
using JBHRIS.Api.Dto._System.View;
using JBHRIS.Api.Service.Menu.View;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLog;

namespace HR_WebApi.Controllers.Menu
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private IMenuService _menuService;
        private ILogger _logger;
        public MenuController(IMenuService menuService, ILogger logger)
        {
            _menuService = menuService;
            _logger = logger;
        }
        /// <summary>
        /// 取得選單功能
        /// </summary>
        /// <param name="code">根節點(Menu)</param>
        [Route("GetMenu")]
        [HttpGet]
        [Authorize(Roles = "Menu/GetMenu,Admin")]
        public ApiResult<List<SysMenuDto>> GetMenu(string code)
        {
            _logger.Info("開始呼叫MenuService.GetMenu");
            ApiResult<List<SysMenuDto>> apiResult = new ApiResult<List<SysMenuDto>>();
            apiResult.State = false;
            try
            {
                var Nobr = User.Identity.Name;
                apiResult.Result = _menuService.GetMenu(code, Nobr);
                apiResult.State = true;
            }
            catch (Exception ex)
            {
                apiResult.Message = ex.ToString();
            }
            return apiResult;
        }

        /// <summary>
        /// 取得所有選單功能
        /// </summary>
        /// <param name="code">根節點(Root)</param>
        [Route("GetAllMenu")]
        [HttpGet]
        [Authorize(Roles = "Menu/GetAllMenu,Admin")]
        public ApiResult<List<SysMenuDto>> GetAllMenu(string code)
        {
            _logger.Info("開始呼叫MenuService.GetAllMenu");
            ApiResult<List<SysMenuDto>> apiResult = new ApiResult<List<SysMenuDto>>();
            apiResult.State = false;
            try
            {
                apiResult.Result = _menuService.GetAllMenu(code);
                apiResult.State = true;
            }
            catch (Exception ex)
            {
                apiResult.Message = ex.ToString();
            }
            return apiResult;
        }

        /// <summary>
        /// 搜尋選單功能
        /// </summary>
        /// <param name="code">根節點(Menu)</param>
        /// <param name="keyword">查詢字</param>
        [Route("GetFeatures")]
        [HttpGet]
        [Authorize(Roles = "Menu/GetFeatures,Admin")]
        public ApiResult<List<SysMenuDto>> GetFeatures(string code,string keyword)
        {
            _logger.Info("開始呼叫MenuService.GetFeatures");
            ApiResult<List<SysMenuDto>> apiResult = new ApiResult<List<SysMenuDto>>();
            apiResult.State = false;
            try
            {
                var Nobr = User.Identity.Name;
                apiResult.Result = _menuService.GetFeatures(code,keyword, Nobr);
                apiResult.State = true;
            }
            catch (Exception ex)
            {
                apiResult.Message = ex.ToString();
            }
            return apiResult;
        }

        /// <summary>
        /// 取得首頁功能
        /// </summary>
        /// <param name="Nobr">工號</param>
        [Route("GetIndexFeatures")]
        [HttpGet]
        [Authorize(Roles = "Menu/GetIndexFeatures,Admin")]
        public ApiResult<List<SysMenuDto>> GetIndexFeatures(string Nobr)
        {
            _logger.Info("開始呼叫MenuService.GetFeatures");
            ApiResult<List<SysMenuDto>> apiResult = new ApiResult<List<SysMenuDto>>();
            apiResult.State = false;
            try
            {
                apiResult.Result = _menuService.GetIndexFeatures(Nobr);
                apiResult.State = true;
            }
            catch (Exception ex)
            {
                apiResult.Message = ex.ToString();
            }
            return apiResult;
        }

        /// <summary>
        /// 新增選單功能
        /// </summary>
        [Route("InsertMenu")]
        [HttpPost]
        [Authorize(Roles = "Menu/InsertMenu,Admin")]
        public ApiResult<string> InsertMenu(SysMenuDto sysMenuDto)
        {
            _logger.Info("開始呼叫MenuService.InsertMenu");
            ApiResult<string> apiResult = new ApiResult<string>();
            apiResult.State = false;
            try
            {
                apiResult.State = _menuService.InsertMenu(sysMenuDto);
            }
            catch (Exception ex)
            {
                apiResult.Message = ex.ToString();
            }
            return apiResult;
        }

        /// <summary>
        /// 更新選單功能
        /// </summary>
        [Route("UpdateMenu")]
        [HttpPut]
        [Authorize(Roles = "Menu/UpdateMenu,Admin")]
        public ApiResult<string> UpdateMenu(SysMenuDto sysMenuDto)
        {
            _logger.Info("開始呼叫MenuService.UpdateMenu");
            ApiResult<string> apiResult = new ApiResult<string>();
            apiResult.State = false;
            try
            {
                apiResult.State = _menuService.UpdateMenu(sysMenuDto);
            }
            catch (Exception ex)
            {
                apiResult.Message = ex.ToString();
            }
            return apiResult;
        }

        /// <summary>
        /// 刪除選單功能
        /// </summary>
        [Route("DeleteMenu")]
        [HttpDelete]
        [Authorize(Roles = "Menu/DeleteMenu,Admin")]
        public ApiResult<string> DeleteMenu(string code)
        {
            _logger.Info("開始呼叫MenuService.DeleteMenu");
            ApiResult<string> apiResult = new ApiResult<string>();
            apiResult.State = false;
            try
            {
                apiResult = _menuService.DeleteMenu(code);
            }
            catch (Exception ex)
            {
                apiResult.Message = ex.ToString();
            }
            return apiResult;
        }

    }
}
