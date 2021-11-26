using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace JBHR.Ins
{
    public partial class FRM3FI : JBControls.JBForm
    {
        public FRM3FI()
        {
            InitializeComponent();

            txtYYMM.Enabled = false;
            cbFA_IDNO.Enabled = false;
            cbEXP.Enabled = false;
            cbCOMP.Enabled = false;
            cbTYPE.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                txtFileName.Text = openFileDialog.FileName;

                DataTable excelDataTable = JBModule.Data.CNPOI.RenderDataTableFromExcel(txtFileName.Text, 0, 0);
                dataGridViewEx1.DataSource = excelDataTable;

                cbFA_IDNO.ClearItems();
                cbFA_IDNO.ValueMember = "ColumnName";
                cbFA_IDNO.AddItem((from DataColumn c in excelDataTable.Columns select c.ColumnName).ToArray());

                cbEXP.ClearItems();
                cbEXP.ValueMember = "ColumnName";
                cbEXP.AddItem((from DataColumn c in excelDataTable.Columns select c.ColumnName).ToArray());

                cbCOMP.ClearItems();
                cbCOMP.ValueMember = "ColumnName";
                cbCOMP.AddItem((from DataColumn c in excelDataTable.Columns select c.ColumnName).ToArray());

                txtYYMM.Enabled = true;
                cbFA_IDNO.Enabled = true;
                cbEXP.Enabled = true;
                cbCOMP.Enabled = true;
                cbTYPE.Enabled = true;
            }
        }

        private void FRM3FI_Load(object sender, EventArgs e)
        {
            this.iNSUR_TYPETableAdapter.Fill(this.insDS.INSUR_TYPE);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            InsDataClassesDataContext db = new InsDataClassesDataContext();
            Sal.Core.SalaryDate sd = new Sal.Core.SalaryDate(txtYYMM.Text);
            var explabSQL = (from a in db.EXPLAB
                             join b in db.BASE on a.NOBR equals b.NOBR
                             where a.YYMM == txtYYMM.Text && a.INSUR_TYPE == cbTYPE.SelectedValue
                             //&& db.GetFilterByNobr(a.NOBR, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value
                             && (from bts in db.BASETTS
                                 where bts.NOBR == b.NOBR
                                 && DateTime.Now.Date >= bts.ADATE && DateTime.Now.Date <= bts.DDATE
                                 && (from urdg in db.UserReadDataGroupList(MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN) select urdg.DATAGROUP).Contains(bts.SALADR)
                                 select 1).Any()
                             select new { a.NOBR, a.FA_IDNO, b.IDNO }).ToList();
            var FAexplabSQL = (from a in db.EXPLAB
                               join b in db.FAMILY on new { a.NOBR, a.FA_IDNO } equals new { b.NOBR, b.FA_IDNO }
                               where a.YYMM == txtYYMM.Text && a.INSUR_TYPE == cbTYPE.SelectedValue
                               //&& db.GetFilterByNobr(a.NOBR, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value
                               && (from bts in db.BASETTS
                                   where bts.NOBR == b.NOBR
                                   && DateTime.Now.Date >= bts.ADATE && DateTime.Now.Date <= bts.DDATE
                                   && (from urdg in db.UserReadDataGroupList(MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN) select urdg.DATAGROUP).Contains(bts.SALADR)
                                   select 1).Any()
                               select new { a.NOBR, a.FA_IDNO }).ToList();
            DateTime d1, d2;
            d1 = sd.FirstDayOfMonth;
            d2 = sd.LastDayOfMonth;
            this.Enabled = false;
            try
            {
                if (db.Connection.State == ConnectionState.Closed) db.Connection.Open();
                db.ExecuteCommand("delete from INPOLAB where yymm = '" + txtYYMM.Text + "' and INSUR_TYPE = '" + cbTYPE.SelectedValue + "' and " + Sal.Function.GetFilterCmdByNobrOfWrite("inpolab.nobr"));
                //and SALADR = '" + MainForm.WORKADR + "'");
            }
            finally
            {
                db.Connection.Close();
            }

            DataTable dtSource = dataGridViewEx1.DataSource as DataTable;

            foreach (DataRow row in dtSource.Rows)
            {
                if (row.IsNull(cbFA_IDNO.SelectedValue)) row.Delete();
                else if (row[cbFA_IDNO.SelectedValue].ToString().Trim() == "") row.Delete();
                else
                {
                    if (row.IsNull(cbEXP.SelectedValue)) row[cbEXP.SelectedValue] = 0;
                    else if (row[cbEXP.SelectedValue].ToString().Trim() == "") row[cbEXP.SelectedValue] = 0;
                    else
                    {
                        try
                        {
                            decimal d = Convert.ToDecimal(row[cbEXP.SelectedValue]);
                        }
                        catch
                        {
                            row.Delete();
                        }
                    }
                    if (row.IsNull(cbCOMP.SelectedValue)) row[cbCOMP.SelectedValue] = 0;
                    else if (row[cbCOMP.SelectedValue].ToString().Trim() == "") row[cbCOMP.SelectedValue] = 0;
                    else
                    {
                        try
                        {
                            decimal d = Convert.ToDecimal(row[cbCOMP.SelectedValue]);
                        }
                        catch
                        {
                            row.Delete();
                        }
                    }
                }
            }
            dtSource.AcceptChanges();

            int year = Convert.ToInt32(txtYYMM.Text.Substring(0, 4));
            int month = Convert.ToInt32(txtYYMM.Text.Substring(4, 2));

            DateTime adate = Convert.ToDateTime(year.ToString() + "/" + month + "/" + DateTime.DaysInMonth(year, month).ToString());

            var BASE = from c in db.BASE select c;
            //var FAMILY = from c in db.FAMILY select c;
            var FAMILY = from a in db.INSLAB where a.IN_DATE <= d2 && a.OUT_DATE >= d1 select a;

            BASE[] baseArray = BASE.ToArray();
            var familyArray = FAMILY.ToArray();

            //檢查 Excel 的資料，是否在 BASE 有對應的身份証號
            List<string> errData1 = new List<string>();
            foreach (DataRow row in dtSource.Rows)
            {
                if (!baseArray.Any(rowBase => rowBase.IDNO.Trim() == row[cbFA_IDNO.SelectedValue].ToString().Trim()))
                {
                    errData1.Add(row[cbFA_IDNO.SelectedValue].ToString().Trim());
                }
            }
            //在 BASE 裡對應不到的資料，去尋找在 FAMILY 是否有對應
            List<string> errData2 = new List<string>();
            foreach (var idno in errData1)
            {
                if (!familyArray.Any(rowFamily => rowFamily.FA_IDNO.Trim() == idno.Trim()))
                {
                    errData2.Add(idno.Trim());
                }
            }
            //檢查是否有對應不到的外籍員工
            List<string> errData3 = new List<string>();
            foreach (var idno in errData2)
            {
                if (!baseArray.Any(rowBase => rowBase.MATNO.Trim() == idno.Trim()))
                {
                    errData3.Add(idno.Trim());
                }
            }

            //檢查是否有對應不到的外籍員工
            List<string> errData4 = new List<string>();
            foreach (var idno in errData3)
            {
                if (!baseArray.Any(rowBase => rowBase.TAXNO.Trim() == idno.Trim()))
                {
                    errData4.Add(idno.Trim());
                }
            }

            string err = "";
            if (errData4.Count > 0)
            {
                foreach (var ss in errData4)
                {
                    if (err != "") err += ",";
                    err += ss;
                }
            }


            //左外部連結
            var leftOuterJoinQuery1 = from rowExcel in dtSource.AsEnumerable()
                                      join rowBase in baseArray on rowExcel[cbFA_IDNO.SelectedValue].ToString().Trim() equals rowBase.IDNO.Trim() into join1
                                      from join1_item in join1.DefaultIfEmpty(new BASE { NOBR = string.Empty })
                                      select new
                                      {
                                          NOBR = join1_item.NOBR.Trim(),
                                          FA_IDNO = rowExcel[cbFA_IDNO.SelectedValue].ToString().Trim(),
                                          EXP = Convert.ToDecimal(rowExcel[cbEXP.SelectedValue]),
                                          COMP = Convert.ToDecimal(rowExcel[cbCOMP.SelectedValue])
                                      };

            var leftOuterJoinQuery2 = from rowQuery1 in leftOuterJoinQuery1
                                      join rowFamily in familyArray on rowQuery1.FA_IDNO equals rowFamily.FA_IDNO.Trim() into join2
                                      from join2_item in join2.DefaultIfEmpty(new INSLAB { NOBR = string.Empty })
                                      select new
                                      {
                                          NOBR = (rowQuery1.NOBR.Trim().Length > 0) ? rowQuery1.NOBR.Trim() : join2_item.NOBR.Trim(),
                                          FA_IDNO = rowQuery1.FA_IDNO.Trim(),
                                          EXP = rowQuery1.EXP,
                                          COMP = rowQuery1.COMP
                                      };

            var leftOuterJoinQuery3 = from rowQuery2 in leftOuterJoinQuery2
                                      join rowBase in baseArray on rowQuery2.FA_IDNO equals rowBase.MATNO.Trim() into join2
                                      from join2_item in join2.DefaultIfEmpty(new BASE { NOBR = string.Empty })
                                      select new
                                      {
                                          NOBR = (rowQuery2.NOBR.Trim().Length > 0) ? rowQuery2.NOBR.Trim() : join2_item.NOBR.Trim(),
                                          FA_IDNO = rowQuery2.FA_IDNO.Trim(),
                                          EXP = rowQuery2.EXP,
                                          COMP = rowQuery2.COMP
                                      };
            var leftOuterJoinQuery4 = from rowQuery3 in leftOuterJoinQuery3
                                      join rowBase in baseArray on rowQuery3.FA_IDNO equals rowBase.TAXNO.Trim() into join3
                                      from join3_item in join3.DefaultIfEmpty(new BASE { NOBR = string.Empty })
                                      select new
                                      {
                                          NOBR = (rowQuery3.NOBR.Trim().Length > 0) ? rowQuery3.NOBR.Trim() : join3_item.NOBR.Trim(),
                                          FA_IDNO = rowQuery3.FA_IDNO.Trim(),
                                          EXP = rowQuery3.EXP,
                                          COMP = rowQuery3.COMP
                                      };

            var GroupByQuery = from row in leftOuterJoinQuery4
                               group row by new { NOBR = row.NOBR, FA_IDNO = row.FA_IDNO, EXP = row.EXP, COMP = row.COMP } into G
                               select new
                               {
                                   NOBR = G.Key.NOBR,
                                   FA_IDNO = G.Key.FA_IDNO,
                                   EXP = G.Key.EXP,
                                   COMP = G.Key.COMP
                               };

            foreach (var row in GroupByQuery)
            {
                if (errData4.Contains(row.FA_IDNO)) continue;

                INPOLAB inpolab = new INPOLAB();
                inpolab.YYMM = txtYYMM.Text;
                inpolab.NOBR = row.NOBR;
                inpolab.FA_IDNO = row.FA_IDNO;
                inpolab.EXP = row.EXP;
                inpolab.COMP = row.COMP;
                inpolab.ADATE = DateTime.Now.Date;
                inpolab.DAYS = 0;
                inpolab.INSCD = 0;
                inpolab.INSUR_TYPE = cbTYPE.SelectedValue;
                inpolab.RATE_CODE = "";
                inpolab.SALADR = MainForm.WORKADR;
                inpolab.KEY_DATE = DateTime.Now;
                inpolab.KEY_MAN = MainForm.USER_NAME;

                var check = from a in explabSQL where a.NOBR == row.NOBR select a;
                if (!check.Any())//如果當月明細沒有該員工，就找有相同身分證號的人
                {
                    var find = from a in explabSQL where a.IDNO == row.FA_IDNO select a;
                    if (find.Any())//如果有對應到身分證號，就置換工號
                        inpolab.NOBR = find.First().NOBR;
                    else//對應不到員工的身分證號，再試著對應眷屬
                    {
                        var findFA = from a in FAexplabSQL where a.FA_IDNO == row.FA_IDNO select a;
                        if (findFA.Any())
                            inpolab.NOBR = findFA.First().NOBR;
                    }
                }
                var check_data = from c in db.INPOLAB
                                 where c.NOBR.Trim() == inpolab.NOBR.Trim() &&
                                 c.FA_IDNO.Trim() == inpolab.FA_IDNO.Trim() &&
                                 c.EXP == inpolab.EXP && c.YYMM == txtYYMM.Text && c.INSUR_TYPE == cbTYPE.SelectedValue
                                 //&& db.GetFilterByNobr(c.NOBR, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value
                                 && (from bts in db.BASETTS
                                     where bts.NOBR == c.NOBR
                                     && DateTime.Now.Date >= bts.ADATE && DateTime.Now.Date <= bts.DDATE
                                     && (from urdg in db.UserReadDataGroupList(MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN) select urdg.DATAGROUP).Contains(bts.SALADR)
                                     select 1).Any()
                                 select c;
                if (check_data.Count() > 0)
                    continue;

                db.INPOLAB.InsertOnSubmit(inpolab);
                db.SubmitChanges();
            }
            db.SubmitChanges();

            this.Enabled = true;

            if (err == "")
            {
                MessageBox.Show(Resources.All.SaveComplete, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.None);
            }
            else
            {
                DataTable dtOutput = dtSource.Clone();
                foreach (DataRow row in dtSource.Rows)
                {
                    if (errData4.Contains(row[cbFA_IDNO.SelectedValue].ToString().Trim()))
                    {
                        dtOutput.ImportRow(row);
                    }
                }

                JBModule.Data.CNPOI.RenderDataTableToExcel(dtOutput, "C:\\TEMP\\勞健保匯入對應不到的工號.xls");
                MessageBox.Show(Resources.Ins.Import_DataErr + "請參考" + "C:\\TEMP\\勞健保匯入對應不到的工號.xls", Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.None);
            }

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
