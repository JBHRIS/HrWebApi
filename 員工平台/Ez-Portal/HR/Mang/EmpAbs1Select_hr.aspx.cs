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
using JBHRModel;
using System.Linq;

public partial class HR_Mang_EmpAbs1Select_hr : JBWebPage 
{

    //joe
    private DEPTA_REPO depta_repo = new DEPTA_REPO();
    private ABS1_REPO abs1Repo = new ABS1_REPO();
    protected void Page_Load(object sender, EventArgs e) {
        if (!IsPostBack) 
        {

            var a = ucEmpDeptQS as IEmpDeptQS;
            a.InitUC_Dept(EnumUC_QS_InitType.HR);

            Session[SessionName] = null;
            adate.SelectedDate = DateTime.Parse(DateTime.Now.Year.ToString() + "/" + DateTime.Now.Month + "/1");
            ddate.SelectedDate = DateTime.Parse(DateTime.Now.Year.ToString() + "/" + DateTime.Now.Month + "/" + DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month).ToString());
        }
    }

    private void UC_SelectEmp(string nobr)
    {
        lb_nobr.Text = nobr;
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

        HRDsTableAdapters.rv_abs3TableAdapter rv_abs = new HRDsTableAdapters.rv_abs3TableAdapter();
        HRDs.rv_abs3DataTable rv_absDs = new HRDs.rv_abs3DataTable();


        if (obj.SelectedType == EnumUC_QS_SelectedType.Emp)
        {
            rv_absDs.Merge(rv_abs.GetDataBy_rv_abs1(adate.SelectedDate.Value, ddate.SelectedDate.Value, obj.Key, ""));
        }
        else if (obj.SelectedType == EnumUC_QS_SelectedType.Dept && !obj.IsSingleDept)
        {
            foreach (var d in obj.DeptList)
            {
                rv_absDs.Merge(rv_abs.GetDataBy_rv_abs1(adate.SelectedDate.Value, ddate.SelectedDate.Value, "", d));
            }
        }




        //List<EmpAbs1List> list = new List<EmpAbs1List>();
        //if (obj.SelectedType == EnumUC_QS_SelectedType.Emp)
        //{          
        //    list =abs1Repo.GetByNobrDateRange_Dlo(lb_nobr.Text, adate.SelectedDate.Value, ddate.SelectedDate.Value);
        //}
        //else if (obj.SelectedType == EnumUC_QS_SelectedType.Dept && !obj.IsSingleDept)
        //{
        //    list = abs1Repo.GetByDeptDateRange_Dlo(lb_dept.Text, adate.SelectedDate.Value, ddate.SelectedDate.Value);            
        //}
        //else if (RBL_deptr.SelectedIndex == 2)
        //{
        //    List<TreeNode> nodeList = new List<TreeNode>();
        //    SiteHelper.GetChildNodes(TreeView1.SelectedNode,nodeList);            

        //    foreach(var n in nodeList)
        //    {
        //        list.AddRange(abs1Repo.GetByDeptDateRange_Dlo(n.Value, adate.SelectedDate.Value, ddate.SelectedDate.Value));
        //    }
        //}

        //list = list.FindAll(p => Juser.SalaDrNobrList.Contains(p.Nobr));

        Session[SessionName] = rv_absDs;
        GridView2.DataSource = rv_absDs;
        GridView2.DataBind();                
    }

    
    

}
