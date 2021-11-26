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

public partial class Salary_CreateSalaryPW : JBWebPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Label4.Text = "";

        ViewState["_nobr"] = JbUser.NOBR;
        


        PWTableAdapters.SALPWTableAdapter pwad = new PWTableAdapters.SALPWTableAdapter();
        PW.SALPWDataTable pw = pwad.GetDataByNobr(ViewState["_nobr"].ToString());
        if (pw.Rows.Count > 0)
        {
            Button1.Visible = false;
            Label4.Text = "您已經新增過薪資密碼，無需再新增！！";
        }

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        PWTableAdapters.SALPWTableAdapter pwad = new PWTableAdapters.SALPWTableAdapter();
        PW.SALPWDataTable pw = pwad.GetDataByNobr(ViewState["_nobr"].ToString());
        if (pw.Rows.Count == 0)
        {
            PW.SALPWRow pwrow = (PW.SALPWRow)pw.NewSALPWRow();
            pwrow.Nobr = ViewState["_nobr"].ToString();
            pwrow.PW = Cs.encode(TextBox1.Text);
            pwrow.KeyDate = DateTime.Now;
            pw.AddSALPWRow(pwrow);
            pwad.Update(pw);
            Label4.Text = "新增完成！！";
        }
        else
        {
            Label4.Text = "您已經新增過薪資密碼，無需再新增！！";
        }

    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Response.Redirect("EmpSalary.aspx");
    }
}
