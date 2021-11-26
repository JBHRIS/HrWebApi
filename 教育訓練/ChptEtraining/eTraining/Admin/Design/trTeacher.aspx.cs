using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using Telerik.Web.UI;
using System.Data;
using Telerik.Web.UI.GridExcelBuilder;
using Repo;

public partial class Admin_Design_trTeacher : JBWebPage
{
    private dcTrainingDataContext dcTraining = new dcTrainingDataContext();
    bool isExport = false;
    protected void Page_Load(object sender, EventArgs e)
    {
        SiteHelper.ConverToChinese(gv);
        if (!IsPostBack)
        {
            this.Title = "講師資料";
        }

        btnAdd.Attributes["onclick"] = String.Format("return ShowInsertForm();");
    }

    protected void gv_ItemCreated(object sender, Telerik.Web.UI.GridItemEventArgs e)
    {
        if (e.Item is GridDataItem || e.Item is GridHeaderItem)
        {
            RadButton btnEdit = e.Item.FindControl("btnEdit") as RadButton;
            if (btnEdit != null)
                btnEdit.Attributes["onclick"] = String.Format("return ShowEditForm('{0}','{1}');", e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["iAutoKey"], e.Item.ItemIndex);

        }

        if (isExport && e.Item is GridFilteringItem)
            e.Item.Visible = false;
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
        int iAutoKey = Convert.ToInt32((e.Item as GridDataItem).GetDataKeyValue("iAutoKey"));
        trTeacher o_trTeacher = dcTraining.trTeacher.Where(p => p.iAutoKey == iAutoKey).FirstOrDefault();
        dcTraining.trTeacher.DeleteOnSubmit(o_trTeacher);
        dcTraining.SubmitChanges();
    }
    protected void btnExcel_Click(object sender, EventArgs e)
    {
        showCol();
        isExport = true;
        gv.ExportSettings.ExportOnlyData = true;
        gv.ExportSettings.HideStructureColumns = true;
        gv.ExportSettings.IgnorePaging = true;
        gv.ExportSettings.OpenInNewWindow = false;
        gv.ExportSettings.FileName = "講師";        
        gv.MasterTableView.ExportToExcel();
    }

    private void showCol()
    {
        gv.Columns.FindByUniqueName("sEmail").Visible = true;         
        gv.Columns.FindByUniqueName("sTel").Visible = true;        
        gv.Columns.FindByUniqueName("sCellPhone").Visible = true;        
        gv.Columns.FindByUniqueName("sNote1").Visible = true;        
        gv.Columns.FindByUniqueName("sNote2").Visible = true;         
        gv.Columns.FindByUniqueName("sNote3").Visible = true;         
        gv.Columns.FindByUniqueName("sTeachExp").Visible = true;
        gv.Columns.FindByUniqueName("sWorkExp").Visible = true;


        //檔案上傳要相反
        gv.Columns.FindByUniqueName("column1").Visible = false;
    }

    private void hideCol()
    {
        gv.Columns.FindByUniqueName("sEmail").Visible = false;        
        gv.Columns.FindByUniqueName("sTel").Visible = false;        
        gv.Columns.FindByUniqueName("sCellPhone").Visible = false;        
        gv.Columns.FindByUniqueName("sNote1").Visible = false;        
        gv.Columns.FindByUniqueName("sNote2").Visible = false;        
        gv.Columns.FindByUniqueName("sNote3").Visible = false;        

        gv.Columns.FindByUniqueName("sTeachExp").Visible = false;
        gv.Columns.FindByUniqueName("sWorkExp").Visible = false;
        //檔案上傳要相反
        gv.Columns.FindByUniqueName("column1").Visible = true;
    }
    protected void gv_ExcelExportCellFormatting(object sender, ExcelExportCellFormattingEventArgs e)
    {
        e.Cell.Style["mso-number-format"] = @"\@";

        //switch (e.FormattedColumn.UniqueName)
        //{
        //    case "sTel": e.Cell.Style["mso-number-format"] = @"\@";
        //        break;

        //}
    }
    protected void gv_ExcelMLExportStylesCreated(object sender, Telerik.Web.UI.GridExcelBuilder.GridExportExcelMLStyleCreatedArgs e)
    {

    }
    protected void gv_ExportCellFormatting(object sender, ExportCellFormattingEventArgs e)
    {
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        pnlNobr.Visible = true;
        btnCloseS.Visible = true;
    }
    protected void btnCloseS_Click(object sender, EventArgs e)
    {
        pnlNobr.Visible = false;
        btnCloseS.Visible = false;
    }
    protected void btnSearchNobr_Click(object sender, EventArgs e)
    {
        gvNobr.Rebind();
    }
    protected void btnSyncInnerTeacherData_Click(object sender, EventArgs e)
    {
        trTeacher_Repo trTeacherRepo = new trTeacher_Repo();
        trTeacherRepo.SyncInnerTeacherData();
        trTeacherRepo.SyncOuterTeacherData();
    }
    protected void gv_ItemCommand(object sender, GridCommandEventArgs e)
    {
        if (e.CommandName.Equals("Del"))
        {
            int iAutokey = Convert.ToInt32(e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["iAutoKey"].ToString());
            trTeacher_Repo teacherRepo = new trTeacher_Repo();
            trTeacher teacherObj = teacherRepo.GetByAutoKey(iAutokey);

            if (teacherRepo != null)
            {
                ClassTeacher_Repo clsTeacher = new ClassTeacher_Repo();
                if (clsTeacher.GetByTeacherCode(teacherObj.sCode).Count > 0)
                {
                    RadAjaxManager1.Alert("此講師已有開課資料，無法刪除");
                    return;
                }
                else
                {
                    teacherRepo.Delete(teacherObj);
                    teacherRepo.Save();
                    gv.Rebind();
                }
            }
            else
            {
                throw new ApplicationException("找無此講師資料!!");
            }

        }
    }
}