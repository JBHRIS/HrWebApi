using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using System.Data;
using Repo;
public partial class DeptPlanFill3Summury : JBWebPage
{
    dcTrainingDataContext dcTraining = new dcTrainingDataContext();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            int year = Convert.ToInt32(Request.QueryString["Year"]);
            bool includeChild = Convert.ToBoolean(Request.QueryString["IncludeChild"]);
            string dept = Request.QueryString["Dept"];
            displayData(year, dept, includeChild);
            //IncludeChild
            //Juser.ManageDeptList
        }

    }

    private void displayData(int year, string dept, bool includeChild)
    {
        trRequirementTemplateRecord_Repo rtrRepo = new trRequirementTemplateRecord_Repo();
        var rtrObj = rtrRepo.GetByYear(year);
        if (rtrObj == null)
            return;

        //要顯示的所有課程
        trRequirementTemplateCourse_Repo rtcRepo = new trRequirementTemplateCourse_Repo();
        List<trRequirementTemplateCourse> rtcList = rtcRepo.GetByRT_CodeDlo(rtrObj.Rt_sCode).OrderBy(p => p.Sequence).ToList();

        QuestDeptDetail3_Repo qdd3Repo = new QuestDeptDetail3_Repo();
        List<QuestDeptDetail3> qdd3List = new List<QuestDeptDetail3>();
        QuestDeptCustom3_Repo qdc3Repo = new QuestDeptCustom3_Repo();
        List<QuestDeptCustom3> qdc3List = new List<QuestDeptCustom3>();

        if (includeChild)
        {
            DEPT_Repo deptRepo = new DEPT_Repo();
            var d = deptRepo.GetDeptByID(dept);

            List<DEPT> deptList = deptRepo.GetAllChildNode(d);

            foreach (var i in deptList)
            {
                qdd3List.AddRange(qdd3Repo.GetByYearDeptCode_Dlo(year, i.D_NO));
                qdc3List.AddRange(qdc3Repo.GetByYearDeptCode_Dlo(year, i.D_NO));
            }
        }
        else
        {
            qdd3List.AddRange(qdd3Repo.GetByYearDeptCode_Dlo(year, dept));
            qdc3List.AddRange(qdc3Repo.GetByYearDeptCode_Dlo(year, dept));
        }

        qdd3List = qdd3List.FindAll(p => p.IsRejection == false && p.IsRequired);

        List<DeptPlanFill3SummuryView> bindList = new List<DeptPlanFill3SummuryView>();

        foreach (var i in rtcList)
        {
            DeptPlanFill3SummuryView obj = new DeptPlanFill3SummuryView();

            obj.Amt = (from c in qdd3List where c.trRequirementTemplateCourse.CourseCode == i.CourseCode && c.Amt.HasValue select c.Amt.Value).Sum();
            obj.Budget = i.Budget;
            obj.CourseCode = i.CourseCode;
            obj.CourseName = i.trCourse.sName;
            obj.Minutes = (from c in qdd3List where c.trRequirementTemplateCourse.CourseCode == i.CourseCode && c.Minutes.HasValue select c.Minutes.Value).Sum();
            obj.StudentNum = (from c in qdd3List where c.trRequirementTemplateCourse.CourseCode == i.CourseCode && c.StudentNum.HasValue select c.StudentNum.Value).Sum();
            obj.Id = i.Id;//注意這邊給需求調查的Id，以便於其他用途
            bindList.Add(obj);
        }

        gvQuest.DataSource = bindList;
        gvQuest.Rebind();

        qdc3List = qdc3List.FindAll(p => p.IsRejection == false && p.IsRequired);
        gvQuestCustom.DataSource = (from c in qdc3List
                                    select new
                                    {
                                        c.Id,
                                        CourseName = c.CourseName,
                                        Amt = c.Amt,
                                        StudentNum = c.StudentNum,
                                        Minutes = c.Minutes,
                                        Month = c.Month,
                                    }).ToList();
        gvQuestCustom.Rebind();

        int amt = (from c in bindList select c.Amt).Sum();
        amt = amt + (from c in qdc3List where c.Amt.HasValue select c.Amt.Value).Sum();
        lbAmt.Text = amt.ToString();

        List<MonthView> monthViewList = new List<MonthView>();
        MonthView monthViewObj = new MonthView();
        monthViewObj.m1 = (from c in qdd3List where c.Month.HasValue && c.Month.Value == 1 && c.Amt.HasValue select c.Amt.Value).Sum() +
            (from c in qdc3List where c.Month.HasValue && c.Month.Value == 1 && c.Amt.HasValue select c.Amt.Value).Sum();

        monthViewObj.m2 = (from c in qdd3List where c.Month.HasValue && c.Month.Value == 2 && c.Amt.HasValue select c.Amt.Value).Sum() +
    (from c in qdc3List where c.Month.HasValue && c.Month.Value == 2 && c.Amt.HasValue select c.Amt.Value).Sum();

        monthViewObj.m3 = (from c in qdd3List where c.Month.HasValue && c.Month.Value == 3 && c.Amt.HasValue select c.Amt.Value).Sum() +
    (from c in qdc3List where c.Month.HasValue && c.Month.Value == 3 && c.Amt.HasValue select c.Amt.Value).Sum();
        monthViewObj.m4 = (from c in qdd3List where c.Month.HasValue && c.Month.Value == 4 && c.Amt.HasValue select c.Amt.Value).Sum() +
    (from c in qdc3List where c.Month.HasValue && c.Month.Value == 4 && c.Amt.HasValue select c.Amt.Value).Sum();
        monthViewObj.m5 = (from c in qdd3List where c.Month.HasValue && c.Month.Value == 5 && c.Amt.HasValue select c.Amt.Value).Sum() +
    (from c in qdc3List where c.Month.HasValue && c.Month.Value == 5 && c.Amt.HasValue select c.Amt.Value).Sum();
        monthViewObj.m6 = (from c in qdd3List where c.Month.HasValue && c.Month.Value == 6 && c.Amt.HasValue select c.Amt.Value).Sum() +
    (from c in qdc3List where c.Month.HasValue && c.Month.Value == 6 && c.Amt.HasValue select c.Amt.Value).Sum();
        monthViewObj.m7 = (from c in qdd3List where c.Month.HasValue && c.Month.Value == 7 && c.Amt.HasValue select c.Amt.Value).Sum() +
    (from c in qdc3List where c.Month.HasValue && c.Month.Value == 7 && c.Amt.HasValue select c.Amt.Value).Sum();
        monthViewObj.m8 = (from c in qdd3List where c.Month.HasValue && c.Month.Value == 8 && c.Amt.HasValue select c.Amt.Value).Sum() +
    (from c in qdc3List where c.Month.HasValue && c.Month.Value == 8 && c.Amt.HasValue select c.Amt.Value).Sum();
        monthViewObj.m9 = (from c in qdd3List where c.Month.HasValue && c.Month.Value == 9 && c.Amt.HasValue select c.Amt.Value).Sum() +
    (from c in qdc3List where c.Month.HasValue && c.Month.Value == 9 && c.Amt.HasValue select c.Amt.Value).Sum();
        monthViewObj.m10 = (from c in qdd3List where c.Month.HasValue && c.Month.Value == 10 && c.Amt.HasValue select c.Amt.Value).Sum() +
    (from c in qdc3List where c.Month.HasValue && c.Month.Value == 10 && c.Amt.HasValue select c.Amt.Value).Sum();
        monthViewObj.m11 = (from c in qdd3List where c.Month.HasValue && c.Month.Value == 11 && c.Amt.HasValue select c.Amt.Value).Sum() +
    (from c in qdc3List where c.Month.HasValue && c.Month.Value == 11 && c.Amt.HasValue select c.Amt.Value).Sum();
        monthViewObj.m12 = (from c in qdd3List where c.Month.HasValue && c.Month.Value == 12 && c.Amt.HasValue select c.Amt.Value).Sum() +
    (from c in qdc3List where c.Month.HasValue && c.Month.Value == 12 && c.Amt.HasValue select c.Amt.Value).Sum();

        monthViewList.Add(monthViewObj);

        gvMonth.DataSource = monthViewList;
        gvMonth.Rebind();
    }

    private void setPageEnable(bool value)
    {
        gvQuest.Enabled = value;
    }



    protected void cbxYear_Load(object sender, EventArgs e)
    {
    }
    protected void Page_LoadComplete(object sender, EventArgs e)
    {
        checkClosed();
    }


    private void checkClosed()
    {
        // bool hasSend = false;   //紀碌需求是否送出
        bool isPlanQuestionClosed = false;   //紀碌需求填寫是否關閉(false:未關閉)

        PlanHelper planHelper = new PlanHelper();
        //抓取是否需求填寫是否已關閉(SetPlanQuestionClosed.aspx)
        //isPlanQuestionClosed = planHelper.isPlanQuestionClosed(Convert.ToInt32(cbxYear.SelectedValue));

        //如果需求填寫未關閉(isPlanQuestionClosed==False)
        if (!isPlanQuestionClosed)
        {

            //已存入填寫日期，代表已填寫完
            //if (mdate != null)
            //{
            //    hasSend = true;
            //}
        }

        //需求填寫關閉
        if (isPlanQuestionClosed)
        {
            lblMsg.Text = "需求填寫已關閉";
            setPageEnable(false);
        }
        else
        {
            lblMsg.Text = "";
            //將狀態設為可存檔可送出
            setPageEnable(true);
        }
    }

    protected void gvQuest_ItemDataBound(object sender, GridItemEventArgs e)
    {
    }

    protected void gvOtherQuest_ItemDataBound(object sender, GridItemEventArgs e)
    {

    }
    protected void gvQuest_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
    {

    }

    protected void gvQuestCustom_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
    {

    }

    protected void gvQuestCustom_InsertCommand(object sender, GridCommandEventArgs e)
    {

    }
    protected void gvQuestCustom_ItemCommand(object sender, GridCommandEventArgs e)
    {

    }
    protected void gvQuest_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void gvQuest_ItemCommand(object sender, GridCommandEventArgs e)
    {

    }

    public class MonthView
    {
        public int m1 { get; set; }
        public int m2 { get; set; }
        public int m3 { get; set; }
        public int m4 { get; set; }
        public int m5 { get; set; }
        public int m6 { get; set; }
        public int m7 { get; set; }
        public int m8 { get; set; }
        public int m9 { get; set; }
        public int m10 { get; set; }
        public int m11 { get; set; }
        public int m12 { get; set; }
    }
}


