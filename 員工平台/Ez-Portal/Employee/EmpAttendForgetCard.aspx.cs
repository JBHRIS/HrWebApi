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
using JBHRModel;
 
using System.Collections.Generic;
using System.Linq;

public partial class EmpAttendForgetCard : JBWebPage
{
    const string SESSION_SUMMURY_TABLE = "EmpAttendForgetCard_Summury";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //SiteHelper sh = new SiteHelper();sh.InitManagerDeptTreeView(TreeView1, Juser.ManageDeptRootNodeList);
            ////SiteHelper.SetAllDeptTree(TreeView1, Juser.ManageComp);

            //if (TreeView1.Nodes.Count>0&&TreeView1.Nodes[0] != null)
            //{
            //    TreeView1.Nodes[0].Select();
            //    TreeView1_SelectedNodeChanged(TreeView1.Nodes[0],null);
            //}

            Session[SessionName] = null;

            SiteHelper siteHelper = new SiteHelper();
            DateTime startDatetime , endDatetime;

            siteHelper.SetDateRange(out startDatetime, out endDatetime, DateTime.Now.Date, JbUser.SalaDr);
            rdpBdate.SelectedDate = startDatetime;
            rdpEdate.SelectedDate = endDatetime;
        }
    }
    protected void TreeView1_SelectedNodeChanged(object sender, EventArgs e)
    {
        setDept(TreeView1.SelectedValue);
        if(IsPostBack)
            GetData();
    }


    private void setDept(string value)
    {
        lb_dept.Text = value;
        //IUC iuc = (IUC)CalendarAbsList1;
        //iuc.SetValue(value);
        //iuc.BindData();
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
        ATTCARD_REPO attcardRepo = new ATTCARD_REPO();
        List<ATTCARD> attcardList = new List<ATTCARD>();

        //if (cbChildDept.Checked)
        //{
        //    List<TreeNode> nodeList = SiteHelper.GetChildNodes(TreeView1.SelectedNode);

        //    foreach (TreeNode node in nodeList)
        //        attcardList.AddRange(attcardRepo.GetLostByEmpDateRange_Dlo(node.Value, rdpBdate.SelectedDate.Value, rdpEdate.SelectedDate.Value));                
        //}      
        //else
            attcardList.AddRange(attcardRepo.GetLostByEmpDateRange_Dlo(Juser.Nobr, rdpBdate.SelectedDate.Value, rdpEdate.SelectedDate.Value));
        
        List<EmpAttendLateDto> attendLateList = (from c in attcardList
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
                                                     Qty = (c.LOST1 && c.LOST2)?2:1
                                                 }).ToList();

        List<EmpAttendLateSumDto> attendLateSumList = attcardRepo.SummaryEmpAttnedCardLost(attendLateList);

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
