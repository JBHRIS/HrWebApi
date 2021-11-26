using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Telerik.Web.UI;

public partial class eTraining_Admin_Do_DoCourseList : JBWebPage
{
    const string SESSION_NAME = "DoCourseList";
    private dcTrainingDataContext dcTraining = new dcTrainingDataContext();
    bool isExport = false;

    protected void Page_Load(object sender, EventArgs e)
    {
        SiteHelper.ConverToChinese(gvCourseList);  
        

        if (!IsPostBack)
        {
            PlanHelper planHelper = new PlanHelper();
            planHelper.setCbYear(cbxYear);

            bindCbxPlanYear();
            changeMode("v");       
        }
    }

    private void bindCbxPlanYear()
    {
       
    }

    protected void btnNPlanCourse_Click(object sender, EventArgs e)
    {
       
    }
    protected void btnPlanAdd_Click(object sender, EventArgs e)
    {
        
    }
    protected void btnNPlanAdd1_Click(object sender, EventArgs e)
    {
        //btnClassAdd_Click
        btnClassAdd_Click(this, new EventArgs());        

    }
    protected void btnPlanCourse_Click(object sender, EventArgs e)       
    {
        changeMode("ePlan");
        
    }
    protected void btnNPlanAdd_Click(object sender, EventArgs e)
    {
        
        gvCourseList.Rebind();
        changeMode("v");
    }

    protected void btnCanelP_Click(object sender, EventArgs e)
    {
        changeMode("v");
    }
    protected void RadButton1_Click(object sender, EventArgs e)
    {
        changeMode("v");
    }
    protected void btnCopy_Click(object sender, EventArgs e)
    {
        
    }
    protected void btnDefaultCheck_Click(object sender, EventArgs e)
    {
        
    }
    protected void btnCourse_Click(object sender, EventArgs e)
    {
        
    }  

    protected void btnExpand_Click(object sender, EventArgs e)
    {        
        
    }
    protected void tv_PreRender(object sender, EventArgs e)
    {
        
    }
    protected void btnClassAdd_Click(object sender, EventArgs e)
    { 
        gvCourseList.Rebind();

        changeMode("v");
    }

    private void changeMode(string mode)
    {
        

    }

    protected void gvCourseList_ItemDataBound(object sender, GridItemEventArgs e)
    {
        if (e.Item is GridDataItem)
        {
            GridDataItem item = (GridDataItem)e.Item;

            string id = (e.Item as GridDataItem).GetDataKeyValue("iAutoKey").ToString();
            
            HyperLink hl = item["set"].FindControl("hlSetClass") as HyperLink;            
            if (hl != null)
            {
                hl.NavigateUrl = hl.NavigateUrl + "?ID=" + id;
            }

            if (item["iYearPlanAutoKey"].Text.Trim().Length > 0)
                item["iYearPlanAutoKey"].Text = "是";
            
           // item["course_sname"].Text = item["trCourse_sCode"].Text + "  "+ item["course_sname"].Text;
           // item["category_sname"].Text = item["sKey"].Text + "  "+  item["category_sname"].Text;
        }
        
    }
    protected void btnExcel_Click(object sender, EventArgs e)
    {
        gvCourseList.ExportSettings.ExportOnlyData = false;
        gvCourseList.ExportSettings.HideStructureColumns = false;
        gvCourseList.ExportSettings.IgnorePaging = true;
        gvCourseList.ExportSettings.OpenInNewWindow = false;
        isExport = true;
        string fileName = cbxYear.SelectedValue.ToString() + "-" + "課程執行狀況";
        gvCourseList.ExportSettings.FileName = fileName;
        gvCourseList.MasterTableView.ExportToExcel();
    }
    protected void gvCourseList_ItemCommand(object sender, GridCommandEventArgs e)
    {

    }
    protected void gvCourseList_ItemCreated(object sender, GridItemEventArgs e)
    {
        if (isExport && e.Item is GridFilteringItem)
        {
            e.Item.Visible = false;
        }
    }
}
