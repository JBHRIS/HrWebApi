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
using BL;
using System.Linq;
using System.Collections.Generic;
using Telerik.Web.UI;
using System.Text;
public partial class CarRent : JBWebPage
{
    private CarRentRecord_REPO crrRepo = new CarRentRecord_REPO();
    private List<CarRentRecord> carRentRecordList = null;

    protected override void OnInit(EventArgs e)
    {
        if ( !IsPostBack )
        {            
        }

        CanCopy = true;
        base.OnInit(e);
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
        Car_REPO carRepo = new Car_REPO();
        List<Car> carList = carRepo.GetByCanRent(true);
        foreach(var c in carList)
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


    protected void RadScheduler1_AppointmentInsert(object sender, SchedulerCancelEventArgs e)
    {
    }

    protected void RadScheduler1_AppointmentUpdate(object sender, AppointmentUpdateEventArgs e)
    {
    }

    protected void RadScheduler1_AppointmentDelete(object sender, SchedulerCancelEventArgs e)
    {
    }

    protected void RadScheduler1_AppointmentDelete(object sender, AppointmentDeleteEventArgs e)
    {
        int id = Convert.ToInt32(e.Appointment.ID);
        var crr= crrRepo.GetByPk(id);
        if ( crr.WritedBy != Juser.Nobr )
        {
            if ( !Juser.IsInRole("HR") )
            {
                Show("非本人不得刪除");
                e.Cancel = true;
                rebindSch();
                return;
            }
        }
        if (crr.EndDateTime <= DateTime.Now)
        {
            Show("已結束不得刪除");
            e.Cancel = true;
            rebindSch();
            return;
        }

        crr.Cancel = true;
        crr.Canceler = Juser.Nobr;
        crrRepo.Update(crr);
        crrRepo.Save();
    }
    protected void RadScheduler1_FormCreating(object sender, SchedulerFormCreatingEventArgs e)
    {

    }
    protected void RadScheduler1_NavigationCommand(object sender, SchedulerNavigationCommandEventArgs e)
    {
        if(e.Command == SchedulerNavigationCommand.NavigateToSelectedDate || e.Command == SchedulerNavigationCommand.SwitchToSelectedDay)
        {
        }
        //rebindSch();
    }

    private void rebindSch()
    {
        if ( cbxItem.SelectedItem != null )
        {
            List<CarRentRecord> crrList = new List<CarRentRecord>();

            if (!cbxItem.SelectedValue.Equals("All"))
            {
                crrList = crrRepo.GetByDate_Dlo(RadScheduler1.VisibleRangeStart.Date, RadScheduler1.VisibleRangeEnd.Date, Convert.ToInt32(cbxItem.SelectedValue), false);
            }
            else
            {
                crrList = crrRepo.GetByDate_Dlo(RadScheduler1.VisibleRangeStart.Date, RadScheduler1.VisibleRangeEnd.Date, false);
            }

            carRentRecordList = crrList;
            RadScheduler1.DataSource = Convert2App(crrList);
        }
    }

    private void changeFormMode(FormMode m)
    {
        if (m == FormMode.Update)
        {
            pnlAddForm.Visible = true;
            btnAdd.Visible = false;
            btnSave.Visible = true;
            btnEdit.Visible = false;
        }
        else if (m == FormMode.ViewDetail)
        {
            pnlAddForm.Visible = true;
            btnAdd.Visible = false;
            btnSave.Visible = false;

            btnEdit.Visible = false;
            var item = crrRepo.GetByPk(Convert.ToInt32(lblId.Text));
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

            btnAdd.Visible = true;
            btnSave.Visible = true;
            btnEdit.Visible = false;
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

    protected void RadScheduler1_AppointmentCommand(object sender, AppointmentCommandEventArgs e)
    {

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
        int itemId = Convert.ToInt32(cbxItem.SelectedValue);

        if (cbxItem.SelectedValue.Equals("All"))
        {
            Show("請先選擇預約的車輛");
            return;
        }

        if (dtpE.SelectedDate.Value.CompareTo(DateTime.Now) < 0)
        {
            Show("預約結束時間已過!!");
            return;
        }       
        
        if((dtpB.SelectedDate.Value.Minute %30!=0) || (dtpE.SelectedDate.Value.Minute %30 !=0))
        {
            Show("選擇時間需30分鐘為最小單位");
            return;
        }

        if ( dtpB.SelectedDate.Value.CompareTo(dtpE.SelectedDate.Value) >= 0 )
        {
            Show("結束時間不能大於等於開始時間");
            return;
        }

        int carId = Convert.ToInt32(cbxItem.SelectedValue);
        FormMode fm = (FormMode)Enum.Parse(typeof(FormMode), lblFormStatus.Text);
        if (fm == FormMode.Insert)
        {
            if (crrRepo.IsUsed(dtpB.SelectedDate.Value, dtpE.SelectedDate.Value, carId))
            {
                Show("此時段已被預約");
                return;
            }

            CarRentRecord obj = new CarRentRecord();
            obj.CarId = carId;
            obj.Contents = tbContents.Text;
            obj.Destination = tbDestination.Text;
            obj.EndDateTime = dtpE.SelectedDate.Value;
            obj.MileageAfterRent = Convert.ToInt32(ntbMileageAfterRent.Value);
            obj.MileageBeforeRent = Convert.ToInt32(ntbMileageBeforeRent.Value);
            obj.StartDateTime = dtpB.SelectedDate.Value;
            TimeSpan ts = obj.EndDateTime - obj.StartDateTime;
            obj.UsedTimeHours = ts.Hours;
            obj.UsedTimeMins = ts.Minutes;
            obj.UsedTotalMins = Convert.ToInt32(ts.TotalMinutes);
            obj.WritedBy = Juser.Nobr;
            obj.WritedDate = DateTime.Now;
            crrRepo.Add(obj);
            crrRepo.Save();

            clearAddForm();
            changeFormMode(FormMode.View);
        }
        else if (fm == FormMode.Update)
        {
            int crrId = Convert.ToInt32(lblId.Text);
            if (crrRepo.IsUsedExceptSelf(dtpB.SelectedDate.Value, dtpE.SelectedDate.Value, itemId, crrId))
            {
                Show("此時段已被預約，重複");
                return;
            }
            else
            {
                var uobj = crrRepo.GetByPk(crrId);
                uobj.CarId = itemId;
                uobj.Destination = tbDestination.Text;
                uobj.Contents = tbContents.Text;
                uobj.EndDateTime = dtpE.SelectedDate.Value;
                uobj.StartDateTime = dtpB.SelectedDate.Value;
                TimeSpan uts = uobj.EndDateTime - uobj.StartDateTime;
                uobj.UsedTimeHours = uts.Hours;
                uobj.UsedTimeMins = uts.Minutes;
                uobj.UsedTotalMins = Convert.ToInt32(uts.TotalMinutes);
                uobj.WritedBy = Juser.Nobr;
                uobj.WritedDate = DateTime.Now;

                crrRepo.Update(uobj);
                crrRepo.Save();
                clearAddForm();
                changeFormMode(FormMode.View);

                rebindSch();
                Show("公務車已修改完成");
                return;
            }
        }

        rebindSch();
    }

    private void clearAddForm()
    {
        tbContents.Text = "";
        tbDestination.Text = "";
        ntbMileageAfterRent.Value = 0;
        ntbMileageBeforeRent.Value = 0;
    }

    private List<Appointment> Convert2App(List<CarRentRecord> crrList)
    {
        List<Appointment> resultList = new List<Appointment>();
        foreach ( var crr in crrList )
        {            
            Appointment ap = new Appointment();
            ap.ID = crr.Id;
            ap.Start =  RadScheduler1.DisplayToUtc(crr.StartDateTime);
            ap.End = RadScheduler1.DisplayToUtc(crr.EndDateTime);

            StringBuilder sb = new StringBuilder();
            sb.Append("[");
            sb.Append(crr.Car.Name);
            sb.Append("]");
            if ( crr.BASE != null )
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
    protected void cbxItem_SelectedIndexChanged(object sender , RadComboBoxSelectedIndexChangedEventArgs e)
    {
        rebindSch();        
    }
    protected void RadScheduler1_AppointmentDataBound(object sender , SchedulerEventArgs e)
    {
        if (carRentRecordList != null)
        {
            int id = Convert.ToInt32(e.Appointment.ID);

            var obj = (from c in carRentRecordList where c.Id == id select c).FirstOrDefault();
            if (obj != null)
            {
                if (obj.Car.DispBackColor.HasValue)
                    e.Appointment.BackColor = System.Drawing.Color.FromArgb(obj.Car.DispBackColor.Value);
            }
        }
    }
    protected void dtpB_SelectedDateChanged(object sender , Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs e)
    {
        if (!dtpE.SelectedDate.HasValue)
            dtpE.SelectedDate = dtpB.SelectedDate.Value;
    }
    protected void RadScheduler1_AppointmentCreated(object sender, AppointmentCreatedEventArgs e)
    {
        if (carRentRecordList != null)
        {
            int id = Convert.ToInt32(e.Appointment.ID);

            var obj = (from c in carRentRecordList where c.Id == id select c).FirstOrDefault();
            if (obj != null)
            {           
                StringBuilder sb = new StringBuilder();
                sb.Append(@"<br \>");
                sb.Append(obj.StartDateTime.ToString("HH:mm"));
                sb.Append("-");
                sb.Append(obj.EndDateTime.ToString("HH:mm"));
                sb.Append(@"<br \>");
                sb.Append("[");
                sb.Append(obj.Contents);
                sb.Append("]");

                Label timeLb = new Label();
                timeLb.Text = sb.ToString();
                e.Container.Controls.Add(timeLb);

                e.Appointment.ToolTip = e.Appointment.Subject + timeLb.Text;
                e.Appointment.ToolTip = e.Appointment.ToolTip.Replace(@"<br \>", "");
            }
        }
    }
    protected void RadScheduler1_NavigationComplete(object sender, SchedulerNavigationCompleteEventArgs e)
    {
        rebindSch();
    }
    protected void btnEdit_Click(object sender, EventArgs e)
    {
        changeFormMode(FormMode.Update);
        loadData(Convert.ToInt32(lblId.Text));
    }

    private void loadData(int id)
    {
        var item = crrRepo.GetByPk(id);
        dtpB.SelectedDate = item.StartDateTime;
        dtpE.SelectedDate = item.EndDateTime;
        tbContents.Text = item.Contents;
        tbDestination.Text = item.Destination;
        lblId.Text = item.Id.ToString();
    }
    protected void RadScheduler1_AppointmentClick(object sender, SchedulerEventArgs e)
    {
        int id = (int)e.Appointment.ID;
        loadData(id);
        changeFormMode(FormMode.ViewDetail);
        rebindSch();
    }
}
