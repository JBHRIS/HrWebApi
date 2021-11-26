using Bll;
using Bll.Base.Vdb;
using Bll.Dept.Vdb;
using Bll.Performance.Vdb;
using Bll.Salary;
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
    public partial class ManageMainWizard_Emc : WebPageBase
    {
        private dcCustomEmcDataContext dcCustom = new dcCustomEmcDataContext();

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
                        SalaryEncrypt se = new SalaryEncrypt();

                        if (dcMain.PerformanceMain.Any(c => c.Yymm == Yymm && c.TypeCode == TypeCode && c.Seq == Seq && c.EmpCategoryCode == EmpCategoryCode))
                        {
                            lblMsg.Text = "資料重複，請重新輸入";
                            wzMain.ActiveStepIndex = 0;
                            return;
                        }

                        var oPerformanceDao = new Dal.Dao.PerformanceDao(dcShare, dcMain, dcHr);

                        //利用員別取出職等代碼
                        var rsJob = (from c in dcHr.ViewJob
                                     select c).ToList();

                        var rsJobl = (from c in dcHr.ViewJobl
                                      select c).ToList();

                        var rsDept = oPerformanceDao.GetDept(DateBase , 999);

                        var rsDepta = oPerformanceDao.GetDepta(DateBase , 999);

                        //以基準日抓出所有員工基本資料
                        //以基準日抓出所有員工基本資料
                        var rsBase = (from b1 in dcHr.ViewEmp
                                      join d in dcHr.ViewDept on b1.DeptCode equals d.Code
                                      join da in dcHr.ViewDepta on b1.DeptmCode equals da.Code
                                      join j in dcHr.ViewJob on b1.JobCode equals j.Code
                                      join jl in dcHr.ViewJobl on b1.JoblCode equals jl.Code
                                      where ((b1.DateA.Date <= DateBase.Date
                                      && DateBase.Date <= b1.DateD.Value.Date)
                                      || (b1.DateA.Date <= DataNow.Date
                                      && DataNow.Date <= b1.DateD.Value.Date))
                                      //&& ListJoblCode.Contains(b1.JOBL)
                                      //&& ListEmpId.Contains(b.NOBR)
                                      select new ViewBaseRow
                                      {
                                          EmpId = b1.Code,
                                          NameC = b1.Name,
                                          NameE = b1.Name,
                                          DateA = b1.DateA.Date,
                                          DateD = b1.DateD.Value.Date,
                                          Ttscode = b1.Ttscode,
                                          Comp = b1.CompCode,
                                          JobCode = b1.JobCode,
                                          JobName = j.Name,
                                          JoblCode = b1.JoblCode,
                                          JoblName = jl.Name,
                                          DeptCode = b1.DeptCode,
                                          DeptName = d.Name,
                                          DeptmCode = b1.DeptmCode,
                                          DeptmName = da.Name,
                                          Email = b1.Email,
                                          WorkCode = "",
                                          WorkName = "",
                                          DateIn = b1.DateIn.GetValueOrDefault(DateTime.Now.Date),
                                      }).ToList();

                        //利用員別取出職等代碼
                        //用料獎金不需要區分工員或職員
                        var ListJoblCode = (from c in rsJobl
                                            where ((TypeCode == "03") ? true : (c.EmpCategoryCode == EmpCategoryCode))
                                            select c.Code).ToList();

                        //var ListEmpId = rsBase.Select(p => p.Nobr).ToList();

                        //考核員工基本資料 計算部門獎金會需要用到 暫存
                        var rsPerformanceBase = new List<PerformanceBase>();

                        var rsPerformanceBaseLog = new List<PerformanceBaseLog>();

                        var oPerformance = new PerformanceDao(dcShare, dcMain, dcHr);

                        //員工異動
                        {
                            //舊的考核資料
                            //月
                            var rsBouns = (from c in dcCustom.BONUS
                                               //join x in dcMain.WriteRuleTable1ByNobr(_UserCode, Comp, true, DateBase.ToShortDateString()) on c.NOBR equals x.NOBR
                                           where c.YYMM == Yymm
                                           //&& ListEmpId.Contains(c.NOBR)
                                           && !c.NOT_REVIEW.GetValueOrDefault(false)
                                           && (TypeCode == "01" || TypeCode == "02")
                                           select new BonusRow
                                           {
                                               EmpId = c.NOBR,
                                               DeptCode = c.DEPT,
                                               BonusCardinal = c.GETBON,    //分配獎金
                                               InWorkSpecific = c.ONBO,//在職比
                                               BonusTotal = c.BONBASE, //獎金基數
                                               BonusAdjust = c.MERIT, //考績加減
                                               Note = c.MEMO,
                                           }).ToList();

                            //季或月
                            var rsEffect = (from c in dcCustom.EFFECT
                                            where c.YYMM == Yymm
                                            && (TypeCode == "01" || TypeCode == "02")
                                            select new
                                            {
                                                EmpId = c.NOBR,
                                                DeptCode = c.DEPT,
                                                WorkPerformance = c.W1,    //工作績效
                                                MannerEsteem = c.W2,   //態度評價
                                                AbilityEsteem = c.W3, //能力評價
                                                Encourage = c.W4,  //激勵
                                                TotalIntegrate = c.W5,//總積分
                                                RatingCode = c.STATE,
                                            }).ToList();

                            //用料
                            var rsGetmertamt = (from c in dcCustom.GETMERTAMT
                                                where c.YYMM == Yymm
                                                && (TypeCode == "03")
                                                select new
                                                {
                                                    EmpId = c.NOBR,
                                                    DeptCode = c.DEPT,
                                                    AvgIntegrate = c.AVGNUM,    //考績平均                                                        
                                                    BonusTotal = c.GETAMT, //可得獎金
                                                    BonusCardinal = c.ENDAMT.GetValueOrDefault(0),   //可給獎金
                                                    BonusAdjust = c.MERIT,  //考績加減
                                                    Note = c.MEMO,
                                                }).ToList();

                            //年
                            var YearInt = Year.ParseInt(0);
                            var rsEffaverage = (from c in dcCustom.EFFAVERAGE
                                                where c.YEAR == YearInt
                                                && (TypeCode == "04")
                                                select new
                                                {
                                                    EmpId = c.NOBR,
                                                    DeptCode = c.DEPT,
                                                    G01 = c.AWARD1,
                                                    G02 = c.AWARD2,
                                                    G03 = c.AWARD3,
                                                    G04 = 0,
                                                    G05 = 0,
                                                    F01 = c.FAULT1,
                                                    F02 = c.FAULT2,
                                                    F03 = c.FAULT3,
                                                    F04 = 0,
                                                    F05 = 0,
                                                    DateIn = c.INDT.Date,
                                                    SumAward = c.SUM_AWARD,
                                                    AvgIntegrate = c.AVERAGE,
                                                    TotalIntegrate = c.TOLAL,
                                                    RatingCode = c.STATE,
                                                }).ToList();

                            //取得來源資料
                            //月或季
                            var rsSource = (from c in dcCustom.BONUS
                                                //join x in dcMain.WriteRuleTable1ByNobr(_UserCode, Comp, true, DateBase.ToShortDateString()) on c.NOBR equals x.NOBR
                                            where c.YYMM == Yymm
                                            //&& ListEmpId.Contains(c.NOBR)
                                            && !c.NOT_REVIEW.GetValueOrDefault(false)
                                            && (TypeCode == "01" || TypeCode == "02")
                                            select new
                                            {
                                                EmpId = c.NOBR,
                                                DeptCode = c.DEPT,
                                            }).ToList();

                            if (rsSource.Count == 0)
                            {
                                //用料獎金
                                rsSource = (from c in dcCustom.GETMERTAMT
                                            where c.YYMM == Yymm
                                            && (TypeCode == "03")
                                            select new
                                            {
                                                EmpId = c.NOBR,
                                                DeptCode = c.DEPT,
                                            }).ToList();

                                if (rsSource.Count == 0)
                                {
                                    //年
                                    rsSource = (from c in dcCustom.EFFAVERAGE
                                                where c.YEAR == YearInt
                                                && (TypeCode == "04")
                                                select new
                                                {
                                                    EmpId = c.NOBR,
                                                    DeptCode = c.DEPT,
                                                }).ToList();
                                }
                            }

                            var CompCode = "A";

                            var rsPerformanceRating = (from c in dcMain.PerformanceRating
                                                       where c.CompCode == CompCode
                                                       && c.EmpCategoryCode == EmpCategoryCode
                                                       //&& c.Code == RatingCode
                                                       select c).ToList();

                            foreach (var rSource in rsSource)
                            {
                                //不包含就踢出去
                                //if (!ListEmpId.Contains(rSource.NOBR))
                                //    continue;

                                //先採用基準日尋找 
                                var rBase = rsBase.FirstOrDefault(p => p.EmpId == rSource.EmpId && (p.DateA.Date <= DateBase.Date && DateBase.Date <= p.DateD));
                                if (rBase == null)
                                {
                                    //採用當前資料
                                    rBase = rsBase.FirstOrDefault(p => p.EmpId == rSource.EmpId);
                                    if (rBase == null)
                                        continue;
                                }

                                //職等必需包含-工職員
                                if (!ListJoblCode.Contains(rBase.JoblCode))
                                    continue;

                                var DeptName = "";
                                var rDept = rsDept.FirstOrDefault(p => p.Code == rSource.DeptCode);
                                if (rDept != null)
                                    DeptName = rDept.Name;

                                //新增：目的資料缺少就是新增
                                {
                                    {
                                        var BonusCardinalTemp = 0m;
                                        var InWorkSpecificTemp = 0m;
                                        var BonusTotalTemp = 0m;
                                        var BonusAdjustTemp = 0m;

                                        //工員或職員的月或季獎金
                                        var rBouns = rsBouns.FirstOrDefault(p => p.EmpId == rSource.EmpId);
                                        if (rBouns != null)
                                        {
                                            BonusCardinalTemp = se.Decode(rBouns.BonusCardinal);   //分配獎金
                                            InWorkSpecificTemp = rBouns.InWorkSpecific; //在職比
                                            BonusTotalTemp = se.Decode(rBouns.BonusTotal); //獎金基數
                                            BonusAdjustTemp = se.Decode(rBouns.BonusAdjust);    //考績加減
                                        }

                                        //用料獎金
                                        var AvgIntegrateTemp = 0m;
                                        var rGetmertamt = rsGetmertamt.FirstOrDefault(p => p.EmpId == rSource.EmpId);
                                        if (rGetmertamt != null)
                                        {
                                            BonusTotalTemp = se.Decode(rGetmertamt.BonusTotal); //可得獎金
                                            BonusCardinalTemp = se.Decode(rGetmertamt.BonusTotal);// se.Decode(rGetmertamt.BonusCardinal);   //可給獎金                                               
                                            BonusAdjustTemp = se.Decode(rGetmertamt.BonusAdjust);    //考績加減
                                            AvgIntegrateTemp = rGetmertamt.AvgIntegrate;
                                        }

                                        var rTarget = new PerformanceBase();
                                        rTarget.PerformanceMainCode = Code;
                                        rTarget.Code = Guid.NewGuid().ToString();
                                        rTarget.EmpId = rSource.EmpId;
                                        rTarget.PerformanceDeptCode = rSource.DeptCode; //這個部門是編制部門 應該是錯的
                                        rTarget.DeptCode = rSource.DeptCode;
                                        rTarget.DeptName = DeptName;
                                        rTarget.WorkPerformance = 0;    //工作績效
                                        rTarget.MannerEsteem = 0;   //態度評價
                                        rTarget.AbilityEsteem = 0;  //能力評價
                                        rTarget.Encourage = 0;  //激勵
                                        rTarget.TotalIntegrate = 0; //總積分
                                        rTarget.RatingCode = RatingCode;    //評等
                                        rTarget.BonusCardinal = BonusCardinal;   //分配獎金
                                        rTarget.InWorkSpecific = InWorkSpecificTemp; //在職比
                                        rTarget.BonusTotal = BonusTotalTemp; //獎金基數
                                        rTarget.BonusDeduct = 0;    //可扣獎金
                                        rTarget.BonusMax = 0;    //最高加發獎金
                                        rTarget.BonusAdjust = BonusAdjustTemp;    //考績加減
                                        rTarget.BonusReal = rTarget.BonusCardinal + rTarget.BonusAdjust;  //實際獎金
                                        rTarget.DateIn = rBase.DateIn;
                                        rTarget.G01 = 0;
                                        rTarget.G02 = 0;
                                        rTarget.G03 = 0;
                                        rTarget.G04 = 0;
                                        rTarget.G05 = 0;
                                        rTarget.F01 = 0;
                                        rTarget.F02 = 0;
                                        rTarget.F03 = 0;
                                        rTarget.F04 = 0;
                                        rTarget.F05 = 0;
                                        rTarget.SumAward = 0;
                                        rTarget.AvgIntegrate = AvgIntegrateTemp;
                                        rTarget.ExceptionBonusAll = false;
                                        rTarget.ExceptionBonus = false;
                                        rTarget.ExceptionNote = false;
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
                                            rTarget.EmpName = rBase.NameC;
                                            rTarget.PerformanceDeptCode = rBase.DeptmCode;    
                                            rTarget.JobCode = rBase.JobCode;
                                            rTarget.JobName = rsJob.FirstOrDefault(p => p.Code == rTarget.JobCode)?.Name ?? "";
                                            rTarget.JoblCode = rBase.JoblCode;
                                            rTarget.JoblName = rsJobl.FirstOrDefault(p => p.Code == rTarget.JoblCode)?.Name ?? "";
                                            rTarget.WorkCode = "";
                                            rTarget.WorkName = "";
                                            rTarget.CompCode = "";
                                        }

                                        //如果是用料獎金 就更改人員的起始部門
                                        if (TypeCode == "03")
                                        {
                                            var DeptCode = oPerformanceDao.GetDeptCode(rsDept, rBase.DeptmCode, DeptTreeB);
                                            if (DeptCode.Length > 0)
                                                rTarget.PerformanceDeptCode = DeptCode;
                                        }

                                        var rEffect = rsEffect.FirstOrDefault(p => p.EmpId == rTarget.EmpId);
                                        if (rEffect != null)
                                        {
                                            rTarget.WorkPerformance = rEffect.WorkPerformance;    //工作績效
                                            rTarget.MannerEsteem = rEffect.MannerEsteem;   //態度評價
                                            rTarget.AbilityEsteem = rEffect.AbilityEsteem;  //能力評價
                                            rTarget.Encourage = rEffect.Encourage;  //激勵
                                            rTarget.TotalIntegrate = rEffect.TotalIntegrate; //總積分

                                            switch (rEffect.RatingCode)
                                            {
                                                case "甲":
                                                    rTarget.RatingCode = "01";
                                                    break;
                                                case "乙":
                                                    rTarget.RatingCode = "02";
                                                    break;
                                                case "丙":
                                                    rTarget.RatingCode = "03";
                                                    break;
                                            }
                                        }

                                        var rEffaverage = rsEffaverage.FirstOrDefault(p => p.EmpId == rTarget.EmpId);
                                        if (rEffaverage != null)
                                        {
                                            rTarget.G01 = rEffaverage.G01;
                                            rTarget.G02 = rEffaverage.G02;
                                            rTarget.G03 = rEffaverage.G03;
                                            rTarget.G04 = rEffaverage.G04;
                                            rTarget.G05 = rEffaverage.G05;
                                            rTarget.F01 = rEffaverage.F01;
                                            rTarget.F02 = rEffaverage.F02;
                                            rTarget.F03 = rEffaverage.F03;
                                            rTarget.F04 = rEffaverage.F04;
                                            rTarget.F05 = rEffaverage.F05;
                                            rTarget.DateIn = rEffaverage.DateIn;
                                            rTarget.SumAward = rEffaverage.SumAward;
                                            rTarget.AvgIntegrate = rEffaverage.AvgIntegrate;
                                            rTarget.TotalIntegrate = rEffaverage.TotalIntegrate;

                                            switch (rEffaverage.RatingCode)
                                            {
                                                case "甲":
                                                    rTarget.RatingCode = "01";
                                                    break;
                                                case "乙":
                                                    rTarget.RatingCode = "02";
                                                    break;
                                                case "丙":
                                                    rTarget.RatingCode = "03";
                                                    break;
                                            }
                                        }

                                        //計算評等最高及可扣獎金
                                        var rPerformanceRating = rsPerformanceRating.FirstOrDefault(p => p.Code == rTarget.RatingCode);
                                        if (rPerformanceRating != null)
                                        {
                                            rTarget.BonusDeduct = oPerformanceDao.CalculationBonusDeduct(rTarget.BonusCardinal, rPerformanceRating.BonusPerMin);    //可扣獎金
                                            rTarget.BonusMax = oPerformanceDao.CalculationBonusMax(rTarget.BonusCardinal, rPerformanceRating.BonusPerMax);  //最高加發獎金
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
                            var rsSource = rsDepta;

                            foreach (var rSource in rsSource)
                            {
                                //必須比最大部門小才會寫入 20201103改成全數產生
                                //if (rSource.DeptTree <= DeptTreeE)
                                {
                                    {
                                        var BonusCardinalTemp = 0m;

                                        //準備計算獎金在部門的總和
                                        var rsPerformanceBaseByDept = rsPerformanceBase.Where(p => p.PerformanceDeptCode == rSource.Code).ToList();
                                        BonusCardinalTemp = rsPerformanceBaseByDept.Sum(p => p.BonusCardinal);

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
                                        rTarget.BonusMax = BonusCardinalTemp;
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

                                        //先採用基準日尋找 
                                        var rBase = rsBase.FirstOrDefault(p => p.EmpId == rSource.ManagerId && (p.DateA.Date <= DateBase.Date && DateBase.Date <= p.DateD));
                                        if (rBase == null)
                                        {
                                            //採用當前資料
                                            rBase = rsBase.FirstOrDefault(p => p.EmpId == rSource.ManagerId);
                                        }
                                        if (rBase != null)
                                        {
                                            rTarget.ManagerName = rBase.NameC;
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

                        UnobtrusiveSession.Session["rsBase"] = rsBase;

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
            var oPerformanceDao = new Dal.Dao.PerformanceDao(dcShare, dcMain, dcHr);

            var rsBase = UnobtrusiveSession.Session["rsBase"] as List<ViewBaseRow>;

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

            //如果是用料獎金 就更改人員的起始部門
            if (ddlType.SelectedItem.Value == "03")
            {
                var rsDept1 = oPerformanceDao.GetDepta(r.DateBase, 99);
                foreach (var rPerformanceBase in rsPerformanceBase)
                {
                    var EmpId = rPerformanceBase.EmpId;

                    //先採用基準日尋找 
                    var rBase = rsBase.FirstOrDefault(p => p.EmpId == EmpId && (p.DateA.Date <= r.DateBase && r.DateBase <= p.DateD));
                    if (rBase == null)
                    {
                        //採用當前資料
                        rBase = rsBase.FirstOrDefault(p => p.EmpId == EmpId);
                        if (rBase == null)
                            continue;
                    }

                    var DeptCode = rBase.DeptmCode;
                    var rDept = rsPerformanceDept.FirstOrDefault(p => p.Code == DeptCode);
                    if (rDept != null)
                    {
                        //只有與原本設定不同才需要置換
                        var DeptTreeB = rDept.DeptTreeB;
                        if (r.DeptTreeB != DeptTreeB)
                        {
                            DeptCode = oPerformanceDao.GetDeptCode(rsDept1, DeptCode, DeptTreeB);
                            if (DeptCode.Length > 0)
                                rPerformanceBase.PerformanceDeptCode = DeptCode;
                        }
                    }
                }
            }

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