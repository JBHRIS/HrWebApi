using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;

namespace JBHR.Med
{
    public partial class FRM51A : JBControls.JBForm
    {
        class param
        {
            public string YYMM_B, YYMM_E;
            public DateTime PAY_DATE_B, PAY_DATE_E;
            public string YEAR;
            public string NOBR_B, NOBR_E;
            public string SER_NOB, SER_NOE;
            public string EMP_B, EMP_E;
            public string SEQ_B, SEQ_E;
            public string FORMAT;
        }

        public FRM51A()
        {
            InitializeComponent();
        }

        private void FRM51A_Load(object sender, EventArgs e)
        {
            this.eMPCDTableAdapter.Fill(this.basDS.EMPCD);
            this.yRFORMATTableAdapter.Fill(this.medDS.YRFORMAT);
            this.v_BASETableAdapter.Fill(this.medDS.V_BASE);

            if (this.medDS.V_BASE.Count > 0)
            {
                popupTextBoxNOBR_B.Text = this.medDS.V_BASE.Min(row => row.NOBR);
                popupTextBoxNOBR_E.Text = this.medDS.V_BASE.Max(row => row.NOBR);
            }
            cbxEmpB.SelectedValue = this.basDS.EMPCD.First().EMPCD;
            cbxEmpE.SelectedValue = this.basDS.EMPCD.Last().EMPCD;
            textBoxSER_NOB.Text = "A0000001";
            textBoxSER_NOE.Text = "Z9999999";
            textBoxSEQB.Text = "2";
            textBoxSEQE.Text = "Z";
            //if (MainForm.WriteRules.Where(p => p.COMPANY == MainForm.COMPANY).FirstOrDefault() != null)
            //{
            //    var flags = MainForm.WriteRules.Where(p => p.COMPANY == MainForm.COMPANY && p.DATAGROUP1.YRTAX_FLAG != null && p.DATAGROUP1.YRTAX_FLAG.Trim().Length > 0).Select(p => p.DATAGROUP1.YRTAX_FLAG).Distinct();
            //    if (flags.Any())
            //    {
            //        textBoxSER_NOB.Text = flags.Min() + "0000001";
            //        textBoxSER_NOE.Text = flags.Min() + "9999999";
            //    }
            //}
            comboBoxFORMAT.SelectedValue = "50";
            Sal.Core.SalaryDate sd = new Sal.Core.SalaryDate(DateTime.Today);
            textBoxYYMM_B.Text = sd.YYMM;
            textBoxYEAR.Text = sd.Year.ToString();
            SetValue();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            medDS.YRTAX.Clear();

            param p = new param();
            p.YYMM_B = textBoxYYMM_B.Text;
            p.YYMM_E = textBoxYYMM_E.Text;
            p.PAY_DATE_B = Convert.ToDateTime(txtPayDateB.Text);
            p.PAY_DATE_E = Convert.ToDateTime(txtPayDateE.Text);
            p.YEAR = textBoxYEAR.Text;
            p.NOBR_B = popupTextBoxNOBR_B.Text;
            p.NOBR_E = popupTextBoxNOBR_E.Text;
            p.SER_NOB = textBoxSER_NOB.Text;
            p.SER_NOE = textBoxSER_NOE.Text;
            p.FORMAT = comboBoxFORMAT.SelectedValue;
            p.EMP_B = cbxEmpB.SelectedValue;
            p.EMP_E = cbxEmpE.SelectedValue;
            p.SEQ_B = textBoxSEQB.Text;
            p.SEQ_E = textBoxSEQE.Text;

            panel1.Enabled = false;

            backgroundWorker1.RunWorkerAsync(p);
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            param p = e.Argument as param;

            List<string> WORKADR = new List<string>();
            //if (MainForm.PROCSUPER)
            //{
            //    new MedDSTableAdapters.SALADRTableAdapter().Fill(this.medDS.SALADR);
            //    foreach (DataRow row in this.medDS.SALADR.Rows) WORKADR.Add(row["saladr"].ToString().Trim());
            //}
            //else
            //{
            //    WORKADR.Add(MainForm.WORKADR.Trim());
            //}
            foreach (var it in MainForm.WriteDataGroups)
                WORKADR.Add(it);

            JBModule.Data.CSQL mySql = new JBModule.Data.CSQL("JBHR.Properties.Settings.JBHRConnectionString");

            string sql = "";

            //先刪除已存在的媒體申報資料

            sql = "delete from yrtax" +
                " where series between '" + p.SER_NOB + "' and '" + p.SER_NOE + "'" +
                " and nobr between '" + p.NOBR_B + "' and '" + p.NOBR_E + "'" +
                " and year = '" + p.YEAR + "'" +
                " and FORMAT = '" + p.FORMAT + "'" +
                " and saladr in (";
            foreach (var it in WORKADR)
                sql += "'" + it + "',";
            sql += "'')";
            mySql.ExecuteNonQuery(sql);
            backgroundWorker1.ReportProgress(20);

            string YYMM_B = p.YYMM_B.Trim().Substring(0, 4) + "/" + p.YYMM_B.Trim().Substring(4, 2) + "/1";
            string YYMM_E = p.YYMM_E.Trim().Substring(0, 4) + "/" + p.YYMM_E.Trim().Substring(4, 2) + "/" +
                DateTime.DaysInMonth(Convert.ToInt32(p.YYMM_E.Trim().Substring(0, 4)), Convert.ToInt32(p.YYMM_E.Trim().Substring(4, 2))).ToString();

            MedDataClassesDataContext db = new MedDataClassesDataContext();
            //讀取條件內的所得稅薪資明細
            var DD1 = from c in db.WAGED
                      join b in db.BASETTS on c.NOBR equals b.NOBR
                      where
                      c.YYMM.Trim().CompareTo(p.YYMM_B) >= 0 && c.YYMM.Trim().CompareTo(p.YYMM_E) <= 0 &&
                      c.NOBR.Trim().CompareTo(p.NOBR_B) >= 0 && c.NOBR.Trim().CompareTo(p.NOBR_E) <= 0 &&
                      c.SEQ.Trim().CompareTo(p.SEQ_B) >= 0 && c.SEQ.Trim().CompareTo(p.SEQ_E) <= 0 &&
                      c.SAL_CODE.Trim() == MainForm.TaxConfig.TAXSALCODE.Trim() &&//讀取所得稅的科目
                      c.WAGE.FORMAT.Trim() == p.FORMAT && //薪資主檔之所得格式需是指定項目
                      c.WAGE.ADATE >= p.PAY_DATE_B && c.WAGE.ADATE <= p.PAY_DATE_E &&
                      WORKADR.Contains(c.WAGE.SALADR.Trim())//符合薪資群組
                      && c.WAGE.ADATE >= b.ADATE && c.WAGE.ADATE <= b.DDATE.Value
                      && b.EMPCD.CompareTo(p.EMP_B) >= 0 && b.EMPCD.CompareTo(p.EMP_E) <= 0
                      select new
                      {
                          NOBR = c.NOBR.Trim(),
                          COMP = c.WAGE.COMP.Trim(),
                          AMT = JBModule.Data.CDecryp.Number(c.AMT),
                          c.WAGE.SALADR,
                      };
            //依工號及公司作群組
            var DD = from c in DD1.AsEnumerable()
                     group c by new { c.NOBR, c.COMP } into g
                     orderby g.Key.NOBR
                     select new
                     {
                         NOBR = g.Key.NOBR,
                         COMP = g.Key.COMP,
                         AMT = g.Sum(r => r.AMT),
                         SALADR = g.First().SALADR,
                     };
            //依條件取出勞退金額
            string[] RetCodeList = new string[] { MainForm.LabConfig.RETSALCODE.Trim(), "N13", "N131" };
            var RR1 = from c in db.WAGED
                      join b in db.BASETTS on c.NOBR equals b.NOBR
                      join d in db.SALCODE on c.SAL_CODE equals d.SAL_CODE
                      join f in db.SALATTR on d.SAL_ATTR equals f.SALATTR1
                      where
                      c.YYMM.Trim().CompareTo(p.YYMM_B) >= 0 && c.YYMM.Trim().CompareTo(p.YYMM_E) <= 0 &&
                      c.NOBR.Trim().CompareTo(p.NOBR_B) >= 0 && c.NOBR.Trim().CompareTo(p.NOBR_E) <= 0 &&
                       c.SEQ.Trim().CompareTo(p.SEQ_B) >= 0 && c.SEQ.Trim().CompareTo(p.SEQ_E) <= 0 &&
                   RetCodeList.Contains(c.SAL_CODE.Trim()) &&
                      c.WAGE.FORMAT.Trim() == p.FORMAT &&//指定所得格式
                      WORKADR.Contains(c.WAGE.SALADR.Trim())//指定的薪資群組
                      && c.WAGE.ADATE >= p.PAY_DATE_B && c.WAGE.ADATE <= p.PAY_DATE_E
                       && c.WAGE.ADATE >= b.ADATE && c.WAGE.ADATE <= b.DDATE.Value
                       && b.EMPCD.CompareTo(p.EMP_B) >= 0 && b.EMPCD.CompareTo(p.EMP_E) <= 0
                      select new
                      {
                          NOBR = c.NOBR.Trim(),
                          COMP = c.WAGE.COMP.Trim(),
                          AMT = JBModule.Data.CDecryp.Number(c.AMT),
                          f.FLAG,
                          c.WAGE.SALADR,
                      };
            //將勞退金額依工號、公司作群組
            var RR = from c in RR1.AsEnumerable()
                     group c by new { c.NOBR, c.COMP } into g
                     orderby g.Key.NOBR
                     select new
                     {
                         NOBR = g.Key.NOBR,
                         COMP = g.Key.COMP,
                         AMT = g.Sum(r => r.FLAG == "-" ? r.AMT : r.AMT * -1),
                         SALADR = g.First().SALADR,
                     };
            //依條件取出應稅薪資明細
            var wagedData = from c in db.WAGED
                            join b in db.BASETTS on c.NOBR equals b.NOBR
                            where
                            c.YYMM.Trim().CompareTo(p.YYMM_B) >= 0 && c.YYMM.Trim().CompareTo(p.YYMM_E) <= 0 &&
                            c.NOBR.Trim().CompareTo(p.NOBR_B) >= 0 && c.NOBR.Trim().CompareTo(p.NOBR_E) <= 0 &&
                            c.SEQ.Trim().CompareTo(p.SEQ_B) >= 0 && c.SEQ.Trim().CompareTo(p.SEQ_E) <= 0 &&
                            c.WAGE.FORMAT.Trim() == p.FORMAT &&
                            WORKADR.Contains(c.WAGE.SALADR.Trim())
                            && c.WAGE.ADATE >= p.PAY_DATE_B && c.WAGE.ADATE <= p.PAY_DATE_E
                             && c.WAGE.ADATE >= b.ADATE && c.WAGE.ADATE <= b.DDATE.Value
                             && b.EMPCD.CompareTo(p.EMP_B) >= 0 && b.EMPCD.CompareTo(p.EMP_E) <= 0
                            orderby c.NOBR
                            select c;
            var GG1 = from c in wagedData
                      join d in db.COMP on c.WAGE.COMP equals d.COMP1
                      where c.SALCODE.SALATTR.TAX
                      orderby c.NOBR
                      select new
                      {
                          NOBR = c.NOBR.Trim(),
                          COMP = c.WAGE.COMP.Trim(),
                          IDNO = c.WAGE.BASE.IDNO.Trim(),
                          COMPID = c.WAGE.COMP1.COMPID.Trim(),
                          NAME_C = c.WAGE.BASE.NAME_C.Trim(),
                          NAME_E = c.WAGE.BASE.NAME_E,
                          ADDR2 = c.WAGE.BASE.ADDR2.Trim(),
                          POSTCODE2 = c.WAGE.BASE.POSTCODE2.Trim(),
                          COUNT_MA = c.WAGE.BASE.COUNT_MA,
                          AMT = JBModule.Data.CDecryp.Number(c.AMT),
                          FLAG = c.SALCODE.SALATTR.FLAG.Trim(),
                          MATNO = c.WAGE.BASE.MATNO,
                          COMPANY = d,
                          c.WAGE.SALADR,
                      };
            //依工號做排序(並整理資料格式)
            var GG2 = from c in GG1.AsEnumerable()
                      orderby c.NOBR
                      select new
                      {
                          NOBR = c.NOBR.Trim(),
                          COMP = c.COMP.Trim(),
                          IDNO = c.IDNO.Trim(),
                          COMPID = c.COMPID.Trim(),
                          NAME_C = c.NAME_C.Trim(),
                          NAME_E = c.NAME_E.Trim(),
                          ADDR2 = c.ADDR2.Trim(),
                          POSTCODE2 = c.POSTCODE2.Trim(),
                          COUNT_MA = c.COUNT_MA,
                          AMT = (c.FLAG == "-") ? c.AMT * -1 : c.AMT,
                          MATNO = c.MATNO,
                          c.COMPANY,
                          SALADR = c.SALADR,
                      };
            decimal totalAmt = GG2.Sum(ps => ps.AMT);
            //作群組
            var GG3 = from c in GG2
                      group c by new { c.NOBR, c.COMP, c.IDNO, c.COMPID, c.NAME_C, c.NAME_E, c.ADDR2, c.POSTCODE2, c.COUNT_MA, c.MATNO, c.COMPANY } into g
                      orderby g.Key.NOBR
                      select new
                      {
                          NOBR = g.Key.NOBR,
                          COMP = g.Key.COMP,
                          IDNO = g.Key.IDNO,
                          COMPID = g.Key.COMPID,
                          NAME_C = g.Key.NAME_C,
                          NAME_E = g.Key.NAME_E,
                          ADDR2 = g.Key.ADDR2,
                          POSTCODE2 = g.Key.POSTCODE2,
                          COUNT_MA = g.Key.COUNT_MA,
                          AMT = g.Sum(r => r.AMT),
                          MATNO = g.Key.MATNO,
                          g.Key.COMPANY,
                          g.First().SALADR,
                      };
            //合併三種資料
            var GG = from c1 in GG3
                     join c2 in DD on new { NOBR = c1.NOBR, COMP = c1.COMP } equals new { NOBR = c2.NOBR, COMP = c2.COMP } into jj1
                     join c3 in RR on new { NOBR = c1.NOBR, COMP = c1.COMP } equals new { NOBR = c3.NOBR, COMP = c3.COMP } into jj2
                     from j1 in jj1.DefaultIfEmpty()
                     from j2 in jj2.DefaultIfEmpty()
                     orderby c1.NOBR
                     select new
                     {
                         NOBR = c1.NOBR,
                         COMP = c1.COMP,
                         IDNO = c1.IDNO,
                         COMPID = c1.COMPID,
                         NAME_C = c1.NAME_C,
                         NAME_E = c1.NAME_E,
                         ADDR2 = c1.ADDR2,
                         POSTCODE2 = c1.POSTCODE2,
                         COUNT_MA = c1.COUNT_MA,
                         TOT_AMT = c1.AMT,
                         TAX_AMT = (j1 != null) ? j1.AMT : 0,
                         RET_AMT = (j2 != null) ? j2.AMT : 0,
                         MATNO = c1.MATNO,
                         c1.COMPANY,
                         c1.SALADR,
                     };
            backgroundWorker1.ReportProgress(40);

            int index = 1;
            int count = GG.Count();
            //取得目前最大序號
            string SERIES = "";
            sql = "select max(series) as series from yrtax" +
                " where year = '" + p.YEAR + "'" +
                " and FORMAT = '" + p.FORMAT + "'"
                + " and series between '" + p.SER_NOB + "' and '" + p.SER_NOE + "'";
            DataTable _dt = new JBModule.Data.CSQL(new MedDSTableAdapters.YRTAXTableAdapter().Connection).GetDataTable(sql);
            if (_dt.Rows.Count > 0 && !_dt.Rows[0].IsNull("series") && _dt.Rows[0]["series"].ToString().Trim().Length > 0)
            {
                SERIES = _dt.Rows[0]["series"].ToString();

                string _s1 = SERIES.Substring(0, 1);
                string _s2 = SERIES.Substring(1, 7);

                if (Convert.ToInt32(_s2) > 9999999)
                {
                    _s1 = (_s1[0] + 1).ToString();
                    _s2 = "0000001";
                }
                else
                {
                    _s2 = (Convert.ToInt32(_s2) + 1).ToString().PadLeft(7, '0');
                }

                SERIES = _s1 + _s2;

                int _pIndex = index / count * 50;
                backgroundWorker1.ReportProgress(40 + _pIndex);

                index++;
            }
            else SERIES = p.SER_NOB;

            foreach (var rGG in GG)
            {
                string IDCODE = "0";
                bool isForeign = false;
                if (rGG.IDNO.Trim().Length > 2)
                {
                    int result = 0;
                    string cc = rGG.IDNO.Substring(1, 1);
                    if (!int.TryParse(cc, out result))
                        isForeign = true;
                }
                else if (rGG.MATNO.Trim().Length > 0)//無身分證號且有居留證好者，視為外籍
                    isForeign = true;
                if (rGG.COUNT_MA || isForeign)//外勞
                {//未超過183為每月申報，不可透過網路申報，故所有身分都是3
                    DateTime ADATE = Convert.ToDateTime((Convert.ToInt32(p.YEAR)).ToString() + "/12/31");
                    IDCODE = "3";
                    var baseTTSList = (from c in db.BASETTS
                                       where c.NOBR.Trim() == rGG.NOBR
                                       && c.TAX_DATE != null && c.TAX_EDATE != null
                                       //&& ADATE >= c.ADATE && ADATE <= c.DDATE
                                       select new { c.TAX_DATE, c.TAX_EDATE });
                    //if (baseTTS != null)//判斷有無超過183天
                    int YearWorkDays = 0;
                    foreach (var baseTTS in baseTTSList.Distinct())
                    {//todo:判斷方式有錯，且證號別應該是3=>滿183有地址，4=>滿183天無地址，7=>未滿183天
                        JBTools.Intersection its = new JBTools.Intersection();
                        its.Inert(new DateTime(ADATE.Year, 1, 1), new DateTime(ADATE.Year, 12, 31));
                        its.Inert(baseTTS.TAX_DATE.Value, baseTTS.TAX_EDATE.Value);
                        YearWorkDays += its.GetDays();
                    }
                    if (YearWorkDays < 183)
                    {
                        IDCODE = "7";
                    }
                }

                decimal _TOT_AMT = 0;
                decimal _TAX_AMT = 0;
                decimal _RET_AMT = 0;
                //若外勞已出境，計算出已申報的金額
                if (rGG.COUNT_MA || isForeign)
                {
                    var _BASETTS = from c in db.BASETTS
                                   where c.NOBR.Trim() == rGG.NOBR
                                   && p.PAY_DATE_E >= c.ADATE && p.PAY_DATE_E <= c.DDATE.Value
                                   select c;
                    if (_BASETTS.Any() && IDCODE != "7")//未滿183全部都要申報(每月)
                    {
                        var r_basetts = _BASETTS.First();
                        DateTime maxDate = new DateTime(1900, 1, 1);
                        if (r_basetts.OUDT != null && r_basetts.OUDT > maxDate) maxDate = r_basetts.OUDT.Value;
                        if (r_basetts.STDT != null && r_basetts.STDT > maxDate) maxDate = r_basetts.STDT.Value;
                        if (r_basetts.TTSCODE == "2" && r_basetts.DDATE > maxDate) maxDate = r_basetts.DDATE.Value;
                        {//TODO:需確認抓取離境申報的資料是否正確
                            var _DD1 = from c in wagedData
                                       where c.YYMM.Trim().CompareTo(maxDate.ToString("yyyyMM")) <= 0//依離職就必須結清，所以抓離職日(含)前的所有薪資資料是做已結清
                                       && c.NOBR.Trim() == rGG.NOBR
                                        && c.SAL_CODE.Trim() == MainForm.TaxConfig.TAXSALCODE.Trim()
                                       select new
                                       {
                                           NOBR = c.NOBR.Trim(),
                                           COMP = c.WAGE.COMP.Trim(),
                                           AMT = JBModule.Data.CDecryp.Number(c.AMT),
                                           c.WAGE.SALADR,
                                       };
                            if (_DD1.Count() > 0)
                            {
                                var _DD = from c in _DD1.AsEnumerable()
                                          group c by new { c.NOBR, c.COMP } into g
                                          orderby g.Key.NOBR
                                          select new
                                          {
                                              NOBR = g.Key.NOBR,
                                              COMP = g.Key.COMP,
                                              AMT = g.Sum(r => r.AMT),
                                              g.First().SALADR
                                          };

                                var _RR1 = from c in wagedData
                                           where c.NOBR.Trim() == rGG.NOBR
                                           && c.SAL_CODE.Trim() == MainForm.LabConfig.RETSALCODE.Trim()
                                           && c.YYMM.Trim().CompareTo(maxDate.ToString("yyyyMM")) <= 0//依離職就必須結清，所以抓離職日(含)前的所有薪資資料是做已結清
                                           select new
                                           {
                                               NOBR = c.NOBR.Trim(),
                                               COMP = c.WAGE.COMP.Trim(),
                                               AMT = JBModule.Data.CDecryp.Number(c.AMT),
                                               c.WAGE.SALADR
                                           };

                                var _RR = from c in _RR1.AsEnumerable()
                                          group c by new { c.NOBR, c.COMP } into g
                                          orderby g.Key.NOBR
                                          select new
                                          {
                                              NOBR = g.Key.NOBR,
                                              COMP = g.Key.COMP,
                                              AMT = g.Sum(r => r.AMT),
                                              g.First().SALADR
                                          };

                                var _GG1 = from c in wagedData
                                           where c.NOBR.Trim() == rGG.NOBR
                                           && c.SALCODE.SALATTR.TAX
                                           && c.YYMM.Trim().CompareTo(maxDate.ToString("yyyyMM")) <= 0//依離職就必須結清，所以抓離職日(含)前的所有薪資資料是做已結清
                                           orderby c.NOBR
                                           select new
                                           {
                                               NOBR = c.NOBR.Trim(),
                                               COMP = c.WAGE.COMP.Trim(),
                                               IDNO = c.WAGE.BASE.IDNO.Trim(),
                                               COMPID = c.WAGE.COMP1.COMPID.Trim(),
                                               NAME_C = c.WAGE.BASE.NAME_C.Trim(),
                                               ADDR2 = c.WAGE.BASE.ADDR2.Trim(),
                                               POSTCODE2 = c.WAGE.BASE.POSTCODE2.Trim(),
                                               COUNT_MA = c.WAGE.BASE.COUNT_MA,
                                               AMT = JBModule.Data.CDecryp.Number(c.AMT),
                                               FLAG = c.SALCODE.SALATTR.FLAG.Trim(),
                                               MATNO = c.WAGE.BASE.MATNO,
                                               c.WAGE.SALADR,
                                           };

                                var _GG2 = from c in _GG1.AsEnumerable()
                                           orderby c.NOBR
                                           select new
                                           {
                                               NOBR = c.NOBR.Trim(),
                                               COMP = c.COMP.Trim(),
                                               IDNO = c.IDNO.Trim(),
                                               COMPID = c.COMPID.Trim(),
                                               NAME_C = c.NAME_C.Trim(),
                                               ADDR2 = c.ADDR2.Trim(),
                                               POSTCODE2 = c.POSTCODE2.Trim(),
                                               COUNT_MA = c.COUNT_MA,
                                               AMT = (c.FLAG == "-") ? c.AMT * -1 : c.AMT,
                                               MATNO = c.MATNO,
                                               c.SALADR,
                                           };
                                var _GG3 = from c in _GG2
                                           group c by new { c.NOBR, c.COMP, c.IDNO, c.COMPID, c.NAME_C, c.ADDR2, c.POSTCODE2, c.COUNT_MA, c.MATNO } into g
                                           orderby g.Key.NOBR
                                           select new
                                           {
                                               NOBR = g.Key.NOBR,
                                               COMP = g.Key.COMP,
                                               IDNO = g.Key.IDNO,
                                               COMPID = g.Key.COMPID,
                                               NAME_C = g.Key.NAME_C,
                                               ADDR2 = g.Key.ADDR2,
                                               POSTCODE2 = g.Key.POSTCODE2,
                                               COUNT_MA = g.Key.COUNT_MA,
                                               AMT = g.Sum(r => r.AMT),
                                               MATNO = g.Key.MATNO,
                                               g.First().SALADR,
                                           };

                                var _GG = from c1 in _GG3
                                          join c2 in _DD on new { NOBR = c1.NOBR, COMP = c1.COMP } equals new { NOBR = c2.NOBR, COMP = c2.COMP } into jj1
                                          join c3 in _RR on new { NOBR = c1.NOBR, COMP = c1.COMP } equals new { NOBR = c3.NOBR, COMP = c3.COMP } into jj2
                                          from j1 in jj1.DefaultIfEmpty()
                                          from j2 in jj2.DefaultIfEmpty()
                                          orderby c1.NOBR
                                          select new
                                          {
                                              NOBR = c1.NOBR,
                                              COMP = c1.COMP,
                                              IDNO = c1.IDNO,
                                              COMPID = c1.COMPID,
                                              NAME_C = c1.NAME_C,
                                              ADDR2 = c1.ADDR2,
                                              POSTCODE2 = c1.POSTCODE2,
                                              COUNT_MA = c1.COUNT_MA,
                                              TOT_AMT = c1.AMT,
                                              TAX_AMT = (j1 != null) ? j1.AMT : 0,
                                              RET_AMT = (j2 != null) ? j2.AMT : 0,
                                              MATNO = c1.MATNO,
                                              c1.SALADR,
                                          };

                                MedDS.YRTAXRow _YRTAXRow = medDS.YRTAX.NewYRTAXRow();

                                _YRTAXRow.F0103 = rGG.COMPANY.F0103.Trim();
                                _YRTAXRow.F0407 = rGG.COMPANY.F0407.Trim();
                                _YRTAXRow.SERIES = SERIES;
                                _YRTAXRow.MARK = " ";
                                _YRTAXRow.FORMAT = p.FORMAT;
                                _YRTAXRow.ID = rGG.COUNT_MA ? rGG.MATNO : rGG.IDNO;//20110107 外勞須要抓取統一證號 by Stanley
                                _YRTAXRow.IDCODE = IDCODE;
                                _YRTAXRow.ID1 = rGG.COMPID;
                                _YRTAXRow.TOT_AMT = _GG.First().TOT_AMT;
                                _YRTAXRow.TAX_AMT = _GG.First().TAX_AMT;
                                _YRTAXRow.REL_AMT = _YRTAXRow.TOT_AMT - _YRTAXRow.TAX_AMT;
                                _YRTAXRow.ACC_NO = rGG.NOBR;
                                _YRTAXRow.BLANK_1 = " ";
                                _YRTAXRow.ERR_MARK = " ";
                                _YRTAXRow.YEAR = p.YEAR;
                                _YRTAXRow.NAME_C = rGG.NAME_C;
                                if (rGG.COUNT_MA && _YRTAXRow.NAME_C.Trim().Length == 1) _YRTAXRow.NAME_C = rGG.NAME_E;//如果外勞名稱只有一碼，就用英文
                                _YRTAXRow.ADDR_2 = rGG.ADDR2;
                                _YRTAXRow.DATE = "      ";
                                _YRTAXRow.NOBR = rGG.NOBR;
                                _YRTAXRow.KEY_DATE = DateTime.Now;
                                _YRTAXRow.KEY_MAN = MainForm.USER_NAME;
                                _YRTAXRow.YEAR_B = YYMM_B;
                                _YRTAXRow.YEAR_E = YYMM_E;
                                _YRTAXRow.POSTCODE2 = rGG.POSTCODE2;
                                _YRTAXRow.T_OK = true;
                                _YRTAXRow.SALADR = rGG.SALADR;
                                _YRTAXRow.COMP = rGG.COMP;
                                _YRTAXRow.RET_AMT = _GG.First().RET_AMT;

                                _TOT_AMT += _YRTAXRow.TOT_AMT;
                                _TAX_AMT += _YRTAXRow.TAX_AMT;
                                _RET_AMT += _YRTAXRow.RET_AMT;
                                if (_YRTAXRow.TOT_AMT == 0) continue;//如果計算的區間無所得，就略過
                                _YRTAXRow.TOT_AMT = JBModule.Data.CEncrypt.Number(_YRTAXRow.TOT_AMT);
                                _YRTAXRow.TAX_AMT = JBModule.Data.CEncrypt.Number(_YRTAXRow.TAX_AMT);
                                _YRTAXRow.REL_AMT = JBModule.Data.CEncrypt.Number(_YRTAXRow.REL_AMT);
                                _YRTAXRow.RET_AMT = JBModule.Data.CEncrypt.Number(_YRTAXRow.RET_AMT);

                                medDS.YRTAX.AddYRTAXRow(_YRTAXRow);

                                string _s1 = SERIES.Substring(0, 1);
                                string _s2 = SERIES.Substring(1, 7);

                                if (Convert.ToInt32(_s2) > 9999999)
                                {
                                    _s1 = (_s1[0] + 1).ToString();
                                    _s2 = "0000001";
                                }
                                else
                                {
                                    _s2 = (Convert.ToInt32(_s2) + 1).ToString().PadLeft(7, '0');
                                }

                                SERIES = _s1 + _s2;
                            }
                        }
                    }
                }

                MedDS.YRTAXRow YRTAXRow = medDS.YRTAX.NewYRTAXRow();

                YRTAXRow.F0103 = rGG.COMPANY.F0103.Trim();
                YRTAXRow.F0407 = rGG.COMPANY.F0407.Trim();
                YRTAXRow.SERIES = SERIES;
                YRTAXRow.MARK = " ";
                YRTAXRow.FORMAT = p.FORMAT;
                YRTAXRow.ID = rGG.COUNT_MA ? rGG.MATNO : rGG.IDNO;
                YRTAXRow.IDCODE = IDCODE;
                YRTAXRow.ID1 = rGG.COMPID;
                YRTAXRow.TOT_AMT = rGG.TOT_AMT - _TOT_AMT;
                YRTAXRow.TAX_AMT = rGG.TAX_AMT - _TAX_AMT;
                YRTAXRow.REL_AMT = YRTAXRow.TOT_AMT - YRTAXRow.TAX_AMT;
                YRTAXRow.ACC_NO = rGG.NOBR;
                YRTAXRow.BLANK_1 = " ";
                YRTAXRow.ERR_MARK = " ";
                YRTAXRow.YEAR = p.YEAR;
                YRTAXRow.NAME_C = rGG.NAME_C;
                if (rGG.COUNT_MA && YRTAXRow.NAME_C.Trim().Length == 1) YRTAXRow.NAME_C = rGG.NAME_E;//如果外勞名稱只有一碼，就用英文
                YRTAXRow.ADDR_2 = rGG.ADDR2;
                YRTAXRow.DATE = "      ";
                YRTAXRow.NOBR = rGG.NOBR;
                YRTAXRow.KEY_DATE = DateTime.Now;
                YRTAXRow.KEY_MAN = MainForm.USER_NAME;
                YRTAXRow.YEAR_B = YYMM_B;
                YRTAXRow.YEAR_E = YYMM_E;
                YRTAXRow.POSTCODE2 = rGG.POSTCODE2;
                YRTAXRow.T_OK = false;
                if (IDCODE == "7") YRTAXRow.T_OK = true;
                YRTAXRow.SALADR = rGG.SALADR;
                YRTAXRow.COMP = rGG.COMP;
                YRTAXRow.RET_AMT = rGG.RET_AMT - _RET_AMT;

                if (YRTAXRow.TOT_AMT == 0) continue;//如果計算的區間無所得，就略過

                YRTAXRow.TOT_AMT = JBModule.Data.CEncrypt.Number(YRTAXRow.TOT_AMT);
                YRTAXRow.TAX_AMT = JBModule.Data.CEncrypt.Number(YRTAXRow.TAX_AMT);
                YRTAXRow.REL_AMT = JBModule.Data.CEncrypt.Number(YRTAXRow.REL_AMT);
                YRTAXRow.RET_AMT = JBModule.Data.CEncrypt.Number(YRTAXRow.RET_AMT);

                medDS.YRTAX.AddYRTAXRow(YRTAXRow);

                string s1 = SERIES.Substring(0, 1);
                string s2 = SERIES.Substring(1, 7);
                if (Convert.ToInt32(s2) > 9999999)
                {
                    s1 = (s1[0] + 1).ToString();
                    s2 = "0000001";
                }
                else
                {
                    s2 = (Convert.ToInt32(s2) + 1).ToString().PadLeft(7, '0');
                }
                SERIES = s1 + s2;

                int pIndex = index / count * 50;
                if (pIndex > 60) pIndex = 60;
                backgroundWorker1.ReportProgress(40 + pIndex);

                index++;
            }

            new MedDSTableAdapters.YRTAXTableAdapter().Update(medDS.YRTAX);
            backgroundWorker1.ReportProgress(100);
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show(Resources.All.ImportCompleted, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.None);
            panel1.Enabled = true;
        }
        void SetValue()
        {
            Sal.Core.SalaryDate sd = new Sal.Core.SalaryDate(textBoxYYMM_B.Text);
            Sal.Core.SalaryDate sd1 = new Sal.Core.SalaryDate(sd.FirstDayOfMonth.AddMonths(11));
            //textBoxYYMM_E.Text = sd1.YYMM;
            textBoxYYMM_E.Text = sd1.YYMM;
            txtPayDateB.Text = Sal.Function.GetDate(new DateTime(Convert.ToInt32(textBoxYEAR.Text), 1, 1));
            txtPayDateE.Text = Sal.Function.GetDate(new DateTime(Convert.ToInt32(textBoxYEAR.Text), 12, 31));
        }

        private void textBoxYYMM_B_Validated(object sender, EventArgs e)
        {
            SetValue();
        }
    }
}
