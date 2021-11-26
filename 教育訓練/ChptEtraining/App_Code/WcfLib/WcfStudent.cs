using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Repo;
// 注意: 您可以使用 [重構] 功能表上的 [重新命名] 命令同時變更程式碼、svc 和組態檔中的類別名稱 "Service"。
public class WcfStudent : IWcfStudent
{
	public void DoWork()
	{
	}


    public List<trTrainingDetailM> GetByYearDateRange_DLO(int year, DateTime adate, DateTime ddate)
    {
        trTrainingDetailM_Repo tdmRepo = new trTrainingDetailM_Repo();
        var result= tdmRepo.GetByYearDateRange_DLO(year, adate, ddate);
        return result;
    }

    /// <summary>
    /// 取得課程資料 By 工號、日期區間、是否通過
    /// </summary>
    /// <param name="Anobr"></param>
    /// <param name="AdatetimeB"></param>
    /// <param name="AdatetimeE"></param>
    /// <param name="Apass"></param>
    /// <returns></returns>
    List<WcfCourseDto> IWcfStudent.GetByNobrDateRange(string Anobr, DateTime AdatetimeB, DateTime AdatetimeE,bool Apass)
    {
        trTrainingStudentM_Repo tsmRepo = new trTrainingStudentM_Repo();
        var list= tsmRepo.GetByNobrDateRangePass_DLO(Anobr, AdatetimeB, AdatetimeE, Apass);
        return (from c in list
                select new WcfCourseDto
                    {
                        ClassId = c.iClassAutoKey,
                        CourseCategoryCode = c.trTrainingDetailM.trCourse.trCategoryCourse[0].trCategory.sCode,
                        CourseCategoryName = c.trTrainingDetailM.trCourse.trCategoryCourse[0].trCategory.sName,
                        CourseCode = c.trTrainingDetailM.trCourse.sCode,
                        CourseName = c.trTrainingDetailM.trCourse.sName,
                        CourseDateB = c.trTrainingDetailM.dDateTimeA.Value,
                        CourseDateE = c.trTrainingDetailM.dDateTimeD.Value
                    }).ToList();
    }
}
