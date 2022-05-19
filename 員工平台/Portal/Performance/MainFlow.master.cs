using Bll;
using Bll.Tools;
using Dal;
using Dal.Dao;
using Dal.Dao.Share;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.Design.ODataDataSource;
using Telerik.Web.UI;

namespace Performance
{
    public partial class MainFlow : WebPageMasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                UnobtrusiveSession.Session["ActivePage"] = WebPage.GetActivePage;

                ddlType_DataBind();
                _DataBind();
            }            
        }

        public void ddlType_DataBind()
        {
            var rs = oMainDao.ShareCodeTextValue("PerformanceType");

            ddlType.DataSource = rs;
            ddlType.DataTextField = "Text";
            ddlType.DataValueField = "Value";
            ddlType.DataBind();

            ddlMain_DataBind();
        }

        protected void ddlType_SelectedIndexChanged(object sender, DropDownListEventArgs e)
        {
            ddlMain_DataBind();
            _DataBind();
        }

        public void ddlMain_DataBind()
        {
            if (ddlType.SelectedItem == null)
                return;

            var TypeCode = ddlType.SelectedItem.Value;

            var rs = (from c in dcMain.PerformanceMain
                      where c.TypeCode == TypeCode
                      orderby c.Yymm descending, c.EmpCategoryCode, c.Seq
                      select new TextValueRow
                      {
                          Text = c.Name + "(" + c.Yymm + "," + c.EmpCategoryCode + ")",
                          Value = c.Code,
                      }).ToList();

            ddlMain.DataSource = rs;
            ddlMain.DataTextField = "Text";
            ddlMain.DataValueField = "Value";
            ddlMain.DataBind();

            var ListMainCode = rs.Select(p => p.Value).ToList();

            ddlDept_DataBind();
        }

        protected void ddlMain_SelectedIndexChanged(object sender, DropDownListEventArgs e)
        {
            ddlDept_DataBind();
            _DataBind();
        }

        public void ddlDept_DataBind()
        {
            if (ddlMain.SelectedItem == null)
                return;

            var MainCode = ddlMain.SelectedItem.Value;

            //取得所有部門
            var rsDept = (from c in dcMain.PerformanceDept
                          where c.PerformanceMainCode == MainCode
                          select c).ToList();

            //取得人員資料
            var rsBase = (from c in dcMain.PerformanceBase
                          where c.PerformanceMainCode == MainCode
                          select c).ToList();

            //取得可傳簽的主流程
            var rsFlowMain = (from f in dcMain.PerformanceFlow
                              join n in dcMain.PerformanceFlowNode on f.Code equals n.PerformanceFlowCode
                              where f.PerformanceMainCode == MainCode
                              select f).ToList();

            //只跑有創出流程的部門 每個部門都是啟始節點
            var ListDeptCode = rsFlowMain.Select(p => p.PerformanceDeptCode).ToList();

            //只跑最大的部門迴圈
            var ListDept = rsDept.Where(p => ListDeptCode.Contains(p.Code)).OrderBy(p => p.DisplayCode).ToList();

            //計算兩項獎金 本部獎金 / 部門及其向下的獎金
            var rs = new List<TextValueRow>();
            TextValueRow r = new TextValueRow();
            r.Value = "-";
            r.Text = "全部";
            rs.Add(r);

            var oShareDefault = new ShareDefaultDao(WebPage.dcShare);
            var rDefaultSystem = oShareDefault.DefaultSystem;
            var CompanyId = rDefaultSystem.CompanyId;

            //取得有該產生者有權限的名單
            if (CompanyId == "Emc")
            {
                var ListEmpId = dcHr.WriteRuleTable1ByNobr(_User.UserCode, "A", true, DateTime.Now.ToShortDateString()).Select(p => p.NOBR.Trim()).ToList();

                rsBase = (from c in rsBase
                          where ListEmpId.Contains(c.EmpId)
                          select c).ToList();
            }

            if (CompanyId == "Emccn")
            {
                var CompCode = rsBase.FirstOrDefault(p => p.EmpId == _User.EmpId)?.CompCode ?? "";

                rsBase = (from c in rsBase
                          where c.CompCode == CompCode
                          select c).ToList();
            }

            foreach (var rDept in ListDept)
            {
                var DeptTree = rsDept.Max(p => p.DeptTree);

                r = new TextValueRow();
                r.Text = rDept.Name;
                r.Value = rDept.Code;

                //待審核
                r.Text = "<font color='#999999'>" + rDept.Name + "</font>";
                if (rsFlowMain.Any(p => p.PerformanceDeptCode == rDept.Code && !p.IsFinish))
                    r.Text = "<font color='#7d0000'>" + rDept.Name + "</font>";
                //tn.ForeColor = ColorTranslator.FromHtml("#0075a9");

                //統計人數
                var rsBaseByDeptCode = rsBase.Where(p => p.PerformanceDeptCode == rDept.Code).ToList();
                if (rsBaseByDeptCode.Count > 0)
                {
                    r.Text += "(" + rsBaseByDeptCode.Count + ")";

                    if (DeptTree >= rDept.DeptTreeB)
                    {
                        if (CompanyId == "Emc" || CompanyId == "Emccn")
                        {
                            //計算部門及其向下可用獎金
                            ListDeptCode = rsDept.Where(p => p.PathCode.IndexOf("/" + rDept.Code + "/") >= 0).Select(p => p.Code).ToList();
                            var BonusAdjust = -rsBase.Where(p => ListDeptCode.Contains(p.PerformanceDeptCode)).Sum(p => p.BonusAdjust);
                            r.Text += "｜";
                            r.Text += String.Format("${0:N0}", BonusAdjust);

                            //計算部門及其向下實發總獎金
                            r.Text += "｜";
                            r.Text += String.Format("${0:N0}", rsBase.Where(p => ListDeptCode.Contains(p.PerformanceDeptCode)).Sum(p => p.BonusReal));
                        }
                    }
                    rs.Add(r);
                }
            }

            ddlDept.DataSource = rs;
            ddlDept.DataTextField = "Text";
            ddlDept.DataValueField = "Value";
            ddlDept.DataBind();
        }

        protected void ddlDept_SelectedIndexChanged(object sender, DropDownListEventArgs e)
        {
            _DataBind();
        }

        public void _DataBind()
        {
            var lblTypeCode = cphMain.FindControl("lblTypeCode");
            if (lblTypeCode != null)
            {
                ((RadLabel)lblTypeCode).Text = "";
                if (ddlType.SelectedItem != null)
                    ((RadLabel)lblTypeCode).Text = ddlType.SelectedItem.Value;
            }

            var lblMainCode = cphMain.FindControl("lblMainCode");
            if (lblMainCode != null)
            {
                ((RadLabel)lblMainCode).Text = "";
                if (ddlMain.SelectedItem != null)
                    ((RadLabel)lblMainCode).Text = ddlMain.SelectedItem.Value;
            }

            var lblDeptCode = cphMain.FindControl("lblDeptCode");
            if (lblDeptCode != null)
            {
                ((RadLabel)lblDeptCode).Text = "";
                if (ddlDept.SelectedItem != null)
                    ((RadLabel)lblDeptCode).Text = ddlDept.SelectedItem.Value;
            }

            var lvMain = cphMain.FindControl("lvMain");
            if (lvMain != null)
                ((RadListView)lvMain).Rebind();
        }
    }
}