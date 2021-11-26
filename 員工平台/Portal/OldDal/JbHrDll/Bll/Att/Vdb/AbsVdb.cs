using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OldBll.Att.Vdb
{
    /// <summary>
    /// 對沖用
    /// </summary>
    public class AbsSubRow
    {
        /// <summary>
        /// 對沖id
        /// </summary>
        public string guid { get; set; }

        /// <summary>
        /// 數量
        /// </summary>
        public decimal use { get; set; }
    }

    public class AbsVdb
    {
        public List<AbsDataTable> AbsData { set; get; }
    }

    public class AbsCalculateRow
    {
        public decimal TotalUse { set; get; }
        public decimal TotalDay { set; get; }
        public List<AbsRow> Day { set; get; }
    }

    public class AbsRow
    {
        public string Nobr { set; get; }
        public DateTime DateB { set; get; }
        public DateTime DateE { set; get; }
        public string TimeB { set; get; }
        public string TimeE { set; get; }
        public DateTime DateTimeB { set; get; }
        public DateTime DateTimeE { set; get; }
        public string Hcode { set; get; }
        public decimal Use { set; get; }
        public string Serno { set; get; }
        public string NameA { set; get; }
        public bool NoCal { set; get; }
        public string AgentNobr { set; get; }
        public decimal Day { set; get; }
    }

    public class AbstRow
    {
        public string Nobr { set; get; }
        public DateTime DateB { set; get; }
        public DateTime DateE { set; get; }
        public string Hcode { set; get; }
        public decimal Use { set; get; }
        public string NameA { set; get; }
    }

    public class BalanceAbstRow
    {
        public DateTime DateB { set; get; }
        public DateTime DateE { set; get; }
        public string Hcode { set; get; }
        public string HcodeName { set; get; }
        public OldBll.MT.mtEnum.HcodeUnit Unit { set; get; }
        public string HType { set; get; }
        public decimal Max { set; get; }
        public decimal Use { set; get; }
        public decimal Balance { set; get; }
        public string Guid { set; get; }
        public string Serno { get; set; }

        public string TimeB { get; set; }
        public string TimeE { get; set; }
    }

    public class BalanceAbsRow
    {
        public DateTime DateB { set; get; }
        public string Hcode { set; get; }
        public decimal Use { set; get; }
    }

    public class AbsBalanceRow
    {
        public string Hcode { set; get; }
        public string HcodeName { set; get; }
        public DateTime DateB { set; get; }
        public DateTime DateE { set; get; }
        public OldBll.MT.mtEnum.HcodeUnit HcodeUnit { set; get; }
        public string HcodeUnitName { set; get; }
        public decimal Max { set; get; }
        public decimal Use { set; get; }
        public decimal Balance { set; get; }
        public decimal RealBalance { set; get; }
        public decimal MaxGroup { set; get; }
        public decimal UseGroup { set; get; }
        public decimal BalanceGroup { set; get; }
        public decimal RealBalanceGroup { set; get; }
        public bool DisplayForm { set; get; }
        public int Sort { set; get; }
        public int CalCate { set; get; }
        public List<string> HcodeGroup { set; get; }
        public List<string> lsGuid { set; get; }
        public bool CheckBalance { set; get; }
        public int FlowCount { set; get; }
    }

    public class AbsDataTable
    {
        public string Nobr { set; get; }
        public string Name { set; get; }
        public DateTime DateB { set; get; }
        public DateTime DateE { set; get; }
        public string TimeB { set; get; }
        public string TimeE { set; get; }
        public DateTime DateTimeB { set; get; }
        public DateTime DateTimeE { set; get; }
        public string Hcode { set; get; }
        public string HcodeName { set; get; }
        public OldBll.MT.mtEnum.HcodeUnit HcodeUnit { set; get; }
        public string HcodeUnitName { set; get; }
        public decimal Use { set; get; }
        public string Serno { set; get; }
        public string NameA { set; get; }
        public bool NoCal { set; get; }
        public string Guid { set; get; }
        public string Note { set; get; }
    }

    public class AbsWDataTable
    {
        public string Nobr { set; get; }
        public DateTime DateB { set; get; }
        public DateTime DateE { set; get; }
        public string TimeB { set; get; }
        public string TimeE { set; get; }
        public DateTime DateTimeB { set; get; }
        public DateTime DateTimeE { set; get; }
        public string Hcode { set; get; }
        public decimal ObtainUse { set; get; }
        public decimal BalanceUse { set; get; }
        public string Serno { set; get; }
        public List<AbsDataTable> AbsData { set; get; }
    }

    public class AbsdDataTable
    {
        public string AbsAdd { set; get; }
        public string AbsSubtract { set; get; }
        public decimal Use { set; get; }
    }
}