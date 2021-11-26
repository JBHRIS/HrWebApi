using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Telerik.Web.UI;

public partial class UC_HRNotify : System.Web.UI.UserControl
{
    private dcTrainingDataContext dcTraining = new dcTrainingDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {    
        //取日期就好
        lblMonth.Text = DateTime.Now.AddMonths(1).ToString().Substring(0,9);       
    }
    protected void btnDone_Click(object sender, EventArgs e)
    {

    }
    protected void gvNotify_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
    {
        if (e.CommandName == "Done")
        {
            GridDataItem item = (GridDataItem)e.Item;
            int autoKey = Convert.ToInt32(item.OwnerTableView.DataKeyValues[item.ItemIndex]["iAutoKey"].ToString());

            var data = (from c in dcTraining.trClassNotify
                        where c.iAutoKey == autoKey
                        select c).FirstOrDefault();

            if (data != null)
            {
                data.dCompletedDate = DateTime.Now;
                data.sCompletedMan = Page.User.Identity.Name;
                dcTraining.SubmitChanges();
                gvNotify.Rebind();
            }
        }
    }
}