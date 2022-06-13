using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NHI2ndCheck
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            List<NHI2ND> nhiListSystem = new List<NHI2ND>();
            List<NHI2ND> nhiListHR = new List<NHI2ND>();
            string connectionString = string.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Jet OLEDB:Database Password=syscom;", textBox1.Text);
            // Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\mydatabase.mdb;Jet OLEDB:Database Password=MyDbPassword;
            OleDbConnection conn = new OleDbConnection(connectionString);
            try
            {
                if (conn.State == System.Data.ConnectionState.Closed) conn.Open();

                Dictionary<string, string> itms = new Dictionary<string, string>();
                var cmd = conn.CreateCommand();
                cmd.CommandText = string.Format("SELECT Expenses.* FROM Expenses where companyno='{0}' and Expenses.PayYYYMM>='{1}' and Expenses.PayYYYMM<='{2}ZZ'", comboBox1.SelectedValue.ToString(), textBoxYYMMB.Text, textBoxYYMME.Text);
                var dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);

                foreach (DataRow r in dt.Rows)
                {
                    NHI2ND nhi = new NHI2ND();
                    nhi.IDNO = r["IDNO"].ToString().Trim();
                    nhi.IncomeType = r["IncomeType"].ToString().Trim();
                    nhi.InsAmt = Convert.ToDecimal(r["InsureAmt"].ToString().Trim());
                    nhi.InsComp = r["Companyno"].ToString().Trim();
                    nhi.SalaryAmt = Convert.ToDecimal(r["PayAmt"].ToString().Trim());
                    nhi.SupAmt = Convert.ToDecimal(r["HealthAmt"].ToString().Trim());
                    nhi.TransDate = r["PayYYYMM"].ToString().Trim();
                    nhiListSystem.Add(nhi);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }

            StreamReader sr = new StreamReader(textBox2.Text, Encoding.GetEncoding("Big5"));

            int i = 0;
            while (!sr.EndOfStream)
            {
                string txtLine = sr.ReadLine() + Environment.NewLine;
                if (i > 0)//略過標頭
                {
                    if (txtLine.Trim().Length > 0)
                    {
                        var txtArray = txtLine.Split(',');
                        NHI2ND nhi = new NHI2ND();
                        nhi.IDNO = txtArray[2].Trim();
                        nhi.IncomeType = txtArray[5].Trim();
                        nhi.InsAmt = 0;
                        if (txtArray[7].Trim().Length > 0)
                            nhi.InsAmt = Convert.ToDecimal(txtArray[7].Trim());
                        nhi.InsComp = txtArray[1].Trim();
                        nhi.SalaryAmt = Convert.ToDecimal(txtArray[6].Trim());
                        nhi.SupAmt = Convert.ToDecimal(txtArray[15].Trim());
                        nhi.TransDate = txtArray[4].Trim();
                        nhiListHR.Add(nhi);
                    }
                }

                i++;
            }

            sr.Close();
            sr.Dispose();
            var compareList = from a in nhiListSystem
                              join b in nhiListHR on new { a.IDNO, a.IncomeType, a.InsComp, a.TransDate,a.SalaryAmt } equals new { b.IDNO, b.IncomeType, b.InsComp, b.TransDate,b.SalaryAmt }
                              select new
                              {
                                  公司統編 = a.InsComp,
                                  身分證號 = a.IDNO,
                                  給付日期 = a.TransDate,
                                  收入類別 = a.IncomeType,
                                  給付金額 = a.SalaryAmt,
                                  投保薪資 = a.InsAmt,
                                  健保局補充保費 = a.SupAmt,
                                  系統補充保費 = b.SupAmt,
                                  差額 = a.SupAmt - b.SupAmt
                              };
            var dtCompare = compareList.CopyToDataTable();
            DataSet ds = new DataSet();
            ds.Tables.Add(dtCompare);
            JBTools.IO.NpoiExcelWriter nw = new JBTools.IO.NpoiExcelWriter(ds);
            string filename = Directory.GetCurrentDirectory() + @"\補充保費比對" + comboBox1.SelectedValue.ToString() + ".xls";
            nw.Save(filename);
            if (MessageBox.Show("檔案已匯出至" + filename + Environment.NewLine + "是否要開啟?", "訊息", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk) == System.Windows.Forms.DialogResult.OK)
                System.Diagnostics.Process.Start(filename);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "mdb檔|*.mdb";
            ofd.InitialDirectory = @"C:\Program Files (x86)\NHI\DB";
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                textBox1.Text = ofd.FileName;
                string connectionString = string.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Jet OLEDB:Database Password=syscom;", textBox1.Text);
                // Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\mydatabase.mdb;Jet OLEDB:Database Password=MyDbPassword;
                OleDbConnection conn = new OleDbConnection(connectionString);
                try
                {
                    if (conn.State == System.Data.ConnectionState.Closed) conn.Open();

                    Dictionary<string, string> itms = new Dictionary<string, string>();
                    var cmd = conn.CreateCommand();
                    cmd.CommandText = string.Format("SELECT Compay.* FROM Compay");
                    var dr = cmd.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(dr);
                    Dictionary<string, string> InsCompList = new Dictionary<string, string>();
                    foreach (DataRow r in dt.Rows)
                    {
                        InsCompList.Add(r[0].ToString(), r[1].ToString());
                    }
                    SystemFunction.SetComboBoxItems(comboBox1, InsCompList, false, true, true);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "csv檔|*.csv";
            ofd.InitialDirectory = @"C:\Temp\";
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                textBox2.Text = ofd.FileName;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBoxYYMMB.Text = (DateTime.Today.Year - 1911 - 1).ToString() + "01";
            textBoxYYMME.Text = (DateTime.Today.Year - 1911 - 1).ToString() + "12";
        }
    }
    public class NHI2ND
    {
        public string IDNO;
        public string InsComp;
        public string TransDate;
        public string IncomeType;
        public decimal SalaryAmt;
        public decimal InsAmt;
        public decimal SupAmt;
    }
}
