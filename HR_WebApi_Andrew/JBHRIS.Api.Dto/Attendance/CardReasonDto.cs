using System;

namespace JBHRIS.Api.Dto.Attendance
{
    public class CardReasonDto
    {
        /// <summary>
        /// 代碼
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// 代碼描述
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// 影響全勤
        /// </summary>
        public bool EffectsAttend { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        public int Sort { get; set; }
        /// <summary>
        /// 登錄者
        /// </summary>
        public string KeyMan { get; set; }
        /// <summary>
        /// 登錄日期
        /// </summary>
        public DateTime KeyDate { get; set; }
    }
}