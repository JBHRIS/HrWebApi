using Bll;
using Bll.Tools;
using Dal;
using Dal.Dao;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace Performance
{
    public partial class MainBaseImport : WebPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                _DataBind();
            }

            lblMsg.Text = "";
        }

        public void _DataBind()
        {
            if (UnobtrusiveSession.Session["TopDeptCode"] == null ||
                UnobtrusiveSession.Session["ListDept"] == null ||
                UnobtrusiveSession.Session["MainCode"] == null)
                return;

            var DeptCode = UnobtrusiveSession.Session["TopDeptCode"].ToString();    //傳送目前點選部門做為審核層級判斷(當前部門為傳簽層級的判斷角度)
            var ListDept = (List<PerformanceDept>)UnobtrusiveSession.Session["ListDept"];
            var MainCode = UnobtrusiveSession.Session["MainCode"].ToString();

            var EmpId = _User.UserCode;



            LoadData(0);
        }

        public void LoadData(int Key)
        {

        }

        FileStream fs;
        HSSFWorkbook workbook;
        ISheet sheet;
        DataTable dt;
        DataRow[] rows;
        DataRow r;

        protected void wz_NextButtonClick(object sender, WizardEventArgs e)
        {
            lblMsg.Text = "";

            switch (e.NextStepIndex)
            {
                case 1: //檔案上傳
                    if (fu.UploadedFiles.Count == 0)
                    {
                        lblMsg.Text = "沒有上傳任何檔案";
                        wz.WizardSteps[0].Active = true;
                        return;
                    }

                    UploadedFile uf = fu.UploadedFiles[0];
                    string ServerName = Guid.NewGuid().ToString() + uf.GetExtension();
                    string Path = @"~/Upload/";
                    string SavePath = MapPath(Path + ServerName);
                    uf.SaveAs(SavePath);

                    lblExcel.Text = uf.FileName;
                    lblFileName.Text = SavePath;

                    fs = new FileStream(lblFileName.Text, FileMode.Open, FileAccess.Read);
                    workbook = new HSSFWorkbook(fs);
                    fs.Close();
                    fs.Dispose();

                    dt = new DataTable();
                    dt.Columns.Add("t", typeof(string)).DefaultValue = 0;
                    dt.Columns.Add("v", typeof(int)).DefaultValue = 0;
                    r = dt.NewRow();
                    r["t"] = "請選擇工作表...";
                    r["v"] = -1;
                    dt.Rows.Add(r);
                    for (int i = 0; i < workbook.NumberOfSheets; i++)
                    {
                        r = dt.NewRow();
                        r["t"] = workbook.GetSheetName(i);
                        r["v"] = i;
                        dt.Rows.Add(r);
                    }

                    ddlSheet.DataSource = dt;
                    ddlSheet.DataValueField = "v";
                    ddlSheet.DataTextField = "t";
                    ddlSheet.DataBind();

                    lblMsg.Text = "上傳完成，請選擇工作表";
                    break;
                case 2: //選擇工作表
                    if (ddlSheet.SelectedItem == null)
                    {
                        lblMsg.Text = "檔案不存在，請重新上傳";
                        wz.WizardSteps[0].Active = true;
                        return;
                    }

                    if (ddlSheet.SelectedItem.Value == "-1")
                    {
                        lblMsg.Text = "請選擇工作表";
                        wz.WizardSteps[1].Active = true;
                        return;
                    }

                    fs = new FileStream(lblFileName.Text, FileMode.Open, FileAccess.Read);
                    workbook = new HSSFWorkbook(fs);
                    fs.Close();
                    fs.Dispose();

                    sheet = workbook.GetSheet(ddlSheet.SelectedItem.Text);
                    if (sheet == null)
                    {
                        lblMsg.Text = "工作表不存在，請重新選擇";
                        wz.WizardSteps[1].Active = true;
                        return;
                    }

                    lblSheet.Text = ddlSheet.SelectedItem.Text;

                    HSSFRow headerRow = sheet.GetRow(0) as HSSFRow;
                    if (headerRow != null)
                    {
                        dt = new DataTable();
                        dt.Columns.Add("t", typeof(string)).DefaultValue = 0;
                        dt.Columns.Add("v", typeof(int)).DefaultValue = 0;

                        r = dt.NewRow();
                        r["t"] = "不匯入";
                        r["v"] = -1;
                        dt.Rows.Add(r);

                        foreach (HSSFCell c in headerRow.Cells)
                        {
                            r = dt.NewRow();
                            r["t"] = c.StringCellValue;
                            r["v"] = c.ColumnIndex;
                            dt.Rows.Add(r);
                        }

                        ddlEmpId.DataSource = dt;
                        ddlEmpId.DataValueField = "v";
                        ddlEmpId.DataTextField = "t";
                        ddlEmpId.DataBind();

                        var ddl = ddlEmpId.FindItemByText("工號");
                        if (ddl != null) ddl.Selected = true;

                        ddlWorkPerformance.DataSource = dt;
                        ddlWorkPerformance.DataValueField = "v";
                        ddlWorkPerformance.DataTextField = "t";
                        ddlWorkPerformance.DataBind();

                        ddl = ddlWorkPerformance.FindItemByText("工作績效");
                        if (ddl != null) ddl.Selected = true;

                        ddlMannerEsteem.DataSource = dt;
                        ddlMannerEsteem.DataValueField = "v";
                        ddlMannerEsteem.DataTextField = "t";
                        ddlMannerEsteem.DataBind();

                        ddl = ddlMannerEsteem.FindItemByText("工作態度");
                        if (ddl != null) ddl.Selected = true;

                        ddlAbilityEsteem.DataSource = dt;
                        ddlAbilityEsteem.DataValueField = "v";
                        ddlAbilityEsteem.DataTextField = "t";
                        ddlAbilityEsteem.DataBind();

                        ddl = ddlAbilityEsteem.FindItemByText("能力評價");
                        if (ddl != null) ddl.Selected = true;

                        ddlEncourage.DataSource = dt;
                        ddlEncourage.DataValueField = "v";
                        ddlEncourage.DataTextField = "t";
                        ddlEncourage.DataBind();

                        ddl = ddlEncourage.FindItemByText("激勵");
                        if (ddl != null) ddl.Selected = true;

                        ddlRating.DataSource = dt;
                        ddlRating.DataValueField = "v";
                        ddlRating.DataTextField = "t";
                        ddlRating.DataBind();

                        ddl = ddlRating.FindItemByText("評等");
                        if (ddl != null) ddl.Selected = true;

                        ddlNote.DataSource = dt;
                        ddlNote.DataValueField = "v";
                        ddlNote.DataTextField = "t";
                        ddlNote.DataBind();

                        ddl = ddlNote.FindItemByText("備註");
                        if (ddl != null) ddl.Selected = true;

                        var DeptCode = UnobtrusiveSession.Session["TopDeptCode"].ToString();    //傳送目前點選部門做為審核層級判斷(當前部門為傳簽層級的判斷角度)
                        var ListDept = (List<PerformanceDept>)UnobtrusiveSession.Session["ListDept"];
                        var MainCode = UnobtrusiveSession.Session["MainCode"].ToString();

                        var EmpId = _User.UserCode;

                        var ListDeptCode = ListDept.Select(p => p.Code).ToList();

                        //取得最上層部門
                        var rDept = (from c in dcMain.PerformanceDept
                                     where c.PerformanceMainCode == MainCode
                                     && c.Code == DeptCode
                                     select c).FirstOrDefault();

                        //取得最高主管部門層級
                        var DeptTree = 0;
                        if (rDept != null)
                            DeptTree = rDept.DeptTree;

                        //判斷最高主管層級必須大於部門設定的可視層級才可以看獎金
                        var rsDept = (from c in dcMain.PerformanceDept
                                      where c.PerformanceMainCode == MainCode
                                      && ListDeptCode.Contains(c.Code)
                                      select c).ToList();

                        var TopDeptTreeB = rsDept.Max(p => p.DeptTreeB);

                        //必須大於等於
                        var BonusView = DeptTree >= TopDeptTreeB;

                        if (!BonusView)
                        {
                            dt = new DataTable();
                            dt.Columns.Add("t", typeof(string)).DefaultValue = 0;
                            dt.Columns.Add("v", typeof(int)).DefaultValue = 0;

                            r = dt.NewRow();
                            r["t"] = "無匯入權限";
                            r["v"] = -1;
                            dt.Rows.Add(r);
                        }

                        ddlBonusAdjust.DataSource = dt;
                        ddlBonusAdjust.DataValueField = "v";
                        ddlBonusAdjust.DataTextField = "t";
                        ddlBonusAdjust.DataBind();

                        ddl = ddlBonusAdjust.FindItemByText("考績加減");
                        if (ddl != null) ddl.Selected = true;

                        lblMsg.Text = "請選擇對應欄位";
                    }
                    break;
                case 3: //選擇對應欄位
                    if (ddlEmpId.SelectedItem.Value == "-1")
                    {
                        lblMsg.Text = "工號欄位不可以不匯入";
                        wz.WizardSteps[2].Active = true;
                        return;
                    }

                    lblEmpId.Text = ddlEmpId.SelectedItem.Text;
                    lblEmpId.ToolTip = ddlEmpId.SelectedItem.Value;
                    lblWorkPerformance.Text = ddlWorkPerformance.SelectedItem.Text;
                    lblWorkPerformance.ToolTip = ddlWorkPerformance.SelectedItem.Value;
                    lblMannerEsteem.Text = ddlMannerEsteem.SelectedItem.Text;
                    lblMannerEsteem.ToolTip = ddlMannerEsteem.SelectedItem.Value;
                    lblAbilityEsteem.Text = ddlAbilityEsteem.SelectedItem.Text;
                    lblAbilityEsteem.ToolTip = ddlAbilityEsteem.SelectedItem.Value;
                    lblEncourage.Text = ddlEncourage.SelectedItem.Text;
                    lblEncourage.ToolTip = ddlEncourage.SelectedItem.Value;
                    lblRating.Text = ddlRating.SelectedItem.Text;
                    lblRating.ToolTip = ddlRating.SelectedItem.Value;
                    lblBonusAdjust.Text = ddlBonusAdjust.SelectedItem.Text;
                    lblBonusAdjust.ToolTip = ddlBonusAdjust.SelectedItem.Value;
                    lblNote.Text = ddlNote.SelectedItem.Text;
                    lblNote.ToolTip = ddlNote.SelectedItem.Value;

                    break;
            }
        }
        protected void wz_PreviousButtonClick(object sender, WizardEventArgs e)
        {
            lblMsg.Text = "";
        }
        protected void wz_FinishButtonClick(object sender, WizardEventArgs e)
        {
            var DeptCode = UnobtrusiveSession.Session["TopDeptCode"].ToString();    //傳送目前點選部門做為審核層級判斷(當前部門為傳簽層級的判斷角度)
            var ListDept = (List<PerformanceDept>)UnobtrusiveSession.Session["ListDept"];
            var MainCode = UnobtrusiveSession.Session["MainCode"].ToString();

            var _UserId = _User.UserCode;

            var ListDeptCode = ListDept.Select(p => p.Code).ToList();

            var oPerformance = new PerformanceDao(dcShare, dcMain, dcHr);

            lblMsg.Text = "";

            fs = new FileStream(lblFileName.Text, FileMode.Open, FileAccess.Read);
            workbook = new HSSFWorkbook(fs);
            fs.Close();
            fs.Dispose();

            sheet = workbook.GetSheet(ddlSheet.SelectedItem.Text);
            if (sheet == null)
            {
                lblMsg.Text = "工作表不存在，請重新選擇";
                wz.WizardSteps[1].Active = true;
                return;
            }

            DataTable dtExcel = CNPOI.RenderDataTableFromExcel(lblFileName.Text, ddlSheet.SelectedItem.Text, 0);

            //先記錄欄位名稱並將第一列刪除
            //object[] oColumns = tbExcel.Rows[0].ItemArray;
            //dtExcel.Rows[0].Delete();
            //dtExcel.AcceptChanges();

            //取得員工基本資料
            var rsBase = (from c in dcMain.PerformanceBase
                          where c.PerformanceMainCode == MainCode
                          && ListDeptCode.Contains(c.PerformanceDeptCode)
                          && c.EmpId != _UserId
                          select c).ToList();

            //取得評等代碼
            var rsRating = (from c in dcMain.PerformanceRating
                            join b in dcMain.PerformanceMain on c.EmpCategoryCode equals b.EmpCategoryCode
                            where b.Code == MainCode
                            select c).ToList();

            //取得主檔
            var rMain = (from c in dcMain.PerformanceMain
                         where c.Code == MainCode
                         select c).FirstOrDefault();

            DateTime DateBase = rMain.DateBase;

            //取得評分職等對應表
            var rsScoreLimits = (from c in dcMain.PerformanceScoreLimits
                                 select c).ToList();

            //忽略來源不存在的工號
            var NeglectEmpId = cbNeglectEmpId.Checked.Value;

            int i = 0, j = 0; //應匯入數/總匯入數
            var Msg = "";
            foreach (DataRow dr in dtExcel.Rows)
            {
                i++;

                var IndexEmpId = Convert.ToInt32(lblEmpId.ToolTip);
                var IndexWorkPerformance = Convert.ToInt32(lblWorkPerformance.ToolTip);
                var IndexMannerEsteem = Convert.ToInt32(lblMannerEsteem.ToolTip);
                var IndexAbilityEsteem = Convert.ToInt32(lblAbilityEsteem.ToolTip);
                var IndexEncourage = Convert.ToInt32(lblEncourage.ToolTip);
                var IndexRating = Convert.ToInt32(lblRating.ToolTip);
                var IndexBonusAdjust = Convert.ToInt32(lblBonusAdjust.ToolTip);
                var IndexNote = Convert.ToInt32(lblNote.ToolTip);

                var EmpId = IndexEmpId >= 0 ? dr.ItemArray[IndexEmpId].ToString() : "";
                var WorkPerformance = 0;
                var MannerEsteem = 0;
                var AbilityEsteem = 0;
                var Encourage = 0;
                var Rating = IndexRating >= 0 ? dr.ItemArray[IndexRating].ToString() : "";
                var BonusAdjust = 0;
                var Note = IndexNote >= 0 ? dr.ItemArray[IndexNote].ToString() : "";

                try
                {
                    WorkPerformance = IndexWorkPerformance >= 0 ? Convert.ToInt32(dr.ItemArray[IndexWorkPerformance]) : 0;
                    MannerEsteem = IndexMannerEsteem >= 0 ? Convert.ToInt32(dr.ItemArray[IndexMannerEsteem]) : 0;
                    AbilityEsteem = IndexAbilityEsteem >= 0 ? Convert.ToInt32(dr.ItemArray[IndexAbilityEsteem]) : 0;
                    Encourage = IndexEncourage >= 0 ? Convert.ToInt32(dr.ItemArray[IndexEncourage]) : 0;
                    BonusAdjust = IndexBonusAdjust >= 0 ? Convert.ToInt32(dr.ItemArray[IndexBonusAdjust]) : 0;
                }
                catch (Exception ex)
                {
                    Msg += "<br>工號：" + EmpId + "轉換失敗，可能因為有套用公式";
                    continue;
                }

                var rBase = rsBase.FirstOrDefault(p => p.EmpId == EmpId);

                if (rBase != null)
                {
                    //各項檢核(先全部做完才會進行寫入)

                    //預設的評分職等對應表(空白)
                    //取得有職等的對應表
                    var rsScoreLimitsTemp = rsScoreLimits.Where(p => p.JobCode == "*" || p.JobCode == rBase.JobCode);
                    {
                        var rScoreLimits = rsScoreLimitsTemp.Where(p => p.ReportContentCode == "WorkPerformance").OrderBy(p => p.Sort).FirstOrDefault();
                        if (rScoreLimits != null)
                        {
                            var Score = rScoreLimits.ScoreLimits;
                            var MaxValue = Score;

                            if (IndexWorkPerformance >= 0)
                            {
                                if (WorkPerformance > MaxValue)
                                {
                                    Msg += "<br>工號：" + EmpId + ",超過工作績效可評分上限,評分上限為：" + MaxValue;
                                    continue;
                                }

                                rBase.WorkPerformance = WorkPerformance;
                            }
                        }
                    }

                    {
                        var rScoreLimits = rsScoreLimitsTemp.Where(p => p.ReportContentCode == "MannerEsteem").OrderBy(p => p.Sort).FirstOrDefault();
                        if (rScoreLimits != null)
                        {
                            var Score = rScoreLimits.ScoreLimits;
                            var MaxValue = Score;

                            if (IndexMannerEsteem >= 0)
                            {
                                if (MannerEsteem > MaxValue)
                                {
                                    Msg += "<br>工號：" + EmpId + ",超過工作態度可評分上限,評分上限為：" + MaxValue;
                                    continue;
                                }

                                rBase.MannerEsteem = MannerEsteem;
                            }
                        }
                    }

                    {
                        var rScoreLimits = rsScoreLimitsTemp.Where(p => p.ReportContentCode == "AbilityEsteem").OrderBy(p => p.Sort).FirstOrDefault();
                        if (rScoreLimits != null)
                        {
                            var Score = rScoreLimits.ScoreLimits;
                            var MaxValue = Score;

                            if (IndexAbilityEsteem >= 0)
                            {
                                if (AbilityEsteem > MaxValue)
                                {
                                    Msg += "<br>工號：" + EmpId + ",超過能力評價可評分上限,評分上限為：" + MaxValue;
                                    continue;
                                }

                                rBase.AbilityEsteem = AbilityEsteem;
                            }
                        }
                    }

                    {
                        var rScoreLimits = rsScoreLimitsTemp.Where(p => p.ReportContentCode == "Encourage").OrderBy(p => p.Sort).FirstOrDefault();
                        if (rScoreLimits != null)
                        {
                            var Score = rScoreLimits.ScoreLimits;
                            var MaxValue = Score;

                            if (IndexEncourage >= 0)
                            {
                                if (Encourage > MaxValue)
                                {
                                    Msg += "<br>工號：" + EmpId + ",超過激勵可評分上限,評分上限為：" + MaxValue;
                                    continue;
                                }

                                rBase.Encourage = Encourage;
                            }
                        }
                    }

                    var rRating = rsRating.FirstOrDefault(p => p.Code == rBase.RatingCode);

                    if (rRating == null)
                    {
                        Msg += "<br>工號：" + EmpId + ",評等代碼對應不到(系統錯誤)";
                        continue;
                    }

                    if (IndexRating >= 0)
                        rRating = rsRating.FirstOrDefault(p => p.Name == Rating);

                    if (rRating == null)
                    {
                        Msg += "<br>工號：" + EmpId + ",評等名稱對應不到,來源名稱為：" + Rating;
                        continue;
                    }

                    if (IndexRating >= 0)
                        rBase.RatingCode = rRating.Code;

                    //如果改評等 也要再次檢查是否有超過最大值
                    if (IndexBonusAdjust >= 0 || IndexRating >= 0)
                    {
                        if (IndexBonusAdjust >= 0)
                            rBase.BonusAdjust = BonusAdjust;

                        BonusAdjust = Convert.ToInt32(rBase.BonusAdjust);
                        var BonusDeduct = oPerformance.CalculationBonusDeduct(rBase.BonusCardinal, rRating.BonusPerMin);
                        var BonusMax = oPerformance.CalculationBonusMax(rBase.BonusCardinal, rRating.BonusPerMax);

                        //可輸入範圍邊界
                        var BonusDeduct1 = -(rBase.BonusCardinal - BonusDeduct);
                        var BonusMax1 = BonusMax - rBase.BonusCardinal;

                        if (BonusAdjust < BonusDeduct1 || BonusAdjust > BonusMax1)
                        {
                            Msg += "<br>工號：" + EmpId + ",獎金可加減金額超過,最低(" + BonusDeduct1 + ")或最高(" + BonusMax1 + ")的區間,來源金額為：" + BonusAdjust;
                            continue;
                        }
                    }

                    if (IndexNote >= 0 || IndexRating >= 0)
                    {
                        if (IndexNote >= 0)
                            rBase.Note = Note;

                        Note = rBase.Note;
                        if (rRating.CheckNote && Note.Length == 0)
                        {
                            Msg += "<br>工號：" + EmpId + ",[" + rRating.Name + "]等需要填寫備註";
                            continue;
                        }
                    }

                    var TotalIntegrate = rBase.WorkPerformance + rBase.MannerEsteem + rBase.AbilityEsteem + rBase.Encourage;
                    rBase.TotalIntegrate = TotalIntegrate > 110 ? 110 : TotalIntegrate;
                    rBase.BonusReal = rBase.BonusCardinal + rBase.BonusAdjust;
                    rBase.UpdateMan = _UserId;
                    rBase.UpdateDate = DateTime.Now;

                    j++;
                }
                else if (!NeglectEmpId && EmpId.Length > 0)
                    Msg += "<br>工號：" + EmpId + ",不存在於目前允許匯入的名單中(可能是不同部門)";

            }

            if (Msg.Length == 0)
            {
                dcMain.SubmitChanges();
                Msg = "匯入完成！共要匯入" + i.ToString() + "筆，實際匯入" + j.ToString() + "筆";
            }

            lblMsg.Text = Msg;
            wz.Visible = false;
            //RadScriptManager.RegisterClientScriptBlock(this, typeof(Page), this.GetType().ToString(), "alert('" + lblMsg.Text + "');GetRadWindow().close();", true);
        }

        protected void btnImport_Click(object sender, EventArgs e)
        {
            lblMsg.Text = "";
            wz.WizardSteps[0].Active = true;
            wz.Visible = true;
        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            if (UnobtrusiveSession.Session["TopDeptCode"] == null ||
                UnobtrusiveSession.Session["ListDept"] == null ||
                UnobtrusiveSession.Session["MainCode"] == null)
                return;

            var DeptCode = UnobtrusiveSession.Session["TopDeptCode"].ToString();    //傳送目前點選部門做為審核層級判斷(當前部門為傳簽層級的判斷角度)
            var ListDept = (List<PerformanceDept>)UnobtrusiveSession.Session["ListDept"];
            var MainCode = UnobtrusiveSession.Session["MainCode"].ToString();

            var _UserId = _User.UserCode;



            lblMsg.Text = "送出成功";
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