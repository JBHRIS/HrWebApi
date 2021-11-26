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

public partial class hrHcode : System.Web.UI.Page
{
    public FlowHrDSTableAdapters.hrHcodeTableAdapter hrHcodeTA = new FlowHrDSTableAdapters.hrHcodeTableAdapter();

    public FlowHrDS oFlowHrDS;

    protected void Page_Load(object sender, EventArgs e)
    {
        oFlowHrDS = new FlowHrDS();

        lblMsg.Text = "";
    }

    public override void VerifyRenderingInServerForm(Control control) { }

    protected void gv_SelectedIndexChanged(object sender, EventArgs e)
    {
        mv.ActiveViewIndex = 1;
        fv.ChangeMode(FormViewMode.Edit);
    }

    protected void gv_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string cmdName = e.CommandName;

        switch (cmdName)
        {
            case "New": //新增
                mv.ActiveViewIndex = 1;
                fv.ChangeMode(FormViewMode.Insert);
                break;
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
                mv.ActiveViewIndex = 0;
                gv.SelectedIndex = -1;
                fv.ChangeMode(FormViewMode.ReadOnly);
                break;
        }
    }

    protected void fv_ItemInserting(object sender, FormViewInsertEventArgs e)
    {
        if (e.Values["sHcodeCode"].ToString().Length == 0)
        {
            lblMsg.Text = "假別代碼為必填欄位";
            e.Cancel = true;
        }

        if (e.Values["sHcodeName"].ToString().Length == 0)
        {
            lblMsg.Text = "假別名稱為必填欄位";
            e.Cancel = true;
        }

        try {
            e.Values["iMin"] = Convert.ToDecimal(e.Values["iMin"]);
            e.Values["iMax"] = Convert.ToDecimal(e.Values["iMax"]);
            e.Values["iHeadway"] = Convert.ToDecimal(e.Values["iHeadway"]);
        }
        catch {
            lblMsg.Text = "最小時數或最大時數或間隔時數的格式錯誤，例：0.5";
            e.Cancel = true;
        }

        try
        {
            e.Values["dDateA"] = Convert.ToDateTime(e.Values["dDateA"]);
        }
        catch
        {
            lblMsg.Text = "日期格式錯誤，例：1979/12/3";
            e.Cancel = true;
        }

        if (hrHcodeTA.GetDataByHcodeCode(e.Values["sHcodeCode"].ToString()).Rows.Count > 0)
        {
            lblMsg.Text = "假別代碼重複";
            e.Cancel = true;
        }

        if (e.Values["bSex"].ToString().Trim().Length == 0)
        {
            e.Values["bSex"] = null;
        }
        else
        {
            e.Values["bSex"] = e.Values["bSex"].ToString() == "1";
        }

        e.Values["sGroupCode"] = "0";
        e.Values["dDateD"] =  new DateTime(9999, 12, DateTime.DaysInMonth(9999, 12));
        e.Values["sKeyMan"] = Request.Cookies["ezFlow"]["Emp_id"];
        e.Values["dKeyDate"] = DateTime.Now;
    }

    protected void fv_ItemInserted(object sender, FormViewInsertedEventArgs e)
    {
        mv.ActiveViewIndex = 0;
        gv.DataBind();
    }

    protected void fv_ItemUpdating(object sender, FormViewUpdateEventArgs e)
    {
        if (e.NewValues["sHcodeName"].ToString().Length == 0)
        {
            lblMsg.Text = "假別名稱為必填欄位";
            e.Cancel = true;
        }

        try
        {
            e.NewValues["iMin"] = Convert.ToDecimal(e.NewValues["iMin"]);
            e.NewValues["iMax"] = Convert.ToDecimal(e.NewValues["iMax"]);
            e.NewValues["iHeadway"] = Convert.ToDecimal(e.NewValues["iHeadway"]);
        }
        catch
        {
            lblMsg.Text = "最小時數或最大時數或間隔時數的格式錯誤，例：0.5";
            e.Cancel = true;
        }

        try
        {
            e.NewValues["dDateA"] = Convert.ToDateTime(e.NewValues["dDateA"]);
            e.NewValues["dDateD"] = Convert.ToDateTime(e.NewValues["dDateD"]);
        }
        catch
        {
            lblMsg.Text = "日期格式錯誤，例：1979/12/3";
            e.Cancel = true;
        }

        if (e.NewValues["bSex"].ToString().Trim().Length == 0)
        {
            e.NewValues["bSex"] = null;
        }
        else
        {
            e.NewValues["bSex"] = e.NewValues["bSex"].ToString() == "1";
        }

        e.NewValues["sKeyMan"] = Request.Cookies["ezFlow"]["Emp_id"];
        e.NewValues["dKeyDate"] = DateTime.Now;
    }

    protected void fv_ItemUpdated(object sender, FormViewUpdatedEventArgs e)
    {
        mv.ActiveViewIndex = 0;
        gv.DataBind();
    }
}
