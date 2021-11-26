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

public partial class hrAbs : System.Web.UI.Page
{
    public FlowHrDSTableAdapters.hrAbsTableAdapter hrAbsTA = new FlowHrDSTableAdapters.hrAbsTableAdapter();

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
        if (e.Values["sNobr"].ToString().Length == 0)
        {
            lblMsg.Text = "工號為必填欄位";
            e.Cancel = true;
        }

        DateTime date, dateB, dateE;
        date = DateTime.Now;
        dateB = date;
        dateE = date;
        try
        {
            dateB = Convert.ToDateTime(e.Values["dDateB"]).AddMinutes(Convert.ToUInt32(e.Values["sTimeB"]));
            dateE = Convert.ToDateTime(e.Values["dDateE"]).AddMinutes(Convert.ToUInt32(e.Values["sTimeE"]));
        }
        catch
        {
            lblMsg.Text = "請假日期或時間的格式錯誤";
            e.Cancel = true;
        }

        try
        {
            e.Values["iHour"] = Convert.ToDecimal(e.Values["iHour"]);
        }
        catch
        {
            lblMsg.Text = "請假時數格式錯誤";
            e.Cancel = true;
        }

        if (hrAbsTA.GetDataByKey(dateE, dateB, e.Values["sNobr"].ToString(), e.Values["sHcodeCode"].ToString()).Rows.Count > 0)
        {
            lblMsg.Text = "時間重複";
            e.Cancel = true;
        }

        e.Values["dDatetimeB"] = dateB;
        e.Values["dDatetimeE"] = dateE;
        e.Values["sYYMM"] = "0000";
        e.Values["sSn"] = "ABS" + date.Month.ToString() + date.Day.ToString() + date.Hour.ToString() + date.Minute.ToString() + date.Second.ToString();
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
        DateTime date, dateB, dateE;
        date = DateTime.Now;
        dateB = date;
        dateE = date;
        try
        {
            dateB = Convert.ToDateTime(e.NewValues["dDateB"]).AddMinutes(Convert.ToUInt32(e.NewValues["sTimeB"]));
            dateE = Convert.ToDateTime(e.NewValues["dDateE"]).AddMinutes(Convert.ToUInt32(e.NewValues["sTimeE"]));
        }
        catch
        {
            lblMsg.Text = "請假日期或時間的格式錯誤";
            e.Cancel = true;
        }

        try
        {
            e.NewValues["iHour"] = Convert.ToDecimal(e.NewValues["iHour"]);
        }
        catch
        {
            lblMsg.Text = "請假時數格式錯誤";
            e.Cancel = true;
        }

        if (hrAbsTA.GetDataByKey(dateE, dateB, e.NewValues["sNobr"].ToString(), e.NewValues["sHcodeCode"].ToString()).Rows.Count > 1)
        {
            lblMsg.Text = "重複";
            e.Cancel = true;
        }

        e.NewValues["dDatetimeB"] = dateB;
        e.NewValues["dDatetimeE"] = dateE;
        e.NewValues["sYYMM"] = "00000";
        e.NewValues["sSn"] = e.NewValues["sSn"].ToString().Trim().Length == 0 ? " " : e.NewValues["sSn"];
        e.NewValues["sKeyMan"] = Request.Cookies["ezFlow"]["Emp_id"];
        e.NewValues["dKeyDate"] = DateTime.Now;
    }

    protected void fv_ItemUpdated(object sender, FormViewUpdatedEventArgs e)
    {
        mv.ActiveViewIndex = 0;
        gv.DataBind();
    }
}
