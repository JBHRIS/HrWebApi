using System;
using System.Collections.Generic;
using System.Linq;

namespace HRWebService.Dto.Vdb
{
    /// <summary>
    /// 
    /// </summary>
    public class ShiftRoteVdb
    {
    }

    /// <summary>
    /// 雙人調班資料
    /// </summary>
    public class ShiftRoteByTwoPersonRow
    {
        /// <summary>
        /// 員工代碼1
        /// </summary>
        public string EmpID1 { get; set; }
        /// <summary>
        /// 員工代碼2
        /// </summary>
        public string EmpID2 { get; set; }
        /// <summary>
        /// 開始日期
        /// </summary>
        public string DateB { get; set; }
        /// <summary>
        /// 結束日期
        /// </summary>
        public string DateE { get; set; }
        /// <summary>
        /// 調班日期
        /// </summary>
        public List<string> ListShiftDate { get; set; }
        /// <summary>
        /// 可不可以不等工時調班
        /// </summary>
        public bool IsDifferShift { set; get; }
    }

    /// <summary>
    /// 調班存入資料
    /// </summary>
    public class ShiftRoteBySaveRow
    {
        /// <summary>
        /// 員工代碼1
        /// </summary>
        public string EmpID1 { get; set; }
        /// <summary>
        /// 員工代碼2(單人的情況下，此代碼與1相同)
        /// </summary>
        public string EmpID2 { get; set; }
        /// <summary>
        /// 每一天的班別
        /// </summary>
        public List<ShiftRoteDateRow> ShiftRoteDate { get; set; }
        /// <summary>
        /// 可不可以不等工時調班
        /// </summary>
        public bool IsDifferShift { set; get; }
    }

    /// <summary>
    /// 日期與班別(此調班規則是針對同一天置換不同班別)
    /// </summary>
    public class ShiftRoteDateRow
    {
        /// <summary>
        /// 調班日期
        /// </summary>
        public string ShiftDate { get; set; }
        /// <summary>
        /// 雙人：員工代碼1的班別ID，單人：原始班別
        /// </summary>
        public string RoteID1 { get; set; }
        /// <summary>
        /// 雙人：員工代碼1的班別代碼，單人：原始班別
        /// </summary>
        public string RoteCode1 { get; set; }
        /// <summary>
        /// 雙人：員工代碼1的班別名稱，單人：原始班別
        /// </summary>
        public string RoteName1 { get; set; }
        /// <summary>
        /// 雙人：員工代碼1的班別ID，單人：原始班別資訊
        /// </summary>
        public RoteRow Rote1Info { get; set; }
        /// <summary>
        /// 雙人：員工代碼2的班別iID，單人：新的班別
        /// </summary>
        public string RoteID2 { get; set; }
        /// <summary>
        /// 雙人：員工代碼1的班別代碼，單人：原始班別
        /// </summary>
        public string RoteCode2 { get; set; }
        /// <summary>
        /// 雙人：員工代碼2的班別名稱，單人：原始班別
        /// </summary>
        public string RoteName2 { get; set; }
        /// <summary>
        /// 雙人：員工代碼2的班別ID，單人：原始班別資訊
        /// </summary>
        public RoteRow Rote2Info { get; set; }
    }

    #region 調班單
    /// <summary>
    /// 調班單主檔資訊
    /// </summary>
    public class ShiftRoteFlowAppRow : FlowAppRow
    {
        /// <summary>
        /// 調班類型(單人、雙人、RR、RZ、DD等)
        /// </summary>
        public string ShiftRoteType { set; get; }
        /// <summary>
        /// 調班類型(單人、雙人、RR、RZ、DD等)
        /// </summary>
        public string ShiftRoteName { set; get; }
        /// <summary>
        /// 不等工時調班
        /// </summary>
        public bool DifferShift { set; get; }
        /// <summary>
        /// 調班單主檔資訊
        /// </summary>
        public List<ShiftRoteFlowAppsRow> FlowApps { get; set; }
    }

    /// <summary>
    /// 調班單主檔資訊
    /// </summary>
    public class ShiftRoteFlowAppsRow
    {
        /// <summary>
        /// EmpID1
        /// </summary>
        public string EmpID1 { get; set; }
        /// <summary>
        /// 工號1
        /// </summary>
        public string EmpCode1 { get; set; }
        /// <summary>
        /// 中文姓名1
        /// </summary>
        public string EmpNameC1 { get; set; }
        /// <summary>
        /// EmpID2
        /// </summary>
        public string EmpID2 { get; set; }
        /// <summary>
        /// 工號2
        /// </summary>
        public string EmpCode2 { get; set; }
        /// <summary>
        /// 中文姓名2
        /// </summary>
        public string EmpNameC2 { get; set; }
        /// <summary>
        /// 備註
        /// </summary>
        public string Note { set; get; }
        /// <summary>
        /// 顯示資訊
        /// </summary>
        public string Info { set; get; }
        /// <summary>
        /// 信件內容
        /// </summary>
        public string MailBody { set; get; }
        /// <summary>
        /// 狀態
        /// </summary>
        public string State { set; get; }
        /// <summary>
        /// 調班單明細檔資訊(拆每一天)
        /// </summary>
        public List<ShiftRoteFlowAppsDetailRow> ShiftRoteFlowAppsDetail { set; get; }
        /// <summary>
        /// 部門名稱
        /// </summary>
        public string DeptName1 { set; get; }
        /// <summary>
        /// 部門名稱
        /// </summary>
        public string JobName1 { set; get; }
        /// <summary>
        /// 部門名稱
        /// </summary>
        public string DeptName2 { set; get; }
        /// <summary>
        /// 部門名稱
        /// </summary>
        public string JobName2 { set; get; }
    }

    /// <summary>
    /// 調班單主檔資訊延伸欄位
    /// </summary>
    public class ShiftRoteFlowAppsExtendRow : ShiftRoteFlowAppsRow
    {
        /// <summary>
        /// ProcessID
        /// </summary>
        public int ProcessID { set; get; }
        /// <summary>
        /// 調班類型(單人、雙人、RR、RZ、DD等)
        /// </summary>
        public string ShiftRoteType { set; get; }
        /// <summary>
        /// 調班類型(單人、雙人、RR、RZ、DD等)
        /// </summary>
        public string ShiftRoteName { set; get; }

        private List<ShiftRoteFlowAppsDetailExtendRow> _ShiftRoteFlowAppsDetail { get; set; }
        /// <summary>
        /// 調班單明細檔資訊(拆每一天)
        /// </summary>
        public new List<ShiftRoteFlowAppsDetailExtendRow> ShiftRoteFlowAppsDetail
        {
            set
            {
                _ShiftRoteFlowAppsDetail = value;
                base.ShiftRoteFlowAppsDetail = value.Cast<ShiftRoteFlowAppsDetailRow>().ToList();
            }
            get
            {
                return _ShiftRoteFlowAppsDetail;
            }
        }
    }

    /// <summary>
    /// 調班單明細檔資訊(拆每一天)
    /// </summary>
    public class ShiftRoteFlowAppsDetailRow
    {
        /// <summary>
        /// 調班日期1
        /// </summary>
        public string ShiftRoteDate { set; get; }
        /// <summary>
        /// RoteID1
        /// </summary>
        public int RoteID1 { set; get; }
        /// <summary>
        /// 班別代碼1
        /// </summary>
        public string RoteCode1 { set; get; }
        /// <summary>
        /// 班別名稱1
        /// </summary>
        public string RoteName1 { set; get; }
        /// <summary>
        /// RoteID2
        /// </summary>
        public int RoteID2 { set; get; }
        /// <summary>
        /// 班別代碼2
        /// </summary>
        public string RoteCode2 { set; get; }
        /// <summary>
        /// 班別名稱2
        /// </summary>
        public string RoteName2 { set; get; }

        /// <summary>
        /// RoteID1
        /// </summary>
        public int RoteID1c { set; get; }
        /// <summary>
        /// 班別代碼1
        /// </summary>
        public string RoteCode1c { set; get; }
        /// <summary>
        /// 班別名稱1
        /// </summary>
        public string RoteName1c { set; get; }
        /// <summary>
        /// RoteID2
        /// </summary>
        public int RoteID2c { set; get; }
        /// <summary>
        /// 班別代碼2
        /// </summary>
        public string RoteCode2c { set; get; }
        /// <summary>
        /// 班別名稱2
        /// </summary>
        public string RoteName2c { set; get; }
    }

    /// <summary>
    /// 調班單明細檔資訊(拆每一天)延伸欄位
    /// </summary>
    public class ShiftRoteFlowAppsDetailExtendRow : ShiftRoteFlowAppsDetailRow
    {
        private DateTime _ShiftRoteDate;
        /// <summary>
        /// 調班日期
        /// </summary>
        public new DateTime ShiftRoteDate
        {
            set
            {
                _ShiftRoteDate = value;
                base.ShiftRoteDate = value.ToString();
            }
            get
            {
                return _ShiftRoteDate;
            }
        }

        /// <summary>
        /// RoteID1Info
        /// </summary>
        public RoteRow RoteID1Info { set; get; }
        /// <summary>
        /// RoteID2Info
        /// </summary>
        public RoteRow RoteID2Info { set; get; }
        /// <summary>
        /// RoteID1Info
        /// </summary>
        public RoteRow RoteID1cInfo { set; get; }
        /// <summary>
        /// RoteID2Info
        /// </summary>
        public RoteRow RoteID2cInfo { set; get; }
    }
    #endregion
}
