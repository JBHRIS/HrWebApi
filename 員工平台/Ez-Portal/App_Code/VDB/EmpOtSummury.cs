using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// OT46AMT 的摘要描述
/// </summary>
public class EmpOtSummury
{
	public EmpOtSummury()
	{
		//
		// TODO: 在此加入建構函式的程式碼
		//
	}

    public string Nobr { get; set; }
    public string NameC { get; set; }
    public string DeptDispCode { get; set; }
    public string DeptName { get; set; }
    public string JobDispCode { get; set; }
    public string JobName { get; set; }
    public decimal OtAmt { get; set; }
    public decimal OtSubmittedAmt { get; set; }
    public decimal OtUnSubmittedAmt { get; set; }
}
