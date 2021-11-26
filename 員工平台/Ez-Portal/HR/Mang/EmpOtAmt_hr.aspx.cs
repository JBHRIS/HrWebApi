using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL;

public partial class HR_Mang_EmpOtAmt_hr : JBWebPage
{
    private OT_REPO otRepo = new OT_REPO();

    protected void Button1_Click(object sender, EventArgs e)
    {
        GetData();
    }

    protected void ExportExcel_Click(object sender, EventArgs e)
    {
        if (Session[SessionName] != null)
            JB.WebModules.Data.Export.Excel.WebResponseExcel(this, gv, (List<OT46AMT>)Session[SessionName], SessionName);
        else
            JB.WebModules.Message.Show("無資料可匯出！");
    }

    protected void ExportSummuryExcel_Click(object sender, EventArgs e)
    {
        Response.ClearContent();
        string excelFileName = "OtSummury.xls";
        Response.AddHeader("content-disposition", "attachment;filename=" + Server.UrlEncode(excelFileName));
        Response.ContentType = "application/excel";
        System.IO.StringWriter stringWrite = new System.IO.StringWriter();
        System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
        gvSummury.RenderControl(htmlWrite);
        //GridView4.RenderControl(htmlWrite);

        Response.Write(stringWrite.ToString());
        Response.End();
    }

    protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        if (ViewState["sortDirection"] == null)
            ViewState["sortDirection"] = "Desc";

        if (ViewState["sortKey"] == null)
            ViewState["sortKey"] = "OtPercent";

        if (Session[SessionName] != null)
        {
            DataView dataview = new DataView(EntityToDataTable.Entity2DataTable<OT46AMT>((List<OT46AMT>)Session[SessionName]));
            dataview.Sort = ViewState["sortKey"] + " " + ViewState["sortDirection"].ToString();
            gv.PageIndex = e.NewPageIndex;
            gv.DataSource = dataview;
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
            //假日加班比
            double value = 0;
            if (e.Row.Cells[7].Text.Contains("%"))
            {
                Double.TryParse(e.Row.Cells[7].Text.Trim('%'), out value);
                if (value > 50)
                    e.Row.Cells[7].ForeColor = System.Drawing.Color.Red;
            }

            //平日加班比
            value = 0;
            if (e.Row.Cells[5].Text.Contains("%"))
            {
                Double.TryParse(e.Row.Cells[5].Text.Trim('%'), out value);
                if (value > 100)
                    e.Row.Cells[5].ForeColor = System.Drawing.Color.Red;
            }
        }
    }

    protected void gv_Sorting(object sender, GridViewSortEventArgs e)
    {
        if (ViewState["sortDirection"] == null)
        {
            ViewState["sortDirection"] = "Desc";
        }

        if (ViewState["sortKey"] != null)
        {
            if (ViewState["sortKey"].ToString().Equals(e.SortExpression.ToString()))
            {
                if (ViewState["sortDirection"].ToString().Equals("Asc"))
                    ViewState["sortDirection"] = "Desc";
                else
                    ViewState["sortDirection"] = "Asc";
            }
            else
            {
                ViewState["sortDirection"] = "Desc";
            }

            ViewState["sortKey"] = e.SortExpression;
        }
        else
        {
            ViewState["sortKey"] = e.SortExpression;
        }

        if (Session[SessionName] != null)
        {
            DataView dataview = new DataView(EntityToDataTable.Entity2DataTable<OT46AMT>((List<OT46AMT>)Session[SessionName]));
            dataview.Sort = e.SortExpression + " " + ViewState["sortDirection"].ToString();
            gv.DataSource = dataview;
            gv.DataBind();
        }
        else
        {
            JB.WebModules.Message.Show("網頁逾時，請重新查詢！");
        }
    }

    protected void gvSummury_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            List<OT46Summury> dt = (List<OT46Summury>)Session[SessionName2];
            if (dt.Count > 0)
            {
                OT46Summury row = dt[0];
                e.Row.Cells[0].Text = "區間人數(平)= " + row.AllEmpOtQty.ToString();
                e.Row.Cells[1].Text = "區間時數(平)= " + row.AllEmpOtTimeAmt.ToString();
                e.Row.Cells[2].Text = "區間人數(假)= " + row.AllEmpHOtQty.ToString();
                e.Row.Cells[3].Text = "區間時數(假)= " + row.AllEmpHOtTimeAmt.ToString();
                e.Row.Cells[4].Text = "區間人數(平假)= " + row.AllEmpOtAndHOtQty.ToString();
                e.Row.Cells[5].Text = "區間時數(平假)= " + row.AllEmpOtAndHOtTimeAmt.ToString();

                e.Row.Cells[0].BackColor = System.Drawing.Color.LightSalmon;
                e.Row.Cells[1].BackColor = System.Drawing.Color.LightSalmon;
                e.Row.Cells[2].BackColor = System.Drawing.Color.LightCyan;
                e.Row.Cells[3].BackColor = System.Drawing.Color.LightCyan;
                e.Row.Cells[4].BackColor = System.Drawing.Color.HotPink;
                e.Row.Cells[5].BackColor = System.Drawing.Color.HotPink;
            }
        }
        else if (e.Row.RowType == DataControlRowType.DataRow)
        {
            double value = 0;
            if (e.Row.Cells[6].Text.Contains("%"))
            {
                Double.TryParse(e.Row.Cells[6].Text.Trim('%'), out value);
                if (value > 50)
                    e.Row.Cells[6].ForeColor = System.Drawing.Color.Red;
            }
        }
    }

    protected void gvSummury_Sorting(object sender, GridViewSortEventArgs e)
    {
        if (ViewState["SummurySortDirection"] == null)
        {
            ViewState["SummurySortDirection"] = "Desc";
        }

        if (ViewState["SummurysortKey"] != null)
        {
            if (ViewState["SummurysortKey"].ToString().Equals(e.SortExpression.ToString()))
            {
                if (ViewState["SummurySortDirection"].ToString().Equals("Asc"))
                    ViewState["SummurySortDirection"] = "Desc";
                else
                    ViewState["SummurySortDirection"] = "Asc";
            }
            else
            {
                ViewState["SummurySortDirection"] = "Desc";
            }

            ViewState["SummurysortKey"] = e.SortExpression;
        }
        else
        {
            ViewState["SummurysortKey"] = e.SortExpression;
        }

        if (Session[SessionName2] != null)
        {
            DataView dataview = new DataView(EntityToDataTable.Entity2DataTable<OT46Summury>((List<OT46Summury>)Session[SessionName2]));
            dataview.Sort = e.SortExpression + " " + ViewState["SummurySortDirection"].ToString();
            gvSummury.DataSource = dataview;
            gvSummury.DataBind();
        }
        else
        {
            JB.WebModules.Message.Show("網頁逾時，請重新查詢！");
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // string dept = "ZZ";// JbUser.DepartmentCode;
            Session[SessionName] = null;
            adate.SelectedDate = DateTime.Parse(DateTime.Now.Year.ToString() + "/" + DateTime.Now.Month.ToString() + "/1");
            ddate.SelectedDate = DateTime.Parse(DateTime.Now.Year.ToString() + "/" + DateTime.Now.Month.ToString() + "/" + DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month));
        }
    }
    private void GetData()
    {
        double dbl = 0;
        Double.TryParse(tbTimeSpan.Text, out dbl);

        List<OT46AMT> dt = otRepo.GetOt46ViewByDateRange(adate.SelectedDate.Value, ddate.SelectedDate.Value, dbl);

        dt = dt.FindAll(p => Juser.SalaDrNobrList.Contains(p.Nobr));

        List<OT46Summury> sdt = otRepo.GetOt46ViewSummuryByDateRange(dt);
        Session[SessionName2] = sdt;
        Session[SessionName] = dt;
        gv.DataSource = dt;
        gv.DataBind();
        gvSummury.DataSource = sdt;
        gvSummury.DataBind();
    }
}