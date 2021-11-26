using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ezOrg {
	public partial class fmDeptLevel : Form {
		public fmDeptLevel() {
			InitializeComponent();
		}

		private void fmDeptLevel_Load(object sender, EventArgs e) {
			// TODO: 這行程式碼會將資料載入 'ezOrgDS.DeptLevel' 資料表。您可以視需要進行移動或移除。
			this.deptLevelTableAdapter.Fill(this.ezOrgDS.DeptLevel);

		}

		private void grdDeptLevel_DataError(object sender, DataGridViewDataErrorEventArgs e) {
			MessageBox.Show(e.Exception.Message, "訊息提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
		}

		private void grdDeptLevel_KeyDown(object sender, KeyEventArgs e) {
			if(e.KeyCode == Keys.Delete) {
				if(MessageBox.Show("確定要除刪資料列？", "訊息提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
					== DialogResult.Yes) {
					this.ezOrgDS.DeptLevel[grdDeptLevel.SelectedRows[0].Index].Delete();
				}
			}
		}

		private void grdDeptLevel_CellEndEdit(object sender, DataGridViewCellEventArgs e) {			
			for(int i = 0; i < grdDeptLevel.Rows.Count; i++) {
				if(i != e.RowIndex && i != grdDeptLevel.NewRowIndex) {
					if(grdDeptLevel[e.ColumnIndex, e.RowIndex].ValueType == typeof(System.String)) {
						if(grdDeptLevel[e.ColumnIndex, e.RowIndex].Value.ToString() == grdDeptLevel[e.ColumnIndex, i].Value.ToString()) {
							grdDeptLevel.CancelEdit();
							this.ezOrgDS.DeptLevel[e.RowIndex].RejectChanges();
							MessageBox.Show("因為資料重覆，所以取消變更。", "訊息提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);							
							break;
						}
					}
					else {
						if(Convert.ToDouble(grdDeptLevel[e.ColumnIndex, e.RowIndex].Value) 
							== Convert.ToDouble(grdDeptLevel[e.ColumnIndex, i].Value)) {							
							grdDeptLevel.CancelEdit();
							this.ezOrgDS.DeptLevel[e.RowIndex].RejectChanges();
							MessageBox.Show("因為資料重覆，所以取消變更。", "訊息提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);							
							break;
						}
					}
				}
			}			
		}

		private void grdDeptLevel_SelectionChanged(object sender, EventArgs e) {
			for(int i = 0; i < this.ezOrgDS.DeptLevel.Count; i++) {
				if(this.ezOrgDS.DeptLevel[i].RowState == DataRowState.Added ||
					this.ezOrgDS.DeptLevel[i].RowState == DataRowState.Deleted ||
					this.ezOrgDS.DeptLevel[i].RowState == DataRowState.Modified) {
					this.deptLevelTableAdapter.Update(this.ezOrgDS.DeptLevel);
					break;
				}
			}
		}
	}
}