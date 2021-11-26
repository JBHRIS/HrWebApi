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
    public partial class FRM3B : JBControls.JBForm
    {
        public FRM3B()
        {
            InitializeComponent();
        }
        string YEAR = "", y1, y2;
        private void FRM3B_Load(object sender, EventArgs e)
        {
            Sal.Function.SetAvaliableVBase(this.insDS.V_BASE);
            this.fAMILYTableAdapter.Fill(this.basDS.FAMILY);
            this.yRINSURTableAdapter.FillByInit(this.insDS.YRINSUR);
            //foreach (var itm in this.basDS.FAMILY) if (itm.FA_IDNO != null && itm.FA_IDNO.Trim().Length == 0) itm.Delete();
            //this.basDS.FAMILY.AcceptChanges();
            //foreach (var row in this.insDS.YRINSUR)
            //{
            //    row.REL_LAB = JBModule.Data.CDecryp.Number(row.REL_LAB);
            //    row.REL_HEL = JBModule.Data.CDecryp.Number(row.REL_HEL);
            //    row.REL_GRP = JBModule.Data.CDecryp.Number(row.REL_GRP);
            //}
            //this.insDS.INSLAB.AcceptChanges();

            //filterData();
            fullDataCtrl1.WhereCmd = Sal.Function.GetFilterCmd("YRINSUR");
            fullDataCtrl1.DataAdapter = yRINSURTableAdapter;
            fullDataCtrl1.Init_Ctrls();
        }

        private void fullDataCtrl1_AfterDel(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            if (!e.Error)
            {
                CDataLog.Save(this.Name, MainForm.USER_NAME, DateTime.Now, fullDataCtrl1.BackupDataTable);
            }
        }

        private void fullDataCtrl1_BeforeSave(object sender, JBControls.FullDataCtrl.BeforeEventArgs e)
        {
            if (!checkSavePower(e.Values["nobr"].ToString()))
            {
                e.Cancel = true;
                MessageBox.Show(Resources.All.WorkadrErr, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!e.Cancel)
            {
                e.Values["REL_LAB"] = JBModule.Data.CEncrypt.Number(Convert.ToDecimal(e.Values["REL_LAB"]));
                e.Values["REL_HEL"] = JBModule.Data.CEncrypt.Number(Convert.ToDecimal(e.Values["REL_HEL"]));
                e.Values["REL_GRP"] = JBModule.Data.CEncrypt.Number(Convert.ToDecimal(e.Values["REL_GRP"]));
                e.Values["key_man"] = MainForm.USER_NAME;
                e.Values["key_date"] = DateTime.Now;
            }
        }

        private void fullDataCtrl1_AfterSave(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            if (!e.Error)
            {
                CDataLog.Save(this.Name, MainForm.USER_NAME, DateTime.Now, fullDataCtrl1.BackupDataTable);

                e.Values["REL_LAB"] = JBModule.Data.CDecryp.Number(Convert.ToDecimal(e.Values["REL_LAB"]));
                e.Values["REL_HEL"] = JBModule.Data.CDecryp.Number(Convert.ToDecimal(e.Values["REL_HEL"]));
                e.Values["REL_GRP"] = JBModule.Data.CDecryp.Number(Convert.ToDecimal(e.Values["REL_GRP"]));
            }

            panelImport.Enabled = true;
        }

        private void fullDataCtrl1_AfterExport(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            DataView dv = ((sender as JBControls.FullDataCtrl).DataSource.DataSource as DataSet).Tables[(sender as JBControls.FullDataCtrl).DataSource.DataMember].DefaultView;
            dv.RowFilter = (sender as JBControls.FullDataCtrl).DataSource.Filter;

            JBModule.Data.CNPOI.RenderDataViewToExcel(dv, "C:\\TEMP\\" + this.Name + ".xls");
            System.Diagnostics.Process.Start("C:\\TEMP\\" + this.Name + ".xls");
        }

        private void popupTextBox1_Leave(object sender, EventArgs e)
        {
            if (popupTextBox1.Text.Trim().Length > 0)
            {
                popupTextBox2.WhereCmd = "nobr = '" + popupTextBox1.Text + "'";
            }
            else popupTextBox2.WhereCmd = "";
        }

        private void filterData()
        {

        }

        private bool checkSavePower(string nobr)
        {
            return Sal.Function.CanModify(nobr);
        }

        private void fullDataCtrl1_AfterQuery(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            foreach (var row in this.insDS.YRINSUR)
            {
                row.REL_LAB = JBModule.Data.CDecryp.Number(row.REL_LAB);
                row.REL_HEL = JBModule.Data.CDecryp.Number(row.REL_HEL);
                row.REL_GRP = JBModule.Data.CDecryp.Number(row.REL_GRP);
                row.REL_SUP = JBModule.Data.CDecryp.Number(row.REL_SUP);
            }
            this.insDS.INSLAB.AcceptChanges();

            filterData();

        }

        private void fullDataCtrl1_AfterShow(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            foreach (var row in this.insDS.YRINSUR)
            {
                row.REL_LAB = JBModule.Data.CDecryp.Number(row.REL_LAB);
                row.REL_HEL = JBModule.Data.CDecryp.Number(row.REL_HEL);
                row.REL_GRP = JBModule.Data.CDecryp.Number(row.REL_GRP);
                row.REL_SUP = JBModule.Data.CDecryp.Number(row.REL_SUP);
            }
            this.insDS.INSLAB.AcceptChanges();

            filterData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBoxY1.Text.Trim().Length == 0)
            {
                MessageBox.Show(Resources.Ins.YYMMB_ReqErr, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (textBoxY2.Text.Trim().Length == 0)
            {
                MessageBox.Show(Resources.Ins.YYMME_ReqErr, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (textBoxYY.Text.Trim().Length == 0)
            {
                MessageBox.Show(Resources.Ins.YYReqErr, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show(Resources.Ins.YYConfirm, Resources.All.DialogTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                button1.Enabled = false;
                YEAR = textBoxYY.Text;
                y1 = textBoxY1.Text;
                y2 = textBoxY2.Text;
                this.insDS.YRINSUR.Clear();
                yRINSURBindingSource.SuspendBinding();
                //backgroundWorker1.RunWorkerAsync();


                InsDataClassesDataContext db = new InsDataClassesDataContext();
                //var SYS4 = (from c in db.U_SYS4 select c).FirstOrDefault();
                //var SYS5 = (from c in db.U_SYS5 select c).FirstOrDefault();
                //var SYS6 = (from c in db.U_SYS6 select c).FirstOrDefault();

                string l_code = null;
                string h_code = null;
                string g_code = null;
                string s_code = null;
                l_code = MainForm.LabConfig.LSALCODE.Trim();
                h_code = MainForm.HealthConfig.HSALCODE.Trim();
                g_code = MainForm.GroupInsConfig.GROUPSALCD.Trim();
                s_code = MainForm.HealthConfig.SUPPLEHINSLABSALCODE.Trim();

                if (l_code != null && h_code != null && g_code != null)
                {
                    var waged = from c in db.EXPLAB
                                where c.YYMM.CompareTo(y1) >= 0 && c.YYMM.CompareTo(y2) <= 0 &&
                                (c.SAL_CODE.Trim() == l_code || c.SAL_CODE == h_code || c.SAL_CODE == g_code)
                                    && (from d in db.WAGE where c.NOBR == d.NOBR && c.YYMM == d.YYMM select 1).Any()
                                && MainForm.WriteRules.Select(p => p.DATAGROUP).Contains(c.SALADR)
                                orderby c.NOBR, c.FA_IDNO, c.SAL_CODE
                                select new YrInsurClass { NOBR = c.NOBR, FA_IDNO = c.FA_IDNO, SAL_CODE = c.SAL_CODE, AMT = JBModule.Data.CDecryp.Number(c.EXP), SALADR = c.SALADR, YYMM = c.YYMM };
                    var enrich = from c in db.ENRICH
                                 join d in db.WAGED on new { c.NOBR, c.YYMM, c.SEQ, c.SAL_CODE } equals new { d.NOBR, d.YYMM, d.SEQ, d.SAL_CODE }
                                 join f in db.WAGE on new { d.NOBR, d.YYMM, d.SEQ } equals new { f.NOBR, f.YYMM, f.SEQ }
                                 where d.YYMM.CompareTo(y1) >= 0 && d.YYMM.CompareTo(y2) <= 0 &&
                                 (c.SAL_CODE.Trim() == l_code || c.SAL_CODE == h_code || c.SAL_CODE == g_code || c.SAL_CODE == s_code)
                                && MainForm.WriteRules.Select(p => p.DATAGROUP).Contains(f.SALADR)
                                 //&& db.GetFilterByNobr(c.NOBR, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value
                                 orderby c.NOBR, c.FA_IDNO, c.SAL_CODE
                                 select new YrInsurClass { NOBR = c.NOBR, FA_IDNO = c.FA_IDNO, SAL_CODE = c.SAL_CODE, AMT = JBModule.Data.CDecryp.Number(c.AMT), SALADR = f.SALADR, YYMM = c.YYMM };
                    var expsup = from c in db.EXPSUP
                                 join f in db.WAGE on new { c.NOBR, c.YYMM, c.SEQ } equals new { f.NOBR, f.YYMM, f.SEQ }
                                 where c.YYMM.CompareTo(y1) >= 0 && c.YYMM.CompareTo(y2) <= 0
                                 && MainForm.WriteRules.Select(p => p.DATAGROUP).Contains(c.SALADR)
                                 orderby c.NOBR, c.SAL_CODE
                                 select new YrInsurClass { NOBR = c.NOBR, FA_IDNO = "", SAL_CODE = c.SAL_CODE, AMT = JBModule.Data.CDecryp.Number(c.SUP_AMT), SALADR = c.SALADR, YYMM = c.YYMM };

                    //foreach (var c in waged) c.AMT = JBModule.Data.CDecryp.Number(c.AMT);
                    //foreach (var c in enrich) c.AMT = JBModule.Data.CDecryp.Number(c.AMT);
                    //foreach (var c in expsup) c.AMT = JBModule.Data.CDecryp.Number(c.AMT);

                    backgroundWorker1.ReportProgress(15);

                    var wagedGroup = from c in waged.ToArray()
                                     group c by new { NOBR = c.NOBR.Trim(), FA_IDNO = c.FA_IDNO.Trim(), SAL_CODE = c.SAL_CODE.Trim() } into g1
                                     //from g in g1
                                     select new
                                     {
                                         NOBR = g1.Key.NOBR,
                                         FA_IDNO = g1.Key.FA_IDNO,
                                         SAL_CODE = g1.Key.SAL_CODE,
                                         AMT = g1.Sum(r => r.AMT),
                                         SALADR = g1.First().SALADR
                                     };
                    var enrichGroup = from c in enrich.ToArray()
                                      group c by new { NOBR = c.NOBR.Trim(), FA_IDNO = c.FA_IDNO.Trim(), SAL_CODE = c.SAL_CODE.Trim() } into g1
                                      //from g in g1
                                      select new
                                      {
                                          NOBR = g1.Key.NOBR,
                                          FA_IDNO = g1.Key.FA_IDNO,
                                          SAL_CODE = g1.Key.SAL_CODE,
                                          AMT = g1.Sum(r => r.AMT),
                                          SALADR = g1.First().SALADR
                                      };
                    var expsupGroup = from c in expsup.ToArray()
                                      group c by new { NOBR = c.NOBR.Trim(), FA_IDNO = "", SAL_CODE = c.SAL_CODE.Trim() } into g1
                                      //from g in g1
                                      select new
                                      {
                                          NOBR = g1.Key.NOBR,
                                          FA_IDNO = g1.Key.FA_IDNO,
                                          SAL_CODE = g1.Key.SAL_CODE,
                                          AMT = g1.Sum(r => r.AMT)
                                      };
                    var yrinsur = from a in db.YRINSUR where a.YEAR == YEAR && MainForm.WriteRules.Select(p => p.DATAGROUP).Contains(a.SALADR) select a;
                    db.YRINSUR.DeleteAllOnSubmit(yrinsur);
                    db.SubmitChanges();
                    //yRINSURTableAdapter.Update(this.insDS.YRINSUR);
                    backgroundWorker1.ReportProgress(50);

                    foreach (var c in wagedGroup)
                    {
                        InsDS.YRINSURRow row = (from a in this.insDS.YRINSUR
                                                where a.YEAR == textBoxYY.Text
                                                && a.NOBR == c.NOBR && a.FA_IDNO == c.FA_IDNO
                                                && MainForm.WriteRules.Select(p => p.DATAGROUP).Contains(a.SALADR)
                                                select a).FirstOrDefault();
                        bool isNewRow = false;
                        if (row == null)
                        {
                            isNewRow = true;
                            row = this.insDS.YRINSUR.NewYRINSURRow();
                        }
                        row.YEAR = textBoxYY.Text;
                        row.NOBR = c.NOBR;
                        row.FA_IDNO = c.FA_IDNO;
                        if (row.IsNull("REL_LAB")) row.REL_LAB = 0;
                        if (row.IsNull("REL_HEL")) row.REL_HEL = 0;
                        if (row.IsNull("REL_GRP")) row.REL_GRP = 0;
                        if (row.IsNull("REL_SUP")) row.REL_SUP = 0;
                        if (c.SAL_CODE == l_code) row.REL_LAB = c.AMT;
                        if (c.SAL_CODE == h_code) row.REL_HEL = c.AMT;
                        if (c.SAL_CODE == g_code) row.REL_GRP = c.AMT;
                        if (c.SAL_CODE == s_code) row.REL_SUP = c.AMT;
                        row.EQUAL = false;
                        row.SALADR = c.SALADR;
                        row.KEY_DATE = DateTime.Now;
                        row.KEY_MAN = MainForm.USER_NAME;
                        if (isNewRow) this.insDS.YRINSUR.AddYRINSURRow(row);
                    }
                    backgroundWorker1.ReportProgress(60);

                    foreach (var c in enrichGroup)
                    {
                        InsDS.YRINSURRow row = (from a in this.insDS.YRINSUR
                                                where a.YEAR == textBoxYY.Text
                                                && a.NOBR == c.NOBR && a.FA_IDNO == c.FA_IDNO
                                                && MainForm.WriteRules.Select(p => p.DATAGROUP).Contains(a.SALADR)
                                                select a).FirstOrDefault();

                        bool isNewRow = false;
                        if (row == null)
                        {
                            isNewRow = true;
                            row = this.insDS.YRINSUR.NewYRINSURRow();
                        }
                        row.YEAR = textBoxYY.Text;
                        row.NOBR = c.NOBR;
                        row.FA_IDNO = c.FA_IDNO;
                        if (row.IsNull("REL_LAB")) row.REL_LAB = 0;
                        if (row.IsNull("REL_HEL")) row.REL_HEL = 0;
                        if (row.IsNull("REL_GRP")) row.REL_GRP = 0;
                        if (row.IsNull("REL_SUP")) row.REL_SUP = 0;
                        if (c.SAL_CODE == l_code) row.REL_LAB += c.AMT;
                        if (c.SAL_CODE == h_code) row.REL_HEL += c.AMT;
                        if (c.SAL_CODE == g_code) row.REL_GRP += c.AMT;
                        if (c.SAL_CODE == s_code) row.REL_SUP += c.AMT;
                        row.EQUAL = false;
                        row.SALADR = c.SALADR;
                        row.KEY_DATE = DateTime.Now;
                        row.KEY_MAN = MainForm.USER_NAME;
                        if (isNewRow) this.insDS.YRINSUR.AddYRINSURRow(row);
                    }
                    foreach (var c in expsup)
                    {
                        InsDS.YRINSURRow row = (from a in this.insDS.YRINSUR
                                                where a.YEAR == textBoxYY.Text
                                                && a.NOBR == c.NOBR && a.FA_IDNO == c.FA_IDNO
                                                && MainForm.WriteRules.Select(p => p.DATAGROUP).Contains(a.SALADR)
                                                select a).FirstOrDefault();
                        bool isNewRow = false;
                        if (row == null)
                        {
                            isNewRow = true;
                            row = this.insDS.YRINSUR.NewYRINSURRow();
                        }
                        row.YEAR = textBoxYY.Text;
                        row.NOBR = c.NOBR;
                        row.FA_IDNO = "";
                        if (row.IsNull("REL_LAB")) row.REL_LAB = 0;
                        if (row.IsNull("REL_HEL")) row.REL_HEL = 0;
                        if (row.IsNull("REL_GRP")) row.REL_GRP = 0;
                        if (row.IsNull("REL_SUP")) row.REL_SUP = 0;
                        row.REL_SUP += c.AMT;
                        row.SALADR = c.SALADR;
                        row.EQUAL = false;
                        row.KEY_DATE = DateTime.Now;
                        row.KEY_MAN = MainForm.USER_NAME;
                        if (isNewRow) this.insDS.YRINSUR.AddYRINSURRow(row);
                    }

                    //foreach (var row in this.insDS.YRINSUR)
                    //{
                    //    var datas = (from c in enrich
                    //                 where c.NOBR == row.NOBR && c.FA_IDNO == row.FA_IDNO
                    //                 select c);//.FirstOrDefault();
                    //    foreach (var data in datas)
                    //    {
                    //        if (data.SAL_CODE == l_code) row.REL_LAB += data.AMT;
                    //        if (data.SAL_CODE == h_code) row.REL_HEL += data.AMT;
                    //        if (data.SAL_CODE == g_code) row.REL_GRP += data.AMT;
                    //    }
                    //}
                    backgroundWorker1.ReportProgress(70);
                    foreach (var row in this.insDS.YRINSUR)//加密寫回
                    {
                        row.REL_LAB = JBModule.Data.CEncrypt.Number(row.REL_LAB);
                        row.REL_HEL = JBModule.Data.CEncrypt.Number(row.REL_HEL);
                        row.REL_GRP = JBModule.Data.CEncrypt.Number(row.REL_GRP);
                        row.REL_SUP = JBModule.Data.CEncrypt.Number(row.REL_SUP);
                    }
                    backgroundWorker1.ReportProgress(80);
                    yRINSURTableAdapter.Update(this.insDS.YRINSUR);
                    backgroundWorker1.ReportProgress(90);
                    foreach (var row in this.insDS.YRINSUR)//解密顯示
                    {
                        row.REL_LAB = JBModule.Data.CDecryp.Number(row.REL_LAB);
                        row.REL_HEL = JBModule.Data.CDecryp.Number(row.REL_HEL);
                        row.REL_GRP = JBModule.Data.CDecryp.Number(row.REL_GRP);
                        row.REL_SUP = JBModule.Data.CDecryp.Number(row.REL_SUP);
                    }
                    backgroundWorker1.ReportProgress(100);
                    this.insDS.AcceptChanges();
                    yRINSURBindingSource.ResumeBinding();
                    button1.Enabled = true;
                }
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            InsDataClassesDataContext db = new InsDataClassesDataContext();
            //var SYS4 = (from c in db.U_SYS4 select c).FirstOrDefault();
            //var SYS5 = (from c in db.U_SYS5 select c).FirstOrDefault();
            //var SYS6 = (from c in db.U_SYS6 select c).FirstOrDefault();

            string l_code = null;
            string h_code = null;
            string g_code = null;
            l_code = MainForm.LabConfig.LSALCODE.Trim();
            h_code = MainForm.HealthConfig.HSALCODE.Trim();
            g_code = MainForm.GroupInsConfig.GROUPSALCD.Trim();

            if (l_code != null && h_code != null && g_code != null)
            {
                var waged = from c in db.EXPLAB
                            where c.YYMM.CompareTo(y1) >= 0 && c.YYMM.CompareTo(y2) <= 0 &&
                            (c.SAL_CODE.Trim() == l_code || c.SAL_CODE == h_code || c.SAL_CODE == g_code)
                            //&& db.GetFilterByNobr(c.NOBR, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value
                            && (from bts in db.BASETTS
                                where bts.NOBR == c.NOBR
                                && DateTime.Now.Date >= bts.ADATE && DateTime.Now.Date <= bts.DDATE
                                && (from urdg in db.UserReadDataGroupList(MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN) select urdg.DATAGROUP).Contains(bts.SALADR)
                                select 1).Any()
                            orderby c.NOBR, c.FA_IDNO, c.SAL_CODE
                            select c;
                var enrich = from c in db.ENRICH
                             where c.YYMM.CompareTo(y1) >= 0 && c.YYMM.CompareTo(y2) <= 0 &&
                             (c.SAL_CODE.Trim() == l_code || c.SAL_CODE == h_code || c.SAL_CODE == g_code)
                             //&& db.GetFilterByNobr(c.NOBR, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value
                             && (from bts in db.BASETTS
                                 where bts.NOBR == c.NOBR
                                 && DateTime.Now.Date >= bts.ADATE && DateTime.Now.Date <= bts.DDATE
                                 && (from urdg in db.UserReadDataGroupList(MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN) select urdg.DATAGROUP).Contains(bts.SALADR)
                                 select 1).Any()
                             orderby c.NOBR, c.FA_IDNO, c.SAL_CODE
                             select c;

                foreach (var c in waged) c.EXP = JBModule.Data.CDecryp.Number(c.EXP);
                foreach (var c in enrich) c.AMT = JBModule.Data.CDecryp.Number(c.AMT);

                backgroundWorker1.ReportProgress(15);

                var wagedGroup = from c in waged.ToArray()
                                 group c by new { NOBR = c.NOBR.Trim(), FA_IDNO = c.FA_IDNO.Trim(), SAL_CODE = c.SAL_CODE.Trim() } into g1
                                 from g in g1
                                 select new
                                 {
                                     NOBR = g1.Key.NOBR,
                                     FA_IDNO = g1.Key.FA_IDNO,
                                     SAL_CODE = g1.Key.SAL_CODE,
                                     AMT = g1.Sum(r => r.EXP)
                                 };
                var enrichGroup = from c in enrich.ToArray()
                                  group c by new { NOBR = c.NOBR.Trim(), FA_IDNO = c.FA_IDNO.Trim(), SAL_CODE = c.SAL_CODE.Trim() } into g1
                                  from g in g1
                                  select new
                                  {
                                      NOBR = g1.Key.NOBR,
                                      FA_IDNO = g1.Key.FA_IDNO,
                                      SAL_CODE = g1.Key.SAL_CODE,
                                      AMT = g1.Sum(r => r.AMT)
                                  };

                //this.yRINSURTableAdapter.FillByYEAR(this.insDS.YRINSUR, YEAR);
                foreach (var r in this.insDS.YRINSUR) r.Delete();
                yRINSURTableAdapter.Update(this.insDS.YRINSUR);
                backgroundWorker1.ReportProgress(50);

                foreach (var c in wagedGroup)
                {
                    InsDS.YRINSURRow row = (from a in this.insDS.YRINSUR
                                            where a.YEAR == textBoxYY.Text
                                            && a.NOBR == c.NOBR && a.FA_IDNO == c.FA_IDNO
                                            && MainForm.WriteRules.Select(p => p.DATAGROUP).Contains(a.SALADR)
                                            select a).FirstOrDefault();
                    bool isNewRow = false;
                    if (row == null)
                    {
                        isNewRow = true;
                        row = this.insDS.YRINSUR.NewYRINSURRow();
                    }
                    row.YEAR = textBoxYY.Text;
                    row.NOBR = c.NOBR;
                    row.FA_IDNO = c.FA_IDNO;
                    if (row.IsNull("REL_LAB")) row.REL_LAB = 0;
                    if (row.IsNull("REL_HEL")) row.REL_HEL = 0;
                    if (row.IsNull("REL_GRP")) row.REL_GRP = 0;
                    if (c.SAL_CODE == l_code) row.REL_LAB = c.AMT;
                    if (c.SAL_CODE == h_code) row.REL_HEL = c.AMT;
                    if (c.SAL_CODE == g_code) row.REL_GRP = c.AMT;
                    row.EQUAL = false;
                    row.KEY_DATE = DateTime.Now;
                    row.KEY_MAN = MainForm.USER_NAME;
                    if (isNewRow) this.insDS.YRINSUR.AddYRINSURRow(row);
                }
                backgroundWorker1.ReportProgress(60);
                foreach (var row in this.insDS.YRINSUR)
                {
                    var data = (from c in enrich
                                where c.NOBR == row.NOBR && c.FA_IDNO == row.FA_IDNO
                                select c).FirstOrDefault();
                    if (data != null)
                    {
                        if (data.SAL_CODE == l_code) row.REL_LAB += data.AMT;
                        if (data.SAL_CODE == h_code) row.REL_HEL += data.AMT;
                        if (data.SAL_CODE == g_code) row.REL_GRP += data.AMT;
                    }
                }
                backgroundWorker1.ReportProgress(70);
                foreach (var row in this.insDS.YRINSUR)
                {
                    row.REL_LAB = JBModule.Data.CEncrypt.Number(row.REL_LAB);
                    row.REL_HEL = JBModule.Data.CEncrypt.Number(row.REL_HEL);
                    row.REL_GRP = JBModule.Data.CEncrypt.Number(row.REL_GRP);
                }
                backgroundWorker1.ReportProgress(80);
                yRINSURTableAdapter.Update(this.insDS.YRINSUR);
                backgroundWorker1.ReportProgress(90);
                foreach (var row in this.insDS.YRINSUR)
                {
                    row.REL_LAB = JBModule.Data.CDecryp.Number(row.REL_LAB);
                    row.REL_HEL = JBModule.Data.CDecryp.Number(row.REL_HEL);
                    row.REL_GRP = JBModule.Data.CDecryp.Number(row.REL_GRP);
                }
                backgroundWorker1.ReportProgress(100);
                this.insDS.AcceptChanges();
            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show(Resources.Ins.WorkCompleted, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.None);
            yRINSURBindingSource.ResumeBinding();
            button1.Enabled = true;
        }

        private void fullDataCtrl1_AfterAdd(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            panelImport.Enabled = false;
        }

        private void fullDataCtrl1_AfterEdit(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            panelImport.Enabled = false;
        }

        private void fullDataCtrl1_AfterCancel(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            panelImport.Enabled = true;
        }
    }
    public class YrInsurClass
    {
        public string NOBR;
        public string FA_IDNO;
        public string YYMM;
        public string SAL_CODE;
        public string SALADR;
        public decimal AMT;
    }
}
