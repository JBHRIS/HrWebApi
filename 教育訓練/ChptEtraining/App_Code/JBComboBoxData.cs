using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using Telerik.Web.UI;
using Repo;
/// <summary>
/// JBComboBoxData 的摘要描述
/// </summary>

[DataObject(true)]
public class JBComboBoxData
{
    private static dcTrainingDataContext dcTraining = new dcTrainingDataContext();
    public void JComboBoxData()
    {
    }


    public static void GetEmps(RadComboBox cbx, string value)
    {
        var o = (from c in dcTraining.BASE
                 where c.NAME_C.Contains(value) || c.NOBR.Contains(value)
                 select c).Take(10).ToList();

        cbx.Items.Clear();

        foreach (var i in o)
        {
            RadComboBoxItem item = new RadComboBoxItem(i.NOBR + " " + i.NAME_C, i.NOBR);
            cbx.Items.Add(item);
        }

    }

    [DataObjectMethod(DataObjectMethodType.Select)]
    public static List<BASE> GetFirstEmp()
    {
        var o = (from c in dcTraining.BASE
                 orderby c.NOBR ascending
                 select c).Take(1).ToList();

        return o;
    }

    [DataObjectMethod(DataObjectMethodType.Select)]
    public static List<BASE> GetLastEmp()
    {
        var o = (from c in dcTraining.BASE
                 orderby c.NOBR descending
                 select c).Take(1).ToList();

        return o;
    }

    public static void GetEmpsDesc(RadComboBox cbx, string value)
    {
        var o = (from c in dcTraining.BASE
                 where c.NAME_C.Contains(value) || c.NOBR.Contains(value)
                 orderby c.NOBR descending
                 select c).Take(10).ToList();

        cbx.Items.Clear();

        foreach (var i in o)
        {
            RadComboBoxItem item = new RadComboBoxItem(i.NOBR + " " + i.NAME_C, i.NOBR);
            cbx.Items.Add(item);
        }

    }
}