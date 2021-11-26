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
using System.Linq; 
using System.Collections.Generic;
using Telerik.Web.UI;
public partial class Mang_EmpAttendList : JBWebPage
{
    private OT_REPO otRepo = new OT_REPO();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            SiteHelper siteHelper = new SiteHelper();
            DateTime startDatetime , endDatetime;

            siteHelper.SetDateRangeForThisMonth(out startDatetime , out endDatetime);
            rdpBdate.SelectedDate = startDatetime;
            rdpEdate.SelectedDate = endDatetime;

            var a = ucEmpDeptQS as IEmpDeptQS;
            a.InitUC_Dept(EnumUC_QS_InitType.Manager);
            Session[SessionName] = null;


        }
    }
 


    protected void Button1_Click(object sender, EventArgs e)
    {
        gv.Rebind();
    }
    protected void ExportExcel_Click(object sender, EventArgs e)
    {
        gv.ExportSettings.ExportOnlyData = false;
        gv.ExportSettings.HideStructureColumns = true;
        gv.ExportSettings.IgnorePaging = true;
        gv.ExportSettings.OpenInNewWindow = false;
        gv.ExportSettings.FileName = "Shift";
        gv.MasterTableView.ExportToExcel();
    }


    protected void gv_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            bool b;
                //= Convert.ToBoolean(e.Row.Cells[11].Text);
            //if (b)
            //    e.Row.Cells[11].Text = "Y";
            //else
            //    e.Row.Cells[11].Text = "N";

            if (Convert.ToInt32(e.Row.Cells[10].Text) == 0)
                e.Row.Cells[10].Text = "";

            if (Convert.ToInt32(e.Row.Cells[11].Text) == 0)
                e.Row.Cells[11].Text = "";

            if (Convert.ToInt32(e.Row.Cells[13].Text) == 0)
                e.Row.Cells[13].Text = "";

            //曠職
            b = Convert.ToBoolean(e.Row.Cells[12].Text);
            if (b)
                e.Row.Cells[12].Text = "Y";
            else
                e.Row.Cells[12].Text = "";
                //e.Row.Cells[12].Text = "N";

            //b = Convert.ToBoolean(e.Row.Cells[13].Text);
            //if (b)
            //    e.Row.Cells[13].Text = "Y";
            //else
            //    e.Row.Cells[13].Text = "N";

            //b = Convert.ToBoolean(e.Row.Cells[10].Text);
            //if (b)
            //    e.Row.Cells[10].Text = "Y";
            //else
            //    e.Row.Cells[10].Text = "N";

            //string str = "vnd.ms-excel.numberformat:@";
            //e.Row.Cells[2].Attributes.Add("style", str);
            //e.Row.Cells[6].Attributes.Add("style", str);
            //e.Row.Cells[7].Attributes.Add("style", str);
            //e.Row.Cells[8].Attributes.Add("style", str);

        }
    }

    protected void gv_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        ATTEND_REPO attendRepo = new ATTEND_REPO();
        List<EmpAttendList> list = new List<EmpAttendList>();
        if (e.RebindReason == Telerik.Web.UI.GridRebindReason.ExplicitRebind)
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
                list.AddRange(attendRepo.GetAttendListByDateRangeNobr(obj.Key, rdpBdate.SelectedDate.Value, rdpEdate.SelectedDate.Value));
            }
            else if (obj.SelectedType == EnumUC_QS_SelectedType.Dept && !obj.IsSingleDept)
            {
                foreach (var d in obj.DeptList)
                {
                    list.AddRange(attendRepo.GetAttendListByDateRangeDept(d, rdpBdate.SelectedDate.Value, rdpEdate.SelectedDate.Value));
                }
            }

            list.RemoveAll(p => Juser.ManagerExeptEmpList.Contains(p.Nobr));
            Session[SessionName] = list;
        }
        else
        {
            
            list=Session[SessionName] as List<EmpAttendList>;
        }

        gv.DataSource = list;
    }
    protected void gv_ItemDataBound(object sender, Telerik.Web.UI.GridItemEventArgs e)
    {
        if (e.Item is GridDataItem) 
        {
            GridDataItem item = e.Item as GridDataItem;
            var b = Convert.ToBoolean(item["IsAbsent"].Text);
            if(b)
            {
                item["IsAbsent"].Text ="Y";
            }
            else
            {
                item["IsAbsent"].Text = "";
            }
        //if (Convert.ToInt32(e.Row.Cells[10].Text) == 0)
        //    e.Row.Cells[10].Text = "";

        //if (Convert.ToInt32(e.Row.Cells[11].Text) == 0)
        //    e.Row.Cells[11].Text = "";

        //if (Convert.ToInt32(e.Row.Cells[13].Text) == 0)
        //    e.Row.Cells[13].Text = "";

        //曠職
        //b = Convert.ToBoolean(e.Row.Cells[12].Text);
        //if (b)
        //    e.Row.Cells[12].Text = "Y";
        //else
        //    e.Row.Cells[12].Text = "";

        }
    }
}
