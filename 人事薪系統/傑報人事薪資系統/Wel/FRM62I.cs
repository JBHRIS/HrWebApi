using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace JBHR.Wel
{
	public partial class FRM62I : JBControls.JBForm
	{
		System.Data.OleDb.OleDbConnection OleDbConnection;

		public FRM62I()
		{
			InitializeComponent();
			
			cbNobr.Enabled = false;
			cbAmt.Enabled = false;
			cbDAmt.Enabled = false;
			txtYYMM.Enabled = false;
			txtSeq.Enabled = false;
			cbSalcode.Enabled = false;
			cbFormat.Enabled = false;
			button2.Enabled = false;
		}

		private void button1_Click(object sender, EventArgs e)
		{
			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				txtFileName.Text = openFileDialog.FileName;

                DataTable excelDataTable = JBModule.Data.CNPOI.RenderDataTableFromExcel(txtFileName.Text, 0, 0);
                dataGridViewEx1.DataSource = excelDataTable;

                cbNobr.ClearItems();
                cbNobr.ValueMember = "ColumnName";
                cbNobr.AddItem((from DataColumn c in excelDataTable.Columns select c.ColumnName).ToArray());

                cbAmt.ClearItems();
                cbAmt.ValueMember = "ColumnName";
                cbAmt.AddItem((from DataColumn c in excelDataTable.Columns select c.ColumnName).ToArray());

                cbDAmt.ClearItems();
                cbDAmt.ValueMember = "ColumnName";
                cbDAmt.AddItem((from DataColumn c in excelDataTable.Columns select c.ColumnName).ToArray());

                cbNobr.Enabled = true;
                cbAmt.Enabled = true;
                cbDAmt.Enabled = true;
                txtYYMM.Enabled = true;
                txtSeq.Enabled = true;
                cbSalcode.Enabled = true;
                cbFormat.Enabled = true;
                button2.Enabled = true;		
			}
		}

		private void button2_Click(object sender, EventArgs e)
		{
            string msg = "";
            if (string.IsNullOrEmpty(cbNobr.SelectedText))
            {
                msg = "請選擇員工編號！";
            }
            else if (string.IsNullOrEmpty(cbAmt.SelectedText))
            {
                msg = "請選擇金額！";
            }
            else if (string.IsNullOrEmpty(cbDAmt.SelectedText))
            {
                msg = "請選擇扣繳稅額！";
            }
            else if (string.IsNullOrEmpty(txtYYMM.Text))
            {
                msg = "請輸入計薪年月！";
                txtYYMM.Focus();
            }
            else if (string.IsNullOrEmpty(txtSeq.Text))
            {
                msg = "請輸入計薪年月！";
                txtSeq.Focus();
            }
            else if (string.IsNullOrEmpty(cbSalcode.SelectedValue))
            {
                msg = "請選擇福利代號！";
            }
            else if (string.IsNullOrEmpty(cbFormat.SelectedValue))
            {
                msg = "請選擇格式！";
            }
            if (!string.IsNullOrEmpty(msg))
            {
                MessageBox.Show(msg);
                return;
            }

			FRM63DataClassesDataContext db = new FRM63DataClassesDataContext();
			WelDataClassesDataContext db1 = new WelDataClassesDataContext();
			try
			{
				this.Enabled = false;

				try
				{
					if (db.Connection.State == ConnectionState.Closed) db.Connection.Open();
					db.ExecuteCommand("delete from welf where yymm='" + txtYYMM.Text + "' and seq='" + txtSeq.Text + "' and sal_code='" + cbSalcode.SelectedValue + "' and format='" + cbFormat.SelectedValue + "'");
				}
				finally
				{
					db.Connection.Close();
				}

				DataTable dt = dataGridViewEx1.DataSource as DataTable;

				var BASE = from c in db1.V_BASE select c;

				V_BASE[] baseArray = BASE.ToArray();
				//檢查 Excel 的資料，是否在 BASE 有對應的工號
				List<string> errData1 = new List<string>();
				foreach (DataRow row in dt.Rows)
				{
					if (!baseArray.Any(rowBase => rowBase.NOBR.Trim() == row[cbNobr.SelectedValue].ToString().Trim()))
					{
						errData1.Add(row[cbNobr.SelectedValue].ToString().Trim());
					}
				}

				if (errData1.Count > 0)
				{
					string err = "";
					foreach (var ss in errData1)
					{
						if (ss != "") err += ",";
						err += ss;
					}
					MessageBox.Show(Resources.Ins.Import_DataErr + "\n" + err, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.None);
				}
				else
				{
					foreach (DataRow row in dt.Rows)
					{
						var v_base = db1.V_BASE.Where(c => c.NOBR.Trim().ToLower() == row[cbNobr.SelectedValue].ToString().Trim().ToLower());
						if (v_base.Count() > 0)
						{
							WELF welf = new WELF();
							welf.NOBR = row[cbNobr.SelectedValue].ToString().Trim();
							welf.YYMM = txtYYMM.Text;
							welf.SEQ = txtSeq.Text;
							welf.SAL_CODE = cbSalcode.SelectedValue;
							welf.FORMAT = cbFormat.SelectedValue;
							if (row.IsNull(cbAmt.SelectedValue)) welf.AMT = 0;
							else welf.AMT = Convert.ToDecimal(row[cbAmt.SelectedValue]);
							if (row.IsNull(cbDAmt.SelectedValue)) welf.D_AMT = 0;
							else welf.D_AMT = Convert.ToDecimal(row[cbDAmt.SelectedValue]);
							welf.SALADR = v_base.First().SALADR;
                            if (!MainForm.WriteDataGroups.Contains(welf.SALADR))//如果預設群組不是目前的權限
                                welf.SALADR = MainForm.WriteDataGroups.First();//就隨便給一個
							welf.TR_TYPE = "";
							welf.KEY_DATE = DateTime.Now;
							welf.KEY_MAN = MainForm.USER_NAME;

							db.WELF.InsertOnSubmit(welf);
						}
					}

					db.SubmitChanges();
				}

				MessageBox.Show(Resources.All.SaveComplete, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.None);

				DialogResult = DialogResult.OK;
				Close();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
			finally
			{
				this.Enabled = true;
			}
		}

		private void FRM62I_Load(object sender, EventArgs e)
		{
			// TODO: 這行程式碼會將資料載入 'mainDS.YRFOMAT' 資料表。您可以視需要進行移動或移除。
			this.yRFOMATTableAdapter.Fill(this.welDS.YRFOMAT);
			// TODO: 這行程式碼會將資料載入 'mainDS.WCODE' 資料表。您可以視需要進行移動或移除。
			this.wCODETableAdapter.Fill(this.welDS.WCODE);
		}
	}
}
