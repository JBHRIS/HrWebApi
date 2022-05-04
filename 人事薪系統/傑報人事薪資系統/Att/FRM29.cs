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
        JBModule.Data.ApplicationConfigSettings AppConfig = null;
        string oldBtime, oldEtime, oldHcode;
        DateTime oldDateB;
        JBModule.Data.Linq.HrDBDataContext dbGlobal = new JBModule.Data.Linq.HrDBDataContext();
        string CompseCode = "";
        List<string> holi_codeList = new List<string>() { "00", "0X", "0Y", "0Z" };
        CheckTimeFormatControl CTFC = new CheckTimeFormatControl();
        private void FRM29_Load(object sender, EventArgs e)
        {
            CTFC.AddControl(txtOtTimeB, true, false, false);
            CTFC.AddControl(txtOtTimeE, true, false, false);
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
            this.rOTETTableAdapter.Fill(this.dsAtt.ROTET, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN);
            this.oTRCDTableAdapter.Fill(this.dsAtt.OTRCD, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN);
            this.dEPTSTableAdapter.Fill(this.dsBas.DEPTS);
            this.rOTETableAdapter.Fill(this.dsAtt.ROTE, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN);
            SystemFunction.SetComboBoxItems(cbxOtDepts, CodeFunction.GetDepts(), true, false, true);
            SystemFunction.SetComboBoxItems(cbxOtRCD, CodeFunction.GetOtrcd(), true, false, true);
            SystemFunction.SetComboBoxItems(cbxOtRote, CodeFunction.GetRote(), true, false, true);
            SystemFunction.SetComboBoxItems(cbxRote, CodeFunction.GetRote(), true, false, true);
            SystemFunction.SetComboBoxItems(cbxOtRate, CodeFunction.GetOtRatecd(), true, false, true);
            this.aTTENDTableAdapter.FillByInit(this.dsAtt.ATTEND);
            this.oTTableAdapter.FillByInt(this.dsAtt.OT);
            AppConfig = new JBModule.Data.ApplicationConfigSettings("FRM29", MainForm.COMPANY);
            SystemFunction.CheckAppConfigRule(btnConfig);
            AppConfig.CheckParameterAndSetDefault("CheckAttTime", "是否檢查出勤時間", "True"
               , "請選擇是否要檢查出勤時間", "ComboBox", "select 'True' value , 'True' union select 'False', 'False'", "String");
            AppConfig.CheckParameterAndSetDefault("CheckAttTimeByHoliDay", "假日是否也需檢查出勤時間", "True"
                , "請選擇假日是否也要檢查出勤時間(前提是檢查出勤須設為True)", "ComboBox", "select 'True' value , 'True' union select 'False', 'False'", "String");
            AppConfig.CheckParameterAndSetDefault("RestHoursEqu1231", "補休效期設為年底", "false"
               , "補休有效期限為當年12月31日", "ComboBox", "select 'True' value , 'True' union select 'False', 'False'", "String");
            AppConfig.CheckParameterAndSetDefault("ComposeEndEqulAnnualEnd", "補休效期同特休推算方式", "false"
               , "補休有校期限同特休有效期限(此設定會比RestHoursEqu1231優先)", "ComboBox", "select 'True' value , 'True' union select 'False', 'False'", "String");
            AppConfig.CheckParameterAndSetDefault("CalcMode", "進位模式", "Floor", "當出現無窮小數時的進位方式", "ComboBox", "select  'Floor' value,'無條件捨去' union select 'Round' value,'四捨五入' union select 'Ceiling' value,'無條件進位'", "String");
            AppConfig = new JBModule.Data.ApplicationConfigSettings("FRM211", MainForm.COMPANY);
            CompseCode = AppConfig.GetConfig("ComposeLeaveGetCode").GetString();

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
        }
        private void fullDataCtrl1_AfterAdd(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            SetDisable();
            ptxNobr.Focus();
            //txtBdate.Text = Sal.Core.SalaryDate.DateString();
            txtSerNO.Text = Guid.NewGuid().ToString();
            bool RestHoursEqu1231 = false;
            bool ComposeEndEqulAnnualEnd = false;
            try
            {
                AppConfig = new JBModule.Data.ApplicationConfigSettings("FRM29", MainForm.COMPANY);
                RestHoursEqu1231 = Convert.ToBoolean(AppConfig.GetConfig("RestHoursEqu1231").Value);
                ComposeEndEqulAnnualEnd = Convert.ToBoolean(AppConfig.GetConfig("ComposeEndEqulAnnualEnd").Value);
                DateTime adate = DateTime.Parse(txtBdate.Text);
                int YYYY = adate.Year;
                if (ComposeEndEqulAnnualEnd)
                {
                    txtAdate.Text = dbGlobal.GetAnnualLeaveEndDate(ptxNobr.Text, adate).Value.ToString();
                }
                else if (RestHoursEqu1231)
                {
                    txtAdate.Text = new DateTime(YYYY, 12, 31).ToString();
                }
                else
                {
                    txtAdate.Text = Sal.Function.GetDate(adate.AddMonths(6));//20150714chpt要求由三個月改為六個月 
                }
            }
            catch
            {
                txtAdate.Text = txtBdate.Text;
            }
            dataGridView3.DataSource = Sal.Function.GetAttend(ptxNobr.Text, Convert.ToDateTime(txtBdate.Text), Convert.ToDateTime(txtBdate.Text));
        }
        private void fullDataCtrl1_BeforeSave(object sender, JBControls.FullDataCtrl.BeforeEventArgs e)
        {
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
            //var OtratecdByNobr = dbGlobal.OTRATECD.Where(p => p.OTRATE_CODE == cbxOtRate.SelectedValue.ToString()).FirstOrDefault();//20190904 新增判斷是否有設定不可同時申請加班及換休 by 志穎
            //if (OtratecdByNobr == null)
            //{
            //    DateTime BDate = DateTime.Parse(txtBdate.Text);
            //    string OtRate =  dbGlobal.BASETTS.Where(p => p.NOBR == ptxNobr.Text && p.ADATE >= BDate && p.DDATE.Value <= BDate).FirstOrDefault().CALOT;
            //    OtratecdByNobr = dbGlobal.OTRATECD.Where(p => p.OTRATE_CODE == OtRate).FirstOrDefault();
            //}
            JBModule.Data.Linq.OTRATECD OtratecdByNobr = GetOTRATECDByNOBR(ptxNobr.Text, DateTime.Parse(txtBdate.Text), cbxOtRate.SelectedValue.ToString());
            if ( Convert.ToDecimal(txtOtHours.Text) > 0 && Convert.ToDecimal(txtRestHours.Text) > 0 && OtratecdByNobr != null && OtratecdByNobr.FIXPER == true)
            {
                MessageBox.Show("加班時數及補休時數只能擇一申請，如需調整請至加班比率代碼進行更改", Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                e.Cancel = true;
                return;
            }

            if (Sal.Function.IsAttendLocked(Convert.ToDateTime(txtBdate.Text), ptxNobr.Text))
            {
                if (fullDataCtrl1.EditType == JBControls.FullDataCtrl.EEditType.Add)
                {//鎖定時新增，移至下個月
                    //e.Values["YYMM"] = GetUnLockYYMM(Convert.ToDateTime(txtDateB.Text));

                    if (MessageBox.Show(Resources.Att.AttendDateLocked + "," + Resources.Att.YymmMoveToNextMonth, Resources.All.DialogTitle, MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk) == System.Windows.Forms.DialogResult.Cancel)
                    {
                        e.Cancel = true;
                    }
                    txtYymm.Text = FRM28.GetUnLockYYMM(Convert.ToDateTime(txtBdate.Text));
                    e.Values["YYMM"] = txtYymm.Text;
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
            if (holi_codeList.Contains(cbxOtRote.SelectedValue.ToString()))
            {
                MessageBox.Show("加班班別不可以選擇假日班，請選擇適用該加班時段津貼的班別", Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                e.Cancel = true;
                return;
            }
            if (fullDataCtrl1.EditType == JBControls.FullDataCtrl.EEditType.Add)
            {
                var absData = JBHR.BLL.Att.OverTime.GetExistsOT(e.Values["nobr"].ToString(), Convert.ToDateTime(e.Values["bdate"]), Convert.ToDateTime(e.Values["bdate"]), e.Values["btime"].ToString(), e.Values["etime"].ToString());
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

            decimal CheckHours = CheckOtHours(OtratecdByNobr);
            //需重新檢查加班總時數
            //if (CheckHours != Convert.ToDecimal(txtOtHours.Text) + Convert.ToDecimal(txtRestHours.Text))
            //{
            //    //MessageBox.Show("加班總時數不正確(加班總時數" + CheckHours.ToString() + "小時)", Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            //    if (CheckHours == 0)
            //    {
            //        JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
            //        var sql = from a in db.ROTE where a.ROTE1 == cbxRote.SelectedValue.ToString() select a;
            //        if (sql.Any())
            //        {
            //            if (sql.First().ON_TIME.CompareTo(e.Values["btime"].ToString()) <= 0 && sql.First().OFF_TIME.CompareTo(e.Values["etime"].ToString()) >= 0)//如果申請時間等於上下班時間
            //            {
            //                MessageBox.Show("申請的時段為上班時間", Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            //                e.Cancel = true;
            //                return;
            //            }
            //        }
            //    }
            //    //if (MessageBox.Show("加班總時數不正確(加班總時數" + CheckHours.ToString() + "小時)" + Environment.NewLine + "是否確認存檔", Resources.All.DialogTitle, MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk) != System.Windows.Forms.DialogResult.OK)
            //    //{
            //    //    //2010805 迅得carol  要求不卡
            //    //    e.Cancel = true;
            //    //    return;
            //    //}
            //    MessageBox.Show("加班總時數不正確(加班總時數" + CheckHours.ToString() + "小時)" + Environment.NewLine + "是否確認存檔", Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            //    e.Cancel = true;
            //    return;
            //}

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
            bool CheckAttTime = false;
            try
            {
                AppConfig = new JBModule.Data.ApplicationConfigSettings("FRM29", MainForm.COMPANY);
                CheckAttTime = Convert.ToBoolean(AppConfig.GetConfig("CheckAttTime").Value);
            }
            catch 
            {
                e.Cancel = true;
                MessageBox.Show("尚未設定是否檢查出勤時間", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (CheckAttTime)
            {
                //假日是否也檢查出勤時間
                bool CheckAttTimeByHoliDay = true;
                try
                {
                    CheckAttTimeByHoliDay = Convert.ToBoolean(AppConfig.GetConfig("CheckAttTimeByHoliDay").Value);
                }
                catch
                {
                }

                JBHR.BLL.OverTimeFactory otf = new BLL.OverTimeFactory();
                var ap = otf.CreateOtApply();
                var apData = ap.GenerateOT(otApply);
                var av = otf.CreateOtValidate();
                if (!CheckAttTimeByHoliDay && cbxRote.SelectedValue != null && holi_codeList.Contains(cbxRote.SelectedValue.ToString()))
                    av.CheckAttCard = false;
                var checkAp = av.Validate(apData);
                if (!checkAp && av.RejectCode != 202001)
                {
                    e.Cancel = true;
                    MessageBox.Show(av.RejectReason, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
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
                e.Values["tot_hours"] = Convert.ToDecimal(e.Values["ot_hrs"]) + Convert.ToDecimal(e.Values["rest_hrs"]);
            }
        }
        void fdc_AfterEdit(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            SetDisable();
            oldBtime = e.Values["btime"].ToString();
            oldEtime = e.Values["etime"].ToString();
            oldDateB = Convert.ToDateTime(e.Values["BDATE"]);
            if (CheckOt_RestUsage())
                MessageBox.Show("此筆補修已被使用,變更資料須留意時數是否異常", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        bool CheckOt_RestUsage()
        {
            //if (Serno.Trim().Length == 0) return false;//無法辨識
            var sql = from a in dbGlobal.ABS where a.SERNO == txtSerNO.Text && a.NOBR == ptxNobr.Text && a.BDATE == Convert.ToDateTime(txtBdate.Text) && a.BTIME == txtOtTimeB.Text select a;
            if (sql.Any())
            {
                return FRM28.CheckABSD(sql.First().Guid, true).Trim().Length > 0;
            }
            return false;

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
            dcAttDataContext db = new dcAttDataContext();
            CDataLog.Save(this.Name, MainForm.USER_ID, DateTime.Now, fullDataCtrl1.BackupDataTable);

            var sql = from a in db.ABS
                      where a.NOBR == e.OldValues["NOBR"].ToString()
                          //&& a.BDATE == abs.BDATE && a.BTIME == abs.BTIME
                      && a.SERNO == e.OldValues["SERNO"].ToString()
                      && a.H_CODE == CompseCode
                      select a;
            db.ABS.DeleteAllOnSubmit(sql);
            db.SubmitChanges();
        }
        //bool CheckOTSerno(string Serno, int auto)
        //{
        //    var sql = from a in dbGlobal.OT where a.SERNO == Serno && a.Autokey == auto select a;
        //    return sql.Any();
        //}

        void fdc_AfterSave(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            if (!e.Error)
            {
                CDataLog.Save(this.Name, MainForm.USER_ID, DateTime.Now, fullDataCtrl1.BackupDataTable);
                dcAttDataContext db = new dcAttDataContext();


                decimal rest_hrs = Convert.ToDecimal(e.Values["REST_HRS"]);

                //ABS abs = new ABS();
                //abs.A_NAME = "";
                //abs.BDATE = Convert.ToDateTime(e.Values["BDATE"]);
                //abs.BTIME = e.Values["BTIME"].ToString();
                //abs.EDATE = Convert.ToDateTime(e.Values["OT_EDATE"]);
                //abs.ETIME = e.Values["ETIME"].ToString();
                //abs.H_CODE = CompseCode;
                //abs.KEY_DATE = DateTime.Now;
                //abs.KEY_MAN = MainForm.USER_NAME;
                //abs.NOBR = e.Values["NOBR"].ToString();
                //abs.nocalc = false;
                //abs.NOTE = e.Values["note"].ToString();
                //abs.NOTEDIT = false;
                //abs.SERNO = e.Values["SERNO"].ToString();
                //abs.SYSCREATE = false;
                //abs.TOL_DAY = 0;
                //abs.TOL_HOURS = rest_hrs;
                //abs.Balance = rest_hrs;
                //abs.Guid = Guid.NewGuid().ToString();
                //abs.LeaveHours = 0;
                //abs.YYMM = txtYymm.Text;
                dsAttTableAdapters.ABSTableAdapter adAbs = new dsAttTableAdapters.ABSTableAdapter();
                dsAtt.ABSDataTable dtAbs = adAbs.GetDataBySerno(e.Values["SERNO"].ToString());
                var rAbs = dtAbs.SingleOrDefault(p => p.BDATE == oldDateB && p.BTIME == oldBtime && p.NOBR == e.Values["NOBR"].ToString());
                if (rest_hrs != 0)
                {
                    if (rAbs == null)//不存在才新增
                    {
                        dsAtt.ABSRow abs = dtAbs.NewABSRow();
                        abs.A_NAME = "";
                        abs.BDATE = Convert.ToDateTime(e.Values["BDATE"]);
                        abs.BTIME = e.Values["BTIME"].ToString();
                        abs.EDATE = Convert.ToDateTime(e.Values["OT_EDATE"]);
                        abs.ETIME = e.Values["ETIME"].ToString();
                        abs.H_CODE = CompseCode;
                        abs.KEY_DATE = DateTime.Now;
                        abs.KEY_MAN = MainForm.USER_NAME;
                        abs.NOBR = e.Values["NOBR"].ToString();
                        abs.nocalc = false;
                        abs.NOTE = e.Values["note"].ToString();
                        abs.NOTEDIT = false;
                        abs.SERNO = e.Values["SERNO"].ToString();
                        abs.SYSCREATE = false;
                        abs.TOL_DAY = 0;
                        abs.TOL_HOURS = rest_hrs;
                        abs.Balance = rest_hrs;
                        abs.Guid = Guid.NewGuid().ToString();
                        abs.LeaveHours = 0;
                        abs.YYMM = txtYymm.Text;
                        dtAbs.AddABSRow(abs);
                        adAbs.Update(dtAbs);
                    }
                    else
                    {
                        //var rAbs = sql.First();
                        rAbs.BDATE = Convert.ToDateTime(e.Values["BDATE"]);
                        rAbs.EDATE = Convert.ToDateTime(e.Values["OT_EDATE"]);
                        rAbs.BTIME = e.Values["BTIME"].ToString();
                        rAbs.ETIME = e.Values["ETIME"].ToString();
                        rAbs.TOL_HOURS = rest_hrs;
                        rAbs.Balance = rAbs.TOL_HOURS - rAbs.LeaveHours;
                        rAbs.KEY_DATE = DateTime.Now;
                        rAbs.KEY_MAN = MainForm.USER_NAME;
                        //string cmd = "UPDATE ABS SET BDATE={0},BTIME={1},ETIME={2},TOL_HOURS={3},BALANCE={3}-LEAVEHOURS,EDATE={7} WHERE NOBR={4} AND SERNO={5} AND H_CODE={6}";
                        //db.ExecuteCommand(cmd, new object[] { abs.BDATE, abs.BTIME, abs.ETIME, abs.TOL_HOURS, abs.NOBR, abs.SERNO, abs.H_CODE, abs.EDATE });
                        adAbs.Update(dtAbs);
                    }
                }
                else
                {
                    //var sql = from a in db.ABS
                    //          where a.NOBR == abs.NOBR
                    //              //&& a.BDATE == abs.BDATE && a.BTIME == abs.BTIME
                    //          && a.SERNO == abs.SERNO
                    //          && a.H_CODE == abs.H_CODE
                    //          select a;
                    //db.ABS.DeleteAllOnSubmit(sql);
                    if (rAbs != null)
                    {
                        rAbs.Delete();
                        adAbs.Update(rAbs);
                    }
                }
                //db.SubmitChanges();                
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
            bool RestHoursEqu1231 = false;
            bool ComposeEndEqulAnnualEnd = false;
            try
            {
                DateTime date = Convert.ToDateTime(txtBdate.Text);
                AppConfig = new JBModule.Data.ApplicationConfigSettings("FRM29", MainForm.COMPANY);
                RestHoursEqu1231 = Convert.ToBoolean(AppConfig.GetConfig("RestHoursEqu1231").Value);
                ComposeEndEqulAnnualEnd = Convert.ToBoolean(AppConfig.GetConfig("ComposeEndEqulAnnualEnd").Value);
                DateTime adate = DateTime.Parse(txtBdate.Text);
                int YYYY = adate.Year;
                if (ComposeEndEqulAnnualEnd)
                {
                    txtAdate.Text = dbGlobal.GetAnnualLeaveEndDate(ptxNobr.Text, adate).Value.ToString();
                }
                else if (RestHoursEqu1231)
                {
                    txtAdate.Text = new DateTime(YYYY, 12, 31).ToString();
                }
                else
                {
                    txtAdate.Text = Sal.Function.GetDate(adate.AddMonths(6));
                }

                SalaryDate sd = new SalaryDate(date);
                txtYymm.Text = sd.YYMM;
                ShowAttend(ptxNobr.Text, Convert.ToDateTime(txtBdate.Text));
                //cbxOtRote.SelectedValue = cbxRote.SelectedValue.ToString();
                SetDepts();
                dataGridView3.DataSource = Sal.Function.GetAttend(ptxNobr.Text, Convert.ToDateTime(txtBdate.Text), Convert.ToDateTime(txtBdate.Text));
                if (txtBdate.Text != null)
                    cbxOtRote.Focus();
            }
            catch 
            {
                txtAdate.Text = txtBdate.Text;
            }
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

        decimal CheckOtHours(JBModule.Data.Linq.OTRATECD OtratecdByNobr)
        {
            string t1, t2;
            DateTime d1;
            decimal TotalHours = 0;
            try
            {
                d1 = Convert.ToDateTime(txtBdate.Text);
                t1 = Convert.ToInt32(txtOtTimeB.Text).ToString("0000");
                t2 = Convert.ToInt32(txtOtTimeE.Text).ToString("0000");
                JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();

                Dal.Dao.Att.OtDao oOtDao = new Dal.Dao.Att.OtDao(db.Connection);
                var Calculate = oOtDao.GetCalculate(ptxNobr.Text, "1", d1, d1, t1, t2, "", 0, cbxOtRote.SelectedValue.ToString(), true, true, OtratecdByNobr.MIN_HOURS / 60M, OtratecdByNobr.OTUNIT / 60M);
                AppConfig = new JBModule.Data.ApplicationConfigSettings("FRM29", MainForm.COMPANY);
                var CalcMode = AppConfig.GetConfig("CalcMode").GetString("Floor");
                if (CalcMode == "Ceiling")
                    Calculate = Math.Ceiling(Calculate * 100) / 100M;
                else if (CalcMode == "Round")
                    Calculate = Math.Round(Calculate, 2);
                else
                    Calculate = Math.Floor(Calculate * 100) / 100M;
                TotalHours = Calculate;
            }
            catch { }

            return TotalHours;
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
            if (!string.IsNullOrWhiteSpace(nobr) && adate >= new DateTime(1753,1,1))
            {
                try
                {
                    dcViewDataContext dv = new dcViewDataContext();
                    var sql = from ac in dv.V_FRM26 where ac.NOBR == nobr && ac.ADATE == adate select ac;
                    this.dsAtt.ATTCARD.Clear();
                    this.dsAtt.ATTCARD.FillData(dv.GetCommand(sql));
                    dcAttDataContext db = new dcAttDataContext();
                    var sql1 = from ac in db.ATTEND where ac.NOBR == nobr && ac.ADATE == adate select ac;
                    if (sql1.Any()) cbxRote.SelectedValue = sql1.First().ROTE;
                    else
                    {
                        cbxRote.SelectedValue = "";
                        //MessageBox.Show(Resources.Att.AttendNoFound, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }

                    //var sql_holday = from a in db.HOL_DAY where a.ADATE == adate && a.ROTE == cbxOtRote.SelectedValue.ToString() select a;
                    if (fullDataCtrl1.EditType == JBControls.FullDataCtrl.EEditType.Modify || fullDataCtrl1.EditType == JBControls.FullDataCtrl.EEditType.Add)
                    {
                        if (!holi_codeList.Contains(cbxRote.SelectedValue.ToString()))
                        {
                            cbxOtRote.SelectedValue = cbxRote.SelectedValue.ToString();
                        }
                        else if (holi_codeList.Contains(cbxRote.SelectedValue.ToString()))
                        {
                            JBModule.Data.Linq.HrDBDataContext db1 = new JBModule.Data.Linq.HrDBDataContext();
                            var rotehsql = from ac in db1.ATTEND where ac.NOBR == nobr && ac.ADATE == adate select ac;
                            cbxOtRote.SelectedValue = rotehsql.First().ROTE_H;
                        }
                        else
                        {
                            var filterAttend = from a in db.ATTEND where a.NOBR == nobr && a.ADATE >= adate.AddDays(-1) && !holi_codeList.Contains(a.ROTE) orderby a.ADATE select new { a.NOBR, a.ADATE, a.ROTE };
                            if (filterAttend.Any())
                                cbxOtRote.SelectedValue = filterAttend.First().ROTE;
                        }
                        if (txtBdate.Text != null && cbxOtRote.SelectedValue.ToString() != "")
                        {
                            JBModule.Data.Linq.HrDBDataContext db1 = new JBModule.Data.Linq.HrDBDataContext();
                            var sql_holday = from a in db1.HOL_DAY
                                             join b in db1.BASETTS on a.HOLI_CODE equals b.HOLI_CODE
                                             where a.ADATE == adate && a.ROTE == cbxOtRote.SelectedValue.ToString()
                                             && b.NOBR == ptxNobr.Text
                                             && adate <= b.DDATE && adate >= b.ADATE
                                             select a;
                            if (sql_holday.Any())
                                cbxOtRate.SelectedValue = sql_holday.First().OTRATECD;
                        }
                    }
                }
                catch { } 
            }
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
            if (CheckOt_RestUsage())
                if (MessageBox.Show("此筆補休已被使用,刪除資料會造成部分請假沖假異常", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Cancel) ;
        }
        void OtCalc()
        {
            JBModule.Data.Linq.OTRATECD OtratecdByNobr = GetOTRATECDByNOBR(ptxNobr.Text, DateTime.Parse(txtBdate.Text), cbxOtRate.SelectedValue.ToString());
            txtOtHours.Text = CheckOtHours(OtratecdByNobr).ToString();
        }

        private JBModule.Data.Linq.OTRATECD GetOTRATECDByNOBR(string nobr,DateTime bdate,string otratecd)
        {
            var OtratecdByNobr = dbGlobal.OTRATECD.Where(p => p.OTRATE_CODE == otratecd).FirstOrDefault();//20190904 新增判斷是否有設定不可同時申請加班及換休 by 志穎
            if (OtratecdByNobr == null)
            {
                DateTime BDate = bdate;
                otratecd = dbGlobal.BASETTS.Where(p => p.NOBR == nobr && p.ADATE <= BDate && p.DDATE.Value >= BDate).FirstOrDefault().CALOT;
                OtratecdByNobr = dbGlobal.OTRATECD.Where(p => p.OTRATE_CODE == otratecd).FirstOrDefault();
            }

            return OtratecdByNobr;
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
        }

        private void btnTrans_Click(object sender, EventArgs e)
        {
            dcAttDataContext db = new dcAttDataContext();
            AppConfig = new JBModule.Data.ApplicationConfigSettings("FRM211", MainForm.COMPANY);
            var CompseCode = AppConfig.GetConfig("ComposeLeaveGetCode").GetString();
            if (CompseCode.Trim().Length > 0)
            {
                int cc = 0, update = 0, delete = 0, error = 0;
                var data = from a in dsAtt.OT where a.REST_HRS > 0 select a;
                foreach (var it in data)
                {
                    try
                    {
                        decimal rest_hrs = it.REST_HRS;
                        ABS abs = new ABS();
                        abs.A_NAME = "";
                        abs.BDATE = it.BDATE;
                        abs.BTIME = it.BTIME;
                        abs.EDATE = it.OT_EDATE;
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
                        abs.Balance = rest_hrs;
                        abs.Guid = Guid.NewGuid().ToString();
                        abs.LeaveHours = 0;
                        abs.YYMM = it.YYMM;
                        if (rest_hrs != 0 && it.SERNO.Trim().Length > 0)
                        {
                            var sql = from a in db.ABS
                                      where a.NOBR == abs.NOBR
                                          && a.BDATE == abs.BDATE && a.BTIME == abs.BTIME
                                      && a.SERNO == abs.SERNO
                                      && a.H_CODE == abs.H_CODE
                                      select a;
                            if (!sql.Any())//不存在才新增
                            {
                                db.ABS.InsertOnSubmit(abs);
                                cc++;
                            }
                            else
                            {
                                string cmd = "UPDATE ABS SET BDATE={0},BTIME={1},ETIME={2},TOL_HOURS={3},BALANCE={3}-LEAVEHOURS,EDATE={7} WHERE NOBR={4} AND SERNO={5} AND H_CODE={6}";
                                db.ExecuteCommand(cmd, new object[] { abs.BDATE, abs.BTIME, abs.ETIME, abs.TOL_HOURS, abs.NOBR, abs.SERNO, abs.H_CODE, abs.EDATE });
                                update++;
                            }
                        }
                        else
                        {
                            if (it.SERNO.Trim().Length > 0)
                            {
                                var sql = from a in db.ABS
                                          where a.NOBR == abs.NOBR
                                              //&& a.BDATE == abs.BDATE && a.BTIME == abs.BTIME
                                          && a.SERNO == abs.SERNO
                                          && a.H_CODE == abs.H_CODE
                                          select a;
                                db.ABS.DeleteAllOnSubmit(sql);
                                delete++;
                            }
                        }
                        db.SubmitChanges();
                    }
                    catch (Exception ex)
                    {
                        JBModule.Message.TextLog.WriteLog(ex + Environment.NewLine + it.NOBR + "," + it.BDATE + "," + it.BTIME + "," + it.SERNO);
                        error++;
                    }
                }
                MessageBox.Show(string.Format("產生{0}筆,更新{1}筆,刪除{2}筆補休資料,{3}筆錯誤", cc, update, delete, error));
            }
        }

        private void TxtRestHours_Leave(object sender, EventArgs e)
        {
            if (txtBdate.Text.Trim().Length != 0 && txtAdate.Text.Trim().Length != 0)
            {
                float result = 0;
                DateTime bdate = DateTime.Parse(txtBdate.Text);
                DateTime adate = DateTime.Parse(txtAdate.Text);
                if (float.TryParse(txtRestHours.Text, out result) && result != 0F && bdate == adate)
                {
                    DateTime lastdate = new DateTime(bdate.Year, bdate.Month, DateTime.DaysInMonth(bdate.Year, bdate.Month));//最後一天
                    txtAdate.Text = lastdate.ToShortDateString();
                } 
            }
        }

        private void cbxOtRote_SelectedvalueChanged(object sender, EventArgs e)
        {
            //if (txtBdate.Text != null && cbxOtRote.SelectedValue !="")
            if (fullDataCtrl1.EditType == JBControls.FullDataCtrl.EEditType.Modify || fullDataCtrl1.EditType == JBControls.FullDataCtrl.EEditType.Add)
            {
                if (txtBdate.Text != null && cbxOtRote.SelectedValue.ToString() != "")
                {
                    JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
                    //var sql_holday = from a in db.HOL_DAY where a.ADATE == Convert.ToDateTime(txtBdate.Text) && a.ROTE == cbxOtRote.SelectedValue.ToString() select a;
                    var sql_holday = from a in db.HOL_DAY
                                     join b in db.BASETTS on a.HOLI_CODE equals b.HOLI_CODE
                                     where a.ADATE == Convert.ToDateTime(txtBdate.Text) && a.ROTE == cbxOtRote.SelectedValue.ToString()
                                     && b.NOBR == ptxNobr.Text
                                     && Convert.ToDateTime(txtBdate.Text) <= b.DDATE && Convert.ToDateTime(txtBdate.Text) >= b.ADATE
                                     select a;
                    if (sql_holday.Any())
                        cbxOtRate.SelectedValue = sql_holday.First().OTRATECD;
                    else
                        cbxOtRate.SelectedIndex = 0;
                }
            }
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            JBControls.U_IMPORT frm = new JBControls.U_IMPORT();
            frm.Allow_Repeat_Delete = true;
            frm.Allow_Repeat_Ignore = true;
            frm.Allow_Repeat_Override = true;

            frm.FieldForm = new FRM29IN();
            frm.TemplateButtonVisible = true;
            frm.DataTransfer = new ImportTransferToOT();
            JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();

            frm.DataTransfer.CheckData = new Dictionary<string, List<JBControls.CheckImportData>>();
            frm.DataTransfer.CheckData.Add("加班班別代碼", db.ROTE.Select(p => new JBControls.CheckImportData { DisplayCode = p.ROTE_DISP, RealCode = p.ROTE1, DisplayName = p.ROTENAME }).ToList());
            frm.DataTransfer.CheckData.Add("加班部門代碼", db.DEPTS.Select(p => new JBControls.CheckImportData { DisplayCode = p.D_NO_DISP, RealCode = p.D_NO, DisplayName = p.D_NAME }).ToList());
            frm.DataTransfer.CheckData.Add("員工編號", this.dsBas.BASE.Select(p => new JBControls.CheckImportData { DisplayCode = p.NOBR, RealCode = p.NOBR, DisplayName = p.NAME_C }).ToList());

            frm.DataTransfer.ColumnList = new Dictionary<string, Type>();
            frm.DataTransfer.ColumnList.Add("警告", typeof(string));
            frm.DataTransfer.ColumnList.Add("錯誤註記", typeof(string));
            frm.DataTransfer.ColumnList.Add("計薪年月", typeof(string));
            frm.DataTransfer.ColumnList.Add("員工編號", typeof(string));
            frm.DataTransfer.ColumnList.Add("員工姓名", typeof(string));
            frm.DataTransfer.ColumnList.Add("加班日期", typeof(DateTime));
            frm.DataTransfer.ColumnList.Add("加班起時間", typeof(string));
            frm.DataTransfer.ColumnList.Add("加班迄時間", typeof(string));
            frm.DataTransfer.ColumnList.Add("檢查出勤時間", typeof(string));
            frm.DataTransfer.ColumnList.Add("加班時數", typeof(string));
            frm.DataTransfer.ColumnList.Add("補休時數", typeof(string));
            frm.DataTransfer.ColumnList.Add("總時數", typeof(decimal));
            frm.DataTransfer.ColumnList.Add("有效日期", typeof(DateTime));
            frm.DataTransfer.ColumnList.Add("加班班別代碼", typeof(string));
            frm.DataTransfer.ColumnList.Add("加班班別名稱", typeof(string));
            frm.DataTransfer.ColumnList.Add("加班部門代碼", typeof(string));
            frm.DataTransfer.ColumnList.Add("加班部門名稱", typeof(string));
            frm.DataTransfer.ColumnList.Add("誤餐費", typeof(string));
            frm.DataTransfer.ColumnList.Add("備註", typeof(string));

            frm.DataTransfer.UnMustColumnList = new List<string>();
            frm.DataTransfer.UnMustColumnList.Add("加班班別代碼");
            frm.DataTransfer.UnMustColumnList.Add("加班部門代碼");
            frm.DataTransfer.UnMustColumnList.Add("誤餐費");
            frm.DataTransfer.UnMustColumnList.Add("總時數");
            frm.DataTransfer.UnMustColumnList.Add("有效日期");
            frm.DataTransfer.UnMustColumnList.Add("備註");

            frm.ShowDialog();
        }




    }
}
