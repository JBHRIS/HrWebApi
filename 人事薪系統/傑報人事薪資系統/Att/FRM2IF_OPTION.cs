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
    public partial class FRM2IF_OPTION : Form
    {
        public FRM2IF_OPTION()
        {
            InitializeComponent();
        }
        public string ExtendLegthType = "年";
        public int ExtendLength = 1;
        public string ExtendSelection = "1";
        public DateTime ExtendSelectedDate = DateTime.Today;

        private void FRM2IF_OPTION_Load(object sender, EventArgs e)
        {
            comboBox1.Text = ExtendLegthType;
            textBox2.Text = ExtendLength.ToString();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                ExtendSelection = "1";
                if (!new string[] { "年", "月", "日" }.Contains(comboBox1.Text.Trim()))
                {
                    MessageBox.Show("時間單位選擇錯誤");
                    return;
                }
                int value = 0;
                if (!int.TryParse(textBox2.Text, out value))
                {
                    MessageBox.Show("時間必須是整數");
                    return;
                }
                if (value <= 0)
                {
                    MessageBox.Show("時間必須是大於0的整數");
                    return;
                }
                ExtendLength = value;
                ExtendLegthType = comboBox1.Text;
            }
            else if (radioButton2.Checked)
            {
                ExtendSelection = "2";
                ExtendSelectedDate = Convert.ToDateTime(txtAdate.Text);
            }
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }
    }
}
