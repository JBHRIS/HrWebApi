using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace JBHRIS.Api.Dto._System.View
{
    public partial class SysMenuDto
    { 
        /// <summary>
        /// 代碼
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 網址路徑
        /// </summary>
        public string SPath { get; set; }

        /// <summary>
        /// 檔名
        /// </summary>
        public string SFileName { get; set; }

        /// <summary>
        /// 檔案抬頭
        /// </summary>
        public string? SFileTitle { get; set; }

        /// <summary>
        /// 父層代碼
        /// </summary>
        public string SParentKey { get; set; }

        /// <summary>
        /// 路徑
        /// </summary>
        public string SidePath { get; set; }

        /// <summary>
        /// icon位置
        /// </summary>
        public string IconPath { get; set; }

        /// <summary>
        /// icon名稱
        /// </summary>
        public string IconName { get; set; }

        /// <summary>
        /// tag
        /// </summary>
        public string? Tag { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public int IOrder { get; set; }

        /// <summary>
        /// 開新分頁
        /// </summary>
        public bool OpenNewWin { get; set; }

        /// <summary>
        /// 提醒內容
        /// </summary>
        public string NoticeContent { get; set; }

        /// <summary>
        /// 提醒標題
        /// </summary>
        public string NoticeTitle { get; set; }

        /// <summary>
        /// 顯示提醒
        /// </summary>
        public bool DisplayNotice { get; set; }

        /// <summary>
        /// 登入者
        /// </summary>
        public string KeyMan { get; set; }

        /// <summary>
        /// 登入日期
        /// </summary>
        public DateTime? KeyDate { get; set; }
    }
}
