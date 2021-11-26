using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using Repo;
public partial class eTraining_Admin_Plan_trCourse : System.Web.UI.Page
{
    private dcTrainingDataContext dcTraining = new dcTrainingDataContext();
    bool isExport = false;
    protected void Page_Load(object sender, EventArgs e)
    {
        SiteHelper.ConverToChinese(gv);
    }
    protected void gv_ItemCreated(object sender, Telerik.Web.UI.GridItemEventArgs e)
    {
        if (e.Item is GridDataItem || e.Item is GridHeaderItem)
        {

            RadButton btnEdit = e.Item.FindControl("btnEdit") as RadButton;
            if (btnEdit != null)
                btnEdit.Attributes["onclick"] = String.Format("return ShowEditFormByParam('{0}');", e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["iAutoKey"]);
            //gv.Rebind();//

            RadButton btnAdd = e.Item.FindControl("btnAdd") as RadButton;
            if (btnAdd != null)
                btnAdd.Attributes["onclick"] = String.Format("return ShowInsertForm();");
        }

        if ( isExport && e.Item is GridFilteringItem )
        {
            e.Item.Visible = false;            
        }

        if ( isExport )
            exportCol();
        else
            unExportCol();
    }
    protected void RadAjaxManager1_AjaxRequest(object sender, AjaxRequestEventArgs e)
    {
        if (e.Argument == "Rebind")
        {
            gv.MasterTableView.SortExpressions.Clear();
            gv.MasterTableView.GroupByExpressions.Clear();
            gv.Rebind();
        }
        else if (e.Argument == "RebindAndNavigate")
        {
            gv.MasterTableView.SortExpressions.Clear();
            gv.MasterTableView.GroupByExpressions.Clear();
            gv.MasterTableView.CurrentPageIndex = gv.MasterTableView.PageCount - 1;
            gv.Rebind();
        }
    }
    protected void gv_DeleteCommand(object sender, GridCommandEventArgs e)
    {
        int key = 0;
        if (!Int32.TryParse(e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["iAutoKey"].ToString(), out key))
            return;

        var data = (from c in dcTraining.trCourse
                    where c.iAutoKey == key
                    select c).FirstOrDefault();

        trTrainingDetailM_Repo tdmRepo = new trTrainingDetailM_Repo();
        trTrainingPlanDetail_Repo tpdRepo = new trTrainingPlanDetail_Repo();

        if (tdmRepo.GetByCourseCode(data.sCode).Count == 0 && tpdRepo.GetByCourseCode(data.sCode).Count==0)
        {
            trCourse_Repo cRepo = new trCourse_Repo();
            trCourse cObj = cRepo.GetByCode(data.sCode);
            cRepo.Delete(cObj);

            trCategoryCourse_Repo ccRepo = new trCategoryCourse_Repo(cRepo.dc);
            trCategoryCourse ccObj = ccRepo.GetByCourseCode(data.sCode);
            if (ccObj != null)
                ccRepo.Delete(ccObj);

            ccRepo.Save();
            gv.Rebind();
        }
        else
        {
            RadAjaxManager1.Alert("該課程已開課、或存在於年度計畫，無法刪除!!");
        }
    }

    protected void gv_ItemDataBound(object sender, GridItemEventArgs e)
    {
        if (e.Item is GridDataItem)
        {
            GridDataItem item = e.Item as GridDataItem;
            double hour = Convert.ToDouble(item["iCourseTime"].Text)/60;
            item["iCourseTime"].Text = Math.Round(hour,1, MidpointRounding.AwayFromZero).ToString();
        }
    }
    protected void btnExportExcel_Click(object sender , EventArgs e)
    {
        isExport = true;
        gv.ExportSettings.ExportOnlyData = true;
        gv.ExportSettings.HideStructureColumns = true;
        gv.ExportSettings.IgnorePaging = true;
        gv.ExportSettings.OpenInNewWindow = false;
        gv.ExportSettings.FileName = "課程";
        gv.MasterTableView.ExportToExcel();
    }

    private void unExportCol()
    {
        gv.Columns.FindByUniqueName("TemplateColumn").Visible = true;
        gv.Columns.FindByUniqueName("CatScode").Visible = false;
        gv.Columns.FindByUniqueName("CatSname").Visible = false;
    }

    private void exportCol()
    {
        gv.Columns.FindByUniqueName("TemplateColumn").Visible = false;
        gv.Columns.FindByUniqueName("CatScode").Visible = true;
        gv.Columns.FindByUniqueName("CatSname").Visible = true;
    }
    protected void gv_ItemCommand(object sender, GridCommandEventArgs e)
    {
        if (e.CommandName.Equals("MustTraining"))
        {
            GridDataItem item = e.Item as GridDataItem;
            Response.Redirect("MustTraining.aspx?Category=Course&code=" + item["sCode"].Text);
        }
        if (e.CommandName.Equals("Inactive"))
        {
            int key = 0;
            if (!Int32.TryParse(e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["iAutoKey"].ToString(), out key))
                return;


            var data = (from c in dcTraining.trCourse
                        where c.iAutoKey == key
                        select c).FirstOrDefault();

            if (data != null)
            {
                data.sKeyMan = Page.User.Identity.Name;
                data.dDateD = DateTime.Now.AddDays(-1);
                data.dKeyDate = DateTime.Now;

                var courseRef = from c in dcTraining.trCategoryCourse
                                where c.sCourseCode == data.sCode
                                select c;

                dcTraining.trCategoryCourse.DeleteAllOnSubmit(courseRef);

                dcTraining.SubmitChanges();
                gv.Rebind();
            }
        }
    }
}