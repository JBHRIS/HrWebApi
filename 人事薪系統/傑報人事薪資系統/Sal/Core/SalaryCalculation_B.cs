using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using JBModule.Data.Linq;
using System.Reflection;
using JBModule.Data.Repo;

namespace JBHR.Sal.Core
{
    public class SalaryCalculation_B : JBModule.Message.ReportStatus
    {
        string YYMM;
        string SEQ;
        string SEQ2;
        string NOBR_B;
        string NOBR_E;
        string DEPT_B;
        string DEPT_E;
        string Type;
        DateTime DATE_B;
        DateTime DATE_E;
        DateTime ATT_DATE_B;
        DateTime ATT_DATE_E;
        DateTime TRANS_DATE;
        DateTime InEDate;
        string SALADR;
        public bool ProcSuper = false;
        public bool MangSuper = false;
        bool Prev = false;
        SalaryDate SalDate;
        JBModule.Data.Linq.HrDBDataContext smd = new JBModule.Data.Linq.HrDBDataContext();
        JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
        //public List<JBHR.Sal.WAGED> wagedList_A;
        public List<JBModule.Data.Linq.WAGED_B> wagedList;
        IQueryable<string> nobrList;
        Dictionary<string, decimal> WorkDaysList;
        public List<JBModule.Data.Linq.WAGE_B> wageList;
        List<JBModule.Data.Linq.SALCODE> salcodeList;
        public BackgroundWorker BW;
        public JBModule.Data.ApplicationConfigSettings AppConfig = null;
        public JBModule.Data.ApplicationConfigSettings OtAppConfig = null;
        public JBModule.Data.ApplicationConfigSettings FRM4IConfig = null;


        public bool isReExpsup = false;
        public SalaryCalculation_B(string yymm, string seq, string seq2, string nobr_b, string nobr_e, string dept_b, string dept_e,
            DateTime date_b, DateTime date_e, DateTime AttDateB, DateTime AttDateE, DateTime TransDate, string SalAdr,
            bool MangSuper, bool ProcSuper, string SalType, bool prev, DateTime InEDate)
        {
            this.YYMM = yymm;
            this.SEQ = seq;
            this.SEQ2 = seq2;
            this.NOBR_B = nobr_b;
            this.NOBR_E = nobr_e;
            this.DEPT_B = dept_b;
            this.DEPT_E = dept_e;
            this.DATE_B = date_b;
            this.DATE_E = date_e;
            this.ATT_DATE_B = AttDateB;
            this.ATT_DATE_E = AttDateE;
            this.TRANS_DATE = TransDate;
            this.SALADR = SalAdr;
            this.MangSuper = MangSuper;
            this.ProcSuper = ProcSuper;
            this.Type = SalType;
            this.Prev = prev;
            this.InEDate = InEDate;
            SalDate = new SalaryDate(yymm);
            wagedList = new List<JBModule.Data.Linq.WAGED_B>();
            db = new JBModule.Data.Linq.HrDBDataContext();
            smd = new JBModule.Data.Linq.HrDBDataContext();
            db.Connection.ConnectionString = U_LOGIN.ConnectionString;
            smd.Connection.ConnectionString = U_LOGIN.ConnectionString;

            var basettsSQL = from a in smd.BASETTS
                             join b in smd.DEPT on a.DEPT equals b.D_NO
                             where a.NOBR.CompareTo(nobr_b) >= 0 && a.NOBR.CompareTo(nobr_e) <= 0
                             && b.D_NO_DISP.CompareTo(dept_b) >= 0 && b.D_NO_DISP.CompareTo(dept_e) <= 0
                             select a;
            if (!ProcSuper) basettsSQL = from a in basettsSQL where a.SALADR == SalAdr select a;
            nobrList = from row in basettsSQL select row.NOBR;
            salcodeList = db.SALCODE.ToList();
            WorkDaysList = new Dictionary<string, decimal>();
            //TaxRateList = new Dictionary<string, decimal>();
        }
        public void Calc(bool CalcTeco, bool CreateAbs, bool CalcAbs, bool CalcOt)
        {
            setProgress(0, "初始化");
            WorkDaysList = new Dictionary<string, decimal>();
            //wagedList = new List<JBModule.Data.Linq.WAGED_B>();
            wageList = new List<JBModule.Data.Linq.WAGE_B>();
            db = new JBModule.Data.Linq.HrDBDataContext();
            smd = new JBModule.Data.Linq.HrDBDataContext();
            db.Connection.ConnectionString = U_LOGIN.ConnectionString;
            smd.Connection.ConnectionString = U_LOGIN.ConnectionString;
            FRM4IConfig = new JBModule.Data.ApplicationConfigSettings("FRM4I", MainForm.COMPANY);

            setProgress(0, "清除資料");
            DeleteAll();
            //setProgress(0, "轉入薪資結果");
            //ImportWagedToB();
            setProgress(0, "匯入變動薪資");
            SalbastdCalc1();

            setProgress(0, "匯入補扣發");
            ImportEnrich();

            if (CalcOt)
            {
                setProgress(0, "轉換加班資料");
                TransOT();
                CheckLabourRule();
                setProgress(0, "計算加班費");
                OtCalculation_B otCalc = new OtCalculation_B(NOBR_B, NOBR_E, DEPT_B, DEPT_E, YYMM, SEQ);
                otCalc.OtData = OvertimeBList;
                otCalc.WagedList = wagedList;
                otCalc.StatusChanged += new JBModule.Message.ReportStatus.StatusChangedEvent(Calc_StatusChanged);
                otCalc.Run();
            }

            setProgress(0, "匯入加班費");
            ImportOt();

            setProgress(0, "計算所得稅");
            TaxCalc(true);

            setProgress(0, "產生薪資主檔");
            CreateWage();

            setProgress(0, "置換期別");
            ChangeSeq();

            setProgress(0, "寫入資料庫");
            WriteToDB();

            setProgress(100, "完成");
        }


        void setProgress(int percent, object state)
        {
            //if (BW != null)
            //{
            //    BW.ReportProgress(percent, state);
            //}
        }
        void Calc_StatusChanged(object sender, JBModule.Message.StatusEventArgs e)
        {
            //BW.ReportProgress(e.Percent, e.Result);
        }
        public void ImportWagedToB(List<WAGED> wagedOriginalList)
        {
            List<string> SkipSalcodeList = new List<string>();
            SkipSalcodeList.Add(MainForm.OvertimeConfig.NOTAXSALCODE);
            SkipSalcodeList.Add(MainForm.OvertimeConfig.TOTAXSALCODE);
            SkipSalcodeList.Add(MainForm.TaxConfig.TAXSALCODE);
            SkipSalcodeList.AddRange(db.SALCODE.Where(p => p.ImportSEQ2).Select(p => p.SAL_CODE).ToList());
            var sql = wagedOriginalList.Where(p => !SkipSalcodeList.Contains(p.SAL_CODE));
            foreach (var it in sql)
            {
                wagedList.Add(new JBModule.Data.Linq.WAGED_B
                {
                    AMT = it.AMT,
                    SAL_CODE = it.SAL_CODE,
                    NOBR = it.NOBR,
                    SEQ = it.SEQ,
                    YYMM = it.YYMM,
                });
            }

        }
        public void SalbastdCalc1()
        {
            List<string> SkipSalcodeList = new List<string>();
            SkipSalcodeList.Add(MainForm.OvertimeConfig.NOTAXSALCODE);
            SkipSalcodeList.Add(MainForm.OvertimeConfig.TOTAXSALCODE);
            SkipSalcodeList.Add(MainForm.TaxConfig.TAXSALCODE);
            List<string> ttscodeList = new List<string>();
            ttscodeList.Add("1");
            ttscodeList.Add("4");
            ttscodeList.Add("6");
            var EmpList_full = (from a in smd.BASETTS
                                join b in smd.BASETTS on a.NOBR equals b.NOBR
                                join e in smd.DEPT on b.DEPT equals e.D_NO
                                //join wrnt in smd.WriteRuleNobrTable.Where(p => p.GUID == guid) on b.NOBR equals wrnt.EMPID																						
                                where ttscodeList.Contains(a.TTSCODE)
                                && a.NOBR.CompareTo(NOBR_B) >= 0 && a.NOBR.CompareTo(NOBR_E) <= 0
                                && e.D_NO_DISP.CompareTo(DEPT_B) >= 0 && e.D_NO_DISP.CompareTo(DEPT_E) <= 0
                                //&& smd.GetFilterByNobr(a.NOBR, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value
                                && DATE_B <= a.DDATE.Value && DATE_E >= a.ADATE
                                && DATE_E >= b.ADATE && DATE_E <= b.DDATE.Value
                                && !b.NOWAGE//須計算薪資
                                && b.INDT <= InEDate
                                && smd.UserReadDataGroupList(MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Select(p => p.DATAGROUP).Contains(a.SALADR)
                                select new { a.NOBR, a.ADATE, a.DDATE }).ToList();
            var EmpList = EmpList_full.GroupBy(p => p.NOBR);
            var salbasdList = (from a in db.SALBASTD
                               join b in db.BASETTS on a.NOBR equals b.NOBR
                               join c in db.SALCODE on a.SAL_CODE equals c.SAL_CODE
                               join e in db.DEPT on b.DEPT equals e.D_NO
                               //join wrnt in db.WriteRuleNobrTable.Where(p => p.GUID == guid) on a.NOBR equals wrnt.EMPID																						
                               where a.NOBR.CompareTo(NOBR_B) >= 0 && a.NOBR.CompareTo(NOBR_E) <= 0
                               && e.D_NO_DISP.CompareTo(DEPT_B) >= 0 && e.D_NO_DISP.CompareTo(DEPT_E) <= 0
                               && DATE_E >= b.ADATE && DATE_E <= b.DDATE.Value
                               //&& c.SOS_ID == "1"
                               //&& a.SAL_CODE != MainForm.SalaryConfig.ATTAWARDSALCODE
                               //&& !c.NOTFREQ
                               && a.ADATE <= DATE_E && a.DDATE >= DATE_B
                               && b.INDT <= InEDate
                               && SkipSalcodeList.Contains(a.SAL_CODE)
                               //&& db.GetFilterByNobr(a.NOBR, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value
                               && db.UserReadDataGroupList(MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Select(p => p.DATAGROUP).Contains(b.SALADR)
                               select new { a.NOBR, a.ADATE, a.DDATE, a.SAL_CODE, a.AMT, c.MONTHTYPE, c.CAL_FREQ }).ToList();

            var yearrestList = new List<string>();
            yearrestList.Add("1");
            yearrestList.Add("3");
            yearrestList.Add("5");
            yearrestList.Add("7");
            yearrestList.Add("9");
            int counts = EmpList.Count();
            SalaryDate sd = new SalaryDate(YYMM);
            decimal monthDays = Convert.ToInt32((sd.LastDayOfSalary - sd.FirstDayOfSalary).TotalDays) + 1;
            foreach (var EmpData in EmpList)//所以需要計算薪資的工號
            {
                var basettsList = EmpData;
                var salbasdOfNobr = salbasdList.Where(p => p.NOBR == EmpData.Key);
                decimal Workdays = basettsList.Sum(row =>
                       Function.RangeMix(row.ADATE, row.DDATE.Value, DATE_B, DATE_E));//在職給薪天數
                //WorkDaysList.Add(EmpData.Key, Workdays);
                //異動資料在計算區間內的天數
                foreach (var salbasdRow in salbasdOfNobr)
                {
                    DateTime ADATE, DDATE;//有效的區間
                    ADATE = Function.MaxValueB(salbasdRow.ADATE, DATE_B);
                    DDATE = Function.MinValueE(salbasdRow.DDATE, DATE_E);
                    decimal Adays = basettsList.Sum(row =>
                        Function.RangeMix(row.ADATE, row.DDATE.Value, ADATE, DDATE));//在職給薪天數
                    bool FullWork = (Adays == monthDays);//是否整月在值    
                    decimal amt = 0;
                    var AvailableDays = Adays;//有效天數;
                    //var AttDataOfNobr = attSQL.Where(p => p.NOBR == EmpData.Key && p.ADATE >= salbasdRow.ADATE.Date && p.ADATE <= salbasdRow.DDATE.Date);
                    decimal salary = JBModule.Data.CDecryp.Number(salbasdRow.AMT);
                    //decimal WorkHrs = AttDataOfNobr.Sum(p => p.ATT_HRS);
                    BaseSalary_Core bc = new BaseSalary_Core();
                    bc.MonthDays = monthDays;
                    bc.OnJobDays = AvailableDays;

                    if (FullWork)//整月在職
                    {
                        bc.MonthType = "2";//整月在職直接用預設(月曆天)
                        bc.CalcUnit = salbasdRow.CAL_FREQ;
                        amt = bc.CalculationRule(salary);

                        var datas = wagedList.Where(p => p.NOBR == EmpData.Key && p.SAL_CODE == salbasdRow.SAL_CODE);
                        if (datas.Any() && salbasdRow.CAL_FREQ == "1" && salbasdRow.ADATE.Date <= DATE_B && salbasdRow.DDATE.Date >= DATE_E)//如果已經有資料(只算月薪)
                        {
                            amt = Math.Round(amt, MidpointRounding.AwayFromZero);
                            var currentAmt = datas.Sum(p => JBModule.Data.CDecryp.Number(p.AMT));
                            if (amt + currentAmt > JBModule.Data.CDecryp.Number(salbasdRow.AMT))
                                amt = JBModule.Data.CDecryp.Number(salbasdRow.AMT) - currentAmt;//避免四捨五入超出
                            else if (JBModule.Data.CDecryp.Number(salbasdRow.AMT) - (amt + currentAmt) == 1)//差一塊
                            {
                                amt = JBModule.Data.CDecryp.Number(salbasdRow.AMT) - currentAmt;
                            }
                        }
                    }
                    else//破月
                    {
                        bc.MonthType = salbasdRow.MONTHTYPE;
                        bc.CalcUnit = salbasdRow.CAL_FREQ;
                        amt = bc.CalculationRule(salary);
                        if (bc.MonthType == "1")
                            amt = salary;
                    }

                    decimal amt45 = Math.Round(amt, MidpointRounding.AwayFromZero);
                    WAGED_B waged = new WAGED_B();
                    waged.AMT = JBModule.Data.CEncrypt.Number(amt45);
                    waged.NOBR = salbasdRow.NOBR;
                    waged.SAL_CODE = salbasdRow.SAL_CODE;
                    waged.SEQ = SEQ;
                    waged.YYMM = YYMM;
                    InsertWaged(waged);
                }
            }
        }

        public void ImportEnrich()
        {
            List<string> SkipSalcodeList = new List<string>();
            SkipSalcodeList.Add(MainForm.OvertimeConfig.NOTAXSALCODE);
            SkipSalcodeList.Add(MainForm.OvertimeConfig.TOTAXSALCODE);
            SkipSalcodeList.Add(MainForm.TaxConfig.TAXSALCODE);
            var enrich = from rowEnrich in smd.ENRICH
                         join basetts in smd.BASETTS on rowEnrich.NOBR equals basetts.NOBR
                         join a in smd.DEPT on basetts.DEPT equals a.D_NO
                         //join wrnt in smd.WriteRuleNobrTable.Where(p => p.GUID == guid) on rowEnrich.NOBR equals wrnt.EMPID																								   
                         where rowEnrich.YYMM == this.YYMM && rowEnrich.SEQ == SEQ
                         && rowEnrich.NOBR.Trim().CompareTo(NOBR_B.Trim()) >= 0 && rowEnrich.NOBR.Trim().CompareTo(NOBR_E.Trim()) <= 0
                         && a.D_NO_DISP.Trim().CompareTo(DEPT_B.Trim()) >= 0 && a.D_NO_DISP.Trim().CompareTo(DEPT_E.Trim()) <= 0
                         && DATE_E >= basetts.ADATE && DATE_E <= basetts.DDATE.Value
                         && SkipSalcodeList.Contains(rowEnrich.SAL_CODE)
                         && smd.UserReadDataGroupList(MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Select(p => p.DATAGROUP).Contains(basetts.SALADR)
                         select rowEnrich;
            foreach (var row in enrich)
            {
                WAGED_B waged = new WAGED_B();
                waged.AMT = row.AMT;
                if (waged.AMT == 0) waged.AMT = 10;
                waged.NOBR = row.NOBR;
                waged.SAL_CODE = row.SAL_CODE;
                waged.SEQ = this.SEQ;
                waged.YYMM = this.YYMM;
                InsertWaged(waged);
            }
        }

        public List<JBModule.Data.Linq.OT_B> OvertimeBList = new List<JBModule.Data.Linq.OT_B>();
        void TransOT()
        {
            var otData = (from ot in db.OT_Simple
                          join basetts in db.BASETTS on ot.NOBR equals basetts.NOBR
                          join b in db.DEPT on basetts.DEPT equals b.D_NO
                          where ot.YYMM == this.YYMM
                          && ot.BDATE.CompareTo(basetts.ADATE) >= 0 && ot.BDATE.CompareTo(basetts.DDATE.Value) <= 0
                          && basetts.NOBR.CompareTo(NOBR_B) >= 0 && basetts.NOBR.CompareTo(NOBR_E) <= 0
                          && b.D_NO_DISP.CompareTo(DEPT_B) >= 0 && b.D_NO_DISP.CompareTo(DEPT_E) <= 0
                          //&& db.GetFilterByNobr(ot.NOBR, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value
                          && db.UserReadDataGroupList(MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Select(p => p.DATAGROUP).Contains(basetts.SALADR)
                          select ot).ToList();
            var otGroup = otData.GroupBy(p => p.NOBR);
            foreach (var otOfEmp in otGroup)
            {
                JBModule.Data.Repo.LabourInspectionRuleCondition cond = new JBModule.Data.Repo.LabourInspectionRuleCondition
                {
                    SourceOT = otOfEmp.ToList(),
                };
                JBModule.Data.Repo.LabourInspectionRuleRepo labRepo = new JBModule.Data.Repo.LabourInspectionRuleRepo(cond);
                var OtB_Data = labRepo.ConvertOtToOtB(cond.SourceOT);
                var results = labRepo.CheckOtLabourInspectionRule(OtB_Data);
                OvertimeBList.AddRange(results);
            }
        }
        void CheckLabourRule()
        {
            JBModule.Data.Repo.LabourInspectionRuleCondition cond = new JBModule.Data.Repo.LabourInspectionRuleCondition();
            cond.Parameters = new Dictionary<string, object>();
            cond.Parameters.Add("MonthlyOvertimeMaxHours", MainForm.OvertimeConfig.MALEMAXHRS.Value);
            cond.Parameters.Add("PersonMaxOT_hrs", FRM4IConfig.GetConfig("PersonMaxOT_hrs").GetString());
            cond.Parameters.Add("Ddate", DATE_E);
            var ParamsList = db.AppConfig.Where(p => p.Category == "CheckLabourRuleParams").Select(p => new { p.Code, p.Value }).ToList();
            //cond.Parameters.Add("HolidayList", "00, 0X");
            //cond.Parameters.Add("RemoveRoteList", "00, 0X, 0Z");
            //cond.Parameters.Add("DaylyMaxOT_hrs", "2");
            //cond.Parameters.Add("HolidayMaxWK_hrs", "8");
            foreach (var Parameter in ParamsList)
                cond.Parameters.Add(Parameter.Code, Parameter.Value);

            var moduleList = db.AppConfig.Where(p => p.Category == "CheckLabourRule").OrderBy(p=> p.Sort);

            foreach (var module in moduleList)
            {
                var sourceDir = string.IsNullOrWhiteSpace(module.DataSource) ? AppDomain.CurrentDomain.BaseDirectory : module.DataSource;
                var asmConcrete = Assembly.LoadFrom(sourceDir + module.DataType);
                var typeClass = asmConcrete.GetType(module.Value);
                var instance = asmConcrete.CreateInstance(module.Value) as ILabourCheckRule;
                cond.CheckRuleList.Add(instance);
            }
            JBModule.Data.Repo.LabourInspectionRuleRepo laborRepo = new JBModule.Data.Repo.LabourInspectionRuleRepo(cond);
            OvertimeBList = laborRepo.CheckOtLabourInspectionRule(OvertimeBList);
            
        }

        void ImportOt()
        {
            string no_tax = MainForm.OvertimeConfig.NOTAXSALCODE;
            string tax = MainForm.OvertimeConfig.TOTAXSALCODE;
            string night = OtAppConfig.GetConfig("OtBonusSalode").GetString("");
            string food = MainForm.SalaryConfig.EATSALCODE;
            string car = "B07";
            string NoTaxAwardCD = OtAppConfig.GetConfig("OtNoTaxAwardSalode").GetString("");
            string TaxAwardCD = OtAppConfig.GetConfig("OtTaxAwardSalode").GetString("");

            var ot = OvertimeBList;
            foreach (var row in ot)
            {
                var waged = new JBModule.Data.Linq.WAGED_B();
                waged.AMT = row.NOT_EXP;
                waged.NOBR = row.NOBR;
                waged.SAL_CODE = no_tax;
                waged.SEQ = this.SEQ;
                waged.YYMM = this.YYMM;
                if (waged.AMT > 10)//大於0
                    InsertWaged(waged, true);

                waged = new JBModule.Data.Linq.WAGED_B();
                waged.AMT = row.TOT_EXP;
                waged.NOBR = row.NOBR;
                waged.SAL_CODE = tax;
                waged.SEQ = this.SEQ;
                waged.YYMM = this.YYMM;
                if (waged.AMT > 10)//大於0
                    InsertWaged(waged, true);

                waged = new JBModule.Data.Linq.WAGED_B();
                waged.AMT = row.OT_FOOD;
                waged.NOBR = row.NOBR;
                waged.SAL_CODE = night;
                waged.SEQ = this.SEQ;
                waged.YYMM = this.YYMM;
                if (waged.AMT > 10)//大於0
                    InsertWaged(waged, true);

                waged = new JBModule.Data.Linq.WAGED_B();
                waged.AMT = JBModule.Data.CEncrypt.Number(row.OT_FOOD1);
                waged.NOBR = row.NOBR;
                waged.SAL_CODE = food;
                waged.SEQ = this.SEQ;
                waged.YYMM = this.YYMM;
                if (waged.AMT > 10)//大於0
                    InsertWaged(waged, true);

                waged = new JBModule.Data.Linq.WAGED_B();
                waged.AMT = row.OT_FOODH;
                waged.NOBR = row.NOBR;
                waged.SAL_CODE = NoTaxAwardCD;
                waged.SEQ = this.SEQ;
                waged.YYMM = this.YYMM;
                if (waged.AMT > 10)//大於0
                    InsertWaged(waged, true);

                waged = new JBModule.Data.Linq.WAGED_B();
                waged.AMT = row.OT_FOODH1;
                waged.NOBR = row.NOBR;
                waged.SAL_CODE = TaxAwardCD;
                waged.SEQ = this.SEQ;
                waged.YYMM = this.YYMM;
                if (waged.AMT > 10)//大於0
                    InsertWaged(waged, true);

                waged = new JBModule.Data.Linq.WAGED_B();
                waged.AMT = row.OT_CAR;
                waged.NOBR = row.NOBR;
                waged.SAL_CODE = car;
                waged.SEQ = this.SEQ;
                waged.YYMM = this.YYMM;
                if (waged.AMT > 10)//大於0
                    InsertWaged(waged, true);
            }
        }
        void InsertWaged(JBModule.Data.Linq.WAGED_B waged)
        {
            if (waged.AMT == 10)//如果金額是0就略過
                return;
            //waged.SALADR = GetSaladr(waged);
            var ExistWagedOfNobr = (from rWaged in wagedList where rWaged.NOBR.Trim() == waged.NOBR.Trim() && rWaged.SAL_CODE.Trim() == waged.SAL_CODE.Trim() select rWaged).FirstOrDefault();
            //如果是已存在的科目就累加，否則就新增
            if (ExistWagedOfNobr != null) ExistWagedOfNobr.AMT =
                JBModule.Data.CEncrypt.Number(JBModule.Data.CDecryp.Number(ExistWagedOfNobr.AMT)
                + JBModule.Data.CDecryp.Number(waged.AMT));
            else wagedList.Add(waged);
        }
        Dictionary<string, List<EmpOtrateCode>> saladrDictionary = new Dictionary<string, List<EmpOtrateCode>>();
        //string GetSaladr(JBModule.Data.Linq.WAGED_B waged)
        //{
        //    if (waged.SALADR != null)
        //    {
        //        return waged.SALADR;
        //    }
        //    else
        //    {
        //        if (!saladrDictionary.ContainsKey(waged.NOBR))
        //        {
        //            JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
        //            saladrDictionary.Add(waged.NOBR, db.BASETTS.Where(p => p.NOBR == waged.NOBR).Select(p => new EmpOtrateCode { DateBegin = p.ADATE, DateEnd = p.DDATE.Value, EmployeeId = p.NOBR, OtRateCode = p.SALADR }).ToList());
        //        }
        //        var empOtRateList = saladrDictionary[waged.NOBR];
        //        var empOtRate = empOtRateList.SingleOrDefault(p => DATE_E >= p.DateBegin && DATE_E <= p.DateEnd);
        //        return empOtRate.OtRateCode;
        //    }
        //}
        void InsertWaged(JBModule.Data.Linq.WAGED_B waged, bool Max)
        {
            if (waged.AMT == 10)//如果金額是0就略過
                return;
            //waged.SALADR = GetSaladr(waged);
            var salcodeRows = from a in salcodeList where a.SAL_CODE == waged.SAL_CODE select a;
            if (!salcodeRows.Any()) return;//沒有代碼就略過
            var salcodeRow = salcodeRows.First();
            if (salcodeRow.MAX_AMT <= 0 || !Max || waged.SAL_CODE == MainForm.SalaryConfig.FOODSALCODE)
            {
                InsertWaged(waged);
                return;
            }

            var ExistWagedOfNobr = (from rWaged in wagedList where rWaged.NOBR.Trim() == waged.NOBR.Trim() && rWaged.SAL_CODE.Trim() == waged.SAL_CODE.Trim() select rWaged).FirstOrDefault();
            //如果是已存在的科目就累加，否則就新增
            if (ExistWagedOfNobr != null)
            {
                ExistWagedOfNobr.AMT =
                   JBModule.Data.CEncrypt.Number(JBModule.Data.CDecryp.Number(ExistWagedOfNobr.AMT)
                   + JBModule.Data.CDecryp.Number(waged.AMT));
                if (JBModule.Data.CDecryp.Number(ExistWagedOfNobr.AMT) > salcodeRow.MAX_AMT)
                {
                    if (waged.SAL_CODE == MainForm.SalaryConfig.FOODSALCODE)//如果是伙食津貼，多餘的部分入到應稅伙食
                    {
                        var foodSalcode = AppConfig.GetConfig("FoodTaxableSalode").GetString("");
                        if (foodSalcode.Trim().Length > 0)
                        {
                            var overAmt = JBModule.Data.CDecryp.Number(waged.AMT) - salcodeRow.MAX_AMT;
                            JBModule.Data.Linq.WAGED_B wagedOver = new JBModule.Data.Linq.WAGED_B();
                            wagedOver.AMT = JBModule.Data.CEncrypt.Number(overAmt);
                            wagedOver.NOBR = waged.NOBR;
                            wagedOver.SAL_CODE = foodSalcode;
                            wagedOver.SEQ = SEQ;
                            wagedOver.YYMM = YYMM;
                            InsertWaged(wagedOver);
                        }
                    }
                    ExistWagedOfNobr.AMT = JBModule.Data.CEncrypt.Number(salcodeRow.MAX_AMT);
                }
            }
            else
            {
                if (JBModule.Data.CDecryp.Number(waged.AMT) > salcodeRow.MAX_AMT)
                {
                    if (waged.SAL_CODE == MainForm.SalaryConfig.FOODSALCODE)//如果是伙食津貼，多餘的部分入到應稅伙食
                    {
                        var foodSalcode = AppConfig.GetConfig("FoodTaxableSalode").GetString("");
                        if (foodSalcode.Trim().Length > 0)
                        {
                            var overAmt = JBModule.Data.CDecryp.Number(waged.AMT) - salcodeRow.MAX_AMT;
                            JBModule.Data.Linq.WAGED_B wagedOver = new JBModule.Data.Linq.WAGED_B();
                            wagedOver.AMT = JBModule.Data.CEncrypt.Number(overAmt);
                            wagedOver.NOBR = waged.NOBR;
                            wagedOver.SAL_CODE = foodSalcode;
                            wagedOver.SEQ = SEQ;
                            wagedOver.YYMM = YYMM;
                            InsertWaged(wagedOver);
                        }
                    }
                    waged.AMT = JBModule.Data.CEncrypt.Number(salcodeRow.MAX_AMT);
                }
                wagedList.Add(waged);
            }
        }
        public void DeleteAll()
        {
            DeleteWage();
            DeleteWaged();
            DeleteOT_B(YYMM, NOBR_B, NOBR_E, DEPT_B, DEPT_E, DATE_B, DATE_E);
        }
        void DeleteOT_B(string yymm, string nobr_b, string nobr_e, string dept_b, string dept_e, DateTime date_b, DateTime date_e)
        {
            JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
            SalaryDate sd = new SalaryDate(yymm);
            //string DeleteSystemCreateCmd = "DELETE ABS WHERE ABS.NOBR BETWEEN {0} AND {1} AND EXISTS(SELECT * FROM BASETTS A WHERE A.NOBR=ABS.NOBR AND {5} BETWEEN A.ADATE AND A.DDATE AND A.DEPT BETWEEN {2} AND {3}) AND SYSCREATE1=1 AND ABS.BDATE BETWEEN {4} AND {5}"
            //    + " AND dbo.GetFilterByNobr(SALABS.NOBR,{6},{7},{8})=1";
            //this.Report(100, "正在執行..刪除自動產生的請假資料");
            //int i = db.ExecuteCommand(DeleteSystemCreateCmd, new object[] { nobr_b, nobr_e, dept_b, dept_e, date_b, date_e, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN });

            object[] parms = new object[] { nobr_b, nobr_e, dept_b, dept_e, yymm, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN };
            int i = db.ExecuteCommand("DELETE OT_B "
                                   + " WHERE EXISTS(SELECT 1 FROM BASETTS A JOIN DEPT B ON A.DEPT=B.D_NO WHERE CONVERT(DATETIME,CONVERT(NVARCHAR(50), GETDATE(),101)) BETWEEN A.ADATE AND A.DDATE "
                                   + " AND A.NOBR BETWEEN {0} AND {1} AND B.D_NO_DISP BETWEEN {2} AND {3} AND A.NOBR=OT_B.NOBR)"
                                   //+ " AND dbo.GetFilterByNobr(OT_B.NOBR,{5},{6},{7})=1"
                                   + " AND exists(select 1 from BASETTS x where x.NOBR=OT_B.NOBR and dbo.Today() between x.ADATE and x.DDATE and x.SALADR in (select DATAGROUP from dbo.UserReadDataGroupList({5},{6},{7})))"
                                   + " AND OT_B.YYMM={4}", parms);
        }
        public void DeleteWage()
        {
            object[] objArray = new object[] { YYMM, SEQ, NOBR_B, NOBR_E, DEPT_B, DEPT_E, SALADR, DATE_E };
            int i = 0;
            string saladr = "";
            //if (!ProcSuper) saladr = " and saladr={6} ";
            string cmd = "DELETE WAGE_B WHERE "
                //+ "nobr in (select nobr from basetts "
                //+ "where nobr between {2} and {3} and dept between {4} and {5} )"
                + " EXISTS(SELECT 1 FROM BASETTS A JOIN DEPT B ON A.DEPT=B.D_NO WHERE CONVERT(DATETIME,CONVERT(NVARCHAR(50), {7},101)) BETWEEN A.ADATE AND A.DDATE "
                + " AND A.NOBR BETWEEN {2} AND {3} AND B.D_NO_DISP BETWEEN {4} AND {5} AND A.NOBR=WAGE_B.NOBR)"
                + " and yymm={0} and seq={1} " + " AND " + Sal.Function.GetFilterCmdByNobrOfWrite("WAGE_B.nobr");
            i = smd.ExecuteCommand(cmd, objArray);
            objArray = new object[] { YYMM, SEQ2, NOBR_B, NOBR_E, DEPT_B, DEPT_E, SALADR, DATE_E };
            i = smd.ExecuteCommand(cmd, objArray);
        }
        public void DeleteWaged()
        {
            object[] objArray = new object[] { YYMM, SEQ, NOBR_B, NOBR_E, DEPT_B, DEPT_E, SALADR, DATE_E };
            int i = 0;
            //waged seq
            string cmd = "DELETE WAGED_B WHERE"
                // +"where nobr in (select nobr from basetts " +
                //"where nobr between {2} and {3} and dept between {4} and {5} )"
                + " EXISTS(SELECT 1 FROM BASETTS A JOIN DEPT B ON A.DEPT=B.D_NO WHERE CONVERT(DATETIME,CONVERT(NVARCHAR(50), {7},101)) BETWEEN A.ADATE AND A.DDATE "
                + " AND A.NOBR BETWEEN {2} AND {3} AND B.D_NO_DISP BETWEEN {4} AND {5} AND A.NOBR=WAGED_B.NOBR)"
               + " and yymm={0} and seq={1} "
               + " AND " + Sal.Function.GetFilterCmdByNobrOfWrite("waged_b.nobr");
            i = smd.ExecuteCommand(cmd, objArray);

            //waged seq2
            objArray = new object[] { YYMM, SEQ2, NOBR_B, NOBR_E, DEPT_B, DEPT_E, SALADR, DATE_E };
            i = smd.ExecuteCommand(cmd, objArray);

        }
        public void TaxCalc(bool isSalary)
        {
            var nobrList = from wagedItem in wagedList
                           join salcode in db.SALCODE.ToList() on wagedItem.SAL_CODE equals salcode.SAL_CODE
                           join salattr in db.SALATTR.ToList() on salcode.SAL_ATTR equals salattr.SALATTR1
                           //join baseRow in smd.BASE on wagedItem.NOBR equals baseRow.NOBR
                           group new { wagedItem, salattr.FLAG, salattr.TAX, salcode.TAXRATE } by wagedItem.NOBR into gp
                           select gp;
            var basettsList = (from a in smd.BASETTS
                               join b in smd.BASE on a.NOBR equals b.NOBR
                               join c in smd.DEPT on a.DEPT equals c.D_NO
                               where a.NOBR.CompareTo(NOBR_B) >= 0 && a.NOBR.CompareTo(NOBR_E) <= 0
                               && c.D_NO_DISP.CompareTo(DEPT_B) >= 0 && c.D_NO_DISP.CompareTo(DEPT_E) <= 0
                               && DATE_E >= a.ADATE && DATE_E <= a.DDATE.Value
                               //&& smd.GetFilterByNobr(a.NOBR, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value
                               && smd.UserReadDataGroupList(MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Select(p => p.DATAGROUP).Contains(a.SALADR)
                               select new { a.NOBR, a.TAX_DATE, a.TAX_EDATE, b.TAXCNT, a.FIXRATE, a.NOCARD, b.COUNT_MA, b.PRETAX }).ToList();
            var taxlvlSQL = from a in db.TAXLVL where a.PER0 > 0 && a.YEAR == db.TAXLVL.Max(p => p.YEAR) orderby a.AMT_L select a;
            decimal MaxTaxlvl = 0;
            if (taxlvlSQL.Any())
                MaxTaxlvl = taxlvlSQL.First().AMT_L;

            foreach (var nobrItem in nobrList)//計算每個人的所得稅(nobrItem包含個人此次計算的所得薪資)
            {
                //BASE baseItem = null;
                //BASETTS basettsLastItem = null;
                var empData = from a in basettsList where a.NOBR == nobrItem.Key select a;
                if (empData.Any())
                {
                    var rEmp = empData.First();
                    decimal inAmt = nobrItem.Where(p => p.FLAG.Trim() != "-"
                        && p.TAX && p.TAXRATE == 0).Sum(pp =>
                        JBModule.Data.CDecryp.Number(pp.wagedItem.AMT));//應稅加項
                    decimal outAmt = nobrItem.Where(p => p.FLAG.Trim() == "-"
                        && p.TAX && p.TAXRATE == 0).Sum(pp =>
                        JBModule.Data.CDecryp.Number(pp.wagedItem.AMT));//應稅減項


                    decimal fixRateInTaxAmt = nobrItem.Where(p => p.TAXRATE > 0 && p.FLAG.Trim() != "-" && p.TAX).Sum(pp =>
                        JBModule.Data.CDecryp.Number(pp.wagedItem.AMT) * pp.TAXRATE);//固定稅率的所得稅金額(加項)
                    decimal fixRateOutTaxAmt = nobrItem.Where(p => p.TAXRATE > 0 && p.FLAG.Trim() == "-" && p.TAX).Sum(pp =>
                        JBModule.Data.CDecryp.Number(pp.wagedItem.AMT) * pp.TAXRATE);//固定稅率的所得稅金額(減項)
                    decimal fixRateInAmt = nobrItem.Where(p => p.TAXRATE > 0 && p.FLAG.Trim() != "-" && p.TAX).Sum(pp =>
                        JBModule.Data.CDecryp.Number(pp.wagedItem.AMT));//固定稅率的所得稅金額(加項)
                    decimal fixRateOutAmt = nobrItem.Where(p => p.TAXRATE > 0 && p.FLAG.Trim() == "-" && p.TAX).Sum(pp =>
                        JBModule.Data.CDecryp.Number(pp.wagedItem.AMT));//固定稅率的所得稅金額(減項)

                    decimal totalAmt = inAmt - outAmt;
                    decimal totalFixRateAmt = fixRateInTaxAmt - fixRateOutTaxAmt;
                    decimal FixRateTotalAmt = fixRateInAmt - fixRateOutAmt;
                    decimal taxAmt = 0;

                    decimal TaxRate = 1;
                    decimal amt = 0, amtFixRate = 0, amtYear = 0;
                    if (rEmp.NOCARD) continue;
                    if (FixRateTotalAmt >= MaxTaxlvl)//如果有設定固定稅率者，總和必須大於設定的金額才要扣
                        amtFixRate = totalFixRateAmt;
                    if (!rEmp.COUNT_MA)//本勞
                    {
                        //年獎必須超過級距表最低應扣金額才要扣錢
                        //if (yearAmt >= MaxTaxlvl) amtYear = Math.Round(yearAmt * MainForm.TaxConfig.FIXTAXRATE.Value, MidpointRounding.AwayFromZero);
                        if (rEmp.FIXRATE) //如果勾選固定稅率
                        {
                            TaxRate = MainForm.TaxConfig.FIXTAXRATE.Value;
                            amt = totalAmt * TaxRate;
                            if (amt > MainForm.TaxConfig.TAXAMTAMONTH) taxAmt = amt;//如果超過設定的金額才要扣(For 固定稅率)
                        }
                        else//如果沒有勾選固定稅率，則看級距表
                        {
                            decimal taxcnt = rEmp.TAXCNT > 11 ? decimal.Parse("11") : rEmp.TAXCNT;//最多只算到10口
                            //SalaryDate sd = new SalaryDate(YYMM);
                            var taxlvl = from taxlvlItem in smd.TAXLVL where taxlvlItem.AMT_L <= totalAmt && taxlvlItem.AMT_H >= totalAmt && taxlvlItem.YEAR == smd.TAXLVL.Max(p => p.YEAR) select taxlvlItem;
                            System.Data.DataTable dt = taxlvl.CopyToDataTable();
                            if (dt.Rows.Count > 0)
                            {
                                string colName = "per" + Convert.ToInt32(taxcnt).ToString();
                                amt = Convert.ToDecimal(dt.Rows[0][colName]);
                                taxAmt = amt;
                            }
                        }
                        //if (isSalary)
                        //    if (taxAmt < rEmp.PRETAX) taxAmt = rEmp.PRETAX;//如果低於預扣金額，就取代成預扣金額

                    }
                    else//外勞
                    {
                        DateTime Bdate, Edate, TaxBdate, TaxEdate;
                        Bdate = new DateTime(this.TRANS_DATE.Year, 1, 1);
                        Edate = new DateTime(this.TRANS_DATE.Year, 12, 31);
                        if (rEmp.TAX_DATE == null)
                            TaxBdate = Bdate;
                        else
                            TaxBdate = rEmp.TAX_DATE.Value;
                        if (rEmp.TAX_EDATE == null)
                            TaxEdate = Edate;
                        else
                            TaxEdate = rEmp.TAX_EDATE.Value;
                        int days = Function.RangeMix(Bdate, Edate, TaxBdate, TaxEdate);

                        if (days > MainForm.TaxConfig.ENTRYDAY.Value)//超過183天
                            TaxRate = MainForm.TaxConfig.FORTAXRATE02.Value;
                        else if (totalAmt < MainForm.TaxConfig.FORSALBASD.Value)//未滿25920
                            TaxRate = MainForm.TaxConfig.FORTAXRATE03.Value;
                        else TaxRate = MainForm.TaxConfig.FORTAXRATE01.Value;//未滿183天

                        taxAmt = totalAmt * TaxRate;
                    }
                    if (isSalary)
                        if (taxAmt < rEmp.PRETAX) taxAmt = rEmp.PRETAX;//如果低於預扣金額，就取代成預扣金額
                    var wageOfNobr = wageList.Where(p => p.NOBR == nobrItem.Key);
                    if (wageOfNobr.Any()) wageOfNobr.First().TAXRATE = TaxRate;

                    var waged = new JBModule.Data.Linq.WAGED_B();
                    //waged.AMT = JBModule.Data.CEncrypt.Number(decimal.Round(taxAmt + amtFixRate + amtYear, MidpointRounding.AwayFromZero));
                    waged.AMT = JBModule.Data.CEncrypt.Number(decimal.Truncate(taxAmt + amtFixRate + amtYear));
                    waged.NOBR = nobrItem.Key;
                    waged.SAL_CODE = MainForm.TaxConfig.TAXSALCODE;
                    waged.SEQ = this.SEQ;
                    waged.YYMM = this.YYMM;
                    InsertWaged(waged);
                }
            }
            db.SubmitChanges();
        }
        public void CreateWage()
        {
            var enrich = (from rowEnrich in smd.ENRICH
                          join basetts in smd.BASETTS on rowEnrich.NOBR equals basetts.NOBR
                          join a in smd.DEPT on basetts.DEPT equals a.D_NO
                          where rowEnrich.YYMM == this.YYMM && rowEnrich.SEQ == SEQ
                          && rowEnrich.NOBR.Trim().CompareTo(NOBR_B.Trim()) >= 0 && rowEnrich.NOBR.Trim().CompareTo(NOBR_E.Trim()) <= 0
                          && a.D_NO_DISP.Trim().CompareTo(DEPT_B.Trim()) >= 0 && a.D_NO_DISP.Trim().CompareTo(DEPT_E.Trim()) <= 0
                          && DATE_E >= basetts.ADATE && DATE_E <= basetts.DDATE.Value
                          //&& smd.GetFilterByNobr(rowEnrich.NOBR, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value
                          && smd.UserReadDataGroupList(MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Select(p => p.DATAGROUP).Contains(basetts.SALADR)
                          && rowEnrich.MEMO.Trim().Length > 0
                          select rowEnrich).ToList();
            var groupWaged = from l in wagedList group l by l.NOBR.Trim() into gp select gp;
            wageList = new List<JBModule.Data.Linq.WAGE_B>();
            var salcodeList = (from a in db.SALCODE select a).ToList();
            foreach (var wagedOfNobr in groupWaged)
            {
                JBModule.Data.Linq.WAGE_B wage = new JBModule.Data.Linq.WAGE_B();
                wage.NOBR = wagedOfNobr.Key;
                //if (!wage.BASE.BASETTS.Any()) continue;
                decimal workDays = 0;
                if (WorkDaysList.ContainsKey(wagedOfNobr.Key)) workDays = WorkDaysList[wagedOfNobr.Key];

                //foreach (var it in wagedOfNobr)
                //{
                //    if (salcodeList.Where(p => p.SAL_CODE == it.SAL_CODE && p.SALBASD1).Any())
                //    {
                //        JBModule.Data.Linq.SALBASD1 salbasd1 = new JBModule.Data.Linq.SALBASD1();
                //        salbasd1.YYMM = YYMM;
                //        salbasd1.AMT = it.AMT;
                //        salbasd1.AMTB = 1;
                //        salbasd1.SEQ = SEQ;
                //        salbasd1.KEY_DATE = DateTime.Now;
                //        salbasd1.KEY_MAN = MainForm.USER_NAME;
                //        salbasd1.MENO = "";
                //        salbasd1.NOBR = it.NOBR;
                //        salbasd1.SAL_CODE = it.SAL_CODE;
                //        db.SALBASD1.InsertOnSubmit(salbasd1);
                //    }
                //}
                //db.SubmitChanges();
                JBModule.Data.Linq.BASETTS basetts = (from b in smd.BASETTS where b.NOBR == wagedOfNobr.Key && b.ADATE <= DATE_E && DATE_E <= b.DDATE select b).FirstOrDefault();
                JBModule.Data.Linq.BASE _base = (from b in smd.BASE where b.NOBR == wagedOfNobr.Key select b).FirstOrDefault();
                if (_base == null || basetts == null || basetts.NOWAGE) continue;//如果勾不發薪//20130111額外判斷null,代表無人事資料                
                wage.KEY_DATE = DateTime.Now;
                wage.KEY_MAN = MainForm.USER_NAME;
                wage.NOTE = "";
                foreach (var it in enrich.Where(p => p.NOBR == wagedOfNobr.Key))
                    wage.NOTE += it.MEMO + ";";
                wage.SALADR = basetts.SALADR;
                wage.SEQ = SEQ;
                wage.TAXRATE = 1;
                wage.WK_DAYS = workDays;
                wage.YYMM = YYMM;
                wage.ACCOUNT_NO = _base.ACCOUNT_NO;
                wage.ADATE = TRANS_DATE;
                wage.BANKNO = _base.BANKNO;
                wage.CASH = false;
                if (wage.ACCOUNT_NO == null || wage.ACCOUNT_NO.Trim().Length == 0) wage.CASH = true;//沒有帳號就發現金
                wage.COMP = basetts.COMP;
                wage.DATE_B = DATE_B;
                wage.DATE_E = DATE_E;
                //wage.ATT_DATE_B = ATT_DATE_B;
                //wage.ATT_DATE_E = ATT_DATE_E;
                wage.FORMAT = this.Type;
                wageList.Add(wage);
                //db.WAGE.InsertOnSubmit(wage);

            }
        }
        public void WriteToDB()
        {
            try
            {
                smd.WAGED_B.InsertAllOnSubmit(wagedList);
                smd.OT_B.InsertAllOnSubmit(OvertimeBList);
                smd.SubmitChanges();
            }
            catch (System.Data.Linq.ChangeConflictException ex)
            {
                foreach (System.Data.Linq.ObjectChangeConflict occ in smd.ChangeConflicts)
                {
                    // 採用目前物件中的值，並更新資料庫中的版本
                    occ.Resolve(System.Data.Linq.RefreshMode.KeepCurrentValues);
                }
                // 注意：解決完衝突之後要記得重新再 SubmitChanges() 一次，否則一樣不會更新資料庫
                smd.SubmitChanges();
            }
        }

        public void ChangeSeq()
        {
            var sql = (from a in db.BASETTS where DATE_E >= a.ADATE && DATE_E <= a.DDATE.Value && a.EMPCD.ToUpper().Contains("C") select a.NOBR).ToList();
            var wageOfEmpcd3 = from a in wageList where sql.Contains(a.NOBR) select a;
            foreach (var it in wageOfEmpcd3)
                it.SEQ = SEQ2;

            var wagedOfEmpcd3 = from a in wagedList where sql.Contains(a.NOBR) select a;
            foreach (var it in wagedOfEmpcd3)
                it.SEQ = SEQ2;
            db.WAGE_B.InsertAllOnSubmit(wageList);
            db.SubmitChanges();
        }
    }
}
