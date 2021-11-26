using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;
using System.Data;

public partial class eTraining_Reports_Do_RptScore : JBWebPage
{
    dcTrainingDataContext dcTrain = new dcTrainingDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            PlanHelper help = new PlanHelper();
            help.setCbYear(cbxYear);

            txtSession.Text = "1";
        }
    }
    protected void btnCheck_Click(object sender, EventArgs e)
    {
        //select m.iYear,m.iSession,ca.sName,co.sName,d.dClassDate,tea.sName,b.NAME_C,s.sDeptCode,s.sNote1,s.iScore from trTrainingStudentM s
        //join trTrainingDetailM m on s.iClassAutoKey=m.iAutoKey
        //join trCategory ca on m.sKey=ca.sCode
        //join trCourse co on m.trCourse_sCode=co.sCode
        //join trAttendClassDate d on m.iAutoKey=d.iClassAutoKey
        //join trAttendClassTeacher t on t.iClassAutoKey=m.iAutoKey and t.dClassDate=d.dClassDate
        //join trTeacher tea on t.sTeacherCode=tea.sCode
        //join BASE b on s.sNobr=b.NOBR
        //where m.sKey='B01'
        try
        {
            var Score = (from s in dcTrain.trTrainingStudentM
                         join m in dcTrain.trTrainingDetailM on s.iClassAutoKey equals m.iAutoKey
                         join ca in dcTrain.trCategory on m.sKey equals ca.sCode
                         join co in dcTrain.trCourse on m.trCourse_sCode equals co.sCode
                         join d in dcTrain.trAttendClassDate on m.iAutoKey equals d.iClassAutoKey
                         //join t in dcTrain.trAttendClassTeacher on m.iAutoKey equals t.iClassAutoKey
                         //join tea in dcTrain.trTeacher on t.sTeacherCode equals tea.sCode
                         join b in dcTrain.BASE on s.sNobr equals b.NOBR
                         where m.sKey == cbxCate.SelectedValue && m.iYear == Convert.ToInt32(cbxYear.SelectedValue)
                         && m.bIsPublished == true && m.iSession == Convert.ToInt32(txtSession.Text)
                         && DateTime.Today >= m.dDateD
                         //&& t.dClassDate==d.dClassDate
                         select new
                         {
                             Year = m.iYear,
                             Session = m.iSession,
                             Cate = ca.sName,
                             Course = co.sName,
                             Date = d.dClassDate,
                             //Teacher = tea.sName,
                             Name = b.NAME_C,
                             Dept = s.sDeptCode,
                             Comment = s.sNote1,
                             Score = s.iScore,
                             classID = m.iAutoKey,
                             Nobr=b.NOBR
                         }).ToList();
            
            


            Reports.ScoreDataTable studentScore = new Reports.ScoreDataTable();

            foreach (var itm in Score)
            {
                Reports.ScoreRow row = studentScore.NewScoreRow();

                row.Year = itm.Year.ToString();
                row.Session = itm.Session.ToString();
                row.Cate = itm.Cate;
                row.Course = itm.Course;
                row.Date = itm.Date;
                //row.Teacher = itm.Teacher;                
                row.Dept = itm.Dept;
                row.Name = itm.Name;
                row.Comment = itm.Comment;
                row.Score = Convert.ToInt32(itm.Score);
                row.Nobr=itm.Nobr;
                
                //講師
                string str = "";
                var teachers = (from act in dcTrain.trAttendClassTeacher
                                join t in dcTrain.trTeacher on act.sTeacherCode equals t.sCode
                                join b in dcTrain.BASE on t.sNobr equals b.NOBR
                                where act.dClassDate==itm.Date && act.iClassAutoKey == itm.classID 
                                select b).ToList();

                for (int i = 0; i < teachers.Count; i++)
                {
                    if (i == 0)
                        str = str + teachers[i].NAME_C;
                    else
                        str = str + "、" + teachers[i].NAME_C;
                }
                
                row.Teacher = str;
                studentScore.AddScoreRow(row);
            }
            //計算平均
            DoSummary(studentScore);
            
            if (studentScore.Rows.Count != 0)
            {
                ReportViewer1.Visible = true;

                ReportViewer1.LocalReport.DataSources.Clear();
                ReportViewer1.LocalReport.DataSources.Add(new ReportDataSource("Score",                                 studentScore.CopyToDataTable()));
                ReportViewer1.DataBind();
                ReportViewer1.LocalReport.Refresh();
            }
            else
            {
                AlertMsg("無資料");
            }
        }
        catch (Exception ex)
        {
            AlertMsg(ex.Message);
        }
    }

    //計算平均方法
    public void DoSummary(Reports.ScoreDataTable dt) 
    {
        var nobr = (from c in dt select c.Nobr).Distinct().ToList(); //找到不重複姓名所有工號

        foreach (var n in nobr)
        {
            var userInfos = (from d in dt where d.Nobr == n select d).ToList();
            if (userInfos != null)
            {
                int count = 0;
                Double ClassScore = 0;
                                
                foreach (var u in userInfos)
                {
                    if (!u.IsScoreNull())
                        ClassScore = ClassScore + u.Score;

                    count++;
                }
                var userInfo = userInfos.FirstOrDefault();

                Reports.ScoreRow row = dt.NewScoreRow();
                row.Nobr = userInfo.Nobr;
                row.Name = userInfo.Name;
                row.Dept = userInfo.Dept;
                row.Cate = userInfo.Cate;
                row.Course = "平均";
                row.Score = Convert.ToInt32((double)(ClassScore / count));
                dt.Rows.Add(row);
            }
        }
    }
}

