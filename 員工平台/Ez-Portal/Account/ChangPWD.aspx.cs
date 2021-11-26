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
using System.Data.SqlClient;
using JB.WebModules;
using System.Net.Mail;
using System.Text;
using BL;
using System.Linq;

public partial class Account_ChangPWD : JBWebPage 
{
    protected void Page_Load(object sender, EventArgs e) 
    {
        if (!IsPostBack)
        {
            HRDsTableAdapters.rv_sysDefaultTableAdapter vd = new HRDsTableAdapters.rv_sysDefaultTableAdapter();
            HRDs.rv_sysDefaultDataTable dt = vd.GetData_sysDefault();
            foreach (DataRow Row1 in dt.Rows)
            {
                if (Row1["sKey"].ToString().Trim() == "iPwLen")
                {
                    if (Row1["sValue"].ToString().Trim() != "0")
                    {
                        TextBox2.MaxLength = int.Parse(Row1["sValue"].ToString());
                        TextBox3.MaxLength = int.Parse(Row1["sValue"].ToString());
                    }
                }
            }
        }
    }

    protected void Button1_Click(object sender, EventArgs e) 
    {
        if (TextBox2.Text.Length < TextBox2.MaxLength)
        {
            Message.Show(GetLocalResourceObject("MsgPwdLenMinWrong").ToString() + TextBox2.MaxLength);
            return;
        }

        if (TextBox3.Text.Length < TextBox3.MaxLength)
        {
            Message.Show(GetLocalResourceObject("MsgPwdLenMinWrong").ToString() + TextBox3.MaxLength);
            return;
        }
        if (!JbUser.PASSWORD.Trim().Equals(TextBox1.Text.Trim())) 
        {
            //Message.Show("原密碼輸入錯誤");
            Message.Show(GetLocalResourceObject("MsgOldPwdWrong").ToString());
            return;
        }

        //判斷密碼不可與前幾次相同       
        HRDs.rv_sysDefaultDataTable dt1 =new  HRDsTableAdapters.rv_sysDefaultTableAdapter().GetData_sysDefault();        
       
        foreach (DataRow Row in dt1.Rows)
        {
            if (Row["sKey"].ToString().Trim() == "iPwChange")
            {
                if (Row["sValue"].ToString().Trim() != "0")
                {
                    HRDs.sysLoginPWDataTable dt2 = new HRDsTableAdapters.sysLoginPWTableAdapter().GetData_sysLoginPW(JbUser.NOBR);
                    int _c = 0;
                    if (int.Parse(Row["sValue"].ToString().Trim()) > dt2.Rows.Count)
                        _c = dt2.Rows.Count;
                    else
                        _c = int.Parse(Row["sValue"].ToString().Trim());
                    for (int i = 0; i < _c; i++)
                    {
                        if (TextBox2.Text.Trim() == dt2.Rows[i]["suserpwnew"].ToString().Trim())
                        {
                            Message.Show(GetLocalResourceObject("MsgPwdBeenUsed").ToString());
                            //Message.Show("密碼與前" + Row["sValue"].ToString().Trim() + "次相同！");
                            return;
                        }
                    }
                }
            }          
        }

        //新增密碼記錄
        HRDsTableAdapters.sysLoginPWTableAdapter rv_sysLoginPW = new HRDsTableAdapters.sysLoginPWTableAdapter();
        HRDs.sysLoginPWDataTable rv_sysLoginPWDs = new HRDs.sysLoginPWDataTable();
        HRDs.sysLoginPWRow newRow = rv_sysLoginPWDs.NewsysLoginPWRow();
        newRow.sUserPWnew = TextBox2.Text;
        newRow.sUserPWold = TextBox1.Text;
        newRow.sysLoginUser_sUserID = JbUser.NOBR;
        newRow.sKeyMan = JbUser.NAME_C;
        newRow.dKeyDate = DateTime.Now;
        rv_sysLoginPWDs.AddsysLoginPWRow(newRow);
        rv_sysLoginPW.Update(rv_sysLoginPWDs);

        //更改人事基本資料密碼
        JbUser.PASSWORD = TextBox2.Text;
        JbUser.ChangePWD();
        
        notifyEmail(JbUser.NOBR);
        Page.ClientScript.RegisterStartupScript(this.GetType(), "MyScript", "<script>alert('" + GetLocalResourceObject("MsgChangePwdSuccess").ToString() + "');location.href='../Login.aspx';</script>");
    }

    private void notifyEmail(string nobr)
    {
        BASE_REPO baseRepo = new BASE_REPO();
        BASE bObj = baseRepo.GetByNobr(nobr);

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
        mailMessage.Subject = "Your Leave Management Portal password has been reset.";
        sb.Append("Hi " + bObj.NAME_C + "<br><br>");
        sb.Append("Your password has been reset on " + DateTime.Now.ToShortDateString() + "　" + DateTime.Now.ToShortTimeString() + @".<br><br>");
        //sb.Append(@"If you believe you have received this email in error, or that an unauthorized person has accessed your account, <br>");
        //sb.Append("please go to " + url + " to reset your password immediately.<br><br>");
        sb.Append("Thanks,<br>");
        sb.Append("The Leave Management Portal Security Team");

        mailMessage.Body = sb.ToString();
        mailMessage.To.Add(bObj.EMAIL);
        smtpClient.Send(mailMessage);
    }
}
