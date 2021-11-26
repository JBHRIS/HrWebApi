using System;
using System.Collections.Generic;

namespace HR_WebApi.Controllers.Attendance
{
    /*
        1.AB分流人員編制
            -工號,AB分流,工作地
        2.AB班出勤設定
            -日期,AB分流 (優先)
            -星期(1-7),AB班
            -週(1-52),AB班
        3.AB分流出勤報表
            -工號、姓名、日期、班別、AB分流、工作地、上班刷卡、下班刷卡
        4.AB分流出勤異常報表[非AB分流出勤設定中出勤]
            -工號、姓名、日期、班別、AB分流、工作地、上班刷卡、下班刷卡
        5.居家工作未打卡報表
            -工號、姓名、日期、班別、AB分流、工作地、上班刷卡、下班刷卡
        6.居家工作日誌未填寫報表
        7.公司工作體溫未填回報報表
     */
    public class DiversionShiftAttendReportDto
    {
        /// <summary>
        /// 員工編號
        /// </summary>
        public string EmployeeId { get; set; }
        /// <summary>
        /// 員工姓名
        /// </summary>
        public string EmployeeName { get; set; }
        /// <summary>
        /// 出勤日期
        /// </summary>
        public DateTime AttendDate { get; set; }
        /// <summary>
        /// 出勤班別
        /// </summary>
        public string Rote { get; set; }
        /// <summary>
        /// 出勤班別名稱
        /// </summary>
        public string RoteName { get; set; }
        /// <summary>
        /// 刷卡上班時間
        /// ATTCARD.TT1
        /// </summary>
        public string CardOnTime { get; set; }
        /// <summary>
        /// 刷卡下班時間
        /// ATTCARD.TT2
        /// </summary>
        public string CardOffTime { get; set; }
        /// <summary>
        /// 地點
        /// </summary>
        public string Location { get; set; }
        /// <summary>
        /// 分流組別
        /// </summary>
        public string DiversionGroup { get; set; }
        /// <summary>
        /// 分流組別名稱
        /// A OR B 班
        /// </summary>
        public string DiversionGroupName { get; set; }
        /// <summary>
        /// 分流上班類別
        /// Attend正常出勤,WFH居家上班,Dayoff休假
        /// </summary>
        public string DiversionAttendType { get; set; }
        /// <summary>
        /// 分流上班類別名稱
        /// </summary>
        public string DiversionAttendTypeName { get; set; }
        /// <summary>
        /// 異常註記
        /// WFH_Attend居家工作期間進公司(需要透過CARD.CODE來判斷是公司卡機)
        /// NoWorkLog未填寫工作日誌
        /// NoWebCard未線上打卡
        /// NoTemperoturyReport未回報體溫
        /// </summary>
        public List<string> AttendErrorList { get; set; }
    }
}