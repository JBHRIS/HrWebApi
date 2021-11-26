using Bll.UserRole.Vdb;
using Bll.Employee.Vdb;
using Bll;
using Dal.Dao.UserRole;
using Dal.Dao.Employee;
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
    public partial class AuthUserView : WebPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                UnobtrusiveSession.Session["ActivePage"] = WebPage.GetActivePage;
                cblRole_DataBind();
                ddlUser_DataBind();

            }
        }
        public void LoadData(string Key = "")
        {

        }

        protected void cblRole_DataBind()
        {
            var rs = AccessData.GetRoleList(_User, CompanySetting);
            //cblRole.DataSource = rs;
            //cblRole.DataBindings.DataTextField = "Name";
            //cblRole.DataBindings.DataValueField = "Code";
            //cblRole.DataBind();
        }

        protected void ddlUser_DataBind()
        {
            var rsData = new List<PeopleRow>();
            var oPeople = new PeopleDao();
            var PeopleCond = new PeopleConditions();
            PeopleCond.AccessToken = _User.AccessToken;
            PeopleCond.RefreshToken = _User.RefreshToken;
            PeopleCond.CompanySetting = CompanySetting;
            var Result = oPeople.GetData(PeopleCond);
            if (Result.Status)
            { 
                if(Result.Data!=null)
                    rsData = Result.Data as List<PeopleRow>;

            }
            var rs = new List<TextValueRow>();
            if (rsData != null)
            {
                foreach (var rData in rsData)
                {
                    var r = new TextValueRow();
                    r.Text = r.Text = rData.EmpName + "," + rData.EmpId;
                    r.Value = rData.EmpId;
                    rs.Add(r);
                }
            }
            ddlEmp.DataSource = rs;
            ddlEmp.DataTextField = "Text";
            ddlEmp.DataValueField = "Value";
            ddlEmp.DataBind();
        }


        protected void btnEdit_Click(object sender, EventArgs e)
        {
            if (ddlEmp.SelectedValue == "")
            {
                lblMsg.CssClass = "badge badge-danger animated shake";
                lblMsg.Text = "請選擇員工";
                return;
            }

            var User = ddlEmp.SelectedValue;
            var Nobr = new List<string>();
            Nobr.Add(User);

            var NewLeftRow = new TableRow();
           
            
            var MenuRow = AccessData.GetMenuList(_User,CompanySetting);
            foreach(var MenuData in MenuRow)
            {
                var NewLeftCell = new TableCell();
                var NewLeftLabel = new Label();
                NewLeftLabel.Text = MenuData.FileTitle;
                NewLeftCell.Controls.Add(NewLeftLabel);
                NewLeftRow.Cells.Add(NewLeftCell);
            }
            tbUserView.Rows.Add(NewLeftRow);

            var rs = new List<UserRoleRow>();
            var oUserRole = new UserRoleDao();
            var UserRoleCond = new UserRoleConditions();
            UserRoleCond.AccessToken = _User.AccessToken;
            UserRoleCond.RefreshToken = _User.RefreshToken;
            UserRoleCond.CompanySetting = CompanySetting;
            UserRoleCond.nobr = Nobr;
            var Result = oUserRole.GetData(UserRoleCond);

            if (Result.Status)
            {
                if (Result.Data != null)
                {
                    rs = Result.Data as List<UserRoleRow>;
                    foreach (var r in rs[0].roleCode)
                    {
                        var NewRow = new TableRow();
                        var NewCell = new TableCell();
                        var NewCheckBox = new CheckBox();
                        var NewLabel = new Label();
                        NewLabel.Text = r;
                        NewCell.Controls.Add(NewLabel);
                        NewCell.Controls.Add(NewCheckBox);
                        NewRow.Cells.Add(NewCell);
                        tbUserView.Rows.Add(NewRow);
                    }
                }
            }
        }

        protected void ddlEmp_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            
        }


        protected void lvUserView_NeedDataSource(object sender, RadListViewNeedDataSourceEventArgs e)
        {
            
        }
    } 
}