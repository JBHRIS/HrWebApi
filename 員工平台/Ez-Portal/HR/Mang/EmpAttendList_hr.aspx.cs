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

public partial class HR_Mang_EmpAttendList_hr : JBWebPage
{
    //joe
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //lb_dept.Text = SiteHelper.GetDeptRoot();
            //SiteHelper.SetAllDeptTree(TreeView1);
            
            //if (TreeView1.Nodes.Count > 0)
            //{
            //    TreeView1.Nodes[0].Select();
            //    TreeView1_SelectedNodeChanged(TreeView1.Nodes[0], null);
            //}
            var a = ucEmpDeptQS as IEmpDeptQS;
            a.InitUC_Dept(EnumUC_QS_InitType.HR);
            Session[SessionName] = null;
            adate.SelectedDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            ddate.SelectedDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month));
        }
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
        //ATTEND_REPO attendRepo = new ATTEND_REPO();        
        //List<EmpAttendList> list = attendRepo.GetAttendListByDateRange(adate.SelectedDate.Value, ddate.SelectedDate.Value);
        //Session[SESSION_TABLE] = list;
        //gv.DataSource = list;
        //gv.DataBind();



        var a = ucEmpDeptQS as IEmpDeptQS;
        var obj = a.GetSelectedObj();

        if (obj == null)
        {
            Show("Select Unit or Team Member");
            return;
        }



        ATTEND_REPO attendRepo = new ATTEND_REPO();
        List<EmpAttendList> list  = new List<EmpAttendList>();
        

        if (obj.SelectedType == EnumUC_QS_SelectedType.Dept && !obj.IsSingleDept)
        {
            //TreeNode node = TreeView1.SelectedNode;
            //List<TreeNode> nodeList = SiteHelper.GetChildNodes(node);
            //foreach (var n in nodeList)

            foreach (var item in obj.DeptList)
            {
                list.AddRange(attendRepo.GetAttendListByDateRangeDept(item, adate.SelectedDate.Value, ddate.SelectedDate.Value));
            }
        }
        //else
        //{
        //    list.AddRange(attendRepo.GetAttendListByDateRangeDept(lb_dept.Text, adate.SelectedDate.Value, ddate.SelectedDate.Value));
        //}

        list = list.FindAll(p => Juser.SalaDrNobrList.Contains(p.Nobr));

        Session[SessionName] = list;
        gv.DataSource = list;
        gv.DataBind();
    }

    protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
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
            //11,12,13,14
            bool b ;

            if (Convert.ToInt32(e.Row.Cells[11].Text) == 0)
                e.Row.Cells[11].Text = "";

            if (Convert.ToInt32(e.Row.Cells[12].Text) == 0)
                e.Row.Cells[12].Text = "";

            if (Convert.ToInt32(e.Row.Cells[14].Text) == 0)
                e.Row.Cells[14].Text = "";
            //    = Convert.ToBoolean(e.Row.Cells[11].Text);
            //if (b)
            //    e.Row.Cells[11].Text = "Y";
            //else
            //    e.Row.Cells[11].Text = "N";

            //b = Convert.ToBoolean(e.Row.Cells[12].Text);
            //if (b)
            //    e.Row.Cells[12].Text = "Y";
            //else
            //    e.Row.Cells[12].Text = "N";

            b = Convert.ToBoolean(e.Row.Cells[13].Text);
            if (b)
                e.Row.Cells[13].Text = "Y";
            else
                e.Row.Cells[13].Text = "";
                //e.Row.Cells[13].Text = "N";

            //b = Convert.ToBoolean(e.Row.Cells[14].Text);
            //if (b)
            //    e.Row.Cells[14].Text = "Y";
            //else
            //    e.Row.Cells[14].Text = "N";

            //string str = "vnd.ms-excel.numberformat:@";
            //e.Row.Cells[2].Attributes.Add("style", str);
            //e.Row.Cells[6].Attributes.Add("style", str);
            //e.Row.Cells[7].Attributes.Add("style", str);
            //e.Row.Cells[8].Attributes.Add("style", str);

        }
    }
    //protected void TreeView1_SelectedNodeChanged(object sender, EventArgs e)
    //{
    //    setDept(TreeView1.SelectedValue);
    //    if (IsPostBack)
    //        GetData();
    //}

    //private void setDept(string value)
    //{
    //    lb_dept.Text = value;

    //}
}
