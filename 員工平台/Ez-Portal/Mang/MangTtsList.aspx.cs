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

public partial class Mang_MangTtsList : JBWebPage {
    protected void Page_Load(object sender, EventArgs e) 
    {
        ucEmpDeptQS.sHandler += new Templet_EmpDeptQS.SelectedEventHandler(UC_SelectObj);

        if ( !IsPostBack )
        {
            var a = ucEmpDeptQS as IEmpDeptQS;
            a.InitUC_Dept(EnumUC_QS_InitType.Manager);
            a.InitUC_Cat(1);
            a.DisplayPushBtn(true);
        }
    }
    private void UC_SelectObj(UC_QS_SelectedObj obj)
    {
        if (obj == null)
        {
            Show("Select Unit or Team Member");
            return;
        }

        SiteHelper sh = new SiteHelper();
        setDept(sh.ListStr2Str(obj.DeptList));
    }

    private void setDept(string value)
    {
        //lb_dept.Text = value;
        IUC iuc = (IUC) calendarListCustomDept1;
        iuc.SetValue(value);
        iuc.BindData();
    }
}
