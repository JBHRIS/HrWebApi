using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace JBHR.Sal
{
    public partial class FRM46A : JBControls.JBForm
    {
        SalaryMDDataContext smd = new SalaryMDDataContext();
        string del_nobr = "";
        string del_salcode = "";
        public FRM46A()
        {
            InitializeComponent();
        }

        CheckControl cc;//必要欄位檢查
        private void FRM46A_Load(object sender, EventArgs e)
        {
            cc = new CheckControl();//必要欄位檢查
            cc.AddControl(comboSalcode);//必要欄位檢查
            SystemFunction.SetComboBoxItems(comboSalcode, CodeFunction.GetSalCode(), false, false, true);
            this.sALCODETableAdapter.Fill(this.salaryDS.SALCODE, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN);
            this.sALBASTDTableAdapter.FillByInit(this.salaryDS.SALBASTD);
            Function.SetAvaliableBase(this.salaryDS.BASE);//設定            

            BasDataClassesDataContext db = new BasDataClassesDataContext();
            var u_prg = (from c in db.U_PRGID where c.USER_ID.Trim() == MainForm.USER_ID && c.PROG.Trim().ToLower() == this.Name.ToLower() select c).FirstOrDefault();
            if (u_prg != null)
            {
                fullDataCtrl1.bnAddEnable = u_prg.ADD_;
                fullDataCtrl1.bnEditEnable = u_prg.EDIT;
                fullDataCtrl1.bnDelEnable = u_prg.DELE;
                fullDataCtrl1.bnExportEnable = u_prg.PRINT_;
            }
            fullDataCtrl1.WhereCmd = Sal.Function.GetFilterCmd(this.Name);

            fullDataCtrl1.DataAdapter = sALBASTDTableAdapter;
            fullDataCtrl1.Init_Ctrls();
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
                //if (e.Values.DataView.Count != 1)
                //    this.salaryDS.SALBASTD.AcceptChanges();
                e.Values["kEy_MaN"] = MainForm.USER_NAME;
                e.Values["KeY_dAtE"] = DateTime.Now;
                e.Values["amt"] = JBModule.Data.CEncrypt.Number(Convert.ToDecimal(txtAmt.Text));
                //string value = e.Values["amt"].ToString();
            }
        }
        private void fullDataCtrl1_AfterSave(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            if (!e.Error)//發生錯誤就略過
            {
                ReSetSalbastdOfNobrSalcode(ptxNobr.Text, comboSalcode.SelectedValue.ToString());
                CDataLog.Save(this.Name, MainForm.USER_ID, DateTime.Now, fullDataCtrl1.BackupDataTable);
                e.Values["amt"] = JBModule.Data.CDecryp.Number(Convert.ToDecimal(e.Values["amt"]));
            }
        }
        /// <summary>
        /// 新增後
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fullDataCtrl1_AfterAdd(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            ptxNobr.Focus();
            txtAdate.Text = Sal.Core.SalaryDate.DateString();
            txtDdate.Text = Sal.Core.SalaryDate.DateString(new DateTime(9999, 12, 31));
        }
        private void fullDataCtrl1_AfterShow(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            GridBind();
        }
        /// <summary>
        /// 匯出後
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fullDataCtrl1_AfterExport(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            DataView dv = ((sender as JBControls.FullDataCtrl).DataSource.DataSource as DataSet).Tables[(sender as JBControls.FullDataCtrl).DataSource.DataMember].DefaultView;
            dv.RowFilter = (sender as JBControls.FullDataCtrl).DataSource.Filter;

            JBModule.Data.CNPOI.RenderDataViewToExcel(dv, "C:\\TEMP\\" + this.Name + ".xls");
            System.Diagnostics.Process.Start("C:\\TEMP\\" + this.Name + ".xls");
        }

        private void fullDataCtrl1_AfterDel(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            if (!e.Error)
            {
                CDataLog.Save(this.Name, MainForm.USER_ID, DateTime.Now, fullDataCtrl1.BackupDataTable);
                ReSetSalbastdOfNobrSalcode(del_nobr, del_salcode);
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
                this.salaryDS.SALBASTD.AcceptChanges();
                del_nobr = e.Values["nobr"].ToString();
                del_salcode = e.Values["sal_code"].ToString();
            }
        }
        private void popupTextBox1_QueryCompleted(object sender, JBControls.PopupTextBox.QueryCompletedArgs e)
        {
            //if (e.HasData) txtAdate.Focus();
        }

        private void txtDdate_Validated(object sender, EventArgs e)
        {
            //Button btn = Function.GetFullDataControlButton(fullDataCtrl1, "儲存");
            //if (btn != null) btn.Focus();
        }

        private void ComboSalcode_QueryCompleted(object sender, JBControls.PopupTextBox.QueryCompletedArgs e)
        {
            //if (e.HasData) txtAmt.Focus();
        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void txtAdate_Validated(object sender, EventArgs e)
        {
            var basetts = from basetts_row in smd.BASETTS where basetts_row.NOBR.Equals(ptxNobr.Text.Trim()) select basetts_row;
            var row = basetts.FirstOrDefault();
            if (row != null)
            {
                if (row.INDT > Convert.ToDateTime(txtAdate.Text)) MessageBox.Show(Resources.Sal.OutOfInDate, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }
        /// <summary>
        /// 解密
        /// </summary>
        void GridBind()
        {
            foreach (var itm in this.salaryDS.SALBASTD) itm.AMT = JBModule.Data.CDecryp.Number(itm.AMT);
            this.salaryDS.SALBASTD.AcceptChanges();
        }

        /// <summary>
        /// 重新設定生失效日
        /// </summary>
        /// <param name="nobr"></param>
        /// <param name="salcode"></param>
        void ReSetSalbastdOfNobrSalcode(string nobr, string salcode)
        {
            var salbastd_of_NobrSalcode = from salbastd_row in smd.SALBASTD
                                          where salbastd_row.NOBR.Equals(nobr) && salbastd_row.SAL_CODE.Equals(salcode)
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


        private void fullDataCtrl1_AfterQuery(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            GridBind();
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            JBControls.U_IMPORT frm = new JBControls.U_IMPORT();
            frm.Allow_Repeat_Delete = true;
            frm.Allow_Repeat_Ignore = true;
            frm.Allow_Repeat_Override = true;

            frm.FieldForm = new FRM46A_Import();
            frm.DataTransfer = new ImportTransferToSalbastd();

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
