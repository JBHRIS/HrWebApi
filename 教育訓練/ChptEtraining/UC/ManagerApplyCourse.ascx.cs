using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Telerik.Web.UI;
using Repo;
public partial class UC_ManagerApplyCourse : System.Web.UI.UserControl
{
    private trTrainingDetailM_Repo tdmRepo = new trTrainingDetailM_Repo(); 
    protected void Page_Load(object sender, EventArgs e)
    {
    }
    protected void Gv_ItemDataBound(object sender, Telerik.Web.UI.GridItemEventArgs e)
    {
        if (e.Item is GridDataItem)
        {
            GridDataItem item = e.Item as GridDataItem;
            //存取開課編號



            HyperLink hl = item["TemplateColumn1"].FindControl("hlJoin") as HyperLink;
            if (hl != null)
            {
                hl.NavigateUrl = "~/eTraining/Manager/CourseDetailM.aspx?ClassID=" + e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["iAutoKey"].ToString();
            }
        }        
    }
    protected void Gv_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
    {
        var dataList = tdmRepo.GetByNow_WebRegisterable_DLO();
        Gv.DataSource = (from c in dataList select 
                         new {
                             iAutoKey = c.iAutoKey,
                             //categoryName = c.trCategory.sName,
                             categoryName = c.trCourse.trCategoryCourse[0].trCategory.sName,
                             courseName = c.trCourse.sName,
                             dDateTimeA = c.dDateTimeA,
                             dWebJoinDateB = c.dWebJoinDateB,
                             dWebJoinDateE = c.dWebJoinDateE,                             
                             iUpLimitP = c.iUpLimitP,
                             iStudentNum = c.iStudentNum
                         }).ToList();
    }
}