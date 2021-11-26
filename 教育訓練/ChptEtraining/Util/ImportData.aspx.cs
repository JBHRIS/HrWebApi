using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Repo;
public partial class Util_ImportData : JBWebPage
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        dcTrainingDataContext dc = new dcTrainingDataContext();

        var list = (from c in dc.ImportInnerTeacher select c).ToList();
        BASE_Repo baseRepo = new BASE_Repo();   
        trTeacher_Repo tRepo = new trTeacher_Repo();

        foreach (var l in list)
        {
            BASE b = baseRepo.GetByNobr(l.Nobr);

            if (b != null)
            {
                trTeacher t = new trTeacher();
                t.bEntTeacherType = true;
                t.sCode = l.Code;
                t.sEmail = b.EMAIL;
                t.sName = b.NAME_C;
                t.sTeacherID = b.IDNO;
                t.sTel = b.TEL1;
                t.sCellPhone = b.GSM;
                t.sNote2 = l.Skill;
                t.sNote1 = l.School;
                t.sNote3 = l.WorkExp;
                t.sNobr = l.Nobr;
                tRepo.Add(t);
                tRepo.Save();
            }
        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        dcTrainingDataContext dc = new dcTrainingDataContext();

        var list = (from c in dc.ImportCourse select c).ToList();
        trCourse_Repo tRepo = new trCourse_Repo();

        foreach (var l in list)
        {
            trCourse o = new trCourse();
            o.bIsSerialCourse = false;
            o.dDateA = new DateTime(1900, 1, 1);
            o.dDateD = new DateTime(9999, 12, 31);
            o.iCourseTime = 0;
            o.iEdition = null;
            o.iJobScore = 0;
            o.iLeftDay = null;
            o.iValidityDay = null;
            o.sCode = Guid.NewGuid().ToString();
            o.sContent = null;
            o.sName = l.Name;
            tRepo.Add(o);
            tRepo.Save();
        }
    }
}