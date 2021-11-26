using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using JBModule.Data;
using System.Data.Linq;
using System.Data.Linq.SqlClient;
using System.Data.Sql;
namespace JBHR.Sal
{
    public partial class FRM44 : JBControls.JBForm
    {
        public FRM44()
        {
            InitializeComponent();
        }
        bool IsSkip = false;
        int INDTPreMonth = 0;
        JBModule.Data.ApplicationConfigSettings acg = null;
        private void FRM44_Load(object sender, EventArgs e)
        {
            btnSalary.Enabled = false;
            this.sALCODETableAdapter.Fill(this.salaryDS.SALCODE, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN);

            string Nobr = "";

            acg = new JBModule.Data.ApplicationConfigSettings(this.Name, MainForm.COMPANY);
            acg.CheckParameterAndSetDefault("INDTPreMonths", "指定檢核月數", "6", "檢核近多少個月的員工(0為不檢核)", "TextBox", "", "Int");
            SystemFunction.CheckAppConfigRule(btnConfig);
            INDTPreMonth = 0 - acg.GetConfig("INDTPreMonths").GetInter(6);
            var tb = CheckNoSalbasd(DateTime.Today.AddMonths(INDTPreMonth));
            if (tb.Rows.Count > 0 && INDTPreMonth != 0)
                Nobr = Function.ShowView(Resources.Sal.titleNoneWaged, tb);

            Function.SetAvaliableBase(this.salaryDS.BASE);
            FormInit();
            if (Nobr.Trim().Length > 0)
            {
                button1_Click(null, null);
                ptxNobr.Text = Nobr;
                btnSalary.Focus();
                JBControls.PopupTextBox.QueryCompletedArgs ee = new JBControls.PopupTextBox.QueryCompletedArgs();
                ee.HasData = true;
                ptxNobr_QueryCompleted(ptxNobr, ee);
            }
        }
        void FormInit()
        {
            ptxNobr.Enabled = false;
            btnCheck.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.salaryDS.SALBASD.RejectChanges();
            this.salaryDS.SALBASD.Clear();
            //DataBind();//解密
            btnSalary.Enabled = false;
            btnCancel.Enabled = false;

            txtAccount.DataBindings.Clear();
            txtBank.DataBindings.Clear();
            txtNameE.DataBindings.Clear();

            ptxNobr.Enabled = true;
            ptxNobr.Focus();
            this.bASEBindingSource.Filter = "";
            txtAccount.Text = "";
            txtAmt.Text = "";
            txtBank.Text = "";
            txtNameE.Text = "";

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                IsSkip = true;
                FormInit();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                DataGridViewRow dgvr = dataGridView1.Rows[e.RowIndex];

                SalaryDSTableAdapters.SALBASDTableAdapter ad = new JBHR.Sal.SalaryDSTableAdapters.SALBASDTableAdapter();
                //SalaryDS.SALBASDDataTable dt = ad.GetDataByNobrCode(dgvr.Cells[2].Value.ToString(), dgvr.Cells[3].Value.ToString());
                string nobr = ptxNobr.Text;
                string salcode = dgvr.Cells[3].Value.ToString();
                SalaryDS.SALBASDDataTable dt = new SalaryDS.SALBASDDataTable();
                SalaryMDDataContext smd = new SalaryMDDataContext();
                var sql = from s in smd.V_FRM46 where s.NOBR == nobr && s.SAL_CODE == salcode select s;
                dt.FillData(smd.GetCommand(sql));

                if (dt.Rows.Count > 0)
                {
                    var itms = from dd in dt let d = CDecryp.Number(dd.AMT) let da = Sal.Core.SalaryDate.DateString(dd.ADATE) select new { da, d };
                    DataTable tb = itms.CopyToDataTable();
                    tb.Columns[0].ColumnName = Resources.Sal.colAdate;
                    tb.Columns[1].ColumnName = Resources.Sal.colAmt;

                    Function.ShowView(Resources.Sal.colSalaryAdjust, tb);
                }

            }
        }

        private void ptxNobr_QueryCompleted(object sender, JBControls.PopupTextBox.QueryCompletedArgs e)
        {
            this.salaryDS.SALBASD.Clear();

            if (IsSkip)
            {
                IsSkip = false;
                this.sALBASDTableAdapter.FillByNobrDateBetween(this.salaryDS.SALBASD, "");
                return;
            }
            if (e.HasData)
            {
                if (!Sal.Function.CanView(ptxNobr.Text))
                {
                    MessageBox.Show("你沒有取得該員工資料的權限", Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    ptxNobr.Focus();
                    return;
                }
                btnSalary.Enabled = true;
                btnCancel.Enabled = true;

                txtAccount.DataBindings.Clear();
                txtBank.DataBindings.Clear();
                txtNameE.DataBindings.Clear();

                txtAccount.DataBindings.Add("Text", bASEBindingSource, "ACCOUNT_NO");
                txtBank.DataBindings.Add("Text", bASEBindingSource, "BANKNO");
                txtNameE.DataBindings.Add("Text", bASEBindingSource, "NAME_E");


                this.sALBASDTableAdapter.FillByNobrDateBetween(this.salaryDS.SALBASD, ptxNobr.Text);
                DataBind();
                JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
                var sql = from b in db.SALCODE
                          join c in db.SALATTR on b.SAL_ATTR equals c.SALATTR1
                          where c.BASIC && db.GetCodeFilter("SALCODE", b.SAL_CODE, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value
                          orderby b.SAL_CODE_DISP
                          select new { b.SAL_CODE, b.SAL_NAME, b.SAL_CODE_DISP };
                var baseRows = from a in db.BASETTS
                               where a.NOBR == ptxNobr.Text
                               //&& DateTime.Now.Date >= a.ADATE && DateTime.Now.Date <= a.DDATE.Value
                               orderby a.ADATE
                               select a;
                if (baseRows.Any())
                {
                    foreach (var itm in sql)
                    {
                        if (!salaryDS.SALBASD.Where(p => p.SAL_CODE == itm.SAL_CODE).Any())
                        {
                            SalaryDS.SALBASDRow row = salaryDS.SALBASD.NewSALBASDRow();
                            row.ADATE = baseRows.First().ADATE;
                            row.AMT = 0;
                            row.AMTB = 0;
                            row.DDATE = new DateTime(9999, 12, 31);
                            row.KEY_DATE = DateTime.Now;
                            row.KEY_MAN = "";
                            row.MENO = "";
                            row.NAME_C = ptxNobr.LabelText;
                            row.NOBR = ptxNobr.Text;
                            row.SAL_CODE = itm.SAL_CODE;
                            row.SAL_NAME = itm.SAL_NAME;
                            row.SAL_CODE_DISP = itm.SAL_CODE_DISP;
                            salaryDS.SALBASD.AddSALBASDRow(row);
                        }
                    }
                }
                this.bASEBindingSource.Filter = "nobr='" + ptxNobr.Text + "'";
                if (this.salaryDS.SALBASD.Count == 0)
                {
                    MessageBox.Show(Resources.Sal.SalbasdNoFound, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }

                dataGridView1.Sort(dataGridView1.Columns["sALCODEDataGridViewTextBoxColumn"], ListSortDirection.Ascending);

                decimal amt = this.salaryDS.SALBASD.Sum(aa => aa.AMT);
                txtAmt.Text = amt.ToString();
                FormInit();
            }

        }
        void DataBind()
        {
            foreach (var itm in this.salaryDS.SALBASD)//解密
            {
                itm.AMT = JBModule.Data.CDecryp.Number(itm.AMT);
            }
            this.salaryDS.SALBASD.AcceptChanges();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.salaryDS.SALBASD.RejectChanges();
            DataBind();//解密
            FormInit();

            btnSalary.Enabled = false;
            btnCancel.Enabled = false;
        }

        private void btnSalary_Click(object sender, EventArgs e)
        {
            if (!Sal.Function.CanModify(ptxNobr.Text))
            {
                MessageBox.Show("你沒有修改該員工資料的權限", Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            var ds = this.salaryDS.SALBASD.GetChanges() as SalaryDS.SALBASDDataTable;
            CDataLog.Save(this.Name, MainForm.USER_ID, DateTime.Now, this.salaryDS.SALBASD);
            foreach (var itm in ds)
            {
                if (itm.RowState == DataRowState.Added && itm.AMT == 0) continue;//0不新增
                itm.KEY_DATE = DateTime.Now;
                itm.KEY_MAN = MainForm.USER_NAME;
                itm.AMT = JBModule.Data.CEncrypt.Number(itm.AMT);
                this.sALBASDTableAdapter.Update(itm);//更新
                itm.AMT = JBModule.Data.CDecryp.Number(itm.AMT);
                itm.AcceptChanges();
            }
            //this.salaryDS.SALBASD.AcceptChanges();

            decimal amt = this.salaryDS.SALBASD.Sum(aa => aa.AMT);
            txtAmt.Text = amt.ToString();
            btnSalary.Enabled = false;
            btnCancel.Enabled = false;
        }

        private void dataGridView1_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                decimal amt = this.salaryDS.SALBASD.Sum(aa => aa.AMT);
                txtAmt.Text = amt.ToString();
            }
        }

        private void btnNoSalbasd_Click(object sender, EventArgs e)
        {
            string Nobr = "";
            var tb = CheckNoSalbasd(DateTime.Today.AddMonths(INDTPreMonth));
            if (tb.Rows.Count > 0 && INDTPreMonth != 0)
                Nobr = Function.ShowView(Resources.Sal.titleNoneWaged, tb);
            FormInit();
            if (Nobr.Trim().Length > 0)
            {
                button1_Click(null, null);
                ptxNobr.Text = Nobr;
                btnSalary.Focus();
                JBControls.PopupTextBox.QueryCompletedArgs ee = new JBControls.PopupTextBox.QueryCompletedArgs();
                ee.HasData = true;
                ptxNobr_QueryCompleted(ptxNobr, ee);
            }
        }

        DataTable CheckNoSalbasd(DateTime ddate)
        {
            SalaryMDDataContext db = new SalaryMDDataContext();
            string[] ttscode = new string[] { "1", "4", "6" };

            var baseSQL = from a in db.BASE
                          join b in db.BASETTS on a.NOBR equals b.NOBR
                          where DateTime.Now.Date >= b.ADATE && DateTime.Now.Date <= b.DDATE.Value
                          //&& ttscode.Contains(b.TTSCODE)
                          //&& db.GetFilterByNobr(a.NOBR, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value
                          && db.UserReadDataGroupList(MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Select(p => p.DATAGROUP).Contains(b.SALADR)
                          && !b.NOWAGE
                          select b;
            var baseList = baseSQL.ToList();
            var sql = from a in baseSQL
                      join b in db.SALBASD on a.NOBR equals b.NOBR
                      join c in db.SALCODE on b.SAL_CODE equals c.SAL_CODE
                      join d in db.SALATTR on c.SAL_ATTR equals d.SALATTR1
                      where DateTime.Now.Date >= b.ADATE && DateTime.Now.Date <= b.DDATE
                      && d.BASIC
                      select a;

            var nosal_List = from a in baseSQL
                             join b in sql on a.NOBR equals b.NOBR into ab
                             from nobr in ab.DefaultIfEmpty()
                             where nobr == null
                             && a.INDT >= ddate
                             select new { 員工編號 = a.NOBR, 員工姓名 = a.BASE.NAME_C, 到職日期 = a.INDT, 離職日期 = a.OUDT };


            DataTable tb = nosal_List.CopyToDataTable();
            //tb.Columns[0].ColumnName = Resources.Sal.colNobr;
            //tb.Columns[1].ColumnName = Resources.Sal.colInDate;
            //tb.Columns[2].ColumnName = Resources.Sal.colOutDate;

            return tb;
        }
    }
}
