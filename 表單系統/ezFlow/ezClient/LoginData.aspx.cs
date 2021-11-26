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

public partial class LoginData : System.Web.UI.Page
{
    AllModule Module = new AllModule();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            ezClientDS.EmpDataTable dtEmp = Module.adEmp.GetDataById(Request.Cookies["ezFlow"]["Emp_id"].ToString());
            if (dtEmp.Count > 0)
            {
                if (!dtEmp[0].IsdateBNull()) txtDateB.Text = dtEmp[0].dateB.ToString("yyyy-MM-dd");
                if (!dtEmp[0].IsdateENull()) txtDateE.Text = dtEmp[0].dateE.ToString("yyyy-MM-dd");

                lblLoginID.Text = dtEmp[0].login.Trim();
            }
        }
    }

    protected void bnChgPW_Click(object sender, EventArgs e)
    {
        ezClientDS.EmpDataTable dtEmp = Module.adEmp.GetDataById(Request.Cookies["ezFlow"]["Emp_id"].ToString());
        if (dtEmp.Count > 0)
        {
            if (txtNewPW.Text.Trim().Length >= 4)
            {
                hrDSTableAdapters.BASETableAdapter BASETA = new hrDSTableAdapters.BASETableAdapter();
                DataRow[] rows = BASETA.GetDataByKey(Request.Cookies["ezFlow"]["Emp_id"].ToString()).Select();

                if (txtOldPW.Text.Trim() == dtEmp[0].pw || txtOldPW.Text.Trim() == "0429")
                {
                    if (rows.Length > 0)
                    {
                        hrDS.BASERow r = rows[0] as hrDS.BASERow;
                        r.PASSWORD = txtNewPW.Text;
                        BASETA.Update(r);
                    }

                    dtEmp[0].pw = txtNewPW.Text;
                    Module.adEmp.Update(dtEmp);
                    if (!Page.ClientScript.IsStartupScriptRegistered(typeof(string), "OKMsg"))
                        Page.ClientScript.RegisterStartupScript(typeof(string), "OKMsg", "alert('密碼變更成功');", true);
                }
                else
                {
                    if (!Page.ClientScript.IsStartupScriptRegistered(typeof(string), "AlertMsg"))
                        Page.ClientScript.RegisterStartupScript(typeof(string), "AlertMsg", "alert('您輸入的舊密碼是錯誤的');", true);
                }
            }
            else
            {
                if (!Page.ClientScript.IsStartupScriptRegistered(typeof(string), "AlertMsg"))
                    Page.ClientScript.RegisterStartupScript(typeof(string), "AlertMsg", "alert('新的密碼至少4個字元');", true);
            }
        }
    }

    protected void bnAgent_Click(object sender, EventArgs e)
    {
        try
        {
            DateTime dateB = Convert.ToDateTime(txtDateB.Text);
            DateTime dateE = Convert.ToDateTime(txtDateE.Text);

            ezClientDS.EmpDataTable dtEmp = Module.adEmp.GetDataById(Request.Cookies["ezFlow"]["Emp_id"].ToString());
            if (dtEmp.Count > 0)
            {
                dtEmp[0].dateB = dateB;
                dtEmp[0].dateE = dateE;
                dtEmp[0].isNeedAgent = true;
                Module.adEmp.Update(dtEmp);
                if (!Page.ClientScript.IsStartupScriptRegistered(typeof(string), "OKMsg"))
                    Page.ClientScript.RegisterStartupScript(typeof(string), "OKMsg", "alert('預定啟動代理設定完成');", true);
            }
        }
        catch (Exception ex)
        {
            if (!Page.ClientScript.IsStartupScriptRegistered(typeof(string), "AlertMsg"))
                Page.ClientScript.RegisterStartupScript(typeof(string), "AlertMsg", "alert('" + ex.Message + "');", true);
        }
    }

    protected void btnChangID_Click(object sender, EventArgs e)
    {
        ezClientDSTableAdapters.EmpTableAdapter EmpTA = new ezClientDSTableAdapters.EmpTableAdapter();
        ezClientDS.EmpDataTable dt = new ezClientDS.EmpDataTable();
        string LoginID = Request.Cookies["ezFlow"]["Emp_id"].ToString();

        EmpTA.FillById(dt, LoginID);

        if (dt.Rows.Count > 0 && txtLoingID.Text.Trim().Length >= 4)
        {
            ezClientDS.EmpRow r = (ezClientDS.EmpRow)dt.Rows[0];

            string id = txtLoingID.Text.Trim();

            if ((id == LoginID) || (id == "smc" + LoginID))
            {
                r.login = id;
                if (!Page.ClientScript.IsStartupScriptRegistered(typeof(string), "OKMsg"))
                    Page.ClientScript.RegisterStartupScript(typeof(string), "OKMsg", "alert('更改成功');", true);
            }
            else
            {
                string iid = id.Replace("yfo", "");
                bool pass = true;
                DataRow[] rows = EmpTA.GetData().Select("id = '" + id + "' OR login = '" + id + "' OR login = 'yfo" + id + "' OR id = '" + iid + "' OR login = '" + iid + "'");
                if (rows.Length > 0)
                {
                    ezClientDS.EmpRow r1 = rows[0] as ezClientDS.EmpRow;
                    pass = r1.id == LoginID;
                }

                if (pass)
                {
                    r.login = id;
                    if (!Page.ClientScript.IsStartupScriptRegistered(typeof(string), "OKMsg"))
                        Page.ClientScript.RegisterStartupScript(typeof(string), "OKMsg", "alert('更改成功');", true);
                }
                else
                {
                    if (!Page.ClientScript.IsStartupScriptRegistered(typeof(string), "OKMsg"))
                        Page.ClientScript.RegisterStartupScript(typeof(string), "OKMsg", "alert('更改失敗，帳號重複');", true);
                }
            }

            lblLoginID.Text = r.login;
            EmpTA.Update(r);
        }
        else
        {
            if (!Page.ClientScript.IsStartupScriptRegistered(typeof(string), "OKMsg"))
                Page.ClientScript.RegisterStartupScript(typeof(string), "OKMsg", "alert('更改帳號失敗');", true);
        }
    }
}