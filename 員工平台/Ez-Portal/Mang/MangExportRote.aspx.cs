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
using System.Text;
public partial class Mang_MangSelectOt:JBWebPage
{
    protected void Page_Load(object sender , EventArgs e)
    {
        ucEmpDeptQS.sHandler += new Templet_EmpDeptQS.SelectedEventHandler(UC_SelectObj);

        if ( !IsPostBack )
        {
            var a = ucEmpDeptQS as IEmpDeptQS;
            a.InitUC_Dept(EnumUC_QS_InitType.Manager);

            a.InitUC_Cat(1,true);
            
            //IUC uc = DeptUserShift1 as IUC;

            //if ( JbUser.DepartmentCode != null )
            //    uc.SetValue(JbUser.DepartmentCode);
        }
    }

    public void UC_SelectObj(UC_QS_SelectedObj obj)
    {
        //IUC uc = DeptUserShift1 as IUC;
        
        //StringBuilder sb = new StringBuilder();

        //foreach (var d in obj.DeptList)
        //{
        //    sb.Append(d);
        //    sb.Append(",");
        //}

        //uc.SetValue(sb.ToString());
    }

    public void SetDeptValue()
    {
        var a = ucEmpDeptQS as IEmpDeptQS;
        var obj=a.GetSelectedObj();
        IUC uc = DeptUserShift1 as IUC;

        StringBuilder sb = new StringBuilder();

        foreach (var d in obj.DeptList)
        {
            sb.Append(d);
            sb.Append(",");
        }

        uc.SetValue(sb.ToString());
    }
}
