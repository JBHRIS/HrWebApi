using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ezFlow {
	public partial class fmLinkPower : Form {
		public string FlowLink_id = "";
		public string FlowLink_name = "";
		public string FlowTree_id = "";

		public fmLinkPower() {
			InitializeComponent();
		}

		private void fmPower_Load(object sender, EventArgs e) {
			// TODO: 這行程式碼會將資料載入 'ezFlowDS.FlowLinkPower' 資料表。您可以視需要進行移動或移除。
			txtFdName1.Clear();
			cbType1.Text = "";
			cbCriteria1.Text = "";
			txtMinValue1.Clear();
			txtMaxValue1.Clear();

			txtFdName2.Clear();
			cbType2.Text = "";
			cbCriteria2.Text = "";
			txtMinValue2.Clear();
			txtMaxValue2.Clear();

			txtFdName3.Clear();
			cbType3.Text = "";
			cbCriteria3.Text = "";
			txtMinValue3.Clear();
			txtMaxValue3.Clear();

			txtFdName4.Clear();
			cbType4.Text = "";
			cbCriteria4.Text = "";
			txtMinValue4.Clear();
			txtMaxValue4.Clear();

			txtFdName5.Clear();
			cbType5.Text = "";
			cbCriteria5.Text = "";
			txtMinValue5.Clear();
			txtMaxValue5.Clear();

			txtFdName6.Clear();
			cbType6.Text = "";
			cbCriteria6.Text = "";
			txtMinValue6.Clear();
			txtMaxValue6.Clear();

			ezFlowDSTableAdapters.NodeStartTableAdapter adNodeStart = new ezFlow.ezFlowDSTableAdapters.NodeStartTableAdapter();
			ezFlowDS.NodeStartDataTable dtNodeStart = adNodeStart.GetDataByFlowTree(FlowTree_id);
			if(dtNodeStart.Count > 0) {
				txtTableName.Text = dtNodeStart[0].tableName;
			}
			else txtTableName.Clear();

			this.flowLinkPowerTableAdapter.FillByFlowLink(this.ezFlowDS.FlowLinkPower, FlowLink_id);
			if(this.ezFlowDS.FlowLinkPower.Count > 0) {
				grdMain.Rows[0].Selected = true;
				grdMain.CurrentCell = grdMain.CurrentRow.Cells[0];				
			}

			this.Text += " - (" + FlowLink_id + ")" + FlowLink_name;
		}

		private void grdMain_SelectionChanged(object sender, EventArgs e) {
			RestoreData();
		}

		void RestoreData() {
			txtNote.Text = "";
			txtTableName.Text = "";

			bool bError = false;
			try {
				int i = grdMain.SelectedRows[0].Index;
				bError = false;
			}
			catch {
				bError = true;
			}

			if(bError) return;


			if(this.ezFlowDS.FlowLinkPower.Count > 0 && grdMain.CurrentRow != null &&
				this.ezFlowDS.FlowLinkPower[grdMain.SelectedRows[0].Index].RowState != DataRowState.Deleted) {
				txtNote.Text = this.ezFlowDS.FlowLinkPower[grdMain.SelectedRows[0].Index].note;
				txtTableName.Text = this.ezFlowDS.FlowLinkPower[grdMain.SelectedRows[0].Index].tableName;

				txtFdName1.Text = this.ezFlowDS.FlowLinkPower[grdMain.SelectedRows[0].Index].fdName1;
				cbType1.Text = this.ezFlowDS.FlowLinkPower[grdMain.SelectedRows[0].Index].fdType1;
				cbCriteria1.Text = this.ezFlowDS.FlowLinkPower[grdMain.SelectedRows[0].Index].criteria1;
				txtMinValue1.Text = this.ezFlowDS.FlowLinkPower[grdMain.SelectedRows[0].Index].minValue1;
				txtMaxValue1.Text = this.ezFlowDS.FlowLinkPower[grdMain.SelectedRows[0].Index].maxValue1;

				if(this.ezFlowDS.FlowLinkPower[grdMain.SelectedRows[0].Index].fdName2.Trim().Length > 0) {
					txtFdName2.Text = this.ezFlowDS.FlowLinkPower[grdMain.SelectedRows[0].Index].fdName2;
					cbType2.Text = this.ezFlowDS.FlowLinkPower[grdMain.SelectedRows[0].Index].fdType2;
					cbCriteria2.Text = this.ezFlowDS.FlowLinkPower[grdMain.SelectedRows[0].Index].criteria2;
					txtMinValue2.Text = this.ezFlowDS.FlowLinkPower[grdMain.SelectedRows[0].Index].minValue2;
					txtMaxValue2.Text = this.ezFlowDS.FlowLinkPower[grdMain.SelectedRows[0].Index].maxValue2;
				}
				else {
					txtFdName2.Text = "";
					cbType2.SelectedItem = null;
					cbCriteria2.SelectedItem = null;
					txtMinValue2.Text = "";
					txtMaxValue2.Text = "";
				}

				if(this.ezFlowDS.FlowLinkPower[grdMain.SelectedRows[0].Index].fdName3.Trim().Length > 0) {
					txtFdName3.Text = this.ezFlowDS.FlowLinkPower[grdMain.SelectedRows[0].Index].fdName3;
					cbType3.Text = this.ezFlowDS.FlowLinkPower[grdMain.SelectedRows[0].Index].fdType3;
					cbCriteria3.Text = this.ezFlowDS.FlowLinkPower[grdMain.SelectedRows[0].Index].criteria3;
					txtMinValue3.Text = this.ezFlowDS.FlowLinkPower[grdMain.SelectedRows[0].Index].minValue3;
					txtMaxValue3.Text = this.ezFlowDS.FlowLinkPower[grdMain.SelectedRows[0].Index].maxValue3;
				}
				else {
					txtFdName3.Text = "";
					cbType3.SelectedItem = null;
					cbCriteria3.SelectedItem = null;
					txtMinValue3.Text = "";
					txtMaxValue3.Text = "";
				}

				if(this.ezFlowDS.FlowLinkPower[grdMain.SelectedRows[0].Index].fdName4.Trim().Length > 0) {
					txtFdName4.Text = this.ezFlowDS.FlowLinkPower[grdMain.SelectedRows[0].Index].fdName4;
					cbType4.Text = this.ezFlowDS.FlowLinkPower[grdMain.SelectedRows[0].Index].fdType4;
					cbCriteria4.Text = this.ezFlowDS.FlowLinkPower[grdMain.SelectedRows[0].Index].criteria4;
					txtMinValue4.Text = this.ezFlowDS.FlowLinkPower[grdMain.SelectedRows[0].Index].minValue4;
					txtMaxValue4.Text = this.ezFlowDS.FlowLinkPower[grdMain.SelectedRows[0].Index].maxValue4;
				}
				else {
					txtFdName4.Text = "";
					cbType4.SelectedItem = null;
					cbCriteria4.SelectedItem = null;
					txtMinValue4.Text = "";
					txtMaxValue4.Text = "";
				}

				if(this.ezFlowDS.FlowLinkPower[grdMain.SelectedRows[0].Index].fdName5.Trim().Length > 0) {
					txtFdName5.Text = this.ezFlowDS.FlowLinkPower[grdMain.SelectedRows[0].Index].fdName5;
					cbType5.Text = this.ezFlowDS.FlowLinkPower[grdMain.SelectedRows[0].Index].fdType5;
					cbCriteria5.Text = this.ezFlowDS.FlowLinkPower[grdMain.SelectedRows[0].Index].criteria5;
					txtMinValue5.Text = this.ezFlowDS.FlowLinkPower[grdMain.SelectedRows[0].Index].minValue5;
					txtMaxValue5.Text = this.ezFlowDS.FlowLinkPower[grdMain.SelectedRows[0].Index].maxValue5;
				}
				else {
					txtFdName5.Text = "";
					cbType5.SelectedItem = null;
					cbCriteria5.SelectedItem = null;
					txtMinValue5.Text = "";
					txtMaxValue5.Text = "";
				}

				if(this.ezFlowDS.FlowLinkPower[grdMain.SelectedRows[0].Index].fdName6.Trim().Length > 0) {
					txtFdName6.Text = this.ezFlowDS.FlowLinkPower[grdMain.SelectedRows[0].Index].fdName6;
					cbType6.Text = this.ezFlowDS.FlowLinkPower[grdMain.SelectedRows[0].Index].fdType6;
					cbCriteria6.Text = this.ezFlowDS.FlowLinkPower[grdMain.SelectedRows[0].Index].criteria6;
					txtMinValue6.Text = this.ezFlowDS.FlowLinkPower[grdMain.SelectedRows[0].Index].minValue6;
					txtMaxValue6.Text = this.ezFlowDS.FlowLinkPower[grdMain.SelectedRows[0].Index].maxValue6;
				}
				else {
					txtFdName6.Text = "";
					cbType6.SelectedItem = null;
					cbCriteria6.SelectedItem = null;
					txtMinValue6.Text = "";
					txtMaxValue6.Text = "";
				}
			}
		}

		private void bnAdd_Click(object sender, EventArgs e) {
			if(txtNote.Text.Trim().Length == 0) {
				MessageBox.Show("條件說明欄位不可空白", "訊息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}
			if(txtTableName.Text.Trim().Length == 0) {
				MessageBox.Show("資料表欄位不可空白", "訊息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}

			List<TextBox> lstFdName = new List<TextBox>();
			lstFdName.Add(txtFdName1);
			lstFdName.Add(txtFdName2);
			lstFdName.Add(txtFdName3);
			lstFdName.Add(txtFdName4);
			lstFdName.Add(txtFdName5);
			lstFdName.Add(txtFdName6);

			List<ComboBox> lstType = new List<ComboBox>();
			lstType.Add(cbType1);
			lstType.Add(cbType2);
			lstType.Add(cbType3);
			lstType.Add(cbType4);
			lstType.Add(cbType5);
			lstType.Add(cbType6);

			List<ComboBox> lstCriteria = new List<ComboBox>();
			lstCriteria.Add(cbCriteria1);
			lstCriteria.Add(cbCriteria2);
			lstCriteria.Add(cbCriteria3);
			lstCriteria.Add(cbCriteria4);
			lstCriteria.Add(cbCriteria5);
			lstCriteria.Add(cbCriteria6);

			List<TextBox> lstMinValue = new List<TextBox>();
			lstMinValue.Add(txtMinValue1);
			lstMinValue.Add(txtMinValue2);
			lstMinValue.Add(txtMinValue3);
			lstMinValue.Add(txtMinValue4);
			lstMinValue.Add(txtMinValue5);
			lstMinValue.Add(txtMinValue6);

			List<TextBox> lstMaxValue = new List<TextBox>();
			lstMaxValue.Add(txtMaxValue1);
			lstMaxValue.Add(txtMaxValue2);
			lstMaxValue.Add(txtMaxValue3);
			lstMaxValue.Add(txtMaxValue4);
			lstMaxValue.Add(txtMaxValue5);
			lstMaxValue.Add(txtMaxValue6);

			//條件正確性檢查			
			for(int i = 0; i < lstFdName.Count; i++) {
				if(lstFdName[i].Text.Trim().Length > 0) {
					if(lstType[i].Text.Trim().Length == 0 || lstCriteria[i].Text.Trim().Length == 0 ||
						lstMinValue[i].Text.Trim().Length == 0 ) {
						MessageBox.Show("條件" + Convert.ToString(i + 1) + "的資訊不完整", "訊息提示",
							MessageBoxButtons.OK, MessageBoxIcon.Warning);
						return;
					}
					if(lstCriteria[i].Text.Trim() == "><") {
						if(lstMinValue[i].Text.Length == 0 || lstMaxValue[i].Text.Length == 0) {
							MessageBox.Show("條件" + Convert.ToString(i + 1) + "為'between'，故最小值與最大值都必須填寫",
								"訊息提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
							return;
						}
					}
				}
			}
			
			//將條件往前順移
			for(int i = 0; i < lstFdName.Count - 1; i++) {
				if(lstFdName[i].Text.Trim().Length == 0) {
					for(int j = i + 1; j < lstFdName.Count; j++) {
						if(lstFdName[j].Text.Trim().Length > 0) {
							lstFdName[i].Text = lstFdName[j].Text;
							lstType[i].Text = lstType[j].Text;
							lstCriteria[i].Text = lstCriteria[j].Text;
							lstMinValue[i].Text = lstMinValue[j].Text;
							lstMaxValue[i].Text = lstMaxValue[j].Text;

							lstFdName[j].Text = "";
							lstType[j].SelectedItem = null;							
							lstCriteria[j].SelectedItem = null;							
							lstMinValue[j].Text = "";
							lstMaxValue[j].Text = "";
							break;
						}
					}
				}
			}			

			ezFlowDS.FlowLinkPowerRow rowFlowLinkPower = null;
			bool isAdd = false;
			if(this.ezFlowDS.FlowLinkPower.Count == 0) {
				isAdd = true;
				rowFlowLinkPower = this.ezFlowDS.FlowLinkPower.NewFlowLinkPowerRow();
			}
			else {
				bool isFind = false;
				for(int i = 0; i < this.ezFlowDS.FlowLinkPower.Count; i++) {
					if(this.ezFlowDS.FlowLinkPower[i].note == txtNote.Text) {
						rowFlowLinkPower = this.ezFlowDS.FlowLinkPower[i];

						if(txtFdName1.Text.Trim().Length == 0 && txtFdName2.Text.Trim().Length == 0 &&
							txtFdName3.Text.Trim().Length == 0 && txtFdName4.Text.Trim().Length == 0 &&
							txtFdName5.Text.Trim().Length == 0 && txtFdName6.Text.Trim().Length == 0) {														
							this.ezFlowDS.FlowLinkPower[i].Delete();
							this.flowLinkPowerTableAdapter.Update(this.ezFlowDS.FlowLinkPower);
							if(i < this.ezFlowDS.FlowLinkPower.Count) grdMain.Rows[i].Cells[0].Selected = true;
							RestoreData();
							return;
						}

						isFind = true;
						isAdd = false;
						break;
					}
				}
				if(!isFind) {
					isAdd = true;
					rowFlowLinkPower = this.ezFlowDS.FlowLinkPower.NewFlowLinkPowerRow();					
				}
			}
			
			rowFlowLinkPower.FlowLink_id = FlowLink_id;
			rowFlowLinkPower.note = txtNote.Text;
			rowFlowLinkPower.tableName = txtTableName.Text;

			rowFlowLinkPower.fdName1 = txtFdName1.Text;
			rowFlowLinkPower.fdType1 = cbType1.Text;
			rowFlowLinkPower.criteria1 = cbCriteria1.Text;
			rowFlowLinkPower.minValue1 = txtMinValue1.Text;
			rowFlowLinkPower.maxValue1 = txtMaxValue1.Text;

			rowFlowLinkPower.fdName2 = txtFdName2.Text;
			rowFlowLinkPower.fdType2 = cbType2.Text;
			rowFlowLinkPower.criteria2	= cbCriteria2.Text;
			rowFlowLinkPower.minValue2 = txtMinValue2.Text;
			rowFlowLinkPower.maxValue2 = txtMaxValue2.Text;

			rowFlowLinkPower.fdName3 = txtFdName3.Text;
			rowFlowLinkPower.fdType3 = cbType3.Text;
			rowFlowLinkPower.criteria3 = cbCriteria3.Text;
			rowFlowLinkPower.minValue3 = txtMinValue3.Text;
			rowFlowLinkPower.maxValue3 = txtMaxValue3.Text;

			rowFlowLinkPower.fdName4 = txtFdName4.Text;
			rowFlowLinkPower.fdType4 = cbType4.Text;
			rowFlowLinkPower.criteria4 = cbCriteria4.Text;
			rowFlowLinkPower.minValue4 = txtMinValue4.Text;
			rowFlowLinkPower.maxValue4 = txtMaxValue4.Text;

			rowFlowLinkPower.fdName5 = txtFdName5.Text;
			rowFlowLinkPower.fdType5 = cbType5.Text;
			rowFlowLinkPower.criteria5 = cbCriteria5.Text;
			rowFlowLinkPower.minValue5 = txtMinValue5.Text;
			rowFlowLinkPower.maxValue5 = txtMaxValue5.Text;

			rowFlowLinkPower.fdName6 = txtFdName6.Text;
			rowFlowLinkPower.fdType6 = cbType6.Text;
			rowFlowLinkPower.criteria6 = cbCriteria6.Text;
			rowFlowLinkPower.minValue6 = txtMinValue6.Text;
			rowFlowLinkPower.maxValue6 = txtMaxValue6.Text;

			if(isAdd) this.ezFlowDS.FlowLinkPower.AddFlowLinkPowerRow(rowFlowLinkPower);
			this.flowLinkPowerTableAdapter.Update(this.ezFlowDS.FlowLinkPower);

			if(isAdd) {
				grdMain.Rows[grdMain.Rows.GetLastRow(DataGridViewElementStates.None)].Cells[0].Selected = true;				
			}

			new ezFlowDSTableAdapters.QueriesTableAdapter().UpdateQueryByFlowLinkPower(txtTableName.Text, FlowLink_id);
			foreach(ezFlowDS.FlowLinkPowerRow rowPower in this.ezFlowDS.FlowLinkPower.Rows) {
				rowPower.tableName = txtTableName.Text;
			}
			this.ezFlowDS.FlowLinkPower.AcceptChanges();

			MessageBox.Show("目前的條件設定已完成儲存", "訊息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void txtFdName1_TextChanged(object sender, EventArgs e) {
			if(txtFdName1.Text.Trim().Length == 0) {
				cbType1.SelectedItem = null;
				cbCriteria1.SelectedItem = null;
				txtMinValue1.Text = "";
				txtMaxValue1.Text = "";
			}
		}

		private void txtFdName2_TextChanged(object sender, EventArgs e) {
			if(txtFdName2.Text.Trim().Length == 0) {
				cbType2.SelectedItem = null;
				cbCriteria2.SelectedItem = null;
				txtMinValue2.Text = "";
				txtMaxValue2.Text = "";
			}
		}

		private void txtFdName3_TextChanged(object sender, EventArgs e) {
			if(txtFdName3.Text.Trim().Length == 0) {
				cbType3.SelectedItem = null;
				cbCriteria3.SelectedItem = null;
				txtMinValue3.Text = "";
				txtMaxValue3.Text = "";
			}
		}

		private void txtFdName4_TextChanged(object sender, EventArgs e) {
			if(txtFdName4.Text.Trim().Length == 0) {
				cbType4.SelectedItem = null;
				cbCriteria4.SelectedItem = null;
				txtMinValue4.Text = "";
				txtMaxValue4.Text = "";
			}
		}

		private void txtFdName5_TextChanged(object sender, EventArgs e) {
			if(txtFdName5.Text.Trim().Length == 0) {
				cbType5.SelectedItem = null;
				cbCriteria5.SelectedItem = null;
				txtMinValue5.Text = "";
				txtMaxValue5.Text = "";
			}
		}

		private void txtFdName6_TextChanged(object sender, EventArgs e) {
			if(txtFdName6.Text.Trim().Length == 0) {
				cbType6.SelectedItem = null;
				cbCriteria6.SelectedItem = null;
				txtMinValue6.Text = "";
				txtMaxValue6.Text = "";
			}
		}
	}
}