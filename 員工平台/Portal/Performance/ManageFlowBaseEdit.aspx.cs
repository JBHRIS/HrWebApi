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
using Telerik.Web.UI;


namespace Performance
{
    public partial class ManageFlowBaseEdit : WebPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                lblAutoKey.Text = "";
                if (Request.QueryString["AutoKey"] == null)
                {
                    UnobtrusiveSession.Session["AutoKey"] = null;
                    UnobtrusiveSession.Session["MainCode"] = null;
                }
                else
                    lblAutoKey.Text = (string)UnobtrusiveSession.Session["AutoKey"];

                if (UnobtrusiveSession.Session["AutoKey"] == null)
                    btnReturn_Click(null, null);

                _DataBind();
                ddlEmpCategory_DataBind();
                LoadData(lblAutoKey.Text);
            }
        }

        public void _DataBind()
        {
            var MainCode = (string)UnobtrusiveSession.Session["MainCode"];

            var rs = new List<TextValueRow>();

            var r = new TextValueRow();
            r.Text = "=====  無  =====";
            r.Value = "";
            rs.Add(r);

            var rs1 = (from c in dcMain.PerformanceDept
                       where c.PerformanceMainCode == MainCode
                       select new TextValueRow
                       {
                           Text = c.Name + "," + c.ManagerName + "," + c.ManagerId,
                           Value = c.Code,
                       }).ToList();

            rs.AddRange(rs1);
            ddlDept.DataSource = rs;
            ddlDept.DataTextField = "Text";
            ddlDept.DataValueField = "Value";
            ddlDept.DataBind();
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

        protected void ddlEmpCategory_SelectedIndexChanged(object sender, Telerik.Web.UI.DropDownListEventArgs e)
        {
            ddlRating_DataBind();
        }

        public void LoadData(string Key)
        {
            Key = Key.Length > 0 ? Key : "-1";
            var AutoKey = Convert.ToInt32(Key);

            var r = (from c in dcMain.PerformanceBase
                     where c.AutoKey == AutoKey
                     select c).FirstOrDefault();

            if (r != null)
            {
                txtEmpId.Text = r.EmpId;
                txtEmpName.Text = r.EmpName;

                ControlGetSet.SetDropDownList(ddlDept, r.PerformanceDeptCode);
                ControlGetSet.SetDropDownList(ddlEmpCategory, r.EmpCategoryCode);
                ddlRating_DataBind();
                txtJobName.Text = r.JobName;
                txtJoblName.Text = r.JoblName;
                txtWorkPerformance.Text = r.WorkPerformance.ToString();
                txtMannerEsteem.Text = r.MannerEsteem.ToString();
                txtAbilityEsteem.Text = r.AbilityEsteem.ToString();
                txtEncourage.Text = r.Encourage.ToString();
                txtTotalIntegrate.Text = r.TotalIntegrate.ToString();
                ControlGetSet.SetDropDownList(ddlRating, r.RatingCode);
                txtInWorkSpecific.Text = r.InWorkSpecific.ToString();
                txtBonusCardinal.Text = r.BonusCardinal.ToString();
                txtBonusTotal.Text = r.BonusTotal.ToString();
                txtBonusDeduct.Text = r.BonusDeduct.ToString();
                txtBonusMax.Text = r.BonusMax.ToString();
                txtBonusAdjust.Text = r.BonusAdjust.ToString();
                txtBonusReal.Text = r.BonusReal.ToString();
                cbExceptionBonusAll.Checked = r.ExceptionBonusAll;
                cbExceptionBonus.Checked = r.ExceptionBonus;
                cbExceptionNote.Checked = r.ExceptionNote;
                txtNote.Text = r.Note.ToString();
                lblUpdateMan.Text = r.UpdateMan;
                lblUpdateDate.Text = r.UpdateDate.ToString();

                //用料
                txtDateIn.SelectedDate = r.DateIn;
                txtAvgIntegrate.Text = r.AvgIntegrate.ToString();

                //年度
                txtG01.Text = r.G01.ToString();
                txtG02.Text = r.G02.ToString();
                txtG03.Text = r.G03.ToString();
                txtF01.Text = r.F01.ToString();
                txtF02.Text = r.F02.ToString();
                txtF03.Text = r.F03.ToString();
                txtSumAward.Text = r.SumAward.ToString();

                txtEmpId.Enabled = false;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string Key = lblAutoKey.Text.Length > 0 ? lblAutoKey.Text : "-1";
            var AutoKey = Convert.ToInt32(Key);

            var MainCode = (string)UnobtrusiveSession.Session["MainCode"];

            var r = (from c in dcMain.PerformanceBase
                     where c.AutoKey == AutoKey
                     select c).FirstOrDefault();

            //重新尋找工號 比對工號是否存在
            if (r != null)
            {
                var EmpId = r.EmpId;

                r = (from c in dcMain.PerformanceBase
                     where c.PerformanceMainCode == MainCode
                     && c.EmpId == EmpId
                     select c).FirstOrDefault();
            }

            if (r == null)
            {
                r = new PerformanceBase();
                r.PerformanceMainCode = MainCode;
                r.Code = Guid.NewGuid().ToString();


                r.JobCode = "";
                r.JoblCode = "";
                r.WorkCode = "";
                r.WorkName = "";
                r.CompCode = "";

                r.InsertMan = _User.UserCode;
                r.InsertDate = DateTime.Now;

                dcMain.PerformanceBase.InsertOnSubmit(r);

            }

            var DeptCode = "";
            if (ddlDept.SelectedItem != null)
                DeptCode = ddlDept.SelectedItem.Value;

            var EmpCategoryCode = "";
            if (ddlEmpCategory.SelectedItem != null)
                EmpCategoryCode = ddlEmpCategory.SelectedItem.Value;

            var RatingCode = "";
            if (ddlRating.SelectedItem != null)
                RatingCode = ddlRating.SelectedItem.Value;

            r.EmpId = txtEmpId.Text;
            r.EmpName = txtEmpName.Text;
            r.PerformanceDeptCode = DeptCode;
            r.JobName = txtJobName.Text;
            r.JoblName = txtJoblName.Text;
            r.EmpCategoryCode = EmpCategoryCode;
            r.WorkPerformance = txtWorkPerformance.Text.ParseInt(0);
            r.MannerEsteem = txtMannerEsteem.Text.ParseInt(0);
            r.AbilityEsteem = txtAbilityEsteem.Text.ParseInt(0);
            r.Encourage = txtEncourage.Text.ParseInt(0);
            r.TotalIntegrate = txtTotalIntegrate.Text.ParseInt(0);
            r.RatingCode = RatingCode;
            r.InWorkSpecific = txtInWorkSpecific.Text.ParseDecimal(0);
            r.BonusCardinal = txtBonusCardinal.Text.ParseInt(0);
            r.BonusTotal = txtBonusTotal.Text.ParseInt(0);
            r.BonusDeduct = txtBonusDeduct.Text.ParseInt(0);
            r.BonusMax = txtBonusMax.Text.ParseInt(0);
            r.BonusAdjust = txtBonusAdjust.Text.ParseInt(0);
            r.BonusReal = txtBonusReal.Text.ParseInt(0);
            r.ExceptionBonusAll = cbExceptionBonusAll.Checked.Value;
            r.ExceptionBonus = cbExceptionBonus.Checked.Value;
            r.ExceptionNote = cbExceptionNote.Checked.Value;
            r.Note = txtNote.Text;
            r.UpdateMan = _User.UserCode;
            r.UpdateDate = DateTime.Now;

            //用料
            r.DateIn = txtDateIn.SelectedDate.GetValueOrDefault(DateTime.Now.Date);
            r.AvgIntegrate = txtAvgIntegrate.Text.ParseDecimal(0);

            //年度
            r.G01 = txtG01.Text.ParseInt(0);
            r.G02 = txtG02.Text.ParseInt(0);
            r.G03 = txtG03.Text.ParseInt(0);
            r.G04 = 0;
            r.G05 = 0;
            r.F01 = txtF01.Text.ParseInt(0);
            r.F02 = txtF02.Text.ParseInt(0);
            r.F03 = txtF03.Text.ParseInt(0);
            r.F04 = 0;
            r.F05 = 0;
            r.SumAward = txtSumAward.Text.ParseDecimal(0);


            dcMain.SubmitChanges();

            oMainDao.MessageLog("1", "頁面：" + WebPage.GetActivePage + "｜名稱：" + WebPage.GetParentInfo() + "｜內容：" + JsonConvert.SerializeObject(r), "", "Performance-儲存員工資料", "", _User.UserCode);

            Response.Redirect("ManageFlowBase.aspx");
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