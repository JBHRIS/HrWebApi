using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL;
using Telerik.Web.UI;

public partial class eTraining_Questionary_QPublish : JBWebPage
{
    private QTpl_Repo tplRepo = new QTpl_Repo();
    private string vst = "QPublish";

    protected override void OnInit(EventArgs e)
    {
        CanCopy = true;
        base.OnInit(e);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            dtpB.SelectedDate = DateTime.Now.Date;

            if (Request.QueryString["Code"] != null)
            {
                QTpl tplObj = tplRepo.GetByPk(Request.QueryString["Code"]);
                if (tplObj == null)
                {
                    btnSave.Enabled = false;
                }
            }
            SiteHelper.SetAllDeptTree(tvDept);

            rblTargetType_SelectedIndexChanged(this, null);
            bind_cbxTargetType();
        }
    }

    private void bind_cbxTargetType()
    {
        EMPCD_REPO eRepo = new EMPCD_REPO();
        var list = eRepo.GetAll();
        foreach (var i in list)
        {
            RadComboBoxItem item = new RadComboBoxItem();
            item.Text = i.EMPDESCR;
            item.Value = i.EMPCD1;
            item.Checked = true;
            cbTargetType.Items.Add(item);
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        QTpl_Repo qtplRepo = new QTpl_Repo();
        var qObj = qtplRepo.GetByPk(Request.QueryString["Code"]);
        if (qObj == null)
        {
            Show("抓無此資料");
            return;
        }
        else
        {
            BASE_REPO baseRepo = new BASE_REPO();
            List<BASE> empList = new List<BASE>();
            if (rblTargetType.SelectedValue.Equals("1"))
            {
                empList.AddRange(baseRepo.GetHiredEmp_Dlo());
            }
            else
            {
                var list = ViewState[vst] as List<QPublishView>;
                if (list != null)
                {
                    foreach (var i in list)
                    {
                        if (i.IsEmp)
                            empList.Add(baseRepo.GetByNobr_Dlo(i.Nobr));
                        else
                            empList.AddRange(baseRepo.GetEmpByDept_Dlo(i.DeptCode));
                    }
                }
                else
                {
                    Show("無選擇對象");
                }
            }

            List<string> checkedList = (from c in cbTargetType.CheckedItems select c.Value).ToList();

            empList.RemoveAll(p => !checkedList.Contains(p.BASETTS[0].EMPCD));

            QA_Published_Repo qaRepo = new QA_Published_Repo();
            QA_Published qao = new QA_Published();
            qao.PublishDatetime = DateTime.Now;
            qao.FillFormDatetimeB = dtpB.SelectedDate.Value;
            qao.FillFormDatetimeE = dtpE.SelectedDate.Value;
            qao.IsPublished = ckPublish.Checked;
            qao.QTplCode = qObj.Code;
            qao.WritedBy = Juser.Nobr;
            qao.ViewSummaryClosed = cbViewSummaryClosed.Checked;
            qao.ViewSummaryOpening = cbViewSummaryOpening.Checked;
            qao.IsAnonymous = cbIsAnonymous.Checked;

            if (cbxMail.Checked)
            {
                qao.SentMail = true;
                qao.MailContent = edtContent.Content;
                qao.MailSubject = tbSubject.Text;
            }

            QAMaster_Repo qamRepo = new QAMaster_Repo(qaRepo.dc);
            foreach (var emp in empList)
                qamRepo.CreateQA(qao, emp);

            qaRepo.Add(qao);
            qaRepo.Save();

            //如果問卷發布，且發送mail
            if (qao.IsPublished && qao.SentMail)
            {
                var list = qamRepo.GetByPublishId_Dlo(qao.Id);
                PARAMETER_REPO pRepo = new PARAMETER_REPO();
                var pList = pRepo.GetAll();

                string smtpServer = (from c in pList where c.CODE.Equals("JbMail.host") select c.VALUE).FirstOrDefault();
                string user = (from c in pList where c.CODE.Equals("JbMail.sys_mail") select c.VALUE).FirstOrDefault();
                string pwd = (from c in pList where c.CODE.Equals("JbMail.sys_pwd") select c.VALUE).FirstOrDefault();
                string needCredentials = (from c in pList where c.CODE.Equals("JbMail.IsNeedCredentials") select c.VALUE).FirstOrDefault();
                int port = Convert.ToInt32((from c in pList where c.CODE.Equals("JbMail.port") select c.VALUE).FirstOrDefault());

                SmtpClient smtpClient = new SmtpClient(smtpServer, port);

                if (needCredentials.Equals("1"))
                    smtpClient.Credentials = new System.Net.NetworkCredential(user, pwd);

                MailMessage mailMessage = new MailMessage();
                mailMessage.SubjectEncoding = System.Text.Encoding.UTF8;
                mailMessage.BodyEncoding = System.Text.Encoding.UTF8; ;
                mailMessage.IsBodyHtml = true;
                mailMessage.From = new MailAddress(user, user);

                QAMaster_Repo qamRepo2 = new QAMaster_Repo();
                foreach (var item in list)
                {
                    try
                    {
                        mailMessage.Body = qao.MailContent;
                        mailMessage.Subject = qao.MailSubject;
                        mailMessage.To.Clear();
                        if (SiteHelper.IsMailAddress(item.BASE.EMAIL))
                        {
                            mailMessage.To.Add(item.BASE.EMAIL);
                            smtpClient.Send(mailMessage);
                            item.MailLog = "Done";
                            qamRepo2.Update(item);
                            qamRepo2.Save();
                        }
                        else
                        {
                            item.MailLog = "mail帳號錯誤";
                            qamRepo2.Update(item);
                            qamRepo2.Save();
                        }
                    }
                    catch (Exception ex)
                    {
                        item.MailLog = ex.Message;
                        qamRepo2.Update(item);
                        qamRepo2.Save();
                    }
                }
            }

            JB_RegisterStartupScript(typeof(Page), this.GetType().ToString(), "CancelEdit();", true);
        }
    }

    protected void rblTargetType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rblTargetType.SelectedValue.Equals("0"))
        {
            pnlTarget.Visible = true;
        }
        else
            pnlTarget.Visible = false;
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        ViewState[vst] = null;
        gvTarget.Rebind();
    }

    protected void gvTarget_ItemCommand(object sender, GridCommandEventArgs e)
    {
        var list = ViewState[vst] as List<QPublishView>;
        if (list == null)
            return;

        if (e.CommandName.Equals("cmdDel"))
        {
            GridDataItem item = e.Item as GridDataItem;
            var ck = item["IsEmp"].Controls[0] as CheckBox;
            if (ck.Checked)
            {
                list.Remove(list.Find(p => p.Nobr == item["Nobr"].Text));
            }
            else
            {
                list.Remove(list.Find(p => p.DeptCode == item["DeptCode"].Text));
            }

            ViewState[vst] = list;
            gvTarget.Rebind();
        }
    }

    protected void gvTarget_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
    {
        var list = ViewState[vst] as List<QPublishView>;
        if (list != null)
            gvTarget.DataSource = list;
    }

    protected void btnAddDept_Click(object sender, EventArgs e)
    {
        var list = ViewState[vst] as List<QPublishView>;
        if (list == null)
            list = new List<QPublishView>();

        DEPT_REPO dRepo = new DEPT_REPO();

        foreach (var n in tvDept.CheckedNodes)
        {
            if (list.Find(p => p.DeptCode == n.Value) == null)
            {
                var d = dRepo.GetByID(n.Value);
                var o = new QPublishView();
                o.DeptCode = d.D_NO;
                o.DeptName = d.D_NAME;
                o.IsEmp = false;
                list.Add(o);
            }
        }

        ViewState[vst] = list;
        gvTarget.Rebind();
    }

    protected void btnAddEmp_Click(object sender, EventArgs e)
    {
        ISelectEmp ss = SelectEmp31 as ISelectEmp;
        var plist = ss.GetSelectedEmps();
        var list = ViewState[vst] as List<QPublishView>;
        if (list == null)
            list = new List<QPublishView>();

        BASE_REPO baseRepo = new BASE_REPO();

        foreach (var emp in plist)
        {
            if (list.Find(p => p.Nobr == emp) == null)
            {
                var b = baseRepo.GetByNobr_Dlo(emp);
                var o = new QPublishView();
                o.Nobr = emp;
                o.EmpName = b.NAME_C;
                o.IsEmp = true;
                list.Add(o);
            }
        }

        ViewState[vst] = list;
        gvTarget.Rebind();
    }

    protected void cbxMail_CheckedChanged(object sender, EventArgs e)
    {
        if (cbxMail.Checked)
        {
            pnlMailDetail.Visible = true;
            loadData();
        }
        else
            pnlMailDetail.Visible = false;
    }

    private void loadData()
    {
        QTpl_Repo qtplRepo = new QTpl_Repo();
        var qObj = qtplRepo.GetByPk(Request.QueryString["Code"]);
        if (qObj == null)
        {
            Show("抓無此資料");
            return;
        }
        else
        {
            tbSubject.Text = qObj.Name;
        }
    }
}

[Serializable]
public class QPublishView
{
    public string Nobr { get; set; }

    public string EmpName { get; set; }

    public string DeptName { get; set; }

    public string DeptCode { get; set; }

    public bool IsEmp { get; set; }
}