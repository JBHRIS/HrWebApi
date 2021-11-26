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
using Telerik.Web.UI;

namespace Performance
{
    public partial class ManageFlowMain : WebPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                UnobtrusiveSession.Session["ActivePage"] = WebPage.GetActivePage;

                ddlType_DataBind();
            }

            RadClientExportManager1.PdfSettings.Fonts.Add("Arial Unicode MS", "Fonts/Arial-Unicode-MS.ttf");
            RadClientExportManager1.PdfSettings.FileName = "相關資訊.pdf";
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
        }

        public void ddlMain_DataBind()
        {
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

            ddlMain_SelectedIndexChanged(null, null);
        }

        protected void ddlMain_SelectedIndexChanged(object sender, DropDownListEventArgs e)
        {
            Info_DataBind();
        }

        public void _DataBind()
        {

        }

        //相關資訊
        private void Info_DataBind()
        {
            if (ddlType.SelectedItem == null || ddlMain.SelectedItem == null)
                return;

            var MainCode = ddlMain.SelectedItem.Value;

            var rMain = (from c in dcMain.PerformanceMain
                         where c.Code == MainCode
                         select c).FirstOrDefault();

            var rsType = oMainDao.ShareCodeTextValue("PerformanceType");
            var rsEmpCategory = oMainDao.ShareCodeTextValue("EmpCategory");

            var EmpCategoryCode = "";

            if (rMain != null)
            {
                EmpCategoryCode = rMain.EmpCategoryCode;

                lblInfoName.Text = rMain.Name;
                lblInfoYymm.Text = rMain.Yymm;
                lblInfoTypeName.Text = rMain.TypeCode;
                var rType = rsType.FirstOrDefault(p => p.Value == rMain.TypeCode);
                if (rType != null)
                    lblInfoTypeName.Text = rType.Text;
                lblInfoEmpCategoryName.Text = rMain.EmpCategoryCode;
                var rEmpCategory = rsEmpCategory.FirstOrDefault(p => p.Value == rMain.EmpCategoryCode);
                if (rEmpCategory != null)
                    lblInfoEmpCategoryName.Text = rEmpCategory.Text;
                lblInfoDeptTreeB.Text = rMain.DeptTreeB.ToString();
                lblInfoDeptTreeE.Text = rMain.DeptTreeE.ToString();
                lblInfoDateA.Text = rMain.DateA.ToShortDateString();
                lblInfoDateD.Text = rMain.DateD.ToShortDateString();
            }

            var oPerformance = new PerformanceDao(dcShare , dcMain , dcHr);
            var rsRating = oPerformance.GetPerformanceRating(EmpCategoryCode);

            var rsFlow = (from c in dcMain.PerformanceFlow
                          where c.PerformanceMainCode == MainCode
                          select c).ToList();

            var ListDeptCode = rsFlow.Select(p => p.PerformanceDeptCode).ToList();

            var rsBase = (from c in dcMain.PerformanceBase
                          where c.PerformanceMainCode == MainCode
                          select c).ToList();

            var rsDept = (from c in dcMain.PerformanceDept
                          where c.PerformanceMainCode == MainCode
                          && ListDeptCode.Contains(c.Code)
                          orderby c.DisplayCode
                          select c).ToList();

            lblInfoFlow.Text = rsFlow.Count.ToString();
            lblInfoBase.Text = rsBase.Count.ToString();
            lblInfoFlowComplete.Text = rsFlow.Count(p => p.IsFinish).ToString();
            lblInfoFlowImperfect.Text = rsFlow.Count(p => !p.IsFinish && !p.IsCancel && !p.IsError).ToString();
            lblInfoFlowStop.Text = rsFlow.Count(p => p.IsCancel).ToString();
            var BonusTotal = rsBase.Sum(p => p.BonusCardinal);
            var BonusReal = rsBase.Sum(p => p.BonusReal);
            var BonusBalance = BonusTotal - BonusReal;
            lblInfoBonusTotal.Text = String.Format("${0:N0}", BonusTotal);
            lblInfoBonusReal.Text = String.Format("${0:N0}", BonusReal);
            lblInfoBonusBalance.Text = String.Format("${0:N0}", BonusBalance);

            //獎金分配圖(圓形圖)
            ctInfoBonus.PlotArea.Series.Clear();
            var psInfo = new PieSeries();
            psInfo.LabelsAppearance.Position = Telerik.Web.UI.HtmlChart.PieAndDonutLabelsPosition.OutsideEnd;
            psInfo.LabelsAppearance.DataFormatString = "{0} %";
            psInfo.TooltipsAppearance.Color = Color.White;
            psInfo.TooltipsAppearance.DataFormatString = "{0} %";

            {
                var item = new PieSeriesItem();
                item.Exploded = true;
                item.Name = "未分配獎金";
                item.Y = 0;
                if (BonusTotal > 0)
                item.Y = Math.Round((BonusBalance / BonusTotal) * 100, 1);
                psInfo.SeriesItems.Add(item);

                item = new PieSeriesItem();
                item.Exploded = false;
                item.Name = "已分配獎金";
                item.Y = 0;
                if (BonusTotal > 0)
                    item.Y = Math.Round((BonusReal / BonusTotal) * 100, 1);
                psInfo.SeriesItems.Add(item);
            }
            ctInfoBonus.PlotArea.Series.Add(psInfo);

            //評等分配圖(圓形圖)
            ctInfoRating.PlotArea.Series.Clear();
            psInfo = new PieSeries();
            psInfo.LabelsAppearance.Position = Telerik.Web.UI.HtmlChart.PieAndDonutLabelsPosition.OutsideEnd;
            psInfo.LabelsAppearance.DataFormatString = "{0} %";
            psInfo.TooltipsAppearance.Color = Color.White;
            psInfo.TooltipsAppearance.DataFormatString = "{0} %";

            var BaseRowCount = Convert.ToDecimal(rsBase.Count);
            foreach (var rRating in rsRating)
            {
                var item = new PieSeriesItem();
                item.Exploded = false;
                item.Name = rRating.Text;
                var RatingRowCount = rsBase.Where(p => p.RatingCode == rRating.Value).ToList().Count;
                item.Y = Math.Round((RatingRowCount / BaseRowCount) * 100, 1);
                psInfo.SeriesItems.Add(item);

                if (item.Name == "甲")
                    item.Exploded = true;
            }
            ctInfoRating.PlotArea.Series.Add(psInfo);

            //各部門獎金(直條圖)     
            ctInfoDept.PlotArea.Series.Clear();
            ctInfoDept.PlotArea.XAxis.Items.Clear();
            var bsInfo = new BarSeries();
            bsInfo.Name = "已分配獎金";
            bsInfo.Stacked = true;
            bsInfo.Gap = 1.5;
            bsInfo.Spacing = 0.4;
            bsInfo.LabelsAppearance.DataFormatString = "${0}";
            bsInfo.LabelsAppearance.Position = Telerik.Web.UI.HtmlChart.BarColumnLabelsPosition.OutsideEnd;
            bsInfo.TooltipsAppearance.DataFormatString = "${0}";

            foreach (var rDept in rsDept)
            {
                var DeptCode = rDept.Code;
                var Name = rDept.Name;

                BonusReal = rsBase.Where(p => p.PerformanceDeptCode == DeptCode).Sum(p => p.BonusReal);

                var item = new CategorySeriesItem();
                item.Y = BonusReal;
                bsInfo.SeriesItems.Add(item);

                var Aitem = new AxisItem();
                Aitem.LabelText = Name;
                ctInfoDept.PlotArea.XAxis.Items.Add(Aitem);

            }
            ctInfoDept.PlotArea.Series.Add(bsInfo);

            bsInfo = new BarSeries();
            bsInfo.Name = "未分配獎金";
            bsInfo.LabelsAppearance.DataFormatString = "${0}";
            bsInfo.LabelsAppearance.Position = Telerik.Web.UI.HtmlChart.BarColumnLabelsPosition.Center;
            bsInfo.LabelsAppearance.Visible = false;
            bsInfo.TooltipsAppearance.DataFormatString = "${0}";

            foreach (var rDept in rsDept)
            {
                var DeptCode = rDept.Code;

                BonusTotal = rsBase.Where(p => p.PerformanceDeptCode == DeptCode).Sum(p => p.BonusCardinal);
                BonusReal = rsBase.Where(p => p.PerformanceDeptCode == DeptCode).Sum(p => p.BonusReal);
                BonusBalance = BonusTotal - BonusReal;

                var item = new CategorySeriesItem();
                item.Y = 0;
                if (BonusBalance >= 0)
                    item.Y = BonusBalance;
                bsInfo.SeriesItems.Add(item);
            }
            ctInfoDept.PlotArea.Series.Add(bsInfo);

            bsInfo = new BarSeries();
            bsInfo.Name = "超發獎金";
            bsInfo.LabelsAppearance.DataFormatString = "${0}";
            bsInfo.LabelsAppearance.Position = Telerik.Web.UI.HtmlChart.BarColumnLabelsPosition.Center;
            bsInfo.LabelsAppearance.Visible = false;
            bsInfo.TooltipsAppearance.DataFormatString = "${0}";

            foreach (var rDept in rsDept)
            {
                var DeptCode = rDept.Code;

                BonusTotal = rsBase.Where(p => p.PerformanceDeptCode == DeptCode).Sum(p => p.BonusCardinal);
                BonusReal = rsBase.Where(p => p.PerformanceDeptCode == DeptCode).Sum(p => p.BonusReal);
                BonusBalance = BonusTotal - BonusReal;

                var item = new CategorySeriesItem();
                item.Y = 0;
                if (BonusBalance < 0)
                    item.Y = Math.Abs(BonusBalance);

                bsInfo.SeriesItems.Add(item);
            }
            ctInfoDept.PlotArea.Series.Add(bsInfo);
        }
        //相關資訊


        protected void btnExportExcel_Click(object sender, EventArgs e)
        {

        }

    }
}