using Bll;
using Bll.Tools;
using Dal;
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
    public partial class ManageMainWizard : WebPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                lblCode.Text = Guid.NewGuid().ToString();

                ddlEmpCategory_DataBind();
                ddlType_DataBind();
                ddlYymm_DataBind();
                _DataBind();

                DateTime DateNow = DateTime.Now.Date.AddMonths(1);
                DateTime DateA = new DateTime(DateNow.Year, DateNow.Month, 1);
                DateTime DateD = new DateTime(DateNow.Year, DateNow.Month, DateTime.DaysInMonth(DateNow.Year, DateNow.Month));

                txtDateA.SelectedDate = DateA;
                txtDateD.SelectedDate = DateD;
                txtDateBase.SelectedDate = DateD;

                LoadData(lblKey1.Text);
            }
        }
        public void ddlType_DataBind()
        {
            var rs = oMainDao.ShareCodeTextValue("PerformanceType");

            ddlType.DataSource = rs;
            ddlType.DataTextField = "Text";
            ddlType.DataValueField = "Value";
            ddlType.DataBind();

            ddlYymm_DataBind();
        }

        public void ddlYymm_DataBind()
        {
            //var TypeCode = ddlType.SelectedItem.Value;

            //var oPerformance = new PerformanceDao(dcShare, dcMain, dcHr);
            //var rsView = oPerformance.GetYymm(TypeCode);

            //ddlYymm.DataSource = rsView;
            //ddlYymm.DataTextField = "Text";
            //ddlYymm.DataValueField = "Value";
            //ddlYymm.DataBind();

            var ListYear = new List<TextValueRow>();
            for (int Year = (oMainDao._NowDate.Year - 1); Year <= (oMainDao._NowDate.Year + 1); Year++)
            {
                var yy = Year.ToString();
                var rYear = new TextValueRow();
                rYear.Text = yy;
                rYear.Value = yy;
                ListYear.Add(rYear);
            }

            ddlYear.DataSource = ListYear;
            ddlYear.DataTextField = "Text";
            ddlYear.DataValueField = "Value";
            ddlYear.DataBind();

            if (ddlYear.FindItemByValue(oMainDao._NowDate.Year.ToString()) != null)
                ddlYear.FindItemByValue(oMainDao._NowDate.Year.ToString()).Selected = true;

            var ListMonth = new List<TextValueRow>();
            for (int Month = 1; Month <= 12; Month++)
            {
                var mm = Month.ToString("00");
                var rMonth = new TextValueRow();
                rMonth.Text = mm;
                rMonth.Value = mm;
                ListMonth.Add(rMonth);
            }

            ddlMonth.DataSource = ListMonth;
            ddlMonth.DataTextField = "Text";
            ddlMonth.DataValueField = "Value";
            ddlMonth.DataBind();

            if (ddlMonth.FindItemByValue(oMainDao._NowDate.Month.ToString("00")) != null)
                ddlMonth.FindItemByValue(oMainDao._NowDate.Month.ToString("00")).Selected = true;
        }

        public void ddlEmpCategory_DataBind()
        {
            var rs = oMainDao.ShareCodeTextValue("EmpCategory");

            ddlEmpCategory.DataSource = rs;
            ddlEmpCategory.DataTextField = "Text";
            ddlEmpCategory.DataValueField = "Value";
            ddlEmpCategory.DataBind();

            ddlRating_DataBind();
        }

        public void ddlRating_DataBind()
        {
            var EmpCategoryCode = ddlEmpCategory.SelectedItem.Value;

            var oPerformance = new PerformanceDao(dcShare, dcMain, dcHr);
            var rs = oPerformance.GetPerformanceRating(EmpCategoryCode);

            ddlRating.DataSource = rs;
            ddlRating.DataTextField = "Text";
            ddlRating.DataValueField = "Value";
            ddlRating.DataBind();
        }

        public void _DataBind()
        {
            var oPerformance = new PerformanceDao(dcShare, dcMain, dcHr);
            var rs = oPerformance.GetDeptLevel();

            ddlDeptTreeB.DataSource = rs;
            ddlDeptTreeB.DataTextField = "Text";
            ddlDeptTreeB.DataValueField = "Value";
            ddlDeptTreeB.DataBind();

            ddlDeptTreeE.DataSource = rs;
            ddlDeptTreeE.DataTextField = "Text";
            ddlDeptTreeE.DataValueField = "Value";
            ddlDeptTreeE.DataBind();
        }

        protected void ddlType_SelectedIndexChanged(object sender, Telerik.Web.UI.DropDownListEventArgs e)
        {
            ddlYymm_DataBind();
        }

        protected void ddlEmpCategory_SelectedIndexChanged(object sender, Telerik.Web.UI.DropDownListEventArgs e)
        {
            ddlRating_DataBind();
        }


        public void LoadData(string Key)
        {
            Key = Key.Length > 0 ? Key : "-1";
            var AutoKey = Convert.ToInt32(Key);

            var r = (from c in dcMain.PerformanceMain
                     where c.AutoKey == AutoKey
                     select c).FirstOrDefault();

            if (r != null)
            {
                lblCode.Text = r.Code;
                lblYymm.Text = r.Yymm;
            }
        }

        protected void wzMain_ActiveStepChanged(object sender, EventArgs e)
        {

        }

        protected void wzMain_NextButtonClick(object sender, WizardEventArgs e)
        {
            if (txtDateA.SelectedDate == null || txtDateD.SelectedDate == null)
            {
                lblMsg.Text = "生失效日不可以空白";
                return;
            }

            var Code = lblCode.Text;
            var Name = txtName.Text;
            var Year = ddlYear.SelectedItem.Value;
            var Month = ddlMonth.SelectedItem.Value;
            //var Yymm = ddlYymm.SelectedItem.Value;
            var Yymm = Year + Month;
            var Seq = "1";
            var EmpCategoryCode = ddlEmpCategory.SelectedItem.Value;
            var TypeCode = ddlType.SelectedItem.Value;
            var DateA = txtDateA.SelectedDate.Value;
            var DateD = txtDateD.SelectedDate.Value;
            var DateBase = txtDateBase.SelectedDate.GetValueOrDefault(DateD);
            var Sort = txtSort.Text.ParseInt(9);
            var RatingCode = ddlRating.SelectedItem.Value;
            var DeptTreeB = ddlDeptTreeB.SelectedItem.Value.ParseInt(50);
            var DeptTreeE = ddlDeptTreeE.SelectedItem.Value.ParseInt(90);
            var Note = txtNote.Text;

            var BonusCardinal = txtBonusCardinal.Text.ParseInt(0);
            var BonusCardinalLimit = txtBonusCardinalLimit.Text.ParseInt(0);
            var ExceptionBonusAll = cbExceptionBonusAll.Checked.GetValueOrDefault(false);
            var ExceptionBonus = cbExceptionBonus.Checked.GetValueOrDefault(false);
            var ExceptionNote = cbExceptionNote.Checked.GetValueOrDefault(false);

            var DataNow = DateTime.Now.Date;

            if (Name.Length == 0)
            {
                lblMsg.Text = "名稱不可空白";
                wzMain.ActiveStepIndex = 0;
                return;
            }

            if (DeptTreeE.ToString().Length == 0)
            {
                lblMsg.Text = "簽核層級不可以空白";
                wzMain.ActiveStepIndex = 0;
                return;
            }

            switch (e.CurrentStep.ID)
            {
                case "s1":  //產生所有名單
                    {
                        if (dcMain.PerformanceMain.Any(c => c.Yymm == Yymm && c.TypeCode == TypeCode && c.Seq == Seq && c.EmpCategoryCode == EmpCategoryCode))
                        {
                            lblMsg.Text = "資料重複，請重新輸入";
                            wzMain.ActiveStepIndex = 0;
                            return;
                        }

                        //利用員別取出職等代碼
                        var rsJob = (from c in dcHr.ViewJob
                                     select c).ToList();

                        var rsJobl = (from c in dcHr.ViewJobl
                                      select c).ToList();

                        var rsDept = (from c in dcHr.ViewDept
                                      select c).ToList();

                        //以基準日抓出所有員工基本資料
                        var rsBase = (from c in dcHr.ViewEmp
                                      select c).ToList();

                        //var ListEmpId = rsBase.Select(p => p.Nobr).ToList();

                        //考核員工基本資料 計算部門獎金會需要用到 暫存
                        var rsPerformanceBase = new List<PerformanceBase>();

                        var rsPerformanceBaseLog = new List<PerformanceBaseLog>();

                        var oPerformance = new PerformanceDao(dcShare, dcMain, dcHr);

                        //員工異動
                        {                         
                            var CompCode = "A";

                            var rsPerformanceRating = (from c in dcMain.PerformanceRating
                                                       where c.CompCode == CompCode
                                                       && c.EmpCategoryCode == EmpCategoryCode
                                                       //&& c.Code == RatingCode
                                                       select c).ToList();

                            foreach (var rSource in rsBase)
                            {
                                //新增：目的資料缺少就是新增
                                {
                                    {
                                        var rTarget = new PerformanceBase();
                                        rTarget.PerformanceMainCode = Code;
                                        rTarget.Code = Guid.NewGuid().ToString();
                                        rTarget.EmpId = rSource.Code;
                                        rTarget.PerformanceDeptCode = rSource.DeptCode; //這個部門是編制部門 應該是錯的
                                        rTarget.WorkPerformance = 0;    //工作績效
                                        rTarget.MannerEsteem = 0;   //態度評價
                                        rTarget.AbilityEsteem = 0;  //能力評價
                                        rTarget.Encourage = 0;  //激勵
                                        rTarget.TotalIntegrate = 0; //總積分
                                        rTarget.RatingCode = RatingCode;    //評等
                                        rTarget.BonusCardinal = BonusCardinal;   //分配獎金
                                        rTarget.InWorkSpecific = 1; //在職比
                                        rTarget.BonusTotal = BonusCardinalLimit; //獎金基數
                                        rTarget.BonusDeduct = 0;    //可扣獎金
                                        rTarget.BonusMax = 0;    //最高加發獎金
                                        rTarget.BonusAdjust =0;    //考績加減
                                        rTarget.BonusReal = rTarget.BonusCardinal + rTarget.BonusAdjust;  //實際獎金
                                        rTarget.ExceptionBonusAll = ExceptionBonusAll;
                                        rTarget.ExceptionBonus = ExceptionBonus;
                                        rTarget.ExceptionNote = ExceptionNote;
                                        rTarget.Note = "";
                                        rTarget.EmpCategoryCode = EmpCategoryCode;
                                        rTarget.InsertMan = lblUserCode.Text;
                                        rTarget.InsertDate = DateTime.Now;
                                        rTarget.UpdateMan = lblUserCode.Text;
                                        rTarget.UpdateDate = DateTime.Now;

                                        rTarget.EmpName = "";
                                        rTarget.PerformanceDeptCode = "";
                                        rTarget.JobCode = "";
                                        rTarget.JobName = "";
                                        rTarget.JoblCode = "";
                                        rTarget.JoblName = "";
                                        rTarget.WorkCode = "";
                                        rTarget.WorkName = "";
                                        rTarget.CompCode = "";

                                        {
                                            rTarget.EmpName = rSource.Name;
                                            rTarget.PerformanceDeptCode = rSource.DeptCode;
                                            rTarget.JobCode = rSource.JobCode;
                                            rTarget.JobName = rsJob.FirstOrDefault(p => p.Code == rTarget.JobCode)?.Name ?? "";
                                            rTarget.JoblCode = rSource.JoblCode;
                                            rTarget.JoblName = rsJobl.FirstOrDefault(p => p.Code == rTarget.JoblCode)?.Name ?? "";
                                            rTarget.WorkCode = "";
                                            rTarget.WorkName = "";
                                            rTarget.CompCode = "";
                                        }

                                        //計算評等最高及可扣獎金
                                        var rPerformanceRating = rsPerformanceRating.FirstOrDefault(p => p.Code == rTarget.RatingCode);
                                        if (rPerformanceRating != null)
                                        {
                                            rTarget.BonusDeduct = oPerformance.CalculationBonusDeduct(rTarget.BonusTotal, rPerformanceRating.BonusPerMin);    //可扣獎金
                                            rTarget.BonusMax = oPerformance.CalculationBonusMax(rTarget.BonusTotal, rPerformanceRating.BonusPerMax);  //最高加發獎金
                                        }

                                        //新增暫存資料
                                        rsPerformanceBase.Add(rTarget);
                                    }
                                }
                            }
                        }

                        //考核部門暫存資料
                        var rsPerformanceDept = new List<PerformanceDept>();

                        //部門異動
                        {
                            //取得來源資料
                            var rsSource = oPerformance.GetDept(DateBase, 999);

                            foreach (var rSource in rsSource)
                            {
                                //必須比最大部門小才會寫入 20201103改成全數產生
                                //if (rSource.DeptTree <= DeptTreeE)
                                {
                                    {
                                        //準備計算獎金在部門的總和
                                        var rsPerformanceBaseByDept = rsPerformanceBase.Where(p => p.PerformanceDeptCode == rSource.Code).ToList();

                                        var rTarget = new PerformanceDept();
                                        rTarget.PerformanceMainCode = Code;
                                        rTarget.Code = rSource.Code;
                                        rTarget.DisplayCode = rSource.DisplayCode;
                                        rTarget.Name = rSource.Name;
                                        rTarget.DeptTree = rSource.DeptTree;
                                        rTarget.DeptTreeB = DeptTreeB;
                                        rTarget.DeptTreeE = DeptTreeE;
                                        rTarget.ParentCode = rSource.ParentCode;
                                        rTarget.ManagerId = rSource.ManagerId;
                                        rTarget.Mail = rSource.Mail;    //待確認：要用部門的信箱還是基本資料的信箱
                                        rTarget.ParentManagerId = rSource.ParentManagerId;
                                        rTarget.BonusMax = rsPerformanceBaseByDept.Sum(p => p.BonusCardinal);
                                        rTarget.BonusUse = rTarget.BonusMax;
                                        rTarget.BonusBalance = 0;
                                        rTarget.InsertMan = lblUserCode.Text;
                                        rTarget.InsertDate = DateTime.Now;
                                        rTarget.UpdateMan = lblUserCode.Text;
                                        rTarget.UpdateDate = DateTime.Now;
                                        rTarget.PathCode = rSource.PathCode;
                                        rTarget.PathName = rSource.PathName;

                                        rTarget.ManagerName = "";
                                        rTarget.JobCode = "";
                                        rTarget.JobName = "";
                                        rTarget.JoblCode = "";
                                        rTarget.JoblName = "";

                                        var rBase = rsBase.FirstOrDefault(p => p.Code == rSource.ManagerId);
                                        if (rBase !=null)
                                        {
                                            rTarget.ManagerName = rBase.Name;
                                            rTarget.JobCode = rBase.JobCode;
                                            rTarget.JobName = rsJob.FirstOrDefault(p => p.Code == rTarget.JobCode)?.Name;
                                            rTarget.JoblCode = rBase.JoblCode;
                                            rTarget.JoblName = rsJobl.FirstOrDefault(p => p.Code == rTarget.JoblCode)?.Name ?? "";
                                            rTarget.Mail = rBase.Email;         
                                        }

                                        dcMain.PerformanceDept.InsertOnSubmit(rTarget);

                                        //新增暫存資料
                                        rsPerformanceDept.Add(rTarget);
                                    }
                                }
                            }
                        }


                        //考核部門暫存資料
                        var rsPerformanceJob = new List<PerformanceJob>();

                        //職稱
                        {
                            //取得來源資料
                            var rsSource = rsJob;

                            foreach (var rSource in rsSource)
                            {
                                var rTarget = new PerformanceJob();
                                rTarget.PerformanceMainCode = Code;
                                rTarget.Code = rSource.Code;
                                rTarget.DisplayCode = rSource.Code;
                                rTarget.Name = rSource.Name;
                                rTarget.InsertMan = lblUserCode.Text;
                                rTarget.InsertDate = DateTime.Now;
                                rTarget.UpdateMan = lblUserCode.Text;
                                rTarget.UpdateDate = DateTime.Now;

                                dcMain.PerformanceJob.InsertOnSubmit(rTarget);

                                //新增暫存資料
                                rsPerformanceJob.Add(rTarget);
                            }
                        }

                        //將資料存到log裡
                        foreach (var rPerformanceBase in rsPerformanceBase)
                        {
                            var rPerformanceBaseLog = new PerformanceBaseLog();
                            rPerformanceBase.CopyPropertyValues(rPerformanceBaseLog);
                            rPerformanceBaseLog.PerformanceFlowNodeCode = "0";
                            rsPerformanceBaseLog.Add(rPerformanceBaseLog);
                        }

                        //主流程
                        var rsPerformanceFlow = new List<PerformanceFlow>();

                        //流程節點
                        var rsPerformanceFlowNode = new List<PerformanceFlowNode>();

                        //流程異動
                        {
                            {
                                //用須考核的員工基本資料 進行表單的產生 一個部門就代表一張表單
                                var ListDept = rsPerformanceBase.Select(p => p.PerformanceDeptCode).Distinct().ToList();

                                switch ("01")
                                {
                                    case "01":  //啟動流程
                                                //已經啟動的流程就不需要啟動
                                                //沒有啟動的流程才需要啟動
                                        foreach (var Dept in ListDept)
                                        {
                                            var rf = rsPerformanceFlow.FirstOrDefault(p => p.PerformanceDeptCode == Dept);
                                            if (rf == null)
                                            {
                                                var rDept = rsPerformanceDept.FirstOrDefault(p => p.Code == Dept);

                                                if (rDept != null)
                                                {
                                                    rf = new PerformanceFlow();
                                                    rf.PerformanceMainCode = Code;
                                                    rf.PerformanceDeptCode = Dept;
                                                    rf.Code = Guid.NewGuid().ToString();
                                                    rf.IsFinish = false;
                                                    rf.IsCancel = false;
                                                    rf.IsError = false;
                                                    rf.DeptTree = rDept.DeptTree;
                                                    rf.DeptTreeB = rDept.DeptTreeB;
                                                    rf.DeptTreeE = rDept.DeptTreeE;// rPerformanceMain.DeptTreeE;
                                                    rf.InsertMan = lblUserCode.Text;
                                                    rf.InsertDate = DateTime.Now;
                                                    rf.UpdateMan = lblUserCode.Text;
                                                    rf.UpdateDate = DateTime.Now;
                                                    rsPerformanceFlow.Add(rf);

                                                    var rn = new PerformanceFlowNode();
                                                    rn.PerformanceFlowCode = rf.Code;
                                                    rn.Code = Guid.NewGuid().ToString();
                                                    rn.ParentCode = ""; //第一層所以空白
                                                    rn.PerformanceDeptCodeDefault = rDept.Code;
                                                    rn.EmpIdDefault = rDept.ManagerId;
                                                    rn.PerformanceDeptCodeReal = "";
                                                    rn.EmpIdReal = "";  //實際簽核主管
                                                    rn.IsFinish = false;
                                                    rn.DeptTree = 0;
                                                    rn.DeptSort = 1;
                                                    rn.ActiveCode = "00";
                                                    rn.Sort = 1;
                                                    rn.InsertMan = lblUserCode.Text;
                                                    rn.InsertDate = DateTime.Now;
                                                    rn.UpdateMan = lblUserCode.Text;
                                                    rn.UpdateDate = DateTime.Now;
                                                    rsPerformanceFlowNode.Add(rn);

                                                    //更改FlowNodeCode
                                                    var rsPerformanceBaseLogTemp = rsPerformanceBaseLog.Where(p => p.PerformanceDeptCode == Dept);
                                                    foreach (var rPerformanceBaseLogTemp in rsPerformanceBaseLogTemp)
                                                        rPerformanceBaseLogTemp.PerformanceFlowNodeCode = rn.Code;
                                                }
                                            }
                                        }
                                        break;
                                }
                            }
                        }

                        if (rsPerformanceBase == null && rsPerformanceBase.Count == 0)
                        {
                            lblMsg.Text = "您沒有產生任何資料";
                            wzMain.ActiveStepIndex = 0;
                            return;
                        }

                        UnobtrusiveSession.Session["rsPerformanceBase"] = rsPerformanceBase;
                        UnobtrusiveSession.Session["rsPerformanceBaseLog"] = rsPerformanceBaseLog;
                        UnobtrusiveSession.Session["rsPerformanceDept"] = rsPerformanceDept;
                        UnobtrusiveSession.Session["rsPerformanceJob"] = rsPerformanceJob;
                        UnobtrusiveSession.Session["rsPerformanceFlow"] = rsPerformanceFlow;
                        UnobtrusiveSession.Session["rsPerformanceFlowNode"] = rsPerformanceFlowNode;

                        lvDept.Rebind();
                    }
                    break;

                case "s2":
                    var rsPerformanceDept2 = UnobtrusiveSession.Session["rsPerformanceDept"] as List<PerformanceDept>;
                    var rsPerformanceFlow2 = UnobtrusiveSession.Session["rsPerformanceFlow"] as List<PerformanceFlow>;

                    //將使用者所設定的部門資訊 重新填入
                    foreach (var item in lvDept.Items)
                    {
                        var Code1 = item.GetDataKeyValue("Code").ToString();

                        var ddlDeptTreeBObj = item.FindControl("ddlDeptTreeB");
                        var ddlDeptTreeEObj = item.FindControl("ddlDeptTreeE");
                        if (Code1.Length > 0)
                        {
                            var ddlDeptTreeB = ddlDeptTreeBObj as RadDropDownList;
                            var ddlDeptTreeE = ddlDeptTreeEObj as RadDropDownList;

                            var rDept = rsPerformanceDept2.FirstOrDefault(p => p.Code == Code1);
                            if (rDept != null)
                            {
                                rDept.DeptTreeB = ddlDeptTreeB.SelectedItem.Value.ParseInt(60);
                                rDept.DeptTreeE = ddlDeptTreeE.SelectedItem.Value.ParseInt(90);

                                var rFlow = rsPerformanceFlow2.FirstOrDefault(p => p.PerformanceDeptCode == rDept.Code);
                                if (rFlow != null)
                                {
                                    rFlow.DeptTreeB = ddlDeptTreeB.SelectedItem.Value.ParseInt(60);
                                    rFlow.DeptTreeE = ddlDeptTreeE.SelectedItem.Value.ParseInt(90);
                                }
                            }
                        }
                    }

                    UnobtrusiveSession.Session["rsPerformanceDept"] = rsPerformanceDept2;
                    UnobtrusiveSession.Session["rsPerformanceFlow"] = rsPerformanceFlow2;

                    var rsPerformanceBase2 = UnobtrusiveSession.Session["rsPerformanceBase"] as List<PerformanceBase>;

                    if (rsPerformanceDept2 != null && rsPerformanceBase2 != null && rsPerformanceFlow2 != null)
                    {
                        lblDeptAllCount.Text = rsPerformanceDept2.Count.ToString();
                        lblDeptCount.Text = rsPerformanceBase2.Select(p => p.PerformanceDeptCode).Distinct().ToList().Count.ToString();
                        lblBaseCount.Text = rsPerformanceBase2.Count.ToString();
                        lblFlowCount.Text = rsPerformanceFlow2.Count.ToString();
                    }

                    //gvBase.Rebind();

                    break;

                case "s3":
                    var rsPerformanceDept3 = UnobtrusiveSession.Session["rsPerformanceDept"] as List<PerformanceDept>;
                    var rsPerformanceBase3 = UnobtrusiveSession.Session["rsPerformanceBase"] as List<PerformanceBase>;
                    var rsPerformanceFlow3 = UnobtrusiveSession.Session["rsPerformanceFlow"] as List<PerformanceFlow>;

                    lblDeptAllCount.Text = rsPerformanceDept3.Count.ToString();
                    lblDeptCount.Text = rsPerformanceBase3.Select(p => p.PerformanceDeptCode).Distinct().ToList().Count.ToString();
                    lblBaseCount.Text = rsPerformanceBase3.Count.ToString();
                    lblFlowCount.Text = rsPerformanceFlow3.Count.ToString();

                    break;
            }
        }

        protected void wzMain_FinishButtonClick(object sender, WizardEventArgs e)
        {
            var rsPerformanceDept = UnobtrusiveSession.Session["rsPerformanceDept"] as List<PerformanceDept>;
            var rsPerformanceJob = UnobtrusiveSession.Session["rsPerformanceJob"] as List<PerformanceJob>;
            var rsPerformanceBase = UnobtrusiveSession.Session["rsPerformanceBase"] as List<PerformanceBase>;
            var rsPerformanceBaseLog = UnobtrusiveSession.Session["rsPerformanceBaseLog"] as List<PerformanceBaseLog>;
            var rsPerformanceFlow = UnobtrusiveSession.Session["rsPerformanceFlow"] as List<PerformanceFlow>;
            var rsPerformanceFlowNode = UnobtrusiveSession.Session["rsPerformanceFlowNode"] as List<PerformanceFlowNode>;

            var Code = lblCode.Text;

            var r = new PerformanceMain();
            r.Code = Code;
            r.InsertMan = lblUserCode.Text;
            r.InsertDate = DateTime.Now;
            r.Name = txtName.Text;
            r.ReportName = txtReportName.Text;
            var Year = ddlYear.SelectedItem.Value;
            var Month = ddlMonth.SelectedItem.Value;
            //var Yymm = ddlYymm.SelectedItem.Value;
            var Yymm = Year + Month;
            r.Yymm = Yymm;
            r.Seq = "1";
            r.EmpCategoryCode = ddlEmpCategory.SelectedItem.Value;
            r.TypeCode = ddlType.SelectedItem.Value;
            r.DateA = txtDateA.SelectedDate.Value;
            r.DateD = txtDateD.SelectedDate.Value;
            r.DateBase = txtDateBase.SelectedDate.GetValueOrDefault(r.DateD);
            r.Sort = txtSort.Text.ParseInt(9);
            r.PerformanceRatingCode = ddlRating.SelectedItem.Value;
            r.DeptTreeB = ddlDeptTreeB.SelectedItem.Value.ParseInt(60);
            r.DeptTreeE = ddlDeptTreeE.SelectedItem.Value.ParseInt(90);
            r.Note = txtNote.Text;
            r.UpdateMan = lblUserCode.Text;
            r.UpdateDate = DateTime.Now;
            dcMain.PerformanceMain.InsertOnSubmit(r);

            //因為人數會增加或減少 所以在這裡處理沒有人的部門 且 非經過路徑的部門 全數刪除
            var rsDept = (from c in rsPerformanceDept
                          select new
                          {
                              c.Code,
                              c.ParentCode,
                              HasPeople = rsPerformanceBase.Any(p => p.PerformanceMainCode == Code && p.PerformanceDeptCode == c.Code),    //部門裡有沒有人
                          }).ToList();

            do
            {
                //找出最後一階的部門 且沒有員工在裡面
                var ListDeptCode = rsDept.Where(p => !p.HasPeople).Select(p => p.Code).ToList();

                //如果沒有部門了 就直接離開
                if (ListDeptCode.Count == 0)
                    break;

                var ListDeptParentCode = rsDept.Select(p => p.ParentCode).ToList();

                //取差集 (A有，B沒有)
                var ListDeptCodeExpected = ListDeptCode.Except(ListDeptParentCode).ToList();

                //如果沒有差集了 就直接離開 代表最底下的部門，已經全部把沒人的刪除了
                if (ListDeptCodeExpected.Count == 0)
                    break;

                //刪除差集的部門資料
                foreach (var DeptCodeExpected in ListDeptCodeExpected)
                {
                    //刪除暫存的資料
                    var rDept = rsDept.FirstOrDefault(p => p.Code == DeptCodeExpected);
                    if (rDept != null)
                        rsDept.Remove(rDept);

                    //刪除資料庫的資料
                    var rPerformanceDept = rsPerformanceDept.FirstOrDefault(p => p.Code == DeptCodeExpected);
                    if (rPerformanceDept != null)
                        rsPerformanceDept.Remove(rPerformanceDept);
                }
            } while (true);

            dcMain.PerformanceDept.InsertAllOnSubmit(rsPerformanceDept);
            dcMain.PerformanceJob.InsertAllOnSubmit(rsPerformanceJob);
            dcMain.PerformanceBase.InsertAllOnSubmit(rsPerformanceBase);
            dcMain.PerformanceBaseLog.InsertAllOnSubmit(rsPerformanceBaseLog);
            dcMain.PerformanceFlow.InsertAllOnSubmit(rsPerformanceFlow);
            dcMain.PerformanceFlowNode.InsertAllOnSubmit(rsPerformanceFlowNode);

            var CompCode = "A";

            var rsPerformanceRating = (from c in dcMain.PerformanceRating
                                       where c.CompCode == CompCode
                                       && c.EmpCategoryCode == ddlEmpCategory.SelectedItem.Value
                                       //&& c.Code == RatingCode
                                       select c).ToList();

            if (rsPerformanceRating.Count == 0)
            {
                lblMsg.Text = "無評等資料";
                return;
            }

            var rsPerformanceDeptRating = (from c in dcMain.PerformanceDeptRating
                                           where c.PerformanceMainCode == Code
                                           select c).ToList();

            //為每一個部門增加評等人數
            foreach (var rDept in rsDept)
                foreach (var rPerformanceRating in rsPerformanceRating)
                {
                    var PerformanceDeptCode = rDept.Code;
                    var PerformanceRatingCode = rPerformanceRating.Code;
                    var rPerformanceDeptRating = rsPerformanceDeptRating.FirstOrDefault(p => p.PerformanceDeptCode == PerformanceDeptCode && p.PerformanceRatingCode == PerformanceRatingCode);

                    if (rPerformanceDeptRating == null)
                    {
                        rPerformanceDeptRating = new PerformanceDeptRating();
                        rPerformanceDeptRating.PerformanceMainCode = Code;
                        rPerformanceDeptRating.PerformanceDeptCode = PerformanceDeptCode;
                        rPerformanceDeptRating.PerformanceRatingCode = PerformanceRatingCode;
                        rPerformanceDeptRating.InsertMan = lblUserCode.Text;
                        rPerformanceDeptRating.InsertDate = DateTime.Now;
                        dcMain.PerformanceDeptRating.InsertOnSubmit(rPerformanceDeptRating);
                    }

                    rPerformanceDeptRating.NumPer = rPerformanceRating.NumPer;
                    rPerformanceDeptRating.UpdateMan = lblUserCode.Text;
                    rPerformanceDeptRating.UpdateDate = DateTime.Now;
                }

            dcMain.SubmitChanges();

            Response.Redirect("ManageMain.aspx");
        }

        protected void lvDept_NeedDataSource(object sender, RadListViewNeedDataSourceEventArgs e)
        {
            if (UnobtrusiveSession.Session["rsPerformanceDept"] != null)
            {
                var rsPerformanceDept = UnobtrusiveSession.Session["rsPerformanceDept"] as List<PerformanceDept>;
                var rsPerformanceBase = UnobtrusiveSession.Session["rsPerformanceBase"] as List<PerformanceBase>;

                //只取出此次要參與簽核的部門
                var ListDeptCode = rsPerformanceBase.Select(p => p.PerformanceDeptCode).Distinct().ToList();

                lvDept.DataSource = rsPerformanceDept.Where(p => ListDeptCode.Contains(p.Code)).ToList();
            }
        }

        protected void lvDept_DataBound(object sender, EventArgs e)
        {
            var oPerformance = new PerformanceDao(dcShare, dcMain, dcHr);

            var DeptTree = ddlDeptTreeE.SelectedItem.Value.ParseInt(90);

            //取得部門層級
            //var rsDeptLevel = oMainDao.GetDeptLevel(DeptTree);
            var rsDeptLevel = oPerformance.GetDeptLevel(999);

            var rsDept = UnobtrusiveSession.Session["rsPerformanceDept"] as List<PerformanceDept>;

            foreach (var Item in lvDept.Items)
            {
                var AutoKey = Convert.ToInt32(Item.GetDataKeyValue("AutoKey"));

                var ddlDeptTreeBObj = Item.FindControl("ddlDeptTreeB");
                var ddlDeptTreeEObj = Item.FindControl("ddlDeptTreeE");
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

        protected void lvDept_ItemCommand(object sender, RadListViewCommandEventArgs e)
        {
            string cn = e.CommandName;
            string ca = e.CommandArgument.ToString();
        }


        protected void gvBase_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            if (UnobtrusiveSession.Session["rsPerformanceBase"] != null)
            {
                var rsPerformanceBase = UnobtrusiveSession.Session["rsPerformanceBase"] as List<PerformanceBase>;

                //gvBase.DataSource = rsPerformanceBase;
            }
        }
    }
}