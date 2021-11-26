using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Repo;
public partial class eTraining_Reports_Review_EmpOjtJobView : JBWebPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        UserQuickSearch1.sHandler += new UC_UserQuickSearch.SelectedEventHandler(gvSelected);
    }

    protected void gvSelected(string nobr, GridDataItem sItem)
    {
        lblNobr.Text = nobr;
        gv.Rebind();
    }

    private void checkHaveOjtCard()
    {
        trOJTStudentM_Repo ojtStudentMRepo = new trOJTStudentM_Repo();
        trOJTStudentM ojtSM = ojtStudentMRepo.GetByNobrOjtCode(lblNobr.Text , cbxCard.SelectedValue);

        if ( ojtSM != null )
        {            
            gv.Visible = true;
            lblMsg.Visible = false;            
        }
        else
        {
            gv.Visible = false;
            lblMsg.Visible = true;
        }

    }

    protected void gv_ItemDataBound(object sender , GridItemEventArgs e)
    {
        if ( e.Item is GridDataItem )
        {
            GridDataItem item = e.Item as GridDataItem;
            CheckBox ckPass = item["bPass"].Controls[0] as CheckBox;
            CheckBox ckTrainned = item["trainned"].Controls[0] as CheckBox;        

            //如果已經通過
            if ( ckPass.Checked == true )
            {
                item["DataEdit"].Enabled = false;
                ckTrainned.Enabled = false;
                ckTrainned.Checked = true;                
            }
            else
            {
                ckTrainned.Enabled = true;              
            }

            //處理以訓練欄位
            if ( item["dCheckDate"].Text.Length > 0 )
            {
                ckTrainned.Checked = true;
            }
            else
                ckTrainned.Checked = false;
        }
    }


    protected void gv_DataBound(object sender , EventArgs e)
    {
        loadJobScore();
        checkHaveOjtCard();
    }


    private void loadJobScore()
    {
        int allScore = 0;
        int userScore = 0;

        foreach ( GridDataItem item in gv.Items )
        {
            CheckBox ckPass = item["bPass"].Controls[0] as CheckBox;

            int score = 0;
            int.TryParse(item["CourseJobScore"].Text , out score);

            if ( ckPass.Checked == true )
            {
                userScore = userScore + score;
            }
            allScore = allScore + score;
        }

        lblUserJobScore.Text = "個人積分 " + userScore.ToString();
        lblJobScoreAmt.Text = "總積分" + allScore.ToString();
    }
    protected void cbxCard_SelectedIndexChanged(object sender , RadComboBoxSelectedIndexChangedEventArgs e)
    {
        gv.Rebind();
    }
}