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
    public partial class CopyBonusSetting : Form
    {
        public CopyBonusSetting()
        {
            InitializeComponent();
        }
        public string CurrentRote = "";
        public bool Read = false, Write = false;

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (comboBox2.Text.Trim().Length == 0)
            {
                MessageBox.Show("請先選取群組代碼", Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (comboBox2.SelectedValue.ToString().Trim().ToUpper() == CurrentRote.Trim().ToUpper())
            {
                MessageBox.Show("不可選取相同的班別設定", Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
            var sql = from a in db.ROTE_BONUS where a.ROTE == CurrentRote select a;
            if (sql.Any())
            {
                if (MessageBox.Show("目前的班別已有設定資料，執行複製的話將會刪除原本的設定，是否要繼續?", Resources.All.DialogTitle, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.OK)
                {
                    foreach (var it in sql)
                    {
                        var calCond = (from a in db.CALC_CONDITION where a.SOURCE == "RoteBonusConditionType" && a.CODE == it.AUTO.ToString() select a).ToList();
                        db.CALC_CONDITION.DeleteAllOnSubmit(calCond);
                    }
                    db.ROTE_BONUS.DeleteAllOnSubmit(sql);
                    db.SubmitChanges();
                }
                else return;
            }
            CopySetting(comboBox2.SelectedValue.ToString());
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            MessageBox.Show("複製完成", Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void AddDataGroup_Load(object sender, EventArgs e)
        {
            //var db = new JBModule.Data.Linq.HrDBDataContext();
            //var sql = from a in db.COMP_DATAGROUP where a.COMP == MainForm.COMPANY select new { disp = a.DATAGROUP1.GROUPNAME, val = a.DATAGROUP };

            //comboBox2.DataSource = sql.CopyToDataTable();
            SystemFunction.SetComboBoxItems(comboBox2, CodeFunction.GetRote());
        }
        void CopySetting(string Rote)
        {
            JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
            var sql = from a in db.ROTE_BONUS where a.ROTE == Rote select a;
            var calCond = (from a in db.CALC_CONDITION where a.SOURCE == "RoteBonusConditionType" select a).ToList();
            var ls1 = new List<JBModule.Data.Linq.ROTE_BONUS>();
            var ls2 = new List<JBModule.Data.Linq.CALC_CONDITION>();
            foreach (var it in sql)
            {
                JBModule.Data.Linq.ROTE_BONUS rb = new JBModule.Data.Linq.ROTE_BONUS();
                rb.AMT = it.AMT;
                rb.CHECK1 = it.CHECK1;
                rb.CHECK2 = it.CHECK2;
                rb.CHECK3 = it.CHECK3;
                rb.CHECK4 = it.CHECK4;
                rb.CHECK5 = it.CHECK5;
                rb.CHECK6 = it.CHECK6;
                rb.KEY_DATE = DateTime.Now;
                rb.KEY_MAN = MainForm.USER_NAME;
                rb.ROTE = CurrentRote;
                rb.SAL_CODE = it.SAL_CODE;
                rb.SORT = it.SORT;
                rb.STR_B = it.STR_B;
                rb.STR_E = it.STR_E;
                rb.VALUE1 = it.VALUE1;
                rb.VALUE2 = it.VALUE2;
                db.ROTE_BONUS.InsertOnSubmit(rb);
                db.SubmitChanges();
                var dd = calCond.Where(p => p.CODE == it.AUTO.ToString());
                foreach (var r in dd)
                {
                    JBModule.Data.Linq.CALC_CONDITION cc = new JBModule.Data.Linq.CALC_CONDITION();
                    cc.CODE = rb.AUTO.ToString();
                    cc.COND_TYPE = r.COND_TYPE;
                    cc.KEY_DATE = DateTime.Now;
                    cc.KEY_MAN = MainForm.USER_NAME;
                    cc.SOURCE = r.SOURCE;
                    cc.VALUE1 = r.VALUE1;
                    cc.VALUE2 = r.VALUE2;
                    cc.CONDITION = r.CONDITION;
                    db.CALC_CONDITION.InsertOnSubmit(cc);
                }
            }
            //db.ROTE_BONUS.InsertAllOnSubmit(ls1);
            db.SubmitChanges();

        }
    }
}
