using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
namespace JBHR.Sal
{
    public partial class FRM46AI : JBControls.JBForm
    {
        public FRM46AI()
        {
            InitializeComponent();
        }
        DataTable dt;
        List<JBModule.Data.Linq.SALBASTD> salbastdData = new List<JBModule.Data.Linq.SALBASTD>();
        List<JBModule.Data.Linq.SALCODE> salcodeList = new List<JBModule.Data.Linq.SALCODE>();
        Dictionary<string, string> empData = new Dictionary<string, string>();
        JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
        DataSet ds = null;
        private void IP_FRM4L_Load(object sender, EventArgs e)
        {
            this.iMPORT_TYPETableAdapter.Fill(this.viewDS.IMPORT_TYPE);
            this.sALCODETableAdapter.Fill(this.salaryDS.SALCODE, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN);
            empData = (from a in db.BASE where db.GetFilterByNobr(a.NOBR, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value select new { a.NOBR, a.NAME_C }).ToDictionary(p => p.NOBR, p => p.NAME_C);
            txtAdate.Text = Sal.Function.GetDate();
        }

        private void btnBrowser_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Excel|*.xls";
            ds = new DataSet();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string path = ofd.FileName;
                try
                {
                    ds = JBModule.Data.CNPOI.ReadExcelToDataSet(path);
                    cbxSheet.Items.Clear();
                    foreach (DataTable it in ds.Tables)
                        cbxSheet.Items.Add(it.TableName);
                }
                catch
                {
                    MessageBox.Show(Resources.Sal.ExcelIOError, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }

                textBox1.Text = path;

            }
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            if (dt != null)
            {
                RenderData();
                var PreviewData = from a in salbastdData
                                  join b in empData on a.NOBR equals b.Key into ab
                                  from emp in ab.DefaultIfEmpty()
                                  join c in salcodeList on a.SAL_CODE equals c.SAL_CODE into ac
                                  from salcode in ac.DefaultIfEmpty()
                                  select new
                                  {
                                      員工編號 = a.NOBR,
                                      員工姓名 = emp.Value,
                                      生效日期 = a.ADATE,
                                      薪資代碼 = salcode != null ? salcode.SAL_CODE_DISP : a.SAL_CODE,
                                      薪資名稱 = salcode != null ? salcode.SAL_NAME : "",
                                      金額 = JBModule.Data.CDecryp.Number(a.AMT),
                                      備註 = a.MENO
                                  };

                PreviewForm vw = new PreviewForm();
                vw.DataTable = PreviewData.CopyToDataTable();
                vw.Width = 800;
                vw.ShowDialog();

                //Sal.ViewDSTableAdapters.ENRICHTableAdapter ad = new JBHR.Sal.ViewDSTableAdapters.ENRICHTableAdapter();

            }

        }
        private void btnImport_Click(object sender, EventArgs e)
        {
            JBTools.Stopwatch sw = new JBTools.Stopwatch();
            sw.Start();
            RenderData();
            var adate = Convert.ToDateTime(txtAdate.Text);
            var ExistsSalbastdData = from a in db.SALBASTD where adate >= a.ADATE && adate <= a.DDATE select new { a.NOBR, a.ADATE, a.DDATE, a.SAL_CODE };
            List<JBModule.Data.Linq.SALBASTD> CurrentSalbastdData = new List<JBModule.Data.Linq.SALBASTD>();
            foreach (var it in salbastdData)
            {
                if (!empData.Where(p => p.Key == it.NOBR).Any())
                {
                    MessageBox.Show("無效的員工編號" + it.NOBR, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }
                if (!salcodeList.Where(p => p.SAL_CODE == it.SAL_CODE).Any())
                {
                    MessageBox.Show("無效的薪資代碼" + it.SAL_CODE, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }
                var existsDB = from a in ExistsSalbastdData where a.NOBR == it.NOBR && a.ADATE == it.ADATE && a.SAL_CODE == it.SAL_CODE select a;
                if (existsDB.Any())
                {
                    MessageBox.Show("已存在的資料," + it.NOBR + " ; " + salcodeList.Where(p => p.SAL_CODE == it.SAL_CODE).First().SAL_CODE_DISP, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }
                var existsExcel = from a in CurrentSalbastdData where a.NOBR == it.NOBR && a.ADATE == it.ADATE && a.SAL_CODE == it.SAL_CODE select a;                
                if (existsExcel.Any())
                {
                    MessageBox.Show("檔案中存在相同的資料," + it.NOBR + " ; " + salcodeList.Where(p => p.SAL_CODE == it.SAL_CODE).First().SAL_CODE_DISP, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }
                CurrentSalbastdData.Add(it);
            }
            db.SALBASTD.InsertAllOnSubmit(salbastdData);
            db.SubmitChanges();
            foreach (var it in salbastdData)
            {
                ReSetSalbasdOfNobrSalcode(it.NOBR, it.SAL_CODE);
            }

            sw.Stop();
            MessageBox.Show("匯入完成!!" + sw.Message, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }
        void RenderData()
        {
            CheckAvailable();
            salbastdData = new List<JBModule.Data.Linq.SALBASTD>();
            if (dt != null)
            {
                db = new JBModule.Data.Linq.HrDBDataContext();
                salcodeList = (from a in db.SALCODE
                               where db.GetCodeFilter("SALCODE", a.SAL_CODE, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value
                               select a).ToList();
                foreach (DataRow r in dt.Rows)
                {
                    string nobr, memo, salcode;
                    DateTime adate;
                    decimal amt = 0;
                    try
                    {
                        if (dt.Columns.Contains(cbNobr.Text)) nobr = r[cbNobr.Text].ToString();
                        else nobr = cbNobr.Text;

                        if (dt.Columns.Contains(cbMemo.Text)) memo = r[cbMemo.Text].ToString();
                        else memo = cbMemo.Text;

                        if (dt.Columns.Contains(cbxSalcode.Text)) salcode = r[cbxSalcode.Text].ToString();
                        else salcode = cbxSalcode.Text;
                        if (salcodeList.Where(p => p.SAL_CODE_DISP == salcode).Any())
                            salcode = salcodeList.Where(p => p.SAL_CODE_DISP == salcode).First().SAL_CODE;
                        //if (!salcodeList.Where(p => p.SAL_CODE == salcode).Any())
                        //{
                        //    MessageBox.Show("無效的薪資代碼" + r[cbxSalcode.Text].ToString(), Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        //    return;
                        //}

                        adate = Convert.ToDateTime(txtAdate.Text);

                        if (dt.Columns.Contains(cbAmt.Text)) amt = Convert.ToDecimal(r[cbAmt.Text.ToString()]);
                        else
                        {
                            bool isDecimal = decimal.TryParse(cbAmt.Text, out amt);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(Resources.Sal.ExcelDataMaping, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        return;
                    }
                    JBModule.Data.Linq.SALBASTD row = new JBModule.Data.Linq.SALBASTD();
                    row.ADATE = adate;
                    row.NOBR = nobr;
                    row.AMT = JBModule.Data.CEncrypt.Number(JBModule.Data.CDecryp.Number(row.AMT) + amt);
                    row.KEY_DATE = DateTime.Now;
                    row.KEY_MAN = MainForm.USER_NAME;
                    row.MENO = memo;
                    row.SAL_CODE = salcode;
                    row.AMTB = 0;
                    row.DDATE = new DateTime(9999, 12, 31);
                    salbastdData.Add(row);
                }
            }
        }
        void ReSetSalbasdOfNobrSalcode(string nobr, string salcode)
        {
            SalaryMDDataContext smd = new SalaryMDDataContext();
            var salbastd_of_NobrSalcode = from salbastd_row in smd.SALBASTD
                                         where salbastd_row.NOBR.Trim().Equals(nobr) && salbastd_row.SAL_CODE.Trim().Equals(salcode)
                                         orderby salbastd_row.ADATE descending
                                         select salbastd_row;
            DateTime dt = new DateTime(9999, 12, 31);
            foreach (var itm in salbastd_of_NobrSalcode)
            {
                itm.DDATE = dt;
                dt = itm.ADATE.AddDays(-1);
            }
            smd.SubmitChanges();
        }

        private void cbxSheet_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ds.Tables.Contains(cbxSheet.Text))
            {
                dt = ds.Tables[cbxSheet.Text];
                cbNobr.Items.Clear();
                cbAmt.Items.Clear();
                cbMemo.Items.Clear();
                cbxSalcode.Items.Clear();
                foreach (DataColumn col in dt.Columns)
                {
                    cbNobr.Items.Add(col.ColumnName);
                    cbAmt.Items.Add(col.ColumnName);
                    cbMemo.Items.Add(col.ColumnName);
                    cbxSalcode.Items.Add(col.ColumnName);
                }
                CombBoxSettingDefault();
            }
        }
        void CombBoxSettingDefault()
        {
            if (cbNobr.Items.Contains(lblNobr.Text)) cbNobr.Text = lblNobr.Text;

            if (cbxSalcode.Items.Contains(lblSalcode.Text)) cbxSalcode.Text = lblSalcode.Text;

            if (cbAmt.Items.Contains(lblAmt.Text)) cbAmt.Text = lblAmt.Text;

            if (cbMemo.Items.Contains(lblMemo.Text)) cbMemo.Text = lblMemo.Text;

        }
        bool CheckAvailable()
        {
            if (cbNobr.Text.Trim().Length == 0)
            {
                MessageBox.Show(lblNobr.Text + "為必要欄位");
                cbNobr.Focus();
                return true;
            }

            if (cbxSalcode.Text.Trim().Length == 0)
            {
                MessageBox.Show(lblSalcode.Text + "為必要欄位");
                cbNobr.Focus();
                return true;
            }

            if (cbAmt.Text.Trim().Length == 0)
            {
                MessageBox.Show(lblAmt.Text + "為必要欄位");
                cbNobr.Focus();
                return true;
            }

            if (cbMemo.Text.Trim().Length == 0)
            {
                MessageBox.Show(lblMemo.Text + "為必要欄位");
                cbNobr.Focus();
                return true;
            }

            return false;
        }
    }

}