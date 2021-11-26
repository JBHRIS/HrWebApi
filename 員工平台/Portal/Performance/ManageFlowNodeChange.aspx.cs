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
    public partial class ManageFlowNodeChange : WebPageBase
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

                _DataBind();
                LoadData(lblAutoKey.Text);
            }
        }

        public void _DataBind()
        {
            var rs = (from c in dcHr.ViewEmp
                      select new TextValueRow
                      {
                          Text = c.Name + "," + c.Code,
                          Value = c.Code,
                      }).ToList();

            ddlEmp.DataSource = rs;
            ddlEmp.DataTextField = "Text";
            ddlEmp.DataValueField = "Value";
            ddlEmp.DataBind();
        }

        public void LoadData(string Key = "")
        {
            Key = Key.Length > 0 ? Key : "-1";
            var AutoKey = Convert.ToInt32(Key);

            var r = (from c in dcMain.PerformanceFlowNode
                     where c.AutoKey == AutoKey
                     select c).FirstOrDefault();

            if (r != null)
                ControlGetSet.SetRadComboBox(ddlEmp, r.EmpIdDefault);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string Key = lblAutoKey.Text.Length > 0 ? lblAutoKey.Text : "-1";
            var AutoKey = Convert.ToInt32(Key);

            var r = (from c in dcMain.PerformanceFlowNode
                     where c.AutoKey == AutoKey
                     select c).FirstOrDefault();

            if (r != null)
            {
                var EmpId = ddlEmp.SelectedItem.Value;
                var DeptCode = r.PerformanceDeptCodeDefault;

                var rDept = (from c in dcMain.PerformanceDept
                             where c.Code == DeptCode
                             //&& c.ManagerId == EmpId
                             select c).FirstOrDefault();

                if (rDept != null)
                {
                    var rBase = (from b in dcHr.ViewEmp
                                join d in dcHr.ViewDept on b.DeptCode equals d.Code
                                join j in dcHr.ViewJob on b.JobCode equals j.Code
                                where b.Code == EmpId
                                select new
                                {
                                    Name = b.Name,
                                    Mail = b.Email,
                                    JobName = j.Name,
                                    JoblName = "",
                                 }).FirstOrDefault();

                    if (rBase != null)
                    {
                        rDept.ManagerId = EmpId;
                        rDept.ManagerName = rBase.Name;
                        rDept.Mail = rBase.Mail;
                        rDept.JobName = rBase.JobName;
                        rDept.JoblName = rBase.JoblName;
                        rDept.UpdateMan = _User.UserCode;
                        rDept.UpdateDate = DateTime.Now;

                        r.EmpIdDefault = EmpId;
                        r.UpdateMan = _User.UserCode;
                        r.UpdateDate = DateTime.Now;

                        dcMain.SubmitChanges();

                        oMainDao.MessageLog("1", "頁面：" + WebPage.GetActivePage + "｜名稱：" + WebPage.GetParentInfo() + "｜內容：" + JsonConvert.SerializeObject(r), "", "Performance-節點變更", "", _User.UserCode);

                        Response.Redirect("ManageFlowNode.aspx");
                    }
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