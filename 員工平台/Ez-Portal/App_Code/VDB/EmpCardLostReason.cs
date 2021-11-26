using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// EmpAttendList 的摘要描述
/// </summary>
public class EmpCardLostReason
{    
    public string Nobr { get; set; }
    public string Name_C { get; set; }
    public string Name_E { get; set; }
    public string DeptName {get;set;}
    public string DeptCode { get; set; }
    public DateTime Adate{get;set;}
    public string ReasonName {get;set;}
    public string ReasonCode { get; set; }

    public EmpCardLostReason()
	{
		//
		// TODO: 在此加入建構函式的程式碼
		//
	}
}
