using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class HR_PwRole : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

         
    }

    //public static Hashtable GetDefault(string sCat)
    //{
    //    Hashtable ht = new Hashtable();

    //    SysDSTableAdapters.sysDefaultTableAdapter sysDefaultTA = new SysDSTableAdapters.sysDefaultTableAdapter();
    //    DataRow[] rows = sysDefaultTA.GetDataByCategory(sCat).Select();

    //    foreach (SysDS.sysDefaultRow r in rows)
    //        ht.Add(r.sKey, r.sValue);

    //    return ht;
    //}
    protected void gv_RowDataBound(object sender, GridViewRowEventArgs e)
    {       
        TextBox txtValue = e.Row.FindControl("txtValue") as TextBox;
        CheckBox cbValue = e.Row.FindControl("cbValue") as CheckBox;

        string[] txt = { "text", "password" };
        string[] cb = { "checkbox" };

        if (txtValue != null)
        {
            if (Array.IndexOf(txt, txtValue.ToolTip) >= 0)
            {
                if (txtValue.ToolTip == "password")
                {
                    if (gv.EditIndex == e.Row.DataItemIndex)
                        txtValue.TextMode = TextBoxMode.Password;
                    else
                        txtValue.Text = "******";
                }

                txtValue.Visible = true;
            }
            else if (Array.IndexOf(cb, txtValue.ToolTip) >= 0)
            {
                cbValue.Checked = (txtValue.Text == "True");
                cbValue.Visible = true;
            }
        }
    }
    protected void gv_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        CheckBox cbValue = gv.Rows[e.RowIndex].FindControl("cbValue") as CheckBox;

        if (cbValue.Visible)
            e.NewValues["sValue"] = cbValue.Checked.ToString();
    }
}
