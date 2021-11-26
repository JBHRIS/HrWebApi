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
 
using System.Collections.Generic;
using Newtonsoft.Json;
using Telerik.Web.UI;
public partial class Employee_EmpAbsStatistics : JBWebPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            initCbxYear();                
            GetData();
        }
    }

    private void initCbxYear()
    {
        RadComboBoxItem item = new RadComboBoxItem();
        item.Text = DateTime.Now.Year.ToString();
        item.Value = DateTime.Now.Year.ToString();
        item.Selected = true;
        cbxYear.Items.Add(item);

        RadComboBoxItem item1 = new RadComboBoxItem();
        item1.Text = DateTime.Now.AddYears(-1).Year.ToString();
        item1.Value = DateTime.Now.AddYears(-1).Year.ToString();
        cbxYear.Items.Add(item1);
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        GetData();
    }
    protected void ExportExcel_Click(object sender, EventArgs e)
    {
        if (Session["SessionName"] != null)
            JB.WebModules.Data.Export.Excel.WebResponseExcel(this, gv, (DataTable)Session["SessionName"], SessionName);
        else
            JB.WebModules.Message.Show("無資料可匯出！");
    }


    void GetData()
    {
       // JbFlow.ServiceClient sc = new JbFlow.ServiceClient();
       // string[] nobrArr =new string[]{Juser.Nobr};

       //var list= sc.GetYearAbsenceDetail(nobrArr, new DateTime(Convert.ToInt32(cbxYear.SelectedValue), 1, 1),
       //    new DateTime(Convert.ToInt32(cbxYear.SelectedValue), 12, 31), DateTime.Now.Date);

       //Session[SessionName] = list;
       //gv.DataSource = list;
       //gv.DataBind();
    }
    protected void cbxYear_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        GetData();
    }
}
