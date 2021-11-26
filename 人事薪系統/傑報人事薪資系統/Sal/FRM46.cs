using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Common;
using System.Data.SqlClient;

namespace JBHR.Sal
{
    public partial class FRM46 : JBControls.JBForm
    {
        SalaryMDDataContext smd = new SalaryMDDataContext();
        SalaryMDDataContext trans_smd;
        DbTransaction trans;
        bool isCancel;
        string del_nobr = "";
        string del_salcode = "";
        public FRM46()
        {
            InitializeComponent();
        }

        CheckControl cc;//必要欄位檢查
        SALBASD temp_sal = new SALBASD();
        private void FRM46_Load(object sender, EventArgs e)
        {
            cc = new CheckControl();//必要欄位檢查
            cc.AddControl(ptxSalcode);//必要欄位檢查

            SystemFunction.SetComboBoxItems(ptxSalcode, CodeFunction.GetBaseSalCode(), true, true, true, true);
            ptxSalcode.Enabled = false;
            this.sALCODETableAdapter.Fill(this.salaryDS.SALCODE, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN);
            this.sALBASDTableAdapter.FillByInit(this.salaryDS.SALBASD);

            BasDataClassesDataContext db = new BasDataClassesDataContext();
            var u_prg = (from c in db.U_PRGID where c.USER_ID.Trim() == MainForm.USER_ID && c.PROG.Trim().ToLower() == this.Name.ToLower() select c).FirstOrDefault();
            if (u_prg != null)
            {
                fullDataCtrl1.bnAddEnable = u_prg.ADD_;
                fullDataCtrl1.bnEditEnable = u_prg.EDIT;
                fullDataCtrl1.bnDelEnable = u_prg.DELE;
                fullDataCtrl1.bnExportEnable = u_prg.PRINT_;
            }

            Function.SetAvaliableBase(this.salaryDS.BASE);
            fullDataCtrl1.WhereCmd = Sal.Function.GetFilterCmd(this.Name);

            fullDataCtrl1.DataAdapter = this.sALBASDTableAdapter;
            fullDataCtrl1.Init_Ctrls();

        }

        private void fullDataCtrl1_AfterDel(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            if (!e.Error)
            {
                CDataLog.Save(this.Name, MainForm.USER_ID, DateTime.Now, fullDataCtrl1.BackupDataTable);
                isCancel = false;
                smd = new SalaryMDDataContext();
                ReSetSalbasdOfNobrSalcode(del_nobr, del_salcode, smd);
                if (isCancel == true)
                {
                    e.Error = true;
                    return;
                }
            }
        }

        private void fullDataCtrl1_BeforeDel(object sender, JBControls.FullDataCtrl.BeforeEventArgs e)
        {
            if (!Sal.Function.CanModify(ptxNobr.Text))
            {
                e.Cancel = true;
                MessageBox.Show(Resources.Sal.NonAccessableRule, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                del_nobr = e.Values["nobr"].ToString();
                del_salcode = e.Values["sal_code"].ToString();
                this.salaryDS.SALBASD.AcceptChanges();
            }
        }

        private void fullDataCtrl1_AfterAdd(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            ptxNobr.Focus();

            txtAdate.Text = Sal.Core.SalaryDate.DateString();
            txtDdate.Text = Sal.Core.SalaryDate.DateString(new DateTime(9999, 12, 31));
            if (isCancel) recovery_sal(e);//還原輸入的資料
        }

        private void fullDataCtrl1_AfterEdit(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            txtAmt.Focus();
            ptxNobr.Enabled = false;
            ptxSalcode.Enabled = false;
        }

        private void fullDataCtrl1_AfterQuery(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            GridBind();
        }

        private void fullDataCtrl1_AfterSave(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            if (e.Error)
            {
                if (trans.Connection.State == ConnectionState.Open) trans.Rollback();
                e.Values["amt"] = JBModule.Data.CDecryp.Number(Convert.ToDecimal(e.Values["amt"]));
                e.Error = true;
                return;
            }
            if (!e.Error)
            {
                var conn = sALBASDTableAdapter.Connection;
                using (trans_smd = new SalaryMDDataContext(conn))
                {
                    trans_smd.Transaction = trans;
                    try
                    {

                        isCancel = false;

                        ReSetSalbasdOfNobrSalcode(e.Values["nobr"].ToString(), e.Values["sal_code"].ToString(), trans_smd);

                        if (isCancel == true)
                        {
                            e.Error = true;
                            return;
                        }
                        else e.Values["amt"] = JBModule.Data.CDecryp.Number(Convert.ToDecimal(e.Values["amt"]));
                        //throw new System.DivideByZeroException();
                        this.salaryDS.SALBASD.AcceptChanges();
                        if (trans.Connection.State == ConnectionState.Open) trans.Commit();
                        CDataLog.Save(this.Name, MainForm.USER_ID, DateTime.Now, fullDataCtrl1.BackupDataTable);
                    }
                    catch (Exception ex)
                    {
                        if (trans.Connection.State == ConnectionState.Open) trans.Rollback();
                        dataGridView1.Rows.Remove(dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex]);
                        MessageBox.Show("儲存時，出現以下錯誤：\n" + ex.Message + "\n\n請重新再操作一次。", Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        isCancel = true;
                        e.Error = true;
                        return;
                    }

                }
            }
        }

        private void fullDataCtrl1_BeforeSave(object sender, JBControls.FullDataCtrl.BeforeEventArgs e)
        {
            var ctrl = cc.CheckRequiredFields();//必要欄位檢查
            if (ctrl != null)//必要欄位檢查
            {
                MessageBox.Show("必要欄位未輸入", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ctrl.Focus();
                e.Cancel = true;
                return;
            }

            if (!Sal.Function.CanModify(ptxNobr.Text))
            {
                e.Cancel = true;
                MessageBox.Show(Resources.Sal.NonAccessableRule, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            if (!e.Cancel)
            {
                var conn = sALBASDTableAdapter.Connection;
                using (trans_smd = new SalaryMDDataContext(conn))
                {
                    try
                    {
                        if (trans_smd.Connection.State != ConnectionState.Open) trans_smd.Connection.Open();
                        trans = trans_smd.Connection.BeginTransaction();
                        sALBASDTableAdapter.Transaction = trans as SqlTransaction;
                        trans_smd.Transaction = trans;

                        backup_sal(e);//備份輸入的資料

                        e.Values["kEy_MaN"] = MainForm.USER_NAME;
                        e.Values["KeY_dAtE"] = DateTime.Now;
                        e.Values["amt"] = JBModule.Data.CEncrypt.Number(Convert.ToDecimal(e.Values["amt"]));



                        //throw new System.DivideByZeroException();
                    }

                    catch (Exception ex)
                    {
                        if (trans.Connection.State == ConnectionState.Open) trans.Rollback();
                        MessageBox.Show("儲存時，出現以下錯誤：\n" + ex.Message + "\n\n請重新再操作一次。", Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        e.Cancel = true;
                        return;
                    }
                }
            }
        }

        private void fullDataCtrl1_AfterExport(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            DataView dv = ((sender as JBControls.FullDataCtrl).DataSource.DataSource as DataSet).Tables[(sender as JBControls.FullDataCtrl).DataSource.DataMember].DefaultView;
            dv.RowFilter = (sender as JBControls.FullDataCtrl).DataSource.Filter;

            JBModule.Data.CNPOI.RenderDataViewToExcel(dv, "C:\\TEMP\\" + this.Name + ".xls");
            System.Diagnostics.Process.Start("C:\\TEMP\\" + this.Name + ".xls");
        }


        private void ptxNobr_QueryCompleted(object sender, JBControls.PopupTextBox.QueryCompletedArgs e)
        {
            //if (e.HasData) txtAdate.Focus();
        }
        private void ptxSalcode_QueryCompleted(object sender, JBControls.PopupTextBox.QueryCompletedArgs e)
        {

        }
        void ReSetSalbasdOfNobrSalcode(string nobr, string salcode, SalaryMDDataContext ddb)
        {
            try
            {
                var salbasd_of_NobrSalcode = from salbasd_row in ddb.SALBASD
                                             where salbasd_row.NOBR.Trim().Equals(nobr) && salbasd_row.SAL_CODE.Trim().Equals(salcode)
                                             orderby salbasd_row.ADATE descending
                                             select salbasd_row;
                DateTime dt = new DateTime(9999, 12, 31);
                foreach (var itm in salbasd_of_NobrSalcode)
                {
                    var dataRow = salaryDS.SALBASD.FindByADATENOBRSAL_CODE(itm.ADATE, itm.NOBR, itm.SAL_CODE);
                    itm.DDATE = dt;
                    if (dataRow != null) dataRow.DDATE = dt;
                    dt = itm.ADATE.AddDays(-1);
                }
                ddb.SubmitChanges();
                //throw new System.DivideByZeroException();
            }
            catch (Exception ex)
            {
                if (ddb == trans_smd)
                {
                    if (trans.Connection.State == ConnectionState.Open) trans.Rollback();
                    dataGridView1.Rows.Remove(dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex]);
                }
                MessageBox.Show("儲存時，出現以下錯誤：\n" + ex.Message + "\n\n請重新再操作一次。", Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                isCancel = true;
                return;

            }
        }
        void GridBind()
        {
            foreach (var itm in this.salaryDS.SALBASD) itm.AMT = JBModule.Data.CDecryp.Number(itm.AMT);
            this.salaryDS.SALBASD.AcceptChanges();
        }

        private void fullDataCtrl1_AfterShow(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            GridBind();
        }

        void backup_sal(JBControls.FullDataCtrl.BeforeEventArgs e)
        {
            temp_sal.NOBR = e.Values["nobr"].ToString();
            temp_sal.ADATE = Convert.ToDateTime(e.Values["adate"]);
            temp_sal.SAL_CODE = e.Values["sal_code"].ToString();
            temp_sal.AMT = Convert.ToDecimal(e.Values["amt"]);
            temp_sal.MENO = e.Values["meno"].ToString();
            temp_sal.DDATE = Convert.ToDateTime(e.Values["ddate"]);
        }
        void recovery_sal(JBControls.FullDataCtrl.AfterEventArgs e)
        {
            ptxNobr.Text = temp_sal.NOBR;
            txtAdate.Text = temp_sal.ADATE.ToString();
            ptxSalcode.SelectedValue = temp_sal.SAL_CODE;
            txtAmt.Text = temp_sal.AMT.ToString();
            txtMemo.Text = temp_sal.MENO;
            txtDdate.Text = temp_sal.DDATE.ToString();
        }
        private void btnImport_Click(object sender, EventArgs e)
        {
            JBControls.U_IMPORT frm = new JBControls.U_IMPORT();
            frm.Allow_Repeat_Delete = true;
            frm.Allow_Repeat_Ignore = true;
            frm.Allow_Repeat_Override = true;

            frm.FieldForm = new FRM46I();
            frm.DataTransfer = new ImportTransferToSalbasd();

            frm.DataTransfer.CheckData = new Dictionary<string, List<JBControls.CheckImportData>>();
            frm.DataTransfer.CheckData.Add("薪資代碼", salaryDS.SALCODE.Where(p => new string[] { "A", "G" }.Contains(p.SAL_ATTR)).Select(p => new JBControls.CheckImportData { DisplayCode = p.SAL_CODE_DISP, RealCode = p.SAL_CODE, DisplayName = p.SAL_NAME }).ToList());
            frm.DataTransfer.CheckData.Add("員工編號", this.salaryDS.BASE.Select(p => new JBControls.CheckImportData { DisplayCode = p.NOBR, RealCode = p.NOBR, DisplayName = p.NAME_C }).ToList());
            frm.DataTransfer.ColumnList = new Dictionary<string, Type>();
            frm.DataTransfer.ColumnList.Add("員工編號", typeof(string));
            frm.DataTransfer.ColumnList.Add("員工姓名", typeof(string));
            frm.DataTransfer.ColumnList.Add("異動日期", typeof(DateTime));
            frm.DataTransfer.ColumnList.Add("薪資代碼", typeof(string));
            frm.DataTransfer.ColumnList.Add("薪資名稱", typeof(string));
            frm.DataTransfer.ColumnList.Add("異動前金額", typeof(decimal));
            frm.DataTransfer.ColumnList.Add("異動後金額", typeof(decimal));
            frm.DataTransfer.ColumnList.Add("差異金額", typeof(decimal));
            frm.DataTransfer.ColumnList.Add("備註", typeof(string));
            frm.DataTransfer.ColumnList.Add("錯誤註記", typeof(string));

            frm.ShowDialog();
        }
    }
}
