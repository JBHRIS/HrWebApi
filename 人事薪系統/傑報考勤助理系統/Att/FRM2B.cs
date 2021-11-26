using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using JBHR.Sal.Core;
using JBTools;
namespace JBHR.Att
{
    public partial class FRM2B : JBControls.JBForm
    {
        public FRM2B()
        {
            InitializeComponent();
        }

        object[] PARMS = null;

        JBModule.Data.Linq.HrDBDataContext linqdb = new JBModule.Data.Linq.HrDBDataContext();

        dcAttDataContext db = new dcAttDataContext();
        private string guid;
        bool IsNew = false;
        string sno = "";
        private void FRM2B_Load(object sender, EventArgs e)
        {
            this.hCODETableAdapter.Fill(this.dsAtt.HCODE, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN);
            SystemFunction.SetComboBoxItems(ptxHcode, CodeFunction.GetHcode("0"), true);
            ptxHcode.Enabled = false;
            SystemFunction.SetComboBoxItems(cbxDepts, CodeFunction.GetDepts(), true);
            //cbxDepts.Enabled = false;
            this.hCODETableAdapter.Fill(this.dsAtt.HCODE, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN);
            //this.dEPTSTableAdapter.Fill(this.dsBas.DEPTS);
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
            
            ptxHcode.Enabled = true;
            cbxDepts.Enabled = false;
            txtDateB.Text = Sal.Function.GetDate();
            txtDateE.Text = Sal.Function.GetDate();
            ptxNobr.Focus();
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

        private void fullDataCtrl1_AfterDel(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            //CDataLog.Save(this.Name, MainForm.USER_ID, DateTime.Now, fullDataCtrl1.BackupDataTable);
            if (!e.Error)
            {
                CDataLog.Save(this.Name, MainForm.USER_ID, DateTime.Now, fullDataCtrl1.BackupDataTable);

                Dal.Dao.Att.TransCardDao tc = new Dal.Dao.Att.TransCardDao(linqdb.Connection);
                tc.TransCard(PARMS[0].ToString().Trim(), PARMS[1].ToString().Trim(), PARMS[2].ToString().Trim(), PARMS[3].ToString().Trim(), DateTime.Parse(PARMS[4].ToString()), DateTime.Parse(PARMS[5].ToString()), MainForm.USER_NAME, true, true, true, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN);
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
            string nobr = "", btime = "", etime = "", depts = "", memo = "", username = "", hcode = ""; ;
            DateTime date_b = DateTime.Now.Date, date_e = DateTime.Now.Date;
            decimal tol_hours = 0;

            if (!e.Error)
            {
                CDataLog.Save(this.Name, MainForm.USER_ID, DateTime.Now, fullDataCtrl1.BackupDataTable);
                bool isDiscount = false;
                if (IsNew)
                {
                    var rows = dsAtt.ABS1.Where(p => p.SERNO == guid);
                    
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
                //執行刷卡轉出勤

                if (nobr == "")
                    nobr = e.Values["nobr"].ToString();

                var DeptSQL = from a in linqdb.BASETTS
                              join b in linqdb.DEPT on a.DEPT equals b.D_NO
                              where date_b <= a.DDATE && date_b >= a.ADATE
                              && a.NOBR == nobr
                              select new { a.NOBR, b.D_NO_DISP };

                string dept_b = DeptSQL.First().D_NO_DISP;

                Dal.Dao.Att.TransCardDao tc = new Dal.Dao.Att.TransCardDao(linqdb.Connection);
                //tc.StatusChanged += new JBModule.Message.ReportStatus.StatusChangedEvent(tc_StatusChanged);
                tc.TransCard(nobr, nobr, dept_b, dept_b, date_b, date_e, MainForm.USER_NAME, true, true, true, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN);
            }
            IsNew = false;
        }

        private void fullDataCtrl1_BeforeDel(object sender, JBControls.FullDataCtrl.BeforeEventArgs e)
        {
            if (Sal.Function.IsAttendLocked(Convert.ToDateTime(txtDateB.Text), ptxNobr.Text))
            {
                //鎖定時修改，不可以修改
                MessageBox.Show(Resources.Att.AttendDateLocked, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                e.Cancel = true;
                return;
            }
            if (!Sal.Function.CanModify(ptxNobr.Text))
            {
                e.Cancel = true;
                MessageBox.Show(Resources.All.WorkadrErr, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }

            var DeptSQL = from a in linqdb.BASETTS
                          join b in linqdb.DEPT on a.DEPT equals b.D_NO
                          where DateTime.Parse(e.Values["bdate"].ToString()) <= a.DDATE && DateTime.Parse(e.Values["bdate"].ToString()) >= a.ADATE
                          && a.NOBR == e.Values["nobr"].ToString().Trim()
                          select new { a.NOBR, b.D_NO_DISP };

            string dept_b = DeptSQL.First().D_NO_DISP;

            PARMS = new object[] { e.Values["nobr"].ToString().Trim(), e.Values["nobr"].ToString().Trim(), dept_b, dept_b, DateTime.Parse(e.Values["bdate"].ToString()), DateTime.Parse(e.Values["edate"].ToString()), MainForm.USER_NAME, true, true, true, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN };
        }

        private void fullDataCtrl1_BeforeSave(object sender, JBControls.FullDataCtrl.BeforeEventArgs e)
        {
            if (Sal.Function.IsAttendLocked(Convert.ToDateTime(txtDateB.Text), ptxNobr.Text))
            {
                if (fullDataCtrl1.EditType == JBControls.FullDataCtrl.EEditType.Add)
                {//鎖定時新增，移至下個月
                    //e.Values["YYMM"] = GetUnLockYYMM(Convert.ToDateTime(txtDateB.Text));
                    if (txtYymm.Text != FRM28.GetUnLockYYMM(Convert.ToDateTime(txtDateB.Text)))
                    {
                        if (MessageBox.Show(Resources.Att.AttendDateLocked + "," + Resources.Att.YymmMoveToNextMonth, Resources.All.DialogTitle, MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk) == System.Windows.Forms.DialogResult.Cancel)
                        {
                            e.Cancel = true;
                        }
                        else
                        {
                            txtYymm.Text = FRM28.GetUnLockYYMM(Convert.ToDateTime(txtDateB.Text));
                            e.Values["YYMM"] = txtYymm.Text;
                        }
                    }
                }
                else if (fullDataCtrl1.EditType == JBControls.FullDataCtrl.EEditType.Modify)
                {//鎖定時修改，不可以修改
                    MessageBox.Show(Resources.Att.AttendDateLocked, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    e.Cancel = true;
                    return;
                }
            }

            if (!Sal.Function.CanModify(ptxNobr.Text))
            {
                e.Cancel = true;
                MessageBox.Show(Resources.All.WorkadrErr, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }

            if (FormatValidate.CheckTimeFormat(txtTimeB.Text.Trim()) != true || FormatValidate.CheckTimeFormat(txtTimeE.Text.Trim()) != true)
            {
                MessageBox.Show("起迄時間輸入錯誤", Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                e.Cancel = true;
                if (FormatValidate.CheckTimeFormat(txtTimeE.Text.Trim()) != true)
                    txtTimeE.Focus();
                if (FormatValidate.CheckTimeFormat(txtTimeB.Text.Trim()) != true)
                    txtTimeB.Focus();
                return;
            }

            if (!e.Cancel)
            {
                e.Values["KEY_MAN"] = MainForm.USER_NAME;
                e.Values["KEY_DATE"] = DateTime.Now;
            }
            if (fullDataCtrl1.EditType == JBControls.FullDataCtrl.EEditType.Add)
            {
                string Hcode = ptxHcode.SelectedValue.ToString();
                var hcodeSQL = from a in db.HCODE where a.H_CODE == Hcode && new string[] { "1", "3", "5", "7", "9" }.Contains(a.YEAR_REST) select a;
                if (!hcodeSQL.Any())
                {
                    JBModule.Data.Dto.AbsenceApply absApply = new JBModule.Data.Dto.AbsenceApply();
                    absApply.EmployeeID = ptxNobr.Text;
                    absApply.ApplyBeginDate = Convert.ToDateTime(txtDateB.Text).AddTime(txtTimeB.Text);
                    absApply.ApplyEndDate = Convert.ToDateTime(txtDateE.Text).AddTime(txtTimeE.Text);
                    absApply.Hcode = ptxHcode.SelectedValue.ToString();
                    JBHR.BLL.AbsenseFactory af = new BLL.AbsenseFactory();
                    var ap = af.CreateAbsApply();
                    var apData = ap.GenerateABS(absApply);
                    var av = af.CreateAbsValidate();
                    var checkAp = av.Validate(apData);
                    if (!checkAp)
                    {
                        e.Cancel = true;
                        if (av.RejectCode == 201001)
                            MessageBox.Show("申請的時段已存在請假資料", Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        if (av.RejectCode == 201002)
                            MessageBox.Show("剩餘時數不足", Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        return;
                    }
                }
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
                    var sql = from ac in db.ATTCARD where ac.NOBR == nobr && ac.ADATE == adate select new { 上班 = ac.T1, 下班 = ac.T2 };
                    dataGridView2.DataSource = sql;
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
                //string hcode = ptxHcode.Text;
                string hcode = ptxHcode.SelectedValue.ToString();
                DateTime Bdate, Edate;
                Bdate = Convert.ToDateTime(txtDateB.Text);
                Edate = Convert.ToDateTime(txtDateE.Text);
                string TimeB, TimeE;
                TimeB = Convert.ToInt32(txtTimeB.Text).ToString("0000");
                TimeE = Convert.ToInt32(txtTimeE.Text).ToString("0000");
                var details = JBHR.Dll.Att.AbsCal.AbsCalculationBy24(nobr, hcode, Bdate, Edate, TimeB, TimeE, "");
                //txtTotalHours.Text = details.iTotalHour.ToString();
                txtTotalHours.Text = details.sHcodeUnit == "天" ? details.iTotalDay.ToString() : details.iTotalHour.ToString();
            }
            catch
            {
                txtTotalHours.Text = "";
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
                var sql = from ac in db.ATTCARD where ac.NOBR == nobr && ac.ADATE == adate select new { 上班 = ac.T1, 下班 = ac.T2 };
                dataGridView2.DataSource = sql;
                //this.dsAtt.ATTCARD.FillData(db.GetCommand(sql));
            }
            dataGridView3.DataSource = Sal.Function.GetAttend(ptxNobr.Text, (Convert.ToDateTime(txtDateB.Text)).AddDays(1), Convert.ToDateTime(txtDateE.Text));
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
            dataGridView3.DataSource = Sal.Function.GetAttend(ptxNobr.Text, (Convert.ToDateTime(txtDateB.Text)).AddDays(1), Convert.ToDateTime(txtDateE.Text));
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

        private void dataGridView3_SelectionChanged(object sender, EventArgs e)
        {
            string nobr = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            if (nobr.Trim().Length > 0 && dataGridView3.CurrentRow.Cells[0].Value != null)
            {
                DateTime adate = Convert.ToDateTime(dataGridView3.CurrentRow.Cells[0].Value);
                if (adate != null )
                {
                    var sql = from ac in db.ATTCARD where ac.NOBR == nobr && ac.ADATE == adate select new { 上班 = ac.T1, 下班 = ac.T2 };
                    dataGridView2.DataSource = sql;
                    //this.dsAtt.ATTCARD.Clear();
                    //this.dsAtt.ATTCARD.FillData(db.GetCommand(sql));
                } 
            }
        }
    }
}
