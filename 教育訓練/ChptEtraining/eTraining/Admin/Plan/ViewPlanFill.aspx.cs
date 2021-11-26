using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

public partial class eTraining_Admin_Plan_ViewPlanFill : System.Web.UI.Page
{
    dcTrainingDataContext dcTrain = new dcTrainingDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            SiteHelper util = new SiteHelper();
            util.setDeptTv(tvDept);
            tvDept.ExpandAllNodes();

            PlanHelper PlanHelper = new PlanHelper();
            PlanHelper.setCbYear(cbYear);
        }
        this.Title = "檢視需求調查表";
    }
    protected void RadButton1_Click(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {

    }

    protected void tvDept_NodeClick(object sender, RadTreeNodeEventArgs e)
    {
        lblDept.Text = tvDept.SelectedValue;

        gvDetail.Visible = false;
        btnBack.Visible = false;
        btnDetail.Visible = true;
        gvTotal.Visible = true;

        gvDetail.Rebind();
        gvTotal.Rebind();

        //抓取部門主管
        var mang = (from b in dcTrain.BASE
                    join t in dcTrain.BASETTS on b.NOBR equals t.NOBR
                    where DateTime.Now.Date >= t.ADATE && DateTime.Now.Date <= t.DDATE &&
                    new string[] { "1", "4", "6" }.Contains(t.TTSCODE) &&
                    t.DEPT == lblDept.Text &&
                    t.MANG == true
                    select b.NAME_C).FirstOrDefault();
        if (mang != null)
            lblMang.Text = "部門主管:" + mang;
        else
            lblMang.Text = "查無此部門主管";


    }
    protected void RadButton1_Click1(object sender, EventArgs e)
    {
        gvDetail.Visible = true;
        btnBack.Visible = true;
        btnDetail.Visible = false;
        gvTotal.Visible = false;
    }
    protected void RadButton2_Click(object sender, EventArgs e)
    {
        gvDetail.Visible = false;
        btnBack.Visible = false;
        btnDetail.Visible = true;
        gvTotal.Visible = true;
    }
}