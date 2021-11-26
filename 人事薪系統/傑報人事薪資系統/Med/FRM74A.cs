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
    public partial class FRM74A : JBControls.JBForm
    {
        class param
        {
            public string YYMM_B, YYMM_E;
            public string YEAR;
            public string NOBR_B, NOBR_E;
            public string SER_NOB, SER_NOE;
            //public string FORMAT;
        }

        public FRM74A()
        {
            InitializeComponent();
        }

        private void FRM51A_Load(object sender, EventArgs e)
        {
            this.tBASETableAdapter.Fill(this.medDS.TBASE);
            this.yRFORMATTableAdapter.Fill(this.medDS.YRFORMAT);

            //new MedDSTableAdapters.U_SYS9TableAdapter().Fill(this.medDS.U_SYS9);
            //new MedDSTableAdapters.U_SYS4TableAdapter().Fill(this.medDS.U_SYS4);
            //new MedDSTableAdapters.U_SYS1TableAdapter().Fill(this.medDS.U_SYS1);

            if (this.medDS.TBASE.Count > 0)
            {
                popupTextBoxNOBR_B.Text = this.medDS.TBASE.Min(row => row.NOBR);
                popupTextBoxNOBR_E.Text = this.medDS.TBASE.Max(row => row.NOBR);
            }

            textBoxSER_NOB.Text = "B0000001";
            textBoxSER_NOE.Text = "Z9999999";
            //if (MainForm.WriteRules.Where(p => p.COMPANY == MainForm.COMPANY).FirstOrDefault() != null)
            //{
            //    var flags = MainForm.WriteRules.Where(p => p.COMPANY == MainForm.COMPANY && p.DATAGROUP1.TYRTAX_FLAG != null && p.DATAGROUP1.TYRTAX_FLAG.Trim().Length > 0).Select(p => p.DATAGROUP1.TYRTAX_FLAG).Distinct();
            //    if (flags.Any())
            //    {
            //        textBoxSER_NOB.Text = flags.Min() + "0000001";
            //        textBoxSER_NOE.Text = flags.Min() + "9999999";
            //    }
            //}
            //comboBoxFORMAT.SelectedValue = "50";
            Sal.Core.SalaryDate sd = new Sal.Core.SalaryDate(DateTime.Today, true);
            textBoxYYMM_B.Text = sd.YYMM;
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
            p.YEAR = textBoxYEAR.Text;
            p.NOBR_B = popupTextBoxNOBR_B.Text;
            p.NOBR_E = popupTextBoxNOBR_E.Text;
            p.SER_NOB = textBoxSER_NOB.Text;
            p.SER_NOE = textBoxSER_NOE.Text;
            //p.FORMAT = comboBoxFORMAT.SelectedValue;

            panel1.Enabled = false;

            backgroundWorker1.RunWorkerAsync(p);
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            param p = e.Argument as param;

            //List<string> WORKADR = new List<string>();
            //if (MainForm.PROCSUPER)
            //{
            //    new MedDSTableAdapters.SALADRTableAdapter().Fill(this.medDS.SALADR);
            //    foreach (DataRow row in this.medDS.SALADR.Rows) WORKADR.Add(row["saladr"].ToString().Trim());
            //}
            //else
            //{
            //    WORKADR.Add(MainForm.WORKADR.Trim());
            //}

            JBModule.Data.CSQL mySql = new JBModule.Data.CSQL("JBHR.Properties.Settings.JBHRConnectionString");

            string sql = "";

            //先刪除已存在的媒體申報資料
            //if (MainForm.PROCSUPER)
            //{
            //    sql = "delete from tyrtax" +
            //        " where series between '" + p.SER_NOB + "' and '" + p.SER_NOE + "'" +
            //        " and nobr between '" + p.NOBR_B + "' and '" + p.NOBR_E + "'" +
            //        " and year = '" + p.YEAR + "'";// +
            //    //" and FORMAT = '" + p.FORMAT + "'";
            //}
            //else
            //{
            sql = "delete from tyrtax" +
                " where series between '" + p.SER_NOB + "' and '" + p.SER_NOE + "'" +
                " and nobr between '" + p.NOBR_B + "' and '" + p.NOBR_E + "'" +
                " and year = '" + p.YEAR + "'" +
                 " and saladr in (";
            foreach (var it in MainForm.WriteDataGroups)
                sql += "'" + it + "',";
            sql += "'')";
            //}
            mySql.ExecuteNonQuery(sql);
            backgroundWorker1.ReportProgress(20);

            string YYMM_B = p.YYMM_B.Trim().Substring(0, 4) + "/" + p.YYMM_B.Trim().Substring(4, 2) + "/1";
            string YYMM_E = p.YYMM_E.Trim().Substring(0, 4) + "/" + p.YYMM_E.Trim().Substring(4, 2) + "/" +
                DateTime.DaysInMonth(Convert.ToInt32(p.YYMM_E.Trim().Substring(0, 4)), Convert.ToInt32(p.YYMM_E.Trim().Substring(4, 2))).ToString();

            JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
            //依條件取出應稅薪資明細
            var GG1 = from c in db.TWAGED
                      join d in db.TBASE on c.NOBR equals d.NOBR
                      join f in db.COMP on c.COMP equals f.COMP1
                      where c.YYMM.Trim().CompareTo(p.YYMM_B) >= 0 && c.YYMM.Trim().CompareTo(p.YYMM_E) <= 0
                      && c.NOBR.Trim().CompareTo(p.NOBR_B) >= 0 && c.NOBR.Trim().CompareTo(p.NOBR_E) <= 0
                      && MainForm.WriteDataGroups.Contains(c.SALADR)
                      orderby c.NOBR
                      select new
                      {
                          NOBR = c.NOBR.Trim(),
                          COMP = c.COMP.Trim(),
                          IDNO = d.IDNO.Trim(),
                          COMPID = f.COMPID.Trim(),
                          NAME_C = d.NAME_C.Trim(),
                          NAME_E = d.NAME_C.Trim(),
                          ADDR2 = d.ADDR.Trim(),
                          POSTCODE2 = d.POSTCODE1.Trim(),
                          AMT = JBModule.Data.CDecryp.Number(c.AMT),
                          D_AMT = JBModule.Data.CDecryp.Number(c.D_AMT),
                          IDCODE = d.IDCODE,
                          c.FORSUB,
                          c.INA_ID,
                          c.FORMAT,
                          c.SALADR,
                      };
            ////作群組
            var GG3 = from c in GG1
                      group c by c.FORMAT;

            backgroundWorker1.ReportProgress(40);

            int index = 0;
            int count = GG1.Count();
            //取得目前最大序號
            string SERIES = "";
            sql = "select max(series) as series from tyrtax" +
                " where year = '" + p.YEAR + "'" +
            " and series between '" + p.SER_NOB + "' and '" + p.SER_NOE + "'";
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
            foreach (var it in GG3)//每種格式
            {

                var GG = from a in it group a by a.NOBR;
                foreach (var rGG in GG)
                {
                    string IDCODE = rGG.First().IDCODE;
                    //decimal _TOT_AMT = 0;
                    //decimal _TAX_AMT = 0;

                    MedDS.TYRTAXRow TYRTAXRow = medDS.TYRTAX.NewTYRTAXRow();

                    TYRTAXRow.F0103 = MainForm.CompanyConfig.FF103;
                    TYRTAXRow.F0407 = MainForm.CompanyConfig.FF0407;
                    TYRTAXRow.SERIES = SERIES;
                    TYRTAXRow.MARK = " ";
                    TYRTAXRow.FORMAT = it.Key;
                    TYRTAXRow.ID = rGG.First().IDNO;
                    TYRTAXRow.IDCODE = IDCODE;
                    TYRTAXRow.ID1 = rGG.First().COMPID;
                    TYRTAXRow.TOT_AMT = rGG.Sum(pp => pp.AMT);
                    TYRTAXRow.TAX_AMT = rGG.Sum(pp => pp.D_AMT);
                    TYRTAXRow.REL_AMT = TYRTAXRow.TOT_AMT - TYRTAXRow.TAX_AMT;
                    TYRTAXRow.ACC_NO = rGG.Key;
                    TYRTAXRow.BLANK_1 = " ";
                    TYRTAXRow.ERR_MARK = " ";
                    TYRTAXRow.YEAR = p.YEAR;
                    TYRTAXRow.NAME_C = rGG.First().NAME_C;
                    TYRTAXRow.ADDR_2 = rGG.First().ADDR2;
                    TYRTAXRow.DATE = "      ";
                    TYRTAXRow.NOBR = rGG.Key;
                    TYRTAXRow.KEY_DATE = DateTime.Now;
                    TYRTAXRow.KEY_MAN = MainForm.USER_NAME;
                    TYRTAXRow.YEAR_B = YYMM_B;
                    TYRTAXRow.YEAR_E = YYMM_E;
                    TYRTAXRow.TAXTYPE = "";
                    TYRTAXRow.RET_AMT = 0;
                    TYRTAXRow.NOMODI = false;
                    TYRTAXRow.ACC_NO = TYRTAXRow.NOBR;
                    TYRTAXRow.INA_ID = rGG.First().INA_ID;
                    TYRTAXRow.FORSUB = rGG.First().FORSUB;
                    TYRTAXRow.SALADR = rGG.First().SALADR;

                    if (TYRTAXRow.TOT_AMT == 0) continue;//如果計算的區間無所得，就略過

                    TYRTAXRow.TOT_AMT = JBModule.Data.CEncrypt.Number(TYRTAXRow.TOT_AMT);
                    TYRTAXRow.TAX_AMT = JBModule.Data.CEncrypt.Number(TYRTAXRow.TAX_AMT);
                    TYRTAXRow.REL_AMT = JBModule.Data.CEncrypt.Number(TYRTAXRow.REL_AMT);
                    TYRTAXRow.RET_AMT = JBModule.Data.CEncrypt.Number(TYRTAXRow.RET_AMT);

                    medDS.TYRTAX.AddTYRTAXRow(TYRTAXRow);

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
            }

            new MedDSTableAdapters.TYRTAXTableAdapter().Update(medDS.TYRTAX);
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

        private void textBoxYYMM_B_Validated(object sender, EventArgs e)
        {
            SetValue();
        }
        void SetValue()
        {
            Sal.Core.SalaryDate sd = new Sal.Core.SalaryDate(textBoxYYMM_B.Text);
            Sal.Core.SalaryDate sd1 = new Sal.Core.SalaryDate(sd.FirstDayOfMonth.AddMonths(11), true);
            textBoxYYMM_E.Text = sd1.YYMM;
            textBoxYEAR.Text = sd.FirstDayOfMonth.Year.ToString();
        }
    }
}
