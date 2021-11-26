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
using Telerik.Web.UI.Calendar;

public partial class Attendance_SP_Card : JBWebPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) {
            ddate.SelectedDate = DateTime.Now.Date;

        }

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if(tb_card.Text .Trim().Length != 4){
            JB.WebModules.Message.Show("輸入刷卡時間有問題！");
            return;
        }

        if (TextBox1.Text.Trim().Length > 0 && lb_name_c.Text.Trim().Length > 0)
        {
            AttendDsTableAdapters.CARDTableAdapter rad = new AttendDsTableAdapters.CARDTableAdapter();
            AttendDs.CARDDataTable rdt = rad.GetDataByAdate(TextBox1.Text, ddate.SelectedDate.Value, tb_card.Text);
            if (rdt.Rows.Count == 0)
            {


                AttendDs.CARDRow nrow = rdt.NewCARDRow();
                nrow.NOBR = TextBox1.Text;
                nrow.ADATE = ddate.SelectedDate.Value;
                nrow.CODE = DropDownList1.SelectedValue;
                nrow.ONTIME = tb_card.Text;
                nrow.KEY_MAN = JbUser.NAME_C;
                nrow.KEY_DATE = DateTime.Now;
                nrow.CARDNO = TextBox1.Text;
                nrow.NOT_TRAN = false;
                nrow.DAYS = 0;
                nrow.REASON = "";
                nrow.LOS = true;
                nrow.IPADD = "";
                nrow.MENO = "";
                nrow.SERNO = "";

                rdt.AddCARDRow(nrow);
                rad.Update(rdt);


                GetData(ddate.SelectedDate.Value.Year, ddate.SelectedDate.Value.Month);
                Calendar1.DataBind();
                JB.WebModules.Message.Show("輸入刷卡資料成功！");

                TextBox1.Text = "";
                tb_card.Text = "";
                TextBox1.Focus();
            }
            else {
                JB.WebModules.Message.Show("資料重覆！");
            }


          //  setAttend(ddate.SelectedDate.Value, TextBox1.Text, CONT_REL1.SelectedValue);
          


        }
        else {
            JB.WebModules.Message.Show("工號輸入有問題！");
        }
    }



    void setAttend(DateTime adate, string nobr, string rote)
    {
        AttendDsTableAdapters.ATTEND1TableAdapter attad = new AttendDsTableAdapters.ATTEND1TableAdapter();
        AttendDs.ATTEND1DataTable attdt = attad.GetDataByNobr(nobr, adate);
        if (attdt.Rows.Count > 0) 
        {
            attdt[0].ROTE = rote;
            attdt[0].KEY_DATE = DateTime.Now;
            attdt[0].KEY_MAN = JbUser.NAME_C;
            attad.Update(attdt);
        }
        else
        {
            AttendDs.ATTEND1Row attrow = attdt.NewATTEND1Row();
            attrow.NOBR = nobr;
            attrow.ROTE = rote;
            attrow.ADATE = adate;
            attrow.KEY_DATE = DateTime.Now;
            attrow.KEY_MAN = JbUser.NAME_C;
            attrow.LATE_MINS = 0;
            attrow.E_MINS = 0;
            attrow.ADJ_CODE = "";
            attrow.CANT_ADJ = false;
            attrow.SER = 0;
            attrow.NIGHT_HRS = 0;
            attrow.FOODAMT = 0;
            attrow.FOODSALCD = "";
            attrow.FORGET = 0;
            attrow.ATT_HRS = 0;
            attrow.NIGAMT = 0;
            attrow.ABS = false;

            attdt.AddATTEND1Row(attrow);
            attad.Update(attdt);
        }
    }
    protected void TextBox1_TextChanged(object sender, EventArgs e)
    {
        lb_name_c.Text = getEmpInfo(TextBox1.Text);
        setRote(ddate.SelectedDate.Value);
        GetData(ddate.SelectedDate.Value.Year, ddate.SelectedDate.Value.Month);
    }


    string getEmpInfo(string nobr ) {
        HRDsTableAdapters.EmpInfoTableAdapter empad = new HRDsTableAdapters.EmpInfoTableAdapter();
        HRDs.EmpInfoDataTable empdt = empad.GetDataByNobr(nobr);
        string name = "";
        if (empdt.Rows.Count > 0) {
            name = empdt[0].NAME_C;
        }
        return name;
    }
    protected void ddate_SelectedDateChanged(object sender, SelectedDateChangedEventArgs e)
    {

        setRote(e.NewDate.Value);
    }


    void setRote(DateTime adate) {
        RoteExDsTableAdapters.AttendExTableAdapter attad = new RoteExDsTableAdapters.AttendExTableAdapter();

        RoteExDs.AttendExDataTable atdt = attad.GetDataByNobr(adate, TextBox1.Text);
        if (atdt.Rows.Count > 0)
        {
            lb_rote.Text = atdt[0].ROTENAME;
        }
    }
    protected void Calendar1_DayRender(object sender, System.Web.UI.WebControls.DayRenderEventArgs e)
    {
        if (Session["rv_attend"] == null)
        {


            GetData(e.Day.Date.Year,e.Day.Date.Month);
        }
        try
        {

            HRDs.rv_attendDataTable bdt = (HRDs.rv_attendDataTable)Session["rv_attend"];
            HRDs.rv_attendRow[] brow = (HRDs.rv_attendRow[])bdt.Select("adate ='" + e.Day.Date.ToShortDateString() + "'");

            HRDs.rv_cardDataTable rv_cardDs = (HRDs.rv_cardDataTable)Session["rv_card"];
            HRDs.rv_cardRow[] rcards = (HRDs.rv_cardRow[])rv_cardDs.Select("adate ='" + e.Day.Date.ToShortDateString() + "'");
            if (brow.Length > 0)
            {

                string s_2 = "";
                string s_1 = "   <tr> <td> <span style=\"color: #000099\">班別</span>：" + brow[0].ROTENAME + "</td> </tr> ";
                for (int i = 0; i < rcards.Length; i++)
                {
                    string cardtpyename = "";
                    if (rcards[i].CODE.Trim().Equals("進入"))
                    {
                        cardtpyename = "刷入";
                    }
                    else if (rcards[i].CODE.Trim().Equals("離開"))
                    {
                        cardtpyename = "刷出";
                    }

                    if (cardtpyename.Trim().Length == 0)
                    {
                        string ss = "";
                    }
                    s_2 += "  <tr>  <td><span style=\"color: #ff0000\">" + cardtpyename + "</span>：" + rcards[i].ONTIME + "</td> </tr> ";

                }
                


                string html = "";
                html = "<br><br><table width='100%' border='0' cellspacing='1' cellpadding='2' > " +

                    s_1 + s_2 +

                    " </table> ";
                Label lb = new Label();
                lb.Text = html;
                e.Cell.Controls.Add(lb);
            }
        }
        catch { }
    }
    protected void Calendar1_SelectionChanged(object sender, EventArgs e)
    {

    }
    protected void Calendar1_VisibleMonthChanged(object sender, MonthChangedEventArgs e)
    {
        GetData(e.NewDate.Year,e.NewDate.Month);
    }


    void GetData(int yy,int month)
    {
        HRDsTableAdapters.rv_attendTableAdapter rv_attend = new HRDsTableAdapters.rv_attendTableAdapter();
        HRDs.rv_attendDataTable rv_attendDs = new HRDs.rv_attendDataTable();
        HRDsTableAdapters.rv_cardTableAdapter rv_card = new HRDsTableAdapters.rv_cardTableAdapter();
        HRDs.rv_cardDataTable rv_cardDs = new HRDs.rv_cardDataTable();

        DateTime _adate = DateTime.Parse(yy.ToString() + "/" + month.ToString()+ "/1");
        DateTime _ddate = DateTime.Parse(yy.ToString() + "/" + month.ToString() + "/" + DateTime.DaysInMonth(yy, month).ToString());


        rv_attendDs.Merge(rv_attend.GetData_rv_attend(_adate, _ddate, TextBox1.Text, ""));
        rv_cardDs.Merge(rv_card.GetData_rv_card(_adate,_ddate, TextBox1.Text, ""));
       
        Session["rv_card"] = rv_cardDs;
        Session["rv_attend"] = rv_attendDs;
       
        Calendar1.DataBind();
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        GetData(ddate.SelectedDate.Value.Year, ddate.SelectedDate.Value.Month);
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        if (tb_card.Text.Trim().Length != 4)
        {
            JB.WebModules.Message.Show("輸入刷卡時間有問題！");
            return;
        }

        if (TextBox1.Text.Trim().Length > 0 && lb_name_c.Text.Trim().Length > 0)
        {
            AttendDsTableAdapters.CARDTableAdapter rad = new AttendDsTableAdapters.CARDTableAdapter();
            AttendDs.CARDDataTable rdt = rad.GetDataByAdate(TextBox1.Text, ddate.SelectedDate.Value, tb_card.Text);
            if (rdt.Rows.Count == 0)
            {

                JB.WebModules.Message.Show("找不到你刪除的資料！");
               
                TextBox1.Focus();
            }
            else
            {
                for (int i = rdt.Rows.Count; i > 0; i--) {
                    rdt.Rows[i - 1].Delete();
                }
                rad.Update(rdt);
                JB.WebModules.Message.Show("刪除成功！");
                GetData(ddate.SelectedDate.Value.Year, ddate.SelectedDate.Value.Month);
            }


            //  setAttend(ddate.SelectedDate.Value, TextBox1.Text, CONT_REL1.SelectedValue);



        }
        else
        {
            JB.WebModules.Message.Show("工號輸入有問題！");
        }
    }
}
