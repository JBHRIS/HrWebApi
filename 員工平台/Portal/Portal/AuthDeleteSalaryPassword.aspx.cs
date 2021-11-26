using Bll.Salary.Vdb;
using Bll.System.Vdb;
using Dal.Dao.Salary;
using Bll.Tools;
using Dal.Dao.Attendance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.Design;
using Telerik.Web.UI;
using System.Text;


namespace Portal
{
    public partial class AuthDeleteSalaryPassword : WebPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                UnobtrusiveSession.Session["ActivePage"] = WebPage.GetActivePage;
                //ddlMenu_Databind();
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (txtEmpId.Text == "")
            {
                lblMsg.Text = "請輸入員工工號";
                lblMsg.CssClass = "badge badge-danger animated shake";
                return;
            }
            var oDeleteSalaryPassWord = new DeleteSalaryPassWordDao();
            var DeleteSalaryPasswordCond = new DeleteSalaryPassWordConditions();
            DeleteSalaryPasswordCond.AccessToken = _User.AccessToken;
            DeleteSalaryPasswordCond.RefreshToken = _User.RefreshToken;
            DeleteSalaryPasswordCond.CompanySetting = CompanySetting;
            DeleteSalaryPasswordCond.EmpId = txtEmpId.Text;
            var Result = oDeleteSalaryPassWord.GetData(DeleteSalaryPasswordCond);
            if (Result.Status)
            {
                lblMsg.Text = "刪除成功，請該員工重新設定密碼";
                lblMsg.CssClass = "badge badge-primary animated shake";
            }
            else
            {
                lblMsg.Text = "刪除失敗";
                lblMsg.CssClass = "badge badge-danger animated shake";
            }
        }
    } 
}