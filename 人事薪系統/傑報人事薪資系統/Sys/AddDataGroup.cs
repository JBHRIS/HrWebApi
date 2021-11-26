using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace JBHR.Sys
{
    public partial class AddDataGroup : Form
    {
        public AddDataGroup()
        {
            InitializeComponent();
        }
        public string DataGroup = "";
        public bool Read = false, Write = false;

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (comboBox2.Text.Trim().Length == 0)
            {
                MessageBox.Show("請先選取群組代碼", Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!MainForm.ADMIN && !MainForm.WriteRules.Where(p => p.DATAGROUP == comboBox2.SelectedValue.ToString()).Any())
            {
                MessageBox.Show("你沒有權限刪除該群組的資料", Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            DataGroup = comboBox2.SelectedValue.ToString();
            Read = cbxRead.Checked;
            Write = cbxWrite.Checked;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void AddDataGroup_Load(object sender, EventArgs e)
        {
            var db = new JBModule.Data.Linq.HrDBDataContext();
            var sql = from a in db.COMP_DATAGROUP where a.COMP == MainForm.COMPANY select new { disp = a.DATAGROUP1.GROUPNAME, val = a.DATAGROUP };

            comboBox2.DataSource = sql.CopyToDataTable();
        }
    }
}
