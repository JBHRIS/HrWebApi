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
using JB.WebModules.Authentication;
using BL;
using System.Linq;
public partial class Templet_BirthdayControl : JBUserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {            
            string dept = JbUser.DepartmentCode;
            lb_dept.Text = dept;
            GetData();
        }
    }

    
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        GetData();
        //GridView2.DataSource = (DataView)Session["rv_tratt"];
        //GridView2.DataBind();
    }

    void GetData()
    {
        //List<Department> depts = new DeptCs().getDeptChild(lb_dept.Text);
        //HRDsTableAdapters.rv_birthTableAdapter rv_birth = new HRDsTableAdapters.rv_birthTableAdapter();
        //HRDs.rv_birthDataTable rv_birthDs = new HRDs.rv_birthDataTable();
      //  for (int i = 0; i < depts.Count; i++)
      //  {
       //     rv_birthDs.Merge(rv_birth.GetData_rv_birth(depts[i].D_NO));
        
        

        //JBPrincipal user = new JBPrincipal(Context.User.Identity.Name);
        
        //if (Page.User.IsInRole("manage"))
        //{
        //    TreeView tv = new TreeView();
        //    SiteHelper.SetDeptTreeByDeptDeptSupervisor(tv,Context.User.Identity.Name);
        //    List<TreeNode> nodeList= SiteHelper.GetTreeViewAllNodes(tv);
        //    foreach (var n in nodeList)
        //        rv_birthDs.Merge(rv_birth.GetData_rv_birth(n.Value));
        //}
        //else
        //    rv_birthDs.Merge(rv_birth.GetData_rv_birth(lb_dept.Text));           
            //rv_birthDs.Merge(rv_birth.GetDataByNotDept());
       // }
        //Session["rv_birth"] = rv_birthDs;

        //DateTime dateB = DateTime.Now.Date;
        //DateTime dateE = dateB.AddDays(7);
        DateTime dateB = new DateTime(DateTime.Now.Year,DateTime.Now.Month,1);
        DateTime dateE = new DateTime(DateTime.Now.Year , DateTime.Now.Month , DateTime.DaysInMonth(dateB.Year,dateB.Month));

        BASE_REPO baseRepo = new BASE_REPO();
        List<BASE> baseList = baseRepo.GetByBirthDayDateRange_DLO(dateB, dateE,JbUser.Comp);

        GridView1.DataSource = (from c in baseList orderby c.BIRDT.Value.Month.ToString().PadLeft(2, '0') + c.BIRDT.Value.Day.ToString().PadLeft(2, '0') select new { c.BIRDT, D_NAME = c.BASETTS[0].DEPT1.D_NAME, c.NAME_C, c.NOBR }).ToList();
        GridView1.DataBind();
    }
}
