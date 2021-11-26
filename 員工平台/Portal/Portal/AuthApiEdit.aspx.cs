using Bll.ApiVoid.Vdb;
using Bll.System.Vdb;
using Dal.Dao.ApiVoid;
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
    public partial class AuthApiEdit : WebPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                AuthApiEdit_DataBind();
            }
        }
        public void LoadData(string Key = "")
        {

        }

        public List<ApiVoidRow> GetApiVoid
        {
            get
            {
                var Value = new List<ApiVoidRow>();

                var oApiVoid = new ApiVoidDao();
                var ApiVoidCond = new ApiVoidConditions();
                ApiVoidCond.AccessToken = _User.AccessToken;
                ApiVoidCond.RefreshToken = _User.RefreshToken;
                ApiVoidCond.CompanySetting = CompanySetting;
                var rs = new List<ApiVoidRow>();

                var Result = oApiVoid.GetData(ApiVoidCond);
                if (Result.Status)
                {
                    if (Result.Data != null)
                    {
                        rs = Result.Data as List<ApiVoidRow>;
                        Value = rs;
                        UnobtrusiveSession.Session["ApiVoid"] = Value;
                    }
                }

                return Value;
            }
        }

        protected void AuthApiEdit_DataBind()
        {

            if (Request.QueryString["AutoKey"] == null)
            {
                return;
            }
            var Result = GetApiVoid;

            var rsList = (from Data in Result
                          where Data.Code == Request.QueryString["AutoKey"]
                          select Data).FirstOrDefault();
            if (rsList != null)
            {
                txtCode.Text = rsList.Code;
                txtRoutePath.Text = rsList.RoutePath;
                txtName.Text = rsList.Name;
            }
            else
            {
                lblMsg.CssClass = "badge badge-danger animated shake";
                lblMsg.Text = "資料載入錯誤，請稍後再試";
            }
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "" || txtRoutePath.Text == "")
            {
                lblMsg.CssClass = "badge badge-danger animated shake";
                lblMsg.Text = "請確認資料是否輸入正確";
                return;
            }
            if (Request.QueryString["AutoKey"] == null)
            {
                var oInsertApiVoid = new InsertApiVoidDao();
                var InsertApiVoidCond = new InsertApiVoidConditions();
                InsertApiVoidCond.AccessToken = _User.AccessToken;
                InsertApiVoidCond.RefreshToken = _User.RefreshToken;
                InsertApiVoidCond.CompanySetting = CompanySetting;
                InsertApiVoidCond.Code = txtCode.Text;
                InsertApiVoidCond.name = txtName.Text;
                InsertApiVoidCond.routePath = txtRoutePath.Text;
                var Result = oInsertApiVoid.GetData(InsertApiVoidCond);
                if (Result.Status)
                {
                    if (Result.Data != null)
                    {
                        var rs = Result.Data as InsertApiVoidRow;
                        if (rs.Result)
                        {
                            lblMsg.CssClass = "badge badge-primary animated shake";
                            lblMsg.Text = "新增成功";
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
                var oUpdateApiVoid = new UpdateApiVoidDao();
                var UpdateApiVoidCond = new UpdateApiVoidConditions();
                UpdateApiVoidCond.AccessToken = _User.AccessToken;
                UpdateApiVoidCond.RefreshToken = _User.RefreshToken;
                UpdateApiVoidCond.CompanySetting = CompanySetting;
                UpdateApiVoidCond.Code = txtCode.Text;
                UpdateApiVoidCond.name = txtName.Text;
                UpdateApiVoidCond.routePath = txtRoutePath.Text;

                var Result = oUpdateApiVoid.GetData(UpdateApiVoidCond);
                if (Result.Status)
                {
                    if (Result.Data != null)
                    {
                        var rs = Result.Data as UpdateApiVoidRow;
                        if (rs.Result)
                        {
                            lblMsg.CssClass = "badge badge-primary animated shake";
                            lblMsg.Text = "更新成功";
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
                    lblMsg.Text = "更新失敗，請確認資料是否輸入正確";
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