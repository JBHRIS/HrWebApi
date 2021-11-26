using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using JBHR.Sal.Core;
namespace JBHR.Sal
{
    public partial class FRM4K : JBControls.JBForm
    {
        public FRM4K()
        {
            InitializeComponent();
        }
        SalaryMDDataContext smd = new SalaryMDDataContext();
        CheckControl cc;//必要欄位檢查
        private void FRM4K_Load(object sender, EventArgs e)
        {
            // TODO: 這行程式碼會將資料載入 'salaryDS.SALENRICH' 資料表。您可以視需要進行移動或移除。
            this.sALENRICHTableAdapter.Fill(this.salaryDS.SALENRICH);
            this.fAMILYTableAdapter.Fill(this.extDS.FAMILY);
            //this.sALCODETableAdapter1.Fill(this.extDS.SALCODE);
            cc = new CheckControl();//必要欄位檢查
            cc.AddControl(ptxSalcode);//必要欄位檢查
            this.sALCODETableAdapter.Fill(this.salaryDS.SALCODE, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN);
            SystemFunction.SetComboBoxItems(ptxSalcode, CodeFunction.GetSalCode(), true, false, true);
            SystemFunction.SetComboBoxItems(cbFA_IDNO, CodeFunction.GetFA_IDNO(""), true, false, true);
            ptxSalcode.Enabled = false;
            this.sALENRICHTableAdapter.FillByInit(this.salaryDS.SALENRICH );

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

            fullDataCtrl1.DataAdapter = this.sALENRICHTableAdapter ;
            fullDataCtrl1.Init_Ctrls();
        }
        private void fullDataCtrl1_AfterAdd(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            ptxNobr.Focus();
            txtSeq.Text = "2";
            btnChange.Enabled = false;
            btnImport.Enabled = false;
        }
        private void fullDataCtrl1_BeforeDel(object sender, JBControls.FullDataCtrl.BeforeEventArgs e)
        {
            if (!Sal.Function.CanModify(ptxNobr.Text))
            {
                e.Cancel = true;
                MessageBox.Show(Resources.Sal.NonAccessableRule, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void fullDataCtrl1_AfterDel(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            if (!e.Error)
            {
                CDataLog.Save(this.Name, MainForm.USER_ID, DateTime.Now, fullDataCtrl1.BackupDataTable);
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
                e.Values["kEy_MaN"] = MainForm.USER_NAME;
                e.Values["KeY_dAtE"] = DateTime.Now;
                e.Values["amt"] = JBModule.Data.CEncrypt.Number(Convert.ToDecimal(e.Values["amt"]));
                e.Values["import"] = false;//只要透過介面編輯過，就當成手動資料
            }
        }
        private void fullDataCtrl1_AfterSave(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            e.Values["amt"] = JBModule.Data.CDecryp.Number(Convert.ToDecimal(e.Values["amt"]));

            btnChange.Enabled = true;
            btnImport.Enabled = true;

            //cbFA_IDNO.DataSource = null;
            //cbFA_IDNO.Items.Clear();
            //SystemFunction.SetComboBoxItems(cbFA_IDNO, CodeFunction.GetFA_IDNO(e.Values["nobr"].ToString()), true);

            if (!e.Error)//發生錯誤就略過
                this.salaryDS.SALBASD.AcceptChanges();
        }
        void fdc_AfterShow(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            GridBind();
        }
        private void fullDataCtrl1_AfterExport(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            DataView dv = ((sender as JBControls.FullDataCtrl).DataSource.DataSource as DataSet).Tables[(sender as JBControls.FullDataCtrl).DataSource.DataMember].DefaultView;
            dv.RowFilter = (sender as JBControls.FullDataCtrl).DataSource.Filter;

            JBModule.Data.CNPOI.RenderDataViewToExcel(dv, "C:\\TEMP\\" + this.Name + ".xls");
            System.Diagnostics.Process.Start("C:\\TEMP\\" + this.Name + ".xls");
        }
        private void fullDataCtrl1_AfterQuery(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            GridBind();
        }
        void GridBind()
        {
            foreach (var itm in this.salaryDS.SALENRICH ) itm.AMT = JBModule.Data.CDecryp.Number(itm.AMT);
            this.salaryDS.SALENRICH.AcceptChanges();
        }

        private void ptxNobr_QueryCompleted(object sender, JBControls.PopupTextBox.QueryCompletedArgs e)
        {
            //if (e.HasData) txtYymm.Focus();
        }
        private void ptxSalcode_QueryCompleted(object sender, JBControls.PopupTextBox.QueryCompletedArgs e)
        {
            //if (e.HasData) txtAmt.Focus();
        }
        private void txtSeq_Validated(object sender, EventArgs e)
        {
            ptxSalcode.Focus();
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            //FRM4KIi frm = new FRM4KIi();
            JBControls.U_IMPORT frm = new JBControls.U_IMPORT();
            frm.Allow_Repeat_Delete = true;
            frm.Allow_Repeat_Ignore = true;
            frm.Allow_Repeat_Override = true;

            frm.DataTransfer = new ImportTransferToENRICH();
            JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
            frm.DataTransfer.CheckData = new Dictionary<string, List<JBControls.CheckImportData>>();
            frm.DataTransfer.CheckData.Add("眷屬身號", db.FAMILY.Select(p => new JBControls.CheckImportData { DisplayCode = p.FA_IDNO, RealCode = p.FA_IDNO, DisplayName = p.FA_NAME }).ToList());
            frm.DataTransfer.CheckData.Add("薪資代碼", salaryDS.SALCODE.Select(p => new JBControls.CheckImportData { DisplayCode = p.SAL_CODE_DISP, RealCode = p.SAL_CODE, DisplayName = p.SAL_NAME }).ToList());
            frm.DataTransfer.CheckData.Add("員工編號", this.salaryDS.BASE.Select(p => new JBControls.CheckImportData { DisplayCode = p.NOBR, RealCode = p.NOBR, DisplayName = p.NAME_C }).ToList());
            frm.DataTransfer.ColumnList = new Dictionary<string, Type>();
            frm.DataTransfer.ColumnList.Add("計薪年月", typeof(string));
            frm.DataTransfer.ColumnList.Add("期別", typeof(string));
            frm.DataTransfer.ColumnList.Add("員工編號", typeof(string));
            frm.DataTransfer.ColumnList.Add("員工姓名", typeof(string));
            frm.DataTransfer.ColumnList.Add("眷屬身號", typeof(string));
            frm.DataTransfer.ColumnList.Add("眷屬姓名", typeof(string));
            //frm.DataTransfer.ColumnList.Add("異動日期", typeof(DateTime));
            frm.DataTransfer.ColumnList.Add("薪資代碼", typeof(string));
            frm.DataTransfer.ColumnList.Add("薪資名稱", typeof(string));
            frm.DataTransfer.ColumnList.Add("異動前金額", typeof(decimal));
            frm.DataTransfer.ColumnList.Add("異動後金額", typeof(decimal));
            frm.DataTransfer.ColumnList.Add("差異金額", typeof(decimal));
            frm.DataTransfer.ColumnList.Add("備註", typeof(string));
            frm.DataTransfer.ColumnList.Add("警告", typeof(string));
            frm.DataTransfer.ColumnList.Add("錯誤註記", typeof(string));

            frm.DataTransfer.UnMustColumnList = new List<string>();
            frm.DataTransfer.UnMustColumnList.Add("眷屬身號");

            frm.ShowDialog();
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(Resources.Sal.DataChangeConfirm, Resources.All.DialogTitle, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                try
                {
                    SalaryDate sd = new SalaryDate(txtYM.Text);
                }
                catch
                {
                    MessageBox.Show(Resources.Sal.YymmFormatInvalidated, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }
                SalaryMDDataContext db = new SalaryMDDataContext();
                var sql = from a in db.SALENRICH
                          join b in db.BASE on a.NOBR equals b.NOBR
                          join c in db.SALCODE on a.SAL_CODE equals c.SAL_CODE
                          where a.YYMM == txtYM.Text && a.SEQ == txtSQ.Text
                          select new { a, b.NAME_C, c.SAL_NAME };
                SalaryDS.SALENRICHDataTable  dtCompare = new SalaryDS.SALENRICHDataTable();
                dtCompare.FillData(db.GetCommand(sql));
                foreach (var itm in this.salaryDS.SALENRICH)
                {
                    try
                    {
                        if (dtCompare.Where(p => p.NOBR == itm.NOBR && p.YYMM == txtYM.Text.Trim() && p.SEQ == txtSQ.Text && p.SAL_CODE == itm.SAL_CODE).Any())// txtYM.Text, txtSQ.Text, itm.SAL_CODE//存在相同主鍵的資料
                        {
                            if (MessageBox.Show(Resources.Sal.UpdateDataExists + "," + Resources.Sal.OkToContinue + Environment.NewLine + itm.NOBR + " " + itm.SAL_CODE, Resources.All.DialogTitle, MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk) == DialogResult.OK)
                                continue;//確定的話就略過，取消的話就終止
                            return;
                        }
                        itm.AMT = JBModule.Data.CEncrypt.Number(itm.AMT);//先加密，以保持寫入值正確
                        itm.YYMM = txtYM.Text;
                        itm.SEQ = txtSQ.Text;
                    }
                    catch (ConstraintException cEx)//如果是Key重複
                    {
                        this.salaryDS.SALENRICH .RejectChanges();
                        MessageBox.Show(Resources.Sal.ChangeConflict + "\n" + label1.Text + itm.NOBR + label2.Text + itm.YYMM + " " + itm.SEQ + label3.Text + itm.SAL_CODE, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        return;
                    }
                }

                this.sALENRICHTableAdapter.Update(this.salaryDS.SALENRICH);
                GridBind();//再加密
                MessageBox.Show(Resources.Sal.StatusFinish, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void fullDataCtrl1_AfterEdit(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            cbFA_IDNO.DataSource = null;
            cbFA_IDNO.Items.Clear();
            SystemFunction.SetComboBoxItems(cbFA_IDNO, CodeFunction.GetFA_IDNO(ptxNobr.Text), true);
            cbFA_IDNO.Enabled = true;

            btnChange.Enabled = false;
            btnImport.Enabled = false;
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            lblSum.Text = Sal.Function.ColumnsSum(dataGridView1, e.ColumnIndex);
        }

        private void ptxNobr_Validated(object sender, EventArgs e)
        {
            cbFA_IDNO.DataSource = null;
            cbFA_IDNO.Items.Clear();
            SystemFunction.SetComboBoxItems(cbFA_IDNO, CodeFunction.GetFA_IDNO(ptxNobr.Text), true);
            cbFA_IDNO.Enabled = true;
        }

        private void fullDataCtrl1_AfterCancel(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            cbFA_IDNO.DataSource = null;
            cbFA_IDNO.Items.Clear();

            btnChange.Enabled = true;
            btnImport.Enabled = true;
            //SystemFunction.SetComboBoxItems(cbFA_IDNO, CodeFunction.GetFA_IDNO(e.Values["nobr"].ToString()), true);
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            SystemFunction.SetComboBoxItems(cbFA_IDNO, CodeFunction.GetFA_IDNO(ptxNobr.Text), true);
        }
    }
}
