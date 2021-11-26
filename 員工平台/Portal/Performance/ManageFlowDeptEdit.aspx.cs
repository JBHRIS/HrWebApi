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
    public partial class ManageFlowDeptEdit : WebPageBase
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
                LoadData(lblAutoKey.Text);
            }
        }

        public void _DataBind()
        {
            string Key = lblAutoKey.Text.Length > 0 ? lblAutoKey.Text : "-1";
            var AutoKey = Convert.ToInt32(Key);

            //var rDept = (from c in dcMain.PerformanceDept
            //             where c.AutoKey == AutoKey
            //             select c).FirstOrDefault();

            //if (rDept == null)
            //    return;

            var MainCode =(string) UnobtrusiveSession.Session["MainCode"];// rDept.PerformanceMainCode;

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

            ddlParent.DataSource = rs;
            ddlParent.DataTextField = "Text";
            ddlParent.DataValueField = "Value";
            ddlParent.DataBind();
        }

        public void LoadData(string Key = "")
        {
            Key = Key.Length > 0 ? Key : "-1";
            var AutoKey = Convert.ToInt32(Key);

            var r = (from c in dcMain.PerformanceDept
                     where c.AutoKey == AutoKey
                     select c).FirstOrDefault();

            if (r != null)
            {
                txtName.Text = r.Name;
                ControlGetSet.SetDropDownList(ddlParent, r.ParentCode);
                txtDeptTree.Text = r.DeptTree.ToString();
                txtDeptTreeB.Text = r.DeptTreeB.ToString();
                txtDeptTreeE.Text = r.DeptTreeE.ToString();
                txtManagerId.Text = r.ManagerId;
                txtManagerName.Text = r.ManagerName;
                txtJobName.Text = r.JobName;
                txtJoblName.Text = r.JoblName;
                txtMail.Text = r.Mail;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string Key = lblAutoKey.Text.Length > 0 ? lblAutoKey.Text : "-1";
            var AutoKey = Convert.ToInt32(Key);

            var r = (from c in dcMain.PerformanceDept
                         where c.AutoKey == AutoKey
                         select c).FirstOrDefault();

            if (r == null)
                return;

            var MainCode = r.PerformanceMainCode;

            var Code = Guid.NewGuid().ToString();

            if (r == null)
            {
                r = new PerformanceDept();
                r.PerformanceMainCode = MainCode;
                r.Code = Code;

                r.ParentManagerId = "";
                r.JobCode = "";
                r.JoblCode = "";
                r.BonusMax = 0;
                r.BonusUse = 0;
                r.BonusBalance = 0;
                r.PathCode = "";
                r.PathName = "";
                r.InsertMan = _User.UserCode;
                r.InsertDate = DateTime.Now;

                dcMain.PerformanceDept.InsertOnSubmit(r);
            }
            else
                Code = r.Code;

            var ParentCode = "";

            if (ddlParent.SelectedItem != null)
                ParentCode = ddlParent.SelectedItem.Value;

            r.Name = txtName.Text;
            r.DeptTree = txtDeptTree.Text.ParseInt(0);
            r.DeptTreeB = txtDeptTreeB.Text.ParseInt(0);
            r.DeptTreeE = txtDeptTreeE.Text.ParseInt(0);
            r.ParentCode = ParentCode;
            r.ManagerId = txtManagerId.Text;
            r.ManagerName = txtManagerName.Text;
            r.JobName = txtJobName.Text;
            r.JoblName = txtJoblName.Text;
            r.Mail = txtMail.Text;
            r.UpdateMan = _User.UserCode;
            r.UpdateDate = DateTime.Now;

            var rFlow = (from c in dcMain.PerformanceFlow
                         where c.PerformanceMainCode == MainCode
                         && c.PerformanceDeptCode == Code
                         select c).FirstOrDefault();

            var FlowCode = "";
            if (rFlow != null)
            {
                FlowCode = rFlow.Code;
                rFlow.DeptTreeB = r.DeptTreeB;
                rFlow.DeptTreeE = r.DeptTreeE;
            }

            var rNode = (from c in dcMain.PerformanceFlowNode
                         where FlowCode == c.PerformanceFlowCode
                         && c.PerformanceDeptCodeDefault == Code
                         select c).FirstOrDefault();

            //修改節點主管
            if (rNode != null)
            {
                rNode.EmpIdDefault = r.ManagerId;
                rNode.UpdateMan = _User.UserCode;
                rNode.UpdateDate = DateTime.Now;
            }

            dcMain.SubmitChanges();

            oMainDao.MessageLog("1", "頁面：" + WebPage.GetActivePage + "｜名稱：" + WebPage.GetParentInfo() + "｜內容：" + JsonConvert.SerializeObject(rFlow), "", "Performance-儲存流程資料", "", _User.UserCode);
            oMainDao.MessageLog("1", "頁面：" + WebPage.GetActivePage + "｜名稱：" + WebPage.GetParentInfo() + "｜內容：" + JsonConvert.SerializeObject(rNode), "", "Performance-儲存節點資料", "", _User.UserCode);
            oMainDao.MessageLog("1", "頁面：" + WebPage.GetActivePage + "｜名稱：" + WebPage.GetParentInfo() + "｜內容：" + JsonConvert.SerializeObject(r), "", "Performance-儲存部門資料", "", _User.UserCode);

            Response.Redirect("ManageFlowDept.aspx");
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