using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Telerik.Web.UI;
/// <summary>
/// MyComparer 的摘要描述
/// </summary>
public class MyComparer : System.Collections.IComparer
{

    #region IComparer 成員

    public int Compare(object x, object y)
    {
        return DateTime.Compare((DateTime.Parse((x as RadListBoxItem).Value)), (DateTime.Parse((y as RadListBoxItem).Value)));
    }

    #endregion
}