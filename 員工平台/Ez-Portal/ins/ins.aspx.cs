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

public partial class ins_ins : JBWebPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) {
            lb_nobr.Text = Juser.Nobr;//JbUser.NOBR;
            load();        
        }
    }

    void load() {
        //insDSTableAdapters.FAMILY_tempTableAdapter fad = new insDSTableAdapters.FAMILY_tempTableAdapter();
        //insDS.FAMILY_tempDataTable fdt = fad.GetData(JbUser.NOBR);
        //GridView1.DataSource = fdt;
        //GridView1.DataBind();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 0;
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 1;
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 2;
    }
    protected void Button4_Click(object sender, EventArgs e)
    {
        insDSTableAdapters.FAMILY_tempTableAdapter fad = new insDSTableAdapters.FAMILY_tempTableAdapter();
        insDS.FAMILY_tempDataTable fdt = new insDS.FAMILY_tempDataTable();
        insDS.FAMILY_tempRow frow = fdt.NewFAMILY_tempRow();
        frow.Adate = DateTime.Now;
        frow.NOBR = Juser.Nobr;
        frow.EDUCODE = "";
        frow.REL_CODE= ddl_f_re.SelectedValue;
        frow.BBC = ddl_f_re.SelectedItem.Text;
        frow.FA_BIRDT = tb_f_br.SelectedDate.Value.Date;
        if (SiteHelper.IsIdentificationId(tb_f_idno.Text))
            frow.FA_IDNO = tb_f_idno.Text;
        else 
        { 
            JB.WebModules.Message.Show("身分證輸入錯誤，請確認");
            return;
        }
        frow.FA_NAME = tb_f_name.Text;
        frow.FAMFORN = ddl_f_t.SelectedValue;
       
        frow.HR_Check = false;
        frow.ins_Type = "申請中";
        frow.KEY_DATE = DateTime.Now;
        frow.KEY_MAN = Juser.NameC; //JbUser.NAME_C;
        frow.LIVE = ddl_f_v.SelectedValue;
        frow.TAX = ddl_f_tax.SelectedValue;
        frow.TEL = DropDownList3.SelectedValue;
        frow.GSM = DropDownList3.SelectedItem.Text;
        frow.TITLE = "";
        frow.COMPNY = "";
       
        frow.ADDR = DropDownList2.SelectedValue;
        frow.AUTOINSLAB = ddl_t_h.SelectedValue;
        frow.AutoKey = 0;
        fdt.AddFAMILY_tempRow(frow);
        fad.Update(fdt);

        GridView1.DataBind();
        JB.WebModules.Message.Show("傳送完成");
      

       
    }
    protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox cb = (CheckBox)sender;
        string nobr =cb.ToolTip.ToString();
        string f_idno =cb.ValidationGroup;
        insDSTableAdapters.FAMILYTableAdapter fad = new insDSTableAdapters.FAMILYTableAdapter();
        insDS.FAMILYDataTable fdt = fad.GetDataByNobrAndFIdno(nobr, f_idno);
        if (fdt.Rows.Count > 0)
        {
            fdt[0].LIVE = cb.Checked;
            fad.Update(fdt);
        }
        
    }
    protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridView gv = (GridView)sender;
        string nobr = gv.SelectedDataKey[0].ToString();
        string f_idno = gv.SelectedDataKey[1].ToString();
         insDSTableAdapters.FAMILYTableAdapter fad = new insDSTableAdapters.FAMILYTableAdapter();
        insDS.FAMILYDataTable fdt = fad.GetDataByNobrAndFIdno(nobr, f_idno);
        if (fdt.Rows.Count > 0)
        {
            tb_f_name.Text = fdt[0].FA_NAME;
            tb_f_idno.Text = fdt[0].FA_IDNO;
            tb_f_br.SelectedDate = fdt[0].FA_BIRDT;
           DropDownList2.SelectedValue = fdt[0].ADDR;
            ddl_f_re.SelectedValue = fdt[0].REL_CODE;
            ddl_f_tax.SelectedIndex = fdt[0].TAX ? 1 : 0;
            ddl_t_h.SelectedIndex = fdt[0].AUTOINSLAB ? 1 : 0;
            ddl_f_t.SelectedIndex = fdt[0].FAMFORN ? 1 : 0;
            ddl_f_v.SelectedIndex = fdt[0].LIVE ? 1 : 0;

        }
    }
    protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //if (e.Row.RowType == DataControlRowType.DataRow) 
        //{
        //    if (e.Row.Cells[4].Text.Trim().ToUpper().Equals("H221480268")) 
        //    {
        //        e.Row.Visible = false;
        //    }
        //}
    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        CheckBox cb = GridView1.Rows[e.RowIndex].FindControl("CheckBox1") as CheckBox;
        if (cb.Checked) {
            e.Cancel = true;
            JB.WebModules.Message.Show("HR已確認不可刪除");
        }
    }
}
