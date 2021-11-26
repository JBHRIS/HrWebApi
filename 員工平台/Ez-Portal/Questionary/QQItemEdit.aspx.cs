using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL;
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
                tbQuestionText.Text = qqItemObj.QuestionText;
            if (qqItemObj.TypeCode.Equals("SAQ")) 
            { 
                pnlSaq.Visible = true;
                if (qqItemObj.MinCharCount.HasValue)
                    ntbMinCharCount.Text = qqItemObj.MinCharCount.Value.ToString();
                else
                    ntbMinCharCount.Text = "";
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

            if (qqItemObj.TypeCode.Equals("SAQ"))
            {
                if (ntbMinCharCount.Value.HasValue)
                    qqItemObj.MinCharCount = Convert.ToInt32(ntbMinCharCount.Value);
                else
                    qqItemObj.MinCharCount = null;
            }

            qqItemObj.CreatedBy = Juser.Nobr;
            qqItemObj.CreatedDate = DateTime.Now;
            qItemRepo.Update(qqItemObj);
            qItemRepo.Save();
            RadScriptManager.RegisterStartupScript(this , typeof(Page) , this.GetType().ToString() , "CloseAndRebind();" , true);
        }
    }
}