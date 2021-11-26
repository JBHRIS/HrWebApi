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

public partial class HR_SelectUpBase : JBWebPage
{
    private UpBaseRecord_REPO upBaseRecordRepo = new UpBaseRecord_REPO();
    protected void Page_Load(object sender, EventArgs e)
    {                       
        if (!IsPostBack)
        {
            tbSerchKey.Attributes.Add("OnFocus", "this.value='';");    
            adate.SelectedDate = DateTime.Parse(DateTime.Now.Year.ToString() + "/" + DateTime.Now.Month + "/1");
            ddate.SelectedDate = DateTime.Parse(DateTime.Now.Year.ToString() + "/" + DateTime.Now.Month + "/" + DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month).ToString());
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string nobr=tbSerchKey.Text.Trim();
        if (nobr.Length == 0)
        {
            GridView1.DataSourceID = "ObjectDataSource1";
            GridView1.DataBind();
        }
        else
        {
            GridView1.DataSource = upBaseRecordRepo.GetByNobr_DateRange(nobr, adate.SelectedDate.Value, ddate.SelectedDate.Value);
            GridView1.DataSourceID = "";
            GridView1.DataBind();
        }

    }
}
