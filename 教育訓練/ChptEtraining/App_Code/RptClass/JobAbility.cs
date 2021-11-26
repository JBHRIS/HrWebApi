using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Repo;
/// <summary>
/// JobAbility 的摘要描述
/// </summary>
public class JobAbility
{
    private dcTrainingDataContext dcTraining = new dcTrainingDataContext();
	public JobAbility()
	{
		//
		// TODO: 在此加入建構函式的程式碼
		//
	}

    public Reports.JobAbilityDataTable GetDataByCardYear(string OJTcard, int year)
    {
        Reports.JobAbilityDataTable dt = new Reports.JobAbilityDataTable();
        var G = (from c in dcTraining.trTrainingCardGoal
                 where c.iYear == year && c.iOJTTemplateCode == OJTcard
                 select c).FirstOrDefault();

        if (G == null)
            return dt;
        else
        {
            Reports.JobAbilityRow row= dt.NewJobAbilityRow();
            row.MonthG1 = G.iMonth1.Value;
            row.MonthG2 = G.iMonth2.Value;
            row.MonthG3 = G.iMonth3.Value;
            row.MonthG4 = G.iMonth4.Value;
            row.MonthG5 = G.iMonth5.Value;
            row.MonthG6 = G.iMonth6.Value;
            row.MonthG7 = G.iMonth7.Value;
            row.MonthG8 = G.iMonth8.Value;
            row.MonthG9 = G.iMonth9.Value;
            row.MonthG10 = G.iMonth10.Value;
            row.MonthG11 = G.iMonth11.Value;
            row.MonthG12 = G.iMonth12.Value;
            row.MonthGAvg = G.iAvg.Value;

            row.MonthA1 = GetDataByMonth(OJTcard, year, 1);
            row.MonthA2 = GetDataByMonth(OJTcard, year, 2);
            row.MonthA3 = GetDataByMonth(OJTcard, year, 3);
            row.MonthA4 = GetDataByMonth(OJTcard, year, 4);
            row.MonthA5 = GetDataByMonth(OJTcard, year, 5);
            row.MonthA6 = GetDataByMonth(OJTcard, year, 6);
            row.MonthA7 = GetDataByMonth(OJTcard, year, 7);
            row.MonthA8 = GetDataByMonth(OJTcard, year, 8);
            row.MonthA9 = GetDataByMonth(OJTcard, year, 9);
            row.MonthA10 = GetDataByMonth(OJTcard, year, 10);
            row.MonthA11 = GetDataByMonth(OJTcard, year, 11);
            row.MonthA12 = GetDataByMonth(OJTcard, year, 12);
            row.MonthAAvg = (row.MonthA1 + row.MonthA2 + row.MonthA3 + row.MonthA4 + row.MonthA5 + row.MonthA6
                + row.MonthA7 + row.MonthA8 + row.MonthA9 + row.MonthA10 + row.MonthA11 + row.MonthA12) / 12;
            dt.Rows.Add(row);
            return dt;
        }
    }

    public int GetDataByMonth(string OJTcard, int year, int month)
    {
        DateTime adate = new DateTime(year,month,1);
        DateTime ddate = adate.AddMonths(1);

        //var d = (from c in dcTraining.trOJTStudentD
        //         where c.OJT_sCode == OJTcard
        //         && c.bPass == true
        //         && c.dFinalCheckDate >= adate
        //         && c.dFinalCheckDate < ddate
        //         select c.iJobScore).Sum();

        //trOJTTemplateDetail_Repo ojtTplDtlRepo = new trOJTTemplateDetail_Repo();
        //List<trOJTTemplateDetail> ojtTplDtlList = ojtTplDtlRepo.GetByOjtTplCode(OJTcard);

        //trOJTStudentM_Repo ojtSmRepo = new trOJTStudentM_Repo();
        //List<trOJTStudentM> ojtSmList = ojtSmRepo.GetByOjtCode(OJTcard);

        DateTime datetime = DateTime.Now.Date;

        int smQty = (from sm in dcTraining.trOJTStudentM
                       join tts in dcTraining.BASETTS on sm.sNobr equals tts.NOBR
                       where BASETTS_Repo.EMP_HIRED_TTSCODE.Contains(tts.TTSCODE) && tts.ADATE <= datetime && tts.DDATE >= datetime && sm.OJT_sCode == OJTcard
                       select sm.sNobr).Count();
        

        var sumValue = (from c in dcTraining.trOJTStudentD
                        where c.bPass == true
                            && c.dFinalCheckDate < ddate
                            && c.OJT_sCode == OJTcard
                            && (from sm in dcTraining.trOJTStudentM 
                                join tts in dcTraining.BASETTS on sm.sNobr equals tts.NOBR
                                where BASETTS_Repo.EMP_HIRED_TTSCODE.Contains(tts.TTSCODE) && tts.ADATE<= datetime && tts.DDATE >= datetime  && sm.OJT_sCode==OJTcard 
                                select sm.sNobr).Contains(c.sNobr)
                            && (from od in dcTraining.trOJTTemplateDetail where od.OJT_sCode==OJTcard select od.trCourse_sCode).Contains(c.trCourse_sCode)
                        select c.iJobScore
                            ).Sum();


        if (sumValue == null)
            return 0;
        else if (smQty == 0)
        {
            return 0;
        }
        else
        {
            int i = Convert.ToInt32(sumValue);
            return i / smQty;
        }         
    }
}