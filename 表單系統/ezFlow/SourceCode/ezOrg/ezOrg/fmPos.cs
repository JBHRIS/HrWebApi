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
			// TODO: �o��{���X�|�N��Ƹ��J 'ezOrgDS.Pos' ��ƪ�C�z�i�H���ݭn�i�沾�ʩβ����C
			this.posTableAdapter.Fill(this.ezOrgDS.Pos);
			// TODO: �o��{���X�|�N��Ƹ��J 'ezOrgDS.PosLevel' ��ƪ�C�z�i�H���ݭn�i�沾�ʩβ����C
			this.posLevelTableAdapter.Fill(this.ezOrgDS.PosLevel);

		}

		private void bnSave_Click(object sender, EventArgs e) {
			this.posTableAdapter.Update(this.ezOrgDS.Pos);
			MessageBox.Show("�x�s����", "�T������", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}
	}
}