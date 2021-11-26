using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BL;

/// <summary>
/// UC_QS_Selected 的摘要描述
/// </summary>
public class UC_QS_SelectedObj
{
	public UC_QS_SelectedObj()
	{
		//
		// TODO: 在此加入建構函式的程式碼
		//
	}
    //UC_QS_Selected 更改名稱為 UC_QS_SelectedObj
    public EnumUC_QS_SelectedType SelectedType { get; set; }
    public string Key { get; set; }
    public bool IsSingleDept { get; set; }
    public List<string> DeptList { get; set; }
}