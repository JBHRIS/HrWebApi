﻿using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class Employee_EmpBaseByUser : JBUserControl ,ICU{
    protected void Page_Load(object sender, EventArgs e) {
        
        //if(!IsPostBack)
        //lb_nobr.Text = JbUser.NOBR;


        GridView gv = (GridView)this.Parent.FindControl("GridView1");
        if (gv != null && gv.SelectedValue!=null) {
             
         //   lb_nobr.Text = gv.SelectedValue;
        }
    }

    #region ICU 成員

    public void bindGrid() {
        Label lb = (Label)AccountPicture1.FindControl("lb_nobr");
        lb.Text = lb_nobr.Text;
        ((ICU)AccountPicture1).bindGrid();
    }

    #endregion
}
