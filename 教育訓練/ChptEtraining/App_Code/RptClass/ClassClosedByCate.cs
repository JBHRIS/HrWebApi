using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// ClassClosedByCate 的摘要描述
/// </summary>
public class ClassClosedByCate
{
    private dcTrainingDataContext dcTraining = new dcTrainingDataContext();
	public ClassClosedByCate()
	{
		//
		// TODO: 在此加入建構函式的程式碼
		//
	}

    public Reports.ClassClosedByCateDataTable GetData(DateTime adate,DateTime ddate,int session,string catLevel1,string catLevel2)
    {
        Reports.ClassClosedByCateDataTable dt = new Reports.ClassClosedByCateDataTable();

        var classObjs = (from c in dcTraining.trTrainingDetailM
                         where c.dDateA <= ddate
                             && c.dDateA >= adate
                             && c.iSession.Value == session
                             && c.bIsPublished == true
                             && c.dDateTimeD <= DateTime.Now
                             && c.sKey == catLevel2
                         select c).ToList();

        //抓取所有課程類別
        var classCats = (from c in dcTraining.trCategory select c).ToList();
        //抓取所有課程
        //var classCourses = (from c in dcTraining.trCourse select c).ToList();

        int sort = 0;

        foreach (var classObj in classObjs)
        {
            sort++;
            var classCat = (from c in classCats where c.sCode == classObj.sKey select c).FirstOrDefault();

            var classCourse = (from c in dcTraining.trCourse where c.sCode == classObj.trCourse_sCode select c).FirstOrDefault();

            if (classCat == null || classCourse ==null)
                continue;

            Course course = new Course();
            string teacherStr = course.GetTeacherNameByClassID(classObj.iAutoKey);

            var studentM = (from c in dcTraining.trTrainingStudentM
                            join b in dcTraining.BASE on c.sNobr equals b.NOBR
                            join tts in dcTraining.BASETTS on b.NOBR equals tts.NOBR
                            join dept in dcTraining.DEPT on tts.DEPT equals dept.D_NO
                            where c.iClassAutoKey == classObj.iAutoKey &&
                            new string[] { "1", "4", "6" }.Contains(tts.TTSCODE) &&
                            tts.ADATE    <= DateTime.Today & tts.DDATE >= DateTime.Today
                            select new { c, b.NAME_C,dept.D_NAME }).ToList();

            foreach (var s in studentM)
            {
                Reports.ClassClosedByCateRow row = dt.NewClassClosedByCateRow();
                row.Cate =  (classObj.iYear - 1911).ToString() + "-"+classObj.iSession.ToString()+ classCat.sName;
                row.Course = classCourse.sName;
                row.Date = classObj.dDateTimeA.Value.ToShortDateString();
                row.Teacher = teacherStr;
                row.Session = classObj.iSession.ToString();
                row.Name = s.NAME_C;
                row.Dept = s.D_NAME;
                row.Nobr = s.c.sNobr;
                //上課表現
                if (s.c.iScore.HasValue)
                    row.ClassScore = s.c.iScore.Value;
                //TR註記
                row.Presence = s.c.sNote3;
                //心得分數
                if (s.c.iNote2Score.HasValue)
                    row.ExpRptScore = s.c.iNote2Score.Value;

                row.Sort = sort;

                dt.Rows.Add(row);
            }
        }

        DoSummary(dt);
        return dt;
    }

    public void DoSummary(Reports.ClassClosedByCateDataTable dt)
    {
        var nobr = (from c in dt select c.Nobr).Distinct().ToList();
        var sort = (from c in dt select c.Sort).Max();

        foreach (var n in nobr)
        {
            var userInfos =(from d in dt where d.Nobr ==n select d).ToList();
            if(userInfos !=null)
            {
                int count=0;
                Double ClassScore = 0;
                Double ExpRptScore =0;
                string Presence = "";


                foreach(var  u in userInfos)
                {
                    if (count == 0 && !Convert.IsDBNull(u.Presence))
                        Presence = Presence + u.Presence;
                    else if (!u.IsPresenceNull())
                        Presence = Presence +"-"+u.Presence;

                    if (!u.IsClassScoreNull())                                            
                      ClassScore = ClassScore + u.ClassScore;

                    if (!u.IsExpRptScoreNull())
                        ExpRptScore = ExpRptScore + u.ExpRptScore;

                    count ++;
                }                
                var userInfo = userInfos.FirstOrDefault();

                Reports.ClassClosedByCateRow row = dt.NewClassClosedByCateRow();
                row.Nobr = userInfo.Nobr;
                row.Name = userInfo.Name;
                row.Dept = userInfo.Dept;
                row.Cate = userInfo.Cate;
                row.Course = "平均";
                row.Presence = Presence;
                row.ClassScore = (double)(ClassScore / count);
                row.ExpRptScore = (double)(ExpRptScore / count);
                row.Sort = sort + 1;
                dt.Rows.Add(row);
            }
        }
    }
}