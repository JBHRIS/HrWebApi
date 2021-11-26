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

public partial class calendarList : JUserControl
{
    protected void Page_Load(object sender, EventArgs e) 
    {
        if (!IsPostBack) 
        {
            setData(DateTime.Parse(DateTime.Now.Year.ToString() + "/" + DateTime.Now.Month + "/1"),
                  DateTime.Parse(DateTime.Now.Year.ToString() + "/" + DateTime.Now.Month + "/" + DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month).ToString()));
       
        }

    }
    void setData(DateTime adate, DateTime ddate) 
    {

        HRDsTableAdapters.basettsTableAdapter bad = new HRDsTableAdapters.basettsTableAdapter();
        //HRDs.basettsDataTable bdt = bad.GetDataByAdateBetween(adate, ddate);
        //HRDs.basettsDataTable prdt = bad.GetDataByPro(3, adate, ddate);
        HRDs.basettsDataTable prdt = bad.GetDataByProExcept235(3, adate, ddate);

        //過濾資料群組
        SiteHelper siteHelper = new SiteHelper();
        prdt = siteHelper.GetSelectedEmpData(prdt, "NOBR", Juser.SalaDrNobrList) as HRDs.basettsDataTable;

        //先抓離職人員、For禾伸堂，他們顯示離職要顯示最後上班日  bdt 所有要顯示的資料
        HRDs.basettsDataTable bdt = bad.GetDataByTts25DateRange(adate.AddDays(1), ddate.AddDays(1));
        foreach (HRDs.basettsRow row in bdt)
        {
            row.ADATE = row.ADATE.AddDays(-1);
        }

        bdt.Merge(bad.GetDataByTts134DateRange(adate, ddate));

        //過濾資料群組
        bdt = siteHelper.GetSelectedEmpData(bdt, "NOBR", Juser.SalaDrNobrList) as HRDs.basettsDataTable;

        int _1 = 0;
        int _2 = 0;
        int _3 = 0;
        int _4 = 0;
        int _5 = 0;
        
        DataTable rv_bdtcount = new DataTable();
        rv_bdtcount.Columns.Add("ttsdesc", typeof(string));
        rv_bdtcount.Columns.Add("count", typeof(decimal));
        rv_bdtcount.PrimaryKey = new DataColumn[] { rv_bdtcount.Columns["ttsdesc"] };
        DataRow[] rowtts = bdt.Select("", "ttscode asc");
        foreach (DataRow Row in rowtts)
        {
            string _ttsdesc = "";
            switch (Row["TTSCODE"].ToString().Trim())
            {
                case "1":
                    _ttsdesc = "新進";
                    break;
                case "2":
                    _ttsdesc = "離職";
                    break;
                case "3":
                    _ttsdesc = "留停";
                    break;
                case "4":
                    _ttsdesc = "復職";
                    break;
                case "5":
                    _ttsdesc = "停職";
                    break;
            }
            DataRow row = rv_bdtcount.Rows.Find(_ttsdesc);
            if (row != null)
                row["count"] = decimal.Parse(row["count"].ToString()) + 1;
            else
            {
                DataRow aRow = rv_bdtcount.NewRow();
                aRow["ttsdesc"] = _ttsdesc;
                aRow["count"] = 1;
                rv_bdtcount.Rows.Add(aRow);
            }
        }

        for (int i = 0; i < prdt.Rows.Count; i++)
        {
            prdt[i].TTSCODE = "7";
            prdt[i].ADATE = prdt[i].ADATE.AddMonths(3);
            DataRow row = rv_bdtcount.Rows.Find("試用期滿");
            if (row != null)
                row["count"] = decimal.Parse(row["count"].ToString()) + 1;
            else
            {
                DataRow aRow = rv_bdtcount.NewRow();
                aRow["ttsdesc"] = "試用期滿";
                aRow["count"] = 1;
                rv_bdtcount.Rows.Add(aRow);
            }
        }

        bdt.Merge(prdt);

        BdtGV.DataSource = rv_bdtcount;
        BdtGV.DataBind();
        Session["bdt"] = bdt;
    }

    protected void Calendar1_DayRender(object sender, DayRenderEventArgs e) 
    {
        if(Session["bdt"]==null)
            setData(DateTime.Parse(e.Day.Date.Year.ToString()+"/"+e.Day.Date.Month+"/1"),
                DateTime.Parse(e.Day.Date.Year.ToString()+"/"+e.Day.Date.Month+"/"+DateTime.DaysInMonth(e.Day.Date.Year,e.Day.Date.Month).ToString()));

        HRDs.basettsDataTable bdt = (HRDs.basettsDataTable)Session["bdt"];
        HRDs.basettsRow[] brow = (HRDs.basettsRow[])bdt.Select("adate ='"+e.Day.Date.ToShortDateString()+"'");
        int _1 = 0;
        int _2 = 0;
        int _3 = 0;
        int _4 = 0;
        int _5 = 0;
        int _7 = 0;
        for (int i = 0; i < brow.Length; i++) {

            switch (brow[i].TTSCODE.Trim()) {
                case "1":
                    _1 += 1;
                    break;
                case "2":
                    _2 += 1;
                    break;
                case "3":
                    _3 += 1;
                    break;
                case "4":
                    _4 += 1;
                    break;
                case "5":
                    _5 += 1;
                    break;
                case "7":
                    _7 += 1;
                    break;
            }
        }
        string s_1 = "   <tr> <td> <span style=\"color: #000099\">到職人數</span>：" + _1.ToString() + "人</td> </tr> ";
        string s_2 = "  <tr>  <td><span style=\"color: #ff0000\">離職人數</span>：" + _2.ToString() + "人</td> </tr> ";
        string s_3 = "   <tr> <td><span style=\"color: #ff6666\">留停人數</span>：" + _3.ToString() + "人</td> </tr> ";
        string s_4 = "   <tr> <td><span style=\"color: #009900\">復職人數</span>：" + _4.ToString() + "人</td> </tr> ";
        string s_5 = "  <tr>  <td><span style=\"color: #666600\">停職人數</span>：" + _5.ToString() + "人</td></tr>  ";
        string s_7 = "  <tr>  <td><span style=\"color: #666600\">試用期滿人數</span>：" + _7.ToString() + "人</td></tr>  ";


        string tts = "";
        if (_1 > 0)
            tts += s_1;
        if (_2 > 0)
            tts += s_2;
        if (_3 > 0)
            tts += s_3;
        if (_4 > 0)
            tts += s_4;
        if (_5 > 0)
            tts += s_5;
        if (_7 > 0)
            tts += s_7;

        string html = "";
        html = "<br><br><table width='100%' border='0' cellspacing='1' cellpadding='2' > " +
          
            tts +
           
            " </table> ";
        Label lb = new Label();
        lb.Text = html;
        e.Cell.Controls.Add(lb);
    }

    protected void Calendar1_VisibleMonthChanged(object sender, MonthChangedEventArgs e)
    {
        setData(DateTime.Parse(e.NewDate.Year.ToString() + "/" + e.NewDate.Month + "/1"),
               DateTime.Parse(e.NewDate.Year.ToString() + "/" + e.NewDate.Month + "/" + DateTime.DaysInMonth(e.NewDate.Year, e.NewDate.Month).ToString()));

    }

    protected void Calendar1_SelectionChanged(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 1;
        if (Session["bdt"] == null)
            setData(DateTime.Parse(Calendar1.SelectedDate.Year.ToString() + "/" + Calendar1.SelectedDate.Month + "/1"),
                DateTime.Parse(Calendar1.SelectedDate.Year.ToString() + "/" + Calendar1.SelectedDate.Month + "/" + DateTime.DaysInMonth(Calendar1.SelectedDate.Year, Calendar1.SelectedDate.Month).ToString()));
        HRDs.basettsDataTable basedt = (HRDs.basettsDataTable)Session["bdt"];
        HRDs.basettsRow[] baserows = (HRDs.basettsRow[])basedt.Select("adate='" + Calendar1.SelectedDate.ToShortDateString() + "'");

        HRDsTableAdapters.EmpInfoTableAdapter rv_base = new HRDsTableAdapters.EmpInfoTableAdapter();
        HRDs.EmpInfoDataTable rv_baseDs = new HRDs.EmpInfoDataTable();


        foreach (DataRow Row in baserows)
        {   
             HRDs.EmpInfoDataTable tempdt = rv_base.GetDataByNobr(Row["nobr"].ToString());
             if (tempdt.Rows.Count == 0)
                continue;

            string DESC ="";
            switch (Row["TTSCODE"].ToString().Trim())
            {
                case "1":
                    DESC = "新進";
                    break;
                case "2":
                    DESC = "離職";
                    break;
                case "3":
                    DESC = "留停";
                    break;
                case "4":
                    DESC = "復職";
                    break;
                case "5":
                    DESC = "停職";
                    break;
                case "7":
                    DESC = "試用期滿";
                    break;
            }
            tempdt[0].TTSDESC = DESC;
            tempdt[0].Adate = Calendar1.SelectedDate.ToShortDateString();
            rv_baseDs.Merge(tempdt);
        }
       
        baseGV.DataSource = rv_baseDs;
        baseGV.DataBind();

        Calendar1.SelectedDate = DateTime.Parse("2099/02/02");
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 0;
    }

    protected void LinkButton1_Click(object sender, EventArgs e) 
    {
        MultiView1.ActiveViewIndex = 1;
        LinkButton lb = (LinkButton)sender;

        if (Session["bdt"] == null)
            setData(DateTime.Parse(Calendar1.SelectedDate.Year.ToString() + "/" + Calendar1.SelectedDate.Month + "/1"),
                DateTime.Parse(Calendar1.SelectedDate.Year.ToString() + "/" + Calendar1.SelectedDate.Month + "/" + DateTime.DaysInMonth(Calendar1.SelectedDate.Year, Calendar1.SelectedDate.Month).ToString()));
        HRDs.basettsDataTable basedt = (HRDs.basettsDataTable)Session["bdt"];
        string _ttscode = "";
        switch (lb.Text) {
            case "新進":
                _ttscode = "1";
                break;
            case "離職":
                _ttscode = "2";
                break;
            case "留停":
                _ttscode = "3";
                break;
            case "復職":
                _ttscode = "4";
                break;
            case "停職":
                _ttscode = "5";
                break;
            case "試用期滿":
                _ttscode = "7";
                break;
        }

        HRDs.basettsRow[] baserows = (HRDs.basettsRow[])basedt.Select("ttscode='" + _ttscode + "'");

        HRDsTableAdapters.EmpInfoTableAdapter rv_base = new HRDsTableAdapters.EmpInfoTableAdapter();
        HRDs.EmpInfoDataTable rv_baseDs = new HRDs.EmpInfoDataTable();


        foreach (DataRow Row in baserows) {
            HRDs.EmpInfoDataTable tempdt = rv_base.GetDataByNobr(Row["nobr"].ToString());
            if (tempdt.Rows.Count == 0)
                continue;

            string DESC = "";
            switch (Row["TTSCODE"].ToString().Trim()) {
                case "1":
                    DESC = "新進";
                    break;
                case "2":
                    DESC = "離職";
                    break;
                case "3":
                    DESC = "留停";
                    break;
                case "4":
                    DESC = "復職";
                    break;
                case "5":
                    DESC = "停職";
                    break;
                case "7":
                    DESC = "試用期滿";
                    break;
            }
            tempdt[0].TTSDESC = DESC;
            tempdt[0].Adate = DateTime.Parse( Row["adate"].ToString()).ToShortDateString();
            rv_baseDs.Merge(tempdt);
        }

        baseGV.DataSource = rv_baseDs;
        baseGV.DataBind();

    }
}
