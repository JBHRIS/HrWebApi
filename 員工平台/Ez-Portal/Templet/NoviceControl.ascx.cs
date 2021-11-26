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

public partial class Templet_NoviceControl:JBUserControl
{
    private SiteHelper siteHelper = new SiteHelper();
    protected void Page_Load(object sender , EventArgs e)
    {
        if ( !IsPostBack )
        {
            string dept = JbUser.DepartmentCode;
            lb_dept.Text = dept;
            GetData();
        }
    }

    protected void GridView1_PageIndexChanging(object sender , GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        GetData();
    }

    void GetData()
    {
        //顯示三個月內
        //DateTime date_b = DateTime.Now.AddDays(-7);
        DateTime date_b = DateTime.Now.AddMonths(-3);
        DateTime date_e = DateTime.Now.Date;

        //顯示當月
        //string date_b = Convert.ToString(DateTime.Now.Year) +"/"+ Convert.ToString(DateTime.Now.Month) + "/01";
        //string date_e = DateTime.Parse(date_b).AddMonths(1).AddDays(-1).ToString("yyyy/MM/dd");


        //List<Department> depts = new DeptCs().getDeptChild(lb_dept.Text);
        HRDsTableAdapters.rv_noviceTableAdapter rv_novice = new HRDsTableAdapters.rv_noviceTableAdapter();
        HRDs.rv_noviceDataTable rv_noviceDS = new HRDs.rv_noviceDataTable();
        //for (int i = 0; i < depts.Count; i++)
        //{
        //    rv_noviceDS.Merge(rv_novice.GetData_rv_novice(DateTime.Parse(date_b),DateTime.Parse(date_e),depts[i].D_NO));
        //}
        //rv_noviceDS.Merge(rv_novice.GetData_rv_novice(DateTime.Parse(date_b), DateTime.Parse(date_e), lb_dept.Text));
        rv_noviceDS.Merge(rv_novice.GetByDateRangeComp(date_b , date_e , JbUser.Comp));


        GridView1.DataSource = rv_noviceDS;//.OrderByDescending(p=>p.ADATE);
        GridView1.DataBind();

        //rv_noviceDS.Select("ADATE > '"+DateTime.Now.AddMonths(-1).ToShortDateString()+"'");
        ////建立分類頁
        PagedDataSource objPage = new PagedDataSource();
        //來源
        objPage.DataSource = rv_noviceDS.DefaultView;
        //允許分頁        
        objPage.AllowPaging = true;
        //可以顯示一頁的項目
        objPage.PageSize = 6;
        //保存當前頁的索引
        int CurPage;
        //判斷是否有要跳頁的動作
        if ( Request.QueryString["Page"] != null )
            CurPage = Convert.ToInt32(Request.QueryString["Page"]);
        else
            CurPage = 1;
        //設為目前頁的索引
        objPage.CurrentPageIndex = CurPage - 1;
        objPage.CurrentPageIndex = CurPage - 1;
        //顯示訊息
        lblCurPage.Text = GetLocalResourceObject("MsgPagePre") + CurPage.ToString() + GetLocalResourceObject("MsgPageMid") + (rv_noviceDS.Count / objPage.PageSize).ToString() + GetLocalResourceObject("MsgPagePost");
        //如果目前頁不是第一頁
        if ( !objPage.IsFirstPage )
            //定義上一頁的超連結為 目前頁 -1
            lnkPrev.NavigateUrl = Request.CurrentExecutionFilePath + "?Page=" + Convert.ToString(CurPage - 1);

        //如果目前頁不是最後一頁        
        if ( !objPage.IsLastPage )
            //定義下一頁的超連結為 目前頁 +1
            lnkNext.NavigateUrl = Request.CurrentExecutionFilePath + "?Page=" + Convert.ToString(CurPage + 1);
        //再把經過篩選的objPage給予DataList 
        //dlPager.DataSource = objPage;
        //dlPager.DataBind();    
        //DataList1.DataSource = objPage;
        //DataList1.DataBind();


        //   DataList1.DataSource = rv_noviceDS;


    }

    protected void DataList1_DataBinding(object sender , EventArgs e)
    {


    }
    protected void DataList1_ItemDataBound(object sender , DataListItemEventArgs e)
    {
        Image eim = (Image) e.Item.FindControl("Image1");
        string nobr = eim.AlternateText;

        eim.ImageUrl = "~/Utli/ShowEmpImage.aspx?Photo=" + nobr.Trim() + ".jpg";
        //eim.ImageUrl = siteHelper.GetEmpPhotoPath(nobr);
    }
}
