using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Repo;
public partial class SetOjtZeroCoursePass : JBWebPage
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        trOJTStudentM_Repo ojtsmRepo = new trOJTStudentM_Repo();
        List<trOJTStudentM> ojtsmList= ojtsmRepo.GetByOjtCode("565e341c-4331-4971-bd03-cd513bc7f035");

        trOJTStudentD_Repo ojtsdRepo = new trOJTStudentD_Repo();

        foreach (var ojtsm in ojtsmList)
        {
            var g01 =ojtsdRepo.GetByNobrCourse(ojtsm.sNobr, "G0100");
            if (g01 != null)
            {
                g01.bPass = true;
                g01.dFinalCheckDate = new DateTime(2013, 2, 18);
                g01.sFinalCheckMan = "0074161";
                g01.dCheckDate = new DateTime(2013, 2, 18);
                g01.sCheckMan= "0074161";
                ojtsdRepo.Update(g01);
            }
            var g02 = ojtsdRepo.GetByNobrCourse(ojtsm.sNobr, "G0200");
            if (g02 != null)
            { 
                g02.bPass = true;
                g02.dFinalCheckDate = new DateTime(2013, 2, 18);
                g02.sFinalCheckMan = "0074161";
                g02.dCheckDate = new DateTime(2013, 2, 18);
                g02.sCheckMan = "0074161";
                ojtsdRepo.Update(g02);
            }
            var g03 = ojtsdRepo.GetByNobrCourse(ojtsm.sNobr, "G0300");
            if (g03 != null)
            {
                g03.bPass = true;
                g03.dFinalCheckDate = new DateTime(2013, 2, 18);
                g03.sFinalCheckMan = "0074161";
                g03.dCheckDate = new DateTime(2013, 2, 18);
                g03.sCheckMan = "0074161";
                ojtsdRepo.Update(g03);
            }

            var g04 = ojtsdRepo.GetByNobrCourse(ojtsm.sNobr, "G0400");
            if (g04 != null)
            {
                g04.bPass = true;
                g04.dFinalCheckDate = new DateTime(2013, 2, 18);
                g04.sFinalCheckMan = "0074161";
                g04.dCheckDate = new DateTime(2013, 2, 18);
                g04.sCheckMan = "0074161";
                ojtsdRepo.Update(g04);
            }

            ojtsdRepo.Save();
        }

        AlertMsg("done");
    }
}