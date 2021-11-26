using System;
using System.Collections.Generic;
using System.Text;

namespace JBAppService.Api.Dto
{
    public class AttEndDetailDto
    {

        /// <summary>
        /// 工號
        /// </summary>
        public string Nobr { get; set; }
        /// <summary>
        /// 日期
        /// </summary>
        public DateTime ADate { get; set; }
        /// <summary>
        /// 班表代碼
        /// </summary>
        public string RoteCode { get; set; }
        /// <summary>
        /// 班表名稱
        /// </summary>
        public string RoteName { get; set; }
        /// <summary>
        /// 班表上班時間
        /// </summary>
        public string ON_Time { get; set; }
        /// <summary>
        /// 班表下班時間
        /// </summary>
        public string OFF_Time { get; set; }
        /// <summary>
        /// 上班刷卡時間
        /// </summary>
        public string T1 { get; set; }
        /// <summary>
        /// 下班刷卡時間
        /// </summary>
        public string T2 { get; set; }


    }
}
