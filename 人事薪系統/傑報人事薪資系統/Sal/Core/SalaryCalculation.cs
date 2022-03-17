using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Autofac;
using System.Windows.Forms;

namespace JBHR.Sal.Core
{
    public class SalaryCalculation : JBModule.Message.ReportStatus
    {
        string YYMM;
        string SEQ;
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
        bool   nonseq;
        public string SEQ2 { get; set; }
        public bool ProcSuper = false;
        public bool MangSuper = false;
        public bool IsCalcB = false;
        bool Prev = false;
        SalaryDate SalDate;
        SalaryMDDataContext smd = new SalaryMDDataContext();
        SalaryMDDataContext db = new SalaryMDDataContext();
        List<WAGED> wagedList;
        public dynamic dyna = new JObject();
        IQueryable<string> nobrList;
        private List<SALCODE> salcodeData;
        Dictionary<string, decimal> WorkDaysList;
        List<WAGE> wageList;
        public BackgroundWorker BW;
        public JBModule.Data.ApplicationConfigSettings AppConfig = null;
        public JBModule.Data.ApplicationConfigSettings OtAppConfig = null;
        public bool isReExpsup = false;
		public Guid guid = Guid.Empty;
        Dictionary<string, string> EmpDataGroupMappingTable = new Dictionary<string, string>();
        Dictionary<string, decimal> TaxRateByNobr = new Dictionary<string, decimal>();
        public SalaryCalculation(string yymm, string seq, string nobr_b, string nobr_e, string dept_b, string dept_e,
            DateTime date_b, DateTime date_e, DateTime AttDateB, DateTime AttDateE, DateTime TransDate, string SalAdr,
            bool MangSuper, bool ProcSuper, string SalType, bool prev, DateTime InEDate)
        {
            this.SEQ2 = "";
            smd.CommandTimeout = 200;
            db.CommandTimeout = 200;
            this.YYMM = yymm;
            this.SEQ = seq;
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
            wagedList = new List<WAGED>();
            db = new SalaryMDDataContext();
            smd = new SalaryMDDataContext();
            var basettsSQL = from a in smd.BASETTS
                             join b in smd.DEPT on a.DEPT equals b.D_NO
                             where a.NOBR.CompareTo(nobr_b) >= 0 && a.NOBR.CompareTo(nobr_e) <= 0
                             && b.D_NO_DISP.CompareTo(dept_b) >= 0 && b.D_NO_DISP.CompareTo(dept_e) <= 0
                             select a;
            if (!ProcSuper) basettsSQL = from a in basettsSQL where a.SALADR == SalAdr select a;
            nobrList = from row in basettsSQL select row.NOBR;
            salcodeData = smd.SALCODE.ToList();
            WorkDaysList = new Dictionary<string, decimal>();
            JBHRIS.BLL.Bas.BasettsFixDdateDao bfd = new JBHRIS.BLL.Bas.BasettsFixDdateDao(db.Connection);
            var ErrorData = bfd.GetErrorData();
            foreach (var it in ErrorData)
                bfd.FixData(it);
        }
        public void Calc(bool CalcTeco, bool CreateAbs, bool CalcAbs, bool CalcOt, bool CalcIns, bool CalNonFreq,bool CalExpSup)
        {
            JArray State = new JArray();
            try
            {
                setProgress(0, "初始化");
                OtAppConfig = new JBModule.Data.ApplicationConfigSettings("FRM4B", MainForm.COMPANY);
                AppConfig = new JBModule.Data.ApplicationConfigSettings("FRM4I", MainForm.COMPANY);
                nonseq = CalNonFreq; 
                WorkDaysList = new Dictionary<string, decimal>();
                wagedList = new List<WAGED>();
                wageList = new List<WAGE>();
                db = new SalaryMDDataContext();
                smd = new SalaryMDDataContext();

                //setProgress(0, "刪除非經常性期別資料");
                //State.Add("刪除非經常性期別資料");
                //if (nonseq )
                //    DeleteNonFeqSEQ();
                setProgress(0, "刪除資料");
                State.Add("刪除資料");
                DeleteAll();
                setProgress(0, "计算薪資公式");
                State.Add("计算薪資公式");
                SalFunction();
                setProgress(0, "計算基本薪資");
                State.Add("計算基本薪資");
                BaseSalary();
                setProgress(0, "計算上月計薪後到職基本薪資");
                State.Add("計算上月計薪後到職基本薪資");
                //setProgress(0, "計算輪班津貼月給");
                //State.Add("計算輪班津貼月給");
                //AllowanceOfMonthCalc();
                //setProgress(0, "計算輪班津貼");
                //AllowanceCalc();
                setProgress(0, "匯入班別津貼");
                State.Add("匯入班別津貼");
                ImportSalAttCalc();
                setProgress(0, "計算全勤獎金");
                State.Add("計算全勤獎金");
                //FullAttend();
                setProgress(0, "計算介紹獎金");
                State.Add("計算介紹獎金");
                IntroductorBonusCalc();
                setProgress(0, "計算外籍伙食津貼");
                State.Add("計算外籍伙食津貼");
                ForeignFoodCalc();
                setProgress(0, "匯入變動薪資");
                State.Add("匯入變動薪資");
                SalbastdCalc1();
                setProgress(0, "檢查伙食津貼上限");
                State.Add("檢查伙食津貼上限");
                CheckFoodAmtMax();
                if (this.SEQ.Trim() == "2" && Prev)
                    PrevBaseSalaryCalc();
                setProgress(0, "匯入補扣發");
                State.Add("匯入補扣發");
                ImportEnrich();

                if (CalcAbs)
                {
                    setProgress(0, "計算請假扣款");
                    State.Add("計算請假扣款");
                    AbsCalculation absCalc = new AbsCalculation(NOBR_B, NOBR_E, DEPT_B, DEPT_E, YYMM, ATT_DATE_B, ATT_DATE_E, SEQ);
                    absCalc.StatusChanged += new JBModule.Message.ReportStatus.StatusChangedEvent(Calc_StatusChanged);
                    absCalc.CreateAbs = false;//停用,改於請假資料做批次產生
                    absCalc.WagedList = wagedList.ToList();
                    absCalc.guid = guid;
                    absCalc.Run();
                }
                setProgress(0, "匯入請假扣款");
                State.Add("匯入請假扣款");
                ImportSalabs();

                if (CalcOt)
                {
                    setProgress(0, "計算加班費");
                    State.Add("計算加班費");
                    OtCalculation otCalc = new OtCalculation(NOBR_B, NOBR_E, DEPT_B, DEPT_E, YYMM, SEQ);
                    otCalc.StatusChanged += new JBModule.Message.ReportStatus.StatusChangedEvent(Calc_StatusChanged);
                    otCalc.WagedList = wagedList;
                    otCalc.guid = guid;
                    otCalc.Run();
                }
                setProgress(0, "匯入加班費");
                State.Add("匯入加班費");
                ImportOt();
                if (CalcIns)
                {
                    setProgress(0, "計算保險費");
                    State.Add("計算保險費");
                    Inslab.Inslab.backgroundWorker = BW;
                    Inslab.Inslab.guid = guid;
                    Inslab.Inslab.Calc(YYMM, NOBR_B, NOBR_E, DEPT_B, DEPT_E, InEDate, Prev);
                }
                setProgress(0, "計算福利金");
                State.Add("計算福利金");
                WelCalc();
                setProgress(0, "計算最低保障薪");
                State.Add("計算最低保障薪");
                MinWageCalc();
                setProgress(0, "匯入勞健保費");
                State.Add("匯入勞健保費");
                ImportInslab();
                //setProgress(0, "產生薪資主檔");
                //CreateWage();
                //setProgress(0, "計算補充保費");
                //CreateExpSup();
                 if (nonseq) //計算非經常性期別資料
                {
                     smd = new SalaryMDDataContext();
                    setProgress(0, "置換期別");
                    State.Add("置換期別");
                    ChangeSeq();
                    //setProgress(0, "計算非經常性期別所得稅");
                    //State.Add("計算非經常性期別所得稅");
                    //TaxCalc(true, YYMM, nonseq, true); //計算非經常性期別所得稅
                    //setProgress(0, "檢核所得稅");
                    //State.Add("檢核所得稅");
                    //CHKTaxCalc(YYMM, nonseq); //檢核應稅薪資
                }

                if (CalcTeco)
                {
                    setProgress(0, "計算銀行代扣");
                    State.Add("計算銀行代扣");
                    TecoCalc();
                    setProgress(0, "匯入銀行代扣");
                    State.Add("匯入銀行代扣");
                    ImportWagedd();
                }

                setProgress(0, "計算所得稅");
                State.Add("計算所得稅");
                TaxCalc(true, YYMM, SEQ);

                if (this.IsCalcB)
                {
                    setProgress(0, "薪資調節作業");
                    State.Add("薪資調節作業");
                    CalcB();
                    WagePartition();
                    DeleteWage();
                    db = new SalaryMDDataContext();
                    smd = new SalaryMDDataContext();
                    CreateWage();
                }
                else
                {
                    setProgress(0, "產生薪資主檔");
                    State.Add("產生薪資主檔");
                    CreateWage();
                }

                if (CalExpSup)
                {
                    setProgress(0, "產生補充保費");
                    State.Add("產生補充保費");
                    CreateExpSup();
                }
                //setProgress(0, "計算所得稅");
                //State.Add("計算所得稅");
                //TaxCalc(true, YYMM, SEQ);

                setProgress(0, "匯入已發扣回");
                State.Add("匯入已發扣回");
                ImportDeductSeq();

                setProgress(0, "寫入資料庫");
                State.Add("寫入資料庫");
                WriteToDB();

                setProgress(100, "完成");
            }
            catch (Exception ex)
            {
                dyna.extime = DateTime.Now;
                dyna.exception = ex.StackTrace;
                dyna.state = State;
                string prgname = dyna.prgname;
                string userid = dyna.userid;
                string message = ex.Message;
                DateTime key_date = dyna.key_date;
                Guid guid = dyna.guid;
                string dynaStr = dyna.ToString(Formatting.None);
                JBModule.Message.DbLog.WriteToDB(message, dynaStr, "err", prgname, -1, userid, guid.ToString());
                MessageBox.Show(string.Format("{0}錯誤:{1}", State[State.Count - 1].ToString(), message),"錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //setProgress(100, BW + "失敗");
            }
        }
        private void WagePartition()
        {
            foreach (var it in wagedList)
            {
                it.SEQ = SEQ2;//置換期別
            }
            List<WAGED> wagedListB = new List<WAGED>();
            foreach (var waged in sc.wagedList)
            {
                wagedListB.Add(new WAGED
                {
                    AMT = waged.AMT,
                    NOBR = waged.NOBR,
                    SEQ = waged.SEQ,
                    SAL_CODE = waged.SAL_CODE,
                    YYMM = waged.YYMM,
                });
                var wagedOriginal = wagedList.SingleOrDefault(p => p.YYMM == waged.YYMM && p.NOBR == waged.NOBR && p.SAL_CODE == waged.SAL_CODE);
                if (wagedOriginal != null)
                {
                    wagedOriginal.AMT = JBModule.Data.CEncrypt.Number(JBModule.Data.CDecryp.Number(wagedOriginal.AMT) - JBModule.Data.CDecryp.Number(waged.AMT));
                }
                else
                {
                    JBModule.Message.TextLog.WriteLog(new Exception("找不到可置換的薪資明細"), waged);
                }
            }
            wagedList.AddRange(wagedListB);
        }
        SalaryCalculation_B sc;
        private void CalcB()
        {
            sc = new SalaryCalculation_B
                     (YYMM, SEQ, this.SEQ, NOBR_B, NOBR_E, DEPT_B, DEPT_E, DATE_B, DATE_E, ATT_DATE_B, ATT_DATE_E, this.TRANS_DATE, " MainForm.WORKADR", false, false, this.Type, Prev, InEDate);
            sc.ImportWagedToB(this.wagedList);
            //sc.AppConfig = config;
            sc.OtAppConfig = new JBModule.Data.ApplicationConfigSettings("FRM4B", MainForm.COMPANY);
            sc.Calc(true, true, true, true);
        }

        private void ForeignFoodCalc()
        {
            //"ForeignFoodAmt"
            //"ForeignFoodRote"
            //"ForeignFoodSalcode"
            //"ForeignFoodSalcodeTax"
            //"ForeignFoodNuTaxMaxAmt"
            //"ForeignFoodNuAddAmt"
            AppConfig = new JBModule.Data.ApplicationConfigSettings("FRM4I", MainForm.COMPANY);
            decimal defaultAmt = AppConfig.GetConfig("ForeignFoodAmt").GetDecimal(0);
            decimal ForeignFoodNuTaxMaxAmt = AppConfig.GetConfig("ForeignFoodNuTaxMaxAmt").GetDecimal(0);
            decimal ForeignFoodNuAddAmt = AppConfig.GetConfig("ForeignFoodNuAddAmt").GetDecimal(0);
            string[] ForeignFoodRotetList = AppConfig.GetConfig("ForeignFoodRotet").GetString("").Split(',');
            string ForeignFoodSalcode = AppConfig.GetConfig("ForeignFoodSalcode").GetString("");
            string ForeignFoodSalcodeTax = AppConfig.GetConfig("ForeignFoodSalcodeTax").GetString("");
            List<string> ttscodeList = new List<string>();
            ttscodeList.Add("1");
            ttscodeList.Add("4");
            ttscodeList.Add("6");
            var basettsSQL = from a in smd.BASETTS
                             join b in smd.DEPT on a.DEPT equals b.D_NO
                             join c in smd.BASE on a.NOBR equals c.NOBR
                             join d in smd.ROTET on a.ROTET equals d.ROTET1
                             where a.NOBR.CompareTo(NOBR_B) >= 0 && a.NOBR.CompareTo(NOBR_E) <= 0
                             //&& smd.GetFilterByNobr(a.NOBR, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value
                             && smd.UserReadDataGroupList(MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Select(p => p.DATAGROUP).Contains(a.SALADR)
                             && ttscodeList.Contains(a.TTSCODE)
                             && ATT_DATE_B <= a.DDATE && ATT_DATE_E >= a.ADATE
                             && b.D_NO_DISP.CompareTo(DEPT_B) >= 0 && b.D_NO_DISP.CompareTo(DEPT_E) <= 0
                             && ForeignFoodRotetList.Contains(d.ROTET_DISP)
                             && c.COUNT_MA
                             select a;
            var EmpList = basettsSQL.Select(p => p.NOBR).Distinct();
            List<string> Holiday = CodeFunction.GetHolidayRoteList();
            var attendSql = from a in smd.ATTEND
                            join b in smd.OT on a.NOBR equals b.NOBR
                            where a.ADATE >= ATT_DATE_B && a.ADATE <= ATT_DATE_E
                            && a.ADATE == b.BDATE
                            && Holiday.Contains(a.ROTE)
                            select a;
            foreach (var nobr in EmpList)
            {
                decimal Amt = defaultAmt;
                var otDay = attendSql.Where(p => p.NOBR == nobr).Distinct().Count();
                Amt -= otDay * ForeignFoodNuAddAmt;
                #region 改成在InsertWaged做
                //if (Amt <= 0) continue;
                //decimal disCount = Amt > ForeignFoodNuTaxMaxAmt ? Amt - ForeignFoodNuTaxMaxAmt : 0;
                //Amt -= disCount;
                //if (disCount > 0)
                //{//應稅項目
                //    WAGED waged = new WAGED();
                //    waged.AMT = JBModule.Data.CEncrypt.Number(disCount);
                //    waged.NOBR = nobr;
                //    waged.SAL_CODE = ForeignFoodSalcodeTax;
                //    waged.SEQ = SEQ;
                //    waged.YYMM = YYMM;
                //    InsertWaged(waged);
                //}
                #endregion
                if (Amt > 0)
                {//免稅項目
                    WAGED waged = new WAGED();
                    waged.AMT = JBModule.Data.CEncrypt.Number(Amt);
                    waged.NOBR = nobr;
                    waged.SAL_CODE = ForeignFoodSalcode;
                    waged.SEQ = SEQ;
                    waged.YYMM = YYMM;
                    InsertWaged(waged);
                }
            }
        }

        void Calc_StatusChanged(object sender, JBModule.Message.StatusEventArgs e)
        {
            if (BW != null)
            {
                BW.ReportProgress(e.Percent, e.Result);
            }
        }
        public void DeleteAll()
        {
            DeleteWage(SEQ);
            DeleteWage(SEQ2);
            DeleteWaged(SEQ);
            DeleteWaged(SEQ2);
        }
        //public void DeleteNonFeqSEQ(string nonseq)
        //{
        //    //       JBModule.Data.ApplicationConfigSettings Frm4iAppConfig = null;
        //   AppConfig = new JBModule.Data.ApplicationConfigSettings("FRM4I", MainForm.COMPANY);
        //     nonseq = AppConfig.GetConfig("SalNonFrqSEQ").GetString(""); 
      
            

        //    object[] objArray = new object[] { YYMM, nonseq, NOBR_B, NOBR_E, DEPT_B, DEPT_E, SALADR, DATE_E };//刪除薪資
        //    int i = 0;
        //     string cmd = " DELETE FROM WAGE  FROM  WAGE ,WAGED B,SALCODE C  WHERE WAGE.NOBR= B.NOBR  AND WAGE.YYMM = B.YYMM AND WAGE.SEQ = B.SEQ AND B.SAL_CODE = C.SAL_CODE AND "
        //         + " EXISTS(SELECT 1 FROM BASETTS A JOIN DEPT B ON A.DEPT=B.D_NO WHERE CONVERT(DATETIME,CONVERT(NVARCHAR(50), {7},101)) BETWEEN A.ADATE AND A.DDATE "
        //        + " AND A.NOBR BETWEEN {2} AND {3} AND B.D_NO_DISP BETWEEN {4} AND {5} AND A.NOBR=WAGE.NOBR)"
        //      //  + "  and C.NOTFREQSEQ = Convert(bit,1)  "
        //        + " and WAGE.yymm={0} and WAGE.seq={1} " + " AND " + Sal.Function.GetFilterCmdByNobrOfWrite("WAGE.nobr");
        //     i = smd.ExecuteCommand(cmd, objArray);

        //     cmd = " DELETE FROM WAGED  FROM WAGED  ,SALCODE C  WHERE   WAGED.SAL_CODE = C.SAL_CODE AND "
        //        + " EXISTS(SELECT 1 FROM BASETTS A JOIN DEPT B ON A.DEPT=B.D_NO WHERE CONVERT(DATETIME,CONVERT(NVARCHAR(50), {7},101)) BETWEEN A.ADATE AND A.DDATE "
        //       + " AND A.NOBR BETWEEN {2} AND {3} AND B.D_NO_DISP BETWEEN {4} AND {5} AND A.NOBR=WAGED.NOBR)"
        //   //    + "  and C.NOTFREQSEQ = Convert(bit,1)  "
        //       + " and WAGED.yymm={0} and WAGED.seq={1} " + " AND " + Sal.Function.GetFilterCmdByNobrOfWrite("WAGED.nobr");
        //    i = smd.ExecuteCommand(cmd, objArray);
 
        //}

        public void DeleteNonFeqSEQ()
        {
            AppConfig = new JBModule.Data.ApplicationConfigSettings("FRM4I", MainForm.COMPANY);
            object[] objArray = new object[] { YYMM,true , NOBR_B, NOBR_E, DEPT_B, DEPT_E, SALADR, DATE_E };//刪除薪資
            int i = 0;
            string cmd = " DELETE FROM WAGE  FROM  WAGE ,WAGED B,SALCODE C  WHERE WAGE.NOBR= B.NOBR  AND WAGE.YYMM = B.YYMM AND WAGE.SEQ = B.SEQ AND B.SAL_CODE = C.SAL_CODE AND "
                + " EXISTS(SELECT 1 FROM BASETTS A JOIN DEPT B ON A.DEPT=B.D_NO WHERE CONVERT(DATETIME,CONVERT(NVARCHAR(50), {7},101)) BETWEEN A.ADATE AND A.DDATE "
               + " AND A.NOBR BETWEEN {2} AND {3} AND B.D_NO_DISP BETWEEN {4} AND {5} AND A.NOBR=WAGE.NOBR)"
          //     + "  and C.NOTFREQSEQ = Convert(bit,1)  "
               + " and WAGE.yymm={0} and WAGE.seq={1} " + " AND " + Sal.Function.GetFilterCmdByNobrOfWrite("WAGE.nobr");
            i = smd.ExecuteCommand(cmd, objArray);

            cmd = " DELETE FROM WAGED  FROM WAGED  ,SALCODE C  WHERE   WAGED.SAL_CODE = C.SAL_CODE AND "
               + " EXISTS(SELECT 1 FROM BASETTS A JOIN DEPT B ON A.DEPT=B.D_NO WHERE CONVERT(DATETIME,CONVERT(NVARCHAR(50), {7},101)) BETWEEN A.ADATE AND A.DDATE "
              + " AND A.NOBR BETWEEN {2} AND {3} AND B.D_NO_DISP BETWEEN {4} AND {5} AND A.NOBR=WAGED.NOBR)"
              //+ "  and C.NOTFREQSEQ = Convert(bit,1)  "
              + " and WAGED.yymm={0} and WAGED.seq={1} " + " AND " + Sal.Function.GetFilterCmdByNobrOfWrite("WAGED.nobr");
            i = smd.ExecuteCommand(cmd, objArray);
         }
         public void DeleteWage(string Seq = "")
        {
            if (Seq == "")
                Seq = SEQ;
            object[] objArray = new object[] { YYMM, Seq, NOBR_B, NOBR_E, DEPT_B, DEPT_E, SALADR, DATE_E };
            int i = 0;
            string saladr = "";
            //if (!ProcSuper) saladr = " and saladr={6} ";
            string cmd = "DELETE WAGE WHERE "
                //+ "nobr in (select nobr from basetts "
                //+ "where nobr between {2} and {3} and dept between {4} and {5} )"
                + " EXISTS(SELECT 1 FROM BASETTS A JOIN DEPT B ON A.DEPT=B.D_NO WHERE CONVERT(DATETIME,CONVERT(NVARCHAR(50), {7},101)) BETWEEN A.ADATE AND A.DDATE "
                + " AND A.NOBR BETWEEN {2} AND {3} AND B.D_NO_DISP BETWEEN {4} AND {5} AND A.NOBR=WAGE.NOBR)"
                + " and yymm={0} and seq={1} " + " AND " + Sal.Function.GetFilterCmdByNobrOfWrite("wage.nobr");

            i = smd.ExecuteCommand(cmd, objArray);
            DeleteExpSup();

            //objArray = new object[] { YYMM, SEQ2, NOBR_B, NOBR_E, DEPT_B, DEPT_E, SALADR };
            //i = smd.ExecuteCommand(cmd, objArray);
            //cmd = "delete waged where nobr in (select nobr from basetts " +
            //   "where nobr between {2} and {3} and dept between {4} and {5} " + saladr + ") and yymm={0} and seq={1} ";

            //i = smd.ExecuteCommand(cmd, objArray);
        }
        public void DeleteWaged(string Seq = "")
        {
            if (Seq == "")
                Seq = SEQ;
            object[] objArray = new object[] { YYMM, Seq, NOBR_B, NOBR_E, DEPT_B, DEPT_E, SALADR, DATE_E };
            int i = 0;
            //waged seq
            string cmd = "DELETE WAGED WHERE"
                // +"where nobr in (select nobr from basetts " +
                //"where nobr between {2} and {3} and dept between {4} and {5} )"
                + " EXISTS(SELECT 1 FROM BASETTS A JOIN DEPT B ON A.DEPT=B.D_NO WHERE CONVERT(DATETIME,CONVERT(NVARCHAR(50), {7},101)) BETWEEN A.ADATE AND A.DDATE "
                + " AND A.NOBR BETWEEN {2} AND {3} AND B.D_NO_DISP BETWEEN {4} AND {5} AND A.NOBR=WAGED.NOBR)"
               + " and yymm={0} and seq={1} "
               + " AND " + Sal.Function.GetFilterCmdByNobrOfWrite("waged.nobr");
            i = smd.ExecuteCommand(cmd, objArray);

            //waged seq2
            //objArray = new object[] { YYMM, SEQ2, NOBR_B, NOBR_E, DEPT_B, DEPT_E, SALADR };
            //i = smd.ExecuteCommand(cmd, objArray);

            //salbasd1
            objArray = new object[] { YYMM, Seq, NOBR_B, NOBR_E, DEPT_B, DEPT_E, SALADR };
            //cmd = "delete salbasd1 WHERE"
            //    + " EXISTS(SELECT 1 FROM BASETTS A JOIN DEPT B ON A.DEPT=B.D_NO WHERE CONVERT(DATETIME,CONVERT(NVARCHAR(50), GETDATE(),101)) BETWEEN A.ADATE AND A.DDATE "
            //    + " AND A.NOBR BETWEEN {2} AND {3} AND B.D_NO_DISP BETWEEN {4} AND {5} AND A.NOBR=salbasd1.NOBR)"
            //   + " and yymm={0} and seq={1} " + " AND " + Sal.Function.GetFilterCmdByNobrOfWrite("SALBASD1.nobr");
            cmd = Function.DeleteCommand("SALBASD1", NOBR_B, NOBR_E, DEPT_B, DEPT_E) + " AND YYMM={0} AND SEQ={1}";
            i = smd.ExecuteCommand(cmd, objArray);
        }
        void DeleteTeco()
        {
            SalaryMDDataContext db = new SalaryMDDataContext();
            object[] PARMS = new object[] { NOBR_B, NOBR_E, DEPT_B, DEPT_E, " MainForm.WORKADR", " MainForm.PROCSUPER", YYMM, SEQ };
            db.ExecuteCommand("DELETE WAGEDD WHERE "
                             + "EXISTS(SELECT * FROM BASETTS A JOIN DEPT B ON A.DEPT=B.D_NO"
                             + " WHERE A.NOBR BETWEEN {0} AND {1} AND B.D_NO_DISP BETWEEN {2} AND {3} AND WAGEDD.NOBR=A.NOBR ) AND YYMM={6} AND SEQ={7}"
                             + " AND " + Sal.Function.GetFilterCmdByNobr("wagedd.nobr"), PARMS);
        }
        public void DeleteExpSup()
        {
            SalaryMDDataContext db = new SalaryMDDataContext();
            object[] PARMS = new object[] { NOBR_B, NOBR_E, DEPT_B, DEPT_E, MainForm.WORKADR, MainForm.PROCSUPER, YYMM, SEQ };
            string CMD = "DELETE EXPSUP WHERE "
                + "EXISTS(SELECT * FROM BASETTS A JOIN DEPT B ON A.DEPT=B.D_NO"
                             + " WHERE A.NOBR BETWEEN {0} AND {1} AND B.D_NO_DISP BETWEEN {2} AND {3} AND EXPSUP.NOBR=A.NOBR) AND YYMM={6} AND SEQ={7}"
                + " AND " + Sal.Function.GetFilterCmdByNobr("EXPSUP.NOBR");
            CMD = Function.DeleteCommand("EXPSUP", NOBR_B, NOBR_E, DEPT_B, DEPT_E) + " AND YYMM={6} AND SEQ={7}";
            db.ExecuteCommand(CMD, PARMS);
        }
        //public void ChangeSeq(string nonseq )
        //{
        //    var waged = (from a in wagedList
        //                 join b in db.SALCODE.ToList() on a.SAL_CODE equals b.SAL_CODE
        //                 where b.NOTFREQSEQ
        //                 group new { a.NOBR } by a.NOBR).ToList();
        //    foreach (var it in waged)
        //    {
        //        var cwage = (from a in wageList where a.NOBR == it.Key && a.YYMM == YYMM && a.SEQ == SEQ  select a).ToList(); //發薪期別
        //        foreach (var wlist in cwage)
        //        {
        //            WAGE wage = new WAGE();
        //            wage.NOBR = wlist.NOBR;
        //            wage.KEY_DATE = DateTime.Now;
        //            wage.KEY_MAN = MainForm.USER_NAME;
        //            wage.NOTE = wlist.NOTE;
        //            wage.SALADR = wlist.SALADR;
        //            wage.SEQ = nonseq;
        //            wage.TAXRATE = wlist.TAXRATE;
        //            wage.WK_DAYS = wlist.WK_DAYS;
        //            wage.YYMM = YYMM;
        //            wage.ACCOUNT_NO = wlist.ACCOUNT_NO;
        //            wage.ADATE = TRANS_DATE;
        //            wage.BANKNO = wlist.BANKNO;
        //            wage.CASH = wlist.CASH;
        //            wage.ACCOUNT_NO = wlist.ACCOUNT_NO;
        //            wage.COMP = wlist.COMP;
        //            wage.DATE_B = DATE_B;
        //            wage.DATE_E = DATE_E;
        //            wage.ATT_DATEB = ATT_DATE_B;
        //            wage.ATT_DATEE = ATT_DATE_E;
        //            wage.FORMAT = wlist.FORMAT;
        //            db.WAGE.InsertOnSubmit(wage);
        //        }
        //        db.SubmitChanges();
        //        var cwaged = (from a in wagedList
        //                      join b in db.SALCODE.ToList() on a.SAL_CODE equals b.SAL_CODE
        //                      where a.NOBR == it.Key && b.NOTFREQSEQ
        //                      && a.YYMM == YYMM && a.SEQ == SEQ
        //                      select a).ToList();
        //         foreach (var w in cwaged)
        //        {
        //            WAGED wagedlst = new WAGED();
        //            wagedlst.AMT = w.AMT;
        //            wagedlst.NOBR = w.NOBR; ;
        //            wagedlst.SAL_CODE = w.SAL_CODE;
        //            wagedlst.SEQ = nonseq;
        //            wagedlst.YYMM = YYMM;
        //            db.WAGED.InsertOnSubmit(wagedlst);
        //            db.SubmitChanges();
        //        }
        //        db.SubmitChanges();

        //    }
        //}
        public void ChangeSeq()
        {
            var waged = (from a in wagedList
                         join b in db.SALCODE.ToList() on a.SAL_CODE equals b.SAL_CODE
                         where b.NOTFREQSEQ && b.SALSEQ.Trim().Length > 0
                         group new { a.NOBR, a.SAL_CODE, a.YYMM, b.SALSEQ } by new { a.NOBR, a.SAL_CODE, a.YYMM, b.SALSEQ }).ToList();
            var wagedgrp = from a in waged group a by new { a.Key.YYMM, a.Key.SALSEQ, a.Key.SAL_CODE }; //刪除原有非經常性薪資期別
             foreach (var item in wagedgrp)
            {
                var DelsALENRICHes = from salenrich in db.SALENRICH
                                     join basetts in db.BASETTS on salenrich.NOBR equals basetts.NOBR
                                     join dept in db.DEPT on basetts.DEPT equals dept.D_NO
                                     where DATE_E >= basetts.ADATE && DATE_E <= basetts.DDATE.Value
                                     && salenrich.NOBR.CompareTo(NOBR_B) >= 0 && salenrich.NOBR.CompareTo(NOBR_E) <= 0
                                     && dept.D_NO_DISP.CompareTo(DEPT_B) >= 0 && dept.D_NO_DISP.CompareTo(DEPT_E) <= 0
                                     && salenrich.YYMM ==item.Key.YYMM 
                                     && salenrich.SAL_CODE == salenrich.SAL_CODE 
                                     && salenrich.SEQ == item.Key.SALSEQ
                                     select salenrich;
                db.SALENRICH.DeleteAllOnSubmit(DelsALENRICHes);
                db.SubmitChanges();
             }
             foreach (var it in waged)
            {
                decimal camt = 0.0M;
                camt = wagedList.Where(x => x.NOBR == it.Key.NOBR && x.YYMM == it.Key.YYMM && x.SAL_CODE == it.Key.SAL_CODE && x.SEQ == SEQ).Sum(xp => JBModule.Data.CDecryp.Number(xp.AMT));
                wagedList.Where(x => x.NOBR == it.Key.NOBR && x.YYMM == it.Key.YYMM && x.SAL_CODE == it.Key.SAL_CODE && x.SEQ == SEQ).ToList();
                var sALENRICHes = from x in db.SALENRICH where x.NOBR == it.Key.NOBR && x.YYMM == it.Key.YYMM && x.SAL_CODE == it.Key.SAL_CODE && x.SEQ == it.Key.SALSEQ  select x;
                db.SALENRICH.DeleteAllOnSubmit(sALENRICHes);
                db.SubmitChanges();

                SALENRICH sALENRICH = new SALENRICH();
                sALENRICH.NOBR = it.Key.NOBR;
                sALENRICH.YYMM = it.Key.YYMM;
                sALENRICH.SEQ = it.Key.SALSEQ;
                sALENRICH.SAL_CODE = it.Key.SAL_CODE;
                sALENRICH.AMT = JBModule.Data.CEncrypt.Number(camt);
                sALENRICH.KEY_DATE = DateTime.Now;
                sALENRICH.KEY_MAN = MainForm.USER_NAME;
                sALENRICH.MEMO = "";
                sALENRICH.FA_IDNO = "";
                sALENRICH.IMPORT = true;
                db.SALENRICH.InsertOnSubmit(sALENRICH);
                var csalenrich = (from a in wagedList
                                  where a.NOBR == it.Key.NOBR
                                 && a.YYMM == it.Key.YYMM
                                 && a.SEQ == SEQ
                                 && a.SAL_CODE == it.Key.SAL_CODE
                                  select a).ToList<JBHR.Sal.WAGED>();
                foreach (var item in csalenrich) wagedList.Remove(item);
            }

        }

        public void CHKTaxCalc(string calyymm, string calseq, bool GetfromDB = false)
        {
            //   JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
            string TaxSalcode = "";


            var calnobrList_full = (from wagedItem in db.WAGED
                              join salcode in db.SALCODE on wagedItem.SAL_CODE equals salcode.SAL_CODE
                              join salattr in db.SALATTR on salcode.SAL_ATTR equals salattr.SALATTR1
                              join basetts in db.BASETTS on wagedItem.NOBR equals basetts.NOBR
                              join dept in db.DEPT on basetts.DEPT equals dept.D_NO
                              where wagedItem.YYMM == calyymm && wagedItem.SEQ == calseq
                              && wagedItem.NOBR.CompareTo(NOBR_B) >= 0 && wagedItem.NOBR.CompareTo(NOBR_E) <= 0
                             && dept.D_NO_DISP.CompareTo(DEPT_B) >= 0 && dept.D_NO_DISP.CompareTo(DEPT_E) <= 0
                             && DATE_E >= basetts.ADATE && DATE_E <= basetts.DDATE.Value
                              select new { wagedItem, salattr.FLAG, salattr.TAX, salcode.TAXRATE } ).ToList();  //應稅加班
            var calnobrList = calnobrList_full.GroupBy(p => p.wagedItem.NOBR);

            var waged = (from wagedItem in db.WAGED
                         join salcode in db.SALCODE on wagedItem.SAL_CODE equals salcode.SAL_CODE
                         join salattr in db.SALATTR on salcode.SAL_ATTR equals salattr.SALATTR1
                         join basetts in db.BASETTS on wagedItem.NOBR equals basetts.NOBR
                         join dept in db.DEPT on basetts.DEPT equals dept.D_NO
                         where wagedItem.YYMM == YYMM && wagedItem.SEQ == SEQ
                         && wagedItem.NOBR.CompareTo(NOBR_B) >= 0 && wagedItem.NOBR.CompareTo(NOBR_E) <= 0
                        && dept.D_NO_DISP.CompareTo(DEPT_B) >= 0 && dept.D_NO_DISP.CompareTo(DEPT_E) <= 0
                        && DATE_E >= basetts.ADATE && DATE_E <= basetts.DDATE.Value //應稅薪資
                         select wagedItem).ToList();
            foreach (var nobrItem in calnobrList)
            {
                decimal nontoltaxamt = 0.0M;
                decimal damt = 0.0M;
                decimal taxamt = 0.0M;
                var nontoltax = nobrItem.Where(p => p.wagedItem.NOBR == nobrItem.Key );
                foreach (var Item in nontoltax)
                {
                     TaxSalcode = Item.wagedItem.SAL_CODE;
                    if (nontoltax.Any())
                            nontoltaxamt = nontoltax.Where(p=>p.wagedItem.SAL_CODE == TaxSalcode).Sum(p => JBModule.Data.CDecryp.Number(p.wagedItem.AMT)); //應稅加班所得稅
                        else
                            continue;
                        var toltaxamt = from a in waged where a.NOBR == nobrItem.Key && a.SAL_CODE== TaxSalcode  select new { amt = Convert.ToDecimal(a.AMT) };
                        if (toltaxamt.Any())
                            taxamt = toltaxamt.Sum(p => JBModule.Data.CDecryp.Number(p.amt));
                        damt = taxamt - nontoltaxamt;

                        var updatewaged = (from a in db.WAGED
                                           where a.NOBR == nobrItem.Key
                                                               && a.SAL_CODE == TaxSalcode //MainForm.TaxConfig.TAXSALCODE
                                                               && a.YYMM == YYMM && a.SEQ == SEQ
                                           select a).FirstOrDefault();
                        if (updatewaged != null)
                            updatewaged.AMT = JBModule.Data.CEncrypt.Number(damt);
                        var taxot = from a in db.WAGED
                                    where a.NOBR == nobrItem.Key
                                             && a.SAL_CODE == TaxSalcode
                                             && a.YYMM == YYMM && a.SEQ == SEQ
                                    select a;
                    if (damt==0)  db.WAGED.DeleteAllOnSubmit(taxot);

                        db.SubmitChanges();
                }
            
       
            }
        }
     public void SalFunction()
        {
            JBModule.Data.CalcSalaryByFunction calcSalary = new JBModule.Data.CalcSalaryByFunction();
            var sql = (from a in db.BASE
                      join b in db.BASETTS on a.NOBR equals b.NOBR
                      join c in db.DEPT on b.DEPT equals c.D_NO
                      join b1 in db.BASETTS on a.NOBR equals b1.NOBR
                      //join d in db.WriteRuleTable(MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN) on a.NOBR equals d.NOBR
					  //join wrnt in db.WriteRuleNobrTable.Where(p => p.GUID == guid) on a.NOBR equals wrnt.EMPID																						   
                      where DATE_E >= b.ADATE && DATE_E <= b.DDATE
                      && c.D_NO_DISP.CompareTo(DEPT_B) >= 0 && c.D_NO_DISP.CompareTo(DEPT_E) <= 0
                      && b.NOBR.CompareTo(NOBR_B) >= 0 && b.NOBR.CompareTo(NOBR_E) <= 0
                      && new string[] { "1", "4", "6" }.Contains(b1.TTSCODE)
                      && (DATE_E >= b1.ADATE && b1.DDATE >= DATE_B
                      || ATT_DATE_E >= b1.ADATE && b1.DDATE >= ATT_DATE_B) //包含當月離離人員
                      && db.UserReadDataGroupList(MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Select(p => p.DATAGROUP).Contains(b.SALADR)
                      select new { a.NOBR, a.NAME_C, b.SALADR }).ToList().Distinct();
            if (!sql.Any()) return;
            foreach (var Emp in sql)
            {
                var list = calcSalary.GetCalcSalaryMsg("SAL", Emp.NOBR, YYMM, ATT_DATE_B, ATT_DATE_E, DATE_B, DATE_E, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN);
                foreach (var itm in list)
                {
                    setProgress(0, string.Format("薪資公式計算_{0}", Emp.NOBR));
                    WAGED waged = new WAGED();
                    waged.AMT = JBModule.Data.CEncrypt.Number(itm.Amt);
                    waged.NOBR = itm.Nobr;
                    waged.SAL_CODE = itm.Salcode;
                    waged.SEQ = SEQ;
                    waged.YYMM = YYMM;
                    InsertWaged(waged);
                }
            }

        }
        public void BaseSalary()
        {
            List<string> ttscodeList = new List<string>();
            ttscodeList.Add("1");
            ttscodeList.Add("4");
            ttscodeList.Add("6");
            var EmpList_full = (from a in smd.BASETTS
                           join b in smd.BASETTS on a.NOBR equals b.NOBR
                           join e in smd.DEPT on a.DEPT equals e.D_NO
						   //join wrnt in smd.WriteRuleNobrTable.Where(p => p.GUID == guid) on a.NOBR equals wrnt.EMPID																						 
                           where ttscodeList.Contains(a.TTSCODE)
                           && a.NOBR.CompareTo(NOBR_B) >= 0 && a.NOBR.CompareTo(NOBR_E) <= 0
                           && e.D_NO_DISP.CompareTo(DEPT_B) >= 0 && e.D_NO_DISP.CompareTo(DEPT_E) <= 0
                           //&& smd.GetFilterByNobr(a.NOBR, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value
                           && DATE_B <= a.DDATE.Value && DATE_E >= a.ADATE
                           && DATE_E >= b.ADATE && DATE_E <= b.DDATE.Value
                           && !b.NOWAGE//須計算薪資
                           && b.INDT <= InEDate
                           && smd.UserReadDataGroupList(MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Select(p => p.DATAGROUP).Contains(a.SALADR)
                           select new { a.NOBR, a.ADATE, a.DDATE, a.SALADR }).ToList();
            var EmpList = EmpList_full.GroupBy(p => p.NOBR);
            EmpDataGroupMappingTable = EmpList.ToDictionary(p => p.Key, p => p.First().SALADR);
            string ATTAWARDSALCODE = MainForm.SalaryConfig.ATTAWARDSALCODE;
            string DeductWage = AppConfig.GetConfig("DeductWage").GetString("");
            var salbasdList = (from a in db.SALBASD
                               join b in db.BASETTS on a.NOBR equals b.NOBR
                               join c in db.SALCODE on a.SAL_CODE equals c.SAL_CODE
                               join e in db.DEPT on b.DEPT equals e.D_NO
							   //join wrnt in db.WriteRuleNobrTable.Where(p => p.GUID == guid) on a.NOBR equals wrnt.EMPID 																						
                               where b.NOBR.CompareTo(NOBR_B) >= 0 && b.NOBR.CompareTo(NOBR_E) <= 0
                               && e.D_NO_DISP.CompareTo(DEPT_B) >= 0 && e.D_NO_DISP.CompareTo(DEPT_E) <= 0
                               && DATE_E >= b.ADATE && DATE_E <= b.DDATE.Value
                               && c.SOS_ID == "1"
                               && a.SAL_CODE != ATTAWARDSALCODE
                               && a.SAL_CODE != DeductWage
                               && !c.NOTFREQ
                               && (c.CAL_TYPE == null || c.CAL_TYPE == "")
                               && (c.SALBASE == null || c.SALBASE == "")
                               && a.ADATE <= DATE_E && a.DDATE >= DATE_B
                               && b.INDT <= InEDate
                               //&& db.GetFilterByNobr(a.NOBR, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value
                               && db.UserReadDataGroupList(MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Select(p => p.DATAGROUP).Contains(b.SALADR)
                               select new { a.NOBR, a.ADATE, a.DDATE, a.SAL_CODE, a.AMT, c.MONTHTYPE, c.CAL_FREQ, c.DEFINEDAYS }).ToList();
            //var sql = from a in smd.BASETTS
            //          join b in smd.SALBASD on a.NOBR equals b.NOBR into ab
            //          from salbasd in ab
            //          join c in smd.SALCODE on salbasd.SAL_CODE equals c.SAL_CODE
            //          join d in smd.SALATTR on c.SAL_ATTR equals d.SALATTR1
            //          join e in smd.DEPT on a.DEPT equals e.D_NO
            //          where ttscodeList.Contains(a.TTSCODE)
            //              && a.NOBR.CompareTo(NOBR_B) >= 0 && a.NOBR.CompareTo(NOBR_E) <= 0
            //              && e.D_NO_DISP.CompareTo(DEPT_B) >= 0 && e.D_NO_DISP.CompareTo(DEPT_E) <= 0
            //              && c.SAL_CODE != MainForm.SalaryConfig.ATTAWARDSALCODE
            //              && DATE_B <= a.DDATE && DATE_E >= a.ADATE
            //              && !a.NOWAGE//須計算薪資
            //              && c.SOS_ID == "1"//系統計算
            //              && !c.NOTFREQ//常態薪資
            //              && a.ADATE <= salbasd.DDATE && a.DDATE >= salbasd.ADATE
            //              && a.INDT <= InEDate
            //              && smd.GetFilterByNobr(a.NOBR, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value
            //          group new { BASETTS = a, SALBASD = salbasd, SALCODE = c } by a into gp
            //          select gp;
            var attSQL = (from a in smd.ATTEND
                          join b in smd.BASETTS on a.NOBR equals b.NOBR
                          join c in smd.tblROTE on a.ROTE equals c.ROTE1
                          join d in smd.DEPT on b.DEPT equals d.D_NO
						  //join wrnt in smd.WriteRuleNobrTable.Where(p => p.GUID == guid) on a.NOBR equals wrnt.EMPID																						
                          where b.NOBR.CompareTo(NOBR_B) >= 0 && b.NOBR.CompareTo(NOBR_E) <= 0
                          && d.D_NO_DISP.CompareTo(DEPT_B) >= 0 && d.D_NO_DISP.CompareTo(DEPT_E) <= 0
                          && ATT_DATE_B <= a.ADATE && ATT_DATE_E >= a.ADATE//請假抓取考勤區間      
                          //&& !CodeFunction.GetHolidayRoteList().Contains(a.ROTE)//只抓上班日
                          && DATE_E >= b.ADATE && DATE_E <= b.DDATE.Value
                          //&& smd.GetFilterByNobr(a.NOBR, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value
                          && smd.UserReadDataGroupList(MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Select(p => p.DATAGROUP).Contains(b.SALADR)
                          select new { a.NOBR, a.ADATE, a.ROTE, c.WK_HRS, a.ATT_HRS }).ToList();
            var yearrestList = new List<string>();
            yearrestList.Add("1");
            yearrestList.Add("3");
            yearrestList.Add("5");
            yearrestList.Add("7");
            yearrestList.Add("9");
            //var absSQL = (from a in smd.ATTEND
            //              join b in smd.BASETTS on a.NOBR equals b.NOBR
            //              join c in smd.tblROTE on a.ROTE equals c.ROTE1
            //              join d in smd.ABS on new { a.NOBR, a.ADATE.Date } equals new { d.NOBR, d.BDATE.Date }
            //              join e in smd.HCODE on d.H_CODE equals e.H_CODE
            //              join f in smd.DEPT on b.DEPT equals f.D_NO
            //              let hcodesList = (from g in smd.HCODES join h in smd.SALCODE on g.SAL_CODE equals h.SAL_CODE where d.H_CODE == g.H_CODE && h.SAL_CODE_DISP == "A01" select d.BDATE)
            //              where a.NOBR.CompareTo(NOBR_B) >= 0 && a.NOBR.CompareTo(NOBR_E) <= 0
            //                  && f.D_NO_DISP.CompareTo(DEPT_B) >= 0 && f.D_NO_DISP.CompareTo(DEPT_E) <= 0
            //                  //&& ATT_DATE_B <= a.ADATE && ATT_DATE_E >= a.ADATE//請假抓取考勤區間                                
            //                  && d.YYMM == YYMM
            //                  && DATE_E >= b.ADATE && DATE_E <= b.DDATE.Value
            //                  && !yearrestList.Contains(e.YEAR_REST)
            //                  && hcodesList.Any()//只抓扣底薪的項目
            //                  && smd.GetFilterByNobr(a.NOBR, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value
            //              select new { a.NOBR, a.ADATE, d.BDATE, d.H_CODE, a.ROTE, c.WK_HRS, a.ATT_HRS, ABS_HRS = d.TOL_HOURS, e.UNIT }).ToList();
            var otSQL = (from a in smd.ATTEND
                         join b in smd.BASETTS on a.NOBR equals b.NOBR
                         join c in smd.tblROTE on a.ROTE equals c.ROTE1
                         join d in smd.OT on new { a.NOBR, a.ADATE.Date } equals new { d.NOBR, d.BDATE.Date }
                         join e in smd.DEPT on b.DEPT equals e.D_NO
                         where b.NOBR.CompareTo(NOBR_B) >= 0 && b.NOBR.CompareTo(NOBR_E) <= 0
                         && e.D_NO_DISP.CompareTo(DEPT_B) >= 0 && e.D_NO_DISP.CompareTo(DEPT_E) <= 0
                         && ATT_DATE_B <= a.ADATE && ATT_DATE_E >= a.ADATE//請假抓取考勤區間                                
                                                                          //&& d.YYMM == YYMM
                         && DATE_E >= b.ADATE && DATE_E <= b.DDATE.Value
                         //&& smd.GetFilterByNobr(a.NOBR, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value
                         && smd.UserReadDataGroupList(MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Select(p => p.DATAGROUP).Contains(b.SALADR)
                         select new { a.NOBR, a.ADATE, d.BDATE, a.ROTE, c.WK_HRS, a.ATT_HRS, OT_HRS = d.TOT_HOURS }).ToList();


            //var groupSQL = from row in sql group row by row.Key.NOBR into g1 select g1;
            int counts = EmpList.Count();
            SalaryDate sd = new SalaryDate(YYMM);
            decimal monthDays = Convert.ToInt32((sd.LastDayOfSalary - sd.FirstDayOfSalary).TotalDays) + 1;
            foreach (var EmpData in EmpList)//所以需要計算薪資的工號
            {
                var basettsList = EmpData;
                var salbasdOfNobr = salbasdList.Where(p => p.NOBR == EmpData.Key);
                decimal Workdays = basettsList.Sum(row =>
                       Function.RangeMix(row.ADATE, row.DDATE.Value, DATE_B, DATE_E));//在職給薪天數
                WorkDaysList.Add(EmpData.Key, Workdays);
                //異動資料在計算區間內的天數
                foreach (var salbasdRow in salbasdOfNobr)
                {
                    DateTime ADATE, DDATE;//有效的區間
                    ADATE = Function.MaxValueB(salbasdRow.ADATE, DATE_B);
                    DDATE = Function.MinValueE(salbasdRow.DDATE, DATE_E);
                    decimal Adays = basettsList.Sum(row =>
                        Function.RangeMix(row.ADATE, row.DDATE.Value, ADATE, DDATE));//在職給薪天數
                    bool FullWork = (Workdays == monthDays);//是否整月在值    
                    //foreach (var itm in gp)
                    //{
                    //    decimal salbasdDays = Function.RangeMix(gp.Key.ADATE.Date, gp.Key.DDATE.Value.Date, DATE_B, DATE_E);
                    //    if (salbasdDays <= 0) continue;

                    //    DateTime d1 = Function.MaxValueB(gp.Key.ADATE.Date, DATE_B);
                    //    DateTime d2 = Function.MinValueE(gp.Key.DDATE.Value.Date, DATE_E);
                    decimal amt = 0;
                    var AvailableDays = Adays;//有效天數;
                    var AttDataOfNobr = attSQL.Where(p => p.NOBR == EmpData.Key && p.ADATE >= salbasdRow.ADATE.Date && p.ADATE <= salbasdRow.DDATE.Date);
                    //var AbsDataOfNobr = absSQL.Where(p => p.NOBR == basettsGroup.Key && p.ADATE >= itm.BASETTS.ADATE.Date && p.ADATE <= itm.BASETTS.DDATE.Value.Date && p.ADATE >= itm.SALBASD.ADATE.Date && p.ADATE <= itm.SALBASD.DDATE.Date);
                    var OtDataOfNobr = otSQL.Where(p => p.NOBR == EmpData.Key && p.ADATE >= salbasdRow.ADATE.Date && p.ADATE <= salbasdRow.DDATE.Date);
                    decimal salary = JBModule.Data.CDecryp.Number(salbasdRow.AMT);
                    decimal WorkHrs = AttDataOfNobr.Sum(p => p.ATT_HRS);
                    //decimal AbsHrs = AbsDataOfNobr.Sum(p => p.UNIT == "天" ? p.ABS_HRS * 8 : p.ABS_HRS);
                    decimal OtHrs = OtDataOfNobr.Sum(p => p.OT_HRS);
                    BaseSalary_Core bc = new BaseSalary_Core();
                    bc.MonthDays = monthDays;
                    bc.OnJobDays = AvailableDays;
                    bc.RealWorkDays = AttDataOfNobr.Where(p => !CodeFunction.GetHolidayRoteList().Contains(p.ROTE)).Count();
                    bc.CustomDays = salbasdRow.DEFINEDAYS > 0 ? salbasdRow.DEFINEDAYS : 30M;
                    if (AppConfig.GetConfig("PTWkHrsIncludeOt").Value == "True")
                        bc.WorkHrs = WorkHrs;// -AbsHrs + OtHrs; 
                    else
                        bc.WorkHrs = WorkHrs - OtHrs;
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
                    }

                    decimal amt45 = Math.Round(amt, MidpointRounding.AwayFromZero);
                    WAGED waged = new WAGED();
                    waged.AMT = JBModule.Data.CEncrypt.Number(amt45);
                    waged.NOBR = salbasdRow.NOBR;
                    waged.SAL_CODE = salbasdRow.SAL_CODE;
                    waged.SEQ = SEQ;
                    waged.YYMM = YYMM;
                    InsertWaged(waged);

                }
            }

        }
        public void PrevBaseSalaryCalc()
        {
            SalaryDate sd = new SalaryDate(YYMM);
            var pd = sd.GetPrevSalaryDate();
            DateTime pDateB, pDateE;
            pDateB = DATE_B.AddMonths(-1);
            pDateE = pDateB.AddMonths(1).AddDays(-1);
            DateTime pATT_DATE_B, pATT_DATE_E;
            pATT_DATE_B = ATT_DATE_B.AddMonths(-1);
            pATT_DATE_E = pATT_DATE_B.AddMonths(1).AddDays(-1);

            List<string> ttscodeList = new List<string>();
            ttscodeList.Add("1");
            ttscodeList.Add("4");
            ttscodeList.Add("6");
            var CalcList = PreviousMonthNoWage().Select(p => p.Key);
            string ATTAWARDSALCODE = MainForm.SalaryConfig.ATTAWARDSALCODE;
            string DeductWage = AppConfig.GetConfig("DeductWage").GetString("");
            var sql_full =( from a in smd.BASETTS
                      join b in smd.SALBASD on a.NOBR equals b.NOBR into ab
                      from salbasd in ab
                      join c in smd.SALCODE on salbasd.SAL_CODE equals c.SAL_CODE
                      join d in smd.SALATTR on c.SAL_ATTR equals d.SALATTR1
                      join e in smd.DEPT on a.DEPT equals e.D_NO
					  //join wrnt in smd.WriteRuleNobrTable.Where(p => p.GUID == guid) on a.NOBR equals wrnt.EMPID																						
                      where ttscodeList.Contains(a.TTSCODE)
                      && a.NOBR.CompareTo(NOBR_B) >= 0 && a.NOBR.CompareTo(NOBR_E) <= 0
                      && e.D_NO_DISP.CompareTo(DEPT_B) >= 0 && e.D_NO_DISP.CompareTo(DEPT_E) <= 0
                      && c.SAL_CODE != ATTAWARDSALCODE
                      && c.SAL_CODE != DeductWage
                      && pDateB <= a.DDATE && pDateE >= a.ADATE
                      && !a.NOWAGE//須計算薪資
                      && c.SOS_ID == "1"//系統計算
                      && !c.NOTFREQ//常態薪資
                      && a.ADATE <= salbasd.DDATE && a.DDATE >= salbasd.ADATE
                      && (c.CAL_TYPE == null || c.CAL_TYPE == "")
                      && (c.SALBASE == null || c.SALBASE == "")
                      //&& a.INDT <= InEDate
                      && CalcList.Contains(a.NOBR)//只算名單人員
                      //&& smd.GetFilterByNobr(a.NOBR, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value
                      && smd.UserReadDataGroupList(MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Select(p => p.DATAGROUP).Contains(a.SALADR)
                      select new { BASETTS = a, SALBASD = salbasd, SALCODE = c } ).ToList();
            var sql = sql_full.GroupBy(p => p.BASETTS);
            var attSQL = (from a in smd.ATTEND
                          join b in smd.BASETTS on a.NOBR equals b.NOBR
                          join c in smd.tblROTE on a.ROTE equals c.ROTE1
                          join d in smd.DEPT on b.DEPT equals d.D_NO
						  //join wrnt in smd.WriteRuleNobrTable.Where(p => p.GUID == guid) on a.NOBR equals wrnt.EMPID																						
                          where b.NOBR.CompareTo(NOBR_B) >= 0 && b.NOBR.CompareTo(NOBR_E) <= 0
                          && d.D_NO_DISP.CompareTo(DEPT_B) >= 0 && d.D_NO_DISP.CompareTo(DEPT_E) <= 0
                          && pATT_DATE_B <= a.ADATE && pATT_DATE_E >= a.ADATE//請假抓取考勤區間      
                          && !CodeFunction.GetHolidayRoteList().Contains(a.ROTE)//只抓上班日
                          && pDateE >= b.ADATE && pDateE <= b.DDATE.Value
                          && CalcList.Contains(a.NOBR)//只算名單人員
                          //&& smd.GetFilterByNobr(a.NOBR, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value
                          && smd.UserReadDataGroupList(MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Select(p => p.DATAGROUP).Contains(b.SALADR)
                          select new { a.NOBR, a.ADATE, a.ROTE, c.WK_HRS, a.ATT_HRS }).ToList();
            var yearrestList = new List<string>();
            yearrestList.Add("1");
            yearrestList.Add("3");
            yearrestList.Add("5");
            yearrestList.Add("7");
            yearrestList.Add("9");
            var absSQL = (from a in smd.ATTEND
                          join b in smd.BASETTS on a.NOBR equals b.NOBR
                          join c in smd.tblROTE on a.ROTE equals c.ROTE1
                          join d in smd.ABS on new { a.NOBR, a.ADATE.Date } equals new { d.NOBR, d.BDATE.Date }
                          join e in smd.HCODE on d.H_CODE equals e.H_CODE
                          join f in smd.DEPT on b.DEPT equals f.D_NO
						  //join wrnt in smd.WriteRuleNobrTable.Where(p => p.GUID == guid) on a.NOBR equals wrnt.EMPID																					   
                          where b.NOBR.CompareTo(NOBR_B) >= 0 && b.NOBR.CompareTo(NOBR_E) <= 0
                          && f.D_NO_DISP.CompareTo(DEPT_B) >= 0 && f.D_NO_DISP.CompareTo(DEPT_E) <= 0
                          && pATT_DATE_B <= a.ADATE && pATT_DATE_E >= a.ADATE//請假抓取考勤區間                                
                          && pDateE >= b.ADATE && pDateE <= b.DDATE.Value
                          && !yearrestList.Contains(e.YEAR_REST)
                          //&& smd.GetFilterByNobr(a.NOBR, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value
                          && smd.UserReadDataGroupList(MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Select(p => p.DATAGROUP).Contains(b.SALADR)
                          select new { a.NOBR, a.ADATE, d.BDATE, d.H_CODE, a.ROTE, c.WK_HRS, a.ATT_HRS, ABS_HRS = d.TOL_HOURS, e.UNIT }).ToList();
            var otSQL = (from a in smd.ATTEND
                         join b in smd.BASETTS on a.NOBR equals b.NOBR
                         join c in smd.tblROTE on a.ROTE equals c.ROTE1
                         join d in smd.OT on new { a.NOBR, a.ADATE.Date } equals new { d.NOBR, d.BDATE.Date }
                         join e in smd.DEPT on b.DEPT equals e.D_NO
						 //join wrnt in smd.WriteRuleNobrTable.Where(p => p.GUID == guid) on a.NOBR equals wrnt.EMPID																						   
                         where b.NOBR.CompareTo(NOBR_B) >= 0 && b.NOBR.CompareTo(NOBR_E) <= 0
                         && e.D_NO_DISP.CompareTo(DEPT_B) >= 0 && e.D_NO_DISP.CompareTo(DEPT_E) <= 0
                         && pATT_DATE_B <= a.ADATE && pATT_DATE_E >= a.ADATE//請假抓取考勤區間                                
                         && pDateE >= b.ADATE && pDateE <= b.DDATE.Value
                         //&& smd.GetFilterByNobr(a.NOBR, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value
                         && smd.UserReadDataGroupList(MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Select(p => p.DATAGROUP).Contains(b.SALADR)
                         select new { a.NOBR, a.ADATE, d.BDATE, a.ROTE, c.WK_HRS, a.ATT_HRS, OT_HRS = d.TOT_HOURS }).ToList();


            var groupSQL = from row in sql group row by row.Key.NOBR into g1 select g1;
            int counts = groupSQL.Count();
            decimal monthDays = Convert.ToInt32((pDateE - pDateB).TotalDays) + 1;
            foreach (var basettsGroup in groupSQL)//所以需要計算薪資的工號
            {
                var basettsList = basettsGroup;
                //異動資料在計算區間內的天數
                decimal Adays = basettsList.Sum(row =>
                    Function.RangeMix(row.Key.ADATE.Date, row.Key.DDATE.Value.Date, pDateB, pDateE));
                bool FullWork = (Adays == monthDays);//是否整月在值
                //WorkDaysList.Add(basettsGroup.Key, Adays);
                foreach (var gp in basettsGroup)//每個人的異動資料
                {
                    foreach (var itm in gp)
                    {
                        decimal salbasdDays = Function.RangeMix(gp.Key.ADATE, gp.Key.DDATE.Value, pDateB, pDateE);
                        if (salbasdDays <= 0) continue;

                        DateTime d1 = Function.MaxValueB(gp.Key.ADATE.Date, pDateB);
                        DateTime d2 = Function.MinValueE(gp.Key.DDATE.Value.Date, pDateE);
                        decimal amt = 0;
                        var AvailableDays = Function.RangeMix(itm.SALBASD.ADATE, itm.SALBASD.DDATE, d1, d2);//有效天數;
                        var AttDataOfNobr = attSQL.Where(p => p.NOBR == basettsGroup.Key && p.ADATE >= itm.BASETTS.ADATE && p.ADATE <= itm.BASETTS.DDATE.Value && p.ADATE >= itm.SALBASD.ADATE && p.ADATE <= itm.SALBASD.DDATE);
                        var AbsDataOfNobr = absSQL.Where(p => p.NOBR == basettsGroup.Key && p.ADATE >= itm.BASETTS.ADATE && p.ADATE <= itm.BASETTS.DDATE.Value && p.ADATE >= itm.SALBASD.ADATE && p.ADATE <= itm.SALBASD.DDATE);
                        var OtDataOfNobr = otSQL.Where(p => p.NOBR == basettsGroup.Key && p.ADATE >= itm.BASETTS.ADATE && p.ADATE <= itm.BASETTS.DDATE.Value && p.ADATE >= itm.SALBASD.ADATE && p.ADATE <= itm.SALBASD.DDATE);
                        decimal salary = JBModule.Data.CDecryp.Number(itm.SALBASD.AMT);
                        decimal WorkHrs = AttDataOfNobr.Sum(p => p.WK_HRS);
                        decimal AbsHrs = AbsDataOfNobr.Sum(p => p.UNIT == "天" ? p.ABS_HRS * 8 : p.ABS_HRS);
                        decimal OtHrs = OtDataOfNobr.Sum(p => p.OT_HRS);
                        BaseSalary_Core bc = new BaseSalary_Core();
                        bc.MonthDays = monthDays;
                        bc.OnJobDays = AvailableDays;
                        bc.RealWorkDays = AttDataOfNobr.Where(p => !CodeFunction.GetHolidayRoteList().Contains(p.ROTE)).Count();
                        bc.CustomDays = itm.SALCODE.DEFINEDAYS > 0 ? itm.SALCODE.DEFINEDAYS : 30M;
                        bc.WorkHrs = WorkHrs - AbsHrs + OtHrs;
                        if (FullWork)//整月在職
                        {
                            bc.MonthType = "2";//整月在職直接用預設(月曆天)
                            bc.CalcUnit = itm.SALCODE.CAL_FREQ;
                            amt = bc.CalculationRule(salary);

                            //var datas = wagedList.Where(p => p.NOBR == itm.BASETTS.NOBR && p.SAL_CODE == itm.SALBASD.SAL_CODE);
                            //if (datas.Any() && itm.SALBASD.ADATE <= pDateB && itm.SALBASD.DDATE >= pDateE)//如果已經有資料
                            //{
                            //    amt = Math.Round(amt, MidpointRounding.AwayFromZero);
                            //    var currentAmt = datas.Sum(p => JBModule.Data.CDecryp.Number(p.AMT));
                            //    if (amt + currentAmt > JBModule.Data.CDecryp.Number(itm.SALBASD.AMT))
                            //        amt = JBModule.Data.CDecryp.Number(itm.SALBASD.AMT) - currentAmt;//避免四捨五入超出
                            //    else if (JBModule.Data.CDecryp.Number(itm.SALBASD.AMT) - (amt + currentAmt) == 1)//差一塊
                            //    {
                            //        amt = JBModule.Data.CDecryp.Number(itm.SALBASD.AMT) - currentAmt;
                            //    }
                            //}
                        }
                        else//破月
                        {
                            bc.MonthType = itm.SALCODE.MONTHTYPE;
                            bc.CalcUnit = itm.SALCODE.CAL_FREQ;
                            amt = bc.CalculationRule(salary);
                        }

                        decimal amt45 = Math.Round(amt, MidpointRounding.AwayFromZero);
                        WAGED waged = new WAGED();
                        waged.AMT = JBModule.Data.CEncrypt.Number(amt45);
                        waged.NOBR = itm.BASETTS.NOBR;
                        waged.SAL_CODE = itm.SALBASD.SAL_CODE;
                        waged.SEQ = SEQ;
                        waged.YYMM = YYMM;//算到這個月
                        InsertWaged(waged);

                    }
                }

            }
        }
        //void PrevBaseSalaryCalc1()
        //{
        //    SalaryDate sd = new SalaryDate(YYMM);
        //    var pd = sd.GetPrevSalaryDate();
        //    //DateTime pd1, pd2;
        //    //pd1 = ATT_DATE_E.AddMonths(-1).AddDays(1);
        //    //pd1 = new DateTime(pd1.Year, pd1.Month, MainForm.SalaryConfig.ATTMONTH.Value);
        //    //pd2 = DATE_E.AddMonths(-1);
        //    //SalaryDate pd = new SalaryDate(pd1);
        //    List<string> ttscodeList = new List<string>();
        //    ttscodeList.Add("1");
        //    ttscodeList.Add("4");


        //    List<string> ttscodeList1 = new List<string>();
        //    ttscodeList1.Add("1");
        //    ttscodeList1.Add("4");
        //    ttscodeList1.Add("6");

        //    DateTime pDateB, pDateE;
        //    pDateB = DATE_B.AddMonths(-1);
        //    pDateE = pDateB.AddMonths(1).AddDays(-1);
        //    var sql = from a in smd.BASETTS
        //              join b in smd.SALBASD on a.NOBR equals b.NOBR into ab
        //              from salbasd in ab
        //              join c in smd.SALCODE on salbasd.SAL_CODE equals c.SAL_CODE
        //              join d in smd.SALATTR on c.SAL_ATTR equals d.SALATTR1
        //              join e in smd.DEPT on a.DEPT equals e.D_NO
        //              //join e in nobrList on a.NOBR equals e
        //              where ttscodeList1.Contains(a.TTSCODE)
        //                  && a.NOBR.CompareTo(NOBR_B) >= 0 && a.NOBR.CompareTo(NOBR_E) <= 0
        //                  && e.D_NO_DISP.CompareTo(DEPT_B) >= 0 && e.D_NO_DISP.CompareTo(DEPT_E) <= 0
        //                  //&& (MainForm.PROCSUPER || a.SALADR == MainForm.WORKADR)
        //                  && pDateB <= a.DDATE && pDateE >= a.ADATE
        //                  && !a.NOWAGE
        //                  && c.SOS_ID == "1"
        //                  && !c.NOTFREQ
        //                  && a.ADATE <= salbasd.DDATE && a.DDATE >= salbasd.ADATE
        //                  && a.INDT <= InEDate
        //                  && c.SAL_CODE != MainForm.SalaryConfig.ATTAWARDSALCODE
        //                  && smd.GetFilterByNobr(a.NOBR, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value
        //              group new { BASETTS = a, SALBASD = salbasd } by a into gp
        //              select gp;

        //    var inSQL = from a in smd.BASETTS where a.TTSCODE == "1" && pDateB <= a.DDATE.Value && pDateE >= a.ADATE select a;

        //    var wageSQL = from a in smd.WAGE where a.YYMM == pd.YYMM && a.SEQ == this.SEQ select a;
        //    var groupSQL = from row in sql where !wageSQL.Where(p => p.NOBR == row.Key.NOBR).Any() group row by row.Key.NOBR into g1 select g1;
        //    int counts = groupSQL.Count();
        //    decimal monthDays = Convert.ToInt32((pDateE - pDateB).TotalDays) + 1;
        //    foreach (var basettsGroup in groupSQL)//所以需要計算薪資的工號
        //    {
        //        if (!inSQL.Where(p => p.NOBR == basettsGroup.Key).Any()) continue;//只取上月到職
        //        var basettsList = basettsGroup;
        //        //異動資料在計算區間內的天數
        //        decimal Adays = basettsList.Sum(row =>
        //            Function.RangeMix(row.Key.ADATE, row.Key.DDATE.Value, pDateB, pDateE));
        //        //bool FullWork = (Adays == Convert.ToInt32((DATE_E - DATE_B).TotalDays) + 1);//是否整月在值
        //        //WorkDaysList.Add(basettsGroup.Key, Adays);
        //        foreach (var gp in basettsGroup)//每個人的異動資料
        //        {
        //            foreach (var itm in gp)
        //            {
        //                decimal salbasdDays = Function.RangeMix(gp.Key.ADATE, gp.Key.DDATE.Value, pDateB, pDateE);
        //                if (salbasdDays <= 0) continue;

        //                DateTime d1 = Function.MaxValueB(gp.Key.ADATE, pDateB);
        //                DateTime d2 = Function.MinValueE(gp.Key.DDATE.Value, pDateE);
        //                decimal amt =
        //                    Function.RangeMix(itm.SALBASD.ADATE, itm.SALBASD.DDATE, d1, d2)//有效天數
        //                    * JBModule.Data.CDecryp.Number(itm.SALBASD.AMT)//薪資科目金額
        //                    / 30;//只有可能是破月，所以是30天

        //                decimal amt45 = Math.Round(amt, MidpointRounding.AwayFromZero);
        //                WAGED waged = new WAGED();
        //                waged.AMT = JBModule.Data.CEncrypt.Number(amt45);
        //                waged.NOBR = itm.BASETTS.NOBR;
        //                waged.SAL_CODE = itm.SALBASD.SAL_CODE;
        //                waged.SEQ = SEQ;
        //                waged.YYMM = YYMM;
        //                InsertWaged(waged);

        //            }
        //        }

        //    }
        //}
        //匯入班別津貼
        void ImportSalAttCalc()
        {
            JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
            //List<string> item = new List<string>() { "RoteByAtt", "RoteByOt" };
            var salAtt = (from a in db.SALATT
                         join d in db.BASETTS on a.NOBR equals d.NOBR
                         join dept in db.DEPT on d.DEPT equals dept.D_NO
						 //join wrnt in db.WriteRuleNobrTable.Where(p => p.GUID == guid) on a.NOBR equals wrnt.EMPID																						   
                         where d.NOBR.CompareTo(NOBR_B) >= 0 && d.NOBR.CompareTo(NOBR_E) <= 0
                         && a.ADATE >= ATT_DATE_B && a.ADATE <= ATT_DATE_E
                         //&& item.Contains(a.CALC_TYPE)
                         && a.ADATE >= d.ADATE && a.ADATE <= d.DDATE.Value
                         && dept.D_NO_DISP.CompareTo(DEPT_B) >= 0 && dept.D_NO_DISP.CompareTo(DEPT_E) <= 0
                         //&& a.YYMM == YYMM
                         //&& db.GetFilterByNobr(a.NOBR, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value//判断数据群组
                         && db.UserReadDataGroupList(MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Select(p => p.DATAGROUP).Contains(d.SALADR)
                         select new
                         {
                             a.AMT,
                             a.NOBR,
                             a.SAL_CODE,
                             d.SALADR
                         }).ToList();
            foreach (var sa in salAtt)
            {
                decimal amt = sa.AMT;
                WAGED waged = new WAGED();
                waged.AMT = JBModule.Data.CEncrypt.Number(amt);
                waged.NOBR = sa.NOBR;
                waged.SAL_CODE = sa.SAL_CODE;
                waged.SEQ = SEQ;
                waged.YYMM = YYMM;
                InsertWaged(waged);
            }
        }
        void AllowanceCalc()
        {
            JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
            var roteList = db.ROTE.ToList();
            var sql = (from a in db.ATTEND
                       join b in db.ROTE on a.ROTE equals b.ROTE1
                       join d in db.BASETTS on a.NOBR equals d.NOBR
                       join e in db.BASE on a.NOBR equals e.NOBR
                       join d1 in db.BASETTS on a.NOBR equals d1.NOBR
                       join f in db.STATION on d1.STATION equals f.Code into df
                       from st in df.DefaultIfEmpty()
                       join g in db.DEPT on d.DEPT equals g.D_NO
					   //join wrnt in db.WriteRuleNobrTable.Where(p => p.GUID == guid) on a.NOBR equals wrnt.EMPID																						
                       where d.NOBR.CompareTo(NOBR_B) >= 0 && d.NOBR.CompareTo(NOBR_E) <= 0
                       && DATE_E >= d.ADATE && DATE_E <= d.DDATE.Value
                       && g.D_NO_DISP.CompareTo(DEPT_B) >= 0 && g.D_NO_DISP.CompareTo(DEPT_E) <= 0
                       && a.ADATE >= ATT_DATE_B && a.ADATE <= ATT_DATE_E
                       && a.ADATE >= d1.ADATE && a.ADATE <= d1.DDATE.Value
                       && !CodeFunction.GetHolidayRoteList().Contains(a.ROTE)
                       //&& !d.NOWAGE//如果不發薪，也不要記錄明細
                       //&& db.GetFilterByNobr(a.NOBR, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value//判斷資料群組
                       && db.UserReadDataGroupList(MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Select(p => p.DATAGROUP).Contains(d.SALADR)
                       select new
                       {
                           ATTEND = a,
                           ROTE = b,
                           COUNT_MA = e.COUNT_MA,
                           d.SALTP,
                           StationAmt = st != null ? Convert.ToDecimal(st.AMT.Value) : 0M,
                           d.NOWAGE,
                       }).ToList();
            var otList = (from a in db.OT
                          join d in db.BASETTS on a.NOBR equals d.NOBR
                          join e in db.BASE on a.NOBR equals e.NOBR
                          join g in db.DEPT on d.DEPT equals g.D_NO
                          join att in db.ATTEND on new { a.NOBR, ADATE = a.BDATE } equals new { att.NOBR, att.ADATE }
                          join rote in db.ROTE on a.OT_ROTE equals rote.ROTE1
					      //join wrnt in db.WriteRuleNobrTable.Where(p => p.GUID == guid) on a.NOBR equals wrnt.EMPID																					   
                          where d.NOBR.CompareTo(NOBR_B) >= 0 && d.NOBR.CompareTo(NOBR_E) <= 0
                          && DATE_E >= d.ADATE && DATE_E <= d.DDATE.Value
                          && g.D_NO_DISP.CompareTo(DEPT_B) >= 0 && g.D_NO_DISP.CompareTo(DEPT_E) <= 0
                          && a.BDATE >= ATT_DATE_B && a.BDATE <= ATT_DATE_E
                          //&& a.YYMM == YYMM
                          //&& a.OT_FOODH > 0
                          && CodeFunction.GetHolidayRoteList().Contains(att.ROTE)
                          //&& !d.NOWAGE//如果不發薪，也不要記錄明細
                          //&& db.GetFilterByNobr(a.NOBR, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value//判斷資料群組
                          && db.UserReadDataGroupList(MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Select(p => p.DATAGROUP).Contains(d.SALADR)
                          select new
                          {
                              a.NOBR,
                              a.BDATE,
                              rote.NIGHTSALCD,
                              rote.FOODSALCD,
                              rote.SPECSALCD,
                              att.NIGAMT,
                              att.FOODAMT,
                              att.SPECAMT,
                          }).ToList();
            var otGroup = otList.GroupBy(p => new { p.NOBR, p.BDATE });


            var sqlCalc = from a in sql
                          group new { a.ATTEND, ROTE = roteList.SingleOrDefault(p => p.ROTE1 == a.ATTEND.ROTE_H) } by a.ATTEND.NOBR into gp
                          select gp;
            decimal TotalMonthDays = Convert.ToInt32((ATT_DATE_E - ATT_DATE_B).TotalDays) + 1;
            foreach (var itm in sqlCalc)
            {
                var GroupByNightCD = from a in itm group a by a.ROTE.NIGHTSALCD into gp select gp;
                foreach (var g in GroupByNightCD)
                {
                    decimal nightamt = g.Sum(p => p.ATTEND.NIGAMT);
                    //decimal foodamt = g.Sum(p => p.ATTEND.FOODAMT);
                    string nightcd = g.Key;
                    WAGED waged = new WAGED();
                    waged.AMT = JBModule.Data.CEncrypt.Number(nightamt);
                    waged.NOBR = itm.Key;
                    waged.SAL_CODE = nightcd;
                    waged.SEQ = SEQ;
                    waged.YYMM = YYMM;
                    InsertWaged(waged);
                }
                var GroupBySpecCD = from a in itm group a by a.ROTE.SPECSALCD into gp select gp;
                foreach (var g in GroupBySpecCD)
                {
                    decimal specamt = g.Sum(p => p.ATTEND.SPECAMT != null ? p.ATTEND.SPECAMT.Value : 0);
                    string speccd = g.Key;
                    WAGED waged = new WAGED();
                    waged.AMT = JBModule.Data.CEncrypt.Number(specamt);
                    waged.NOBR = itm.Key;
                    waged.SAL_CODE = speccd;
                    waged.SEQ = SEQ;
                    waged.YYMM = YYMM;
                    InsertWaged(waged);
                }
                var GroupByFoodCD = from a in itm group a by a.ROTE.FOODSALCD into gp select gp;
                foreach (var g in GroupByFoodCD)
                {
                    decimal foodamt = g.Sum(p => p.ATTEND.FOODAMT);
                    string foodcd = g.Key;
                    WAGED waged = new WAGED();
                    waged.AMT = JBModule.Data.CEncrypt.Number(foodamt);
                    waged.NOBR = itm.Key;
                    waged.SAL_CODE = foodcd;
                    waged.SEQ = SEQ;
                    waged.YYMM = YYMM;
                    InsertWaged(waged);
                }
                var GroupByStationCD = from a in itm select a;

                {
                    decimal stationamt = GroupByStationCD.Sum(p => p.ATTEND.STATIONAMT != null ? p.ATTEND.STATIONAMT.Value : 0);
                    string stationsalcode = MainForm.SalaryConfig.EMPSALCODE;
                    WAGED waged = new WAGED();
                    waged.AMT = JBModule.Data.CEncrypt.Number(stationamt);
                    waged.NOBR = itm.Key;
                    waged.SAL_CODE = stationsalcode;
                    waged.SEQ = SEQ;
                    waged.YYMM = YYMM;
                    InsertWaged(waged);
                }
            }
            string FoodAmtSalcode = MainForm.OvertimeConfig.OTTRASALCODE;
            foreach (var it in otGroup)
            {
                decimal NIGAMT = it.First().NIGAMT;
                WAGED waged = new WAGED();
                waged.AMT = JBModule.Data.CEncrypt.Number(NIGAMT);
                waged.NOBR = it.Key.NOBR;
                waged.SAL_CODE = it.First().NIGHTSALCD;
                waged.SEQ = SEQ;
                waged.YYMM = YYMM;
                InsertWaged(waged);

                decimal FOODAMT = it.First().FOODAMT;
                waged = new WAGED();
                waged.AMT = JBModule.Data.CEncrypt.Number(FOODAMT);
                waged.NOBR = it.Key.NOBR;
                waged.SAL_CODE = it.First().FOODSALCD;
                waged.SEQ = SEQ;
                waged.YYMM = YYMM;
                InsertWaged(waged);

                decimal SPECAMT = it.First().SPECAMT.GetValueOrDefault(0);
                waged = new WAGED();
                waged.AMT = JBModule.Data.CEncrypt.Number(SPECAMT);
                waged.NOBR = it.Key.NOBR;
                waged.SAL_CODE = it.First().SPECSALCD;
                waged.SEQ = SEQ;
                waged.YYMM = YYMM;
                InsertWaged(waged);
            }
            db.SubmitChanges();
        }
        /// <summary>
        /// 輪班津貼月給
        /// </summary>
        void AllowanceOfMonthCalc()
        {
            JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
            List<string> ttscodeList = new List<string>();
            ttscodeList.Add("1");
            ttscodeList.Add("4");
            ttscodeList.Add("6");
            var ts = ATT_DATE_E - ATT_DATE_B;
            decimal monthDays = Convert.ToDecimal(ts.TotalDays + 1);
            var sql_full = (from a in db.BASETTS
                      join b in db.ROTET on a.ROTET equals b.ROTET1
                      join c in db.DEPT on a.DEPT equals c.D_NO
					  //join wrnt in db.WriteRuleNobrTable.Where(p => p.GUID == guid) on a.NOBR equals wrnt.EMPID																					   
                      where a.NOBR.CompareTo(NOBR_B) >= 0 && a.NOBR.CompareTo(NOBR_E) <= 0
                      && c.D_NO_DISP.CompareTo(DEPT_B) >= 0 && c.D_NO_DISP.CompareTo(DEPT_E) <= 0
                      && a.ADATE <= ATT_DATE_E && a.DDATE >= ATT_DATE_B//出勤區間內有效的在職區間
                      && ttscodeList.Contains(a.TTSCODE)
                      //&& db.GetFilterByNobr(a.NOBR, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value//判斷資料群組
                      && db.UserReadDataGroupList(MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Select(p => p.DATAGROUP).Contains(a.SALADR)
                      select new
                      {
                          a.NOBR,
                          ADATE = a.ADATE >= ATT_DATE_B ? a.ADATE : ATT_DATE_B,
                          DDATE = a.DDATE <= ATT_DATE_E ? a.DDATE : ATT_DATE_E,
                          b.NIGHTAMT,
                          b.NIGHTSALCODE,
                          b.FOODAMT,
                          b.FOODAMT1,
                          b.FOODSALCODE,
                      } ).ToList();
            var sql = sql_full.GroupBy(p => p.NOBR);
            var attendList = (from a in db.ATTEND
                              join b in db.BASETTS on a.NOBR equals b.NOBR
                              join c in db.DEPT on b.DEPT equals c.D_NO
                              where DATE_E >= b.ADATE && DATE_E <= b.DDATE.Value
                              && a.NOBR.CompareTo(NOBR_B) >= 0 && a.NOBR.CompareTo(NOBR_E) <= 0
                              && c.D_NO_DISP.CompareTo(DEPT_B) >= 0 && c.D_NO_DISP.CompareTo(DEPT_E) <= 0
                              select a).ToList();
            foreach (var gp in sql)
            {
                var totalMonthDay = gp.Where(p => p.FOODAMT > 0).Sum(p => p.ADATE < p.DDATE ? Convert.ToInt32((p.DDATE.Value - p.ADATE).TotalDays + 1) : 0);
                bool fullWork = false;
                if (totalMonthDay >= monthDays)
                    fullWork = true;
                decimal MaxNight = 0;
                foreach (var it in gp)
                {
                    var totalDay = it.ADATE < it.DDATE ? Convert.ToDecimal((it.DDATE.Value - it.ADATE).TotalDays + 1) : 0;
                    if (totalDay > 0)
                    {
                        decimal nightAmt = it.NIGHTAMT != null ? it.NIGHTAMT.Value : 0;
                        if (nightAmt > MaxNight) MaxNight = nightAmt;
                        if (nightAmt > 0)
                        {
                            decimal amt = totalDay * nightAmt / monthDays;
                            decimal amt45 = Math.Round(amt, MidpointRounding.AwayFromZero);

                            var datas = wagedList.Where(p => p.NOBR == it.NOBR && p.SAL_CODE == it.NIGHTSALCODE);
                            if (datas.Any())//如果已經有資料
                            {
                                var currentAmt = datas.Sum(p => JBModule.Data.CDecryp.Number(p.AMT));
                                if (amt45 + currentAmt > MaxNight)
                                    amt45 = nightAmt - currentAmt;//避免四捨五入超出
                                else if (MaxNight - (amt45 + currentAmt) == 1)//差一塊
                                {
                                    amt45 = MaxNight - currentAmt;
                                }
                            }

                            WAGED waged = new WAGED();
                            waged.AMT = JBModule.Data.CEncrypt.Number(amt45);
                            waged.NOBR = it.NOBR;
                            waged.SAL_CODE = it.NIGHTSALCODE;
                            waged.SEQ = SEQ;
                            waged.YYMM = YYMM;
                            InsertWaged(waged);
                        }
                        if (!fullWork)
                        {
                            var attendOfNobr = from a in attendList where a.NOBR == it.NOBR && a.ADATE >= it.ADATE && a.ADATE <= it.DDATE.Value && !CodeFunction.GetHolidayRoteList().Contains(a.ROTE) select a;
                            var attDays = attendOfNobr.Count();
                            decimal foodAmt = it.FOODAMT1 != null ? it.FOODAMT1.Value : 0;
                            var amt = foodAmt * attDays;
                            WAGED waged = new WAGED();
                            waged.AMT = JBModule.Data.CEncrypt.Number(amt);
                            waged.NOBR = it.NOBR;
                            waged.SAL_CODE = it.FOODSALCODE;
                            waged.SEQ = SEQ;
                            waged.YYMM = YYMM;
                            InsertWaged(waged);
                        }
                    }
                }
                if (fullWork)//整月不變
                {
                    decimal amt = gp.First().FOODAMT.Value;
                    WAGED waged = new WAGED();
                    waged.AMT = JBModule.Data.CEncrypt.Number(amt);
                    waged.NOBR = gp.Key;
                    waged.SAL_CODE = gp.First().FOODSALCODE;
                    waged.SEQ = SEQ;
                    waged.YYMM = YYMM;
                    InsertWaged(waged);
                }
            }

        }
        void OtBonusCalc()
        {
            var ot_full = (from row in smd.OT
                      join basetts in smd.BASETTS on row.NOBR equals basetts.NOBR
                      join b in smd.DEPT on basetts.DEPT equals b.D_NO
                      join c in smd.BASE on row.NOBR equals c.NOBR
					  //join wrnt in smd.WriteRuleNobrTable.Where(p => p.GUID == guid) on row.NOBR equals wrnt.EMPID																						  
                      where row.YYMM == this.YYMM
                      && row.BDATE.CompareTo(basetts.ADATE) >= 0 && row.BDATE.CompareTo(basetts.DDATE.Value) <= 0
                      && basetts.NOBR.CompareTo(NOBR_B) >= 0 && basetts.NOBR.CompareTo(NOBR_E) <= 0
                      && b.D_NO_DISP.CompareTo(DEPT_B) >= 0 && b.D_NO_DISP.CompareTo(DEPT_E) <= 0
                      && !c.COUNT_MA
                      //&& smd.GetFilterByNobr(row.NOBR, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value
                      && smd.UserReadDataGroupList(MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Select(p => p.DATAGROUP).Contains(basetts.SALADR)
                      select new { row.NOBR, row.TOT_HOURS }).ToList();
            var ot = ot_full.GroupBy(p => p.NOBR);
            decimal OtBonusSection1Hours = OtAppConfig.GetConfig("OtBonusSection1").GetDecimal(0);
            decimal OtBonusSection2Hours = OtAppConfig.GetConfig("OtBonusSection2").GetDecimal(0);
            decimal OtBonusSection3Hours = OtAppConfig.GetConfig("OtBonusSection3").GetDecimal(0);
            decimal OtBonusAmtSection1 = OtAppConfig.GetConfig("OtBonusAmtSection1").GetDecimal(0);
            decimal OtBonusAmtSection2 = OtAppConfig.GetConfig("OtBonusAmtSection2").GetDecimal(0);
            decimal OtBonusAmtSection3 = OtAppConfig.GetConfig("OtBonusAmtSection3").GetDecimal(0);
            string OtBonusSalcode = OtAppConfig.GetConfig("OtBonusSalcode").GetString("");
            foreach (var it in ot)
            {
                decimal tot_hours = it.Sum(p => p.TOT_HOURS);
                decimal amt = 0;
                if (tot_hours >= OtBonusSection3Hours)
                    amt = OtBonusAmtSection3;
                else if (tot_hours >= OtBonusSection2Hours)
                    amt = OtBonusAmtSection2;
                else if (tot_hours >= OtBonusSection1Hours)
                    amt = OtBonusAmtSection1;
                decimal amt45 = Math.Round(amt, MidpointRounding.AwayFromZero);
                WAGED waged = new WAGED();
                waged.AMT = JBModule.Data.CEncrypt.Number(amt45);
                waged.NOBR = it.Key;
                waged.SAL_CODE = OtBonusSalcode;
                waged.SEQ = SEQ;
                waged.YYMM = YYMM;
                InsertWaged(waged);
            }

        }
        int GetHour(string HHmm)
        {
            return Convert.ToInt32(HHmm.Substring(0, 2));
        }
        int GetMinute(string HHmm)
        {
            return Convert.ToInt32(HHmm.Substring(2, 2));
        }
        string AddHour(string HHmm, decimal hour)
        {
            var HH = GetHour(HHmm) + Math.Ceiling(hour);
            var mm = GetMinute(HHmm) + (hour % 1M) * 60M;
            if (mm >= 60)
            {
                HH++;
                mm -= 60;
            }
            return HH.ToString("00") + mm.ToString("00");
        }
        TimeSpan TimeSpan(string btime, string etime)
        {
            DateTime dd = new DateTime(1900, 1, 1);
            DateTime d1 = dd.AddHours(GetHour(btime)).AddMinutes(GetMinute(btime));
            DateTime d2 = dd.AddHours(GetHour(etime)).AddMinutes(GetMinute(etime));

            return d2 - d1;
        }

        public void TecoCalc()
        {
            DeleteTeco();
            SalaryMDDataContext db = new SalaryMDDataContext();
            var sql = (from a in db.SALBASND
                       join b in db.WAGEDD on a.ACNO equals b.ACNO into WAGEDDs
                       join c in db.BASETTS on a.NOBR equals c.NOBR
                       join d in db.DEPT on c.DEPT equals d.D_NO
                       //join wrnt in db.WriteRuleNobrTable.Where(p => p.GUID == guid) on a.NOBR equals wrnt.EMPID
                       where c.NOBR.CompareTo(NOBR_B) >= 0 && c.NOBR.CompareTo(NOBR_E) <= 0
                       && d.D_NO_DISP.CompareTo(DEPT_B) >= 0 && d.D_NO_DISP.CompareTo(DEPT_E) <= 0
                       //&& (c.SALADR == MainForm.WORKADR || MainForm.PROCSUPER)
                       && DATE_E >= c.ADATE && DATE_E <= c.DDATE.Value
                       //&& db.GetFilterByNobr1(a.NOBR, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value
                       && db.UserReadDataGroupList(MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Select(p => p.DATAGROUP).Contains(c.SALADR)
                       select new { SALBASND = a, WAGEDDs }).ToList();

            var empList = sql.Select(p => p.SALBASND.NOBR).Distinct().ToList();
            var groupList = sql.GroupBy(p => p.SALBASND.NOBR);
            object[] PARMS = new object[] { NOBR_B, NOBR_E, DEPT_B, DEPT_E, "MainForm.WORKADR", "MainForm.PROCSUPER", YYMM };
            var hrdb = new JBModule.Data.Linq.HrDBDataContext();

            var wagedRepo = MainForm.JbContainer.Resolve<JBHRIS.BLL.Salary.Payroll.Model.ISalaryWageDetailRepository>();

            DateTime DateBegin = new DateTime(this.TRANS_DATE.Year, this.TRANS_DATE.Month, 1);
            DateTime DateEnd = new DateTime(this.TRANS_DATE.Year, this.TRANS_DATE.Month, DateTime.DaysInMonth(this.TRANS_DATE.Year, this.TRANS_DATE.Month));
            var salaryWageDetailData = wagedRepo.GetSalaryWageDetailListByPayDate(empList, DateBegin, DateEnd, db.SALCODE.Select(p => p.SAL_CODE).ToList());


            foreach (var gp in groupList)
            {
                var wagedListOfNobr = wagedList.Where(p => p.NOBR == gp.Key);
                var wagedOfType1 = from a in wagedListOfNobr
                                   join b in Sal.Core.SalaryVar.dtSalcode on a.SAL_CODE equals b.SAL_CODE
                                   join c in Sal.Core.SalaryVar.dtSalattr on b.SAL_ATTR equals c.SALATTR1
                                   where c.TYPE == "1"//應發薪資
                                   select a;
                var wagedOfType2 = from a in wagedListOfNobr
                                   join b in Sal.Core.SalaryVar.dtSalcode on a.SAL_CODE equals b.SAL_CODE
                                   join c in Sal.Core.SalaryVar.dtSalattr on b.SAL_ATTR equals c.SALATTR1
                                   where c.TYPE == "2"//應扣薪資
                                   select a;
                var wagedOfType3 = from a in wagedListOfNobr
                                   join b in Sal.Core.SalaryVar.dtSalcode on a.SAL_CODE equals b.SAL_CODE
                                   join c in Sal.Core.SalaryVar.dtSalattr on b.SAL_ATTR equals c.SALATTR1
                                   where c.TYPE == "3"//代扣
                                   select a;
                var paymentItemOfMonth = salaryWageDetailData.Where(p => p.EmployeeId == gp.Key);
                var totalPaymentOfMonth = paymentItemOfMonth.Sum(p => p.AMT);
                decimal amt1 = wagedOfType1.Sum(p => JBModule.Data.CDecryp.Number(p.AMT));
                decimal amt2 = wagedOfType2.Sum(p => JBModule.Data.CDecryp.Number(p.AMT));
                decimal amt3 = wagedOfType3.Sum(p => JBModule.Data.CDecryp.Number(p.AMT));
                decimal totalamt = amt1 - amt2;// -amt3;
                decimal totalamt1 = amt1 - amt2 - amt3;
                decimal TotalTecoAmt = 0;
                var InstallmentData = from a in gp where !a.SALBASND.A_TYPE select a;
                var BankTecoData = from a in gp where a.SALBASND.A_TYPE select a;

                if (amt1 > 0)
                {
                    //分期付款

                    foreach (var itm in InstallmentData)
                    {
                        if (itm.SALBASND.YYMM_B != null && itm.SALBASND.YYMM_B.Trim().Length != 0
                            && YYMM.CompareTo(itm.SALBASND.YYMM_B) < 0) continue;//未開始
                        if (itm.SALBASND.YYMM_E != null && itm.SALBASND.YYMM_E.Trim().Length != 0
                            && YYMM.CompareTo(itm.SALBASND.YYMM_E) > 0) continue;//已結束

                        decimal pamt = JBModule.Data.CDecryp.Number(itm.SALBASND.P_AMT);
                        decimal tamt = JBModule.Data.CDecryp.Number(itm.SALBASND.T_AMT);
                        decimal famt = JBModule.Data.CDecryp.Number(itm.SALBASND.F_AMT);
                        decimal amt_has_payed = itm.WAGEDDs.Sum(p => JBModule.Data.CDecryp.Number(p.AMT));
                        decimal amt_total = tamt;
                        decimal amt_has_to_pay = amt_total - amt_has_payed;//剩餘金額
                        decimal pay_amt = 0;

                        if (pamt > 0)
                        {
                            pay_amt = decimal.Round(pamt, 0, MidpointRounding.AwayFromZero);
                            if (pay_amt > amt_has_to_pay)
                            {
                                pay_amt = amt_has_to_pay;
                            }
                        }
                        else if (itm.SALBASND.SEQ > 0)
                        {
                            pay_amt = decimal.Ceiling(amt_total / itm.SALBASND.SEQ);
                            if (pay_amt > amt_has_to_pay)
                            {
                                pay_amt = amt_has_to_pay;
                            }
                        }
                        else continue;
                        pay_amt = Math.Round(pay_amt, MidpointRounding.AwayFromZero);
                        WAGEDD wagedd = new WAGEDD();
                        wagedd.ACNO = itm.SALBASND.ACNO;
                        wagedd.AMT = JBModule.Data.CEncrypt.Number(pay_amt);
                        wagedd.KEY_DATE = DateTime.Now;
                        wagedd.KEY_MAN = MainForm.USER_NAME;
                        wagedd.NOBR = itm.SALBASND.NOBR;
                        wagedd.SAL_CODE = itm.SALBASND.SAL_CODE;
                        wagedd.SEQ = SEQ;
                        wagedd.YYMM = YYMM;
                        db.WAGEDD.InsertOnSubmit(wagedd);
                    }

                    //銀行代扣

                    //考慮併案
                    foreach (var itm in BankTecoData)
                    {
                        if (itm.SALBASND.YYMM_B != null && itm.SALBASND.YYMM_B.Trim().Length != 0
                             && YYMM.CompareTo(itm.SALBASND.YYMM_B) < 0) continue;//未開始
                        if (itm.SALBASND.YYMM_E != null && itm.SALBASND.YYMM_E.Trim().Length != 0
                            && YYMM.CompareTo(itm.SALBASND.YYMM_E) > 0) continue;//已結束

                        decimal pamt = JBModule.Data.CDecryp.Number(itm.SALBASND.P_AMT);
                        decimal tamt = JBModule.Data.CDecryp.Number(itm.SALBASND.T_AMT);
                        decimal famt = JBModule.Data.CDecryp.Number(itm.SALBASND.F_AMT);
                        decimal amt_has_payed = itm.WAGEDDs.Sum(p => JBModule.Data.CDecryp.Number(p.AMT));
                        decimal amt_total = tamt;
                        decimal amt_has_to_pay = amt_total - amt_has_payed;//剩餘金額
                        decimal pay_amt = 0;

                        //應發薪資*強制扣款比例(1/a_per)*併案百分比
                        decimal divBase = itm.SALBASND.A_PER;
                        if (divBase <= 0) divBase = 3;
                        decimal CourtChargeBase = totalamt / divBase;
                        if (itm.SALBASND.MIN_COST_LIVING != 0)//如果有設定最低生活費
                        {
                            //Hint:如果只參考最低生活費，就把強制扣款比率設定為1/1，就會強迫參考最低生活費
                            if (totalamt1 - CourtChargeBase < (itm.SALBASND.MIN_COST_LIVING - totalPaymentOfMonth))//如果前面設定金額扣完之後低於最低生活費，則應扣款金額改為最低生活費(扣除已發金額)
                            {
                                CourtChargeBase = totalamt1 - (itm.SALBASND.MIN_COST_LIVING - totalPaymentOfMonth);
                                if (CourtChargeBase < 0)
                                    CourtChargeBase = 0;
                            }
                        }
                        pay_amt = decimal.Round(CourtChargeBase * (itm.SALBASND.P_PER / 100), 0, MidpointRounding.AwayFromZero);
                        if (TotalTecoAmt + pay_amt > CourtChargeBase)
                            pay_amt = pay_amt - (TotalTecoAmt + pay_amt - CourtChargeBase);
                        if (pay_amt > amt_has_to_pay)
                        {
                            pay_amt = amt_has_to_pay;
                        }
                        pay_amt = Math.Round(pay_amt, MidpointRounding.AwayFromZero);
                        TotalTecoAmt += pay_amt;
                        WAGEDD wagedd = new WAGEDD();
                        wagedd.ACNO = itm.SALBASND.ACNO;
                        wagedd.AMT = JBModule.Data.CEncrypt.Number(pay_amt);
                        wagedd.KEY_DATE = DateTime.Now;
                        wagedd.KEY_MAN = MainForm.USER_NAME;
                        wagedd.NOBR = itm.SALBASND.NOBR;
                        wagedd.SAL_CODE = itm.SALBASND.SAL_CODE;
                        wagedd.SEQ = SEQ;
                        wagedd.YYMM = YYMM;
                        db.WAGEDD.InsertOnSubmit(wagedd);
                    } 
                }
            }
            db.SubmitChanges();
        }
        public void SalbastdCalc1()
        {
            List<string> ttscodeList = new List<string>();
            ttscodeList.Add("1");
            ttscodeList.Add("4");
            ttscodeList.Add("6");
            var EmpList_full1 = (from a in smd.BASETTS
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
                                select new { a.NOBR, a.ADATE, a.DDATE });

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
                               where b.NOBR.CompareTo(NOBR_B) >= 0 && b.NOBR.CompareTo(NOBR_E) <= 0
                               && e.D_NO_DISP.CompareTo(DEPT_B) >= 0 && e.D_NO_DISP.CompareTo(DEPT_E) <= 0
                               && DATE_E >= b.ADATE && DATE_E <= b.DDATE.Value
                               //&& c.SOS_ID == "1"
                               //&& a.SAL_CODE != MainForm.SalaryConfig.ATTAWARDSALCODE
                               //&& !c.NOTFREQ
                               && a.ADATE <= DATE_E && a.DDATE >= DATE_B
                               && b.INDT <= InEDate
                               //&& db.GetFilterByNobr(a.NOBR, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value
                               && db.UserReadDataGroupList(MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Select(p => p.DATAGROUP).Contains(b.SALADR)
                               select new { a.NOBR, a.ADATE, a.DDATE, a.SAL_CODE, a.AMT, c.MONTHTYPE, c.CAL_FREQ, c.DEFINEDAYS }).ToList();

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
                    bc.CustomDays = salbasdRow.DEFINEDAYS > 0 ? salbasdRow.DEFINEDAYS : 30M;
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
                    WAGED waged = new WAGED();
                    waged.AMT = JBModule.Data.CEncrypt.Number(amt45);
                    waged.NOBR = salbasdRow.NOBR;
                    waged.SAL_CODE = salbasdRow.SAL_CODE;
                    waged.SEQ = SEQ;
                    waged.YYMM = YYMM;
                    InsertWaged(waged);

                }
            }

        }
        public void SalbastdCalc()
        {
            List<string> ttscodeList = new List<string>();
            ttscodeList.Add("1");
            ttscodeList.Add("4");
            ttscodeList.Add("6");
            var sql_full = (from a in smd.BASETTS
                      join b in smd.SALBASTD on a.NOBR equals b.NOBR into ab
                      from salbastd in ab
                      join c in smd.SALCODE on salbastd.SAL_CODE equals c.SAL_CODE
                      join d in smd.SALATTR on c.SAL_ATTR equals d.SALATTR1
                      join e in smd.DEPT on a.DEPT equals e.D_NO
					  //join wrnt in smd.WriteRuleNobrTable.Where(p => p.GUID == guid) on a.NOBR equals wrnt.EMPID																						
                      where ttscodeList.Contains(a.TTSCODE)
                      && a.NOBR.CompareTo(NOBR_B) >= 0 && a.NOBR.CompareTo(NOBR_E) <= 0
                      && e.D_NO_DISP.CompareTo(DEPT_B) >= 0 && e.D_NO_DISP.CompareTo(DEPT_E) <= 0
                      //&& (MainForm.PROCSUPER || a.SALADR == MainForm.WORKADR)
                      && DATE_B <= a.DDATE && DATE_E >= a.ADATE
                      && !a.NOWAGE//須計算薪資
                      && a.ADATE <= salbastd.DDATE && a.DDATE >= salbastd.ADATE
                      //&& smd.GetFilterByNobr(a.NOBR, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value
                      && smd.UserReadDataGroupList(MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Select(p => p.DATAGROUP).Contains(a.SALADR)
                      select new { BASETTS = a, SALBASD = salbastd, SALCODE = c }).ToList();
            var sql = sql_full.GroupBy(p => p.BASETTS);
            var groupSQL = from row in sql group row by row.Key.NOBR into g1 select g1;
            int counts = groupSQL.Count();
            decimal monthDays = Convert.ToInt32((DATE_E - DATE_B).TotalDays) + 1;
            foreach (var basettsGroup in groupSQL)//所以需要計算薪資的工號
            {
                var basettsList = basettsGroup;
                //異動資料在計算區間內的天數
                decimal Adays = basettsList.Sum(row =>
                    Function.RangeMix(row.Key.ADATE, row.Key.DDATE.Value, DATE_B, DATE_E));
                var MonthDays = Convert.ToInt32((DATE_E - DATE_B).TotalDays) + 1;
                bool FullWork = (Adays == MonthDays);//是否整月在值
                //WorkDaysList.Add(basettsGroup.Key, Adays);
                foreach (var gp in basettsGroup)//每個人的異動資料
                {
                    foreach (var itm in gp)
                    {
                        decimal basettsDays = Function.RangeMix(gp.Key.ADATE, gp.Key.DDATE.Value, DATE_B, DATE_E);
                        if (basettsDays <= 0) continue;
                        decimal salbastdDays = Function.RangeMix(itm.SALBASD.ADATE, itm.SALBASD.DDATE, DATE_B, DATE_E);
                        if (salbastdDays <= 0) continue;

                        DateTime d1 = Function.MaxValueB(gp.Key.ADATE, DATE_B);
                        DateTime d2 = Function.MinValueE(gp.Key.DDATE.Value, DATE_E);
                        decimal amt = 0;
                        if (FullWork)//整月在職
                        {
                            amt = Function.RangeMix(itm.SALBASD.ADATE, itm.SALBASD.DDATE, d1, d2)//有效天數
                            * JBModule.Data.CDecryp.Number(itm.SALBASD.AMT)//薪資科目金額
                            / monthDays;//月曆天
                        }
                        else//破月
                        {
                            amt = JBModule.Data.CDecryp.Number(itm.SALBASD.AMT);//預設全給
                            if (itm.SALCODE.MONTHTYPE == "2")
                            {
                                amt = Function.RangeMix(itm.SALBASD.ADATE, itm.SALBASD.DDATE, d1, d2)
                                 * JBModule.Data.CDecryp.Number(itm.SALBASD.AMT)//薪資科目金額
                                 / MonthDays;//30天
                            }
                            else if (itm.SALCODE.MONTHTYPE == "3")
                            {
                                amt = Function.RangeMix(itm.SALBASD.ADATE, itm.SALBASD.DDATE, d1, d2)
                                * JBModule.Data.CDecryp.Number(itm.SALBASD.AMT)//薪資科目金額
                                / 30;//30天
                            }
                            else if (itm.SALCODE.MONTHTYPE == "4")
                            {
                                if (itm.SALCODE.DEFINEDAYS <= 0)
                                {
                                    throw new Exception("薪資代碼月給總額選擇自訂天數時，自訂天數不可以是0");
                                }
                                amt = Function.RangeMix(itm.SALBASD.ADATE, itm.SALBASD.DDATE, d1, d2)
                                 * JBModule.Data.CDecryp.Number(itm.SALBASD.AMT)//薪資科目金額
                                 / itm.SALCODE.DEFINEDAYS;
                            }
                        }

                        decimal amt45 = Math.Round(amt, MidpointRounding.AwayFromZero);
                        WAGED waged = new WAGED();
                        waged.AMT = JBModule.Data.CEncrypt.Number(amt45);
                        waged.NOBR = itm.BASETTS.NOBR;
                        waged.SAL_CODE = itm.SALBASD.SAL_CODE;
                        waged.SEQ = SEQ;
                        waged.YYMM = YYMM;
                        InsertWaged(waged);

                    }
                }

            }
        }


        void FullAttend()
        {//clone from rebar @20180204
            List<string> ttscodeList = new List<string>();
            ttscodeList.Add("1");
            ttscodeList.Add("4");
            ttscodeList.Add("6");
            string FAttSalcode = MainForm.SalaryConfig.ATTAWARDSALCODE;
            //切割日期
            int DivDay = 15;
            int DivDay1 = 15;

            int total_days = Convert.ToInt32((DATE_E - DATE_B).TotalDays) + 1;//整月在職的天數
            Sal.Core.SalaryDate salaryDate = new SalaryDate(this.YYMM);
            SalaryMDDataContext db = new SalaryMDDataContext();
            //DateTime halfDate1 = new DateTime(salaryDate.Year, salaryDate.Month, DivDay);
            //DateTime halfDate2 = new DateTime(salaryDate.Year, salaryDate.Month, DivDay + 1);
            //int Upper_days = Convert.ToInt32((halfDate1 - DATE_B).TotalDays) + 1;
            //int Lower_days = Convert.ToInt32((DATE_E - halfDate2).TotalDays) + 1;
            var sql = from a in db.SALBASD
                      join b in db.BASETTS on a.NOBR equals b.NOBR
                      join c in db.ROTET on b.ROTET equals c.ROTET1
                      join d in db.DEPT on b.DEPT equals d.D_NO
					  //join wrnt in db.WriteRuleNobrTable.Where(p => p.GUID == guid) on a.NOBR equals wrnt.EMPID																						   
                      where b.NOBR.CompareTo(NOBR_B) >= 0 && b.NOBR.CompareTo(NOBR_E) <= 0
                      && d.D_NO_DISP.CompareTo(DEPT_B) >= 0 && d.D_NO_DISP.CompareTo(DEPT_E) <= 0
                      && DATE_E >= b.ADATE && DATE_E <= b.DDATE.Value
                      && DATE_E >= a.ADATE && DATE_E <= a.DDATE
                      && a.SAL_CODE == FAttSalcode//全勤
                      && a.AMT != 0//只抓有金額的
                      //&& db.GetFilterByNobr(a.NOBR, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value
                      && db.UserReadDataGroupList(MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Select(p => p.DATAGROUP).Contains(b.SALADR)
                      select new
                      {
                          a.NOBR,
                          a.AMT,
                          FATTAMT = c.FATTAMT != null ? c.FATTAMT.Value : 0,
                          InDT = b.INDT.Value,
                          OutDT = b.OUDT,
                          b.HOLI_CODE,
                      };

            //請假資料
            var absSQL = (from a in db.ABS
                          join b in db.HCODE on a.H_CODE equals b.H_CODE
                          join c in db.BASETTS on a.NOBR equals c.NOBR
                          join f in db.DEPT on c.DEPT equals f.D_NO
						  //join wrnt in db.WriteRuleNobrTable.Where(p => p.GUID == guid) on a.NOBR equals wrnt.EMPID																					   
                          where a.BDATE.CompareTo(DATE_B) >= 0 && a.BDATE.CompareTo(DATE_E) <= 0
                          && DATE_E >= c.ADATE && DATE_E <= c.DDATE.Value
                          && c.NOBR.CompareTo(NOBR_B) >= 0 && c.NOBR.CompareTo(NOBR_E) <= 0
                          && f.D_NO_DISP.CompareTo(DEPT_B) >= 0 && f.D_NO_DISP.CompareTo(DEPT_E) <= 0
                          //&& db.GetFilterByNobr(a.NOBR, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value
                          && b.ATT
                          //group a by a.NOBR into gp
                          && db.UserReadDataGroupList(MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Select(p => p.DATAGROUP).Contains(c.SALADR)
                          select new { NOBR = a.NOBR, a.BDATE, a.TOL_HOURS }).ToList();

            DateTime AttMidDate1, AttMidDate2;
            AttMidDate1 = new DateTime(salaryDate.Year, salaryDate.Month, DivDay1);
            AttMidDate2 = new DateTime(salaryDate.Year, salaryDate.Month, DivDay1 + 1);
            DateTime SalMidDate1, SalMidDate2;
            SalMidDate1 = new DateTime(salaryDate.Year, salaryDate.Month, DivDay);
            SalMidDate2 = new DateTime(salaryDate.Year, salaryDate.Month, DivDay + 1);
            var basettsSQL = (from a in db.BASETTS
                              join b in db.BASETTS on a.NOBR equals b.NOBR
                              join d in db.DEPT on b.DEPT equals d.D_NO
						      //join wrnt in db.WriteRuleNobrTable.Where(p => p.GUID == guid) on a.NOBR equals wrnt.EMPID																					   
                              where b.NOBR.CompareTo(NOBR_B) >= 0 && b.NOBR.CompareTo(NOBR_E) <= 0
                              && d.D_NO_DISP.CompareTo(DEPT_B) >= 0 && d.D_NO_DISP.CompareTo(DEPT_E) <= 0
                              && DATE_E >= b.ADATE && DATE_E <= b.DDATE.Value
                              && DATE_B <= a.DDATE.Value && DATE_E >= a.ADATE
                              && ttscodeList.Contains(a.TTSCODE)
                              //&& db.GetFilterByNobr(b.NOBR, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value
                              && db.UserReadDataGroupList(MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Select(p => p.DATAGROUP).Contains(a.SALADR)
                              select new
                              {
                                  a.NOBR,
                                  a.TTSCODE,
                                  a.ADATE,
                                  DDATE = a.DDATE.Value,
                              }).ToList();

            foreach (var itm in sql)
            {
                //上半月請假
                var absSQLofNobr1 = from a in absSQL
                                    where a.NOBR == itm.NOBR && a.BDATE <= AttMidDate1
                                    select a;
                //下半月請假
                var absSQLofNobr2 = from a in absSQL
                                    where a.NOBR == itm.NOBR && a.BDATE >= AttMidDate2
                                    select a;
                decimal ABS_HRS1 = 0;//上半月請假時數
                decimal ABS_HRS2 = 0;//下半月請假時數
                if (absSQLofNobr1.Any())
                    ABS_HRS1 = absSQLofNobr1.First().TOL_HOURS;
                if (absSQLofNobr2.Any())
                    ABS_HRS2 = absSQLofNobr2.First().TOL_HOURS;
                decimal amt = JBModule.Data.CDecryp.Number(itm.AMT);//完整金額
                decimal famt = amt;
                decimal famtHalf = amt / 2;
                decimal discount1 = 0, discount2 = 0;
                if (ABS_HRS1 > 0 && ABS_HRS1 < MainForm.SalaryConfig.ATTQTY)
                {
                    discount1 += famtHalf * MainForm.SalaryConfig.ATTAMT.Value / 100;
                }
                else if (ABS_HRS1 > 0 && ABS_HRS1 >= MainForm.SalaryConfig.ATTQTY1)
                {
                    discount1 += famtHalf * MainForm.SalaryConfig.ATTAMT1.Value / 100;
                }
                if (ABS_HRS2 > 0 && ABS_HRS2 < MainForm.SalaryConfig.ATTQTY)
                {
                    discount1 += famtHalf * MainForm.SalaryConfig.ATTAMT.Value / 100;
                }
                else if (ABS_HRS2 > 0 && ABS_HRS2 >= MainForm.SalaryConfig.ATTQTY1)
                {
                    discount2 += famtHalf * MainForm.SalaryConfig.ATTAMT1.Value / 100;
                }

                var basettsSQLofNobr = from a in basettsSQL where a.NOBR == itm.NOBR select a;
                int TotalWorkDaysUpper = 0, TotalWorkDaysLower = 0;
                JBTools.Intersection itsUpper = new JBTools.Intersection();
                itsUpper.Inert(DATE_B, AttMidDate1);
                var total_daysUpper = itsUpper.GetDays();
                JBTools.Intersection itsLower = new JBTools.Intersection();
                itsLower.Inert(DATE_B, AttMidDate1);
                var total_daysLower = itsLower.GetDays();
                foreach (var rs in basettsSQLofNobr)
                {
                    JBTools.Intersection itsUpperCheck = new JBTools.Intersection();
                    itsUpperCheck.Inert(DATE_B, AttMidDate1);
                    itsUpperCheck.Inert(rs.ADATE, rs.DDATE);
                    TotalWorkDaysUpper += itsUpperCheck.GetDays();

                    JBTools.Intersection itsLowerCheck = new JBTools.Intersection();
                    itsLowerCheck.Inert(AttMidDate1, DATE_E);
                    itsLowerCheck.Inert(rs.ADATE, rs.DDATE);
                    TotalWorkDaysLower += itsLowerCheck.GetDays();
                }
                if (TotalWorkDaysUpper < total_daysUpper)//非整月在職
                {
                    discount1 = famtHalf;//不給                   
                }
                if (TotalWorkDaysLower < total_daysLower)//非整月在職
                {
                    discount2 = famtHalf;//不給                   
                }

                //設定不可以超扣
                if (famtHalf < discount1) discount1 = famtHalf;
                if (famtHalf < discount2) discount2 = famtHalf;

                decimal fa_amt = famt - discount1 - discount2;
                if (fa_amt <= 0) continue;//沒有全勤

                WAGED waged = new WAGED();
                waged.AMT = JBModule.Data.CEncrypt.Number(Math.Round(fa_amt, MidpointRounding.AwayFromZero));
                waged.NOBR = itm.NOBR;
                waged.SAL_CODE = FAttSalcode;
                waged.SEQ = SEQ;
                waged.YYMM = YYMM;
                InsertWaged(waged);
            }
        }
        void IntroductorBonusCalc()
        {
            DateTime d1, d2;
            d1 = DATE_B.AddMonths(-3);
            d2 = DATE_E.AddMonths(-3);
            var db = new JBModule.Data.Linq.HrDBDataContext();
            var sql = from a in db.BASETTS
                      join b in db.BASE on a.NOBR equals b.NOBR
                      join c in db.BASE on b.Introductor equals c.NOBR//去除不存在的工號
                      join d in db.DEPT on a.DEPT equals d.D_NO
					  //join wrnt in db.WriteRuleNobrTable.Where(p => p.GUID == guid) on a.NOBR equals wrnt.EMPID																					   
                      where a.NOBR.CompareTo(NOBR_B) >= 0 && a.NOBR.CompareTo(NOBR_E) <= 0
                      && d.D_NO_DISP.CompareTo(DEPT_B) >= 0 && d.D_NO_DISP.CompareTo(DEPT_E) <= 0
                      && DATE_E >= a.ADATE && DATE_E <= a.DDATE.Value
                      && b.Introductor.Trim().Length > 0 && b.IntroductionBonus != null && b.IntroductionBonus.Value
                      && a.INDT.Value >= d1 && a.INDT.Value <= d2
                      //&& db.GetFilterByNobr(a.NOBR, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value
                      && db.UserReadDataGroupList(MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Select(p => p.DATAGROUP).Contains(a.SALADR)
                      select new { a.NOBR, a.INDT, b.Introductor };
            foreach (var it in sql)
            {
                WAGED waged = new WAGED();
                waged.AMT = JBModule.Data.CEncrypt.Number(MainForm.SalaryConfig.ATTMONAMT.Value);
                waged.NOBR = it.Introductor;
                waged.SAL_CODE = MainForm.OvertimeConfig.OTFOODSALCODE1;
                waged.SEQ = SEQ;
                waged.YYMM = YYMM;
                InsertWaged(waged);
            }
        }

        void InsertWaged(WAGED waged)
        {
            if (salcodeData.Select(p => p.SAL_CODE).ToList().Contains(waged.SAL_CODE))
            {
                if (waged.AMT == 10)//如果金額是0就略過
                    return;
                var ExistWagedOfNobr = (from rWaged in wagedList where rWaged.NOBR.Trim() == waged.NOBR.Trim() && rWaged.SAL_CODE.Trim() == waged.SAL_CODE.Trim() select rWaged).FirstOrDefault();
                //如果是已存在的科目就累加，否則就新增
                if (ExistWagedOfNobr != null) ExistWagedOfNobr.AMT =
                    JBModule.Data.CEncrypt.Number(JBModule.Data.CDecryp.Number(ExistWagedOfNobr.AMT)
                    + JBModule.Data.CDecryp.Number(waged.AMT));
                else wagedList.Add(waged);

                TransWagedListG01ToG02Salcode(waged);
            }
            else
            {
                JBModule.Message.TextLog.WriteLog("不存在的薪資代碼" + waged.SAL_CODE + "。");
            }
        }

        private void TransWagedListG01ToG02Salcode(WAGED waged)
        {
            AppConfig = new JBModule.Data.ApplicationConfigSettings("FRM4I", MainForm.COMPANY);
            string ForeignFoodSalcode = AppConfig.GetConfig("ForeignFoodSalcode").GetString("");
            string ForeignFoodSalcodeTax = AppConfig.GetConfig("ForeignFoodSalcodeTax").GetString("");
            decimal ForeignFoodNuTaxMaxAmt = AppConfig.GetConfig("ForeignFoodNuTaxMaxAmt").GetDecimal(0);
            if (ForeignFoodSalcode == "" || ForeignFoodSalcodeTax == "") return;
            if (waged.SAL_CODE != ForeignFoodSalcode) return;
            if (!salcodeData.Select(p => p.SAL_CODE).ToList().Contains(waged.SAL_CODE)) return;

            var G01WagedOfNobr = (from rWaged in wagedList where rWaged.NOBR.Trim() == waged.NOBR.Trim() && rWaged.SAL_CODE.Trim() == ForeignFoodSalcode select rWaged).FirstOrDefault();
            var G02WagedOfNobr = (from rWaged in wagedList where rWaged.NOBR.Trim() == waged.NOBR.Trim() && rWaged.SAL_CODE.Trim() == ForeignFoodSalcodeTax select rWaged).FirstOrDefault();
            var g01totalAmt = JBModule.Data.CDecryp.Number(G01WagedOfNobr.AMT);
            if (g01totalAmt <= ForeignFoodNuTaxMaxAmt) return;
            decimal disCount = g01totalAmt - ForeignFoodNuTaxMaxAmt;
            if (disCount > 0)
            {
                G01WagedOfNobr.AMT = JBModule.Data.CEncrypt.Number(JBModule.Data.CDecryp.Number(G01WagedOfNobr.AMT) - disCount);
                if (G02WagedOfNobr != null)
                    G02WagedOfNobr.AMT = JBModule.Data.CEncrypt.Number(JBModule.Data.CDecryp.Number(G02WagedOfNobr.AMT) + disCount);
                else
                {
                    var waged_temp = G01WagedOfNobr.Clone();
                    waged_temp.AMT = JBModule.Data.CEncrypt.Number(disCount);
                    waged_temp.SAL_CODE = ForeignFoodSalcodeTax;
                    wagedList.Add(waged_temp);
                }
            }
        }

        public void CreateWage()
        {
            var groupWaged = from l in wagedList group l by new { NOBR = l.NOBR.Trim(), SEQ = l.SEQ } into gp select gp;

            var enrich = (from rowEnrich in smd.ENRICH
                          join basetts in smd.BASETTS on rowEnrich.NOBR equals basetts.NOBR
                          join a in smd.DEPT on basetts.DEPT equals a.D_NO
						  //join wrnt in smd.WriteRuleNobrTable.Where(p => p.GUID == guid) on basetts.NOBR equals wrnt.EMPID																							  
                          where rowEnrich.YYMM == this.YYMM && rowEnrich.SEQ == SEQ
                          && basetts.NOBR.Trim().CompareTo(NOBR_B.Trim()) >= 0 && basetts.NOBR.Trim().CompareTo(NOBR_E.Trim()) <= 0
                          && a.D_NO_DISP.Trim().CompareTo(DEPT_B.Trim()) >= 0 && a.D_NO_DISP.Trim().CompareTo(DEPT_E.Trim()) <= 0
                          && DATE_E >= basetts.ADATE && DATE_E <= basetts.DDATE.Value
                          //&& smd.GetFilterByNobr(rowEnrich.NOBR, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value
                          && rowEnrich.MEMO.Trim().Length > 0
                          && smd.UserReadDataGroupList(MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Select(p => p.DATAGROUP).Contains(basetts.SALADR)
                          select rowEnrich).ToList();
            wageList = new List<WAGE>();
            var salcodeList = (from a in db.SALCODE select a).ToList();
            foreach (var wagedOfNobr in groupWaged)
            {
                WAGE wage = new WAGE();
                wage.NOBR = wagedOfNobr.Key.NOBR;
                //if (!wage.BASE.BASETTS.Any()) continue;
                decimal workDays = 0;
                if (WorkDaysList.ContainsKey(wagedOfNobr.Key.NOBR)) workDays = WorkDaysList[wagedOfNobr.Key.NOBR];
                var nobrEnrich = enrich.Where(p => p.NOBR == wagedOfNobr.Key.NOBR && wagedOfNobr.Key.SEQ == p.SEQ && p.MEMO.Length > 0);
                foreach (var it in wagedOfNobr)
                {
                    if (salcodeList.Where(p => p.SAL_CODE == it.SAL_CODE && p.SALBASD1).Any())
                    {
                        SALBASD1 salbasd1 = new SALBASD1();
                        salbasd1.YYMM = YYMM;
                        salbasd1.AMT = it.AMT;
                        salbasd1.AMTB = 1;
                        salbasd1.SEQ = it.SEQ;
                        salbasd1.KEY_DATE = DateTime.Now;
                        salbasd1.KEY_MAN = MainForm.USER_NAME;
                        salbasd1.MENO = "";
                        salbasd1.NOBR = it.NOBR;
                        salbasd1.SAL_CODE = it.SAL_CODE;
                        db.SALBASD1.InsertOnSubmit(salbasd1);
                    }
                }
                db.SubmitChanges();
                BASETTS basetts = (from b in smd.BASETTS where b.NOBR == wagedOfNobr.Key.NOBR && b.ADATE <= DATE_E && DATE_E <= b.DDATE select b).FirstOrDefault();

                BASE _base = (from b in smd.BASE where b.NOBR == wagedOfNobr.Key.NOBR select b).FirstOrDefault();
                if (_base == null || basetts == null || basetts.NOWAGE) continue;//如果勾不發薪//20130111額外判斷null,代表無人事資料                
                wage.KEY_DATE = DateTime.Now;
                wage.KEY_MAN = MainForm.USER_NAME;
                wage.NOTE = "";
                foreach (var it in nobrEnrich)
                    wage.NOTE += it.MEMO + ";";
                wage.SALADR = basetts.SALADR;
                wage.SEQ = wagedOfNobr.Key.SEQ;
                wage.TAXRATE = 1;
                if (TaxRateByNobr.Keys.Contains(wagedOfNobr.Key.NOBR))
                    wage.TAXRATE = TaxRateByNobr[wagedOfNobr.Key.NOBR];
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
                wage.ATT_DATEB = ATT_DATE_B;
                wage.ATT_DATEE = ATT_DATE_E;
                wage.FORMAT = this.Type;
                wageList.Add(wage);
                //db.WAGE.InsertOnSubmit(wage);
            }
            //db.WAGE.InsertAllOnSubmit(wageList);
            //ChangeSeq();
            //db.SubmitChanges();
        }
        public void CreateExpSup()
        {
            var groupWaged = from l in wagedList group l by l.NOBR into gp select gp;
            var BaseData = (from b in smd.BASETTS
                            join a in smd.BASE on b.NOBR equals a.NOBR
                            where b.ADATE <= DATE_E && DATE_E <= b.DDATE
                            && a.NOBR.CompareTo(NOBR_B) >= 0 && a.NOBR.CompareTo(NOBR_E) <= 0
                            select new { a.NOBR, a.BIRDT, a.COUNT_MA, b.NOWAGE, a.BASECD }).ToList();
            #region 二代健保補充保費
            SalaryDate sd = new SalaryDate(TRANS_DATE.ToString("yyyyMM"));
            DateTime y1, y2;
            y1 = new DateTime(TRANS_DATE.Year, 1, 1);
            y2 = new DateTime(TRANS_DATE.Year, 12, 31);
            var expsupList = (from a in db.EXPSUP
                              join b in db.BASETTS on a.NOBR equals b.NOBR
                              join c in db.DEPT on b.DEPT equals c.D_NO
                              where b.NOBR.CompareTo(NOBR_B) >= 0 && b.NOBR.CompareTo(NOBR_E) <= 0
                              && c.D_NO_DISP.CompareTo(DEPT_B) >= 0 && c.D_NO_DISP.CompareTo(DEPT_E) <= 0
                              && a.PAY_DATE >= y1 && a.PAY_DATE <= y2
                              && a.PAY_DATE >= b.ADATE && a.PAY_DATE <= b.DDATE.Value
                              && a.PAY_DATE < TRANS_DATE//不可同一天兩筆發薪，不然補充保費上傳會錯(健保局規定)
                              select a).ToList();            
            var insList = (from a in db.INSLAB
                           join b in db.BASETTS on a.NOBR equals b.NOBR
                           join c in db.DEPT on b.DEPT equals c.D_NO
                           where b.NOBR.CompareTo(NOBR_B) >= 0 && b.NOBR.CompareTo(NOBR_E) <= 0
                           && c.D_NO_DISP.CompareTo(DEPT_B) >= 0 && c.D_NO_DISP.CompareTo(DEPT_E) <= 0
                           && a.IN_DATE <= sd.LastDayOfMonth && a.OUT_DATE >= sd.FirstDayOfMonth.AddMonths(-5)
                           && DATE_E >= b.ADATE && DATE_E <= b.DDATE
                           && a.FA_IDNO.Trim().Length == 0
                           orderby a.IN_DATE descending
                           select a).ToList();
            var formatList = smd.YRFORMAT.ToList();
            var salcodeList = smd.SALCODE.ToList();
            var salattrList = db.SALATTR.ToList();
            #endregion
            //BASE _base = null;
            //BASETTS basetts = null;
            Dictionary<string, decimal> totalSupDic = new Dictionary<string, decimal>();
            //var basecd = db.BASECD.Select(p => new { p.BASECD1, p.SUP_TYPE }).ToList();
            var basecd = db.BASECD.Select(p => new { p.BASECD1, SUP_TYPE = "" }).ToList();////20130203暫時不實作

            foreach (var wagedOfNobr in groupWaged)
            {
                var baseItem = from a in BaseData where a.NOBR == wagedOfNobr.Key select a;
                var wageOfNobr = from a in wageList where a.NOBR == wagedOfNobr.Key select a;
                //basetts = baseItem.First().BASETTS;
                if (!baseItem.Any()) continue;//如果沒資料
                if (baseItem.First().NOWAGE) continue;//如果勾不發薪             
                //_base = baseItem.First().BASE;
                var empItem = baseItem.First();
                #region 二代健保補充保費
                decimal total_bonus = 0;
                //if (totalSupDic.ContainsKey(wagedOfNobr.Key)) total_bonus = totalSupDic[wagedOfNobr.Key];
                //else
                //{
                //var expsupOfNobr = expsupList.Where(p => p.NOBR == wagedOfNobr.Key);
                //if (expsupOfNobr.Any())
                //    total_bonus += expsupOfNobr.Sum(p => JBModule.Data.CDecryp.Number(p.PAY_AMT));
                //}
                var insOfNobr = insList.Where(p => p.NOBR == wagedOfNobr.Key);
                decimal H_AMT = 0;
                if (insOfNobr.Any())
                {
                    var insRow = insOfNobr.First();
                    if (insRow.NOSUP)//免收補充保費
                        continue;
                    H_AMT = JBModule.Data.CDecryp.Number(insOfNobr.First().H_AMT);
                    var expsupOfNobr = expsupList.Where(p => p.NOBR == wagedOfNobr.Key && p.S_NO == insOfNobr.First().S_NO);//同一公司累計
                    if (expsupOfNobr.Any())
                        total_bonus = expsupOfNobr.Sum(p => JBModule.Data.CDecryp.Number(p.PAY_AMT));
                }
                if (MainForm.HealthConfig.SUPPLEHINSLABSALCODE == null)
                {
                    if (BW != null)
                        BW.ReportProgress(50, "尚未設定補充保費薪資代碼");
                    else
                        throw new NullReferenceException("尚未設定補充保費薪資代碼");
                    return;
                }
                decimal H_AMTX4 = H_AMT * MainForm.HealthConfig.BONUSYEARRATEMAX.Value;

                if (H_AMT > 0)//有投保，只算獎金累計超過四倍
                {
                    var wagedData = from a in wagedOfNobr
                                    join b in salcodeList on a.SAL_CODE equals b.SAL_CODE
                                    join c in salattrList on b.SAL_ATTR equals c.SALATTR1
                                    where b.SUP
                                    select new { a.NOBR, a.SAL_CODE, a.AMT, c.FLAG };
                    if (!wagedData.Any()) continue;//沒有補充保費的項目就略過
                    decimal current_amt = wagedData.Sum(p => p.FLAG != "-" ? JBModule.Data.CDecryp.Number(p.AMT) : JBModule.Data.CDecryp.Number(p.AMT) * -1);
                    total_bonus += current_amt;//累加
                    var format = formatList.Where(p => p.M_FORMAT.Trim() == this.Type.Trim()).FirstOrDefault();
                    decimal Over4xBonus = total_bonus - H_AMTX4;//超過四倍的部分
                    decimal sup_amt = 0;
                    if (Over4xBonus > 0)
                    {
                        decimal min = Over4xBonus < current_amt ? Over4xBonus : current_amt;//取小的金額x2%
                        sup_amt = Math.Round(min * MainForm.HealthConfig.SUPPLEINSLABRATE.Value, MidpointRounding.AwayFromZero);
                    }
                    WAGED waged = new WAGED();
                    waged.AMT = JBModule.Data.CEncrypt.Number(Math.Round(sup_amt, MidpointRounding.AwayFromZero));
                    waged.NOBR = wagedOfNobr.Key;
                    waged.SAL_CODE = MainForm.HealthConfig.SUPPLEHINSLABSALCODE;
                    waged.SEQ = SEQ;
                    waged.YYMM = YYMM;
                    if (!isReExpsup)
                        InsertWaged(waged);
                    EXPSUP sup = new EXPSUP();
                    sup.ADATE = y1;
                    sup.DDATE = y2;
                    sup.FORMAT = this.Type;
                    sup.INS_HAMT = JBModule.Data.CEncrypt.Number(H_AMT);
                    sup.KEY_DATE = DateTime.Now;
                    sup.KEY_MAN = MainForm.USER_NAME;
                    sup.NOBR = wagedOfNobr.Key;
                    sup.PAY_AMT = JBModule.Data.CEncrypt.Number(current_amt);
                    sup.PAY_DATE = this.TRANS_DATE;
                    sup.S_NO = "";
                    if (insOfNobr.Any()) sup.S_NO = insOfNobr.First().S_NO;
                    sup.SAL_CODE = "62";
                    sup.SEQ = this.SEQ;
                    sup.SUP_AMT = JBModule.Data.CEncrypt.Number(sup_amt);
                    sup.TOTAL_AMT = JBModule.Data.CEncrypt.Number(total_bonus);//兼職所得不累計
                    sup.YYMM = this.YYMM;
                    sup.SALADR = wageOfNobr.First().SALADR;
                    db.EXPSUP.InsertOnSubmit(sup);
                }
                else//兼職所得(無投保資料或金額)，應稅薪資2%
                {
                    var wagedData = from a in wagedOfNobr
                                    join b in salcodeList on a.SAL_CODE equals b.SAL_CODE
                                    join c in salattrList on b.SAL_ATTR equals c.SALATTR1
                                    where c.TAX//應稅
                                    select new { a.NOBR, a.SAL_CODE, a.AMT, c.FLAG };
                    decimal taxamt = wagedData.Sum(p => p.FLAG != "-" ? JBModule.Data.CDecryp.Number(p.AMT) : JBModule.Data.CDecryp.Number(p.AMT) * -1);
                    var format = formatList.Where(p => p.M_FORMAT.Trim() == this.Type.Trim()).FirstOrDefault();
                    var its = new JBTools.Intersection();
                    its.Inert(empItem.BIRDT.Value, TRANS_DATE);//到轉帳當天年齡
                    var iAge = Convert.ToDecimal(its.IntersectionTimeSpan.TotalDays / 365.24);
                    var basecdRow = basecd.Where(p => p.BASECD1 == empItem.BASECD);
                    //if (basecdRow.Any())
                    //{
                    //    //如果原本的設定有補休保費類別，就使用原本的
                    //    if (!(basecdRow.First().SUP_TYPE != null && basecdRow.First().SUP_TYPE.Trim().Length > 0) && iAge < 18M)
                    //        basecdRow = basecd.Where(p => p.BASECD1 == "O");
                    //    if (basecdRow.Any())
                    //        if (basecdRow.First().SUP_TYPE == "1")//免收補充保費
                    //            continue;
                    //        else if (basecdRow.First().SUP_TYPE == "2" && taxamt < MainForm.TaxConfig.FORSALBASD.Value * 2 / 3)//大於基本薪資才需收取補充保費(小於基本薪資不計費)
                    //            continue;
                    //}
                    decimal amt = taxamt < format.SUPPLEMAX ? taxamt : format.SUPPLEMAX;//不超過最大值
                    if (amt < format.SUPPLEMIN)
                        amt = 0;
                    WAGED waged = new WAGED();
                    decimal sup_amt = Math.Round(amt * format.FIXRATE, MidpointRounding.AwayFromZero);
                    waged.AMT = JBModule.Data.CEncrypt.Number(Math.Round(sup_amt, MidpointRounding.AwayFromZero));
                    waged.NOBR = wagedOfNobr.Key;
                    waged.SAL_CODE = MainForm.HealthConfig.SUPPLEHINSLABSALCODE;
                    waged.SEQ = SEQ;
                    waged.YYMM = YYMM;
                    if (!isReExpsup)
                        InsertWaged(waged);
                    EXPSUP sup = new EXPSUP();
                    sup.ADATE = y1;
                    sup.DDATE = y2;
                    sup.FORMAT = this.Type;
                    sup.INS_HAMT = JBModule.Data.CEncrypt.Number(H_AMT);
                    sup.KEY_DATE = DateTime.Now;
                    sup.KEY_MAN = MainForm.USER_NAME;
                    sup.NOBR = wagedOfNobr.Key;
                    sup.PAY_AMT = JBModule.Data.CEncrypt.Number(taxamt);
                    sup.PAY_DATE = this.TRANS_DATE;
                    sup.S_NO = "";
                    if (insOfNobr.Any()) sup.S_NO = insOfNobr.First().S_NO;
                    sup.SAL_CODE = "63";
                    sup.SEQ = this.SEQ;
                    sup.SUP_AMT = JBModule.Data.CEncrypt.Number(sup_amt);
                    sup.TOTAL_AMT = JBModule.Data.CEncrypt.Number(0);//兼職所得不累計
                    sup.YYMM = this.YYMM;
                    sup.SALADR = wageOfNobr.First().SALADR;
                    db.EXPSUP.InsertOnSubmit(sup);
                }
                #endregion

            }
            db.SubmitChanges();
        }
        void CheckFoodAmtMax()
        {
            var salcode = db.SALCODE.FirstOrDefault(pp => pp.SAL_CODE == MainForm.SalaryConfig.FOODSALCODE);
            if (salcode != null)
            {
                var query = from a in wagedList where a.SAL_CODE == MainForm.SalaryConfig.FOODSALCODE && JBModule.Data.CDecryp.Number(a.AMT) > salcode.MAX_AMT select a;
                List<WAGED> wagedList1 = new List<WAGED>();
                foreach (var it in query)
                {
                    decimal diff = JBModule.Data.CDecryp.Number(it.AMT) - salcode.MAX_AMT;
                    it.AMT = JBModule.Data.CEncrypt.Number(salcode.MAX_AMT);
                    //decimal amt = diff;
                    WAGED waged = new WAGED();
                    waged.AMT = JBModule.Data.CEncrypt.Number(diff);
                    waged.NOBR = it.NOBR;
                    waged.SAL_CODE = AppConfig.GetConfig("TaxableFoodCode").GetString("");
                    waged.SEQ = SEQ;
                    waged.YYMM = YYMM;
                    wagedList1.Add(waged);
                }
                foreach (var rr in wagedList1)
                {
                    InsertWaged(rr);
                }
            }
        }
        public void ReLoadWaged()
        {
            wagedList = (from a in db.WAGED
                         join b in db.BASETTS on a.NOBR equals b.NOBR
                         join c in db.DEPT on b.DEPT equals c.D_NO						                          
                         where DATE_E >= b.ADATE && DATE_E <= b.DDATE.Value
                         && b.NOBR.CompareTo(NOBR_B) >= 0 && b.NOBR.CompareTo(NOBR_E) <= 0
                         && c.D_NO_DISP.CompareTo(DEPT_B) >= 0 && c.D_NO_DISP.CompareTo(DEPT_E) <= 0
                         && a.YYMM == this.YYMM && a.SEQ == this.SEQ
                         //&& db.GetFilterByNobr(a.NOBR, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value
                         && db.UserReadDataGroupList(MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Select(p => p.DATAGROUP).Contains(b.SALADR)
                         select a).ToList();
            wageList = (from a in db.WAGE
                         join b in db.BASETTS on a.NOBR equals b.NOBR
                         join c in db.DEPT on b.DEPT equals c.D_NO
                         where DATE_E >= b.ADATE && DATE_E <= b.DDATE.Value
                         && b.NOBR.CompareTo(NOBR_B) >= 0 && b.NOBR.CompareTo(NOBR_E) <= 0
                         && c.D_NO_DISP.CompareTo(DEPT_B) >= 0 && c.D_NO_DISP.CompareTo(DEPT_E) <= 0
                         && a.YYMM == this.YYMM && a.SEQ == this.SEQ
                         //&& db.GetFilterByNobr(a.NOBR, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value
                         && db.UserReadDataGroupList(MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Select(p => p.DATAGROUP).Contains(b.SALADR)
                        select a).ToList();
        }
        public void WriteToDB()
        {
            try
            {
                smd.WAGE.InsertAllOnSubmit(wageList);
                smd.WAGED.InsertAllOnSubmit(wagedList);
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
        void ImportSalabs()
        {
            var salabs = from row in smd.SALABS
                         join basetts in smd.BASETTS on row.NOBR equals basetts.NOBR
                         join s in smd.SALCODE on row.MLSSALCODE equals s.SAL_CODE
                         join a in smd.SALATTR on s.SAL_ATTR equals a.SALATTR1
                         join b in smd.DEPT on basetts.DEPT equals b.D_NO
						 //join wrnt in smd.WriteRuleNobrTable.Where(p => p.GUID == guid) on basetts.NOBR equals wrnt.EMPID																								 
                         where row.YYMM == this.YYMM
                         && row.ADATE.CompareTo(basetts.ADATE) >= 0 && row.ADATE.CompareTo(basetts.DDATE.Value) <= 0
                         && basetts.NOBR.CompareTo(NOBR_B) >= 0 && basetts.NOBR.CompareTo(NOBR_E) <= 0
                         && b.D_NO_DISP.CompareTo(DEPT_B) >= 0 && b.D_NO_DISP.CompareTo(DEPT_E) <= 0
                         //&& (basetts.SALADR == MainForm.WORKADR || MainForm.PROCSUPER)
                         //&& smd.GetFilterByNobr(row.NOBR, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value
                         && smd.UserReadDataGroupList(MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Select(p => p.DATAGROUP).Contains(basetts.SALADR)
                         select new { SALABS = row, SALATTR = a };
            foreach (var row in salabs)
            {
                WAGED waged = new WAGED();
                if (row.SALATTR.FLAG != "-")//如果屬性是不是減項(代表加項)，就要扣掉
                    waged.AMT = JBModule.Data.CEncrypt.Number(JBModule.Data.CDecryp.Number(row.SALABS.AMT) * -1);
                else
                    waged.AMT = row.SALABS.AMT;
                waged.NOBR = row.SALABS.NOBR;
                waged.SAL_CODE = row.SALABS.MLSSALCODE;
                waged.SEQ = this.SEQ;
                waged.YYMM = this.YYMM;
                InsertWaged(waged);
            }
        }
        void MinWageCalc()
        {
            AppConfig = new JBModule.Data.ApplicationConfigSettings("FRM4I", MainForm.COMPANY);
            string NoPayDeductionCode = AppConfig.GetConfig("NoPayDeductionCode").GetString("D04");
            string minWageCode = AppConfig.GetConfig("MinWageCode").GetString("A01");
            int minAmt = AppConfig.GetConfig("MinAmt").GetInter(20008);


            var EmpWagedList = (from a in wagedList
                                join b in db.BASETTS on a.NOBR equals b.NOBR
                                join c in db.DEPT on b.DEPT equals c.D_NO
							    //join wrnt in db.WriteRuleNobrTable.Where(p => p.GUID == guid) on a.NOBR equals wrnt.EMPID																							 
                                where DATE_E >= b.ADATE && DATE_E <= b.DDATE.Value
                                && b.NOBR.CompareTo(NOBR_B) >= 0 && b.NOBR.CompareTo(NOBR_E) <= 0
                                && new string[] { "1", "4", "6" }.Contains(b.TTSCODE)
                                && c.D_NO_DISP.CompareTo(DEPT_B) >= 0 && c.D_NO_DISP.CompareTo(DEPT_E) <= 0
                                && a.YYMM == this.YYMM && a.SEQ == this.SEQ
                                && a.SAL_CODE == NoPayDeductionCode
                                //&& db.GetFilterByNobr(a.NOBR, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value
                                && db.UserReadDataGroupList(MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Select(p => p.DATAGROUP).Contains(b.SALADR)
                                select a).ToList();

            var salCodeList = (from a in db.SALCODE
                               join b in db.SALATTR on a.SAL_ATTR equals b.SALATTR1
                               where a.SOS_ID == "1"
                               && !a.NOTFREQ
                               && b.BASIC
                               select a.SAL_CODE).ToList();



            foreach (var emp in EmpWagedList)
            {
                var sumBaseSalList = (from a in wagedList
                                      where a.NOBR == emp.NOBR
                                      && salCodeList.Contains(a.SAL_CODE)
                                      select a).ToList();
                //本薪總金額
                var totalBaseSal = sumBaseSalList.Sum(p => JBModule.Data.CDecryp.Number(p.AMT));
                CodeMDDataContext cdc = new CodeMDDataContext();

                //本薪大於等於最低薪資才要檢查
                if (totalBaseSal >= minAmt)
                {
                    //實得本薪
                    var tempAmt = totalBaseSal - JBModule.Data.CDecryp.Number(emp.AMT);

                    //實得本薪如果小於最低薪資
                    if (tempAmt < minAmt)
                    {
                        var addAmt = minAmt - tempAmt;//系統會補足至基本工資金額


                        WAGED waged = new WAGED();
                        waged.AMT = JBModule.Data.CEncrypt.Number(addAmt);
                        waged.NOBR = emp.NOBR;
                        waged.SAL_CODE = minWageCode;
                        waged.SEQ = this.SEQ;
                        waged.YYMM = this.YYMM;
                        InsertWaged(waged);

                    }
                }
            }
        }
        void ImportOt()
        {
            string no_tax = MainForm.OvertimeConfig.NOTAXSALCODE;
            string tax = MainForm.OvertimeConfig.TOTAXSALCODE;
            string night = MainForm.OvertimeConfig.OTFOODSALCODE;
            string food = MainForm.SalaryConfig.EATSALCODE;
            string car = "B07";

            var ot = from row in smd.OT
                     join basetts in smd.BASETTS on row.NOBR equals basetts.NOBR
                     join b in smd.DEPT on basetts.DEPT equals b.D_NO
					 //join wrnt in smd.WriteRuleNobrTable.Where(p => p.GUID == guid) on row.NOBR equals wrnt.EMPID																							 
                     where row.YYMM == this.YYMM
                     && row.BDATE.CompareTo(basetts.ADATE) >= 0 && row.BDATE.CompareTo(basetts.DDATE.Value) <= 0
                     && basetts.NOBR.CompareTo(NOBR_B) >= 0 && basetts.NOBR.CompareTo(NOBR_E) <= 0
                     && b.D_NO_DISP.CompareTo(DEPT_B) >= 0 && b.D_NO_DISP.CompareTo(DEPT_E) <= 0
                     //&& smd.GetFilterByNobr(row.NOBR, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value
                     && smd.UserReadDataGroupList(MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Select(p => p.DATAGROUP).Contains(basetts.SALADR)
                     select row;
            foreach (var row in ot)
            {
                WAGED waged = new WAGED();
                waged.AMT = row.NOT_EXP;
                waged.NOBR = row.NOBR;
                waged.SAL_CODE = no_tax;
                waged.SEQ = this.SEQ;
                waged.YYMM = this.YYMM;
                if (waged.AMT > 10)//大於0
                    InsertWaged(waged);

                waged = new WAGED();
                waged.AMT = row.TOT_EXP;
                waged.NOBR = row.NOBR;
                waged.SAL_CODE = tax;
                waged.SEQ = this.SEQ;
                waged.YYMM = this.YYMM;
                if (waged.AMT > 10)//大於0
                    InsertWaged(waged);

                waged = new WAGED();
                waged.AMT = row.OT_FOOD;
                waged.NOBR = row.NOBR;
                waged.SAL_CODE = night;
                waged.SEQ = this.SEQ;
                waged.YYMM = this.YYMM;
                if (waged.AMT > 10)//大於0
                    InsertWaged(waged);

                waged = new WAGED();
                waged.AMT = JBModule.Data.CEncrypt.Number(row.OT_FOOD1);
                waged.NOBR = row.NOBR;
                waged.SAL_CODE = food;
                waged.SEQ = this.SEQ;
                waged.YYMM = this.YYMM;
                if (waged.AMT > 10)//大於0
                    InsertWaged(waged);

                waged = new WAGED();
                waged.AMT = row.OT_CAR;
                waged.NOBR = row.NOBR;
                waged.SAL_CODE = car;
                waged.SEQ = this.SEQ;
                waged.YYMM = this.YYMM;
                if (waged.AMT > 10)//大於0
                    InsertWaged(waged);
            }
        }
        void ImportInslab()
        {
            var explab = (from rowExplab in smd.EXPLAB
                          join basetts in smd.BASETTS on rowExplab.NOBR equals basetts.NOBR
                          join d in smd.DEPT on basetts.DEPT equals d.D_NO
						  //join wrnt in smd.WriteRuleNobrTable.Where(p => p.GUID == guid) on rowExplab.NOBR equals wrnt.EMPID																									
                          where rowExplab.SAL_YYMM == this.YYMM
                          && DATE_E >= basetts.ADATE && DATE_E <= basetts.DDATE
                          && basetts.NOBR.CompareTo(NOBR_B) >= 0 && basetts.NOBR.CompareTo(NOBR_E) <= 0
                          && d.D_NO_DISP.CompareTo(DEPT_B) >= 0 && d.D_NO_DISP.CompareTo(DEPT_E) <= 0
                          //&& smd.GetFilterByNobr(rowExplab.NOBR, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value
                          && smd.UserReadDataGroupList(MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Select(p => p.DATAGROUP).Contains(basetts.SALADR)
                          select rowExplab).Distinct();
            foreach (var row in explab)
            {
                WAGED waged = new WAGED();
                waged.AMT = row.EXP;
                waged.NOBR = row.NOBR;
                waged.SAL_CODE = row.SAL_CODE;
                waged.SEQ = this.SEQ;
                waged.YYMM = this.YYMM;
                InsertWaged(waged);
            }
        }
        public void ImportEnrich()
        {
            var enrich = from rowEnrich in smd.ENRICH
                         join basetts in smd.BASETTS on rowEnrich.NOBR equals basetts.NOBR
                         join a in smd.DEPT on basetts.DEPT equals a.D_NO
						 //join wrnt in smd.WriteRuleNobrTable.Where(p => p.GUID == guid) on rowEnrich.NOBR equals wrnt.EMPID																								   
                         where rowEnrich.YYMM == this.YYMM && rowEnrich.SEQ == SEQ
                         && basetts.NOBR.Trim().CompareTo(NOBR_B.Trim()) >= 0 && basetts.NOBR.Trim().CompareTo(NOBR_E.Trim()) <= 0
                         && a.D_NO_DISP.Trim().CompareTo(DEPT_B.Trim()) >= 0 && a.D_NO_DISP.Trim().CompareTo(DEPT_E.Trim()) <= 0
                         && DATE_E >= basetts.ADATE && DATE_E <= basetts.DDATE.Value
                         && smd.UserReadDataGroupList(MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Select(p => p.DATAGROUP).Contains(basetts.SALADR)
                         select rowEnrich;
            foreach (var row in enrich)
            {
                WAGED waged = new WAGED();
                waged.AMT = row.AMT;
                if (waged.AMT == 0) waged.AMT = 10;
                waged.NOBR = row.NOBR;
                waged.SAL_CODE = row.SAL_CODE;
                waged.SEQ = this.SEQ;
                waged.YYMM = this.YYMM;
                InsertWaged(waged);
            }
        }

        public void ImportSalEnrich()
        {
            var salenrich = from rowEnrich in smd.SALENRICH
                            join basetts in smd.BASETTS on rowEnrich.NOBR equals basetts.NOBR
                            join a in smd.DEPT on basetts.DEPT equals a.D_NO
                            where rowEnrich.YYMM == this.YYMM && rowEnrich.SEQ == SEQ
                            && rowEnrich.NOBR.Trim().CompareTo(NOBR_B.Trim()) >= 0 && rowEnrich.NOBR.Trim().CompareTo(NOBR_E.Trim()) <= 0
                            && a.D_NO_DISP.Trim().CompareTo(DEPT_B.Trim()) >= 0 && a.D_NO_DISP.Trim().CompareTo(DEPT_E.Trim()) <= 0
                            && DATE_E >= basetts.ADATE && DATE_E <= basetts.DDATE.Value
                            && smd.GetFilterByNobr(rowEnrich.NOBR, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value
                            select rowEnrich;
            foreach (var row in salenrich)
            {
                WAGED waged = new WAGED();
                waged.AMT = row.AMT;
                if (waged.AMT == 0) waged.AMT = 10;
                waged.NOBR = row.NOBR;
                waged.SAL_CODE = row.SAL_CODE;
                waged.SEQ = this.SEQ;
                waged.YYMM = this.YYMM;
                InsertWaged(waged);
            }
        }

        public void ImportWagedd()
        {
            var sql = from a in smd.WAGEDD
                      join b in smd.BASETTS on a.NOBR equals b.NOBR
                      join c in smd.DEPT on b.DEPT equals c.D_NO
					  //join wrnt in smd.WriteRuleNobrTable.Where(p => p.GUID == guid) on a.NOBR equals wrnt.EMPID																							
                      where b.NOBR.CompareTo(NOBR_B) >= 0 && b.NOBR.CompareTo(NOBR_E) <= 0
                      && c.D_NO_DISP.CompareTo(DEPT_B) >= 0 && c.D_NO_DISP.CompareTo(DEPT_E) <= 0
                      && a.YYMM == YYMM && a.SEQ == SEQ
                      && TRANS_DATE >= b.ADATE && TRANS_DATE <= b.DDATE.Value
                      //&& smd.GetFilterByNobr(a.NOBR, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value
                      && smd.UserReadDataGroupList(MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Select(p => p.DATAGROUP).Contains(b.SALADR)
                      select a;
            foreach (var itm in sql)
            {
                WAGED waged = new WAGED();
                waged.AMT = itm.AMT;
                waged.NOBR = itm.NOBR;
                waged.SAL_CODE = itm.SAL_CODE;
                waged.SEQ = this.SEQ;
                waged.YYMM = this.YYMM;
                InsertWaged(waged);
            }
        }

        void WelCalc()
        {
            var lst = (from itm in wagedList
                       join s in SalaryVar.dtSalcode on itm.SAL_CODE equals s.SAL_CODE
                       join c in db.SALATTR.ToList() on s.SAL_ATTR equals c.SALATTR1
                       where s.WEL
                       select new { itm.NOBR, itm.SAL_CODE, AMT = c.FLAG != "-" ? itm.AMT : itm.AMT * -1 }).ToList();
            var WelList = (from a in db.BASETTS where DATE_E >= a.ADATE && DATE_E <= a.DDATE.Value && a.NOBR.CompareTo(NOBR_B) >= 0 && a.NOBR.CompareTo(NOBR_E) <= 0 && !a.NOWEL select a.NOBR).ToList();
            var itms = from g in lst where WelList.Contains(g.NOBR) group g by g.NOBR into gp select new { gp, AMT = gp.Sum(p => JBModule.Data.CDecryp.Number(p.AMT)) };

            foreach (var itm in itms)
            {
                decimal amt = Math.Round(itm.AMT * MainForm.SalaryConfig.WELPAY.Value, MidpointRounding.AwayFromZero);
                WAGED waged = new WAGED();
                waged.AMT = JBModule.Data.CEncrypt.Number(amt);
                waged.NOBR = itm.gp.Key;
                waged.SAL_CODE = MainForm.SalaryConfig.WELSALCODE;
                waged.SEQ = this.SEQ;
                waged.YYMM = this.YYMM;
                InsertWaged(waged);
            }
        }
        public void TaxCalc(bool isSalary, string calyymm, string calseq, bool GetfromDB = false)
        {
            var nobrList = from wagedItem in wagedList
                           join salcode in db.SALCODE.ToList() on wagedItem.SAL_CODE equals salcode.SAL_CODE
                           join salattr in db.SALATTR.ToList() on salcode.SAL_ATTR equals salattr.SALATTR1
                           where wagedItem.YYMM == calyymm && wagedItem.SEQ == calseq
                            group new { wagedItem, salattr.FLAG, salattr.TAX, salcode.TAXRATE } by wagedItem.NOBR into gp
                           select gp;
            if (GetfromDB)
            {
                var nobrList_full = (from wagedItem in db.WAGED
                           join salcode in db.SALCODE on wagedItem.SAL_CODE equals salcode.SAL_CODE
                           join salattr in db.SALATTR on salcode.SAL_ATTR equals salattr.SALATTR1
                           where wagedItem.YYMM == calyymm && wagedItem.SEQ == calseq
                            select new { wagedItem, salattr.FLAG, salattr.TAX, salcode.TAXRATE }).ToList();
                nobrList = nobrList_full.GroupBy(p => p.wagedItem.NOBR);
            }
             var basettsList = (from a in smd.BASETTS
                               join b in smd.BASE on a.NOBR equals b.NOBR
                               join c in smd.DEPT on a.DEPT equals c.D_NO
							   //join wrnt in smd.WriteRuleNobrTable.Where(p => p.GUID == guid) on a.NOBR equals wrnt.EMPID																						 
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
            TaxRateByNobr.Clear();
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
                        if (isSalary)
                            if (taxAmt < rEmp.PRETAX) taxAmt = rEmp.PRETAX;//如果低於預扣金額，就取代成預扣金額

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
                    TaxRateByNobr.Add(nobrItem.Key, TaxRate);
                    var wageOfNobr = wageList.Where(p => p.NOBR == nobrItem.Key);
                    if (wageOfNobr.Any()) wageOfNobr.First().TAXRATE = TaxRate;

                    WAGED waged = new WAGED();
                    //waged.AMT = JBModule.Data.CEncrypt.Number(decimal.Round(taxAmt + amtFixRate + amtYear, MidpointRounding.AwayFromZero));
                    waged.AMT = JBModule.Data.CEncrypt.Number(decimal.Truncate(taxAmt + amtFixRate + amtYear));
                    waged.NOBR = nobrItem.Key;
                    waged.SAL_CODE = MainForm.TaxConfig.TAXSALCODE;
                    waged.SEQ = calseq;//this.SEQ;
                    waged.YYMM = calyymm; //this.YYMM;
                    if (!GetfromDB)
                        InsertWaged(waged);
                    else db.WAGED.InsertOnSubmit(waged);
                }
            }
            db.SubmitChanges();
        }
        public void PreSalaryCalc()
        {
            List<string> ttscodeList = new List<string>();
            ttscodeList.Add("1");
            ttscodeList.Add("4");
            ttscodeList.Add("6");
            var EmpList_full = (from a in smd.BASETTS
                           join b in smd.BASETTS on a.NOBR equals b.NOBR
                           join e in smd.DEPT on a.DEPT equals e.D_NO
                           join c in smd.BASE on a.NOBR equals c.NOBR
                           where ttscodeList.Contains(a.TTSCODE)
                           && a.NOBR.CompareTo(NOBR_B) >= 0 && a.NOBR.CompareTo(NOBR_E) <= 0
                           && e.D_NO_DISP.CompareTo(DEPT_B) >= 0 && e.D_NO_DISP.CompareTo(DEPT_E) <= 0
                           //&& smd.GetFilterByNobr(a.NOBR, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value
                           && smd.UserReadDataGroupList(MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Select(p => p.DATAGROUP).Contains(b.SALADR)
                           && DATE_B <= a.DDATE.Value && DATE_E >= a.ADATE
                           && DATE_E >= b.ADATE && DATE_E <= b.DDATE.Value
                           && !b.NOWAGE//須計算薪資
                           && b.INDT <= InEDate
                           //&& !c.COUNT_MA
                           select new { a.NOBR, a.ADATE, a.DDATE }).ToList();
            var EmpList = EmpList_full.GroupBy(p => p.NOBR);
            var salbasdList = (from a in db.SALBASD
                               join b in db.BASETTS on a.NOBR equals b.NOBR
                               join c in db.SALCODE on a.SAL_CODE equals c.SAL_CODE
                               join e in db.DEPT on b.DEPT equals e.D_NO
                               where b.NOBR.CompareTo(NOBR_B) >= 0 && b.NOBR.CompareTo(NOBR_E) <= 0
                               && e.D_NO_DISP.CompareTo(DEPT_B) >= 0 && e.D_NO_DISP.CompareTo(DEPT_E) <= 0
                               && DATE_E >= b.ADATE && DATE_E <= b.DDATE.Value
                               //&& c.SOS_ID == "1"
                               && a.SAL_CODE == AppConfig.GetConfig("DeductWage").GetString("")
                               //&& !c.NOTFREQ
                               && a.ADATE <= DATE_E && a.DDATE >= DATE_B
                               && b.INDT <= InEDate
                               //&& db.GetFilterByNobr(a.NOBR, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value
                               && db.UserReadDataGroupList(MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Select(p => p.DATAGROUP).Contains(b.SALADR)
                               select new { a.NOBR, a.ADATE, a.DDATE, a.SAL_CODE, a.AMT, c.MONTHTYPE, c.CAL_FREQ, c.DEFINEDAYS }).ToList();

            int counts = EmpList.Count();
            SalaryDate sd = new SalaryDate(YYMM);
            decimal monthDays = Convert.ToInt32((sd.LastDayOfSalary - sd.FirstDayOfSalary).TotalDays) + 1;
            foreach (var EmpData in EmpList)//所以需要計算薪資的工號
            {
                var basettsList = EmpData;
                var salbasdOfNobr = salbasdList.Where(p => p.NOBR.Trim() == EmpData.Key.Trim());
                decimal Workdays = basettsList.Sum(row =>
                       Function.RangeMix(row.ADATE, row.DDATE.Value, DATE_B, DATE_E));//在職給薪天數
                WorkDaysList.Add(EmpData.Key, Workdays);
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

                    decimal salary = JBModule.Data.CDecryp.Number(salbasdRow.AMT);
                    BaseSalary_Core bc = new BaseSalary_Core();
                    bc.MonthDays = monthDays;
                    bc.OnJobDays = AvailableDays;
                    bc.CustomDays = salbasdRow.DEFINEDAYS > 0 ? salbasdRow.DEFINEDAYS : 30M;
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
                        //bc.MonthType = salbasdRow.MONTHTYPE;
                        //bc.CalcUnit = salbasdRow.CAL_FREQ;
                        //amt = bc.CalculationRule(salary);
                        amt = 0;
                    }

                    decimal amt45 = Math.Round(amt, MidpointRounding.AwayFromZero);
                    WAGED waged = new WAGED();
                    waged.AMT = JBModule.Data.CEncrypt.Number(amt45);
                    waged.NOBR = salbasdRow.NOBR;
                    waged.SAL_CODE = AppConfig.GetConfig("PreSalcode").GetString("");
                    waged.SEQ = SEQ;
                    waged.YYMM = YYMM;
                    InsertWaged(waged);
                }
            }
        }
        public void ImportDeductSeq()
        {
            string salcode = AppConfig.GetConfig("DeductWage").GetString("");
            if (salcode.Trim().Length > 0)
            {
                var sql_full = (from a in db.WAGED
                          join b in db.WAGE on new { a.NOBR, a.YYMM, a.SEQ } equals new { b.NOBR, b.YYMM, b.SEQ }
                          join c in db.SALCODE on a.SAL_CODE equals c.SAL_CODE
                          join d in db.BASETTS on a.NOBR equals d.NOBR
                          join f in db.DEPT on d.DEPT equals f.D_NO
                          where a.YYMM == YYMM //&& DeductSEQ.Contains(a.SEQ)
                                               //&& c.PART_SALARY != null && c.PART_SALARY.Value
                          && DATE_E >= d.ADATE && DATE_E <= d.DDATE.Value
                          && d.NOBR.CompareTo(NOBR_B) >= 0 && d.NOBR.CompareTo(NOBR_E) <= 0
                          && f.D_NO_DISP.CompareTo(DEPT_B) >= 0 && f.D_NO_DISP.CompareTo(DEPT_E) <= 0
                          && b.FORMAT.Trim().Length == 0//借支期別必須是不申報的期別
                          //&& db.GetFilterByNobr(a.NOBR, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value
                          && db.UserReadDataGroupList(MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Select(p => p.DATAGROUP).Contains(d.SALADR)
                          select new { a.NOBR, a.SAL_CODE, a.AMT }).ToList();
                var sql = sql_full.GroupBy(p => p.NOBR);
                var gpWaged = sql.ToList();
                foreach (var it in gpWaged)
                {
                    decimal amt45 = 0;
                    amt45 = it.Sum(p => JBModule.Data.CDecryp.Number(p.AMT));
                    WAGED waged = new WAGED();
                    waged.AMT = JBModule.Data.CEncrypt.Number(amt45);
                    waged.NOBR = it.Key;
                    waged.SAL_CODE = salcode;
                    waged.SEQ = this.SEQ;
                    waged.YYMM = this.YYMM;
                    InsertWaged(waged);
                }
            }
        }
        void setProgress(int percent, object state)
        {
            if (BW != null)
            {
                BW.ReportProgress(percent, state);
            }
        }
        public Dictionary<string, string> PreviousMonthNoWage()
        {
            JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
            SalaryDate sd = new SalaryDate(YYMM);
            var pd = sd.GetPrevSalaryDate();
            List<string> ttscodeList = new List<string>();
            ttscodeList.Add("1");
            ttscodeList.Add("4");

            List<string> ttscodeList1 = new List<string>();
            ttscodeList1.Add("1");
            ttscodeList1.Add("4");
            ttscodeList1.Add("6");

            DateTime pDateB, pDateE;
            pDateB = DATE_B.AddMonths(-1);
            pDateE = pDateB.AddMonths(1).AddDays(-1);
            var sql = from a in db.BASETTS
                      join b in db.SALBASD on a.NOBR equals b.NOBR into ab
                      from salbasd in ab
                      join c in db.SALCODE on salbasd.SAL_CODE equals c.SAL_CODE
                      join d in db.SALATTR on c.SAL_ATTR equals d.SALATTR1
                      join e in db.DEPT on a.DEPT equals e.D_NO
					  //join wrnt in db.WriteRuleNobrTable.Where(p => p.GUID == guid) on a.NOBR equals wrnt.EMPID																						   
                      //join e in nobrList on a.NOBR equals e
                      where ttscodeList1.Contains(a.TTSCODE)
                       && a.NOBR.CompareTo(NOBR_B) >= 0 && a.NOBR.CompareTo(NOBR_E) <= 0
                       && e.D_NO_DISP.CompareTo(DEPT_B) >= 0 && e.D_NO_DISP.CompareTo(DEPT_E) <= 0
                       //&& (MainForm.PROCSUPER || a.SALADR == MainForm.WORKADR)
                       && pDateB <= a.DDATE && pDateE >= a.ADATE
                       && !a.NOWAGE
                       && c.SOS_ID == "1"
                       && !c.NOTFREQ
                       && a.ADATE <= salbasd.DDATE && a.DDATE >= salbasd.ADATE
                       && a.INDT <= InEDate
                       && c.SAL_CODE != MainForm.SalaryConfig.ATTAWARDSALCODE
                       //&& db.GetFilterByNobr(a.NOBR, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value
                       && db.UserReadDataGroupList(MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Select(p => p.DATAGROUP).Contains(a.SALADR)
                      select new { a.NOBR, a.BASE.NAME_C };

            var inSQL = from a in db.BASETTS where a.TTSCODE == "1" && pDateB <= a.DDATE.Value && pDateE >= a.ADATE select a;

            var wageSQL = from a in db.WAGE where a.YYMM == pd.YYMM && a.SEQ == this.SEQ select a;
            var groupSQL = from row in sql where !wageSQL.Where(p => p.NOBR == row.NOBR).Any() select new { row.NOBR, row.NAME_C };
            var result = groupSQL.AsEnumerable().Distinct().ToDictionary(p => p.NOBR, p => p.NAME_C);
            return result;
        }
    }


    public static class extBASETTS
    {
        public static BASETTS GetBasetts(this System.Data.Linq.EntitySet<BASETTS> basetts, string nobr, DateTime adate)
        {
            var ans = from b in basetts where b.NOBR == nobr && adate >= b.ADATE && adate <= b.DDATE select b;
            return ans.FirstOrDefault();
        }
    }
}
