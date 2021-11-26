using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Web.UI.WebControls;
using BL;
using Telerik.Web.UI;

public partial class MeetingRoomRent : JBWebPage
{
    private MeetingRoomRentRecord_REPO mrrrRepo = new MeetingRoomRentRecord_REPO();
    private List<MeetingRoomRentRecord> mrrrList = null;

    protected override void OnInit(EventArgs e)
    {
        if (!IsPostBack)
        {
            rblType_SelectedIndexChanged(null, null);
        }
        CanCopy = true;

        base.OnInit(e);

        //dpB.Calendar.PreRender += new EventHandler(this.cld_PreRender);
        //dpB.Calendar.DayRender += new EventHandler(this.cld_DayRender);
        //dpB.Calendar.DayRender += new Telerik.Web.UI.Calendar.DayRenderEventHandler(this.cld_DayRender);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bindCbxCar();
            rebindSch();
        }
    }

    private void bindCbxCar()
    {
        MeetingRoom_REPO mrRepo = new MeetingRoom_REPO();
        List<MeetingRoom> list = mrRepo.GetByCanRent(true);
        foreach (var c in list)
        {
            RadComboBoxItem cbi = new RadComboBoxItem();
            cbi.Text = c.Name;
            cbi.Value = c.Id.ToString();
            cbxItem.Items.Add(cbi);
        }

        RadComboBoxItem cba = new RadComboBoxItem();
        cba.Text = "全部";
        cba.Value = "All";
        cbxItem.Items.Add(cba);
    }

    protected void RadScheduler1_AppointmentDelete(object sender, AppointmentDeleteEventArgs e)
    {
        int id = Convert.ToInt32(e.Appointment.ID);
        var item = mrrrRepo.GetByPk(id);
        if (item.WritedBy != Juser.Nobr)
        {
            if (!Juser.IsInRole("HR"))
            {
                Show("非本人不得刪除");
                e.Cancel = true;
                rebindSch();
                return;
            }
        }
        if (item.EndDateTime <= DateTime.Now)
        {
            Show("已結束不得刪除");
            e.Cancel = true;
            rebindSch();
            return;
        }

        var pnlDelCycle = e.Appointment.AppointmentControls[0].AppointmentContainer.FindControl("pnlDelCycle") as Panel;
        var cbDelCycle = pnlDelCycle.FindControl("cbDelCycle") as CheckBox;

        //取消單筆
        if (!cbDelCycle.Checked)
        {
            item.Cancel = true;
            item.Canceler = Juser.Nobr;
            mrrrRepo.Update(item);
            mrrrRepo.Save();
        }
        else//取消循環
        {
            var itemList = mrrrRepo.GetCycleItemsByDateMoreThan(item);
            foreach (var i in itemList)
            {
                if (!i.Cancel)
                {
                    i.Cancel = true;
                    i.Canceler = Juser.Nobr;
                    mrrrRepo.Update(i);
                }

                mrrrRepo.Save();
            }
        }

        rebindSch();
    }

    protected void RadScheduler1_FormCreating(object sender, SchedulerFormCreatingEventArgs e)
    {
    }

    protected void RadScheduler1_NavigationCommand(object sender, SchedulerNavigationCommandEventArgs e)
    {
        if (e.Command == SchedulerNavigationCommand.NavigateToSelectedDate || e.Command == SchedulerNavigationCommand.SwitchToSelectedDay)
        {
        }
        //rebindSch();
    }

    private void rebindSch()
    {
        if (cbxItem.SelectedItem != null)
        {
            List<MeetingRoomRentRecord> mrrrList2 = new List<MeetingRoomRentRecord>();

            if (!cbxItem.SelectedValue.Equals("All"))
            {
                mrrrList2 = mrrrRepo.GetByDate_Dlo(RadScheduler1.VisibleRangeStart.Date, RadScheduler1.VisibleRangeEnd.Date, Convert.ToInt32(cbxItem.SelectedValue), false);
            }
            else
            {
                mrrrList2 = mrrrRepo.GetByDate_Dlo(RadScheduler1.VisibleRangeStart.Date, RadScheduler1.VisibleRangeEnd.Date, false);
            }

            mrrrList = mrrrList2;
            RadScheduler1.DataSource = Convert2App(mrrrList2);
        }
    }

    protected void RadScheduler1_AppointmentCommand(object sender, AppointmentCommandEventArgs e)
    {
        if (e.CommandName.Equals("cmdEdit"))
        {
            int id = (int)e.Container.Appointment.ID;
            loadData(id);
            changeFormMode(FormMode.Update);
        }
    }

    private void changeFormMode(FormMode m)
    {
        if (m == FormMode.Update)
        {
            pnlAddForm.Visible = true;
            rblType.SelectedIndex = 0;
            rblType.Enabled = false;

            cbEmailNotification.Enabled = true;
            btnAdd.Visible = false;
            btnSave.Visible = true;
            btnEdit.Visible = false;
            ISelectEmp s = SelectEmp31 as ISelectEmp;
            //s.SetReadOnly(true);
            s.SetReadOnly(false);
        }
        else if (m == FormMode.ViewDetail)
        {
            pnlAddForm.Visible = true;
            rblType.SelectedIndex = 0;
            rblType.Enabled = false;

            cbEmailNotification.Enabled = false;
            btnAdd.Visible = false;
            btnSave.Visible = false;

            ISelectEmp s = SelectEmp31 as ISelectEmp;
            s.SetReadOnly(true);

            btnEdit.Visible = false;
            var item = mrrrRepo.GetByPk(Convert.ToInt32(lblId.Text));
            if (item.WritedBy == Juser.Nobr)
            {
                btnEdit.Visible = true;
            }

            if (Juser.IsInRole("HR"))
            {
                btnEdit.Visible = true;
            }
        }
        else if (m == FormMode.Insert)
        {
            pnlAddForm.Visible = true;
            rblType.SelectedIndex = 0;
            rblType.Enabled = true;

            cbEmailNotification.Enabled = true;
            btnAdd.Visible = true;
            btnSave.Visible = true;
            btnEdit.Visible = false;
            ISelectEmp s = SelectEmp31 as ISelectEmp;
            s.SetReadOnly(false);
            lblId.Text = "";
        }
        else if (m == FormMode.View)
        {
            btnAdd.Visible = true;
            btnEdit.Visible = false;
            pnlAddForm.Visible = false;
            lblId.Text = "";
        }

        rebindSch();
        lblFormStatus.Text = m.ToString();
    }

    private void loadData(int id)
    {
        var item = mrrrRepo.GetByPk_Dlo(id);
        dtpB.SelectedDate = item.StartDateTime;
        dtpE.SelectedDate = item.EndDateTime;
        tbContents.Text = item.Contents;
        tbTopic.Text = item.Topic;

        cbEmailNotification.Checked = item.EmailNotification;

        List<RadListBoxItem> list = new List<RadListBoxItem>();
        foreach (var p in item.MeetingRoomRentAttendee)
        {
            RadListBoxItem b = new RadListBoxItem();
            b.Value = p.EmpNo;
            b.Text = p.BASE.NAME_C;
            list.Add(b);
        }

        ISelectEmp s = SelectEmp31 as ISelectEmp;
        s.ClearAll();
        s.SetSelectedData(list);

        foreach (RadComboBoxItem i in cbxItem.Items)
        {
            if (i.Value.Equals(item.MeetingRoomId.ToString()))
                i.Selected = true;
            else
                i.Selected = false;
        }

        lblId.Text = item.Id.ToString();
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        changeFormMode(FormMode.Insert);
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        changeFormMode(FormMode.View);
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (cbxItem.SelectedValue.Equals("All"))
        {
            Show("請先選擇預約會議室");
            return;
        }

        int itemId = Convert.ToInt32(cbxItem.SelectedValue);

        //單一租借
        if (rblType.SelectedValue.Equals("0"))
        {
            if ((dtpB.SelectedDate.Value.Minute % 30 != 0) || (dtpE.SelectedDate.Value.Minute % 30 != 0))
            {
                Show("選擇時間需30分鐘為最小單位");
                return;
            }
            if (dtpB.SelectedDate.Value.CompareTo(dtpE.SelectedDate.Value) >= 0)
            {
                Show("結束時間不能大於等於開始時間");
                return;
            }
            if (dtpE.SelectedDate.Value.CompareTo(DateTime.Now) < 0)
            {
                Show("預約結束時間已過!!");
                return;
            }

            FormMode fm = (FormMode)Enum.Parse(typeof(FormMode), lblFormStatus.Text);
            if (fm == FormMode.Insert)
            {
                if (mrrrRepo.IsUsed(dtpB.SelectedDate.Value, dtpE.SelectedDate.Value, itemId))
                {
                    Show("此時段已被預約");
                    return;
                }

                MeetingRoomRentRecord obj = new MeetingRoomRentRecord();
                obj.MeetingRoomId = itemId;
                obj.EmailNotification = cbEmailNotification.Checked;
                obj.Topic = tbTopic.Text;
                obj.Contents = tbContents.Text;
                obj.EndDateTime = dtpE.SelectedDate.Value;
                obj.StartDateTime = dtpB.SelectedDate.Value;
                TimeSpan ts = obj.EndDateTime - obj.StartDateTime;
                obj.UsedTimeHours = ts.Hours;
                obj.UsedTimeMins = ts.Minutes;
                obj.UsedTotalMins = Convert.ToInt32(ts.TotalMinutes);
                obj.WritedBy = Juser.Nobr;
                obj.WritedDate = DateTime.Now;

                //處理與會人員
                ISelectEmp ss = SelectEmp31 as ISelectEmp;
                var plist = ss.GetSelectedEmps();
                foreach (var p in plist)
                {
                    MeetingRoomRentAttendee aObj = new MeetingRoomRentAttendee();
                    aObj.EmpNo = p;
                    obj.MeetingRoomRentAttendee.Add(aObj);
                }

                mrrrRepo.Add(obj);
                mrrrRepo.Save();
                clearAddForm();
                changeFormMode(FormMode.View);

                if (obj.EmailNotification)
                    notifyEmail(obj.Id);

                rebindSch();

                ss.ClearSelected();
                Show("會議室已預約完成");
                return;
            }
            else if (fm == FormMode.Update)
            {
                int mrrrId = Convert.ToInt32(lblId.Text);
                if (mrrrRepo.IsUsedExceptSelf(dtpB.SelectedDate.Value, dtpE.SelectedDate.Value, itemId, mrrrId))
                {
                    Show("此時段已被預約，重複");
                    return;
                }
                else
                {
                    var uobj = mrrrRepo.GetByPk(mrrrId);
                    uobj.MeetingRoomId = itemId;
                    uobj.EmailNotification = cbEmailNotification.Checked;
                    uobj.Topic = tbTopic.Text;
                    uobj.Contents = tbContents.Text;
                    uobj.EndDateTime = dtpE.SelectedDate.Value;
                    uobj.StartDateTime = dtpB.SelectedDate.Value;
                    TimeSpan uts = uobj.EndDateTime - uobj.StartDateTime;
                    uobj.UsedTimeHours = uts.Hours;
                    uobj.UsedTimeMins = uts.Minutes;
                    uobj.UsedTotalMins = Convert.ToInt32(uts.TotalMinutes);
                    uobj.WritedBy = Juser.Nobr;
                    uobj.WritedDate = DateTime.Now;

                    //處理與會人員
                    ISelectEmp s = SelectEmp31 as ISelectEmp;
                    var list = s.GetSelectedEmps();

                    MeetingRoomRentAttendee_REPO mrraRepo = new MeetingRoomRentAttendee_REPO(mrrrRepo.dc);
                    var mrraList = mrraRepo.GetByMrrId(uobj.Id);

                    foreach (var p in mrraList)
                    {
                        mrraRepo.Delete(p);
                    }

                    foreach (var p in list)
                    {
                        MeetingRoomRentAttendee aObj = new MeetingRoomRentAttendee();
                        aObj.EmpNo = p;
                        aObj.MeetingRoomRentRecordId = uobj.Id;
                        mrraRepo.Add(aObj);
                    }

                    mrrrRepo.Update(uobj);
                    mrrrRepo.Save();
                    clearAddForm();
                    changeFormMode(FormMode.View);

                    if (uobj.EmailNotification)
                        notifyEmail(uobj.Id);

                    rebindSch();
                    Show("會議室已修改完成");
                    return;
                }
            }
            else
            {
                Show("系統錯誤");
                return;
            }
        }
        else//循環租借
        {
            if ((tpB.SelectedDate.Value.Minute % 30 != 0) || (tpE.SelectedDate.Value.Minute % 30 != 0))
            {
                Show("選擇時間需30分鐘為最小單位");
                return;
            }
            if (dpB.SelectedDate.Value.CompareTo(dpE.SelectedDate.Value) >= 0)
            {
                Show("結束時間不能大於等於開始時間");
                return;
            }
            if (tpB.SelectedDate.Value.CompareTo(tpE.SelectedDate.Value) >= 0)
            {
                Show("結束時間不能大於等於開始時間");
                return;
            }
            if (dpE.SelectedDate.Value.CompareTo(DateTime.Now) < 0)
            {
                Show("預約結束時間已過!!");
                return;
            }
            var weekValue = cbxWeekValue.CheckedItems.Select(p => p.Value).ToList();
            if (weekValue.Count == 0)
            {
                Show("需選擇循環的日期");
                return;
            }

            DateTime sDate = dpB.SelectedDate.Value;
            DateTime tmpDateB;
            DateTime tmpDateE;

            string gpCode = Guid.NewGuid().ToString();

            //處理與會人員
            ISelectEmp s = SelectEmp31 as ISelectEmp;
            var list = s.GetSelectedEmps();

            StringBuilder sb = new StringBuilder("");
            while (sDate.CompareTo(dpE.SelectedDate.Value) <= 0)
            {
                var a = ((int)sDate.DayOfWeek).ToString();
                if (weekValue.Any(p => p == a))
                {
                    tmpDateB = new DateTime(sDate.Year, sDate.Month, sDate.Day, tpB.SelectedDate.Value.Hour, tpB.SelectedDate.Value.Minute, 0);
                    tmpDateE = new DateTime(sDate.Year, sDate.Month, sDate.Day, tpE.SelectedDate.Value.Hour, tpE.SelectedDate.Value.Minute, 0);
                    if (mrrrRepo.IsUsed(tmpDateB, tmpDateE, itemId))
                    {
                        sb.Append("日期：");
                        sb.Append(tmpDateB.ToShortDateString());
                        sb.Append("、");
                        //Show("此時段已被預約");
                        //return;
                    }
                    else
                    {
                        MeetingRoomRentRecord obj = new MeetingRoomRentRecord();
                        obj.MeetingRoomId = itemId;
                        obj.EmailNotification = cbEmailNotification.Checked;
                        obj.Topic = tbTopic.Text;
                        obj.Contents = tbContents.Text;
                        obj.EndDateTime = tmpDateE;
                        obj.StartDateTime = tmpDateB;
                        TimeSpan ts = obj.EndDateTime - obj.StartDateTime;
                        obj.UsedTimeHours = ts.Hours;
                        obj.UsedTimeMins = ts.Minutes;
                        obj.UsedTotalMins = Convert.ToInt32(ts.TotalMinutes);
                        obj.WritedBy = Juser.Nobr;
                        obj.WritedDate = DateTime.Now;
                        obj.GroupCode = gpCode;

                        foreach (var p in list)
                        {
                            MeetingRoomRentAttendee aObj = new MeetingRoomRentAttendee();
                            aObj.EmpNo = p;
                            obj.MeetingRoomRentAttendee.Add(aObj);
                        }

                        mrrrRepo.Add(obj);
                    }
                }

                sDate = sDate.AddDays(1);
            }

            mrrrRepo.Save();
            rebindSch();

            s.ClearSelected();
            if (sb.Length == 0)
                Show("會議室已預約完成");
            else
            {
                sb.Insert(0, "以下日期皆已被預約");
                Show(sb.ToString());
            }
        }
    }

    private void clearAddForm()
    {
        tbContents.Text = "";
        tbTopic.Text = "";
        ISelectEmp s = SelectEmp31 as ISelectEmp;
        s.ClearSelected();
    }

    private List<Appointment> Convert2App(List<MeetingRoomRentRecord> crrList)
    {
        List<Appointment> resultList = new List<Appointment>();
        foreach (var crr in crrList)
        {
            Appointment ap = new Appointment();
            ap.ID = crr.Id;
            ap.Start = RadScheduler1.DisplayToUtc(crr.StartDateTime);
            ap.End = RadScheduler1.DisplayToUtc(crr.EndDateTime);

            StringBuilder sb = new StringBuilder();
            sb.Append("[");
            sb.Append(crr.MeetingRoom.Name);
            sb.Append("]");
            if (crr.BASE != null)
            {
                sb.Append(crr.BASE.NAME_C);
            }

            sb.Append("(");
            sb.Append(crr.BASE.SUBTEL);
            sb.Append(")");

            //sb.Append("[");
            //sb.Append(crr.StartDateTime.ToString("HH:mm"));
            //sb.Append("-");
            //sb.Append(crr.EndDateTime.ToString("HH:mm"));
            //sb.Append("]");
            ap.Subject = sb.ToString();
            resultList.Add(ap);
        }

        return resultList;
    }

    protected void cbxItem_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        rebindSch();
    }

    protected void RadScheduler1_AppointmentDataBound(object sender, SchedulerEventArgs e)
    {
        if (mrrrList != null)
        {
            int id = Convert.ToInt32(e.Appointment.ID);

            var obj = (from c in mrrrList where c.Id == id select c).FirstOrDefault();
            if (obj != null)
            {
                if (obj.MeetingRoom.DispBackColor.HasValue)
                    e.Appointment.BackColor = System.Drawing.Color.FromArgb(obj.MeetingRoom.DispBackColor.Value);
            }
        }
    }

    protected void dtpB_SelectedDateChanged(object sender, Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs e)
    {
        if (!dtpE.SelectedDate.HasValue)
            dtpE.SelectedDate = dtpB.SelectedDate.Value;
    }

    protected void RadScheduler1_AppointmentCreated(object sender, AppointmentCreatedEventArgs e)
    {
        if (mrrrList != null)
        {
            int id = Convert.ToInt32(e.Appointment.ID);

            var obj = (from c in mrrrList where c.Id == id select c).FirstOrDefault();
            if (obj != null)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(@"<br \>");
                sb.Append(obj.StartDateTime.ToString("HH:mm"));
                sb.Append("-");
                sb.Append(obj.EndDateTime.ToString("HH:mm"));
                sb.Append(@"<br \>");
                sb.Append("[");
                sb.Append(obj.Topic);
                sb.Append("]");

                Label timeLb = new Label();
                timeLb.Text = sb.ToString();
                e.Container.Controls.Add(timeLb);

                e.Appointment.ToolTip = e.Appointment.Subject + timeLb.Text;
                e.Appointment.ToolTip = e.Appointment.ToolTip.Replace(@"<br \>", "");

                var pnlDelCycle = e.Appointment.AppointmentControls[0].AppointmentContainer.FindControl("pnlDelCycle") as Panel;
                var cbDelCycle = pnlDelCycle.FindControl("cbDelCycle") as CheckBox;
                if (cbDelCycle != null)
                {
                    if (obj.GroupCode == null)
                        pnlDelCycle.Visible = false;
                    else
                    {
                        if ((obj.WritedBy == Juser.Nobr || Juser.IsInRole("HR")) && obj.EndDateTime.CompareTo(DateTime.Now) > 0)
                            pnlDelCycle.Visible = true;
                    }
                }
            }
        }
    }

    protected void RadScheduler1_NavigationComplete(object sender, SchedulerNavigationCompleteEventArgs e)
    {
        rebindSch();
    }

    private void notifyEmail(int id)
    {
        BASE_REPO baseRepo = new BASE_REPO();

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

        var mrrrObj = mrrrRepo.GetByPk_Dlo(id);

        StringBuilder sb = new StringBuilder();
        mailMessage.Subject = @"【會議室預約通知】" + " " + mrrrObj.MeetingRoom.Name + "-" + mrrrObj.Topic;

        sb.Append("<table>");
        sb.Append("<tr>");
        sb.Append("<td>");
        sb.Append("會議室名稱");
        sb.Append("</td>");
        sb.Append("<td>");
        sb.Append(mrrrObj.MeetingRoom.Name);
        sb.Append("</td>");
        sb.Append("</tr>");

        sb.Append("<tr>");
        sb.Append("<td>");
        sb.Append("預約者姓名");
        sb.Append("</td>");
        sb.Append("<td>");
        sb.Append(mrrrObj.BASE.NAME_C);
        sb.Append("</td>");
        sb.Append("</tr>");

        sb.Append("<tr>");
        sb.Append("<td>");
        sb.Append("分機號碼");
        sb.Append("</td>");
        sb.Append("<td>");
        sb.Append(mrrrObj.BASE.SUBTEL);
        sb.Append("</td>");
        sb.Append("</tr>");

        sb.Append("<tr>");
        sb.Append("<td>");
        sb.Append("會議開始時間");
        sb.Append("</td>");
        sb.Append("<td>");
        sb.Append(mrrrObj.StartDateTime.ToString("yyyy/MM/dd HH:mm"));
        sb.Append("</td>");
        sb.Append("</tr>");

        sb.Append("<tr>");
        sb.Append("<td>");
        sb.Append("會議結束時間");
        sb.Append("</td>");
        sb.Append("<td>");
        sb.Append(mrrrObj.EndDateTime.ToString("yyyy/MM/dd HH:mm"));
        sb.Append("</td>");
        sb.Append("</tr>");

        sb.Append("<tr>");
        sb.Append("<td>");
        sb.Append("會議主旨");
        sb.Append("</td>");
        sb.Append("<td>");
        sb.Append(mrrrObj.Topic);
        sb.Append("</td>");
        sb.Append("</tr>");

        sb.Append("<tr>");
        sb.Append("<td>");
        sb.Append("會議內容");
        sb.Append("</td>");
        sb.Append("<td>");
        sb.Append(mrrrObj.Contents);
        sb.Append("</td>");
        sb.Append("</tr>");

        sb.Append("<tr>");
        sb.Append("<td>");
        sb.Append("與會人員");
        sb.Append("</td>");
        sb.Append("<td>");
        var empList = mrrrObj.MeetingRoomRentAttendee.Select(p => p.BASE.NAME_C).ToList();
        sb.Append(listToString(empList));
        sb.Append("</td>");
        sb.Append("</tr>");
        sb.Append("</table>");

        sb.Append("<br><br>");
        sb.Append("請準時參加!");
        sb.Append("<br><br>");
        sb.Append("((此為會議室預約系統所發之通知信，請勿直接回覆))");

        mailMessage.Body = sb.ToString();

        //先加上預約人的通知
        if (SiteHelper.IsMailAddress(mrrrObj.BASE.EMAIL))
            mailMessage.To.Add(mrrrObj.BASE.EMAIL);

        //與會人員的通知
        foreach (var emp in mrrrObj.MeetingRoomRentAttendee)
        {
            if (SiteHelper.IsMailAddress(emp.BASE.EMAIL))
                mailMessage.To.Add(emp.BASE.EMAIL);
        }

        smtpClient.Send(mailMessage);
    }

    private string listToString(List<string> list)
    {
        StringBuilder sb = new StringBuilder();
        foreach (var l in list)
        {
            sb.Append(l);
            sb.Append("、");
        }

        if (sb.Length > 0)
        {
            sb[sb.Length - 1].Equals("、");
            sb = sb.Remove(sb.Length - 1, 1);
        }

        return sb.ToString();
    }

    protected void rblType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rblType.SelectedValue.Equals("0"))
        {
            btnSave.ValidationGroup = "G0";
            pnlSingle.Visible = true;
            pnlCycle.Visible = false;
        }
        else
        {
            btnSave.ValidationGroup = "G1";
            pnlSingle.Visible = false;
            pnlCycle.Visible = true;
        }
    }

    protected void RadScheduler1_AppointmentClick(object sender, SchedulerEventArgs e)
    {
        int id = (int)e.Appointment.ID;
        loadData(id);
        changeFormMode(FormMode.ViewDetail);
        rebindSch();
    }

    protected void btnEdit_Click(object sender, EventArgs e)
    {
        changeFormMode(FormMode.Update);
        loadData(Convert.ToInt32(lblId.Text));
    }
}