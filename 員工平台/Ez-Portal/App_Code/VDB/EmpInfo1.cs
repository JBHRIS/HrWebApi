using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// EmpInfo1 的摘要描述
/// </summary>
public class EmpInfo1
{
	public EmpInfo1()
	{
		//
		// TODO: 在此加入建構函式的程式碼
		//
	}

    public string Nobr { get; set; }
    public string NameC { get; set; }
    public string NameE { get; set; }
    public string JobCode { get; set; }
    public string JobTitle { get; set; }
    public string DeptCode { get; set; }
    public string DeptName { get; set; }
    public string ExtNum { get; set; }//分機
    //性別
    public string Gender
    {
        get;
        set;
    }
    public DateTime? BirthDate
    {
        get;
        set;
    }
    public string JoblCode{get;set;}
    public string JoblName
    {
        get;
        set;
    }
    public string JoboCode { get; set; }
    public string JoboName { get; set; }
    public DateTime? Indt { get; set; }
    public decimal? Seniority { get; set; }
    public string MobileNumber { get; set; }
    public string PhoneNumber { get; set; }//通訊電話
    public string Addr1 { get; set; }
    public string TopSchoolName { get; set; }
    public string TopSchoolMajorName { get; set; }
}