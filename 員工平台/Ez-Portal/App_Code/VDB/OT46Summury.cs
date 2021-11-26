using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// OT46Summury 的摘要描述
/// </summary>
public class OT46Summury
{
	public OT46Summury()
	{
		//
		// TODO: 在此加入建構函式的程式碼
		//
	}

    /// <summary>
    /// 部門名稱
    /// </summary>
    public string DeptName { get; set; }
    /// <summary>
    /// 部門員工平日加班人數
    /// </summary>
    public int DeptEmpOtQty { get; set; }
    /// <summary>
    /// 部門平日加班時數合計
    /// </summary>
    public decimal DeptOtTimeAmt { get; set; }
    /// <summary>
    /// 部門平日加班比例
    /// </summary>
    public decimal DeptOtPercent { get; set; }
    /// <summary>
    /// 部門平日加班時數合計
    /// </summary>
    public decimal DeptHOtTimeAmt { get; set; }

    /// <summary>
    /// 部門假日加班比例
    /// </summary>
    public decimal DeptHOtPercent { get; set; }
    /// <summary>
    /// 所有員工平日加班總和
    /// </summary>
    public decimal AllEmpOtTimeAmt { get; set; }
    /// <summary>
    /// 所有員工平日及假日加班人數
    /// </summary>
    public int AllEmpOtAndHOtQty { get; set; }
    /// <summary>
    /// 所有員工假日加班時間總和
    /// </summary>
    public decimal AllEmpHOtTimeAmt { get; set; }
    /// <summary>
    /// 所有員工平日加班人數
    /// </summary>
    public int AllEmpOtQty { get; set; }
    /// <summary>
    /// 所有員工假日加班人數
    /// </summary>
    public int AllEmpHOtQty { get; set; }

    /// <summary>
    /// 部門員工假日加班人數
    /// </summary>
    public int DeptEmpHOtQty { get; set; }
    /// <summary>
    /// 部門員工平日及假日加班人數
    /// </summary>
    public int DeptEmpOtAndHOtQty { get; set; }
    /// <summary>
    /// 部門平日及假日加班總和
    /// </summary>
    public decimal DeptOtAndHOtTimeAmt { get; set; }
    /// <summary>
    /// 部門平日及假日加班百分比
    /// </summary>
    public decimal DeptOtAndHOtPercent { get; set; }
    /// <summary>
    /// 所有員工平日及假日加班總和
    /// </summary>
    public decimal AllEmpOtAndHOtTimeAmt { get; set; }
    /// <summary>
    /// 部門員工總數
    /// </summary>
    public int DeptEmpQty { get; set; }
    /// <summary>
    /// 部門員工平日加班異常數量
    /// </summary>
    public int DeptEmpOtErrorQty { get; set; }
    /// <summary>
    /// 部門所有員工的的假日天數 X 8 (部門員工的假日總時數)
    /// </summary>
    public decimal DeptAllHoliHrsAmt { get; set; }
    /// <summary>
    /// 部門員工假日加班異常數量
    /// </summary>
    public int DeptEmpHOtErrorQty { get; set; }
}
