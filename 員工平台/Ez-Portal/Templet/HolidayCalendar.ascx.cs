using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL;

public partial class Templet_HolidayCalendar : JUserControl
{
    private HOLI_REPO holiRepo = new HOLI_REPO();
    private List<HOLI> holiList = null;

    protected void Page_Load(object sender, EventArgs e)
    {
        cld.CultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;
        if (!IsPostBack)
        {
            cld.SelectedDate = DateTime.Now.Date;
        }
    }
    protected void cld_PreRender(object sender, EventArgs e)
    {
        holiList = holiRepo.GetByDateRange_Dlo(cld.CalendarView.ViewStartDate, cld.CalendarView.ViewEndDate, Juser.HoliCode);
    }

    protected void cld_DayRender(object sender, Telerik.Web.UI.Calendar.DayRenderEventArgs e)
    {
        var hObj = (from c in holiList where e.Day.Date == c.H_DATE select c).FirstOrDefault();
        if (hObj != null)
        {
            //e.Cell.BackColor = Color.FromArgb(Convert.ToInt32(hObj.OTHCODE1.OTHCOLOR));
            //e.Cell.Style["background-color"] = @"#"+SiteHelper.ToRgb(Convert.ToInt32(hObj.OTHCODE1.OTHCOLOR));

            ////彈性假的顯示方式A、國定假日C
            //if (hObj.OTHCODE.Equals("A") || hObj.OTHCODE.Equals("C"))
            //{
            //    e.Cell.Style["background-color"] = @"#" + SiteHelper.ToRgb(Convert.ToInt32(hObj.OTHCODE1.OTHCOLOR));
            //}
            //else
            //{
            Label lb = new Label();
            e.Cell.Controls.Add(lb);
            lb.Text = e.Day.Date.Day.ToString();
            lb.ForeColor = System.Drawing.ColorTranslator.FromHtml(@"#" + SiteHelper.ToRgb(Convert.ToInt32(hObj.OTHCODE1.OTHCOLOR)));
            //}
        }
    }
}