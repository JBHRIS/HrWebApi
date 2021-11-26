using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Windows.Forms;
using JBHR.Sal;
using JBHR.Sal.Core;
namespace JBHR.Sal
{
    public partial class FRM4C : JBControls.JBForm
    {
        class param
        {
            public string YYMM;
            public string NOBRB, NOBRE;
            public string DEPTB, DEPTE;
            public string SEQ;
            public DateTime DateB, DateE;
        }
        static decimal year_days = 365.24M;
        TimeSpan ts;
        public JBModule.Data.ApplicationConfigSettings AppConfig = null;
        JBModule.Data.Linq.SALARYCALC sclc = new JBModule.Data.Linq.SALARYCALC();
        public FRM4C()
        {
            InitializeComponent();
        }
        private void FRM4C_Load(object sender, EventArgs e)
        {
            SystemFunction.CheckAppConfigRule(btnConfig);
            AppConfig = new JBModule.Data.ApplicationConfigSettings("FRM4C", MainForm.COMPANY);
            AppConfig.CheckParameterAndSetDefault("DI", "請假直間接", ""
                , "設定請假計算時要計算直接或是間接人員(D-直接,I-間接)", "TextBox"
                , "", "String");
            AppConfig.CheckParameterAndSetDefault("LateCode", "遲到代碼", ""
              , "指定遲到代碼", "ComboBox", "select h_code,h_code_disp+'-'+h_name from hcode where dbo.getcodefilter('HCODE',H_CODE,@userid,@comp,@admin)=1", "String");
            AppConfig.CheckParameterAndSetDefault("EarilyCode", "早退代碼", ""
                , "指定早退代碼", "ComboBox", "select h_code,h_code_disp+'-'+h_name from hcode where dbo.getcodefilter('HCODE',H_CODE,@userid,@comp,@admin)=1", "String");
            AppConfig.CheckParameterAndSetDefault("AbsenceCode", "曠職代碼", ""
               , "指定曠職代碼", "ComboBox", "select h_code,h_code_disp+'-'+h_name from hcode where dbo.getcodefilter('HCODE',H_CODE,@userid,@comp,@admin)=1", "String");
           
            var deptData = CodeFunction.GetDeptDisp();
            SystemFunction.SetComboBoxItems(txtDeptB, deptData, false);
            SystemFunction.SetComboBoxItems(txtDeptE, deptData, false);
            Sal.Function.SetAvaliableVBase(this.fRM4CDS.V_BASE);
            //this.dEPTTableAdapter.Fill(this.fRM4CDS.DEPT);
            Sal.Core.SalaryDate sd = new SalaryDate(DateTime.Now.Date, true);
            txtYear.Text = Sal.Core.SalaryDate.YearString();
            txtMonth.Text = Sal.Core.SalaryDate.MonthDayString();
            txtNobrB.Text = this.fRM4CDS.V_BASE.Min(r => r.NOBR).Trim();
            txtNobrE.Text = this.fRM4CDS.V_BASE.Max(r => r.NOBR).Trim();
            txtDeptB.SelectedValue = deptData.First().Key;
            txtDeptE.SelectedValue = deptData.Last().Key;
            txtDateB.Text = Sal.Function.GetDate(sd.FirstDayOfAttend);
            txtDateE.Text = Sal.Function.GetDate(sd.LastDayOfAttend);
            txtSeq.Text = "2";
        }

        private void btnCalc_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否要執行請假扣款計算作業?", "訊息", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk) == System.Windows.Forms.DialogResult.Cancel) return;
            progressBar1.Value = 0;
            int yy, mm;
            yy = int.Parse(txtYear.Text);
            mm = int.Parse(txtMonth.Text);
            param p = new param();
            p.YYMM = yy.ToString("0000") + mm.ToString("00");
            p.NOBRB = txtNobrB.Text.Trim();
            p.NOBRE = txtNobrE.Text.Trim();
            p.DEPTB = txtDeptB.SelectedValue.ToString();
            p.DEPTE = txtDeptE.SelectedValue.ToString();
            p.DateB = Convert.ToDateTime(txtDateB.Text);
            p.DateE = Convert.ToDateTime(txtDateE.Text);
            p.SEQ = txtSeq.Text;
            //string msg = Sal.Function.AttendAlert(sd.FirstDayOfAttend, sd.LastDayOfAttend);
            //if (msg.Trim().Length > 0)
            //{
            //    if (MessageBox.Show(msg + Environment.NewLine + "是否要繼續?", Resources.All.DialogTitle,
            //            MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk) != System.Windows.Forms.DialogResult.OK)
            //    {
            //        return;
            //    }
            //}
            if (Function.IsSalaryLocked(p.YYMM, txtSeq.Text, MainForm.WORKADR))//已鎖檔
            {
                MessageBox.Show(Resources.Sal.WageIsLocked, Resources.All.DialogTitle,
                        MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            this.panel1.Enabled = false;
            BW.RunWorkerAsync(p);
        }

        //bool a(string t1, string t2, string t3)
        //{
        //    return false;
        //}

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                DateTime d1, d2;
                d1 = DateTime.Now;
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

                param p = e.Argument as param;
                AbsCalculation calc = new AbsCalculation(p.NOBRB, p.NOBRE, p.DEPTB, p.DEPTE, p.YYMM, p.DateB, p.DateE, p.SEQ);
                calc.StatusChanged += new JBModule.Message.ReportStatus.StatusChangedEvent(calc_StatusChanged);
                calc.guid = sclc.GUID;
                calc.Run();
                d2 = DateTime.Now;
                ts = d2 - d1;
            }
            catch (System.Data.Linq.DuplicateKeyException ex)
            {
                BW.ReportProgress(100, "計算時發生錯誤");
                JBModule.Message.TextLog.WriteLog(ex);
                e.Result = ex;
            }
            catch (Exception ex)
            {
                BW.ReportProgress(100, "計算時發生錯誤");
                JBModule.Message.TextLog.WriteLog(ex);
                e.Result = ex;
            }

        }

        void calc_StatusChanged(object sender, JBModule.Message.StatusEventArgs e)
        {
            BW.ReportProgress(e.Percent, e.Result);
        }
        void Delete(string yymm, string nobr_b, string nobr_e, string dept_b, string dept_e)
        {
            SalaryMDDataContext smd = new SalaryMDDataContext();
            SalaryDate sd = new SalaryDate(yymm);
            object[] parms = new object[] { nobr_b, nobr_e, dept_b, dept_e, yymm };
            smd.ExecuteCommand("DELETE SALABS FROM SALABS" +
            " JOIN BASETTS ON SALABS.NOBR=BASETTS.NOBR AND SALABS.ADATE BETWEEN BASETTS.ADATE AND BASETTS.DDATE" +
            " WHERE (SALABS.NOBR BETWEEN {0} AND {1})" +
            " AND (BASETTS.DEPT BETWEEN {2} AND {3})" +
            " AND SALABS.YYMM={4}", parms);
        }
        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            trpState.Text = e.UserState.ToString();
            progressBar1.Value = e.ProgressPercentage;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            var ex = e.Result as Exception;
            if (ex != null)
            {
                string msg = "計算時發生錯誤" + Environment.NewLine + ex.Message;
                MessageBox.Show(msg, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string msg = string.Format(Resources.Sal.TimeSpan, ts.Minutes.ToString(), ts.Seconds.ToString());
                MessageBox.Show(msg, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            this.panel1.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtDateB_Validated(object sender, EventArgs e)
        {
            var dd = Convert.ToDateTime(txtDateB.Text);
            var d2 = dd.AddMonths(1).AddDays(-1);
            txtDateE.Text = Sal.Function.GetDate(d2);
        }

        private void txtYear_Validated(object sender, EventArgs e)
        {
            int yy, mm;
            yy = int.Parse(txtYear.Text);
            mm = int.Parse(txtMonth.Text);
            var YYMM = yy.ToString("0000") + mm.ToString("00");
            Sal.Core.SalaryDate sd = new SalaryDate(YYMM);
            txtDateB.Text = Sal.Function.GetDate(sd.FirstDayOfAttend);
            txtDateE.Text = Sal.Function.GetDate(sd.LastDayOfAttend);
        }

        private void btnConfigMtCode_Click(object sender, EventArgs e)
        {

        }
    }
}
