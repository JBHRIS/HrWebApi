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
    public partial class ManageReportTypeEdit : WebPageBase
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
                ddlJob_DataBind();
                ddlDept_DataBind();
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

        public void ddlJob_DataBind()
        {
            var rs = (from c in dcHr.ViewJob
                      orderby c.Code
                      select new TextValueRow
                      {
                          Text = c.Name + "(" + c.Code + ")",
                          Value = c.Code,
                      }).ToList();

            ddlJob.DataSource = rs;
            ddlJob.DataTextField = "Text";
            ddlJob.DataValueField = "Value";
            ddlJob.DataBind();
        }

        public void ddlDept_DataBind()
        {
            var rs = (from c in dcHr.ViewDept
                      orderby c.Code
                      select new TextValueRow
                      {
                          Text = c.Name + "(" + c.Code + ")",
                          Value = c.Code,
                      }).ToList();

            ddlDept.DataSource = rs;
            ddlDept.DataTextField = "Text";
            ddlDept.DataValueField = "Value";
            ddlDept.DataBind();
        }

        public void _DataBind()
        {

        }

        public void LoadData(string Key = "")
        {
            Key = Key.Length > 0 ? Key : "-1";
            var AutoKey = Convert.ToInt32(Key);

            var r = (from c in dcMain.PerformanceReportType
                     where c.AutoKey == AutoKey
                     select c).FirstOrDefault();

            if (r != null)
            {
                ControlGetSet.SetDropDownList(ddlEmpCategory, r.EmpCategoryCode);
                txtCode.Text = r.Code;
                txtName.Text = r.Name;
                txtDateA.SelectedDate = r.DateA;
                txtDateD.SelectedDate = r.DateD;
                txtNote.Text = r.Note;

                var Code = r.Code;

                var ListJobCode = (from c in dcMain.PerformanceReportTypeJob
                                   where c.PerformanceReportTypeCode == Code
                                   select c.JobCode).ToList();

                ddlJob.Value = ListJobCode;

                var ListDeptCode = (from c in dcMain.PerformanceReportTypeDept
                                    where c.PerformanceReportTypeCode == Code
                                    select c.DeptCode).ToList();

                ddlDept.Value = ListDeptCode;

                //如果可以取得資料 則代碼不可以編輯
                ddlEmpCategory.Enabled = false;
                txtCode.Enabled = false;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string Key = lblAutoKey.Text.Length > 0 ? lblAutoKey.Text : "-1";
            var AutoKey = Convert.ToInt32(Key);

            var r = (from c in dcMain.PerformanceReportType
                     where c.AutoKey == AutoKey
                     select c).FirstOrDefault();

            var EmpCategoryCode = ddlEmpCategory.SelectedItem.Value;
            var Code = txtCode.Text;
            var Name = txtName.Text;
            var DateA = txtDateA.SelectedDate.GetValueOrDefault(DateTime.Now.Date);
            var DateD = txtDateD.SelectedDate.GetValueOrDefault(DateTime.Now.Date);
            var Sort = 99;
            var Note = txtNote.Text;

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
                if (dcMain.PerformanceReportType.Any(c => c.EmpCategoryCode == EmpCategoryCode && c.Code == Code))
                {
                    lblMsg.Text = "資料重複，請重新輸入";
                    return;
                }
            }

            if (r == null)
            {
                r = new PerformanceReportType();
                r.EmpCategoryCode = EmpCategoryCode;
                r.Code = Code;
                r.ContentHead = "";
                r.ContentFooter = "";
                r.InsertMan = _User.UserCode;
                r.InsertDate = DateTime.Now;
                dcMain.PerformanceReportType.InsertOnSubmit(r);
            }

            r.Name = Name;
            r.DateA = DateA;
            r.DateD = DateD;
            r.Sort = Sort;
            r.Note = Note;
            r.UpdateMan = _User.UserCode;
            r.UpdateDate = DateTime.Now;

            var ListJob = ddlJob.Value.ToList();

            //清空目前的可用職稱
            var rsTypeJob = (from c in dcMain.PerformanceReportTypeJob
                             where c.PerformanceReportTypeCode == Code
                             select c).ToList();

            var rsJob = (from c in dcHr.ViewJob
                         select c).ToList();

            dcMain.PerformanceReportTypeJob.DeleteAllOnSubmit(rsTypeJob);

            var ListTypeJob = new List<PerformanceReportTypeJob>();

            foreach (string JobCode in ListJob)
            {
                var rTypeJob = new PerformanceReportTypeJob();
                rTypeJob.Code = Guid.NewGuid().ToString();
                rTypeJob.PerformanceReportTypeCode = Code;
                rTypeJob.JobCode = JobCode;
                rTypeJob.JobName = "";

                var rJob = rsJob.FirstOrDefault(p => p.Code == JobCode);
                if (rJob != null)
                    rTypeJob.JobName = rJob.Name;

                rTypeJob.Note = "";
                rTypeJob.Sort = 9;
                rTypeJob.InsertMan = _User.UserCode;
                rTypeJob.InsertDate = DateTime.Now;
                rTypeJob.UpdateMan = _User.UserCode;
                rTypeJob.UpdateDate = DateTime.Now;

                ListTypeJob.Add(rTypeJob);
            }

            dcMain.PerformanceReportTypeJob.InsertAllOnSubmit(ListTypeJob);

            var ListDept = ddlDept.Value.ToList();

            //清空目前的可用職稱
            var rsTypeDept = (from c in dcMain.PerformanceReportTypeDept
                              where c.PerformanceReportTypeCode == Code
                              select c).ToList();

            var rsDept = (from c in dcHr.ViewDept
                          select c).ToList();

            dcMain.PerformanceReportTypeDept.DeleteAllOnSubmit(rsTypeDept);

            var ListTypeDept = new List<PerformanceReportTypeDept>();

            foreach (string DeptCode in ListDept)
            {
                var rTypeDept = new PerformanceReportTypeDept();
                rTypeDept.Code = Guid.NewGuid().ToString();
                rTypeDept.PerformanceReportTypeCode = Code;
                rTypeDept.DeptCode = DeptCode;
                rTypeDept.DeptName = "";

                var rDept = rsDept.FirstOrDefault(p => p.Code == DeptCode);
                if (rDept != null)
                    rTypeDept.DeptName = rDept.Name;

                rTypeDept.Note = "";
                rTypeDept.Sort = 9;
                rTypeDept.InsertMan = _User.UserCode;
                rTypeDept.InsertDate = DateTime.Now;
                rTypeDept.UpdateMan = _User.UserCode;
                rTypeDept.UpdateDate = DateTime.Now;

                ListTypeDept.Add(rTypeDept);
            }

            dcMain.PerformanceReportTypeDept.InsertAllOnSubmit(ListTypeDept);

            dcMain.SubmitChanges();

            oMainDao.MessageLog("1", "頁面：" + WebPage.GetActivePage + "｜名稱：" + WebPage.GetParentInfo() + "｜內容：" + JsonConvert.SerializeObject(ListTypeDept), "", "Performance-儲存報表代碼採用部門", "", _User.UserCode);
            oMainDao.MessageLog("1", "頁面：" + WebPage.GetActivePage + "｜名稱：" + WebPage.GetParentInfo() + "｜內容：" + JsonConvert.SerializeObject(ListTypeJob), "", "Performance-儲存報表代碼採用職稱", "", _User.UserCode);

            oMainDao.MessageLog("1", "頁面：" + WebPage.GetActivePage + "｜名稱：" + WebPage.GetParentInfo() + "｜內容：" + JsonConvert.SerializeObject(r), "", "Performance-儲存報表代碼", "", _User.UserCode);

            Response.Redirect("ManageReportType.aspx");
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