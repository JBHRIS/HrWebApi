using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

public partial class eTraining_System_setMail : JBWebPage
{
    private dcTrainingDataContext dcTraining = new dcTrainingDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            loadData();
        }
    }

    private void loadData()
    {
        var dataList = (from c in dcTraining.mtCode
                        where c.sCategory == "sysMail"
                        select c).ToList();

        var SmtpServer = (from c in dataList
                          where c.sCode == "SmtpServer"
                          select c).FirstOrDefault();
        if (SmtpServer != null)
        {
            tbSmtpServer.Text = SmtpServer.s1;
        }


        var MailFrom = (from c in dataList
                        where c.sCode == "MailFrom"
                        select c).FirstOrDefault();
        if (MailFrom != null)
        {
            tbMailFrom.Text = MailFrom.s1;
        }

        var SmtpPort = (from c in dataList
                        where c.sCode == "SmtpPort"
                        select c).FirstOrDefault();
        if (SmtpPort != null)
        {
            tbSmtpPort.Text = SmtpPort.s1;
        }

        var SmtpUser = (from c in dataList
                        where c.sCode == "SmtpUser"
                        select c).FirstOrDefault();
        if (SmtpUser != null)
        {
            tbSmtpUser.Text = SmtpUser.s1;
        }

        var SmtpPassword = (from c in dataList
                        where c.sCode == "SmtpPassword"
                        select c).FirstOrDefault();
        if (SmtpPassword != null)
        {
            tbSmtpPassword.Text = SmtpPassword.s1;          
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        var dataList = (from c in dcTraining.mtCode
                        where c.sCategory == "sysMail"
                        select c).ToList();

        var SmtpServer = (from c in dataList
                          where c.sCode == "SmtpServer"
                          select c).FirstOrDefault();
        if (SmtpServer != null)
        {
            SmtpServer.s1 = tbSmtpServer.Text;
        }


        var MailFrom = (from c in dataList
                        where c.sCode == "MailFrom"
                        select c).FirstOrDefault();
        if (MailFrom != null)
        {
            MailFrom.s1 = tbMailFrom.Text;
        }

        var SmtpPort = (from c in dataList
                        where c.sCode == "SmtpPort"
                        select c).FirstOrDefault();
        if (SmtpPort != null)
        {
            SmtpPort.s1 = tbSmtpPort.Text;
        }

        var SmtpUser = (from c in dataList
                        where c.sCode == "SmtpUser"
                        select c).FirstOrDefault();
        if (SmtpUser != null)
        {
            SmtpUser.s1 = tbSmtpUser.Text;
        }

        var SmtpPassword = (from c in dataList
                            where c.sCode == "SmtpPassword"
                            select c).FirstOrDefault();
        if (SmtpPassword != null)
        {
            SmtpPassword.s1 = tbSmtpPassword.Text;
        }

        dcTraining.SubmitChanges();
        AlertMsg("存檔完成");
    }
}