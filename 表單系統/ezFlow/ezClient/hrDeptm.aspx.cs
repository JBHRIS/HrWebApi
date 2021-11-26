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

public partial class hrDeptm : System.Web.UI.Page
{
    public FlowHrDSTableAdapters.hrDeptmTableAdapter hrDeptmTA = new FlowHrDSTableAdapters.hrDeptmTableAdapter();

    public FlowHrDS oFlowHrDS;

    protected void Page_Load(object sender, EventArgs e)
    {
        oFlowHrDS = new FlowHrDS();

        lblMsg.Text = "";
    }

    public override void VerifyRenderingInServerForm(Control control) { }

    protected void gv_SelectedIndexChanged(object sender, EventArgs e)
    {
        fv.ChangeMode(FormViewMode.Edit);
    }

    protected void gv_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string cmdName = e.CommandName;

        switch (cmdName)
        {
            case "ExportXLS":   //匯出
                gv.AllowPaging = false;
                gv.AllowSorting = false;
                gv.Columns[0].Visible = false;
                gv.DataBind();
                gvCS.ExportXls(gv);
                break;
        }
    }
    protected void gv_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        //刪除要檢查一些表單
    }

    protected void gv_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        gvCS.RowDataBoundColorChange(e);
    }

    protected void fv_ItemCommand(object sender, FormViewCommandEventArgs e)
    {
        string cmdName = e.CommandName;

        switch (cmdName)
        {
            case "Cancel": //取消
                gv.SelectedIndex = -1;
                fv.ChangeMode(FormViewMode.Insert);
                break;
        }
    }

    protected void fv_ItemInserting(object sender, FormViewInsertEventArgs e)
    {
        if (e.Values["sDeptmCode"].ToString().Length == 0)
        {
            lblMsg.Text = "部門代碼為必填欄位";
            e.Cancel = true;
        }

        if (e.Values["sDeptmName"].ToString().Length == 0)
        {
            lblMsg.Text = "部門名稱為必填欄位";
            e.Cancel = true;
        }


        DateTime dateB, dateE;
        dateE = new DateTime(9999, 12, DateTime.DaysInMonth(9999, 12));
        try
        {
            dateB = DateTime.Parse(e.Values["dDateA"].ToString());
        }
        catch
        {
            lblMsg.Text = "日期格式錯誤，例：1979/12/3";
            e.Cancel = true;
        }

        if (hrDeptmTA.GetDataByDeptmCode(e.Values["sDeptmCode"].ToString()).Rows.Count > 0)
        {
            lblMsg.Text = "部門代碼重複";
            e.Cancel = true;
        }

        e.Values["sParentDept"] = (e.Values["sParentDept"].ToString().Length == 0) ? " " : e.Values["sParentDept"];
        e.Values["dDateD"] = dateE;
        e.Values["sKeyMan"] = Request.Cookies["ezFlow"]["Emp_id"];
        e.Values["dKeyDate"] = DateTime.Now;
    }

    protected void fv_ItemInserted(object sender, FormViewInsertedEventArgs e)
    {
        gv.DataBind();
    }

    protected void fv_ItemUpdating(object sender, FormViewUpdateEventArgs e)
    {
        if (e.NewValues["sDeptmName"].ToString().Length == 0)
        {
            lblMsg.Text = "部門名稱為必填欄位";
            e.Cancel = true;
        }

        try
        {
            e.NewValues["dDateA"] = DateTime.Parse(e.NewValues["dDateA"].ToString());
            e.NewValues["dDateD"] = DateTime.Parse(e.NewValues["dDateD"].ToString());
        }
        catch
        {
            lblMsg.Text = "日期格式錯誤，例：1979/12/3";
            e.Cancel = true;
        }

        e.NewValues["sParentDept"] = (e.NewValues["sParentDept"].ToString().Length == 0) ? " " : e.NewValues["sParentDept"];
        e.NewValues["sKeyMan"] = Request.Cookies["ezFlow"]["Emp_id"];
        e.NewValues["dKeyDate"] = DateTime.Now;
    }

    protected void fv_ItemUpdated(object sender, FormViewUpdatedEventArgs e)
    {
        gv.DataBind();
    }
}
