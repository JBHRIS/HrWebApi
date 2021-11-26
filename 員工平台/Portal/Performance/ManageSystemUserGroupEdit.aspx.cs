using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Bll.Share.Vdb;
using Dal;


namespace Performance
{
    public partial class ManageSystemUserGroupEdit : WebPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                if(Request.QueryString["AutoKey"] != null&& Request.QueryString["AutoKey"] != "0")
                {
                    var r = (from c in dcShare.SystemUserGroup
                             where c.AutoKey == Convert.ToInt32(Request.QueryString["AutoKey"])
                             select c).FirstOrDefault();
                    txtCode.Text = r.Code;
                    txtAuth.Text = r.RoleKey.ToString();
                    txtName.Text = r.Name;
                    txtSort.Text = r.Sort.ToString();
                }
            }
        }

        protected void btnReturn_Click(object sender, EventArgs e)
        {
            if (UnobtrusiveSession.Session["ActivePage"] != null)
            {
                var ReturnPage = (string)UnobtrusiveSession.Session["ActivePage"];

                Response.Redirect(ReturnPage);
            }
            else
                Response.Redirect("Index.aspx");
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if(txtAuth.Text == "" || txtCode.Text == "" || txtName.Text == "")
            {
                lblMsg.CssClass = "badge-danger badge";
                lblMsg.Text = "請確認資料是否輸入正確";
                return;
            }
            if (Request.QueryString["AutoKey"] != null && Request.QueryString["AutoKey"] != "0")
            {
                var r = (from c in dcShare.SystemUserGroup
                         where c.AutoKey == Convert.ToInt32(Request.QueryString["AutoKey"])
                         select c).FirstOrDefault();
                if(r!=null)
                {
                    r.Code = txtCode.Text;
                    r.Name = txtName.Text;
                    r.RoleKey = Convert.ToInt32(txtAuth.Text);
                    r.Sort = (txtSort.Text == "") ? 99 : Convert.ToInt32(txtSort.Text);
                    dcShare.SubmitChanges();
                    lblMsg.CssClass = "badge-primary badge";
                    lblMsg.Text = "更新成功";
                    if (UnobtrusiveSession.Session["ActivePage"] != null)
                    {
                        var ReturnPage = (string)UnobtrusiveSession.Session["ActivePage"];

                        Response.Redirect(ReturnPage);
                    }
                    else
                        Response.Redirect("Index.aspx");
                }
            }
            else
            {
                var oSystemUserGroup = new SystemUserGroup();
                oSystemUserGroup.Code = txtCode.Text;
                oSystemUserGroup.Name = txtName.Text;
                oSystemUserGroup.RoleKey = Convert.ToInt32(txtAuth.Text);
                oSystemUserGroup.InsertDate = DateTime.Now;
                oSystemUserGroup.InsertMan = _User.EmpName;
                oSystemUserGroup.DateA = DateTime.Now;
                oSystemUserGroup.DateD = DateTime.MaxValue;
                oSystemUserGroup.Status = "1";
                oSystemUserGroup.UpdateDate = DateTime.Now;
                oSystemUserGroup.UpdateMan = _User.EmpName;
                oSystemUserGroup.Sort = (txtSort.Text == "") ? 99 : Convert.ToInt32(txtSort.Text);
                dcShare.SystemUserGroup.InsertOnSubmit(oSystemUserGroup);
                dcShare.SubmitChanges();
                lblMsg.CssClass = "badge-primary badge";
                lblMsg.Text = "新增成功";
                if (UnobtrusiveSession.Session["ActivePage"] != null)
                {
                    var ReturnPage = (string)UnobtrusiveSession.Session["ActivePage"];

                    Response.Redirect(ReturnPage);
                }
                else
                    Response.Redirect("Index.aspx");
            }
        }
    }
}