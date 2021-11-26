using System;
using System.Collections.Generic;

namespace HRWebService.Dto.Vdb
{ /// <summary>
  /// 
  /// </summary>
    public class OtVdb
    {
    }

    /// <summary>
    /// 加班原因
    /// </summary>
    public class OtCauseRow
    {
        /// <summary>
        /// 加班原因代碼
        /// </summary>
        public string CauseID { get; set; }
        /// <summary>
        /// 加班原因可見代碼
        /// </summary>
        public string CauseCode { get; set; }
        /// <summary>
        /// 加班原因名稱
        /// </summary>
        public string CauseNameC { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        public int Seq { get; set; }
        /// <summary>
        /// 緊急CallIn
        /// </summary>
        public bool OnCall { get; set; }
        /// <summary>
        /// 不顯示
        /// </summary>
        public bool NotDisplay { set; get; }
        /// <summary>
        /// 不計算
        /// </summary>
        public bool NotCalculate { set; get; }
        /// <summary>
        /// 無誤餐
        /// </summary>
        public bool NotFood { set; get; }
        /// <summary>
        /// 不檢查刷卡
        /// </summary>
        public bool NotCheckCard { set; get; }
        /// <summary>
        /// 假日加班
        /// </summary>
        public bool Holiday { set; get; }
        /// <summary>
        /// 假日型別
        /// </summary>
        public string HolidayTypeID { set; get; }
        /// <summary>
        /// 加班倍率
        /// </summary>
        public int RateMasterID { set; get; }
    }

    /// <summary>
    /// 加班資料
    /// </summary>
    public class OtRow
    {
        /// <summary>
        /// OtID
        /// </summary>
        public string OtID { set; get; }
        /// <summary>
        /// 員工代碼
        /// </summary>
        public string EmpID { set; get; }
        /// <summary>
        /// 加班日期
        /// </summary>
        public DateTime DateB { set; get; }
        /// <summary>
        /// 加班開始時間
        /// </summary>
        public string TimeB { set; get; }
        /// <summary>
        /// 加班結束時間
        /// </summary>
        public string TimeE { set; get; }
        /// <summary>
        /// 加班開始日期時間
        /// </summary>
        public DateTime DateTimeB { set; get; }
        /// <summary>
        /// 加班結束日期時間
        /// </summary>
        public DateTime DateTimeE { set; get; }
        /// <summary>
        /// 總時數
        /// </summary>
        public decimal Hour { get; set; }
        /// <summary>
        /// 加班時數
        /// </summary>
        public decimal OtHour { get; set; }
        /// <summary>
        /// 補休時數
        /// </summary>
        public decimal RestHour { get; set; }
        /// <summary>
        /// 加班原因代碼
        /// </summary>
        public string CauseID { get; set; }
        /// <summary>
        /// 備註
        /// </summary>
        public string Memo { set; get; }
        /// <summary>
        /// 計薪年月
        /// </summary>
        public string SalaryYYMM { set; get; }
        /// <summary>
        /// 序號
        /// </summary>
        public string Serno { set; get; }
        /// <summary>
        /// 加班原因
        /// </summary>
        public OtCauseRow Cause { set; get; }
    }

    /// <summary>
    /// 加班資料By46小時計算
    /// </summary>
    public class OtBy46Row
    {
        /// <summary>
        /// 總時數
        /// </summary>
        public decimal TotalHour { set; get; }
        /// <summary>
        /// 加班資料
        /// </summary>
        public List<OtRow> Ot { set; get; }
    }

    public class OtRowSave
    {
        public int RowID { get; set; }
        public string EmpID { get; set; }
        public string OtCat { get; set; }
        public string DateB { get; set; }
        public string DateE { get; set; }
        public string DateA { get; set; }
        public string DateD { get; set; }
        public string TimeB { get; set; }
        public string TimeE { get; set; }
        public decimal Amount { get; set; }
        public string CauseID { get; set; }
        public string RoteID { get; set; }
        public string DeptcID { get; set; }
        public string Note { get; set; }
        public string KeyMan { get; set; }
        public string Serno { get; set; }
        public bool Time24 { get; set; }
    }


    /// <summary>
    /// 檢查加班單(檢查通過後計算時數)
    /// </summary>
    public class OTCheckRow
    {

        public int RowID { get; set; }
        public string EmpID { get; set; }
        public string OtCat { get; set; }
        public string DateB { get; set; }
        public string DateE { get; set; }
        public string TimeB { get; set; }
        public string TimeE { get; set; }
        public string CauseID { get; set; }
        public string RoteID { get; set; }
        public bool Card { get; set; }
        public bool CalculateRes { get; set; }
        public bool CalculateAtt { get; set; }
        public bool Time24 { get; set; }
    }





    public class OtDetailRowacc
    {

        public int idProcess { get; set; }

        public string sNobr { get; set; }

        public string sName { get; set; }


        public string sDept { get; set; }

        public string sDeptName { get; set; }

        public string sJob { get; set; }

        public string sJobName { get; set; }


        public string sJoblName { get; set; }

        public string sEmpcd { get; set; }

        public string sRole { get; set; }


        public DateTime dDateTimeB1 { get; set; }

        public DateTime dDateTimeE1 { get; set; }

        public string dDateB1 {get;set;}

        public string dDateE1 { get; set; }



        public string sTimeB1 { get; set; }


        public string sTimeE1 { get; set; }


        public DateTime dDateTimeB { get; set; }

        public DateTime dDateTimeE { get; set; }


        public string dDateB { get; set; }
        public string dDateE { get; set; }

        public string sTimeB { get; set; }





    }




    public class OTFlowAppRowDto
    {

        public OTFlowAppRow FlowApp { get; set; }

        public FlowDynamicRow FlowDynamic { get; set; }

    }




    #region 加班單
    /// <summary>
    /// 加班單主檔資訊
    /// </summary>
    public class OTFlowAppRow : FlowAppRow
    {
        /// <summary>
        /// 加班時數
        /// </summary>
        public decimal Amount { set; get; }
        /// <summary>
        /// 班別代碼
        /// </summary>
        public string RoteID { set; get; }
        /// <summary>
        /// 請假單單筆主檔資訊
        /// </summary>
        public List<OTFlowAppsRow> FlowApps { get; set; }
    }

    /// <summary>
    /// 加班單單筆主檔資訊
    /// </summary>
    public class OTFlowAppsRow
    {
        /// <summary>
        /// EmpID
        /// </summary>
        public string EmpID { get; set; }
        /// <summary>
        /// 工號
        /// </summary>
        public string EmpCode { get; set; }
        /// <summary>
        /// 中文姓名
        /// </summary>
        public string EmpNameC { get; set; }
        /// <summary>
        /// 班別
        /// </summary>
        public string RoteID { get; set; }
        
        /// <summary>
        /// 加班開始日期
        /// </summary>
        public string DateB { set; get; }
        /// <summary>
        /// 加班結束日期
        /// </summary>
        public string DateE { set; get; }
        /// <summary>
        /// 加班開始時間
        /// </summary>
        public string TimeB { set; get; }
        /// <summary>
        /// 加班結束時間
        /// </summary>
        public string TimeE { set; get; }
        /// <summary>
        /// 加班開始日期時間
        /// </summary>
        public DateTime DateTimeB { set; get; }
        /// <summary>
        /// 加班結束日期時間
        /// </summary>
        public DateTime DateTimeE { set; get; }
        /// <summary>
        /// 1 : 加班費 , 2 : 加班換補休
        /// </summary>
        public string OtCat { set; get; }
        /// <summary>
        /// 加班費 , 加班換補休
        /// </summary>
        //public string OtCatName { set; get; }

        /// <summary>
        /// 加班原因代碼
        /// </summary>
        public string CauseID { set; get; }
        /// <summary>
        /// 加班原因名稱
        /// </summary>
        //public string CauseName { set; get; }


        /// <summary>
        /// 加班時數
        /// </summary>
        public decimal Amount { set; get; }

        /// <summary>
        /// 假別單位名稱
        /// </summary>
        public string HoliDayUnitName { set; get; }
     
        /// <summary>
        /// 備註
        /// </summary>
        public string Note { set; get; }
        /// <summary>
        /// 顯示資訊
        /// </summary>
        public string Info { set; get; }
        /// <summary>
        /// 對沖主鍵
        /// </summary>
        public string KeyName { set; get; }
        /// <summary>
        /// 事件發生日
        /// </summary>
        public string EventDate { set; get; }
        /// <summary>
        /// 檔案
        /// </summary>
        public List<UploadFileRow> UploadFile { get; set; }
        /// <summary>
        /// 信件內容
        /// </summary>
        public string MailBody { set; get; }
        /// <summary>
        /// 狀態
        /// </summary>
        public string State { set; get; }
        /// <summary>
        /// 當日申請
        /// </summary>
        public bool Today { set; get; }

        /// <summary>
        /// ProcessID
        /// </summary>
        public int ProcessID { set; get; }
        /// <summary>
        /// Serno
        /// </summary>
        public string Serno { set; get; }
        /// <summary>
        /// 假別名稱
        /// </summary>
        public string HoliDayName { set; get; }

        /// <summary>
        /// 職務名稱
        /// </summary>
        public string JobName { set; get; }
        /// <summary>
        /// 部門ID
        /// </summary>
        public string DeptID { get; set; }
        /// <summary>
        /// 部門名稱
        /// </summary>
        public string DeptName { set; get; }

        /// <summary>
        /// 成本部門代碼
        /// </summary>
        public string DeptcID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string sGuid { get; set; }
        /// <summary>
        /// AutoKey
        /// </summary>
        public int AutoKey { set; get; }
        /// <summary>
        /// Key
        /// </summary>
        public string Key { set; get; }
    }

    ///// <summary>
    ///// 請假檢查條件資料
    ///// </summary>
    //public class OTFlowCheckRow
    //{
    //    /// <summary>
    //    /// EmpID
    //    /// </summary>
    //    public string EmpID { get; set; }
    //    /// <summary>
    //    /// 請假開始日期
    //    /// </summary>
    //    public string DateB { set; get; }
    //    /// <summary>
    //    /// 請假結束日期
    //    /// </summary>
    //    public string DateE { set; get; }
    //    /// <summary>
    //    /// 請假開始時間
    //    /// </summary>
    //    public string TimeB { set; get; }
    //    /// <summary>
    //    /// 請假結束時間
    //    /// </summary>
    //    public string TimeE { set; get; }
    //    /// <summary>
    //    /// 狀態(0=正準備新增的)
    //    /// </summary>
    //    public string State { set; get; }
    //}













    // <summary>
    /// 加班單單筆主檔資訊
    /// </summary>
    public class OTFlowAppsDetailRow
    {
        /// <summary>
        /// AutoKey
        /// </summary>
        public int AutoKey { set; get; }
        /// <summary>
        /// 表單代碼
        /// </summary>
        public string FormCode { get; set; }
        /// <summary>
        /// EmpID
        /// </summary>
        public string EmpID { get; set; }
        /// <summary>
        /// 工號
        /// </summary>
        public string EmpCode { get; set; }
        /// <summary>
        /// 中文姓名
        /// </summary>
        public string EmpNameC { get; set; }
        /// <summary>
        /// 班別
        /// </summary>
        public string RoteID { get; set; }
        /// <summary>
        /// 加班開始日期
        /// </summary>
        public string DateB { set; get; }
        /// <summary>
        /// 加班結束日期
        /// </summary>
        public string DateE { set; get; }
        /// <summary>
        /// 加班開始時間
        /// </summary>
        public string TimeB { set; get; }
        /// <summary>
        /// 加班結束時間
        /// </summary>
        public string TimeE { set; get; }
        /// <summary>
        /// 加班開始日期時間
        /// </summary>
        public DateTime DateTimeB { set; get; }
        /// <summary>
        /// 加班結束日期時間
        /// </summary>
        public DateTime DateTimeE { set; get; }
        /// <summary>
        /// 1 : 加班費 , 2 : 加班換補休
        /// </summary>
        public string OtCat { set; get; }
        /// <summary>
        /// 加班費 , 加班換補休
        /// </summary>
        public string OtCatName { set; get; }
        /// <summary>
        /// 加班原因代碼
        /// </summary>
        public string CauseID { set; get; }
        /// <summary>
        /// 加班原因名稱
        /// </summary>
        public string CauseName { set; get; }
        /// <summary>
        /// 顯示資訊
        /// </summary>
        public string Info { set; get; }

        /// <summary>
        /// 信件內容
        /// </summary>
        public string MailBody { set; get; }
        /// <summary>
        /// 備註
        /// </summary>
        public string Note { set; get; }
        /// <summary>
        /// 檔案
        /// </summary>
        public List<UploadFileRow> UploadFile { get; set; }
        /// <summary>
        /// 狀態
        /// </summary>
        public string State { set; get; }
        /// <summary>
        /// 當日申請
        /// </summary>
        public bool Today { set; get; }
        /// <summary>
        /// 事件發生日
        /// </summary>
        public string EventDate { set; get; }
        /// <summary>
        /// ProcessID
        /// </summary>
        public int ProcessID { set; get; }
        /// <summary>
        /// Serno
        /// </summary>
        public string Serno { set; get; }
        /// <summary>
        /// 部門ID
        /// </summary>
        public string DeptID { get; set; }
        /// <summary>
        /// 部門名稱
        /// </summary>
        public string DeptName { set; get; }
        /// <summary>
        /// 部門ID
        /// </summary>
        public string DeptsID { get; set; }
        /// <summary>
        /// 部門名稱
        /// </summary>
        public string DeptsName { set; get; }

        /// <summary>
        /// 職務名稱
        /// </summary>
        public string JobName { set; get; }

        /// <summary>
        /// 
        /// </summary>
        public string sGuid { get; set; }
        
        /// <summary>
        /// KeyMan 輸入人員
        /// </summary>
        public string KeyMan { set; get; }
        /// <summary>
        /// KeyManNobr 輸入人員工號
        /// </summary>
        public string KeyManNobr { set; get; }
        /// <summary>
        /// 加班時數
        /// </summary>
        public decimal Amount { set; get; }
        /// <summary>
        /// UseDayHourMinute  計算時段 日時分
        /// </summary>
        public DayHourMinuteRow UseDayHourMinute { set; get; }



    }


    #endregion



    /// <summary>
    /// 加班單判斷簽核層級
    /// </summary>
    public class OTFlowSignTreeRow
    {
        /// <summary>
        /// 簽核層級
        /// </summary>
        public int Tree { get; set; }
        ///// <summary>
        ///// 假別ID
        ///// </summary>
        //public string HoliDayID { get; set; }
        ///// <summary>
        ///// 天數
        ///// </summary>
        //public decimal Day { get; set; }
    }
}
