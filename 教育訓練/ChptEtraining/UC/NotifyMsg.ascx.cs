using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using Telerik.Web.UI;
using Repo;
public partial class UC_NotifyMsg : JUserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

        }
    }



    protected void gv_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
    {
        NotifyMsgFacade nmf = new NotifyMsgFacade();
        DateTime bDate = DateTime.Now.Date;
        DateTime eDate = bDate.AddDays(1);
        gv.DataSource = nmf.GetMsg(bDate, eDate, Juser.Nobr, NotifyTargetTypeEnum.Emp).OrderByDescending(p=>p.NotifyAdate);
    }
}