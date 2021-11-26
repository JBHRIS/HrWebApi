using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Repo;
public partial class eTraining_Reports_Admin_Do_ClassExceptionProcess : JBWebPage
{
    dcTrainingDataContext dcTrain = new dcTrainingDataContext();
    private trTrainingDetailM_Repo tdmRepo = new trTrainingDetailM_Repo();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["ID"] != null)
            {
                lblID.Text = Request.QueryString["ID"].ToString();
                trTrainingDetailM tdm = tdmRepo.GetByKey_DLO(Convert.ToInt32(lblID.Text));
                if (tdm.bIsPublished)
                {
                    btnCancelClassPublish.Enabled = true;
                }
                else
                    btnCancelClassPublish.Enabled = false;

            }
            else
                throw new ApplicationException("無輸入課程ID");
        }
    }
    protected void btnCancelClassPublish_Click(object sender, EventArgs e)
    {
        var tdm = (from c in dcTrain.trTrainingDetailM
                   where c.iAutoKey == Convert.ToInt32(lblID.Text)
                   && c.bIsPublished == true
                   select c).FirstOrDefault();

        tdm.bIsPublished = false;
        dcTrain.SubmitChanges();
        Response.Redirect(@"~/eTraining/Admin/Do/DoCourseList.aspx",true);        
    }
}