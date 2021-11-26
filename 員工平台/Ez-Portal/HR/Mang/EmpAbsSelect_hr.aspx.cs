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
public partial class Mang_EmpAbsSelect_hr : JBWebPage {
    private DEPT_REPO dept_repo = new DEPT_REPO();
    protected void Page_Load(object sender, EventArgs e) {
        if (!IsPostBack) 
        {
            var a = ucEmpDeptQS as IEmpDeptQS;
            a.InitUC_Dept(EnumUC_QS_InitType.HR);

            Session[SessionName] = null;
            adate.SelectedDate = DateTime.Parse(DateTime.Now.Year.ToString() + "/" + DateTime.Now.Month + "/1");
            ddate.SelectedDate = DateTime.Parse(DateTime.Now.Year.ToString() + "/" + DateTime.Now.Month + "/" + DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month).ToString());
            bindDdlHcode();
        }
    }

    private void bindDdlHcode()
    {
        ListItem all = new ListItem();
        all.Selected = true;
        all.Text="全部";
        all.Value = "SelectedAll";
        ddlHcode.Items.Add(all);

        HCODE_REPO hcodeRepo = new HCODE_REPO();
        //List<HCODE> hcodeList = hcodeRepo.GetAll();
        //List<HCODE> hcode135List = (from c in hcodeList where c.YEAR_REST != "1" && c.YEAR_REST != "3" && c.YEAR_REST != "5" select c).ToList();

        List<HCODE> hcodeList2 = hcodeRepo.GetByCompany(Juser.ManageComp);
        List<HCODE> hcode135List = (from c in hcodeList2 where c.YEAR_REST != "1" && c.YEAR_REST != "3" && c.YEAR_REST != "5" select c).ToList();

        foreach (var h in hcode135List)
        {
            //排除顯示公出，因為公出寫在ABS1中，這個查不出來
            if (h.H_CODE.ToUpper().Equals("O"))
                continue;

            ListItem item = new ListItem();            
            item.Text = h.H_NAME;
            item.Value = h.H_CODE;
            ddlHcode.Items.Add(item);
        }
    }

    private void UC_SelectEmp(string nobr)
    {
        lb_nobr.Text = nobr;
        GetData();
    }

    //void setDept(TreeNode cnode, Department dept) {
    //    List<Department> depts = dept.GetChildDepartment();
    //    for (int i = 0; i < depts.Count; i++) {
    //        TreeNode treenode = new TreeNode();
    //        treenode.Text = depts[i].D_NAME;
    //        treenode.Value = depts[i].D_NO;
    //        cnode.ChildNodes.Add(treenode);
    //        setDept(treenode, depts[i]);
    //    }
    //}

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
            foreach(var d in obj.DeptList)
            {
                rv_absDs.Merge(rv_abs.GetDataBy_rv_abs1(adate.SelectedDate.Value, ddate.SelectedDate.Value, "", d));                
            }
        }


        if (!ddlHcode.SelectedValue.Equals("SelectedAll"))
        {
            HRDs.rv_abs3Row[] abs3Row = (HRDs.rv_abs3Row[])rv_absDs.Select("H_CODE<>'" + ddlHcode.SelectedValue + "'");            
            HRDs.rv_abs3DataTable temp_absDs = new HRDs.rv_abs3DataTable();

            foreach (var r in abs3Row)
            {
                rv_absDs.Rows.Remove(r);     
            }
        }

        //SiteHelper siteHelper = new SiteHelper();
        //rv_absDs = siteHelper.GetSelectedEmpData(rv_absDs, "NOBR", Juser.SalaDrNobrList) as HRDs.rv_abs3DataTable;


        Session[SessionName] = rv_absDs;
        GridView2.DataSource = rv_absDs;

        //Session[SessionName] = rv_absDs;
        //GridView2.DataSource = rv_absDs;
        GridView2.DataBind();
    }

    
    

}
