using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class ins_ins_hr : JBWebPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            adate.SelectedDate = DateTime.Now.AddMonths(-1);
            ddate.SelectedDate = DateTime.Now;
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (RadioButtonList1.SelectedIndex == 0)
        {
            GridView1.DataSourceID = "SqlDataSource1";
        }
        else {

            GridView1.DataSourceID = "All_SqlDataSource";
        }
        GridView1.DataBind();
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow) {
            //o_FA_BIRDT
            //o_TAX
            //o_AUTOINSLAB
            //o_LIVE
            //o_FAMFORN
            string nobr = e.Row.Cells[1].Text;
            string f_idno = e.Row.Cells[4].Text;
            Label o_FA_BIRDT = e.Row.FindControl("o_FA_BIRDT") as Label;
            Label o_TAX = e.Row.FindControl("o_TAX") as Label;
            Label o_AUTOINSLAB = e.Row.FindControl("o_AUTOINSLAB") as Label;
            Label o_LIVE = e.Row.FindControl("o_LIVE") as Label;
            Label o_FAMFORN = e.Row.FindControl("o_FAMFORN") as Label;

            insDSTableAdapters.FAMILYTableAdapter ad = new insDSTableAdapters.FAMILYTableAdapter();
            insDS.FAMILYDataTable dt= ad.GetDataByNobrAndFIdno(nobr,f_idno);
            if (dt.Rows.Count > 0) {

                o_FA_BIRDT.Text = dt[0].FA_BIRDT.ToShortDateString();
                o_TAX.Text = dt[0].TAX ? "扶養" : "不扶養";
                o_AUTOINSLAB.Text = dt[0].AUTOINSLAB ? "加保" : "不加保";
                o_LIVE.Text = dt[0].LIVE ? "顯示" : "不顯示";
                o_FAMFORN.Text = dt[0].AUTOINSLAB ? "加保" : "不加保";

            }

            CheckBox cb = e.Row.FindControl("CheckBox1") as CheckBox;
            cb.Enabled = cb.Checked ? false : true;
        
        }
    }
    protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox cb = (CheckBox)sender;
        GridViewRow row = (GridViewRow)(cb.NamingContainer);

       
        Label AutoKey = row.FindControl("AutoKey") as Label;


        insDSTableAdapters.FAMILY_tempTableAdapter ad = new insDSTableAdapters.FAMILY_tempTableAdapter();
        insDSTableAdapters.FAMILYTableAdapter f_Ad = new insDSTableAdapters.FAMILYTableAdapter();
        insDS.FAMILY_tempDataTable dt = ad.GetDataByAutoKey(int.Parse(AutoKey.Text));
        if (dt.Rows.Count > 0)
        {
            insDS.FAMILYDataTable f_dt = f_Ad.GetDataByNobrAndFIdno(dt[0].NOBR, dt[0].FA_IDNO);
            if (f_dt.Rows.Count > 0)
            {
                f_dt[0].FA_BIRDT = dt[0].FA_BIRDT;
                f_dt[0].TAX = dt[0].TAX.Trim().Equals("扶養") ? true : false;
                f_dt[0].AUTOINSLAB = dt[0].AUTOINSLAB.Trim().Equals("加保") ? true : false;
                f_dt[0].LIVE = dt[0].LIVE.Trim().Equals("顯示") ? true : false;
                f_dt[0].FAMFORN = dt[0].FAMFORN.Trim().Equals("加保") ? true : false;
            }
            else {

                insDS.FAMILYRow r = f_dt.NewFAMILYRow();
                r.NOBR = dt[0].NOBR;
                r.FA_BIRDT = dt[0].FA_BIRDT;
                r.FA_IDNO = dt[0].FA_IDNO;
                r.FA_NAME = dt[0].FA_NAME;
                //r.FAMFORN = dt[0].FAMFORN.Trim().Equals("加保") ? true : false;
                r.ADDR = dt[0].ADDR;
                //r.AUTOINSLAB = dt[0].AUTOINSLAB.Trim().Equals("加保") ? true : false;
                r.BBC = dt[0].BBC;
                r.COMPNY = dt[0].COMPNY;
                r.EDUCODE = dt[0].EDUCODE;
                r.GSM = dt[0].GSM;
                r.KEY_DATE = DateTime.Now;
                r.KEY_MAN = dt[0].KEY_MAN;
                r.LIVE = dt[0].LIVE.Trim().Equals("顯示") ? true : false;
                r.REL_CODE = dt[0].REL_CODE;
                r.TAX = dt[0].TAX.Trim().Equals("扶養") ? true : false;
                r.TEL = dt[0].TEL;
                r.TITLE = dt[0].TITLE;
                f_dt.AddFAMILYRow(r);
           
            }
            f_Ad.Update(f_dt);

            dt[0].HR_Check = true;
            dt[0].HR_Check_Date = DateTime.Now;
            dt[0].ins_Type = "HR確認完成";
            ad.Update(dt);
           
        }
        GridView1.DataBind();

    }
}
