using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OldBll.Att.Vdb
{
    /// <summary>
    /// HcodeVdb
    /// </summary>
    public class HcodeVdb
    {
        /// <summary>
        /// 假別資料
        /// </summary>
        public List<HcodeTable> HcodeData { get; set; }
        /// <summary>
        /// 假別資料 細項
        /// </summary>
        public List<HcodeDetailTable> HcodeDetailData { get; set; }
    }

    /// <summary>
    /// 假別資料
    /// </summary>
    public class HcodeTable
    {
        /// <summary>
        /// 代碼
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// 顯示代碼
        /// </summary>
        public string CodeDisp { get; set; }
        /// <summary>
        /// 中文名稱
        /// </summary>
        public string NameC { get; set; }
        /// <summary>
        /// 英文名稱
        /// </summary>
        public string NameE { get; set; }
        /// <summary>
        /// 可請上限
        /// </summary>
        public decimal Max { get; set; }
        /// <summary>
        /// 得假長度
        /// </summary>
        public int AbstLen { get; set; }
        /// <summary>
        /// 得假單位年月日
        /// </summary>
        public string AbstUnit { get; set; }
        /// <summary>
        /// 單位
        /// </summary>
        public OldBll.MT.mtEnum.HcodeUnit Unit { get; set; }
    }

    /// <summary>
    /// 假別資料
    /// </summary>
    public class HcodeTable1
    {
        /// <summary>
        /// 代碼
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// 顯示代碼
        /// </summary>
        public string CodeDisp { get; set; }
        /// <summary>
        /// 中文名稱
        /// </summary>
        public string NameC { get; set; }
        /// <summary>
        /// 英文名稱
        /// </summary>
        public string NameE { get; set; }
        /// <summary>
        /// 可請上限
        /// </summary>
        public decimal Max { get; set; }
        /// <summary>
        /// 得假長度
        /// </summary>
        public int AbstLen { get; set; }
        /// <summary>
        /// 得假單位年月日
        /// </summary>
        public string AbstUnit { get; set; }
        /// <summary>
        /// 單位
        /// </summary>
        public string Unit { get; set; }
    }

    public class BalanceHcodeRow
    {
        public string Hcode { get; set; }
        public string HcodeName { get; set; }
        public string HType { get; set; }
        public OldBll.MT.mtEnum.HcodeUnit Unit { get; set; }
        public string Flag { get; set; }
        public bool DisplayForm { get; set; }
        public int Sort { get; set; }
        public bool HaveDCode { get; set; }
        public string DCode { get; set; }
        public OldBll.MT.mtEnum.HcodeUnit CalUnit { get; set; }
        public decimal CalNum { get; set; }
        public decimal CalMax { get; set; }
        public int CalEnd { get; set; }
        public DateTime CalDateTimeB { get; set; }
        public DateTime CalDateTimeE { get; set; }
        public bool CheckBalance { get; set; }
    }

    /// <summary>
    /// 假別資料 細項
    /// </summary>
    public class HcodeDetailTable
    {
        /// <summary>
        /// 代碼
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// 中文名稱
        /// </summary>
        public string NameC { get; set; }
        /// <summary>
        /// 英文名稱
        /// </summary>
        public string NameE { get; set; }
        /// <summary>
        /// 包含假日
        /// </summary>
        public bool InHoli { get; set; }
        /// <summary>
        /// 最小數
        /// </summary>
        public decimal Min { get; set; }
        /// <summary>
        /// 最小數(全部)
        /// </summary>
        public decimal MinTotal { get; set; }
        /// <summary>
        /// 間隔數
        /// </summary>
        public decimal Interval { get; set; }
        /// <summary>
        /// 可請上限
        /// </summary>
        public decimal Max { get; set; }
        /// <summary>
        /// 單位
        /// </summary>
        public OldBll.MT.mtEnum.HcodeUnit Unit { get; set; }
        /// <summary>
        /// 計算單位
        /// </summary>
        public OldBll.MT.mtEnum.HcodeUnit CalUnit { get; set; }
        /// <summary>
        /// 性別
        /// </summary>
        public OldBll.MT.mtEnum.SexCategroy Sex { get; set; }
        /// <summary>
        /// 是否顯示
        /// </summary>
        public bool DisplayForm { get; set; }
        /// <summary>
        /// 是否檢查剩餘數
        /// </summary>
        public bool CheckBalance { get; set; }
        /// <summary>
        /// 檢查是否要上傳附件
        /// </summary>
        public bool CheckUploadFlie { get; set; }
        /// <summary>
        /// 順序
        /// </summary>
        public int Sort { get; set; }
        /// <summary>
        /// 年補休特性
        /// </summary>
        public string YearRest { get; set; }
        /// <summary>
        /// 反向關聯假別代碼
        /// </summary>
        public string Dcode { get; set; }
        /// <summary>
        /// 得假長度
        /// </summary>
        public int AbstLen { get; set; }
        /// <summary>
        /// 得假單位年月日
        /// </summary>
        public string AbstUnit { get; set; }
        /// <summary>
        /// 站別
        /// </summary>
        public bool Station { get; set; }
        /// <summary>
        /// 起點要給特殊的人
        /// </summary>
        public string FlowGo { get; set; }
        /// <summary>
        /// 終點要給特殊的人
        /// </summary>
        public string FlowFinal { get; set; }
        /// <summary>
        /// 群組假別代碼
        /// </summary>
        public string GroupCode { get; set; }
        /// <summary>
        /// 天災日計算
        /// </summary>
        public bool CalOt { get; set; }
    }
}
