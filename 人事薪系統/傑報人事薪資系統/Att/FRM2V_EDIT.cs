using JBModule.Data.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace JBHR.Att
{
    public partial class FRM2V_EDIT : Form
    {
        public FRM2V_EDIT()
        {
            InitializeComponent();
        }
        public int Id = -1;
        public int CheckId = -1;
        ATTEND_ABNORMAL errorRecord;
        ATTEND_ABNORMAL_CHECK checkRecord;
        JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
        private void FRM2V_EDIT_Load(object sender, EventArgs e)
        {
            SystemFunction.SetComboBoxItems(comboBoxErrorType, CodeFunction.GetMtCode("ATTEND_ABNORMAL"), false, true);
            SystemFunction.SetComboBoxItems(comboBoxRemarkType, CodeFunction.GetMtCode("ATTEND_ABNORMAL_CHECK"), false, true);
            errorRecord = db.ATTEND_ABNORMAL.SingleOrDefault(p => p.ID == Id);
            if (errorRecord != null)
            {
                dtpDate.Value = errorRecord.ADATE;
                comboBoxErrorType.SelectedValue = errorRecord.TYPE;
                textBoxRoteOnTime.Text = errorRecord.ON_TIME;
                textBoxRoteOffTime.Text = errorRecord.OFF_TIME;
                textBoxCardOnTime.Text = errorRecord.ON_TIME_ACTUAL;
                textBoxCardOffTime.Text = errorRecord.OFF_TIME_ACTUAL;
                textBoxErrorMinutes.Text = errorRecord.ERROR_MINS.ToString();
                if (CheckId != -1)
                {
                    checkRecord = db.ATTEND_ABNORMAL_CHECK.SingleOrDefault(p => p.ID == CheckId);
                }
                else
                {
                    checkRecord = new ATTEND_ABNORMAL_CHECK();
                    checkRecord.ADATE = errorRecord.ADATE;
                    checkRecord.NOBR = errorRecord.NOBR;
                    checkRecord.TYPE = errorRecord.TYPE;
                    checkRecord.CREATE_DATE = DateTime.Now;
                    checkRecord.CREATE_MAN = MainForm.USER_NAME;
                    db.ATTEND_ABNORMAL_CHECK.InsertOnSubmit(checkRecord);
                }
                aTTENDABNORMALCHECKBindingSource.DataSource = checkRecord;
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (Sal.Function.IsAttendLocked(errorRecord.ADATE, errorRecord.NOBR))
            {
                MessageBox.Show("考勤已鎖檔");
                return;
            }
            if (comboBoxRemarkType.SelectedIndex == -1)
            {
                MessageBox.Show("請選擇註記種類");
                return;
            }
            if (textBoxRemark.Text.Trim().Length == 0)
            {
                MessageBox.Show("請輸入註記說明");
                return;
            }
            checkRecord.UPDATE_DATE = DateTime.Now;
            checkRecord.UPDATE_MAN = MainForm.USER_NAME;
            db.SubmitChanges();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {

        }
    }
}
