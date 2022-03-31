using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JBHR.Sal.Core.Inslab
{
    public class Inslab
    {
        public static System.ComponentModel.BackgroundWorker backgroundWorker;
        public static Guid guid = Guid.Empty;
        #region 勞健保類別
        INSLAB ri;
        DateTime date_ins_b;
        DateTime date_ins_e;
        decimal _JOBACCRATE = 0;
        List<INSURLV> insurlvList = new List<INSURLV>();
        public Inslab()
        {
            SalaryMDDataContext db = new SalaryMDDataContext();
            insurlvList = db.INSURLV.ToList();
        }
        public Inslab(INSLAB row, DateTime ins_b, DateTime ins_e, decimal JOBACCRATE)
        {
            this.ri = row;
            date_ins_b = ins_b;
            date_ins_e = ins_e;
            _JOBACCRATE = JOBACCRATE;
        }
        public string h_inscd
        {
            get
            {
                if (ri.IN_DATE <= date_ins_b && date_ins_e <= ri.OUT_DATE)//整月在職
                    return "0";
                else if (ri.CODE == "3" && date_ins_b == ri.IN_DATE && ri.OUT_DATE < date_ins_e)//如果該筆為退保，且加保日為勞健保計算起始日，就檢查是否有上一筆連續資料，且不能是退保
                {
                    SalaryMDDataContext db = new SalaryMDDataContext();
                    var sql = from a in db.INSLAB where a.NOBR == ri.NOBR && a.FA_IDNO == ri.FA_IDNO && ri.IN_DATE.AddDays(-1) >= a.IN_DATE && ri.IN_DATE.AddDays(-1) <= a.OUT_DATE select a;
                    if (sql.Any())//有連續資料
                    {
                        var inslab = sql.First();
                        if (inslab.CODE == "3") return "1";//如果連續的資料是退保，一樣代表不連續，所以是當月加退
                        else return "3";//如果不是退保，又是連續資料，就當作是調整退保
                    }
                    else
                        return "1";
                }
                else if (date_ins_b <= ri.IN_DATE && ri.OUT_DATE < date_ins_e)//當月加退保，計一個月
                    return "1";
                else if (date_ins_b < ri.IN_DATE && ri.IN_DATE <= date_ins_e)//月中投保，月底在保
                    return "2";
                else if (date_ins_b <= ri.OUT_DATE && ri.OUT_DATE < date_ins_e)//月初在保，月中退保
                    return "3";
                else//整月在保
                    return "4";
            }
        }
        public string l_inscd
        {
            get
            {
                if (ri.IN_DATE <= date_ins_b && date_ins_e == ri.OUT_DATE && date_ins_e.Month == 2 && ri.CODE == "3")//剛好2月底離開
                {
                    //if (date_ins_e.DayOfWeek == DayOfWeek.Sunday )
                    //    return "01-27";//遇到月底放假
                    //if (date_ins_e.DayOfWeek == DayOfWeek.Saturday)
                    //    return "01-26";//遇到月底放假
                    return "01";//月底最後一天
                }
                else if (ri.IN_DATE <= date_ins_b && date_ins_e <= ri.OUT_DATE)//整月在職
                    return "0";
                else if (date_ins_b <= ri.IN_DATE && ri.OUT_DATE < date_ins_e)//當月到離
                    return "1";
                else if (date_ins_b < ri.IN_DATE && ri.IN_DATE <= date_ins_e)//月中投保，月底在保(一號加保的話可能是整月)
                    return "2";
                else if (date_ins_b <= ri.OUT_DATE && ri.OUT_DATE < date_ins_e)//月初在保，月中退保
                    return "3";
                else//整月在保
                    return "4";
            }
        }
        public int l_adays
        {
            get
            {
                int total_days = 0;
                switch (l_inscd)
                {
                    case "0":
                        total_days = 30;
                        break;
                    case "1"://當月到離
                        total_days = Function.RangeMix(date_ins_b, date_ins_e, ri.IN_DATE, ri.OUT_DATE);
                        break;
                    case "2":
                        total_days = 30 - ri.IN_DATE.Day + 1;
                        if (ri.IN_DATE.Day == 31) total_days = 1;//如果剛好是31號加保，也要算一天
                        break;
                    case "3":
                        total_days = Function.RangeMix(date_ins_b, date_ins_e, ri.IN_DATE, ri.OUT_DATE);
                        break;
                    case "4":
                        total_days = 30;
                        break;
                    case "01":
                        total_days = date_ins_e.Day;
                        break;

                }
                return total_days > 30 ? 30 : total_days;
            }
        }
        public string r_inscd
        {
            get
            {
                if (ri.IN_DATE <= date_ins_b && date_ins_e <= ri.ROUT_DATE)//整月在職
                    return "0";
                else if (date_ins_b <= ri.IN_DATE && ri.ROUT_DATE < date_ins_e)//當月到離
                    return "1";
                else if (date_ins_b < ri.IN_DATE && ri.IN_DATE <= date_ins_e)//月中投保，月底在保
                    return "2";
                else if (date_ins_b <= ri.ROUT_DATE && ri.ROUT_DATE < date_ins_e)//月初在保，月中退保
                    return "3";
                else//整月在保
                    return "4";
            }
        }
        public int r_adays()
        {
            int total_days = 0;
            switch (r_inscd)
            {
                case "0":
                    total_days = 30;
                    break;
                case "1"://當月加退
                    total_days = Function.RangeMix(date_ins_b, date_ins_e, ri.IN_DATE, ri.ROUT_DATE == null ? ri.OUT_DATE : ri.ROUT_DATE.Value);
                    break;
                case "2"://月中加保
                    total_days = 30 - ri.IN_DATE.Day + 1;
                    if (ri.IN_DATE.Day == 31) total_days = 1;//如果剛好是31號加保，也要算一天
                    break;
                case "3"://月中退保
                    total_days = Function.RangeMix(date_ins_b, date_ins_e, ri.IN_DATE, ri.ROUT_DATE == null ? ri.OUT_DATE : ri.ROUT_DATE.Value);
                    break;
                case "4":
                    total_days = 30;
                    break;

            }
            return total_days > 30 ? 30 : total_days;

        }
        public int r_adays(DateTime date_b, DateTime date_e)
        {
            int total_days = 0;
            if (date_b <= date_ins_b && date_ins_e <= date_e)//整月在職
                total_days = 30;
            else if (date_ins_b <= date_b && date_e < date_ins_e)//當月到離
                total_days = Function.RangeMix(date_ins_b, date_ins_e, date_b, date_e);
            else if (date_ins_b < date_b && date_b <= date_ins_e)//月中投保，月底在保
            {
                total_days = 30 - date_b.Day + 1;
                if (date_b.Day == 31) total_days = 1;//如果剛好是31號加保，也要算一天
            }
            else if (date_ins_b <= date_e && date_e < date_ins_e)//月初在保，月中退保
                total_days = Function.RangeMix(date_ins_b, date_ins_e, date_b, date_e);
            else//整月在保
                total_days = 30;
            return total_days;
        }

        #region 勞保
        public LARCODE larcode
        {
            get
            {
                return SalaryVar.GetLarCode(ri.LRATE_CODE);
            }
        }
        public decimal lab_amt_self
        {
            get
            {//部分負擔*(普通事故+失業給付)*個人負擔*投保金額*勞保天數/30
                decimal amt = Math.Round((larcode.NORMALRATE) * larcode.SELFCHARGE * JBModule.Data.CDecryp.Number(ri.L_AMT) * l_adays / 30, MidpointRounding.AwayFromZero);
                decimal amt1 = Math.Round((larcode.LOSJOBRATE) * larcode.SELFCHARGE * JBModule.Data.CDecryp.Number(ri.L_AMT) * l_adays / 30, MidpointRounding.AwayFromZero);
                decimal deduct = Math.Round((1 - larcode.PARTIAL) * (larcode.NORMALRATE) * larcode.SELFCHARGE * JBModule.Data.CDecryp.Number(ri.L_AMT) * l_adays / 30, MidpointRounding.AwayFromZero);
                decimal deduct1 = Math.Round((1 - larcode.PARTIAL) * (larcode.LOSJOBRATE) * larcode.SELFCHARGE * JBModule.Data.CDecryp.Number(ri.L_AMT) * l_adays / 30, MidpointRounding.AwayFromZero);
                return amt + amt1 - deduct - deduct1;
            }
        }
        public decimal lab_amt_comp
        {
            get
            {
                if (ri.FA_IDNO.Trim().Length != 0)
                    return 0;
                if (ri.FA_IDNO.Trim().Length != 0)
                    return 0;
                if (larcode == null)
                    throw new Exception(Resources.Sal.DataNoFound + ":" + ri.LRATE_CODE);
                //(普通事故+失業給付)*公司負擔*投保金額*勞保天數/30
                decimal amtNormal = Math.Round(larcode.NORMALRATE * larcode.COMPCHARGE * JBModule.Data.CDecryp.Number(ri.L_AMT) * l_adays / 30, MidpointRounding.AwayFromZero);
                decimal amtLos = Math.Round(larcode.LOSJOBRATE * larcode.COMPCHARGE * JBModule.Data.CDecryp.Number(ri.L_AMT) * l_adays / 30, MidpointRounding.AwayFromZero);
                return Math.Round(amtNormal + amtLos + LAB_JOBAMT + LAB_FUNAMT, MidpointRounding.AwayFromZero);
            }
        }
        /// <summary>
        /// 職災(未四捨五入)
        /// </summary>
        private decimal lab_JobAmt
        {
            get
            {//投保金額*職災比率*勞保天數/30
                if (larcode.NODISASTER) return 0;
                return JBModule.Data.CDecryp.Number(ri.L_AMT) * _JOBACCRATE * this.l_adays / 30;//(投保金額*職災比率*身分別)*有效天數/30
            }
        }
        /// <summary>
        /// 職災(四捨五入)
        /// </summary>
        public decimal LAB_JOBAMT
        {
            get
            {
                return Math.Round(lab_JobAmt, MidpointRounding.AwayFromZero);
            }
        }
        /// <summary>
        /// 墊償基金(未四捨五入)
        /// </summary>
        private decimal lab_FundAmt
        {
            get
            {//墊償基金比率*投保金額*勞保天數/30
                if (larcode.NOFUND) return 0;
                return SalaryVar.FudRate * JBModule.Data.CDecryp.Number(ri.L_AMT) * this.l_adays / 30;//(墊償基金比率*投保金額)*有效天數/30
            }
        }
        /// <summary>
        /// 墊償基金(四捨五入)
        /// </summary>
        public decimal LAB_FUNAMT
        {
            get
            {
                //return 0;//不算
                return Math.Round(lab_FundAmt, MidpointRounding.AwayFromZero);
            }
        }
        #endregion
        #region 健保
        public bool isNeedHea
        {
            get
            {
                bool isNeed = true;
                switch (h_inscd)
                {
                    case "1":
                        isNeed = false;
                        break;
                    case "3":
                        isNeed = false;
                        break;
                    default:
                        isNeed = true;
                        break;
                }
                return isNeed;
            }
        }
        public HARCODE harcode
        {
            get
            {
                return SalaryVar.GetHarCode(ri.HRATE_CODE);
            }
        }
        public decimal hea_amt_self
        {
            get
            {//MEMO:0990412 健保個人負擔的健保費率，修改成依照該投保薪資所對應的保險等級中所設定的倍率
                decimal h_amt = JBModule.Data.CDecryp.Number(ri.H_AMT);
                INSURLV ins = SalaryVar.GetInsurlv(h_amt);
                decimal rate = ins.EFF_RATE;
                if (harcode.SELFCHARGE == 1)//MEMO:0990414 如果部分負擔是1(全額負擔，雇主)，就走系統設定的倍率
                    rate = MainForm.HealthConfig.HEACOMPRATE.Value;
                decimal amt = Math.Round(harcode.SELFCHARGE * rate * h_amt, MidpointRounding.AwayFromZero);
                amt = decimal.Floor(amt * harcode.PARTIAL);
                if (amt < harcode.NOPAYTOP)
                    amt = 0;
                else
                    amt = amt - harcode.NOPAYTOP;
                if (harcode.FIX_AMT > 0)
                    amt = harcode.FIX_AMT;
                return amt;
            }
        }
        public decimal hea_amt_comp
        {
            get
            {   //眷屬公司負擔為0(算在員工部分，以平均眷口數計算)
                if (ri.FA_IDNO.Trim().Length > 0) return 0;
                //部分負擔*公司負擔*健保費率*平均眷口數*投保金額        
                //MEMO:0990412 2010年4月修改的保險費率，不影響原本公司負擔的計算公式，僅倍率提高
                decimal amt = harcode.COMPCHARGE * SalaryVar.HeaRate * SalaryVar.AvgFamily * JBModule.Data.CDecryp.Number(ri.H_AMT);
                return Math.Round(amt, MidpointRounding.AwayFromZero);
            }
        }
        #endregion
        #endregion
        public static void Calc(string yymm, string nobr_b, string nobr_e, string dept_b, string dept_e, DateTime InEDate, bool Prev)
        {
            Delete(yymm, nobr_b, nobr_e, dept_b, dept_e);
            List<string> ttscodeList = new List<string>();
            ttscodeList.Add("1");
            ttscodeList.Add("4");
            ttscodeList.Add("6");
            SalaryDate sd = new SalaryDate(yymm);
            //DateTime date_b = sd.FirstDayOfMonth;
            //DateTime date_e = sd.LastDayOfMonth;
            //DateTime Lastdate_b= new DateTime(int.Parse(yymm.Substring(0, 4)), int.Parse(yymm.Substring(4, 2)), 1).AddMonths(-1);
            //DateTime Lastdate_e = Lastdate_b.AddMonths(1).AddDays(-1);
            DateTime date_b = new DateTime(int.Parse(yymm.Substring(0, 4)), int.Parse(yymm.Substring(4, 2)), 1);
            DateTime date_e = date_b.AddMonths(1).AddDays(-1);
            SalaryMDDataContext smd = new SalaryMDDataContext();
            var sql = from a in smd.INSLAB
                      join b in smd.BASETTS on a.NOBR equals b.NOBR
                      join c in smd.DEPT on b.DEPT equals c.D_NO
                      join d in smd.INSCOMP on a.S_NO equals d.S_NO
                      //join wrnt in smd.WriteRuleNobrTable.Where(p => p.GUID == guid) on a.NOBR equals wrnt.EMPID
                      where b.NOBR.CompareTo(nobr_b) >= 0 && b.NOBR.CompareTo(nobr_e) <= 0
                      //&& sd.LastDayOfMonth >= b.ADATE && sd.LastDayOfMonth <= b.DDATE
                      && date_e >= b.ADATE && date_e <= b.DDATE
                      && c.D_NO_DISP.CompareTo(dept_b) >= 0 && c.D_NO_DISP.CompareTo(dept_e) <= 0
                      && a.IN_DATE <= date_e && a.OUT_DATE >= date_b
                      && b.INDT <= InEDate
                      //&& smd.GetFilterByNobr(a.NOBR, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value
                      && smd.UserReadDataGroupList(MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Select(p => p.DATAGROUP).Contains(b.SALADR)
                      orderby a.NOBR, a.FA_IDNO, a.IN_DATE
                      select new { inslab = a, basetts = b, d.JOBACCRATE };
            var basettsSQL = from a in smd.BASETTS
                             join b in smd.BASETTS on a.NOBR equals b.NOBR into BASETTSs
                             join c in smd.DEPT on a.DEPT equals c.D_NO
                             //join wrnt in smd.WriteRuleNobrTable.Where(p => p.GUID == guid) on a.NOBR equals wrnt.EMPID
                             from basettsRow in BASETTSs
                             where a.NOBR.CompareTo(nobr_b) >= 0 && a.NOBR.CompareTo(nobr_e) <= 0
                             && c.D_NO_DISP.CompareTo(dept_b) >= 0 && c.D_NO_DISP.CompareTo(dept_e) <= 0
                             //&& sd.LastDayOfMonth >= a.ADATE && sd.LastDayOfMonth <= a.DDATE
                             && date_e >= a.ADATE && date_e <= a.DDATE
                             //&& basettsRow.ADATE <= sd.LastDayOfMonth && basettsRow.DDATE >= sd.FirstDayOfMonth
                             && basettsRow.ADATE <= date_e && basettsRow.DDATE >= date_b
                             && ttscodeList.Contains(basettsRow.TTSCODE)
                             && basettsRow.RETRATE > 0
                             //&& smd.GetFilterByNobr(a.NOBR, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value
                             && smd.UserReadDataGroupList(MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Select(p => p.DATAGROUP).Contains(a.SALADR)
                             select new { a.NOBR, BASETTSs };
            var RV_INSLAB = from rv in sql group rv by rv.inslab.NOBR into g1 select g1;
            EXPLAB re = null;
            List<EXPLAB> explabList = new List<EXPLAB>();
            decimal total_count = RV_INSLAB.Count();
            decimal current_count = 0;
            foreach (var gp in RV_INSLAB)//以每個人來跑回圈
            {
                int i = 0;
                current_count++;

                int percentage = Convert.ToInt32(current_count / total_count * 100);
                if (backgroundWorker != null)
                    backgroundWorker.ReportProgress(percentage, Resources.Sal.StatusComputing + gp.Key.ToString());
                List<EXPLAB> dt = new List<EXPLAB>();
                foreach (var ri in gp)
                {
                    //i++;
                    Inslab ins = new Inslab(ri.inslab, date_b, date_e, ri.JOBACCRATE.Value);
                    if (ri.inslab.LRATE_CODE.Trim() != "" && ri.inslab.FA_IDNO.Trim().Length == 0)//不計眷屬
                    {
                        //勞保
                        re = new EXPLAB();
                        re.ADATE = date_b;
                        re.COMP = JBModule.Data.CEncrypt.Number(ins.lab_amt_comp);
                        re.DAYS = ins.l_adays;
                        re.EXP = JBModule.Data.CEncrypt.Number(ins.lab_amt_self);
                        if (ri.inslab.LRATE_CODE.Trim() == "B")//育嬰留停
                        {
                            re.COMP = 10;
                            re.EXP = 10;
                        }
                        re.FA_IDNO = ri.inslab.FA_IDNO;
                        re.FUNDAMT = JBModule.Data.CEncrypt.Number(ins.LAB_FUNAMT);
                        re.INSCD = decimal.Parse(ins.l_inscd);
                        re.INSUR_TYPE = "1";
                        re.JOBAMT = JBModule.Data.CEncrypt.Number(ins.LAB_JOBAMT);
                        re.KEY_DATE = DateTime.Now;
                        re.KEY_MAN = MainForm.USER_NAME;
                        re.NOBR = ri.inslab.NOBR;
                        re.NOTEDIT = false;
                        re.RATE_CODE = ri.inslab.LRATE_CODE;
                        re.S_NO = ri.inslab.S_NO;
                        re.SAL_CODE = MainForm.LabConfig.LSALCODE;
                        re.YYMM = yymm;
                        re.SAL_YYMM = yymm;
                        re.SALADR = ri.basetts.SALADR;
                        var labSQL = from a in explabList where a.NOBR == re.NOBR && a.INSUR_TYPE == re.INSUR_TYPE && a.YYMM == re.YYMM select a;
                        if (labSQL.Any())
                        {
                            var rre = labSQL.First();
                            rre.EXP = JBModule.Data.CEncrypt.Number(JBModule.Data.CDecryp.Number(rre.EXP) + JBModule.Data.CDecryp.Number(re.EXP));
                            rre.COMP = JBModule.Data.CEncrypt.Number(JBModule.Data.CDecryp.Number(rre.COMP) + JBModule.Data.CDecryp.Number(re.COMP));
                            rre.JOBAMT = JBModule.Data.CEncrypt.Number(JBModule.Data.CDecryp.Number(rre.JOBAMT) + JBModule.Data.CDecryp.Number(re.JOBAMT));
                            rre.FUNDAMT = JBModule.Data.CEncrypt.Number(JBModule.Data.CDecryp.Number(rre.FUNDAMT) + JBModule.Data.CDecryp.Number(re.FUNDAMT));
                        }
                        else
                            explabList.Add(re);

                        //if (ri.basetts.RETCHOO == "2")//選擇勞退新制
                        //{
                        DateTime retdate1 = ri.basetts.RETDATE1 == null ? new DateTime(1900, 1, 1) : ri.basetts.RETDATE1.Value;
                        decimal adays = ins.r_adays();
                        decimal r_amt = JBModule.Data.CDecryp.Number(ri.inslab.R_AMT);
                        //decimal work_rate = adays / 30;
                        decimal comp = Math.Round(r_amt / 30M * adays * MainForm.LabConfig.NRETIRERATE.Value, MidpointRounding.AwayFromZero);
                        //decimal rate = ri.basetts.RETRATE / 100;
                        decimal self = 0;
                        //decimal self_adays = 0;
                        var basettsSQLofNobr = from a in basettsSQL where a.NOBR == ri.basetts.NOBR select a;
                        if (basettsSQLofNobr.Any())
                        {//只要抓出本月的起迄時間
                         // r_amt * a.rdays * a.RETRATE / 30 + r_amt * b.rdays * b.RETRATE / 30 + r_amt * c.rdays * c.RETRATE / 30 ...
                         // (r_amt * a.rdays * a.RETRATE + r_amt * b.rdays * b.RETRATE + r_amt * c.rdays * c.RETRATE ...) / 30
                         // r_amt * (a.rdays * a.RETRATE + b.rdays * b.RETRATE + c.rdays * c.RETRATE ...) / 30
                            decimal rate = 0;
                            foreach (var itm in basettsSQLofNobr.First().BASETTSs.Where(p => p.RETRATE > 0 && p.ADATE <= date_e && p.DDATE >= date_b))
                            {
                                DateTime bdate = date_e, edate = date_b;
                                if (bdate > itm.ADATE) bdate = itm.ADATE;
                                if (retdate1 > bdate) bdate = retdate1;
                                if (edate < itm.DDATE.Value) edate = itm.DDATE.Value;
                                if (bdate < date_b) bdate = date_b;
                                if (edate > date_e) edate = date_e;
                                if (bdate < ri.inslab.IN_DATE) bdate = ri.inslab.IN_DATE;
                                if (ri.inslab.ROUT_DATE != null && edate > ri.inslab.ROUT_DATE.Value) edate = ri.inslab.ROUT_DATE.Value;
                                if (bdate <= edate)
                                    rate += itm.RETRATE * ins.r_adays(bdate, edate) / 100;
                            }
                            self = Math.Round(r_amt / 30 * rate , MidpointRounding.AwayFromZero);
                        }
                        re = new EXPLAB();
                        re.ADATE = date_e;
                        re.COMP = ri.basetts.RETCHOO == "2" ? JBModule.Data.CEncrypt.Number(comp) : 10;//選擇新制公司才會提撥
                        if (ri.basetts.NORET) re.COMP = 10;//如果設定不計算退休金
                        re.DAYS = ins.l_adays;
                        re.EXP = JBModule.Data.CEncrypt.Number(self);
                        if (ri.inslab.LRATE_CODE.Trim() == "B")//育嬰留停
                        {
                            re.COMP = 10;
                            re.EXP = 10;
                        }
                        re.FA_IDNO = ri.inslab.FA_IDNO;
                        re.FUNDAMT = 10;
                        re.INSCD = decimal.Parse(ins.r_inscd);
                        re.INSUR_TYPE = "4";
                        re.JOBAMT = 10;
                        re.KEY_DATE = DateTime.Now;
                        re.KEY_MAN = MainForm.USER_NAME;
                        re.NOBR = ri.inslab.NOBR;
                        re.NOTEDIT = false;
                        re.RATE_CODE = ri.basetts.RETCHOO;
                        re.S_NO = ri.inslab.S_NO;
                        re.SAL_CODE = MainForm.LabConfig.RETSALCODE;
                        re.YYMM = yymm;
                        re.SAL_YYMM = yymm;
                        re.SALADR = ri.basetts.SALADR;
                        var retSQL = from a in explabList where a.NOBR == re.NOBR && a.INSUR_TYPE == re.INSUR_TYPE && a.YYMM == re.YYMM select a;
                        if (retSQL.Any())
                        {
                            var rre = retSQL.First();
                            rre.EXP = JBModule.Data.CEncrypt.Number(JBModule.Data.CDecryp.Number(rre.EXP) + JBModule.Data.CDecryp.Number(re.EXP));
                            rre.COMP = JBModule.Data.CEncrypt.Number(JBModule.Data.CDecryp.Number(rre.COMP) + JBModule.Data.CDecryp.Number(re.COMP));
                        }
                        else
                            explabList.Add(re);
                    }

                    //健保
                    if (ins.isNeedHea)
                    {
                        re = new EXPLAB();
                        re.ADATE = date_e;
                        re.COMP = JBModule.Data.CEncrypt.Number(ins.hea_amt_comp);
                        re.DAYS = 1;
                        re.EXP = JBModule.Data.CEncrypt.Number(ins.hea_amt_self);
                        re.FA_IDNO = ri.inslab.FA_IDNO;
                        re.FUNDAMT = 10;
                        re.INSCD = decimal.Parse(ins.h_inscd);
                        re.INSUR_TYPE = "2";
                        re.JOBAMT = 10;
                        re.KEY_DATE = DateTime.Now;
                        re.KEY_MAN = MainForm.USER_NAME;
                        re.NOBR = ri.inslab.NOBR;
                        re.NOTEDIT = false;
                        re.RATE_CODE = ri.inslab.HRATE_CODE;
                        re.S_NO = ri.inslab.S_NO;
                        re.SAL_CODE = MainForm.HealthConfig.HSALCODE;
                        re.YYMM = yymm;
                        re.SAL_YYMM = yymm;
                        re.SALADR = ri.basetts.SALADR;
                        var heaSQL = from a in explabList where a.NOBR == re.NOBR && a.FA_IDNO == re.FA_IDNO && a.INSUR_TYPE == re.INSUR_TYPE && a.YYMM == re.YYMM select a;
                        if (heaSQL.Any())
                        {
                            var rre = heaSQL.First();
                            if (JBModule.Data.CDecryp.Number(rre.EXP) > 0)//如果有錢，代表算過了，就略過
                            {
                                rre.EXP = JBModule.Data.CEncrypt.Number(JBModule.Data.CDecryp.Number(rre.EXP) + JBModule.Data.CDecryp.Number(re.EXP));
                                rre.COMP = JBModule.Data.CEncrypt.Number(JBModule.Data.CDecryp.Number(rre.COMP) + JBModule.Data.CDecryp.Number(re.COMP));
                            }
                        }
                        else
                        {
                            explabList.Add(re);
                            if (re.FA_IDNO.Trim().Length > 0)//只取眷屬//第二次算不判眷屬
                                dt.Add(re);
                        }
                    }

                }
                var dt_asc = dt.OrderBy(p => JBModule.Data.CDecryp.Number(p.EXP)).ToList();
                for (i = 3; i < dt_asc.Count(); i++)
                {
                    dt_asc[i].EXP = 10;//眷屬第四口開始不收費
                }

            }
            if (Prev)
            {
                //UNDONE:0990414 尚未檢查上個月是否已經先扣款
                var pd = sd.GetPrevSalaryDate();
                DateTime pdate_b = new DateTime(int.Parse(yymm.Substring(0, 4)), int.Parse(yymm.Substring(4, 2)), 1).AddMonths(-1);
                DateTime pdate_e = pdate_b.AddMonths(1).AddDays(-1);
                var pSQL = from a in smd.INSLAB
                           join b in smd.BASETTS on a.NOBR equals b.NOBR
                           join c in smd.DEPT on b.DEPT equals c.D_NO
                           join d in smd.INSCOMP on a.S_NO equals d.S_NO
                           //join wrnt in smd.WriteRuleNobrTable.Where(p => p.GUID == guid) on a.NOBR equals wrnt.EMPID
                           where b.NOBR.CompareTo(nobr_b) >= 0 && b.NOBR.CompareTo(nobr_e) <= 0
                           //&& sd.LastDayOfMonth >= b.ADATE && sd.LastDayOfMonth <= b.DDATE
                           && date_e >= b.ADATE && date_e <= b.DDATE
                           && c.D_NO_DISP.CompareTo(dept_b) >= 0 && c.D_NO_DISP.CompareTo(dept_e) <= 0
                           //&& a.IN_DATE <= pd.LastDayOfMonth && a.OUT_DATE >= pd.FirstDayOfMonth
                           && a.IN_DATE <= pdate_e && a.OUT_DATE >= pdate_b
                           && b.INDT <= InEDate
                           //&& smd.GetFilterByNobr(a.NOBR, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value
                           && smd.UserReadDataGroupList(MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Select(p => p.DATAGROUP).Contains(b.SALADR)
                           orderby a.NOBR, a.FA_IDNO, a.IN_DATE
                           select new { inslab = a, basetts = b, d.JOBACCRATE };

                basettsSQL = from a in smd.BASETTS
                             join b in smd.BASETTS on a.NOBR equals b.NOBR into BASETTSs
                             from basettsRow in BASETTSs
                             join c in smd.DEPT on a.DEPT equals c.D_NO
                             //join wrnt in smd.WriteRuleNobrTable.Where(p => p.GUID == guid) on a.NOBR equals wrnt.EMPID
                             where a.NOBR.CompareTo(nobr_b) >= 0 && a.NOBR.CompareTo(nobr_e) <= 0
                             && c.D_NO_DISP.CompareTo(dept_b) >= 0 && c.D_NO_DISP.CompareTo(dept_e) <= 0
                             //&& pd.LastDayOfMonth >= a.ADATE && pd.LastDayOfMonth <= a.DDATE
                             && pdate_e >= a.ADATE && pdate_e <= a.DDATE
                             //&& basettsRow.ADATE <= pd.LastDayOfMonth && basettsRow.DDATE >= pd.FirstDayOfMonth
                             && basettsRow.ADATE <= pdate_e && basettsRow.DDATE >= pdate_b
                             && ttscodeList.Contains(basettsRow.TTSCODE)
                             && basettsRow.RETRATE > 0
                             //&& smd.GetFilterByNobr(a.NOBR, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value
                             && smd.UserReadDataGroupList(MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Select(p => p.DATAGROUP).Contains(a.SALADR)
                             select new { a.NOBR, BASETTSs };

                var pExplab = from a in smd.EXPLAB
                              where a.YYMM == pd.YYMM && a.SAL_YYMM == pd.YYMM
                              select a;//上個月的勞健保費明細

                var calcList = from a in pSQL
                               where !pExplab.Where(p => p.NOBR == a.inslab.NOBR).Any()//避免誤判健保減免者為未計算，所以不抓眷屬身號
                               select a;//取其不存在者，為應計算而未計算
                date_b = pdate_b;// pd.FirstDayOfMonth;
                date_e = pdate_e;// pd.LastDayOfMonth;
                var RV_INSLAB1 = from rv in calcList group rv by rv.inslab.NOBR into g1 select g1;
                total_count = RV_INSLAB1.Count();
                current_count = 0;
                foreach (var gp in RV_INSLAB1)//以每個人來跑回圈
                {
                    int i = 0;
                    current_count++;

                    int percentage = Convert.ToInt32(current_count / total_count * 100);
                    if (backgroundWorker != null)
                        backgroundWorker.ReportProgress(percentage, Resources.Sal.StatusComputing + gp.Key.ToString());
                    List<EXPLAB> dt = new List<EXPLAB>();
                    foreach (var ri in gp)
                    {
                        //i++;
                        Inslab ins = new Inslab(ri.inslab, date_b, date_e, ri.JOBACCRATE.Value);
                        if (ri.inslab.FA_IDNO.Trim().Length == 0)//不計眷屬
                        {
                            //勞保
                            re = new EXPLAB();
                            re.ADATE = date_b;
                            re.COMP = JBModule.Data.CEncrypt.Number(ins.lab_amt_comp);
                            re.DAYS = ins.l_adays;
                            re.EXP = JBModule.Data.CEncrypt.Number(ins.lab_amt_self);
                            re.FA_IDNO = ri.inslab.FA_IDNO;
                            re.FUNDAMT = JBModule.Data.CEncrypt.Number(ins.LAB_FUNAMT);
                            re.INSCD = decimal.Parse(ins.l_inscd);
                            re.INSUR_TYPE = "1";
                            re.JOBAMT = JBModule.Data.CEncrypt.Number(ins.LAB_JOBAMT);
                            re.KEY_DATE = DateTime.Now;
                            re.KEY_MAN = MainForm.USER_NAME;
                            re.NOBR = ri.inslab.NOBR;
                            re.NOTEDIT = false;
                            re.RATE_CODE = ri.inslab.LRATE_CODE;
                            re.S_NO = ri.inslab.S_NO;
                            re.SAL_CODE = MainForm.LabConfig.LSALCODE;
                            re.YYMM = pd.YYMM;
                            re.SAL_YYMM = yymm;
                            re.SALADR = ri.basetts.SALADR;
                            //smd.EXPLAB.InsertOnSubmit(re);
                            var labSQL = from a in explabList where a.NOBR == re.NOBR && a.INSUR_TYPE == re.INSUR_TYPE && a.YYMM == re.YYMM select a;
                            if (labSQL.Any())
                            {
                                var rre = labSQL.First();
                                rre.EXP = JBModule.Data.CEncrypt.Number(JBModule.Data.CDecryp.Number(rre.EXP) + JBModule.Data.CDecryp.Number(re.EXP));
                                rre.COMP = JBModule.Data.CEncrypt.Number(JBModule.Data.CDecryp.Number(rre.COMP) + JBModule.Data.CDecryp.Number(re.COMP));
                                rre.JOBAMT = JBModule.Data.CEncrypt.Number(JBModule.Data.CDecryp.Number(rre.JOBAMT) + JBModule.Data.CDecryp.Number(re.JOBAMT));
                                rre.FUNDAMT = JBModule.Data.CEncrypt.Number(JBModule.Data.CDecryp.Number(rre.FUNDAMT) + JBModule.Data.CDecryp.Number(re.FUNDAMT));
                            }
                            else
                                explabList.Add(re);

                            //if (ri.basetts.RETCHOO == "2")//選擇勞退新制
                            //{
                            DateTime retdate1 = ri.basetts.RETDATE1 == null ? new DateTime(1900, 1, 1) : ri.basetts.RETDATE1.Value;
                            decimal adays = ins.r_adays();
                            decimal r_amt = JBModule.Data.CDecryp.Number(ri.inslab.R_AMT);
                            decimal work_rate = adays / 30;
                            decimal comp = Math.Round(r_amt * SalaryVar.RetRate * work_rate, MidpointRounding.AwayFromZero);
                            //decimal rate = ri.basetts.RETRATE / 100;
                            decimal self = 0;
                            //decimal self_adays = 0;
                            var basettsSQLofNobr = from a in basettsSQL where a.NOBR == ri.basetts.NOBR select a;
                            if (basettsSQLofNobr.Any())
                            {//只要抓出本月的起迄時間
                             // r_amt * a.rdays * a.RETRATE / 30 + r_amt * b.rdays * b.RETRATE / 30 + r_amt * c.rdays * c.RETRATE / 30 ...
                             // (r_amt * a.rdays * a.RETRATE + r_amt * b.rdays * b.RETRATE + r_amt * c.rdays * c.RETRATE ...) / 30
                             // r_amt * (a.rdays * a.RETRATE + b.rdays * b.RETRATE + c.rdays * c.RETRATE ...) / 30
                                decimal rate = 0;
                                foreach (var itm in basettsSQLofNobr.First().BASETTSs.Where(p => p.RETRATE > 0 && p.ADATE <= date_e && p.DDATE >= date_b))
                                {
                                    DateTime bdate = date_e, edate = date_b;
                                    if (bdate > itm.ADATE) bdate = itm.ADATE;
                                    if (retdate1 > bdate) bdate = retdate1;
                                    if (edate < itm.DDATE.Value) edate = itm.DDATE.Value;
                                    if (bdate < date_b) bdate = date_b;
                                    if (edate > date_e) edate = date_e;
                                    if (bdate < ri.inslab.IN_DATE) bdate = ri.inslab.IN_DATE;
                                    if (ri.inslab.ROUT_DATE != null && edate > ri.inslab.ROUT_DATE.Value) edate = ri.inslab.ROUT_DATE.Value;
                                    if (bdate <= edate)
                                        rate += itm.RETRATE * ins.r_adays(bdate, edate) / 100;
                                }
                                self = Math.Round(r_amt * rate / 30, MidpointRounding.AwayFromZero);
                            }
                            re = new EXPLAB();
                            re.ADATE = date_e;
                            re.COMP = ri.basetts.RETCHOO == "2" ? JBModule.Data.CEncrypt.Number(comp) : 10;//選擇新制公司才會提撥
                            re.DAYS = ins.l_adays;
                            re.EXP = JBModule.Data.CEncrypt.Number(self);
                            re.FA_IDNO = ri.inslab.FA_IDNO;
                            re.FUNDAMT = 10;
                            re.INSCD = decimal.Parse(ins.r_inscd);
                            re.INSUR_TYPE = "4";
                            re.JOBAMT = 10;
                            re.KEY_DATE = DateTime.Now;
                            re.KEY_MAN = MainForm.USER_NAME;
                            re.NOBR = ri.inslab.NOBR;
                            re.NOTEDIT = false;
                            re.RATE_CODE = ri.basetts.RETCHOO;
                            re.S_NO = ri.inslab.S_NO;
                            re.SAL_CODE = MainForm.LabConfig.RETSALCODE;
                            re.YYMM = pd.YYMM;
                            re.SAL_YYMM = yymm;
                            re.SALADR = ri.basetts.SALADR;
                            var retSQL = from a in explabList where a.NOBR == re.NOBR && a.INSUR_TYPE == re.INSUR_TYPE && a.YYMM == re.YYMM select a;
                            if (retSQL.Any())
                            {
                                var rre = retSQL.First();
                                rre.EXP = JBModule.Data.CEncrypt.Number(JBModule.Data.CDecryp.Number(rre.EXP) + JBModule.Data.CDecryp.Number(re.EXP));
                                rre.COMP = JBModule.Data.CEncrypt.Number(JBModule.Data.CDecryp.Number(rre.COMP) + JBModule.Data.CDecryp.Number(re.COMP));
                            }
                            else
                                explabList.Add(re);
                        }

                        //健保
                        if (ins.isNeedHea)
                        {
                            re = new EXPLAB();
                            re.ADATE = date_e;
                            re.COMP = JBModule.Data.CEncrypt.Number(ins.hea_amt_comp);
                            re.DAYS = 1;
                            re.EXP = JBModule.Data.CEncrypt.Number(ins.hea_amt_self);
                            re.FA_IDNO = ri.inslab.FA_IDNO;
                            re.FUNDAMT = 10;
                            re.INSCD = decimal.Parse(ins.h_inscd);
                            re.INSUR_TYPE = "2";
                            re.JOBAMT = 10;
                            re.KEY_DATE = DateTime.Now;
                            re.KEY_MAN = MainForm.USER_NAME;
                            re.NOBR = ri.inslab.NOBR;
                            re.NOTEDIT = false;
                            re.RATE_CODE = ri.inslab.HRATE_CODE;
                            re.S_NO = ri.inslab.S_NO;
                            re.SAL_CODE = MainForm.HealthConfig.HSALCODE;
                            re.YYMM = pd.YYMM;
                            re.SAL_YYMM = yymm;
                            re.SALADR = ri.basetts.SALADR;
                            var heaSQL = from a in explabList where a.NOBR == re.NOBR && a.FA_IDNO == re.FA_IDNO && a.INSUR_TYPE == re.INSUR_TYPE && a.YYMM == re.YYMM select a;
                            if (heaSQL.Any())
                            {
                                var rre = heaSQL.First();
                                if (JBModule.Data.CDecryp.Number(rre.EXP) > 0)//如果有錢，代表算過了，就略過
                                {
                                    rre.EXP = JBModule.Data.CEncrypt.Number(JBModule.Data.CDecryp.Number(rre.EXP) + JBModule.Data.CDecryp.Number(re.EXP));
                                    rre.COMP = JBModule.Data.CEncrypt.Number(JBModule.Data.CDecryp.Number(rre.COMP) + JBModule.Data.CDecryp.Number(re.COMP));
                                }
                            }
                            else
                            {
                                explabList.Add(re);
                                if (re.FA_IDNO.Trim().Length > 0)//只取眷屬//第二次算不判眷屬
                                    dt.Add(re);
                            }
                        }

                    }
                    var dt_asc = dt.OrderBy(p => JBModule.Data.CDecryp.Number(p.EXP)).ToList();
                    for (i = 3; i < dt_asc.Count(); i++)
                    {
                        dt_asc[i].EXP = 10;//眷屬第四口開始不收費
                    }

                }
            }
            if (backgroundWorker != null)
                backgroundWorker.ReportProgress(100, Resources.Sal.StatusWriteToDB);
            explabList = explabList.Where(p => p.SAL_CODE != "").ToList();
            smd.EXPLAB.InsertAllOnSubmit(explabList);
            smd.SubmitChanges();
            if (backgroundWorker != null)
                backgroundWorker.ReportProgress(100, Resources.Sal.StatusFinish);
        }
        public static Dictionary<string, string> GetPreviousExplab(string yymm, string nobr_b, string nobr_e, string dept_b, string dept_e)
        {
            List<string> ttscodeList = new List<string>();
            ttscodeList.Add("1");
            ttscodeList.Add("4");
            ttscodeList.Add("6");
            SalaryDate sd = new SalaryDate(yymm);
            DateTime date_b = sd.FirstDayOfMonth;
            DateTime date_e = sd.LastDayOfMonth;
            JBModule.Data.Linq.HrDBDataContext smd = new JBModule.Data.Linq.HrDBDataContext();
            var pd = sd.GetPrevSalaryDate();
            var pSQL = from a in smd.INSLAB
                       join b in smd.BASETTS on a.NOBR equals b.NOBR
                       join c in smd.DEPT on b.DEPT equals c.D_NO
                       //join wrnt in smd.WriteRuleNobrTable.Where(p => p.GUID == guid) on a.NOBR equals wrnt.EMPID
                       where b.NOBR.CompareTo(nobr_b) >= 0 && b.NOBR.CompareTo(nobr_e) <= 0
                       && sd.LastDayOfMonth >= b.ADATE && sd.LastDayOfMonth <= b.DDATE
                       && c.D_NO_DISP.CompareTo(dept_b) >= 0 && c.D_NO_DISP.CompareTo(dept_e) <= 0
                       && a.IN_DATE <= pd.LastDayOfMonth && a.OUT_DATE >= pd.FirstDayOfMonth
                       //&& b.INDT <= InEDate
                       //&& smd.GetFilterByNobr(a.NOBR, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value
                       && smd.UserReadDataGroupList(MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Select(p => p.DATAGROUP).Contains(b.SALADR)
                       orderby a.NOBR, a.FA_IDNO, a.IN_DATE
                       select new { a.NOBR, b.BASE.NAME_C };
            var basettsSQL = from a in smd.BASETTS
                             join b in smd.BASETTS on a.NOBR equals b.NOBR into BASETTSs
                             from basettsRow in BASETTSs
                             join c in smd.DEPT on a.DEPT equals c.D_NO
                             //join wrnt in smd.WriteRuleNobrTable.Where(p => p.GUID == guid) on a.NOBR equals wrnt.EMPID
                             where a.NOBR.CompareTo(nobr_b) >= 0 && a.NOBR.CompareTo(nobr_e) <= 0
                             && c.D_NO_DISP.CompareTo(dept_b) >= 0 && c.D_NO_DISP.CompareTo(dept_e) <= 0
                             && pd.LastDayOfMonth >= a.ADATE && pd.LastDayOfMonth <= a.DDATE
                             && basettsRow.ADATE <= pd.LastDayOfMonth && basettsRow.DDATE >= pd.FirstDayOfMonth
                             && ttscodeList.Contains(basettsRow.TTSCODE)
                             && basettsRow.RETRATE > 0
                             //&& smd.GetFilterByNobr(a.NOBR, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value
                             && smd.UserReadDataGroupList(MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Select(p => p.DATAGROUP).Contains(a.SALADR)
                             select new { a.NOBR, BASETTSs };

            var pExplab = from a in smd.EXPLAB
                          where a.YYMM == pd.YYMM && a.SAL_YYMM == pd.YYMM
                          select a;//上個月的勞健保費明細

            var calcList = from a in pSQL
                           where !pExplab.Where(p => p.NOBR == a.NOBR).Any()//避免誤判健保減免者為未計算，所以不抓眷屬身號
                           select a;//取其不存在者，為應計算而未計算
            //20130520如果員工或眷屬其中一個存在保費明細者，就不會在名單內
            return calcList.Distinct().ToDictionary(p => p.NOBR, p => p.NAME_C);
        }
        static void Delete(string yymm, string nobr_b, string nobr_e, string dept_b, string dept_e)
        {
            SalaryMDDataContext smd = new SalaryMDDataContext();
            //SalaryDate sd = new SalaryDate(yymm);
            DateTime date_b = new DateTime(int.Parse(yymm.Substring(0, 4)), int.Parse(yymm.Substring(4, 2)), 1);
            DateTime date_e = date_b.AddMonths(1).AddDays(-1);
            //object[] parms = new object[] { yymm, nobr_b, nobr_e, dept_b, dept_e, sd.FirstDayOfMonth, sd.LastDayOfMonth, MainForm.GroupInsConfig.GROUPSALCD, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN };
            object[] parms = new object[] { yymm, nobr_b, nobr_e, dept_b, dept_e, date_b, date_e, MainForm.GroupInsConfig.GROUPSALCD, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN };
            smd.ExecuteCommand("DELETE  EXPLAB"
                                + " WHERE EXISTS(SELECT 1 FROM BASETTS A JOIN DEPT B ON A.DEPT=B.D_NO WHERE CONVERT(DATETIME,CONVERT(NVARCHAR(50), GETDATE(),101)) BETWEEN A.ADATE AND A.DDATE "
                                + " AND A.NOBR BETWEEN {1} AND {2} AND B.D_NO_DISP BETWEEN {3} AND {4} AND EXPLAB.NOBR=A.NOBR)"
                                //+ " AND dbo.GetFilterByNobr(EXPLAB.NOBR,{8},{9},{10})=1"
                                + " AND exists(select 1 from BASETTS x where x.NOBR=EXPLAB.NOBR and dbo.Today() between x.ADATE and x.DDATE and x.SALADR in (select DATAGROUP from dbo.UserReadDataGroupList({8},{9},{10})))"
                                + " AND (EXPLAB.SAL_YYMM = {0}) AND SAL_CODE<>{7}", parms);
        }
        public static decimal GetLabAmtByInsurlv(decimal Salary)
        {
            SalaryMDDataContext db = new SalaryMDDataContext();
            var sql = from a in db.INSURLV where DateTime.Now.Date >= a.EFF_DATEL && DateTime.Now.Date <= a.LFF_DATEL select a;
            var query = from a in sql where a.AMT >= Salary select a;
            if (query.Any()) return query.First().AMT;
            return sql.Max(p => p.AMT);
        }
        public static decimal GetHeaAmtByInsurlv(decimal Salary)
        {
            SalaryMDDataContext db = new SalaryMDDataContext();
            var sql = from a in db.INSURLV where DateTime.Now.Date >= a.EFF_DATEH && DateTime.Now.Date <= a.LFF_DATEH select a;
            var query = from a in sql where a.AMT >= Salary select a;
            if (query.Any()) return query.First().AMT;
            return sql.Max(p => p.AMT);
        }
        public static decimal GetRetAmtByInsurlv(decimal Salary)
        {
            SalaryMDDataContext db = new SalaryMDDataContext();
            var sql = from a in db.INSURLV where DateTime.Now.Date >= a.EFF_DATER && DateTime.Now.Date <= a.LFF_DATER select a;
            var query = from a in sql where a.AMT >= Salary select a;
            if (query.Any()) return query.First().AMT;
            return sql.Max(p => p.AMT);
        }
        public decimal GetLabAmt(decimal Salary)
        {
            var sql = from a in insurlvList where DateTime.Now.Date >= a.EFF_DATEL && DateTime.Now.Date <= a.LFF_DATEL select a;
            var query = from a in sql where a.AMT >= Salary select a;
            if (query.Any()) return query.First().AMT;
            return sql.Max(p => p.AMT);
        }
        public decimal GetHeaAmt(decimal Salary)
        {

            var sql = from a in insurlvList where DateTime.Now.Date >= a.EFF_DATEH && DateTime.Now.Date <= a.LFF_DATEH select a;
            var query = from a in sql where a.AMT >= Salary select a;
            if (query.Any()) return query.First().AMT;
            return sql.Max(p => p.AMT);
        }
        public decimal GetRetAmt(decimal Salary)
        {
            var sql = from a in insurlvList where DateTime.Now.Date >= a.EFF_DATER && DateTime.Now.Date <= a.LFF_DATER select a;
            var query = from a in sql where a.AMT >= Salary select a;
            if (query.Any()) return query.First().AMT;
            return sql.Max(p => p.AMT);
        }
    }
}
