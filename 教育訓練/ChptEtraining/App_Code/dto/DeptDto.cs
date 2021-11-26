using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// DeptDto 的摘要描述
/// </summary>
public class DeptDto
{
	public DeptDto()
	{
		//
		// TODO: 在此加入建構函式的程式碼
		//
	}

    public string ParentDeptCode { get; set; }
    public string DeptCode { get; set; }
    public string DeptName { get; set; }
}