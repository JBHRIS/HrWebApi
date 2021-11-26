using Bll.Performance.Vdb;
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
using Telerik.Web.UI;

namespace Performance
{
    public partial class MainBaseViewChart : WebPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                UnobtrusiveSession.Session["ActivePage"] = WebPage.GetActivePage;

                var ph = (ContentPlaceHolder)this.Master.Master.FindControl("cphMain");
                if (ph != null)
                {
                    var phEtc = ph.FindControl("phEtc");
                    if (phEtc != null)
                        ((PlaceHolder)phEtc).Visible = false;
                }
            }

            RadClientExportManager1.PdfSettings.Fonts.Add("Arial Unicode MS", "Fonts/Arial-Unicode-MS.ttf");
            RadClientExportManager1.PdfSettings.FileName = "績效考核圖表.pdf";
        }

        public void _DataBind()
        {

        }

        protected void lvMain_NeedDataSource(object sender, RadListViewNeedDataSourceEventArgs e)
        {
            var TypeCode = lblTypeCode.Text;
            var MainCode = lblMainCode.Text;
            var DeptCode = lblDeptCode.Text;
            var SubDept = lblSubDept.Text == "1";
            var Base = lblBase.Text == "1";

            var EmpId = _User.UserCode;

            if (TypeCode.Length == 0 || MainCode.Length == 0 || DeptCode.Length == 0)
                return;

            //取得所有部門
            var rsDeptAll = (from c in dcMain.PerformanceDept
                             where c.PerformanceMainCode == MainCode
                             select c).ToList();

            //取得當前部門
            var rDept = rsDeptAll.FirstOrDefault(p => p.Code == DeptCode);

            if (rDept == null)
            {
                lblMsg.Text = "沒有產生部門";
                return;
            }

            //路徑
            var PathCode = rDept.PathCode;

            //加入子部門
            var rsDept = rsDeptAll.Where(p => p.PathCode.IndexOf(PathCode) >= 0).ToList();

            //部門清單
            var ListDeptCode = rsDept.Select(p => p.Code).ToList();

            var rs = (from c in dcMain.PerformanceDept
                      where c.PerformanceMainCode == MainCode
                      && ListDeptCode.Contains(c.Code)
                      orderby c.DeptTree descending
                      select c).ToList();

            lvMain.DataSource = rs;
        }

        protected void lvMain_DataBound(object sender, EventArgs e)
        {
            var TypeCode = lblTypeCode.Text;
            var MainCode = lblMainCode.Text;
            var EmpCategoryCode = lblEmpCategoryCode.Text;
            var DeptCode = lblDeptCode.Text;
            var SubDept = lblSubDept.Text == "1";
            var Base = lblBase.Text == "1";

            var EmpId = _User.UserCode;

            if (TypeCode.Length == 0 || MainCode.Length == 0 || DeptCode.Length == 0)
                return;

            //取得所有部門
            var rsDeptAll = (from c in dcMain.PerformanceDept
                             where c.PerformanceMainCode == MainCode
                             select c).ToList();

            //取得當前部門
            var rDept = rsDeptAll.FirstOrDefault(p => p.Code == DeptCode);

            if (rDept == null)
            {
                lblMsg.Text = "沒有產生部門";
                return;
            }

            //路徑
            var PathCode = rDept.PathCode;

            //加入子部門
            var rsDept = rsDeptAll.Where(p => p.PathCode.IndexOf(PathCode) >= 0).ToList();

            //部門清單
            var ListDeptCode = rsDept.Select(p => p.Code).ToList();

            var rs = rsDept;

            var rsBase = (from c in dcMain.PerformanceBase
                          where c.PerformanceMainCode == MainCode
                          && ListDeptCode.Contains(c.PerformanceDeptCode)
                           && c.EmpId != EmpId
                          select c).ToList();

            var oPerformance = new PerformanceDao(dcShare, dcMain, dcHr);
            var rsRating = oPerformance.GetPerformanceRating(EmpCategoryCode);

            foreach (var item in lvMain.Items)
            {
                var ctInfoRatingObj = item.FindControl("ctInfoRating");

                if (ctInfoRatingObj != null)
                {
                    var AutoKey = Convert.ToInt32(item.GetDataKeyValue("AutoKey"));

                    //推斷部門向下
                    rDept = rs.FirstOrDefault(p => p.AutoKey == AutoKey);
                    if (rDept != null)
                    {
                        var ListDeptCodeDown = rs.Where(p => p.PathCode.IndexOf(rDept.PathCode) >= 0).Select(p => p.Code).ToList();

                        var ctInfoRating = ctInfoRatingObj as RadHtmlChart;

                        //評等分配圖(圓形圖)
                        ctInfoRating.PlotArea.Series.Clear();
                        //ctInfoRating.ChartTitle.Text = rDept.Name;
                        var psInfo = new PieSeries();
                        psInfo.LabelsAppearance.Position = Telerik.Web.UI.HtmlChart.PieAndDonutLabelsPosition.OutsideEnd;
                        psInfo.LabelsAppearance.DataFormatString = "{0} %";
                        psInfo.TooltipsAppearance.Color = Color.White;
                        psInfo.TooltipsAppearance.DataFormatString = "{0} %";

                        var rsBaseDept = rsBase.Where(p => ListDeptCodeDown.Contains(p.PerformanceDeptCode)).ToList();
                        var BaseRowCount = Convert.ToDecimal(rsBaseDept.Count);
                        foreach (var rRating in rsRating)
                        {
                            var itemPie = new PieSeriesItem();
                            itemPie.Exploded = false;
                            itemPie.Name = rRating.Text;
                            var RatingRowCount = rsBaseDept.Where(p => p.RatingCode == rRating.Value).ToList().Count;
                            itemPie.Y = Math.Round((RatingRowCount / BaseRowCount) * 100, 1);
                            psInfo.SeriesItems.Add(itemPie);

                            if (itemPie.Name == "甲")
                                itemPie.Exploded = true;
                        }
                        ctInfoRating.PlotArea.Series.Add(psInfo);
                    }
                }
            }
        }
    }
}