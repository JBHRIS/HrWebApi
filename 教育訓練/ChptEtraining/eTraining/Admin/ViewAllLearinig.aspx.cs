using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using System.Data.Linq;
using Repo;
public partial class eTraining_Admin_ViewAllLearinig : System.Web.UI.Page
{
    private dcTrainingDataContext dcTraining = new dcTrainingDataContext();
    bool isExport = false;
    protected void Page_Load(object sender, EventArgs e)
    {
        UserQuickSearch1.sHandler += new UC_UserQuickSearch.SelectedEventHandler(gvSelected);
        SiteHelper.ConverToChinese(gv);
        if (!IsPostBack)
        {
            SiteHelper util = new SiteHelper();
            util.setDeptTv(tvDept);
            tvDept.ExpandAllNodes();

            PlanHelper PlanHelper = new PlanHelper();
            PlanHelper.setCbYear(cbxYear);
            gv.Rebind();
        }
    }

    protected void tvDept_NodeClick(object sender, Telerik.Web.UI.RadTreeNodeEventArgs e)
    {
        lblSearchBy.Text = "dept";
        gv.CurrentPageIndex = 0;
        gv.Rebind();        
    }
    protected void cbxYear_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        gv.Rebind();
    }

    protected void gvSelected(string nobr, GridDataItem sItem)
    {
        lblNobr.Text = nobr;
        lblSearchBy.Text = "nobr";
        gv.Rebind();
    }

    protected void gv_NeedDataSource(object sender , GridNeedDataSourceEventArgs e)
    {       
        Repo.trTrainingStudentM_Repo smRepo = new trTrainingStudentM_Repo();
        Repo.DEPT_Repo deptRepo = new DEPT_Repo();
        deptRepo.IsFromCache = true;

        List<trTrainingStudentM> dataList=null;

        int year = Convert.ToInt32(cbxYear.SelectedValue);

        if (lblSearchBy.Text.Equals("dept"))
        {
            DEPT dept = deptRepo.GetDeptByID(tvDept.SelectedValue);

            List<DEPT> deptList = deptRepo.GetAllChildNode(dept);
            dataList = smRepo.GetByDeptListYearPresence_DLO(deptList, year);
            //dataList = smRepo.GetByDeptYear_DLO(tvDept.SelectedValue, year);
        }
        else
            dataList = smRepo.GetByNobrYearPresence_DLO(lblNobr.Text, year); ;

        gv.DataSource =(from c in  dataList  select new {
                                 Nobr = c.sNobr
                                ,Name_C = c.BASE!=null? c.BASE.NAME_C:""
                                ,DeptName = c.DEPT !=null?c.DEPT.D_NAME:""
                                //,CateName = c.trTrainingDetailM.trCategory.sName
                                ,CateName = c.trTrainingDetailM.trCourse.trCategoryCourse[0].trCategory.sName
                                ,CourseCode = c.trTrainingDetailM.trCourse.sCode
                                ,CourseName = c.trTrainingDetailM.trCourse.sName
                                ,Session = c.trTrainingDetailM.iSession
                                ,CourseAdate = c.trTrainingDetailM.dDateA
                                ,Pass=c.bPass});
    }
    protected void btnExportExcel_Click(object sender, EventArgs e)
    {
        isExport = true;
        gv.ExportSettings.ExportOnlyData = true;
        gv.ExportSettings.HideStructureColumns = true;
        gv.ExportSettings.IgnorePaging = true;
        gv.ExportSettings.OpenInNewWindow = false;
        gv.ExportSettings.FileName = "EmpData";
        gv.MasterTableView.ExportToExcel();
    }
    protected void gv_ItemCreated(object sender, GridItemEventArgs e)
    {
        if (isExport && e.Item is GridFilteringItem)
        {
            e.Item.Visible = false;
        }
    }
    protected void gv_ExportCellFormatting(object sender, ExportCellFormattingEventArgs e)
    {
        e.Cell.Style["mso-number-format"] = @"\@";
    }
}