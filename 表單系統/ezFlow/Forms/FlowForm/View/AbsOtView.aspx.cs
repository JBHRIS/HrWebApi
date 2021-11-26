using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using JBHR.Dll;

public partial class View_AbsOtView : System.Web.UI.Page
{
    private dsAtt.JB_HR_AttendDataTable dtAttend;
    private dsAtt.JB_HR_AttCardDataTable dtAttCard;
    private dsAtt.JB_HR_RoteDataTable dtRote;
    private dsAtt.JB_HR_AbsUnionDataTable dtAbs;
    private dsAtt.JB_HR_OtDataTable dtOt;

    private DataRow[] rows;

    private string Rote, RoteName, R, OnTime, OffTime, Time, T1, T2, T, tr, html;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ddlDept.DataBind();

            lblSql.Text = sdsGV.SelectCommand;

            SetYYMM();

            ddlYYMM.ClearSelection();
            if (ddlYYMM.Items.FindByValue(JBHR.Dll.Tools.DateToYyMm(DateTime.Now)) != null)
                ddlYYMM.Items.FindByValue(JBHR.Dll.Tools.DateToYyMm(DateTime.Now)).Selected = true;

            plColor.Visible = false;
        }

        if (cbAll.Checked)
            sdsGV.SelectCommand = lblSql.Text + " WHERE (GETDATE() BETWEEN Role.dateB AND Role.dateE) AND Dept.path LIKE '" + ddlDept.SelectedItem.Value + "%'";
        else
            sdsGV.SelectCommand = lblSql.Text + " WHERE (GETDATE() BETWEEN Role.dateB AND Role.dateE) AND Dept.path = '" + ddlDept.SelectedItem.Value + "'";
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        if (cbAll.Checked)
            sdsGV.SelectCommand = lblSql.Text + " WHERE (GETDATE() BETWEEN Role.dateB AND Role.dateE) AND Dept.path LIKE '" + ddlDept.SelectedItem.Value + "%'";
        else
            sdsGV.SelectCommand = lblSql.Text + " WHERE (GETDATE() BETWEEN Role.dateB AND Role.dateE) AND Dept.path = '" + ddlDept.SelectedItem.Value + "'";

        gv.DataBind();
    }

    private void SetYYMM()
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("t", typeof(string));
        dt.Columns.Add("v", typeof(string));
        DataRow r;

        DateTime d = new DateTime(2004, 10, 1);
        string yymm;

        //再加三個月的選項
        for (DateTime i = d; i <= DateTime.Now.AddMonths(3); i = i.AddMonths(1))
        {
            yymm = JBHR.Dll.Tools.DateToYyMm(i);
            rows = dt.Select("v = '" + yymm + "'");
            if (rows.Length == 0)
            {
                r = dt.NewRow();
                r["t"] = ConvertYymmToYyymm(yymm) + "(" + yymm + ")";
                r["v"] = yymm;
                dt.Rows.Add(r);
            }
        }

        DataView dv = new DataView(dt);
        dv.Sort = "v Desc";
        ddlYYMM.DataSource = dv;
        ddlYYMM.DataTextField = "t";
        ddlYYMM.DataValueField = "v";
        ddlYYMM.DataBind();

        dt = new DataTable();
        dt.Columns.Add("t", typeof(string));
        dt.Columns.Add("v", typeof(string));

        for (DateTime i = d; i <= DateTime.Now; i = i.AddYears(1))
        {
            yymm = i.Year.ToString();
            rows = dt.Select("v = '" + yymm + "'");
            if (rows.Length == 0)
            {
                r = dt.NewRow();
                r["t"] = yymm + "年";
                r["v"] = yymm;
                dt.Rows.Add(r);
            }
        }

        dv = new DataView(dt);
        dv.Sort = "v Desc";
        cbQueryYear.DataSource = dv;
        cbQueryYear.DataTextField = "t";
        cbQueryYear.DataValueField = "v";
        cbQueryYear.DataBind();
    }

    private string ConvertYymmToYyymm(string yymm)
    {
        string yyy = (Convert.ToInt32(yymm.Substring(0, 3)) + 1911).ToString() + "年";
        string mm = yymm.Substring(3, 2) + "月";
        string yyymm = yyy + mm;

        return yyymm;
    }

    protected void gv_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //滑鼠移至資料列上的顏色
            e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='#FFC0FF'");
            //滑鼠點擊後變色
            e.Row.Attributes.Add("onclick", "this.style.backgroundColor='#FF9933'");
            //e.Row.Attributes.Add("onclick", "window.location.href='Login.aspx'");
            if (e.Row.RowState == DataControlRowState.Alternate)
            {
                //滑鼠離開資料列上的顏色
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='White'");
            }
            else if (e.Row.RowState == DataControlRowState.Normal)
            {
                //滑鼠離開資料列上的顏色
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='#EFF3FB'");
            }
        }
    }
    protected void gv_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Select")
        {
            mv.ActiveViewIndex = 1;

            lblNobr.Text = e.CommandArgument.ToString();

            SetData();
        }
    }
    protected void ddlYYMM_SelectedIndexChanged(object sender, EventArgs e)
    {
        SetData();

        cld.VisibleDate = JBHR.Dll.Tools.DateOfStartOrEnd(ddlYYMM.SelectedItem.Value, true);
    }

    private void SetData()
    {
        string sYYMM = ddlYYMM.SelectedValue;
        DateTime dDateB = Tools.YyMnToDate(sYYMM, 1).AddDays(-10);
        DateTime dDateE = dDateB.AddMonths(1).AddDays(20);
        dtRote = Att.Rote(lblNobr.Text, dDateB, dDateE);
        dtAbs = Att.Abs(lblNobr.Text, dDateB, dDateE);
        dtOt = Att.Ot(lblNobr.Text, dDateB, dDateE);
        dtAttend = Att.Attend(lblNobr.Text, dDateB, dDateE);
        dtAttCard = Att.AttCard(lblNobr.Text, dDateB, dDateE);
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        mv.ActiveViewIndex = 0;
    }
    protected void btnSwap_Click(object sender, EventArgs e)
    {
        mv.ActiveViewIndex = 2;
        cbQueryYear.DataBind();
        GridView1.DataBind();
        GridView2.DataBind();
    }
    protected void btnSwap1_Click(object sender, EventArgs e)
    {
        SetData();
        mv.ActiveViewIndex = 1;
        cld.DataBind();
    }
    protected void bnQuery_Click(object sender, EventArgs e)
    {

    }
    protected void cbColor_CheckedChanged(object sender, EventArgs e)
    {
        SetData();

        plColor.Visible = false;
    }
    protected void cld_DayRender(object sender, DayRenderEventArgs e)
    {
        tr = "";
        var rRote = dtRote.Where(p => p.dAdate.Date == e.Day.Date).FirstOrDefault();
        var rAttend = dtAttend.Where(p => p.dAdate.Date == e.Day.Date).FirstOrDefault();
        var rAttCard = dtAttCard.Where(p => p.dAdate.Date == e.Day.Date).FirstOrDefault();
        if (rRote != null && rAttend != null)
        {
            Rote = rRote.sRoteCode;
            RoteName = rRote.sRoteName;
            R = RoteName + "(" + Rote + ")";
            OnTime = rRote.sOnTime;
            OffTime = rRote.sOffTime;
            Time = OnTime + "-" + OffTime;

            T = "";
            if (rAttCard != null)
            {
                T1 = rAttCard.sT1;
                T2 = rAttCard.sT2;
                T = T1 + "-" + T2;
            }

            tr = "<tr><td" + (cbColor.Checked ? " bgcolor='#FFC0C0'" : "") + ">" + R + "</td></tr>";
            tr += "<tr><td" + (cbColor.Checked ? " bgcolor='#FFFFC0'" : "") + ">" + Time + "</td></tr>";
            tr += "<tr><td" + (cbColor.Checked ? " bgcolor='#C0FFFF'" : "") + ">" + T + "</td></tr>";

            //請假
            var lsAbs = dtAbs.Where(p => p.dDateB.Date == e.Day.Date).ToList();
            foreach (var rAbs in lsAbs)
                tr += "<tr><td" + (cbColor.Checked ? " bgcolor='Red'" : "") + ">" + rAbs.sHoliName + rAbs.iUse.ToString() + rAbs.sUint + "</td></tr>";

            //加班
            var lsOt = dtOt.Where(p => p.dDateB.Date == e.Day.Date).ToList();
            foreach (var rOt in lsOt)
                tr += "<tr><td" + (cbColor.Checked ? " bgcolor='Yellow'" : "") + ">加班：" + Convert.ToString(rOt.iOtHrs + rOt.iRestHrs) + "小時" + "</td></tr>";

        }

        html = "<font size='1'><table width='100%' border='0'>" + tr + "</table></font>";
        Label lb = new Label();
        lb.Text = html;
        e.Cell.Controls.Add(lb);
    }
    protected void cld_VisibleMonthChanged(object sender, MonthChangedEventArgs e)
    {
        ddlYYMM.ClearSelection();
        if (ddlYYMM.Items.FindByValue(JBHR.Dll.Tools.DateToYyMm(e.NewDate)) != null)
            ddlYYMM.Items.FindByValue(JBHR.Dll.Tools.DateToYyMm(e.NewDate)).Selected = true;

        SetData();
    }
}