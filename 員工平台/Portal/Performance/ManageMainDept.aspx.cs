using Bll.Tools;
using Dal.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace Performance
{
    public partial class ManageMainDept : WebPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                lblKey1.Text = "";
                if (Request.QueryString["AutoKey"] == null)
                {
                    UnobtrusiveSession.Session["AutoKey"] = null;
                }
                else
                    lblKey1.Text = (string)UnobtrusiveSession.Session["AutoKey"];

                if (UnobtrusiveSession.Session["AutoKey"] == null)
                {
                    btnSave.Enabled = false;
                    return;
                }

                LoadData("");

            }
        }

        public void LoadData(string Key)
        {
            Key = Key.Length > 0 ? Key : "-1";
            var AutoKey = Convert.ToInt32(Key);

        }

        protected void lvDept_NeedDataSource(object sender, RadListViewNeedDataSourceEventArgs e)
        {
            string Key = lblKey1.Text.Length > 0 ? lblKey1.Text : "-1";
            var AutoKey = Convert.ToInt32(Key);

            var rMain = dcMain.PerformanceMain.FirstOrDefault(p => p.AutoKey == AutoKey);

            if (rMain != null)
            {
                //只取出此次要參與簽核的部門
                var ListDeptCode = dcMain.PerformanceBase.Where(p => p.PerformanceMainCode == rMain.Code).Select(p => p.PerformanceDeptCode).Distinct().ToList();

                lvDept.DataSource = dcMain.PerformanceDept.Where(p => p.PerformanceMainCode == rMain.Code && ListDeptCode.Contains(p.Code)).ToList();
            }
        }

        protected void lvDept_DataBound(object sender, EventArgs e)
        {
            string Key = lblKey1.Text.Length > 0 ? lblKey1.Text : "-1";
            var AutoKey = Convert.ToInt32(Key);

            var rMain = dcMain.PerformanceMain.FirstOrDefault(p => p.AutoKey == AutoKey);
            if (rMain != null)
            {
                var DeptTree = rMain.DeptTreeE;

                var oPerformance = new PerformanceDao(dcShare, dcMain, dcHr);

                //取得部門層級
                //var rsDeptLevel = oMainDao.GetDeptLevel(DeptTree);
                var rsDeptLevel = oPerformance.GetDeptLevel(999);

                var rsDept = dcMain.PerformanceDept.Where(p => p.PerformanceMainCode == rMain.Code).ToList();

                foreach (var item in lvDept.Items)
                {
                    AutoKey = Convert.ToInt32(item.GetDataKeyValue("AutoKey"));

                    var ddlDeptTreeBObj = item.FindControl("ddlDeptTreeB");
                    var ddlDeptTreeEObj = item.FindControl("ddlDeptTreeE");
                    if (AutoKey >= 0)
                    {
                        var ddlDeptTreeB = ddlDeptTreeBObj as RadDropDownList;
                        var ddlDeptTreeE = ddlDeptTreeEObj as RadDropDownList;

                        ddlDeptTreeB.DataSource = rsDeptLevel;
                        ddlDeptTreeB.DataTextField = "Text";
                        ddlDeptTreeB.DataValueField = "Value";
                        ddlDeptTreeB.DataBind();

                        ddlDeptTreeE.DataSource = rsDeptLevel;
                        ddlDeptTreeE.DataTextField = "Text";
                        ddlDeptTreeE.DataValueField = "Value";
                        ddlDeptTreeE.DataBind();

                        var rDept = rsDept.FirstOrDefault(p => p.AutoKey == AutoKey);
                        if (rDept != null)
                        {
                            ControlGetSet.SetDropDownList(ddlDeptTreeB, rDept.DeptTreeB.ToString());
                            ControlGetSet.SetDropDownList(ddlDeptTreeE, rDept.DeptTreeE.ToString());
                        }
                    }
                }
            }
        }

        protected void lvDept_ItemCommand(object sender, RadListViewCommandEventArgs e)
        {
            string cn = e.CommandName;
            string ca = e.CommandArgument.ToString();
        }


        protected void btnSave_Click(object sender, EventArgs e)
        {
            string Key = lblKey1.Text.Length > 0 ? lblKey1.Text : "-1";
            var AutoKey = Convert.ToInt32(Key);

            var rMain = dcMain.PerformanceMain.FirstOrDefault(p => p.AutoKey == AutoKey);

            if (rMain != null)
            {
                var rsDept = dcMain.PerformanceDept.Where(p => p.PerformanceMainCode == rMain.Code).ToList();
                var rsFlow = dcMain.PerformanceFlow.Where(p => p.PerformanceMainCode == rMain.Code).ToList();

                //將使用者所設定的部門資訊 重新填入
                foreach (var item in lvDept.Items)
                {
                    AutoKey = Convert.ToInt32(item.GetDataKeyValue("AutoKey"));

                    var ddlDeptTreeBObj = item.FindControl("ddlDeptTreeB");
                    var ddlDeptTreeEObj = item.FindControl("ddlDeptTreeE");
                    if (AutoKey >= 0)
                    {
                        var ddlDeptTreeB = ddlDeptTreeBObj as RadDropDownList;
                        var ddlDeptTreeE = ddlDeptTreeEObj as RadDropDownList;

                        var rDept = rsDept.FirstOrDefault(p => p.AutoKey == AutoKey);
                        if (rDept != null)
                        {
                            rDept.DeptTreeB = ddlDeptTreeB.SelectedItem.Value.ParseInt(60);
                            rDept.DeptTreeE = ddlDeptTreeE.SelectedItem.Value.ParseInt(90);

                            var rFlow = rsFlow.FirstOrDefault(p => p.PerformanceDeptCode == rDept.Code);
                            if (rFlow != null)
                            {
                                rFlow.DeptTreeB = ddlDeptTreeB.SelectedItem.Value.ParseInt(60);
                                rFlow.DeptTreeE = ddlDeptTreeE.SelectedItem.Value.ParseInt(90);
                            }
                        }
                    }
                }

                dcMain.SubmitChanges();

                oMainDao.MessageLog("1", "頁面：" + WebPage.GetActivePage + "｜名稱：" + WebPage.GetParentInfo() + "｜內容：", "", "Performance-考核部門修改", "", _User.UserCode);

                Response.Redirect("ManageMain.aspx");
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