using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace JBHRKEYCREATOR
{
    public partial class Form1 : JBControls.JBForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                textBoxFOLDER.Text = folderBrowserDialog.SelectedPath;
                if (textBoxFOLDER.Text.Substring(textBoxFOLDER.Text.Length - 1, 1) != "\\") textBoxFOLDER.Text += "\\";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string connectionString = string.Format("Data Source={0};Initial Catalog={1};Persist Security Info=True;User ID={2};Password={3}", textBoxSERVER.Text, textBoxDATABASE.Text, textBoxUSERID.Text, textBoxPASSWORD.Text);

            SqlConnection conn = new SqlConnection(connectionString);
            try
            {
                if (conn.State == System.Data.ConnectionState.Closed) conn.Open();
                MessageBox.Show("連線成功", "訊息", MessageBoxButtons.OK, MessageBoxIcon.None);
            }
            catch
            {
                MessageBox.Show("無法與資料庫取得連線，請重新設定連線字串。", "訊息", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBoxSERVER.Text.Trim().Length == 0)
            {
                MessageBox.Show("請填寫伺服器名稱或IP位址", "訊息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (textBoxDATABASE.Text.Trim().Length == 0)
            {
                MessageBox.Show("請填寫資料庫名稱", "訊息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (textBoxUSERID.Text.Trim().Length == 0)
            {
                MessageBox.Show("請填寫登入帳號", "訊息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (textBoxPASSWORD.Text.Trim().Length == 0)
            {
                MessageBox.Show("請填寫登入密碼", "訊息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (textBoxFOLDER.Text.Trim().Length == 0)
            {
                MessageBox.Show("請選擇儲存路徑", "訊息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string connectionString = string.Format("Data Source={0};Initial Catalog={1};Persist Security Info=True;User ID={2};Password={3}", textBoxSERVER.Text, textBoxDATABASE.Text, textBoxUSERID.Text, textBoxPASSWORD.Text);
            string str1 = JBModule.Data.CEncrypt.Text("connectionString[=]" + connectionString);            
            StreamWriter sw = new StreamWriter(textBoxFOLDER.Text + "JBHR.CONNECTION.STR", false, Encoding.Default);
            sw.WriteLine(str1);            
            sw.Close();

            if (textBoxLOGINID.Text.Trim().Length > 0)
            {
                List<string> SalaryKeys = new List<string>();
                if (File.Exists(textBoxFOLDER.Text + "JBHR.SALARY.KEY"))
                {
                    StreamReader sr = File.OpenText(textBoxFOLDER.Text + "JBHR.SALARY.KEY");
                    while (!sr.EndOfStream) SalaryKeys.Add(JBModule.Data.CDecryp.Text(sr.ReadLine()));
                    sr.Close();
                }

                bool findKey = false;
                foreach (string key in SalaryKeys)
                {
                    string[] pp = key.Split(new string[] { "[=]" }, StringSplitOptions.RemoveEmptyEntries);
                    if (pp.Length == 2 && pp[1].Trim().ToUpper() == textBoxLOGINID.Text.Trim().ToUpper())
                    {
                        findKey = true;
                        break;
                    }
                }

                if (!findKey)
                {
                    string loginID = textBoxLOGINID.Text.Trim();
                    string str2 = JBModule.Data.CEncrypt.Text("loginID[=]" + loginID);
                    sw = new StreamWriter(textBoxFOLDER.Text + "JBHR.SALARY.KEY", true, Encoding.Default);                    
                    sw.WriteLine(str2);
                    sw.Close();
                }
            }
            else
            {
                MessageBox.Show("請填寫薪資授權帳號", "訊息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            MessageBox.Show("產生完畢!", "訊息", MessageBoxButtons.OK, MessageBoxIcon.None);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBoxFOLDER.Text.Trim().Length == 0)
            {
                MessageBox.Show("請選擇儲存路徑", "訊息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (textBoxLOGINID.Text.Trim().Length > 0)
            {
                List<string> SalaryKeys = new List<string>();
                if (File.Exists(textBoxFOLDER.Text + "JBHR.SALARY.KEY"))
                {
                    StreamReader sr = File.OpenText(textBoxFOLDER.Text + "JBHR.SALARY.KEY");
                    while (!sr.EndOfStream) SalaryKeys.Add(JBModule.Data.CDecryp.Text(sr.ReadLine()));
                    sr.Close();
                }

                bool findKey = false;
                foreach (string key in SalaryKeys)
                {
                    string[] pp = key.Split(new string[] { "[=]" }, StringSplitOptions.RemoveEmptyEntries);
                    if (pp.Length == 2 && pp[1].Trim().ToUpper() == textBoxLOGINID.Text.Trim().ToUpper())
                    {
                        findKey = true;
                        break;
                    }
                }

                if (!findKey)
                {
                    string loginID = textBoxLOGINID.Text.Trim();
                    string str2 = JBModule.Data.CEncrypt.Text("loginID[=]" + loginID);
                    StreamWriter sw = new StreamWriter(textBoxFOLDER.Text + "JBHR.SALARY.KEY", true, Encoding.Default);                    
                    sw.WriteLine(str2);
                    sw.Close();
                }
            }
            else
            {
                MessageBox.Show("請填寫薪資授權帳號", "訊息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            MessageBox.Show("產生完畢!", "訊息", MessageBoxButtons.OK, MessageBoxIcon.None);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (textBoxFOLDER.Text.Trim().Length == 0)
            {
                MessageBox.Show("請選擇儲存路徑", "訊息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (textBoxSERVER.Text.Trim().Length == 0)
            {
                MessageBox.Show("請填寫伺服器名稱或IP位址", "訊息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (textBoxDATABASE.Text.Trim().Length == 0)
            {
                MessageBox.Show("請填寫資料庫名稱", "訊息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (textBoxUSERID.Text.Trim().Length == 0)
            {
                MessageBox.Show("請填寫登入帳號", "訊息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (textBoxPASSWORD.Text.Trim().Length == 0)
            {
                MessageBox.Show("請填寫登入密碼", "訊息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (textBoxFOLDER.Text.Trim().Length == 0)
            {
                MessageBox.Show("請選擇儲存路徑", "訊息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string connectionString = string.Format("Data Source={0};Initial Catalog={1};Persist Security Info=True;User ID={2};Password={3}", textBoxSERVER.Text, textBoxDATABASE.Text, textBoxUSERID.Text, textBoxPASSWORD.Text);
            string str1 = JBModule.Data.CEncrypt.Text("connectionString[=]" + connectionString);
            StreamWriter sw = new StreamWriter(textBoxFOLDER.Text + "JBHR.CONNECTION.STR", false, Encoding.Default);
            sw.WriteLine(str1);
            sw.Close();

            MessageBox.Show("產生完畢!", "訊息", MessageBoxButtons.OK, MessageBoxIcon.None);
        }
    }
}