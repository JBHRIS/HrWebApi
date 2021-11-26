using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Repo;
public partial class AlterClassRptEDate : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        trTrainingDetailM_Repo tdmRepo = new trTrainingDetailM_Repo();        
        trTrainingStudentM_Repo tsm = new trTrainingStudentM_Repo();
        List<trTrainingDetailM> tdmList = tdmRepo.GetByAll();
        foreach(var tdm in tdmList)        
        {
            if (tdm.bIsNeedClassRpt && tdm.bIsPublished)
            { }
            else
                continue;

            if (tdm.dClassRptDeadline.HasValue)
            {
                if (tdm.dClassRptDeadline.Value.CompareTo(new DateTime(2012, 8, 31)) <= 0)
                {


                }
                else
                    continue;
            }
            else
            {
                continue;
            }
            


            List<trTrainingStudentM> list = tsm.GetByClassID_WithPresence_DLO(tdm.iAutoKey);
            var b = (from c in list where c.dNote2KeyDate.HasValue ==false && c.bPresence select c).Any();
            if (b)
            {
                tdm.dClassRptDeadline = new DateTime(2012, 9, 1);
                tdmRepo.Update(tdm);
                tdmRepo.Save();
            }



        }
    }
}