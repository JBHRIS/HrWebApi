using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Repo;

public partial class TransOldOjtCourse : JBWebPage
{
    private dcTrainingDataContext dc = new dcTrainingDataContext();
    //private trOJTStudentD_Repo ojtsdRepo = new trOJTStudentD_Repo();
    protected NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void RadButton2_Click(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        var pa9List = (from c in dc.PA9_11
                       select c).ToList();
        var ojtClassMappingList = (from c in dc.OjtClassMapping
                                   select c).ToList();
        var courseList = (from c in dc.trCourse
                          select c).ToList();


        foreach ( var pa9 in pa9List )
        {
            DateTime dt = ConvertDateTime(pa9.ABLYMD);
            //if (dt.CompareTo(new DateTime(2012, 7, 1)) <= 0)
            //{
            if (dt.CompareTo(new DateTime(2012 ,12 , 31)) < 0 )
            {
                var ojbClassMapping = (from c in ojtClassMappingList
                                       where c.OjtClass_Old == pa9.ABLNO
                                       select c).FirstOrDefault();

                if ( ojbClassMapping == null )
                    continue;

                trOJTStudentD_Repo ojtsdRepo = new trOJTStudentD_Repo(dc.Connection);
                trOJTStudentD obj = ojtsdRepo.GetByNobrPassCourse(pa9.EMPNO , ojbClassMapping.OjtClass_new);
                if ( obj != null )
                {
                    obj.bPass = true;
                    obj.dFinalCheckDate = dt;
                    obj.dCheckDate = dt;
                    ojtsdRepo.Update(obj);
                    ojtsdRepo.Save();
                }
                else
                {
                    trOJTStudentD newObj = new trOJTStudentD();
                    newObj.bPass = true;
                    newObj.dCheckDate = dt;
                    newObj.dFinalCheckDate = dt;
                    newObj.sNobr = pa9.EMPNO;
                    newObj.trCourse_sCode = ojbClassMapping.OjtClass_new;
                    newObj.iJobScore = courseList.Where(c => c.sCode == ojbClassMapping.OjtClass_new).FirstOrDefault().iJobScore;
                    newObj.OJT_sCode = "565e341c-4331-4971-bd03-cd513bc7f035";
                    ojtsdRepo.Add(newObj);
                    ojtsdRepo.Save();
                    //logger.Info(pa9.EMPNO +","+ojbClassMapping.OjtClass_new);
                }
            }
            //}
        }

        AlertMsg("完成");
    }

    public DateTime ConvertDateTime(string str)
    {
        int y = 0;
        int m = 0;
        int d = 0;
        if (str.Length == 6)
        {
            y = Convert.ToInt32(str.Substring(0, 2)) + 1911;
            m = Convert.ToInt32(str.Substring(2, 2));
            d = Convert.ToInt32(str.Substring(4, 2));
        }
        else if (str.Length == 7)
        {
            y = Convert.ToInt32(str.Substring(0, 3)) + 1911;
            m = Convert.ToInt32(str.Substring(3, 2));
            d = Convert.ToInt32(str.Substring(5, 2));
        }
        else
        {
            y = Convert.ToInt32(str.Substring(0, 4));
            m = Convert.ToInt32(str.Substring(4, 2));
            d = Convert.ToInt32(str.Substring(6, 2));
        }

        return new DateTime(y, m, d);
    }

}