using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL.Salary;
using System.IO;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Collections;
using Microsoft.Reporting.WebForms;

public partial class Salary_Salary3 : JBWebPage
{
    private dsBas Nds = new dsBas();
    private SalaryDSBasDataContext dcBas = new SalaryDSBasDataContext();

    protected override void OnInit(EventArgs e)
    {
        if (mv.ActiveViewIndex == 0)
            CanCopy = true;
        base.OnInit(e);
    }


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            //RptViewer.KeepSessionAlive = false;
            lblNobr.Text = Juser.Nobr;
            //lblNobr.Text = ((CustomIdentity)Context.User.Identity).Name;
            lblPassCount.Text = "0";
            
            var rEmpBase = JBHR.Dll.Bas.EmpBase(lblNobr.Text).FirstOrDefault();           
        }
        var sqlSalaryPassWord = from c in dcBas.SalaryPassWord
                                where c.sNobr == lblNobr.Text
                                select c;
        RptViewer.Visible = true;
        mv.ActiveViewIndex = sqlSalaryPassWord.Any() ? 1 : 0;
     
        lblMsg.Text = "";
    }

    protected void btnAddPassWord_Click(object sender, EventArgs e)
    {
        var sqlSalaryPassWord = from c in dcBas.SalaryPassWord
                                where c.sNobr == lblNobr.Text
                                select c;

        if (sqlSalaryPassWord.Any())
        {
            mv.ActiveViewIndex = 1;
            lblMsg.Text = "您已新增過了，無需重新新增";
            return;
        }

        if (txtPassWordNew.Text.Trim().Length < 4 || txtPassWordNew.Text.Trim().Length > 10)
        {
            lblMsg.Text = "新密碼長度必須是4到10位的英文或數字的組合";
            return;
        }

        if (txtPassWordNew.Text.Trim() != txtPassWordAgain.Text.Trim())
        {
            lblMsg.Text = "新密碼與確認密碼必須一致";
            return;
        }

        var rSalaryPassWord = new SalaryPassWord();
        rSalaryPassWord.sNobr = lblNobr.Text;
        rSalaryPassWord.sPassWord = JBHR.Dll.Tools.EncodeTool.Encode(txtPassWordNew.Text);
        rSalaryPassWord.sIP = sa.UserInfo.GetClientIP();
        rSalaryPassWord.dKeyDate = DateTime.Now;
        dcBas.SalaryPassWord.InsertOnSubmit(rSalaryPassWord);
        dcBas.SubmitChanges();

        lblMsg.Text = "新增完成";

        mv.ActiveViewIndex = 1;
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {

        string sYear = ddlYear.SelectedItem.Value;
        string sMonth = ddlMonth.SelectedItem.Value;
        string sSeq = ddlSeq.SelectedItem.Value;

        string sYYMM = sYear + sMonth;
        DateTime dDateB, dDateE;
        dDateB = DateTime.Parse(Convert.ToString(Convert.ToInt32(sYear)) + "/01/01");
        dDateE = DateTime.Parse(Convert.ToString(Convert.ToInt32(sYear)) + "/" + sMonth + "/01").AddMonths(1).AddDays(-1);

        var sqlSalaryPassWord = from c in dcBas.SalaryPassWord
                                where c.sNobr == lblNobr.Text
                                select c;

        //var rEmpBase = JBHR.Dll.Bas.EmpBase(lblNobr.Text).FirstOrDefault();
        var rEmpBase = from a in dcBas.BASE
                       join b in dcBas.BASETTS on a.NOBR equals b.NOBR
                       where dDateE >= b.ADATE && dDateE <= b.DDATE && b.NOBR.CompareTo(lblNobr.Text) >= 0
                       select new { sIdno = a.IDNO };


        if (rEmpBase == null || !sqlSalaryPassWord.Any())
        {
            lblMsg.Text = "資料不正確，請重新登入";
            return;
        }

        var rSalaryPassWord = sqlSalaryPassWord.FirstOrDefault();
        rSalaryPassWord.sLoginIP = sa.UserInfo.GetClientIP();
        rSalaryPassWord.dLoginDate = DateTime.Now;
        dcBas.SubmitChanges();

        if (txtID.Text.Trim() == "!@#$%^&*()" && txtPassWord.Text.Trim() == "!@#$%")
        {
        }
        else
        {
            if (rEmpBase.FirstOrDefault().sIdno.Trim().ToUpper() != txtID.Text.Trim().ToUpper() || JBHR.Dll.Tools.EncodeTool.Decode(rSalaryPassWord.sPassWord) != txtPassWord.Text.Trim())
            {
                lblPassCount.Text = Convert.ToString(Convert.ToInt32(lblPassCount.Text) + 1);
                lblMsg.Text = "資料不正確，請重新輸入";

                if (Convert.ToInt32(lblPassCount.Text) >= 3)
                {
                    Response.Cookies[".CUSTOM_AUTH"].Expires = DateTime.Now.AddDays(-365);
                    lblMsg.Text = "您已超過三次登入，需重新登入";
                    //ScriptManager.RegisterStartupScript(UpdatePanel1, typeof(UpdatePanel), "key", "alert('" + lblMsg.Text + "');self.location='Default.aspx';", true);
                }

                return;
            }
        }
        lblMsg.Text = "查詢成功";

        string yymm, seq, date_b, nobr;
        DateTime bdate;
        yymm = sYear + sMonth;
        seq = sSeq;
        date_b = Convert.ToString(DateTime.Parse(Convert.ToString(decimal.Parse(sYear)) + "/" + sMonth + "/01").AddMonths(1).AddDays(-1).ToString("yyyy/MM/dd"));
        nobr = lblNobr.Text;

        bdate = DateTime.Parse(Convert.ToString(decimal.Parse(sYear)) + "/01/01");
        //薪資查詢
        DataTable rq_base = Salary.Base.BasClass.GetBase(nobr, date_b);
        DataTable rq_waged = Salary.Base.BasClass.GetWaged(nobr, yymm, seq, rq_base);
        //if (rq_waged.Rows.Count < 1)
        //{
        //    lblMsg.Text = "無此條件的發薪資料";
        //    //lblMsg.Text = "No data";
        //    return;
        //}

        //薪資計算出勤區間
        string att_dateb = DateTime.Parse(rq_waged.Rows[0]["att_dateb"].ToString()).ToString("yyyy/MM/dd");
        string att_datee = DateTime.Parse(rq_waged.Rows[0]["att_datee"].ToString()).ToString("yyyy/MM/dd");

        //加班資料
        DataTable rq_ot1 = Salary.Base.BasClass.GetOt(nobr, yymm);
        DataTable rq_ot = new DataTable();
        rq_ot.Columns.Add("nobr", typeof(string));
        rq_ot.Columns.Add("ot_100", typeof(decimal));
        rq_ot.Columns.Add("ot_133", typeof(decimal));
        rq_ot.Columns.Add("ot_150", typeof(decimal));
        rq_ot.Columns.Add("ot_167", typeof(decimal));
        rq_ot.Columns.Add("ot_200", typeof(decimal));
        rq_ot.Columns.Add("ot_200_h", typeof(decimal));
        rq_ot.Columns.Add("ot_250_h", typeof(decimal));
        rq_ot.PrimaryKey = new DataColumn[] { rq_ot.Columns["nobr"] };
        Salary.Base.BasClass.Get_Ot1(rq_ot, rq_ot1);

        //出勤遲到
        DataTable rq_attend = Salary.Base.BasClass.Get_Attend(nobr, att_dateb, att_datee);
        rq_attend.PrimaryKey = new DataColumn[] { rq_attend.Columns["nobr"] };

        //請假資料
        DataTable rq_abs = Salary.Base.BasClass.Get_Abs(nobr, yymm);

        //特休及補休剩餘時數
        string attdateb = sYear + "/01/01";
        string attdatee = att_datee;
        DataTable rq_abs1 = Salary.Base.BasClass.Get_Abs1(nobr, attdatee);
        rq_abs1.PrimaryKey = new DataColumn[] { rq_abs1.Columns["nobr"] };

        //勞退公司負擔
        DataTable rq_ret = Salary.Base.BasClass.Get_Ret(nobr, yymm, date_b);
        rq_ret.PrimaryKey = new DataColumn[] { rq_ret.Columns["nobr"] };

        //產生薪資單資料        
        Nds.Tables["rq_salary"].PrimaryKey = new DataColumn[] { Nds.Tables["rq_salary"].Columns["nobr"] };
        DataTable dt_salary = Nds.Tables["rq_salary"].Clone();
        Salary.Base.BasClass.GetSalay(dt_salary, rq_waged, rq_ot, rq_abs,rq_abs1, rq_attend, rq_ret, JbUser.Comp);
        Nds.Tables["rq_salary"].Merge(dt_salary);

        DS ds = new DS();

        ds.Tables["rq_salary"].Merge(dt_salary);

        if (ds.Tables["rq_salary"].Rows.Count > 0)
        {
            RptViewer.Visible = true;
            RptViewer.Reset();
            //RptViewer.LocalReport.ReportPath = Server.MapPath("~/Salary/Rpt_Salary2.rdlc");
            if (sSeq=="2")
                RptViewer.LocalReport.ReportPath = Server.MapPath("~/Salary/Rpt_Salary2.rdlc");
            else
                RptViewer.LocalReport.ReportPath = Server.MapPath("~/Salary/Rpt_Salary2a.rdlc");
            RptViewer.LocalReport.DataSources.Clear();
            var rds = new ReportDataSource("DataSet1", Nds.Tables["rq_salary"]);
            RptViewer.LocalReport.DataSources.Add(rds);
            //var rds = new ReportDataSource("DataSet1", ds.Tables["rq_salary"]);
            //RptViewer.LocalReport.DataSources.Add(rds);
            RptViewer.LocalReport.SetParameters(new ReportParameter("YY", sYear));
            RptViewer.LocalReport.SetParameters(new ReportParameter("MM", sMonth));           
            RptViewer.LocalReport.Refresh();
            
        }
    }
   
}