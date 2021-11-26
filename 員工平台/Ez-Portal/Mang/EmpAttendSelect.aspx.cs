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
using BL;
using JBHRModel;
public partial class Mang_EmpAttendSelect : JBWebPage {
    protected void Page_Load(object sender, EventArgs e) {
        ucEmpDeptQS.sHandler += new Templet_EmpDeptQS.SelectedEventHandler(UC_SelectObj);
        if (!IsPostBack) 
        {
            var a = ucEmpDeptQS as IEmpDeptQS;
            a.InitUC_Dept(EnumUC_QS_InitType.Manager);
            a.InitUC_Cat(0);

            Session[SessionName] = null;

            //Label lblManagerChangeShift =  RoteList1.FindControl("lblManagerChangeShift") as Label;
            //lblManagerChangeShift.Text = "1";
        }
    }

    private void UC_SelectObj(UC_QS_SelectedObj obj)
    {
        if ( obj == null )
        {
            Show("Select Unit or Team Member");
            return;
        }

        if ( obj.SelectedType == EnumUC_QS_SelectedType.Emp )
        {
            Label lb = (Label) RoteList1.FindControl("lb_nobr");
            lb.Text = obj.Key;
            ((ICU) RoteList1).bindGrid();
        }
    }


    protected void Button1_Click(object sender, EventArgs e) 
    {
        GetData();  
    }



    int t1 = 0;
    int t2 = 0;
    int t3 = 0;

    void GetData()
    {
        var a = ucEmpDeptQS as IEmpDeptQS;
        var obj = a.GetSelectedObj();

        if (obj == null)
        {
            Show("Select Unit or Team Member");
            return;
        }

        if (obj.SelectedType == EnumUC_QS_SelectedType.Emp)
        {
            Label lb = (Label)RoteList1.FindControl("lb_nobr");
            lb.Text = obj.Key;
            ((ICU)RoteList1).bindGrid();
        }
    }
    protected void Button4_Click(object sender, EventArgs e)
    {
        //if (Panel1.Visible)
        //{
        //    Panel1.Visible = false;
        //    Button4.Text = "顯示部門";
        //}
        //else {
        //    Panel1.Visible = true;
        //    Button4.Text = "隱藏部門";
        //}

    }
    protected void Calendar1_DataBinding(object sender, EventArgs e)
    {

       

    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //if (e.Row.RowType == DataControlRowType.DataRow)
        //{
        //    if (Juser.ManagerExeptEmpList.Contains(GridView1.DataKeys[e.Row.RowIndex].Values[0].ToString()))
        //        e.Row.Visible = false;
        //    else
        //        e.Row.Visible = true;
             
        //}
    }
}
