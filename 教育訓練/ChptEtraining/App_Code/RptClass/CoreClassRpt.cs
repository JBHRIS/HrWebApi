using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// CoreClassRpt 的摘要描述
/// </summary>
public class CoreClassRpt
{
    private dcTrainingDataContext dcTraining = new dcTrainingDataContext();
    public String 課程名稱
    {
        get;
        set;
    }
    public int 計畫開課梯次
    {
        get;
        set;
    }
    public int 計畫人次
    {
        get;
        set;
    }
    public int 計畫費用
    {
        get;
        set;
    }
    public int 實際開課梯次
    {
        get;
        set;
    }
    public int 實際人次
    {
        get;
        set;
    }
    public int 實際費用
    {
        get;
        set;
    }
    public int 差異開課梯次
    {
        get;
        set;
    }
    public int 差異人次
    {
        get;
        set;
    }
    public int 差異費用
    {
        get;
        set;
    }
    public double 開課達成率
    {
        get;
        set;
    }
    public double 培育達成率
    {
        get;
        set;
    }    

	public CoreClassRpt()
	{
		//
		// TODO: 在此加入建構函式的程式碼
		//
	}

    public List<CoreClassRpt> GetData(String catCode,int year)
    {
        List<CoreClassRpt> list = new List<CoreClassRpt>();

        //年度計畫
        var TrainingPlanDetail = (from c in dcTraining.trTrainingPlanDetail
                                  where c.iYear == year
                                  select c).ToList();

        //實際開課
        var TrainingDetailM = (from c in dcTraining.trTrainingDetailM
                               where c.iYear == year
                               && c.bIsPublished == true
                               select c).ToList();

        var cats = (from c in dcTraining.trCategory
                    where c.sParentCode == catCode
                    select c).ToList();

        foreach ( var cat in cats )
        {
            CoreClassRpt obj = new CoreClassRpt();
            obj.課程名稱 = cat.sName;
            obj.計畫開課梯次 = getPlanSession(cat.sCode , TrainingPlanDetail);
            obj.計畫人次 = getPlanStudents(cat.sCode , TrainingPlanDetail);
            obj.計畫費用 = getPlanAmt(cat.sCode, TrainingPlanDetail);

            obj.實際開課梯次 = getClassSession(cat.sCode, TrainingDetailM);
            obj.實際人次 = getClassStudents(cat.sCode, TrainingDetailM);
            obj.實際費用 = getClassActualAmt(cat.sCode, TrainingDetailM);

            obj.差異開課梯次 = obj.實際開課梯次 - obj.計畫開課梯次;
            obj.差異人次 = obj.實際人次 - obj.計畫人次;
            obj.差異費用 = obj.實際費用 - obj.計畫費用;

            if (obj.計畫開課梯次 == 0)
                obj.開課達成率 = 0;
            else
                obj.開課達成率 = (Double)obj.實際開課梯次 / (Double)obj.計畫開課梯次;                
            if ( obj.計畫人次 == 0 )
                obj.培育達成率 = 0;                
            else
                obj.培育達成率 = (Double)obj.實際人次 / (Double)obj.計畫人次;

            list.Add(obj);
        }

        if (list.Count > 0)
        {
            CoreClassRpt obj = new CoreClassRpt();
            obj.課程名稱 = "合計";
            obj.計畫開課梯次 = (from c in list
                          select c.計畫開課梯次).Sum();
            obj.計畫人次 = (from c in list
                        select c.計畫人次).Sum();
            obj.計畫費用 = (from c in list
                        select c.計畫費用).Sum();

            obj.實際開課梯次 = (from c in list
                          select c.實際開課梯次).Sum();
            obj.實際人次 = (from c in list
                        select c.實際人次).Sum();
            obj.實際費用 = (from c in list
                        select c.實際費用).Sum();

            obj.差異開課梯次 = (from c in list
                          select c.差異開課梯次).Sum();

            obj.差異人次 = (from c in list
                        select c.差異人次).Sum();
            obj.差異費用 = (from c in list
                        select c.差異費用).Sum();

            //obj.開課達成率 = (from c in list
            //             select c.開課達成率).Average();

            obj.開課達成率 = (Double)obj.實際開課梯次 / (Double)obj.計畫開課梯次;

            //obj.培育達成率 = (from c in list
            //             select c.培育達成率).Average();

            obj.培育達成率 = (Double)obj.實際人次 / (Double)obj.計畫人次;

            list.Add(obj);
        }
        return list;
    }

    //年度計畫資料抓取
    private int getPlanSession(string catCode,List<trTrainingPlanDetail> list)
    {      
        var r = (from c in list
                 where c.sKey == catCode
                 select c.iSession).Max();

        if ( r.HasValue )
            return r.Value;
        else
            return 0;        
    }

    private int getPlanStudents(string catCode , List<trTrainingPlanDetail> list)
    {
        var r = (from c in list
                 where c.sKey == catCode
                 select c.iNumOfPeople).Sum();

        if ( r!=null)
            return r;
        else
            return 0;
    }

    //年度計畫費用
    private int getPlanAmt(string catCode, List<trTrainingPlanDetail> list)
    {
        var r = (from c in list
                 where c.sKey == catCode
                 select c.iAmt).Sum();

        if (r!=null)
            return r;
        else
            return 0;
    }


    //實際開課抓取
    private int getClassSession(string catCode, List<trTrainingDetailM> list)
    {
        var r = (from c in list
                 where c.sKey == catCode
                 && c.bIsPublished == true
                 select c.iSession).Max();

        if ( r.HasValue )
            return r.Value;
        else
            return 0;
    }


    private int getClassStudents(string catCode, List<trTrainingDetailM> list)
    {
        var r = (from c in list
                 where c.sKey == catCode
                 && c.bIsPublished == true
                 select c.iStudentNum).Sum();

        if ( r.HasValue )
            return r.Value;
        else
            return 0;
    }

    private int getClassActualAmt(string catCode, List<trTrainingDetailM> list)
    {
        var r = (from c in list
                 where c.sKey == catCode
                 && c.bIsPublished == true
                 select c.iActualAMT).Sum();

        if (r !=null)
            return r;
        else
            return 0;
    }
}


