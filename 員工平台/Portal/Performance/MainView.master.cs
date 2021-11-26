using Bll;
using Bll.Tools;
using Dal;
using Dal.Dao;
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
    public partial class MainView : WebPageMasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                UnobtrusiveSession.Session["ActivePage"] = WebPage.GetActivePage;

                ddlReportContent_DataBind();

                ddlMain_DataBind();
                ddlDept_DataBind();            
            }
        }

        public void ddlMain_DataBind()
        {
            var ListPerformanceMainCode = dcMain.PerformanceDept.Where(p => p.ManagerId == _User.UserCode).Select(p => p.PerformanceMainCode).ToList();

            var rsMain = (from c in dcMain.PerformanceMain
                          where ListPerformanceMainCode.Contains(c.Code)
                          select new
                          {
                              c.Yymm,
                              c.EmpCategoryCode,
                          }).ToList();

            var ListEmpCategory = rsMain.Select(p => p.EmpCategoryCode).Distinct().ToList();

            var ListYymm = (from c in rsMain
                            select c.Yymm).ToList();

            //如果該主管不曾出現在任何一個部門 就踢出去
            if (ListYymm.Count == 0)
            {
                lblMsg.Text = "目前無資料可以查詢";
                return;
            }

            //分解年月
            var ListYear = (from c in ListYymm
                            select new
                            {
                                Text = c.Substring(0, 4),
                                Value = c.Substring(0, 4),
                            }).Distinct().OrderByDescending(p => p.Value).ToList();

            var ListMonth = (from c in ListYymm
                             select new
                             {
                                 Text = c.Substring(4),
                                 Value = c.Substring(4),
                             }).Distinct().OrderByDescending(p => p.Value).ToList();

            ddlYear.DataSource = ListYear;
            ddlYear.DataTextField = "Text";
            ddlYear.DataValueField = "Value";
            ddlYear.DataBind();

            ddlMonth.DataSource = ListMonth;
            ddlMonth.DataTextField = "Text";
            ddlMonth.DataValueField = "Value";
            ddlMonth.DataBind();

            var rsEmpCategory = oMainDao.ShareCodeTextValue("EmpCategory");
            rsEmpCategory = rsEmpCategory.Where(p => ListEmpCategory.Contains(p.Value)).ToList();

            ddlEmpCategory.DataSource = rsEmpCategory;
            ddlEmpCategory.DataTextField = "Text";
            ddlEmpCategory.DataValueField = "Value";
            ddlEmpCategory.DataBind();
        }

        protected void ddlMain_SelectedIndexChanged(object sender, DropDownListEventArgs e)
        {
            ddlDept_DataBind();
        }

        /// <summary>
        /// 部門
        /// </summary>
        public class DeptRow
        {
            /// <summary>
            /// 代碼
            /// </summary>
            public string Code { get; set; }
            /// <summary>
            /// 名稱
            /// </summary>
            public string Name { get; set; }
            /// <summary>
            /// 部門主管工號
            /// </summary>
            public string ManagerId { get; set; }
            /// <summary>
            /// PathCode
            /// </summary>
            public string PathCode { get; set; }
            /// <summary>
            /// PathName
            /// </summary>
            public string PathName { get; set; }
            /// <summary>
            /// DeptTree
            /// </summary>
            public int DeptTree { get; set; }
            /// <summary>
            /// DeptTreeB
            /// </summary>
            public int DeptTreeB { get; set; }
            /// <summary>
            /// 父層級代碼
            /// </summary>
            public string ParentCode { get; set; }
            /// <summary>
            /// 暫用代碼
            /// </summary>
            public int Id { get; set; }
            /// <summary>
            /// 暫用父層級代碼
            /// </summary>
            public int ParentId { get; set; }
        }

        public void ddlDept_DataBind()
        {
            if (ddlYear.SelectedItem == null || ddlMonth.SelectedItem == null || ddlEmpCategory.SelectedItem == null)
                return;

            var Year = ddlYear.SelectedItem.Value;
            var Month = ddlMonth.SelectedItem.Value;
            var EmpCategoryCode = ddlEmpCategory.SelectedItem.Value;

            var Yymm = Year + Month;

            //主檔設定
            var rMain = (from c in dcMain.PerformanceMain
                         where c.Yymm == Yymm && c.EmpCategoryCode == EmpCategoryCode
                         select c).FirstOrDefault();

            if (rMain == null)
            {
                lblMsg.Text = "考核主檔錯誤";
                return;
            }

            var MainCode = rMain.Code;

            var EmpId = _User.UserCode;

            //取得所有部門
            var rsDeptAll = (from c in dcMain.PerformanceDept
                             where c.PerformanceMainCode == MainCode
                             select new DeptRow
                             {
                                 Code = c.Code,
                                 Name = c.Name,
                                 ParentCode = c.ParentCode,
                                 Id = 0,
                                 ParentId = 0,
                                 ManagerId = c.ManagerId,
                                 PathCode = c.PathCode,
                                 PathName = c.PathName,
                                 DeptTree = c.DeptTree,
                                 DeptTreeB = c.DeptTreeB,
                             }).ToList();

            //取得可簽核部門
            var rsDept = (from c in rsDeptAll
                          where c.ManagerId == EmpId
                          select c).ToList();

            if (rsDept.Count == 0)
            {
                lblMsg.Text = "沒有產生部門";
                return;
            }

            var DeptCode = rsDept.OrderByDescending(p => p.DeptTree).First().Code;

            //加入子部門
            rsDept = rsDeptAll.Where(p => rsDept.Any(c => p.PathCode.IndexOf(c.PathCode) >= 0)).ToList();

            var ListDeptCode = rsDept.Select(p => p.Code).ToList();

            //加入目前可視部門(無踢除重複)
            //lblAllDeptCode.Text = string.Join(",", ListDeptCode.Select(x => x).ToArray<string>());

            //取得人員資料
            var rsBase = (from c in dcMain.PerformanceBase
                          where c.PerformanceMainCode == MainCode
                          && ListDeptCode.Contains(c.PerformanceDeptCode)
                          && c.EmpId != EmpId
                          select c).ToList();

            //取得可傳簽的主流程
            var rsFlowMain = (from f in dcMain.PerformanceFlow
                              join n in dcMain.PerformanceFlowNode on f.Code equals n.PerformanceFlowCode
                              where f.PerformanceMainCode == MainCode
                              && ListDeptCode.Contains(f.PerformanceDeptCode)
                              && !f.IsCancel
                              && !f.IsError
                              && !f.IsFinish
                              && !n.IsFinish
                              && n.EmpIdDefault == EmpId
                              select f).ToList();

            //將代碼及新的id暫存於dc裡
            var ListId = new Dictionary<string, int>();

            //處理代碼資料
            int i = 1;
            foreach (var rVdb in rsDept)
            {
                //產生id
                ListId.Add(rVdb.Code, i);
                rVdb.Id = i;

                i++;
            }

            //計算兩項獎金 本部獎金 / 部門及其向下的獎金

            var DeptTree = rsDept.Max(p => p.DeptTree);

            foreach (var r in rsDept)
            {
                //將上層的代碼轉換為id
                if (ListId.ContainsKey(r.ParentCode))
                    r.ParentId = ListId[r.ParentCode];
                else
                    r.ParentId = 0;  //如果沒有找到 就以0取代

                if (rsFlowMain.Any(p => p.PerformanceDeptCode == r.Code))
                    r.Name = "<font color='#7d0000'>" + r.Name + "</font>";
                else
                    r.Name = "<font color='#999999'>" + r.Name + "</font>"; //待審核

                //統計人數
                var rsBaseByDeptCode = rsBase.Where(p => p.PerformanceDeptCode == r.Code).ToList();
                if (rsBaseByDeptCode.Count > 0)
                    r.Name += "(" + rsBaseByDeptCode.Count + ")";

                if (DeptTree >= r.DeptTreeB)
                {
                    //計算部門及其向下可用獎金
                    ListDeptCode = rsDept.Where(p => p.PathCode.IndexOf("/" + r.Code + "/") >= 0).Select(p => p.Code).ToList();
                    var BonusAdjust = -rsBase.Where(p => ListDeptCode.Contains(p.PerformanceDeptCode)).Sum(p => p.BonusAdjust);
                    r.Name += "｜";
                    r.Name += String.Format("${0:N0}", BonusAdjust);

                    //計算部門及其向下實發總獎金
                    r.Name += "｜";
                    r.Name += String.Format("${0:N0}", rsBase.Where(p => ListDeptCode.Contains(p.PerformanceDeptCode)).Sum(p => p.BonusReal));
                }
            }

            ddlDept.DataSource = rsDept;
            ddlDept.DataValueField = "Code";
            ddlDept.DataTextField = "Name";
            ddlDept.DataFieldID = "Id";
            ddlDept.DataFieldParentID = "ParentId";
            ddlDept.DataBind();

            ddlDept.ExpandAllDropDownNodes();

            ddlDept.SelectedValue = DeptCode;

            ddlReportType_DataBind(DeptCode);
            _DataBind(DeptCode);            
        }

        public void ddlReportType_DataBind(string DeptCode)
        {
            if (ddlYear.SelectedItem == null || ddlMonth.SelectedItem == null || ddlEmpCategory.SelectedItem == null)
                return;

            var Year = ddlYear.SelectedItem.Value;
            var Month = ddlMonth.SelectedItem.Value;
            var EmpCategoryCode = ddlEmpCategory.SelectedItem.Value;

            var Yymm = Year + Month;

            //主檔設定
            var rMain = (from c in dcMain.PerformanceMain
                         where c.Yymm == Yymm && c.EmpCategoryCode == EmpCategoryCode
                         select c).FirstOrDefault();

            if (rMain == null)
            {
                lblMsg.Text = "考核主檔錯誤";
                return;
            }

            var MainCode = rMain.Code;

            //載入員工所擁有的職稱
            var ListBaseJobCode = (from c in dcMain.PerformanceBase
                                   where c.PerformanceMainCode == MainCode
                                   && c.PerformanceDeptCode == DeptCode
                                   && c.EmpCategoryCode == EmpCategoryCode
                                   select c.JobCode).ToList();

            //職稱可使用的樣版
            var ListReportTypeCode = (from c in dcMain.PerformanceReportTypeJob
                                      where (ListBaseJobCode.Contains(c.JobCode) || c.JobCode == "*")
                                      select c.PerformanceReportTypeCode).ToList();

            //部門可使用的樣版
            ListReportTypeCode.AddRange((from c in dcMain.PerformanceReportTypeDept
                                         where (c.DeptCode == DeptCode || c.DeptCode == "*")
                                         select c.PerformanceReportTypeCode).ToList());

            var rs = (from c in dcMain.PerformanceReportType
                      where c.EmpCategoryCode == EmpCategoryCode
                      && ListReportTypeCode.Contains(c.Code)
                      select new TextValueRow
                      {
                          Value = c.Code,
                          Text = c.Name,
                      }).ToList();

            ddlReportType.DataSource = rs;
            ddlReportType.DataTextField = "Text";
            ddlReportType.DataValueField = "Value";
            ddlReportType.DataBind();

            if (UnobtrusiveSession.Session["ReportType"] != null)
            {
                var ReportType = (string)UnobtrusiveSession.Session["ReportType"];
                if (ddlReportType.FindItemByValue(ReportType) != null)
                    ddlReportType.FindItemByValue(ReportType).Selected = true;
            }
        }

        public void ddlReportContent_DataBind()
        {
            var rs = oMainDao.ShareCodeTextValue("ReportContent");

            var r = new TextValueRow();
            r.Text = "全部";
            r.Value = "0";
            r.Sort = 0;
            rs.Add(r);

            rs = rs.OrderBy(p => p.Sort).ToList();

            ddlReportContent.DataSource = rs;
            ddlReportContent.DataTextField = "Text";
            ddlReportContent.DataValueField = "Value";
            ddlReportContent.DataBind();

            if (UnobtrusiveSession.Session["ReportContent"] != null)
            {
                var ReportContent = (string)UnobtrusiveSession.Session["ReportContent"];
                if (ddlReportContent.FindItemByValue(ReportContent) != null)
                    ddlReportContent.FindItemByValue(ReportContent).Selected = true;
            }
        }

        protected void ddlDept_EntryAdded(object sender, DropDownTreeEntryEventArgs e)
        {
            var DeptCode = e.Entry.Value;
            ddlReportType_DataBind(DeptCode);
            _DataBind(DeptCode);
        }

        protected void cbSubDept_CheckedChanged(object sender, EventArgs e)
        {
            var DeptCode = ddlDept.SelectedValue;
            _DataBind(DeptCode);
        }

        protected void cbBase_CheckedChanged(object sender, EventArgs e)
        {
            var DeptCode = ddlDept.SelectedValue;
            _DataBind(DeptCode);
        }

        protected void ddlReportType_SelectedIndexChanged(object sender, DropDownListEventArgs e)
        {
            var DeptCode = ddlDept.SelectedValue;
            _DataBind(DeptCode);

            if (ddlReportType.SelectedItem != null)
                UnobtrusiveSession.Session["ReportType"] = ddlReportType.SelectedItem.Value;
        }

        protected void ddlReportContent_SelectedIndexChanged(object sender, DropDownListEventArgs e)
        {
            var DeptCode = ddlDept.SelectedValue;
            _DataBind(DeptCode);

            if (ddlReportContent.SelectedItem != null)
                UnobtrusiveSession.Session["ReportContent"] = ddlReportContent.SelectedItem.Value;
        }

        public void _DataBind(string DeptCode)
        {
            if (ddlYear.SelectedItem == null ||
                ddlMonth.SelectedItem == null || 
                ddlEmpCategory.SelectedItem == null ||
                DeptCode.Length == 0)
                return;

            var Year = ddlYear.SelectedItem.Value;
            var Month = ddlMonth.SelectedItem.Value;
            var EmpCategoryCode = ddlEmpCategory.SelectedItem.Value;
            var SubDept = cbSubDept.Checked.GetValueOrDefault(false) ? "1" : "0";
            var Base = cbBase.Checked.GetValueOrDefault(false) ? "1" : "0";

            var Yymm = Year + Month;

            //主檔設定
            var rMain = (from c in dcMain.PerformanceMain
                         where c.Yymm == Yymm && c.EmpCategoryCode == EmpCategoryCode
                         select c).FirstOrDefault();

            if (rMain == null)
            {
                lblMsg.Text = "考核主檔錯誤";
                return;
            }

            var MainCode = rMain.Code;
            var ReportTypeCode = ddlReportType.SelectedItem.Value;
            var ReportContentCode = ddlReportContent.SelectedItem.Value;
            var TypeCode = rMain.TypeCode;

            var lblTypeCode = cphMain.FindControl("lblTypeCode");
            if (lblTypeCode != null)
            {
                ((RadLabel)lblTypeCode).Text = TypeCode;
            }

            var lblMainCode = cphMain.FindControl("lblMainCode");
            if (lblMainCode != null)
            {
                ((RadLabel)lblMainCode).Text = MainCode;
            }

            var lblEmpCategoryCode = cphMain.FindControl("lblEmpCategoryCode");
            if (lblEmpCategoryCode != null)
            {
                ((RadLabel)lblEmpCategoryCode).Text = EmpCategoryCode;
            }

            var lblDeptCode = cphMain.FindControl("lblDeptCode");
            if (lblDeptCode != null)
            {
                ((RadLabel)lblDeptCode).Text = DeptCode;
            }

            //樣版
            var lblReportTypeCode = cphMain.FindControl("lblReportTypeCode");
            if (lblReportTypeCode != null)
            {
                ((RadLabel)lblReportTypeCode).Text = ReportTypeCode;
            }

            var lblReportContentCode = cphMain.FindControl("lblReportContentCode");
            if (lblReportContentCode != null)
            {
                ((RadLabel)lblReportContentCode).Text = ReportContentCode;
            }

            //檢視
            var lblSubDept = cphMain.FindControl("lblSubDept");
            if (lblSubDept != null)
            {
                ((RadLabel)lblSubDept).Text = SubDept;
            }

            var lblBase = cphMain.FindControl("lblBase");
            if (lblBase != null)
            {
                ((RadLabel)lblBase).Text = Base;
            }

            var lvMain = cphMain.FindControl("lvMain");
            if (lvMain != null)
                ((RadListView)lvMain).Rebind();

            var lvMain1 = cphMain1.FindControl("lvMain1");
            if (lvMain1 != null)
                ((RadListView)lvMain1).Rebind();
        }

    }
}