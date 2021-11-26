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

		//藍色－無條件的限制
		//綠色－有條件的限制
		//紅色－無符合的條件
		//線段樣式一
		//線段樣式二
		//線段樣式三

		public fmLineType() {
			InitializeComponent();
			linkType = LinkType.TrueCriteria;
			linkText = "";
			cbLinkType.Text = "藍色－無條件的限制";
			cbLinkStyle.Text = "線段樣式一";
		}

		private void bnOK_Click(object sender, EventArgs e) {
			if (cbLinkType.Text == "綠色－有條件的限制" && txtLinkText.Text.Trim().Length == 0) {
				MessageBox.Show("條件式線段必須寫下說明", "訊息提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			linkText = txtLinkText.Text;
			switch(cbLinkType.Text) {
				case "綠色－有條件的限制":
					linkType = LinkType.TrueCriteria;
					break;
				case "紅色－無符合的條件":
					linkType = LinkType.DefaultCriteria;
					break;
				case "藍色－無條件的限制":
					linkType = LinkType.NoCriteria;
					break;
			}
			switch(cbLinkStyle.Text) {
				case "線段樣式一":
					linkStyle = LinkStyle.Standard;
					break;
				case "線段樣式二":
					linkStyle = LinkStyle.NearStart;
					break;
				case "線段樣式三":
					linkStyle = LinkStyle.NearEnd;
					break;
			}
			DialogResult = DialogResult.OK;
			this.Close();
		}
	}
}