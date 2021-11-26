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

public partial class Utli_CalendarTaskList : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Session["dt"] = null;
            setData(DateTime.Parse(DateTime.Now.Year.ToString() + "/" + DateTime.Now.Month + "/1"),
                  DateTime.Parse(DateTime.Now.Year.ToString() + "/" + DateTime.Now.Month + "/" + DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month).ToString()));           
        }
    }

    void setData(DateTime adate, DateTime ddate)
    {
        HRDs.rq_TaskDataTable rq_task = new HRDsTableAdapters.rq_TaskTableAdapter().GetData_task(adate, ddate);
        Session["dt"] = rq_task;
        gv_task.DataSource = rq_task;
        gv_task.DataBind();
        
    }
    protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
    {
        if (Session["dt"] == null)
            setData(DateTime.Parse(e.Day.Date.Year.ToString() + "/" + e.Day.Date.Month + "/1"),
                DateTime.Parse(e.Day.Date.Year.ToString() + "/" + e.Day.Date.Month + "/" + DateTime.DaysInMonth(e.Day.Date.Year, e.Day.Date.Month).ToString()));
        HRDs.rq_TaskDataTable dt = (HRDs.rq_TaskDataTable)Session["dt"];
        HRDs.rq_TaskRow[] row = (HRDs.rq_TaskRow [])dt.Select("expiredate='" + e.Day.Date.ToShortDateString() + "'");
        string _body = "";
        foreach (DataRow Row in row)
        {
            if (Row["type"].ToString().Trim() == "1")
            {
                //_body += "<tr> <td> <span style=\"color: red\"> " + Row["tasks"].ToString() + "</span></td> </tr> ";
                _body += "<tr> <td> <span style=\"color: red\"> <a href='#' onclick='ShowNewForm(\"" + Row["id"].ToString() + "\");'> " + Row["tasks"].ToString() + "</a></span></td> </tr> ";
            }
            else
            {
                _body += "<tr> <td> <span style=\"color: #000099\">  <a  href='#' onclick='xx(\"" + Row["tasks"].ToString() + "\");'>" + Row["tasks"].ToString() + "</a></span></td> </tr> ";
            }
        }
        string html = "";
        html = "<br><br><table width='100%' border='0' cellspacing='1' cellpadding='2' > " +

            _body +

            " </table> ";
        Label lb = new Label();
        lb.Text = html;
        e.Cell.Controls.Add(lb);
    }
    protected void Calendar1_SelectionChanged(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 1;
        if (Session["dt"] == null)
            setData(DateTime.Parse(Calendar1.SelectedDate.Year.ToString() + "/" + Calendar1.SelectedDate.Month + "/1"),
                DateTime.Parse(Calendar1.SelectedDate.Year.ToString() + "/" + Calendar1.SelectedDate.Month + "/" + DateTime.DaysInMonth(Calendar1.SelectedDate.Year, Calendar1.SelectedDate.Month).ToString()));

        HRDs.rq_TaskDataTable dt = (HRDs.rq_TaskDataTable)Session["dt"];
        
        DataView dv = dt.DefaultView;
        dv.RowFilter = "Expiredate ='" + Calendar1.SelectedDate.ToShortDateString() + "'";

        gv_task.DataSource = dv;
        gv_task.DataBind();     

        Calendar1.SelectedDate = DateTime.Parse("2099/02/02");       
    }
    protected void Calendar1_VisibleMonthChanged(object sender, MonthChangedEventArgs e)
    {
        setData(DateTime.Parse(e.NewDate.Year.ToString() + "/" + e.NewDate.Month + "/1"),
              DateTime.Parse(e.NewDate.Year.ToString() + "/" + e.NewDate.Month + "/" + DateTime.DaysInMonth(e.NewDate.Year, e.NewDate.Month).ToString()));
        
    }
    protected void Back_Button_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 0;
    }
    
    protected void gv_task_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string aa = e.Row.Cells[0].Text.Trim();
            string aa1 = e.Row.Cells[1].Text.Trim();
            string aa2 = e.Row.Cells[2].Text.Trim();
            string aa3 = e.Row.Cells[3].Text.Trim();
            string aa4 = e.Row.Cells[4].Text.Trim();
            string aa5 = e.Row.Cells[5].Text.Trim();
            if (e.Row.Cells[6].Text.Trim()=="1")
                e.Row.Cells[6].Text = "公司";
            else
                e.Row.Cells[6].Text = "個人";
        }
    }

    protected void Link_task_Click(object sender, EventArgs e)
    {

    }
    protected void gv_task_SelectedIndexChanged(object sender, EventArgs e)
    {
        string link = "ShowTask.aspx?keyid=" + gv_task.SelectedDataKey.Values[0].ToString();
        string script = "var sFeatures = 'dialogWidth:500px;dialogHeight:500px;center:yes;help:no;resizable:no;scroll:no;status:no';" +
            "window.showModalDialog('../utli/ShowTask.aspx?url=" + link + "', '', sFeatures) ; ";
        if (!Page.ClientScript.IsStartupScriptRegistered(typeof(string), "GridView"))
            Page.ClientScript.RegisterStartupScript(typeof(string), "GridView", script, true);
        //Response.Write(string.Format("<script>window.open('{0}')</script>", "../utli/ShowTask.aspx"));
    }
}
