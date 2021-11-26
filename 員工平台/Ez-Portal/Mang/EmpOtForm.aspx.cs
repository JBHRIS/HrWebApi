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
using BL;

public partial class Mang_EmpOtForm : JBWebPage
{
    protected void Page_Load(object sender , EventArgs e)
    {
        if ( !IsPostBack )
        {
            var a = EmpDeptQS1 as IEmpDeptQS;
            a.InitUC_Dept(EnumUC_QS_InitType.Manager);
        }
    }



    void GetData()
    {
        var a = EmpDeptQS1 as IEmpDeptQS;
        var obj = a.GetSelectedObj();

        if (obj == null)
        {
            Show("Select Unit or Team Member");
            return;
        }

        JbFlow.ServiceClient sc = new JbFlow.ServiceClient();
        List<string> nobrArr = new List<string>();
        List<string> deptArr = new List<string>();

        List<JbFlow.FlowOtTable> resultList = new List<JbFlow.FlowOtTable>();
        if (obj.SelectedType == EnumUC_QS_SelectedType.Emp)
        {
            nobrArr.Add(obj.Key);
            resultList.AddRange(sc.GetFlowOt(dpDtlB.SelectedDate.Value, dpDtlE.SelectedDate.Value, deptArr.ToArray(), nobrArr.ToArray(), new string[] { "1", "2", "3" }));
        }
        else
        {
            deptArr.AddRange(obj.DeptList);
            resultList.AddRange(sc.GetFlowOt(dpDtlB.SelectedDate.Value, dpDtlE.SelectedDate.Value, deptArr.ToArray(), nobrArr.ToArray(), new string[] { "1", "2", "3" }));

        }

        Session[SessionName] = resultList;
    }
    protected void cbxYear_SelectedIndexChanged(object sender , RadComboBoxSelectedIndexChangedEventArgs e)
    {
        GetData();
    }
    protected void GridView2_RowDataBound(object sender , GridViewRowEventArgs e)
    {

    }
    protected void Button2_Click(object sender , EventArgs e)
    {
        GetData();
    }

  }
