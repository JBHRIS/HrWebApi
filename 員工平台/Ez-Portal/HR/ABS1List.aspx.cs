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
 

public partial class HR_ABS1List : JBWebPage
{
    protected void Page_Load(object sender, EventArgs e)
    {

        HRDs.EmpInfoDataTable empdt = new HRDsTableAdapters.EmpInfoTableAdapter().GetDataByAll();

        DataTable dt = new DataTable();
        dt.Columns.Add("a1");
        dt.Columns.Add("a2");
        dt.Columns.Add("a3");
        dt.Columns.Add("a4");
        dt.Columns.Add("a5");
        dt.Columns.Add("a6");
        dt.Columns.Add("a7");
        dt.Columns.Add("BDATE"); //得假日期
        dt.Columns.Add("nobr");
        dt.Columns.Add("name");
        dt.Columns.Add("emp_year");
        dt.Columns.Add("indt");
        dt.Columns.Add("dept");
        dt.Columns.Add("d_name");
       

        for (int i = 0; i < empdt.Rows.Count; i++) {

            DataRow row = dt.NewRow();
            row["nobr"] = empdt[i].NOBR;
            row["name"] = empdt[i].NAME_C;
            row["emp_year"] = setEmpYear(empdt[i].NOBR);
            row["indt"] = empdt[i].INDT.ToShortDateString();
            row["dept"] = empdt[i].DEPT.Trim();
            row["d_name"] = empdt[i].D_NAME.Trim();
             setAbsData(row, empdt[i].NOBR);
             dt.Rows.Add(row);
        }

        DataView dv = dt.DefaultView;
        dv.Sort = "nobr ASC";

        GridView2.DataSource = dv;
        GridView2.DataBind();
    }

    HRDsTableAdapters.basettsTableAdapter ttsad = new HRDsTableAdapters.basettsTableAdapter();
    string setEmpYear(string _nobr ) {

        double inCompYear = 0;
        double leCompYear = 0;
        double chCompYear = 0;

        DateTime endDate = new DateTime();
        HRDs.basettsDataTable ttsNowInfodt = ttsad.GetDataByNowInfo(_nobr);
        HRDs.basettsDataTable ttsdt = ttsad.GetData(_nobr);

        if (ttsNowInfodt.Rows.Count <= 0)
            return "";


        switch (ttsNowInfodt[0].TTSCODE.Trim())
        {
            case "1":
            case "4":
            case "6":
               
                endDate = DateTime.Now.Date;
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





    DataRow setAbsData(DataRow row,string _nobr)
    {
        string nobr =_nobr;
        DateTime adate;
        DateTime ddate;
        //if (DateTime.Parse(DateTime.Now.ToShortDateString()) < DateTime.Parse(DateTime.Now.Year.ToString() + "/04/01"))
        //{
        //    adate = DateTime.Parse(Convert.ToString(DateTime.Now.Year - 1) + "/01/01");
        //    ddate = DateTime.Parse(DateTime.Now.Year.ToString() + "/12/31");
        //}
        //else
        //{
        //    adate = DateTime.Parse(DateTime.Now.Year.ToString() + "/04/01");
        //    ddate = DateTime.Parse(Convert.ToString(DateTime.Now.Year + 1) + "/03/31");
        //}
        adate = DateTime.Parse(DateTime.Now.Year.ToString() + "/01/01");
        ddate = DateTime.Parse(Convert.ToString(DateTime.Now.Year ) + "/12/31");
        decimal a1 = 0;//去年度剩餘年假
        decimal a2 = 0;//今年度年假
        decimal a3 = 0;//今年已請天數
        decimal a4 = 0;//可累計之天數
        decimal a5 = 0;//今年度剩餘天數
        decimal a6 = 0;//本月份已請天數
        decimal a7 = 0;//去年度剩餘年假未休天數
       // DateTime BDATE //得假日期


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
                row["BDATE"] = absdt[i].BDATE.ToShortDateString();
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
        //row["BDATE"] = 
        return row;

    }
    protected void btnExportExcel_Click(object sender, EventArgs e)
    {
        Response.ClearContent();
        string excelFileName = "data.xls";
        Response.AddHeader("content-disposition", "attachment;filename=" + Server.UrlEncode(excelFileName));
        Response.ContentType = "application/excel";
        System.IO.StringWriter stringWrite = new System.IO.StringWriter();
        System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
        GridView2.RenderControl(htmlWrite);
        Response.Write(stringWrite.ToString());
        Response.End();
    }
}
