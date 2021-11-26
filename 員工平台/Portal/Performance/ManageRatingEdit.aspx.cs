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
    public partial class ManageRatingEdit : WebPageBase
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
                ddlRatingGroup_DataBind();
                _DataBind();

                LoadData(lblAutoKey.Text);
            }
        }

        public void ddlEmpCategory_DataBind()
        {
            var rs = oMainDao.ShareCodeTextValue("EmpCategory");

            ddlEmpCategory.DataSource = rs;
            ddlEmpCategory.DataTextField = "Text";
            ddlEmpCategory.DataValueField = "Value";
            ddlEmpCategory.DataBind();
        }

        public void ddlRatingGroup_DataBind()
        {
            var rs = (from c in dcMain.PerformanceRatingGroup
                      select new TextValueRow
                      {
                          Text = c.Name,
                          Value = c.Code,
                      }).ToList();

            TextValueRow tv = new TextValueRow();
            tv.Text = "無";
            tv.Value = "";
            rs.Add(tv);

            ddlRatingGroup.DataSource = rs;
            ddlRatingGroup.DataTextField = "Text";
            ddlRatingGroup.DataValueField = "Value";
            ddlRatingGroup.DataBind();
        }

        public void _DataBind()
        {

        }

        public void LoadData(string Key = "")
        {
            Key = Key.Length > 0 ? Key : "-1";
            var AutoKey = Convert.ToInt32(Key);

            var r = (from c in dcMain.PerformanceRating
                     where c.AutoKey == AutoKey
                     select c).FirstOrDefault();

            if (r != null)
            {
                ControlGetSet.SetDropDownList(ddlEmpCategory, r.EmpCategoryCode);
                txtCode.Text = r.Code;
                txtName.Text = r.Name;
                txtBonusPerMax.Text = r.BonusPerMax.ToString();
                txtBonusPerMin.Text = r.BonusPerMin.ToString();
                txtNumPerMax.Text = r.NumPerMax.ToString();
                txtNumPerMin.Text = r.NumPerMin.ToString();
                txtNumPer.Text = r.NumPer.ToString();
                txtSort.Text = r.Sort.ToString();
                txtNote.Text = r.Note;
                txtNum.Text = r.Num.ToString();
                cbCheckNote.Checked = r.CheckNote;
                ControlGetSet.SetDropDownList(ddlRatingGroup, r.PerformanceRatingGroupCode);

                //如果可以取得資料 則代碼不可以編輯
                ddlEmpCategory.Enabled = false;
                txtCode.Enabled = false;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string Key = lblAutoKey.Text.Length > 0 ? lblAutoKey.Text : "-1";
            var AutoKey = Convert.ToInt32(Key);

            var r = (from c in dcMain.PerformanceRating
                     where c.AutoKey == AutoKey
                     select c).FirstOrDefault();

            var CompCode = "A";
            var EmpCategoryCode = ddlEmpCategory.SelectedItem.Value;
            var Code = txtCode.Text;
            var Name = txtName.Text;
            var BonusPerMax = txtBonusPerMax.Text.ParseInt(100);
            var BonusPerMin = txtBonusPerMin.Text.ParseInt(75);
            var NumPerMax = txtNumPerMax.Text.ParseInt(94);
            var NumPerMin = txtNumPerMin.Text.ParseInt(65);
            var NumPer = txtNumPer.Text.ParseInt(90);
            var Sort = txtSort.Text.ParseInt(99);
            var Note = txtNote.Text;
            var Num = txtNum.Text.ParseInt(0);
            var CheckNote = cbCheckNote.Checked.Value;
            var RatingGroupCode = ddlRatingGroup.SelectedItem.Value;

            if (Code.Trim().Length == 0)
            {
                lblMsg.Text = "代碼為必填欄位";
                return;
            }

            if (Name.Trim().Length == 0)
            {
                lblMsg.Text = "名稱為必填欄位";
                return;
            }

            if (AutoKey == -1)
            {
                if (dcMain.PerformanceRating.Any(c => c.CompCode == CompCode && c.EmpCategoryCode == EmpCategoryCode && c.Code == Code))
                {
                    lblMsg.Text = "資料重複，請重新輸入";
                    return;
                }
            }

            if (r == null)
            {
                r = new PerformanceRating();
                r.CompCode = CompCode;
                r.EmpCategoryCode = EmpCategoryCode;
                r.Code = Code;
                r.InsertMan = _User.UserCode;
                r.InsertDate = DateTime.Now;
                dcMain.PerformanceRating.InsertOnSubmit(r);
            }

            r.Name = txtName.Text;
            r.BonusPerMax = BonusPerMax;
            r.BonusPerMin = BonusPerMin;
            r.NumPerMax = NumPerMax;
            r.NumPerMin = NumPerMin;
            r.NumPer = NumPer;
            r.Sort = Sort;
            r.Note = txtNote.Text;
            r.Num = Num;
            r.CheckNote = CheckNote;
            r.PerformanceRatingGroupCode = RatingGroupCode;
            r.UpdateMan = _User.UserCode;
            r.UpdateDate = DateTime.Now;

            dcMain.SubmitChanges();

            oMainDao.MessageLog("1", "頁面：" + WebPage.GetActivePage + "｜名稱：" + WebPage.GetParentInfo() + "｜內容：" + JsonConvert.SerializeObject(r), "", "Performance-儲存評等", "", _User.UserCode);

            Response.Redirect("ManageRating.aspx");
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