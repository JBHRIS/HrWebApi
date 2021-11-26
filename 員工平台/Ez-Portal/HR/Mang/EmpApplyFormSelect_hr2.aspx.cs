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
using Telerik.Web.UI;
public partial class EmpApplyFormSelect_hr2 : JBWebPage
{
    private DEPT_REPO dept_repo = new DEPT_REPO();
    protected void Page_Load(object sender, EventArgs e) {
        //SelectEmpHr1.sHandler += new Templet_SelectEmpHr.SelectEmpEventHandler(UC_SelectEmp);


        ucEmpDeptQS.sHandler += new Templet_EmpDeptQS.SelectedEventHandler(UC_SelectObj);
        if (!IsPostBack) 
        {
            //SiteHelper.SetAllDeptMenu(menuDept);
            var a = ucEmpDeptQS as IEmpDeptQS;
            a.InitUC_Dept(EnumUC_QS_InitType.HR);
            Session[SessionName] = null;
            adate.SelectedDate = DateTime.Parse(DateTime.Now.Year.ToString() + "/" + DateTime.Now.Month + "/1");
            ddate.SelectedDate = DateTime.Parse(DateTime.Now.Year.ToString() + "/" + DateTime.Now.Month + "/" + DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month).ToString());
        }
    }

    private void UC_SelectObj(UC_QS_SelectedObj obj)
    {
        GetData();
    }
    //private void UC_SelectEmp(string nobr)
    //{
    //    lb_nobr.Text = nobr;
    //    GetData();
    //}



    protected void Button1_Click(object sender, EventArgs e) 
    {
        GetData();
    }

    protected void RBL_deptr_SelectedIndexChanged(object sender, EventArgs e)
    {
        //DataTable rv_null = new DataTable();
        //GridView2.DataSource = rv_null;
        //GridView2.DataBind();
        //if (RBL_deptr.SelectedIndex == 0)
        //{
        //    empMenu.Visible = true;
        //   // GridView1.DataBind();
        //}
        //else
        //{
        //    empMenu.Visible = false;
        //}
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
        JbFlow.ServiceClient sc = new JbFlow.ServiceClient();
        //state 1 為在途、2為駁回、3核准

        var nobrList = new List<string>();
        var deptList = new List<string>();
        JbFlow.FlowAbsTable[] resultList = null;

        //if (RBL_deptr.SelectedIndex == 0)
        //{
        //    nobrList.Add(lb_nobr.Text);
        //    resultList = sc.GetFlowAbs(adate.SelectedDate.Value, ddate.SelectedDate.Value, ddlCat.SelectedValue, null, nobrList.ToArray(), new string[] { "1", "2", "3" });
        //}
        //else if (RBL_deptr.SelectedIndex == 1)
        //{
        //        deptList.Add(lb_dept.Text);
        //        resultList = sc.GetFlowAbs(adate.SelectedDate.Value, ddate.SelectedDate.Value, ddlCat.SelectedValue, deptList.ToArray(), null, new string[] { "1", "2", "3" });
        //}
        //else if (RBL_deptr.SelectedIndex == 2)
        //{
        //    //List<TreeNode> nodeList = SiteHelper.GetChildNodes(TreeView1.SelectedNode);

        //    //foreach (TreeNode n in nodeList)
        //    //{
        //    //        deptList.Add(n.Value);
        //    //}

        //    //resultList = sc.GetFlowAbs(adate.SelectedDate.Value, ddate.SelectedDate.Value, ddlCat.SelectedValue, deptList.ToArray(), null, new string[] { "1", "2", "3" });
        //}

//        SiteHelper siteHelper = new SiteHelper();
  //      flowAbsList = flowAbsList.FindAll(p => Juser.SalaDrNobrList.Contains(p.sNobr));
        var a = ucEmpDeptQS as IEmpDeptQS;
        var obj = a.GetSelectedObj();

        if (obj.SelectedType == EnumUC_QS_SelectedType.Emp)
        {
            nobrList.Add(obj.Key);
            resultList = sc.GetFlowAbs(adate.SelectedDate.Value, ddate.SelectedDate.Value, ddlCat.SelectedValue, null, nobrList.ToArray(), new string[] { "1", "2", "3" });
        }
        else if (obj.SelectedType == EnumUC_QS_SelectedType.Dept && !obj.IsSingleDept) {
            foreach (var item in obj.DeptList)
            {
                deptList.Add(item);
            }
            resultList = sc.GetFlowAbs(adate.SelectedDate.Value, ddate.SelectedDate.Value, ddlCat.SelectedValue, deptList.ToArray(), null, new string[] { "1", "2", "3" });
        }
        if (obj == null)
        {
            Show("Select Unit or Team Member");
            return;
        }

        Session[SessionName] = resultList.ToList();
        GridView2.DataSource = resultList.ToList();
        GridView2.DataBind();
    }

    protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (e.Row.Cells[14].Text.Equals("1"))
            {
                e.Row.Cells[14].Text = "在途";
            }
            else if (e.Row.Cells[14].Text.Equals("2"))
            {
                e.Row.Cells[14].Text = "駁回";
            }
            else if (e.Row.Cells[14].Text.Equals("3"))
            {
                e.Row.Cells[14].Text = "核准";
            }

            string str = "vnd.ms-excel.numberformat:@";
            e.Row.Cells[5].Attributes.Add("style", str);
            e.Row.Cells[6].Attributes.Add("style", str);
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        if (Session[SessionName] != null)
            JB.WebModules.Data.Export.Excel.WebResponseExcel(this, GridView2, (List<JbFlow.FlowAbsTable>)Session[SessionName], this.GetType().ToString());
        else
            JB.WebModules.Message.Show("no data");
    }

 
}
