using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace JBHR.Att
{
    public partial class FRM2V_EDIT_M : Form
    {
        public string RemarkType = "";
        public string Remark = "";
        public FRM2V_EDIT_M()
        {
            InitializeComponent();
        }
        private void FRM2V_EDIT_M_Load(object sender, EventArgs e)
        {
            SystemFunction.SetComboBoxItems(comboBoxRemarkType, CodeFunction.GetMtCode("ATTEND_ABNORMAL_CHECK"), false, true);
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (comboBoxRemarkType.SelectedIndex == -1)
            {
                MessageBox.Show("請選擇註記種類");
                return;
            }
            if (textBoxRemark.Text.Trim().Length == 0)
            {
                MessageBox.Show("請輸入註記說明");
                return;
            }
            RemarkType = comboBoxRemarkType.SelectedValue.ToString();
            Remark = textBoxRemark.Text;
            this.DialogResult = DialogResult.OK;
        }

    }
}
