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
    public partial class FRM46EI : JBControls.JBForm
    {
        public FRM46EI()
        {
            InitializeComponent();
        }
        DataTable dt;
        SalaryDS.SALBASD_TMPDataTable dtImport;
        private void IP_FRM4L_Load(object sender, EventArgs e)
        {
            this.iMPORT_TYPETableAdapter.Fill(this.viewDS.IMPORT_TYPE);
            this.sALCODETableAdapter.Fill(this.salaryDS.SALCODE);
            txtAdate.Text = Sal.Core.SalaryDate.DateString();
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
                    dt = JBModule.Data.CNPOI.RenderDataTableFromExcel(path, 0, 0);
                }
                catch
                {
                    MessageBox.Show(Resources.Sal.ExcelIOError, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }
                cbNobr.Items.Clear();
                cbAmt.Items.Clear();
                cbMemo.Items.Clear();
                foreach (DataColumn col in dt.Columns)
                {
                    cbNobr.Items.Add(col.ColumnName);
                    cbAmt.Items.Add(col.ColumnName);
                    cbMemo.Items.Add(col.ColumnName);
                }

                textBox1.Text = path;
                txtAdate.Focus();
            }
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            if (dt != null)
            {
                setTable();
                PreviewForm vw = new PreviewForm();
                vw.DataTable = dtImport;
                vw.Width = 800;
                vw.ShowDialog();
                //Sal.ViewDSTableAdapters.ENRICHTableAdapter ad = new JBHR.Sal.ViewDSTableAdapters.ENRICHTableAdapter();

            }

        }
        void setTable()
        {
            dtImport = new SalaryDS.SALBASD_TMPDataTable();
            SalaryMDDataContext smd = new SalaryMDDataContext();

            foreach (DataRow r in dt.Rows)
            {
                string nobr, memo;
                decimal amt = 0;
                try
                {
                    if (dt.Columns.Contains(cbNobr.Text)) nobr = r[cbNobr.Text].ToString();
                    else nobr = cbNobr.Text;

                    if (dt.Columns.Contains(cbMemo.Text)) memo = r[cbMemo.Text].ToString();
                    else memo = cbMemo.Text;

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

                var rowImp = dtImport.NewSALBASD_TMPRow();
                rowImp.ADATE = Convert.ToDateTime(txtAdate.Text);
                rowImp.NOBR = nobr;
                rowImp.AMT = amt;
                rowImp.KEY_DATE = DateTime.Now;
                rowImp.KEY_MAN = MainForm.USER_NAME;
                rowImp.MEMO = memo;
                rowImp.SAL_CODE = ptxSalcode.Text;


                var name_c = from b in smd.BASE where b.NOBR == rowImp.NOBR select b;
                var name = name_c.FirstOrDefault();//判斷有無此員工
                if (name == null)
                {
                    MessageBox.Show(Resources.Sal.DataNoFound + "(nobr:" + rowImp.NOBR + ")", Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }
                //rowImp.NAME_C = name.NAME_C;
                //rowImp.SAL_NAME = ptxSalcode.LabelText;
                dtImport.AddSALBASD_TMPRow(rowImp);
            }
        }
        private void btnImport_Click(object sender, EventArgs e)
        {
            if (dt != null)
            {
                SalaryMDDataContext smd = new SalaryMDDataContext();
                //dtEnrich = new ViewDS.ENRICHDataTable();
                var data = new Sal.SalaryDS.SALBASD_TMPDataTable();
                var sql = from a in smd.SALBASD_TMP
                          join b in smd.BASE on a.NOBR equals b.NOBR
                          join c in smd.SALCODE on a.SAL_CODE equals c.SAL_CODE
                          where a.ADATE == Convert.ToDateTime(txtAdate.Text) && a.SAL_CODE == ptxSalcode.Text
                          select new { a, b.NAME_C, c.SAL_NAME };
                if (cbType.SelectedValue.ToString() == "1")
                {

                }
                else if (cbType.SelectedValue.ToString() == "2")//撈出既有的資料，以供修改內容
                {
                    data.FillData(smd.GetCommand(sql));
                }
                else if (cbType.SelectedValue.ToString() == "3")//撈出既有的資料，以供比對刪除
                {
                    data.FillData(smd.GetCommand(sql));
                }
                else if (cbType.SelectedValue.ToString() == "4")//撈出既有的資料，以供資料加總
                {
                    data.FillData(smd.GetCommand(sql));
                }
                else
                {
                    MessageBox.Show(Resources.Sal.msgChoiceImportType, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }


                foreach (DataRow r in dt.Rows)
                {
                    string nobr, memo;
                    decimal amt = 0;
                    try
                    {
                        if (dt.Columns.Contains(cbNobr.Text)) nobr = r[cbNobr.Text].ToString();
                        else nobr = cbNobr.Text;

                        if (dt.Columns.Contains(cbMemo.Text)) memo = r[cbMemo.Text].ToString();
                        else memo = cbMemo.Text;

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


                    SalaryDS.SALBASD_TMPRow rowI = null;
                    DateTime adate = Convert.ToDateTime(txtAdate.Text);
                    string salcode = ptxSalcode.Text;
                    bool isNew = false;
                    rowI = data.FindByNOBRADATESAL_CODE(nobr, adate, salcode);
                    if (cbType.SelectedValue.ToString() == "1")//如果有資料就保留(略過異動)
                    {

                        if (rowI == null)//如果資料不存在，就寫入0
                        {
                            rowI = data.NewSALBASD_TMPRow();
                            rowI.AMT = 10;
                            isNew = true;
                        }
                        else continue;
                    }
                    else if (cbType.SelectedValue.ToString() == "2")
                    {
                        if (rowI == null)//不管資料存不存在都補0
                        {
                            rowI = data.NewSALBASD_TMPRow();
                            isNew = true;
                        }
                        rowI.AMT = 10;
                    }
                    else if (cbType.SelectedValue.ToString() == "3")
                    {
                        if (rowI != null)//如果資料存在，就刪除
                        {
                            rowI.Delete();
                        }
                    }
                    else if (cbType.SelectedValue.ToString() == "4")
                    {
                        if (rowI == null)//如果資料不存在，就寫入0
                        {
                            rowI = data.NewSALBASD_TMPRow();
                            rowI.AMT = 10;
                            isNew = true;
                        }
                    }
                    else
                    {
                        MessageBox.Show(Resources.Sal.msgChoiceImportType, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        return;
                    }
                    if (cbType.SelectedValue.ToString() != "3")
                    {
                        rowI.ADATE = adate;
                        rowI.NOBR = nobr;
                        rowI.AMT = JBModule.Data.CEncrypt.Number(JBModule.Data.CDecryp.Number(rowI.AMT) + amt);
                        rowI.KEY_DATE = DateTime.Now;
                        rowI.KEY_MAN = MainForm.USER_NAME;
                        rowI.MEMO = memo;
                        rowI.SAL_CODE = ptxSalcode.Text;
                        //rowI.AMTB = 0;
                        //rowI.DDATE = new DateTime(9999, 12, 31);

                        var name_c = from b in smd.BASE where b.NOBR == rowI.NOBR select b;
                        var name = name_c.FirstOrDefault();
                        if (name == null)
                        {
                            MessageBox.Show(Resources.Sal.DataNoFound, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            return;
                        }
                        //rowI.NAME_C = name.NAME_C;
                        //rowI.SAL_NAME = ptxSalcode.LabelText;
                        if (isNew)
                            data.AddSALBASD_TMPRow(rowI);
                    }
                }
                SalaryDSTableAdapters.SALBASD_TMPTableAdapter ad = new SalaryDSTableAdapters.SALBASD_TMPTableAdapter();
                System.Data.SqlClient.SqlTransaction trans = null;
                try
                {
                    if (ad.Connection.State != ConnectionState.Open) ad.Connection.Open();
                    trans = ad.Connection.BeginTransaction();
                    ad.Transaction = trans;
                    ad.Update(data);
                    trans.Commit();
                }
                catch
                {
                    if (trans != null)
                        trans.Rollback();//回復
                }
                finally
                {
                    foreach (DataRow itm in dt.Rows)
                    {
                        string nobr;
                        if (dt.Columns.Contains(cbNobr.Text)) nobr = itm[cbNobr.Text].ToString();
                        else nobr = cbNobr.Text;

                        //ReSetSalbasdOfNobrSalcode(nobr, ptxSalcode.Text);
                    }
                    MessageBox.Show(Resources.Sal.StatusFinish, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
        }
        //void ReSetSalbasdOfNobrSalcode(string nobr, string salcode)
        //{
            //SalaryMDDataContext smd = new SalaryMDDataContext();
            //var salbasd_of_NobrSalcode = from salbasd_row in smd.SALBASD_TMP
            //                             where salbasd_row.NOBR.Trim().Equals(nobr) && salbasd_row.SAL_CODE.Trim().Equals(salcode)
            //                             orderby salbasd_row.ADATE descending
            //                             select salbasd_row;
            //DateTime dt = new DateTime(9999, 12, 31);
            //foreach (var itm in salbasd_of_NobrSalcode)
            //{
            //    //itm.DDATE = dt;
            //    dt = itm.ADATE.AddDays(-1);
            //}
            //smd.SubmitChanges();
        //}
    }

}