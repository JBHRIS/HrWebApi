using Bll.Menu.Vdb;
using Bll.System.Vdb;
using Dal.Dao.Menu;
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
    public partial class AuthMenuEdit : WebPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                ParentCode_DataBind();
                AuthMenuEdit_DataBind();
            }
        }
        public void LoadData(string Key = "")
        {

        }
        protected void ParentCode_DataBind()
        {
            var Value = new List<SystemPageRow>();
            if (WebPage.DataCache && UnobtrusiveSession.Session["ParentCode"] != null)
            {
                Value = (List<SystemPageRow>)UnobtrusiveSession.Session["ParentCode"];
            }
            else
            {

                //var oMenu = new MenuDao();
                //var MenuCond = new MenuConditions();
                //MenuCond.AccessToken = _User.AccessToken;
                //MenuCond.RefreshToken = _User.RefreshToken;
                //MenuCond.code = "Menu";
                //var rs = new List<MenuRow>();

                //var Result = oMenu.GetData(MenuCond);
                //if (Result.Status)
                //{
                //    if (Result.Data != null)
                //    {
                //        rs = Result.Data as List<MenuRow>;
                //    }
                //}
                var rs = AccessData.GetMenuList(_User, CompanySetting) ;
                var rSystemPage = new SystemPageRow();
                foreach (var rTarget in rs)
                {
                    rSystemPage = new SystemPageRow();
                    rSystemPage.TypeCode = rTarget.TypeCode;
                    rSystemPage.TypeName = rTarget.TypeName;
                    rSystemPage.Code = rTarget.Code;
                    rSystemPage.FilePath = rTarget.FilePath;
                    rSystemPage.FileName = rTarget.FileName;
                    rSystemPage.FileTitle = rTarget.FileTitle;
                    rSystemPage.RoleKey = rTarget.RoleKey;
                    rSystemPage.ParentCode = rTarget.ParentCode;
                    rSystemPage.PathCode = rTarget.PathCode;
                    rSystemPage.PathName = rTarget.PathName;
                    rSystemPage.IsAuth = rTarget.IsAuth;
                    rSystemPage.OpenWindow = rTarget.OpenWindow;
                    Value.Add(rSystemPage);
                }
                UnobtrusiveSession.Session["ParentCode"] = Value;
            }

            var ListId = new Dictionary<string, int>();
            //處理代碼資料
            int i = 1;
            foreach (var rVdb in Value)
            {
                //產生id
                ListId.Add(rVdb.Code, i);
                rVdb.CodeId = i;

                i++;
            }

            foreach (var r in Value)
            {
                //將上層的代碼轉換為id
                if (ListId.ContainsKey(r.ParentCode))
                    r.ParentId = ListId[r.ParentCode];
                else
                    r.ParentId = 0;  //如果沒有找到 就以0取代
            }

            ddlParent.DataSource = Value;
            ddlParent.DataValueField = "Code";
            ddlParent.DataTextField = "FileTitle";
            ddlParent.DataFieldID = "CodeId";
            ddlParent.DataFieldParentID = "ParentId";
            ddlParent.DataBind();

            ddlParent.ExpandAllDropDownNodes();
        }
        protected void AuthMenuEdit_DataBind()
        {
            if ((Request.QueryString["InsertKey"] != null))
            {
                ddlParent.SelectedValue = Request.QueryString["InsertKey"];
            }
            if (Request.QueryString["AutoKey"] == null && Request.QueryString["Copy"] == null)
            {
                return;
            }
            var Result = AccessData.GetMenuList(_User,CompanySetting);

            var rsData = (from Data in Result
                          where Data.Code == Request.QueryString["AutoKey"] || Data.Code == Request.QueryString["Copy"]
                          select new
                          {
                              code = Data.Code,
                              parentCode = Data.ParentCode,//parentKey
                              tag = Data.Tag,
                              fileName = Data.FileName,
                              fileTitle = Data.FileTitle,
                              iconName = Data.TypeName,
                              iOrder = Data.Order,
                              openNew = Data.OpenWindow
                          }).FirstOrDefault();
            txtCode.Text = rsData.code;
            ddlParent.SelectedValue = rsData.parentCode;
            txtTag.Text = rsData.tag;
            txtOrder.Text = rsData.iOrder.ToString();
            txtFileName.Text = rsData.fileName;
            txtFileTitle.Text = rsData.fileTitle;
            txtIconName.Text = rsData.iconName;
            cbOpen.Checked = rsData.openNew;
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (txtCode.Text == "" || txtFileTitle.Text == "")
            {
                lblMsg.CssClass = "badge badge-danger animated shake";
                lblMsg.Text = "請確認資料是否輸入正確";
                return;
            }
            if (Request.QueryString["AutoKey"] == null)
            {
                var oInsertMenu = new InsertMenuDao();
                var InsertMenuCond = new InsertMenuConditions();
                InsertMenuCond.AccessToken = _User.AccessToken;
                InsertMenuCond.RefreshToken = _User.RefreshToken;
                InsertMenuCond.CompanySetting = CompanySetting;
                InsertMenuCond.Code = txtCode.Text;
                InsertMenuCond.sPath = "";
                InsertMenuCond.sFileName = txtFileName.Text;
                InsertMenuCond.sFileTitle = txtFileTitle.Text;
                InsertMenuCond.sParentKey = ddlParent.SelectedValue;
                InsertMenuCond.iconName = txtIconName.Text;
                InsertMenuCond.iconPath = "";
                InsertMenuCond.sidePath = "";
                InsertMenuCond.tag = txtTag.Text;//描述
                InsertMenuCond.iOrder = (txtOrder.Text != null && txtOrder.Text != "")? Convert.ToInt32(txtOrder.Text):99;
                InsertMenuCond.keyMan = _User.EmpName;
                InsertMenuCond.keyDate = DateTime.Now;
                InsertMenuCond.noticeContent = "";
                InsertMenuCond.noticeTtile = "";
                InsertMenuCond.displayNotice = false;
                InsertMenuCond.openNewWin = (bool)cbOpen.Checked;
                var Result = oInsertMenu.GetData(InsertMenuCond);
                if (Result.Status)
                {
                    if (Result.Data != null)
                    {
                        var rs = Result.Data as InsertMenuRow;
                        if (rs.Result)
                        {
                            lblMsg.CssClass = "badge badge-primary animated shake";
                            lblMsg.Text = "新增成功";
                            UnobtrusiveSession.Session["SystemPage"] = null;
                            UnobtrusiveSession.Session["MenuRow"] = null;
                            if (UnobtrusiveSession.Session["ActivePage"] != null)
                            {
                                var ReturnPage = (string)UnobtrusiveSession.Session["ActivePage"];

                                Response.Redirect(ReturnPage);
                            }
                            else
                                Response.Redirect("Index.aspx");
                        }
                        else
                        {
                            lblMsg.CssClass = "badge badge-danger animated shake";
                            lblMsg.Text = "新增失敗，請確認資料是否輸入正確";
                        }
                    }
                }
                else
                {
                    lblMsg.CssClass = "badge badge-danger animated shake";
                    lblMsg.Text = "新增失敗，請確認資料是否輸入正確";
                }
            }
            else
            {
                var oUpdateMenu = new UpdateMenuDao();
                var UpdateMenuCond = new UpdateMenuConditions();
                UpdateMenuCond.AccessToken = _User.AccessToken;
                UpdateMenuCond.RefreshToken = _User.RefreshToken;
                UpdateMenuCond.CompanySetting = CompanySetting;
                UpdateMenuCond.Code = txtCode.Text;
                UpdateMenuCond.sPath = "";
                UpdateMenuCond.sFileName = txtFileName.Text;
                UpdateMenuCond.sFileTitle = txtFileTitle.Text;
                UpdateMenuCond.sidePath = "";
                UpdateMenuCond.sParentKey = ddlParent.SelectedValue;
                UpdateMenuCond.iconPath = "";
                UpdateMenuCond.iconName = txtIconName.Text;
                UpdateMenuCond.tag = txtTag.Text;
                UpdateMenuCond.noticeContent = "";
                UpdateMenuCond.noticeTtile = "";
                UpdateMenuCond.displayNotice = false;
                UpdateMenuCond.iOrder = Convert.ToInt32(txtOrder.Text);
                UpdateMenuCond.keyMan = _User.EmpName;
                UpdateMenuCond.keyDate = DateTime.Now;
                UpdateMenuCond.openNewWin = (bool)cbOpen.Checked;
                var Result = oUpdateMenu.GetData(UpdateMenuCond);
                if (Result.Status)
                {
                    if (Result.Data != null)
                    {
                        var rs = Result.Data as UpdateMenuRow;
                        if (rs.Result)
                        {
                            lblMsg.CssClass = "badge badge-primary animated shake";
                            lblMsg.Text = "更新成功";
                            UnobtrusiveSession.Session["SystemPage"] = null;
                            UnobtrusiveSession.Session["MenuRow"] = null;

                            if (UnobtrusiveSession.Session["ActivePage"] != null)
                            {
                                var ReturnPage = (string)UnobtrusiveSession.Session["ActivePage"];

                                Response.Redirect(ReturnPage);
                            }
                            else
                                Response.Redirect("Index.aspx");
                        }
                        else
                        {
                            lblMsg.CssClass = "badge badge-danger animated shake";
                            lblMsg.Text = "更新失敗，請確認資料是否輸入正確";
                        }
                    }
                }
                else
                {
                    lblMsg.CssClass = "badge badge-danger animated shake";
                    lblMsg.Text = "新增失敗，請確認資料是否輸入正確";
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

        
    } 
}