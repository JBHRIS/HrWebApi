using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Data.Linq;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JBHR.Med
{
    public partial class FRM71N_ADD : JBControls.JBForm
    {
        public FRM71N_ADD()
        {
            InitializeComponent();
        }
        public int TW_TAX_AUTO = -1;
        JBModule.Data.Linq.TW_TAX instance = null;
        JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
        private void FRM71N_ADD_Load(object sender, EventArgs e)
        {
            if (TW_TAX_AUTO == -1)
            {
                instance = new JBModule.Data.Linq.TW_TAX();
                instance.Remark = "";
                instance.DateBegin = new DateTime(DateTime.Today.Year, 1, 1);
                instance.DateEnd = new DateTime(DateTime.Today.Year, 12, 31);
                db.TW_TAX.InsertOnSubmit(instance);
            }
            else
                instance = db.TW_TAX.SingleOrDefault(p => p.AUTO == TW_TAX_AUTO);
            if (instance == null)
            {
                MessageBox.Show("查無資料", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }

            if (instance.RelaseDate == null)
                textBoxReleaseDate.Text = "";
            else textBoxReleaseDate.Text = Sal.Function.GetDate(instance.RelaseDate.Value);
            tWTAXBindingSource.DataSource = instance;
        }
        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (textBoxSubject.Text.Trim().Length == 0)
            {
                MessageBox.Show("標題不可以是空白", "警告", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (textBoxYearMonth.Text.Trim().Length == 0)
            {
                MessageBox.Show("年月不可以是空白", "警告", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DateTime ReleaseDate = new DateTime();
            if (DateTime.TryParse(textBoxReleaseDate.Text, out ReleaseDate))
                instance.RelaseDate = ReleaseDate;
            else instance.RelaseDate = null;
            instance.Key_Date = DateTime.Now;
            instance.Key_Man = MainForm.USER_ID;
            db.SubmitChanges();
            this.Close();
        }
    }
}
