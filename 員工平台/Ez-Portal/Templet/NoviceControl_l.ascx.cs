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
public partial class Templet_NoviceControl_l : JBUserControl
{
    private DEPT_REPO deptRepo = new DEPT_REPO();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string dept = JbUser.DepartmentCode;
            lb_dept.Text = dept;
            GetData();
        }
    }

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        GetData();
    }

    void GetData()
    {
        string date_b = Convert.ToString(DateTime.Now.Year) +"/"+ Convert.ToString(DateTime.Now.Month) + "/01";
        string date_e = DateTime.Parse(date_b).AddMonths(1).AddDays(-1).ToString("yyyy/MM/dd");

        List<DEPT> depts = deptRepo.GetChildByID(lb_dept.Text);

        HRDsTableAdapters.rv_noviceTableAdapter rv_novice = new HRDsTableAdapters.rv_noviceTableAdapter();
        HRDs.rv_noviceDataTable rv_noviceDS = new HRDs.rv_noviceDataTable();
        //for (int i = 0; i < depts.Count; i++)
        //{
        //    rv_noviceDS.Merge(rv_novice.GetData_rv_novice(DateTime.Parse(date_b),DateTime.Parse(date_e),depts[i].D_NO));
        //}

        rv_noviceDS.Merge(rv_novice.GetDataByLeNotDet(DateTime.Parse(date_b), DateTime.Parse(date_e)));

        GridView1.DataSource = rv_noviceDS;
        GridView1.DataBind();

        rv_noviceDS.Select("ADATE > '"+DateTime.Now.AddMonths(-1).ToShortDateString()+"'");

        DataList1.DataSource = rv_noviceDS;
     DataList1.DataBind();

    }

    protected void DataList1_DataBinding(object sender, EventArgs e)
    {

     
    }
    protected void DataList1_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        Image eim = (Image)e.Item.FindControl("Image1");
        string nobr = eim.AlternateText;
        SiteHelper siteHelper = new SiteHelper();
        eim.ImageUrl = siteHelper.GetEmpPhotoPath(nobr);
        //eim.ImageUrl = "~/Utli/ShowEmpImage.aspx?Photo=" + nobr.Trim() + ".jpg";
    }
}
