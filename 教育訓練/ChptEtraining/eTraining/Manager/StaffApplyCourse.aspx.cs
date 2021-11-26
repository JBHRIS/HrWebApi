using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Telerik.Web.UI;
using Repo;

public partial class eTraining_Manager_StaffApplyCourse : System.Web.UI.Page
{
    private trTrainingDetailM_Repo tdmRepo = new trTrainingDetailM_Repo();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DoHelper helper = new DoHelper();
            helper.setCbYear(cbxYear);
        }

    }
    protected void RadGrid1_ItemDataBound(object sender, Telerik.Web.UI.GridItemEventArgs e)
    {
        //    if (e.Item is GridDataItem)
        //    {
        //        //存取開課編號
        //        HyperLink hl = e.Item.Cells[6].FindControl("hlJoin") as HyperLink;
        //        if (hl != null)
        //        {
        //            hl.NavigateUrl = "~/eTraining/Manager/CourseDetail.aspx?ClassID=" + e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["iAutoKey"].ToString();
        //        }

        //    }

        if (e.Item is GridDataItem)
        {
            GridDataItem item = e.Item as GridDataItem;            
            HyperLink hl = item["TemplateColumn"].FindControl("hlJoin") as HyperLink;
            if (hl != null)
            {
                hl.NavigateUrl = "~/eTraining/Manager/CourseDetailM.aspx?ClassID=" + e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["iAutoKey"].ToString();

            }
        }

    }
    protected void gv_NeedDataSource(object sender , GridNeedDataSourceEventArgs e)
    {
        gv.DataSource = (from c in tdmRepo.GetByYear_WebRegisterable_DLO(Convert.ToInt32(cbxYear.SelectedValue))
                         select new
                         {
                             //cateName = c.trCategory.sName ,
                             cateName = c.trCourse.trCategoryCourse[0].trCategory.sName ,
                             courseName = c.trCourse.sName ,
                             iAutoKey = c.iAutoKey ,
                             dWebJoinDateB = c.dWebJoinDateB ,
                             dWebJoinDateE = c.dWebJoinDateE ,
                             dDateTimeA = c.dDateTimeA ,
                             iUpLimitP = c.iUpLimitP ,
                             studentNum = c.iStudentNum
                         }).ToList();
    }
    protected void cbxYear_SelectedIndexChanged(object sender , RadComboBoxSelectedIndexChangedEventArgs e)
    {
        gv.Rebind();
    }
}