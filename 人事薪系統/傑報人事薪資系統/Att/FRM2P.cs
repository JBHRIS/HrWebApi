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
    public partial class FRM2P : JBControls.JBForm
    {
        public FRM2P()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 設定這個值來控制當資料重複時，要選擇複寫或是略過
        /// </summary>
        bool RepeatOverWrite = true;

        private void FRM2P_Load(object sender, EventArgs e)
        {
            SystemFunction.SetComboBoxItems(cbxHcode, CodeFunction.GetHcode(), true, false, true);
            cbxHcode.Enabled = false;
            //this.hCODETableAdapter.Fill(this.dsAtt.HCODE, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN);
            this.aBSPRETableAdapter.FillByInit(this.dsAtt.ABSPRE);
            Sal.Function.SetAvaliableBase(this.dsBas.BASE);

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

            fullDataCtrl1.DataAdapter = this.aBSPRETableAdapter;
            fullDataCtrl1.Init_Ctrls();
        }

        private void fullDataCtrl1_AfterAdd(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            ptxNobr.Focus();
            txtAdate.Text = Sal.Function.GetDate();
            DateTime d1 = Convert.ToDateTime(txtAdate.Text);
            SalaryDate sd = new SalaryDate(d1);
            txtYymm.Text = sd.YYMM;

            txtSugHrs.Enabled = false;
        }

        private void fullDataCtrl1_AfterDel(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            CDataLog.Save(this.Name, MainForm.USER_ID, DateTime.Now, fullDataCtrl1.BackupDataTable);
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
                CDataLog.Save(this.Name, MainForm.USER_ID, DateTime.Now, fullDataCtrl1.BackupDataTable);
        }

        private void fullDataCtrl1_BeforeDel(object sender, JBControls.FullDataCtrl.BeforeEventArgs e)
        {
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
            }
        }

        private void txtAdate_Validated(object sender, EventArgs e)
        {
            DateTime d1 = Convert.ToDateTime(txtAdate.Text);
            SalaryDate sd = new SalaryDate(d1);
            txtYymm.Text = sd.YYMM;

            TimeSet();
        }

        private void txtEtime_Validated(object sender, EventArgs e)
        {
            TimeCalc();
        }
        void TimeCalc()
        {
            if (ptxNobr.Text.Trim().Length > 0 && txtBtime.Text.Trim().Length > 0 && txtEtime.Text.Trim().Length > 0)
            {
                DateTime d1;
                d1 = Convert.ToDateTime(txtAdate.Text);
                var calc = Dll.Att.AbsCal.AbsCalculation(ptxNobr.Text, cbxHcode.SelectedValue.ToString(), d1, d1, txtBtime.Text, txtEtime.Text, "");
                txtAbsHrs.Text = calc.iTotalHour.ToString();
                txtSugHrs.Text = calc.iTotalHour.ToString();
            }
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
            txtSugHrs.Enabled = false;
        }

        void TimeSet()
        {
            DateTime d1 = Convert.ToDateTime(txtAdate.Text);
            dcAttDataContext db = new dcAttDataContext();
            var sql = from a in db.ATTEND join r in db.ROTE on a.ROTE equals r.ROTE1 where a.NOBR == ptxNobr.Text && a.ADATE == d1 select r;
            if (sql.Any())
            {
                txtBtime.Text = sql.First().ON_TIME;
                txtEtime.Text = sql.First().OFF_TIME;
            }
            else
            {
                txtBtime.Text = "0000";
                txtEtime.Text = "0000";
            }
        }

        private void btnMultiOperation_Click(object sender, EventArgs e)
        {
            FRM2PBA frm = new FRM2PBA();
            frm.ShowDialog();
        }

        private void btnTrans_Click(object sender, EventArgs e)
        {
            DateTime t1, t2;
            t1 = DateTime.Now;

            var data = from r in dsAtt.ABSPRE where r.TRANS == false select r;
            dcAttDataContext dbTran = new dcAttDataContext();
            dcAttDataContext dbDelete = new dcAttDataContext();
            foreach (var row in data)
            {
                var absSQL = from r in dbDelete.ABS where r.NOBR == row.NOBR && r.BDATE == row.ADATE && r.BTIME == row.BTIME select r;
                if (absSQL.Any())//如果有重複資料
                {
                    if (RepeatOverWrite)//且設定重複要複寫，則刪除原紀錄
                        dbDelete.ABS.DeleteAllOnSubmit(absSQL);
                    else continue;//否則就略過此筆記錄
                }

                ABS abs = new ABS();
                abs.A_NAME = "";
                abs.BDATE = row.ADATE;
                abs.BTIME = row.BTIME;
                abs.EDATE = row.ADATE;
                abs.ETIME = row.ETIME;
                abs.H_CODE = row.H_CODE;
                abs.KEY_DATE = DateTime.Now;
                abs.KEY_MAN = MainForm.USER_NAME;
                abs.NOBR = row.NOBR;
                abs.NOTE = "";
                abs.NOTEDIT = false;
                abs.SERNO = "";
                abs.SYSCREATE = true;
                abs.TOL_DAY = 0;
                abs.TOL_HOURS = row.ABS_HRS;
                abs.YYMM = row.YYMM;
                abs.LeaveHours = 0;
                abs.Balance = abs.TOL_HOURS;
                dbTran.ABS.InsertOnSubmit(abs);
                row.TRANS = true;
            }
            //先刪除，後先增
            dbDelete.SubmitChanges();
            dbTran.SubmitChanges();
            //再異動
            aBSPRETableAdapter.Update(dsAtt.ABSPRE);

            t2 = DateTime.Now;
            TimeSpan ts = t2 - t1;
            string msg = string.Format(Resources.Sal.TimeSpan, ts.Minutes, ts.Seconds);
            MessageBox.Show(msg, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

        }
    }
}
