using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using JBHR.Sal.Core;
namespace JBHR.Att
{
    public partial class FRM2Q : JBControls.JBForm
    {
        public FRM2Q()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 設定這個值來控制當資料重複時，要選擇複寫或是略過
        /// </summary>
        bool RepeatOverWrite = true;
        string sno = "";
        private void FRM2P_Load(object sender, EventArgs e)
        {
            SystemFunction.SetComboBoxItems(ptxHcode, CodeFunction.GetHcode(), true);
            ptxHcode.Enabled = false;
            this.eXT_HCODETableAdapter.Fill(this.dsView.EXT_HCODE);
            this.aBS_EXTTableAdapter.FillByInit(this.dsAtt.ABS_EXT);
            //this.hCODETableAdapter.Fill(this.dsAtt.HCODE, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN);
            
            BasDataClassesDataContext db = new BasDataClassesDataContext();
            var u_prg = (from c in db.U_PRGID where c.USER_ID.Trim() == MainForm.USER_ID && c.PROG.Trim().ToLower() == this.Name.ToLower() select c).FirstOrDefault();
            if (u_prg != null)
            {
                fullDataCtrl1.bnAddEnable = u_prg.ADD_;
                fullDataCtrl1.bnEditEnable = u_prg.EDIT;
                fullDataCtrl1.bnDelEnable = u_prg.DELE;
                fullDataCtrl1.bnExportEnable = u_prg.PRINT_;
            }

            Sal.Function.SetAvaliableBase(this.dsBas.BASE);
           fullDataCtrl1.WhereCmd = Sal.Function.GetFilterCmd(this.Name);

            fullDataCtrl1.DataAdapter = this.aBS_EXTTableAdapter;
            fullDataCtrl1.Init_Ctrls();
        }

        private void fullDataCtrl1_AfterAdd(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            ptxNobr.Focus();
            DateTime d1 = new DateTime(DateTime.Now.Year, 1, 1);
            txtAdate.Text = Sal.Function.GetDate(d1);
            DateTime d2 = new DateTime(DateTime.Now.Year, 12, 31);
            txtDdate.Text = Sal.Function.GetDate(d2);

            //txtTolHrs.Enabled = false;
            checkBox2.Enabled = false;
        }

        private void fullDataCtrl1_AfterDel(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            if (!e.Error)
            {
                if (sno.Trim().Length != 0)
                {
                    dcAttDataContext db = new dcAttDataContext();
                    var sql = from a in db.ABS where a.SERNO == sno select a;
                    db.ABS.DeleteAllOnSubmit(sql);
                    db.SubmitChanges();
                }
                CDataLog.Save(this.Name, MainForm.USER_ID, DateTime.Now, fullDataCtrl1.BackupDataTable);
            }
        }

        private void fullDataCtrl1_AfterExport(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            DataView dv = ((sender as JBControls.FullDataCtrl).DataSource.DataSource as DataSet).Tables[(sender as JBControls.FullDataCtrl).DataSource.DataMember].DefaultView;
            dv.RowFilter = (sender as JBControls.FullDataCtrl).DataSource.Filter;

            JBModule.Data.CNPOI.RenderDataViewToExcel(dv, "C:\\TEMP\\" + this.Name + ".xls");
            System.Diagnostics.Process.Start("C:\\TEMP\\" + this.Name + ".xls");
        }

        private void fullDataCtrl1_AfterSave(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            if (!e.Error)
            {
                e.Values["AMT"] = JBModule.Data.CDecryp.Number(Convert.ToDecimal(txtAmt.Text));
                dsAtt.ABS_EXT.AcceptChanges();
                CDataLog.Save(this.Name, MainForm.USER_ID, DateTime.Now, fullDataCtrl1.BackupDataTable);
            }
        }

        private void fullDataCtrl1_BeforeDel(object sender, JBControls.FullDataCtrl.BeforeEventArgs e)
        {
            sno = "EXT" + Convert.ToInt32(e.Values["sno"]).ToString("0000000000");
            if (!Sal.Function.CanModify(ptxNobr.Text))
            {
                e.Cancel = true;
                MessageBox.Show(Resources.All.WorkadrErr, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void fullDataCtrl1_BeforeSave(object sender, JBControls.FullDataCtrl.BeforeEventArgs e)
        {
            if (!Sal.Function.CanModify(ptxNobr.Text))
            {
                e.Cancel = true;
                MessageBox.Show(Resources.All.WorkadrErr, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            if (!e.Cancel)
            {
                e.Values["KEY_MAN"] = MainForm.USER_NAME;
                e.Values["KEY_DATE"] = DateTime.Now;
                e.Values["AMT"] = JBModule.Data.CEncrypt.Number(Convert.ToDecimal(txtAmt.Text));
                e.Values["SYSCREAT"] = false;
            }
        }

        private void txtAdate_Validated(object sender, EventArgs e)
        {
            DateTime d1 = Convert.ToDateTime(txtAdate.Text);
            DateTime d2 = new DateTime(d1.Year, 12, 31);
            txtDdate.Text = Sal.Function.GetDate(d2);

            TimeSet();
        }

        private void txtEtime_Validated(object sender, EventArgs e)
        {
            TimeCalc();
        }
        void TimeCalc()
        {
            //if (ptxNobr.Text.Trim().Length > 0 && txtBtime.Text.Trim().Length > 0 && txtEtime.Text.Trim().Length > 0)
            //{
            //    DateTime d1;
            //    d1 = Convert.ToDateTime(txtAdate.Text);
            //    var calc = Dll.Att.AbsCal.AbsCalculation(ptxNobr.Text, cbxHcode.SelectedValue.ToString(), d1, d1, txtBtime.Text, txtEtime.Text, "");
            //    txtExtHrs.Text = calc.iTotalHour.ToString();
            //    txtTolHrs.Text = calc.iTotalHour.ToString();
            //}
        }

        private void ptxNobr_QueryCompleted(object sender, JBControls.PopupTextBox.QueryCompletedArgs e)
        {
            if (e.HasData)
            {
                //txtAdate.Focus();
                TimeCalc();
                TimeSet();
            }
        }

        private void cbxHcode_SelectedIndexChange(object sender, EventArgs e)
        {
            TimeCalc();
        }

        private void fullDataCtrl1_AfterEdit(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            //txtTolHrs.Enabled = false;
            checkBox2.Enabled = false;
        }

        void TimeSet()
        {
            //DateTime d1 = Convert.ToDateTime(txtAdate.Text);
            //dcAttDataContext db = new dcAttDataContext();
            //var sql = from a in db.ATTEND join r in db.ROTE on a.ROTE equals r.ROTE1 where a.NOBR == ptxNobr.Text && a.ADATE == d1 select r;
            //if (sql.Any())
            //{
            //    txtBtime.Text = sql.First().ON_TIME;
            //    txtEtime.Text = sql.First().OFF_TIME;
            //}
            //else
            //{
            //    txtBtime.Text = "0000";
            //    txtEtime.Text = "0000";
            //}
        }

        private void btnMultiOperation_Click(object sender, EventArgs e)
        {
            FRM2QA frm = new FRM2QA();
            frm.ShowDialog();
        }

        private void btnTrans_Click(object sender, EventArgs e)
        {
            DateTime t1, t2;
            t1 = DateTime.Now;
            int err_count = 0;
            var data = from r in dsAtt.ABS_EXT where r.PTRANS == false && r.NTRANS == true select r;
            dcAttDataContext dbTran = new dcAttDataContext();
            dcAttDataContext dbDelete = new dcAttDataContext();
            foreach (var row in data)
            {
                if (row.PTRANS) continue;//如果已經轉檔的話就略過
                try
                {
                    DateTime adate, ddate;
                    adate = new DateTime(row.DDATE.Year + 1, 1, 1);
                    ddate = new DateTime(row.DDATE.Year + 1, 12, 31);
                    var absSQL = from r in dbDelete.ABS
                                 where r.NOBR == row.NOBR
                                     && r.SERNO == "EXT" + row.SNO.ToString("0000000000")
                                 select r;
                    if (absSQL.Any())//如果有重複資料
                    {
                        if (RepeatOverWrite)//且設定重複要複寫，則刪除原紀錄
                            dbDelete.ABS.DeleteAllOnSubmit(absSQL);
                        else continue;//否則就略過此筆記錄
                    }
                    string hcode = "", hcode1 = "";
                    if (row.HCODE == "1")//特休
                    {
                        if (row.EXT_HOURS != 0)
                        {
                            hcode = "W1";
                            hcode1 = "W3";
                            ABS abs = new ABS();
                            abs.A_NAME = "";
                            abs.BDATE = adate;
                            abs.BTIME = "";
                            abs.EDATE = ddate;
                            abs.ETIME = "";
                            abs.H_CODE = hcode;
                            abs.KEY_DATE = DateTime.Now;
                            abs.KEY_MAN = MainForm.USER_NAME;
                            abs.NOBR = row.NOBR;
                            abs.NOTE = "";
                            abs.NOTEDIT = false;
                            abs.SERNO = "EXT" + row.SNO.ToString("0000000000");
                            abs.SYSCREATE = true;
                            abs.TOL_DAY = 0;
                            abs.TOL_HOURS = row.EXT_HOURS;
                            abs.YYMM = row.DDATE.Year.ToString();
                            dbTran.ABS.InsertOnSubmit(abs);

                            abs = new ABS();
                            abs.A_NAME = "";
                            abs.BDATE = row.ADATE;
                            abs.BTIME = "";
                            abs.EDATE = row.DDATE;
                            abs.ETIME = "";
                            abs.H_CODE = hcode1;
                            abs.KEY_DATE = DateTime.Now;
                            abs.KEY_MAN = MainForm.USER_NAME;
                            abs.NOBR = row.NOBR;
                            abs.NOTE = "";
                            abs.NOTEDIT = false;
                            abs.SERNO = "EXT" + row.SNO.ToString("0000000000");
                            abs.SYSCREATE = true;
                            abs.TOL_DAY = 0;
                            abs.TOL_HOURS = row.EXT_HOURS;
                            abs.YYMM = row.DDATE.Year.ToString();
                            dbTran.ABS.InsertOnSubmit(abs);
                        }
                        if (row.CASH_HOURS != 0)
                        {
                            hcode = "W4";//代金(減項)
                            ABS abs = new ABS();
                            abs.A_NAME = "";
                            abs.BDATE = row.ADATE;
                            abs.BTIME = "";
                            abs.EDATE = row.DDATE;
                            abs.ETIME = "";
                            abs.H_CODE = hcode;
                            abs.KEY_DATE = DateTime.Now;
                            abs.KEY_MAN = MainForm.USER_NAME;
                            abs.NOBR = row.NOBR;
                            abs.NOTE = "";
                            abs.NOTEDIT = false;
                            abs.SERNO = "EXT" + row.SNO.ToString("0000000000");
                            abs.SYSCREATE = true;
                            abs.TOL_DAY = 0;
                            abs.TOL_HOURS = row.CASH_HOURS;
                            abs.YYMM = row.DDATE.Year.ToString();
                            dbTran.ABS.InsertOnSubmit(abs);
                            //代金寫入補扣發
                            ENRICH enrich = new ENRICH();
                            enrich.AMT = JBModule.Data.CEncrypt.Number(row.AMT);
                            enrich.FA_IDNO = "";
                            enrich.IMPORT = true;
                            enrich.KEY_DATE = DateTime.Now;
                            enrich.KEY_MAN = MainForm.USER_NAME;
                            enrich.MEMO = "EXT" + row.SNO.ToString("0000000000");
                            enrich.NOBR = row.NOBR;
                            enrich.SAL_CODE = "H04";
                            enrich.YYMM = row.YYMM;
                            enrich.SEQ = row.SEQ;
                            dbTran.ENRICH.InsertOnSubmit(enrich);
                        }
                    }
                    if (row.HCODE == "3")//補休
                    {
                        if (row.EXT_HOURS != 0)
                        {
                            hcode = "W6";
                            hcode1 = "W8";
                            ABS abs = new ABS();
                            abs.A_NAME = "";
                            abs.BDATE = adate;
                            abs.BTIME = "";
                            abs.EDATE = ddate;
                            abs.ETIME = "";
                            abs.H_CODE = hcode;
                            abs.KEY_DATE = DateTime.Now;
                            abs.KEY_MAN = MainForm.USER_NAME;
                            abs.NOBR = row.NOBR;
                            abs.NOTE = "";
                            abs.NOTEDIT = false;
                            abs.SERNO = "EXT" + row.SNO.ToString("0000000000");
                            abs.SYSCREATE = true;
                            abs.TOL_DAY = 0;
                            abs.TOL_HOURS = row.EXT_HOURS;
                            abs.YYMM = row.DDATE.Year.ToString();
                            dbTran.ABS.InsertOnSubmit(abs);
                            //補休失效
                            abs = new ABS();
                            abs.A_NAME = "";
                            abs.BDATE = row.ADATE;
                            abs.BTIME = "";
                            abs.EDATE = row.DDATE;
                            abs.ETIME = "";
                            abs.H_CODE = hcode1;
                            abs.KEY_DATE = DateTime.Now;
                            abs.KEY_MAN = MainForm.USER_NAME;
                            abs.NOBR = row.NOBR;
                            abs.NOTE = "";
                            abs.NOTEDIT = false;
                            abs.SERNO = "EXT" + row.SNO.ToString("0000000000");
                            abs.SYSCREATE = true;
                            abs.TOL_DAY = 0;
                            abs.TOL_HOURS = row.EXT_HOURS;
                            abs.YYMM = row.DDATE.Year.ToString();
                            dbTran.ABS.InsertOnSubmit(abs);
                        }
                        if (row.CASH_HOURS != 0)
                        {
                            hcode = "W7";
                            ABS abs = new ABS();
                            abs.A_NAME = "";
                            abs.BDATE = row.ADATE;
                            abs.BTIME = "";
                            abs.EDATE = row.DDATE;
                            abs.ETIME = "";
                            abs.H_CODE = hcode;
                            abs.KEY_DATE = DateTime.Now;
                            abs.KEY_MAN = MainForm.USER_NAME;
                            abs.NOBR = row.NOBR;
                            abs.NOTE = "";
                            abs.NOTEDIT = false;
                            abs.SERNO = "EXT" + row.SNO.ToString("0000000000");
                            abs.SYSCREATE = true;
                            abs.TOL_DAY = 0;
                            abs.TOL_HOURS = row.CASH_HOURS;
                            abs.YYMM = row.DDATE.Year.ToString();
                            dbTran.ABS.InsertOnSubmit(abs);
                            //代金寫入補扣發
                            ENRICH enrich = new ENRICH();
                            enrich.AMT = JBModule.Data.CEncrypt.Number(row.AMT);
                            enrich.FA_IDNO = "";
                            enrich.IMPORT = true;
                            enrich.KEY_DATE = DateTime.Now;
                            enrich.KEY_MAN = MainForm.USER_NAME;
                            enrich.MEMO = "EXT" + row.SNO.ToString("0000000000");
                            enrich.NOBR = row.NOBR;
                            enrich.SAL_CODE = "H04";
                            enrich.YYMM = row.YYMM;
                            enrich.SEQ = row.SEQ;
                            dbTran.ENRICH.InsertOnSubmit(enrich);
                        }
                    }
                    //先刪除，後先增
                    dbDelete.SubmitChanges();
                    dbTran.SubmitChanges();
                    //再異動
                    row.PTRANS = true;
                    aBS_EXTTableAdapter.Update(dsAtt.ABS_EXT);
                }
                catch
                {
                    err_count++;
                    continue;
                }

            }


            t2 = DateTime.Now;
            TimeSpan ts = t2 - t1;
            string msg = string.Format(Resources.Sal.TimeSpan, ts.Minutes, ts.Seconds);
            if (err_count == 0)
                MessageBox.Show(msg, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            else MessageBox.Show("轉換時發生" + err_count.ToString() + "筆錯誤", Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void fullDataCtrl1_AfterQuery(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            DataBidn();
        }
        void DataBidn()
        {
            foreach (var itm in this.dsAtt.ABS_EXT)
            {
                itm.AMT = JBModule.Data.CDecryp.Number(itm.AMT);
            }
            this.dsAtt.ABS_EXT.AcceptChanges();
        }

        private void fullDataCtrl1_AfterShow(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            DataBidn();
        }
    }
}
