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
    public partial class FRM3AA : JBControls.JBForm
    {
        public DateTime TransDate = DateTime.Now;
        public FRM3AA()
        {
            InitializeComponent();
        }
        DataSet ds;
        DataTable dt;
        public Ins.InsDS.FRM3AZDataTable dtImport;
        public DateTime ddate;
        private void IP_FRM4L_Load(object sender, EventArgs e)
        {
            txtDdate.Text = Sal.Core.SalaryDate.DateString();
        }

        private void btnBrowser_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Excel|*.xls";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string path = ofd.FileName;
                try
                {
                    ds = JBModule.Data.CNPOI.ReadExcelToDataSet(path);
                    comboBoxSheet.Items.Clear();
                    foreach (DataTable itm in ds.Tables)
                    {
                        comboBoxSheet.Items.Add(itm.TableName);
                    }
                    textBox1.Text = path;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(Resources.Sal.ExcelIOError + Environment.NewLine + ex.Message, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }

            }
        }

        //private void btnPreview_Click(object sender, EventArgs e)
        //{
        //    if (dt != null)
        //    {
        //        setTable();
        //        PreviewForm vw = new PreviewForm();

        //        var query = from a in dtImport select new { a.NOBR, a.NAME_C, a.L_AMT, a.L_AMT1, a.H_AMT, a.H_AMT1, a.R_AMT, a.R_AMT1 };
        //        var dt1 = query.CopyToDataTable();
        //        foreach (DataColumn dc in dt1.Columns)
        //            dc.ColumnName = dtImport.Columns[dc.ColumnName].Caption;
        //        vw.DataTable = dt1;

        //        vw.Width = 800;
        //        vw.ShowDialog();
        //        //Sal.ViewDSTableAdapters.ENRICHTableAdapter ad = new JBHR.Sal.ViewDSTableAdapters.ENRICHTableAdapter();

        //    }

        //}
        void setTable()
        {
            dtImport = new Ins.InsDS.FRM3AZDataTable();
            Sal.Core.Inslab.Inslab ins=new Core.Inslab.Inslab();
            JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
            ddate = Convert.ToDateTime(txtDdate.Text);
            var inslabSQL = (from a in db.INSLAB
                             join b in db.BASE on a.NOBR equals b.NOBR
                             join c in db.BASETTS on a.NOBR equals c.NOBR
                             join d in db.INSCOMP on a.S_NO equals d.S_NO
                             where
                                 (a.IN_DATE <= ddate && a.OUT_DATE >= ddate)
                                 && ddate >= c.ADATE && ddate <= c.DDATE.Value
                             select new { BASE = b, BASETTS = c, INSLAB = a , INSCOMP = d}).ToList();
            insDS.FRM3AZ.Clear();
            int total, current = 0;
            total = dt.Rows.Count;
            foreach (DataRow r in dt.Rows)
            {
                current++;
                pbStatus.Value = current * 100 / total;
                decimal lab, hea, ret;
                string memo, nobr;
                try
                {
                    if (dt.Columns.Contains(cbxLab.Text)) lab = Convert.ToDecimal(r[cbxLab.Text.ToString()]);
                    else
                    {
                        bool isDecimal = decimal.TryParse(cbxLab.Text, out lab);
                        if (!isDecimal && cbxLab.Text.Trim().Length > 0)
                        {
                            MessageBox.Show("轉換格式(Decimal)時發生錯誤，" + cbxLab.Text, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            return;
                        }
                    }
                    lab = ins.GetLabAmt(lab);

                    if (dt.Columns.Contains(cbxHea.Text)) hea = Convert.ToDecimal(r[cbxHea.Text.ToString()]);
                    else
                    {
                        bool isDecimal = decimal.TryParse(cbxHea.Text, out hea);
                        if (!isDecimal && cbxHea.Text.Trim().Length > 0)
                        {
                            MessageBox.Show("轉換格式(Decimal)時發生錯誤，" + cbxHea.Text, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            return;
                        }                       
                    }
                    hea = ins.GetHeaAmt(hea);
                    if (dt.Columns.Contains(cbxRet.Text)) ret = Convert.ToDecimal(r[cbxRet.Text.ToString()]);
                    else
                    {
                        bool isDecimal = decimal.TryParse(cbxRet.Text, out ret);
                        if (!isDecimal && cbxRet.Text.Trim().Length > 0)
                        {
                            MessageBox.Show("轉換格式(Decimal)時發生錯誤，" + cbxRet.Text, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            return;
                        }
                    }
                    ret = ins.GetRetAmt(ret);

                    if (dt.Columns.Contains(cbxNobr.Text)) nobr = r[cbxNobr.Text].ToString();
                    else nobr = cbxNobr.Text;

                    if (dt.Columns.Contains(cbMemo.Text)) memo = r[cbMemo.Text].ToString();
                    else memo = cbMemo.Text;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(Resources.Sal.ExcelDataMaping, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }
                var inslabSQCheck = from a in inslabSQL where (a.INSLAB.IN_DATE <= ddate && a.INSLAB.OUT_DATE >= ddate) && a.BASE.NOBR == nobr select a;
                if (!inslabSQCheck.Any())//找不到工號就找身分證號
                {
                    inslabSQCheck = from a in inslabSQL where (a.INSLAB.IN_DATE <= ddate && a.INSLAB.OUT_DATE >= ddate) && a.BASE.IDNO == nobr select a;
                }
                //var inslabSQLofHea = from a in inslabSQL where (a.INSLAB.HBDATE <= ddate && a.INSLAB.HEDATE >= ddate) && a.BASE.NOBR == nobr select a;
                //var inslabSQLofRet = from a in inslabSQL where (a.INSLAB.RBDATE <= ddate && a.INSLAB.REDATE >= ddate) && a.BASE.NOBR == nobr select a;
                var rowImp = insDS.FRM3AZ.NewFRM3AZRow();
                rowImp.NAME_C = "";
                rowImp.RETCHOO = "";
                rowImp.H_AMT = -1;
                //if (inslabSQLofHea.Any())
                //{                   
                //    rowImp.H_AMT = JBModule.Data.CDecryp.Number(inslabSQLofHea.First().INSLAB.H_AMT);
                //    rowImp.NAME_C = inslabSQLofHea.First().BASE.NAME_C;
                //    rowImp.RETCHOO = inslabSQLofHea.First().BASETTS.RETCHOO;
                //    if (inslabSQLofHea.First().INSLAB.HEDATE.Date < new DateTime(9999, 12, 31))
                //        rowImp.H_AMT = -2;//代表不是最後一筆資料(已異動)
                //}
                rowImp.H_AMT1 = 0;
                if (cbxHea.Text.Trim().Length == 0) rowImp.H_AMT1 = rowImp.H_AMT;//如果未選擇就是代表不變

                else rowImp.H_AMT1 = hea;
                rowImp.L_AMT = -1;
                rowImp.L_AMT1 = 0; 
                rowImp.R_AMT = -1;
                rowImp.R_AMT1 = 0;
                rowImp.REMARK = "";
                rowImp.NOBR = nobr;
                if (inslabSQCheck.Any())
                {
                    rowImp.L_AMT = JBModule.Data.CDecryp.Number(inslabSQCheck.First().INSLAB.L_AMT);
                    rowImp.H_AMT = JBModule.Data.CDecryp.Number(inslabSQCheck.First().INSLAB.H_AMT);
                    rowImp.R_AMT = JBModule.Data.CDecryp.Number(inslabSQCheck.First().INSLAB.R_AMT);
                    rowImp.NAME_C = inslabSQCheck.First().BASE.NAME_C;
                    rowImp.RETCHOO = inslabSQCheck.First().BASETTS.RETCHOO;
                    rowImp.NOBR = inslabSQCheck.First().BASE.NOBR;
                    if (inslabSQCheck.First().INSLAB.OUT_DATE.Date < new DateTime(9999, 12, 31))
                        rowImp.REMARK += "調整必須為最新的投保資料;";//代表不是最後一筆資料(已異動)
                    if (inslabSQCheck.First().INSLAB.IN_DATE == ddate)
                        rowImp.REMARK += "已存在相同時間的投保資料;";//代表不是最後一筆資料(已異動)
                    rowImp.InsComp = inslabSQCheck.First().INSCOMP.INSNAME;
                }
                else
                    rowImp.REMARK += "找不到投保資料;";
                if (cbxLab.Text.Trim().Length == 0) rowImp.L_AMT1 = rowImp.L_AMT;//如果未選擇就是代表不變
                else rowImp.L_AMT1 = lab;

                rowImp.NOTTRAN = false;
               
                if (cbxRet.Text.Trim().Length == 0) rowImp.R_AMT1 = rowImp.R_AMT;//如果未選擇就是代表不變
                else
                {
                    rowImp.R_AMT1 = ret;
                }
                rowImp.SALARY = 0;
                rowImp.SALARYA = 0;

                if (rowImp.NAME_C.Trim().Length == 0)
                {
                    var baseData = from a in db.BASE
                                   join b in db.BASETTS on a.NOBR equals b.NOBR
                                   where ddate >= b.ADATE && ddate <= b.DDATE.Value
                                   && a.NOBR == nobr
                                   select new { BASE = a, BASETTS = b };
                    if (baseData.Any())
                    {
                        rowImp.NAME_C = baseData.First().BASE.NAME_C;
                        rowImp.RETCHOO = baseData.First().BASETTS.RETCHOO;
                    }
                }
                insDS.FRM3AZ.AddFRM3AZRow(rowImp);
            }
        }
        private void btnImport_Click(object sender, EventArgs e)
        {
            var dd = Convert.ToDateTime(txtDdate.Text);
            if (dd.Day != 1)
            {
                MessageBox.Show("調整日期必須在月初，請重新確認一次調整日期", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //setTable();
            int total = 0, success = 0, fault = 0;
            total = insDS.FRM3AZ.Rows.Count;
            foreach (var it in insDS.FRM3AZ)
            {
                if (it.REMARK.Trim().Length > 0)
                {
                    fault++;
                    continue;
                }
                var newRow = this.dtImport.NewFRM3AZRow();
                for (int i = 0; i < this.dtImport.Columns.Count; i++)
                {
                    newRow[i] = it[i];
                }
                this.dtImport.AddFRM3AZRow(newRow);
                success++;
            }
            TransDate = Convert.ToDateTime(txtDdate.Text);
            MessageBox.Show(string.Format("匯入完成，共{0}筆，成功{1}筆，失敗{2}筆", total, success, fault));
            this.Close();
        }
        //void ReSetSalbasdOfNobrSalcode(string nobr, string salcode)
        //{
        //    SalaryMDDataContext smd = new SalaryMDDataContext();
        //    var salbasd_of_NobrSalcode = from salbasd_row in smd.SALBASD
        //                                 where salbasd_row.NOBR.Trim().Equals(nobr) && salbasd_row.SAL_CODE.Trim().Equals(salcode)
        //                                 orderby salbasd_row.ADATE descending
        //                                 select salbasd_row;
        //    DateTime dt = new DateTime(9999, 12, 31);
        //    foreach (var itm in salbasd_of_NobrSalcode)
        //    {
        //        itm.DDATE = dt;
        //        dt = itm.ADATE.AddDays(-1);
        //    }
        //    smd.SubmitChanges();
        //}

        private void comboBoxSheet_SelectedIndexChanged(object sender, EventArgs e)
        {
            dt = ds.Tables[comboBoxSheet.SelectedItem.ToString()];

            cbxNobr.Items.Clear();
            cbxLab.Items.Clear();
            cbxHea.Items.Clear();
            cbxRet.Items.Clear();
            cbMemo.Items.Clear();
            foreach (DataColumn col in dt.Columns)
            {
                cbxNobr.Items.Add(col.ColumnName);
                cbxLab.Items.Add(col.ColumnName);
                cbxHea.Items.Add(col.ColumnName);
                cbxRet.Items.Add(col.ColumnName);
                cbMemo.Items.Add(col.ColumnName);
            }

            txtDdate.Focus();
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            if (dt != null)
            {
                PreviewForm vw = new PreviewForm();
                vw.Text = "資料預覽";
                vw.DataTable = dt;
                vw.Width = 800;
                vw.ShowDialog();
                //Sal.ViewDSTableAdapters.ENRICHTableAdapter ad = new JBHR.Sal.ViewDSTableAdapters.ENRICHTableAdapter();

            }
        }

        private void buttonGen_Click(object sender, EventArgs e)
        {
            var dd = Convert.ToDateTime(txtDdate.Text);
            if (dd.Day != 1)
            {
                MessageBox.Show("調整日期必須在月初，請重新確認一次調整日期", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            setTable();
            TransDate = Convert.ToDateTime(txtDdate.Text);
            //this.Close();
        }
    }

}