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
    public partial class FRMG13A : JBControls.JBForm
    {
        public FRMG13A()
        {
            InitializeComponent();
        }

        private void FRMG13A_Load(object sender, EventArgs e)
        {
            var lst = CodeFunction.GetDatagroup();
            SystemFunction.SetComboBoxItems(comboBox1, lst);
            SystemFunction.SetComboBoxItems(comboBox2, lst);
            comboBox1.SelectedValue = lst.First().Key;
            comboBox2.SelectedValue = lst.Last().Key;
            maskedTextBox1.Focus();
            Sal.Core.SalaryDate sd = new Sal.Core.SalaryDate(new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1));
            maskedTextBox1.Text = Sal.Function.GetDate(sd.FirstDayOfAttend);
            maskedTextBox2.Text = Sal.Function.GetDate(sd.LastDayOfAttend);
            //dataComboBox1.SelectedValue = MainForm.ReadRules.First().DATAGROUP;

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

            DateTime d1, d2;
            try
            {
                d1 = Convert.ToDateTime(maskedTextBox1.Text).Date;
                d2 = Convert.ToDateTime(maskedTextBox2.Text).Date;
            }
            catch (Exception ex)
            {
                MessageBox.Show(Resources.All.ExceptionStr1 + "\n" + ex.Message + "\n\n" + Resources.All.ExceptionStr2, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }

            dATA_PATableAdapter.FillByDATAPASSBETWEEN(sysDS.DATA_PA, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN, d1, d2, comboBox1.SelectedValue.ToString(), comboBox2.SelectedValue.ToString());


            if (!MainForm.WriteRules.Select(p => p.DATAGROUP).Contains(comboBox1.SelectedValue))
            {
                button3.Enabled = false;
                button2.Enabled = false;
            }
            else
            {
                button3.Enabled = true;
                button2.Enabled = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridViewEx1.Rows)
            {
                row.Cells["Column1"].Value = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(Resources.Sys.CancelAttendLock, Resources.All.DialogTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                maskedTextBox1.Enabled = false;
                maskedTextBox2.Enabled = false;
                button1.Enabled = false;
                button2.Enabled = false;
                button3.Enabled = false;

                List<DataRowView> delete_rows = new List<DataRowView>();

                foreach (DataGridViewRow row in dataGridViewEx1.Rows)
                {
                    if (Convert.ToBoolean(row.Cells["Column1"].Value))
                    {
                        delete_rows.Add(row.DataBoundItem as DataRowView);
                    }
                }

                foreach (var row in delete_rows)
                {
                    row.Delete();
                }

                CDataLog.Save(this.Name, MainForm.USER_NAME, DateTime.Now, sysDS.DATA_PA);
                dATA_PATableAdapter.Update(sysDS.DATA_PA);

                MessageBox.Show(Resources.Sys.CancelAttendComplete, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.None);

                maskedTextBox1.Enabled = true;
                maskedTextBox2.Enabled = true;
                button1.Enabled = true;
                button2.Enabled = true;
                button3.Enabled = true;
            }
        }

        private void dataComboBox1_SelectedIndexChange(object sender, EventArgs e)
        {
            sysDS.DATA_PA.Clear();

            if (!MainForm.WriteRules.Select(p => p.DATAGROUP).Contains(comboBox1.SelectedValue.ToString()))
            {
                button3.Enabled = false;
                button2.Enabled = false;
            }
            else
            {
                button3.Enabled = true;
                button2.Enabled = true;
            }
        }
    }
}
