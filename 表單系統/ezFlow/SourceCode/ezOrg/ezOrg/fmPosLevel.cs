using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ezOrg {
	public partial class fmPosLevel : Form {
		public fmPosLevel() {
			InitializeComponent();
		}

		private void fmPosLevel_Load(object sender, EventArgs e) {
			// TODO: �o��{���X�|�N��Ƹ��J 'ezOrgDS.PosLevel' ��ƪ�C�z�i�H���ݭn�i�沾�ʩβ����C
			this.posLevelTableAdapter.Fill(this.ezOrgDS.PosLevel);
			// TODO: �o��{���X�|�N��Ƹ��J 'ezOrgDS.PosLevel' ��ƪ�C�z�i�H���ݭn�i�沾�ʩβ����C
			this.posLevelTableAdapter.Fill(this.ezOrgDS.PosLevel);

		}

		private void grdPosLevel_DataError(object sender, DataGridViewDataErrorEventArgs e) {
			MessageBox.Show(e.Exception.Message, "�T������", MessageBoxButtons.OK, MessageBoxIcon.Warning);
		}

		private void grdPosLevel_KeyDown(object sender, KeyEventArgs e) {
			if(e.KeyCode == Keys.Delete) {
				if(MessageBox.Show("�T�w�n���R��ƦC�H", "�T������", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
					== DialogResult.Yes) {
					this.ezOrgDS.PosLevel[grdPosLevel.SelectedRows[0].Index].Delete();
				}
			}
		}

		private void grdPosLevel_CellEndEdit(object sender, DataGridViewCellEventArgs e) {
			for(int i = 0; i < grdPosLevel.Rows.Count; i++) {
				if(i != e.RowIndex && i != grdPosLevel.NewRowIndex) {
					if(grdPosLevel[e.ColumnIndex, e.RowIndex].ValueType == typeof(System.String)) {
						if(grdPosLevel[e.ColumnIndex, e.RowIndex].Value.ToString() == grdPosLevel[e.ColumnIndex, i].Value.ToString()) {
							grdPosLevel.CancelEdit();
							this.ezOrgDS.PosLevel[e.RowIndex].RejectChanges();
							MessageBox.Show("�]����ƭ��СA�ҥH�����ܧ�C", "�T������", MessageBoxButtons.OK, MessageBoxIcon.Warning);
							break;
						}
					}
					else {
						if(Convert.ToDouble(grdPosLevel[e.ColumnIndex, e.RowIndex].Value)
							== Convert.ToDouble(grdPosLevel[e.ColumnIndex, i].Value)) {
							grdPosLevel.CancelEdit();
							this.ezOrgDS.PosLevel[e.RowIndex].RejectChanges();
							MessageBox.Show("�]����ƭ��СA�ҥH�����ܧ�C", "�T������", MessageBoxButtons.OK, MessageBoxIcon.Warning);
							break;
						}
					}
				}
			}
		}

		private void grdPosLevel_SelectionChanged(object sender, EventArgs e) {
			for(int i = 0; i < this.ezOrgDS.PosLevel.Count; i++) {
				if(this.ezOrgDS.PosLevel[i].RowState == DataRowState.Added ||
					this.ezOrgDS.PosLevel[i].RowState == DataRowState.Deleted ||
					this.ezOrgDS.PosLevel[i].RowState == DataRowState.Modified) {
					this.posLevelTableAdapter.Update(this.ezOrgDS.PosLevel);
					break;
				}
			}
		}
	}
}