using Bll.Performance.Vdb;
using Bll.Tools;
using Dal;
using Dal.Dao;
using Dal.Dao.Share;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace Performance
{
    public partial class MainBaseView : WebPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                UnobtrusiveSession.Session["ActivePage"] = WebPage.GetActivePage;
            }

            ScriptManager.GetCurrent(this).RegisterPostBackControl(btnExportReport);
        }

        public void _DataBind()
        {

        }

        public List<BaseViewRow> ListBaseView
        {
            get
            {
                var Value = new List<BaseViewRow>();
                if (WebPage.DataCache && UnobtrusiveSession.Session["BaseView"] != null && UnobtrusiveSession.Session["BonusView"] != null)
                {
                    Value = (List<BaseViewRow>)UnobtrusiveSession.Session["BaseView"];
                }
                else
                {
                    var TypeCode = lblTypeCode.Text;
                    var MainCode = lblMainCode.Text;
                    var DeptCode = lblDeptCode.Text;
                    var SubDept = lblSubDept.Text == "1";
                    var Base = lblBase.Text == "1";

                    var EmpId = _User.UserCode;

                    if (TypeCode.Length == 0 || MainCode.Length == 0 || DeptCode.Length == 0)
                        return Value;

                    //取得所有部門
                    var rsDeptAll = (from c in dcMain.PerformanceDept
                                     where c.PerformanceMainCode == MainCode
                                     select c).ToList();

                    //取得當前部門
                    var rDept = rsDeptAll.FirstOrDefault(p => p.Code == DeptCode);

                    if (rDept == null)
                    {
                        lblMsg.Text = "沒有產生部門";
                        return Value;
                    }

                    //可視層級
                    var DeptTreeB = rDept.DeptTreeB;

                    //路徑
                    var PathCode = rDept.PathCode;

                    //加入子部門
                    var rsDept = rsDeptAll.Where(p => p.PathCode.IndexOf(PathCode) >= 0).ToList();

                    //部門清單
                    var ListDeptCode = rsDept.Select(p => p.Code).ToList();

                    //取得最高部門主管層級
                    var TopDeptTree = rsDeptAll.Where(p => p.ManagerId == EmpId).Max(p => p.DeptTree);

                    //取得最上層部門
                    var TopDeptCode = rsDept.OrderByDescending(p => p.DeptTree).First().Code;

                    //必須大於等於
                    var BonusView = TopDeptTree >= DeptTreeB;

                    Value = (from r in dcMain.PerformanceBase
                             join c in dcMain.PerformanceRating on r.RatingCode equals c.Code
                             where r.PerformanceMainCode == MainCode
                             && r.EmpCategoryCode == c.EmpCategoryCode
                             && ((SubDept && ListDeptCode.Contains(r.PerformanceDeptCode)) || (r.PerformanceDeptCode == DeptCode))
                             && r.EmpId != EmpId
                             select new BaseViewRow
                             {
                                 AutoKey = r.AutoKey,
                                 EmpId = r.EmpId,
                                 EmpName = r.EmpName,
                                 JobName = r.JobName,
                                 WorkPerformance = r.WorkPerformance,
                                 MannerEsteem = r.MannerEsteem,
                                 AbilityEsteem = r.AbilityEsteem,
                                 Encourage = r.Encourage,
                                 TotalIntegrate = r.TotalIntegrate,
                                 RatingName = c.Name,
                                 BonusCardinal = r.BonusCardinal,
                                 InWorkSpecific = r.InWorkSpecific,
                                 BonusDeduct = r.BonusDeduct,
                                 BonusMax = r.BonusMax,
                                 BonusAdjust = r.BonusAdjust,
                                 BonusReal = r.BonusReal,
                                 Note = r.Note,
                             }).ToList();

                    UnobtrusiveSession.Session["BaseView"] = Value;
                    UnobtrusiveSession.Session["BonusView"] = BonusView;
                }

                return Value;
            }
        }

        public class BaseViewRow
        {
            public int AutoKey { get; set; }
            public string EmpId { get; set; }
            public string EmpName { get; set; }
            public string JobName { get; set; }
            public decimal WorkPerformance { get; set; }
            public decimal MannerEsteem { get; set; }
            public decimal AbilityEsteem { get; set; }
            public decimal Encourage { get; set; }
            public decimal TotalIntegrate { get; set; }
            public string RatingName { get; set; }
            public decimal BonusCardinal { get; set; }
            public decimal InWorkSpecific { get; set; }
            public decimal BonusDeduct { get; set; }
            public decimal BonusMax { get; set; }
            public decimal BonusAdjust { get; set; }
            public decimal BonusReal { get; set; }
            public string Note { get; set; }
        }

        protected void btnExportExcel_Click(object sender, EventArgs e)
        {
            var rs = ListBaseView;

            var BonusView = false;
            if (UnobtrusiveSession.Session["BonusView"] != null)
                BonusView = Convert.ToBoolean(UnobtrusiveSession.Session["BonusView"]);

            //處理html
            foreach (var r in rs)
            {
            }

            var dt = rs.CopyToDataTable();

            //移除不顯示的欄位
            if (!BonusView)
            {
                dt.Columns.Remove("BonusCardinal");
                dt.Columns.Remove("InWorkSpecific");
                dt.Columns.Remove("BonusDeduct");
                dt.Columns.Remove("BonusMax");
                dt.Columns.Remove("BonusAdjust");
                dt.Columns.Remove("BonusReal");
            }

            //更改欄位名稱
            var ListGroupCode = new List<string>();
            ListGroupCode.Add("PerformanceBase");
            AccessData.SetColumnsName(dt, ListGroupCode);

            var stream = CNPOI.RenderDataTableToExcel(dt);
            var FileName = Guid.NewGuid().ToString() + ".xls";

            Byte[] bytes = new byte[stream.Length];
            stream.Read(bytes, 0, int.Parse(stream.Length.ToString()));
            stream.Close();

            Response.Clear();
            Response.AddHeader("content-disposition", "attachment;filename=" + HttpUtility.UrlEncode(FileName, Encoding.UTF8));
            //Response.ContentType = "application/vnd.ms-excel";
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.OutputStream.Write(bytes, 0, bytes.Length);
            Response.OutputStream.Flush();
            Response.OutputStream.Close();
            Response.Flush();
            Response.End();
        }

        protected void lvMain_NeedDataSource(object sender, RadListViewNeedDataSourceEventArgs e)
        {
            UnobtrusiveSession.Session["BaseView"] = null;

            var rs = ListBaseView;

            var BonusView = false;
            if (UnobtrusiveSession.Session["BonusView"] != null)
                BonusView = Convert.ToBoolean(UnobtrusiveSession.Session["BonusView"]);

            //移除不顯示的欄位
            if (!BonusView)
            {
                foreach (var r in rs)
                {
                    r.BonusCardinal = 0;
                    r.InWorkSpecific = 0;
                    r.BonusDeduct = 0;
                    r.BonusMax = 0;
                    r.BonusAdjust = 0;
                    r.BonusReal = 0;
                }
            }

            lvMain.DataSource = rs;

            var Script = "$(document).ready(function() {$('.footable').footable();});";
            ScriptManager.RegisterStartupScript(this, typeof(UpdatePanel), "footable", Script, true);
        }

        protected void lvMain_DataBound(object sender, EventArgs e)
        {


        }

        public List<DeptViewRow> ListDeptView
        {
            get
            {
                var Value = new List<DeptViewRow>();
                if (WebPage.DataCache && UnobtrusiveSession.Session["DeptView"] != null)
                {
                    Value = (List<DeptViewRow>)UnobtrusiveSession.Session["DeptView"];
                }
                else
                {
                    var TypeCode = lblTypeCode.Text;
                    var MainCode = lblMainCode.Text;
                    var DeptCode = lblDeptCode.Text;
                    var SubDept = lblSubDept.Text == "1";
                    var Base = lblBase.Text == "1";

                    var EmpId = _User.UserCode;

                    if (TypeCode.Length == 0 || MainCode.Length == 0 || DeptCode.Length == 0)
                        return Value;

                    //取得部門
                    var rsDept = (from c in dcMain.PerformanceDept
                                  where c.PerformanceMainCode == MainCode
                                  && c.PathCode.IndexOf(DeptCode) >= 0
                                  select c).ToList();

                    var ListDeptCode = rsDept.Select(p => p.Code).ToList();

                    //取得人員資料
                    var rsBase = (from c in dcMain.PerformanceBase
                                  where c.PerformanceMainCode == MainCode
                                  && ListDeptCode.Contains(c.PerformanceDeptCode)
                                  && c.EmpId != EmpId
                                  select c).ToList();

                    var rs = (from c in rsDept
                              select new DeptViewRow
                              {
                                  AutoKey = c.AutoKey,
                                  Code = c.Code,
                                  Name = c.Name,
                                  PeopleNumber = rsBase.Where(p => p.PerformanceDeptCode == c.Code).Count(),
                                  BonusAdjust = rsBase.Where(p => p.PerformanceDeptCode == c.Code).Sum(p => p.BonusAdjust),
                                  //獎金基數<br>總額
                                  BonusCardinalSubDept = rsBase.Where(p =>
                                  rsDept.Where(d => d.PathCode.IndexOf("/" + c.Code + "/") >= 0).Select(s => s.Code).ToList().
                                  Contains(p.PerformanceDeptCode)).Sum(p => p.BonusCardinal),
                                  //跨單位<br>可調整金額
                                  BonusAdjustSubDept = -rsBase.Where(p =>
                                  rsDept.Where(d => d.PathCode.IndexOf("/" + c.Code + "/") >= 0).Select(s => s.Code).ToList().
                                  Contains(p.PerformanceDeptCode)).Sum(p => p.BonusAdjust),
                                  //已分配<br>總額
                                  BonusRealSubDept = rsBase.Where(p =>
                                  rsDept.Where(d => d.PathCode.IndexOf("/" + c.Code + "/") >= 0).Select(s => s.Code).ToList().
                                  Contains(p.PerformanceDeptCode)).Sum(p => p.BonusReal),
                              }).ToList();

                    Value = (from c in rs
                             where c.PeopleNumber > 0
                             select c).ToList();

                    UnobtrusiveSession.Session["DeptView"] = Value;
                }

                return Value;
            }
        }


        public class DeptViewRow
        {
            public int AutoKey { get; set; }
            public string Code { get; set; }
            public string Name { get; set; }
            public int PeopleNumber { get; set; }
            public decimal BonusAdjust { get; set; }
            public decimal BonusCardinalSubDept { get; set; }
            public decimal BonusAdjustSubDept { get; set; }
            public decimal BonusRealSubDept { get; set; }
        }

        protected void btnExportExcel1_Click(object sender, EventArgs e)
        {
            var rs = ListDeptView;

            var BonusView = false;
            if (UnobtrusiveSession.Session["BonusView"] != null)
                BonusView = Convert.ToBoolean(UnobtrusiveSession.Session["BonusView"]);

            //處理html
            foreach (var r in rs)
            {
            }

            var dt = rs.CopyToDataTable();

            //移除不顯示的欄位
            dt.Columns.Remove("BonusAdjust");
            if (!BonusView)
            {
                dt.Columns.Remove("BonusCardinalSubDept");
                dt.Columns.Remove("BonusAdjustSubDept");
                dt.Columns.Remove("BonusRealSubDept");
            }

            //移除不顯示的欄位

            //更改欄位名稱
            var ListGroupCode = new List<string>();
            ListGroupCode.Add("PerformanceDept");
            AccessData.SetColumnsName(dt, ListGroupCode);

            var stream = CNPOI.RenderDataTableToExcel(dt);
            var FileName = Guid.NewGuid().ToString() + ".xls";

            Byte[] bytes = new byte[stream.Length];
            stream.Read(bytes, 0, int.Parse(stream.Length.ToString()));
            stream.Close();

            Response.Clear();
            Response.AddHeader("content-disposition", "attachment;filename=" + HttpUtility.UrlEncode(FileName, Encoding.UTF8));
            //Response.ContentType = "application/vnd.ms-excel";
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.OutputStream.Write(bytes, 0, bytes.Length);
            Response.OutputStream.Flush();
            Response.OutputStream.Close();
            Response.Flush();
            Response.End();
        }

        protected void lvMain1_NeedDataSource(object sender, RadListViewNeedDataSourceEventArgs e)
        {
            var rs = ListDeptView;

            var BonusView = false;
            if (UnobtrusiveSession.Session["BonusView"] != null)
                BonusView = Convert.ToBoolean(UnobtrusiveSession.Session["BonusView"]);

            //移除不顯示的欄位
            if (!BonusView)
            {
                foreach (var r in rs)
                {
                    r.BonusAdjust = 0;
                    r.BonusCardinalSubDept = 0;
                    r.BonusAdjustSubDept = 0;
                    r.BonusRealSubDept = 0;
                }
            }

            lvMain1.DataSource = rs;

            var Script = "$(document).ready(function() {$('.footable1').footable();});";
            ScriptManager.RegisterStartupScript(this, typeof(UpdatePanel), "footable", Script, true);
        }

        protected void lvMain1_DataBound(object sender, EventArgs e)
        {

        }

        public class ReportContentRow
        {
            public int AutoKey { get; set; }
            public string Code { get; set; }
            public string ReportContentCode { get; set; }
            public string ReportContentName { get; set; }
            public string ContentTargetType { get; set; }
            public string ContentTargetRef { get; set; }
            public int ReportContentSort { get; set; }
            public int Sort { get; set; }
        }

        protected void btnExportReport_Click(object sender, EventArgs e)
        {
            var TypeCode = lblTypeCode.Text;
            var MainCode = lblMainCode.Text;
            var EmpCategoryCode = lblEmpCategoryCode.Text;
            var DeptCode = lblDeptCode.Text;
            var SubDept = lblSubDept.Text == "1";
            var Base = lblBase.Text == "1";

            if (TypeCode.Length == 0 || MainCode.Length == 0 || DeptCode.Length == 0)
            {
                lblMsg.Text = "資訊不正確";
                return;
            }

            //準備匯出資料
            //取得主檔資料
            var rMain = dcMain.PerformanceMain.FirstOrDefault(p => p.Code == MainCode);

            if (rMain == null)
            {
                lblMsg.Text = "主檔資訊不正確";
                return;
            }

            //取得員工資料
            var rsBase = (from c in dcMain.PerformanceBase
                          where c.PerformanceMainCode == MainCode
                          && c.PerformanceDeptCode == DeptCode
                          && c.EmpId != _User.UserCode
                          select c).ToList();

            if (rsBase.Count == 0)
            {
                lblMsg.Text = "沒有員工需要匯出";
                return;
            }

            //部門資料
            var rsDept = (from c in dcMain.PerformanceDept
                          where c.PerformanceMainCode == MainCode
                          select c).ToList();

            //職稱資料
            //var rsJob = (from c in dcMain.PerformanceJob
            //             where c.PerformanceMainCode == MainCode
            //             select c).ToList();

            //引用HR
            var rsJob = (from c in dcHr.ViewJob
                         select new
                         {
                             JobCode = c.Code,
                             JobName = c.Name,
                         }).ToList();

            //評核等級
            var rsRating = (from c in dcMain.PerformanceRating
                            where c.EmpCategoryCode == EmpCategoryCode
                            select c).ToList();

            //取得樣版主檔-表頭、表尾
            var ListBaseJobCode = rsBase.Select(p => p.JobCode).ToList();
            var ListDeptCode = rsBase.Select(p => p.PerformanceDeptCode).ToList();

            //職稱可使用的樣版
            var rsReportTypeJob = (from c in dcMain.PerformanceReportTypeJob
                                   where (ListBaseJobCode.Contains(c.JobCode) || c.JobCode == "*")
                                   select c).ToList();

            //部門可使用的樣版
            var rsReportTypeDept = (from c in dcMain.PerformanceReportTypeDept
                                    where (ListDeptCode.Contains(c.DeptCode) || c.DeptCode == "*")
                                    select c).ToList();

            var ListReportTypeCode = rsReportTypeJob.Select(p => p.PerformanceReportTypeCode).ToList();
            ListReportTypeCode.AddRange(rsReportTypeDept.Select(p => p.PerformanceReportTypeCode).ToList());

            //取得樣版主檔
            var rsReportType = (from c in dcMain.PerformanceReportType
                                where c.EmpCategoryCode == EmpCategoryCode
                                && ListReportTypeCode.Contains(c.Code)
                                select c).ToList();

            //取得樣版內容
            var rsReportContent = (from c in dcMain.PerformanceReportContent
                                   where ListReportTypeCode.Contains(c.PerformanceReportTypeCode)
                                   orderby c.ReportContentCode, c.Sort
                                   select new ReportContentRow
                                   {
                                       AutoKey = c.AutoKey,
                                       Code = c.Code,
                                       ReportContentCode = c.ReportContentCode,
                                       ReportContentName = "",
                                       ContentTargetType = c.ContentTargetType,
                                       ContentTargetRef = c.ContentTargetRef,
                                       ReportContentSort = 0,
                                       Sort = c.Sort,
                                   }).ToList();

            //取得樣版內容-部門
            var rsReportContentDept = (from c in dcMain.PerformanceReportContentDept
                                       where c.PerformanceMainCode == MainCode
                                       && c.PerformanceDeptCode == DeptCode
                                       && ListReportTypeCode.Contains(c.PerformanceReportTypeCode)
                                       select new ReportContentRow
                                       {
                                           AutoKey = c.AutoKey,
                                           Code = c.Code,
                                           ReportContentCode = c.ReportContentCode,
                                           ReportContentName = "",
                                           ContentTargetType = c.ContentTargetType,
                                           ContentTargetRef = c.ContentTargetRef,
                                           ReportContentSort = 0,
                                           Sort = c.Sort,
                                       }).ToList();

            //採用代碼
            var rsReportContentCode = oMainDao.ShareCodeTextValue("ReportContent");

            //初始化
            Document Doc = new Document();
            MemoryStream Memory = new MemoryStream();
            PdfWriter PdfWriter = PdfWriter.GetInstance(Doc, Memory);

            //字型設定
            string FontPath = Server.MapPath("Fonts/Arial-Unicode-MS.ttf");
            BaseFont bfChinese = BaseFont.CreateFont(FontPath, BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
            Font ChFont = new Font(bfChinese, 9);
            Font ChFontTitle = new Font(bfChinese, 14);
            Font ChFontBaseData = new Font(bfChinese, 12);
            Font ChFontBig = new Font(bfChinese, 50);
            Font ChFont_Red = new Font(bfChinese, 10, Font.NORMAL, BaseColor.RED);

            var imgLogo = iTextSharp.text.Image.GetInstance(Server.MapPath("~/images/ReportTitle.jpg"));
            float percentage = 1;
            //這裡都是圖片最原始的寬度與高度  
            //float resizedWidht = image.Width;
            //float resizedHeight = image.Height;
            ////這裡用計算出來的百分比來縮小圖片  
            imgLogo.ScalePercent(percentage * 50);
            //讓圖片的中心點與頁面的中心店進行重合  
            //imgLogo.SetAbsolutePosition(doc.PageSize.Width / 2 - resizedWidht / 2, doc.PageSize.Height / 2 - resizedHeight / 2);
            //imgLogo.ScaleToFit(200f, 230f);
            //imgLogo.BorderWidth = 5f;

            //開檔
            Doc.Open();

            PdfContentByte cb = PdfWriter.DirectContent;
            PdfOutline rootOutline = cb.RootOutline;

            var Page = 1;
            int iCount = 0;
            foreach (var rBase in rsBase)
            {
                //開新頁
                if (Page > 1)
                    Doc.NewPage();

                var ListScore = new Dictionary<string, int>();
                ListScore.Add("WorkPerformance", Convert.ToInt32(rBase.WorkPerformance));
                ListScore.Add("MannerEsteem", Convert.ToInt32(rBase.MannerEsteem));
                ListScore.Add("AbilityEsteem", Convert.ToInt32(rBase.AbilityEsteem));
                ListScore.Add("Encourage", Convert.ToInt32(rBase.Encourage));
                var TotalIntegrate = Convert.ToInt32(rBase.TotalIntegrate);

                var RatingName = rsRating.FirstOrDefault(p => p.Code == rBase.RatingCode)?.Name ?? "";

                var Note = rBase.Note;

                //設定幾欄
                var Tb = new PdfPTable(new float[] { 1, 4, 5, 1, 2 });
                Tb.WidthPercentage = 100; // percentage          
                Tb.DefaultCell.Padding = 1;
                Tb.DefaultCell.BorderWidth = 1;
                Tb.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;

                //標題欄(放圖片)
                Paragraph Title = new Paragraph("台光電子材料股份有限公司", ChFont);

                PdfPCell cellTitle = new PdfPCell(imgLogo);
                cellTitle.Colspan = 5;
                cellTitle.HorizontalAlignment = Element.ALIGN_CENTER;
                cellTitle.VerticalAlignment = Element.ALIGN_MIDDLE;
                cellTitle.FixedHeight = 50f;
                cellTitle.Border = 0;
                Tb.AddCell(cellTitle);

                var JobCode = rBase.JobCode;
                DeptCode = rBase.PerformanceDeptCode;
                EmpCategoryCode = rBase.EmpCategoryCode;

                //職稱可使用的樣版
                var rsReportTypeJobTemp = (from c in rsReportTypeJob
                                           where (c.JobCode == JobCode || c.JobCode == "*")
                                           select c).ToList();

                //部門可使用的樣版
                var rsReportTypeDeptTemp = (from c in rsReportTypeDept
                                            where (c.DeptCode == DeptCode || c.DeptCode == "*")
                                            select c).ToList();

                ListReportTypeCode = new List<string>();
                ListReportTypeCode = rsReportTypeJobTemp.Select(p => p.PerformanceReportTypeCode).ToList();
                ListReportTypeCode.AddRange(rsReportTypeDeptTemp.Select(p => p.PerformanceReportTypeCode).ToList());

                //取得樣版主檔
                var rReportTyp = rsReportType.FirstOrDefault(c => c.EmpCategoryCode == EmpCategoryCode && ListReportTypeCode.Contains(c.Code));

                if (rReportTyp == null)
                    continue;
                else
                {
                    var ReportTypName = rMain.Name;

                    //標題欄
                    Title = new Paragraph(ReportTypName, ChFontTitle);
                    cellTitle = new PdfPCell(Title);
                    cellTitle.Colspan = 5;
                    cellTitle.HorizontalAlignment = Element.ALIGN_CENTER;
                    cellTitle.Border = 0;
                    Tb.AddCell(cellTitle);

                    var Text = HtmlToText.ConvertHtml(rReportTyp.ContentHead);
                    var CellText = new Paragraph(Text, ChFont);
                    var Cell = new PdfPCell(CellText);
                    Cell.Colspan = 5;
                    Cell.Border = 0;

                    //頁首
                    if (rReportTyp.ContentHead.Length > 0)
                        Tb.AddCell(Cell);

                    //第三列 基本資料
                    var DeptName = rsDept.FirstOrDefault(p => p.Code == rBase.PerformanceDeptCode)?.Name ?? "";
                    var JobName = rsJob.FirstOrDefault(p => p.JobCode == rBase.JobCode)?.JobName ?? "";
                    var EmpId = rBase.EmpId;
                    var EmpName = rBase.EmpName;

                    Text = "部門：" + DeptName + "　　　　職稱：" + JobName + "　　　　工號：" + EmpId + "　　　　姓名：" + EmpName;
                    CellText = new Paragraph(Text, ChFontBaseData);
                    Cell = new PdfPCell(CellText);
                    Cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    Cell.Colspan = 5;
                    Cell.Border = 0;
                    Tb.AddCell(Cell);

                    //第四列 標題
                    CellText = new Paragraph("考評\n內容", ChFont);
                    Cell = new PdfPCell(CellText);
                    Cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    Cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                    Tb.AddCell(Cell);

                    CellText = new Paragraph("指標類型/分值", ChFont);
                    Cell = new PdfPCell(CellText);
                    Cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    Cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                    Tb.AddCell(Cell);

                    CellText = new Paragraph("具體指標或非量化參考指標", ChFont);
                    Cell = new PdfPCell(CellText);
                    Cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    Cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                    Tb.AddCell(Cell);

                    CellText = new Paragraph("考評\n分數", ChFont);
                    Cell = new PdfPCell(CellText);
                    Cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    Cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                    Tb.AddCell(Cell);

                    CellText = new Paragraph("優劣事蹟及\n改善措施", ChFont);
                    Cell = new PdfPCell(CellText);
                    Cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    Cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                    Tb.AddCell(Cell);

                    var RowTotal = 0;
                    //先計算全部有幾列
                    foreach (var rReportContentCode in rsReportContentCode)
                    {
                        var ReportContentCode = rReportContentCode.Value;

                        //計算有幾列
                        var rsReportContentTemp = rsReportContentDept.Where(p => p.ReportContentCode == ReportContentCode).ToList();
                        if (rsReportContentTemp.Count == 0)
                            rsReportContentTemp = rsReportContent.Where(p => p.ReportContentCode == ReportContentCode).ToList();

                        RowTotal += rsReportContentTemp.Count;
                    }

                    //內文
                    var Cell5Index = 0;
                    foreach (var rReportContentCode in rsReportContentCode)
                    {
                        var ReportContentCode = rReportContentCode.Value;
                        var ReportContentName = rReportContentCode.Text;

                        //計算有幾列
                        var rsReportContentTemp = rsReportContentDept.Where(p => p.ReportContentCode == ReportContentCode).ToList();
                        if (rsReportContentTemp.Count == 0)
                            rsReportContentTemp = rsReportContent.Where(p => p.ReportContentCode == ReportContentCode).ToList();

                        //如果沒有建此考評內容的樣版，就略過
                        if (rsReportContentTemp.Count == 0)
                            continue;

                        Text = ReportContentName;
                        CellText = new Paragraph(Text, ChFont);
                        Cell = new PdfPCell(CellText);
                        Cell.HorizontalAlignment = Element.ALIGN_CENTER;
                        Cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        Cell.Rowspan = rsReportContentTemp.Count;
                        Tb.AddCell(Cell);

                        var Cell4Index = 0;
                        foreach (var rReportContent in rsReportContentTemp)
                        {
                            Cell4Index++;
                            Cell5Index++;

                            //指標類型/分值
                            Text = HtmlToText.ConvertHtml(rReportContent.ContentTargetType);
                            CellText = new Paragraph(Text, ChFont);
                            Cell = new PdfPCell(CellText);
                            Tb.AddCell(Cell);

                            //具體指標或非量化參考指標
                            Text = HtmlToText.ConvertHtml(rReportContent.ContentTargetRef);
                            CellText = new Paragraph(Text, ChFont);
                            Cell = new PdfPCell(CellText);
                            Tb.AddCell(Cell);

                            //考評分數
                            if (Cell4Index == 1)
                            {
                                Text = ListScore[ReportContentCode].ToString();
                                CellText = new Paragraph(Text, ChFont);
                                Cell = new PdfPCell(CellText);
                                Cell.HorizontalAlignment = Element.ALIGN_RIGHT;
                                Cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                                Cell.Rowspan = rsReportContentTemp.Count;
                                Cell.BackgroundColor = new BaseColor(System.Drawing.Color.LightGray);
                                Tb.AddCell(Cell);
                            }

                            //空白 只有第一列才需要畫出來
                            if (Cell5Index == 1)
                            {
                                Text = "";
                                CellText = new Paragraph(Text, ChFont);
                                Cell = new PdfPCell(CellText);
                                Cell.Rowspan = RowTotal;
                                Tb.AddCell(Cell);
                            }
                        }
                    }

                    CellText = new Paragraph("備註", ChFont);
                    Cell = new PdfPCell(CellText);
                    Cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    Cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                    Tb.AddCell(Cell);

                    Text = Note;
                    CellText = new Paragraph(Text, ChFont);
                    Cell = new PdfPCell(CellText);
                    Cell.Colspan = 4;
                    Cell.BackgroundColor = new BaseColor(System.Drawing.Color.Yellow);
                    Tb.AddCell(Cell);

                    CellText = new Paragraph("評核總分", ChFont);
                    Cell = new PdfPCell(CellText);
                    Cell.Colspan = 3;
                    Cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    Cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                    Tb.AddCell(Cell);

                    Text = TotalIntegrate.ToString();
                    CellText = new Paragraph(Text, ChFont);
                    Cell = new PdfPCell(CellText);
                    Cell.Colspan = 2;
                    Cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    Cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                    Cell.BackgroundColor = new BaseColor(System.Drawing.Color.Yellow);
                    Tb.AddCell(Cell);

                    CellText = new Paragraph("評核等級\n甲等：經常超過職務要求；乙等：符合職務要求；丙等：經常不符合職務要求，需培訓", ChFont);
                    Cell = new PdfPCell(CellText);
                    Cell.Colspan = 3;
                    Cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    Cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                    Tb.AddCell(Cell);

                    Text = RatingName;
                    CellText = new Paragraph(Text, ChFont);
                    Cell = new PdfPCell(CellText);
                    Cell.Colspan = 2;
                    Cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    Cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                    Cell.BackgroundColor = new BaseColor(System.Drawing.Color.Yellow);
                    Tb.AddCell(Cell);

                    CellText = new Paragraph("直屬主管簽名/複考主管簽名", ChFont);
                    Cell = new PdfPCell(CellText);
                    Cell.Colspan = 3;
                    Cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    Cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                    Cell.FixedHeight = 30f;
                    //Cell.PaddingTop = 15f;
                    //Cell.PaddingBottom = 15f;
                    Tb.AddCell(Cell);

                    Text = "";
                    CellText = new Paragraph(Text, ChFont);
                    Cell = new PdfPCell(CellText);
                    Cell.Colspan = 2;
                    Cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    Cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                    Tb.AddCell(Cell);

                    var chunkText1 = new Chunk("員工意見簽名欄", ChFont_Red);
                    var chunkText2 = new Chunk("\n員工意見簽名欄(直屬主管及複考主管簽核完畢由直屬主管約談員工)", ChFont);

                    //CellText = new Paragraph(Text, ChFont);
                    CellText = new Paragraph();
                    CellText.Add(chunkText1);
                    CellText.Add(chunkText2);
                    Cell = new PdfPCell(CellText);
                    Cell.Colspan = 3;
                    Cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    Cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                    Cell.FixedHeight = 30f;
                    //Cell.PaddingTop = 10f;
                    //Cell.PaddingBottom = 10f;
                    Tb.AddCell(Cell);

                    Text = "";
                    CellText = new Paragraph(Text, ChFont);
                    Cell = new PdfPCell(CellText);
                    Cell.Colspan = 2;
                    Cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    Cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                    Tb.AddCell(Cell);

                    //頁尾
                    Text = HtmlToText.ConvertHtml(rReportTyp.ContentFooter);
                    CellText = new Paragraph(Text, ChFont);
                    Cell = new PdfPCell(CellText);
                    Cell.Colspan = 5;
                    Cell.Border = 0;
                    Tb.AddCell(Cell);

                    //加入頁面的抬頭
                    //Doc.Add(Title);
                    //把表格插入到頁面
                    Doc.Add(Tb);

                    //目錄
                    Text = EmpId + "," + EmpName;
                    CellText = new Paragraph(Text, ChFont);

                    PdfAction action = PdfAction.GotoLocalPage(Page, new PdfDestination(PdfDestination.FIT), PdfWriter);
                    PdfOutline outline = new PdfOutline(rootOutline, action, CellText);

                    Page++;
                    iCount++;
                }
            }

            if (iCount == 0)
            {
                lblMsg.Text = "沒有員工需要匯出";
                return;
            }

            //關閉
                Doc.Close();

            //浮水印及密碼
            var oShareDefault = new ShareDefaultDao(WebPage.dcShare);
            var rSystem = oShareDefault.DefaultSystem;
            var UniversalPassword = rSystem.UniversalAccountPassword;

            //引用HR
            var rBase1 = (from c in dcHr.ViewEmp
                          where c.Code == _User.UserCode
                          select c).First();

            var Password = rBase1.Password.Trim();
            byte[] bytes = Memory.ToArray();

            PdfReader reader = new PdfReader(bytes);
            reader.ViewerPreferences = 4096;

            using (MemoryStream memoryStream = new MemoryStream())
            {
                var stamp = new PdfStamper(reader, memoryStream);
                stamp.SetEncryption(true, Password, UniversalPassword, 2052);
                int count1 = reader.NumberOfPages;

                iTextSharp.text.pdf.PdfGState pdfgstate = new iTextSharp.text.pdf.PdfGState()
                {
                    FillOpacity = 0.4f,
                    StrokeOpacity = 0.4f
                };

                //for (int i = 1; i <= count1; i++)
                for (int i = 1; i < count1; i++)
                {
                    Rectangle pagesize = reader.GetPageSizeWithRotation(i); //每頁的Size
                                                                            //頁尾的文本
                    var txt = "嚴禁傳閱";
                    //Chunk ctitle = new Chunk(txt, FontFactory.GetFont("Arial", 12f, new BaseColor(0, 0, 0)));
                    Chunk ctitle = new Chunk(txt, ChFontBig);
                    Phrase ptitle = new Phrase(ctitle);
                    //浮水印
                    //string imageUrl = HttpContext.Current.Server.MapPath(@"~/File/logo.png"); //Logo
                    //Image img = iTextSharp.text.Image.GetInstance(imageUrl);
                    //img.ScalePercent(20f);  //縮放比例
                    //img.RotationDegrees = 10; //旋轉角度
                    //img.SetAbsolutePosition(10, pagesize.Height - 40); //設定圖片每頁的絕對位置

                    //PdfContentByte類，用設置圖像像和文本的絕對位置
                    var over = stamp.GetOverContent(i);
                    over.SetGState(pdfgstate); //寫入入設定的透明度
                    ColumnText.ShowTextAligned(over, Element.ALIGN_MIDDLE, ptitle, 200, 500, 0); //設定頁尾的絕對位置      
                }

                stamp.FormFlattening = true;
                stamp.Close();

                // iTextSharp.text.pdf.PdfEncryptor.Encrypt(reader, memoryStream, true, Password, UniversalPassword, 2052);

                reader.Close();


                //文件下載
                Response.Clear();
                Response.AddHeader("Content-Disposition", "attachment; filename=" + rMain.Name + "個人評核表.pdf");
                Response.ContentType = "application/octet-stream";

                Response.OutputStream.Write(memoryStream.GetBuffer(), 0, memoryStream.GetBuffer().Length);
                Response.OutputStream.Flush();
                Response.OutputStream.Close();
                Response.Flush();
                Response.End();
            }
        }
    }
}