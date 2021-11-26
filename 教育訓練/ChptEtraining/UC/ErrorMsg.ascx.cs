using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using Telerik.Web.UI;

public partial class UC_ErrorMsg : JUserControl
{
    private dcTrainingDataContext dcTraining = new dcTrainingDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    private string  getQuery()
    {        
        //CustomIdentity identity = (CustomIdentity)Context.User.Identity;
        sdsGv.SelectParameters.Clear();
        String sql_str = @"select * from trErrorNotify where TargetNobr = '" + Page.User.Identity.Name +"'";
        sql_str = sql_str + " and dCompletedDate is null";
              
        //SiteHelper siteHelper = new SiteHelper();
        ArrayList arrList = Juser.RoleList;
            //siteHelper.TransRoles(identity.UserRole.ToString());

        if (arrList.Count > 0)
        {
            sql_str = sql_str + @" union select * from trErrorNotify where dCompletedDate is null";

            if ( arrList.Count > 0 )
                sql_str = sql_str + " and (";

            for (int i = 0; i < arrList.Count; i++)
            {
                sql_str = sql_str + "TargetRole = " + arrList[i].ToString();

                if (i != arrList.Count - 1)
                {
                    sql_str = sql_str + " or ";
                }
            }

            if(arrList.Count >0)
                sql_str = sql_str + ")";
        }

        sql_str = sql_str + " order by NotifyDate desc";

        return sql_str;
        //sdsGv.SelectCommand = sql_str;
    }
    protected void sdsGv_Selecting(object sender , SqlDataSourceSelectingEventArgs e)
    {

        e.Command.CommandText = getQuery();
    }
    protected void gv_ItemCommand(object sender , Telerik.Web.UI.GridCommandEventArgs e)
    {
        if ( e.CommandName == "Done" )
        {
            GridDataItem item = (GridDataItem) e.Item;
            int autoKey = Convert.ToInt32(item.OwnerTableView.DataKeyValues[item.ItemIndex]["iAutoKey"].ToString());

            var data = (from c in dcTraining.trErrorNotify
                        where c.iAutoKey == autoKey
                        select c).FirstOrDefault();

            if ( data != null )
            {
                data.dCompletedDate = DateTime.Now;
                data.sCompletedMan = Page.User.Identity.Name;
                dcTraining.SubmitChanges();
                gv.Rebind();
            }
        }
    }
}