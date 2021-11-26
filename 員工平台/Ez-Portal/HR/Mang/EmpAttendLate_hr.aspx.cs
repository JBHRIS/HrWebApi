﻿using System;
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
using JBHRModel;
 
using System.Collections.Generic;
using System.Linq;

public partial class HR_Mang_EmpAttendLate_hr : JBWebPage
{
    //joe
    const string SESSION_SUMMURY_TABLE = "HR_Mang_AttendLate_Summury";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //SiteHelper.SetAllDeptTree(TreeView1);

            //if (TreeView1.Nodes.Count>0&&TreeView1.Nodes[0] != null)
            //{
            //    TreeView1.Nodes[0].Select();
            //    TreeView1_SelectedNodeChanged(TreeView1.Nodes[0],null);
            //}
            var a = ucEmpDeptQS as IEmpDeptQS;
            a.InitUC_Dept(EnumUC_QS_InitType.HR);
            a.InitUC_Cat(1);

            Session[SessionName] = null;

            SiteHelper siteHelper = new SiteHelper();
            DateTime startDatetime , endDatetime;

            siteHelper.SetDateRange(out startDatetime, out endDatetime, DateTime.Now.Date, JbUser.SalaDr);
            rdpBdate.SelectedDate = startDatetime;
            rdpEdate.SelectedDate = endDatetime;
        }
    }
   


    
    protected void Button1_Click(object sender, EventArgs e)
    {
        GetData();
    }
    protected void ExportExcel_Click(object sender, EventArgs e)
    {
        if (Session[SessionName] != null)
            JB.WebModules.Data.Export.Excel.WebResponseExcel(this, gv, (List<EmpAttendLateDto>)Session[SessionName], SessionName);
        else
            JB.WebModules.Message.Show("無資料可匯出！");
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

        ATTEND_REPO attendRepo = new ATTEND_REPO();
        List<ATTEND> attendList = new List<ATTEND>();

        if (obj.SelectedType == EnumUC_QS_SelectedType.Dept && !obj.IsSingleDept)
        {
            //List<TreeNode> nodeList = SiteHelper.GetChildNodes(TreeView1.SelectedNode);
            foreach (var node in obj.DeptList)
                attendList.AddRange(attendRepo.GetAttendLateByDeptDateRange_Dlo(node, rdpBdate.SelectedDate.Value, rdpEdate.SelectedDate.Value));                
        }      
        //else
        //    attendList.AddRange(attendRepo.GetAttendLateByDeptDateRange_Dlo(lb_dept.Text, rdpBdate.SelectedDate.Value, rdpEdate.SelectedDate.Value));


        attendList = attendList.FindAll(p => Juser.SalaDrNobrList.Contains(p.NOBR));
        
        List<EmpAttendLateDto> attendLateList = (from c in attendList
                                                 select new EmpAttendLateDto
                                                 {
                                                     Nobr = c.NOBR,
                                                     DeptName = c.BASE.BASETTS[0].DEPT1.D_NAME,
                                                     DeptCode = c.BASE.BASETTS[0].DEPT1.D_NO_DISP,
                                                     Name_C = c.BASE.NAME_C,
                                                     Name_E = c.BASE.NAME_E,
                                                     Date = c.ADATE,
                                                     JobCode = c.BASE.BASETTS[0].JOB1.JOB_DISP,
                                                     JobName = c.BASE.BASETTS[0].JOB1.JOB_NAME,
                                                     Qty = c.LATE_MINS
                                                 }).ToList();

        List<EmpAttendLateSumDto> attendLateSumList = attendRepo.SummaryEmpAttnedLate(attendLateList);

        Session[SessionName] = attendLateList;
        Session[SESSION_SUMMURY_TABLE] = attendLateSumList;

        gv.DataSource = attendLateList;
        gv.DataBind();
        gvSummury.DataSource = attendLateSumList;
        gvSummury.DataBind();

    }
    protected void gv_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        if (Session[SessionName] != null)
        {
            gv.PageIndex = e.NewPageIndex;
            gv.DataSource = (List<OT46AMT>)Session[SessionName];
            gv.DataBind();
        }
        else
        {
            JB.WebModules.Message.Show("網頁逾時，請重新查詢！");
        }
    }
    protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

        if (Session[SessionName] != null)
        {
            //DataView dataview = new DataView(EntityToDataTable.Entity2DataTable<OT46AMT>((List<OT46AMT>)Session[SessionName]));
            //dataview.Sort = ViewState["sortKey"] + " " + ViewState["sortDirection"].ToString();
            //gv.PageIndex = e.NewPageIndex;
            gv.PageIndex = e.NewPageIndex;
            gv.DataSource = Session[SessionName] as List<EmpAttendLateDto>; //dataview;
            gv.DataBind();
            //gv.PageIndex = e.NewPageIndex;
            //gv.DataSource = (OT_Ds.OT46AMTDataTable)Session[SessionName];
            //gv.DataBind();
        }
        else
        {
            JB.WebModules.Message.Show("網頁逾時，請重新查詢！");
        }
    }

    protected void ExportSummuryExcel_Click(object sender, EventArgs e)
    {
        if (Session[SESSION_SUMMURY_TABLE] != null)
            JB.WebModules.Data.Export.Excel.WebResponseExcel(this, gvSummury, (List<EmpAttendLateSumDto>)Session[SESSION_SUMMURY_TABLE], SESSION_SUMMURY_TABLE);
        else
            JB.WebModules.Message.Show("無資料可匯出！");


        //Response.ClearContent();
        //string excelFileName = SESSION_SUMMURY_TABLE +".xls";
        //Response.AddHeader("content-disposition", "attachment;filename=" + Server.UrlEncode(excelFileName));
        //Response.ContentType = "application/excel";
        //System.IO.StringWriter stringWrite = new System.IO.StringWriter();
        //System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
        ////gvSummury.RenderControl(htmlWrite);
        ////GridView4.RenderControl(htmlWrite);

        //Response.Write(stringWrite.ToString());
        //Response.End();
    }

    protected void gvSummury_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        if (Session[SessionName] != null)
        {
            gvSummury.PageIndex = e.NewPageIndex;
            gvSummury.DataSource = Session[SESSION_SUMMURY_TABLE] as List<EmpAttendLateSumDto>;
            gvSummury.DataBind();
        }
        else
        {
            JB.WebModules.Message.Show("網頁逾時，請重新查詢！");
        }
    }
}
