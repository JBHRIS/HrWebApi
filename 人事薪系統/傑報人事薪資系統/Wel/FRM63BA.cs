using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace JBHR.Wel
{
    public partial class FRM63BA : JBControls.JBForm
    {
        class param
        {
            public string YYMM_B, YYMM_E;
            public string NOBR_B, NOBR_E;
            public string YEAR;
            public string Format;
        }

        public FRM63BA()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            param p = new param();
            p.YYMM_B = textBoxYYMM_B.Text;
            p.YYMM_E = textBoxYYMM_E.Text;
            p.NOBR_B = textBoxNOBR_B.Text;
            p.NOBR_E = textBoxNOBR_E.Text;
            p.YEAR = textBoxYEAR.Text;
            p.Format = cbFormat.SelectedValue;

            button1.Enabled = false;
            backgroundWorker1.RunWorkerAsync(p);
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            param p = e.Argument as param;

            string YYYY = (Convert.ToInt32(p.YEAR)).ToString();
            List<string> WORKADR = new List<string>();
            WelDSTableAdapters.YRWELTableAdapter YRWELTableAdapter = new JBHR.Wel.WelDSTableAdapters.YRWELTableAdapter();
            //YRWELTableAdapter.DeleteQueryByYear_Nobr(p.YEAR, p.NOBR_B, p.NOBR_E);

            backgroundWorker1.ReportProgress(10);
            foreach (var it in MainForm.WriteDataGroups)
                WORKADR.Add(it);

            FRM63DataClassesDataContext frm63dc = new FRM63DataClassesDataContext();
            var deleteSQL = from a in frm63dc.YRWEL
                            where a.YEAR == p.YEAR && WORKADR.Contains(a.SALADR)
                                && a.NOBR.CompareTo(p.NOBR_B) >= 0 && a.NOBR.CompareTo(p.NOBR_E) <= 0
                                && a.FORMAT == p.Format
                            select a;
            frm63dc.YRWEL.DeleteAllOnSubmit(deleteSQL);
            frm63dc.SubmitChanges();

            var dbWELF = (from c in frm63dc.WELF
                          where
                             c.YYMM.Trim().CompareTo(p.YYMM_B) >= 0 && c.YYMM.Trim().CompareTo(p.YYMM_E) <= 0 &&
                             c.NOBR.Trim().CompareTo(p.NOBR_B) >= 0 && c.NOBR.Trim().CompareTo(p.NOBR_E) <= 0 &&
                             (c.AMT > 0 || c.D_AMT > 0)
                             && c.FORMAT == p.Format
                             && WORKADR.Contains(c.SALADR)
                          group c by new { c.NOBR } into g//必須要是同一個格式
                          select new
                          {
                              NOBR = g.First().NOBR.Trim(),
                              FORMAT = g.First().FORMAT.Trim(),
                              GP = g
                              //TOT_D_AMT = g.Sum(welf => welf.D_AMT)
                          }).ToList();
            var dbWaged = from a in frm63dc.WAGED
                          join b in frm63dc.WAGE on new { a.NOBR, a.YYMM, a.SEQ } equals new { b.NOBR, b.YYMM, b.SEQ }
                          where a.NOBR.CompareTo(p.NOBR_B) >= 0 && a.NOBR.CompareTo(p.NOBR_E) <= 0
                              && a.YYMM.CompareTo(p.YYMM_B) >= 0 && a.YYMM.CompareTo(p.YYMM_E) <= 0
                              && a.SAL_CODE == MainForm.SalaryConfig.WELSALCODE
                              && p.Format == "92"
                              && WORKADR.Contains(b.SALADR)
                          group new { a.NOBR, a.AMT, a.YYMM, a.SEQ, a.SAL_CODE, b.SALADR } by new { a.NOBR } into gp
                          select gp;
            var wagedList = (from a in dbWaged
                             select new
                         {
                             NOBR = a.Key.NOBR,
                             a.First().SALADR,
                             GP = a
                             //TOT_D_AMT = 0
                         }).ToList();






            //FRM63DataClassesDataContext frm63dc = new FRM63DataClassesDataContext();
            var dbBASE = (from a in frm63dc.BASE
                          join b in frm63dc.BASETTS on a.NOBR equals b.NOBR
                          where DateTime.Today >= b.ADATE && DateTime.Today <= b.DDATE.Value
                          select new { a.NOBR, a.NAME_C, b.TTSCODE, b.INDT, a.COUNT_MA, a.MATNO, a.TAXNO, b.SALADR, a.IDNO, a.ADDR2 }
                              ).ToList();
            var DataQuery = (from a in dbWELF select new { a.NOBR })
                .Union(from b in wagedList select new { b.NOBR });
            var DQQ = from a in DataQuery
                      join b in dbBASE on a.NOBR equals b.NOBR
                      select new
                      {
                          a.NOBR,
                          b.NAME_C,
                          TTSCODE = b.TTSCODE.Trim(),
                          name_c = b.NAME_C.Trim(),
                          ADDR2 = b.ADDR2.Trim(),
                          indt = b.INDT,
                          count_ma = b.COUNT_MA,
                          taxno = b.TAXNO.Trim(),
                          matno = b.MATNO.Trim(),
                          saladr = b.SALADR.Trim(),
                          idno = b.IDNO.Trim()
                      };

            //foreach (var itm in DataQuery)
            //{
            //    var Welf = dbWELF.Where(pp => pp.NOBR == itm.NOBR && pp.FORMAT == itm.FORMAT);
            //    var Waged = wagedList.Where(pp => pp.NOBR == itm.NOBR && pp.FORMAT == itm.FORMAT);
            //    var amtWelf = Welf.Any() ? Welf.First().TOT_AMT : 0;
            //    var DamtWelf = Welf.Any() ? Welf.First().TOT_D_AMT : 0;
            //    var amtWaged = wagedList.First().TOT_AMT;


            //}
            //var dbUSYS1 = from c in frm63dc.U_SYS1 select c;
            //var dbUSYS2 = from c in frm63dc.U_SYS2 select c;

            //var vWELF = from c1 in dbWELF.ToArray()
            //            join c2 in dbBASE.ToArray() on c1.NOBR.Trim() equals c2.NOBR.Trim()
            //            //orderby c1.YYMM, c1.SEQ, c1.NOBR
            //            select new
            //            {
            //                nobr = c1.NOBR,
            //                tot_amt = c1.TOT_AMT,
            //                tot_d_amt = c1.TOT_D_AMT,
            //                format = c1.FORMAT,
            //                ttscode = c2.BASETTS.First().TTSCODE.Trim(),
            //                name_c = c2.NAME_C.Trim(),
            //                addr2 = c2.ADDR2.Trim(),
            //                indt = c2.BASETTS.First().INDT,
            //                count_ma = c2.COUNT_MA,
            //                taxno = c2.TAXNO.Trim(),
            //                matno = c2.MATNO.Trim(),
            //                saladr = c2.BASETTS.First().SALADR.Trim(),
            //                idno = c2.IDNO.Trim()
            //            };

            string series;
            string ser_1;
            string ser_2;

            if (frm63dc.YRWEL.Count() > 0)
            {
                series = frm63dc.YRWEL.Max(r => r.SERIES);

                ser_1 = series.Substring(0, 1);
                ser_2 = series.Substring(1, 7);
            }
            else
            {
                ser_1 = "A";
                ser_2 = "0000000";
            }

            ASCIIEncoding AE = new ASCIIEncoding();
            byte[] byteArray = AE.GetBytes(ser_1);

            int index = 1;
            foreach (var r in DQQ)
            {
                if (Convert.ToInt32(ser_2) + 1 == 10000000)
                {
                    byteArray[0] += 1;
                    ser_2 = (1).ToString().PadLeft(7, '0');
                }
                else
                {
                    ser_2 = (Convert.ToInt32(ser_2) + 1).ToString().PadLeft(7, '0');
                }
                var Welf = dbWELF.Where(pp => pp.NOBR == r.NOBR);
                var Waged = wagedList.Where(pp => pp.NOBR == r.NOBR);
                var amtWelf = Welf.Any() ? Welf.First().GP.Sum(pp => pp.AMT) : 0;
                var DamtWelf = Welf.Any() ? Welf.First().GP.Sum(pp => pp.D_AMT) : 0;
                var amtWaged = Waged.Any() ? Waged.First().GP.Sum(pp => JBModule.Data.CDecryp.Number(pp.AMT)) : 0;

                YRWEL oYRWEL = new YRWEL();
                oYRWEL.F0103 = (MainForm.CompanyConfig.FF103 != null) ? MainForm.CompanyConfig.FF103.Trim() : "";
                oYRWEL.F0407 = (MainForm.CompanyConfig.FF04071 != null) ? MainForm.CompanyConfig.FF04071.Trim() : "";
                oYRWEL.SERIES = new StringBuilder().Append(AE.GetChars(byteArray)).ToString() + ser_2;
                oYRWEL.MARK = "";
                oYRWEL.FORMAT = p.Format;
                oYRWEL.ID = (r.count_ma) ? r.matno : r.idno;
                oYRWEL.IDCODE = (r.count_ma) ? "3" : "0";
                oYRWEL.ID1 = MainForm.CompanyConfig.COMPID1;
                oYRWEL.TOT_AMT = amtWelf - amtWaged;
                oYRWEL.TAX_AMT = DamtWelf;
                oYRWEL.REL_AMT = oYRWEL.TOT_AMT - oYRWEL.TAX_AMT;
                oYRWEL.ACC_NO = "";
                oYRWEL.BLANK_1 = "";
                oYRWEL.ERR_MARK = "";
                oYRWEL.YEAR = p.YEAR;
                oYRWEL.NAME_C = r.name_c;
                oYRWEL.ADDR_2 = r.ADDR2;
                oYRWEL.DATE = "";
                oYRWEL.NOBR = r.NOBR;
                oYRWEL.KEY_MAN = MainForm.USER_NAME;
                oYRWEL.KEY_DATE = DateTime.Now;
                oYRWEL.SALADR = r.saladr;
                if (Waged.Any())
                    oYRWEL.SALADR = Waged.First().SALADR;
                oYRWEL.T_OK = (r.count_ma && r.TTSCODE.Trim() == "2") ? true : false;

                oYRWEL.ADDR_2 = oYRWEL.ADDR_2.Replace('1', '１');
                oYRWEL.ADDR_2 = oYRWEL.ADDR_2.Replace('2', '２');
                oYRWEL.ADDR_2 = oYRWEL.ADDR_2.Replace('3', '３');
                oYRWEL.ADDR_2 = oYRWEL.ADDR_2.Replace('4', '４');
                oYRWEL.ADDR_2 = oYRWEL.ADDR_2.Replace('5', '５');
                oYRWEL.ADDR_2 = oYRWEL.ADDR_2.Replace('6', '６');
                oYRWEL.ADDR_2 = oYRWEL.ADDR_2.Replace('7', '７');
                oYRWEL.ADDR_2 = oYRWEL.ADDR_2.Replace('8', '８');
                oYRWEL.ADDR_2 = oYRWEL.ADDR_2.Replace('9', '９');
                oYRWEL.ADDR_2 = oYRWEL.ADDR_2.Replace('0', '０');
                oYRWEL.ADDR_2 = oYRWEL.ADDR_2.Replace('-', '－');
                oYRWEL.ADDR_2 = oYRWEL.ADDR_2.Replace('~', '～');
                oYRWEL.ADDR_2 = oYRWEL.ADDR_2.Replace('f', '樓');
                oYRWEL.ADDR_2 = oYRWEL.ADDR_2.Replace('F', '樓');
                oYRWEL.ADDR_2 = oYRWEL.ADDR_2.Replace(" ", "");
                oYRWEL.ADDR_2 = oYRWEL.ADDR_2.Replace("(", "");
                oYRWEL.ADDR_2 = oYRWEL.ADDR_2.Replace(")", "");
                oYRWEL.ADDR_2 = oYRWEL.ADDR_2.Replace("#", "");
                oYRWEL.ADDR_2 = oYRWEL.ADDR_2.Replace("@", "");
                oYRWEL.ADDR_2 = oYRWEL.ADDR_2.Replace("*", "");
                oYRWEL.ADDR_2 = oYRWEL.ADDR_2.Replace("?", "㊣");

                oYRWEL.NAME_C = oYRWEL.NAME_C.Replace("(", "");
                oYRWEL.NAME_C = oYRWEL.NAME_C.Replace(")", "");
                oYRWEL.NAME_C = oYRWEL.NAME_C.Replace("#", "");
                oYRWEL.NAME_C = oYRWEL.NAME_C.Replace("@", "");
                oYRWEL.NAME_C = oYRWEL.NAME_C.Replace("*", "");
                oYRWEL.NAME_C = oYRWEL.NAME_C.Replace("?", "㊣");

                frm63dc.YRWEL.InsertOnSubmit(oYRWEL);

                decimal pIndex = Math.Floor(Convert.ToDecimal(index) / Convert.ToDecimal(DQQ.Count()) * Convert.ToDecimal(80));
                if (pIndex > 0 && pIndex % 8 == 0)
                {
                    backgroundWorker1.ReportProgress(10 + Convert.ToInt32(pIndex));
                }
                index++;
            }

            frm63dc.SubmitChanges();
            backgroundWorker1.ReportProgress(100);
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show(Resources.All.ImportCompleted, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.None);
            Close();
        }

        private void FRM63BA_Load(object sender, EventArgs e)
        {
            // TODO: 這行程式碼會將資料載入 'medDS.YRFORMAT' 資料表。您可以視需要進行移動或移除。
            this.yRFORMATTableAdapter.Fill(this.medDS.YRFORMAT);
            // TODO: 這行程式碼會將資料載入 'welDS.V_BASE' 資料表。您可以視需要進行移動或移除。
            Sal.Function.SetAvaliableVBase(this.welDS.V_BASE);

            textBoxNOBR_B.Text = this.welDS.V_BASE.Min(r => r.NOBR);
            textBoxNOBR_E.Text = this.welDS.V_BASE.Max(r => r.NOBR);
        }
    }
}
