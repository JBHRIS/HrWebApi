using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Telerik.Web.UI;
using Repo;
public partial class eTraining_Admin_Design_SetCourseDo : JBWebPage
{
    dcTrainingDataContext dcTraining = new dcTrainingDataContext();
    private trTrainingDetailM_Repo tdmRepo = new trTrainingDetailM_Repo();
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            if (Request.QueryString["ID"] != null)
            {
                RadTabStrip1.SelectedIndex = 0;
                this.Title = "執行清單";

                int id = Convert.ToInt32(Request.QueryString["ID"].ToString());

                var cls = tdmRepo.GetByKey_DLO(id);

                if (cls != null)
                {
                    lblID.Text = cls.iAutoKey.ToString();

                    lblClassName.Text = cls.trCourse.sName;
                    lblClassCode.Text = cls.trCourse.sCode;
                    loadClassData();
                }
                else
                    throw new Exception("參數不正確");
            }
            else
            {
                throw new Exception("無傳入參數");
            }

            //第一次進來，導到第一個頁面
            string urlPara = "?ID=" + Request.QueryString["ID"].ToString();
            RadMultiPage1.PageViews[0].Selected = true;
            pvContent.ContentUrl = "~/eTraining/Admin/Do/ClassInfo.aspx" + urlPara;

        }
    }

    private void loadClassData()
    {
        int id = Convert.ToInt32(lblID.Text);

        var cls = tdmRepo.GetByKey_DLO(id);
        if (cls != null)
        {

            lblClassName.Text = cls.trCourse.sName;
            lblClassCode.Text = cls.trCourse.sCode;

            //cbIsNeedClassRpt.Checked = cls.bIsNeedClassRpt;
            //cbIsNeedStudentScore.Checked = cls.bIsNeedStudentScore;

            //if (cls.bIsNeedClassRpt && cls.dClassRptDeadline.HasValue)
            //    rdtpClassRptDeadLine.SelectedDate = cls.dClassRptDeadline.Value;
            //else
            //    rdtpClassRptDeadLine.Clear();

            //if (cls.bIsNeedStudentScore && cls.dStudentScoreDeadline.HasValue)
            //    rdtpStudentScoreDeadLine.SelectedDate = cls.dStudentScoreDeadline.Value;
            //else
            //    rdtpStudentScoreDeadLine.Clear();

        }
        else
            throw new Exception("參數不正確");

    }


    //存檔開課資料檔的 EstimateAmt
    private void saveClassEstimateAmt()
    {
        var dataList = (from c in dcTraining.trTrainingEstimateCost
                        where c.iClassAutoKey == Convert.ToInt32(lblClassCode.Text)
                        select c).ToList();

        int iAmt = 0;

        foreach (var data in dataList)
        {
            iAmt = iAmt + data.iAmt;
        }

        var cls = (from c in dcTraining.trTrainingDetailM
                   where c.iAutoKey == Convert.ToInt32(lblClassCode.Text)
                   select c).FirstOrDefault();

        if (cls != null)
        {
            cls.iEstimateAMT = iAmt;
            dcTraining.SubmitChanges();
        }

    }



    protected void RadButton1_Click(object sender, EventArgs e)
    {
        TextBox TextBox1 = new TextBox();

        TextBox1.Visible = true;
    }


    protected void ckxWebAdd_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void gvClassTime_ItemDataBound(object sender, GridItemEventArgs e)
    {
        //if (e.Item is GridDataItem)
        //{
        //    GridDataItem item = (GridDataItem)e.Item;

        //    string id = (e.Item as GridDataItem).GetDataKeyValue("iAutoKey").ToString();
        //    RadButton btn = e.Item.Cells[5].FindControl("btnClassTimeSave") as RadButton;

        //    if (btn != null)
        //    {
        //        btn.GroupName = id;
        //    }
        //}
    }

    protected void gvClassTime_ItemCommand(object sender, GridCommandEventArgs e)
    {
        //e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["iAutoKey"], e.Item.ItemIndex);
        string key = e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["iAutoKey"].ToString();

        DateTime dtA, dtD;

        if ((e.Item.Cells[2].FindControl("tpTimeA") as RadTimePicker).SelectedDate.HasValue
            && (e.Item.Cells[4].FindControl("tpTimeD") as RadTimePicker).SelectedDate.HasValue)
        {

            var obj = (from c in dcTraining.trAttendClassDate
                       where c.iAutoKey == Convert.ToInt32(key)
                       select c).FirstOrDefault();

            if (obj != null)
            {
                dtA = (e.Item.Cells[2].FindControl("tpTimeA") as RadTimePicker).SelectedDate.Value;
                dtD = (e.Item.Cells[4].FindControl("tpTimeD") as RadTimePicker).SelectedDate.Value;

                //TimePicker選的是當天的日期，所以要把日期換成上課日，時間則套用選擇的
                obj.dClassDateA = new DateTime(obj.dClassDate.Year, obj.dClassDate.Month, obj.dClassDate.Day, dtA.Hour, dtA.Minute, 0);
                obj.dClassDateD = new DateTime(obj.dClassDate.Year, obj.dClassDate.Month, obj.dClassDate.Day, dtD.Hour, dtD.Minute, 0);

                if (obj.dClassDateA.Value > obj.dClassDateD.Value)
                {
                    AlertMsg("時間輸入有誤");
                    (e.Item.Cells[2].FindControl("tpTimeA") as RadTimePicker).Clear();
                    (e.Item.Cells[4].FindControl("tpTimeD") as RadTimePicker).Clear();
                    return;
                }

                //TimeSpan ts = obj.dClassDateD.Value - obj.dClassDateA.Value;
                //obj.iAttendMins = Convert.ToInt32(ts.TotalMinutes);

                //上課時間扣除休息時間
                RadNumericTextBox ntb = e.Item.Cells[5].FindControl("ntbiAttendMins") as RadNumericTextBox;
                int iAttendMins = 0;
                int.TryParse(ntb.Text, out iAttendMins);

                //obj.iAttendMins = obj.iAttendMins - breakTimeMins;
                //if (obj.iAttendMins < 0)
                //{
                //    Show("輸入錯誤，不得為負數");
                //    return;
                //} 

                obj.iAttendMins = iAttendMins;
                dcTraining.SubmitChanges();
            }


        }
        else
        {
            AlertMsg("時間輸入有誤");
            (e.Item.Cells[2].FindControl("tpTimeA") as RadTimePicker).Clear();
            (e.Item.Cells[4].FindControl("tpTimeD") as RadTimePicker).Clear();
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



    protected void RadTabStrip1_TabClick(object sender, RadTabStripEventArgs e)
    {
        //   this.Title = "執行清單";
        string urlPara = "?ID=" + Request.QueryString["ID"].ToString();
        RadMultiPage1.FindPageViewByID("pvContent").Selected = true;
        
        if(e.Tab.Value.Trim().Length>0)
        {
            pvContent.ContentUrl = e.Tab.Value + urlPara;
        }
        else if (e.Tab.Text.Equals("例外狀況"))
        {
            RadMultiPage1.FindPageViewByID("pvClassExceptionProcess").Selected = true;
            // pvContent.ContentUrl = "~/eTraining/Admin/Do/ClassExceptionProcess.aspx" + urlPara;            
        }
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

        RadTabStripEventArgs e = new RadTabStripEventArgs(RadTabStrip1.SelectedTab);
        RadTabStrip1_TabClick(this, e);

        //RadMultiPage1.PageViews[RadTabStrip1.SelectedTab.PageView.Index].Selected = true;

        //SpiceIframe1.SourceURL = RadTabStrip1_TabClick(SpiceIframe1.SourceURL,RadTabStrip1.SelectedTab.Index);

    }
    protected void btnCancelClassPublish_Click(object sender, EventArgs e)
    {
        if (Request.QueryString["ID"] != null)
        {
            var tdm = (from c in dcTraining.trTrainingDetailM
                       where c.iAutoKey == Convert.ToInt32(Request.QueryString["ID"])
                       && c.bIsPublished == true
                       select c).FirstOrDefault();

            tdm.bIsPublished = false;
            dcTraining.SubmitChanges();
            Response.Redirect(@"~/eTraining/Admin/Do/DoCourseList.aspx", true);
        }
    }
    protected void btnStudentScoreDeadLine_Click(object sender, EventArgs e)
    {
        //int classID = Convert.ToInt32(lblID.Text);
        //var cls = tdmRepo.GetByKey_DLO(classID);

        //if (cls != null)
        //{
        //    cls.bIsNeedStudentScore = cbIsNeedStudentScore.Checked;

        //    if (cls.bIsNeedStudentScore)
        //    {
        //        if (rdtpStudentScoreDeadLine.SelectedDate.HasValue)
        //            cls.dStudentScoreDeadline = rdtpStudentScoreDeadLine.SelectedDate.Value;
        //        else
        //        {
        //            RadAjaxPanel1.Alert("請輸入時間");
        //            return;
        //        }

        //    }
        //    else
        //        cls.dStudentScoreDeadline = null;

        //    tdmRepo.Update(cls);
        //    tdmRepo.Save();
        //    RadAjaxPanel1.Alert("已存檔");
        //    loadClassData();
        //}
        //else
        //    throw new Exception("參數不正確");
    }
    protected void btnClassRptDeadLine_Click(object sender, EventArgs e)
    {
        //int classID = Convert.ToInt32(lblID.Text);
        //var cls = tdmRepo.GetByKey_DLO(classID);
        //if (cls != null)
        //{
        //    cls.bIsNeedClassRpt = cbIsNeedClassRpt.Checked;

        //    if (cls.bIsNeedClassRpt)
        //    {
        //        if (rdtpClassRptDeadLine.SelectedDate.HasValue)
        //            cls.dClassRptDeadline = rdtpClassRptDeadLine.SelectedDate.Value;
        //        else
        //        {
        //            RadAjaxPanel1.Alert("請輸入時間");
        //            return;
        //        }
        //    }
        //    else
        //        cls.dClassRptDeadline = null;

        //    tdmRepo.Update(cls);
        //    tdmRepo.Save();
        //    RadAjaxPanel1.Alert("已存檔");
        //    loadClassData();
        //}
        //else
        //    throw new Exception("參數不正確");


    }
    protected void btnAlterCourse_Click(object sender, EventArgs e)
    {
        string url = @"~/eTraining/Admin/Design/SetCourse.aspx?ID=" + Request.QueryString["ID"]+"&Mode=SUPER";
        Response.Redirect(url, true);
    }
}
