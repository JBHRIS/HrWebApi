using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Telerik.Web.UI;
using System.IO;
using Repo;

public partial class eTraining_Admin_Design_SetCourse : JBWebPage
{
    dcTrainingDataContext dcTraining = new dcTrainingDataContext();
    private trTrainingDetailM_Repo tdmRepo = new trTrainingDetailM_Repo();
    private CourseType_Repo courseTypeRepo = new CourseType_Repo();
    const string planDetailEditUrl = @"~/eTraining/Admin/Design/PlanDetailEdit.aspx?Id=";
    protected void Page_Load(object sender, EventArgs e)
    {
        SiteHelper.ConverToChinese(gvPastClass);
        SiteHelper.ConverToChinese(gvTeachingMaterialList);
        SiteHelper.ConverToChinese(gvQList);
        SiteHelper.ConverToChinese(gvTrainingStudentList);
        SiteHelper.ConverToChinese(gvUserList);
        SiteHelper.ConverToChinese(gvTeacherList);

        win.VisibleOnPageLoad = false;

        if (!IsPostBack)
        {
            this.Title = "設定課程";
            if (Request.QueryString["ID"] != null)
            {
                RadTabStrip1.SelectedIndex = 1;
                RadMultiPage1.PageViews[RadTabStrip1.SelectedTab.PageView.Index].Selected = true;

                int id = Convert.ToInt32(Request.QueryString["ID"].ToString());
                var cls = dcTraining.GetTable<trTrainingDetailM>().Where(c => c.iAutoKey == id).FirstOrDefault();

                cbxCourseType.DataSource = courseTypeRepo.GetAll();
                cbxCourseType.DataBind();
                RadComboBoxItem item = new RadComboBoxItem("未指定", "");
                cbxCourseType.Items.Add(item);
                cbxCourseType.ClearSelection();

                

                if (cls != null)
                {
                    var course = (from c in dcTraining.trCourse
                                  where c.sCode == cls.trCourse_sCode
                                  select c).FirstOrDefault();

                    if (course != null)
                    {
                        lblClassID.Text = cls.iAutoKey.ToString();
                        lblClassName.Text = course.sName;
                        var cate = (from c in dcTraining.trCategory
                                    join cc in dcTraining.trCategoryCourse on c.sCode equals cc.sCateCode
                                    join co in dcTraining.trCourse on cc.sCourseCode equals co.sCode
                                    //where co.sName == lblClassName.Text
                                    where co.sCode == cls.trCourse_sCode
                                    select c).FirstOrDefault();
                        lblCateName.Text = cate.sName;
                        lblCateCode.Text = cate.sCode;

                        loadAll(cls);

                        if (cls.bIsPublished == true)
                        {
                            changeMode("v");
                        }
                    }
                    else
                        throw new Exception("參數不正確");
                }
                else
                    throw new Exception("參數不正確");
            }
            else
            {
                throw new Exception("無傳入參數");
            }
        }
    }

    private void doChangeMode(bool value)
    {
        //pnAttendClassDate
        pnAttendClassDate.Enabled = value;

        //清除發佈的錯誤訊息
        lblPublishMsg.Text = "";

        //教材上傳
        pvTextBook.Enabled = value;
        //gvTeachingMaterial.Enabled = value;        
        //btnFileUpload.Enabled = value;
        //ul.Enabled = value;

        //課程計畫
        //pnCoursePlan.Enabled = value;
        pnCoursePlan.Enabled = true;

        rblSet.Enabled = value;
        gvTeachingMaterialList.Enabled = value;
        btnMaterialSave.Enabled = value;


        gvKnotTeachesList.Enabled = value;

        rblMemberSelect.Enabled = value;
        btnLoadMustTraining.Enabled = value;
        btnAddMember.Enabled = value;
        btnDelQualifier.Enabled = value;
        btnAddTrainingUser.Enabled = value;
        gvTrainingStudentList.Enabled = value;
        gvUserList.Enabled = value;


        gvClassNotify.Enabled = value;
        btnAddNotifyTpl.Enabled = value;
        btnSaveClassNotify.Enabled = value;
        btnAddItem.Enabled = value;
        btnDelAllNotify.Enabled = value;

        gvEstimateAmt.Enabled = value;
        gvCostItem.Enabled = value;

        btnSaveCost.Enabled = value;

        gvClassTime.Enabled = value;
        // btnSaveAttendClassDate.Enabled = value;
        // btnAddAttendClassDate.Enabled = value;
        // lbAttendClassDate.Enabled = value;

        gvTeacherList.Enabled = value;
        gvTeacher.Enabled = value;
        btnAttendClassTeacherSave.Enabled = value;
        btnAttendClassTeacherCancel.Enabled = value;
        btnTeacherAdd.Enabled = value;

        gvPlaceList.Enabled = value;
        btnPlaceAdd.Enabled = value;
        btnPlaceCancel.Enabled = value;
        btnAddPlace.Enabled = value;
        gvPlace.Enabled = value;



        gvPastClass.Enabled = value;
        btnCloneClass.Enabled = value;

        rbtnJoin.Enabled = value;
        dpBDate.Enabled = value;
        dpEDate.Enabled = value;
        RadButton7.Enabled = value;

        //問卷
        btnCheckQ.Enabled = value;
        btnAddClassQnCU.Enabled = value;
        //gvQList.Enabled = value;

        //結訓項目
        btnClassKnotTeaches.Enabled = value;

        if (GetRequestQueryStringValue("MODE").Equals("SUPER"))
            doSuperMode();
    }

    private void doSuperMode()
    {
        pnAttendClassDate.Enabled = true;
        gvClassTime.Enabled = true;
        //pvCourseSammary.Enabled = true;
        btnUnpublished.Enabled = true;
        pnlECost.Enabled = true;
        pvTextBook.Enabled = true;
        btnCheckQ.Enabled = true;


        //cldAttendClassDate.Enabled = false;
        lbAttendClassDate.Enabled = false;

        //cbIsNeedClassRpt.Enabled = false;
        ntbClassRptDateSpan.Enabled = false;
        //cbIsNeedStudentScore.Enabled = false;
        ntbStudentScoreDateSpan.Enabled = false;

        btnAddAttendClassDate.Enabled = false;
    }

    private void changeMode(string mode)
    {
        if (mode == "v")
        {
            doChangeMode(false);

        }
        else if (mode == "e")
        {
            doChangeMode(true);
        }
    }

    private void loadAll(trTrainingDetailM tdm)
    {
        loadAttendClassDate(tdm);
        loadMaterial(tdm);

        loadPlanData(tdm); //載入年度計畫資料
        loadEstimatesAMT(tdm);//載入預估費用
        loadWebJoin(tdm);//載入線上報名資料
        loadCoursePlan(tdm); //載入課程大綱
    }

    //載入課程大綱
    private void loadCoursePlan(trTrainingDetailM tdm)
    {
        edtCourseGoal.Content = tdm.sCourseGoal;
        edtCourseGoal2.Content =tdm.sCourseGoal2 ;
        edtPlanRequirement.Content =tdm.PlanRequirement ;
        edtPlanStudentQualification.Content = tdm.PlanStudentQualification;
        edtPlanTrainingMethod.Content = tdm.PlanTrainingMethod;
        edtPlanComment.Content = tdm.PlanComment ;
        
        gvPlanDetail.Rebind();
    }

    //載入年度計畫資料
    private void loadPlanData(trTrainingDetailM tdm)
    {
        var p = (from c in dcTraining.trTrainingPlanDetail
                 where c.iClassAutoKey == tdm.iAutoKey
                 select c).FirstOrDefault();

        if (p != null)
        {
            lblPlanAmt.Text = "年度計畫預估費用：" + p.iAmt.ToString();
        }
        else
            lblPlanAmt.Text = "";

    }
    //帶入線上報名資料
    private void loadWebJoin(trTrainingDetailM tdm)
    {
        //撈取此課程資料
        //var classObj = (from c in dcTraining.trTrainingDetailM
        //          where c.iAutoKey == Convert.ToInt32(lblClassID.Text)
        //          select c).FirstOrDefault();

        if (tdm != null)
        {
            //判斷此課程是否開放線上報名
            if (tdm.bWebJoin == true)
            {
                rbtnJoin.SelectedValue = "y";
                pnlWebAdd.Visible = true;

                dpBDate.SelectedDate = tdm.dWebJoinDateB;
                dpEDate.SelectedDate = tdm.dWebJoinDateE;
            }
            else
            {
                rbtnJoin.SelectedValue = "n";
            }

            //判斷此課程是否發佈   
            btnUnpublished.Enabled = false; //default
            if (tdm.bIsPublished == true)
            {
                btnPublished.Enabled = false;

                if (tdm.dDateA.HasValue)
                    if (DateTime.Now < tdm.dDateTimeA)
                        btnUnpublished.Enabled = true;
            }
            else
            {
                btnPublished.Enabled = true;
                btnUnpublished.Enabled = false;
            }
        }
    }

    private void loadEstimatesAMT(trTrainingDetailM tdm)
    {
        //var cls = (from c in dcTraining.trTrainingDetailM
        //           where c.iAutoKey == Convert.ToInt32(lblClassID.Text)
        //           select c).FirstOrDefault();

        if (tdm != null)
        {
            lblEstimateAmt.Text = "小計：" + tdm.iEstimateAMT.ToString();
        }
    }


    //存檔開課資料檔的 EstimateAmt
    private void saveClassEstimateAmt()
    {
        var dataList = (from c in dcTraining.trTrainingEstimateCost
                        where c.iClassAutoKey == Convert.ToInt32(lblClassID.Text)
                        select c).ToList();

        int iAmt = 0;

        foreach (var data in dataList)
        {
            iAmt = iAmt + data.iAmt;
        }

        var cls = (from c in dcTraining.trTrainingDetailM
                   where c.iAutoKey == Convert.ToInt32(lblClassID.Text)
                   select c).FirstOrDefault();

        if (cls != null)
        {
            cls.iEstimateAMT = iAmt;
            dcTraining.SubmitChanges();
        }

    }

    private void loadMaterial(trTrainingDetailM tdm)
    {
        //var cls = (from c in dcTraining.trTrainingDetailM
        //           where
        //               c.iAutoKey == Convert.ToInt32(lblClassID.Text)
        //           select c).FirstOrDefault();

        if (tdm != null)
        {
            foreach (ListItem item in rblSet.Items)
            {
                if (item.Value == tdm.sMaterialSelector)
                {
                    item.Selected = true;
                }
                else
                    item.Selected = false;
            }

            if (tdm.sMaterialSelector == "M")
            {
                gvTeachingMaterialList.Visible = true;
                lblMaterialCode.Visible = true;
            }
            else
            {
                gvTeachingMaterialList.Visible = false;
                lblMaterialCode.Visible = false;
            }

            lblMaterialCode.Text = tdm.iMaterialAutoKey.ToString();
        }
    }

    protected void btnPlaceAdd_Click(object sender, EventArgs e)
    {
        GridItemCollection items = gvPlaceList.SelectedItems;

        foreach (GridItem item in items)
        {
            //如果勾選預設設定地點，就將尚未選擇的課程都帶地點進去
            if (cbDefaultAttnedPlace.Checked)
            {
                trAttendClassPlace_Repo acpRepo = new trAttendClassPlace_Repo();
                List<trAttendClassPlace> acpList = acpRepo.GetByClassKey(Convert.ToInt32(lblClassID.Text));

                List<trAttendClassDate> acdList = new List<trAttendClassDate>();
                trAttendClassDate_Repo acdRepo = new trAttendClassDate_Repo();
                acdList = acdRepo.GetByClassKey(Convert.ToInt32(lblClassID.Text));

                var exList = (from c in acdList where !acpList.Select(p => p.dClassDate).Contains(c.dClassDate) select c).ToList();

                foreach (var ex in exList)
                {
                    trAttendClassPlace obj = new trAttendClassPlace();
                    obj.iClassAutoKey = Convert.ToInt32(lblClassID.Text);
                    obj.sPlaceCode = item.Cells[5].Text;
                    obj.dClassDate = ex.dClassDate;
                    obj.dKeyDate = DateTime.Now;
                    obj.sKeyMan = User.Identity.Name;
                    dcTraining.trAttendClassPlace.InsertOnSubmit(obj);
                }
            }
            else
            {
                var p = (from c in dcTraining.trAttendClassPlace
                         where c.dClassDate == DateTime.Parse(cbxAttendDate.SelectedValue)
                         && c.iClassAutoKey == Convert.ToInt32(lblClassID.Text)
                         select c).FirstOrDefault();
                //c.sPlaceCode == item.Cells[5].Text 
                if (p == null)
                {
                    trAttendClassPlace obj = new trAttendClassPlace();
                    obj.iClassAutoKey = Convert.ToInt32(lblClassID.Text);
                    obj.sPlaceCode = item.Cells[5].Text;
                    obj.dClassDate = DateTime.Parse(cbxAttendDate.SelectedValue);
                    obj.dKeyDate = DateTime.Now;
                    obj.sKeyMan = User.Identity.Name;
                    dcTraining.trAttendClassPlace.InsertOnSubmit(obj);
                }
                else
                {
                    //Show("時間重複");
                    RadAjaxPanel1.Alert("時間重複");
                }
            }
        }
        dcTraining.SubmitChanges();

        gvPlace.Rebind();
        pnlPlace.Visible = true;
        pnlSetPlace.Visible = false;


    }
    protected void btnPlaceCancel_Click(object sender, EventArgs e)
    {

        pnlPlace.Visible = true;
        pnlSetPlace.Visible = false;
    }

    protected void RadButton1_Click(object sender, EventArgs e)
    {
        TextBox TextBox1 = new TextBox();

        TextBox1.Visible = true;
    }

    protected void btnSaveCost_Click(object sender, EventArgs e)
    {
        foreach (GridDataItem item in gvEstimateAmt.Items)
        {
            int key = Convert.ToInt32(item.GetDataKeyValue("iAutoKey").ToString());

            var data = (from c in dcTraining.trTrainingEstimateCost
                        where c.iAutoKey == key
                        select c).FirstOrDefault();

            if (data != null)
            {
                RadNumericTextBox ntb = item.Cells[2].FindControl("ntb_iAmt") as RadNumericTextBox;

                if (ntb != null)
                {
                    data.iAmt = Convert.ToInt32(ntb.Text);
                    data.dKeyDate = DateTime.Now;
                    data.sKeyMan = User.Identity.Name;
                    dcTraining.SubmitChanges();
                    //Show("已更新");
                    RadAjaxPanel1.Alert("已更新");

                }
            }
        }
        foreach (GridDataItem itm in gvCostItem.Items)
        {
            int key = Convert.ToInt32(itm.GetDataKeyValue("iAutoKey").ToString());

        }
        //開課資料的EstimateAmt儲存
        saveClassEstimateAmt();

        trTrainingDetailM tdm = tdmRepo.GetByKey_DLO(Convert.ToInt32(lblClassID.Text));
        loadEstimatesAMT(tdm);
    }




    protected void btnAddAttendClassDate_Click(object sender, EventArgs e)
    {
        foreach (Telerik.Web.UI.RadDate datetime in cldAttendClassDate.SelectedDates)
        {
            if (lbAttendClassDate.Items.Any(p => p.Value == datetime.Date.ToShortDateString()))
            {

            }
            else
            {
                RadListBoxItem item = new RadListBoxItem();
                item.Text = datetime.Date.ToShortDateString();
                item.Value = datetime.Date.ToShortDateString();
                lbAttendClassDate.Items.Add(item);
            }
        }

        lbAttendClassDate.Items.Sort(new MyComparer());
    }

    //IComparer<object>


    private void loadAttendClassDate(trTrainingDetailM tdm)
    {
        if (tdm != null)
        {
            txtSession.Text = tdm.iSession.ToString();
            txtDownPeople.Text = tdm.iLowLimitP.ToString();
            txtUpPeople.Text = tdm.iUpLimitP.ToString();
            if (tdm.dDateA.HasValue)
            {
                lblClassBDate.Text = tdm.dDateA.Value.ToShortDateString();
                lblClassBDate0.Text = tdm.dDateA.Value.ToShortDateString();
                lblClassBDate1.Text = tdm.dDateA.Value.ToShortDateString();
            }
            if (tdm.dDateD.HasValue)
            {
                lblClassEDate.Text = tdm.dDateD.Value.ToShortDateString();
                lblClassEDate0.Text = tdm.dDateD.Value.ToShortDateString();
                lblClassEDate1.Text = tdm.dDateD.Value.ToShortDateString();
            }

            //職能積分
            txtJobScore.Text = tdm.iJobScore.ToString();
            //課程時數
            ntb_iCourseTime.Text = tdm.iCourseTime.HasValue ? ((Double)(tdm.iCourseTime.Value) / 60).ToString() : "0";

            //訓練方式
            bindCbx_trTrainingMethod();

            //內外師
            bindCbxTeacherType();

            //課後心得填寫
            ntbClassRptDateSpan.Value = tdm.iClassRptDateSpan;
            cbIsNeedClassRpt.Checked = tdm.bIsNeedClassRpt;
            if (tdm.dClassRptDeadline.HasValue)
                rdtpClassRptDeadLine.SelectedDate = tdm.dClassRptDeadline.Value;
            else
                rdtpClassRptDeadLine.Clear();

            ntbStudentScoreDateSpan.Value = tdm.iStudentScoreDateSpan;
            cbIsNeedStudentScore.Checked = tdm.bIsNeedStudentScore;
            if (tdm.dStudentScoreDeadline.HasValue)
                rdtpStudentScoreDeadLine.SelectedDate = tdm.dStudentScoreDeadline.Value;
            else
                rdtpStudentScoreDeadLine.Clear();

            //課程類型

            cbIsManagerScoreStudentClassReport.Checked = tdm.IsManagerScoreStudentClassReport;

            if (tdm.CourseType == null)
                cbxCourseType.SelectedValue = "";
            else
                cbxCourseType.SelectedValue = tdm.CourseType;

        }

        //show 年度計畫開課id
        lblYearPlanID.Text = "";
        if (tdm.iYearPlanAutoKey.HasValue)
        {
            if (tdm.iYearPlanAutoKey != 0)
            {
                lblYearPlanID.Text = "年度計畫課程編號：" + tdm.iYearPlanAutoKey.Value.ToString();
            }
        }

        //listbox的資料
        lbAttendClassDate.Items.Clear();
        var data = (from c in dcTraining.trAttendClassDate
                    where c.iClassAutoKey == tdm.iAutoKey
                    orderby c.dClassDate ascending
                    select c).ToList();

        foreach (trAttendClassDate d in data)
        {
            RadListBoxItem item = new RadListBoxItem();
            item.Value = d.dClassDate.ToShortDateString();
            item.Text = d.dClassDate.ToShortDateString();
            lbAttendClassDate.Items.Add(item);
        }



        //上課時間
        gvClassTime.Rebind();

        //講師設定
        gvTeacher.Rebind();
        gvTeacherList.Rebind();
        cbxAttendDateTeacher.DataBind();

        //地點設定
        gvPlace.Rebind();
        gvPlaceList.Rebind();
        cbxAttendDate.DataBind();
    }

    private void bindCbx_trTrainingMethod()
    {
        cbxTrainingMethod.DataBind();
        RadComboBoxItemCollection items = cbxTrainingMethod.Items;

        var classObj = (from c in dcTraining.trTrainingDetailM
                        where c.iAutoKey == Convert.ToInt32(lblClassID.Text)
                        select c).FirstOrDefault();

        foreach (RadComboBoxItem i in items)
        {
            if (i.Value == classObj.trTrainingMethod_sCode)
            {
                i.Selected = true;
            }
            else
                i.Selected = false;
        }
    }

    private void bindCbxTeacherType()
    {
        cbxTeacherType.DataBind();
        RadComboBoxItemCollection items = cbxTeacherType.Items;

        var classObj = (from c in dcTraining.trTrainingDetailM
                        where c.iAutoKey == Convert.ToInt32(lblClassID.Text)
                        select c).FirstOrDefault();

        foreach (RadComboBoxItem i in items)
        {
            if (i.Value == classObj.trTeacher_sCode)
            {
                i.Selected = true;
            }
            else
                i.Selected = false;
        }
    }

    protected void ckxWebAdd_CheckedChanged(object sender, EventArgs e)
    {

    }
    protected void btnSaveAttendClassDate_Click(object sender, EventArgs e)
    {
        int classID = Convert.ToInt32(lblClassID.Text);

        var data = (from c in dcTraining.trTrainingDetailM
                    where c.iAutoKey == classID
                    select c).FirstOrDefault();

        if (data != null)
        {
            lbAttendClassDate.Items.Sort(new MyComparer());
            if (lbAttendClassDate.Items.Count == 1)
            {
                data.dDateA = DateTime.Parse(lbAttendClassDate.Items[0].Value);
                data.dDateD = DateTime.Parse(lbAttendClassDate.Items[0].Value);
            }
            else if (lbAttendClassDate.Items.Count > 1)
            {
                data.dDateA = DateTime.Parse(lbAttendClassDate.Items[0].Value);
                data.dDateD = DateTime.Parse(lbAttendClassDate.Items[lbAttendClassDate.Items.Count - 1].Value);
            }

            data.iSession = Convert.ToInt32(txtSession.Text);
            data.iLowLimitP = Convert.ToInt32(txtDownPeople.Text);
            data.iUpLimitP = Convert.ToInt32(txtUpPeople.Text);
            data.iJobScore = Convert.ToInt32(txtJobScore.Text);
            data.bIsNeedClassRpt = cbIsNeedClassRpt.Checked;
            data.bIsNeedStudentScore = cbIsNeedStudentScore.Checked;
            data.IsManagerScoreStudentClassReport = cbIsManagerScoreStudentClassReport.Checked;

            //data.CourseType = cbxCourseType.SelectedValue;
            //選擇課程類型
            if (cbxCourseType.SelectedValue.Equals(""))
                data.CourseType = null;
            else
                data.CourseType = cbxCourseType.SelectedValue;

            if (ntbClassRptDateSpan.Value.HasValue)
                data.iClassRptDateSpan = Convert.ToInt32(ntbClassRptDateSpan.Value);
            else
                data.iClassRptDateSpan = 0;

            if (ntbStudentScoreDateSpan.Value.HasValue)
                data.iStudentScoreDateSpan = Convert.ToInt32(ntbStudentScoreDateSpan.Value);
            else
                data.iStudentScoreDateSpan = 0;


            if (rdtpStudentScoreDeadLine.SelectedDate.HasValue && cbIsNeedStudentScore.Checked)
                data.dStudentScoreDeadline = rdtpStudentScoreDeadLine.SelectedDate.Value;
            else
                data.dStudentScoreDeadline = null;

            if (rdtpClassRptDeadLine.SelectedDate.HasValue && cbIsNeedClassRpt.Checked)
                data.dClassRptDeadline = rdtpClassRptDeadLine.SelectedDate.Value;
            else
                data.dClassRptDeadline = null;

            if (ntb_iCourseTime.Text.Length > 0)
                data.iCourseTime = Convert.ToInt32(Convert.ToDouble(ntb_iCourseTime.Text) * 60);
            else
                data.iCourseTime = 0;

            //內外訓
            data.trTrainingMethod_sCode = cbxTrainingMethod.SelectedValue;

            //內外師
            data.trTeacher_sCode = cbxTeacherType.SelectedValue;

            //處理選擇listbox日期的部分
            var attendClassDate = (from c in dcTraining.trAttendClassDate
                                   where c.iClassAutoKey == classID
                                   select c).ToList();

            foreach (var classDate in attendClassDate)
            {

                var item = (from c in lbAttendClassDate.Items
                            where c.Value == classDate.dClassDate.ToShortDateString()
                            select c).FirstOrDefault();
                //資料庫有這天開課，且選擇的選單也有，則先替除掉listbox中的選項，最後listbox剩下來的
                //就是需要新增的開課日
                if (item != null)
                {
                    lbAttendClassDate.Items.Remove(item);
                }
                else //資料庫有，但listbox沒有，則砍掉資料庫那筆
                {
                    //砍掉此開課日
                    dcTraining.trAttendClassDate.DeleteOnSubmit(classDate);
                    //砍掉開課日的上課地點
                    var place = from c in dcTraining.trAttendClassPlace
                                where c.dClassDate == classDate.dClassDate
                                && c.iClassAutoKey == classDate.iClassAutoKey
                                select c;
                    dcTraining.trAttendClassPlace.DeleteAllOnSubmit(place);

                    //砍掉開課日的上課講師
                    var teacher = from c in dcTraining.trAttendClassTeacher
                                  where c.dClassDate == classDate.dClassDate
                                  && c.iClassAutoKey == classDate.iClassAutoKey
                                  select c;
                    dcTraining.trAttendClassTeacher.DeleteAllOnSubmit(teacher);
                }
            }

            foreach (RadListBoxItem item in lbAttendClassDate.Items)
            {
                trAttendClassDate obj = new trAttendClassDate();
                obj.dClassDate = DateTime.Parse(item.Value);
                obj.iClassAutoKey = classID;
                obj.dKeyDate = DateTime.Now;
                obj.sKeyMan = User.Identity.Name;
                dcTraining.trAttendClassDate.InsertOnSubmit(obj);
            }

            dcTraining.SubmitChanges();

            loadAttendClassDate(data);
        }
    }
    protected void gvClassTime_ItemDataBound(object sender, GridItemEventArgs e)
    {
        //Bind("iAttendMins")
        if (e.Item is GridDataItem)
        {
            GridDataItem item = (GridDataItem)e.Item;

            RadNumericTextBox ntb = item["CourseTime"].FindControl("ntbiAttendMins") as RadNumericTextBox;
            if (ntb.Text.Length > 0)
            {
                ntb.Text = ((Double)(Convert.ToDouble(ntb.Text) / 60)).ToString();
            }
        }
    }

    private void saveTimeItem(GridCommandEventArgs e, DateTime dtA, DateTime dtD, int attendClassKey, bool countClassTime)
    {
        var obj = (from c in dcTraining.trAttendClassDate
                   where c.iAutoKey == Convert.ToInt32(attendClassKey)
                   select c).FirstOrDefault();

        if (obj != null)
        {
            //TimePicker選的是當天的日期，所以要把日期換成上課日，時間則套用選擇的
            obj.dClassDateA = new DateTime(obj.dClassDate.Year, obj.dClassDate.Month, obj.dClassDate.Day, dtA.Hour, dtA.Minute, 0);
            obj.dClassDateD = new DateTime(obj.dClassDate.Year, obj.dClassDate.Month, obj.dClassDate.Day, dtD.Hour, dtD.Minute, 0);

            if (obj.dClassDateA.Value > obj.dClassDateD.Value)
            {
                //Show("時間輸入有誤");
                RadAjaxPanel1.Alert("時間輸入有誤");
                (e.Item.Cells[2].FindControl("tpTimeA") as RadTimePicker).Clear();
                (e.Item.Cells[4].FindControl("tpTimeD") as RadTimePicker).Clear();
                return;
            }

            //上課時間
            int iAttendMins = 0;
            //自動計算上課時間
            if (countClassTime)
            {
                TimeSpan ts = dtD - dtA;
                iAttendMins = Convert.ToInt32(ts.TotalMinutes);
                obj.iAttendMins = iAttendMins;
            }
            else//上課時間輸入多少就存多少
            {
                double hour = 0;
                RadNumericTextBox ntb = e.Item.Cells[5].FindControl("ntbiAttendMins") as RadNumericTextBox;
                double.TryParse(ntb.Text, out hour);

                obj.iAttendMins = Convert.ToInt32(hour * 60);
            }

            dcTraining.SubmitChanges();
        }
    }

    protected void gvClassTime_ItemCommand(object sender, GridCommandEventArgs e)
    {
        //e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["iAutoKey"], e.Item.ItemIndex);

        string key = e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["iAutoKey"].ToString();
        int attendClassKey = Convert.ToInt32(key);

        if (e.CommandName == "Save")
        {
            DateTime dtA, dtD;

            //如果開始時間跟結束時間都有設定
            //StartTime,EndTime
            if ((e.Item.Cells[2].FindControl("tpTimeA") as RadTimePicker).SelectedDate.HasValue
                && (e.Item.Cells[4].FindControl("tpTimeD") as RadTimePicker).SelectedDate.HasValue)
            {
                dtA = (e.Item.Cells[2].FindControl("tpTimeA") as RadTimePicker).SelectedDate.Value;
                dtD = (e.Item.Cells[4].FindControl("tpTimeD") as RadTimePicker).SelectedDate.Value;
                saveTimeItem(e, dtA, dtD, attendClassKey, false);

                gvClassTime.Rebind();
            }
            //如果開始時間有選，結束時間沒選的話，結束就帶預設的課程時間
            else if ((e.Item.Cells[2].FindControl("tpTimeA") as RadTimePicker).SelectedDate.HasValue
                && !(e.Item.Cells[4].FindControl("tpTimeD") as RadTimePicker).SelectedDate.HasValue)
            {
                dtA = (e.Item.Cells[2].FindControl("tpTimeA") as RadTimePicker).SelectedDate.Value;

                var obj = (from c in dcTraining.trTrainingDetailM
                           where c.iAutoKey == Convert.ToInt32(lblClassID.Text)
                           select c).FirstOrDefault();
                if (obj != null)
                {
                    if (obj.iCourseTime.HasValue)
                    {
                        dtD = dtA.AddMinutes(obj.iCourseTime.Value);
                        saveTimeItem(e, dtA, dtD, attendClassKey, true);
                        gvClassTime.Rebind();
                    }
                    else
                    {
                        //Show("尚未設定課程時間");
                        RadAjaxPanel1.Alert("尚未設定課程時間");
                        return;
                    }
                }
            }
            else
            {
                //Show("時間輸入有誤");
                RadAjaxPanel1.Alert("時間輸入有誤");
                (e.Item.Cells[2].FindControl("tpTimeA") as RadTimePicker).Clear();
                (e.Item.Cells[4].FindControl("tpTimeD") as RadTimePicker).Clear();
            }


            if (GetRequestQueryStringValue("MODE").Equals("SUPER"))
            {
                trTrainingDetailM_Repo tdmRepo = new trTrainingDetailM_Repo();
                trTrainingDetailM tdm = tdmRepo.GetByPK(Convert.ToInt32(lblClassID.Text));
                Course course = new Course();
                course.SetCourseStartTimeEndTime(tdm);

                QAMaster_Repo qamRepo = new QAMaster_Repo(tdmRepo.dc);

                //結束時間提早，問卷時間應該也要提早可填寫
                qamRepo.SetFillFormDatetimeB_ByClassID(tdm.iAutoKey , tdm.dDateTimeD.Value);

                tdmRepo.Update(tdm);
                tdmRepo.Save();
            }
        }
    }

    protected void btnAddPlace_Click(object sender, EventArgs e)
    {
        if (lblClassBDate1.Text.Length > 0)
        {
            pnlSetPlace.Visible = true;
            pnlPlace.Visible = false;
        }
        else
            RadAjaxPanel1.Alert("未設定開課日期");
        //Show("未設定開課日期");
    }
    protected void btnAddTeacher_Click(object sender, EventArgs e)
    {
        if (lblClassBDate0.Text.Length > 0)
        {
            pnlSetTeacher.Visible = true;
            pnlTeacher.Visible = false;
        }
        else
            RadAjaxPanel1.Alert("未設定開課日期");
        //Show("未設定開課日期");
    }
    protected void btnAttendClassTeacherSave_Click(object sender, EventArgs e)
    {
        GridItemCollection items = gvTeacherList.SelectedItems;

        foreach (GridItem item in items)
        {
            //如果都尚未設定，就將尚未設定天數都帶講師進去
            if (cbDefaultAttendTeacher.Checked)
            {
                trAttendClassTeacher_Repo actRepo = new trAttendClassTeacher_Repo();
                List<trAttendClassTeacher> actList = actRepo.GetByClassKey(Convert.ToInt32(lblClassID.Text));

                List<trAttendClassDate> acdList = new List<trAttendClassDate>();
                trAttendClassDate_Repo acdRepo = new trAttendClassDate_Repo();
                acdList = acdRepo.GetByClassKey(Convert.ToInt32(lblClassID.Text));

                var exList = (from c in acdList where !actList.Select(p => p.dClassDate).Contains(c.dClassDate) select c).ToList();

                foreach (var ex in exList)
                {
                    trAttendClassTeacher obj = new trAttendClassTeacher();
                    obj.iClassAutoKey = Convert.ToInt32(lblClassID.Text);
                    obj.sTeacherCode = item.Cells[5].Text;
                    obj.dClassDate = ex.dClassDate;
                    obj.dKeyDate = DateTime.Now;
                    obj.sKeyMan = User.Identity.Name;
                    dcTraining.trAttendClassTeacher.InsertOnSubmit(obj);
                }
            }
            else
            {
                var p = (from c in dcTraining.trAttendClassTeacher
                         where c.iClassAutoKey == Convert.ToInt32(lblClassID.Text)
                         && c.dClassDate == DateTime.Parse(cbxAttendDateTeacher.SelectedValue)
                         && c.sTeacherCode == item.Cells[5].Text
                         select c).FirstOrDefault();

                if (p == null)
                {
                    trAttendClassTeacher obj = new trAttendClassTeacher();
                    obj.iClassAutoKey = Convert.ToInt32(lblClassID.Text);
                    obj.sTeacherCode = item.Cells[5].Text;
                    obj.dClassDate = DateTime.Parse(cbxAttendDateTeacher.SelectedValue);
                    obj.dKeyDate = DateTime.Now;
                    obj.sKeyMan = User.Identity.Name;

                    dcTraining.trAttendClassTeacher.InsertOnSubmit(obj);
                }
            }
        }

        dcTraining.SubmitChanges();
        gvTeacher.Rebind();
        pnlSetTeacher.Visible = false;
        pnlTeacher.Visible = true;
    }

    protected void btnAttendClassTeacherCancel_Click(object sender, EventArgs e)
    {
        pnlSetTeacher.Visible = false;
        pnlTeacher.Visible = true;
    }
    protected void btnAddMember_Click(object sender, EventArgs e)
    {
        pnlAddMember.Visible = true;
    }
    protected void btnCheckMember_Click(object sender, EventArgs e)
    {
        pnlAddMember.Visible = false;
    }

    protected void rblSet_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rblSet.SelectedValue == "M")
        {
            gvTeachingMaterialList.Visible = true;
        }
        else
        {
            gvTeachingMaterialList.Visible = false;
        }
    }
    protected void gvTeachingMaterialList_SelectedIndexChanged(object sender, EventArgs e)
    {
        lblMaterialCode.Text = gvTeachingMaterialList.SelectedValue.ToString();

    }

    protected void btnMaterialSave_Click(object sender, EventArgs e)
    {
        var cls = (from c in dcTraining.trTrainingDetailM
                   where
                       c.iAutoKey == Convert.ToInt32(lblClassID.Text)
                   select c).FirstOrDefault();

        if (cls != null)
        {
            cls.sMaterialKeyMan = User.Identity.Name;
            cls.dMaterialKeyDate = DateTime.Now;
            cls.sMaterialSelector = rblSet.SelectedValue;
            if (rblSet.SelectedValue == "M")
            {
                if (lblMaterialCode.Text.Trim().Length > 0)
                {
                    cls.iMaterialAutoKey = Convert.ToInt32(lblMaterialCode.Text);
                }
                else
                {
                    return;
                }
            }
            else
            {
                cls.iMaterialAutoKey = 0;
            }

            dcTraining.SubmitChanges();
            loadMaterial(cls);
        }
    }
    protected void gvTeachingMaterialList_ItemDataBound(object sender, GridItemEventArgs e)
    {
        if (e.Item is GridDataItem)
        {
            e.Item.Cells[5].Text = e.Item.Cells[5].Text.Replace(System.Environment.NewLine, "<br>");
            e.Item.Cells[6].Text = e.Item.Cells[6].Text.Replace(System.Environment.NewLine, "<br>");
        }
    }
    protected void btnAddItem_Click(object sender, EventArgs e)
    {
        gvNotifyItem.Visible = true;
    }
    protected void gvNotifyItem_SelectedIndexChanged(object sender, EventArgs e)
    {
        var data = (from c in dcTraining.trNotifyItem
                    where
                        c.iAutokey == Convert.ToInt32(gvNotifyItem.SelectedValue)
                    select c).FirstOrDefault();

        int classID = Convert.ToInt32(lblClassID.Text);
        ;

        var classOjb = (from c in dcTraining.trTrainingDetailM
                        where c.iAutoKey == classID
                        select c).FirstOrDefault();

        if (data != null)
        {
            trClassNotify obj = new trClassNotify();
            obj.iClassAutoKey = classID;
            obj.iNotifyItemAutoKey = data.iAutokey;
            obj.iTimespan = data.iTimespan;
            obj.dKeyDate = DateTime.Now;
            obj.sKeyMan = User.Identity.Name;

            if (classOjb.dDateA.HasValue)
            {
                obj.dNotifyDate = classOjb.dDateA.Value.AddDays(obj.iTimespan);
            }

            dcTraining.trClassNotify.InsertOnSubmit(obj);
            dcTraining.SubmitChanges();
            gvClassNotify.Rebind();
        }


    }
    protected void btnSaveClassNotify_Click(object sender, EventArgs e)
    {
        foreach (GridDataItem item in gvClassNotify.Items)
        {
            int key = Convert.ToInt32(item.GetDataKeyValue("iAutoKey").ToString());

            var data = (from c in dcTraining.trClassNotify
                        where c.iAutoKey == key
                        select c).FirstOrDefault();

            var classOjb = (from c in dcTraining.trTrainingDetailM
                            where c.iAutoKey == Convert.ToInt32(lblClassID.Text)
                            select c).FirstOrDefault();

            if (data != null)
            {
                RadNumericTextBox ntb = item.Cells[3].FindControl("ntb_iTimespan") as RadNumericTextBox;
                if (ntb != null)
                {
                    data.iTimespan = Convert.ToInt32(ntb.Text);

                    if (classOjb.dDateA.HasValue)
                    {
                        data.dNotifyDate = classOjb.dDateA.Value.AddDays(data.iTimespan);
                    }

                    dcTraining.SubmitChanges();
                }
            }
        }

        gvClassNotify.Rebind();
    }
    protected void btnAddNotifyTpl_Click(object sender, EventArgs e)
    {
        string sCode = cbxNotifyTpl.SelectedValue;

        var dataList = (from c in dcTraining.trNotifyTemplateDetail
                        join i in dcTraining.trNotifyItem
                        on c.NotifyItem_iAutokey equals i.iAutokey
                        where c.sCode == sCode
                        select new
                        {
                            c,
                            i
                        }).ToList();

        int classID = Convert.ToInt32(lblClassID.Text);

        var classOjb = (from c in dcTraining.trTrainingDetailM
                        where c.iAutoKey == classID
                        select c).FirstOrDefault();

        foreach (var data in dataList)
        {
            trClassNotify obj = new trClassNotify();

            obj.iTimespan = 0;

            obj.iClassAutoKey = classID;
            obj.iNotifyItemAutoKey = data.c.NotifyItem_iAutokey;

            if (data.c.iTimespanT.HasValue)
                obj.iTimespan = data.c.iTimespanT.Value;

            obj.sKeyMan = User.Identity.Name;
            obj.dKeyDate = DateTime.Now;

            if (classOjb.dDateA.HasValue)
            {
                obj.dNotifyDate = classOjb.dDateA.Value.AddDays(obj.iTimespan);
            }

            dcTraining.trClassNotify.InsertOnSubmit(obj);
        }

        dcTraining.SubmitChanges();

        gvClassNotify.Rebind();
    }


    protected void gvCostItem_SelectedIndexChanged(object sender, EventArgs e)
    {
        int classID = Convert.ToInt32(lblClassID.Text);
        ;

        var data = (from c in dcTraining.trTrainingEstimateCost
                    where c.trCostItem_sCode == gvCostItem.SelectedValue
                    && c.iClassAutoKey == classID
                    select c).FirstOrDefault();

        if (data == null)
        {
            trTrainingEstimateCost obj = new trTrainingEstimateCost();
            obj.iClassAutoKey = classID;
            obj.iAmt = 0;
            obj.trCostItem_sCode = gvCostItem.SelectedValue.ToString();
            obj.dKeyDate = DateTime.Now;
            obj.sKeyMan = User.Identity.Name;
            dcTraining.trTrainingEstimateCost.InsertOnSubmit(obj);
            dcTraining.SubmitChanges();
            //gvClassNotify.Rebind();
            gvEstimateAmt.Rebind();
            RadAjaxPanel1.Alert("新增完成");
            //Show("新增完成");
        }
    }
    protected void gvEstimateAmt_ItemDeleted(object sender, GridDeletedEventArgs e)
    {
        saveClassEstimateAmt();
        trTrainingDetailM tdm = tdmRepo.GetByKey_DLO(Convert.ToInt32(lblClassID.Text));
        loadEstimatesAMT(tdm);
    }
    protected void btnLoadMustTraining_Click(object sender, EventArgs e)
    {
        var classObj = (from c in dcTraining.trTrainingDetailM
                        where c.iAutoKey == Convert.ToInt32(lblClassID.Text)
                        select c).FirstOrDefault();


        //離線式處理使用者資料
        var userList = (from b in dcTraining.BASE
                        join t in dcTraining.BASETTS on b.NOBR equals t.NOBR
                        join d in dcTraining.DEPT on t.DEPT equals d.D_NO
                        where DateTime.Now.Date >= t.ADATE && DateTime.Now.Date <= t.DDATE &&
                        DateTime.Now.Date >= d.ADATE && DateTime.Now.Date <= d.DDATE &&//部門也要過濾失效的
                        new string[] { "1", "4", "6" }.Contains(t.TTSCODE)
                        select new
                        {
                            b,
                            t,
                            d
                        }).ToList();

        //目前這堂課，所有學員的名單，離線式處理
        var studentList = (from c in dcTraining.trTrainingStudentM
                           where
                               c.iClassAutoKey == classObj.iAutoKey
                           select c).ToList();

        if (rblMemberSelect.SelectedValue == "Course")
        {
            var trainingUnitList = (from c in dcTraining.trTrainingPlanRequiredUnit
                                    where c.sMode == "Course" &&
                                    c.sCode == classObj.trCourse_sCode
                                    select c).ToList();

            foreach (var trainingUnit in trainingUnitList)
            {
                var dataList = (from c in userList
                                where c.t.DEPT == trainingUnit.dept_sCode
                                && c.t.JOB == trainingUnit.job_sCode
                                select c).ToList();

                foreach (var c in dataList)
                {
                    var student = (from s in studentList
                                   where
                                       s.sNobr == c.b.NOBR
                                       && s.iClassAutoKey == classObj.iAutoKey
                                   select s).FirstOrDefault();

                    if (student == null)
                    {
                        trTrainingStudentM obj = new trTrainingStudentM();
                        obj.iClassAutoKey = classObj.iAutoKey;
                        obj.sDeptCode = c.t.DEPT;
                        obj.sJobCode = c.t.JOB;
                        obj.sJobsCode = c.t.JOBS;
                        obj.sJoblCode = c.t.JOBL;
                        obj.bPass = false;
                        obj.sNobr = c.b.NOBR;
                        obj.dKeyDate = DateTime.Now;
                        obj.sKeyMan = User.Identity.Name;
                        obj.trJoinType_sCode = "01";
                        dcTraining.trTrainingStudentM.InsertOnSubmit(obj);
                        dcTraining.SubmitChanges();
                    }
                }
            }
        }
        else//從類別載入
        {
            var category = (from c in dcTraining.trCategoryCourse
                            where c.sCourseCode == classObj.trCourse_sCode
                            select c).FirstOrDefault();

            if (category == null)
                return;


            var trainingUnitList = (from c in dcTraining.trTrainingPlanRequiredUnit
                                    where c.sMode == "Category" &&
                                    c.sCode == category.sCateCode
                                    select c).ToList();

            foreach (var trainingUnit in trainingUnitList)
            {
                var dataList = (from c in userList
                                where c.t.DEPT == trainingUnit.dept_sCode
                                && c.t.JOB == trainingUnit.job_sCode
                                select c).ToList();

                foreach (var c in dataList)
                {
                    var student = (from s in studentList
                                   where
                                       s.sNobr == c.b.NOBR
                                       && s.iClassAutoKey == classObj.iAutoKey
                                   select s).FirstOrDefault();

                    if (student == null)
                    {
                        trTrainingStudentM obj = new trTrainingStudentM();
                        obj.iClassAutoKey = classObj.iAutoKey;
                        obj.sDeptCode = c.t.DEPT;
                        obj.sJobCode = c.t.JOB;
                        obj.sJobsCode = c.t.JOBS;
                        obj.sJoblCode = c.t.JOBL;
                        obj.bPass = false;
                        obj.sNobr = c.b.NOBR;
                        obj.dKeyDate = DateTime.Now;
                        obj.sKeyMan = User.Identity.Name;

                        dcTraining.trTrainingStudentM.InsertOnSubmit(obj);
                        dcTraining.SubmitChanges();
                    }
                }
            }
        }
        gvTrainingStudentList.Rebind();
    }
    protected void rbtnJoin_SelectedIndexChanged(object sender, EventArgs e)
    {

        var Obj = (from c in dcTraining.trTrainingDetailM
                   where c.iAutoKey == Convert.ToInt32(lblClassID.Text)
                   select c).FirstOrDefault();


        if (rbtnJoin.SelectedValue == "y")
        {
            pnlWebAdd.Visible = true;

            //預設報名起日為輸入資料當天，迄日開課時間
            //m預設報名迄日為開課當天前一個小時
            dpBDate.SelectedDate = DateTime.Today;
            if (Obj.dDateTimeA.HasValue)
                dpEDate.SelectedDate = Convert.ToDateTime(Obj.dDateTimeA.Value.AddHours(-1));
            else
                dpEDate.SelectedDate = Convert.ToDateTime(Obj.dDateA.Value.AddDays(-1));
        }
        else
        {
            pnlWebAdd.Visible = false;

            if (Obj != null)
            {

                Obj.bWebJoin = false;
                Obj.dWebJoinDateB = null;
                Obj.dWebJoinDateE = null;

                dcTraining.SubmitChanges();
            }
        }
    }
    protected void RadButton7_Click(object sender, EventArgs e)
    {
        var obj = (from c in dcTraining.trTrainingDetailM
                   where c.iAutoKey == Convert.ToInt32(lblClassID.Text)
                   select c).FirstOrDefault();

        if (obj != null)
        {
            if (rbtnJoin.SelectedValue.ToUpper().Equals("Y"))
            {
                //Course courseFacade = new Course();
                //if (!courseFacade.IsValidWebDateTime(dpBDate.SelectedDate.Value, dpEDate.SelectedDate.Value, obj.dDateTimeA.Value))
                //{
                //    RadAjaxPanel1.Alert("網路報名時間有誤，請查看時間是否正確!!");
                //    return;
                //}

                obj.bWebJoin = true;
                obj.dWebJoinDateB = dpBDate.SelectedDate;
                obj.dWebJoinDateE = dpEDate.SelectedDate;
            }
            else
            {
                obj.bWebJoin = false;
                obj.dWebJoinDateB = null;
                obj.dWebJoinDateE = null;

            }

            dcTraining.SubmitChanges();

        }
        RadAjaxPanel1.Alert("已存檔");
    }


    protected void btnPublished_Click(object sender, EventArgs e)
    {
        var obj = (from c in dcTraining.trTrainingDetailM
                   where c.iAutoKey == Convert.ToInt32(lblClassID.Text)
                   select c).FirstOrDefault();

        if (obj == null)
            throw new ApplicationException("開課資料錯誤，請聯絡資訊人員");

        //是否允許線上報名，則必須要設時間
        if (rbtnJoin.SelectedValue == "y")
        {
            //如果有值就存，不然他有可能去改掉原本的時間卻沒存到
            if (dpBDate.SelectedDate.HasValue && dpEDate.SelectedDate.HasValue)
            {
                obj.bWebJoin = true;
                obj.dWebJoinDateB = dpBDate.SelectedDate;
                obj.dWebJoinDateE = dpEDate.SelectedDate;
                dcTraining.SubmitChanges();
            }
            else
            {
                //Show("請輸入線上報名日期");
                lblPublishMsg.Text = "請輸入線上報名日期";
                return;
            }
        }
        else
        {
            obj.bWebJoin = false;
            obj.dWebJoinDateB = null;
            obj.dWebJoinDateE = null;
            dcTraining.SubmitChanges();
        }

        try
        {
            Course courseFacade = new Course();
            courseFacade.PublishCourse(Convert.ToInt32(lblClassID.Text), User.Identity.Name);

            obj = courseFacade.CourseObj;
            loadAll(obj);
            changeMode("v");

            //Show("已發佈");

        }
        catch (Exception ex)
        {
            //Show(ex.Message);
            lblPublishMsg.Text = ex.Message;
        }
    }
    protected void btnAddTrainingUser_Click(object sender, EventArgs e)
    {
        int classID = Convert.ToInt32(lblClassID.Text);

        GridItemCollection items = gvUserList.SelectedItems;

        //目前這堂課，所有學員的名單
        var studentList = (from c in dcTraining.trTrainingStudentM
                           where c.iClassAutoKey == classID
                           select c).ToList();

        var teacherList = (from c in dcTraining.trAttendClassTeacher
                           join t in dcTraining.trTeacher on c.sTeacherCode equals t.sCode
                           where c.iClassAutoKey == classID
                           select new
                           {
                               c.sTeacherCode,
                               t.sNobr
                           }).ToList();

        foreach (GridItem item in items)
        {
            GridDataItem dItem = item as GridDataItem;
            var p = (from c in studentList
                     where c.sNobr == dItem["nobr"].Text
                     select c).FirstOrDefault();

            //如果此學員是講師的話，則不加入。
            var t = (from c in teacherList
                     where c.sNobr == dItem["nobr"].Text
                     select c).FirstOrDefault();

            if (t != null)
                continue;

            //沒有在目前學員清單的話
            if (p == null)
            {
                var tts = (from c in dcTraining.BASETTS
                           where
                               c.NOBR == dItem["nobr"].Text
                               && DateTime.Now.Date >= c.ADATE && DateTime.Now.Date <= c.DDATE &&
                               new string[] { "1", "4", "6" }.Contains(c.TTSCODE)
                           select c).FirstOrDefault();

                if (tts != null)
                {
                    trTrainingStudentM obj = new trTrainingStudentM();
                    obj.iClassAutoKey = Convert.ToInt32(lblClassID.Text);
                    obj.sDeptCode = tts.DEPT;
                    obj.sJobCode = tts.JOB;
                    obj.sJobsCode = tts.JOBS;
                    obj.sJoblCode = tts.JOBL;
                    obj.bPass = false;
                    obj.sNobr = dItem["nobr"].Text;
                    obj.trJoinType_sCode = "01";
                    obj.dKeyDate = DateTime.Now;
                    obj.sKeyMan = User.Identity.Name;
                    dcTraining.trTrainingStudentM.InsertOnSubmit(obj);
                    dcTraining.SubmitChanges();
                }
            }
        }

        var tdm = (from c in dcTraining.trTrainingDetailM
                   where c.iAutoKey == classID
                   select c).FirstOrDefault();
        tdm.iStudentNum = tdmRepo.GetLatestStudentNum(classID);
        dcTraining.SubmitChanges();

        gvTrainingStudentList.Rebind();
    }

    protected void cbIsPage_CheckedChanged(object sender, EventArgs e)
    {
        if (cbIsPage.Checked)
        {
            gvUserList.AllowPaging = true;
        }
        else
            gvUserList.AllowPaging = false;

        gvUserList.Rebind();
    }
    protected void btnCloneClass_Click(object sender, EventArgs e)
    {
        int selectedClassID = Convert.ToInt32(gvPastClass.SelectedValue);

        var cloneClassObj = (from c in dcTraining.trTrainingDetailM
                             where c.iAutoKey == Convert.ToInt32(lblClassID.Text)
                             select c).FirstOrDefault();

        if (cloneClassObj.bIsPublished)
        {
            RadAjaxPanel1.Alert("此課程已發佈，無法複製");
            //Show("此課程已發佈，無法複製");
            return;
        }
        else
        {
            var selectedClassObj = (from c in dcTraining.trTrainingDetailM
                                    where c.iAutoKey == selectedClassID
                                    select c).FirstOrDefault();

            //基本資料
            cloneClassObj.bWebJoin = selectedClassObj.bWebJoin;
            cloneClassObj.iActualAMT = selectedClassObj.iActualAMT;
            cloneClassObj.iCourseTime = selectedClassObj.iCourseTime;
            cloneClassObj.iJobScore = selectedClassObj.iJobScore;
            cloneClassObj.iLowLimitP = selectedClassObj.iLowLimitP;
            cloneClassObj.iMaterialAutoKey = selectedClassObj.iMaterialAutoKey;
            cloneClassObj.iUpLimitP = selectedClassObj.iUpLimitP;
            cloneClassObj.trClassroom_sCode = selectedClassObj.trClassroom_sCode;
            cloneClassObj.trTrainingMethod_sCode = selectedClassObj.trTrainingMethod_sCode;
            cloneClassObj.iEstimateAMT = selectedClassObj.iEstimateAMT;
            cloneClassObj.trTeacherType_sCode = selectedClassObj.trTeacherType_sCode;
            cloneClassObj.bIsNeedStudentScore = selectedClassObj.bIsNeedStudentScore;
            cloneClassObj.iStudentScoreDateSpan = selectedClassObj.iStudentScoreDateSpan;
            cloneClassObj.bIsNeedClassRpt = selectedClassObj.bIsNeedClassRpt;
            cloneClassObj.iClassRptDateSpan = selectedClassObj.iClassRptDateSpan;
            cloneClassObj.CourseType = selectedClassObj.CourseType;


            //clone訓練名單全部學員
            if (cblCopyItem.Items.FindByValue("trTrainingStudentM").Selected == true)
            {
                var studentList = (from c in dcTraining.trTrainingStudentM
                                   where c.iClassAutoKey == cloneClassObj.iAutoKey
                                   select c).ToList();

                dcTraining.trTrainingStudentM.DeleteAllOnSubmit(studentList);

                var selected_studentList = (from c in dcTraining.trTrainingStudentM
                                            where c.iClassAutoKey == selectedClassObj.iAutoKey
                                            select c).ToList();

                //這邊載入學員名單，只看工號，當時的部門資料，要另外查詢才塞進去，還要判斷離職否才載入
                foreach (var o in selected_studentList)
                {
                    var tts = (from c in dcTraining.BASETTS
                               where c.NOBR == o.sNobr
                          && DateTime.Now.Date >= c.ADATE && DateTime.Now.Date <= c.DDATE &&
                          new string[] { "1", "4", "6" }.Contains(c.TTSCODE)
                               select c).FirstOrDefault();

                    if (tts != null)
                    {
                        trTrainingStudentM obj = new trTrainingStudentM();
                        obj.iClassAutoKey = cloneClassObj.iAutoKey;
                        obj.sDeptCode = tts.DEPT;
                        obj.sJobCode = tts.JOB;
                        obj.sJobsCode = tts.JOBS;
                        obj.sJoblCode = tts.JOBL;
                        obj.bPass = false;
                        obj.sNobr = o.sNobr;
                        obj.trJoinType_sCode = "01";
                        obj.dKeyDate = DateTime.Now;
                        obj.sKeyMan = User.Identity.Name;
                        dcTraining.trTrainingStudentM.InsertOnSubmit(obj);
                        dcTraining.SubmitChanges();
                    }
                }
            }

            //clone訓練名單出席學員
            if (cblCopyItem.Items.FindByValue("PresenceStudents").Selected == true)
            {
                var studentList = (from c in dcTraining.trTrainingStudentM
                                   where c.iClassAutoKey == cloneClassObj.iAutoKey
                                   select c).ToList();

                dcTraining.trTrainingStudentM.DeleteAllOnSubmit(studentList);

                var selected_studentList = (from c in dcTraining.trTrainingStudentM
                                            where c.iClassAutoKey == selectedClassObj.iAutoKey
                                            && c.bPresence
                                            select c).ToList();

                //這邊載入學員名單，只看工號，當時的部門資料，要另外查詢才塞進去，還要判斷離職否才載入
                foreach (var o in selected_studentList)
                {
                    var tts = (from c in dcTraining.BASETTS
                               where c.NOBR == o.sNobr
                          && DateTime.Now.Date >= c.ADATE && DateTime.Now.Date <= c.DDATE &&
                          new string[] { "1", "4", "6" }.Contains(c.TTSCODE)
                               select c).FirstOrDefault();

                    if (tts != null)
                    {
                        trTrainingStudentM obj = new trTrainingStudentM();
                        obj.iClassAutoKey = cloneClassObj.iAutoKey;
                        obj.sDeptCode = tts.DEPT;
                        obj.sJobCode = tts.JOB;
                        obj.sJobsCode = tts.JOBS;
                        obj.sJoblCode = tts.JOBL;
                        obj.bPass = false;
                        obj.sNobr = o.sNobr;
                        obj.trJoinType_sCode = "01";
                        obj.dKeyDate = DateTime.Now;
                        obj.sKeyMan = User.Identity.Name;
                        dcTraining.trTrainingStudentM.InsertOnSubmit(obj);
                        dcTraining.SubmitChanges();
                    }
                }
            }

            //clone結訓條件
            if (cblCopyItem.Items.FindByValue("knotTeaches").Selected == true)
            {
                var knotTeachesList = (from c in dcTraining.trTrainingDetailS
                                       where c.iClassAutoKey == cloneClassObj.iAutoKey
                                       select c).ToList();

                dcTraining.trTrainingDetailS.DeleteAllOnSubmit(knotTeachesList);

                var selected_knotTeachesList = (from c in dcTraining.trTrainingDetailS
                                                where c.iClassAutoKey == selectedClassObj.iAutoKey
                                                select c).ToList();

                foreach (var o in selected_knotTeachesList)
                {
                    trTrainingDetailS obj = new trTrainingDetailS();
                    obj.iClassAutoKey = cloneClassObj.iAutoKey;
                    obj.trKnotTeaches_sCode = o.trKnotTeaches_sCode;
                    obj.sKeyMan = User.Identity.Name;
                    obj.dKeyDate = DateTime.Now;
                    dcTraining.trTrainingDetailS.InsertOnSubmit(obj);
                }
            }

            //clone流程通知項目
            if (cblCopyItem.Items.FindByValue("classNotify").Selected == true)
            {
                var classNotifyList = (from c in dcTraining.trClassNotify
                                       where c.iClassAutoKey == cloneClassObj.iAutoKey
                                       select c).ToList();
                dcTraining.trClassNotify.DeleteAllOnSubmit(classNotifyList);

                var selected_classNotifyList = (from c in dcTraining.trClassNotify
                                                where c.iClassAutoKey == selectedClassObj.iAutoKey
                                                select c).ToList();

                foreach (var o in selected_classNotifyList)
                {
                    trClassNotify obj = new trClassNotify();
                    obj.iClassAutoKey = cloneClassObj.iAutoKey;
                    obj.iNotifyItemAutoKey = o.iNotifyItemAutoKey;
                    obj.iTimespan = o.iTimespan;
                    obj.dKeyDate = DateTime.Now;
                    obj.sKeyMan = User.Identity.Name;
                    dcTraining.trClassNotify.InsertOnSubmit(obj);
                }
            }

            //clone預估費用
            if (cblCopyItem.Items.FindByValue("estimateAMT").Selected == true)
            {
                var estimateAMTList = (from c in dcTraining.trTrainingEstimateCost
                                       where c.iClassAutoKey == cloneClassObj.iAutoKey
                                       select c).ToList();
                dcTraining.trTrainingEstimateCost.DeleteAllOnSubmit(estimateAMTList);

                var selEstimateCost = (from c in dcTraining.trTrainingEstimateCost
                                       where c.iClassAutoKey == selectedClassObj.iAutoKey
                                       select c).ToList();

                foreach (var o in selEstimateCost)
                {
                    trTrainingEstimateCost obj = new trTrainingEstimateCost();
                    obj.iClassAutoKey = cloneClassObj.iAutoKey;
                    obj.iAmt = o.iAmt;
                    obj.trCostItem_sCode = o.trCostItem_sCode;
                    obj.sKeyMan = User.Identity.Name;
                    obj.dKeyDate = DateTime.Now;
                    dcTraining.trTrainingEstimateCost.InsertOnSubmit(obj);
                }
            }

            //clone問卷
            if (cblCopyItem.Items.FindByValue("問卷").Selected == true)
            {
                var Questionary = (from c in dcTraining.ClassQuestionnaire
                                   where c.iClassAutoKey == cloneClassObj.iAutoKey
                                   select c).ToList();
                dcTraining.ClassQuestionnaire.DeleteAllOnSubmit(Questionary);

                var selectedClassQuestionaryList = (from c in dcTraining.ClassQuestionnaire
                                                    where c.iClassAutoKey == selectedClassObj.iAutoKey
                                                    select c).ToList();

                foreach (var l in selectedClassQuestionaryList)
                {
                    ClassQuestionnaire obj = new ClassQuestionnaire();
                    obj.iClassAutoKey = cloneClassObj.iAutoKey;
                    obj.qQuestionaryM = l.qQuestionaryM;
                    obj.qTypeCode = l.qTypeCode;
                    obj.sKeyMan = l.sKeyMan;
                    obj.dKeyDate = l.dKeyDate;
                    dcTraining.ClassQuestionnaire.InsertOnSubmit(obj);
                }
            }

            //commit all
            dcTraining.SubmitChanges();

            gvTrainingStudentList.Rebind();
            gvClassNotify.Rebind();
            gvKnotTeachesList.Rebind();
            gvEstimateAmt.Rebind();
            gvQList.Rebind();
            loadAll(cloneClassObj);
            RadAjaxPanel1.Alert("複製完成");
            //Show("複製完成");
        }
    }

    protected void btnFileUpload_Click(object sender, EventArgs e)
    {
        if (IsRefresh)
        {
            return;
        }

        for (int i = 0; i < ul.UploadedFiles.Count; i++)
        {
            UPLOAD obj = new UPLOAD();

            Guid guid = Guid.NewGuid();
            obj.FileCategory = "TeachingMaterial";
            obj.FileStoredPath = @"~\UPLOAD\" + obj.FileCategory + @"\";

            obj.FileNote = tbFileNote.Text;
            obj.FileCategoryKey = lblClassID.Text;
            obj.FileKeyDate = DateTime.Now;
            obj.FileKeyMan = User.Identity.Name;
            obj.FileNameExt = ul.UploadedFiles[i].GetExtension();
            obj.FileOriginName = ul.UploadedFiles[i].FileName;
            obj.FileSize = ul.UploadedFiles[i].ContentLength;
            obj.FileStoredName = guid.ToString();

            if (!Directory.Exists(Server.MapPath(obj.FileStoredPath)))
            {
                Directory.CreateDirectory(Server.MapPath(obj.FileStoredPath));
            }

            ul.UploadedFiles[i].SaveAs(Server.MapPath(obj.FileStoredPath) + guid.ToString());

            if (File.Exists(Server.MapPath(obj.FileStoredPath) + guid.ToString()))
            {
                dcTraining.UPLOAD.InsertOnSubmit(obj);
                dcTraining.SubmitChanges();
                gvTeachingMaterial.Rebind();
                RadAjaxPanel1.Alert("上傳完成");
                //Show("上傳完成");
            }
        }
    }
    protected void btnUnpublished_Click(object sender, EventArgs e)
    {
        var obj = (from c in dcTraining.trTrainingDetailM
                   where c.iAutoKey == Convert.ToInt32(lblClassID.Text)
                   select c).FirstOrDefault();

        if (obj == null)
            throw new ApplicationException("課程編號錯誤");

        if (GetRequestQueryStringValue("MODE").Equals("SUPER"))
        {
            cancelPublishCourse(obj);
            return;
        }

        if (obj.dDateTimeA >= DateTime.Now)
        {
            cancelPublishCourse(obj);
            return;
        }
        else
        {
            RadAjaxPanel1.Alert("課程已開始，無法取消");
        }
    }

    private void cancelPublishCourse(trTrainingDetailM obj)
    {
        obj.bIsPublished = false;
        dcTraining.SubmitChanges();
        changeMode("e");
        //Show("已取消發佈");
        RadAjaxPanel1.Alert("已取消發佈");
        loadWebJoin(obj);
    }

    //問卷存檔
    protected void btnCheckQ_Click(object sender, EventArgs e)
    {
        GridDataItemCollection items = gvQList.Items;
        foreach (GridDataItem item in items)
        {
            if (item.Selected == true && item["qQuestionaryM"].Text.Trim().Length == 0)
            {
                ClassQuestionnaire obj = new ClassQuestionnaire();
                obj.iClassAutoKey = Convert.ToInt32(Request.QueryString["ID"].ToString());
                obj.qQuestionaryM = item["Code"].Text.ToString();
                obj.qTypeCode = obj.qQuestionaryM + obj.iClassAutoKey.ToString();
                obj.sKeyMan = User.Identity.Name;
                obj.dKeyDate = DateTime.Now;

                dcTraining.ClassQuestionnaire.InsertOnSubmit(obj);

                //如果是Super Mode就產生問卷
                if (GetRequestQueryStringValue("MODE").Equals("SUPER"))
                {
                    QAMaster_Repo mRepo = new QAMaster_Repo();
                    mRepo.CreatedQA_ByClassQuestionnaire(obj);
                }
            }
            else if (item.Selected == false && item["qQuestionaryM"].Text.Trim().Length > 0)
            {
                var obj = (from c in dcTraining.ClassQuestionnaire
                           where c.iClassAutoKey == Convert.ToInt32(Request.QueryString["ID"].ToString())
                           && c.qQuestionaryM == item["Code"].Text.ToString()
                           select c).FirstOrDefault();

                if (obj != null)
                {
                    dcTraining.ClassQuestionnaire.DeleteOnSubmit(obj);
                    //處理Super Mode
                    if (GetRequestQueryStringValue("MODE").Equals("SUPER"))
                    {
                        QAMaster_Repo qamRepo = new QAMaster_Repo(dcTraining);
                        List<QAMaster> qamList = qamRepo.GetByClassQTpl_Dlo(obj.iClassAutoKey , obj.qQuestionaryM);

                        foreach ( var a in qamList )
                        {
                            qamRepo.Delete(a);
                        }   
                    }
                }
            }
        }

        lblMsgQues.Text = "已存檔";
        dcTraining.SubmitChanges();
        gvQList.Rebind();
    }
    protected void gvQList_ItemDataBound(object sender, GridItemEventArgs e)
    {
        if (e.Item is GridDataItem)
        {
            GridDataItem item = (GridDataItem)e.Item;

            if (item["qQuestionaryM"].Text.Trim().Length == 0)
            {
                item.Selected = false;
            }
            else
                item.Selected = true;

            Control control = item["View"].Controls[0];
            if (item["FillerCategory"].Text.Equals("CU"))
            {
                if (control != null)
                {
                    control.Visible = true;
                }
            }
            else
            {
                if (control != null)
                {
                    control.Visible = false;
                }
            }
        }
        //if (e.Item is GridDataItem || e.Item is GridHeaderItem)
        //{
        //    RadButton btnView = e.Item.FindControl("btnView") as RadButton;
        //    if (btnView != null)
        //    {
        //        //url = FileName + btnView.CommandName;
        //        string sCode = btnView.CommandArgument;
        //        btnView.Attributes["onclick"] = String.Format("return ShowViewForm('{0}');", url + "?sCode=" + sCode);
        //    }
        //}
    }

    protected void gvKnotTeachesList_ItemDataBound(object sender, GridItemEventArgs e)
    {
        if (e.Item is GridDataItem)
        {
            GridDataItem item = (GridDataItem)e.Item;
            if (item["trKnotTeaches_sCode"].Text.Trim().Length == 0)
            {
                item.Selected = false;
            }
            else
            {
                item.Selected = true;
            }
        }
    }
    protected void btnClassKnotTeaches_Click(object sender, EventArgs e)
    {
        GridDataItemCollection items = gvKnotTeachesList.Items;

        foreach (GridDataItem item in items)
        {
            if (item.Selected == true && item["trKnotTeaches_sCode"].Text.Trim().Length == 0)
            {
                trTrainingDetailS obj = new trTrainingDetailS();
                obj.dKeyDate = DateTime.Now;
                obj.sKeyMan = User.Identity.Name;
                obj.iClassAutoKey = Convert.ToInt32(Request.QueryString["ID"].ToString());
                obj.trKnotTeaches_sCode = item["KnotTeachesCode"].Text.Trim();
                dcTraining.trTrainingDetailS.InsertOnSubmit(obj);

            }
            else if (item.Selected == false && item["trKnotTeaches_sCode"].Text.Trim().Length > 0)
            {
                var obj = (from c in dcTraining.trTrainingDetailS
                           where c.iClassAutoKey == Convert.ToInt32(Request.QueryString["ID"].ToString())
                           && c.trKnotTeaches_sCode == item["trKnotTeaches_sCode"].Text.Trim()
                           select c).FirstOrDefault();

                dcTraining.trTrainingDetailS.DeleteOnSubmit(obj);
            }
        }

        lblMsgKnot.Text = "已存檔";

        dcTraining.SubmitChanges();
        gvKnotTeachesList.Rebind();
    }
    protected void gvTeachingMaterial_DeleteCommand(object sender, GridCommandEventArgs e)
    {
        //FileStoredName
        if (e.Item is GridDataItem)
        {
            GridDataItem item = (GridDataItem)e.Item;

            var obj = (from c in dcTraining.UPLOAD
                       where c.iAutoKey == Convert.ToInt32(item.OwnerTableView.DataKeyValues[item.ItemIndex]["iAutoKey"].ToString())
                       select c).FirstOrDefault();

            if (obj != null)
            {
                SiteHelper siteHelper = new SiteHelper();
                siteHelper.DeleteFile(obj);
                gvTeachingMaterial.Rebind();
            }
        }
    }
    protected void cbxAttendDateTeacher_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        //gvTeachingDateList.Rebind();
    }
    protected void ckxThisTeacher_CheckedChanged(object sender, EventArgs e)
    {
        if (ckxThisTeacher.Checked == true)
        {
            gvTeacherList.DataSourceID = "sdsExperiencedTeacher";
            gvTeacherList.DataBind();
        }
        else
        {
            gvTeacherList.DataSourceID = "sdsTeacherGv";
            gvTeacherList.DataBind();
        }
    }
    protected void btnAddC_Click(object sender, EventArgs e)
    {
        pnlCost.Visible = true;
        pnlECost.Visible = false;
    }
    protected void btnCostAdd_Click(object sender, EventArgs e)
    {
        pnlCost.Visible = false;
        pnlECost.Visible = true;
    }
    protected void btnCancelC_Click(object sender, EventArgs e)
    {
        pnlCost.Visible = false;
        pnlECost.Visible = true;
    }
    protected void btnNextStep1_Click(object sender, EventArgs e)
    {
        nextStep();
    }

    private void nextStep()
    {
        if (RadTabStrip1.SelectedIndex == RadTabStrip1.Tabs.Count - 1)
        {
            RadTabStrip1.SelectedIndex = 0;
        }
        else
        {
            RadTabStrip1.SelectedIndex = RadTabStrip1.SelectedIndex + 1;
        }

        //若有隱藏tab則忽略(跳下一個)
        if (RadTabStrip1.SelectedTab.Visible == false)
        {
            nextStep();
        }

        RadMultiPage1.PageViews[RadTabStrip1.SelectedTab.PageView.Index].Selected = true;
    }

    protected void gvClassTime_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
    {

    }
    protected void btnDelQualifier_Click(object sender, EventArgs e)
    {
        int classID = Convert.ToInt32(lblClassID.Text);
        var obj = (from c in dcTraining.trTrainingDetailM
                   where c.iAutoKey == classID
                   select c).FirstOrDefault();

        if (obj != null)
        {
            //有設定日期
            if (obj.dDateA.HasValue)
            {
                DoHelper doHelper = new DoHelper();
                var studentList = (from c in dcTraining.trTrainingStudentM
                                   where c.iClassAutoKey == obj.iAutoKey
                                   select c).ToList();

                foreach (var s in studentList)
                {
                    //如果已有資格者，則刪除
                    if (doHelper.isQualifier(obj.trCourse_sCode, s.sNobr, obj.dDateA.Value))
                    {
                        dcTraining.trTrainingStudentM.DeleteOnSubmit(s);
                    }
                }

                dcTraining.SubmitChanges();
                gvTrainingStudentList.Rebind();
            }
            else
            {
                RadAjaxPanel1.Alert("未設定開課日期");
                //Show("未設定開課日期");
                return;
            }

            obj.iStudentNum = tdmRepo.GetLatestStudentNum(classID);
            dcTraining.SubmitChanges();
        }
    }
    protected void btnCancelAddTrainingUser_Click(object sender, EventArgs e)
    {
        pnlAddMember.Visible = false;
    }
    protected void btnDelAllNotify_Click(object sender, EventArgs e)
    {
        var NotifyList = (from c in dcTraining.trClassNotify
                          where c.iClassAutoKey == Convert.ToInt32(lblClassID.Text)
                          select c).ToList();

        dcTraining.trClassNotify.DeleteAllOnSubmit(NotifyList);
        dcTraining.SubmitChanges();
        gvClassNotify.Rebind();
    }
    protected void gvQList_ItemCommand(object sender, GridCommandEventArgs e)
    {

        GridDataItem item = (GridDataItem)e.Item;

        if (e.CommandName.Equals("View"))
        {
            pnClassQnCU.Visible = true;
            lblQnView.Text = item["sCode"].Text;
            lblClassQnCUName.Text = item["sName"].Text;
            gvClassQnCU.Rebind();
        }
    }
    protected void btnAddClassQnCU_Click(object sender, EventArgs e)
    {
        if (lblQnView.Text.Trim().Length > 0)
        {
            winUser.VisibleOnPageLoad = true;

        }
        else
            RadAjaxPanel1.Alert("尚未選擇自訂使用者問卷");
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        int classID = Convert.ToInt32(lblClassID.Text);

        if (gvNobr.SelectedValue != null)
        {
            var cu = (from c in dcTraining.ClassQuestionnaireCU
                      where c.iClassAutoKey == classID
                      && c.qQuestionaryM == lblQnView.Text
                      && c.Nobr == gvNobr.SelectedValue
                      select c).FirstOrDefault();

            if (cu == null)
            {
                ClassQuestionnaireCU obj = new ClassQuestionnaireCU();
                obj.iClassAutoKey = classID;
                obj.Nobr = gvNobr.SelectedValue.ToString();
                ;
                obj.qQuestionaryM = lblQnView.Text;
                obj.dKeyDate = DateTime.Now;
                obj.sKeyMan = User.Identity.Name;
                dcTraining.ClassQuestionnaireCU.InsertOnSubmit(obj);
                dcTraining.SubmitChanges();
                gvClassQnCU.Rebind();
            }

        }

        winUser.VisibleOnPageLoad = true;
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        txtName.Text = "";
        gvNobr.Rebind();
        winUser.VisibleOnPageLoad = false;
    }
    protected void btnSearchNobr_Click(object sender, EventArgs e)
    {
        gvNobr.Rebind();
    }
    protected void btnCloseClassQnCU_Click(object sender, EventArgs e)
    {
        pnClassQnCU.Visible = false;
        winUser.VisibleOnPageLoad = false;
    }
    protected void gvTrainingStudentList_ItemDeleted(object sender, GridDeletedEventArgs e)
    {
        int classID = Convert.ToInt32(lblClassID.Text);
        var obj = (from c in dcTraining.trTrainingDetailM
                   where c.iAutoKey == classID
                   select c).FirstOrDefault();

        obj.iStudentNum = tdmRepo.GetLatestStudentNum(classID);
        dcTraining.SubmitChanges();
    }
    protected void btnSaveSammary_Click(object sender, EventArgs e)
    {
        trTrainingDetailM tdm = tdmRepo.GetByKey_DLO(Convert.ToInt32(lblClassID.Text));
        tdm.sCourseGoal = edtCourseGoal.Content;
        tdm.sCourseGoal2 = edtCourseGoal2.Content;
        tdm.PlanRequirement = edtPlanRequirement.Content;
        tdm.PlanStudentQualification = edtPlanStudentQualification.Content;
        tdm.PlanTrainingMethod = edtPlanTrainingMethod.Content;
        tdm.PlanComment = edtPlanComment.Content;

        tdmRepo.dc = new dcTrainingDataContext();
        tdmRepo.Update(tdm);
        tdmRepo.Save();
        loadCoursePlan(tdm);
    }
    protected void gvTrainingStudentList_ItemCommand(object sender, GridCommandEventArgs e)
    {
        if (e.CommandName.Equals("Delete"))
        {
            string key = e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["iAutoKey"].ToString();
            int intKey = Convert.ToInt32(key);

            trTrainingStudentM_Repo tsmRepo = new trTrainingStudentM_Repo();
            trTrainingStudentM tsmObj = tsmRepo.GetByPk(intKey);

            tsmRepo.DelStudent(tsmObj.iClassAutoKey, tsmObj.sNobr);
        }
    }
    protected void btnPlanDetailAddItem_Click(object sender, EventArgs e)
    {
        win.NavigateUrl = planDetailEditUrl + lblClassID.Text;
        win.Width = 900;
        win.Height =600;
        win.VisibleOnPageLoad = true;
    }


    protected void gvPlanDetail_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
    {
        if (e.RebindReason == GridRebindReason.ExplicitRebind)
        {
            CoursePlanDetail_Repo cpdRepo = new CoursePlanDetail_Repo();
            gvPlanDetail.DataSource = cpdRepo.GetCoursePlanDetailViewListByClassId_Dlo(Convert.ToInt32(lblClassID.Text));
        }
    }


    protected void RadAjaxPanel1_AjaxRequest(object sender, AjaxRequestEventArgs e)
    {
        if (e.Argument == "PlanDetail")
        {
            gvPlanDetail.Rebind();
            win.VisibleOnPageLoad = true;
        }
    }
    protected void gvPlanDetail_ItemCommand(object sender, GridCommandEventArgs e)
    {
        if (e.CommandName.Equals("Del"))
        {
            GridDataItem item = e.Item as GridDataItem;
            CoursePlanDetail_Repo cpdRepo = new CoursePlanDetail_Repo();
            var obj= cpdRepo.GetByPk(Convert.ToInt32(item["Id"].Text));
            cpdRepo.Delete(obj);
            cpdRepo.Save();
            gvPlanDetail.Rebind();
        }
    }
}
