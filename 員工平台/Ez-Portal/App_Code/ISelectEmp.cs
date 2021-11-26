using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BL;
using Telerik.Web.UI;
/// <summary>
/// IBindNeedAssignedNum 的摘要描述
/// </summary>
public interface ISelectEmp
{
    List<string> GetSelectedEmps();
    void SetSelectedData(List<RadListBoxItem> list);
    void SetReadOnly(bool value);
    void ClearSelected();
    void ClearAll();
    
}