using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.IO;
using Repo;
public partial class eTraining_Admin_Plan_YearPlan : JBWebPage
{  
   private dcTrainingDataContext dcTraining = new dcTrainingDataContext();
   private CourseType_Repo courseTypeRepo = new CourseType_Repo();
    protected void Page_Load(object sender, EventArgs e)
    {

        lblMonth.Text = RadTabStrip1.SelectedTab.Value;

        if (!IsPostBack)
        {
            PlanHelper PlanHelper = new PlanHelper();
            PlanHelper.setCbYear(cbxYear);
            RadTabStrip1.SelectedIndex = 0;
            lblMonth.Text = "1";
            setLblYYMM();
            changeMode("v");
            //setPanelDefault();
            SiteHelper siteHelper = new SiteHelper();
            siteHelper.SetTvCourseCat(tv);
            siteHelper.SetTvCourse(tv);

            rblCourseType.DataSource = courseTypeRepo.GetAll();
            rblCourseType.DataBind();
            rblCourseType.ClearSelection();
        }
        this.Title = "年度訓練計劃";
    }

    private void setLblYYMM()
    {
        lblYYMM.Text = cbxYear.SelectedValue + "年" + RadTabStrip1.SelectedTab.Value + "月";

    }

    protected void Button1_Click(object sender, EventArgs e)
    {

    }


    protected void RadTabStrip1_TabClick(object sender, RadTabStripEventArgs e)
    {
        if (RadTabStrip1.SelectedTab.Value != "13")
        {
            GridColumn col = gv.Columns.FindByUniqueName("Edit");
            if (col != null)
                col.Visible = true;

            btnAdd.Visible = true;
            lblMonth.Text = RadTabStrip1.SelectedTab.Value;            
        }
        else
        {
            btnAdd.Visible = false;
            GridColumn col = gv.Columns.FindByUniqueName("Edit");
            if (col != null)
                col.Visible = false;
            
        }

        gv.Rebind();
    }

    private void changeMode(string mode)
    {
        lblMode.Text = mode;
        lbManager.Items.Clear();

        clearGvPerson();

        if (mode == "v")
        {
            tv.Enabled = true;
            lblAutoKey.Text = "";
            lblCourseCode.Text = "";
            tbSearch.Text = "";
            cbIsSerialCourse.Checked = false;

            pnView.Visible = true;
            pnAdd.Visible = false;
            lblMsg.Text = "";
            //gv.Rebind();

        }
        else if (mode == "i")
        {
            pnView.Visible = false;
            pnAdd.Visible = true;
            rblCourseType.ClearSelection();
            setLblYYMM();
        }
        else if (mode == "e")
        {
            tv.Enabled = false;
            loadEditData();
            pnView.Visible = false;
            pnAdd.Visible = true;
            setLblYYMM();
        }
    }


    protected void gv_ItemUpdated(object sender, GridUpdatedEventArgs e)
    {

    }
    protected void gv_DataBound(object sender, EventArgs e)
    {
        
    }
    protected void gv_ItemDataBound(object sender, GridItemEventArgs e)
    {       
        
        if(e.Item is GridDataItem)
        {
            GridDataItem item = (GridDataItem)e.Item;

            if (item["iClassAutoKey"].Text.Trim().Length > 0)
            {
                item["Delete"].ToolTip = "已開課，無法刪除";
                item["Edit"].ToolTip = "已開課，無法更新";
                item["Edit"].Text = "已開課"; 
                item["Delete"].Text = "已開課";
            }

            item["iMins"].Text = string.Format("{0:#,0.0}" , float.Parse(item["iMins"].Text)/60);
        }

        if (e.Item is GridFooterItem)
        {
            GridFooterItem f_item = (GridFooterItem)e.Item;
            GridDataItemCollection items = gv.Items;
            
            int iNumOfPeople = 0;
            int iAmt = 0;
            double iMins = 0;
            double temp_d = 0;
            int temp_i=0;


            if ( RadTabStrip1.SelectedTab.Value == "13" )
            {
                var dataList = (from c in dcTraining.trTrainingPlanDetail
                                where c.iYear == Convert.ToInt32(cbxYear.SelectedValue)
                                select c).ToList();

                iNumOfPeople = (from c in dataList
                                select c.iNumOfPeople).Sum();
                iAmt = (from c in dataList
                        select c.iAmt).Sum();
                iMins = (from c in dataList
                         select c.iMins).Sum();
            }
            else
            {
                var dataList = (from c in dcTraining.trTrainingPlanDetail
                                where c.iYear == Convert.ToInt32(cbxYear.SelectedValue)
                                && c.iMonth == Convert.ToInt32(RadTabStrip1.SelectedTab.Value)
                                select c).ToList();

                iNumOfPeople = (from c in dataList
                                select c.iNumOfPeople).Sum();
                iAmt = (from c in dataList
                        select c.iAmt).Sum();
                iMins = (from c in dataList
                         select c.iMins).Sum();


            }

            f_item["iNumOfPeople"].Text = iNumOfPeople.ToString();
            f_item["iAmt"].Text = iAmt.ToString();
            f_item["iMins"].Text = string.Format("{0:#,0.0}" , iMins/ 60);            
            f_item["iYear"].Text = "小計";
        }

    }
    protected void gv_ItemCommand(object sender, GridCommandEventArgs e)
    {
        if (e.CommandName == "Edit")
        {
            lblAutoKey.Text = e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["iAutokey"].ToString();
            changeMode("e");
            //取消內建的Edit，跑我的
            e.Canceled = true;
        }
        else if (e.CommandName.Equals("Delete"))
        {
            if (e.Item is GridDataItem)
            {
                GridDataItem item = (GridDataItem)e.Item;
                int key = Convert.ToInt32(lblAutoKey.Text = e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["iAutokey"].ToString());

                trTrainingPlanDetail_Repo tpdRepo = new trTrainingPlanDetail_Repo();
                var tpdObj=tpdRepo.GetByPk(key);

                if (tpdObj != null)
                {
                    if (tpdObj.iClassAutoKey.HasValue)
                    {
                        RadAjaxPanel1.Alert("已開課的年度計劃，無法刪除");
                        e.Canceled = true;
                    }
                    else
                    {
                        tpdRepo.Delete(tpdObj);
                        tpdRepo.Save();
                    }
                }
                else
                {
                    throw new ApplicationException("刪除無此autokey的年度計畫");
                }

            }
        }
    }

    private void loadEditData()
    {
        var data = (from c in dcTraining.trTrainingPlanDetail
                    where c.iAutoKey == Convert.ToInt32(lblAutoKey.Text)
                    select c).FirstOrDefault();

        if (data != null)
        {
            lblCourse.Text = data.trCourse.sName;
            txtSession.Text = data.iSession.ToString();
            txtHour.Text = string.Format("{0:#,0.0}" , data.iMins/60);
            txtAmt.Text = data.iAmt.ToString();
            txtNumOfPeople.Text = data.iNumOfPeople.ToString();
            cbIsSerialCourse.Checked = data.trCourse.bIsSerialCourse;
            lblCourseCode.Text = data.trCourse_sCode;
            rblCourseType.ClearSelection();

            if (data.CourseType == null)
            { }
            else
                rblCourseType.SelectedValue = data.CourseType;

            var managers = from m in dcTraining.trTrainingPlanDetailManager
                           join b in dcTraining.BASE on m.sPersonInCharge equals b.NOBR
                           where m.iPlanDetailAutoKey == Convert.ToInt32(lblAutoKey.Text)
                           select new { m, b };


            lbManager.Items.Clear();
            foreach (var man in managers)
            {
                RadListBoxItem item = new RadListBoxItem();
                item.Text = man.b.NAME_C;
                item.Value = man.m.sPersonInCharge;
                lbManager.Items.Add(item);
            }

            SiteHelper siteHelper = new SiteHelper();
            siteHelper.SetTvSelectedNode(tv, lblCourseCode.Text);
            tv.CollapseAllNodes();

            if (tv.SelectedNode != null)
                tv.SelectedNode.ExpandParentNodes();
        }
    }




    protected void btnAdd_Click(object sender, EventArgs e)
    {
        changeMode("i");
    }

    private void setPanelDefault()
    {
        pnView.Visible = true;
        pnAdd.Visible = false;
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (lblCourseCode.Text.Trim().Length > 0)
        {
            try
            {
                if (lblMode.Text == "e")
                {
                    var plan = (from c in dcTraining.trTrainingPlanDetail
                                where c.iAutoKey == Convert.ToInt32(lblAutoKey.Text)
                                select c).FirstOrDefault();

                    var dataMan = from c in dcTraining.trTrainingPlanDetailManager
                                  where c.iPlanDetailAutoKey == Convert.ToInt32(lblAutoKey.Text)
                                  select c;

                    //dcTraining.trTrainingPlanDetail.DeleteAllOnSubmit(plan);                   
                    //dcTraining.trTrainingPlanDetailManager.DeleteAllOnSubmit(dataMan);
                    dcTraining.trTrainingPlanDetailManager.DeleteAllOnSubmit(dataMan);
                    if (plan != null)
                    {
                        plan.iSession = Convert.ToInt32(txtSession.Text);
                        plan.iAmt = Convert.ToInt32(txtAmt.Text);
                        //plan.iHours = Convert.ToDecimal(txtHour.Text);
                        plan.iMins = Convert.ToInt32(Convert.ToDouble(txtHour.Text) * 60);
                        plan.iNumOfPeople = Convert.ToInt32(txtNumOfPeople.Text);
                        plan.iYear = Convert.ToInt32(cbxYear.Text);
                        plan.iMonth = Convert.ToInt32(RadTabStrip1.SelectedTab.Value);
                        plan.dKeyDate = DateTime.Now;
                        plan.sKeyMan = User.Identity.Name;
                        plan.trCourse_sCode = tv.SelectedValue;
                        plan.sKey = tv.SelectedNode.ParentNode.Value;

                        if (rblCourseType.SelectedItem == null)
                            plan.CourseType = null;
                        else
                            plan.CourseType = rblCourseType.SelectedValue;
                        dcTraining.SubmitChanges();
                    }

                    foreach (RadListBoxItem item in lbManager.Items)
                    {
                        trTrainingPlanDetailManager objMan = new trTrainingPlanDetailManager();
                        objMan.iPlanDetailAutoKey = plan.iAutoKey;
                        objMan.sPersonInCharge = item.Value;
                        dcTraining.trTrainingPlanDetailManager.InsertOnSubmit(objMan);
                        dcTraining.SubmitChanges();
                    }
                }
                else
                {

                    trTrainingPlanDetail obj = new trTrainingPlanDetail();
                    obj.iSession = Convert.ToInt32(txtSession.Text);
                    obj.iAmt = Convert.ToInt32(txtAmt.Text);
                    //obj.iHours = Convert.ToDecimal(txtHour.Text);
                    obj.iMins = Convert.ToInt32(Convert.ToDouble(txtHour.Text) * 60);                    
                    obj.iNumOfPeople = Convert.ToInt32(txtNumOfPeople.Text);
                    obj.iYear = Convert.ToInt32(cbxYear.Text);
                    obj.iMonth = Convert.ToInt32(RadTabStrip1.SelectedTab.Value);
                    obj.dKeyDate = DateTime.Now;
                    obj.sKeyMan = User.Identity.Name;
                    obj.trCourse_sCode = tv.SelectedValue;
                    obj.sKey = tv.SelectedNode.ParentNode.Value;

                    if (rblCourseType.SelectedItem == null)
                        obj.CourseType = null;
                    else
                        obj.CourseType = rblCourseType.SelectedValue;

                    dcTraining.trTrainingPlanDetail.InsertOnSubmit(obj);
                    dcTraining.SubmitChanges();

                    foreach (RadListBoxItem item in lbManager.Items)
                    {
                        trTrainingPlanDetailManager objMan = new trTrainingPlanDetailManager();
                        objMan.iPlanDetailAutoKey = obj.iAutoKey;
                        objMan.sPersonInCharge = item.Value;
                        dcTraining.trTrainingPlanDetailManager.InsertOnSubmit(objMan);
                    }

                    dcTraining.SubmitChanges();
                }

                lblCourseCode.Text = "";
                gv.Rebind();
                changeMode("v");
                //setPanelDefault();
            }

            catch (Exception ex)
            {
                lblMsg.Text = ex.Message;
            }
        }
        else
        {
            lblMsg.Text = "尚未選擇課程";
        }


    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        changeMode("v");
    }
    protected void tv_NodeClick(object sender, RadTreeNodeEventArgs e)
    {
        if (tv.SelectedNode.Category == "CATEGORY")
        {
            lblCourse.Text = "您選擇的是類別，不是課程喔!!";
            lblCourseCode.Text = "";
        }
        else
        {
            lblCourse.Text = "課程:" + tv.SelectedNode.Text;
            lblCourseCode.Text = tv.SelectedNode.Value;
            lblMsg.Text = "";
        }

    }
    //負責人搜尋
    //protected void btnSearchMan_Click(object sender, EventArgs e)
    //{
    //    //sdsEmpInfo_QuickSearch.SelectCommand = "SELECT NOBR, NAME_C, INDT, DEPT, D_NAME, JOB, JOB_NAME, EMPCD, EMPDESCR, MANG, DI FROM HR_Portal_EmpInfo_Le WHERE NOBR like @value or NAME_C  like @value";
    //    //sdsEmpInfo_QuickSearch.SelectParameters.Clear();
    //    //sdsEmpInfo_QuickSearch.SelectParameters.Add("value", tbEmpSearch.Text + @"%");
    //    //GridView2.DataBind();

    //    sdsGvPerson.SelectCommand = "select b.NOBR,b.NAME_C from BASE b join BASETTS t on b.NOBR = t.NOBR and t.TTSCODE in ('1','4','6') and GETDATE() between t.ADATE and t.DDATE where b.NAME_C like @value or b.NOBR like @value";
    //    sdsGvPerson.SelectParameters.Clear();
    //    sdsGvPerson.SelectParameters.Add("value", tbSearch.Text + @"%");
    //    gvPerson.Rebind();
    //}

    private void clearGvPerson()
    {
        sdsGvPerson.SelectParameters.Clear();
        sdsGvPerson.SelectParameters.Add("value", "-_-+");
        //sdsGvPerson.SelectParameters.Add("value", tbSearch.Text + @"%");                
        //gvPerson.DataSource = null;
        gvPerson.Rebind();
    }

    ////負責人gv
    protected void gvPerson_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void gv_DeleteCommand(object sender, GridCommandEventArgs e)
    {

    }
    protected void gv_PreRender(object sender, EventArgs e)
    {

    }

    protected void btnUpload_Click(object sender, EventArgs e)
    {
        if (ul.UploadedFiles.Count > 0)
        {
            string fileStoredPath = @"~\UPLOAD\" + "PLAN" + @"\";
            string fileName =DateTime.Now.Ticks.ToString()+ "file.xls";
            string fileFullPath = Server.MapPath(fileStoredPath) + fileName;

            if (!Directory.Exists(Server.MapPath(fileStoredPath)))
            {
                Directory.CreateDirectory(Server.MapPath(fileStoredPath));
            }
            
            ul.UploadedFiles[0].SaveAs(fileFullPath,true);

            if (File.Exists(fileFullPath))
            {

                FileStream fileStream = File.Open(fileFullPath, FileMode.Open);
                DataTable dt = DataTableRenderToExcel.RenderDataTableFromExcel(fileStream, 0, 0);

                PlanHelper planHelper = new PlanHelper();
                try
                {
                    planHelper.DoUpdatePlan(dt, User.Identity.Name);
                    RadAjaxPanel1.Alert("上傳完成");
                }
                catch (Exception ex)
                {                    
                    RadAjaxPanel1.Alert(ex.Message);
                    fileStream.Close();
                    return;
                }
                finally
                {
                    gv.Rebind();                                       
                }
            }
        }
    }
    protected void gv_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
    {
        trTrainingPlanDetail_Repo tpdRepo = new trTrainingPlanDetail_Repo();
        if (RadTabStrip1.SelectedTab.Value.Equals("13"))
        {
            gv.DataSource = (from c in tpdRepo.GetByYear_Dlo(Convert.ToInt32(cbxYear.SelectedValue))
                             orderby c.iMonth, c.iSession
                             select new
                             {
                                 catsName = c.trCourse.trCategoryCourse.Count == 0 ? "" : c.trCourse.trCategoryCourse[0].trCategory.sName,
                                 csName = c.trCourse.sName,
                                 iAutokey = c.iAutoKey,
                                 iYear = c.iYear,
                                 iMonth = c.iMonth,
                                 iSession = c.iSession,
                                 iMins = c.iMins,
                                 iNumOfPeople = c.iNumOfPeople,
                                 iAmt = c.iAmt
                             }
                                 ).ToList();
        }
        else
        {
            gv.DataSource = (from c in tpdRepo.GetByYearMonth_Dlo(Convert.ToInt32(cbxYear.SelectedValue), Convert.ToInt32(RadTabStrip1.SelectedTab.Value))
                             orderby c.iMonth, c.iSession
                             select new
                             {
                                 catsName = c.trCourse.trCategoryCourse.Count == 0 ? "" : c.trCourse.trCategoryCourse[0].trCategory.sName,
                                 csName = c.trCourse.sName,
                                 iAutokey = c.iAutoKey,
                                 iYear = c.iYear,
                                 iMonth = c.iMonth,
                                 iSession = c.iSession,
                                 iMins = c.iMins,
                                 iNumOfPeople = c.iNumOfPeople,
                                 iAmt = c.iAmt
                             }
                           ).ToList();
        }
    }
}