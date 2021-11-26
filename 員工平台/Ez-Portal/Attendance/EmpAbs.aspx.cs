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

public partial class Employee_EmpAbs : JBWebPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            lb_nobr.Text = JbUser.NOBR;            
            Session[SessionName] = null;

            DateTime startDatetime, endDatetime;
            SiteHelper siteHelper = new SiteHelper();
            siteHelper.SetDateRangeForThisYear(out startDatetime, out endDatetime);

            adate.SelectedDate = startDatetime;
            ddate.SelectedDate = endDatetime;
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        GetData();
    }
    protected void ExportExcel_Click(object sender, EventArgs e)
    {
        if (Session[SessionName] != null)
            JB.WebModules.Data.Export.Excel.WebResponseExcel(this, GridView2, (DataTable)Session[SessionName], "EmpAbs");
        else
            JB.WebModules.Message.Show("無資料可匯出！");
    }
    protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        if (Session[SessionName] != null)
        {
            GridView2.PageIndex = e.NewPageIndex;
            GridView2.DataSource = (DataTable)Session[SessionName];
            GridView2.DataBind();
        }
        else
        {
            JB.WebModules.Message.Show("網頁逾時，請重新查詢！");
        }
    }

    void GetData()
    {
        HRDsTableAdapters.rv_absTableAdapter rv_abs = new HRDsTableAdapters.rv_absTableAdapter();
        HRDs.rv_absDataTable rv_absDs = new HRDs.rv_absDataTable();
        rv_absDs.Merge(rv_abs.GetData_rv_abs(adate.SelectedDate.Value, ddate.SelectedDate.Value, lb_nobr.Text, ""));

        DataTable rv_absb = new DataTable();
        rv_absb.Columns.Add("nobr", typeof(string));
        rv_absb.Columns.Add("name_c", typeof(string));
        rv_absb.Columns.Add("bdate", typeof(DateTime));
        rv_absb.Columns.Add("edate", typeof(string));
        rv_absb.Columns.Add("h_code1", typeof(string));
        rv_absb.Columns.Add("h_name1", typeof(string));
        rv_absb.Columns.Add("tol_hrs1", typeof(decimal));
        rv_absb.Columns.Add("h_code2", typeof(string));
        rv_absb.Columns.Add("h_name2", typeof(string));
        rv_absb.Columns.Add("tol_hrs2", typeof(decimal));
        rv_absb.Columns.Add("tolhrs", typeof(decimal));
        rv_absb.Columns.Add("note", typeof(string));
        string str_nobr1 = "";
        decimal tolhrs = 0;
        foreach (DataRow Row in rv_absDs.Rows)
        {
            string str_nobr = Row["nobr"].ToString();
            DataRow aRow = rv_absb.NewRow();
            aRow["nobr"] = Row["nobr"].ToString();
            aRow["name_c"] = Row["name_c"].ToString();
            aRow["bdate"] = DateTime.Parse(Row["bdate"].ToString());
            aRow["edate"] = DateTime.Parse(Row["edate"].ToString());
            aRow["tol_hrs1"] = 0;
            aRow["tol_hrs2"] = 0;
            aRow["note"] = Row["NOTE"].ToString();
            if (Row["year_rest"].ToString().Trim() == "3")
            {
                aRow["h_code1"] = Row["h_code"].ToString();
                //aRow["h_name1"] = Row["h_code"].ToString().Trim()+Row["h_name"].ToString();
                aRow["h_name1"] = Row["h_name"].ToString();
                aRow["tol_hrs1"] = decimal.Parse(Row["tol_hours"].ToString());
                aRow["edate"]=DateTime.Parse(Row["edate"].ToString()).AddDays(1).ToString("yyyy/MM/dd");
                tolhrs += decimal.Parse(Row["tol_hours"].ToString());
                if (str_nobr == str_nobr1)
                    aRow["tolhrs"] = tolhrs;
                else
                    aRow["tolhrs"] = decimal.Parse(Row["tol_hours"].ToString());
            }
            if (Row["year_rest"].ToString().Trim() == "4")
            {
                aRow["h_code2"] = Row["h_code"].ToString();
                //aRow["h_name2"] = Row["h_code"].ToString().Trim()+Row["h_name"].ToString();
                aRow["h_name2"] = Row["h_name"].ToString();
                aRow["tol_hrs2"] = decimal.Parse(Row["tol_hours"].ToString());
                aRow["edate"] = "";
                tolhrs -= decimal.Parse(Row["tol_hours"].ToString());
                if (str_nobr == str_nobr1)
                    aRow["tolhrs"] = tolhrs;
                else
                    aRow["tolhrs"] = decimal.Parse(Row["tol_hours"].ToString()) * (-1);
            }
            str_nobr1 = str_nobr;

            rv_absb.Rows.Add(aRow);
        }

        rv_absb.DefaultView.Sort = "bdate desc";
        Session[SessionName] = rv_absb;
        GridView2.DataSource = Session[SessionName];
        GridView2.DataBind();
    }
}
