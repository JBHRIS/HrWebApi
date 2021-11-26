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

public partial class hrHoliday : System.Web.UI.Page
{
    public FlowHrDSTableAdapters.hrHolidayTableAdapter hrHolidayTA = new FlowHrDSTableAdapters.hrHolidayTableAdapter();
    public FlowHrDSTableAdapters.hrBaseMTableAdapter hrBaseMTA = new FlowHrDSTableAdapters.hrBaseMTableAdapter();
    public FlowHrDSTableAdapters.hrRoteTableAdapter hrRoteTA = new FlowHrDSTableAdapters.hrRoteTableAdapter();

    public FlowHrDS oFlowHrDS;

    public DataRow[] rows, rowsA, rowsB;

    public string nobr, rote, holiday, r, n, h, tr, html, color;

    protected void Page_Load(object sender, EventArgs e)
    {
        oFlowHrDS = new FlowHrDS();

        lblMsg.Text = "";
        nobr = ddlBase.SelectedItem.Value;
        rote = ddlRote.SelectedItem.Value;
        holiday = ddlHoliday.SelectedItem.Value;

        hrHolidayTA.Fill(oFlowHrDS.hrHoliday);
        hrBaseMTA.Fill(oFlowHrDS.hrBaseM);
        hrRoteTA.Fill(oFlowHrDS.hrRote);
    }

    public FlowHrDS.hrHolidayRow rh;
    public FlowHrDS.hrBaseMRow rb;
    public FlowHrDS.hrRoteRow rr;
    protected void cldHoliday_DayRender(object sender, DayRenderEventArgs e)
    {
        tr = "";
        rows = oFlowHrDS.hrHoliday.Select("dHdate = '" + e.Day.Date.ToShortDateString() + "'");
        foreach (FlowHrDS.hrHolidayRow rh in rows)
        {
            n = (rh.sNobr.Trim().Length == 0) && (rh.sRoteCode.Trim().Length == 0) ? "所有人" : "";
            r = (rh.sNobr.Trim().Length == 0) && (rh.sRoteCode.Trim().Length == 0) ? "所有班別" : "";
            h = rh.bHoliday ? "休息日" : "上班日";
            color = rh.bHoliday ? "Red" : "Blue";

            rowsA = oFlowHrDS.hrBaseM.Select("sNobr = '" + rh.sNobr + "'");
            if (rowsA.Length > 0)
            {
                rb = (FlowHrDS.hrBaseMRow)rowsA[0];
                n = rb.sName;
            }

            rowsB = oFlowHrDS.hrRote.Select("sRoteCode = '" + rh.sRoteCode + "'");
            if (rowsB.Length > 0)
            {
                rr = (FlowHrDS.hrRoteRow)rowsB[0];
                r = rr.sRoteName;
            }

            tr += "<tr><td bgcolor='" + color + "'>" + n + r + h + "</td></tr>";
        }

        html = "<font size='1'><table width='100%' border='0'>" + tr + "</table></font>";
        Label lb = new Label();
        lb.Text = html;
        e.Cell.Controls.Add(lb);
    }

    protected void cldHoliday_SelectionChanged(object sender, EventArgs e)
    {
        DateTime date = cldHoliday.SelectedDate.Date;
        rows = oFlowHrDS.hrHoliday.Select("dHdate = '" + date.ToShortDateString() + "' AND sRoteCode = '" + rote + "' AND sNobr = '" + nobr + "'");

        //清除設定
        if (holiday == "2")
        {
            foreach (FlowHrDS.hrHolidayRow rh in rows) rh.Delete();
        }
        else
        {
            //如果使用者點的那天在行事曆已經存在
            if (rows.Length > 0)
            {
                lblMsg.Text = "資料重複";
            }
            else
            {
                rh = oFlowHrDS.hrHoliday.NewhrHolidayRow();
                rh.dHdate = date;
                rh.sRoteCode = rote.Trim();
                rh.sNobr = nobr.Trim();
                rh.bHoliday = holiday == "1";
                rh.sKeyMan = Request.Cookies["ezFlow"]["Emp_id"];
                rh.dKeyDate = DateTime.Now;
                oFlowHrDS.hrHoliday.AddhrHolidayRow(rh);
            }
        }

        hrHolidayTA.Update(oFlowHrDS.hrHoliday);
        cldHoliday.SelectedDates.Clear();
    }
}
