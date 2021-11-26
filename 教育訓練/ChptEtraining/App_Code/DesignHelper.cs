using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
/// <summary>
/// DesignHelper 的摘要描述
/// </summary>
public class DesignHelper
{
    private dcTrainingDataContext dcTraining = new dcTrainingDataContext();

	public DesignHelper()
	{
		//
		// TODO: 在此加入建構函式的程式碼
		//
	}



    public int getNewClassSession(int year, string courseCode)
    {
        int result =1;
        
        var classSession = (from c in dcTraining.trTrainingDetailM 
                     where c.iYear ==year 
                     && c.trCourse_sCode == courseCode
                     select c.iSession).Max();

        if (classSession.HasValue)
        {
            result = classSession.Value + 1;
        }
        else
        {
            result = 1;
        }

        return result;
    }


    public  DataTable getTeachingMaterialDetail(int key)
    {
        var dataHead = (from c in dcTraining.trTeachingMaterialDetail
                        where c.MaterialAutoKey == key && c.ParentiAutoKey == 0
                        select c).ToList();

        int i = dataHead.Count;

        DataTable dt = new DataTable();

        dt.Columns.Add("A1", typeof(string));
        dt.Columns.Add("A2", typeof(string));
        dt.Columns.Add("A3", typeof(string));
        dt.Columns.Add("A4", typeof(string));
        dt.Columns.Add("A5", typeof(string));
        dt.Columns.Add("A6", typeof(string));

        foreach (var data in dataHead)
        {
            var dataDetail = (from c in dcTraining.trTeachingMaterialDetail
                              where c.MaterialAutoKey == key && c.ParentiAutoKey == data.iAutoKey
                              select c).ToList();

            if (dataDetail.Count > 0)
            {
                foreach (var detail in dataDetail)
                {
                    DataRow row = dt.NewRow();
                    row["A1"] = data.sOutline;
                    row["A2"] = detail.sOutline;
                    row["A3"] = getTechingMethod(detail.iAutoKey);
                    row["A4"] = getTechingResources(detail.iAutoKey);
                    row["A5"] = detail.iTimeMin.ToString();
                    row["A6"] = detail.sNote;
                    dt.Rows.Add(row);
                }
            }
            else//如果只有一筆，就顯示大綱就好
            {
                DataRow row = dt.NewRow();
                row["A1"] = data.sOutline;
                row["A2"] = "";
                row["A3"] = getTechingMethod(data.iAutoKey);
                row["A4"] = getTechingResources(data.iAutoKey);
                row["A5"] = data.iTimeMin.ToString();
                row["A6"] = data.sNote;
                dt.Rows.Add(row);
            }
        }
        return dt;
    }

    private string getTechingMethod(int key)
    {
        string result = "";
        var list = (from d in dcTraining.trTeachingMaterialDetail_TeachingMethod
                    join m in dcTraining.trTeachingMethod on d.trTeachingMethod_sCode equals m.sCode
                    where d.MaterialDetailAutoKey == key
                    select new { d, m }).ToList();


        foreach (var l in list)
        {
            result = result + l.m.sName + "、";
        }

        if (result.Length > 0)
        {
            if (result[result.Length - 1].Equals('、'))
            {
                result = result.Substring(0, result.Length - 1);
            }
        }
        return result;
    }

    private string getTechingResources(int key)
    {
        string result = "";
        var list = (from d in dcTraining.trTeachingMaterialDetail_TeachingResource
                    join r in dcTraining.trTeachingResource on d.trTeachingResourceCode equals r.ResourceCode
                    where d.MaterialDetailAutoKey == key
                    select new { d, r }).ToList();

        foreach (var l in list)
        {
            result = result + l.r.ResourceName + "、";
        }

        if (result.Length > 0)
        {
            if (result[result.Length - 1].Equals('、'))
            {
                result = result.Substring(0, result.Length - 1);
            }
        }
        return result;
    }

    public void DeleteClass(int classID)
    {
        var trainingDetailM = (from c in dcTraining.trTrainingDetailM
                               where c.iAutoKey == classID
                               select c).FirstOrDefault();

        dcTraining.trTrainingDetailM.DeleteOnSubmit(trainingDetailM);

        var attendClassDate = (from c in dcTraining.trAttendClassDate
                               where c.iClassAutoKey == classID
                               select c).ToList();

        dcTraining.trAttendClassDate.DeleteAllOnSubmit(attendClassDate);

        var attendClassPlace = (from c in dcTraining.trAttendClassPlace
                                where c.iClassAutoKey == classID
                                select c).ToList();
        dcTraining.trAttendClassPlace.DeleteAllOnSubmit(attendClassPlace);

        var attendClassTeacher = (from c in dcTraining.trAttendClassTeacher
                                  where c.iClassAutoKey == classID
                                  select c).ToList();
        dcTraining.trAttendClassTeacher.DeleteAllOnSubmit(attendClassTeacher);

        var trainingStudentM = (from c in dcTraining.trTrainingStudentM
                                where c.iClassAutoKey == classID
                                select c).ToList();
        dcTraining.trTrainingStudentM.DeleteAllOnSubmit(trainingStudentM);

        var trainingStudentS = (from c in dcTraining.trTrainingStudentS
                                where c.iClassAutoKey == classID
                                select c).ToList();
        dcTraining.trTrainingStudentS.DeleteAllOnSubmit(trainingStudentS);

        var trainingStudentPresence = (from c in dcTraining.trTrainingStudentPresence
                                       where c.iClassAutoKey == classID
                                       select c).ToList();
        dcTraining.trTrainingStudentPresence.DeleteAllOnSubmit(trainingStudentPresence);


        var trainingStudentScore = (from c in dcTraining.trTrainingStudentScore
                                    where c.iClassAutoKey == classID
                                    select c).ToList();
        dcTraining.trTrainingStudentScore.DeleteAllOnSubmit(trainingStudentScore);


        var trainingEstimateCost = (from c in dcTraining.trTrainingEstimateCost
                                    where c.iClassAutoKey == classID
                                    select c).ToList();
        dcTraining.trTrainingEstimateCost.DeleteAllOnSubmit(trainingEstimateCost);

        var trainingActualCost = (from c in dcTraining.trTrainingActualCost
                                    where c.iClassAutoKey == classID
                                    select c).ToList();
        dcTraining.trTrainingActualCost.DeleteAllOnSubmit(trainingActualCost);

        var qbaseM = (from c in dcTraining.qBaseM
                      where c.iClassAutoKey == classID
                      select c).ToList();
        dcTraining.qBaseM.DeleteAllOnSubmit(qbaseM);

        var classNotify = (from c in dcTraining.trClassNotify
                           where c.iClassAutoKey == classID
                           select c).ToList();
        dcTraining.trClassNotify.DeleteAllOnSubmit(classNotify);

        var classQuestionnaire = (from c in dcTraining.ClassQuestionnaire
                                  where c.iClassAutoKey == classID
                                  select c).ToList();
        dcTraining.ClassQuestionnaire.DeleteAllOnSubmit(classQuestionnaire);

        //年度計
        var trainingPlanDetail = (from c in dcTraining.trTrainingPlanDetail
                                  where c.iClassAutoKey == classID
                                  select c).ToList();
        foreach (var pd in trainingPlanDetail)
        {
            pd.iClassAutoKey = null;
        }

        //刪除課程通知
        var classNotifyList = (from c in dcTraining.trClassNotify
                           where c.iClassAutoKey == classID
                           select c).ToList();
        dcTraining.trClassNotify.DeleteAllOnSubmit(classNotifyList);

        dcTraining.SubmitChanges();

    }

}