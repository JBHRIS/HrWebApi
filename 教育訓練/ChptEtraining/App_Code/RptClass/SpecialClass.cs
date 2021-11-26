using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// SpecialClass 的摘要描述
/// </summary>
public class SpecialClass
{
    private dcTrainingDataContext dcTraining = new dcTrainingDataContext();
	public SpecialClass()
	{
		//
		// TODO: 在此加入建構函式的程式碼
		//        
	}


    public Reports.CourseReviewBDataTable GetData(String catLevel1Code, int year)
    {
        Reports.CourseReviewBDataTable dt = new Reports.CourseReviewBDataTable();

        var catLevel2 = (from c in dcTraining.trCategory
                         where c.sParentCode == catLevel1Code
                         select c).ToList();

        foreach (var cat2 in catLevel2)
        {
            Reports.CourseReviewBRow row = dt.NewCourseReviewBRow();
            row.Cate = cat2.sName;            

            List<string> list = GetStudentsDistinct(cat2.sCode, year);
            row.Student = GetStudentNameStr(list);
            row.aPeople = list.Count();
            row.aLicense = GetLicenseNumDistinct(cat2.sCode, year);

            int planStudentCount = GetPlanStudentCountByClass(cat2.sCode, year);
            row.ePeople = planStudentCount;
            row.eLicense = planStudentCount;

            row.diffLicense = row.aLicense - row.eLicense;
            row.diffPeople = row.aPeople - row.ePeople;

            row.aCost = GetClassActualAmtByCatLevel2(cat2.sCode, year);
            dt.Rows.Add(row);
        }

        return dt;
    }


    public int GetClassActualAmtByCatLevel2(String catLevel2Code, int year)
    {
        int result = 0;

        int sum = (from c in dcTraining.trTrainingDetailM
                   where c.iYear == year &&
                   c.sKey == catLevel2Code &&
                   c.bIsPublished == true
                   select c.iActualAMT).ToList().Sum();

        result = sum;

        return result;
    }


    public int GetPlanStudentCountByClass(String catLevel2Code, int year)
    {
        int result = 0;

        var obj = (from c in dcTraining.trTrainingPlanDetail
                   where c.iYear == year &&
                   c.sKey == catLevel2Code
                   select c).FirstOrDefault();

        if(obj !=null)
            result = obj.iNumOfPeople;

        return result;
    }


    public String GetStudentNameStr(List<string> list)
    {
        string str = "";

        for (int i = 0; i < list.Count; i++)
        {
            if (i == 0)
                str = str + list[i];
            else
            {
                str = str + "、" + list[i];
            }
        }

        return str;
    }

    /// <summary>
    /// 取得證照數量，不重複學員名單
    /// </summary>
    /// <param name="catLevel2"></param>
    /// <param name="year"></param>
    /// <returns></returns>

    public int GetLicenseNumDistinct(string catLevel2, int year)
    {
        int result = 0;
        var key = (from c in dcTraining.mtCode
                   where c.sCategory =="REPORT" && c.sCode =="LicensePass"
                   select c).FirstOrDefault();

        if(key ==null)
        {
            new ApplicationException("未設定結訓證照項目");
        }

        var obj = (from c in dcTraining.trTrainingDetailM
                   join sm in dcTraining.trTrainingStudentM
                   on c.iAutoKey equals sm.iClassAutoKey
                   join ss in dcTraining.trTrainingStudentS
                   on sm.iAutoKey equals ss.trTrainingStudentM_ID
                   where c.sKey == catLevel2 &&
                   ss.bPass == true &&
                   ss.trKnotTeaches_sCode == key.s1 &&                                     
                   c.iYear == year &&
                   c.bIsPublished == true
                   select sm.sNobr).ToList();

        return obj.Count;
    }

    ///    
    /// 取得學員人數，不重複學員名單
    ///
    public List<string> GetStudentsDistinct(string catLevel2, int year)
    {
        List<string> list = new List<string>();

        var classObjs = (from c in dcTraining.trTrainingDetailM
                         join s in dcTraining.trTrainingStudentM
                         on c.iAutoKey equals s.iClassAutoKey
                         join b in dcTraining.BASE on
                         s.sNobr equals b.NOBR
                         where c.sKey == catLevel2 &&
                         c.iYear == year &&
                         c.bIsPublished == true
                         select new { b.NOBR, b.NAME_C }).Distinct().ToList();

        var students = (from c in classObjs
                        select c.NAME_C).ToList();

        return students;
    }
}

