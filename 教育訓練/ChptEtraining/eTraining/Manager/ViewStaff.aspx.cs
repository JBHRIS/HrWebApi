using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Telerik.Web.UI;
using Repo;
using System.Data.SqlTypes;
public partial class eTraining_Manager_ViewStaff : JBWebPage
{
    dcTrainingDataContext dcTrain = new dcTrainingDataContext();
    bool isExport = false;
    const string popWinUrl = @"~/eTraining/Teacher/ScoreStudentReport2.aspx?ID=";
    protected void Page_Load(object sender, EventArgs e)
    {
        SiteHelper.ConverToChinese(gvEmp);
        SiteHelper.ConverToChinese(gvEmpData);
        win.VisibleOnPageLoad = false;
        if (!IsPostBack)
        {
            SiteHelper.ConverToChinese(gvEmpData);
            DoHelper doHelper = new DoHelper();
            //doHelper.setCbYear(cbxYear);

            sdsName.SelectParameters.Clear();
            sdsName.SelectParameters.Add("Manage", Page.User.Identity.Name);


            var LoginDept = (from c in dcTrain.DEPT
                             join bt in dcTrain.BASETTS on c.D_NO equals bt.DEPT
                             where bt.NOBR == User.Identity.Name
                             && new string[] { "1", "4", "6" }.Contains(bt.TTSCODE)
                             && DateTime.Now.Date >= bt.ADATE && DateTime.Now.Date <= bt.DDATE
                             select c).FirstOrDefault();

            if (LoginDept != null)
            {
                lblLoginDept.Text = LoginDept.D_NO;
            }

            sdsName.SelectParameters.Add("Dept", lblLoginDept.Text);

            this.Title = "查詢員工學習紀錄";
        }
    }
    protected void cbxYear_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        gvEmpData.Rebind();
    }
    protected void gvEmp_SelectedIndexChanged(object sender, EventArgs e)
    {
        gvEmpData.Rebind();
    }
    protected void sdsEmpData_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
    {
        e.Command.Parameters["@nobr"].Value = gvEmp.SelectedValue;
    }
    protected void btnExportExcel_Click(object sender, EventArgs e)
    {        
        
        isExport = true;
        gvEmpData.ExportSettings.ExportOnlyData = true;
        gvEmpData.ExportSettings.HideStructureColumns = true;
        gvEmpData.ExportSettings.IgnorePaging = true;
        gvEmpData.ExportSettings.OpenInNewWindow = false;
        gvEmpData.ExportSettings.FileName = "EmpData";
        gvEmpData.MasterTableView.ExportToExcel();
    }
    protected void gvEmpData_ItemCreated(object sender, Telerik.Web.UI.GridItemEventArgs e)
    {
        if (isExport && e.Item is GridFilteringItem)
        {
            e.Item.Visible = false;
        }
    }
    protected void gvEmpData_ExportCellFormatting(object sender, ExportCellFormattingEventArgs e)
    {
        e.Cell.Style["mso-number-format"] = @"\@";
    }
    protected void gvEmpData_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
    {
        if (gvEmp.SelectedItems.Count > 0)
        {
            trTrainingStudentM_Repo tsmRepo = new trTrainingStudentM_Repo();
            List<trTrainingStudentM> tsmList = tsmRepo.GetByNobrDateRange_Dlo(gvEmp.SelectedValue.ToString(), SqlDateTime.MinValue.Value, SqlDateTime.MaxValue.Value);

            gvEmpData.DataSource = (from c in tsmList
                                    select new
                                    {
                                        NAME_C = c.BASE.NAME_C,
                                        categoryName = c.trTrainingDetailM.trCourse.trCategoryCourse[0].trCategory.sName,
                                        courseName = c.trTrainingDetailM.trCourse.sName,
                                        iSession = c.trTrainingDetailM.iSession,
                                        dDateA = c.trTrainingDetailM.dDateA.Value,
                                        bPass = c.bPass,
                                        iClassAutoKey = c.iClassAutoKey,
                                        iAutoKey = c.iAutoKey,
                                        sNote1 = c.sNote1,
                                        sAbsenceNote = c.sAbsenceNote,
                                        bAbsence = c.bPresence,
                                        trCourse_sCode = c.trTrainingDetailM.trCourse_sCode,
                                        sNobr = c.sNobr,
                                        sDeptCode = c.sDeptCode,
                                        TrainingMethodName = c.trTrainingDetailM.trTrainingMethod.sName,
                                        IsManagerScoreStudentClassReport = c.trTrainingDetailM.IsManagerScoreStudentClassReport,
                                        bIsNeedClassRpt = c.trTrainingDetailM.bIsNeedClassRpt
                                    }).ToList();
        }
    }
    protected void gvEmpData_ItemCommand(object sender, GridCommandEventArgs e)
    {
        GridDataItem item = e.Item as GridDataItem;
        if (item == null)
            return;

        if (e.CommandName.Equals("ClassRpt"))
        {
            win.NavigateUrl = popWinUrl+item["iAutoKey"].Text+@"&Mode=View";
            win.VisibleOnPageLoad = true;
        }
    }
    protected void gvEmpData_ItemDataBound(object sender, GridItemEventArgs e)
    {
        if (e.Item is GridDataItem)
        {
            GridDataItem item = e.Item as GridDataItem;
            if (item == null)
                return;

            bool b;
            Boolean.TryParse(item["IsManagerScoreStudentClassReport"].Text, out b);

            bool b1;
            Boolean.TryParse(item["bIsNeedClassRpt"].Text, out b1);

            if (!(b&&b1))
            {
                item["ClassRpt"].Controls[0].Visible = false;
            }

        }
    }
    protected void gvEmp_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
    {
        List<BASE> baseList;
        if (Session[SessionName] != null)
        {
            baseList = Session[SessionName] as List<BASE>;
        }
        else
        {
            BASE_Repo baseRepo = new BASE_Repo();
            baseList = baseRepo.GetEmpHiredByDate_Dlo(DateTime.Now.Date).FindAll(p => Juser.ManageFullEmpList.Contains(p.NOBR));
            Session[SessionName] = baseList;
        }

        gvEmp.DataSource = (from c in baseList
                            select new
                                {
                                    NOBR = c.NOBR,
                                    NAME_C = c.NAME_C,
                                    D_NAME = c.BASETTS[0].DEPT1.D_NAME
                                }).ToList();
    }
}