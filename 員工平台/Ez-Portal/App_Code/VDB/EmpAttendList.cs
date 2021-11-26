using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// EmpAttendList 的摘要描述
/// </summary>
public class EmpAttendList
{
    public string DeptName { get; set; }
    public string Nobr { get; set; }
    public string NameC { get; set; }
    public DateTime AttendDate { get; set; }
    public string DayOfWeek { get; set; }
    public string Calendar { get; set; }
    public string Shift { get; set; }
    public string ShiftName { get; set; }
    public string StartWorkingTime { get; set; }
    public string EndWorkingTime { get; set; }
    public double RealWorkHours { get; set; }
    /// <summary>
    /// 遲到
    /// </summary>
    public bool IsLate { get; set; }
    public int LateMins { get; set; }
    /// <summary>
    /// 早退
    /// </summary>
    public bool IsLeaveEarly { get; set; }
    public int LeaveEarlyMins { get; set; }
    /// <summary>
    /// 曠職
    /// </summary>
    public bool IsAbsent { get; set; }
    /// <summary>
    /// 忘刷
    /// </summary>
    public bool IsLostCard { get; set; }
    public int LostCardTimes { get; set; }
    public string TakeLeaveNote { get; set; }



	public EmpAttendList()
	{
		//
		// TODO: 在此加入建構函式的程式碼
		//
	}
}
