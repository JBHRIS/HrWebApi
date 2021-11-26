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
public partial class Mang_EmpCardLostReasonSelect : JBWebPage
{
    private BASETTS_REPO basetts_repo = new BASETTS_REPO();
    //private OT_REPO otRepo = new OT_REPO();
    private CARD_REPO cardRepo = new CARD_REPO();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //BASETTS basetts = basetts_repo.GetLatestRecordByNobr(JbUser.NOBR);

            //if (basetts == null)
            //    return;

            //lb_dept.Text = basetts.DEPT;
            //SiteHelper sh = new SiteHelper();sh.InitManagerDeptTreeView(TreeView1, Juser.ManageDeptRootNodeList);
            //if (TreeView1.Nodes.Count > 0)
            //{
            //    TreeView1.Nodes[0].Select();
            //    TreeView1_SelectedNodeChanged(TreeView1.Nodes[0], null);
            //}


            var a = ucEmpDeptQS as IEmpDeptQS;
            a.InitUC_Dept(EnumUC_QS_InitType.Manager);
            a.InitUC_Cat(1);




            Session[SessionName] = null;
            rdpBdate.SelectedDate = DateTime.Parse(DateTime.Now.Year.ToString() + "/" + DateTime.Now.Month.ToString() + "/1");
            rdpEdate.SelectedDate = DateTime.Parse(DateTime.Now.Year.ToString() + "/" + DateTime.Now.Month.ToString() + "/" + DateTime.DaysInMonth(DateTime.Now.Year,DateTime.Now.Month));
        }
    }
    //protected void TreeView1_SelectedNodeChanged(object sender, EventArgs e)
    //{
    //    setDept(TreeView1.SelectedValue);
    //    if(IsPostBack)
    //        GetData();
    //}


    //private void setDept(string value)
    //{
    //    lb_dept.Text = value;
    //    //IUC iuc = (IUC)CalendarAbsList1;
    //    //iuc.SetValue(value);
    //    //iuc.BindData();
    //}
    protected void Button1_Click(object sender, EventArgs e)
    {
        GetData();
    }
    protected void ExportExcel_Click(object sender, EventArgs e)
    {
        if (Session[SessionName] != null)
            JB.WebModules.Data.Export.Excel.WebResponseExcel(this, gv, (List<EmpCardLostReason>)Session[SessionName], SessionName);
        else
            JB.WebModules.Message.Show("無資料可匯出！");
    }

    void GetData()
    {
        double dbl = 0;
        Double.TryParse(tbTimeSpan.Text, out dbl);
        var a = ucEmpDeptQS as IEmpDeptQS;
        var obj = a.GetSelectedObj();

        if (obj == null)
        {
            Show("Select Unit or Team Member");
            return;
        }
        //List<CARD> cardList = cardRepo.GetByCardWithReasonDeptDateRange_DLO(lb_dept.Text, rdpBdate.SelectedDate.Value, rdpEdate.SelectedDate.Value);
        //if (cbChildDept.Checked)
        //{
        //    TreeNode node = TreeView1.SelectedNode;
        //    List<TreeNode> nodeList = SiteHelper.GetChildNodes(node);
        //    foreach ( var n in nodeList )
        //        cardList.AddRange(cardRepo.GetByCardWithReasonDeptDateRange_DLO(n.Value, rdpBdate.SelectedDate.Value, rdpEdate.SelectedDate.Value));                
        //}
        List<CARD> cardList = new List<CARD>();
        if (obj.SelectedType == EnumUC_QS_SelectedType.Dept && !obj.IsSingleDept) {
            foreach (var n in obj.DeptList)
            {
                cardList.AddRange(cardRepo.GetByCardWithReasonDeptDateRange_DLO(n, rdpBdate.SelectedDate.Value, rdpEdate.SelectedDate.Value));
            }
        }
        //排除主管不可看部分
        cardList.RemoveAll(p => Juser.ManagerExeptEmpList.Contains(p.NOBR));
        var gvSource = (from c in cardList
                        select new EmpCardLostReason
                        {
                            Nobr = c.NOBR,
                            DeptName = c.BASE.BASETTS[0].DEPT1.D_NAME,
                            DeptCode = c.BASE.BASETTS[0].DEPT1.D_NO,
                            Name_C = c.BASE.NAME_C,
                            Name_E = c.BASE.NAME_E,
                            Adate = c.ADATE,
                            ReasonName = c.CARDLOSD.DESCR,
                            ReasonCode = c.CARDLOSD.CODE
                        }).ToList();

        Session[SessionName] = gvSource;        
        gv.DataSource = gvSource;
        gv.DataBind();
        List<EmpCardLostReasonAmt> amtList= cardRepo.CalcCardReasonByDept(gvSource);
        //不顯示次數0
        if (!cbZero.Checked)
        {
            for (int i = 0; i < amtList.Count; i++)
            {
                if (amtList[i].Counter == 0)
                {
                    amtList.RemoveAt(i);
                    i--;
                }
            }
        }
        gvSummury.DataSource = amtList;
        gvSummury.DataBind();
        var amtAllList = cardRepo.CalcCardReasonByReason(amtList).OrderByDescending(p => p.Counter);
        Session[SessionName3] = amtAllList;
        gvAllSummury.DataSource = amtAllList;
        gvAllSummury.DataBind();
    }
    protected void gv_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        if (Session[SessionName] != null)
        {
            gv.PageIndex = e.NewPageIndex;
            gv.DataSource = (List<EmpCardLostReason>)Session[SessionName];
            gv.DataBind();
        }
        else
        {
            JB.WebModules.Message.Show("網頁逾時，請重新查詢！");
        }
    }
    protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        if (ViewState["sortDirection"] == null)
            ViewState["sortDirection"] = "Desc";

        if (ViewState["sortKey"] == null)
            ViewState["sortKey"] = "Nobr";

        if (Session[SessionName] != null)
        {
            //DataView dataview = new DataView((OT_Ds.OT46AMTDataTable)Session[SESSION_TABLE]);
            //dataview.Sort = ViewState["sortKey"] + " " + ViewState["sortDirection"].ToString();
            //gv.PageIndex = e.NewPageIndex;
            //gv.DataSource = dataview;
            //gv.DataBind();

            var dataList = (List<EmpCardLostReason>)Session[SessionName];
            List<EmpCardLostReason> resultList = null;
            if (ViewState["sortDirection"].ToString().Equals("Desc"))
            {
                if (ViewState["sortKey"].ToString().Equals("DeptName"))
                    resultList = (from c in dataList orderby c.DeptName descending select c).ToList();
                else
                    resultList = (from c in dataList orderby c.Nobr descending select c).ToList();
            }
            else
            {
                if (ViewState["sortKey"].ToString().Equals("DeptName"))
                    resultList = (from c in dataList orderby c.DeptName ascending select c).ToList();
                else
                    resultList = (from c in dataList orderby c.Nobr ascending select c).ToList();
            }

            gv.PageIndex = e.NewPageIndex;
            gv.DataSource = resultList;
            gv.DataBind();
  
        }
        else
        {
            JB.WebModules.Message.Show("網頁逾時，請重新查詢！");
        }
    }
    protected void gvSummury_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //if (e.Row.RowType == DataControlRowType.Footer)
        //{
        //    //OT_Ds.OT46SummuryDataTable dt = (OT_Ds.OT46SummuryDataTable)gvSummury.DataSource;
        //    OT_Ds.OT46SummuryDataTable dt = (OT_Ds.OT46SummuryDataTable)Session[SESSION_SUMMURY_TABLE];
        //    if (dt.Rows.Count > 0)
        //    {
        //        OT_Ds.OT46SummuryRow row = (OT_Ds.OT46SummuryRow)dt.Rows[0];
        //        e.Row.Cells[0].Text = "區間人數(平)= " + row.AllEmpOtQty.ToString();
        //        e.Row.Cells[1].Text = "區間時數(平)= " + row.AllEmpOtTimeAmt.ToString();
        //        e.Row.Cells[2].Text = "區間人數(假)= " + row.AllEmpHOtQty.ToString();
        //        e.Row.Cells[3].Text = "區間時數(假)= " + row.AllEmpHOtTimeAmt.ToString();
        //        e.Row.Cells[4].Text = "區間人數(平假)= " + row.AllEmpOtAndHOtQty.ToString();
        //        e.Row.Cells[5].Text = "區間時數(平假)= " + row.AllEmpOtAndHOtTimeAmt.ToString();

        //        e.Row.Cells[0].BackColor = System.Drawing.Color.LightSalmon;
        //        e.Row.Cells[1].BackColor = System.Drawing.Color.LightSalmon;
        //        e.Row.Cells[2].BackColor = System.Drawing.Color.LightCyan;
        //        e.Row.Cells[3].BackColor = System.Drawing.Color.LightCyan;
        //        e.Row.Cells[4].BackColor = System.Drawing.Color.HotPink;
        //        e.Row.Cells[5].BackColor = System.Drawing.Color.HotPink;
        //    }
        //}
        //else if (e.Row.RowType == DataControlRowType.DataRow)
        //{
        //    double value = 0;
        //    if (e.Row.Cells[7].Text.Contains("%"))
        //    {
        //        Double.TryParse(e.Row.Cells[7].Text.Trim('%'), out value);
        //        if (value > 50)
        //            e.Row.Cells[7].ForeColor = System.Drawing.Color.Red;
        //    }
        //}
    }
    protected void ExportSummuryExcel_Click(object sender, EventArgs e)
    {
        Response.ClearContent();
        string excelFileName = SessionName2.ToString() +".xls";
        Response.AddHeader("content-disposition", "attachment;filename=" + Server.UrlEncode(excelFileName));
        Response.ContentType = "application/excel";
        System.IO.StringWriter stringWrite = new System.IO.StringWriter();
        System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
        gvSummury.RenderControl(htmlWrite);
        //GridView4.RenderControl(htmlWrite);

        Response.Write(stringWrite.ToString());
        Response.End();
    }
    protected void gv_RowDataBound(object sender , GridViewRowEventArgs e)
    {
        //if ( e.Row.RowType == DataControlRowType.DataRow )
        //{
        //    //假日加班比
        //    double value = 0;
        //    if ( e.Row.Cells[7].Text.Contains("%") )
        //    {
        //        Double.TryParse(e.Row.Cells[7].Text.Trim('%') , out value);
        //        if ( value > 50 )
        //            e.Row.Cells[7].ForeColor = System.Drawing.Color.Red;
        //    }

        //    //平日加班比
        //    value = 0;
        //    if ( e.Row.Cells[5].Text.Contains("%") )
        //    {
        //        Double.TryParse(e.Row.Cells[5].Text.Trim('%') , out value);
        //        if ( value > 100 )
        //            e.Row.Cells[5].ForeColor = System.Drawing.Color.Red;
        //    }
        //}
    }
    protected void gv_Sorting(object sender, GridViewSortEventArgs e)
    {
        if (ViewState["sortDirection"] == null)
        {
            ViewState["sortDirection"] = "Desc";
        }

        if (ViewState["sortKey"] != null)
        {
            if (ViewState["sortKey"].ToString().Equals(e.SortExpression.ToString()))
            {
                if (ViewState["sortDirection"].ToString().Equals("Asc"))
                    ViewState["sortDirection"] = "Desc";
                else
                    ViewState["sortDirection"] = "Asc";
            }
            else
            {
                ViewState["sortDirection"] = "Desc";
            }

            ViewState["sortKey"] = e.SortExpression;
        }
        else
        {
            ViewState["sortKey"] = e.SortExpression;
        }

        if (Session[SessionName] != null)
        {
            //DataView dataview = new DataView((OT_Ds.OT46AMTDataTable)Session[SESSION_TABLE]);
            //dataview.Sort = e.SortExpression + " " + ViewState["sortDirection"].ToString();            
            var dataList= (List<EmpCardLostReason>)Session[SessionName];
            List<EmpCardLostReason> resultList = null;
            if (ViewState["sortDirection"].ToString().Equals("Desc"))
            {
                if (e.SortExpression.Equals("DeptName"))                
                    resultList = (from c in dataList orderby c.DeptName descending select c).ToList();                
                else                
                    resultList = (from c in dataList orderby c.Nobr descending select c).ToList();                
            }
            else
            {
                if (e.SortExpression.Equals("DeptName"))                
                    resultList = (from c in dataList orderby c.DeptName ascending select c).ToList();                
                else                
                    resultList = (from c in dataList orderby c.Nobr ascending select c).ToList();                
            }

            gv.DataSource = resultList;
            gv.DataBind();

        }
        else
        {
            JB.WebModules.Message.Show("網頁逾時，請重新查詢！");
        }
    }

    protected void ExportReasonSummury_Click(object sender, EventArgs e)
    {
        Response.ClearContent();
        string excelFileName = SessionName3.ToString() + ".xls";
        Response.AddHeader("content-disposition", "attachment;filename=" + Server.UrlEncode(excelFileName));
        Response.ContentType = "application/excel";
        System.IO.StringWriter stringWrite = new System.IO.StringWriter();
        System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
        gvAllSummury.RenderControl(htmlWrite);
        //GridView4.RenderControl(htmlWrite);

        Response.Write(stringWrite.ToString());
        Response.End();
    }
}
