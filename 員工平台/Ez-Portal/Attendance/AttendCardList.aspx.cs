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

public partial class Attendance_AttendCardList : JBWebPage
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack) {
            adate.SelectedDate = DateTime.Now.Date;
            ddate.SelectedDate = DateTime.Now.Date;
            loadData();
        }
    }


    void loadData() {
        RoteExDsTableAdapters.AttendExTableAdapter attad = new RoteExDsTableAdapters.AttendExTableAdapter();
        DateTime _adate = adate.SelectedDate.Value;
        DateTime _ddate = ddate.SelectedDate.Value;



        RoteExDs.AttendExDataTable atdt = new RoteExDs.AttendExDataTable();

        for (; _adate <= _ddate; _adate =_adate.AddDays(1))
        {
            atdt.Merge(attad.GetDataByMa(_adate));
        }

        Session["rv_card"] = atdt;
        GridView1.DataSource = atdt;
        GridView1.DataBind();
    
    
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow) {
            Label lb_inTime = (Label)e.Row.FindControl("lb_inTime");
            Label lb_outTime = (Label)e.Row.FindControl("lb_outTime");
            Label lb_abs = (Label)e.Row.FindControl("lb_abs");
            DateTime adate_ = DateTime.Parse(e.Row.Cells[3].Text);
            string nobr = e.Row.Cells[0].Text;
            lb_inTime.Text = getInTime(nobr, adate_);
            lb_outTime.Text = getOutTime(nobr, adate_);

            string def_inTime =((Label)e.Row.FindControl("lb_on_time")).Text;
            string def_outTime = ((Label)e.Row.FindControl("lb_off_time")).Text;
            bool is24 = false;
            bool iserror = false;

            if (def_outTime.Trim().Length >= 2)
            {
                int outtime = int.Parse(def_outTime.Substring(0, 2));
                if (outtime > 24) {
                    lb_outTime.Text = getOutTime(nobr, adate_.AddDays(1));
                    is24 = true;
                }
            }


            int newhour = DateTime.Now.Hour;
            int newsec = DateTime.Now.Second;
            int nowtime = (newhour * 60) + newsec;

            if (def_inTime.Trim().Length > 0) {
                if (lb_inTime.Text.Length == 0) {

                    if (DateTime.Now.ToShortDateString().Equals(adate_.ToShortDateString()))
                    {
                        if (nowtime > setTime(def_inTime))
                        {

                            iserror = true;
                            e.Row.BackColor = System.Drawing.Color.Red;
                        }
                    }
                    else {
                        iserror = true;
                        e.Row.BackColor = System.Drawing.Color.Red;
                    }
                    
                    
                }
                else if (setTime(def_inTime) < setTime(lb_inTime.Text))
                {
                    if (setTime(lb_inTime.Text) - setTime(def_inTime) >= 240)
                    {
                        e.Row.BackColor = System.Drawing.Color.Green;
                    }
                    else
                    {
                        e.Row.BackColor = System.Drawing.Color.Yellow;
                    }
                    iserror = true;

                }

            
            }

            if (!iserror)
            {


                if (def_outTime.Trim().Length > 0)
                {
                    if (lb_outTime.Text.Length == 0)
                    {
                        if (DateTime.Now.ToShortDateString().Equals(adate_.ToShortDateString()))
                        {
                            if (nowtime > setTime(def_outTime))
                            {

                                iserror = true;
                                e.Row.BackColor = System.Drawing.Color.Red;
                            }
                        }
                        else
                        {

                            iserror = true;
                            e.Row.BackColor = System.Drawing.Color.Red;
                        }

                    }
                    else if (setTime(def_outTime) > setTime(lb_outTime.Text))
                    {
                        if (is24)
                        {
                            if (setTime(def_outTime) > (setTime(lb_outTime.Text) + 24 * 60))
                            {
                                e.Row.BackColor = System.Drawing.Color.Yellow;
                                iserror = true;

                            }
                        }
                        else
                        {
                            e.Row.BackColor = System.Drawing.Color.Yellow;
                            iserror = true;

                        }
                    }
                }
            }


            if (!iserror)
            {
                e.Row.Visible = false;

            }
            else {
               lb_abs.Text = getAbsList(nobr, adate_);
            }


        }
    }

    int setTime(string time) 
    {
        int sen = 0;
        if (time.Trim().Length == 4) {
            sen = int.Parse(time.Trim().Substring(0, 2))*60;
            sen += int.Parse(time.Trim().Substring(2));

        }

        return sen;
    }


    string getInTime(string nobr, DateTime adate)
    {
        RoteExDsTableAdapters.CARDTableAdapter cad = new RoteExDsTableAdapters.CARDTableAdapter();
        RoteExDs.CARDDataTable cdt = cad.GetDataByInTime(nobr, adate);
        string inTime = "";
        if (cdt.Rows.Count > 0)
        {
            inTime = cdt[0].ONTIME;

        }

        return inTime;
    }

    string getAbsList(string nobr, DateTime adate)
    {
        RoteExDsTableAdapters.AbsListTableAdapter absad = new RoteExDsTableAdapters.AbsListTableAdapter();
        RoteExDs.AbsListDataTable absdt = absad.GetData(nobr, adate);
        string note = "";
        if (absdt.Rows.Count>0) 
        {
            note = absdt[0].H_NAME.Trim() + ",時數：" + absdt[0].TOL_HOURS.ToString() + ",時間：" + absdt[0].BTIME + "~" + absdt[0].ETIME;
        }

        return note;
    }

    string getOutTime(string nobr, DateTime adate)
    {
        RoteExDsTableAdapters.CARDTableAdapter cad = new RoteExDsTableAdapters.CARDTableAdapter();
        RoteExDs.CARDDataTable cdt = cad.GetDataByOutTime(nobr, adate);
        string inTime = "";
        if (cdt.Rows.Count > 0)
        {
            inTime = cdt[0].ONTIME;

        }

        return inTime;
    }


    protected void Button1_Click(object sender, EventArgs e)
    {
        if (adate.SelectedDate.Value > ddate.SelectedDate.Value)
            return;

        loadData();

    }
    protected void ExportExcel_Click(object sender, EventArgs e)
    {
        if (Session["rv_card"] != null)
            JB.WebModules.Data.Export.Excel.WebResponseExcel(this, GridView1, (RoteExDs.AttendExDataTable)Session["rv_card"], "CardList");
        else
            JB.WebModules.Message.Show("無資料可匯出！");
    }
}
