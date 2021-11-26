using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace JBHR.Ins
{
    public partial class FRM3V : JBControls.JBForm
    {
        public FRM3V()
        {
            InitializeComponent();
        }

        private void FRM3V_Load(object sender, EventArgs e)
        {
            var deptDisp = CodeFunction.GetDeptDisp();
            SystemFunction.SetComboBoxItems(cbxDeptB, deptDisp, false, true, true);
            SystemFunction.SetComboBoxItems(cbxDeptE, deptDisp, false, true, true);
            //SystemFunction.SetComboBoxItems(comboBoxInsComp, CodeFunction.GetInsComp());
            this.v_BASETableAdapter.Fill(this.mainDS.V_BASE);
            Sal.Core.SalaryDate sd = new Sal.Core.SalaryDate(DateTime.Now, true);
            txtYYMM.Text = sd.YYMM;
            txtSeq.Text = "2";
            textBoxSeq1.Text = "Z";
            textBoxYear.Text = DateTime.Today.Year.ToString();
            cbxDeptB.SelectedValue = deptDisp.First().Key;
            cbxDeptE.SelectedValue = deptDisp.Last().Key;
            ptxNobrB.Text = this.mainDS.V_BASE.First().NOBR;
            ptxNobrE.Text = this.mainDS.V_BASE.Last().NOBR;
            txtFileName.Text = @"C:\temp";
            SetData(txtYYMM.Text);
            txtYYMM.Focus();
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGen_Click(object sender, EventArgs e)
        {
            //if (JBTools.IO.FileSystem.IsOpenedFile(txtFileName.Text))
            //{
            //    MessageBox.Show("目的地的檔案已開啟，請關閉後重新產生，或是指定其他位置", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}
            JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
            DateTime d1, d2;
            int year = Convert.ToInt32(textBoxYear.Text);
            d1 = new DateTime(year, 1, 1);
            d2 = new DateTime(year, 12, 31);
            var sql = from a in db.EXPSUP
                      join b in db.BASETTS on a.NOBR equals b.NOBR
                      join c in db.INSCOMP on a.S_NO equals c.S_NO into ac
                      from inscomp in ac.DefaultIfEmpty()
                      join d in db.BASE on a.NOBR equals d.NOBR
                      join f in db.COMP on b.COMP equals f.COMP1
                      join g in db.DEPT on b.DEPT equals g.D_NO
                      join h in db.WAGE on new { a.NOBR, a.YYMM, a.SEQ } equals new { h.NOBR, h.YYMM, h.SEQ }//為了排除派遣B期
                      where DateTime.Today >= b.ADATE && DateTime.Today <= b.DDATE.Value
                      && b.NOBR.CompareTo(ptxNobrB.Text) >= 0 && b.NOBR.CompareTo(ptxNobrE.Text) <= 0
                      && g.D_NO_DISP.CompareTo(cbxDeptB.SelectedValue.ToString()) >= 0 && g.D_NO_DISP.CompareTo(cbxDeptE.SelectedValue.ToString()) <= 0
                      && a.YYMM.CompareTo(txtYYMM.Text) >= 0 && a.YYMM.CompareTo(textBoxYYMM1.Text) <= 0
                      && a.SEQ.CompareTo(txtSeq.Text) >= 0 && a.SEQ.CompareTo(textBoxSeq1.Text) <= 0
                      && a.PAY_DATE >= d1 && a.PAY_DATE <= d2
                      && a.PAY_AMT > 10
                     && MainForm.WriteDataGroups.Contains(h.SALADR)
                      group new { EXPSUP = a, COMP_IDNO = inscomp != null ? inscomp.INSIDNO : f.COMPID, IDNO = d.COUNT_MA ? d.MATNO : d.IDNO, d.NAME_C, INSID = inscomp != null ? inscomp.INSPO : "" } by new { h.COMP, a.NOBR, a.YYMM, a.SEQ };

            var sqlFilter = (from a in db.EXPSUP
                             join b in db.BASETTS on a.NOBR equals b.NOBR
                             join c in db.INSCOMP on a.S_NO equals c.S_NO into ac
                             from inscomp in ac.DefaultIfEmpty()
                             join d in db.BASE on a.NOBR equals d.NOBR
                             join f in db.COMP on b.COMP equals f.COMP1
                             join g in db.DEPT on b.DEPT equals g.D_NO
                             join h in db.WAGE on new { a.NOBR, a.YYMM, a.SEQ } equals new { h.NOBR, h.YYMM, h.SEQ }//為了排除派遣B期
                             where DateTime.Today >= b.ADATE && DateTime.Today <= b.DDATE.Value
                             && b.NOBR.CompareTo(ptxNobrB.Text) >= 0 && b.NOBR.CompareTo(ptxNobrE.Text) <= 0
                             && g.D_NO_DISP.CompareTo(cbxDeptB.SelectedValue.ToString()) >= 0 && g.D_NO_DISP.CompareTo(cbxDeptE.SelectedValue.ToString()) <= 0
                             && a.YYMM.CompareTo(txtYYMM.Text) >= 0 && a.YYMM.CompareTo(textBoxYYMM1.Text) <= 0
                             && a.SEQ.CompareTo(txtSeq.Text) >= 0 && a.SEQ.CompareTo(textBoxSeq1.Text) <= 0
                             && a.PAY_DATE >= d1 && a.PAY_DATE <= d2
                             && a.PAY_AMT > 10
                             && a.SUP_AMT > 10
                            && MainForm.WriteDataGroups.Contains(h.SALADR)
                             select a.NOBR).Distinct().ToList();
            string msg = "";
            foreach (var gp in sql.GroupBy(p => p.Key.COMP))
            {
                JBHRIS.HR.Ins.CASuppleInsurance cs = new JBHRIS.HR.Ins.CASuppleInsurance();
                foreach (var it in gp)
                {
                    if (!sqlFilter.Contains(it.Key.NOBR)) continue;//不存在就略過(只抓年度有金額)
                    if (JBModule.Data.CDecryp.Number(it.First().EXPSUP.INS_HAMT) > 0)
                        cs.Insert(it.First().INSID, it.First().COMP_IDNO, it.First().IDNO, it.First().NAME_C, it.First().EXPSUP.PAY_DATE, "62", it.Sum(p => JBModule.Data.CDecryp.Number(p.EXPSUP.PAY_AMT)), JBModule.Data.CDecryp.Number(it.First().EXPSUP.INS_HAMT), 0, "", "", 0, 0, DateTime.MinValue, "", it.Sum(p => JBModule.Data.CDecryp.Number(p.EXPSUP.SUP_AMT)));
                    else
                        cs.Insert(it.First().INSID, it.First().COMP_IDNO, it.First().IDNO, it.First().NAME_C, it.First().EXPSUP.PAY_DATE, "63", it.Sum(p => JBModule.Data.CDecryp.Number(p.EXPSUP.PAY_AMT)), JBModule.Data.CDecryp.Number(it.First().EXPSUP.INS_HAMT), 0, "", "", 0, 0, DateTime.MinValue, "", it.Sum(p => JBModule.Data.CDecryp.Number(p.EXPSUP.SUP_AMT)));
                }
                string path = txtFileName.Text + @"\補充保費申報_扣繳資料_" + gp.First().First().COMP_IDNO + ".csv";
                msg += path;
                JBModule.Data.CNPOI.CreateCSVFile(cs.ExportDataTable, path);
            }
            //Sal.Core.SalaryDate sd = new Sal.Core.SalaryDate(DateTime.Now);
            //var sql1 = from a in db.TWAGED
            //           join b in db.TBASE on a.NOBR equals b.NOBR
            //           join c in db.YRFORMAT on a.FORMAT.Trim() equals c.M_FORMAT.Trim()
            //           join f in db.COMP on a.COMP equals f.COMP1
            //           where
            //               //b.NOBR.CompareTo(ptxNobrB.Text) >= 0 && b.NOBR.CompareTo(ptxNobrE.Text) <= 0 &&
            //           a.YYMM.CompareTo(d1.ToString("yyyyMM")) >= 0 && a.YYMM.CompareTo(d2.ToString("yyyyMM")) <= 0
            //           && a.SEQ.CompareTo(txtSeq.Text) >= 0 && a.SEQ.CompareTo(textBoxSeq1.Text) <= 0
            //           && c.INCOMETYPE.Trim().Length > 0
            //           && a.SUP_AMT != 10
            //           && MainForm.WriteDataGroups.Contains(a.SALADR)
            //           select new { TWAGED = a, COMP_IDNO = f.COMPID, IDNO = b.IDNO, b.NAME_C, INCOMETYPE = c.INCOMETYPE, a.FORMAT };

            //foreach (var it in sql1)
            //{
            //    Sal.Core.SalaryDate sd1 = new Sal.Core.SalaryDate(it.TWAGED.YYMM);
            //    cs.Insert("", it.COMP_IDNO, it.IDNO, it.NAME_C, sd1.FirstDayOfMonth, it.INCOMETYPE, JBModule.Data.CDecryp.Number(it.TWAGED.AMT), 0, 0, "", "", 0, 0, sd1.FirstDayOfMonth, "", JBModule.Data.CDecryp.Number(it.TWAGED.SUP_AMT));
            //}

            //JBModule.Data.CNPOI.RenderDataTableToExcel(cs.ExportDataTable, txtFileName.Text);

            MessageBox.Show("產生完成!!" + Environment.NewLine + msg, "訊息", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void btnBrowser_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog sfd = new FolderBrowserDialog();
            sfd.SelectedPath = txtFileName.Text;
            if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txtFileName.Text = sfd.SelectedPath;
            }
        }

        private void txtYYMM_Validated(object sender, EventArgs e)
        {
            SetData(txtYYMM.Text);
        }
        void SetData(string YYMM)
        {
            Sal.Core.SalaryDate sd = new Sal.Core.SalaryDate(YYMM);
            Sal.Core.SalaryDate sd1 = new Sal.Core.SalaryDate(sd.FirstDayOfMonth.AddMonths(11), true);
            textBoxYYMM1.Text = sd1.YYMM;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime d1, d2;
            int year = Convert.ToInt32(textBoxYear.Text);
            d1 = new DateTime(year, 1, 1);
            d2 = new DateTime(year, 12, 31);
            JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
            var sql = from a in db.EXPSUP
                      join b in db.BASETTS on a.NOBR equals b.NOBR
                      join c in db.INSCOMP on a.S_NO equals c.S_NO into ac
                      from inscomp in ac.DefaultIfEmpty()
                      join d in db.BASE on a.NOBR equals d.NOBR
                      join f in db.COMP on b.COMP equals f.COMP1
                      join g in db.DEPT on b.DEPT equals g.D_NO
                      join h in db.WAGE on new { a.NOBR, a.YYMM, a.SEQ } equals new { h.NOBR, h.YYMM, h.SEQ }//為了排除派遣B期
                      let INSIDNO = inscomp != null ? inscomp.INSIDNO : f.COMPID
                      where DateTime.Today >= b.ADATE && DateTime.Today <= b.DDATE.Value
                      && b.NOBR.CompareTo(ptxNobrB.Text) >= 0 && b.NOBR.CompareTo(ptxNobrE.Text) <= 0
                      && g.D_NO_DISP.CompareTo(cbxDeptB.SelectedValue.ToString()) >= 0 && g.D_NO_DISP.CompareTo(cbxDeptE.SelectedValue.ToString()) <= 0
                      && a.YYMM.CompareTo(txtYYMM.Text) >= 0 && a.YYMM.CompareTo(textBoxYYMM1.Text) <= 0
                      && a.SEQ.CompareTo(txtSeq.Text) >= 0 && a.SEQ.CompareTo(textBoxSeq1.Text) <= 0
                        && MainForm.WriteDataGroups.Contains(h.SALADR)
                      select new { 統一編號 = INSIDNO, 所得人身分證號 = d.COUNT_MA ? d.MATNO : d.IDNO, 所得人姓名 = d.NAME_C, 所得人地址 = d.ADDR2 };
            //var sql1 = from a in db.TWAGED
            //           join b in db.TBASE on a.NOBR equals b.NOBR
            //           join c in db.YRFORMAT on a.FORMAT.Trim() equals c.M_FORMAT.Trim()
            //           join f in db.COMP on a.COMP equals f.COMP1
            //           let INSIDNO = f.COMPID
            //           where
            //               //b.NOBR.CompareTo(ptxNobrB.Text) >= 0 && b.NOBR.CompareTo(ptxNobrE.Text) <= 0 &&
            //           a.YYMM.CompareTo(d1.ToString("yyyyMM")) >= 0 && a.YYMM.CompareTo(d2.ToString("yyyyMM")) <= 0
            //           && a.SEQ.CompareTo(txtSeq.Text) >= 0 && a.SEQ.CompareTo(textBoxSeq1.Text) <= 0
            //           && c.INCOMETYPE.Trim().Length > 0
            //             && MainForm.WriteDataGroups.Contains(a.SALADR)
            //           select new { 統一編號 = INSIDNO, 所得人身分證號 = b.IDNO, 所得人姓名 = b.NAME_C, 所得人地址 = b.ADDR };
            var data = sql.Distinct();
            //var data1 = data.Union(sql1.Distinct());
            int cc = 0;
            string msg = "";
            foreach (var it in data.GroupBy(p => p.統一編號))
            {
                var dt = it.CopyToDataTable();
                dt.TableName = "所得人資料";
                string path = txtFileName.Text + @"\補充保費申報_所得人資料_" + it.Key + ".csv";
                JBModule.Data.CNPOI.CreateCSVFile(dt, path);
                msg += path + Environment.NewLine;
                cc++;
            }
            MessageBox.Show("匯出完成：" + Environment.NewLine + msg);
        }

    }
}
