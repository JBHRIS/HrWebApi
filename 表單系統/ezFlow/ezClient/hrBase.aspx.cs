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

public partial class hrBase : System.Web.UI.Page
{
    public FlowHrDSTableAdapters.hrBaseMTableAdapter hrBaseMTA = new FlowHrDSTableAdapters.hrBaseMTableAdapter();

    public FlowHrDSTableAdapters.hrDeptmTableAdapter hrDeptmTA = new FlowHrDSTableAdapters.hrDeptmTableAdapter();
    public FlowHrDSTableAdapters.hrJobTableAdapter hrJobTA = new FlowHrDSTableAdapters.hrJobTableAdapter();

    public FlowHrDS oFlowHrDS;

    protected void Page_Load(object sender, EventArgs e)
    {
        oFlowHrDS = new FlowHrDS();

        lblMsg.Text = "";
    }

    public override void VerifyRenderingInServerForm(Control control) { }

    protected void gvBase_SelectedIndexChanged(object sender, EventArgs e)
    {
        mv.ActiveViewIndex = 1;
        fvBase.ChangeMode(FormViewMode.Edit);
    }

    protected void gvBase_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string cmdName = e.CommandName;

        switch (cmdName)
        {
            case "New": //新增
                mv.ActiveViewIndex = 1;
                fvBase.ChangeMode(FormViewMode.Insert);
                break;
            case "ExportXLS":   //匯出
                gvBase.AllowPaging = false;
                gvBase.AllowSorting = false;
                gvBase.Columns[0].Visible = false;
                gvBase.DataBind();
                gvCS.ExportXls(gvBase);
                break;
        }
    }
    protected void gvBase_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        //刪除要檢查一些表單
    }

    protected void gvBase_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        gvCS.RowDataBoundColorChange(e);
    }

    protected void fvBase_ItemCommand(object sender, FormViewCommandEventArgs e)
    {
        string cmdName = e.CommandName;

        switch (cmdName)
        {
            case "Cancel": //取消
                mv.ActiveViewIndex = 0;
                gvBase.SelectedIndex = -1;
                fvBase.ChangeMode(FormViewMode.ReadOnly);
                break;
        }
    }

    protected void fvBase_ItemInserting(object sender, FormViewInsertEventArgs e)
    {
        if (e.Values["sNobr"].ToString().Length == 0)
        {
            lblMsg.Text = "工號為必填欄位";
            e.Cancel = true;
        }

        if (e.Values["sName"].ToString().Length == 0)
        {
            lblMsg.Text = "姓名為必填欄位";
            e.Cancel = true;
        }

        if (e.Values["sLoginID"].ToString().Length == 0)
        {
            lblMsg.Text = "帳號為必填欄位";
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

        if (hrBaseMTA.GetDataByNobr(e.Values["sNobr"].ToString()).Rows.Count > 0)
        {
            lblMsg.Text = "工號重複";
            e.Cancel = true;
        }

        e.Values["dDateD"] = dateE;
        e.Values["sLoginPW"] = "jbjob";
        e.Values["sKeyMan"] = Request.Cookies["ezFlow"]["Emp_id"];
        e.Values["dKeyDate"] = DateTime.Now;
    }

    protected void fvBase_ItemInserted(object sender, FormViewInsertedEventArgs e)
    {
        mv.ActiveViewIndex = 0;
        gvBase.DataBind();
    }

    protected void fvBase_ItemUpdating(object sender, FormViewUpdateEventArgs e)
    {
        if (e.NewValues["sName"].ToString().Length == 0)
        {
            lblMsg.Text = "姓名為必填欄位";
            e.Cancel = true;
        }

        if (e.NewValues["sLoginID"].ToString().Length == 0)
        {
            lblMsg.Text = "帳號為必填欄位";
            e.Cancel = true;
        }

        if (e.NewValues["sLoginPW"].ToString().Length == 0)
        {
            lblMsg.Text = "密碼為必填欄位";
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

        e.NewValues["sKeyMan"] = Request.Cookies["ezFlow"]["Emp_id"];
        e.NewValues["dKeyDate"] = DateTime.Now;
    }

    protected void fvBase_ItemUpdated(object sender, FormViewUpdatedEventArgs e)
    {
        mv.ActiveViewIndex = 0;
        gvBase.DataBind();
    }
}