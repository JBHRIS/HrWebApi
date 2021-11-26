using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// MailSetting 的摘要描述
/// </summary>
public class MailSetting
{
    private dcTrainingDataContext dcTraining = new dcTrainingDataContext();
    public string SmtpServer { get; set; }
    public string MailFrom { get; set; }
    public int SmtpPort  { get; set; }
    public string SmtpUser { get; set; }
    public string SmtpPassword { get; set; }
    public bool IsBodyHtml { get; set; }    

	public MailSetting()
	{
        var sysMail = from c in dcTraining.mtCode
                      where c.sCategory == "sysMail"
                      select c;

        var data = sysMail.Where(c => c.sCode == "SmtpServer").FirstOrDefault();
        SmtpServer = data.s1;

        data = sysMail.Where(c => c.sCode == "SmtpPort").FirstOrDefault();
        SmtpPort = int.Parse(data.s1);

        data = sysMail.Where(c => c.sCode == "MailFrom").FirstOrDefault();
        MailFrom = data.s1;

        data = sysMail.Where(c => c.sCode == "SmtpUser").FirstOrDefault();
        SmtpUser = data.s1;

        data = sysMail.Where(c => c.sCode == "SmtpPassword").FirstOrDefault();
        SmtpPassword = data.s1;

        IsBodyHtml = true;  
	}

    
}