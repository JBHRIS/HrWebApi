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
using JB.HRIS.Organization;
using System.Collections.Generic;
using BL;
using JBHRModel;
using System.Linq;
public partial class Mang_EmpApplyFormSelect : JBWebPage {    
    protected void Page_Load(object sender, EventArgs e) {

        if (!IsPostBack) 
        {
            SiteHelper siteHelper = new SiteHelper();
            DateTime startDatetime, endDatetime;

            siteHelper.SetDateRange(out startDatetime, out endDatetime, DateTime.Now.Date, JbUser.SalaDr);
            adate.SelectedDate = startDatetime;
            ddate.SelectedDate = endDatetime;

            var a = ucEmpDeptQS as IEmpDeptQS;
            a.InitUC_Dept(EnumUC_QS_InitType.Manager);

            Session[SessionName] = null;
        }
    }

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e) 
    {
        GridView gv = (GridView)sender;
        lb_nobr.Text = gv.SelectedValue.ToString();
        GetData();
    }

    protected void Button1_Click(object sender, EventArgs e) 
    {
        GetData();
    }

    protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        if (Session[SessionName] != null)
        {
            GridView2.PageIndex = e.NewPageIndex;
            GridView2.DataSource = Session[SessionName];
            GridView2.DataBind();
        }
        else
        {
            JB.WebModules.Message.Show("網頁逾時，請重新查詢！");
        }
    }

    void GetData()
    {
        var a = ucEmpDeptQS as IEmpDeptQS;
        var obj = a.GetSelectedObj();

        if (obj == null)
        {
            Show("Select Unit or Team Member");
            return;
        }

        JbFlow.ServiceClient sc = new JbFlow.ServiceClient();
        //state 1 為在途、2為駁回、3核准

        var nobrList = new List<string>();
        var deptList = new List<string>();

        JbFlow.FlowAbsTable[] resultList = null;

        if (obj.SelectedType == EnumUC_QS_SelectedType.Emp)
        {
            nobrList.Add(obj.Key);
            resultList = sc.GetFlowAbs(adate.SelectedDate.Value, ddate.SelectedDate.Value, ddlCat.SelectedValue, null, nobrList.ToArray(), new string[] { "1", "2", "3" });
        }
        else if (obj.SelectedType == EnumUC_QS_SelectedType.Dept && !obj.IsSingleDept)
        {
            deptList.Add(obj.Key);
            resultList = sc.GetFlowAbs(adate.SelectedDate.Value, ddate.SelectedDate.Value, ddlCat.SelectedValue, obj.DeptList.ToArray(), null, new string[] { "1", "2", "3" });
        }

        //SiteHelper siteHelper = new SiteHelper();
        //resultList.RemoveAll(p => Juser.ManagerExeptEmpList.Contains(p.sNobr));

        Session[SessionName] = resultList.ToList();
        GridView2.DataSource = resultList.ToList();
        GridView2.DataBind();
    }


    protected void Button2_Click(object sender, EventArgs e)
    {
        if (Session[SessionName] != null)
            JB.WebModules.Data.Export.Excel.WebResponseExcel(this, GridView2, (List<JbFlow.FlowAbsTable>)Session[SessionName], this.GetType().ToString());
        else
            JB.WebModules.Message.Show("無資料可匯出！");
    }
    protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if(e.Row.Cells[14].Text.Equals("1"))
            {
                e.Row.Cells[14].Text = "Ongoing";
            }
            else if (e.Row.Cells[14].Text.Equals("2"))
            {
                e.Row.Cells[14].Text = "Rejected";
            }
            else if (e.Row.Cells[14].Text.Equals("3"))
            {
                e.Row.Cells[14].Text = "Approved";
            }

            string str = "vnd.ms-excel.numberformat:@";
            e.Row.Cells[5].Attributes.Add("style", str);
            e.Row.Cells[6].Attributes.Add("style", str);
        }
        //if (e.Row.RowType == DataControlRowType.DataRow)
        //{
        //    e.Row.Cells[5].Text = SiteHelper.ConvertStrTimeTo24(e.Row.Cells[5].Text);
        //    e.Row.Cells[6].Text = SiteHelper.ConvertStrTimeTo24(e.Row.Cells[6].Text);
        //}
    }
}
