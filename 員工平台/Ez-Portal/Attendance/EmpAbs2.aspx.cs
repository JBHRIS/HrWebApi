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
using System.Collections.Generic;
using BL;
using System.Data.Linq;
using System.Linq;

public partial class Attendance_EmpAbs2 : JBWebPage
{
    private HRDsTableAdapters.basettsTableAdapter ttsad = new HRDsTableAdapters.basettsTableAdapter();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            SiteHelper siteHelper = new SiteHelper();
            DateTime startDatetime, endDatetime;
            siteHelper.SetDateRangeForThisYear(out startDatetime, out endDatetime);
            adate.SelectedDate = startDatetime;
            ddate.SelectedDate = endDatetime;
            Session[SessionName] = null;
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        GetData();
    }

    void GetData()
    {
        ABS_REPO absRepo = new ABS_REPO();

        List<BL.ABS> absList = new List<BL.ABS>();

        string[] yearRestArr = { "1", "2" };

        absList.AddRange(absRepo.GetByNobrDateRange_Dlo(JbUser.NOBR, adate.SelectedDate.Value, ddate.SelectedDate.Value, yearRestArr));

        Session[SessionName] = absList;
        GridView2.DataSource = (from c in absList
                                select new
                                {
                                    c.NOBR,
                                    c.BASE.NAME_C,
                                    c.BASE.NAME_E,
                                    c.BASE.BASETTS[0].JOB1.JOB_NAME,
                                    c.BASE.BASETTS[0].DEPT1.D_NAME,
                                    c.BDATE,
                                    c.BTIME,
                                    c.ETIME,
                                    c.H_CODE,
                                    c.HCODE.H_NAME,
                                    c.HCODE.UNIT,
                                    c.TOL_HOURS,
                                    c.NOTE
                                }).OrderByDescending(p => p.BDATE).ToList();
        GridView2.DataBind();
    }


    protected void Button2_Click(object sender, EventArgs e)
    {
        if (Session[SessionName] != null)
        {
            var list = (from c in (List<BL.ABS>)Session[SessionName]
                        select new
                        {
                            c.NOBR,
                            c.BASE.NAME_C,
                            c.BASE.NAME_E,
                            c.BASE.BASETTS[0].JOB1.JOB_NAME,
                            c.BASE.BASETTS[0].DEPT1.D_NAME,
                            c.BDATE,
                            c.BTIME,
                            c.ETIME,
                            c.H_CODE,
                            c.HCODE.H_NAME,
                            c.HCODE.UNIT,
                            c.TOL_HOURS,
                            c.NOTE
                        }).ToList();
            JB.WebModules.Data.Export.Excel.WebResponseExcel(this, GridView2, list, SessionName);
        }
        else
            JB.WebModules.Message.Show("無資料可匯出！");
    }
    protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Cells[5].Text = SiteHelper.ConvertStrTimeTo24(e.Row.Cells[5].Text);
            e.Row.Cells[6].Text = SiteHelper.ConvertStrTimeTo24(e.Row.Cells[6].Text);
        }
    }
    protected void rblCate_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rblCate.SelectedValue.Equals("1"))
            MultiView1.ActiveViewIndex = 0;
        else
            MultiView1.ActiveViewIndex = 1;
    }
    protected void btnSummurySearch_Click(object sender, EventArgs e)
    {
        bindSummuryData();
    }

    private void bindSummuryData()
    {

        DateTime adate = DateTime.Parse(DateTime.Now.Year.ToString() + "/1/1");
        DateTime ddate = DateTime.Parse(DateTime.Now.Year.ToString() + "/12/31");
        HRDs.EmpInfoDataTable empdt = new HRDs.EmpInfoDataTable();

        empdt.Merge(new HRDsTableAdapters.EmpInfoTableAdapter().GetDataByNobr(Juser.Nobr));

        DataTable dt = new DataTable();
        dt.Columns.Add("a1");
        dt.Columns.Add("a2");
        dt.Columns.Add("a3");
        dt.Columns.Add("a4");
        dt.Columns.Add("a5");
        dt.Columns.Add("a6");
        dt.Columns.Add("a7");
        dt.Columns.Add("nobr");
        dt.Columns.Add("name");
        dt.Columns.Add("name_e");
        dt.Columns.Add("emp_year");
        dt.Columns.Add("indt");
        dt.Columns.Add("dept");


        for (int i = 0; i < empdt.Rows.Count; i++)
        {
            DataRow row = dt.NewRow();
            row["nobr"] = empdt[i].NOBR;
            row["name"] = empdt[i].NAME_C;
            row["name_e"] = empdt[i].NAME_E;
            row["emp_year"] = setEmpYear(empdt[i].NOBR);
            row["indt"] = empdt[i].INDT.ToShortDateString();
            //row["dept"] = empdt[i].DEPT.Trim();
            row["dept"] = empdt[i].D_NAME.Trim();
            setAbsData(row, empdt[i].NOBR);
            dt.Rows.Add(row);
        }

        Session.Add(SessionName2, dt);
        GridView3.DataSource = dt;
        GridView3.DataBind();
    }

    string setEmpYear(string _nobr)
    {
        double inCompYear = 0;
        double leCompYear = 0;
        double chCompYear = 0;

        DateTime endDate = new DateTime();
        HRDs.basettsDataTable ttsNowInfodt = ttsad.GetDataByNowInfo(Juser.Nobr);
        HRDs.basettsDataTable ttsdt = ttsad.GetData(Juser.Nobr);

        if (ttsNowInfodt.Rows.Count <= 0)
            return "";


        switch (ttsNowInfodt[0].TTSCODE.Trim())
        {
            case "1":
            case "4":
            case "6":

                endDate = DateTime.Now;
                break;
            case "2":

                endDate = ttsNowInfodt[0].OUDT;
                break;
            case "3":

                endDate = ttsNowInfodt[0].STINDT;
                break;
            case "5":

                endDate = ttsNowInfodt[0].STOUDT;
                break;
        }


        TimeSpan ts = (TimeSpan)(endDate - DateTime.Parse(ttsNowInfodt[0].INDT.ToShortDateString()));
        inCompYear = Math.Round((double)ts.Days / 365, 2, MidpointRounding.AwayFromZero);

        HRDs.basettsRow[] ttsrows = (HRDs.basettsRow[])ttsdt.Select("ttscode='4'");
        for (int i = 0; i < ttsrows.Length; i++)
        {
            TimeSpan tss = (TimeSpan)(ttsrows[i].STINDT - ttsrows[i].STDT);
            leCompYear += Math.Round((double)tss.Days / 365, 2, MidpointRounding.AwayFromZero);

        }

        DateTime indt = ttsNowInfodt[0].INDT;

        int mo = 0;
        int ye = 0;
        indt.AddDays(leCompYear);
        indt = indt.AddMonths(1);

        for (; indt < DateTime.Now; )
        {

            if (mo == 12)
            {
                ye += 1;
                mo = 0;
            }

            mo += 1;
            indt = indt.AddMonths(1);

            if (indt > DateTime.Now)
                break;
        }

        chCompYear = inCompYear - leCompYear;
        // lb_year.Text = chCompYear.ToString();

        string s_year = ye + "年" + mo.ToString() + "月";
        return s_year;
    }

    DataRow setAbsData(DataRow row, string _nobr)
    {
        string nobr = _nobr;
        DateTime adate;
        DateTime ddate;

        adate = DateTime.Parse(DateTime.Now.Year.ToString() + "/01/01");
        ddate = DateTime.Parse(Convert.ToString(DateTime.Now.Year) + "/12/31");
        decimal a1 = 0;//去年度剩餘年假
        decimal a2 = 0;//今年度年假
        decimal a3 = 0;//今年已請天數
        decimal a4 = 0;//可累計之天數
        decimal a5 = 0;//今年度剩餘天數
        decimal a6 = 0;//本月份已請天數
        decimal a7 = 0;//去年度剩餘年假未休天數

        eHRDSTableAdapters.AbsInfoTableAdapter absad = new eHRDSTableAdapters.AbsInfoTableAdapter();
        eHRDS.AbsInfoDataTable absdt = absad.GetData(nobr, adate, ddate);
        for (int i = 0; i < absdt.Rows.Count; i++)
        {
            if (absdt[i].H_NAME.Trim().Equals("特休(延)"))
            {
                a1 += absdt[i].TOL_HOURS;
            }
            else if (absdt[i].H_NAME.Trim().Equals("特休(得)"))
            {
                a2 += absdt[i].TOL_HOURS;
            }
            else
            {
                a3 += absdt[i].TOL_HOURS;
                if (DateTime.Now.Month == absdt[i].BDATE.Month)
                {
                    a6 += absdt[i].TOL_HOURS;
                }
            }
        }

        if ((a1 - a3) < 0)
        {
            a4 = a2 - Math.Abs((a1 - a3));
        }
        else
        {
            a4 = a2;
        }
        //    a4 = ;

        a5 = (a1 + a2) - a3;

        if ((a1 - a3) > 0)
        {
            a7 = a1 - a3;
        }

        row[0] = Math.Round(a1, 1);
        row[1] = Math.Round(a2, 1);
        row[2] = Math.Round(a3, 1);
        row[3] = Math.Round(a4, 1);
        row[4] = Math.Round(a5, 1);
        row[5] = Math.Round(a6, 1);
        row[6] = Math.Round(a7, 1);

        return row;
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        if (Session[SessionName2] != null)
            JB.WebModules.Data.Export.Excel.WebResponseExcel(this, GridView3, (DataTable)Session[SessionName2], SessionName2);
        else
            JB.WebModules.Message.Show("無資料可匯出！");
    }
    
}
