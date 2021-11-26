using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using JBHR.Sal;
using JBHR.Sal.Core;
using JBHR.Sal.Core.OvertTime;
namespace JBHR.Sal
{
    public partial class FRM4B : JBControls.JBForm
    {

        TimeSpan ts;
        int year;
        int month;
        string yymm, nobr_b, nobr_e, dept_b, dept_e, seq;
        DateTime DateB;
        DateTime DateE;
        decimal NoTaxHours;
        public FRM4B()
        {
            InitializeComponent();
        }
        public JBModule.Data.ApplicationConfigSettings AppConfig = null;
        JBModule.Data.Linq.SALARYCALC sclc = new JBModule.Data.Linq.SALARYCALC();
        private void FRM4B_Load(object sender, EventArgs e)
        {
            SystemFunction.CheckAppConfigRule(btnConfig);
            AppConfig = new JBModule.Data.ApplicationConfigSettings("FRM4B", MainForm.COMPANY);
            AppConfig.CheckParameterAndSetDefault("OtBonusSection1", "加班獎金第一段", "50"
                , "設定加班獎金第一段起始時數", "TextBox"
                , "", "String");
            AppConfig.CheckParameterAndSetDefault("OtBonusAmtSection1", "加班獎金第一段金額", "2000"
              , "設定加班獎金第一段金額", "TextBox"
              , "", "String");
            AppConfig.CheckParameterAndSetDefault("OtBonusSection2", "加班獎金第二段", "80"
              , "設定加班獎金第二段起始時數", "TextBox"
              , "", "String");
            AppConfig.CheckParameterAndSetDefault("OtBonusAmtSection2", "加班獎金第二段金額", "4000"
             , "設定加班獎金第二段金額", "TextBox"
             , "", "String");
            AppConfig.CheckParameterAndSetDefault("OtBonusSection3", "加班獎金第三段", "100"
              , "設定加班獎金第三段起始時數", "TextBox"
              , "", "String");
            AppConfig.CheckParameterAndSetDefault("OtBonusAmtSection3", "加班獎金第三段金額", "6000"
           , "設定加班獎金第三段金額", "TextBox"
           , "", "String");
            AppConfig.CheckParameterAndSetDefault("OtBonusSalcode", "加班獎金代碼", ""
         , "設定加班獎金代碼", "ComboBox"
         , "select sal_code,sal_code_disp+'-'+sal_name from salcode where dbo.getcodefilter('SALCODE',SAL_CODE,@userid,@comp,@admin)=1", "String");
            var deptData = CodeFunction.GetDeptDisp();
            SystemFunction.SetComboBoxItems(ptxDeptB, deptData, false);
            SystemFunction.SetComboBoxItems(ptxDeptE, deptData, false);
            Function.SetAvaliableBase(this.salaryDS.BASE);
            txtYear.Text = Sal.Core.SalaryDate.YearString();// (DateTime.Now.Year - 1911).ToString("000");
            txtMonth.Text = Sal.Core.SalaryDate.MonthString();
            ptxDeptB.SelectedValue = deptData.First().Key;
            ptxDeptE.SelectedValue = deptData.Last().Key;
            ptxNobrB.Text = BaseValue.MinNobr;
            ptxNobrE.Text = BaseValue.MaxNobr;
            txtSeq.Text = "2";
            txtYear.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否要執行加班費計算作業?", "訊息", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk) == System.Windows.Forms.DialogResult.Cancel) return;
            year = Convert.ToInt32(txtYear.Text);
            month = Convert.ToInt32(txtMonth.Text);
            Sal.Core.SalaryDate sd = new SalaryDate(year, month);
            yymm = sd.YYMM;
            //string msg = Sal.Function.AttendAlert(sd.FirstDayOfAttend, sd.LastDayOfAttend);
            //if (msg.Trim().Length > 0)
            //{
            //    if (MessageBox.Show(msg + Environment.NewLine + "是否要繼續?", Resources.All.DialogTitle,
            //            MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk) != System.Windows.Forms.DialogResult.OK)
            //    {
            //        return;
            //    }
            //}
            //year += 1911;
           
            DateB = new DateTime(year, month, 1);
            DateE = new DateTime(year, month, DateTime.DaysInMonth(year, month));
            nobr_b = ptxNobrB.Text;
            nobr_e = ptxNobrE.Text;
            dept_b = ptxDeptB.SelectedValue.ToString();
            dept_e = ptxDeptE.SelectedValue.ToString();
            seq = txtSeq.Text;
            if (Function.IsSalaryLocked(yymm, txtSeq.Text, seq))//已鎖檔
            {
                MessageBox.Show(Resources.Sal.WageIsLocked, Resources.All.DialogTitle,
                        MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            BW.RunWorkerAsync();
            this.panel1.Enabled = false;
        }

        void calc_StatusChanged(object sender, JBModule.Message.StatusEventArgs e)
        {
            BW.ReportProgress(e.Percent, e.Result);
        }

        private void txtYear_TextChanged(object sender, EventArgs e)
        {
            //if (txtYear.Text.Length >= 4)
            //    this.SelectNextControl(txtYear, true, true, true, true);
        }

        private void txtMonth_TextChanged(object sender, EventArgs e)
        {
            if (txtMonth.Text.Length >= 2)
                this.SelectNextControl(txtYear, true, true, true, true);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BW_DoWork(object sender, DoWorkEventArgs e)
        {
            DateTime t1, t2;
            t1 = DateTime.Now;
            var db = new JBModule.Data.Linq.HrDBDataContext();
            DateTime DT = DateTime.Now;
            sclc = new JBModule.Data.Linq.SALARYCALC();
            sclc.GUID = Guid.NewGuid();
            sclc.USERID = MainForm.USER_ID;
            sclc.TIMEB = DT;
            sclc.SOURCE = this.Name;
            db.SALARYCALC.InsertOnSubmit(sclc);
            db.SubmitChanges();

            //var sqlNobrTable = db.WriteRuleTable(MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).ToList();
            //if (sqlNobrTable.Count > 0)
            //{
            //    foreach (var item in sqlNobrTable)
            //    {
            //        JBModule.Data.Linq.WriteRuleNobrTable WriteRuleTable = new JBModule.Data.Linq.WriteRuleNobrTable();
            //        WriteRuleTable.GUID = sclc.GUID;
            //        WriteRuleTable.EMPID = item.NOBR;
            //        WriteRuleTable.KEY_DATE = DT;
            //        db.WriteRuleNobrTable.InsertOnSubmit(WriteRuleTable);
            //    }
            //    db.SubmitChanges();
            //}
            OtCalculation calc = new OtCalculation(nobr_b, nobr_e, dept_b, dept_e, yymm, seq);
            calc.guid = sclc.GUID;
            calc.StatusChanged += new JBModule.Message.ReportStatus.StatusChangedEvent(calc_StatusChanged);
            calc.Run();
            t2 = DateTime.Now;
            TimeSpan ts = t2 - t1;
            string msg = string.Format(Resources.Sal.TimeSpan, ts.Minutes, ts.Seconds);
            e.Result = msg;
        }

        private void BW_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result != null && e.Result.ToString().Trim().Length > 0)
                MessageBox.Show(e.Result.ToString(), Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            this.panel1.Enabled = true;
        }

        private void BW_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            trpState.Text = e.UserState.ToString();
            toolStripProgressBar1.Value = e.ProgressPercentage;
        }
    }

    public class OtTaxHours
    {

    }
    public class OtRateHours
    {
        decimal OtHrs = 0;
        OT ot = null;
        OTRATECD otrcd = null;
        public OtRateHours(OT Ot, OTRATECD OtRCD)
        {
            OtHrs = Ot.OT_HRS;
            ot = Ot;
            otrcd = OtRCD;
        }
    }

}