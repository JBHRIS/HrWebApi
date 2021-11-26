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

public partial class HR_Mang_EmpAttendUnusual_hr : JBWebPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            
            Session[SessionName] = null;
            adate.SelectedDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            ddate.SelectedDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month));
        }

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        GetData();   
    }
    protected void ExportExcel_Click(object sender, EventArgs e)
    {
        if (Session[SessionName] != null)
            JB.WebModules.Data.Export.Excel.WebResponseExcel(this, gv, (AttendDs.AttendUnusualDataTable)Session[SessionName], SessionName);
        else
            JB.WebModules.Message.Show("無資料可匯出！");
    }

    void GetData()
    {
        AttendDsTableAdapters.AttendUnusualTableAdapter attU_adapter = new AttendDsTableAdapters.AttendUnusualTableAdapter();
        AttendDs.AttendUnusualDataTable attU_DT = new AttendDs.AttendUnusualDataTable();

        if (cbType.SelectedValue.Equals("0"))//遲到
        {
            attU_DT.Merge(attU_adapter.GetByLateMinsDateRangeMins(adate.SelectedDate.Value, ddate.SelectedDate.Value, Convert.ToDecimal(tbHrs.Text)));
        }
        else if (cbType.SelectedValue.Equals("1"))//早退
        {
            attU_DT.Merge(attU_adapter.GetByEMinsDateRangeMins(adate.SelectedDate.Value, ddate.SelectedDate.Value, Convert.ToDecimal(tbHrs.Text)));
        }
        else if (cbType.SelectedValue.Equals("2"))//曠職
        {
            attU_DT.Merge(attU_adapter.GetByAbsDateRange(adate.SelectedDate.Value, ddate.SelectedDate.Value));
        }
        else if (cbType.SelectedValue.Equals("3"))//全部
            attU_DT.Merge(attU_adapter.GetByDateRangeMins(adate.SelectedDate.Value, ddate.SelectedDate.Value, Convert.ToDecimal(tbHrs.Text)));

        SiteHelper siteHelper = new SiteHelper();
        attU_DT = siteHelper.GetSelectedEmpData(attU_DT, "NOBR", Juser.SalaDrNobrList) as AttendDs.AttendUnusualDataTable;

        Session[SessionName] = attU_DT;
        gv.DataSource = attU_DT;
        gv.DataBind(); 
        //HRDsTableAdapters.AttendRptTableAdapter attendRptAdapter = new HRDsTableAdapters.AttendRptTableAdapter();
        //if(tbHrs.Text.Trim().Length == 0 )
        //    tbHrs.Text = "1";
        //HRDs.AttendRptDataTable attendRptDT = attendRptAdapter.GetDataLateEarly(adate.SelectedDate.Value,ddate.SelectedDate.Value,(Convert.ToInt16(tbHrs.Text)));

        ////2011/06/27 海悅需求，不顯示00班的資料
        //if (cbExcludeRote00.Checked == true)
        //{
        //    HRDs.AttendRptRow[] rows = (HRDs.AttendRptRow[])attendRptDT.Select("ROTE='00'");

        //    foreach (var row in rows)
        //    {
        //        attendRptDT.Rows.Remove(row);
        //    }
        //}

        //Session[SessionName] = attendRptDT;
        //gv.DataSource = attendRptDT;
        //gv.DataBind(); 
    }

    protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        if (Session[SessionName] != null)
        {
            gv.PageIndex = e.NewPageIndex;
            gv.DataSource = (AttendDs.AttendUnusualDataTable)Session[SessionName];
            gv.DataBind();
        }
        else
        {
            JB.WebModules.Message.Show("網頁逾時，請重新查詢！");
        }
    }
    protected void gv_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            bool b = Convert.ToBoolean(e.Row.Cells[6].Text);
            if (b)
                e.Row.Cells[6].Text = "Y";
            else
                e.Row.Cells[6].Text = "N";
        }
    }
}
