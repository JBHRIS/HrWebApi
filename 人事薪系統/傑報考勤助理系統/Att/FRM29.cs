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
    public partial class FRM29 : JBControls.JBForm
    {
        public FRM29()
        {
            InitializeComponent();
        }

        object[] PARMS = null;
        JBModule.Data.Linq.HrDBDataContext linqdb = new JBModule.Data.Linq.HrDBDataContext();
        List<string> CheckOnWorkOtrcd = new List<string>();
        string oldBtime, oldEtime, oldHcode;
        DateTime oldDateB;
        CheckControl cc;//必要欄位檢查
        JBModule.Data.ApplicationConfigSettings AppConfig = new JBModule.Data.ApplicationConfigSettings("FRM211", MainForm.COMPANY);
        private void FRM29_Load(object sender, EventArgs e)
        {
            Sal.Function.SetAvaliableVBase(this.mainDS.V_BASE);
            cc = new CheckControl();//必要欄位檢查
            cc.AddControl(cbxOtDepts);
            //cc.AddControl(cbxOtRCD);
            cc.AddControl(cbxOtRote);
            txtYymm.Enabled = false;
            txtSerNO.Enabled = false;
            chkEat.Enabled = false;
            chkNotModi.Enabled = false;
            chkRes.Enabled = false;
            chkSysCreat.Enabled = false;
            chkSysCreat1.Enabled = false;
            chkSysCreate.Enabled = false;
            //checkBox1.Enabled = false;
            //checkBox2.Enabled = false;
            //this.oTRCDTableAdapter.Fill(this.dsAtt.OTRCD, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN);
            //this.dEPTSTableAdapter.Fill(this.dsBas.DEPTS);
            //this.rOTETableAdapter.Fill(this.dsAtt.ROTE, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN);
            SystemFunction.SetComboBoxItems(cbxOtDepts, CodeFunction.GetDepts(), true);
            SystemFunction.SetComboBoxItems(cbxOtRCD, CodeFunction.GetOtrcd(), true);
            SystemFunction.SetComboBoxItems(cbxOtRote, CodeFunction.GetRote(), true);
            SystemFunction.SetComboBoxItems(cbxRote, CodeFunction.GetRote(), true);
            SystemFunction.SetComboBoxItems(cbxOtRate, CodeFunction.GetOtRatecd(), true);
            this.aTTENDTableAdapter.FillByInit(this.dsAtt.ATTEND);
            this.oTTableAdapter.FillByInt(this.dsAtt.OT);
            CheckOnWorkOtrcd = (from a in new JBModule.Data.Linq.HrDBDataContext().OTRCD where a.NOCALC == null || !a.NOCALC.Value select a.OTRCD1).ToList();
            CheckOnWorkOtrcd.Add("");
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

            fullDataCtrl1.DataAdapter = oTTableAdapter;
            fullDataCtrl1.Init_Ctrls();
            dataGridView3.DataSource = Sal.Function.GetAttend(ptxNobr.Text, Convert.ToDateTime(txtBdate.Text), Convert.ToDateTime(txtBdate.Text));

            AppConfig = new JBModule.Data.ApplicationConfigSettings("FRM211", MainForm.COMPANY);
        }
        private void fullDataCtrl1_AfterAdd(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            SetDisable();

            txtBdate.Text = Sal.Core.SalaryDate.DateString();
            cbxOtRCD.SelectedValue = "";
            try
            {
                DateTime adate = DateTime.Parse(txtBdate.Text);
                txtAdate.Text = Sal.Function.GetDate(new DateTime(adate.Year, 12, 31));//有效日到當年年底
                //txtAdate.Text = Sal.Function.GetDate(new DateTime(adate.AddMonths(1).Year, adate.AddMonths(2).Month, 1).AddDays(-1));//有效日到次月月底

            }
            catch
            {
                txtAdate.Text = txtBdate.Text;
            }
            dataGridView3.DataSource = Sal.Function.GetAttend(ptxNobr.Text, Convert.ToDateTime(txtBdate.Text), Convert.ToDateTime(txtBdate.Text));
            ptxNobr.Focus();

        }
        private void fullDataCtrl1_BeforeSave(object sender, JBControls.FullDataCtrl.BeforeEventArgs e)
        {
            //if (Sal.Function.IsAttendLocked(Convert.ToDateTime(txtBdate.Text), ptxNobr.Text))
            //{
            //    //鎖定時修改，不可以修改
            //    MessageBox.Show(Resources.Att.AttendDateLocked, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            //    e.Cancel = true;
            //    return;
            //}
            var ctrl = cc.CheckRequiredFields();//必要欄位檢查
            if (ctrl != null)//必要欄位檢查
            {
                MessageBox.Show("必要欄位未輸入", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ctrl.Focus();
                e.Cancel = true;
                return;
            }
            if (txtOtTimeB.Text.Trim().Length < 4 || txtOtTimeE.Text.Trim().Length < 4)
            {
                MessageBox.Show("起迄時間輸入不完整", Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                e.Cancel = true;
                return;
            }

            //if (FormatValidate.CheckTimeFormat(txtOtTimeB.Text.Trim()) != true || FormatValidate.CheckTimeFormat(txtOtTimeE.Text.Trim()) != true)
            //{
            //    MessageBox.Show("起迄時間輸入錯誤", Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            //    e.Cancel = true;
            //    if (FormatValidate.CheckTimeFormat(txtOtTimeE.Text.Trim()) != true)
            //        txtOtTimeE.Focus();
            //    if (FormatValidate.CheckTimeFormat(txtOtTimeB.Text.Trim()) != true)
            //        txtOtTimeB.Focus();
            //    return;
            //}

            if (FormatValidate.CheckYearMonthFormat(txtYymm.Text.Trim()) != true)
            {
                MessageBox.Show("計薪年月格式輸入錯誤", Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                e.Cancel = true;
                txtYymm.Focus();
                return;
            }

            if (Convert.ToDecimal(txtOtHours.Text) > 0 && Convert.ToDecimal(txtRestHours.Text) > 0)
            {
                MessageBox.Show("加班時數及補休時數只能擇一申請", Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                e.Cancel = true;
                return;
            }
            if (cbxOtRote.SelectedValue.ToString() == "00")
            {
                MessageBox.Show("加班班別不可以選擇假日班，請選擇適用該加班時段津貼的班別", Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                e.Cancel = true;
                return;
            }
            if (Sal.Function.IsAttendLocked(Convert.ToDateTime(txtBdate.Text), ptxNobr.Text))
            {
                if (fullDataCtrl1.EditType == JBControls.FullDataCtrl.EEditType.Add)
                {//鎖定時新增，移至下個月
                    //e.Values["YYMM"] = GetUnLockYYMM(Convert.ToDateTime(txtDateB.Text));
                    if (txtYymm.Text != FRM28.GetUnLockYYMM(Convert.ToDateTime(txtBdate.Text)))
                    {
                        if (MessageBox.Show(Resources.Att.AttendDateLocked + "," + Resources.Att.YymmMoveToNextMonth, Resources.All.DialogTitle, MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk) == System.Windows.Forms.DialogResult.Cancel)
                        {
                            e.Cancel = true;
                        }
                        else
                        {
                            txtYymm.Text = FRM28.GetUnLockYYMM(Convert.ToDateTime(txtBdate.Text));
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



            if (fullDataCtrl1.EditType == JBControls.FullDataCtrl.EEditType.Add)
            {
                var otData = JBHR.BLL.Att.OverTime.GetExistsOT(ptxNobr.Text, Convert.ToDateTime(e.Values["bdate"]), Convert.ToDateTime(e.Values["bdate"]), e.Values["btime"].ToString(), e.Values["etime"].ToString());
                if (otData.Any())
                {
                    if (MessageBox.Show("申請的時段內已有存在的加班資料" + Environment.NewLine + "按確認顯示查詢影響的資料", Resources.All.DialogTitle, MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk) == System.Windows.Forms.DialogResult.OK)
                    {
                        Sal.PreviewForm frm = new Sal.PreviewForm();
                        frm.DataTable = otData.Select(p => new { 工號 = p.Nobr, 姓名 = p.NameC, 加班日期 = p.DateB, 開始時間 = p.Btime, 結束時間 = p.Etime }).CopyToDataTable();
                        frm.Width = 800;
                        frm.ShowDialog();
                    }
                    e.Cancel = true;
                    return;
                }
            }


            decimal CheckHours = CheckOtHours();
            //需重新檢查加班總時數
            if (CheckHours != Convert.ToDecimal(txtOtHours.Text) + Convert.ToDecimal(txtRestHours.Text))
            {
                //MessageBox.Show("加班總時數不正確(加班總時數" + CheckHours.ToString() + "小時)", Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                if (CheckHours == 0 && CheckOnWorkOtrcd.Contains(cbxOtRCD.SelectedValue.ToString()))
                {
                    JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
                    var sql = from a in db.ROTE where a.ROTE1 == cbxRote.SelectedValue.ToString() select a;
                    if (sql.Any())
                    {
                        if (sql.First().ON_TIME.CompareTo(e.Values["btime"].ToString()) <= 0 && sql.First().OFF_TIME.CompareTo(e.Values["etime"].ToString()) >= 0)//如果申請時間等於上下班時間
                        {
                            MessageBox.Show("申請的時段為上班時間", Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            e.Cancel = true;
                            return;
                        }
                    }
                }
                if (MessageBox.Show("加班總時數不正確(加班總時數" + CheckHours.ToString() + "小時)" + Environment.NewLine + "是否確認存檔", Resources.All.DialogTitle, MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk) != System.Windows.Forms.DialogResult.OK)
                {
                    //2010805 迅得carol  要求不卡
                    e.Cancel = true;
                    return;
                }
            }
            //if (fullDataCtrl1.EditType == JBControls.FullDataCtrl.EEditType.Add)
            //{
            JBModule.Data.Dto.OvertimeApply otApply = new JBModule.Data.Dto.OvertimeApply();
            otApply.EmployeeID = ptxNobr.Text;
            otApply.ApplyBeginDate = Convert.ToDateTime(txtBdate.Text).AddTime(txtOtTimeB.Text);
            otApply.ApplyEndDate = Convert.ToDateTime(txtBdate.Text).AddTime(txtOtTimeE.Text);
            otApply.OtRote = cbxOtRote.SelectedValue.ToString();
            otApply.AttendDate = Convert.ToDateTime(txtBdate.Text);
            if (Convert.ToDecimal(txtOtHours.Text) > 0)
                otApply.OtType = JBModule.Data.Dto.OvertimeApply.OverTimeType.OtHours;
            else if (Convert.ToDecimal(txtRestHours.Text) > 0)
                otApply.OtType = JBModule.Data.Dto.OvertimeApply.OverTimeType.RestHours;
            else
            {
                MessageBox.Show("加班費時數及補休時數不可同時為0", Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                e.Cancel = true;
                return;
            }

            JBHR.BLL.OverTimeFactory otf = new BLL.OverTimeFactory();
            var ap = otf.CreateOtApply();
            var apData = ap.GenerateOT(otApply);
            var av = otf.CreateOtValidate();
            av.LateBufferMins = 5;
            var checkAp = av.Validate(apData);
            if (!checkAp && av.RejectCode != 202001)
            {
                var empData = from a in (new JBModule.Data.Linq.HrDBDataContext()).BASETTS
                              where a.NOBR == otApply.EmployeeID && otApply.AttendDate >= a.ADATE && otApply.AttendDate <= a.DDATE.Value
                              //&& a.CARD.Trim()=="Y"
                              select new { a.NOBR, a.CARD };
                if (new int[] { 202004, 202005, 202006 }.Contains(av.RejectCode) && empData.Any())
                {
                    if (empData.First().CARD.Trim() == "Y")
                    {
                        e.Cancel = true;
                        MessageBox.Show(av.RejectReason, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        if (cbxRote.SelectedValue.ToString() == "00" && (av.RejectCode == 202004 && av.RejectCode == 202005 && av.RejectCode == 202006))
                            ;
                        else
                            return;
                    }
                }
                else
                {
                    e.Cancel = true;
                    MessageBox.Show(av.RejectReason, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    if (cbxRote.SelectedValue.ToString() == "00" && (av.RejectCode == 202004 && av.RejectCode == 202005 && av.RejectCode == 202006))
                        ;
                    else
                        return;
                }
            }
            //}
            if (fullDataCtrl1.EditType == JBControls.FullDataCtrl.EEditType.Modify)
            {
                var absData = JBHR.BLL.Att.OverTime.GetExistsOTWhenEdit(e.Values["nobr"].ToString(), Convert.ToDateTime(e.Values["bdate"]), Convert.ToDateTime(e.Values["bdate"]), e.Values["btime"].ToString(), e.Values["etime"].ToString(), oldDateB, oldBtime, oldEtime);
                if (absData.Any())
                {
                    if (MessageBox.Show("申請的時段內已有存在的加班資料" + Environment.NewLine + "按確認顯示查詢影響的資料", Resources.All.DialogTitle, MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk) == System.Windows.Forms.DialogResult.OK)
                    {
                        Sal.PreviewForm frm = new Sal.PreviewForm();
                        frm.DataTable = absData.Select(p => new { 工號 = p.Nobr, 姓名 = p.NameC, 加班日期 = p.DateB, 開始時間 = p.Btime, 結束時間 = p.Etime }).CopyToDataTable();
                        frm.Width = 800;
                        frm.ShowDialog();
                    }
                    e.Cancel = true;
                    return;
                }
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
                e.Values["ot_food"] = 0;
                e.Values["ot_car"] = 0;
                e.Values["not_exp"] = 0;
                e.Values["tot_exp"] = 0;
                e.Values["salary"] = 0;
                e.Values["ot_hrs"] = txtOtHours.Text;
                e.Values["rest_hrs"] = txtRestHours.Text;
                e.Values["tot_hours"] = Convert.ToDecimal(e.Values["ot_hrs"]) + Convert.ToDecimal(e.Values["rest_hrs"]);
            }
        }
        decimal CheckOtHours()
        {
            string t1, t2;
            DateTime d1;
            decimal TotalHours = 0;
            d1 = Convert.ToDateTime(txtBdate.Text);
            t1 = Convert.ToInt32(txtOtTimeB.Text).ToString("0000");
            t2 = Convert.ToInt32(txtOtTimeE.Text).ToString("0000");
            var details = JBHR.Dll.Att.OtCal.CalculationOt(ptxNobr.Text, cbxOtRote.SelectedValue.ToString(), d1, t1, t2);
            TotalHours = details.iHour;
            //if (details.iHour == 0)
            //{
            //    JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
            //    var sql = from a in db.ROTE where a.ROTE1 == cbxRote.SelectedValue.ToString() select a;
            //    if (sql.Any())
            //    {
            //        if (sql.First().ON_TIME.CompareTo(t1) == 0 && sql.First().OFF_TIME.CompareTo(t2) == 0)//如果申請時間等於上下班時間
            //            TotalHours = sql.First().WK_HRS;
            //    }
            //}
            return TotalHours;
        }
        void fdc_AfterEdit(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            SetDisable();
            oldBtime = e.Values["btime"].ToString();
            oldEtime = e.Values["etime"].ToString();
            oldDateB = Convert.ToDateTime(e.Values["BDATE"]);
        }
        private void fullDataCtrl1_AfterExport(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            DataView dv = ((sender as JBControls.FullDataCtrl).DataSource.DataSource as DataSet).Tables[(sender as JBControls.FullDataCtrl).DataSource.DataMember].DefaultView;
            dv.RowFilter = (sender as JBControls.FullDataCtrl).DataSource.Filter;

            JBModule.Data.CNPOI.RenderDataViewToExcel(dv, "C:\\TEMP\\" + this.Name + ".xls");
            System.Diagnostics.Process.Start("C:\\TEMP\\" + this.Name + ".xls");
        }
        void fdc_AfterDel(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            //CDataLog.Save(this.Name, MainForm.USER_ID, DateTime.Now, fullDataCtrl1.BackupDataTable);
            if (!e.Error)
            {
                CDataLog.Save(this.Name, MainForm.USER_ID, DateTime.Now, fullDataCtrl1.BackupDataTable);

                Dal.Dao.Att.TransCardDao tc = new Dal.Dao.Att.TransCardDao(linqdb.Connection);
                tc.TransCard(PARMS[0].ToString().Trim(), PARMS[1].ToString().Trim(), PARMS[2].ToString().Trim(), PARMS[3].ToString().Trim(), DateTime.Parse(PARMS[4].ToString()), DateTime.Parse(PARMS[5].ToString()), MainForm.USER_NAME, true, true, true, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN);
            }
        }

        void fdc_AfterSave(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            if (!e.Error)
            {
                CDataLog.Save(this.Name, MainForm.USER_ID, DateTime.Now, fullDataCtrl1.BackupDataTable);
                JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
                var CompseCode = AppConfig.GetConfig("ComposeLeaveGetCode").GetString();
                decimal rest_hrs = Convert.ToDecimal(txtRestHours.Text);
                if (rest_hrs != 0)
                {

                    JBModule.Data.Linq.ABS abs = new JBModule.Data.Linq.ABS();
                    abs.A_NAME = "";
                    abs.BDATE = Convert.ToDateTime(txtBdate.Text);
                    abs.BTIME = e.Values["BTIME"].ToString();
                    abs.EDATE = Convert.ToDateTime(e.Values["OT_EDATE"]);
                    abs.ETIME = e.Values["ETIME"].ToString();
                    abs.H_CODE = CompseCode;
                    abs.KEY_DATE = DateTime.Now;
                    abs.KEY_MAN = MainForm.USER_NAME;
                    abs.NOBR = ptxNobr.Text;
                    abs.nocalc = false;
                    abs.NOTE = e.Values["note"].ToString();
                    abs.NOTEDIT = false;
                    abs.SERNO = txtSerNO.Text;
                    abs.SYSCREATE = false;
                    abs.TOL_DAY = 0;
                    abs.TOL_HOURS = rest_hrs;
                    abs.Balance = rest_hrs;
                    abs.Guid = Guid.NewGuid().ToString();
                    abs.LeaveHours = 0;
                    abs.YYMM = txtYymm.Text;
                    var sql = from a in db.ABS
                              where a.NOBR == abs.NOBR
                              && a.BDATE == abs.BDATE && a.BTIME == abs.BTIME
                              && a.H_CODE == abs.H_CODE
                              select a;
                    if (!sql.Any())//不存在才新增
                    {
                        db.ABS.InsertOnSubmit(abs);
                        db.SubmitChanges();
                    }
                }
            }
        }
        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null && dataGridView1.CurrentRow.Cells[0].Value.ToString().Trim().Length > 0)
            {
                ShowAttend(ptxNobr.Text, Convert.ToDateTime(txtBdate.Text));
                dataGridView3.DataSource = Sal.Function.GetAttend(ptxNobr.Text, Convert.ToDateTime(txtBdate.Text), Convert.ToDateTime(txtBdate.Text));
                if (dataGridView3.RowCount > 2)
                {
                    dataGridView3.Rows[0].Selected = false;
                    dataGridView3.Rows[1].Selected = true;
                }
            }
        }
        private void txtOtTimeB_Validated(object sender, EventArgs e)
        {
            try
            {
                OtCalc();
            }
            catch
            {
                //如果發生錯誤，就略過計算時數
            }
        }
        private void ptxNobr_QueryCompleted(object sender, JBControls.PopupTextBox.QueryCompletedArgs e)
        {
            if (e.HasData)//如果有撈到資料，就將focus移到下一筆
            {
                txtBdate_Validated(null, null);
                //SendKeys.Send("{Tab}");
            }
        }
        private void txtBdate_Validated(object sender, EventArgs e)
        {
            try
            {
                DateTime date = Convert.ToDateTime(txtBdate.Text);
                txtAdate.Text = Sal.Function.GetDate(new DateTime(date.Year, 12, 31));//有效日到當年年底
                //txtAdate.Text = Sal.Function.GetDate(new DateTime(date.AddMonths(1).Year, date.AddMonths(2).Month, 1).AddDays(-1));//有效日到次月月底
                SalaryDate sd = new SalaryDate(date);
                txtYymm.Text = sd.YYMM;
                ShowAttend(ptxNobr.Text, Convert.ToDateTime(txtBdate.Text));
                //cbxOtRote.SelectedValue = cbxRote.SelectedValue.ToString();
                SetDepts();
                dataGridView3.DataSource = Sal.Function.GetAttend(ptxNobr.Text, Convert.ToDateTime(txtBdate.Text), Convert.ToDateTime(txtBdate.Text));
                if (dataGridView3.RowCount > 2)
                {
                    dataGridView3.Rows[0].Selected = false;
                    dataGridView3.Rows[1].Selected = true;
                }
            }
            catch { }
        }
        private void ptxNobr_Validated(object sender, EventArgs e)
        {
            ShowAttend(ptxNobr.Text, Convert.ToDateTime(txtBdate.Text));
        }
        void SetDepts()
        {
            try
            {
                dcAttDataContext db = new dcAttDataContext();
                string nobr;
                nobr = ptxNobr.Text;
                DateTime d1;
                d1 = Convert.ToDateTime(txtBdate.Text);
                var sql = from d in db.ATT_BASETTS where d.NOBR == nobr && d1 >= d.ADATE && d1 <= d.DDATE select d;
                if (sql.Any()) cbxOtDepts.SelectedValue = sql.First().DEPTS;
            }
            catch { }


        }
        void SetDisable()
        {
            //txtYymm.Enabled = false;
            //txtSerNO.Enabled = false;
            //chkEat.Enabled = false;
            //chkNotModi.Enabled = false;
            //chkRes.Enabled = false;
            //chkSysCreat.Enabled = false;
            //chkSysCreat1.Enabled = false;
            //chkSysCreate.Enabled = false;
            //checkBox1.Enabled = false;
            //checkBox2.Enabled = false;

        }
        void ShowAttend(string nobr, DateTime adate)
        {
            try
            {
                dcViewDataContext dv = new dcViewDataContext();
                var sql = from ac in dv.V_FRM26 where ac.NOBR == nobr && ac.ADATE == adate select ac;
                this.dsAtt.ATTCARD.Clear();
                this.dsAtt.ATTCARD.FillData(dv.GetCommand(sql));
                dcAttDataContext db = new dcAttDataContext();
                var sql1 = (from ac in db.ATTEND where ac.NOBR == nobr && ac.ADATE == adate select new { ac.NOBR, ac.ADATE, ac.ROTE }).ToList();
                if (sql1.Any()) cbxRote.SelectedValue = sql1.First().ROTE;
                else
                {
                    cbxRote.SelectedValue = "";
                    //MessageBox.Show(Resources.Att.AttendNoFound, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                if (cbxRote.SelectedValue.ToString() != "00")
                {
                    cbxOtRote.SelectedValue = cbxRote.SelectedValue.ToString();
                }
                else
                {
                    var filterAttend = from a in db.ATTEND where a.NOBR == nobr && a.ADATE >= adate.AddDays(-1) && a.ROTE != "00" orderby a.ADATE select new { a.NOBR, a.ADATE, a.ROTE };
                    if (filterAttend.Any())
                        cbxOtRote.SelectedValue = filterAttend.First().ROTE;
                }
            }
            catch { }
        }

        private void fullDataCtrl1_BeforeDel(object sender, JBControls.FullDataCtrl.BeforeEventArgs e)
        {
            if (Sal.Function.IsAttendLocked(Convert.ToDateTime(txtBdate.Text), ptxNobr.Text))
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

            PARMS = new object[] { e.Values["nobr"].ToString().Trim(), e.Values["nobr"].ToString().Trim(), dept_b, dept_b, DateTime.Parse(e.Values["bdate"].ToString()), DateTime.Parse(e.Values["bdate"].ToString()), MainForm.USER_NAME, true, true, true, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN };
        }
        void OtCalc()
        {
            string t1, t2;
            DateTime d1;
            d1 = Convert.ToDateTime(txtBdate.Text);
            t1 = Convert.ToInt32(txtOtTimeB.Text).ToString("0000");
            t2 = Convert.ToInt32(txtOtTimeE.Text).ToString("0000");
            var details = JBHR.Dll.Att.OtCal.CalculationOt(ptxNobr.Text, cbxOtRote.SelectedValue.ToString(), d1, t1, t2);
            txtOtHours.Text = details.iHour.ToString();
            //if (details.iHour == 0)
            //{
            //    JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
            //    var sql = from a in db.ROTE where a.ROTE1 == cbxRote.SelectedValue.ToString() select a;
            //    if (sql.Any())
            //    {
            //        if (sql.First().ON_TIME.CompareTo(t1) == 0 && sql.First().OFF_TIME.CompareTo(t2) == 0)//如果申請時間等於上下班時間
            //            txtOtHours.Text = sql.First().WK_HRS.ToString();
            //    }
            //}
        }
        void GridBind()
        {
            //foreach (var itm in this.dsAtt.OT)
            //{
            //    itm.OT_FOOD = JBModule.Data.CDecryp.Number(itm.OT_FOOD);
            //    itm.OT_CAR = JBModule.Data.CDecryp.Number(itm.OT_CAR);
            //    itm.NOT_EXP = JBModule.Data.CDecryp.Number(itm.NOT_EXP);
            //    itm.TOT_EXP = JBModule.Data.CDecryp.Number(itm.TOT_EXP);
            //    itm.SALARY = JBModule.Data.CDecryp.Number(itm.SALARY);
            //}
            //this.dsAtt.OT.AcceptChanges();
        }

        private void fullDataCtrl1_AfterShow(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            GridBind();
        }

        private void fullDataCtrl1_AfterQuery(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            GridBind();
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            lblSum.Text = Sal.Function.ColumnsSum(dataGridView1, e.ColumnIndex);
        }

        private void fullDataCtrl1_AfterCancel(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            dataGridView3.DataSource = Sal.Function.GetAttend(ptxNobr.Text, Convert.ToDateTime(txtBdate.Text), Convert.ToDateTime(txtBdate.Text));
            this.dsAtt.ATTCARD.Clear();
        }

        private void btnTrans_Click(object sender, EventArgs e)
        {
            dcAttDataContext db = new dcAttDataContext();
            var CompseCode = AppConfig.GetConfig("ComposeLeaveGetCode").GetString();
            if (CompseCode.Trim().Length > 0)
            {
                int cc = 0;
                var data = from a in dsAtt.OT where a.REST_HRS > 0 select a;
                foreach (var it in data)
                {
                    decimal rest_hrs = it.REST_HRS;
                    if (rest_hrs != 0)
                    {
                        ABS abs = new ABS();
                        abs.A_NAME = "";
                        abs.BDATE = it.BDATE;
                        abs.BTIME = it.BTIME;
                        abs.EDATE = it.BDATE.AddMonths(6);
                        //abs.EDATE = new DateTime(it.BDATE.Year, 12, 31);//有效日到當年年底
                        abs.ETIME = it.ETIME;
                        abs.H_CODE = CompseCode;
                        abs.KEY_DATE = DateTime.Now;
                        abs.KEY_MAN = MainForm.USER_NAME;
                        abs.NOBR = it.NOBR;
                        abs.nocalc = false;
                        abs.NOTE = it.NOTE;
                        abs.NOTEDIT = false;
                        abs.SERNO = it.SERNO;
                        abs.SYSCREATE = false;
                        abs.TOL_DAY = 0;
                        abs.TOL_HOURS = rest_hrs;
                        abs.YYMM = it.YYMM;
                        var sql = from a in db.ABS
                                  where a.NOBR == abs.NOBR
                                  && a.BDATE == abs.BDATE && a.BTIME == abs.BTIME
                                  && a.H_CODE == abs.H_CODE
                                  select a;
                        if (!sql.Any())//不存在才新增
                        {
                            cc++;
                            db.ABS.InsertOnSubmit(abs);
                            db.SubmitChanges();
                        }
                    }
                }
                MessageBox.Show("產生" + cc.ToString() + "筆補休資料");
            }
        }

        private void bnIMPORT_Click(object sender, EventArgs e)
        {
            FRM29IN oFRM29IN = new FRM29IN();
            oFRM29IN.ShowDialog();
        }


    }
}
