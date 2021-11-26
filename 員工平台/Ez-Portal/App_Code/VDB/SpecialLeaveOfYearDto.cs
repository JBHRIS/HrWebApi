using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// SpecialLeaveOfYearDto 的摘要描述
/// </summary>
public class SpecialLeaveOfYearDto
{
        public string NOBR{get;set;}
        public string NAME_C{get;set;}
        public string DeptName { get; set; }
        public string DI{get;set;}
        public DateTime INDT{get;set;}
        //public DateTime OUDT;
        public decimal GET_HOURS{get;set;}
        public decimal LEAVE_HOURS{get;set;}
        public decimal ABS_HOURS{get;set;}
        public decimal FullHours1{get;set;}
        public decimal FullHours2{get;set;}
        public decimal FullHours3{get;set;}
        public decimal FullHours4{get;set;}
        public decimal FullHours5{get;set;}
        public decimal FullHours6{get;set;}
        public decimal HalfHours1{get;set;}
        public decimal HalfHours2{get;set;}
        public decimal TOL_HOURS{get;set;}

    //員工編號 = a.NOBR,
    //                           員工姓名 = a.NAME_C,
    //                           直間接 = a.DI.Trim().ToUpper() == "D" ? "直接" : "間接",
    //                           到職日期 = a.INDT,
    //                           離職日期 = a.OUDT,
    //                           留停日期 = a.STDT,
    //                           特休應休 = a.GET_HOURS,
    //                           特休已休 = a.FullHours1,
    //                           特休未休 = a.LEAVE_HOURS,
    //                           其他已休 = a.ABS_HOURS,
    //                           剩餘可休 = a.TOL_HOURS,
    //                           事假 = a.FullHours2,
    //                           家庭照顧假 = a.FullHours3,
    //                           無薪假 = a.FullHours4,
    //                           曠職 = a.FullHours5,
    //                           無薪病假 = a.FullHours6,
    //                           病假 = a.HalfHours1,
    //                           生理假 = a.HalfHours2,

	public SpecialLeaveOfYearDto()
	{
		//
		// TODO: 在此加入建構函式的程式碼
		//
	}
}