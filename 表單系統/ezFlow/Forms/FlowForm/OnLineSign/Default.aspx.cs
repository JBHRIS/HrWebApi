using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dal.Dao.Bas;
using Dal.Dao.Att;
using Bll.Att.Vdb;

public partial class OnLineSign_Default : System.Web.UI.Page
{
    dcFlowDataContext dcFlow = new dcFlowDataContext();
    dcHRDataContext dcHR = new dcHRDataContext();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            txtNobr.Text = Request.QueryString["idEmp_Start"] != null ? Request.QueryString["idEmp_Start"].ToUpper() : txtNobr.Text;

            if (User.Identity.IsAuthenticated && User.Identity.Name.Trim().Length > 0)
            {
                txtNobr.Text = User.Identity.Name;
                Session["Emp_id"] = User.Identity.Name.Trim();
                Response.Cookies["ezFlow"]["Emp_id"] = User.Identity.Name.Trim();
                Response.Cookies["ezFlow"].Expires = DateTime.Now.AddDays(1);
            }

            txtNobr.Text = txtNobr.Text.Trim().Length == 0 ? " " : txtNobr.Text;

            lblIP.Text = GetClientIP();
            //lblIP.Text = "127.0.0.1";

            string conn = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["HR"].ConnectionString;
            IpControlDao oIpControlDao = new Dal.Dao.Bas.IpControlDao(conn);
            var rsIp = oIpControlDao.GetData(lblIP.Text);

            btnSign.Enabled = rsIp.Any();

            lblMsg.Text = btnSign.Enabled ? "" : "如果您IP位置不正確，將無法線上簽核，請洽人事單位";
        }

        //Response.Write("<script language=javascript>function show() { var curTime = new Date(); document.forms['aspnetForm'].getElementById(\"Time\").innerHTML = curTime.toLocaleString(); setTimeout(\"show()\", 1000) };show();</script> ");
    }
    protected void btnSign_Click(object sender, EventArgs e)
    {
        string sIP = GetClientIP();
        DateTime dDate = DateTime.Now;

        var rEmp = (from c in dcFlow.Emp
                    where c.id == txtNobr.Text.Trim()
                    //&& c.pw == txtPass.Text.Trim()
                    //&& txtPass.Text == "1234"
                    select c).FirstOrDefault();

        if (rEmp == null)
        {
            lblMsg.Text = "工號或密碼不正確";
            //ScriptManager.RegisterStartupScript(updatePanel, typeof(UpdatePanel), "key", "alert('" + lblMsg.Text + "');", true);
            return;
        }

        string conn = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["HR"].ConnectionString;
        IpControlDao oIpControlDao = new Dal.Dao.Bas.IpControlDao(conn);
        var rsIp = oIpControlDao.GetData(lblIP.Text);

        if (!rsIp.Any())
        {
            lblMsg.Text = "IP位置不正確";
            //ScriptManager.RegisterStartupScript(updatePanel, typeof(UpdatePanel), "key", "alert('" + lblMsg.Text + "');", true);
            return;
        }

        CardDao oCardDao = new Dal.Dao.Att.CardDao(conn);
        var rsCard = oCardDao.GetData(txtNobr.Text, dDate.Date);

        rsCard = (from c in rsCard
                  where c.DateA.Date.AddMinutes(JBHR.Dll.Tools.ConvertHhMmToMinutes(c.OnTime)) >= dDate.AddMinutes(-5)
                  && c.DateA.Date.AddMinutes(JBHR.Dll.Tools.ConvertHhMmToMinutes(c.OnTime)) <= dDate
                  select c).ToList();

        if (rsCard.Any())
        {
            lblMsg.Text = "5分鐘內有相同的刷卡記錄";
            //ScriptManager.RegisterStartupScript(updatePanel, typeof(UpdatePanel), "key", "alert('" + lblMsg.Text + "');", true);
            return;
        }

        CardRow rCard = new Bll.Att.Vdb.CardRow();
        rCard.Nobr = txtNobr.Text.Trim();
        rCard.DateA = dDate.Date;
        rCard.OnTime = JBHR.Dll.Tools.SplitTimeToHhMm(dDate);
        rCard.KeyMan = txtNobr.Text.Trim();
        rCard.NotTran = false;
        rCard.Reason = "";
        rCard.Los = false;
        rCard.IpAdd = lblIP.Text;
        rCard.Note = "OnLineSign";
        rCard.Serno = Guid.NewGuid().ToString();
        bool bSave = oCardDao.Save(rCard);

        if (bSave)
        {
            lblTime.Text = dDate.ToString();
            lblMsg.Text = "簽到完成，時間是：" + dDate.ToString();
        }
    }

    //取得Client端的IP位址
    public static string GetClientIP()
    {
        string strIpAddr = string.Empty;
        if (HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"] == null || HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"].IndexOf("unknown") > 0)
        {
            strIpAddr = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
        }
        else if (HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"].IndexOf(",") > 0)
        {
            strIpAddr = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"].Substring(1, HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"].IndexOf(",") - 1);
        }
        else if (HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"].IndexOf(";") > 0)
        {
            strIpAddr = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"].Substring(1, HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"].IndexOf(";") - 1);
        }
        else
        {
            strIpAddr = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
        }

        return strIpAddr;
    }
}