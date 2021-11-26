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
    public partial class FRMG14 : JBControls.JBForm
    {
        public FRMG14()
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
            if (!MainForm.WriteRules.Select(p => p.DATAGROUP).Contains(comboBox1.SelectedValue))
            {
                MessageBox.Show(Resources.All.WorkadrErr, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            maskedTextBox1.Enabled = false;
            maskedTextBox2.Enabled = false;
            comboBox1.Enabled = false;
            button1.Enabled = false;

            Sys.SysDSTableAdapters.DATA_PASSTableAdapter DATA_PASSTableAdapter = new JBHR.Sys.SysDSTableAdapters.DATA_PASSTableAdapter();

            DateTime d1, d2;
            try
            {
                d1 = Convert.ToDateTime(maskedTextBox1.Text).Date;
                d2 = Convert.ToDateTime(maskedTextBox2.Text).Date;

                DATA_PASSTableAdapter.DeleteQuery(d1, d2, comboBox1.SelectedValue.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(Resources.All.ExceptionStr1 + "\n" + ex.Message + "\n\n" + Resources.All.ExceptionStr2, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);

                maskedTextBox1.Enabled = true;
                maskedTextBox2.Enabled = true;
                button1.Enabled = true;

                return;
            }

            Sys.SysDS.DATA_PASSDataTable DATA_PASSDataTable = new SysDS.DATA_PASSDataTable();

            while (d1 <= d2)
            {
                Sys.SysDS.DATA_PASSRow DATA_PASSRow = DATA_PASSDataTable.NewDATA_PASSRow();
                DATA_PASSRow.DATA_PASS = d1;
                DATA_PASSRow.SALADR = comboBox1.SelectedValue.ToString();
                DATA_PASSDataTable.AddDATA_PASSRow(DATA_PASSRow);

                d1 = d1.AddDays(1);
            }


            CDataLog.Save(this.Name, MainForm.USER_NAME, DateTime.Now, DATA_PASSDataTable);
            DATA_PASSTableAdapter.Update(DATA_PASSDataTable);

            MessageBox.Show(Resources.Sys.AttendLock, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.None);

            maskedTextBox1.Enabled = true;
            maskedTextBox2.Enabled = true;
            comboBox1.Enabled = true;
            button1.Enabled = true;
        }

        private void FRMG14_Load(object sender, EventArgs e)
        {
            SystemFunction.SetComboBoxItems(comboBox1, CodeFunction.GetDatagroup());    
            comboBox1.SelectedValue = MainForm.ReadRules.First().DATAGROUP;
            Sal.Core.SalaryDate sd = new Sal.Core.SalaryDate(new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1));
            maskedTextBox1.Text = Sal.Function.GetDate(sd.FirstDayOfAttend);
            maskedTextBox2.Text = Sal.Function.GetDate(sd.LastDayOfAttend);
        }
    }
}
