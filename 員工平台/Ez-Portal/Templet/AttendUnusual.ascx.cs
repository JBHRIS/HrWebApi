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
using System.Linq;
using BL;

public partial class Templet_AttendUnusual : JBUserControl
{
    private ATTEND_REPO attendRepo = new ATTEND_REPO();
    const string SESSION_TABLE = "AttendUnusualUC";
    private BASETTS_REPO basettsRepo = new BASETTS_REPO();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Session[SESSION_TABLE] = null;

            SiteHelper siteHelper = new SiteHelper();
            DateTime startDatetime, endDatetime;
            siteHelper.SetDateRange(out startDatetime, out endDatetime, DateTime.Now.Date, JbUser.SalaDr);
            startRdp.SelectedDate = startDatetime;
            endRdp.SelectedDate = endDatetime;

            bindData();
        }
    }

    private void bindData()
    {
        AttendDs.AttendUnusualDataTable dt = attendRepo.GetAttendUnusualDT(startRdp.SelectedDate.Value, endRdp.SelectedDate.Value, 1);
        AttendDs.AttendUnusualDataTable dt2 = new AttendDs.AttendUnusualDataTable();
        AttendDs.AttendUnusualRow[] rows = null;

        //if (basettsRepo.IsManager(this.Page.User.Identity.Name))
        if (this.Page.User.IsInRole("manage"))
        {
            TreeView tv = new TreeView();
            SiteHelper.SetDeptTreeByDeptDeptSupervisor(tv, JbUser.NOBR);

            List<TreeNode> nodeList = SiteHelper.GetTreeViewAllNodes(tv);

            var nodes = (from c in nodeList select c.Value).Distinct();

            foreach (String deptCode in nodes)
            {
                rows = dt.Select("D_NO='" + deptCode + "'") as AttendDs.AttendUnusualRow[];
                foreach (var row in rows)
                    dt2.ImportRow(row);
            }
        }
        else
        {
            rows = dt.Select("nobr='" + this.Page.User.Identity.Name + "'") as AttendDs.AttendUnusualRow[];
            foreach (var row in rows)
                dt2.ImportRow(row);
        }

        dt2.DefaultView.Sort = "ADATE desc";
        Session[SESSION_TABLE] = dt2;
        gv.DataSource = dt2;
        gv.DataBind();

    }

    protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        if (Session[SESSION_TABLE] != null)
        {
            gv.PageIndex = e.NewPageIndex;
            gv.DataSource = (AttendDs.AttendUnusualDataTable)Session[SESSION_TABLE];
            gv.DataBind();
        }
        else
        {
            JB.WebModules.Message.Show("網頁逾時，請重新查詢！");
        }
    }
    protected void btnExportExcel_Click(object sender, EventArgs e)
    {
        if (Session[SESSION_TABLE] != null)
            JB.WebModules.Data.Export.Excel.WebResponseExcel(this.Page, gv, (AttendDs.AttendUnusualDataTable)Session[SESSION_TABLE], SESSION_TABLE);
        else
            JB.WebModules.Message.Show("無資料可匯出！");
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        bindData();
    }
    protected void gv_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Boolean b;
            if (Boolean.TryParse(e.Row.Cells[6].Text, out b))
            {
                if (b)
                    e.Row.Cells[6].Text = "Y";
                else
                    e.Row.Cells[6].Text = "N";
            }
        }
    }
}
