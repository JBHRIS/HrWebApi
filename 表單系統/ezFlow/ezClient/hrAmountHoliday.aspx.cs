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

public partial class hrAmountHoliday : System.Web.UI.Page
{
    public FlowHrDSTableAdapters.hrHcodeTableAdapter hrHcodeTA = new FlowHrDSTableAdapters.hrHcodeTableAdapter();
    public FlowHrDSTableAdapters.hrAbsTableAdapter hrAbsTA = new FlowHrDSTableAdapters.hrAbsTableAdapter();
    public FlowHrDSTableAdapters.hrBaseMTableAdapter hrBaseMTA = new FlowHrDSTableAdapters.hrBaseMTableAdapter();

    public FlowHrDS oFlowHrDS;

    public DataRow[] rows;

    protected void Page_Load(object sender, EventArgs e)
    {
        oFlowHrDS = new FlowHrDS();
        lblMsg.Text = "";
        
        if (!this.IsPostBack)
        {
            hrHcodeTA.FillByHcodeCode(oFlowHrDS.hrHcode, "A");
            if (oFlowHrDS.hrHcode.Rows.Count > 0)
            {
                //得知目前特休假別的單位
                FlowHrDS.hrHcodeRow rh = (FlowHrDS.hrHcodeRow)oFlowHrDS.hrHcode.Rows[0];
                lblHcode.Text = rh.sUnitCode == "1" ? "小時" : "天";

                //取得目前年度
                DateTime date = DateTime.Now.Date;
                txtYear.Text = date.Year.ToString();
            }
        }
    }

    protected void btnAmount_Click(object sender, EventArgs e)
    {
        //現在日期，特休計算開始日，特休計算結束日，特休給假開始日，特休給假結束日
        DateTime date, dateB, dateE, dateA, dateD;
        String sDateB, sDateE, sDateA, sDateD , sHoliday;
        date = DateTime.Now.Date;

        try
        {
            dateB = Convert.ToDateTime(txtYear.Text + "/" + txtMonthDayB.Text);
            dateE = Convert.ToDateTime(txtYear.Text + "/" + txtMonthDayE.Text);
        }
        catch
        {
            lblMsg.Text = "日期格式錯誤";
            return;
        }

        sDateA = rblDateA.SelectedItem.Value;
        sDateB = rblDateB.SelectedItem.Value;
        sDateE = rblDateE.SelectedItem.Value;
        sHoliday = rblHoliday.SelectedItem.Value;

        double y = 0;  //年資
        int x = 0;  //取整數後的年資
        int d = 0;  //給假天數
        int d0, d1, d9, d10 , d30;
        TimeSpan ts;

        FlowHrDS.hrAbsDataTable dtAbs = new FlowHrDS.hrAbsDataTable();
        hrAbsTA.Fill(dtAbs);

        hrBaseMTA.FillByDate(oFlowHrDS.hrBaseM, dateB);
        foreach (FlowHrDS.hrBaseMRow rb in oFlowHrDS.hrBaseM.Rows)
        {
            if (dtAbs.Select("sNobr = '" + rb.sNobr + "' AND sYYMM = '" + txtYear.Text + "'").Length == 0)
            {
                date = rb.dDateA.Date;  //到職日
                dateB = (sDateB == "1") ? date
                    : (Convert.ToInt32(date.Month.ToString() + date.Day.ToString().PadLeft(2, char.Parse("0")))) <= (Convert.ToInt32(dateB.Month.ToString() + dateB.Day.ToString().PadLeft(2, char.Parse("0"))))
                    ? new DateTime(date.Year, dateB.Month, dateB.Day) : new DateTime(date.AddYears(1).Year, dateB.Month, dateB.Day); //特休計算開始日
                dateE = (sDateE == "1") ? new DateTime(dateE.Year, date.Month, date.Day) : dateE;    //特休計算結束日
                dateA = (sDateA == "1") ? dateE : dateE.AddYears(1);
                dateD = dateA.AddYears(1).AddDays(-1);

                //特休計算開始日減到職日
                ts = dateE - dateB;

                y = ts.TotalDays / 365;
                x = Convert.ToInt32(y);

                d0 = Convert.ToInt32(((TextBox)((ContentPlaceHolder)Page.Master.FindControl("ContentPlaceHolder1")).FindControl("txtHoliday0")).Text);
                d1 = Convert.ToInt32(((TextBox)((ContentPlaceHolder)Page.Master.FindControl("ContentPlaceHolder1")).FindControl("txtHoliday1")).Text);
                d9 = Convert.ToInt32(((TextBox)((ContentPlaceHolder)Page.Master.FindControl("ContentPlaceHolder1")).FindControl("txtHoliday9")).Text);
                d10 = Convert.ToInt32(((TextBox)((ContentPlaceHolder)Page.Master.FindControl("ContentPlaceHolder1")).FindControl("txtHoliday10")).Text);
                d30 = 8 * 30;

                if (y < 1)  //1年以下(不含)
                {
                    if (sHoliday == "1")  //不給假
                        d = 0;
                    else if (sHoliday == "2")
                        d = Convert.ToInt32(Math.Round(y, 0));
                    else if (sHoliday == "3")
                        d = d0;
                }
                else if (y <= 9)    //9年以下者(含)
                {
                    d = Convert.ToInt32(((TextBox)((ContentPlaceHolder)Page.Master.FindControl("ContentPlaceHolder1")).FindControl("txtHoliday" + x.ToString())).Text);
                }
                else
                {
                    d = d9 + (d10 * (x - 9));
                }

                FlowHrDS.hrAbsRow ra = oFlowHrDS.hrAbs.NewhrAbsRow();
                ra.sSn = "";
                ra.sNobr = rb.sNobr;
                ra.sName = rb.sName;
                ra.dDateB = dateA.Date;
                ra.dDateE = dateD.Date;
                ra.sTimeB = "0000";
                ra.sTimeE = "0000";
                ra.dDatetimeB = dateA.Date;
                ra.dDatetimeE = dateD.Date;
                ra.sHcodeCode = "W";
                ra.iHour = d >= d30 ? d30 : d;
                ra.sYYMM = txtYear.Text;
                ra.sNote = "特休統一給假";
                ra.sKeyMan = Request.Cookies["ezFlow"]["Emp_id"];
                ra.dKeyDate = DateTime.Now;
                oFlowHrDS.hrAbs.AddhrAbsRow(ra);
            }
        }

        Session["oFlowHrDS"] = oFlowHrDS;
        gv.DataSource = oFlowHrDS.hrAbs;
        gv.DataBind();

        mv.ActiveViewIndex = 1;
        lblMsg.Text = "產生完成";
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        mv.ActiveViewIndex = 0;

        if (Session["oFlowHrDS"] == null)
        {
            lblMsg.Text = "參數錯誤請重新產生";
            return;
        }

        oFlowHrDS = (FlowHrDS)Session["oFlowHrDS"];

        hrAbsTA.Update(oFlowHrDS.hrAbs);
        lblMsg.Text = "新增完成";
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        mv.ActiveViewIndex = 0;
        Session.Remove("oFlowHrDS");
    }
}