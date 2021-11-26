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

public partial class Attendance_SelectBak : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) {

            GetData(DateTime.Parse(DateTime.Now.Year.ToString() + "/" + DateTime.Now.Month + "/1"),
            DateTime.Parse(DateTime.Now.Year.ToString() + "/" + DateTime.Now.Month + "/" + DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month).ToString()));
        }

    }



    void GetData(DateTime adate ,DateTime ddate)
    {

        AttendDsTableAdapters.selectAttBakTableAdapter attad = new AttendDsTableAdapters.selectAttBakTableAdapter();
        AttendDs.selectAttBakDataTable attdt = attad.GetData(adate, ddate);




        Session["attbak"] = attdt;

        Calendar2.DataBind();
    }

    protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
    {
         if (Session["attbak"] == null)
        {


            
            GetData(DateTime.Parse(e.Day.Date.Year.ToString() + "/" + e.Day.Date.Month + "/1"),DateTime.Parse(e.Day.Date.Year.ToString() + "/" + e.Day.Date.Month + "/" + DateTime.DaysInMonth(e.Day.Date.Year, e.Day.Date.Month).ToString()));
        }

        AttendDs.selectAttBakDataTable bdt = (AttendDs.selectAttBakDataTable)Session["attbak"];
        AttendDs.selectAttBakRow [] brow = (AttendDs.selectAttBakRow[])bdt.Select("adate ='" + e.Day.Date.ToShortDateString() + "'");

         string s_1="";
         string s_2 = "";
        if (brow.Length > 0)
        {

            for (int i = 0; i < brow.Length; i++)
            {

                s_1 += "   <tr> <td> <span style=\"color: #000099\">備勤人員</span>：" + brow[i].NAME_C + "</td> </tr> " +
                    "  <tr>  <td><span style=\"color: #ff0000\">手機</span>：" + brow[i].GSM.Trim() + "</td> </tr> ";
            }
          //  string s_2 = 
            //  string s_3 = "   <tr> <td><span style=\"color: #ff6666\">留停人數</span>：" + _3.ToString() + "人</td> </tr> ";
            // string s_4 = "   <tr> <td><span style=\"color: #009900\">復職人數</span>：" + _4.ToString() + "人</td> </tr> ";
            //  string s_5 = "  <tr>  <td><span style=\"color: #666600\">停職人數</span>：" + _5.ToString() + "人</td></tr>  ";
            //string s_7 = "  <tr>  <td><span style=\"color: #666600\">試用期滿人數</span>：" + _7.ToString() + "人</td></tr>  ";




            string html = "";
            html = "<br><br><table width='100%' border='0' cellspacing='1' cellpadding='2' > " +

                s_1 + s_2 +

                " </table> ";
            Label lb = new Label();
            lb.Text = html;
            e.Cell.Controls.Add(lb);
        }
    }
    protected void Calendar1_SelectionChanged(object sender, EventArgs e)
    {

    }
    protected void Calendar1_VisibleMonthChanged(object sender, MonthChangedEventArgs e)
    {
        
        GetData(DateTime.Parse(e.NewDate.Year.ToString() + "/" + e.NewDate.Month + "/1"),
           DateTime.Parse(e.NewDate.Year.ToString() + "/" + e.NewDate.Month + "/" + DateTime.DaysInMonth(e.NewDate.Year, e.NewDate.Month).ToString()) );
    }
}
