using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Telerik.Web.UI;
using Repo;
public partial class eTraining_Staff_ViewTrainingCard : System.Web.UI.Page
{
    private trOJTStudentM_Repo osmRepo = new trOJTStudentM_Repo();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            osmRepo.CheckEmpOjtCard(User.Identity.Name);
        }
    }
    protected void sdsCard_Selecting(object sender , SqlDataSourceSelectingEventArgs e)
    {
        e.Command.Parameters["@nobr"].Value = User.Identity.Name;
    }
    protected void sdsCardData_Selecting(object sender , SqlDataSourceSelectingEventArgs e)
    {
        e.Command.Parameters["@nobr"].Value = User.Identity.Name;
    }
    private void loadJobScore()
    {
        int allScore = 0;
        int userScore = 0;

        foreach (GridDataItem item in gv.Items)
        {
            CheckBox ckPass = item["bPass"].Controls[0] as CheckBox;

            int score = 0;
            int.TryParse(item["CourseJobScore"].Text, out score);

            if (ckPass.Checked == true)
            {
                userScore = userScore + score;
            }
            allScore = allScore + score;
        }

        lblUserJobScore.Text = "個人積分" + userScore.ToString();
        lblJobScoreAmt.Text = "總積分" + allScore.ToString();
    }
    protected void gv_DataBound(object sender, EventArgs e)
    {
        loadJobScore();
    }
}