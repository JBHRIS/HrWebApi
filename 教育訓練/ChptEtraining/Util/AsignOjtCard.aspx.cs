using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Repo;
public partial class Util_AsignOjtCard : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {



    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        trOJTTemplateDetail_Repo ojtTplDelRepo = new trOJTTemplateDetail_Repo();
        List<trOJTTemplateDetail> list = ojtTplDelRepo.GetByOjtTplCode("565e341c-4331-4971-bd03-cd513bc7f035");

        List<String> courseList = (from c in list select c.trCourse_sCode).ToList();


        BASE_Repo baseRepo = new BASE_Repo();
        List<BASE> baseList = baseRepo.GetAll();

        trOJTStudentD_Repo ojtsdRepo = new trOJTStudentD_Repo();

        foreach (var b in baseList)
        {
            List<trOJTStudentD> ojtsdList = ojtsdRepo.GetByNobrCourseList(b.NOBR, courseList);
            if (ojtsdList.Count > 0)
            {
                OjtCardGrantedRecord_Repo cgrRepo = new OjtCardGrantedRecord_Repo();
                List<OjtCardGrantedRecord> cgrList= cgrRepo.GetByNobr(b.NOBR);

                if (cgrList.Count > 0)
                {
                    //do nothing
                }
                else
                {
                    trOJTStudentM_Repo ojtsmRepo = new trOJTStudentM_Repo();
                    trOJTStudentM ojtsmObj= ojtsmRepo.GetByNobrOjtCode(b.NOBR, "565e341c-4331-4971-bd03-cd513bc7f035");
                    if (ojtsmObj == null)
                    {
                        //新增
                        ojtsmObj = new trOJTStudentM();
                        ojtsmObj.dKeyDate = DateTime.Now;
                        ojtsmObj.OJT_sCode = "565e341c-4331-4971-bd03-cd513bc7f035";
                        ojtsmObj.sNobr = b.NOBR;

                        ojtsmRepo.Add(ojtsmObj);
                        ojtsmRepo.Save();
                    }
                }
            }
        }


    }
    protected void Button2_Click(object sender, EventArgs e)
    {
            trOJTStudentM_Repo ojtSmRepo = new trOJTStudentM_Repo();
            BASE_Repo baseRepo = new BASE_Repo();
            List<BASE> baseList = baseRepo.GetEmpHiredByDate_Dlo(DateTime.Now.Date);
            foreach (var b in baseList)
            {
                ojtSmRepo.CheckEmpOjtCard(b.NOBR);
            }
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        DateTime datetime = new DateTime(2012, 1, 1, 0, 10, 10);
    }
}