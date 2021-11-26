using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// OT46AMT 的摘要描述
/// </summary>
public class EmpAttendLateDto
{
    public EmpAttendLateDto()
	{
		//
		// TODO: 在此加入建構函式的程式碼
		//
	}

    public string Nobr { get; set; }
    public string DeptName { get; set; }
    public string DeptCode { get; set; }
    public string Name_C { get; set; }
    public string Name_E { get; set; }
    public DateTime Date { get; set; }
    public string JobCode { get; set; }
    public string JobName { get; set; }
    /// <summary>
    /// 遲到分鐘數
    /// </summary>
    public Decimal Qty { get; set; }
}
