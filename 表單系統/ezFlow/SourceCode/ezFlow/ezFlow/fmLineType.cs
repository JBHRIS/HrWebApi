using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ezFlow {	
	public partial class fmLineType : Form {
		public LinkType linkType;
		public LinkStyle linkStyle;
		public string linkText;

		//�Ŧ�еL���󪺭���
		//���Ц����󪺭���
		//����еL�ŦX������
		//�u�q�˦��@
		//�u�q�˦��G
		//�u�q�˦��T

		public fmLineType() {
			InitializeComponent();
			linkType = LinkType.TrueCriteria;
			linkText = "";
			cbLinkType.Text = "�Ŧ�еL���󪺭���";
			cbLinkStyle.Text = "�u�q�˦��@";
		}

		private void bnOK_Click(object sender, EventArgs e) {
			if (cbLinkType.Text == "���Ц����󪺭���" && txtLinkText.Text.Trim().Length == 0) {
				MessageBox.Show("���󦡽u�q�����g�U����", "�T������", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			linkText = txtLinkText.Text;
			switch(cbLinkType.Text) {
				case "���Ц����󪺭���":
					linkType = LinkType.TrueCriteria;
					break;
				case "����еL�ŦX������":
					linkType = LinkType.DefaultCriteria;
					break;
				case "�Ŧ�еL���󪺭���":
					linkType = LinkType.NoCriteria;
					break;
			}
			switch(cbLinkStyle.Text) {
				case "�u�q�˦��@":
					linkStyle = LinkStyle.Standard;
					break;
				case "�u�q�˦��G":
					linkStyle = LinkStyle.NearStart;
					break;
				case "�u�q�˦��T":
					linkStyle = LinkStyle.NearEnd;
					break;
			}
			DialogResult = DialogResult.OK;
			this.Close();
		}
	}
}