using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using JBModule.Data.Linq;
namespace JBHR.Att
{
    public partial class FRM2IB : JBControls.JBForm
    {
        public FRM2IB()
        {
            InitializeComponent();
        }
        public JBModule.Data.ApplicationConfigSettings AppConfig = null;
        private void FRM2O_Load(object sender, EventArgs e)
        {
            SystemFunction.CheckAppConfigRule(btnConfig);
            AppConfig = new JBModule.Data.ApplicationConfigSettings("FRM2IB", MainForm.COMPANY);
            AppConfig.CheckParameterAndSetDefault("ExpireCode1", "特休失效代碼", "", "設定特休延休代碼", "ComboBox", "select h_code,h_code_disp+'-'+h_name from hcode where dbo.getcodefilter('HCODE',H_CODE,@userid,@comp,@admin)=1 order by h_code_disp", "String");
            AppConfig.CheckParameterAndSetDefault("ExpireCode2", "補休失效代碼", "", "設定補休延休代碼", "ComboBox", "select h_code,h_code_disp+'-'+h_name from hcode where dbo.getcodefilter('HCODE',H_CODE,@userid,@comp,@admin)=1 order by h_code_disp", "String");
            AppConfig.CheckParameterAndSetDefault("ExpireCode3", "彈休失效代碼", "", "設定彈休延休代碼", "ComboBox", "select h_code,h_code_disp+'-'+h_name from hcode where dbo.getcodefilter('HCODE',H_CODE,@userid,@comp,@admin)=1 order by h_code_disp", "String");
            this.jOBLTableAdapter.Fill(this.dsBas.JOBL);
            this.jOBTableAdapter.Fill(this.dsBas.JOB);
            this.dEPTTableAdapter.Fill(this.dsBas.DEPT);
            Sal.Function.SetAvaliableBase(this.dsBas.BASE);
            this.ptxNobrB.Text = this.dsBas.BASE.First().NOBR;
            this.ptxNobrE.Text = this.dsBas.BASE.Last().NOBR;
            //this.ptxJoblE.Text = Sal.BaseValue.MaxJobl;
            int yy, MM, dd;
            yy = DateTime.Now.Year;
            MM = DateTime.Now.Month;
            dd = DateTime.Now.Day;
            DateTime d1, d2;
            d1 = new DateTime(yy, 1, 1);
            d2 = DateTime.Now.Date;
            txtBdate.Text = Sal.Core.SalaryDate.DateString(d1);
            txtEdate.Text = Sal.Core.SalaryDate.DateString(d2);
            txtYear.Text = DateTime.Now.Year.ToString();
            //txtExpireDate.Text = Sal.Core.SalaryDate.DateString();
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            BW.RunWorkerAsync();
            panel1.Enabled = false;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BW_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                DateTime t1, t2;
                t1 = DateTime.Now;

                DateTime d1, d2;
                d1 = Convert.ToDateTime(txtBdate.Text);
                d2 = Convert.ToDateTime(txtEdate.Text);
                JBHR.BLL.Att.AbsDisable ad = new BLL.Att.AbsDisable(ptxNobrB.Text, ptxNobrE.Text, MainForm.USER_NAME, checkBox1.Checked);
                ad.StatusChanged += new JBModule.Message.ReportStatus.StatusChangedEvent(ad_StatusChanged);
                if (rdbType1.Checked)
                {
                    ad.YearRest1 = "1";
                    ad.YearRest2 = "2";
                    ad.ExpireCode = AppConfig.GetConfig("ExpireCode1").GetString();
                    if (ad.ExpireCode.Trim().Length == 0)
                    {
                        BW.ReportProgress(5, "請先設定特休失效代碼");
                        return;
                    }
                }
                if (rdbType2.Checked)
                {
                    ad.YearRest1 = "3";
                    ad.YearRest2 = "4";
                    ad.ExpireCode = AppConfig.GetConfig("ExpireCode2").GetString();
                    if (ad.ExpireCode.Trim().Length == 0)
                    {
                        BW.ReportProgress(5, "請先設定補休失效代碼");
                        return;
                    }
                }
                if (rdbType3.Checked)
                {
                    ad.YearRest1 = "5";
                    ad.YearRest2 = "6";
                    ad.ExpireCode = AppConfig.GetConfig("ExpireCode3").GetString();
                    if (ad.ExpireCode.Trim().Length == 0)
                    {
                        BW.ReportProgress(5,"請先設定彈休失效代碼");
                        return;
                    }
                }
               
                ad.Run(d1, d2);

                t2 = DateTime.Now;
                TimeSpan ts = t2 - t1;
                string msg = string.Format(Resources.Sal.TimeSpan, ts.Minutes, ts.Seconds);
                e.Result = msg;
                BW.ReportProgress(100, "完成");
            }
            catch (Exception ex)
            {
                string err = "執行時發生錯誤";
                JBModule.Message.TextLog.WriteLog(ex, err);
                e.Result = err;
            }
        }

        void ad_StatusChanged(object sender, JBModule.Message.StatusEventArgs e)
        {
            BW.ReportProgress(e.Percent, e.Result);
        }

        private void BW_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            toolStripProgressBar1.Value = e.ProgressPercentage;
            trpState.Text = e.UserState.ToString();
        }

        private void BW_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            panel1.Enabled = true;
            MessageBox.Show(e.Result.ToString(), Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void btnConfig_Click(object sender, EventArgs e)
        {

        }

    }
}
