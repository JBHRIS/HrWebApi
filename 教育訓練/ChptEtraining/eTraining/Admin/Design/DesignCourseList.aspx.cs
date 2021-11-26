using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Telerik.Web.UI;   
using Repo;

public partial class eTraining_Admin_Design_DesignCourseList : JBWebPage
{
    const string SESSION_NAME = "DesignCourseList";
    const string COURSE_LIST_SESSION_NAME = "eTraining_Admin_Design_DesignCourseList";
    const string PLANCOURSE_LIST_SESSION_NAME = "eTraining_Admin_Design_DesignPlanCourseList";
    private dcTrainingDataContext dcTraining = new dcTrainingDataContext();

    protected void Page_Load(object sender, EventArgs e)
    {
        SiteHelper.ConverToChinese(gvCourseList);
        SiteHelper.ConverToChinese(gvYearPlan);

        if (!IsPostBack)
        {
            SiteHelper util = new SiteHelper();
            util.SetTvCourseCat(tv);
            util.SetTvCourse(tv);
            util.SaveTreeViewNodesColor(tv.GetAllNodes(), SESSION_NAME);

            PlanHelper planHelper = new PlanHelper();
            planHelper.setCbYear(cbxYear);

            bindCbxPlanYear();
            changeMode("v");
            gvYearPlan.Rebind();
        }
    }

    private void bindCbxPlanYear()
    {
        PlanHelper planHelper = new PlanHelper();
        int year = Convert.ToInt32(planHelper.getLastPlanYear());

        cbxPlanYear.Items.Clear();

        RadComboBoxItem item = new RadComboBoxItem(year.ToString(), year.ToString());
        cbxPlanYear.Items.Add(item);

        year--;
        item = new RadComboBoxItem(year.ToString(), year.ToString());
        item.Selected = true;
        cbxPlanYear.Items.Add(item);
    }

    protected void btnNPlanCourse_Click(object sender, EventArgs e)
    {
        palCourse.Visible = false;
        palNPlanCourse.Visible = true;
    }
    protected void btnPlanAdd_Click(object sender, EventArgs e)
    {
        palPlanCourse.Visible = false;
        palCourse.Visible = true;
    }
    protected void btnNPlanAdd1_Click(object sender, EventArgs e)
    {
        btnClassAdd_Click(this, new EventArgs());
    }
    protected void btnPlanCourse_Click(object sender, EventArgs e)
    {
        changeMode("ePlan");
    }



    //年度開課
    protected void btnNPlanAdd_Click(object sender, EventArgs e)
    {
        GridItemCollection items = gvYearPlan.SelectedItems;

        foreach (GridDataItem item in items)
        {            
            var p = (from c in dcTraining.trTrainingPlanDetail
                     where c.iAutoKey == Convert.ToInt32(item["iAutoKey"].Text)
                     select c).FirstOrDefault();

            if (p != null)
            {
                //判斷是否已開課
                if (p.iClassAutoKey.HasValue)
                {
                    if (p.iClassAutoKey.Value >= 1)
                    {
                        continue;
                    }
                }                
            }

            //新增課程
            try
            {
                Course courseObj = new Course();
                courseObj.RegisterCourseByPlan(p , User.Identity.Name);
            }
            catch ( Exception ex )
            {
                //Show(ex.Message);
                RadAjaxPanel1.Alert(ex.Message);
                return;
            }
        }        

        cleanCourseCache();
        cleanYearPlanCache();
        gvCourseList.Rebind();
        changeMode("v");
    }

    protected void gvYearPlan_ItemDataBound(object sender, GridItemEventArgs e)
    {

        if (e.Item.ItemType == GridItemType.Item || e.Item.ItemType == GridItemType.AlternatingItem)
        {
            GridDataItem dataItem = (GridDataItem)e.Item;

            Label lbl = dataItem["iClassAutoKey"].FindControl("iClassAutoKeyLabel") as Label;

            if (lbl != null)
            {
                if (lbl.Text == "" || lbl.Text == "0")
                {
                    dataItem.Cells[2].Enabled = true;
                }
                else
                {
                    dataItem.Cells[2].Enabled = false;
                    dataItem.Cells[2].Controls[0].Visible = false;
                }
            }
        }
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
        palCourse.Visible = false;
    }
    protected void btnDefaultCheck_Click(object sender, EventArgs e)
    {
        palCourse.Visible = true;
    }
    protected void btnCourse_Click(object sender, EventArgs e)
    {
        if (rbtnPlanCourse.Checked == true)
        {
            //選擇年度計畫開課
            SiteHelper siteHelper = new SiteHelper();
            siteHelper.SetCbxSameValue(cbxYear, cbxPlanYear);

            palPlanCourse.Visible = true;
            palCourse.Visible = false;
            cleanYearPlanCache();
            gvYearPlan.Rebind();
        }
        else
        {
            palCourse.Visible = false;
            palNPlanCourse.Visible = true;
        }
    }

    protected void btnExpand_Click(object sender, EventArgs e)
    {
        SiteHelper util = new SiteHelper();
        util.SetExpand(tv, btnExpand);
    }
    protected void tv_PreRender(object sender, EventArgs e)
    {
        SiteHelper util = new SiteHelper();
        util.LoadTreeViewNodesColor(tv.GetAllNodes(), SESSION_NAME);
    }
    protected void btnClassAdd_Click(object sender, EventArgs e)
    {
        RadTreeNode node = tv.SelectedNode;
        if (node == null)
        {
            return;
        }

        try
        {
            Course courseObj = new Course();
            courseObj.RegisterCourse(tv.SelectedValue , tv.SelectedNode.ParentNode.Value , Convert.ToInt32(cbxYear.SelectedValue) , User.Identity.Name);
        }
        catch ( Exception ex )
        {
            //Show(ex.Message);
            RadAjaxPanel1.Alert(ex.Message);
            return;
        }

        cleanCourseCache();
        gvCourseList.Rebind();
        changeMode("v");
    }

    private void changeMode(string mode)
    {
        if (mode == "v")
        {
            palNPlanCourse.Visible = false;
            palPlanCourse.Visible = false;
            palCourse.Visible = true;
        }
        else if (mode == "ePlan")
        {
            palNPlanCourse.Visible = false;
            palPlanCourse.Visible = true;
            palCourse.Visible = false;
        }
        else if (mode == "eNPlan")
        {
            palNPlanCourse.Visible = true;
            palPlanCourse.Visible = false;
            palCourse.Visible = false;
        }

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

            CheckBox cb = item["bIsPublished"].Controls[0] as CheckBox;
            if (cb.Checked == true)
            {
                item["Delete"].Text = "";
            }                   
        }
    }
    protected void gvCourseList_DeleteCommand(object sender, GridCommandEventArgs e)
    {
        if (e.Item is GridDataItem)
        {
            GridDataItem item = (GridDataItem)e.Item;

            string id = (e.Item as GridDataItem).GetDataKeyValue("iAutoKey").ToString();

            CheckBox cb = item["bIsPublished"].Controls[0] as CheckBox;

            if (cb.Checked == true)
            {
                //Show("已發佈無法刪除");
                RadAjaxPanel1.Alert("已發佈無法刪除");
                return;
            }
            else
            {
                DesignHelper designHelper = new DesignHelper();
                designHelper.DeleteClass(Convert.ToInt32(id));
                RadAjaxPanel1.Alert("已刪除");
                //Show("已刪除");
            }

            cleanCourseCache();
        }
    }
    protected void gvCourseList_ItemCommand(object sender, GridCommandEventArgs e)
    {

    }
    protected void gvYearPlan_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
    {
        if (Session[PLANCOURSE_LIST_SESSION_NAME] == null || e.RebindReason == GridRebindReason.InitialLoad)
            getYearPlanCache();

        List<trTrainingPlanDetail> tpdList = Session[PLANCOURSE_LIST_SESSION_NAME] as List<trTrainingPlanDetail>;

        gvYearPlan.DataSource = (from c in tpdList
                                 select new
                                 {
                                     catsName = c.trCourse.trCategoryCourse[0].trCategory.sName,
                                     csName = c.trCourse.sName,
                                     trCategory_sCode = c.trCourse.trCategoryCourse[0].trCategory.sCode,
                                     courseCode = c.trCourse_sCode,
                                     c.iYear,
                                     c.iMonth,
                                     c.iClassAutoKey,
                                     c.iAutoKey,
                                     c.iNumOfPeople,
                                     c.iAmt,
                                     c.iMins,
                                     c.iSession
                                 }).ToList();
    }

    private void getYearPlanCache()
    {
        trTrainingPlanDetail_Repo tpdRepo = new trTrainingPlanDetail_Repo();
        List<trTrainingPlanDetail> tpdList = tpdRepo.GetByUnRunningYear_Dlo(Convert.ToInt32(cbxPlanYear.SelectedValue));
        Session[PLANCOURSE_LIST_SESSION_NAME] = tpdList;
    }

    private void cleanYearPlanCache()
    {
        Session[PLANCOURSE_LIST_SESSION_NAME] = null;
    }

    protected void gvCourseList_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
    {
        if (Session[COURSE_LIST_SESSION_NAME] == null || e.RebindReason==GridRebindReason.InitialLoad)
            getCourseCache();

        List<trTrainingDetailM> tdmList = Session[COURSE_LIST_SESSION_NAME] as List<trTrainingDetailM>;

        gvCourseList.DataSource = (from c in tdmList
                                 select new
                                 {
                                     category_sname = c.trCourse.trCategoryCourse[0].trCategory.sName,
                                     combineCategory= c.trCourse.trCategoryCourse[0].trCategory.sName,
                                     course_sname = c.trCourse.sName,
                                     trCategory_sCode = c.trCourse.trCategoryCourse[0].trCategory.sCode,
                                     courseCode = c.trCourse_sCode,
                                     classMonth=c.dDateA.HasValue?c.dDateA.Value.Month.ToString():"",
                                     combineCourse = c.trCourse.sCode + " " + c.trCourse.sName,
                                     c.sKey,
                                     c.iYear,
                                     c.iSession,
                                     c.iStudentNum,
                                     c.iEstimateAMT,
                                     c.dDateTimeD,
                                     c.dDateTimeA,
                                     c.iYearPlanAutoKey,
                                     c.bIsPublished,
                                     c.iUpLimitP,
                                     c.iLowLimitP,
                                     c.sKeyMan,
                                     c.dKeyDate,
                                     c.dWebJoinDateE,
                                     c.dWebJoinDateB,
                                     c.bWebJoin,
                                     c.dDateA,
                                     c.dDateD,
                                     c.iAutoKey,
                                     c.sTimeA,
                                     c.sTimeD
                                 }).ToList();
    }

    private void getCourseCache()
    {
        trTrainingDetailM_Repo tdmRepo = new trTrainingDetailM_Repo();
        List<trTrainingDetailM> tdmList = tdmRepo.GetByYear_Dlo(Convert.ToInt32(cbxYear.SelectedValue));
        Session[COURSE_LIST_SESSION_NAME] = tdmList;
    }

    private void cleanCourseCache()
    {
        Session[COURSE_LIST_SESSION_NAME] = null;
    }
}
