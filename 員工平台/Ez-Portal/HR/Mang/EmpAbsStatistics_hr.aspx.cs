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
using JBHRModel;

using System.Collections.Generic;
using System.Linq;
using Telerik.Web.UI;
using Newtonsoft.Json;

public partial class HR_Mang_EmpAbsStatistics_hr:JBWebPage
{
    protected void Page_Load(object sender , EventArgs e)
    {
        if ( !IsPostBack )
        {
            var a = ucEmpDeptQS as IEmpDeptQS;
            a.InitUC_Dept(EnumUC_QS_InitType.HR);
//            a.InitUC_Cat(1);
            Session[SessionName] = null;

            RadTabStrip1.SelectedIndex = 0;
            mp.SelectedIndex = 0;

            SiteHelper sh = new SiteHelper();
            DateTime bDate,eDate;
            sh.SetDateRangeForThisYear(out bDate , out eDate);
            dpDtlB.SelectedDate = bDate;
            dpDtlE.SelectedDate = eDate;
        }
    }


    protected void ExportExcel_Click(object sender , EventArgs e)
    {
        if ( Session[SessionName] != null )
            JB.WebModules.Data.Export.Excel.WebResponseExcel(this , gv , (List<SpecialLeaveOfYearDto>) Session[SessionName] , SessionName);
        else
            JB.WebModules.Message.Show("無資料可匯出！");
    }

    void GetLeaveData()
    {
        var a = ucEmpDeptQS as IEmpDeptQS;
        var obj = a.GetSelectedObj();

        if ( obj == null )
        {
            Show("Select Unit or Team Member");
            return;
        }

        var nobrList = new List<string>();
        var deptList = new List<string>();

        if ( obj.SelectedType == EnumUC_QS_SelectedType.Dept && !obj.IsSingleDept )
        {
            foreach ( var item in obj.DeptList )
            {
                deptList.Add(item);
            }
        }

        JbFlow.ServiceClient sc = new JbFlow.ServiceClient();
        //state 1 為在途、2為駁回、3核准

        JbFlow.FlowAbsTable[] resultList = null;

        nobrList.Add(obj.Key);
        //1是請假
        if ( obj.SelectedType == EnumUC_QS_SelectedType.Emp )
            resultList = sc.GetFlowAbs(dpDtlB.SelectedDate.Value , dpDtlE.SelectedDate.Value , "1" , null , nobrList.ToArray() , new string[] { "1" , "2" , "3" }).OrderByDescending(p => p.DateB).ToArray();
        else
            resultList = sc.GetFlowAbs(dpDtlB.SelectedDate.Value , dpDtlE.SelectedDate.Value , "1" , deptList.ToArray() , null , new string[] { "1" , "2" , "3" }).OrderByDescending(p => p.DateB).ToArray();

        //sCat 0是全部，1請假，2公出

        Session[SessionName] = resultList;
    }
    protected void gv_PageIndexChanging(object sender , GridViewPageEventArgs e)
    {
        if ( Session[SessionName] != null )
        {
            gv.PageIndex = e.NewPageIndex;
            gv.DataSource = (List<SpecialLeaveOfYearDto>) Session[SessionName];
            gv.DataBind();
        }
        else
        {
            JB.WebModules.Message.Show("網頁逾時，請重新查詢！");
        }
    }


    protected void gvLeave_ItemDataBound(object sender , GridItemEventArgs e)
    {
        if ( e.Item is GridDataItem )
        {
            GridDataItem item = e.Item as GridDataItem;
            if ( item["State"].Text.Equals("1") )
            {
                item["State"].Text = "Ongoing";
            }
            else if ( item["State"].Text.Equals("2") )
            {
                item["State"].Text = "Rejected";
            }
            else if ( item["State"].Text.Equals("3") )
            {
                item["State"].Text = "Approved";
            }
        }
    }
    protected void gvLeave_NeedDataSource(object sender , GridNeedDataSourceEventArgs e)
    {
        if ( e.RebindReason == GridRebindReason.ExplicitRebind )
        {
            GetLeaveData();
        }
        if ( Session[SessionName] != null )
        {
            var resultList = Session[SessionName] as JbFlow.FlowAbsTable[];
            gvLeave.DataSource = resultList;
        }
    }
    protected void gvLeave_ItemCommand(object sender , GridCommandEventArgs e)
    {
        GridDataItem item = e.Item as GridDataItem;
        if ( e.CommandName.Equals("cmdViewUrl") )
        {            
            if ( item["ViewUrl"].Text.Equals(@"&nbsp;") )
                return;
            else
            {
                win.NavigateUrl = item["ViewUrl"].Text;
                win.VisibleOnPageLoad = true;
            }
        }
        else if ( e.CommandName.Equals("cmdDel") )
        {
            List<int> pidList = new List<int>();
            pidList.Add(Convert.ToInt32(item["ProcessID"].Text));
            JbFlow.ServiceClient sc = new JbFlow.ServiceClient();
            var arrProcessID = sc.SetCancelForm(JbFlow.FormCategroy.Abs , pidList.ToArray() , true);
            gvLeave.Rebind();
        }
    }
    protected void Button2_Click(object sender , EventArgs e)
    {
        gvLeave.Rebind();
    }
}
