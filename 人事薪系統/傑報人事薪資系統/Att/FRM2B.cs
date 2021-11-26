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
    public partial class FRM2B : JBControls.JBForm
    {
        public FRM2B()
        {
            InitializeComponent();
        }
        dcAttDataContext db = new dcAttDataContext();
        private string guid;
        bool IsNew = false;
        string sno = "";
        private void FRM2B_Load(object sender, EventArgs e)
        {
            SystemFunction.SetComboBoxItems(cbxDepts, CodeFunction.GetDepts(), true, false, true);
            txtSerno.Enabled = false;
            //cbxDepts.Enabled = false;
            this.hCODETableAdapter.Fill(this.dsAtt.HCODE, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN);
            this.dEPTSTableAdapter1.Fill(this.basDS.DEPTS, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN);
            this.dEPTTableAdapter.Fill(this.basDS.DEPT, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN);
            this.aTTCARDTableAdapter.FillByInit(this.dsAtt.ATTCARD);
            this.aBS1TableAdapter.FillByInit(this.dsAtt.ABS1);

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

            fullDataCtrl1.DataAdapter = aBS1TableAdapter;
            fullDataCtrl1.Init_Ctrls();
        }

        private void ptxNobr_QueryCompleted(object sender, JBControls.PopupTextBox.QueryCompletedArgs e)
        {
            if (e.HasData)
            {
                //ptxHcode.Focus();
                SetDepts();
            }
        }

        private void ptxHcode_QueryCompleted(object sender, JBControls.PopupTextBox.QueryCompletedArgs e)
        {
            //if (e.HasData) txtDateB.Focus();
        }

        private void fullDataCtrl1_AfterAdd(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            ptxNobr.Focus();
            cbxDepts.Enabled = false;
            txtDateB.Text = Sal.Function.GetDate();
            txtDateE.Text = Sal.Function.GetDate();
            var sql = from d in db.HCODE
                      where d.H_CODE == "MA01"
                      select new
                      {
                          d.H_CODE_DISP
                      };
            int count = sql.Count();
            if (count > 0)
            {
                ptxHcode.Text = sql.FirstOrDefault().H_CODE_DISP;
            }
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
            //if (!e.Error)
            //    CDataLog.Save(this.Name, MainForm.USER_ID, DateTime.Now, fullDataCtrl1.BackupDataTable);
            if (!e.Error)
            {
                CDataLog.Save(this.Name, MainForm.USER_ID, DateTime.Now, fullDataCtrl1.BackupDataTable);
                bool isDiscount = false;
                if (IsNew)
                {
                    var rows = dsAtt.ABS1.Where(p => p.SERNO == guid);
                    string nobr = "", btime = "", etime = "", depts = "", memo = "", username = "", hcode = ""; ;
                    DateTime date_b = DateTime.Now.Date, date_e = DateTime.Now.Date;
                    decimal tol_hours = 0;
                    if (rows.Count() > 0)
                    {
                        var row = rows.First();
                        nobr = row.NOBR;
                        btime = row.BTIME;
                        etime = row.ETIME;
                        depts = "";
                        memo = row.NOTE;
                        username = MainForm.USER_NAME;
                        date_b = row.BDATE;
                        date_e = row.EDATE;
                        hcode = row.H_CODE;
                        tol_hours = row.TOL_HOURS;
                        List<string> yearrestList = new List<string>();
                        yearrestList.Add("0");
                        yearrestList.Add("2");
                        yearrestList.Add("4");
                        yearrestList.Add("6");
                        yearrestList.Add("8");
                        var sql = from a in db.HCODE where a.H_CODE == hcode && yearrestList.Contains(a.YEAR_REST) select a;
                        if (sql.Any())
                        {
                            isDiscount = true;
                            if (date_b.AddDays(1) == date_e && btime.CompareTo(etime) > 0)//日期差一天，但是申請時間大於結束時間，代表跨天
                                row.Delete();
                            else if (date_b < date_e)//請多天要拆每天時數
                                row.Delete();
                            else if (date_b == date_e)
                                row.SERNO = sno;
                            new dsAttTableAdapters.ABS1TableAdapter().Update(row);
                        }
                        else
                        {
                            row.SERNO = sno;
                            new dsAttTableAdapters.ABS1TableAdapter().Update(row);
                        }
                    }
                    //}
                    if (isDiscount)
                    {
                        DateTime t1, t2;
                        t1 = DateTime.Now;
                        if (date_b.AddDays(1) == date_e && btime.CompareTo(etime) > 0)//日期差一天，但是申請時間大於結束時間，代表跨天
                            Dll.Att.AbsCal.AbsSaveBy24(nobr, hcode, date_b, date_e, btime, etime, depts, memo, MainForm.USER_NAME, "", tol_hours, sno);
                        else if (date_b < date_e)//請多天要拆每天時數
                            Dll.Att.AbsCal.AbsSaveBy24(nobr, hcode, date_b, date_e, btime, etime, depts, memo, MainForm.USER_NAME, "", 0, sno);
                        //else if (date_b == date_e)//如果是單天...就自己存
                        //    Dll.Att.AbsCal.AbsSave(nobr, hcode, date_b, date_e, btime, etime, depts, memo, MainForm.USER_NAME, "", 0, sno, 0);
                        t2 = DateTime.Now;
                        dsAtt.ABS1DataTable dtAbs = new dsAtt.ABS1DataTable();
                        //var sql = from a in db.ABS where a.KEY_DATE >= t1 && a.KEY_DATE <= t2 select a;
                        //dtAbs.FillData(db.GetCommand(sql));

                        dtAbs = new dsAttTableAdapters.ABS1TableAdapter().GetDataByKeyDate(t1, t2);
                        dsAtt.ABS1.Merge(dtAbs);
                    }
                }
            }
            IsNew = false;
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
            DateTime d1 = Convert.ToDateTime(txtDateB.Text);
            string saladr = Sal.Core.SalaryDate.GetSaladr(ptxNobr.Text, d1);
            if (fullDataCtrl1.EditType == JBControls.FullDataCtrl.EEditType.Add)
            {
                if (Sal.Core.SalaryDate.CheckAttendLock(d1, saladr) && Sal.Core.SalaryDate.GetUnLockYYMM(d1, saladr).CompareTo(txtYymm.Text) > 0)
                {
                    MessageBox.Show(Resources.Att.AttendDateLocked + "," + Resources.Att.YymmMoveToNextMonth, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    e.Cancel = true;
                    return;
                }
            }
            //if (Sal.Function.IsAttendLocked(Convert.ToDateTime(txtDateB.Text)))
            //{
            //    if (fullDataCtrl1.EditType == JBControls.FullDataCtrl.EEditType.Add)
            //    {//鎖定時新增，移至下個月
            //        //e.Values["YYMM"] = GetUnLockYYMM(Convert.ToDateTime(txtDateB.Text));

            //        if (MessageBox.Show(Resources.Att.AttendDateLocked + "," + Resources.Att.YymmMoveToNextMonth, Resources.All.DialogTitle, MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk) == System.Windows.Forms.DialogResult.Cancel)
            //        {
            //            e.Cancel = true;
            //        }
            //        e.Values["YYMM"] =FRM28.GetUnLockYYMM(Convert.ToDateTime(txtDateB.Text));
            //    }
            //    else if (fullDataCtrl1.EditType == JBControls.FullDataCtrl.EEditType.Modify)
            //    {//鎖定時修改，不可以修改
            //        MessageBox.Show(Resources.Att.AttendDateLocked, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            //        e.Cancel = true;
            //        return;
            //    }
            //}
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
            IsNew = false;
            if (fullDataCtrl1.EditType == JBControls.FullDataCtrl.EEditType.Add)
            {//鎖定時修改，不可以修改
                //e.Cancel = true;
                guid = Guid.NewGuid().ToString();
                sno = txtSerno.Text;
                e.Values["serno"] = guid;
                IsNew = true;
                //foreach (var row in dtAbs) dsAtt.ABS.AddABSRow(row);
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0 && dataGridView1.CurrentRow != null)
            {
                string nobr = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                if (nobr.Trim().Length > 0)
                {
                    DateTime adate = Convert.ToDateTime(dataGridView1.CurrentRow.Cells[4].Value);
                    var sql = from ac in db.ATTCARD where ac.NOBR == nobr && ac.ADATE == adate select ac;
                    this.dsAtt.ATTCARD.FillData(db.GetCommand(sql));
                }
            }
        }
        void TimeSet()
        {
            try
            {
                string nobr = ptxNobr.Text;
                DateTime Bdate;
                Bdate = Convert.ToDateTime(txtDateB.Text);
                var sql = from rowAtt in db.ATTEND join rowRote in db.ROTE on rowAtt.ROTE equals rowRote.ROTE1 where rowAtt.NOBR == nobr && rowAtt.ADATE.Date == Bdate.Date select rowRote;
                if (sql.Any())
                {
                    var row = sql.First();
                    txtTimeB.Text = row.ON_TIME;
                    txtTimeE.Text = row.OFF_TIME;
                }
                else
                {
                    txtTimeB.Text = "0000";
                    txtTimeE.Text = "0000";
                }
            }
            catch
            {

            }
        }
        void UnitSet()
        {
            try
            {
                string hcode = ptxHcode.Text;
                DateTime Bdate;
                Bdate = Convert.ToDateTime(txtDateB.Text);
                var sql = from row in db.HCODE where row.H_CODE == hcode select row;
                if (sql.Any()) lblUnit.Text = sql.First().UNIT;
            }
            catch
            {

            }
        }
        void AbsHrsCalc()
        {
            try
            {
                string nobr = ptxNobr.Text;
                string hcode = ptxHcode.Text;
                DateTime Bdate, Edate;
                Bdate = Convert.ToDateTime(txtDateB.Text);
                Edate = Convert.ToDateTime(txtDateE.Text);
                string TimeB, TimeE;
                TimeB = Convert.ToInt32(txtTimeB.Text).ToString("0000");
                TimeE = Convert.ToInt32(txtTimeE.Text).ToString("0000");
                var details = JBHR.Dll.Att.AbsCal.AbsCalculationBy24(nobr, hcode, Bdate, Edate, TimeB, TimeE, "");
                txtTotalHours.Text = details.iTotalHour.ToString();
            }
            catch
            {

            }
        }

        private void txtDateB_Validated(object sender, EventArgs e)
        {
            SetDepts();
            DateTime d1 = Convert.ToDateTime(txtDateB.Text);
            txtDateE.Text = txtDateB.Text;
            SalaryDate sd = new SalaryDate(d1);
            txtYymm.Text = sd.YYMM;
            string saladr = Sal.Core.SalaryDate.GetSaladr(ptxNobr.Text, d1);
            if (Sal.Core.SalaryDate.CheckAttendLock(d1, saladr))
                txtYymm.Text = Sal.Core.SalaryDate.GetUnLockYYMM(d1, saladr);
            TimeSet();//設定該天班別的上下班時間
            AbsHrsCalc();//計算時數
            string nobr = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            if (nobr.Trim().Length > 0)
            {
                DateTime adate = Convert.ToDateTime(dataGridView1.CurrentRow.Cells[4].Value);
                var sql = from ac in db.ATTCARD where ac.NOBR == nobr && ac.ADATE == adate select ac;
                this.dsAtt.ATTCARD.FillData(db.GetCommand(sql));
            }
            dataGridView3.DataSource = Sal.Function.GetAttend(ptxNobr.Text, Convert.ToDateTime(txtDateB.Text), Convert.ToDateTime(txtDateE.Text));
        }
        void SetDepts()
        {
            string nobr;
            nobr = ptxNobr.Text;
            DateTime d1;
            d1 = Convert.ToDateTime(txtDateB.Text);
            var sql = from d in db.ATT_BASETTS where d.NOBR == nobr && d1 >= d.ADATE && d1 <= d.DDATE select d;
            if (sql.Any()) cbxDepts.SelectedValue = sql.First().DEPTS;
        }

        private void fullDataCtrl1_AfterEdit(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            cbxDepts.Enabled = false;
        }

        private void txtDateE_Validated(object sender, EventArgs e)
        {
            DateTime d1 = Convert.ToDateTime(txtDateB.Text);
            DateTime d2 = Convert.ToDateTime(txtDateE.Text);
            if (d2 < d1) txtDateB.Text = txtDateE.Text;
            AbsHrsCalc();//計算時數
            dataGridView3.DataSource = Sal.Function.GetAttend(ptxNobr.Text, Convert.ToDateTime(txtDateB.Text), Convert.ToDateTime(txtDateE.Text));
        }

        private void txtTimeB_Validated(object sender, EventArgs e)
        {
            AbsHrsCalc();//計算時數
        }

        private void ptxNobr_Validated(object sender, EventArgs e)
        {
            //var sql = from d in db.HCODE
            //          where d.H_CODE == "MA01"
            //          select new
            //          {
            //              d.H_CODE_DISP
            //          };
            //int count = sql.Count();
            //if (count > 0)
            //{
            //    ptxHcode.Text = sql.FirstOrDefault().H_CODE_DISP;
            //}
        }

    }
}
