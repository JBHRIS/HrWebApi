using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ezOrg {
	public partial class fmPos : Form {
		public fmPos() {
			InitializeComponent();
		}

		private void fmPos_Load(object sender, EventArgs e) {
			// TODO: 這行程式碼會將資料載入 'ezOrgDS.Pos' 資料表。您可以視需要進行移動或移除。
			this.posTableAdapter.Fill(this.ezOrgDS.Pos);
			// TODO: 這行程式碼會將資料載入 'ezOrgDS.PosLevel' 資料表。您可以視需要進行移動或移除。
			this.posLevelTableAdapter.Fill(this.ezOrgDS.PosLevel);

		}

		private void bnSave_Click(object sender, EventArgs e) {
			this.posTableAdapter.Update(this.ezOrgDS.Pos);
			MessageBox.Show("儲存完成", "訊息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}
	}
}