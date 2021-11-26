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
using BL;
using JBHRModel;
 
using System.Collections.Generic;
public partial class Mang_EmpOtSummurySelect : JBWebPage
{
    private OT_REPO otRepo = new OT_REPO();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            var a = ucEmpDeptQS as IEmpDeptQS;
            a.InitUC_Dept(EnumUC_QS_InitType.Manager);
            a.InitUC_Cat(1);
            Session[SessionName] = null;


            rdpBdate.Culture = System.Threading.Thread.CurrentThread.CurrentCulture;
            rdpEdate.Culture = System.Threading.Thread.CurrentThread.CurrentCulture;

            SiteHelper siteHelper = new SiteHelper();
            DateTime startDatetime , endDatetime;

            siteHelper.SetDateRange(out startDatetime , out endDatetime , DateTime.Now.Date , JbUser.SalaDr);
            rdpBdate.SelectedDate = startDatetime;
            rdpEdate.SelectedDate = endDatetime;
        }
    }


    //private void setDept(string value)
    //{
    //    lb_dept.Text = value;
    //    //IUC iuc = (IUC)CalendarAbsList1;
    //    //iuc.SetValue(value);
    //    //iuc.BindData();
    //}
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

    void GetData()
    {
        double dbl = 0;
        Double.TryParse(tbTimeSpan.Text, out dbl);

        List<OT46AMT> dt = new List<OT46AMT>();

        var a = ucEmpDeptQS as IEmpDeptQS;
        var obj = a.GetSelectedObj();

        if (obj == null)
        {
            Show("Select Unit or Team Member");
            return;
        }

        if (obj.SelectedType == EnumUC_QS_SelectedType.Dept && !obj.IsSingleDept) {

            foreach (var node in obj.DeptList) {
                dt.AddRange(otRepo.GetOt46ViewByDateRangeDept(rdpBdate.SelectedDate.Value, rdpEdate.SelectedDate.Value, node));
            }
        }

        //if (cbChildDept.Checked)
        //{
        //    List<TreeNode> nodeList = SiteHelper.GetChildNodes(TreeView1.SelectedNode);
        //    foreach (TreeNode node in nodeList)
        //        dt.AddRange(otRepo.GetOt46ViewByDateRangeDept(rdpBdate.SelectedDate.Value, rdpEdate.SelectedDate.Value, node.Value));
        //}      
        //else
        //    dt.AddRange(otRepo.GetOt46ViewByDateRangeDept(rdpBdate.SelectedDate.Value, rdpEdate.SelectedDate.Value, lb_dept.Text));


        //排除主管不可看部分
        //dt.RemoveAll(p => Juser.ManagerExeptEmpList.Contains(p.Nobr));

        List<OT46Summury> sdt = otRepo.GetOt46ViewSummuryByDateRange(dt);

        Session[SessionName] = dt;
        Session[SessionName2] = sdt;

        gv.DataSource = dt;
        gv.DataBind();
        gvSummury.DataSource = sdt;
        gvSummury.DataBind();

    }
    protected void gv_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        if (Session[SessionName] != null)
        {
            gv.PageIndex = e.NewPageIndex;
            gv.DataSource = (List<OT46AMT>)Session[SessionName];
            gv.DataBind();
        }
        else
        {
            JB.WebModules.Message.Show("網頁逾時，請重新查詢！");
        }
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
            //gv.PageIndex = e.NewPageIndex;
            //gv.DataSource = (OT_Ds.OT46AMTDataTable)Session[SESSION_TABLE];
            //gv.DataBind();
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
            //OT_Ds.OT46SummuryDataTable dt = (OT_Ds.OT46SummuryDataTable)gvSummury.DataSource;
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
            if (e.Row.Cells[7].Text.Contains("%"))
            {
                Double.TryParse(e.Row.Cells[7].Text.Trim('%'), out value);
                if (value > 50)
                    e.Row.Cells[7].ForeColor = System.Drawing.Color.Red;
            }
        }
    }
    protected void ExportSummuryExcel_Click(object sender, EventArgs e)
    {
        Response.ClearContent();
        string excelFileName = "OtSummuryByDept.xls";
        Response.AddHeader("content-disposition", "attachment;filename=" + Server.UrlEncode(excelFileName));
        Response.ContentType = "application/excel";
        System.IO.StringWriter stringWrite = new System.IO.StringWriter();
        System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
        gvSummury.RenderControl(htmlWrite);
        //GridView4.RenderControl(htmlWrite);

        Response.Write(stringWrite.ToString());
        Response.End();
    }
    protected void gv_RowDataBound(object sender , GridViewRowEventArgs e)
    {
        if ( e.Row.RowType == DataControlRowType.DataRow )
        {
            //假日加班比
            double value = 0;
            if ( e.Row.Cells[7].Text.Contains("%") )
            {
                Double.TryParse(e.Row.Cells[7].Text.Trim('%') , out value);
                if ( value > 50 )
                    e.Row.Cells[7].ForeColor = System.Drawing.Color.Red;
            }

            //平日加班比
            value = 0;
            if ( e.Row.Cells[5].Text.Contains("%") )
            {
                Double.TryParse(e.Row.Cells[5].Text.Trim('%') , out value);
                if ( value > 100 )
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
}
