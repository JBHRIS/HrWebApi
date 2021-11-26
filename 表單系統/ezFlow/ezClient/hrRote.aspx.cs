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

public partial class hrRote : System.Web.UI.Page
{
    public FlowHrDSTableAdapters.hrRoteTableAdapter hrRoteTA = new FlowHrDSTableAdapters.hrRoteTableAdapter();

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
        if (e.Values["sRoteCode"].ToString().Length == 0)
        {
            lblMsg.Text = "班別代碼為必填欄位";
            e.Cancel = true;
        }

        if (e.Values["sRoteName"].ToString().Length == 0)
        {
            lblMsg.Text = "班別名稱為必填欄位";
            e.Cancel = true;
        }

        try
        {
            e.Values["sWorkTimeB"] = Convert.ToInt32(e.Values["sWorkTimeB"]).ToString().PadLeft(4 , char.Parse("0"));
            e.Values["sWorkTimeE"] = Convert.ToInt32(e.Values["sWorkTimeE"]).ToString().PadLeft(4, char.Parse("0"));
            e.Values["sRes1TimeB"] = Convert.ToInt32(e.Values["sRes1TimeB"]).ToString().PadLeft(4, char.Parse("0"));
            e.Values["sRes1TimeE"] = Convert.ToInt32(e.Values["sRes1TimeE"]).ToString().PadLeft(4, char.Parse("0"));
            e.Values["sRes2TimeB"] = Convert.ToInt32(e.Values["sRes2TimeB"]).ToString().PadLeft(4, char.Parse("0"));
            e.Values["sRes2TimeE"] = Convert.ToInt32(e.Values["sRes2TimeE"]).ToString().PadLeft(4, char.Parse("0"));
            e.Values["iWorkHour"] = Convert.ToDecimal(e.Values["iWorkHour"]);
        }
        catch
        {
            lblMsg.Text = "工作時間或休息時間或投入工時的格式錯誤，例：0830";
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

        if (hrRoteTA.GetDataByRoteCode(e.Values["sRoteCode"].ToString()).Rows.Count > 0)
        {
            lblMsg.Text = "工號重複";
            e.Cancel = true;
        }

        e.Values["dDateD"] = new DateTime(9999, 12, DateTime.DaysInMonth(9999, 12));
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
        if (e.NewValues["sRoteName"].ToString().Length == 0)
        {
            lblMsg.Text = "班別名稱為必填欄位";
            e.Cancel = true;
        }

        try
        {
            e.NewValues["sWorkTimeB"] = Convert.ToInt32(e.NewValues["sWorkTimeB"]).ToString().PadLeft(4, char.Parse("0"));
            e.NewValues["sWorkTimeE"] = Convert.ToInt32(e.NewValues["sWorkTimeE"]).ToString().PadLeft(4, char.Parse("0"));
            e.NewValues["sRes1TimeB"] = Convert.ToInt32(e.NewValues["sRes1TimeB"]).ToString().PadLeft(4, char.Parse("0"));
            e.NewValues["sRes1TimeE"] = Convert.ToInt32(e.NewValues["sRes1TimeE"]).ToString().PadLeft(4, char.Parse("0"));
            e.NewValues["sRes2TimeB"] = Convert.ToInt32(e.NewValues["sRes2TimeB"]).ToString().PadLeft(4, char.Parse("0"));
            e.NewValues["sRes2TimeE"] = Convert.ToInt32(e.NewValues["sRes2TimeE"]).ToString().PadLeft(4, char.Parse("0"));
            e.NewValues["iWorkHour"] = Convert.ToDecimal(e.NewValues["iWorkHour"]);
        }
        catch
        {
            lblMsg.Text = "工作時間或休息時間或投入工時的格式錯誤，例：0830";
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

        e.NewValues["sKeyMan"] = Request.Cookies["ezFlow"]["Emp_id"];
        e.NewValues["dKeyDate"] = DateTime.Now;
    }

    protected void fv_ItemUpdated(object sender, FormViewUpdatedEventArgs e)
    {
        mv.ActiveViewIndex = 0;
        gv.DataBind();
    }
}
