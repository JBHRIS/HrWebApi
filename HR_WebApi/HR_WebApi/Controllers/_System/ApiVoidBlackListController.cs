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
    public class ApiVoidBlackListController : ControllerBase
    {
        private ISysApiVoidBlackListService _sysApiVoidBlackListService;
        private ILogger _logger;

        /// <summary>
        /// 建構子
        /// </summary>
        /// <param name="sysApiVoidBlackListService">方法黑名單</param>
        public ApiVoidBlackListController(ISysApiVoidBlackListService sysApiVoidBlackListService,
           ILogger logger
            )
        {
            _sysApiVoidBlackListService = sysApiVoidBlackListService;
            _logger = logger;
        }

        /// <summary>
        /// 取得方法黑名單
        /// </summary>
        /// <param name="nobr">員工號</param>
        /// <returns>方法黑名單資料</returns>
        [Route("GetApiVoidBlackList")]
        [HttpPost]
        [Authorize(Roles = "ApiVoidBlackList/GetApiVoidBlackList,Admin")]
        public ApiResult<List<SysApiVoidBlackListDto>> GetApiVoidBlackList(List<string> nobr)
        {
            _logger.Info("開始呼叫SysApiVoidBlackListService.GetApiVoidBlackListView");
            ApiResult<List<SysApiVoidBlackListDto>> apiResult = new ApiResult<List<SysApiVoidBlackListDto>>();
            apiResult.State = false;
            try
            {
                apiResult.Result = _sysApiVoidBlackListService.GetApiVoidBlackListView(nobr);
                apiResult.State = true;
            }
            catch (Exception ex)
            {
                apiResult.Message = ex.ToString();
            }
            return apiResult;
        }

        /// <summary>
        /// 新增方法黑名單
        /// </summary>
        [Route("InsertApiVoidBlackList")]
        [HttpPost]
        [Authorize(Roles = "ApiVoidBlackList/InsertApiVoidBlackList,Admin")]
        public ApiResult<string> InsertApiVoidBlackList(SysApiVoidBlackListEntry sysApiVoidBlackListEntry)
        {
            _logger.Info("開始呼叫SysApiVoidBlackListService.InsertApiVoidBlackList");
            var KeyMan = User.Identity.Name;
            if (KeyMan == null) KeyMan = "";
            return _sysApiVoidBlackListService.InsertApiVoidBlackListView(sysApiVoidBlackListEntry, KeyMan);
        }

        /// <summary>
        /// 刪除方法黑名單
        /// </summary>
        [Route("DeleteApiVoidBlackList")]
        [HttpDelete]
        [Authorize(Roles = "ApiVoidBlackList/DeleteApiVoidBlackList,Admin")]
        public ApiResult<string> DeleteApiVoidBlackList(SysApiVoidBlackListEntry sysApiVoidBlackListEntry)
        {
            _logger.Info("開始呼叫SysApiVoidBlackListService.DeleteApiVoidBlackList");
            return _sysApiVoidBlackListService.DeleteApiVoidBlackListView(sysApiVoidBlackListEntry);
        }

    }
}
