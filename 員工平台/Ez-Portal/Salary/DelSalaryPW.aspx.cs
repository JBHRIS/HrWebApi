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
public partial class Salary_DelSalaryPW : JBWebPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        showMeg.Text = "";
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        //PWTableAdapters.SALPWTableAdapter pwad = new PWTableAdapters.SALPWTableAdapter();
        //PW.SALPWDataTable pw = pwad.GetDataByNobr(TextBox1.Text);
        SalaryPassWord_REPO spRepo = new SalaryPassWord_REPO();
        var o = spRepo.GetByNobr(TextBox1.Text);
        //if (pw.Rows.Count > 0)
        if(o!=null)
        {
            //pw.Rows[0].Delete();
            //pwad.Update(pw);
            spRepo.Delete(o);
            spRepo.Save();
            showMeg.Text = "刪除成功！！";
        }
        else
        {
            showMeg.Text = "此工號未建立薪資密碼！！";
        }
    }
}
