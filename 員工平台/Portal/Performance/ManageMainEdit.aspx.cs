using Bll;
using Bll.Tools;
using Dal;
using Dal.Dao;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Performance
{
    public partial class ManageMainEdit : WebPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                lblAutoKey.Text = "";
                if (Request.QueryString["AutoKey"] == null)
                {
                    UnobtrusiveSession.Session["AutoKey"] = null;
                }
                else
                    lblAutoKey.Text = (string)UnobtrusiveSession.Session["AutoKey"];

                ddlEmpCategory_DataBind();
                ddlType_DataBind();
                _DataBind();

                DateTime DateNow = DateTime.Now.Date.AddMonths(1);
                DateTime DateA = new DateTime(DateNow.Year, DateNow.Month, 1);
                DateTime DateD = new DateTime(DateNow.Year, DateNow.Month, DateTime.DaysInMonth(DateNow.Year, DateNow.Month));

                txtDateA.SelectedDate = DateA;
                txtDateD.SelectedDate = DateD;
                txtDateBase.SelectedDate = DateD;

                LoadData(lblAutoKey.Text);
            }
        }

        public void ddlType_DataBind()
        {
            var rs = oMainDao.ShareCodeTextValue("PerformanceType");

            ddlType.DataSource = rs;
            ddlType.DataTextField = "Text";
            ddlType.DataValueField = "Value";
            ddlType.DataBind();

            ddlYymm_DataBind();
        }

        public void ddlYymm_DataBind()
        {
            //var TypeCode = ddlType.SelectedItem.Value;

            //var oPerformance = new PerformanceDao(dcShare, dcMain, dcHr);
            //var rsView = oPerformance.GetYymm(TypeCode);

            //ddlYymm.DataSource = rsView;
            //ddlYymm.DataTextField = "Text";
            //ddlYymm.DataValueField = "Value";
            //ddlYymm.DataBind();

            var ListYear = new List<TextValueRow>();
            for (int Year = (oMainDao._NowDate.Year - 1); Year <= (oMainDao._NowDate.Year + 1); Year++)
            {
                var yy = Year.ToString();
                var rYear = new TextValueRow();
                rYear.Text = yy;
                rYear.Value = yy;
                ListYear.Add(rYear);
            }

            ddlYear.DataSource = ListYear;
            ddlYear.DataTextField = "Text";
            ddlYear.DataValueField = "Value";
            ddlYear.DataBind();

            if (ddlYear.FindItemByValue(oMainDao._NowDate.Year.ToString()) != null)
                ddlYear.FindItemByValue(oMainDao._NowDate.Year.ToString()).Selected = true;

            var ListMonth = new List<TextValueRow>();
            for (int Month = 1; Month <= 12; Month++)
            {
                var mm = Month.ToString("00");
                var rMonth = new TextValueRow();
                rMonth.Text = mm;
                rMonth.Value = mm;
                ListMonth.Add(rMonth);
            }

            ddlMonth.DataSource = ListMonth;
            ddlMonth.DataTextField = "Text";
            ddlMonth.DataValueField = "Value";
            ddlMonth.DataBind();

            if (ddlMonth.FindItemByValue(oMainDao._NowDate.Month.ToString("00")) != null)
                ddlMonth.FindItemByValue(oMainDao._NowDate.Month.ToString("00")).Selected = true;
        }

        public void ddlEmpCategory_DataBind()
        {
            var rs = oMainDao.ShareCodeTextValue("EmpCategory");

            ddlEmpCategory.DataSource = rs;
            ddlEmpCategory.DataTextField = "Text";
            ddlEmpCategory.DataValueField = "Value";
            ddlEmpCategory.DataBind();

            ddlRating_DataBind();
        }

        public void ddlRating_DataBind()
        {
            var EmpCategoryCode = ddlEmpCategory.SelectedItem.Value;

            var oPerformance = new PerformanceDao(dcShare, dcMain, dcHr);
            var rs = oPerformance.GetPerformanceRating(EmpCategoryCode);

            ddlRating.DataSource = rs;
            ddlRating.DataTextField = "Text";
            ddlRating.DataValueField = "Value";
            ddlRating.DataBind();
        }

        public void _DataBind()
        {
            var oPerformance = new PerformanceDao(dcShare, dcMain, dcHr);
            var rs = oPerformance.GetDeptLevel();

            ddlDeptTreeB.DataSource = rs;
            ddlDeptTreeB.DataTextField = "Text";
            ddlDeptTreeB.DataValueField = "Value";
            ddlDeptTreeB.DataBind();

            ddlDeptTreeE.DataSource = rs;
            ddlDeptTreeE.DataTextField = "Text";
            ddlDeptTreeE.DataValueField = "Value";
            ddlDeptTreeE.DataBind();
        }

        protected void ddlType_SelectedIndexChanged(object sender, Telerik.Web.UI.DropDownListEventArgs e)
        {
            ddlYymm_DataBind();
        }

        protected void ddlEmpCategory_SelectedIndexChanged(object sender, Telerik.Web.UI.DropDownListEventArgs e)
        {
            ddlRating_DataBind();
        }

        public void LoadData(string Key = "")
        {
            Key = Key.Length > 0 ? Key : "-1";
            var AutoKey = Convert.ToInt32(Key);

            var r = (from c in dcMain.PerformanceMain
                     where c.AutoKey == AutoKey
                     select c).FirstOrDefault();

            if (r != null)
            {
                ControlGetSet.SetDropDownList(ddlType, r.TypeCode);
                txtName.Text = r.Name;
                //ControlGetSet.SetDropDownList(ddlYymm, r.Yymm);
                var Yymm = r.Yymm;
                var Year = Yymm.Substring(0, 4);
                var Month = Yymm.Substring(4);
                ControlGetSet.SetDropDownList(ddlYear, Year);
                ControlGetSet.SetDropDownList(ddlMonth, Month);
                ControlGetSet.SetDropDownList(ddlEmpCategory, r.EmpCategoryCode);
                txtDateA.SelectedDate = r.DateA;
                txtDateD.SelectedDate = r.DateD;
                txtDateBase.SelectedDate = r.DateBase;
                txtSort.Text = r.Sort.ToString();
                ControlGetSet.SetDropDownList(ddlRating, r.PerformanceRatingCode);
                ControlGetSet.SetDropDownList(ddlDeptTreeB, r.DeptTreeB.ToString());
                ControlGetSet.SetDropDownList(ddlDeptTreeE, r.DeptTreeE.ToString());
                txtNote.Text = r.Note;

                ddlType.Enabled = false;
                //ddlYymm.Enabled = false;
                ddlYear.Enabled = false;
                ddlMonth.Enabled = false;
                ddlEmpCategory.Enabled = false;
                txtDateBase.Enabled = false;
                txtSort.Enabled = false;
                ddlDeptTreeB.Enabled = false;
                ddlDeptTreeE.Enabled = false;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string Key = lblAutoKey.Text.Length > 0 ? lblAutoKey.Text : "-1";
            var AutoKey = Convert.ToInt32(Key);

            var r = (from c in dcMain.PerformanceMain
                     where c.AutoKey == AutoKey
                     select c).FirstOrDefault();

            var Year = ddlYear.SelectedItem.Value;
            var Month = ddlMonth.SelectedItem.Value;

            //var Yymm = ddlYymm.SelectedItem.Value;
            var Yymm = Year + Month;
            var Seq = "1";
            var EmpCategory = ddlEmpCategory.SelectedItem.Value;
            var TypeCode = ddlType.SelectedItem.Value;

            if (AutoKey == -1)
            {
                if (dcMain.PerformanceMain.Any(c => c.Yymm == Yymm && c.TypeCode == TypeCode && c.Seq == Seq && c.EmpCategoryCode == EmpCategory))
                {
                    lblMsg.Text = "資料重複，請重新輸入";
                    return;
                }
            }

            if (r == null)
            {
                r = new PerformanceMain();
                r.Code = Guid.NewGuid().ToString();
                r.InsertMan = _User.UserCode;
                r.InsertDate = DateTime.Now;
                dcMain.PerformanceMain.InsertOnSubmit(r);
            }

            if (!txtDateA.SelectedDate.HasValue || !txtDateD.SelectedDate.HasValue)
            {
                lblMsg.Text = "生失效日為必填欄位";
                return;
            }

            r.Name = txtName.Text;
            r.Yymm = Yymm;
            r.Seq = Seq;
            r.TypeCode = TypeCode;
            r.EmpCategoryCode = EmpCategory;
            r.DateA = txtDateA.SelectedDate.Value;
            r.DateD = txtDateD.SelectedDate.Value;
            r.DateBase = txtDateBase.SelectedDate.GetValueOrDefault(r.DateD);
            r.Sort = txtSort.Text.ParseInt(9);
            r.PerformanceRatingCode = ddlRating.SelectedItem.Value;
            r.DeptTreeB = ddlDeptTreeB.SelectedItem.Value.ParseInt(50);
            r.DeptTreeE = ddlDeptTreeE.SelectedItem.Value.ParseInt(90);
            r.Note = txtNote.Text;
            r.UpdateMan = _User.UserCode;
            r.UpdateDate = DateTime.Now;

            dcMain.SubmitChanges();

            oMainDao.MessageLog("1", "頁面：" + WebPage.GetActivePage + "｜名稱：" + WebPage.GetParentInfo() + "｜內容：" + JsonConvert.SerializeObject(r), "", "Performance-儲存考核主檔", "", _User.UserCode);

            Response.Redirect("ManageMain.aspx");
        }

        protected void btnReturn_Click(object sender, EventArgs e)
        {
            if (UnobtrusiveSession.Session["ActivePage"] != null)
            {
                var ReturnPage = (string)UnobtrusiveSession.Session["ActivePage"];

                Response.Redirect(ReturnPage);
            }else
                Response.Redirect("Index.aspx");
        }
    }
}