using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using JB.WebModules;
using JB.WebModules.Authentication;
using JB.WebModules.Accounts;
using System.Threading;
using System.Globalization;
using JB.WebModules.Business;
using BL;
using System.Linq;
using System.Net.Mail;
using System.Text;
public partial class ForgetPwd : JBBasicWebPage
{
    protected override void InitializeCulture()
    {
        String selectedLanguage = "en-US";
        //if (Request.Cookies["lang"] != null)
        //    selectedLanguage = Request.Cookies["lang"].Value;
        //else
        //    selectedLanguage = "en-US";

        UICulture = selectedLanguage;
        Culture = selectedLanguage;

        Thread.CurrentThread.CurrentCulture =
        CultureInfo.CreateSpecificCulture(selectedLanguage);
        Thread.CurrentThread.CurrentUICulture = new
        CultureInfo(selectedLanguage);

        base.InitializeCulture();
    }


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            SetFocus(tbId);
    }

    protected void btnSend_Click(object sender, EventArgs e)
    {
        BASE_REPO baseRepo = new BASE_REPO();
        BASE bObj = baseRepo.GetByNobr(tbId.Text);
        if (bObj == null)
        {
            Show("Wrong ID!!");
            return;
        }
        else
        {
            string newPassword = Guid.NewGuid().ToString().Substring(0, 8);

            PARAMETER_REPO pRepo = new PARAMETER_REPO();
            var pList = pRepo.GetAll();

            string smtpServer = (from c in pList where c.CODE.Equals("JbMail.host") select c.VALUE).FirstOrDefault();
            string user = (from c in pList where c.CODE.Equals("JbMail.sys_mail") select c.VALUE).FirstOrDefault();
            string pwd = (from c in pList where c.CODE.Equals("JbMail.sys_pwd") select c.VALUE).FirstOrDefault();
            int port = Convert.ToInt32((from c in pList where c.CODE.Equals("JbMail.port") select c.VALUE).FirstOrDefault());

            SmtpClient smtpClient = new SmtpClient(smtpServer, port);
            smtpClient.Credentials = new System.Net.NetworkCredential(user, pwd);
            MailMessage mailMessage = new MailMessage();
            mailMessage.SubjectEncoding = System.Text.Encoding.UTF8;
            mailMessage.BodyEncoding = System.Text.Encoding.UTF8; ;
            mailMessage.IsBodyHtml = true;
            mailMessage.From = new MailAddress(user, user);

            string url = @"Http://hr.jbjob.com.tw/asml/ezportal/Account/ChangPWD.aspx";

            StringBuilder sb = new StringBuilder();
            mailMessage.Subject = "You requested a new Leave Management Portal password.";

            sb.Append("Hi " + bObj.NAME_C + "<br><br>");
            sb.Append("You recently asked to reset your Leave Management Portal password.<br>");
            sb.Append("please go to " + url + " to reset your password.<br><br>");
            sb.Append("You can enter the following password reset code below:<br>");
            sb.Append(newPassword + "<br><br>");
            sb.Append("Thanks,<br>");
            sb.Append("The Leave Management Portal Security Team");

            mailMessage.Body = sb.ToString();

            mailMessage.To.Add(bObj.EMAIL);
            smtpClient.Send(mailMessage);

            bObj.PASSWORD = newPassword;
            baseRepo.Update(bObj);
            baseRepo.Save();
            Show("Password has been changed");
        }
    }
}
