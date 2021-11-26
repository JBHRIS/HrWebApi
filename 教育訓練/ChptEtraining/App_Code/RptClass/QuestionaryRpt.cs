using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Questionary 的摘要描述
/// </summary>
public class QuestionaryRpt
{
    private dcTrainingDataContext dcTraining = new dcTrainingDataContext();
    private Reports.QuestionaryRptDataTable dt = new Reports.QuestionaryRptDataTable();
	public QuestionaryRpt()
	{
		//
		// TODO: 在此加入建構函式的程式碼
		//
	}

    public Reports.QuestionaryRptDataTable GetDataByClass(int classID, string qQuestionary_sCode)
    {
        int sort = 1;
        var maxSort = (from c in dt orderby c.Sort descending select c).FirstOrDefault();

        if (maxSort !=null)
            sort = maxSort.Sort + 1;            
        else
            sort = 1;
                    
        var classObj = (from m in dcTraining.trTrainingDetailM
                        join cat in dcTraining.trCategory on m.sKey equals cat.sCode
                        join course in dcTraining.trCourse on m.trCourse_sCode equals course.sCode
                        where m.iAutoKey == classID
                        && DateTime.Now.CompareTo(m.dDateTimeD) > 0
                        select new { m, cat, course }).FirstOrDefault();

        if (classObj == null)
            return dt;

        Course courseObj = new Course();
        string teacherStr = courseObj.GetTeacherNameByClassID(classObj.m.iAutoKey);
        string placeStr = courseObj.GetPlaceNameByClassID(classObj.m.iAutoKey);

        var Questionary = (from qm in dcTraining.qQuestionaryM
                           join qs in dcTraining.qQuestionaryS on qm.sCode equals qs.sCode
                           join cm in dcTraining.qCastM on qs.qCastM_sCode equals cm.sCode
                           join cs in dcTraining.qCastS on cm.sCode equals cs.sCode
                           join tm in dcTraining.qTheme on cs.qTheme_sCode equals tm.sCode
                           where qm.sCode == qQuestionary_sCode
                           //orderby cm.iOrder, cs.iOrder
                           select new { qm, qs, cm, cs, tm }).ToList();


        var qBaseList = (from bs in dcTraining.qBaseS
                         join bm in dcTraining.qBaseM on bs.qBase_sCode equals bm.sCode
                         join tm in dcTraining.qTheme on bs.qTheme_sCode equals tm.sCode
                         join cm in dcTraining.qCastM on bs.qCast_sCode equals cm.sCode
                         where bm.qQuestionary_sCode == qQuestionary_sCode && bm.iClassAutoKey == classID
                         select new { bs, bm, tm, cm }).ToList();

        foreach (var q in Questionary)
        {
            Reports.QuestionaryRptRow row = dt.NewQuestionaryRptRow();
            row.Cate = classObj.cat.sName;
            row.CourseName = (classObj.m.iYear - 1911).ToString() + "-" + classObj.m.iSession.ToString() + classObj.course.sName;
            row.Session = classObj.m.iSession.ToString();
            row.Date = classObj.m.dDateA.Value.ToShortDateString();
            row.Teacher = teacherStr;
            row.ClassPlace = placeStr;
            row.CourseCode = classObj.m.trCourse_sCode;
            row.Qcate = q.cm.sContent;
            row.Qitem = q.tm.sContent;
            row.qTheme_sCode = q.tm.sCode;
            row.Sort = sort;
            if(q.tm.qTitle_sCode.Equals("01"))
            {
                //除數
                int divisor =0;
                //被除數
                int dividend = 0;

                dividend = (from c in qBaseList
                           where c.bs.qTheme_sCode == q.cs.qTheme_sCode
                           && c.bs.iFraction.HasValue
                           select c.bs.iFraction.Value).Sum();

                divisor = (from c in qBaseList
                            where c.bs.qTheme_sCode == q.cs.qTheme_sCode
                            && c.bs.iFraction.HasValue
                            select c.bs).Count();

                if (divisor == 0)
                { }
                else
                {
                    row.Qscore = (Double)(dividend / divisor);
                }
            }
           
            dt.Rows.Add(row);
        }                

        return dt;
    }

    public Reports.QuestionaryRptDataTable GetDataByClassCategory(int year, int session, string classCate, string qQuestionary_sCode)
    {
        var classObjs = (from c in dcTraining.trTrainingDetailM
                         where c.iYear == year                         
                             && c.iSession.Value == session
                             && c.bIsPublished == true
                             && c.dDateTimeD <= DateTime.Now
                             && c.sKey == classCate
                             orderby c.dDateTimeD ascending
                         select c).ToList();

        foreach (var o in classObjs)
        {
            GetDataByClass(o.iAutoKey, qQuestionary_sCode);
        }

        DoSummary();
        return dt;
    }

    public void DoSummary()
    {
        if (dt.Rows.Count == 0)
            return;
        var qTheme_sCodeList = (from c in dt select c.qTheme_sCode).Distinct().ToList();
        //var nobr = (from c in dt select c.Nobr).Distinct().ToList();
        var Maxsort = (from c in dt select c.Sort).Max()+1;

        foreach (var theme in qTheme_sCodeList)
        {
            Reports.QuestionaryRptRow row = dt.NewQuestionaryRptRow();

            var item =(from c in dt where c.qTheme_sCode == theme
                       select c).FirstOrDefault();

            double sum = 0;
            int count = 0;

            var data = (from c in dt
                        where c.qTheme_sCode == theme
                        select c).ToList();

            foreach (var c in data)
            {
                if (c.IsQscoreNull())
                {

                }
                else
                {
                    count++;
                    sum = sum + c.Qscore;
                }
            }     


            //sum = (from c in dt
            //       where c.qTheme_sCode == theme && c.Qscore != null
            //            select c.Qscore).Sum();

            
            //count =(from c in dt
            //            where c.qTheme_sCode == theme && c.Qscore != null
            //            select c.Qscore).Count();
            
            row.Cate = "平均";
            row.CourseName = "平均";
            row.Session = "";
            //row.Date = classObj.m.dDateA.Value.ToShortDateString();
            //row.Teacher = teacherStr;
            //row.ClassPlace = placeStr;
            row.CourseCode ="平均";
            row.Qcate = item.Qcate;
            row.Qitem = item.Qitem;
            row.qTheme_sCode = theme;
            row.Sort = Maxsort;
            if ( count == 0 )
            {
            }
            else
            {
                row.Qscore = (Double) (sum / count);
            }

            dt.Rows.Add(row);
        }
    }
}