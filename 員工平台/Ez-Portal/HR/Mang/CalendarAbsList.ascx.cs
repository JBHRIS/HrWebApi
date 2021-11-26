using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;


public partial class CalendarAbsList : JBUserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            setData(DateTime.Parse(DateTime.Now.Year.ToString() + "/" + DateTime.Now.Month + "/1"),
                  DateTime.Parse(DateTime.Now.Year.ToString() + "/" + DateTime.Now.Month + "/" + DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month).ToString()));
        }

    }
    void setData(DateTime adate, DateTime ddate)
    {
        HRDsTableAdapters.rv_abs3TableAdapter rv_abs = new HRDsTableAdapters.rv_abs3TableAdapter();
        HRDs.rv_abs3DataTable rv_absDs = new HRDs.rv_abs3DataTable();
        HRDsTableAdapters.HR_Portal_OtTableAdapter rv_ot = new HRDsTableAdapters.HR_Portal_OtTableAdapter();
        HRDs.HR_Portal_OtDataTable rv_otDs = new HRDs.HR_Portal_OtDataTable();


        //List<Department> depts = new DeptCs().getDeptChild(SiteHelper.GetDeptRoot());//JbUser.DepartmentCode

        TreeView tv = new TreeView();
        SiteHelper.SetAllDeptTree(tv, Juser.ManageComp);
        List<TreeNode> nodeList = SiteHelper.GetTreeViewAllNodes(tv);

        foreach (TreeNode n in nodeList)
        {
            rv_absDs.Merge(rv_abs.GetDataByDEPT(adate, ddate, n.Value));
            rv_otDs.Merge(rv_ot.GetDataByDEPT(adate, ddate, n.Value));
        }

        SiteHelper siteHelper = new SiteHelper();
        HRDs.rv_abs3DataTable rv_absDs2 = siteHelper.GetSelectedEmpData(rv_absDs, "NOBR", Juser.SalaDrNobrList) as HRDs.rv_abs3DataTable;
        HRDs.HR_Portal_OtDataTable rv_otDs2 = siteHelper.GetSelectedEmpData(rv_otDs, "NOBR", Juser.SalaDrNobrList) as HRDs.HR_Portal_OtDataTable;


        DataTable rv_abscount = new DataTable();
        rv_abscount.Columns.Add("h_name", typeof(string));
        rv_abscount.Columns.Add("unit", typeof(string));
        rv_abscount.Columns.Add("tol_hours", typeof(decimal));
        rv_abscount.PrimaryKey = new DataColumn[] { rv_abscount.Columns["h_name"] };

        foreach (DataRow Row in rv_absDs2.Rows)
        {
            string str_hname = Row["h_name"].ToString().Trim();
            DataRow row = rv_abscount.Rows.Find(str_hname);
            if (row != null)
            {
                row["tol_hours"] = decimal.Parse(row["tol_hours"].ToString()) + decimal.Parse(Row["tol_hours"].ToString());
            }
            else
            {
                DataRow aRow = rv_abscount.NewRow();
                aRow["h_name"] = str_hname;
                aRow["unit"] = Row["unit"].ToString();
                aRow["tol_hours"] = decimal.Parse(Row["tol_hours"].ToString());
                rv_abscount.Rows.Add(aRow);
            }
        }


        DataTable rv_otcount = new DataTable();
        rv_otcount.Columns.Add("ot_name", typeof(string));
        rv_otcount.Columns.Add("hrs", typeof(decimal));

        decimal _othrs = 0; decimal _resthrs = 0;
        foreach (DataRow Row in rv_otDs2.Rows)
        {
            _othrs += decimal.Parse(Row["ot_hrs"].ToString());
            _resthrs += decimal.Parse(Row["rest_hrs"].ToString());
        }
        if (_othrs > 0)
        {
            DataRow aRow2 = rv_otcount.NewRow();
            aRow2["ot_name"] = "加班時數";
            aRow2["hrs"] = _othrs;
            rv_otcount.Rows.Add(aRow2);
        }

        if (_resthrs > 0)
        {
            DataRow aRow3 = rv_otcount.NewRow();
            aRow3["ot_name"] = "補休時數";
            aRow3["hrs"] = _resthrs;
            rv_otcount.Rows.Add(aRow3);
        }

        Session["absdt"] = rv_absDs2;
        Session["otdt"] = rv_otDs2;

        AbsCountGV.DataSource = rv_abscount;
        AbsCountGV.DataBind();

        OtCountGV.DataSource = rv_otcount;
        OtCountGV.DataBind();
    }
    protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
    {

        if (Session["absdt"] == null)
            setData(DateTime.Parse(e.Day.Date.Year.ToString() + "/" + e.Day.Date.Month + "/1"),
                DateTime.Parse(e.Day.Date.Year.ToString() + "/" + e.Day.Date.Month + "/" + DateTime.DaysInMonth(e.Day.Date.Year, e.Day.Date.Month).ToString()));

        HRDs.rv_abs3DataTable bdt = (HRDs.rv_abs3DataTable)Session["absdt"];
        HRDs.rv_abs3Row[] brow = (HRDs.rv_abs3Row[])bdt.Select("BDATE ='" + e.Day.Date.ToShortDateString() + "'");
        HRDs.HR_Portal_OtDataTable rv_otDt = (HRDs.HR_Portal_OtDataTable)Session["otdt"];
        HRDs.HR_Portal_OtRow[] orow = (HRDs.HR_Portal_OtRow[])rv_otDt.Select("BDATE ='" + e.Day.Date.ToShortDateString() + "'");



        int _1 = brow.Length;
        int _2 = orow.Length;


        string s_1 = "   <tr><td><span style=\"color: #000099\"> 請假人數</span>：" + _1.ToString() + "人</td> </tr> ";
        string s_2 = "  <tr><td><span style=\"color: #ff0000\">加班人數</span>：" + _2.ToString() + "人</td> </tr> ";


        string tts = "";
        if (_1 > 0)
            tts += s_1;
        if (_2 > 0)
            tts += s_2;


        string html = "";
        html = "<br><br><table width='100%' border='0' cellspacing='1' cellpadding='2' > " +

            tts +

            " </table> ";
        LinkButton lb = new LinkButton();

        lb.Click += new EventHandler(LinkButton1_Click);
        lb.Text = html;
        e.Cell.Controls.Add(lb);
    }


    protected void Calendar1_VisibleMonthChanged(object sender, MonthChangedEventArgs e)
    {
        setData(DateTime.Parse(e.NewDate.Year.ToString() + "/" + e.NewDate.Month + "/1"),
               DateTime.Parse(e.NewDate.Year.ToString() + "/" + e.NewDate.Month + "/" + DateTime.DaysInMonth(e.NewDate.Year, e.NewDate.Month).ToString()));


    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {

    }
    protected void LinkButton1_Click1(object sender, EventArgs e)
    {

    }
    protected void Calendar1_SelectionChanged(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 1;


        if (Session["absdt"] == null)
            setData(DateTime.Parse(Calendar1.SelectedDate.Year.ToString() + "/" + Calendar1.SelectedDate.Month + "/1"),
                DateTime.Parse(Calendar1.SelectedDate.Year.ToString() + "/" + Calendar1.SelectedDate.Month + "/" + DateTime.DaysInMonth(Calendar1.SelectedDate.Year, Calendar1.SelectedDate.Month).ToString()));

        HRDs.rv_abs3DataTable bdt = (HRDs.rv_abs3DataTable)Session["absdt"];
        HRDs.HR_Portal_OtDataTable rv_otDt = (HRDs.HR_Portal_OtDataTable)Session["otdt"];
        DataView absdv = bdt.DefaultView;
        absdv.RowFilter = "BDATE ='" + Calendar1.SelectedDate.ToShortDateString() + "'";
        DataView otdv = rv_otDt.DefaultView;
        otdv.RowFilter = "BDATE ='" + Calendar1.SelectedDate.ToShortDateString() + "'";

        absGV.DataSource = absdv;
        otGV.DataSource = otdv;

        absGV.DataBind();
        otGV.DataBind();

        AttendDsTableAdapters.ATTENDTableAdapter attad = new AttendDsTableAdapters.ATTENDTableAdapter();
        AttendDs.ATTENDDataTable attdt = new AttendDs.ATTENDDataTable();

        TreeView tv = new TreeView();
        SiteHelper sh = new SiteHelper();
        SiteHelper.SetAllDeptTree(tv);
        List<TreeNode> nodeList= SiteHelper.GetTreeViewAllNodes(tv);

        foreach(var n in nodeList)
        {
            attdt.Merge(attad.GetData(Calendar1.SelectedDate, n.Value));
        }

        GridView1.DataSource = attdt;
        GridView1.DataBind();

        Calendar1.SelectedDate = DateTime.Parse("2099/02/02");
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 0;

    }

    protected void LinkButton1_Click2(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 1;
        LinkButton lb = (LinkButton)sender;
        if (Session["absdt"] == null)
            setData(DateTime.Parse(Calendar1.SelectedDate.Year.ToString() + "/" + Calendar1.SelectedDate.Month + "/1"),
                DateTime.Parse(Calendar1.SelectedDate.Year.ToString() + "/" + Calendar1.SelectedDate.Month + "/" + DateTime.DaysInMonth(Calendar1.SelectedDate.Year, Calendar1.SelectedDate.Month).ToString()));

        HRDs.rv_abs3DataTable bdt = (HRDs.rv_abs3DataTable)Session["absdt"];

        DataView absdv = bdt.DefaultView;
        absdv.RowFilter = "h_name ='" + lb.Text + "'";

        absGV.DataSource = absdv;
        absGV.DataBind();
        HRDs.HR_Portal_OtDataTable rv_otDt = new HRDs.HR_Portal_OtDataTable();
        otGV.DataSource = rv_otDt;
        otGV.DataBind();

    }
    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 1;
        LinkButton lb = (LinkButton)sender;

        if (Session["absdt"] == null)
            setData(DateTime.Parse(Calendar1.SelectedDate.Year.ToString() + "/" + Calendar1.SelectedDate.Month + "/1"),
                DateTime.Parse(Calendar1.SelectedDate.Year.ToString() + "/" + Calendar1.SelectedDate.Month + "/" + DateTime.DaysInMonth(Calendar1.SelectedDate.Year, Calendar1.SelectedDate.Month).ToString()));


        HRDs.HR_Portal_OtDataTable rv_otDt = (HRDs.HR_Portal_OtDataTable)Session["otdt"];

        DataView otdv = rv_otDt.DefaultView;
        if (lb.Text.Trim().Equals("補休時數"))
        {
            otdv.RowFilter = " rest_hrs > 0 ";
        }
        else
        {
            otdv.RowFilter = " rest_hrs = 0 ";
        }

        HRDs.rv_abs3DataTable bdt = new HRDs.rv_abs3DataTable();
        absGV.DataSource = bdt;
        absGV.DataBind();



        otGV.DataSource = otdv;
        otGV.DataBind();


    }
}
