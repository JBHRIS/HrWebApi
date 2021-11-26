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
public partial class Mang_EmpSelect :JBWebPage {
    private BASETTS_REPO basetts_repo = new BASETTS_REPO();



    protected void Page_Load(object sender, EventArgs e) {
        ucEmpDeptQS.sHandler += new Templet_EmpDeptQS.SelectedEventHandler(UC_SelectObj);
        if (!IsPostBack) 
        {
            var a = ucEmpDeptQS as IEmpDeptQS;
            a.InitUC_Dept(EnumUC_QS_InitType.Manager);
            a.InitUC_Cat(0,true);
            //SiteHelper sh = new SiteHelper();
            //sh.InitManagerDeptTreeView(TreeView1, Juser.ManageDeptRootNodeList);

            //if (TreeView1.Nodes.Count > 0)
            //{                
            //    TreeView1.Nodes[0].Select();
            //    TreeView1_SelectedNodeChanged(TreeView1.Nodes[0], null);
            //}
        }

    }

    //protected void TreeView1_SelectedNodeChanged(object sender, EventArgs e)
    //{
    //    lb_dept.Text = TreeView1.SelectedNode.Value;

    //    try
    //    {
    //        GridView1.DataBind();
    //        if(GridView1.Rows.Count>1)
    //            GridView1.SelectedIndex = 0;
    //        else
    //            GridView1.SelectedIndex = -1;

    //        loadData();
    //        //GridView1_SelectedIndexChanged(null, null);
    //        //GridView1.SelectedIndex = 0;

            
    //    }
    //    catch { }
    //}
    //protected void GridView1_SelectedIndexChanged(object sender, EventArgs e) {
    // //   Session["nobr"] = GridView1.SelectedValue;

    //    loadData();
    //}





    private void UC_SelectObj(UC_QS_SelectedObj obj)
    {


        var a = ucEmpDeptQS as IEmpDeptQS;
        var obj1 = a.GetSelectedObj();

        if (obj1 == null)
        {
            Show("Select Unit or Team Member");
            return;
        }

        loadData(obj1.Key);
    }



    //void loadData() 
    //{
    //    string selectedValue = "";

    //    if (!IsPostBack && GridView1.SelectedValue == null)
    //        selectedValue = JbUser.NOBR;        
    //    else if (GridView1.SelectedValue == null)
    //        selectedValue = "";           
    //    else
    //        selectedValue = GridView1.SelectedValue.ToString();


    //    loadData(selectedValue);
    //}


    void loadData(string selectedValue)
    {

        ((Label)EmpBase2.FindControl("lb_nobr")).Text = selectedValue;
        ((ICU)EmpBase2).bindGrid();
        ((Label)EmpFamilyInfo1.FindControl("lb_nobr")).Text = selectedValue;
        ((ICU)EmpFamilyInfo1).bindGrid();
        if (selectedValue.Equals(JbUser.NOBR))
        {
            EmpFamilyInfo1.Visible = true;
        }
        else
            EmpFamilyInfo1.Visible = false;

        ((Label)EmpInfoState1.FindControl("lb_nobr")).Text = selectedValue;
        ((ICU)EmpInfoState1).bindGrid();

        ((Label)EmployeeContact2.FindControl("lb_nobr")).Text = selectedValue;
        //((ICU)EmployeeContact2).bindGrid();

        ((Label)EmployeeContactPeople1.FindControl("lb_nobr")).Text = selectedValue;
        if (selectedValue.Equals(JbUser.NOBR))
        {
            EmployeeContactPeople1.Visible = true;
        }
        else
            EmployeeContactPeople1.Visible = false;
        //((ICU)EmployeeContactPeople1).bindGrid();
        ((Label)EmpTtsInfo1.FindControl("lb_nobr")).Text = selectedValue;
        //((ICU)EmpTtsInfo1).bindGrid();
        //IUC ucEmpSecretary = EmployeeSecretarySetting1 as IUC;
        //ucEmpSecretary.SetValue(selectedValue);
        //ucEmpSecretary.BindData();
        AbsList1.SetValue(selectedValue);
        AbsList1.BindData();
    }





    //protected void RBL_deptr_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //}
    //protected void RBL_deptr_TextChanged(object sender, EventArgs e) {

    //}
    //protected void GridView1_DataBound(object sender, EventArgs e)
    //{
        
      
 

    //}
    //protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
    //{
    //    if (CheckBox1.Checked)
    //    {
    //        GridView1.DataSourceID = "HR_Portal_EmpInfo_LeSqlDataSource1";
    //        GridView1.DataBind();
    //    }
    //    else
    //    {
    //        GridView1.DataSourceID = "HR_Portal_EmpInfoSqlDataSource";
    //        GridView1.DataBind();
    //    }
    //}
    //protected void btnEmpSearch_Click(object sender , EventArgs e)
    //{
    //    List<TreeNode> nodeList= SiteHelper.GetTreeViewAllNodes(TreeView1);

    //    List<BASETTS> ttsList = new List<BASETTS>();
        
    //    foreach ( var n in nodeList )
    //    {
    //        ttsList.AddRange(basetts_repo.GetByDeptSearchValue_Inc(tbEmpSearch.Text , n.Value));                        
    //    }
        
    //    //var dataList = from c in ttsList select new {NOBR = c.BASE.NOBR,NAME_C="["+c.BASE.NAME_AD+"]"+c.BASE.NAME_C};
    //    var dataList = from c in ttsList select new { NOBR = c.BASE.NOBR, NAME_C = c.BASE.NAME_C };

    //    GridView2.DataSource = dataList;
    //    GridView2.DataBind();

    //    if (dataList.Count() > 0)
    //    {
    //        GridView2.SelectedIndex = 0;
    //        GridView2_SelectedIndexChanged(this, null);
    //    }
    //}
    //protected void GridView2_SelectedIndexChanged(object sender , EventArgs e)
    //{
    //    loadData(GridView2.SelectedValue.ToString());
    //}
}
