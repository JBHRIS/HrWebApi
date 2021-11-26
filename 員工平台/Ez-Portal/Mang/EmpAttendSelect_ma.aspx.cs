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
using System.Collections.Generic;

public partial class Mang_EmpAttendSelect_ma : JBWebPage {

    
    private HRDsTableAdapters.DEPTTableAdapter deptAdapter = new HRDsTableAdapters.DEPTTableAdapter();
    protected void Page_Load(object sender, EventArgs e) {
        if (!IsPostBack) 
        {
            //string dept = ""; ;
            //TreeNode treenode = new TreeNode();
            //DEPT_REPO deptRepo = new DEPT_REPO();
            //DEPT deptObj = deptRepo.GetByID(dept);
            //treenode.Text = deptObj.D_NAME;
            //treenode.Value = deptObj.D_NO;

            //TreeView1.Nodes.Add(SiteHelper.GetDeptTreeNode(treenode));
            //HRDs.DEPTDataTable deptDT = deptAdapter.GetDataByNobr(JbUser.NOBR);
            //foreach (HRDs.DEPTRow row in deptDT.Rows)
            //{
            //    TreeNode node = new TreeNode(row.D_NAME, row.D_NO);
            //    TreeView1.Nodes.Add(SiteHelper.GetDeptTreeNode(node));
            //}

            //lb_dept.Text = dept;
            var a = ucEmpDeptQS as IEmpDeptQS;
            a.InitUC_Dept(EnumUC_QS_InitType.Manager);

            Session[SessionName] = null;
            adate.SelectedDate = DateTime.Parse(DateTime.Now.Year.ToString() + "/" + DateTime.Now.Month + "/1");
            ddate.SelectedDate = DateTime.Parse(DateTime.Now.Year.ToString() + "/" + DateTime.Now.Month + "/" + DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month).ToString());
            //try
            //{
            //    GridView1.DataBind();
            //    GridView1.SelectedIndex = 0;
            //    lb_nobr.Text = GridView1.SelectedValue.ToString();
            //}
            //catch { }
            //GetData();
        }
    }


    //protected void TreeView1_SelectedNodeChanged(object sender, EventArgs e)
    //{
    //    lb_dept.Text = TreeView1.SelectedNode.Value;
    //    try
    //    {
    //        GridView1.DataBind();
    //        GridView1.SelectedIndex = 0;
    //        lb_nobr.Text = GridView1.SelectedValue.ToString();
    //    }
    //    catch { };
    //    GetData();
    //}
    //protected void GridView1_SelectedIndexChanged(object sender, EventArgs e) 
    //{
    //    GridView gv = (GridView)sender;
    //    lb_nobr.Text = gv.SelectedValue.ToString();
    //    GetData();
    //}
    protected void Button1_Click(object sender, EventArgs e) 
    {
        GetData();
    }
    //protected void GridView1_DataBound(object sender, EventArgs e)
    //{
    //    if (GridView1.Rows.Count > 0)
    //    {
    //        GridView1.SelectedIndex = 0;
    //        lb_nobr.Text = GridView1.SelectedValue.ToString();
    //    }
    //}
    //protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
    //{
    //    if (Session[SessionName] != null)
    //    {
    //        GridView2.PageIndex = e.NewPageIndex;
    //        GridView2.DataSource = Session[SessionName];
    //        GridView2.DataBind();
    //    }
    //    else
    //    {
    //        JB.WebModules.Message.Show("網頁逾時，請重新查詢！");
    //    }
    //}

    //protected void RBL_deptr_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    DataTable rv_null = new DataTable();
    //    GridView2.DataSource = rv_null;
    //    GridView2.DataBind();
    //    if (RBL_deptr.SelectedIndex == 0)
    //    {
    //        empMenu.Visible = true;
    //        GridView1.DataBind();
    //    }
    //    else
    //    {
    //        empMenu.Visible = false;            
    //    }
        
    //}

    void GetData()
    {
        HRDsTableAdapters.rv_attendTableAdapter rv_attend = new HRDsTableAdapters.rv_attendTableAdapter();
        HRDs.rv_attendDataTable rv_attendDs = new HRDs.rv_attendDataTable();
        HRDsTableAdapters.rv_cardTableAdapter rv_card = new HRDsTableAdapters.rv_cardTableAdapter();
        HRDs.rv_cardDataTable rv_cardDs = new HRDs.rv_cardDataTable();
        //if (RBL_deptr.SelectedIndex == 0)
        //{
        //    rv_attendDs.Merge(rv_attend.GetData_rv_attend(adate.SelectedDate.Value, ddate.SelectedDate.Value, lb_nobr.Text, ""));
        //    rv_cardDs.Merge(rv_card.GetData_rv_card(adate.SelectedDate.Value, ddate.SelectedDate.Value, lb_nobr.Text, ""));
        //}
        //else if (RBL_deptr.SelectedIndex == 1)
        //{
        //    rv_attendDs.Merge(rv_attend.GetData_rv_attend(adate.SelectedDate.Value, ddate.SelectedDate.Value,"", lb_dept.Text));
        //}
        //else if (RBL_deptr.SelectedIndex == 2)
        //{
        //    List<TreeNode> nodeList = SiteHelper.GetChildNodes(TreeView1.SelectedNode);

        //    foreach (var d in nodeList)
        //    {
        //        rv_attendDs.Merge(rv_attend.GetData_rv_attend(adate.SelectedDate.Value, ddate.SelectedDate.Value, "", d.Value));                
        //    }
        //}
        //else
        //{
        //    GridView1.DataBind();
        //}
        var a = ucEmpDeptQS as IEmpDeptQS;
        var obj = a.GetSelectedObj();

        if (obj == null)
        {
            Show("Select Unit or Team Member");
            return;
        }
        if (obj.SelectedType == EnumUC_QS_SelectedType.Emp)
        {
            rv_attendDs.Merge(rv_attend.GetData_rv_attend(adate.SelectedDate.Value, ddate.SelectedDate.Value, obj.Key, ""));
            rv_cardDs.Merge(rv_card.GetData_rv_card(adate.SelectedDate.Value, ddate.SelectedDate.Value, obj.Key, ""));
        }
        else if (obj.SelectedType == EnumUC_QS_SelectedType.Dept && !obj.IsSingleDept)
        {
            foreach (var d in obj.DeptList)
            {
                rv_attendDs.Merge(rv_attend.GetData_rv_attend(adate.SelectedDate.Value, ddate.SelectedDate.Value, "", d));
            }
        }

        SiteHelper siteHelper = new SiteHelper();
        //rv_cardDs = siteHelper.RemoveSelectedEmpData(rv_cardDs , "NOBR" , Juser.ManagerExeptEmpList) as HRDs.rv_cardDataTable;

        //rv_attendDs = siteHelper.RemoveSelectedEmpData(rv_attendDs , "NOBR" , Juser.ManagerExeptEmpList) as HRDs.rv_attendDataTable;

        Session[SessionName2]  = rv_cardDs;
        Session[SessionName] = rv_attendDs;
        GridView2.DataSource = rv_attendDs;
        GridView2.DataBind();
        Calendar1.DataBind();
    }

    protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
    {

        if (Session[SessionName] == null)
        {


            adate.SelectedDate = DateTime.Parse(e.Day.Date.Year.ToString() + "/" + e.Day.Date.Month + "/1");
            ddate.SelectedDate = DateTime.Parse(e.Day.Date.Year.ToString() + "/" + e.Day.Date.Month + "/" + DateTime.DaysInMonth(e.Day.Date.Year, e.Day.Date.Month).ToString());
            //GetData();
        }
        else
        {
            HRDs.rv_attendDataTable bdt = (HRDs.rv_attendDataTable)Session[SessionName];
            HRDs.rv_attendRow[] brow = (HRDs.rv_attendRow[])bdt.Select("adate ='" + e.Day.Date.ToShortDateString() + "'");

            HRDs.rv_cardDataTable rv_cardDs = (HRDs.rv_cardDataTable)Session[SessionName2];
            HRDs.rv_cardRow[] rcards = (HRDs.rv_cardRow[])rv_cardDs.Select("adate ='" + e.Day.Date.ToShortDateString() + "'");
            if (brow.Length > 0)
            {

                string s_2 = "";
                string s_1 = "   <tr> <td> <span style=\"color: #000099\">班別</span>：" + brow[0].ROTENAME + "</td> </tr> ";
                for (int i = 0; i < rcards.Length; i++)
                {
                    string cardtpyename = "";
                    if (rcards[i].CODE.Trim().Equals("進入"))
                    {
                        cardtpyename = "刷入";
                    }
                    else if (rcards[i].CODE.Trim().Equals("離開"))
                    {
                        cardtpyename = "刷出";
                    }

                    if (cardtpyename.Trim().Length == 0)
                    {
                        string ss = "";
                    }
                    s_2 += "  <tr>  <td><span style=\"color: #ff0000\">" + cardtpyename + "</span>：" + rcards[i].ONTIME + "</td> </tr> ";

                }
                // string s_2 = "  <tr>  <td><span style=\"color: #ff0000\">離職人數</span>：" + _2.ToString() + "人</td> </tr> ";
                //  string s_3 = "   <tr> <td><span style=\"color: #ff6666\">留停人數</span>：" + _3.ToString() + "人</td> </tr> ";
                // string s_4 = "   <tr> <td><span style=\"color: #009900\">復職人數</span>：" + _4.ToString() + "人</td> </tr> ";
                //  string s_5 = "  <tr>  <td><span style=\"color: #666600\">停職人數</span>：" + _5.ToString() + "人</td></tr>  ";
                //string s_7 = "  <tr>  <td><span style=\"color: #666600\">試用期滿人數</span>：" + _7.ToString() + "人</td></tr>  ";

                string html = "";
                html = "<br><br><table width='100%' border='0' cellspacing='1' cellpadding='2' > " +

                    s_1 + s_2 +

                    " </table> ";
                Label lb = new Label();
                lb.Text = html;
                e.Cell.Controls.Add(lb);
            }
        }

       



    }
    protected void Calendar1_SelectionChanged(object sender, EventArgs e)
    {

    }
    protected void Calendar1_VisibleMonthChanged(object sender, MonthChangedEventArgs e)
    {
        adate.SelectedDate = DateTime.Parse(e.NewDate.Year.ToString() + "/" + e.NewDate.Month + "/1");
        ddate.SelectedDate = DateTime.Parse(e.NewDate.Year.ToString() + "/" + e.NewDate.Month + "/" + DateTime.DaysInMonth(e.NewDate.Year, e.NewDate.Month).ToString());
        GetData();
    }
}
