using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Repo;
public partial class FillOjtDetailCourseEmpty : JBWebPage
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string ojtCode = "565e341c-4331-4971-bd03-cd513bc7f035";
        trOJTStudentM_Repo ojtsmRepo = new trOJTStudentM_Repo();
        List<trOJTStudentM> ojtsmList = ojtsmRepo.GetByOjtCode(ojtCode);

        trOJTStudentD_Repo ojtSdRepo = new trOJTStudentD_Repo();
        trOJTTemplateDetail_Repo ojtTplDtlRepo = new trOJTTemplateDetail_Repo();
        List<trOJTTemplateDetail> ojtTplDtlList = ojtTplDtlRepo.GetByOjtTplCode(ojtCode);
        trCourse_Repo trCourseRepo = new trCourse_Repo();
        List<trCourse> trCourseList = trCourseRepo.GetAll();

        foreach (var ojtsm in ojtsmList)
        {
            //新增訓練卡中的項目Detail部分
            var ojtSdObjList = ojtSdRepo.GetByNobrOjtCode(ojtsm.sNobr, ojtCode);

            foreach (var d in ojtTplDtlList)
            {
                var ojtSdObj = (from c in ojtSdObjList where c.trCourse_sCode == d.trCourse_sCode select c).FirstOrDefault();

                if (ojtSdObj == null)
                {
                    trCourse trCourseObj = (from c in trCourseList where c.sCode == d.trCourse_sCode select c).FirstOrDefault();
                    trOJTStudentD ojtSdNew = new trOJTStudentD();
                    ojtSdNew.OJT_sCode = ojtCode;
                    ojtSdNew.iJobScore = trCourseObj.iJobScore;
                    ojtSdNew.trCourse_sCode = d.trCourse_sCode;

                    if (ojtSdNew.trCourse_sCode.Equals("G0100") || ojtSdNew.trCourse_sCode.Equals("G0200") || ojtSdNew.trCourse_sCode.Equals("G0300")
                        || ojtSdNew.trCourse_sCode.Equals("G0400"))
                    {
                        ojtSdNew.bPass = true;
                        ojtSdNew.dFinalCheckDate = new DateTime(2012, 1, 1);
                        ojtSdNew.sFinalCheckMan = "0074161";
                    }
                    else
                    {
                        ojtSdNew.bPass = false;
                    }
                    ojtSdNew.dCreatedDate = DateTime.Now;
                    ojtSdNew.sNobr = ojtsm.sNobr;
                    
                    ojtSdRepo.Add(ojtSdNew);
                }
            }
            ojtSdRepo.Save();
        }

        AlertMsg("done");
    }
}