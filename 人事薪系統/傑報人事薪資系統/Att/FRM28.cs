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
using JBHR.BLL.Att;
using JBHR.Sal;

namespace JBHR.Att
{
    /**補休規則
     * 利用ABSD作對沖
     * 新增時，系統自動產生沖假
     * 修改時，需檢查有無多筆相同序號的請假資料，如果有，就必須刪除全部重新申請
     * 刪除時，需檢查有無多筆相同序號的請假資料，如果有，就必須刪除全部
     * 如果是得假，當已有ABSD時，不可修改
     * 必須將所有ABSD對應的資料刪除後才可修改
     * 刪除亦同
     * */
    public partial class FRM28 : JBControls.JBForm
    {
        public FRM28()
        {
            InitializeComponent();
        }
        dcAttDataContext db = new dcAttDataContext();
        string sno = "";
        private string guid;
        string prehocde;
        bool IsNew = false;
        string oldBtime, oldEtime, oldHcode;
        DateTime oldDateB;
        string Del_Serno = "";
        List<HCODE> HcodeList = new List<HCODE>();
        CheckTimeFormatControl CTFC = new CheckTimeFormatControl();
        Dictionary<DateTime, decimal> TotalHrsList = new Dictionary<DateTime, decimal>();
        private void FRM28_Load(object sender, EventArgs e)
        {
            CTFC.AddControl(txtTimeB, true, false, false);
            CTFC.AddControl(txtTimeE, true, false, false);
            this.hCODETableAdapter.Fill(this.dsAtt.HCODE, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN);
            HcodeList = db.HCODE.ToList();
            List<string> FlagList = new List<string> { "-", "X" };
            SystemFunction.SetComboBoxItems(ptxHcode, CodeFunction.GetHcode(FlagList), true, false, true);
            ptxHcode.Enabled = false;
            //this.dEPTSTableAdapter.Fill(this.dsBas.DEPTS);
            SystemFunction.SetComboBoxItems(cbxDepts, CodeFunction.GetDepts(), true, false, true);
            //初始化Adapter
            this.aTTCARDTableAdapter.FillByInit(this.dsAtt.ATTCARD);
            this.aBSTableAdapter.FillByInit(this.dsAtt.ABS);

            BasDataClassesDataContext db1 = new BasDataClassesDataContext();
            var u_prg = (from c in db1.U_PRGID where c.USER_ID.Trim() == MainForm.USER_ID && c.PROG.Trim().ToLower() == this.Name.ToLower() select c).FirstOrDefault();
            if (u_prg != null)
            {
                fullDataCtrl1.bnAddEnable = u_prg.ADD_;
                fullDataCtrl1.bnEditEnable = u_prg.EDIT;
                fullDataCtrl1.bnDelEnable = u_prg.DELE;
                fullDataCtrl1.bnExportEnable = u_prg.PRINT_;
            }

            Sal.Function.SetAvaliableBase(this.dsBas.BASE);
            fullDataCtrl1.WhereCmd = Sal.Function.GetFilterCmd("ABS") + " AND EXISTS(SELECT 1 FROM HCODE X1 WHERE X1.H_CODE=ABS.H_CODE AND X1.FLAG !='+')";

            fullDataCtrl1.DataAdapter = aBSTableAdapter;
            fullDataCtrl1.Init_Ctrls();
            dataGridView3.DataSource = Sal.Function.GetAttend(ptxNobr.Text, Convert.ToDateTime(txtDateB.Text), Convert.ToDateTime(txtDateE.Text));
        }

        private void fullDataCtrl1_AfterAdd(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            ptxNobr.Focus();
            txtDateB.Text = Sal.Core.SalaryDate.DateString();
            txtDateE.Text = txtDateB.Text;
            //cbxDepts.Enabled = false;
            dataGridView3.DataSource = Sal.Function.GetAttend(ptxNobr.Text, Convert.ToDateTime(txtDateB.Text), Convert.ToDateTime(txtDateE.Text));
            txtSerNO.Text = Guid.NewGuid().ToString();
            txtSerNO.Enabled = false;
            txtGuid.Enabled = false;
        }
        private void fullDataCtrl1_BeforeSave(object sender, JBControls.FullDataCtrl.BeforeEventArgs e)
        {
            var db = new JBModule.Data.Linq.HrDBDataContext();
            //List<string> yearrestList = new List<string>();
            //yearrestList.Add("1");
            //yearrestList.Add("3");
            //yearrestList.Add("5");
            //yearrestList.Add("7");
            //yearrestList.Add("9");
            //if (txtTimeB.Text.Trim().Length < 4 || txtTimeE.Text.Trim().Length < 4 || txtTimeB.Text.Trim() == "0000" || txtTimeE.Text.Trim() == "0000")
            //{
            //    var sql = from a in HcodeList where a.H_CODE == ptxHcode.Text && !yearrestList.Contains(a.YEAR_REST) select a;
            //    if (sql.Any())
            //    {
            //        MessageBox.Show("起迄時間輸入不完整", Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            //        e.Cancel = true;
            //        return;
            //    }
            //}

            //中華精測取消判斷
            //if (FormatValidate.CheckTimeFormat(txtTimeB.Text.Trim()) != true || FormatValidate.CheckTimeFormat(txtTimeE.Text.Trim()) != true)
            //{
            //    MessageBox.Show("起迄時間輸入錯誤", Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            //    e.Cancel = true;
            //    if (FormatValidate.CheckTimeFormat(txtTimeE.Text.Trim()) != true)
            //        txtTimeE.Focus();
            //    if (FormatValidate.CheckTimeFormat(txtTimeB.Text.Trim()) != true)
            //        txtTimeB.Focus();
            //    return;
            //}

            e.Values["btime"] = txtTimeB.Text;
            e.Values["etime"] = txtTimeE.Text;

            if (fullDataCtrl1.EditType == JBControls.FullDataCtrl.EEditType.Add)
            {
                DateTime d1 = Convert.ToDateTime(txtDateB.Text);
                DateTime d2 = Convert.ToDateTime(txtDateE.Text);
                for (DateTime i = d1; i <= d2; i = i.AddDays(1))
                {
                    string saladr = Sal.Core.SalaryDate.GetSaladr(ptxNobr.Text, i);
                    if (Sal.Core.SalaryDate.CheckAttendLock(i, saladr) && Sal.Core.SalaryDate.GetUnLockYYMM(i, saladr).CompareTo(txtYymm.Text) > 0)
                    {
                        MessageBox.Show(Resources.Att.AttendDateLocked + "," + Resources.Att.YymmMoveToNextMonth, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        e.Cancel = true;
                        return;
                    }
                }
            }
            if (fullDataCtrl1.EditType == JBControls.FullDataCtrl.EEditType.Add)
            {
                string Hcode = ptxHcode.SelectedValue.ToString();
                //lblSerno.Tag = Guid.NewGuid().ToString();
                txtGuid.Text = Guid.NewGuid().ToString();
                //var hcodeSQL = from a in HcodeList where a.H_CODE == Hcode && new string[] { "1", "3", "5", "7", "9" }.Contains(a.YEAR_REST) select a;
                //if (!hcodeSQL.Any())
                //{
                //JBModule.Data.Dto.AbsenceApply absApply = new JBModule.Data.Dto.AbsenceApply();
                //absApply.EmployeeID = ptxNobr.Text;
                //absApply.ApplyBeginDate = Convert.ToDateTime(txtDateB.Text).AddTime(txtTimeB.Text);
                //absApply.ApplyEndDate = Convert.ToDateTime(txtDateE.Text).AddTime(txtTimeE.Text);
                //absApply.Hcode = ptxHcode.SelectedValue.ToString();
                //JBHR.BLL.AbsenseFactory af = new BLL.AbsenseFactory();
                //var ap = af.CreateAbsApply();
                //var apData = ap.GenerateABS(absApply);
                //var av = af.CreateAbsValidate();
                //var checkAp = av.Validate(apData);
                //if (!checkAp)
                //{
                //    e.Cancel = true;
                //    if (av.RejectCode == 201001)
                //        MessageBox.Show("申請的時段已存在請假資料", Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                //    if (av.RejectCode == 201002)
                //        MessageBox.Show("剩餘時數不足", Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                //    return;
                //}
                //}
                //CheckAbsHrs();
                //if (Convert.ToDecimal(txtTotalHours.Text) > Convert.ToDecimal(txtCurrentHrs.Text))
                //{
                //    MessageBox.Show("剩餘時數不足", Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                //    return;
                //}
            }
            var absData = FRM28.GetExistsABS(e.Values["nobr"].ToString(), Convert.ToDateTime(e.Values["bdate"]), Convert.ToDateTime(e.Values["edate"]), e.Values["btime"].ToString(), e.Values["etime"].ToString(), e.Values["h_code"].ToString(), e.Values["Guid"].ToString());
            if (absData.Any())
            {
                if (MessageBox.Show("申請的時段內已有存在的請假資料" + Environment.NewLine + "按確認顯示查詢影響的資料", Resources.All.DialogTitle, MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk) == System.Windows.Forms.DialogResult.OK)
                {
                    Sal.PreviewForm frm = new Sal.PreviewForm();
                    frm.DataTable = absData.Select(p => new { 工號 = p.Nobr, 姓名 = p.NameC, 假別代碼 = p.Hcode, 假別名稱 = p.Hname, 請假日期 = p.DateB, 開始時間 = p.Btime, 結束時間 = p.Etime }).CopyToDataTable();
                    frm.Width = 800;
                    frm.ShowDialog();
                }
                e.Cancel = true;
                return;
            }
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
                sno = txtSerNO.Text;
                IsNew = true;
            }
            //guid = lblSerno.Tag.ToString();
            guid = txtGuid.Text.ToString();
            //if (fullDataCtrl1.EditType == JBControls.FullDataCtrl.EEditType.Modify)//修改要檢查有無重複序號(連續申請多天)
            //{
            //    int count = CheckABS_Exist(txtSerNO.Text);
            //    if (count > 1)//多筆
            //    {
            //        MessageBox.Show("該筆資料共有" + count.ToString() + "連續申請資料，需刪除後重新申請", Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            //        e.Cancel = true;
            //        return;
            //    }
            //}
            var rhcode = HcodeList.Where(pp => pp.H_CODE == ptxHcode.SelectedValue.ToString()).First();

            if (rhcode.CHE)
            {
                //decimal chkDiscount = 0;//修改時檢查修正
                //if (fullDataCtrl1.EditType == JBControls.FullDataCtrl.EEditType.Modify)
                //{
                //    //var chkSQL = from a in db.ABS where a.Guid == lblSerno.Tag.ToString() select a;
                //    var chkSQL = from a in db.ABS where a.Guid == txtGuid.Text.ToString() && a.H_CODE == rhcode.H_CODE select a;
                //    if (chkSQL.Any()) chkDiscount = chkSQL.First().TOL_HOURS;
                //}

                JBModule.Data.Linq.HrDBDataContext dbchk = new JBModule.Data.Linq.HrDBDataContext();
                string nobr = ptxNobr.Text;
                string hcode = ptxHcode.SelectedValue.ToString();
                DateTime Bdate = Convert.ToDateTime(txtDateB.Text);
                DateTime Edate = Convert.ToDateTime(txtDateE.Text);
                var ABSPlus = (from a in dbchk.ABS
                               join b in dbchk.HCODE on a.H_CODE equals b.H_CODE
                               join c in dbchk.HCODE on b.HTYPE equals c.HTYPE
                               where a.NOBR == nobr && Edate >= a.BDATE && Bdate <= a.EDATE
                               && c.H_CODE == hcode
                               && b.FLAG == "+"
                               select a).ToList();

                if (fullDataCtrl1.EditType == JBControls.FullDataCtrl.EEditType.Modify)
                {
                    //var chkSQL = from a in db.ABS where a.Guid == txtGuid.Text.ToString() && a.H_CODE == rhcode.H_CODE select a;
                    //if (chkSQL.Any()) chkDiscount = chkSQL.First().TOL_HOURS;
                    var chkSQL = (from a in dbchk.ABSD
                                  join b in dbchk.ABS on a.ABSADD equals b.Guid
                                  where a.ABSSUBTRACT == txtGuid.Text.ToString()
                                  select a).ToList();

                    ABSPlus = (from a in ABSPlus
                               join b in chkSQL on a.Guid equals b.ABSADD into b1
                               from b in b1.DefaultIfEmpty()
                               select new
                               JBModule.Data.Linq.ABS
                               {
                                   A_NAME = a.A_NAME,
                                   BDATE = a.BDATE,
                                   EDATE = a.EDATE,
                                   KEY_DATE = a.KEY_DATE,
                                   KEY_MAN = a.KEY_MAN,
                                   //SALABS = a.SALABS,
                                   SYSCREATE = a.SYSCREATE,
                                   SYSCREATE1 = a.SYSCREATE1,
                                   TOL_DAY = a.TOL_DAY,
                                   Balance = a.Balance + (b != null ? b.USEHOUR : 0.0M),
                                   BTIME = a.BTIME,
                                   ETIME = a.ETIME,
                                   Guid = a.Guid,
                                   HCODE = a.HCODE,
                                   H_CODE = a.H_CODE,
                                   LeaveHours = a.LeaveHours,
                                   //Memo = a.Memo,
                                   NOBR = a.NOBR,
                                   nocalc = a.nocalc,
                                   NOTE = a.NOTE,
                                   NOTEDIT = a.NOTEDIT,
                                   //OT_HRS = a.OT_HRS,
                                   SERNO = a.SERNO,
                                   TOL_HOURS = a.TOL_HOURS,
                                   YYMM = a.YYMM,
                               }).ToList();
                }

                Dictionary<DateTime, decimal> insufficientList = new Dictionary<DateTime, decimal>();
                foreach (var item in TotalHrsList)
                {
                    decimal balance = item.Value;
                    foreach (var abs in ABSPlus.Where(p => item.Key >= p.BDATE && item.Key <= p.EDATE).ToList())
                    {
                        if (abs.Balance >= balance)
                        {
                            abs.Balance -= balance;
                            balance = 0;
                            break;
                        }
                        else
                        {
                            balance -= abs.Balance.Value;
                            abs.Balance = 0;
                        }
                    }
                    if (balance > 0)
                    {
                        insufficientList.Add(item.Key, balance);
                        e.Cancel = true;
                    }
                }
                if (insufficientList.Count > 0)
                {
                    MessageBox.Show("剩餘時數不足", Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    if (Bdate != Edate)
                    {
                        PreviewForm frm = new PreviewForm();
                        frm.DataTable = insufficientList.Select(p => new { 請假日期 = p.Key, 不足時數 = p.Value }).CopyToDataTable();
                        frm.Form_Title = "剩餘時數不足";
                        frm.ShowDialog();
                    }
                    e.Cancel = true;
                }
            }
            //}
        }
        //bool CheckABSD_Exist(string YearRest, string Serno)
        //{
        //    var mydb = new JBModule.Data.Linq.HrDBDataContext();
        //    var sql = from a in mydb.ABSD select a;
        //    if (YearRest == "3")
        //        sql = from a in sql where a.ABSADD == Serno select a;
        //    else sql = from a in sql where a.ABSSUBTRACT == Serno select a;
        //    return sql.Any();
        //}
        //int CheckABS_Exist(string Serno)
        //{
        //    var mydb = new JBModule.Data.Linq.HrDBDataContext();
        //    var sql = from a in mydb.ABS where a.SERNO == Serno select a;
        //    return sql.Count();
        //}
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
                CDataLog.Save(this.Name, MainForm.USER_ID, DateTime.Now, fullDataCtrl1.BackupDataTable);
                bool isDiscount = false;
                if (IsNew)
                {
                    var rows = dsAtt.ABS.Where(p => p.SERNO == sno);
                    string nobr = "", btime = "", etime = "", depts = "", memo = "", username = "", hcode = "", note = "";
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
                        note = row.NOTE;
                        //List<string> yearrestList = new List<string>();
                        //yearrestList.Add("0");
                        //yearrestList.Add("2");
                        //yearrestList.Add("4");
                        //yearrestList.Add("6");
                        //yearrestList.Add("8");
                        //var sql = from a in HcodeList where a.flag == hcode && yearrestList.Contains(a.YEAR_REST) select a;
                        //if (sql.Any())
                        //{
                        isDiscount = true;
                        //if (date_b.AddDays(1) == date_e && btime.CompareTo(etime) > 0)//日期差一天，但是申請時間大於結束時間，代表跨天
                        row.Delete();
                        //else if (date_b < date_e)//請多天要拆每天時數
                        //    row.Delete();
                        //else if (date_b == date_e)
                        //    row.SERNO = sno;
                        new dsAttTableAdapters.ABSTableAdapter().Update(row);
                        //}
                        //else
                        //{
                        //    row.SERNO = sno;
                        //    new dsAttTableAdapters.ABSTableAdapter().Update(row);
                        //}
                    }
                    //}
                    if (isDiscount)
                    {
                        DateTime t1, t2;
                        t1 = DateTime.Now;
                        //if (date_b.AddDays(1) == date_e && btime.CompareTo(etime) > 0)//日期差一天，但是申請時間大於結束時間，代表跨天
                        //{
                        //    //Dll.Att.AbsCal.AbsSaveBy24(nobr, hcode, date_b, date_e, btime, etime, depts, memo, MainForm.USER_NAME, "", tol_hours, sno);
                        //    Dal.Dao.Att.AbsDao absDao = new Dal.Dao.Att.AbsDao(db.Connection);
                        //    absDao.AbsSave(nobr, hcode, date_b, date_e, btime, etime, textBox7.Text, MainForm.USER_NAME, "", sno, "", "", true, true, tol_hours, false, "");
                        //}
                        //else if (date_b < date_e)//請多天要拆每天時數
                        {
                            //Dll.Att.AbsCal.AbsSaveBy24(nobr, hcode, date_b, date_e, btime, etime, depts, memo, MainForm.USER_NAME, "", 0, sno);
                            Dal.Dao.Att.AbsDao absDao = new Dal.Dao.Att.AbsDao(db.Connection);
                            absDao.AbsSave(nobr, hcode, date_b, date_e, btime, etime, note, MainForm.USER_NAME, "", sno, "", "", true, true, tol_hours, false, "");
                        }
                        //else if (date_b == date_e)//如果是單天...就自己存
                        //    Dll.Att.AbsCal.AbsSave(nobr, hcode, date_b, date_e, btime, etime, depts, memo, MainForm.USER_NAME, "", 0, sno, 0);
                        t2 = DateTime.Now;
                        dsAtt.ABSDataTable dtAbs = new dsAtt.ABSDataTable();
                        //var sql = from a in db.ABS where a.KEY_DATE >= t1 && a.KEY_DATE <= t2 select a;
                        //dtAbs.FillData(db.GetCommand(sql));

                        dtAbs = new dsAttTableAdapters.ABSTableAdapter().GetDataBySerno(sno);
                        //foreach (var it in dtAbs)
                        //    AutoABSD(it.NOBR, it.H_CODE, it.BDATE, it.Guid, it.TOL_HOURS, true);
                        dsAtt.ABS.Merge(dtAbs);
                        guid = dtAbs.Rows[0].Field<string>("guid");
                    }
                }
                else
                {
                    var rows = dsAtt.ABS.Where(p => !p.IsGuidNull() && p.Guid == guid);
                    foreach (var it in rows)
                    {
                        AutoABSD(it.NOBR, it.H_CODE, it.BDATE, it.Guid, it.TOL_HOURS, true, prehocde);
                    }
                }
                CheckAbsHrs(guid);
            }
            IsNew = false;
        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null && dataGridView1.CurrentRow.Cells[0].Value.ToString().Trim().Length > 0)
            {
                string nobr = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                this.dsAtt.ATTCARD.Clear();
                if (nobr.Trim().Length > 0)
                {
                    dcViewDataContext dv = new dcViewDataContext();
                    DateTime adate = Convert.ToDateTime(dataGridView1.CurrentRow.Cells[4].Value);
                    String hcode = Convert.ToString(dataGridView1.CurrentRow.Cells[2].Value);
                    if (hcode[0].ToString() != "W")
                    {
                        var sql = from ac in dv.V_FRM26 where ac.NOBR == nobr && ac.ADATE == adate select ac;
                        this.dsAtt.ATTCARD.FillData(dv.GetCommand(sql));

                        dataGridView3.DataSource = Sal.Function.GetAttend(ptxNobr.Text, Convert.ToDateTime(txtDateB.Text), Convert.ToDateTime(txtDateE.Text));
                        if (dataGridView3.RowCount > 2)
                        {
                            dataGridView3.Rows[0].Selected = false;
                            this.dataGridView3.CurrentCell = this.dataGridView3.Rows[1].Cells[0];
                            dataGridView3.Rows[1].Selected = true;
                        }
                    }
                }
                SetDepts();
            }
        }
        void TimeSet()
        {
            try
            {
                string nobr = ptxNobr.Text;
                DateTime Bdate;
                Bdate = Convert.ToDateTime(txtDateB.Text);
                var sql = from rowAtt in db.ATTEND join rowRote in db.ROTE on rowAtt.ROTE equals rowRote.ROTE1 where rowAtt.NOBR == nobr && rowAtt.ADATE.Date <= Bdate.Date && !CodeFunction.GetHolidayRoteList().Contains(rowAtt.ROTE) orderby rowAtt.ADATE descending select rowRote;
                if (sql.Any())
                {
                    var row = sql.First();
                    txtTimeB.Text = row.ON_TIME;
                    txtTimeE.Text = string.IsNullOrWhiteSpace(row.ATT_END) ? row.OFF_TIME : row.ATT_END;
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
                if (ptxHcode.SelectedValue != null)
                {
                    string hcode = ptxHcode.SelectedValue.ToString();
                    DateTime Bdate;
                    Bdate = Convert.ToDateTime(txtDateB.Text);
                    var sql = from row in HcodeList where row.H_CODE == hcode select row;
                    if (sql.Any()) lblUnit.Text = sql.First().UNIT; 
                }
            }
            catch
            {

            }
        }
        void AbsHrsCalc()
        {
            try
            {
                if (fullDataCtrl1.EditType == JBControls.FullDataCtrl.EEditType.None) return;
                string nobr = ptxNobr.Text;
                if (ptxHcode.SelectedValue != null)
                {
                    string hcode = ptxHcode.SelectedValue.ToString();
                    DateTime Bdate, Edate;
                    Bdate = Convert.ToDateTime(txtDateB.Text);
                    Edate = Convert.ToDateTime(txtDateE.Text);
                    string TimeB, TimeE;
                    TimeB = Convert.ToInt32(txtTimeB.Text).ToString("0000");
                    TimeE = Convert.ToInt32(txtTimeE.Text).ToString("0000");
                    //var details = JBHR.Dll.Att.AbsCal.AbsCalculationBy24(nobr, hcode, Bdate, Edate, TimeB, TimeE, "");
                    //string Hcode = ptxHcode.SelectedValue.ToString();
                    //var hcodeSQL = from a in HcodeList where a.H_CODE.Trim() == Hcode && new string[] { "1", "3", "5", "7", "9" }.Contains(a.YEAR_REST) select a;
                    //if (!hcodeSQL.Any())//得假不跑
                    //{
                    //    var HcodeData = HcodeList.Where(p => p.H_CODE == Hcode);
                    //    JBModule.Data.Dto.AbsenceApply absApply = new JBModule.Data.Dto.AbsenceApply();
                    //    absApply.EmployeeID = ptxNobr.Text;
                    //    absApply.ApplyBeginDate = Convert.ToDateTime(txtDateB.Text).AddTime(txtTimeB.Text);
                    //    absApply.ApplyEndDate = Convert.ToDateTime(txtDateE.Text).AddTime(txtTimeE.Text);
                    //    absApply.Hcode = ptxHcode.SelectedValue.ToString();
                    //    JBHR.BLL.AbsenseFactory af = new BLL.AbsenseFactory();
                    //    var ap = af.CreateAbsApply();
                    //    var apData = ap.GenerateABS(absApply);
                    //    if (apData.Any())
                    //        txtTotalHours.Text = apData.Sum(p => p.TOL_HOURS).ToString();
                    //    else txtTotalHours.Text = "0";
                    Dal.Dao.Att.AbsDao oAbsDao = new Dal.Dao.Att.AbsDao(db.Connection);
                    decimal TotalUse = 0;
                    TotalHrsList.Clear();
                    var Calculate = oAbsDao.GetCalculate(nobr, hcode, Bdate, Edate, TimeB, TimeE);
                    foreach (var item in Calculate.Day)
                        TotalHrsList.Add(item.DateB, item.Use);
                    txtTotalHours.Text = Calculate.TotalUse.ToString();
                }
                else
                    txtTotalHours.Text = "";
            }
            catch
            {
                txtTotalHours.Text = "";
            }
        }
        decimal CheckAbsHrs(string chkguid = "")
        {
            if (ptxHcode.SelectedValue != null && txtDateB.Text != null)
            {
                string nobr = ptxNobr.Text;
                string hcode = ptxHcode.SelectedValue.ToString();
                DateTime Bdate;
                Bdate = Convert.ToDateTime(txtDateB.Text);
                //JBHR.BLL.AbsInfoFactory aif = new BLL.AbsInfoFactory();
                //JBHR.BLL.AbsInfoQueryCondition condition = new BLL.AbsInfoQueryCondition();
                //condition.Adate = Bdate;
                //condition.EmployeeID = nobr;
                //condition.HolidayCode = hcode;
                //var absInfo = aif.getInfo(condition);
                JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
                if (!string.IsNullOrWhiteSpace(chkguid))
                {
                    var sqlbyGuid = (from a in db.ABS
                                     where a.Guid == guid
                                     select new { a.NOBR, a.BDATE, a.H_CODE }).SingleOrDefault();
                    if (sqlbyGuid != null)
                    {
                        nobr = sqlbyGuid.NOBR;
                        Bdate = sqlbyGuid.BDATE;
                        hcode = sqlbyGuid.H_CODE;
                    }
                }
                var sql = from a in db.ABS
                          join b in db.HCODE on a.H_CODE equals b.H_CODE
                          join c in db.HCODE on b.HTYPE equals c.HTYPE
                          where a.NOBR == nobr && Bdate >= a.BDATE && Bdate <= a.EDATE
                          && c.H_CODE == hcode
                          && b.FLAG == "+"
                          select new { a.BDATE, a.EDATE, a.Balance };
                txtCurrentHrs.Text = String.Empty;
                if (sql.Any())
                    txtCurrentHrs.Text = sql.Sum(p => p.Balance).ToString();
                return txtCurrentHrs.Text != String.Empty ? Convert.ToDecimal(txtCurrentHrs.Text) : 0.0M; 
            }
            else
            {
                txtCurrentHrs.Text = string.Empty;
                return 0.0M;
            }
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

            //var HcodeData = HcodeList.Where(p => p.H_CODE == oldHcode);
            //if (HcodeData.Any())
            //{
            //if (HcodeData.First().YEAR_REST == "3")
            //{
            //    if (!CheckABSD_Exist("3", txtSerNO.Text))
            //    {
            //        MessageBox.Show("得假資料已申請，請先將申請資料刪除", Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //        e.Cancel = true;
            //    }
            //}
            //else if (HcodeData.First().YEAR_REST == "4")
            //{
            //    int count = CheckABS_Exist(txtSerNO.Text);
            //    if (count > 1)//多筆
            //    {
            //        if (MessageBox.Show("該筆資料共有" + count.ToString() + "連續申請資料，刪除的話將會全部一併刪除，是否要繼續?", Resources.All.DialogTitle, MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == System.Windows.Forms.DialogResult.Cancel)
            //        {
            //            e.Cancel = true;
            //            return;
            //        }
            //    }
            //}
            //}

            Del_Serno = e.Values["GUID"].ToString();
            oldHcode = e.Values["H_CODE"].ToString();
        }

        private void ptxNobr_QueryCompleted(object sender, JBControls.PopupTextBox.QueryCompletedArgs e)
        {
            if (e.HasData)
            {
                //ptxHcode.Focus();
                TimeSet();
                SetDepts();
            }
        }

        private void ptxHcode_QueryCompleted(object sender, JBControls.PopupTextBox.QueryCompletedArgs e)
        {
            //if (e.HasData) txtDateB.Focus();
        }

        private void txtDateB_Validated(object sender, EventArgs e)
        {
            if (!IsNew)
            {
                SetDepts();
                DateTime d1 = Convert.ToDateTime(txtDateB.Text);
                txtDateE.Text = txtDateB.Text;
                SalaryDate sd = new SalaryDate(d1);
                //sd = sd.GetNextSalaryDate();
                txtYymm.Text = sd.YYMM;
                string saladr = Sal.Core.SalaryDate.GetSaladr(ptxNobr.Text, d1);
                if (Sal.Core.SalaryDate.CheckAttendLock(d1, saladr))
                    txtYymm.Text = Sal.Core.SalaryDate.GetUnLockYYMM(d1, saladr);
                TimeSet();//設定該天班別的上下班時間
                AbsHrsCalc();//計算時數
                this.dsAtt.ATTCARD.Clear();
                string nobr = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                if (nobr.Trim().Length > 0)
                {
                    dcViewDataContext dv = new dcViewDataContext();
                    DateTime adate = Convert.ToDateTime(dataGridView1.CurrentRow.Cells[4].Value);
                    var sql = from ac in dv.V_FRM26 where ac.NOBR == nobr && ac.ADATE == adate select ac;
                    this.dsAtt.ATTCARD.FillData(dv.GetCommand(sql));
                }
                dataGridView3.DataSource = Sal.Function.GetAttend(ptxNobr.Text, Convert.ToDateTime(txtDateB.Text), Convert.ToDateTime(txtDateE.Text));
                if (dataGridView3.RowCount > 2)
                {
                    dataGridView3.Rows[0].Selected = false;
                    this.dataGridView3.CurrentCell = this.dataGridView3.Rows[1].Cells[0];
                    dataGridView3.Rows[1].Selected = true;
                }
                CheckAbsHrs(); 
            }
        }

        private void txtTimeE_Validated(object sender, EventArgs e)
        {
            AbsHrsCalc();//計算時數
        }

        private void ptxHcode_Validated(object sender, EventArgs e)
        {
            UnitSet();//設定該假別的時間單位
            AbsHrsCalc();//計算時數
            CheckAbsHrs();
            //if (dataGridView1.CurrentRow != null && dataGridView1.CurrentRow.Cells[0].Value.ToString().Trim().Length > 0)
            //{
            //    String hcode = Convert.ToString(dataGridView1.CurrentRow.Cells[2].Value);
            //    prehocde = hcode;
            //}
        }

        private void txtDateB_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                DateTime d1, d2;
                d1 = Convert.ToDateTime(txtDateB.Text);
                d2 = Convert.ToDateTime(txtDateE.Text);
                if (d1 > d2) txtDateE.Text = txtDateB.Text;//開始日期不可大於結束日期
            }
            catch
            { }
        }

        private void txtDateE_Validated(object sender, EventArgs e)
        {
            DateTime d1 = Convert.ToDateTime(txtDateB.Text);
            DateTime d2 = Convert.ToDateTime(txtDateE.Text);
            if (d2 < d1) txtDateB.Text = txtDateE.Text;
            AbsHrsCalc();
            CheckAbsHrs();
            dataGridView3.DataSource = Sal.Function.GetAttend(ptxNobr.Text, Convert.ToDateTime(txtDateB.Text), Convert.ToDateTime(txtDateE.Text));
            if (dataGridView3.RowCount > 2)
            {
                dataGridView3.Rows[0].Selected = false;
                this.dataGridView3.CurrentCell = this.dataGridView3.Rows[1].Cells[0];
                dataGridView3.Rows[1].Selected = true;
            }
        }

        private void fullDataCtrl1_AfterDel(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            CDataLog.Save(this.Name, MainForm.USER_ID, DateTime.Now, fullDataCtrl1.BackupDataTable);
            var HcodeData = HcodeList.Where(p => p.H_CODE == oldHcode);
            if (HcodeData.Any())
            {
                //if (HcodeData.First().YEAR_REST == "3")
                //    db.ExecuteCommand("DELETE ABSD WHERE ABSADD={0}", Del_Serno);
                //else if (HcodeData.First().YEAR_REST == "4")
                //{
                //db.ExecuteCommand("DELETE ABSD WHERE ABSSUBTRACT={0}", Del_Serno);
                if (Del_Serno.Trim().Length > 0)//避免空白
                {
                    db.ExecuteCommand("DELETE ABS WHERE guid={0}", Del_Serno);
                    var qq = from a in dsAtt.ABS where a.Guid == Del_Serno select a;
                    foreach (dsAtt.ABSRow r in qq)
                    {
                        r.Delete();
                    }
                    dsAtt.ABS.AcceptChanges();
                    AutoABSD(e.OldValues["nobr"].ToString(), oldHcode, Convert.ToDateTime(e.OldValues["bdate"]), Del_Serno, 0, true);//帶入0表示刪除
                }
                //}
            }
            CheckAbsHrs();
        }
        void SetDepts()
        {
            try
            {
                string nobr;
                nobr = ptxNobr.Text;
                DateTime d1;
                d1 = Convert.ToDateTime(txtDateB.Text);
                var sql = from d in db.ATT_BASETTS where d.NOBR == nobr && d1 >= d.ADATE && d1 <= d.DDATE select d;
                if (sql.Any()) cbxDepts.SelectedValue = sql.First().DEPTS;
            }
            catch { }
        }

        private void fullDataCtrl1_AfterEdit(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            cbxDepts.Enabled = false;
            ptxNobr.Enabled = false;
            txtSerNO.Enabled = false;
            txtGuid.Enabled = false;
            oldBtime = e.Values["btime"].ToString();
            oldEtime = e.Values["etime"].ToString();
            oldDateB = Convert.ToDateTime(e.Values["BDATE"]);
            oldHcode = e.Values["h_code"].ToString();
        }

        public static string GetUnLockYYMM(DateTime date)
        {
            Sal.SalaryMDDataContext db = new Sal.SalaryMDDataContext();
            var sql = from a in db.DATA_PA where a.DATA_PASS >= date select a;
            var gg = from a in sql.ToList() orderby a.DATA_PASS select new SalaryDate(a.DATA_PASS).YYMM;
            var orderList = gg.Distinct();
            SalaryDate sd = new SalaryDate(date);
            sd = sd.GetNextSalaryDate();
            while (orderList.Contains(sd.YYMM))//如果列表中有這筆計薪年月，就在往下個月
                sd = sd.GetNextSalaryDate();
            return sd.YYMM;

        }
        bool IsLockedYYMM(DateTime date)
        {
            dcAttDataContext db = new dcAttDataContext();
            var sql = from a in db.DATA_PASS where a.DATA_PASS1 >= date select a;
            var gg = from a in sql.ToList() orderby a.DATA_PASS1 select new SalaryDate(a.DATA_PASS1).YYMM;
            var orderList = gg.Distinct();
            SalaryDate sd = new SalaryDate(date);
            sd = sd.GetNextSalaryDate();
            while (orderList.Contains(sd.YYMM))//如果列表中有這筆計薪年月，就在往下個月
                return true;
            return false;

        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            lblSum.Text = Sal.Function.ColumnsSum(dataGridView1, e.ColumnIndex);
            CheckAbsHrs();
        }


        private void fullDataCtrl1_AfterCancel(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            dataGridView3.DataSource = Sal.Function.GetAttend(ptxNobr.Text, Convert.ToDateTime(txtDateB.Text), Convert.ToDateTime(txtDateE.Text));
            this.dsAtt.ATTCARD.Clear();
        }

        private void dataGridView3_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null && dataGridView1.CurrentRow.Cells[0].Value.ToString().Trim().Length > 0)
            {
                string nobr = dataGridView1.CurrentRow.Cells[0].Value.ToString();

                //if (nobr.Trim().Length > 0 && dataGridView3.CurrentRow.Selected == true && dataGridView3.CurrentRow.Cells[0].Value.ToString().Trim().Length > 0)
                if (nobr.Trim().Length > 0 && dataGridView3.CurrentCell.Value != null && dataGridView3.CurrentCell.Value.ToString().Length > 0)
                {
                    DateTime adate = Convert.ToDateTime(dataGridView3.CurrentRow.Cells[0].Value);

                    if (adate != null)
                    {
                        this.dsAtt.ATTCARD.Clear();
                        dcViewDataContext dv = new dcViewDataContext();
                        var sql = from ac in dv.V_FRM26 where ac.NOBR == nobr && ac.ADATE == adate select ac;
                        this.dsAtt.ATTCARD.FillData(dv.GetCommand(sql));
                    }
                }
            }
        }
        public static bool AutoABSD(string Nobr, string Hcode, DateTime dDate, string guid, decimal AbsHours, bool OverWrite = false,string Original_Hcode ="")
        {
            if (string.IsNullOrEmpty(Original_Hcode))
                Original_Hcode = Hcode;
            var myDB = new JBModule.Data.Linq.HrDBDataContext();
            var hcodeCheck = (from a in myDB.HCODE where (a.CHE || a.FLAG == "X") && a.HTYPE.Trim().Length > 0 && a.H_CODE == Hcode select a).FirstOrDefault();
            DateTime BDate = DateTime.MaxValue;
            DateTime EDate = DateTime.MinValue;

            if (guid.Trim().Length == 0) return false;
            //取出已存在的ABSD
            var absdSQL = from a in myDB.ABSD where a.ABSSUBTRACT == guid select a;
            if (!OverWrite)
                if (absdSQL.Any()) return true;//有資料就跳出
            //取出與ABSD有關的ABS(得)
            var abstList = (from a in myDB.ABS
                            join h in myDB.HCODE on a.H_CODE equals h.H_CODE
                            where (from b in absdSQL where b.ABSADD == a.Guid select 1).Any()
                            select new { abs = a, htype = h.HTYPE }).ToList();
            var hcodeSql = (from a in myDB.HCODE where a.H_CODE == Original_Hcode select a).FirstOrDefault();
            string advABSDexpire = string.Empty;
            foreach (var it in absdSQL)//先清掉舊時數
            {
                var abst = from a in abstList where a.abs.Guid == it.ABSADD select a;
                foreach (var itm in abst)
                {
                    if (hcodeSql != null && (hcodeSql.FLAG == "X" || itm.htype != hcodeSql.HTYPE))
                    {
                        if (itm.htype != hcodeSql.HTYPE) advABSDexpire = itm.abs.Guid;
                        itm.abs.LeaveHours += it.USEHOUR;
                        BDate = itm.abs.BDATE < BDate ? itm.abs.BDATE : BDate;
                        EDate = itm.abs.EDATE > EDate ? itm.abs.EDATE : EDate;
                    }
                    else
                        itm.abs.LeaveHours -= it.USEHOUR;
                    itm.abs.Balance = itm.abs.TOL_HOURS - itm.abs.LeaveHours;
                }
            }
            myDB.ABSD.DeleteAllOnSubmit(absdSQL);
            BDate = BDate == DateTime.MaxValue ? dDate : BDate;
            EDate = EDate == DateTime.MinValue ? dDate : EDate;
            if (hcodeCheck != null)
            {
                //取出有效得假
                var sql = from a in myDB.ABS
                          join b in myDB.HCODE on a.H_CODE equals b.H_CODE
                          where b.FLAG == "+"
                          && a.NOBR == Nobr
                          &&
                          (//借假須追朔至原沖銷得假，無法單由請假日期去找
                            (
                              (hcodeSql.FLAG == "X" ? BDate == a.BDATE && EDate == a.EDATE : dDate >= a.BDATE && dDate <= a.EDATE)
                              &&
                              (from c in myDB.HCODE where c.HTYPE == b.HTYPE && c.H_CODE == Hcode && c.HTYPE.Trim().Length > 0 select 1).Any()
                            )
                            || a.Guid == advABSDexpire //如果為借假產生的請假(失效)須追朔原借假
                          )
                          orderby b.SORT, a.EDATE, a.BDATE
                          select a;
                decimal Hrs = AbsHours;
                decimal XHrs = AbsHours;
                foreach (var it in sql)
                {
                    decimal useHrs = it.LeaveHours.GetValueOrDefault(0);
                    decimal Balance = it.TOL_HOURS - useHrs;

                    if (hcodeCheck.FLAG == "X" || it.Guid == advABSDexpire)
                    {
                        decimal absHrs = XHrs;
                        if (XHrs > useHrs)//沖假大於已請
                            absHrs = useHrs;
                        if (absHrs == 0) continue;
                        insertABSD(myDB, it, guid, absHrs);
                        if (hcodeCheck.FLAG == "X") Hrs -= absHrs;
                        it.LeaveHours -= absHrs;
                    }
                    else if (Balance > 0 && Hrs > 0)//還有剩餘
                    {
                        decimal absHrs = Hrs;
                        if (Hrs > Balance)//請假大於剩餘
                            absHrs = Balance;
                        if (absHrs == 0) continue;
                        insertABSD(myDB, it, guid, absHrs);
                        Hrs -= absHrs;
                        it.LeaveHours += absHrs;
                    }
                    it.Balance = it.TOL_HOURS - it.LeaveHours;
                }
                if (Hrs > 0)
                    return false;//時數不足
            }
            myDB.SubmitChanges();
            return true;
        }
        public static bool ResetABSD(string Nobr, string Hcode, DateTime dDate, string guid, decimal AbsHours, bool reset = false)
        {
            var myDB = new JBModule.Data.Linq.HrDBDataContext();
            var hcodeCheck = from a in myDB.HCODE where a.CHE && a.HTYPE.Trim().Length > 0 && a.H_CODE == Hcode select 1;
            if (!hcodeCheck.Any()) return true;//若不是
            if (guid.Trim().Length == 0) return false;
            //取出已存在的ABSD
            var absdSQL = from a in myDB.ABSD where a.ABSSUBTRACT == guid select a;
            //if (!true)
            //    if (absdSQL.Any()) return false;//有資料就跳出
            //取出與ABSD有關的ABS(得)
            var abstList = (from a in myDB.ABS where (from b in absdSQL where b.ABSADD == a.Guid select 1).Any() select a).ToList();
            foreach (var it in absdSQL)//先清掉舊時數
            {
                var abst = from a in abstList where a.Guid == it.ABSADD select a;
                foreach (var itm in abst)
                {
                    itm.LeaveHours -= it.USEHOUR;
                    itm.Balance = itm.TOL_HOURS - itm.LeaveHours;
                }
            }
            myDB.ABSD.DeleteAllOnSubmit(absdSQL);


            //取出有效得假
            if (!reset)
            {
                var sql = from a in myDB.ABS
                          join b in myDB.HCODE on a.H_CODE equals b.H_CODE
                          where b.FLAG == "+"
                          && a.NOBR == Nobr
                          && dDate >= a.BDATE && dDate <= a.EDATE
                          && (from c in myDB.HCODE where c.HTYPE == b.HTYPE && c.H_CODE == Hcode && c.HTYPE.Trim().Length > 0 select 1).Any()
                          orderby a.EDATE, b.SORT
                          select a;
                decimal Hrs = AbsHours;
                foreach (var it in sql)
                {
                    decimal useHrs = it.LeaveHours.GetValueOrDefault(0);
                    decimal Balance = it.TOL_HOURS - useHrs;
                    var absSQL = from a in myDB.ABSD where a.ABSSUBTRACT == guid && a.ABSADD != it.Guid select a;
                    if (absSQL.Any())
                        Hrs -= absSQL.Sum(p => p.USEHOUR);
                    if (Balance > 0 && Hrs > 0)//還有剩餘
                    {
                        decimal absHrs = Hrs;
                        if (Hrs > Balance)//請假大於剩餘
                            absHrs = Balance;
                        if (absHrs == 0) continue;
                        insertABSD(myDB, it, guid, absHrs);
                        //JBModule.Data.Linq.ABSD absd = new JBModule.Data.Linq.ABSD();
                        //absd.ABSADD = it.Guid;
                        //absd.ABSSUBTRACT = guid;
                        //absd.KEY_DATE = DateTime.Now;
                        //absd.KEY_MAN = MainForm.USER_NAME;
                        //absd.USEHOUR = absHrs;
                        //myDB.ABSD.InsertOnSubmit(absd);
                        Hrs -= absHrs;
                        it.LeaveHours += absHrs;
                    }
                    it.Balance = it.TOL_HOURS - it.LeaveHours;
                }
                if (Hrs > 0)
                    return false;//時數不足
            }
            else
            {//拿原本的來沖
                var sql = from a in abstList
                          join b in myDB.HCODE.ToList() on a.H_CODE equals b.H_CODE
                          where b.FLAG == "+"
                          && a.NOBR == Nobr
                              //&& dDate >= a.BDATE && dDate <= a.EDATE
                          && (from c in myDB.HCODE where c.HTYPE == b.HTYPE && c.H_CODE == Hcode && c.HTYPE.Trim().Length > 0 select 1).Any()
                          orderby a.EDATE, b.SORT
                          select a;
                decimal Hrs = AbsHours;
                foreach (var it in sql)
                {
                    decimal useHrs = it.LeaveHours.GetValueOrDefault(0);
                    decimal Balance = it.TOL_HOURS - useHrs;

                    if (Balance > 0 && Hrs > 0)//還有剩餘
                    {
                        decimal absHrs = Hrs;
                        if (Hrs > Balance)//請假大於剩餘
                            absHrs = Balance;
                        if (absHrs == 0) continue;
                        insertABSD(myDB, it, guid, absHrs);
                        //JBModule.Data.Linq.ABSD absd = new JBModule.Data.Linq.ABSD();
                        //absd.ABSADD = it.Guid;
                        //absd.ABSSUBTRACT = guid;
                        //absd.KEY_DATE = DateTime.Now;
                        //absd.KEY_MAN = MainForm.USER_NAME;
                        //absd.USEHOUR = absHrs;
                        //myDB.ABSD.InsertOnSubmit(absd);
                        Hrs -= absHrs;
                        it.LeaveHours += absHrs;
                    }
                    it.Balance = it.TOL_HOURS - it.LeaveHours;
                }
                //if (Hrs > 0)
                //    return false;//時數不足
            }
            //myDB.ExecuteCommand("DELETE ABSD WHERE ABSSUBTRACT={0}", guid);
            myDB.SubmitChanges();
            return true;
        }
        public static bool AutoABSDWithForce(string Nobr, string Hcode, DateTime dDate, string guid, decimal AbsHours)
        {
            var myDB = new JBModule.Data.Linq.HrDBDataContext();
            if (guid.Trim().Length == 0) return false;

            var hcodeCheck = (from a in myDB.HCODE where a.FLAG == "X" && a.HTYPE.Trim().Length > 0 && a.H_CODE == Hcode select a).FirstOrDefault();
            DateTime BDate = DateTime.MaxValue;
            DateTime EDate = DateTime.MinValue;

            //取出已存在的ABSD
            var absdSQL = from a in myDB.ABSD where a.ABSSUBTRACT == guid select a;
            //取出與ABSD有關的ABS(得)
            var abstList = (from a in myDB.ABS
                            join h in myDB.HCODE on a.H_CODE equals h.H_CODE
                            where (from b in absdSQL where b.ABSADD == a.Guid select 1).Any()
                            select new { abs = a, htype = h.HTYPE }).ToList();
            var hcodeSql = (from a in myDB.HCODE where a.H_CODE == Hcode select a).FirstOrDefault();
            string advABSDexpire = string.Empty;
            foreach (var it in absdSQL)//先清掉舊時數
            {
                var abst = from a in abstList where a.abs.Guid == it.ABSADD select a;
                foreach (var itm in abst)
                {
                    if (hcodeSql != null && (hcodeSql.FLAG == "X" || itm.htype != hcodeSql.HTYPE))
                    {
                        if (itm.htype != hcodeSql.HTYPE) advABSDexpire = itm.abs.Guid;
                        itm.abs.LeaveHours += it.USEHOUR;
                        BDate = itm.abs.BDATE < BDate ? itm.abs.BDATE : BDate;
                        EDate = itm.abs.EDATE > EDate ? itm.abs.EDATE : EDate;
                    }
                    else
                        itm.abs.LeaveHours -= it.USEHOUR;
                    itm.abs.Balance = itm.abs.TOL_HOURS - itm.abs.LeaveHours;
                }
            }
            myDB.ABSD.DeleteAllOnSubmit(absdSQL);
            BDate = BDate == DateTime.MaxValue ? dDate : BDate;
            EDate = EDate == DateTime.MinValue ? dDate : EDate;

            var sql = from a in myDB.ABS
                      join b in myDB.HCODE on a.H_CODE equals b.H_CODE
                      where b.FLAG == "+"
                      && a.NOBR == Nobr
                      &&
                      (//借假須追朔至原沖銷得假，無法單由請假日期去找
                        (
                          ((hcodeCheck != null && hcodeCheck.FLAG == "X") ? BDate == a.BDATE && EDate == a.EDATE : dDate >= a.BDATE && dDate <= a.EDATE) 
                          && 
                          (from c in myDB.HCODE where c.HTYPE == b.HTYPE && c.H_CODE == Hcode && c.HTYPE.Trim().Length > 0 select 1).Any()
                        )
                        || a.Guid == advABSDexpire //如果為借假產生的請假(失效)須追朔原借假
                      )
                      orderby b.SORT, a.EDATE, a.BDATE
                      select a;
            //var absdSQL = (from a in myDB.ABSD where a.ABSSUBTRACT == guid select a);
            decimal Hrs = AbsHours;
            foreach (var it in sql)
            {
                var absdOfEntitle = from a in absdSQL where a.ABSADD == it.Guid select a;
                decimal current = 0;
                if (absdOfEntitle.Any()) current = absdOfEntitle.Sum(pp => pp.USEHOUR);
                //if (Hrs <= 0) break;
                if ((hcodeCheck != null && hcodeCheck.FLAG == "X") || it.Guid == advABSDexpire)
                {
                    it.LeaveHours += current;
                    decimal useHrs = it.LeaveHours.GetValueOrDefault(0);
                    //if (qq.Any()) useHrs = qq.Sum(p => p.USEHOUR);
                    decimal Balance = it.TOL_HOURS - useHrs;
                    decimal absHrs = Hrs;
                    insertABSD(myDB, it, guid, absHrs);
                    if ((hcodeCheck != null && hcodeCheck.FLAG == "X")) Hrs -= absHrs;
                    it.LeaveHours -= absHrs;
                }
                else
                {
                    it.LeaveHours -= current;//扣掉原本的
                    //var qq = from a in myDB.ABSD where a.ABSADD == it.SERNO && a.ABSSUBTRACT != Serno select a;
                    decimal useHrs = it.LeaveHours.GetValueOrDefault(0);
                    //if (qq.Any()) useHrs = qq.Sum(p => p.USEHOUR);
                    decimal Balance = it.TOL_HOURS - useHrs;

                    if (Balance > 0 && Hrs > 0)//還有剩餘
                    {
                        decimal absHrs = Hrs;
                        if (Hrs > Balance)//請假大於剩餘
                            absHrs = Balance;
                        if (absHrs == 0) continue;
                        insertABSD(myDB, it, guid, absHrs);
                        Hrs -= absHrs;
                        it.LeaveHours += absHrs;
                    }
                }
                it.Balance = it.TOL_HOURS - it.LeaveHours;
            }
            if (Hrs > 0)//沖不夠
            {
                sql = from a in myDB.ABS
                      join b in myDB.HCODE on a.H_CODE equals b.H_CODE
                      where b.FLAG == "+"
                      && a.NOBR == Nobr
                      && 
                      (
                        (dDate < a.BDATE //先找未來生效，因為不再此區間內有效，所以先不管資料會不會有未存入的問題
                        && (from c in myDB.HCODE where c.HTYPE == b.HTYPE && c.H_CODE == Hcode && c.HTYPE.Trim().Length > 0 select 1).Any())
                        || a.Guid == advABSDexpire
                      )
                      select a;
                foreach (var it in sql)
                {
                    var absdOfEntitle = from a in absdSQL where a.ABSADD == it.Guid select a;
                    decimal current = 0;
                    if (absdOfEntitle.Any()) current = absdOfEntitle.Sum(pp => pp.USEHOUR);
                    //if (Hrs <= 0) break;

                    if ((hcodeCheck != null && hcodeCheck.FLAG == "X") || it.Guid == advABSDexpire)
                    {
                        it.LeaveHours += current;
                        decimal useHrs = it.LeaveHours.GetValueOrDefault(0);
                        //if (qq.Any()) useHrs = qq.Sum(p => p.USEHOUR);
                        decimal Balance = it.TOL_HOURS - useHrs;
                        decimal absHrs = Hrs;
                        insertABSD(myDB, it, guid, absHrs);
                        if ((hcodeCheck != null && hcodeCheck.FLAG == "X")) Hrs -= absHrs;
                        it.LeaveHours -= absHrs;
                    }
                    else
                    {
                        it.LeaveHours -= current;//扣掉原本的
                                                 //var qq = from a in myDB.ABSD where a.ABSADD == it.SERNO && a.ABSSUBTRACT != Serno select a;
                        decimal useHrs = it.LeaveHours.GetValueOrDefault(0);
                        //if (qq.Any()) useHrs = qq.Sum(p => p.USEHOUR);
                        decimal Balance = it.TOL_HOURS - useHrs;

                        if (Balance > 0 && Hrs > 0)//還有剩餘
                        {
                            decimal absHrs = Hrs;
                            if (Hrs > Balance)//請假大於剩餘
                                absHrs = Balance;
                            if (absHrs == 0) continue;
                            insertABSD(myDB, it, guid, absHrs);
                            Hrs -= absHrs;
                            it.LeaveHours += absHrs;
                        }
                    }
                    it.Balance = it.TOL_HOURS - it.LeaveHours;
                }
                if (Hrs > 0)//還是沖不夠
                {
                    sql = from a in myDB.ABS
                          join b in myDB.HCODE on a.H_CODE equals b.H_CODE
                          where b.FLAG == "+"
                          && a.NOBR == Nobr
                          && 
                          (
                            (dDate > a.EDATE //先找過去失效，因為不再此區間內有效，所以先不管資料會不會有未存入的問題
                            && (from c in myDB.HCODE where c.HTYPE == b.HTYPE && c.H_CODE == Hcode && c.HTYPE.Trim().Length > 0 select 1).Any())
                            || a.Guid == advABSDexpire
                          )
                          select a;
                    foreach (var it in sql)
                    {
                        var absdOfEntitle = from a in absdSQL where a.ABSADD == it.Guid select a;
                        decimal current = 0;
                        if (absdOfEntitle.Any()) current = absdOfEntitle.Sum(pp => pp.USEHOUR);

                        if ((hcodeCheck != null && hcodeCheck.FLAG == "X") || it.Guid == advABSDexpire)
                        {
                            it.LeaveHours += current;
                            decimal useHrs = it.LeaveHours.GetValueOrDefault(0);
                            //if (qq.Any()) useHrs = qq.Sum(p => p.USEHOUR);
                            decimal Balance = it.TOL_HOURS - useHrs;
                            decimal absHrs = Hrs;
                            insertABSD(myDB, it, guid, absHrs);
                            if ((hcodeCheck != null && hcodeCheck.FLAG == "X")) Hrs -= absHrs;
                            it.LeaveHours -= absHrs;
                        }
                        else
                        {
                            //if (Hrs <= 0) break;
                            it.LeaveHours -= current;//扣掉原本的
                                                     //var qq = from a in myDB.ABSD where a.ABSADD == it.SERNO && a.ABSSUBTRACT != Serno select a;
                            decimal useHrs = it.LeaveHours.GetValueOrDefault(0);
                            //if (qq.Any()) useHrs = qq.Sum(p => p.USEHOUR);
                            decimal Balance = it.TOL_HOURS - useHrs;

                            if (Balance > 0 && Hrs > 0)//還有剩餘
                            {
                                decimal absHrs = Hrs;
                                if (Hrs > Balance)//請假大於剩餘
                                    absHrs = Balance;
                                if (absHrs == 0) continue;
                                insertABSD(myDB, it, guid, absHrs);
                                Hrs -= absHrs;
                                it.LeaveHours += absHrs;
                            }
                        }
                        it.Balance = it.TOL_HOURS - it.LeaveHours;
                    }
                    return false;//時數不足
                }
                //return false;//時數不足
            }
            //myDB.ExecuteCommand("DELETE ABSD WHERE ABSSUBTRACT={0}", guid);
            myDB.SubmitChanges();
            return true;
        }
        private static void insertABSD(JBModule.Data.Linq.HrDBDataContext db, JBModule.Data.Linq.ABS ABSADD, string guid, decimal UseHrs)
        {
            var rABSD = new JBModule.Data.Linq.ABSD();
            rABSD.ABSADD = ABSADD.Guid;
            rABSD.ABSSUBTRACT = guid;
            rABSD.USEHOUR = UseHrs;
            rABSD.KEY_MAN = MainForm.USER_NAME;
            rABSD.KEY_DATE = DateTime.Now;
            db.ABSD.InsertOnSubmit(rABSD);
        }
        private void buttonABSD_Click(object sender, EventArgs e)
        {
            if (fullDataCtrl1.EditType == JBControls.FullDataCtrl.EEditType.None)
            {
                if (ptxHcode.SelectedValue != null && ptxNobr.Text.Trim().Length > 0)
                {
                    string hcode = ptxHcode.SelectedValue.ToString().Trim();
                    var sql = from a in HcodeList where a.H_CODE == hcode select a;
                    if (sql.Any())
                    {
                        var r = ((DataRowView)aBSBindingSource.Current).Row as dsAtt.ABSRow;
                        if (r != null)
                        {
                            var myDB = new JBModule.Data.Linq.HrDBDataContext();
                            var guid = r.Guid;
                            var abssql = from a in myDB.ABS
                                         join h in myDB.HCODE on a.H_CODE equals h.H_CODE
                                         join ht in myDB.HcodeType on h.HTYPE equals ht.HTYPE
                                         select new { ABS = a, Flag = h.FLAG, HCodeName = h.H_NAME, Htype = h.HTYPE };

                            //var qq = from a in myDB.ABSD
                            //         join b in myDB.ABS on a.ABSADD equals b.Guid into ab
                            //         from abs in ab.DefaultIfEmpty()
                            //         where a.ABSSUBTRACT == guid
                            //         select new { 開始日期 = abs.BDATE, 結束日期 = abs.EDATE, 時數 = a.USEHOUR, 備註 = abs.NOTE };

                            var qq = from a in myDB.ABSD
                                     join add in abssql on a.ABSADD equals add.ABS.Guid into add1
                                     from add in add1.DefaultIfEmpty()
                                     join sub in abssql on a.ABSSUBTRACT equals sub.ABS.Guid into sub1
                                     from sub in sub1.DefaultIfEmpty()
                                     where a.ABSSUBTRACT == guid
                                     select new
                                     {
                                         屬性 = add != null ? add.HCodeName : "",
                                         開始日期 = add != null ? add.ABS.BDATE : new DateTime(1900, 1, 1),
                                         結束日期 = add != null ? add.ABS.EDATE : new DateTime(1900, 1, 1),
                                         時數 = a.USEHOUR,
                                         備註 = add.ABS.NOTE
                                     };

                            Sal.PreviewForm frm = new Sal.PreviewForm();
                            frm.DataTable = qq.CopyToDataTable();
                            frm.StartPosition = FormStartPosition.CenterScreen;
                            frm.Width = 800;
                            frm.ShowDialog();

                        }
                    }
                }
            }
            //else
            //{
            //    FRM_ABSD frm = new FRM_ABSD(ptxNobr.Text, txtSerNO.Text, Convert.ToDateTime(txtDateB.Text), Convert.ToDecimal(txtTotalHours.Text));
            //    frm.StartPosition = FormStartPosition.CenterScreen;
            //    frm.ShowDialog();
            //}
        }

        private void buttonCheckABSD_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否要執行重新沖假?", "警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Cancel) return;
            //var myDB = new JBModule.Data.Linq.HrDBDataContext();
            //foreach (var it in dsAtt.ABS)
            //{
            //    myDB.ExecuteCommand("DELETE ABSD WHERE ABSSUBTRACT={0}", it.Guid);//刪除所有扣假相關ABSD
            //}
            int cc = 0;
            foreach (var it in dsAtt.ABS)
            {
                it.nocalc = false;
                if (checkBoxForce.Checked)
                {
                    if (!AutoABSDWithForce(it.NOBR, it.H_CODE, it.BDATE, it.Guid, it.TOL_HOURS))
                    {
                        cc++;
                        it.nocalc = true;
                    }
                }
                else
                    if (!AutoABSD(it.NOBR, it.H_CODE, it.BDATE, it.Guid, it.TOL_HOURS, checkBoxABSD.Checked))
                    {
                        cc++;
                        it.nocalc = true;
                    }
                aBSTableAdapter.Update(it);
            }
            if (cc == 0)
                MessageBox.Show("沖假資料已完成");
            else
                MessageBox.Show(string.Format("沖假資料已完成，但有{0}筆資料沖假失敗", cc));
        }
        public static List<AbsCheck> GetExistsABS(string Nobr, DateTime DateB, DateTime DateE, string Btime, string Etime, string Hcode, string Guid)
        {
            JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
            //var hcodeSQL = from a in db.HCODE where a.H_CODE == Hcode && new string[] { "1", "3", "5", "7", "9" }.Contains(a.YEAR_REST) select a;
            //if (hcodeSQL.Any()) return new List<AbsCheck>();//不判得假
            var sql = from a in db.ABS
                      join b in db.HCODE on a.H_CODE equals b.H_CODE
                      join c in db.BASE on a.NOBR equals c.NOBR
                      where (b.FLAG == "-" || b.FLAG == "X")//請抓扣假及沖假
                      && a.NOBR == Nobr
                      && a.BDATE.AddHours(Convert.ToInt32(a.BTIME.Substring(0, 2))).AddMinutes(Convert.ToInt32(a.BTIME.Substring(2, 2))) < DateE.AddTime(Etime)
                      && a.EDATE.AddHours(Convert.ToInt32(a.ETIME.Substring(0, 2))).AddMinutes(Convert.ToInt32(a.ETIME.Substring(2, 2))) > DateB.AddTime(Btime)
                      && a.Guid != Guid
                      //&& a.BTIME.CompareTo(Etime) < 0 && a.ETIME.CompareTo(Btime) > 0//有交集(僅頭尾相等不計)
                      //&& !(a.BTIME == Btime && a.ETIME == Etime && a.H_CODE == Hcode)//不包含自己
                      select new AbsCheck { Nobr = a.NOBR, NameC = c.NAME_C, Hcode = b.H_CODE, Hname = b.H_NAME, Btime = a.BTIME, Etime = a.ETIME, DateB = a.BDATE };
            //var sql1 = from a in db.ABS1
            //           join b in db.HCODE on a.H_CODE equals b.H_CODE
            //           join c in db.BASE on a.NOBR equals c.NOBR
            //           where !new string[] { "1", "3", "5", "7", "9" }.Contains(b.YEAR_REST)//請抓扣假
            //           && a.NOBR == Nobr
            //           && a.BDATE.AddHours(Convert.ToInt32(a.BTIME.Substring(0, 2))).AddMinutes(Convert.ToInt32(a.BTIME.Substring(2, 2))) < DateE.AddTime(Etime)
            //           && a.EDATE.AddHours(Convert.ToInt32(a.ETIME.Substring(0, 2))).AddMinutes(Convert.ToInt32(a.ETIME.Substring(2, 2))) > DateB.AddTime(Btime)
            //           //&& a.BTIME.CompareTo(Etime) < 0 && a.ETIME.CompareTo(Btime) > 0//有交集(僅頭尾相等不計)
            //           //&& !(a.BTIME == Btime && a.ETIME == Etime && a.H_CODE == Hcode)//不包含自己
            //           select new AbsCheck { Nobr = a.NOBR, NameC = c.NAME_C, Hcode = b.H_CODE, Hname = b.H_NAME, Btime = a.BTIME, Etime = a.ETIME, DateB = a.BDATE };
            return sql.OrderBy(p => p.DateB).ToList();
        }

        private void buttonCheckFail_Click(object sender, EventArgs e)
        {
            var myDB = new JBModule.Data.Linq.HrDBDataContext();
            var hcodeList = myDB.HCODE.ToList();
            foreach (var it in dsAtt.ABS)
            {
                var hcodeCheck = from a in hcodeList where a.H_CODE == it.H_CODE && (!a.CHE || a.HTYPE.Trim().Length == 0) select 1;
                if (hcodeCheck.Any())
                {
                    it.Delete(); //剔除不檢查以及未設定類別
                    continue;
                }
                if (it.IsGuidNull() || it.Guid.Trim().Length == 0) continue;
                //取出已存在的ABSD
                var absdSQL = from a in myDB.ABSD where a.ABSSUBTRACT == it.Guid select a;
                if (absdSQL.Any())
                {
                    it.Delete();
                    continue;
                }
            }
            dsAtt.ABS.AcceptChanges();
            fullDataCtrl1.Init_Ctrls();
            MessageBox.Show("檢查完成");
        }
        public static string CheckABSD(string Guid, bool IsAdd)
        {
            var db = new JBModule.Data.Linq.HrDBDataContext();
            var sql = from a in db.ABSD select a;
            if (IsAdd) sql = from a in sql where a.ABSADD == Guid select a;
            else sql = from a in sql where a.ABSSUBTRACT == Guid select a;
            if (sql.Any())
            {
                var absd = sql.First();
                if (IsAdd) return absd.ABSSUBTRACT;
                else return absd.ABSADD;
            }
            return "";
        }

        private void fullDataCtrl1_AfterQuery(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            CheckAbsHrs();
        }

        private void fullDataCtrl1_AfterShow(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            CheckAbsHrs();
        }

        private void fullDataCtrl1_BeforeEdit(object sender, JBControls.FullDataCtrl.BeforeEventArgs e)
        {
            if (dataGridView1.CurrentRow != null && dataGridView1.CurrentRow.Cells[0].Value.ToString().Trim().Length > 0)
            {
                String hcode = Convert.ToString(dataGridView1.CurrentRow.Cells[2].Value);
                prehocde = hcode;
            }
        }

        private void bnImport_Click(object sender, EventArgs e)
        {
            JBControls.U_IMPORT frm = new JBControls.U_IMPORT();
            frm.Allow_Repeat_Delete = true;
            frm.Allow_Repeat_Ignore = true;
            frm.Allow_Repeat_Override = true;

            frm.FieldForm = new FRM28IN();
            frm.DataTransfer = new ImportTransferToABS();
            JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();

            frm.DataTransfer.CheckData = new Dictionary<string, List<JBControls.CheckImportData>>();
            frm.DataTransfer.CheckData.Add("假別代碼", db.HCODE.Select(p => new JBControls.CheckImportData { DisplayCode = p.H_CODE_DISP, RealCode = p.H_CODE, DisplayName = p.H_NAME }).ToList());
            frm.DataTransfer.CheckData.Add("員工編號", this.dsBas.BASE.Select(p => new JBControls.CheckImportData { DisplayCode = p.NOBR, RealCode = p.NOBR, DisplayName = p.NAME_C }).ToList());

            frm.DataTransfer.ColumnList = new Dictionary<string, Type>();
            frm.DataTransfer.ColumnList.Add("計薪年月", typeof(string));
            frm.DataTransfer.ColumnList.Add("員工編號", typeof(string));
            frm.DataTransfer.ColumnList.Add("員工姓名", typeof(string));
            frm.DataTransfer.ColumnList.Add("請假日期", typeof(DateTime));
            frm.DataTransfer.ColumnList.Add("請假起時", typeof(string));
            frm.DataTransfer.ColumnList.Add("請假迄時", typeof(string));
            frm.DataTransfer.ColumnList.Add("請假時數/天數", typeof(decimal));
            frm.DataTransfer.ColumnList.Add("假別代碼", typeof(string));
            frm.DataTransfer.ColumnList.Add("假別名稱", typeof(string));
            frm.DataTransfer.ColumnList.Add("備註", typeof(string));
            frm.DataTransfer.ColumnList.Add("警告", typeof(string));
            frm.DataTransfer.ColumnList.Add("錯誤註記", typeof(string));

            //frm.DataTransfer.UnMustColumnList = new List<string>();

            frm.ShowDialog();
        }

        private void buttonGen_Click(object sender, EventArgs e)
        {
            JBControls.U_PATCH frm = new JBControls.U_PATCH();
            //frm.Allow_Repeat_Delete = true;
            //frm.Allow_Repeat_Ignore = true;
            //frm.Allow_Repeat_Override = true;

            frm.FieldForm = new FRM28P();
            frm.DataTransfer = new PatchTransferToABS<FRM28P_RESULT>();
            JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();

            frm.DataTransfer.CheckData = new Dictionary<string, List<JBControls.CheckImportData>>();
            frm.DataTransfer.CheckData.Add("假別代碼", db.HCODE.Select(p => new JBControls.CheckImportData { DisplayCode = p.H_CODE_DISP, RealCode = p.H_CODE, DisplayName = p.H_NAME }).ToList());
            frm.DataTransfer.CheckData.Add("員工編號", this.dsBas.BASE.Select(p => new JBControls.CheckImportData { DisplayCode = p.NOBR, RealCode = p.NOBR, DisplayName = p.NAME_C }).ToList());

            frm.DataTransfer.ColumnList = new Dictionary<string, Tuple<string, Type, string>>();
            //frm.DataTransfer.ColumnList.Add("YYMM", new Tuple<string, Type, string>("計薪年月", typeof(string), ""));
            frm.DataTransfer.ColumnList.Add("EmployeeID", new Tuple<string, Type, string>("員工編號", typeof(string), ""));
            frm.DataTransfer.ColumnList.Add("EmployeeName", new Tuple<string, Type, string>("員工姓名", typeof(string), ""));
            frm.DataTransfer.ColumnList.Add("AttendDate", new Tuple<string, Type, string>("請假日期", typeof(DateTime), ""));
            frm.DataTransfer.ColumnList.Add("BeginTime", new Tuple<string, Type, string>("請假起時", typeof(string), "HHmm"));
            frm.DataTransfer.ColumnList.Add("EndTime", new Tuple<string, Type, string>("請假迄時", typeof(string), "HHmm"));
            frm.DataTransfer.ColumnList.Add("Taken", new Tuple<string, Type, string>("請假時數/天數", typeof(decimal), ""));
            frm.DataTransfer.ColumnList.Add("HcodeName1", new Tuple<string, Type, string>("假別名稱1", typeof(string), ""));
            frm.DataTransfer.ColumnList.Add("HcodeName2", new Tuple<string, Type, string>("假別名稱2", typeof(string), ""));
            frm.DataTransfer.ColumnList.Add("HcodeName3", new Tuple<string, Type, string>("假別名稱3", typeof(string), ""));
            frm.DataTransfer.ColumnList.Add("Remark", new Tuple<string, Type, string>("備註", typeof(string), ""));
            frm.DataTransfer.ColumnList.Add("WarningMsg", new Tuple<string, Type, string>("警告", typeof(string), ""));
            frm.DataTransfer.ColumnList.Add("ErrorMsg", new Tuple<string, Type, string>("錯誤註記", typeof(string), ""));
            frm.Text = "FRM28P-請假匯入";
            //frm.DataTransfer.UnMustColumnList = new List<string>();

            frm.ShowDialog();
        }
    }
}
