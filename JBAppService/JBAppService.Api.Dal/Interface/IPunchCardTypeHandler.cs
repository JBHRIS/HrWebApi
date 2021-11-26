using JBAppService.Api.Dto.ItemObject;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBAppService.Api.Dal.Interface
{
    public interface IPunchCardTypeHandler
    {

      
        /// <summary>
        /// 取得打卡類型
        /// </summary>
        /// <returns></returns>
       List<ItemObject> GetPunchCardType();
    }
}
