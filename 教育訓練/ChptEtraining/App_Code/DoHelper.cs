using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Repo;
/// <summary>
/// DoHelper 的摘要描述
/// </summary>
public class DoHelper
{
    private dcTrainingDataContext dcTraining = new dcTrainingDataContext();
    private trTrainingDetailM_Repo tdmRepo = new trTrainingDetailM_Repo();
    public DoHelper()
    {
        //
        // TODO: 在此加入建構函式的程式碼
        //
    }




    public void setCbYear(Telerik.Web.UI.RadComboBox cbYear)
    {
        Dictionary<string, string> yearDic = new Dictionary<string, string>();

        var data = (from c in dcTraining.trTrainingDetailM select c.iYear).Distinct();

        //先找資料庫有的年度
        foreach (var row in data)
        {
            if (!yearDic.ContainsKey(row.ToString()))
                yearDic.Add(row.ToString(), row.ToString());
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

    /// <summary>
    ///是否為已有資格者、如果仍有資格，傳回true
    ///傳入，課程代碼、工號、開課日期(是否有資格，用看哪一天計算)
    /// </summary>
    /// <param name="courseCode"></param>
    /// <param name="nobr"></param>
    /// <param name="classDate"></param>
    /// <returns></returns>
    public bool isQualifier(string courseCode, string nobr, DateTime classDate)
    {
        var data = (from sm in dcTraining.trTrainingStudentM
                    join dm in dcTraining.trTrainingDetailM
                    on sm.iClassAutoKey equals dm.iAutoKey
                    where sm.sNobr == nobr
                    && sm.bPass == true
                    && dm.bIsPublished == true
                    && dm.dExpiryDate >= classDate
                    && dm.trCourse_sCode == courseCode
                    select dm).FirstOrDefault();

        if (data != null)//有資料，代表有資格
            return true;
        else
            return false;
    }


    /// <summary>
    /// 傳回是否為此課程的講師
    /// </summary>
    /// <param name="ClassID"></param>
    /// <param name="Nobr"></param>
    /// <returns></returns>
    public bool IsClassTeacher(int ClassID, string Nobr)
    {
        var teacher = (from act in dcTraining.trAttendClassTeacher
                       join t in dcTraining.trTeacher on act.sTeacherCode equals t.sCode
                       where act.iClassAutoKey == ClassID
                       && t.sNobr == Nobr
                       select t.sNobr).FirstOrDefault();
        if (teacher != null)
            return true;
        else
            return false;
    }

}