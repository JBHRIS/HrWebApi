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
public partial class Mang_EmpAttendSelect_hr : JBWebPage {
    protected void Page_Load(object sender, EventArgs e)
    {
        ucEmpDeptQS.sHandler += new Templet_EmpDeptQS.SelectedEventHandler(UC_SelectObj);
        if (!IsPostBack)
        {
            Session["rv_attend"] = null;
            try
            {
                var a = ucEmpDeptQS as IEmpDeptQS;
                a.InitUC_Dept(EnumUC_QS_InitType.HR);
                a.InitUC_Cat(0);

                //GridView1.DataBind();
                //GridView1.SelectedIndex = 0;                
                //lb_nobr.Text = GridView1.SelectedValue.ToString();
                //((Label)RoteList1.FindControl("lb_nobr")).Text = lb_nobr.Text;
                //Session["selected_nobr"] = lb_nobr.Text;
                //((ICU)RoteList1).bindGrid();

            }
            catch { }
        }
    }

    private void UC_SelectObj(UC_QS_SelectedObj obj)
    {
        bindRoteList(obj.Key);
    }


    private void bindRoteList(string nobr)
    {
        Session["rv_attend"] = null;
        ((Label)RoteList1.FindControl("lb_nobr")).Text = nobr;
        Session["selected_nobr"] = nobr;
        ((ICU)RoteList1).bindGrid();
    }
}
