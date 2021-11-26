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
 
using System.Collections.Generic;
using BL;
using System.Linq;
using System.Net.Mail;

public partial class HR_UpBaseCon : JBWebPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            lb_nobr.Text = JbUser.NOBR;
        }
    }
    protected void UpButton_Click(object sender, EventArgs e)
    {
        //SqlDataSource1.Update();      

    }

    protected void FormView1_ItemUpdating(object sender, FormViewUpdateEventArgs e)
    {
        if (e.NewValues["ADDR1"].ToString().Trim().Equals(""))
        {
            e.NewValues["ADDR1"] = " ";
        }
        if (e.NewValues["ADDR2"].ToString().Trim().Equals(""))
        {
            e.NewValues["ADDR2"] = " ";
        }
        if (e.NewValues["BORN_ADDR"].ToString().Trim().Equals(""))
        {
            e.NewValues["BORN_ADDR"] = " ";
        }
        if (e.NewValues["CONT_MAN"].ToString().Trim().Equals(""))
        {
            e.NewValues["CONT_MAN"] = " ";
        }
        if (e.NewValues["CONT_GSM"].ToString().Trim().Equals(""))
        {
            e.NewValues["CONT_GSM"] = " ";
        }
        if (e.NewValues["CONT_GSM2"].ToString().Trim().Equals(""))
        {
            e.NewValues["CONT_GSM2"] = " ";
        }
        if (e.NewValues["CONT_REL1"].ToString().Trim().Equals(""))
        {
            e.NewValues["CONT_REL1"] = " ";
        }
        if (e.NewValues["CONT_GSM"].ToString().Trim().Equals(""))
        {
            e.NewValues["CONT_GSM"] = " ";
        }
        if (e.NewValues["CONT_MAN2"].ToString().Trim().Equals(""))
        {
            e.NewValues["CONT_MAN2"] = " ";
        }
        if (e.NewValues["CONT_REL2"].ToString().Trim().Equals(""))
        {
            e.NewValues["CONT_REL2"] = " ";
        }
        if (e.NewValues["CONT_TEL"].ToString().Trim().Equals(""))
        {
            e.NewValues["CONT_TEL"] = " ";
        }
        if (e.NewValues["CONT_TEL2"].ToString().Trim().Equals(""))
        {
            e.NewValues["CONT_TEL2"] = " ";
        }
        if (e.NewValues["CONT_GSM2"].ToString().Trim().Equals(""))
        {
            e.NewValues["CONT_GSM2"] = " ";
        }
        if (e.NewValues["POSTCODE1"].ToString().Trim().Equals(""))
        {
            e.NewValues["POSTCODE1"] = " ";
        }
        if (e.NewValues["POSTCODE2"].ToString().Trim().Equals(""))
        {
            e.NewValues["POSTCODE2"] = " ";
        }
        if (e.NewValues["TEL1"].ToString().Trim().Equals(""))
        {
            e.NewValues["TEL1"] = " ";
        }
        if (e.NewValues["TEL2"].ToString().Trim().Equals(""))
        {
            e.NewValues["TEL2"] = " ";
        }
        if (e.NewValues["SUBTEL"].ToString().Trim().Equals(""))
        {
            e.NewValues["SUBTEL"] = " ";
        }

        BASE_REPO baseRepo = new BASE_REPO();
        BASE baseObj = baseRepo.GetByNobr(lb_nobr.Text);

        ApplyUpdateBase applyObj = new ApplyUpdateBase();
        applyObj.ADDR1 = e.NewValues["ADDR1"].ToString();
        applyObj.ADDR2 = e.NewValues["ADDR2"].ToString();
        applyObj.ApplyDatetime = DateTime.Now;
        applyObj.ApplyMan = JbUser.NOBR;
        applyObj.BORN_ADDR = e.NewValues["BORN_ADDR"].ToString();
        applyObj.CONT_GSM = e.NewValues["CONT_GSM"].ToString();
        applyObj.CONT_GSM2 = e.NewValues["CONT_GSM2"].ToString();
        applyObj.CONT_MAN = e.NewValues["CONT_MAN"].ToString();
        applyObj.CONT_MAN2 = e.NewValues["CONT_MAN2"].ToString();
        applyObj.CONT_REL1 = e.NewValues["CONT_REL1"].ToString();
        applyObj.CONT_REL2 = e.NewValues["CONT_REL2"].ToString();
        applyObj.CONT_TEL = e.NewValues["CONT_TEL"].ToString();
        applyObj.CONT_TEL2 = e.NewValues["CONT_TEL2"].ToString();
        applyObj.EMAIL = e.NewValues["EMAIL"].ToString();
        applyObj.GSM = e.NewValues["GSM"].ToString();
        applyObj.POSTCODE1 = e.NewValues["POSTCODE1"].ToString();
        applyObj.POSTCODE2 = e.NewValues["POSTCODE2"].ToString();
        applyObj.PROVINCE = e.NewValues["PROVINCE"].ToString();
        applyObj.TEL1 = e.NewValues["TEL1"].ToString();
        applyObj.TEL2 = e.NewValues["TEL2"].ToString();
        applyObj.SUBTEL = e.NewValues["SUBTEL"].ToString();

        applyObj.ADDR1_Old = e.OldValues["ADDR1"].ToString();
        applyObj.ADDR2_Old = e.OldValues["ADDR2"].ToString();
        applyObj.ApplyDatetime = DateTime.Now;
        applyObj.ApplyMan = JbUser.NOBR;
        applyObj.BORN_ADDR_Old = e.OldValues["BORN_ADDR"].ToString();
        applyObj.CONT_GSM_Old = e.OldValues["CONT_GSM"].ToString();
        applyObj.CONT_GSM2_Old = e.OldValues["CONT_GSM2"].ToString();
        applyObj.CONT_MAN_Old = e.OldValues["CONT_MAN"].ToString();
        applyObj.CONT_MAN2_Old = e.OldValues["CONT_MAN2"].ToString();
        applyObj.CONT_REL1_Old = e.OldValues["CONT_REL1"].ToString();
        applyObj.CONT_REL2_Old = e.OldValues["CONT_REL2"].ToString();
        applyObj.CONT_TEL_Old = e.OldValues["CONT_TEL"].ToString();
        applyObj.CONT_TEL2_Old = e.OldValues["CONT_TEL2"].ToString();
        applyObj.EMAIL_Old = e.OldValues["EMAIL"].ToString();
        applyObj.GSM_Old = e.OldValues["GSM"].ToString();
        applyObj.POSTCODE1_Old = e.OldValues["POSTCODE1"].ToString();
        applyObj.POSTCODE2_Old = e.OldValues["POSTCODE2"].ToString();
        applyObj.PROVINCE_Old = e.OldValues["PROVINCE"].ToString();
        applyObj.TEL1_Old = e.OldValues["TEL1"].ToString();
        applyObj.TEL2_Old = e.OldValues["TEL2"].ToString();
        applyObj.SUBTEL_Old = e.OldValues["SUBTEL"].ToString();

        ApplyUpdateBase_REPO applyRepo = new ApplyUpdateBase_REPO();
        if (applyRepo.CheckHaveChanged(applyObj))
        {
            applyRepo.Add(applyObj);
            applyRepo.Save();
            JB.WebModules.Message.Show("已存檔");
            try
            {
                sendEmail(baseObj);
            }
            catch (Exception ex)
            {
                JB.WebModules.Message.Show(ex.Message);
            }
            
        }
        else
        {
            JB.WebModules.Message.Show("未修改任何值！！");
        }

        e.Cancel = true;

        //e.NewValues["BORN_ADDR"] = e.OldValues["BORN_ADDR"];
        //if (!e.OldValues[0].ToString().Trim().Equals(e.NewValues[0].ToString().Trim()))
        //    lb_updescr.Text = "手機資料是為：" + e.OldValues[0].ToString().Trim() + "改為：" + e.NewValues[0].ToString().Trim() + ";<br>";
        //if (!e.OldValues[1].ToString().Trim().Equals(e.NewValues[1].ToString().Trim()))
        //    lb_updescr.Text += "E-Mail資料是為：" + e.OldValues[1].ToString().Trim() + "改為：" + e.NewValues[1].ToString().Trim() + ";<br>";
        //if (!e.OldValues[2].ToString().Trim().Equals(e.NewValues[2].ToString().Trim()))
        //    lb_updescr.Text += "戶籍電話資料是為：" + e.OldValues[2].ToString().Trim() + "改為：" + e.NewValues[2].ToString().Trim() + ";<br>";
        //if (!e.OldValues[3].ToString().Trim().Equals(e.NewValues[3].ToString().Trim()))
        //    lb_updescr.Text += "通訊電話資料是為：" + e.OldValues[3].ToString().Trim() + "改為：" + e.NewValues[3].ToString().Trim() + ";<br>";
        //if (!e.OldValues[4].ToString().Trim().Equals(e.NewValues[4].ToString().Trim()))
        //    lb_updescr.Text += "戶籍郵政區號資料是為：" + e.OldValues[4].ToString().Trim() + "改為：" + e.NewValues[4].ToString().Trim() + ";<br>";

        //if (!e.OldValues[5].ToString().Trim().Equals(e.NewValues[5].ToString().Trim()))
        //    lb_updescr.Text += "戶籍地址資料是為：" + e.OldValues[5].ToString().Trim() + "改為：" + e.NewValues[5].ToString().Trim() + ";<br>";
        //if (!e.OldValues[6].ToString().Trim().Equals(e.NewValues[6].ToString().Trim()))
        //    lb_updescr.Text += "通訊地址區號地址資料是為：" + e.OldValues[6].ToString().Trim() + "改為：" + e.NewValues[6].ToString().Trim() + ";<br>";
        //if (!e.OldValues[7].ToString().Trim().Equals(e.NewValues[7].ToString().Trim()))
        //    lb_updescr.Text += "通訊地址資料是為：" + e.OldValues[7].ToString().Trim() + "改為：" + e.NewValues[7].ToString().Trim() + ";<br>";
        //if (!e.OldValues[8].ToString().Trim().Equals(e.NewValues[8].ToString().Trim()))
        //    lb_updescr.Text += "戶籍地是為：" + e.OldValues[8].ToString().Trim() + "改為：" + e.NewValues[8].ToString().Trim() + ";<br>";
        //if (!e.OldValues[9].ToString().Trim().Equals(e.NewValues[9].ToString().Trim()))
        //    lb_updescr.Text += "出生地是為：" + e.OldValues[9].ToString().Trim() + "改為：" + e.NewValues[9].ToString().Trim() + ";<br>";

        //if (!e.OldValues["CONT_MAN"].ToString().Trim().Equals(e.NewValues["CONT_MAN"].ToString().Trim()))
        //    lb_updescr.Text += "連絡人1姓名資料是為：" + e.OldValues["CONT_MAN"].ToString().Trim() + "改為：" + e.NewValues["CONT_MAN"].ToString().Trim() + ";<br>";
        //if (!e.OldValues["CONT_REL1"].ToString().Trim().Equals(e.NewValues["CONT_REL1"].ToString().Trim()))
        //    lb_updescr.Text += "連絡人1關係資料是為：" + e.OldValues["CONT_REL1"].ToString().Trim() + "改為：" + e.NewValues["CONT_REL1"].ToString().Trim() + ";<br>";

        //if (!e.OldValues["CONT_TEL"].ToString().Trim().Equals(e.NewValues["CONT_TEL"].ToString().Trim()))
        //    lb_updescr.Text += "連絡人1電話資料是為：" + e.OldValues["CONT_TEL"].ToString().Trim() + "改為：" + e.NewValues["CONT_TEL"].ToString().Trim() + ";<br>";

        //if (!e.OldValues["CONT_GSM"].ToString().Trim().Equals(e.NewValues["CONT_GSM"].ToString().Trim()))
        //    lb_updescr.Text += "連絡人1行動電話資料是為：" + e.OldValues["CONT_GSM"].ToString().Trim() + "改為：" + e.NewValues["CONT_GSM"].ToString().Trim() + ";<br>";

        //if (!e.OldValues["CONT_MAN2"].ToString().Trim().Equals(e.NewValues["CONT_MAN2"].ToString().Trim()))
        //    lb_updescr.Text += "連絡人2姓名資料是為：" + e.OldValues["CONT_MAN2"].ToString().Trim() + "改為：" + e.NewValues["CONT_MAN2"].ToString().Trim() + ";<br>";

        //if (!e.OldValues["CONT_REL2"].ToString().Trim().Equals(e.NewValues["CONT_REL2"].ToString().Trim()))
        //    lb_updescr.Text += "連絡人2關係資料是為：" + e.OldValues["CONT_REL2"].ToString().Trim() + "改為：" + e.NewValues["CONT_REL2"].ToString().Trim() + ";<br>";

        //if (!e.OldValues["CONT_TEL2"].ToString().Trim().Equals(e.NewValues["CONT_TEL2"].ToString().Trim()))
        //    lb_updescr.Text += "連絡人2電話資料是為：" + e.OldValues["CONT_TEL2"].ToString().Trim() + "改為：" + e.NewValues["CONT_TEL"].ToString().Trim() + ";<br>";

        //if (!e.OldValues["CONT_GSM2"].ToString().Trim().Equals(e.NewValues["CONT_GSM2"].ToString().Trim()))
        //    lb_updescr.Text += "連絡人2行動電話資料是為：" + e.OldValues["CONT_GSM2"].ToString().Trim() + "改為：" + e.NewValues["CONT_GSM2"].ToString().Trim() + ";<br>";





        //if (lb_updescr.Text.Trim().Length <= 0) 
        //{
        //    e.Cancel = true;
        //    JB.WebModules.Message.Show("資料未修改！");
        //    return;

        //}

        //HRDsTableAdapters.UpBaseRecordTableAdapter rv_upbasecon = new HRDsTableAdapters.UpBaseRecordTableAdapter();
        //HRDs.UpBaseRecordDataTable rv_upbaseconDs = new HRDs.UpBaseRecordDataTable();
        //HRDs.UpBaseRecordRow newrow = rv_upbaseconDs.NewUpBaseRecordRow();
        //newrow.nobr = lb_nobr.Text;
        //newrow.updescr = lb_updescr.Text;
        //newrow.name_c = JbUser.NAME_C;
        //newrow.key_date = DateTime.Now;
        //rv_upbaseconDs.AddUpBaseRecordRow(newrow);
        //rv_upbasecon.Update(rv_upbaseconDs);

        //JB.WebModules.Message.Show("修改完成！！");
    }
    protected void FormView1_PageIndexChanging(object sender, FormViewPageEventArgs e)
    {

    }
    protected void CONT_REL1_DataBound(object sender, EventArgs e)
    {
        DropDownList DDL = (DropDownList)sender;
        DDL.Items.Insert(0, new ListItem("", ""));
    }
    protected void CONT_REL2_PreRender(object sender, EventArgs e)
    {
        DropDownList DDL = (DropDownList)sender;
        DDL.Items.Insert(0, new ListItem("", ""));
    }
    protected void CONT_REL1_DataBinding(object sender, EventArgs e)
    {
        DropDownList DDL = (DropDownList)sender;
        DDL.Items.Insert(0, new ListItem("", ""));
    }

    private void sendEmail(BASE baseObj)
    {
        BASETTS_REPO ttsRepo = new BASETTS_REPO();
        BASETTS ttsObj= ttsRepo.GetByNobrNow(baseObj.NOBR);

        NotifyApplyUpdateBase_REPO naubRepo = new NotifyApplyUpdateBase_REPO();
        List<NotifyApplyUpdateBase> naubList= naubRepo.GetByDataGroup_Dlo(ttsObj.SALADR);

        if (naubList.Count == 0)
            return;

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

        mailMessage.Subject = "工號 "+baseObj.NOBR+ "、姓名"+baseObj.NAME_C +" 已修改通訊資料";
        mailMessage.Body = "工號 " + baseObj.NOBR + "、姓名" + baseObj.NAME_C + " 已修改通訊資料";

        foreach (var a in naubList)
        {
            mailMessage.To.Add(a.BASE.EMAIL);
        }
        //mailMessage.To.Add(@"kukoc@jbjob.com.tw");
        smtpClient.Send(mailMessage);
    }
}
