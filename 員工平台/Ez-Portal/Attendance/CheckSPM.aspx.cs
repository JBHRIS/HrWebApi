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

public partial class Attendance_CheckSPM : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            adate.SelectedDate = DateTime.Now.Date;
            ddate.SelectedDate = DateTime.Now.Date;

        }

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        SpmDSTableAdapters.VLeaveTableAdapter VLAD = new SpmDSTableAdapters.VLeaveTableAdapter();
        SpmDS.VLeaveDataTable VLDT = VLAD.GetData(adate.SelectedDate.Value, ddate.SelectedDate.Value);
        SpmDS.VLeaveDataTable VLDT_temp = new SpmDS.VLeaveDataTable();
        SpmDSTableAdapters.ABSTableAdapter abad = new SpmDSTableAdapters.ABSTableAdapter();

        lb_spm.Text = VLDT.Rows.Count.ToString();

        for (int i = 0; i < VLDT.Rows.Count; i++) {

            bool isError = false;
            for (DateTime _i = VLDT[i].LeaveDateSince; _i <= VLDT[i].LeaveDateEnd; _i = _i.AddDays(1))
            {

                SpmDS.ABSDataTable abdt = abad.GetData(VLDT[i].StaffNo, _i, VLDT[i].LeaveCategory);
                if (abdt.Rows.Count == 0)
                {
                    if (!getVLeaveCancel(VLDT[i].StaffNo, _i))
                    {

                        isError = true;
                        continue;
                    }
                }

            }

            if (isError) {
                VLDT_temp.Rows.Add(VLDT[i].ItemArray);
            }
        
        }
        lb_HR.Text = VLDT_temp.Rows.Count.ToString();
        GridView1.DataSource = VLDT_temp;
        GridView1.DataBind();

    }


    bool getVLeaveCancel(string nobr, DateTime adate)
    {
        SpmDSTableAdapters.VLeaveCancelTableAdapter vlcad = new SpmDSTableAdapters.VLeaveCancelTableAdapter();
        SpmDS.VLeaveCancelDataTable vlcdt = vlcad.GetData(nobr, adate);
        bool isOK = false;
        if (vlcdt.Rows.Count > 0)
        {
            isOK = true;
        }
        return isOK;
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        SpmDSTableAdapters.VOverTimeTableAdapter VLAD = new SpmDSTableAdapters.VOverTimeTableAdapter();
        SpmDS.VOverTimeDataTable VLDT = VLAD.GetData(adate.SelectedDate.Value, ddate.SelectedDate.Value);
        SpmDS.VOverTimeDataTable VLDT_temp = new SpmDS.VOverTimeDataTable();
        SpmDSTableAdapters.OTTableAdapter abad = new SpmDSTableAdapters.OTTableAdapter();

        lb_spm.Text = VLDT.Rows.Count.ToString();

        for (int i = 0; i < VLDT.Rows.Count; i++)
        {

            bool isError = false;
            for (DateTime _i = DateTime.Parse( VLDT[i].StartDate); _i <=DateTime.Parse(  VLDT[i].EndDate); _i = _i.AddDays(1))
            {

                SpmDS.OTDataTable abdt = abad.GetData(VLDT[i].StaffNo, DateTime.Parse(VLDT[i].StartDate));
                if (abdt.Rows.Count == 0)
                {
                  

                        isError = true;
                        continue;
                  
                }

            }

            if (isError)
            {
                VLDT_temp.Rows.Add(VLDT[i].ItemArray);
            }

        }
        lb_HR.Text = VLDT_temp.Rows.Count.ToString();
        GridView1.DataSource = VLDT_temp;
        GridView1.DataBind();
    }
}
