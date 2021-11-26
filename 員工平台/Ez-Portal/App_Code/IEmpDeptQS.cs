using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BL;

/// <summary>
/// IBindNeedAssignedNum 的摘要描述
/// </summary>
public interface IEmpDeptQS
{
    void InitUC_Dept(EnumUC_QS_InitType type);
    void InitUC_Cat(int value);
    void InitUC_Cat(int value,bool disableItem);
    void SelectSingleDept(bool value);
    void DisplayPushBtn(bool value);
    void SetQuickSearchAdvanced(bool value);
    UC_QS_SelectedObj GetSelectedObj();
}