


using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// FlowProcessingDto 的摘要描述
/// </summary>
public class FlowProcessingDto
{
	public FlowProcessingDto()
	{
		//
		// TODO: 在此加入建構函式的程式碼
		//
	}

    public string sNobr { get; set; }
    public DateTime dDateB { get; set; }
    public DateTime dDateE { get; set; }
    public string sTimeB { get; set; }
    public string sTimeE { get; set; }
    public string sHcode { get; set; }
    public string sHcodeName { get; set; }
    public decimal iTotalDay { get; set; }
    public decimal iTotalHour { get; set; }
}