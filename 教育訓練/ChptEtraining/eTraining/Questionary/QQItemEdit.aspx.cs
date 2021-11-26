using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Repo;
using Telerik.Web.UI;
public partial class eTraining_Questionary_QQItemEdit:JBWebPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);

        if ( Request.QueryString["Id"] == null )
            throw new ApplicationException("未傳入參數");
        else
        {
            QQItem_Repo qItemRepo = new QQItem_Repo();
            QQItem qqItemObj= qItemRepo.GetByPk(Convert.ToInt32(Request.QueryString["Id"]));
            if ( qqItemObj != null )
            {
                tbQuestionText.Text = qqItemObj.QuestionText;
            }
        }
    }
    protected void btnSave_Click(object sender , EventArgs e)
    {
        QQItem_Repo qItemRepo = new QQItem_Repo();
        QQItem qqItemObj = qItemRepo.GetByPk(Convert.ToInt32(Request.QueryString["Id"]));
        if ( qqItemObj != null )
        {
            qqItemObj.QuestionText = tbQuestionText.Text;
            qItemRepo.Update(qqItemObj);
            qItemRepo.Save();
            RadScriptManager.RegisterStartupScript(this , typeof(Page) , this.GetType().ToString() , "CloseAndRebind();" , true);
        }
    }
}