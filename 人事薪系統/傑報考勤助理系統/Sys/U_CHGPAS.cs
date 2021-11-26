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
	public partial class U_CHGPAS : JBControls.JBForm
	{
		public U_CHGPAS()
		{
			InitializeComponent();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			if (textBox2.Text.Trim().Length == 0)
			{
				MessageBox.Show(Resources.Sys.pass1Required, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}
			if (textBox3.Text.Trim().Length == 0)
			{
				MessageBox.Show(Resources.Sys.pass2Required, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}
			if (textBox3.Text != textBox2.Text)
			{
				MessageBox.Show(Resources.Sys.TwoInputPasswordErrorMsg, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
				textBox2.Text = "";
				textBox3.Text = "";
				textBox2.Focus();
				return;
			}

			Sys.SysDS.U_USERDataTable U_USERDataTable = new JBHR.Sys.SysDS.U_USERDataTable();
			Sys.SysDSTableAdapters.U_USERTableAdapter U_USERTableAdapter = new JBHR.Sys.SysDSTableAdapters.U_USERTableAdapter();
			U_USERTableAdapter.FillByUSERID(U_USERDataTable, textBox1.Text);
			if (U_USERDataTable.Count > 0)
			{
				U_USERDataTable[0].PASSWORD = JBModule.Data.CEncrypt.Text(textBox2.Text.Trim().ToLower());
				CDataLog.Save(this.Name, MainForm.USER_NAME, DateTime.Now, U_USERDataTable);
				U_USERTableAdapter.Update(U_USERDataTable);
			}			

			MessageBox.Show(Resources.Sys.PasswordChangeSuccess, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.None);
			this.Close();
		}

		private void U_CHGPAS_Load(object sender, EventArgs e)
		{
			textBox1.Text = MainForm.USER_ID;
		}
	}
}
