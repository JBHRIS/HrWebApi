using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// OT46AMT 的摘要描述
/// </summary>
public class OT46AMT
{
	public OT46AMT()
	{
		//
		// TODO: 在此加入建構函式的程式碼
		//
	}

    public string Nobr { get; set; }
    public string DeptName { get; set; }
    public string Name_C { get; set; }
    public string Name_E { get; set; }
    /// <summary>
    /// 假日加班時數
    /// </summary>
    public decimal HolidayOT { get; set; } 
    /// <summary>
    /// 平日加班時數
    /// </summary>
    public decimal OT { get; set; }
    /// <summary>
    /// 平日加班百分比
    /// </summary>
    public decimal OtPercent { get; set; }
    /// <summary>
    /// 假日加班百分比
    /// </summary>
    public decimal HOtPercent { get; set; }
    /// <summary>
    /// 員工的的假日天數 X 8 (員工的假日總時數)
    /// </summary>
    public decimal AllHoliHrsAmt { get; set; }

    /// <summary>
    /// 成本部門名稱
    /// </summary>
    public string DeptsName { get; set; }
}
