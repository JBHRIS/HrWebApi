using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;

public partial class Batch_List : System.Web.UI.Page
{
    private dcFlowDataContext dcFlow = new dcFlowDataContext();
    private dcFormDataContext dcForm = new dcFormDataContext();

    private GridView gv;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            if (Request.Cookies["ezFlow"] == null || Request.Cookies["ezFlow"]["Emp_id"] == null)
            {
                lblMsg.Text = "由於太久沒有動作，請先登出，再重新登入";
                return;
            }

            lblNobr.Text = Convert.ToString(Request.Cookies["ezFlow"]["Emp_id"]);
        }

        //gvList.DataBind();
    }

    protected void gvList_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        Button btnSelect = e.Row.FindControl("btnSelect") as Button;
        Label lblCount = e.Row.FindControl("lblCount") as Label;

        if (lblCount != null)
        {
            var sql = from pc in dcFlow.ProcessCheck
                      join pn in dcFlow.ProcessNode on pc.ProcessNode_auto equals pn.auto
                      join pf in dcFlow.ProcessFlow on pn.ProcessFlow_id equals pf.id
                      where !Convert.ToBoolean(pn.isFinish)
                      && !Convert.ToBoolean(pf.isFinish)
                      && !Convert.ToBoolean(pf.isError)
                      && !Convert.ToBoolean(pf.isCancel)
                      && pf.FlowTree_id == lblCount.ToolTip
                      && (pc.Emp_idDefault == lblNobr.Text || pc.Emp_idAgent == lblNobr.Text)
                      select pf.id;

            var sqlAbs = from abs in dcForm.wfAppAbs
                         where sql.ToArray().Contains(abs.idProcess)
                         select abs;

            var sqlOt = from ot in dcForm.wfAppOt
                        where sql.ToArray().Contains(ot.idProcess)
                        select ot;

            lblCount.Text = Convert.ToString(sqlAbs.Count() + sqlOt.Count() );


            string[] arrTree = { "16" };
            btnSelect.Visible = (arrTree.Contains(lblCount.ToolTip));
        }

        if (btnSelect != null)
            ScriptManager.GetCurrent(this).RegisterPostBackControl(btnSelect);

        if (e.Row.Cells[0].Text != "加班單")
            e.Row.Visible = false;
    }

    protected void gvList_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        switch (e.CommandArgument.ToString())
        {
            case "15": //請假
                btnSend.CommandArgument = "Abs";
                btnSelectAll.CommandArgument = "Abs";
                btnSelectCancel.CommandArgument = "Abs";
                mv.ActiveViewIndex = 0;
                break;
            case "16":  //加班
                btnSend.CommandArgument = "Ot";
                btnSelectAll.CommandArgument = "Ot";
                btnSelectCancel.CommandArgument = "Ot";
                mv.ActiveViewIndex = 1;
                break;
        }

        gv = mv.FindControl("gv" + btnSend.CommandArgument) as GridView;
        if (gv != null)
            gv.PageSize = 10;

        gvList.DataBind();
    }

    private static bool bRow = true;
    protected void gvData_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        Label lblProcessID = e.Row.FindControl("lblProcessID") as Label;

        if (lblProcessID == null) return;
    }

    protected void btnSend_Click(object sender, EventArgs e)
    {
        bool bPass = false; //是否傳送成功
        int x = 0, y = 0;   //記錄幾筆表單,幾筆資料
        Button btn = sender as Button;
        gv = mv.FindControl("gv" + btn.CommandArgument) as GridView;
        JBHR.Dll.dsBas.JB_HR_BaseDataTable dtBaseTemp, dtBase = JBHR.Dll.Bas.EmpBase(lblNobr.Text);

        var rSysVar = (from c in dcFlow.SysVar
                       select c).FirstOrDefault();
        if (rSysVar == null || rSysVar.sysClose == null || rSysVar.sysClose.Value)
        {
            lblMsg.Text = "系統維護中，請稍後再送出表單 System maintain,please sent it later.";
            ScriptManager.RegisterStartupScript(updatePanel, typeof(UpdatePanel), "key", "alert('" + lblMsg.Text + "');", true);
            return;
        }

        gvList.DataBind();
        if (gv == null || gv.Rows.Count == 0 || dtBase.Rows.Count == 0) return;
        var rDeptm = JBHR.Dll.Bas.Deptm(dtBase.First().sDeptmCode).FirstOrDefault();
        string sCateOrder = string.Empty;
        //string sCateOrder = (from c in dtDeptm where c.sDeptCode == dtBase.First().sDeptmCode select c.sDeptTree).FirstOrDefault();
        if (rDeptm == null) return;
        string sDeptm;
        string to, sub, body;

        int ApParm;
        Label lblAutoKey, lblProcessID;
        CheckBox ckSend, ckSign;
        localhost.Service oService = new localhost.Service();
        List<string> lsTemp = new List<string>();
        foreach (GridViewRow r in gv.Rows)
        {
            lblAutoKey = r.FindControl("lblAutoKey") as Label;
            lblProcessID = r.FindControl("lblProcessID") as Label;
            ckSend = r.FindControl("ckSend") as CheckBox;
            ckSign = r.FindControl("ckSign") as CheckBox;

            ApParm = Convert.ToInt32(ckSign.ToolTip);

            //不包含才需要做傳送
            if (ckSend.Checked && !lsTemp.Contains(lblProcessID.Text))
            {
                var rp = (from c in dcFlow.ProcessApParm
                          where c.auto == ApParm
                          select c).FirstOrDefault();

                if (rp == null) break;


                var rPorcessFlow = (from pn in dcFlow.ProcessNode
                                    join pc in dcFlow.ProcessCheck on pn.auto equals pc.ProcessNode_auto
                                    join rl in dcFlow.Role on pc.Role_idDefault equals rl.id
                                    where pn.ProcessFlow_id == Convert.ToInt32(lblProcessID.Text)
                                    orderby pc.auto descending
                                    select new { pn, pc, rl }).FirstOrDefault();

                sDeptm = rPorcessFlow.rl.Dept_id;

                rp.Role_id = rPorcessFlow.pc.Role_idDefault;
                rp.Emp_id = rPorcessFlow.pc.Emp_idDefault;

                //dcFlow.SubmitChanges();

                var sDept = (from pc in dcFlow.ProcessCheck
                             join pn in dcFlow.ProcessNode on pc.ProcessNode_auto equals pn.auto
                             join role in dcFlow.Role on pc.Role_idDefault equals role.id
                             where Convert.ToString(pn.ProcessFlow_id) == lblProcessID.Text
                             orderby pc.auto descending
                             select role.Dept_id).FirstOrDefault();

                if (sDept != null)
                {
                    var sTree = JBHR.Dll.Bas.Deptm(sDept).FirstOrDefault();
                    if (sTree != null)
                        sCateOrder = sTree.sDeptTree;
                }

                var dtAppM = from c in dcFlow.wfFormApp
                             where c.sProcessID == lblProcessID.Text
                             select c;

                bool bSign = false;
                switch (btn.CommandArgument)
                {
                    case "Abs":
                        var dtAppAbs = (from c in dcForm.wfAppAbs
                                        where c.sProcessID == lblProcessID.Text
                                        select c).ToList();

                        if (!dtAppM.Any() || !dtAppAbs.Any()) break;

                        foreach (var rs in dtAppAbs)
                        {
                            foreach (GridViewRow rgv in gv.Rows)
                            {
                                lblAutoKey = rgv.FindControl("lblAutoKey") as Label;
                                ckSign = rgv.FindControl("ckSign") as CheckBox;
                                if (Convert.ToInt32(lblAutoKey.Text) == rs.iAutoKey)
                                    rs.bSign = ckSign.Checked;
                            }

                            rs.sState = (rs.bSign) ? "1" : "2";

                            bSign = bSign ? bSign : rs.bSign;

                            y++;

                            //發信通知被駁回的資料
                            dtBaseTemp = JBHR.Dll.Bas.EmpBase(rs.sNobr);
                            to = dtBaseTemp.FirstOrDefault().sEmail;
                            if (to.Length > 0 && !rs.bSign)
                            {
                                sub = "請假駁回通知";
                                body = rs.sName + "您好：<br>您於 " + rs.dDateTimeB.ToString() + " 到 " + rs.dDateTimeE.ToString() + " 請假(" + rs.sHname + ")" + "被主管駁回了。<br>特此通知。";

                                SendMail(to, sub, body);
                            }
                        }

                        //sCateOrder = (sDeptm == null) ? sCateOrder : (from c in dtDeptm where c.sDeptCode == sDeptm select c.sDeptTree).FirstOrDefault();

                        if (sCateOrder == null) break;

                        break;
                    case "Ot":
                        var dtAppOt = (from c in dcForm.wfAppOt
                                       where c.sProcessID == lblProcessID.Text
                                       select c).ToList();

                        if (!dtAppM.Any() || !dtAppOt.Any()) break;

                        foreach (var rs in dtAppOt)
                        {
                            foreach (GridViewRow rgv in gv.Rows)
                            {
                                lblAutoKey = rgv.FindControl("lblAutoKey") as Label;
                                ckSign = rgv.FindControl("ckSign") as CheckBox;
                                if (Convert.ToInt32(lblAutoKey.Text) == rs.iAutoKey)
                                    rs.bSign = ckSign.Checked;
                            }

                            rs.sState = (rs.bSign) ? "1" : "2";

                            bSign = bSign ? bSign : rs.bSign;

                            y++;

                            //發信通知被駁回的資料
                            //dtBaseTemp = JBHR.Dll.Bas.EmpBase(rs.sNobr);
                            //to = dtBaseTemp.FirstOrDefault().sEmail;
                            //if (to.Length > 0 && !rs.bSign)
                            //{
                            //    sub = "加班駁回通知";
                            //    body = rs.sName + "您好：<br>您於 " + rs.dDateTimeB.ToString() + " 到 " + rs.dDateTimeE.ToString() + "加班被主管駁回了。<br>特此通知。";

                            //    SendMail(to, sub, body);
                            //}

                            try
                            {
                                //foreach (var rs in dtAppS)
                                {
                                    //string sNobr = "";
                                    //string sEmail = MessageSendMail.SendMailBySign(rs.idProcess, out sNobr);
                                    //if (sEmail.Trim().Length > 0 && lblNobr.Text != sNobr)
                                    //{
                                    //    string sSubject = "";
                                    //    string sBody = MessageSendMail.OtByManage(rs.sNobr, rs.sName, rs.sDeptName, rs.sRoteName, rs.dDateB, rs.sTimeB, rs.sTimeE, rs.iTotalHour, rs.sOtcatName, rs.sNote, out  sSubject);
                                    //    sSubject = "【通知】(" + rs.sNobr + ")" + rs.sName + " 之加班單，請進入系統簽核";
                                    //    JBHR.Dll.Tools.SendMailThread(rSysVar.mailServer, rSysVar.senderMail, false, rSysVar.mailID, rSysVar.mailPW, sEmail, sSubject, sBody);
                                    //}
                                }
                            }
                            catch
                            {
                            }
                        }

                        //sCateOrder = (sDeptm == null) ? sCateOrder : (from c in dtDeptm where c.sDeptCode == sDeptm select c.sDeptTree).FirstOrDefault();

                        if (sCateOrder == null) break;

                        break;
                }

                var rm = dtAppM.First();
                rm.sNote = "Batch";
                rm.bSign = bSign;
                rm.sConditions1 = sCateOrder.PadLeft(2, '0');
                rm.sState = (!rm.bSign) ? "2" : rm.sState;
                rm.dDateTimeD = DateTime.Now;

                var rSignM = new wfFormSignM();
                rSignM.sFormCode = btn.CommandArgument;
                rSignM.sFormName = "Batch";
                rSignM.sKey = Guid.NewGuid().ToString();
                rSignM.sProcessID = lblProcessID.Text;
                rSignM.idProcess = Convert.ToInt32(rSignM.sProcessID);
                rSignM.sNobr = lblNobr.Text;
                rSignM.sName = dtBase.First().sNameC;
                rSignM.sRole = rp.Role_id;
                rSignM.sDept = dtBase.First().sDeptmCode;
                rSignM.sDeptName = (from c in dcFlow.Dept where c.id == rSignM.sDept select c.name).FirstOrDefault();
                rSignM.sJob = "";
                rSignM.sJobName = "";
                rSignM.sNote = "Batch";
                rSignM.bSign = bSign;
                rSignM.dKeyDate = DateTime.Now;
                dcFlow.wfFormSignM.InsertOnSubmit(rSignM);

                dcFlow.SubmitChanges();
                dcForm.SubmitChanges();

                oService.WorkFinish(ApParm);
                lsTemp.Add(lblProcessID.Text);

                x++;
            }   //End if
        }

        gv.DataBind();
        gvList.DataBind();
        lblMsg.Text = "共傳出" + x.ToString() + "筆表單,其中包含" + y.ToString() + "筆資料";
        ScriptManager.RegisterStartupScript(updatePanel, typeof(UpdatePanel), "AlertMsg", "alert('" + lblMsg.Text + "');", true);
    }

    protected void ckSend_CheckedChanged(object sender, EventArgs e)
    {
        //表單傳送需要一起送
        CheckBox ckSend = sender as CheckBox;
        bool Checked = ckSend.Checked;
        string ProcessID = ckSend.ToolTip;

        GridView gv = mv.FindControl(ckSend.ValidationGroup) as GridView;
        foreach (GridViewRow r in gv.Rows)
        {
            ckSend = r.FindControl("ckSend") as CheckBox;
            if (ckSend.ToolTip == ProcessID)
                ckSend.Checked = Checked;
        }
    }

    protected void btnReset_Click(object sender, EventArgs e)
    {
        gvList.SelectedIndex = -1;
        gvList.DataBind();
    }

    protected void btnSelectAll_Click(object sender, EventArgs e)
    {
        gvList.DataBind();

        Button btn = sender as Button;
        gv = mv.FindControl("gv" + btn.CommandArgument) as GridView;

        if (gv == null) return;

        CheckBox ckSend;
        foreach (GridViewRow r in gv.Rows)
        {
            ckSend = r.FindControl("ckSend") as CheckBox;
            ckSend.Checked = btn.CommandName == "1";
        }
    }

    public void SendMail(string to, string subject, string body)
    {
        var rs =( from c in dcFlow.SysVar
                   select c).FirstOrDefault();

        string mailServerName = rs.mailServer;
        string from = rs.senderMail;
        bool isUseDefaultCredentials = true;
        string strFrom = rs.mailID;
        string strFromPass = rs.mailPW;

        body += "<br><br><font color='red'>此信件為系統自動寄送，請勿直接回信，同仁若有疑問請直接洽業務承辦人員辦理，謝謝您！</font>";

        try
        {
            using (MailMessage message =
                new MailMessage(from, to, subject, body))
            {
                message.IsBodyHtml = true;
                message.Priority = MailPriority.High;
                message.BodyEncoding = System.Text.Encoding.Default;
                message.SubjectEncoding = System.Text.Encoding.Default;

                SmtpClient mailClient = new SmtpClient(mailServerName);
                mailClient.DeliveryMethod = SmtpDeliveryMethod.Network;

                if (isUseDefaultCredentials) mailClient.UseDefaultCredentials = true;
                else
                {
                    mailClient.UseDefaultCredentials = false;
                    mailClient.Credentials = new System.Net.NetworkCredential(strFrom, strFromPass);
                }

                mailClient.Send(message);
            }
        }
        catch (Exception ex)
        {
        }
    }
    protected void gvList_DataBound(object sender, EventArgs e)
    {

    }
}