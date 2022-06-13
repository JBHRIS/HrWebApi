using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
namespace HR_TOOL
{
    public partial class SalaryKeyViewer : Form
    {
        public SalaryKeyViewer()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                textBoxFOLDER.Text = ofd.FileName;
                StreamReader sr = new StreamReader(textBoxFOLDER.Text, true);
                textBox1.Text = string.Empty;
                int i = 0;
                while (sr.Peek() > 0)
                {
                    textBox1.Text += JBModule.Data.CDecryp.Text(sr.ReadLine()) + Environment.NewLine;
                    i++;
                }

                sr.Close();
                sr.Dispose();
            }
        }

        private void buttonDecode_Click(object sender, EventArgs e)
        {
            textBox1.Text = JBModule.Data.CDecryp.Text(textBoxDcode.Text);
        }
    }
}
