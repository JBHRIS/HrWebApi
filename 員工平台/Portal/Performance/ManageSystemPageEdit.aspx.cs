using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Bll.System.Vdb;
using Bll.Tools;
using Dal;

namespace Performance
{
    public partial class ManageSystemPageEdit : WebPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                var PageRowList = new List<SystemPageRow>();
                var Value = (from c in dcShare.SystemPage
                             where c.Href == true && c.TypeCode == "02"
                             orderby c.Sort
                             select c).ToList();
                var ListId = new Dictionary<string, int>();
                //處理代碼資料
                int i = 1;
                //轉換成Tree的結構
                foreach (var rTrans in Value)
                {
                    var PageRow = new SystemPageRow();
                    PageRow.Code = rTrans.Code;
                    PageRow.ParentCode = rTrans.ParentCode;
                    PageRow.FileTitle = rTrans.FileTitle;
                    PageRowList.Add(PageRow);
                }
                //將parentCode轉成字典檔
                foreach (var rCode in PageRowList)
                {
                    ListId.Add(rCode.Code, i);
                    rCode.CodeId = i;
                    i++;
                }
                foreach (var r in PageRowList)
                {
                    //將上層的代碼轉換為id
                    if (ListId.ContainsKey(r.ParentCode))
                        r.ParentId = ListId[r.ParentCode];
                    else
                        r.ParentId = 0;  //如果沒有找到 就以0取代
                }
                ddlParentCode.DataSource = PageRowList;
                ddlParentCode.DataValueField = "Code";
                ddlParentCode.DataTextField = "FileTitle";
                ddlParentCode.DataFieldID = "CodeId";
                ddlParentCode.DataFieldParentID = "ParentId";
                ddlParentCode.DataBind();

                ddlParentCode.ExpandAllDropDownNodes();
                if (Request.QueryString["AutoKey"] != null && Request.QueryString["AutoKey"] != "0")
                {
                    var r = (from c in dcShare.SystemPage
                             where c.AutoKey == Convert.ToInt32(Request.QueryString["AutoKey"])
                             select c).FirstOrDefault();
                    txtCode.Text = r.Code;
                    txtFileName.Text = r.FileName;
                    txtFileTitle.Text = r.FileTitle;
                    txtIcon.Text = r.Icon;
                    txtSort.Text = r.Sort.ToString();
                    txtRoleKey.Text = r.RoleKey.ToString();
                    ddlParentCode.SelectedValue = r.ParentCode;
                    isHref.Checked = r.Href;
                    isOpenWindow.Checked = r.OpenWindow;
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
            if (txtCode.Text == "" || txtFileName.Text == "" || txtFileTitle.Text == "" || txtRoleKey.Text == "")
            {
                lblMsg.CssClass = "badge-danger badge";
                lblMsg.Text = "請確認資料是否輸入正確";
                return;
            }
            if (Request.QueryString["AutoKey"] != null && Request.QueryString["AutoKey"] != "0")
            {
                var r = (from c in dcShare.SystemPage
                         where c.AutoKey == Convert.ToInt32(Request.QueryString["AutoKey"])
                         select c).FirstOrDefault();
                if (r != null)
                {
                    r.Code = txtCode.Text;
                    r.FileName = txtFileName.Text;
                    r.FileTitle = txtFileTitle.Text;
                    r.RoleKey = Convert.ToInt32(txtRoleKey.Text);
                    r.ParentCode = ddlParentCode.SelectedValue;
                    r.Icon = txtIcon.Text;
                    r.Sort = Convert.ToInt32(txtSort.Text);
                    r.Href = (bool)isHref.Checked;
                    r.OpenWindow = (bool)isOpenWindow.Checked;
                    r.UpdateMan = _User.EmpName;
                    r.UpdateDate = DateTime.Now;
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
                var oSystemUser = new SystemPage();
                oSystemUser.Code = txtCode.Text;
                oSystemUser.FileName = txtFileName.Text;
                oSystemUser.FileTitle = txtFileTitle.Text;
                oSystemUser.SystemCode = "Performance";
                oSystemUser.TypeCode = "02";
                oSystemUser.RoleKey = Convert.ToInt32(txtRoleKey.Text);
                oSystemUser.ParentCode = ddlParentCode.SelectedValue;
                oSystemUser.Href = (bool)isHref.Checked;
                oSystemUser.OpenWindow = (bool)isOpenWindow.Checked;
                oSystemUser.Icon = txtIcon.Text;
                oSystemUser.Sort = Convert.ToInt32(txtSort.Text);
                oSystemUser.InsertDate = DateTime.Now;
                oSystemUser.InsertMan = _User.EmpName;
                oSystemUser.Status = "1";
                oSystemUser.UpdateDate = DateTime.Now;
                oSystemUser.UpdateMan = _User.EmpName;
                dcShare.SystemPage.InsertOnSubmit(oSystemUser);
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