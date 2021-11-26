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
    public partial class FRMG14A : JBControls.JBForm
    {
        public FRMG14A()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!maskedTextBox1.HasTextInput())
            {
                MessageBox.Show(Resources.All.RequiredField, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                maskedTextBox1.Focus();
                return;
            }

            if (!maskedTextBox2.HasTextInput())
            {
                MessageBox.Show(Resources.All.RequiredField, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                maskedTextBox2.Focus();
                return;
            }
            if (!MainForm.WriteRules.Select(p => p.DATAGROUP).Contains(comboBox1.SelectedValue.ToString()))
            {
                MessageBox.Show(Resources.All.WorkadrErr, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            maskedTextBox1.Enabled = false;
            maskedTextBox2.Enabled = false;
            comboBox1.Enabled = false;
            button1.Enabled = false;

            Sys.SysDSTableAdapters.DATA_PATableAdapter DATA_PATableAdapter = new JBHR.Sys.SysDSTableAdapters.DATA_PATableAdapter();

            DateTime d1, d2;
            try
            {
                d1 = Convert.ToDateTime(maskedTextBox1.Text).Date;
                d2 = Convert.ToDateTime(maskedTextBox2.Text).Date;

                DATA_PATableAdapter.DeleteQuery(d1, d2, comboBox1.SelectedValue.ToString(), comboBox2.SelectedValue.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(Resources.All.ExceptionStr1 + "\n" + ex.Message + "\n\n" + Resources.All.ExceptionStr2, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);

                maskedTextBox1.Enabled = true;
                maskedTextBox2.Enabled = true;
                button1.Enabled = true;

                return;
            }

            Sys.SysDS.DATA_PADataTable DATA_PADataTable = new SysDS.DATA_PADataTable();
            var lst = from a in MainForm.WriteRules where a.DATAGROUP.CompareTo(comboBox1.SelectedValue.ToString()) >= 0 && a.DATAGROUP.CompareTo(comboBox2.SelectedValue.ToString()) <= 0 select a;
            foreach (var it in lst)
            {
                d1 = Convert.ToDateTime(maskedTextBox1.Text).Date;
                while (d1 <= d2)
                {
                    Sys.SysDS.DATA_PARow DATA_PARow = DATA_PADataTable.NewDATA_PARow();
                    DATA_PARow.DATA_PASS = d1;
                    DATA_PARow.SALADR = it.DATAGROUP;
                    DATA_PADataTable.AddDATA_PARow(DATA_PARow);

                    d1 = d1.AddDays(1);
                }
            }
            CDataLog.Save(this.Name, MainForm.USER_NAME, DateTime.Now, DATA_PADataTable);
            DATA_PATableAdapter.Update(DATA_PADataTable);

            MessageBox.Show(Resources.Sys.AttendLock, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.None);

            maskedTextBox1.Enabled = true;
            maskedTextBox2.Enabled = true;
            button1.Enabled = true;
            comboBox1.Enabled = true;
            //if (MainForm.PROCSUPER)
            //{
            //    dataComboBox1.Enabled = true;
            //}
            //else
            //{
            //    dataComboBox1.Enabled = false;
            //}
        }

        private void FRMG14A_Load(object sender, EventArgs e)
        {
            var lst = CodeFunction.GetDatagroup();
            SystemFunction.SetComboBoxItems(comboBox1, lst);
            SystemFunction.SetComboBoxItems(comboBox2, lst);
            comboBox1.SelectedValue = lst.First().Key;
            comboBox2.SelectedValue = lst.Last().Key;
            Sal.Core.SalaryDate sd = new Sal.Core.SalaryDate(new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1));
            maskedTextBox1.Text = Sal.Function.GetDate(sd.FirstDayOfAttend);
            maskedTextBox2.Text = Sal.Function.GetDate(sd.LastDayOfAttend);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
