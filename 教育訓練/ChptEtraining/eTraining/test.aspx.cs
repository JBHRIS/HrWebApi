using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class eTraining_test : System.Web.UI.Page
{
    private dcTrainingDataContext dcTraining = new dcTrainingDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        Label1.Text = Convert.ToDateTime("2012-02-14 19:52:06.333").ToString("HH:mm");
    }
    protected void RadGrid1_NeedDataSource(object sender , Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {

    }
    protected void LinqDataSource1_Selecting(object sender , LinqDataSourceSelectEventArgs e)
    {
        var q = (from c in dcTraining.trNotifyTemplate
                   join i in dcTraining.trNotifyTemplateDetail
                   on c.iAutoKey equals i.NotifyItem_iAutokey                 
        select new{c,i}).ToList();
        e.Result = q;
    }
    protected void RadButton1_Click(object sender, EventArgs e)
    {
        RadGrid2.Visible = true;
    }
}