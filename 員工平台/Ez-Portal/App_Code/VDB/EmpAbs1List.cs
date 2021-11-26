using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// EmpAttendList 的摘要描述
/// </summary>
public class EmpAbs1List
{
    public string DeptName { get; set; }
    public string Nobr { get; set; }
    public string NameC { get; set; }
    public string NameE { get; set; }
    public string JobName {get;set;}
    public DateTime AbsDate { get; set; }       
    public string AbsBtime { get; set; }  
    public string AbsEtime { get; set; }  
    public string H_Code { get; set; }  
    public string H_CodeName { get; set; }
    public string H_CodeUnit{get;set;}
    public decimal TOL_HOURS{get;set;}        
    public string Reason { get; set; }
    public string NOTE { get; set; }      
    public string YYMM { get; set; }      

    public EmpAbs1List()
	{
		//
		// TODO: 在此加入建構函式的程式碼
		//
	}
}
