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
public partial class Mang_EmpAttendUnusual:JBWebPage
{
    protected void Page_Load(object sender , EventArgs e)
    {
        //SelectEmp1.sHandler += new Templet_SelectEmp.SelectEmpEventHandler(UC_SelectEmp);
        if ( !IsPostBack )
        {

            var a = ucEmpDeptQS as IEmpDeptQS;
            a.InitUC_Dept(EnumUC_QS_InitType.Manager);
            a.InitUC_Cat(1);
            //SiteHelper siteHelper = new SiteHelper();
            //DateTime startDatetime, endDatetime;
            //siteHelper.SetDateRange(out startDatetime, out endDatetime, DateTime.Now.Date, JbUser.SalaDr);
            //adate.SelectedDate = startDatetime;
            //ddate.SelectedDate = endDatetime;
            //SiteHelper.SetDeptTreeByDeptDeptSupervisor(TreeView1 , JbUser.NOBR);
            //if ( TreeView1.Nodes.Count > 0 )
            //{
            //    TreeView1.Nodes[0].Select();
            //    TreeView1_SelectedNodeChanged(TreeView1.Nodes[0] , null);
            //}



        }
    }

    protected void TreeView1_SelectedNodeChanged(object sender , EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        GetData();   
    }
    void GetData()
    {
        AttendDsTableAdapters.AttendUnusualTableAdapter attU_adapter = new AttendDsTableAdapters.AttendUnusualTableAdapter();
        AttendDs.AttendUnusualDataTable attU_DT = new AttendDs.AttendUnusualDataTable();
        var a = ucEmpDeptQS as IEmpDeptQS;
        var obj = a.GetSelectedObj();

        if (obj == null)
        {
            Show("Select Unit or Team Member");
            return;
        }
        if (obj.SelectedType == EnumUC_QS_SelectedType.Dept && !obj.IsSingleDept) {
            foreach (var n in obj.DeptList)
            {
                if (cbType.SelectedValue.Equals("0"))//遲到
                {
                    attU_DT.Merge(attU_adapter.GetByLateMinsDateRangeMinsDept(adate.SelectedDate.Value, ddate.SelectedDate.Value, Convert.ToDecimal(tbHrs.Text), n));
                }
                else if (cbType.SelectedValue.Equals("1"))//早退
                {
                    attU_DT.Merge(attU_adapter.GetByEMinsDateRangeMinsDept(adate.SelectedDate.Value, ddate.SelectedDate.Value, Convert.ToDecimal(tbHrs.Text), n));
                }
                else if (cbType.SelectedValue.Equals("2"))//曠職
                {
                    attU_DT.Merge(attU_adapter.GetByAbsDateRangeDept(adate.SelectedDate.Value, ddate.SelectedDate.Value, n));
                }
                else if (cbType.SelectedValue.Equals("3"))//全部
                {
                    attU_DT.Merge(attU_adapter.GetByDateRangeMinsDept(adate.SelectedDate.Value, ddate.SelectedDate.Value, Convert.ToDecimal(tbHrs.Text), n));
                } 
            }
        }
        //string deptValue = TreeView1.SelectedValue;

        //if (RBL_deptr.SelectedValue.Equals("1"))
        //{
        //    if (cbType.SelectedValue.Equals("0"))//遲到
        //    {
        //        attU_DT.Merge(attU_adapter.GetByLateMinsDateRangeMinsDept(adate.SelectedDate.Value, ddate.SelectedDate.Value, Convert.ToDecimal(tbHrs.Text), deptValue));
        //    }
        //    else if (cbType.SelectedValue.Equals("1"))//早退
        //    {
        //        attU_DT.Merge(attU_adapter.GetByEMinsDateRangeMinsDept(adate.SelectedDate.Value, ddate.SelectedDate.Value, Convert.ToDecimal(tbHrs.Text), deptValue));
        //    }
        //    else if (cbType.SelectedValue.Equals("2"))//曠職
        //    {
        //        attU_DT.Merge(attU_adapter.GetByAbsDateRangeDept(adate.SelectedDate.Value, ddate.SelectedDate.Value, deptValue));
        //    }
        //    else if (cbType.SelectedValue.Equals("3"))//全部
        //        attU_DT.Merge(attU_adapter.GetByDateRangeMinsDept(adate.SelectedDate.Value, ddate.SelectedDate.Value, Convert.ToDecimal(tbHrs.Text), deptValue));
        //}
        //else if (RBL_deptr.SelectedValue.Equals("2"))
        //{
        //    List<TreeNode> nodeList = SiteHelper.GetChildNodes(TreeView1.SelectedNode);

        //    foreach (TreeNode n in nodeList)
        //    {
        //        if (cbType.SelectedValue.Equals("0"))//遲到
        //        {
        //            attU_DT.Merge(attU_adapter.GetByLateMinsDateRangeMinsDept(adate.SelectedDate.Value, ddate.SelectedDate.Value, Convert.ToDecimal(tbHrs.Text), n.Value));
        //        }
        //        else if (cbType.SelectedValue.Equals("1"))//早退
        //        {
        //            attU_DT.Merge(attU_adapter.GetByEMinsDateRangeMinsDept(adate.SelectedDate.Value, ddate.SelectedDate.Value, Convert.ToDecimal(tbHrs.Text), n.Value));
        //        }
        //        else if (cbType.SelectedValue.Equals("2"))//曠職
        //        {
        //            attU_DT.Merge(attU_adapter.GetByAbsDateRangeDept(adate.SelectedDate.Value, ddate.SelectedDate.Value, n.Value));
        //        }
        //        else if (cbType.SelectedValue.Equals("3"))//全部
        //            attU_DT.Merge(attU_adapter.GetByDateRangeMinsDept(adate.SelectedDate.Value, ddate.SelectedDate.Value, Convert.ToDecimal(tbHrs.Text), n.Value));
        //    }
        //}


        SiteHelper siteHelper = new SiteHelper();
        attU_DT = siteHelper.RemoveSelectedEmpData(attU_DT, "NOBR", Juser.ManagerExeptEmpList) as AttendDs.AttendUnusualDataTable;

        Session[SessionName] = attU_DT;
        gv.DataSource = attU_DT;
        gv.DataBind();
        //HRDsTableAdapters.AttendRptTableAdapter attendRptAdapter = new HRDsTableAdapters.AttendRptTableAdapter();
        //if(tbHrs.Text.Trim().Length == 0 )
        //    tbHrs.Text = "1";
        //HRDs.AttendRptDataTable attendRptDT = attendRptAdapter.GetDataLateEarly(adate.SelectedDate.Value,ddate.SelectedDate.Value,(Convert.ToInt16(tbHrs.Text)));

        ////2011/06/27 海悅需求，不顯示00班的資料
        //if (cbExcludeRote00.Checked == true)
        //{
        //    HRDs.AttendRptRow[] rows = (HRDs.AttendRptRow[])attendRptDT.Select("ROTE='00'");

        //    foreach (var row in rows)
        //    {
        //        attendRptDT.Rows.Remove(row);
        //    }
        //}

        //Session[SessionName] = attendRptDT;
        //gv.DataSource = attendRptDT;
        //gv.DataBind(); 
    }
    protected void gv_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        if (Session[SessionName] != null)
        {
            gv.PageIndex = e.NewPageIndex;
            gv.DataSource = (AttendDs.AttendUnusualDataTable)Session[SessionName];
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
            bool b = Convert.ToBoolean(e.Row.Cells[6].Text);
            if (b)
                e.Row.Cells[6].Text = "Y";
            else
                e.Row.Cells[6].Text = "N";
        }
    }
    protected void ExportExcel_Click(object sender, EventArgs e)
    {
        if (Session[SessionName] != null)
            JB.WebModules.Data.Export.Excel.WebResponseExcel(this, gv, (AttendDs.AttendUnusualDataTable)Session[SessionName], SessionName);
        else
            JB.WebModules.Message.Show("無資料可匯出！");
    }
}
