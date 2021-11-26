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
using System.Linq;

public partial class EmpAttendForgetCard : JBWebPage
{
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Session[SessionName] = null;

            SiteHelper siteHelper = new SiteHelper();
            DateTime startDatetime , endDatetime;

            siteHelper.SetDateRange(out startDatetime, out endDatetime, DateTime.Now.Date, JbUser.SalaDr);
            rdpBdate.SelectedDate = startDatetime;
            rdpEdate.SelectedDate = endDatetime;
        }
    }
    protected void TreeView1_SelectedNodeChanged(object sender, EventArgs e)
    {
        setDept(TreeView1.SelectedValue);
        if(IsPostBack)
            GetData();
    }


    private void setDept(string value)
    {
        lb_dept.Text = value;
        //IUC iuc = (IUC)CalendarAbsList1;
        //iuc.SetValue(value);
        //iuc.BindData();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        GetData();
    }
    protected void ExportExcel_Click(object sender, EventArgs e)
    {
        if (Session[SessionName] != null)
            JB.WebModules.Data.Export.Excel.WebResponseExcel(this, gv, (List<EmpAttendList>)Session[SessionName], SessionName);
        else
            JB.WebModules.Message.Show("無資料可匯出！");
    }

    void GetData()
    {
        ATTEND_REPO attendRepo = new ATTEND_REPO();
        List<EmpAttendList> list = new List<EmpAttendList>();

        list.AddRange(attendRepo.GetAttendListByDateRangeNobr(Juser.Nobr, rdpBdate.SelectedDate.Value, rdpEdate.SelectedDate.Value));

        Session[SessionName] = list.OrderByDescending(p=>p.AttendDate).ToList();
        gv.DataSource = Session[SessionName];
        gv.DataBind();

    }
    protected void gv_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        if (Session[SessionName] != null)
        {
            gv.PageIndex = e.NewPageIndex;
            gv.DataSource = (List<EmpAttendList>)Session[SessionName];
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
            bool b;
                //Convert.ToBoolean(e.Row.Cells[11].Text);

            if ( Convert.ToInt32(e.Row.Cells[10].Text) == 0 )
                e.Row.Cells[10].Text = "";

            if ( Convert.ToInt32(e.Row.Cells[11].Text) == 0 )
                e.Row.Cells[11].Text = "";

            if ( Convert.ToInt32(e.Row.Cells[13].Text) == 0 )
                e.Row.Cells[13].Text = "";

            b = Convert.ToBoolean(e.Row.Cells[12].Text);
            if (b)
                e.Row.Cells[12].Text = "Y";
            else
                e.Row.Cells[12].Text = "";

            //string str = "vnd.ms-excel.numberformat:@";
            //e.Row.Cells[2].Attributes.Add("style", str);
            //e.Row.Cells[6].Attributes.Add("style", str);
            //e.Row.Cells[7].Attributes.Add("style", str);
            //e.Row.Cells[8].Attributes.Add("style", str);

        }
    }
}
