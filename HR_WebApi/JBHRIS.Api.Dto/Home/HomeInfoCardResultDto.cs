using JBHRIS.Api.Dto;
using System.Collections.Generic;

namespace JBHRIS.Api.Dto.Home
{
    /// <summary>
    /// 首頁資訊卡-結果
    /// </summary>
    public class HomeInfoCardResultDto : ApiResult<List<string>>
    {
        /// <summary>
        /// 取得首頁資訊卡
        /// </summary>
        /// <returns></returns>
        public List<HomeInfoCardDto> GetHomeInfoCards()
        {
            return null;
        }
    }
}