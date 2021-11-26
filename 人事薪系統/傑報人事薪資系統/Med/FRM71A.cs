using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace JBHR.Med
{
    public partial class FRM71A : JBControls.JBForm
    {
        System.Data.OleDb.OleDbConnection OleDbConnection;
        private DataTable dt;

        public FRM71A()
        {
            InitializeComponent();


        }
        void SetEnable(bool enable)
        {
            cbxAmt.Enabled = enable;
            cbxComp.Enabled = enable;
            cbxDAMT.Enabled = enable;
            cbxYYMM.Enabled = enable;
            cbxSEQ.Enabled = enable;
            cbxFormat.Enabled = enable;
            cbxForsub.Enabled = enable;
            cbxMemo.Enabled = enable;
            cbxNobr.Enabled = enable;
            cbxTaxNO.Enabled = enable;
            cbxYRINA.Enabled = enable;
            cbxSalcode.Enabled = enable;
            cbxSupAmt.Enabled = enable;
            button2.Enabled = enable;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Excel|*.xls";//|全部檔案|*.*";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string path = ofd.FileName;
                try
                {
                    dt = JBModule.Data.CNPOI.RenderDataTableFromExcel(path, 0, 0);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(Resources.Sal.ExcelIOError, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }
                cbxAmt.Items.Clear();
                cbxComp.Items.Clear();
                cbxDAMT.Items.Clear();
                cbxFormat.Items.Clear();
                cbxForsub.Items.Clear();
                cbxMemo.Items.Clear();
                cbxNobr.Items.Clear();
                cbxTaxNO.Items.Clear();
                cbxYRINA.Items.Clear();
                cbxSalcode.Items.Clear();
                cbxYYMM.Items.Clear();
                cbxSEQ.Items.Clear();
                cbxSupAmt.Items.Clear();
                foreach (DataColumn col in dt.Columns)
                {
                    cbxAmt.Items.Add(col.ColumnName);
                    cbxComp.Items.Add(col.ColumnName);
                    cbxDAMT.Items.Add(col.ColumnName);
                    cbxFormat.Items.Add(col.ColumnName);
                    cbxForsub.Items.Add(col.ColumnName);
                    cbxMemo.Items.Add(col.ColumnName);
                    cbxNobr.Items.Add(col.ColumnName);
                    cbxTaxNO.Items.Add(col.ColumnName);
                    cbxYRINA.Items.Add(col.ColumnName);
                    cbxSalcode.Items.Add(col.ColumnName);
                    cbxYYMM.Items.Add(col.ColumnName);
                    cbxSEQ.Items.Add(col.ColumnName);
                    cbxSupAmt.Items.Add(col.ColumnName);
                }

                txtFileName.Text = path;
                SetEnable(true);
                CombBoxSettingDefault();
                cbxYYMM.Focus();
            }
        }
        void CombBoxSettingDefault()
        {
            if (cbxNobr.Items.Contains(lblNobr.Text)) cbxNobr.Text = lblNobr.Text;

            if (cbxSalcode.Items.Contains(lblSalcode.Text)) cbxSalcode.Text = lblSalcode.Text;

            if (cbxComp.Items.Contains(lblComp.Text)) cbxComp.Text = lblComp.Text;

            if (cbxAmt.Items.Contains(lblAmt.Text)) cbxAmt.Text = lblAmt.Text;

            if (cbxDAMT.Items.Contains(lblDAmt.Text)) cbxDAMT.Text = lblDAmt.Text;

            if (cbxYRINA.Items.Contains(lblYrina.Text)) cbxYRINA.Text = lblYrina.Text;

            if (cbxForsub.Items.Contains(lblForsub.Text)) cbxForsub.Text = lblForsub.Text;

            if (cbxFormat.Items.Contains(lblFormat.Text)) cbxFormat.Text = lblFormat.Text;

            if (cbxMemo.Items.Contains(lblMemo.Text)) cbxMemo.Text = lblMemo.Text;

            if (cbxTaxNO.Items.Contains(lblTaxno.Text)) cbxTaxNO.Text = lblTaxno.Text;

            if (cbxYYMM.Items.Contains(lblYYMM.Text)) cbxYYMM.Text = lblYYMM.Text;

            if (cbxSEQ.Items.Contains(lblSEQ.Text)) cbxSEQ.Text = lblSEQ.Text;

            if (cbxSupAmt.Items.Contains(lblSupAmt.Text)) cbxSupAmt.Text = lblSupAmt.Text;
        }
        bool CheckAvailable()
        {
            if (cbxYYMM.Text.Trim().Length == 0)
            {
                MessageBox.Show(lblYYMM.Text + "為必要欄位");
                cbxYYMM.Focus();
                return true;
            }

            if (cbxSEQ.Text.Trim().Length == 0)
            {
                MessageBox.Show(lblYYMM.Text + "為必要欄位");
                cbxSEQ.Focus();
                return true;
            }

            if (cbxNobr.Text.Trim().Length == 0)
            {
                MessageBox.Show(lblNobr.Text + "為必要欄位");
                cbxNobr.Focus();
                return true;
            }

            //if (cbxSalcode.Text.Trim().Length == 0)
            //{
            //    MessageBox.Show(lblSalcode.Text + "為必要欄位");
            //    cbxSalcode.Focus();
            //}

            if (cbxComp.Text.Trim().Length == 0)
            {
                MessageBox.Show(lblComp.Text + "為必要欄位");
                cbxComp.Focus();
                return true;
            }

            if (cbxAmt.Text.Trim().Length == 0)
            {
                MessageBox.Show(lblAmt.Text + "為必要欄位");
                cbxAmt.Focus();
                return true;
            }

            if (cbxDAMT.Text.Trim().Length == 0)
            {
                MessageBox.Show(lblDAmt.Text + "為必要欄位");
                cbxDAMT.Focus();
                return true;
            }

            //if (cbxYRINA.Text.Trim().Length == 0)
            //{
            //    MessageBox.Show(lblYrina.Text + "為必要欄位");
            //    cbxYRINA.Focus();
            //    return true;
            //}

            //if (cbxForsub.Text.Trim().Length == 0)
            //{
            //    MessageBox.Show(lblForsub.Text + "為必要欄位");
            //    cbxForsub.Focus();
            //    return true;
            //}

            if (cbxFormat.Text.Trim().Length == 0)
            {
                MessageBox.Show(lblFormat.Text + "為必要欄位");
                cbxFormat.Focus();
                return true;
            }

            //if (cbxMemo.Text.Trim().Length == 0)
            //{
            //    MessageBox.Show(lblNobr.Text + "為必要欄位");
            //    cbxMemo.Focus();
            //}

            //if (cbxTaxNO.Text.Trim().Length == 0)
            //{
            //    MessageBox.Show(lblTaxno.Text + "為必要欄位");
            //    cbxTaxNO.Focus();
            //}

            return false;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (CheckAvailable()) return;
            if (dt != null)
            {
                List<JBModule.Data.Linq.TWAGED> ExistTwagedList = new List<JBModule.Data.Linq.TWAGED>();
                List<JBModule.Data.Linq.TWAGED> AddTwagedList = new List<JBModule.Data.Linq.TWAGED>();
                JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
                var baseList = (from a in db.TBASE select new { a.NOBR, a.NAME_C, a.SALADR }).ToList();
                var data = new Sal.SalaryDS.ENRICHDataTable();
                //string yymm = txtYYMM.Text;
                //string seq = txtSeq.Text;
                //var twagedSQL = (from p in db.TWAGED where p.YYMM == yymm && p.SEQ == seq select p).ToList();
                foreach (DataRow r in dt.Rows)
                {
                    string yymm, seq, nobr, memo, comp, format, forsub, taxno, yrina, salcode;
                    decimal amt = 0, damt = 0, supamt;
                    try
                    {
                        if (dt.Columns.Contains(cbxAmt.Text)) amt = Convert.ToDecimal(r[cbxAmt.Text.ToString()]);
                        else decimal.TryParse(cbxAmt.Text, out amt);

                        if (dt.Columns.Contains(cbxComp.Text)) comp = r[cbxComp.Text].ToString();
                        else comp = cbxComp.Text;

                        if (dt.Columns.Contains(cbxDAMT.Text)) damt = Convert.ToDecimal(r[cbxDAMT.Text.ToString()]);
                        else decimal.TryParse(cbxDAMT.Text, out damt);

                        if (dt.Columns.Contains(cbxSupAmt.Text)) supamt = Convert.ToDecimal(r[cbxSupAmt.Text.ToString()]);
                        else decimal.TryParse(cbxSupAmt.Text, out supamt);

                        if (dt.Columns.Contains(cbxFormat.Text)) format = r[cbxFormat.Text].ToString();
                        else format = cbxFormat.Text;

                        if (dt.Columns.Contains(cbxYYMM.Text)) yymm = r[cbxYYMM.Text].ToString();
                        else yymm = cbxYYMM.Text;

                        if (dt.Columns.Contains(cbxSEQ.Text)) seq = r[cbxSEQ.Text].ToString();
                        else seq = cbxSEQ.Text;

                        if (dt.Columns.Contains(cbxForsub.Text)) forsub = r[cbxForsub.Text].ToString();
                        else forsub = cbxForsub.Text;

                        if (dt.Columns.Contains(cbxMemo.Text)) memo = r[cbxMemo.Text].ToString();
                        else memo = cbxMemo.Text;

                        if (dt.Columns.Contains(cbxNobr.Text)) nobr = r[cbxNobr.Text].ToString();
                        else nobr = cbxNobr.Text;

                        if (dt.Columns.Contains(cbxTaxNO.Text)) taxno = r[cbxTaxNO.Text].ToString();
                        else taxno = cbxTaxNO.Text;

                        if (dt.Columns.Contains(cbxYRINA.Text)) yrina = r[cbxYRINA.Text].ToString();
                        else yrina = cbxYRINA.Text;

                        if (dt.Columns.Contains(cbxSalcode.Text)) salcode = r[cbxSalcode.Text].ToString();
                        else salcode = cbxSalcode.Text;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(Resources.Sal.ExcelDataMaping, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        return;
                    }
                    JBModule.Data.Linq.TWAGED tw = new JBModule.Data.Linq.TWAGED();
                    tw.AMT = JBModule.Data.CEncrypt.Number(amt);
                    tw.COMP = comp;
                    tw.D_AMT = JBModule.Data.CEncrypt.Number(damt);
                    tw.FORMAT = format;
                    tw.FORSUB = forsub;
                    tw.INA_ID = yrina;
                    tw.KEY_DATE = DateTime.Now;
                    tw.KEY_MAN = MainForm.USER_NAME;
                    tw.MENO = memo;
                    tw.NOBR = nobr;
                    tw.SAL_CODE = salcode;
                    tw.SEQ = seq;
                    tw.SUBCODE = "";
                    tw.SUP_AMT = JBModule.Data.CEncrypt.Number(FRM71.SuppleInsCalc(tw.FORMAT, amt));
                    if (cbxSupAmt.Text.Trim().Length > 0)
                        tw.SUP_AMT = JBModule.Data.CEncrypt.Number(supamt);
                    var baseQuery = baseList.Where(p => p.NOBR == tw.NOBR);
                    if (baseQuery.Any())
                        tw.SALADR = baseQuery.First().SALADR;
                    else tw.SALADR = MainForm.WriteDataGroups.First();
                    tw.FORSUB = forsub;
                    tw.TAXNO = taxno;
                    tw.TR_TYPE = "";
                    tw.YYMM = yymm;
                    var checkExists = from a in db.TWAGED
                                      where a.NOBR == nobr && a.YYMM == yymm && a.SEQ == seq && a.FORMAT == format
                                      && a.SAL_CODE == salcode
                                      select a;
                    var checkExists1 = from a in AddTwagedList
                                       where a.NOBR == nobr && a.YYMM == yymm && a.SEQ == seq && a.FORMAT == format
                                       && a.SAL_CODE == salcode
                                       select a;
                    if (checkExists.Any())
                    {
                        tw.AMT = JBModule.Data.CDecryp.Number(tw.AMT);
                        tw.D_AMT = JBModule.Data.CDecryp.Number(tw.D_AMT);
                        tw.SUP_AMT = JBModule.Data.CDecryp.Number(tw.SUP_AMT);
                        ExistTwagedList.Add(tw);
                    }
                    else if (checkExists1.Any())
                    {
                        tw.AMT = JBModule.Data.CDecryp.Number(tw.AMT);
                        tw.D_AMT = JBModule.Data.CDecryp.Number(tw.D_AMT);
                        tw.SUP_AMT = JBModule.Data.CDecryp.Number(tw.SUP_AMT);
                        ExistTwagedList.Add(tw);
                    }
                    else
                    {
                        AddTwagedList.Add(tw);
                    }
                }
                db.TWAGED.InsertAllOnSubmit(AddTwagedList);
                db.SubmitChanges();
                if (ExistTwagedList.Any())
                {
                    var exportExists = ExistTwagedList.Select(p => new
                    {
                        員工編號 = p.NOBR,
                        計薪年月 = p.YYMM,
                        期別 = p.SEQ,
                        扣繳公司 = p.COMP,
                        所得代號 = p.SAL_CODE,
                        格式 = p.FORMAT,
                        金額 = p.AMT,
                        扣繳稅額 = p.D_AMT,
                        業別 = p.INA_ID,
                        給付項目 = p.FORSUB,
                        租賃稅籍編號 = p.TAXNO,
                        備註 = p.MENO
                    });
                    var existsDT = exportExists.CopyToDataTable();
                    var ds = new DataSet();
                    ds.Tables.Add(existsDT);
                    string Path = JBControls.ControlConfig.GetExportPath() + @"\各類所得重複資料.xls";
                    JBModule.Data.CNPOI.SaveDataSetToExcel(ds, Path);
                    MessageBox.Show("匯入完成，有" + existsDT.Rows.Count.ToString() + "筆重複的資料(" + Path + ")", Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    MessageBox.Show("匯入完成", Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
        }

        private void FRM62I_Load(object sender, EventArgs e)
        {

            SetEnable(false);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
