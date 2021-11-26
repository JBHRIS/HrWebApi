using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Repo;
public partial class eTraining_Staff_ExpReport : JBWebPage
{
    private dcTrainingDataContext dcTraining = new dcTrainingDataContext();
    DataContext dc = new DataContext();
    private mtCode_Repo mtCodeRepo = new mtCode_Repo(); 
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["ID"] == null)
            {
                throw new ApplicationException("無參數，錯誤");
            }

            int id = 0;
            if (int.TryParse(Request.QueryString["ID"].ToString(), out id))
            {
                loadData(id);
            }
            else
                throw new ApplicationException("參數錯誤");
        }
    }

    private void loadData(int id)
    {
        var studentMObj = (from c in dcTraining.trTrainingStudentM
                           where c.iAutoKey == id
                           select c).FirstOrDefault();

        if (studentMObj == null)
        {
            throw new ApplicationException("找不到相關值");
        }

        if (studentMObj.sNobr != User.Identity.Name)
        {
            throw new ApplicationException("非本人不得填寫");
        }

        IRepository<trTrainingDetailM> DMRepository = new Repository<trTrainingDetailM>(dc);
        trTrainingDetailM DMObj = DMRepository.FirstOrDefault(c => c.iAutoKey == studentMObj.iClassAutoKey);

        if (!DMObj.bIsNeedClassRpt)
        {
            btnSave.Enabled = false;
            lblMsg.Text = "未設定填寫心得";
            return;
        }

        //抓mtCode的是否鎖定心得，如果逾期的話
        mtCode_Repo mtCodeRepo = new mtCode_Repo();
        mtCode mtCodeObj = mtCodeRepo.GetByCategroyCode("ClassReport", "FillDeadLineLock");

        if (!mtCodeObj.b1.HasValue)
            throw new ApplicationException("Category:ClassReport,Code:FillDeadLineLock的b1未設定");


        //if (mtCodeObj.b1.Value)
        //{
        //    if (DMObj.dClassRptDeadline <= DateTime.Now)
        //    {
        //        btnSave.Enabled = false;
        //        lblMsg.Text = "已超過填寫時間";
        //    }
        //}

        edtStudent.Content = studentMObj.sNote2;

        //載入講師評語
        edtTeacher.Content = studentMObj.sNote4;


        if(studentMObj.iNote2Score.HasValue)
            tbScore.Text = studentMObj.iNote2Score.ToString();

        var classObj = (from c in dcTraining.trTrainingDetailM
                        where c.iAutoKey == studentMObj.iClassAutoKey
                        select c).FirstOrDefault();

        var courseObj = (from c in dcTraining.trCourse
                         where c.sCode == classObj.trCourse_sCode
                         select c).FirstOrDefault();
        if (courseObj != null)
        {
            lblClassName.Text = courseObj.sName;
        }

        lblClassDate.Text = classObj.dDateTimeA.Value.ToShortDateString();
        lblClassTime.Text = classObj.dDateTimeA.Value.ToShortTimeString();

        var classPlaceObj = (from c in dcTraining.trAttendClassPlace
                             join p in dcTraining.trClassroom on c.sPlaceCode equals p.sCode
                             where c.iClassAutoKey == classObj.iAutoKey
                             select new { c, p.sName }).FirstOrDefault();

        if (classPlaceObj != null)
        {

            lblClassPlace.Text = classPlaceObj.sName;
        }

        var classTeacherObj = (from c in dcTraining.trAttendClassTeacher
                               join t in dcTraining.trTeacher on c.sTeacherCode equals t.sCode
                               where c.iClassAutoKey == classObj.iAutoKey
                               select new { c, t.sName }).FirstOrDefault();

        if (classTeacherObj != null)
        {
            lblTeacher.Text = classTeacherObj.sName;
        }


        var user = (from b in dcTraining.BASE
                    join t in dcTraining.BASETTS on b.NOBR equals t.NOBR
                    join d in dcTraining.DEPT on t.DEPT equals d.D_NO
                    where DateTime.Now.Date >= t.ADATE && DateTime.Now.Date <= t.DDATE &&
                    DateTime.Now.Date >= d.ADATE && DateTime.Now.Date <= d.DDATE &&//部門也要過濾失效的
                    b.NOBR == User.Identity.Name &&
                    new string[] { "1", "4", "6" }.Contains(t.TTSCODE)
                    select new { b, t, d }).FirstOrDefault();

        if (user != null)
        {
            lblUserName.Text = user.b.NAME_C;
            var jobObj = (from c in dcTraining.JOB
                          where c.JOB1 == user.t.JOB
                          select c).FirstOrDefault();
            if (jobObj != null)
            {
                lblJobName.Text = jobObj.JOB_NAME;
            }

        }

        if (studentMObj.dNote2KeyDate != null)
        {
            edtStudent.Enabled = false;
            btnSave.Enabled = false;
            btnSaveTemp.Enabled = false;
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (IsRefresh)
        {
            return;
        }

        int id = 0;
        int.TryParse(Request.QueryString["ID"].ToString(), out id);
        var studentMObj = (from c in dcTraining.trTrainingStudentM
                           where c.iAutoKey == id
                           select c).FirstOrDefault();

        if (studentMObj != null)
        {
            mtCode mtCodeObj= mtCodeRepo.GetByCategroyCode("ClassReport", "NumberOfCharactersBaseLine");
            if (!mtCodeObj.i1.HasValue)
                throw new ApplicationException("尚未設定 Category:ClassReport,Code:NumberOfCharactersBaseLine的i1值");


            if ( edtStudent.Text.Length < mtCodeObj.i1 )
            {
                AlertMsg("填寫字數需超過"+mtCodeObj.i1.ToString()+"字");
                return;
            }
            studentMObj.sNote2 = edtStudent.Content;
            
            studentMObj.dNote2KeyDate = DateTime.Now;
            dcTraining.SubmitChanges();
        }

        loadData(id);
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        string tab = "0";
        if (Request.QueryString["tab"] != null)
            tab = Request.QueryString["tab"];

        if (ViewState["URL"] != null)
        {
            if (!ViewState["URL"].ToString().Contains("tab="))
                Response.Redirect(ViewState["URL"].ToString() + "?tab=" + tab);
            else
                Response.Redirect(ViewState["URL"].ToString());
        }
    }
    protected void btnSaveTemp_Click(object sender, EventArgs e)
    {
        if (IsRefresh)
        {
            return;
        }

        int id = 0;
        int.TryParse(Request.QueryString["ID"].ToString(), out id);
        var studentMObj = (from c in dcTraining.trTrainingStudentM
                           where c.iAutoKey == id
                           select c).FirstOrDefault();

        if (studentMObj != null)
        {
            studentMObj.sNote2 = edtStudent.Content;            
            dcTraining.SubmitChanges();
        }
        loadData(id);
    }
}