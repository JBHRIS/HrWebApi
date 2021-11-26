using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// YearPlan 的摘要描述
/// </summary>
public class YearPlan
{
    public string sKey { get; set; }
    public string trCourse_sCode { get; set; }
    public int iMonth { get; set; }
    public decimal iHours { get; set; }
    public int iPeople { get; set; }
    public int iAmt { get; set; }
	public YearPlan()
	{
		//
		// TODO: 在此加入建構函式的程式碼
		//
	}
}