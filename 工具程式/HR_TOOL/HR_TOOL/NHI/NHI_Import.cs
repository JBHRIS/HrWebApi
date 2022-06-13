using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HR_TOOL.NHI
{
    public partial class NHI_Import : Form
    {
        public NHI_Import()
        {
            InitializeComponent();
        }
        DataSet ds;
        private void buttonFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                textBox1.Text = ofd.FileName;
                ds = JBModule.Data.CNPOI.ReadExcelToDataSet(ofd.FileName);
                SetState();
            }
        }
        void SetState()
        {
            comboBoxSheet.Enabled = ds != null;
            comboBoxSheet.Items.Clear();
            if (ds != null)
            {
                foreach (DataTable it in ds.Tables)
                {
                    comboBoxSheet.Items.Add(it.TableName);
                }
            }
        }
        List<string> ExcelColumns = new List<string>();
        void SetColumn()
        {
            ExcelColumns.Clear();
            comboBoxAmt.Items.Clear();
            comboBoxBirthday.Items.Clear();
            comboBoxFaName.Items.Clear();
            comboBoxIDNO.Items.Clear();
            comboBoxIdType.Items.Clear();
            comboBoxName.Items.Clear();
            comboBoxSNO.Items.Clear();
            var table = ds.Tables[comboBoxSheet.Text];
            foreach (DataColumn col in table.Columns)
            {
                ExcelColumns.Add(col.ColumnName);
                comboBoxAmt.Items.Add(col.ColumnName);
                comboBoxBirthday.Items.Add(col.ColumnName);
                comboBoxFaName.Items.Add(col.ColumnName);
                comboBoxIDNO.Items.Add(col.ColumnName);
                comboBoxIdType.Items.Add(col.ColumnName);
                comboBoxName.Items.Add(col.ColumnName);
                comboBoxSNO.Items.Add(col.ColumnName);
            }
            foreach (var it in ExcelColumns)
            {
                if (it.Contains("投保金額/平均保險費"))
                    comboBoxAmt.Text = it;
                if (it.Contains("出生日期"))
                    comboBoxBirthday.Text = it;
                if (it.Contains("眷屬姓名"))
                    comboBoxFaName.Text = it;
                if (it.Contains("身分證號"))
                    comboBoxIDNO.Text = it;
                if (it.Contains("身份別"))
                    comboBoxIdType.Text = it;
                if (it.Contains("被保險人姓名"))
                    comboBoxName.Text = it;
                if (it.Contains("單位代號"))
                    comboBoxSNO.Text = it;
            }
        }
        private void buttonLoad_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.Tables[comboBoxSheet.Text];
            SetColumn();

        }

        private void buttonImport_Click(object sender, EventArgs e)
        {
            var dt = ds.Tables[comboBoxSheet.Text];
            var dtError = dt.Copy();
            dtError.Rows.Clear();
            HrDBDataContext db = new HrDBDataContext();
            DateTime d1 = new DateTime(Convert.ToInt32(textBoxYYMM.Text.Substring(0, 4)), Convert.ToInt32(textBoxYYMM.Text.Substring(4, 2)), 1);
            DateTime d2 = d1.AddMonths(1).AddDays(-1);
            var inscomp = db.INSCOMP.ToList();
            int count = 0;
            foreach (DataRow r in dt.Rows)
            {
                count++;
                string amt, birth, fa_name, idno, idtype, name, sno;
                amt = r[comboBoxAmt.Text].ToString();
                birth = r[comboBoxBirthday.Text].ToString();
                fa_name = r[comboBoxFaName.Text].ToString();
                idno = r[comboBoxIDNO.Text].ToString();
                idtype = r[comboBoxIdType.Text].ToString();
                name = r[comboBoxName.Text].ToString();
                sno = r[comboBoxSNO.Text].ToString();
                if (name.Trim().Length > 0)//員工
                {
                    var checkIns = from a in db.INSLAB
                                   join b in db.BASE on a.NOBR equals b.NOBR
                                   where a.FA_IDNO.Trim().Length == 0
                                   && b.IDNO == idno
                                   && a.IN_DATE <= d2 && a.OUT_DATE >= d1
                                   select a;
                    if (checkIns.Any())//目前有資料
                    {
                        var ins = checkIns.First();
                        ins.H_AMT = JBModule.Data.CEncrypt.Number(Convert.ToDecimal(amt));
                        ins.NOTE = "JB_Import20140619";
                    }
                    else
                    {

                        var checkInsOld = from a in db.INSLAB
                                          join b in db.BASE on a.NOBR equals b.NOBR
                                          where a.FA_IDNO.Trim().Length == 0
                                          && b.IDNO == idno
                                          orderby a.IN_DATE descending
                                          select a;
                        if (checkInsOld.Any())//目前有資料
                        {
                            var ins = checkInsOld.First();
                            ins.H_AMT = JBModule.Data.CEncrypt.Number(Convert.ToDecimal(amt));
                            ins.NOTE = "JB_Import20140619";
                        }
                        else
                        {
                            var checkIns1 = from a in db.BASE
                                            join b in db.BASETTS on a.NOBR equals b.NOBR
                                            where a.IDNO == idno
                                            orderby b.ADATE descending
                                            select new { a.NOBR, a.IDNO, b.INDT };
                            if (checkIns1.Any())//未加保
                            {
                                var rIns = checkIns1.First();
                                INSLAB ins = new INSLAB();
                                ins.CODE = "1";
                                ins.CODE1 = "1";
                                ins.FA_IDNO = "";
                                ins.H_AMT = JBModule.Data.CEncrypt.Number(Convert.ToDecimal(amt));
                                ins.HRATE_CODE = "1";
                                ins.IN_DATE = rIns.INDT.Value;
                                ins.KEY_DATE = DateTime.Now;
                                ins.KEY_MAN = "JB";
                                ins.L_AMT = ins.H_AMT;
                                if (JBModule.Data.CEncrypt.Number(Convert.ToDecimal(amt)) > 43900M)
                                    ins.L_AMT = JBModule.Data.CEncrypt.Number(43900M);
                                ins.LRATE_CODE = "1";
                                ins.NOBR = rIns.NOBR;
                                ins.NOTE = "JB_Import20140619";
                                ins.OUT_DATE = new DateTime(9999, 12, 31);
                                ins.R_AMT = ins.H_AMT;
                                ins.ROUT_DATE = new DateTime(9999, 12, 31); ;
                                ins.S_NO = "";
                                var inscompCheck = from a in inscomp where a.INSIDNO == sno select a;
                                if (inscompCheck.Any())
                                {
                                    ins.S_NO = inscompCheck.First().S_NO;
                                }
                                ins.SEQ = "";
                                ins.SPTYP = "";
                                ins.WBSPTYP = "";
                                db.INSLAB.InsertOnSubmit(ins);
                            }
                            else//還是找不到
                            {
                                dtError.ImportRow(r);
                            }
                        }
                    }
                }
                else//眷屬
                {
                    var checkIns = from a in db.INSLAB
                                   where a.FA_IDNO.Trim().Length > 0
                                   && a.FA_IDNO == idno
                                   && a.IN_DATE <= d2 && a.OUT_DATE >= d1
                                   select a;
                    if (checkIns.Any())//目前有資料
                    {
                        var ins = checkIns.First();
                        ins.H_AMT = JBModule.Data.CEncrypt.Number(Convert.ToDecimal(amt));
                        ins.NOTE = "JB_Import20140619";
                    }
                    else
                    {
                        var checkIns1 = from a in db.FAMILY
                                        join b in db.BASETTS on a.NOBR equals b.NOBR
                                        where a.FA_IDNO == idno
                                        orderby b.ADATE descending
                                        select new { a.NOBR, a.FA_IDNO, b.INDT };
                        if (checkIns1.Any())//未加保
                        {
                            var rIns = checkIns1.First();
                            INSLAB ins = new INSLAB();
                            ins.CODE = "1";
                            ins.CODE1 = "1";
                            ins.FA_IDNO = rIns.FA_IDNO;
                            ins.H_AMT = JBModule.Data.CEncrypt.Number(Convert.ToDecimal(amt));
                            ins.HRATE_CODE = "1";
                            ins.IN_DATE = rIns.INDT.Value;
                            ins.KEY_DATE = DateTime.Now;
                            ins.KEY_MAN = "JB";
                            ins.L_AMT = ins.H_AMT;
                            if (JBModule.Data.CEncrypt.Number(Convert.ToDecimal(amt)) > 43900M)
                                ins.L_AMT = JBModule.Data.CEncrypt.Number(43900M);
                            ins.LRATE_CODE = "1";
                            ins.NOBR = rIns.NOBR;
                            ins.NOTE = "";
                            ins.OUT_DATE = new DateTime(9999, 12, 31);
                            ins.R_AMT = ins.H_AMT;
                            ins.ROUT_DATE = new DateTime(9999, 12, 31); ;
                            ins.S_NO = "";
                            ins.NOTE = "JB_Import20140619";
                            var inscompCheck = from a in inscomp where a.INSIDNO == sno select a;
                            if (inscompCheck.Any())
                            {
                                ins.S_NO = inscompCheck.First().S_NO;
                            }
                            ins.SEQ = "";
                            ins.SPTYP = "";
                            ins.WBSPTYP = "";
                            db.INSLAB.InsertOnSubmit(ins);
                        }
                        else//還是找不到
                        {
                            dtError.ImportRow(r);
                        }
                    }
                }
            }
            db.SubmitChanges();
            MessageBox.Show("完成");
            DataSet dsError = new DataSet("保險錯誤名單");
            dtError.TableName = "對應不到資料";
            dsError.Tables.Add(dtError);
            JBModule.Data.CNPOI.SaveDataSetToExcel(dsError, @"C:\Temp\健保匯入-對應不到資料名單.xls");
        }

        private void NHI_Import_Load(object sender, EventArgs e)
        {
            textBoxYYMM.Text = DateTime.Today.AddMonths(-1).ToString("yyyyMM");
        }

        private void buttonIG_Click(object sender, EventArgs e)
        {
            var dt = ds.Tables[comboBoxSheet.Text];
            var dtError = dt.Copy();
            dtError.Rows.Clear();
            HrDBDataContext db = new HrDBDataContext();
            DateTime d1 = new DateTime(Convert.ToInt32(textBoxYYMM.Text.Substring(0, 4)), Convert.ToInt32(textBoxYYMM.Text.Substring(4, 2)), 1);
            DateTime d2 = d1.AddMonths(1).AddDays(-1);
            var inscomp = db.INSCOMP.ToList();
            int count = 0;
            foreach (DataRow r in dt.Rows)
            {
                count++;
                string amt, birth, fa_name, idno, idtype, name, sno;
                //amt = r[comboBoxAmt.Text].ToString();
                //birth = r[comboBoxBirthday.Text].ToString();
                //fa_name = r[comboBoxFaName.Text].ToString();
                idno = r[comboBoxIDNO.Text].ToString().Split('\\').First().Trim();
                //idtype = r[comboBoxIdType.Text].ToString();
                //name = r[comboBoxName.Text].ToString();
                //sno = r[comboBoxSNO.Text].ToString();
                //if (name.Trim().Length > 0)//員工
                //{
                var checkIns = from a in db.INSLAB
                               join b in db.BASE on a.NOBR equals b.NOBR
                               where a.FA_IDNO.Trim().Length == 0
                               && b.IDNO == idno
                               && b.IDNO.Trim().Length > 0
                               && a.IN_DATE <= d2 && a.OUT_DATE >= d1
                               select a;
                if (checkIns.Any())//目前有資料
                {
                    //var ins = checkIns.First();
                    //ins.H_AMT = JBModule.Data.CEncrypt.Number(Convert.ToDecimal(amt));
                    //ins.NOTE = "JB_Import20140619";
                }
                else
                {

                    var checkInsOld = from a in db.INSLABG
                                      join b in db.BASE on a.NOBR equals b.NOBR
                                      where a.FA_IDNO.Trim().Length == 0
                                      && b.IDNO == idno
                                      && b.IDNO.Trim().Length > 0
                                      orderby a.IN_DATE descending
                                      select a;
                    if (checkInsOld.Any())//目前有資料
                    {
                        //var ins = checkInsOld.First();
                        //ins.H_AMT = JBModule.Data.CEncrypt.Number(Convert.ToDecimal(amt));
                        //ins.NOTE = "JB_Import20140619";
                    }
                    else
                    {
                        var checkIns1 = from a in db.BASE
                                        join b in db.BASETTS on a.NOBR equals b.NOBR
                                        where a.IDNO == idno
                                        && a.IDNO.Trim().Length > 0
                                        orderby b.ADATE descending
                                        select new { a.NOBR, a.IDNO, b.INDT };
                        if (checkIns1.Any())//未加保
                        {
                            var rIns = checkIns1.First();
                            INSLABG ins = new INSLABG();
                            ins.CODE = "1";
                            ins.FA_IDNO = "";
                            //ins.H_AMT = JBModule.Data.CEncrypt.Number(Convert.ToDecimal(amt));
                            //ins.HRATE_CODE = "1";
                            ins.IN_DATE = rIns.INDT.Value;
                            ins.KEY_DATE = DateTime.Now;
                            ins.KEY_MAN = "JB";
                            ins.AMT = 0;
                            //if (JBModule.Data.CEncrypt.Number(Convert.ToDecimal(amt)) > 43900M)
                            //    ins.L_AMT = JBModule.Data.CEncrypt.Number(43900M);
                            //ins.LRATE_CODE = "1";
                            ins.NOBR = rIns.NOBR;
                            ins.NOTE = "JB_Import_InsG";
                            ins.OUT_DATE = new DateTime(9999, 12, 31);
                            //ins.R_AMT = ins.H_AMT;
                            //ins.ROUT_DATE = new DateTime(9999, 12, 31); ;
                            //ins.S_NO = "";
                            //var inscompCheck = from a in inscomp where a.INSIDNO == sno select a;
                            //if (inscompCheck.Any())
                            //{
                            //    ins.S_NO = inscompCheck.First().S_NO;
                            //}
                            //ins.SEQ = "";
                            //ins.SPTYP = "";
                            //ins.WBSPTYP = "";
                            db.INSLABG.InsertOnSubmit(ins);
                        }
                        else//還是找不到
                        {
                            var checkInsF = from a in db.INSLABG
                                            where a.FA_IDNO.Trim().Length > 0
                                            && a.FA_IDNO == idno
                                            && a.FA_IDNO.Trim().Length > 0
                                            && a.IN_DATE <= d2 && a.OUT_DATE >= d1
                                            select a;
                            if (checkInsF.Any())//目前有資料
                            {
                                //var ins = checkIns.First();
                                //ins.H_AMT = JBModule.Data.CEncrypt.Number(Convert.ToDecimal(amt));
                                //ins.NOTE = "JB_Import20140619";
                            }
                            else
                            {
                                var checkIns2 = from a in db.FAMILY
                                                join b in db.BASETTS on a.NOBR equals b.NOBR
                                                where a.FA_IDNO == idno
                                                  && a.FA_IDNO.Trim().Length > 0
                                                orderby b.ADATE descending
                                                select new { a.NOBR, a.FA_IDNO, b.INDT };
                                if (checkIns2.Any())//未加保
                                {
                                    var rIns = checkIns2.First();
                                    INSLABG ins = new INSLABG();
                                    ins.CODE = "1";
                                    //ins.CODE1 = "1";
                                    ins.FA_IDNO = rIns.FA_IDNO;
                                    //ins.H_AMT = JBModule.Data.CEncrypt.Number(Convert.ToDecimal(amt));
                                    //ins.HRATE_CODE = "1";
                                    ins.IN_DATE = rIns.INDT.Value;
                                    ins.KEY_DATE = DateTime.Now;
                                    ins.KEY_MAN = "JB";
                                    ins.AMT = 0;
                                    //if (JBModule.Data.CEncrypt.Number(Convert.ToDecimal(amt)) > 43900M)
                                    //    ins.L_AMT = JBModule.Data.CEncrypt.Number(43900M);
                                    //ins.LRATE_CODE = "1";
                                    ins.NOBR = rIns.NOBR;
                                    ins.NOTE = "";
                                    ins.OUT_DATE = new DateTime(9999, 12, 31);
                                    //ins.R_AMT = ins.H_AMT;
                                    //ins.ROUT_DATE = new DateTime(9999, 12, 31); ;
                                    //ins.S_NO = "";
                                    ins.NOTE = "JB_Import_InsG";
                                    //var inscompCheck = from a in inscomp where a.INSIDNO == sno select a;
                                    //if (inscompCheck.Any())
                                    //{
                                    //    ins.S_NO = inscompCheck.First().S_NO;
                                    //}
                                    //ins.SEQ = "";
                                    //ins.SPTYP = "";
                                    //ins.WBSPTYP = "";
                                    db.INSLABG.InsertOnSubmit(ins);
                                }
                                else//還是找不到
                                {
                                    dtError.ImportRow(r);
                                }
                            }

                        }
                    }
                }
            }
            db.SubmitChanges();
            MessageBox.Show("完成");
            DataSet dsError = new DataSet("保險錯誤名單");
            dtError.TableName = "對應不到資料";
            dsError.Tables.Add(dtError);
            JBModule.Data.CNPOI.SaveDataSetToExcel(dsError, @"C:\Temp\團保匯入-對應不到資料名單.xls");
        }
    }
}
