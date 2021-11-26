using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLog;
using JBHRIS.Api.Dto;
using Microsoft.AspNetCore.Authorization;
using JBHRIS.Api.Dto._System.View;
using JBHRIS.Api.Dto._System.Entry;
using JBHRIS.Api.Service._System.View;

namespace HR_WebApi.Controllers._System
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiVoidWhiteListController : ControllerBase
    {
        private ISysApiVoidWhiteListService _sysApiVoidWhiteListService;
        private ILogger _logger;

        /// <summary>
        /// 建構子
        /// </summary>
        /// <param name="sysApiVoidWhiteListService">方法白名單</param>
        public ApiVoidWhiteListController(ISysApiVoidWhiteListService sysApiVoidWhiteListService,
           ILogger logger
            )
        {
            _sysApiVoidWhiteListService = sysApiVoidWhiteListService;
            _logger = logger;
        }

        /// <summary>
        /// 取得方法白名單
        /// </summary>
        /// <param name="nobr">員工號</param>
        /// <returns>方法白名單資料</returns>
        [Route("GetApiVoidWhiteList")]
        [HttpPost]
        [Authorize(Roles = "ApiVoidWhiteList/GetApiVoidWhiteList,Admin")]
        public ApiResult<List<SysApiVoidWhiteListDto>> GetApiVoidWhiteList(List<string> nobr)
        {
            _logger.Info("開始呼叫SysApiVoidWhiteListService.GetApiVoidWhiteListView");
            ApiResult<List<SysApiVoidWhiteListDto>> apiResult = new ApiResult<List<SysApiVoidWhiteListDto>>();
            apiResult.State = false;
            try
            {
                apiResult.Result = _sysApiVoidWhiteListService.GetApiVoidWhiteListView(nobr);
                apiResult.State = true;
            }
            catch (Exception ex)
            {
                apiResult.Message = ex.ToString();
            }
            return apiResult;
        }

        /// <summary>
        /// 新增方法白名單
        /// </summary>
        [Route("InsertApiVoidWhiteList")]
        [HttpPost]
        [Authorize(Roles = "ApiVoidWhiteList/InsertApiVoidWhiteList,Admin")]
        public ApiResult<string> InsertApiVoidWhiteList(SysApiVoidWhiteListEntry sysApiVoidWhiteListEntry)
        {
            _logger.Info("開始呼叫SysApiVoidWhiteListService.InsertApiVoidWhiteList");
            var KeyMan = User.Identity.Name;
            if (KeyMan == null) KeyMan = "";
            return _sysApiVoidWhiteListService.InsertApiVoidWhiteListView(sysApiVoidWhiteListEntry, KeyMan);
        }

        /// <summary>
        /// 刪除方法白名單
        /// </summary>
        [Route("DeleteApiVoidWhiteList")]
        [HttpDelete]
        [Authorize(Roles = "ApiVoidWhiteList/DeleteApiVoidWhiteList,Admin")]
        public ApiResult<string> DeleteApiVoidWhiteList(SysApiVoidWhiteListEntry sysApiVoidWhiteListEntry)
        {
            _logger.Info("開始呼叫SysApiVoidWhiteListService.DeleteApiVoidWhiteList");
            return _sysApiVoidWhiteListService.DeleteApiVoidWhiteListView(sysApiVoidWhiteListEntry);
        }

    }
}
