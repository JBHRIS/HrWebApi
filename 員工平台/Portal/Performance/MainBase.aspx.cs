using Bll;
using Bll.Dept.Vdb;
using Bll.Performance.Vdb;
using Bll.Tools;
using Dal;
using Dal.Dao;
using Newtonsoft.Json;
using Performance.Scripts;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.Design.ODataDataSource;
using Telerik.Web.UI;
using Image = System.Web.UI.WebControls.Image;

namespace Performance
{
    public partial class MainBase : WebPageBase
    {
        CallJavaScript Scripts = new CallJavaScript();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                UnobtrusiveSession.Session["ActivePage"] = WebPage.GetActivePage;

                ddlMain_DataBind();
                ddlDept_DataBind();
            }

            ScriptManager.GetCurrent(this).RegisterPostBackControl(btnExportExcel);

            lblMsg.Text = "";
        }

        public void ddlMain_DataBind()
        {
            var oPerformance = new PerformanceDao(dcShare, dcMain, dcHr);
            var rs = oPerformance.GetPerformanceMain("01");

            var ListDeptCode = dcMain.PerformanceDept.Where(p => p.ManagerId == _User.UserCode).Select(p => p.PerformanceMainCode).ToList();

            rs = rs.Where(p => ListDeptCode.Contains(p.Value)).ToList();

            if (rs.Count == 0)
            {
                lblMsg.Text = "您權限不足或目前還沒有開始打考核";
                return;
            }

            ddlMain.DataSource = rs;
            ddlMain.DataTextField = "Text";
            ddlMain.DataValueField = "Value";
            ddlMain.DataBind();


            if (UnobtrusiveSession.Session["MainCode"] != null)
            {
                var MainCode = UnobtrusiveSession.Session["MainCode"].ToString();
                if (ddlMain.FindItemByValue(MainCode) != null)
                    ddlMain.FindItemByValue(MainCode).Selected = true;
            }

            var ListMainCode = rs.Select(p => p.Value).ToList();
        }

        protected void ddlMain_SelectedIndexChanged(object sender, DropDownListEventArgs e)
        {
            ddlDept_DataBind();
        }

      

        public void ddlDept_DataBind()
        {
            if (ddlMain.SelectedItem == null)
                return;

            var MainCode = ddlMain.SelectedItem.Value;

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

            if (UnobtrusiveSession.Session["SelectDeptCode"] != null)
                DeptCode = UnobtrusiveSession.Session["SelectDeptCode"].ToString();

            ddlDept.SelectedValue = DeptCode;

        }

        protected void ddlDept_EntryAdded(object sender, DropDownTreeEntryEventArgs e)
        {
            gvMain.Rebind();
        }

        protected void cbSubDept_CheckedChanged(object sender, EventArgs e)
        {
            gvMain.Rebind();
        }

        protected void cbBase_CheckedChanged(object sender, EventArgs e)
        {
            gvMain.Rebind();
        }

        public void _DataBind(string DeptCode)
        {

        }

        protected void btnExportExcel_Click(object sender, EventArgs e)
        {
            var rs = ListBaseView;

            //處理html
            foreach (var r in rs)
            {
            }

            var dt = rs.CopyToDataTable();

            //移除不顯示的欄位


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

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            gvMain.Rebind();
        }

        public List<BaseViewRow> ListBaseView
        {
            get
            {
                var Value = new List<BaseViewRow>();
                if (WebPage.DataCache &&
                    UnobtrusiveSession.Session["BaseView"] != null &&
                    UnobtrusiveSession.Session["BonusView"] != null &&
                    UnobtrusiveSession.Session["MainCode"] != null &&
                    UnobtrusiveSession.Session["TopDeptCode"] != null)
                {
                    Value = (List<BaseViewRow>)UnobtrusiveSession.Session["BaseView"];
                }
                else
                {
                    if (ddlMain.SelectedItem == null || ddlDept.SelectedValue.Length == 0)
                    {
                        lblMsg.Text = "資訊錯誤";
                        return Value;
                    }

                    var MainCode = ddlMain.SelectedItem.Value;
                    var DeptCode = ddlDept.SelectedValue;
                    var SubDept = cbSubDept.Checked.GetValueOrDefault(false);
                    var Base = cbBase.Checked.GetValueOrDefault(false);

                    var EmpId = _User.UserCode;

                    var rMain = (from c in dcMain.PerformanceMain
                                 where c.Code == MainCode
                                 select c).FirstOrDefault();

                    if (rMain == null)
                    {
                        lblMsg.Text = "資訊錯誤";
                        return Value;
                    }

                    var EmpCategoryCode = rMain.EmpCategoryCode;

                    //取得所有部門
                    var rsDeptAll = (from c in dcMain.PerformanceDept
                                     where c.PerformanceMainCode == MainCode
                                     select c).ToList();

                    //取得最高部門主管層級
                    var TopDeptTree = rsDeptAll.Where(p => p.ManagerId == EmpId).Max(p => p.DeptTree);

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

                    //加入子部門(以選擇的部門角度向下展開加入)
                    var rsDept1 = rsDeptAll.Where(p => p.PathCode.IndexOf(PathCode) >= 0).ToList();

                    //部門清單
                    var ListDeptCode = rsDept1.Select(p => p.Code).ToList();

                    //取得可簽核部門
                   var  rsDept = (from c in rsDeptAll
                                  where c.ManagerId == EmpId
                                  select c).ToList();

                    if (rsDept.Count == 0)
                    {
                        lblMsg.Text = "沒有產生部門";
                        return Value;
                    }

                    //加入子部門(以登入主管的工號為角度搜尋符合的部門)
                    rsDept = rsDept.Where(p => PathCode.IndexOf(p.PathCode) >= 0).ToList();
                    //rsDept = rsDeptAll.Where(p => rsDept.Any(c => p.PathCode.IndexOf(c.PathCode) >= 0)).ToList();

                    //取得最上層部門
                    var TopDeptCode = rsDept.OrderByDescending(p => p.DeptTree).First().Code;

                    //必須大於等於
                    var BonusView = TopDeptTree >= DeptTreeB;

                    var ValueSql = (from r in dcMain.PerformanceBase
                                    join c in dcMain.PerformanceRating on r.RatingCode equals c.Code
                                    where r.PerformanceMainCode == MainCode
                                    && c.EmpCategoryCode == EmpCategoryCode
                                    && ((SubDept && ListDeptCode.Contains(r.PerformanceDeptCode)) || (r.PerformanceDeptCode == DeptCode))
                                    && r.EmpId != EmpId
                                    select new BaseViewRow
                                    {
                                        AutoKey = r.AutoKey,
                                        EmpId = r.EmpId,
                                        EmpName = r.EmpName,
                                        JobName = r.JobName,
                                        DeptCode = r.PerformanceDeptCode,
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
                                    });

                    if (Base)
                    {
                        //取得可傳簽的主流程
                        var ListFlowDeptCode = (from f in dcMain.PerformanceFlow
                                                join n in dcMain.PerformanceFlowNode on f.Code equals n.PerformanceFlowCode
                                                where f.PerformanceMainCode == MainCode
                                                && !f.IsCancel
                                                && !f.IsError
                                                && !f.IsFinish
                                                && !n.IsFinish
                                                && n.EmpIdDefault == EmpId
                                                select f.PerformanceDeptCode).ToList();

                        ValueSql = from c in ValueSql
                                   where ListFlowDeptCode.Contains(c.DeptCode)
                                   select c;
                    }

                    Value = ValueSql.ToList();

                    var SearchKey = txtSearchKey.Text.Trim();

                    //先計算剩餘金額
                    var BonusAdjust = -Value.Sum(p => p.BonusAdjust);
                    txtBonusBalance.Text = BonusAdjust.ToString();
                    txtBonusBalance.ForeColor = Color.Blue;
                    if (BonusAdjust < 0)
                        txtBonusBalance.ForeColor = Color.Red;

                    //搜尋關鍵字
                    if (SearchKey.Length > 0)
                        Value = Value.Where(m => ("," + m.EmpId + "," + m.EmpName + "," + m.RatingName + ",").IndexOf(SearchKey) >= 0).ToList();

                    UnobtrusiveSession.Session["BaseView"] = Value;
                    UnobtrusiveSession.Session["BonusView"] = BonusView;
                    UnobtrusiveSession.Session["ListDept"] = rsDept1;
                    UnobtrusiveSession.Session["MainCode"] = MainCode;
                    UnobtrusiveSession.Session["TopDeptCode"] = TopDeptCode;
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
            public string DeptCode { get; set; }
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


        protected void gvMain_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            UnobtrusiveSession.Session["BaseView"] = null;

            //初始化
            txtBonusBalance.Text = "0";

            var rs = ListBaseView;

            gvMain.DataSource = rs;

            gvDept.Rebind();
        }

        protected void gvMain_ExportCellFormatting(object sender, ExportCellFormattingEventArgs e)
        {
            e.Cell.Style["mso-number-format"] = @"\@";
        }

        protected void gvMain_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            string cn = e.CommandName;
            string ca = e.CommandArgument.ToString();

            if (cn == "Page")
            {
                SaveData(true);
            }
        }

        protected void gvMain_DataBound(object sender, EventArgs e)
        {
            if (ddlMain.SelectedItem == null || ddlDept.SelectedValue.Length == 0)
            {
                lblMsg.Text = "資訊錯誤";
                return;
            }

            if (UnobtrusiveSession.Session["BaseView"] == null || 
                UnobtrusiveSession.Session["ListDept"] == null ||
                UnobtrusiveSession.Session["BonusView"] == null ||
                UnobtrusiveSession.Session["MainCode"] == null ||
                UnobtrusiveSession.Session["TopDeptCode"] == null)
            {
                var Temp = ListBaseView;
            }

            var MainCode = ddlMain.SelectedItem.Value;
            var DeptCode = ddlDept.SelectedValue;
            var SubDept = cbSubDept.Checked.GetValueOrDefault(false);
            var Base = cbBase.Checked.GetValueOrDefault(false);
            var ListDept = (List<PerformanceDept>)UnobtrusiveSession.Session["ListDept"];
            var BonusView = Convert.ToBoolean(UnobtrusiveSession.Session["BonusView"]);

            var ListDeptCode = ListDept.Select(p => p.Code).ToList();

            var EmpId = _User.UserCode;

            var rMain = (from c in dcMain.PerformanceMain
                         where c.Code == MainCode
                         select c).FirstOrDefault();

            if (rMain != null)
            {
                DateTime DateBase = rMain.DateBase;
                var CompCode = "A";
                var EmpCategoryCode = rMain.EmpCategoryCode;
                //var RatingCode = rMain.PerformanceRatingCode;

                //工員加前兩個月的評等及分數、職員前一季
                var Yymm = rMain.Yymm;
                var Yymm1 = TimeTrans.YyMmAddMonth(Yymm, -1); //前一次評核
                var Yymm2 = TimeTrans.YyMmAddMonth(Yymm, -2); //前二次評核

                //如果是職員則減3個月   職員01工員02
                if (EmpCategoryCode == "01")
                {
                    Yymm1 = TimeTrans.YyMmAddMonth(Yymm, -3); //前一次評核
                    Yymm2 = TimeTrans.YyMmAddMonth(Yymm, -6); //前二次評核
                }

                var rsMain = (from c in dcMain.PerformanceMain
                              where (c.Yymm == Yymm1 || c.Yymm == Yymm2)
                              && c.EmpCategoryCode == EmpCategoryCode
                              orderby c.Yymm
                              select new
                              {
                                  c.Code,
                                  c.Yymm,
                              }).ToList();

                var ListMainCode = rsMain.Select(p => p.Code).ToList();

                ListMainCode.Add(MainCode);

                //取得過去歷史的人員資料
                var rsBase = (from c in dcMain.PerformanceBase
                              where ListMainCode.Contains(c.PerformanceMainCode)
                              //where c.PerformanceMainCode == MainCode
                              //&& ListDeptCode.Contains(c.PerformanceDeptCode)
                              && c.EmpId != EmpId
                              select c).ToList();

                //取得評等
                var rsRating = (from c in dcMain.PerformanceRating
                                where c.CompCode == CompCode
                                && c.EmpCategoryCode == EmpCategoryCode
                                orderby c.Sort
                                select c).ToList();

                //取得評分職等對應表
                var rsScoreLimits = (from c in dcMain.PerformanceScoreLimits
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

                //點擊部門 及其向下所有的部門在自己身上 才可以進行調整獎金

                //取得主流程
                var rsFlow = (from pf in dcMain.PerformanceFlow
                              where ListDeptCode.Contains(pf.PerformanceDeptCode)
                              && pf.PerformanceMainCode == MainCode
                              select pf).ToList();

                var ListFlowCode = rsFlow.Select(p => p.Code).ToList();

                //取得流程節點 尋找 主管可以簽的表單 且 未簽核結束的
                var rsNode = (from c in dcMain.PerformanceFlowNode
                              where ListFlowCode.Contains(c.PerformanceFlowCode)
                              && !c.IsFinish
                              && c.EmpIdDefault == EmpId
                              select c).ToList();

                var BonusAdjustEnabled = rsFlow.Count == rsNode.Count;
                btnReCalRating.Enabled = BonusAdjustEnabled;
                btnReset.Enabled = BonusAdjustEnabled;
                btnImport.Enabled = BonusAdjustEnabled;
                if (!BonusAdjustEnabled)
                {
                    btnReCalRating.ToolTip = "必須所有評核部門在您身上才可以使用這個功能";
                    btnReset.ToolTip = "必須所有評核部門在您身上才可以使用這個功能";
                    btnImport.ToolTip = "必須所有評核部門在您身上才可以使用這個功能";
                }

                gvMain.Columns.FindByUniqueName("BonusCardinal").Visible = BonusView;
                gvMain.Columns.FindByUniqueName("BonusAdjust").Visible = BonusView;
                gvMain.Columns.FindByUniqueName("BonusReal").Visible = BonusView;

                gvDept.Visible = BonusView;
                phBonusBalance.Visible = BonusView;

                var oPerformance = new PerformanceDao(dcShare, dcMain, dcHr);

                foreach (GridDataItem item in gvMain.Items)
                {
                    var AutoKey = Convert.ToInt32(item.GetDataKeyValue("AutoKey"));

                    var lblEmpIdObj = item.FindControl("lblEmpId");

                    var txtWorkPerformanceObj = item.FindControl("txtWorkPerformance");
                    var txtMannerEsteemObj = item.FindControl("txtMannerEsteem");
                    var txtAbilityEsteemObj = item.FindControl("txtAbilityEsteem");
                    var txtEncourageObj = item.FindControl("txtEncourage");

                    var ttWorkPerformanceObj = item.FindControl("ttWorkPerformance");
                    var ttMannerEsteemObj = item.FindControl("ttMannerEsteem");
                    var ttAbilityEsteemObj = item.FindControl("ttAbilityEsteem");
                    var ttEncourageObj = item.FindControl("ttEncourage");

                    var txtTotalIntegrateObj = item.FindControl("txtTotalIntegrate");
                    var imgTotalIntegrateObj = item.FindControl("imgTotalIntegrate");
                    var ttTotalIntegrateObj = item.FindControl("ttTotalIntegrate");

                    var ddlRatingObj = item.FindControl("ddlRating");

                    var BonusCardinal = item["BonusCardinal"].Text.ParseDecimal();
                    var txtBonusDeductObj = item.FindControl("txtBonusDeduct");
                    var txtBonusMaxObj = item.FindControl("txtBonusMax");
                    var txtBonusDeduct1Obj = item.FindControl("txtBonusDeduct1");
                    var txtBonusMax1Obj = item.FindControl("txtBonusMax1");
                    var txtBonusAdjustObj = item.FindControl("txtBonusAdjust");
                    var txtBonusAdjustTempObj = item.FindControl("txtBonusAdjustTemp");

                    var ttBonusAdjustObj = item.FindControl("ttBonusAdjust");
                    var txtBonusRealObj = item.FindControl("txtBonusReal");

                    var txtNoteObj = item.FindControl("txtNote");
                    var ttNoteObj = item.FindControl("ttNote");

                    if (AutoKey > 0)
                    {
                        var lblEmpId = lblEmpIdObj as RadLabel;

                        var txtWorkPerformance = txtWorkPerformanceObj as RadNumericTextBox;
                        var txtMannerEsteem = txtMannerEsteemObj as RadNumericTextBox;
                        var txtAbilityEsteem = txtAbilityEsteemObj as RadNumericTextBox;
                        var txtEncourage = txtEncourageObj as RadNumericTextBox;

                        var ttWorkPerformance = ttWorkPerformanceObj as RadToolTip;
                        var ttMannerEsteem = ttMannerEsteemObj as RadToolTip;
                        var ttAbilityEsteem = ttAbilityEsteemObj as RadToolTip;
                        var ttEncourage = ttEncourageObj as RadToolTip;

                        var txtTotalIntegrate = txtTotalIntegrateObj as RadNumericTextBox;
                        var imgTotalIntegrate = imgTotalIntegrateObj as Image;
                        var ttTotalIntegrate = ttTotalIntegrateObj as RadToolTip;

                        var ddlRating = ddlRatingObj as RadDropDownList;

                        var txtBonusDeduct = txtBonusDeductObj as RadNumericTextBox;
                        var txtBonusMax = txtBonusMaxObj as RadNumericTextBox;
                        var txtBonusDeduct1 = txtBonusDeduct1Obj as RadNumericTextBox;
                        var txtBonusMax1 = txtBonusMax1Obj as RadNumericTextBox;
                        var txtBonusAdjust = txtBonusAdjustObj as RadNumericTextBox;
                        var txtBonusAdjustTemp = txtBonusAdjustTempObj as RadNumericTextBox;

                        var ttBonusAdjust = ttBonusAdjustObj as RadToolTip;
                        var txtBonusReal = txtBonusRealObj as RadNumericTextBox;

                        var txtNote = txtNoteObj as RadTextBox;
                        var ttNote = ttNoteObj as RadToolTip;

                        //只有全部部門都在自己身上才能調整金額與評等
                        if (!BonusAdjustEnabled)
                        {
                            txtBonusAdjust.Enabled = false;
                            txtBonusAdjust.ToolTip = "必須要所有部門都送到您身上才可以調整獎金";

                            ddlRating.Enabled = false;
                            ddlRating.ToolTip = "必須要所有部門都送到您身上才可以調整評等";
                        }

                        var ExceptionBonus = false;
                        var ExceptionNote = false;

                        var BonusTotal = 0m;

                        //先全部不允許編輯
                        item.Enabled = false;
                        var rBase = rsBase.FirstOrDefault(p => p.AutoKey == AutoKey);
                        if (rBase != null)
                        {
                             BonusTotal = rBase.BonusTotal;

                            //例外處理 獎金可以超過 不用輸入備註
                            ExceptionBonus = rBase.ExceptionBonus;
                            ExceptionNote = rBase.ExceptionNote;

                            //歷史資料
                            {
                                if (rsMain.Count > 0)
                                {
                                    var OldData = "歷史記錄：";
                                    foreach (var rMainOld in rsMain)
                                    {
                                        MainCode = rMainOld.Code;
                                        Yymm1 = rMainOld.Yymm;
                                        EmpId = rBase.EmpId;
                                        var rBaseByYymm1 = rsBase.FirstOrDefault(p => p.PerformanceMainCode == MainCode && p.EmpId == EmpId);

                                        if (rBaseByYymm1 != null)
                                        {
                                            var rRatingOld = rsRating.FirstOrDefault(p => p.Code == rBaseByYymm1.RatingCode);
                                            if (rRatingOld != null)
                                                OldData += "<br>" + Yymm1 + "：" + string.Format("{0:N0}", rBaseByYymm1.TotalIntegrate) + " / " + rRatingOld.Name;
                                        }
                                    }

                                    ttTotalIntegrate.Text = OldData;
                                    ttTotalIntegrate.TargetControlID = imgTotalIntegrate.ClientID;
                                    //txtTotalIntegrate.ToolTip = OldData;
                                    //ddlRating.ToolTip = OldData;

                                    var rMainYymm = rsMain.FirstOrDefault(p => p.Yymm == Yymm1);
                                    if (rMainYymm != null)
                                    {
                                        MainCode = rMainYymm.Code;
                                        EmpId = rBase.EmpId;
                                        var rBaseByYymm1 = rsBase.FirstOrDefault(p => p.PerformanceMainCode == MainCode && p.EmpId == EmpId);

                                        if (rBaseByYymm1 != null)
                                        {
                                            item["PreTotalIntegrate"].Text = string.Format("{0:N0}", rBaseByYymm1.TotalIntegrate);

                                            var rRatingOld = rsRating.FirstOrDefault(p => p.Code == rBaseByYymm1.RatingCode);
                                            if (rRatingOld != null)
                                                item["PreRatingName"].Text = rRatingOld.Name;
                                        }
                                    }

                                    rMainYymm = rsMain.FirstOrDefault(p => p.Yymm == Yymm2);
                                    if (rMainYymm != null)
                                    {
                                        MainCode = rMainYymm.Code;
                                        EmpId = rBase.EmpId;
                                        var rBaseByYymm1 = rsBase.FirstOrDefault(p => p.PerformanceMainCode == MainCode && p.EmpId == EmpId);

                                        if (rBaseByYymm1 != null)
                                        {
                                            item["PrePreTotalIntegrate"].Text = string.Format("{0:N0}", rBaseByYymm1.TotalIntegrate);

                                            var rRatingOld = rsRating.FirstOrDefault(p => p.Code == rBaseByYymm1.RatingCode);
                                            if (rRatingOld != null)
                                                item["PrePreRatingName"].Text = rRatingOld.Name;
                                        }
                                    }
                                }
                            }

                            //改變是否可以編輯
                            if (rsFlowMain.Any(p => p.PerformanceDeptCode == rBase.PerformanceDeptCode))
                            {
                                item.Enabled = true;
                                //item.BackColor = ColorTranslator.FromHtml("#FFFDC0");
                                //item.BorderWidth = Unit.Pixel(200);
                            }

                            //職稱代碼
                            var JobCode = rBase.JobCode;

                            //預設的評分職等對應表(空白)
                            //取得有職等的對應表
                            var rsScoreLimitsTemp = rsScoreLimits.Where(p => p.JobCode == "*" || p.JobCode == rBase.JoblCode);
                            //這裡需要特別客制撰寫 因為每個公司訂義的[上限代碼]以及[職稱代碼]並不相同
                            {
                                var rScoreLimits = rsScoreLimitsTemp.Where(p => p.ReportContentCode == "WorkPerformance").OrderBy(p => p.Sort).FirstOrDefault();
                                if (rScoreLimits != null)
                                {
                                    var Score = rScoreLimits.ScoreLimits;
                                    txtWorkPerformance.MaxValue = Convert.ToDouble(Score);

                                    ttWorkPerformance.TargetControlID = txtWorkPerformance.ClientID;
                                    ttWorkPerformance.Text = "上限：" + string.Format("{0:N0}", Score);
                                }
                            }
                            {
                                var rScoreLimits = rsScoreLimitsTemp.Where(p => p.ReportContentCode == "MannerEsteem").OrderBy(p => p.Sort).FirstOrDefault();
                                if (rScoreLimits != null)
                                {
                                    var Score = rScoreLimits.ScoreLimits;
                                    txtMannerEsteem.MaxValue = Convert.ToDouble(Score);

                                    ttMannerEsteem.TargetControlID = txtMannerEsteem.ClientID;
                                    ttMannerEsteem.Text = "上限：" + string.Format("{0:N0}", Score);
                                }
                            }
                            {
                                var rScoreLimits = rsScoreLimitsTemp.Where(p => p.ReportContentCode == "AbilityEsteem").OrderBy(p => p.Sort).FirstOrDefault();
                                if (rScoreLimits != null)
                                {
                                    var Score = rScoreLimits.ScoreLimits;
                                    txtAbilityEsteem.MaxValue = Convert.ToDouble(Score);

                                    ttAbilityEsteem.TargetControlID = txtAbilityEsteem.ClientID;
                                    ttAbilityEsteem.Text = "上限：" + string.Format("{0:N0}", Score);
                                }
                            }
                            {
                                var rScoreLimits = rsScoreLimitsTemp.Where(p => p.ReportContentCode == "Encourage").OrderBy(p => p.Sort).FirstOrDefault();
                                if (rScoreLimits != null)
                                {
                                    var Score = rScoreLimits.ScoreLimits;
                                    txtEncourage.MaxValue = Convert.ToDouble(Score);

                                    ttEncourage.TargetControlID = txtEncourage.ClientID;
                                    ttEncourage.Text = "上限：" + string.Format("{0:N0}", Score);
                                }
                            }
                        }

                        //評核總分上限就是110
                        txtTotalIntegrate.MaxValue = 110;

                        //評核總分Script
                        var Script = Scripts.ScriptPerformanceBaseRowCellsSumTotalIntegrateTextChanged;
                        var FunName = "TotalIntegrate" + AutoKey;
                        Script = Script.Replace("<FunName>", FunName);
                        ScriptManager.RegisterStartupScript(this, typeof(UpdatePanel), FunName, Script, true);
                        txtWorkPerformance.ClientEvents.OnBlur = "Blur" + FunName;
                        txtWorkPerformance.ClientEvents.OnFocus = "Focus" + FunName;
                        txtMannerEsteem.ClientEvents.OnBlur = "Blur" + FunName;
                        txtMannerEsteem.ClientEvents.OnFocus = "Focus" + FunName;
                        txtAbilityEsteem.ClientEvents.OnBlur = "Blur" + FunName;
                        txtAbilityEsteem.ClientEvents.OnFocus = "Focus" + FunName;
                        txtEncourage.ClientEvents.OnBlur = "Blur" + FunName;
                        txtEncourage.ClientEvents.OnFocus = "Focus" + FunName;
                        txtTotalIntegrate.ClientEvents.OnLoad = "Load" + FunName;

                        if (BonusView)
                        {
                            //獎金Script
                            Script = Scripts.ScriptPerformanceBaseRowCellsSumBonusRealTextChanged;
                            FunName = "BonusReal" + AutoKey;
                            Script = Script.Replace("<FunName>", FunName);
                            Script = Script.Replace("<BonusDeduct1>", txtBonusDeduct1.ClientID);
                            Script = Script.Replace("<BonusMax1>", txtBonusMax1.ClientID);
                            Script = Script.Replace("<BonusAdjust>", txtBonusAdjust.ClientID);
                            Script = Script.Replace("<BonusAdjustTemp>", txtBonusAdjustTemp.ClientID);
                            ScriptManager.RegisterStartupScript(this, typeof(UpdatePanel), FunName, Script, true);
                            txtBonusAdjust.ClientEvents.OnBlur = "Blur" + FunName;
                            txtBonusAdjust.ClientEvents.OnFocus = "Focus" + FunName;
                            txtBonusAdjust.ClientEvents.OnValueChanged = "ValueChanged" + FunName;
                            txtBonusAdjust.ClientEvents.OnError = "Error" + FunName;
                            txtBonusReal.ClientEvents.OnLoad = "Load" + FunName;

                            //評等RatingSelectedItemScript
                            Script = Scripts.ScriptPerformanceBaseRatingSelectedItem;
                            FunName = "RatingSelectedItem" + AutoKey;
                            Script = Script.Replace("<FunName>", FunName);
                            Script = Script.Replace("<Target>", ddlRating.ClientID);
                            Script = "Sys.Application.add_load(" + Script + ");";
                            ScriptManager.RegisterStartupScript(this, typeof(UpdatePanel), FunName, Script, true);

                            //評等SelectedIndexChangedScript
                            Script = Scripts.ScriptPerformanceBaseRatingSelectedIndexChanged;
                            FunName = "RatingSelectedIndexChanged" + AutoKey;
                            Script = Script.Replace("<FunName>", FunName);
                            Script = Script.Replace("<BonusDeduct>", txtBonusDeduct.ClientID);
                            Script = Script.Replace("<BonusMax>", txtBonusMax.ClientID);
                            Script = Script.Replace("<BonusDeduct1>", txtBonusDeduct1.ClientID);
                            Script = Script.Replace("<BonusMax1>", txtBonusMax1.ClientID);
                            Script = Script.Replace("<BonusAdjust>", txtBonusAdjust.ClientID);
                            Script = Script.Replace("<BonusAdjustTemp>", txtBonusAdjustTemp.ClientID);
                            Script = Script.Replace("<ttBonusAdjust>", ttBonusAdjust.ClientID);

                            //組合各種Case
                            var RatingCase = "";
                            var x = 0;
                            foreach (var rRatingTemp in rsRating)
                            {
                                //最高跟最低的邊界
                                var BonusDeduct = oPerformance.CalculationBonusDeduct(BonusTotal, rRatingTemp.BonusPerMin);
                                var BonusMax = oPerformance.CalculationBonusMax(BonusTotal, rRatingTemp.BonusPerMax);

                                //可輸入範圍邊界
                                var BonusDeduct1 = -(BonusTotal - BonusDeduct);
                                var BonusMax1 = BonusMax - BonusTotal;

                                //var BonusAdjustTooltip = "最低可得獎金：" + string.Format("{0:N0}", BonusDeduct) + "(" + string.Format("{0:N0}", BonusDeduct1) + ")" +
                                //    "<br>最高可得獎金：" + string.Format("{0:N0}", BonusMax) + "(" + string.Format("{0:N0}", BonusMax1) + ")";

                                var BonusAdjustTooltip = "獎金可加減金額：<br>最低：" + string.Format("{0:N0}", BonusDeduct1) +
                                    "<br>最高：" + string.Format("{0:N0}", BonusMax1);

                                //if (ExceptionBonus)
                                //    BonusAdjustTooltip += "<br>考績加減允許超過限制";

                                //if (ExceptionNote)
                                //    BonusAdjustTooltip += "<br>備註允許不用輸入";

                                RatingCase += "case " + x + ":\r";
                                RatingCase += "var BonusAdjust = txtBonusAdjustTemp.get_value();\r";
                                //RatingCase += "var BonusAdjustStyle = txtBonusAdjustTemp._textBoxElement.style.cssText;\r";
                                //RatingCase += "var BonusAdjustStyleError = BonusAdjustStyle + 'background-color:yellow';\r";
                                //RatingCase += "txtBonusAdjustTemp.set_value(BonusAdjust);\r";
                                RatingCase += "txtBonusDeduct1.set_value(" + BonusDeduct1 + ");\r";
                                RatingCase += "txtBonusMax1.set_value(" + BonusMax1 + ");\r";
                                RatingCase += "txtBonusDeduct.set_value(" + BonusDeduct + ");\r";
                                RatingCase += "txtBonusMax.set_value(" + BonusMax + ");\r";
                                RatingCase += "txtBonusAdjust.set_maxValue(" + BonusMax1 + ");\r";
                                RatingCase += "txtBonusAdjust.set_minValue(" + BonusDeduct1 + ");\r";
                                RatingCase += "ttBonusAdjust.set_text('" + BonusAdjustTooltip + "');\r";
                                //RatingCase += "debugger;\r";
                                RatingCase += "if (BonusAdjust < " + BonusDeduct1 + " || BonusAdjust > " + BonusMax1 + ") {\r" +
                                          "txtBonusAdjust._invalid = true;\r" +
                                          "txtBonusAdjust.updateCssClass();\r" +
                                          " } else { \r " +
                                          "txtBonusAdjust._invalid = false;\r" +
                                          "txtBonusAdjust.updateCssClass();\r" +
                                          " }\r";
                                //RatingCase += "if (BonusAdjust < " + BonusDeduct1 + " || BonusAdjust > " + BonusMax1 + ") {" +
                                //    " txtBonusAdjust._textBoxElement.style.cssText = BonusAdjustStyleError;\r " +
                                //    " for (var style in txtBonusAdjust.get_styles()) {\r" +
                                //    "   style = BonusAdjustStyleError;\r " +
                                //    "   }\r" + 
                                //    " } else { \r " +
                                //    " txtBonusAdjust._textBoxElement.style.cssText = BonusAdjustStyle;\r" +
                                //    " for (var style in txtBonusAdjust.get_styles()) {\r" +
                                //    "   style = BonusAdjustStyle;\r " +
                                //    "   }\r" +
                                //    " }\r";
                                RatingCase += "break;\r";

                                x++;
                            }

                            Script = Script.Replace("<Case>", RatingCase);

                            ScriptManager.RegisterStartupScript(this, typeof(UpdatePanel), FunName, Script, true);
                            ddlRating.OnClientSelectedIndexChanged = FunName;
                        }

                        //i++;

                        //置換評等
                        ddlRating.DataSource = rsRating;
                        ddlRating.DataTextField = "Name";
                        ddlRating.DataValueField = "Code";
                        ddlRating.DataBind();

                        var RatingCode = rBase == null ? "" : rBase.RatingCode;
                        ControlGetSet.SetDropDownList(ddlRating, RatingCode);

                        //txtBonusDeduct.Text = String.Format("{0:N0}", txtBonusDeduct.Text.ParseDecimal());
                        //txtBonusMax.Text = String.Format("{0:N0}", txtBonusMax.Text.ParseDecimal());

                        //計算評等最高及可扣獎金
                        var rRating = rsRating.FirstOrDefault(p => p.Code == RatingCode);
                        if (rRating != null)
                        {
                            var BonusDeduct = oPerformance.CalculationBonusDeduct(BonusTotal, rRating.BonusPerMin);
                            var BonusMax = oPerformance.CalculationBonusMax(BonusTotal, rRating.BonusPerMax);

                            var BonusDeduct1 = -(BonusTotal - BonusDeduct);
                            var BonusMax1 = BonusMax - BonusTotal;

                            txtBonusDeduct1.Text = BonusDeduct1.ToString();
                            txtBonusMax1.Text = BonusMax1.ToString();

                            //txtBonusAdjust.MinValue = Convert.ToDouble(BonusDeduct1);
                            //txtBonusAdjust.MaxValue = Convert.ToDouble(BonusMax1);

                            txtBonusDeduct.Text = BonusDeduct.ToString();    //最低可得獎金
                            txtBonusMax.Text = BonusMax.ToString();  //最高可得獎金

                            ttBonusAdjust.TargetControlID = txtBonusAdjust.ClientID;
                            //var BonusAdjustTooltip = "最低可得獎金：" + string.Format("{0:N0}", BonusDeduct) + "(" + string.Format("{0:N0}", BonusDeduct1) + ")" +
                            //    "<br>最高可得獎金：" + string.Format("{0:N0}", BonusMax) + "(" + string.Format("{0:N0}", BonusMax1) + ")";
                            var BonusAdjustTooltip = "獎金可加減金額：<br>最低：" + string.Format("{0:N0}", BonusDeduct1) +
                                    "<br>最高：" + string.Format("{0:N0}", BonusMax1);

                            //if (ExceptionBonus)
                            //    BonusAdjustTooltip += "<br>考績加減允許超過限制";

                            //if (ExceptionNote)
                            //    BonusAdjustTooltip += "<br>備註允許不用輸入";
                        }
                    }
                }

                //改變欄位名稱
                gvMain.MasterTableView.ColumnGroups.FindGroupByName("Pre").HeaderText = Yymm1;
                gvMain.MasterTableView.ColumnGroups.FindGroupByName("PrePre").HeaderText = Yymm2;
                gvMain.Columns.FindByUniqueName("PreRatingName").HeaderText = "評等";
                gvMain.Columns.FindByUniqueName("PreTotalIntegrate").HeaderText = "分數";
                gvMain.Columns.FindByUniqueName("PrePreRatingName").HeaderText = "評等";
                gvMain.Columns.FindByUniqueName("PrePreTotalIntegrate").HeaderText = "分數";
            }
        }

        protected void gvDept_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            if (ddlMain.SelectedItem == null || ddlDept.SelectedValue.Length == 0)
            {
                lblMsg.Text = "資訊錯誤";
                return;
            }

            var MainCode = ddlMain.SelectedItem.Value;
            var DeptCode = ddlDept.SelectedValue;
            var SubDept = cbSubDept.Checked.GetValueOrDefault(false);
            var Base = cbBase.Checked.GetValueOrDefault(false);

            var EmpId = _User.UserCode;

            var rMain = (from c in dcMain.PerformanceMain
                         where c.Code == MainCode
                         select c).FirstOrDefault();

            if (rMain == null)
            {
                lblMsg.Text = "資訊錯誤";
                return;
            }

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
                      select new
                      {
                          c.AutoKey,
                          c.Code,
                          c.Name,
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

            //部門裡至少有一人
            rs = (from c in rs
                  where c.PeopleNumber > 0
                  select c).ToList();

            var EmpCategoryCode = rMain.EmpCategoryCode;

            var rsRating = (from c in dcMain.PerformanceRating
                            where c.EmpCategoryCode == EmpCategoryCode
                            orderby c.Sort
                            select c).ToList();

            UnobtrusiveSession.Session["rsRating"] = rsRating;

            var dt = new DataTable();
            dt.Columns.Add("Name", typeof(string));
            dt.Columns.Add("BonusCardinalSubDept", typeof(string));
            dt.Columns.Add("BonusRealSubDept", typeof(string));
            dt.Columns.Add("BonusAdjustSubDept", typeof(string));
            dt.Columns.Add("PeopleNumber", typeof(string));

            foreach (var rRating in rsRating)
                dt.Columns.Add("R" + rRating.Code, typeof(string));

            foreach (var r in rs)
            {
                var row = dt.NewRow();
                row["Name"] = r.Name;
                row["BonusCardinalSubDept"] = string.Format("{0:N0}", r.BonusCardinalSubDept);
                row["BonusRealSubDept"] = string.Format("{0:N0}", r.BonusRealSubDept);
                row["BonusAdjustSubDept"] = string.Format("{0:N0}", r.BonusAdjustSubDept);
                row["PeopleNumber"] = string.Format("{0:N0}", r.PeopleNumber);

                var rsBaseDept = rsBase.Where(p => p.PerformanceDeptCode == r.Code).ToList();
                var BaseRowCount = Convert.ToDecimal(rsBaseDept.Count);
                foreach (var rRating in rsRating)
                {
                    var RatingRowCount = rsBaseDept.Where(p => p.RatingCode == rRating.Code).ToList().Count;
                    var Percent = Math.Round((RatingRowCount / BaseRowCount), 2);

                    row["R" + rRating.Code] = RatingRowCount + "<BR>" + string.Format("{0:P0}", Percent);
                }

                dt.Rows.Add(row);
            }

            gvDept.DataSource = dt;
        }

        protected void gvDept_DataBound(object sender, EventArgs e)
        {
            //GridColumnGroup gColumn = new GridColumnGroup();
            //gColumn.Name = "RatingPeople";
            //gColumn.HeaderText = "評等分配(人數 / 百分比)";
            //gColumn.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
            //gvDept.MasterTableView.ColumnGroups.Add(gColumn);
        }

        protected void gvDept_ColumnCreated(object sender, GridColumnCreatedEventArgs e)
        {
            if (UnobtrusiveSession.Session["rsRating"] != null)
            {
                var rsRating = UnobtrusiveSession.Session["rsRating"] as List<PerformanceRating>;

                var rRating = rsRating.FirstOrDefault(p => ("R" + p.Code) == e.Column.UniqueName);
                if (rRating != null)
                {
                    e.Column.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                    e.Column.ItemStyle.Wrap = false;
                    e.Column.HeaderText = rRating.Name;
                    e.Column.ColumnGroupName = "RatingPeople";
                }
            }

            if (e.Column.UniqueName == "Name")
                e.Column.HeaderText = "部門<br>名稱";
            if (e.Column.UniqueName == "BonusCardinalSubDept")
            {
                e.Column.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
                e.Column.HeaderText = "獎金基數<br>總額(a)";
            }
            if (e.Column.UniqueName == "BonusRealSubDept")
            {
                e.Column.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
                e.Column.HeaderText = "已分配<br>獎金總額(b)";
            }
            if (e.Column.UniqueName == "BonusAdjustSubDept")
            {
                e.Column.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
                e.Column.HeaderText = "未分配<br>獎金(c)=a-b";
            }
            if (e.Column.UniqueName == "PeopleNumber")
            {
                e.Column.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
                e.Column.HeaderText = "評核<br>人數";
                e.Column.ColumnGroupName = "RatingPeople";
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            SaveData();
        }

        protected void btnImport_Click(object sender, EventArgs e)
        {
            FlowAction("Import");
        }

        protected void btnApprove_Click(object sender, EventArgs e)
        {
            FlowAction("Approve");
        }

        protected void btnReject_Click(object sender, EventArgs e)
        {
            FlowAction("Reject");
        }

        protected void btnReminder_Click(object sender, EventArgs e)
        {
            FlowAction("Reminder");
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            FlowAction("Reset");
        }

        protected void btnReCalRating_Click(object sender, EventArgs e)
        {
            FlowAction("ReCalRating");
        }

        public void FlowAction(string ActionCode)
        {
            if (ddlMain.SelectedItem == null || ddlDept.SelectedValue.Length == 0)
            {
                lblMsg.Text = "資訊錯誤";
                return;
            }

            if (UnobtrusiveSession.Session["BaseView"] == null ||
                UnobtrusiveSession.Session["ListDept"] == null ||
                UnobtrusiveSession.Session["BonusView"] == null ||
                UnobtrusiveSession.Session["MainCode"] == null ||
                UnobtrusiveSession.Session["TopDeptCode"] == null)
            {
                var Temp = ListBaseView;
            }

            var MainCode = ddlMain.SelectedItem.Value;
            var DeptCode = ddlDept.SelectedValue;
            var SubDept = cbSubDept.Checked.GetValueOrDefault(false);
            var Base = cbBase.Checked.GetValueOrDefault(false);
            var ListDept = (List<PerformanceDept>)UnobtrusiveSession.Session["ListDept"];
            var BonusView = Convert.ToBoolean(UnobtrusiveSession.Session["BonusView"]);

            var ListDeptCode = ListDept.Select(p => p.Code).ToList();

            var EmpId = _User.UserCode;

            var rMain = (from c in dcMain.PerformanceMain
                         where c.Code == MainCode
                         select c).FirstOrDefault();

            if (rMain == null)
            {
                lblMsg.Text = "資訊錯誤";
                return;
            }

            var EmpCategoryCode = rMain.EmpCategoryCode;

            SaveData(true);

            UnobtrusiveSession.Session["SelectDeptCode"] = ddlDept.SelectedValue;

            switch (ActionCode)
            {
                case "Approve": //呈核
                    {
                        SaveData(true);

                        //取得人員資料
                        var rsBase = (from c in dcMain.PerformanceBase
                                      where c.PerformanceMainCode == MainCode
                                      && ListDeptCode.Contains(c.PerformanceDeptCode)
                                      && c.EmpId != EmpId
                                      orderby c.EmpId
                                      select c).ToList();

                        //ExceptionBonusAll有設定的情況下 這些人不參與總金額的限制
                        var BonusAdjust = rsBase.Where(p => !p.ExceptionBonusAll && ListDeptCode.Contains(p.PerformanceDeptCode)).Sum(p => p.BonusAdjust);
                        if (BonusAdjust > 0)
                        {
                            lblMsg.Text = "請檢查可分配獎金是否超出預算";
                            return;
                        }

                        var rsRating = (from c in dcMain.PerformanceRating
                                        where c.CheckNote
                                        && c.EmpCategoryCode == EmpCategoryCode
                                        select c).ToList();

                        var Msg = "";
                        //檢查總分數必需大於0
                        //檢查金額是否落於最大及最小裡(js會判)
                        //判斷丙等是否有輸入備註
                        var MsgTotalIntegrate = "";
                        var MsgRange = "";
                        var MsgNote = "";
                        foreach (var rBase in rsBase)
                        {
                            var TotalIntegrate = rBase.TotalIntegrate;
                            var Rating = rsRating.Any(p => p.Code == rBase.RatingCode);
                            var Note = rBase.Note.Length == 0;
                            var ExceptionBonusAll = rBase.ExceptionBonusAll;
                            var ExceptionBonus = rBase.ExceptionBonus;
                            var ExceptionNote = rBase.ExceptionNote;

                            if (!ExceptionNote && Rating && Note)
                                MsgNote += "<br>工號：" + rBase.EmpId + ",姓名：" + rBase.EmpName;

                            var Max = rBase.BonusMax;
                            var Min = rBase.BonusDeduct;
                            var Bonus = rBase.BonusReal;

                            //不受限制
                            if (!ExceptionBonusAll)
                                if (!ExceptionBonus && (Bonus < Min || Bonus > Max))
                                    MsgRange += "<br>工號：" + rBase.EmpId + ",姓名：" + rBase.EmpName;

                            if (!ExceptionBonusAll)
                                if (TotalIntegrate == 0)
                                    MsgTotalIntegrate += "<br>工號：" + rBase.EmpId + ",姓名：" + rBase.EmpName;
                        }

                        if (MsgNote.Length > 0)
                        {
                            MsgNote = "<div class=\"RadAlertRedBlock\">下列人員，請輸入備註欄評語：</div>" + MsgNote ;
                            Msg += MsgNote + "<br><br>";
                        }

                        if (MsgTotalIntegrate.Length > 0)
                        {
                            MsgTotalIntegrate = "<div class=\"RadAlertRedBlock\">下列人員，評核總分不得為零：</div>" + MsgTotalIntegrate;
                            Msg += MsgTotalIntegrate + "<br><br>";
                        }

                        if (BonusView)
                        {
                            if (MsgRange.Length > 0)
                            {
                                MsgRange = "<div class=\"RadAlertRedBlock\">下列人員，總分配獎金超過上下限範圍：</div>" + MsgRange;
                                Msg += MsgRange + "<br><br>";
                            }
                        }

                        if (Msg.Length > 0)
                        {
                            UnobtrusiveSession.Session["Msg"] = Msg;
                            Response.Redirect("ShareMessage.aspx");
                        }
                        else
                            Response.Redirect("MainBaseApprove.aspx");
                        //傳送完整部門 可能包含子部門
                        //傳送目前點選部門做為審核層級判斷(當前部門為傳簽層級的判斷角度)
                    }
                    break;
                case "Reject":  //退回
                    SaveData(true);

                    Response.Redirect("MainBaseReject.aspx");
                    break;
                case "Reminder":    //催簽
                    Response.Redirect("MainBaseReminder.aspx");
                    break;
                case "Reset":   //重置
                    Response.Redirect("MainBaseReset.aspx");
                    break;
                case "Import":  //匯入
                    SaveData(true);

                    Response.Redirect("MainBaseImport.aspx");
                    break;
                case "ReCalRating":   //重新計算評等
                    {
                        SaveData(true);

                        //由大排到小 例如 甲→乙→丙
                        var rsRating = (from c in dcMain.PerformanceRating
                                        join d in dcMain.PerformanceDeptRating on c.Code equals d.PerformanceRatingCode
                                        where c.EmpCategoryCode == EmpCategoryCode
                                        && d.PerformanceMainCode == MainCode
                                        && d.PerformanceDeptCode == DeptCode
                                        orderby c.Sort
                                        select new
                                        {
                                            c.Code,
                                            c.Name,
                                            d.NumPer,
                                        }).ToList();

                        //取得部門及其向下的人
                        var rsDept = (from c in dcMain.PerformanceDept
                                      where c.PerformanceMainCode == MainCode
                                      && c.PathCode.IndexOf("/" + DeptCode + "/") >= 0
                                      select c).ToList();

                         ListDeptCode = rsDept.Select(p => p.Code).ToList();

                        //由大排到小
                        var rsBase = (from c in dcMain.PerformanceBase
                                      where c.PerformanceMainCode == MainCode
                                      && ListDeptCode.Contains(c.PerformanceDeptCode)
                                      && c.EmpId != EmpId
                                      orderby c.TotalIntegrate descending
                                      select c).ToList();

                      var  Msg = "此次調整總人數為：" + rsBase.Count + "人";

                        if (rsRating.Count > 0)
                        {
                            var iRating = 0;  //評等列數
                            var iBase = 0;    //人數分配列數
                            var iBaseCount = 0;
                            var Num = 0; //分配人數
                            var rRating = rsRating.First();
                            foreach (var rBase in rsBase)
                            {
                                //人數分配列數 大於 評等列數
                                while (iBase >= Num && (iRating <= (rsRating.Count - 1)))
                                {
                                    //依序取得評等的人數分配百分比
                                    rRating = rsRating[iRating];

                                    //無條件捨去
                                    //Num = Convert.ToInt32(Math.Floor(rsBase.Count * (rRating.NumPer / 100M)));
                                    //四捨五入
                                    Num = Convert.ToInt32(Math.Floor(rsBase.Count * Math.Round((rRating.NumPer / 100M), 2, MidpointRounding.AwayFromZero)));

                                    //最後一次計算 剩下的人數都給最後一次
                                    if (rRating == rsRating.Last())
                                        Num = rsBase.Count - iBaseCount;

                                    Msg += "｜[" + rRating.Name + "]等：" + Num + "人";

                                    iRating++;
                                    iBase = 0;
                                };

                                //填入
                                rBase.RatingCode = rRating.Code;
                                rBase.BonusAdjust = 0;
                                rBase.BonusReal = rBase.BonusCardinal;

                                iBase++;
                                iBaseCount++;
                            }

                            dcMain.SubmitChanges();

                            gvMain.Rebind();
                        }

                        lblMsg.Text = Msg;
                    }
                    break;
                default:
                    break;
            }
        }


        public void SaveData(bool FlowSend = false)
        {
            if (ddlMain.SelectedItem == null || ddlDept.SelectedValue.Length == 0)
            {
                lblMsg.Text = "資訊錯誤";
                return;
            }

            if (UnobtrusiveSession.Session["BaseView"] == null ||
                UnobtrusiveSession.Session["ListDept"] == null ||
                UnobtrusiveSession.Session["BonusView"] == null ||
                UnobtrusiveSession.Session["MainCode"] == null ||
                UnobtrusiveSession.Session["TopDeptCode"] == null)
            {
                var Temp = ListBaseView;
            }

            var MainCode = ddlMain.SelectedItem.Value;
            var DeptCode = ddlDept.SelectedValue;
            var SubDept = cbSubDept.Checked.GetValueOrDefault(false);
            var Base = cbBase.Checked.GetValueOrDefault(false);
            var ListDept = (List<PerformanceDept>)UnobtrusiveSession.Session["ListDept"];
            var BonusView = Convert.ToBoolean(UnobtrusiveSession.Session["BonusView"]);

            var EmpId = _User.UserCode;

            var rMain = (from c in dcMain.PerformanceMain
                         where c.Code == MainCode
                         select c).FirstOrDefault();

            if (rMain == null)
            {
                lblMsg.Text = "資訊錯誤";
                return;
            }

            var ListDeptCode = ListDept.Select(p => p.Code).ToList();

            //儲存資料
            var rsBase = (from c in dcMain.PerformanceBase
                          where c.PerformanceMainCode == MainCode
                          && ListDeptCode.Contains(c.PerformanceDeptCode)
                          && c.EmpId != EmpId
                          select c).ToList();

            foreach (GridDataItem item in gvMain.Items)
            {
                //是可以儲存的資料
                if (item.Enabled)
                {
                    var AutoKey = Convert.ToInt32(item.GetDataKeyValue("AutoKey"));

                    var txtWorkPerformanceObj = item.FindControl("txtWorkPerformance");
                    var txtMannerEsteemObj = item.FindControl("txtMannerEsteem");
                    var txtAbilityEsteemObj = item.FindControl("txtAbilityEsteem");
                    var txtEncourageObj = item.FindControl("txtEncourage");

                    var ddlRatingObj = item.FindControl("ddlRating");

                    var txtBonusDeductObj = item.FindControl("txtBonusDeduct");
                    var txtBonusMaxObj = item.FindControl("txtBonusMax");
                    var txtBonusAdjustObj = item.FindControl("txtBonusAdjust");
                    var txtBonusAdjustTempObj = item.FindControl("txtBonusAdjustTemp");
                    var lblBonusCardinalObj = item.FindControl("lblBonusCardinal");
                    var txtBonusRealObj = item.FindControl("txtBonusReal");

                    var txtNoteObj = item.FindControl("txtNote");

                    if (txtWorkPerformanceObj != null)
                    {
                        var txtWorkPerformance = txtWorkPerformanceObj as RadNumericTextBox;
                        var txtMannerEsteem = txtMannerEsteemObj as RadNumericTextBox;
                        var txtAbilityEsteem = txtAbilityEsteemObj as RadNumericTextBox;
                        var txtEncourage = txtEncourageObj as RadNumericTextBox;

                        var ddlRating = ddlRatingObj as RadDropDownList;

                        var txtBonusDeduct = txtBonusDeductObj as RadNumericTextBox;
                        var txtBonusMax = txtBonusMaxObj as RadNumericTextBox;
                        var txtBonusAdjust = txtBonusAdjustObj as RadNumericTextBox;
                        var txtBonusAdjustTemp = txtBonusAdjustTempObj as RadNumericTextBox;
                        var lblBonusCardinal = lblBonusCardinalObj as RadLabel;
                        var txtBonusReal = txtBonusRealObj as RadNumericTextBox;

                        var txtNote = txtNoteObj as RadTextBox;

                        var WorkPerformance = txtWorkPerformance.Text.ParseInt();
                        var MannerEsteem = txtMannerEsteem.Text.ParseInt();
                        var AbilityEsteem = txtAbilityEsteem.Text.ParseInt();
                        var Encourage = txtEncourage.Text.ParseInt();
                        var TotalIntegrate = WorkPerformance + MannerEsteem + AbilityEsteem + Encourage;

                        var RatingCode = ddlRating.SelectedItem.Value;

                        var BonusDeduct = txtBonusDeduct.Text.ParseInt();
                        var BonusMax = txtBonusMax.Text.ParseInt();
                        var BonusAdjust = txtBonusAdjust.Text.ParseInt();
                        var BonusAdjustTemp = txtBonusAdjustTemp.Text.ParseInt();
                        var BonusCardinal = lblBonusCardinal.Text.ParseDecimal();
                        var BonusReal = BonusCardinal + BonusAdjustTemp;

                        var Note = txtNote.Text;

                        var r = rsBase.FirstOrDefault(p => p.AutoKey == AutoKey);
                        if (r != null)
                        {
                            r.WorkPerformance = WorkPerformance;
                            r.MannerEsteem = MannerEsteem;
                            r.AbilityEsteem = AbilityEsteem;
                            r.Encourage = Encourage;
                            r.TotalIntegrate = TotalIntegrate;
                            r.RatingCode = RatingCode;
                            r.BonusDeduct = BonusDeduct;
                            r.BonusMax = BonusMax;
                            //違返規則會有沒有值 就不用再寫入
                            //if (txtBonusAdjust.Text.Length > 0)
                            {
                                r.BonusAdjust = BonusAdjustTemp;
                                r.BonusReal = BonusReal;
                            }
                            r.Note = Note;
                            r.UpdateMan = _User.UserCode;
                            r.UpdateDate = DateTime.Now;
                        }
                    }
                }
            }

            dcMain.SubmitChanges();

            if (!FlowSend)
                lblMsg.Text = "儲存成功";

            gvMain.Rebind();
        }
    }
}