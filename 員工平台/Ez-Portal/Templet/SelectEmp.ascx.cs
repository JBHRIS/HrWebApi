using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Templet_SelectEmp : JBUserControl,IUC
{
    public delegate void SelectEmpEventHandler(string nobr);
    public event SelectEmpEventHandler sHandler;
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }
    protected void gv_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (sHandler != null)
        {
            sHandler(gv.SelectedValue.ToString());
        }
    }

    #region IUC 成員

    public void BindData()
    {
        gv.DataBind();
        gv.SelectedIndex = -1;
    }

    public void SetValue(string value)
    {
        lblDept.Text = value;
    }

    #endregion
    protected void HR_Portal_EmpInfoSqlDataSource_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
    {

    }
    protected void cbIncludeEmpLeaving_CheckedChanged(object sender, EventArgs e)
    {
        if (cbIncludeEmpLeaving.Checked)
        {
            gv.DataSourceID = "HR_Portal_EmpInfo_LeSqlDataSource";
            gv.DataBind();
            gv.SelectedIndex = -1;
        }
        else
        {
            gv.DataSourceID = "HR_Portal_EmpInfoSqlDataSource";
            gv.DataBind();
            gv.SelectedIndex = -1;
        }
    }
    protected void gv_DataBound(object sender, EventArgs e)
    {
    }
    protected void gv_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //if (e.Row.RowType == DataControlRowType.DataRow)
        //{
        //    object objTemp = gv.DataKeys[e.Row.RowIndex].Value as object;
        //    if (objTemp != null)
        //    {
        //        string nobr = objTemp.ToString();
        //        if (Juser.SalaDrNobrList.Contains(nobr))
        //            e.Row.Visible = true;
        //        else
        //            e.Row.Visible = false;
        //    }

        //}
    }
}
