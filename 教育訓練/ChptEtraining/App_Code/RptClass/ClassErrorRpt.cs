using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// ClassErrorByDateRpt 的摘要描述
/// </summary>
public class ClassErrorRpt
{
    private dcTrainingDataContext dcTraining = new dcTrainingDataContext();
	public ClassErrorRpt()
	{
		//
		// TODO: 在此加入建構函式的程式碼
		//
	}

    public Reports.ClassErrorDataTable GetClassErrorBy2Date(DateTime adate,DateTime ddate)
    {
        dcTraining.Log = new DebuggerWriter();
        Reports.ClassErrorDataTable dt = new Reports.ClassErrorDataTable();
        var classErrors = (from cse in dcTraining.trClassStudentError
                           join dm in dcTraining.trTrainingDetailM on cse.iClassAutoKey equals dm.iAutoKey
                           where dm.bIsPublished == true 
                           && dm.dDateTimeD.Value.CompareTo(adate) >=0
                           && dm.dDateTimeD.Value.CompareTo(ddate) <=0
                           group cse by cse.StudentErrorCode into g                           
                           select new {code=g.Key,count=g.Count()}).ToList();

        var errors = (from c in dcTraining.trStudentError
                      orderby c.sName ascending
                      select c).ToList();

        int amt = (from c in classErrors select c).Sum(p => p.count);

        foreach (var e in errors)
        {
            Reports.ClassErrorRow row = dt.NewClassErrorRow();
            row.ErrorCat = e.sName;

            var r = (from c in classErrors
                     where c.code == e.sCode
                     select c).FirstOrDefault();

            if (r != null && amt!=0)
            {
                row.ErrorCount = r.count;
                row.ErrorPercent = (Double)r.count / amt;
            }
            else
            {
                row.ErrorCount = 0;
                row.ErrorPercent = 0;
            }

            dt.Rows.Add(row);
        }

        return dt;
    }
}