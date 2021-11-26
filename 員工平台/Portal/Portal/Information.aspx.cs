using Bll.BillBoard.Vdb;
using Dal.Dao.BillBoard;
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
using Dal.Dao.Share;
using Dal.Dao.Token;
using Bll.Token.Vdb;

namespace Portal
{
    public partial class Information : WebPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                lblAccessToken.Text = "AccessToken:" + _User.AccessToken;
                lblRefreshToken.Text = "RefreshToken:" + _User.RefreshToken;
                lblEmpID.Text = "員工工號:" + _User.EmpId;
                lblEmpName.Text = "員工姓名:" + _User.EmpName;
                if (Request.Cookies["CompanyId"] != null && Request.Cookies["CompanyId"].Value != "")
                {
                    var oShareCompany = new ShareCompanyDao();
                    var CompanySetting = oShareCompany.GetCompanySetting(Request.Cookies["CompanyId"].Value);

                    this.CompanySetting = CompanySetting;
                    var oConnection = new ConnectionDao();
                    var ConnectionCondition = new ConnectionConditions();
                    ConnectionCondition.DbName = CompanySetting.HrApiConnection;
                    var LoginTokenResult = oConnection.GetData(ConnectionCondition);
                    var LoginToken = LoginTokenResult.Payload.ToString();
                    lblConnectionToken.Text = "ConnectionToken:" + LoginToken;
                }
            }
        }


    }
}