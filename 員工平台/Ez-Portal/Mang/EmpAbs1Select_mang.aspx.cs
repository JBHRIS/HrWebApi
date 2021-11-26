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

public partial class Mang_EmpAbs1Select_mang : JBWebPage 
{
    private DEPTA_REPO depta_repo = new DEPTA_REPO();
    private ABS1_REPO abs1Repo = new ABS1_REPO();
    
    protected void Page_Load(object sender, EventArgs e) {
        ucEmpDeptQS.sHandler += new Templet_EmpDeptQS.SelectedEventHandler(UC_SelectObj);
        //SelectEmp1.sHandler += new Templet_SelectEmp.SelectEmpEventHandler(UC_SelectEmp);
        if (!IsPostBack) 
        {
            var a = ucEmpDeptQS as IEmpDeptQS;
            a.InitUC_Dept(EnumUC_QS_InitType.Manager);

            //SiteHelper siteHelper = new SiteHelper();
            //DateTime startDatetime , endDatetime;
            //siteHelper.SetDateRange(out startDatetime , out endDatetime , DateTime.Now.Date , JbUser.SalaDr);
            //adate.SelectedDate = startDatetime;
            //ddate.SelectedDate = endDatetime;

            Session[SessionName] = null;

            //SiteHelper sh = new SiteHelper();sh.InitManagerDeptTreeView(TreeView1, Juser.ManageDeptRootNodeList);            
            //if (TreeView1.Nodes.Count > 0)
            //{
            //    TreeView1.Nodes[0].Select();
            //    TreeView1_SelectedNodeChanged(TreeView1.Nodes[0], null);
            //}
        }
    }


	private void UC_SelectObj(UC_QS_SelectedObj obj)
    	{
            GetData();
    	}


    //private void UC_SelectEmp(string nobr)
    //{
    //    //lb_nobr.Text = nobr;
    //    GetData();
    //}


    //protected void TreeView1_SelectedNodeChanged(object sender, EventArgs e) 
    //{
    //    lb_dept.Text = TreeView1.SelectedNode.Value;
    //    lb_nobr.Text = "";
    //    (SelectEmp1 as IUC).SetValue(lb_dept.Text);
    //    (SelectEmp1 as IUC).BindData();
    //    //GetData();
    //}


    protected void Button1_Click(object sender, EventArgs e) 
    {
        GetData();
    }

    //protected void RBL_deptr_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    DataTable rv_null = new DataTable();
    //    GridView2.DataSource = rv_null;
    //    GridView2.DataBind();
    //    if (RBL_deptr.SelectedIndex == 0)
    //    {
    //        empMenu.Visible = true;
    //       // GridView1.DataBind();
    //    }
    //    else
    //    {
    //        empMenu.Visible = false;
    //    }
    //}

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

        List<EmpAbs1List> list = new List<EmpAbs1List>();

        if (obj.SelectedType == EnumUC_QS_SelectedType.Emp)
        {
            list = abs1Repo.GetByNobrDateRange_Dlo(obj.Key, adate.SelectedDate.Value, ddate.SelectedDate.Value);
        }
        else if (obj.SelectedType == EnumUC_QS_SelectedType.Dept && !obj.IsSingleDept)
        {
            foreach (var d in obj.DeptList)
            {
                list.AddRange(abs1Repo.GetByDeptDateRange_Dlo(d, adate.SelectedDate.Value, ddate.SelectedDate.Value));
            }
        }

        //if (RBL_deptr.SelectedIndex == 0)
        //{          
        //    list =abs1Repo.GetByNobrDateRange_Dlo(lb_nobr.Text, adate.SelectedDate.Value, ddate.SelectedDate.Value);
        //}
        //else if (RBL_deptr.SelectedIndex == 1)
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

        //list.RemoveAll(p => Juser.ManagerExeptEmpList.Contains(p.Nobr));

        Session[SessionName] = list;
        GridView2.DataSource = list;
        GridView2.DataBind();                
    }

    
    

}
