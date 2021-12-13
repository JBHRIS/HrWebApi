using JBTools.Extend;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using JBTools;

namespace JBHR.Att
{
    public partial class FRM27A_ADD : JBControls.JBForm
    {
        public FRM27A_ADD()
        {
            InitializeComponent();
        }

        public List<Dictionary<string, string>> keys = new List<Dictionary<string, string>>();
        private void FRM27A_ADD_Load(object sender, EventArgs e)
        {
            SystemFunction.SetComboBoxItems(cbxROTE_H, CodeFunction.GetRote(), false, true, true);
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
            foreach (var key in keys)
            {
                string nobr = key["員工編號"].ToString();
                DateTime adate = Convert.ToDateTime(key["出勤日期"].ToString());
                var attend = db.ATTEND.Where(p => p.NOBR == nobr && p.ADATE == adate).FirstOrDefault();
                if (attend != null)
                {
                    attend.ROTE_H = cbxROTE_H.SelectedValue.ToString();
                    attend.CANT_ADJ = true; 
                }
            }
            db.SubmitChanges();
            if (chkTransCard.Checked)
            {
                object[] parameters = new object[] { keys };
                BW.RunWorkerAsync(parameters);
                tableLayoutPanel1.Enabled = false;
            }
            else
                this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BW_DoWork(object sender, DoWorkEventArgs e)
        {
            FRM2G fRM = new FRM2G();
            object[] parameters = e.Argument as object[];
            List<Dictionary<string, string>> keys = parameters[0] as List<Dictionary<string, string>>;
            JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
            int nowcount = 0, totalcount = keys.Count;
            string Dept_Disp_Min = CodeFunction.GetDeptDisp().First().Key;
            string Dept_Disp_Max = CodeFunction.GetDeptDisp().Last().Key;
            Stopwatch sw = new Stopwatch();
            DateTime t1, t2;
            t1 = sw.Start();

            foreach (var key in keys)
            {
                string nobr = key["員工編號"].ToString();
                DateTime adate = Convert.ToDateTime(key["出勤日期"].ToString());
                var attend = db.ATTEND.Where(p => p.NOBR == nobr && p.ADATE == adate).FirstOrDefault();
                if (attend != null)
                {
                    nowcount++;
                    BW.ReportProgress(Convert.ToInt32(Convert.ToDecimal(nowcount) / Convert.ToDecimal(totalcount) * 100), string.Format("正在執行{0},{1}的刷卡轉出勤", attend.NOBR, attend.ADATE.ToShortDateString()));
                    object[] parameter = new object[] { attend.ADATE, attend.ADATE, attend.NOBR, attend.NOBR, Dept_Disp_Min, Dept_Disp_Max, true, true, true, true, false, true };
                    fRM.OneDayTrans(parameter);
                }
            }
            t2 = sw.Stop();
            var ts = t2 - t1;
            string msg = "共耗時";
            if (ts.Hours > 0)
                msg += string.Format("{0}時", Convert.ToInt32(ts.Hours).ToString());
            msg += string.Format("{0}分{1}秒.", Convert.ToInt32(ts.Minutes).ToString(), Convert.ToInt32(ts.Seconds).ToString());
            e.Result = msg;
            BW.ReportProgress(100, "完成.");
        }

        private void BW_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            toolStripProgressBar1.Value = e.ProgressPercentage;
            trpState.Text = e.UserState.ToString();
        }

        private void BW_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result != null && e.Result.ToString().Trim().Length > 0)
                MessageBox.Show(e.Result.ToString(), Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            tableLayoutPanel1.Enabled = true;
            this.Close();
        }
    }
}
