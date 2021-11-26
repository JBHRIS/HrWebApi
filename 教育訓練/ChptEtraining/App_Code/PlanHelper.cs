using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Repo;
/// <summary>
/// Plan 的摘要描述
/// </summary>
public class PlanHelper
{
    private dcTrainingDataContext dcTraining = new dcTrainingDataContext();
    private CourseType_Repo courseTypeRepo = new CourseType_Repo();
    public PlanHelper()
    {
        //
        // TODO: 在此加入建構函式的程式碼
        //
    }

    public string getLastPlanYear()
    {
        var data = (from c in dcTraining.trTrainingPlanDetail
                    orderby c.iYear descending
                    select c).FirstOrDefault();

        if (data != null)
        {
            return data.iYear.ToString();
        }
        else
        {
            return DateTime.Now.Year.ToString();
        }
    }

    public bool isPlanQuestionClosed(int year)
    {
        bool result = false;

        var data = (from c in dcTraining.trRequirementTemplateRecord
                    where c.iYear == year && c.bIsClosed == true
                    select c).FirstOrDefault();

        if (data != null)
        {
            result = true;
        }

        return result;
    }



    public void setCbYear(Telerik.Web.UI.RadComboBox cbYear)
    {
        Dictionary<string, string> yearDic = new Dictionary<string, string>();

        var data = (from c in dcTraining.trRequirementTemplateRecord select c.iYear).Distinct();

        //先找資料庫有的年度
        foreach (var row in data)
        {
            if (!yearDic.ContainsKey(row.ToString()))
                yearDic.Add(row.ToString(), row.ToString());
        }

        //從今年度往後推顯示兩年
        int year = DateTime.Now.Year;
        for (int i = 0; i < 3; i++, year++)
        {
            if (!yearDic.ContainsKey(year.ToString()))
                yearDic.Add(year.ToString(), year.ToString());
        }

        //排序一下
        Dictionary<string, string> list = (from c in yearDic
                                           orderby c.Key ascending
                                           select c).ToDictionary(d => d.Key, d => d.Value);

        cbYear.DataSource = list;
        cbYear.DataTextField = "value";
        cbYear.DataValueField = "key";
        cbYear.DataBind();

        foreach (Telerik.Web.UI.RadComboBoxItem item in cbYear.Items)
        {
            if (item.Value == DateTime.Now.Year.ToString())
            {
                item.Selected = true;
            }
        }
    }

    public  bool IsYearQuestClosed(int year)
    {
        var data = (from c in dcTraining.trRequirementTemplateRecord
                    where c.iYear == year && c.bIsClosed == true
                    select c).FirstOrDefault();

        if (data != null)
        {
            return true;
        }
        else
            return false;
    }

    public void DoUpdatePlan(DataTable dt, string keyMan)
    {
        int iyear = 0;
        int r = 0;//宣告在此，是為了catch可以抓到哪一行
        var categoryCourses = (from c in dcTraining.trCategoryCourse
                                 select c).ToList();

        var courseTypeList = courseTypeRepo.GetAll();

        try
        {
            if (dt.Rows.Count > 0)
            {
                iyear = int.Parse(dt.Rows[0]["年度"].ToString());
            }

            var YearPlans = (from c in dcTraining.trTrainingPlanDetail
                             where c.iYear == iyear
                             select c).ToList();

            //foreach (DataRow row in dt.Rows)

            for(; r<dt.Rows.Count ; r++)
            {
                DataRow row = dt.Rows[r];

                int year = int.Parse(row["年度"].ToString());
                int month = int.Parse(row["月份"].ToString());
                int session = int.Parse(row["梯次"].ToString());
                string catLevel1Code = row["階層代碼"].ToString();
                string courseCode = row["課程名稱代碼"].ToString();
                double timeAmt = double.Parse(row["時數"].ToString());
                int peopleAmt = int.Parse(row["人數"].ToString());
                Int32 chargeAmt = Int32.Parse(row["預估費用"].ToString());
                string courseType = row["課程類型"].ToString();

                //檢查courseType是否正確
                if(!courseTypeList.Any(p=>p.sCode.Equals(courseType)))
                    throw new ApplicationException("錯誤的課程類型，請輸入正確的課程類型");


                //檢查上傳excel年度是否為西元年
                if (year.ToString().Length < 4)
                    throw new ApplicationException("錯誤的年度，請檢查是否為西元年");

                //確認課程，階層類別是否正確
                var catCourse = (from c in categoryCourses
                                 where c.sCourseCode == courseCode && c.sCateCode == catLevel1Code
                                 select c).FirstOrDefault();

                if (catCourse == null)
                    throw new ApplicationException("錯誤的課程與階層");


                var plan = (from c in YearPlans
                            where c.iYear == year
                                && c.iMonth == month
                                && c.iSession == session
                                && c.sKey == catLevel1Code
                                && c.trCourse_sCode == courseCode
                            select c).FirstOrDefault();

                if (plan == null)
                {
                    trTrainingPlanDetail obj = new trTrainingPlanDetail();
                    obj.dKeyDate = DateTime.Now;
                    obj.iAmt = chargeAmt;
                    obj.iMins = Convert.ToInt32(timeAmt * 60);
                    obj.iMonth = month;
                    obj.iNumOfPeople = peopleAmt;
                    obj.iSession = session;
                    obj.iYear = year;
                    obj.sKey = catLevel1Code;
                    obj.trCourse_sCode = courseCode;
                    obj.sKeyMan = keyMan;
                    obj.CourseType = courseType;
                    dcTraining.trTrainingPlanDetail.InsertOnSubmit(obj);
                }
                else
                {
                    plan.dKeyDate = DateTime.Now;
                    plan.iAmt = chargeAmt;
                    plan.CourseType = courseType;
                    plan.iMins = Convert.ToInt32(timeAmt * 60);
                    plan.iNumOfPeople = peopleAmt;
                    plan.sKeyMan = keyMan;
                }
                dcTraining.SubmitChanges();
            }
        }
        catch (Exception ex)
        {
           throw new ApplicationException((r+2).ToString()+"行資料有誤"+"\r\n"+ex.Message);

        }
    }

}