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
    public partial class FRM41 : JBControls.JBForm
    {
        public FRM41()
        {
            InitializeComponent();
        }

        CheckControl cc;//必要欄位檢查
        private void FRM41_Load(object sender, EventArgs e)
        {
            // TODO:  這行程式碼會將資料載入 'basDS.CostType' 資料表。您可以視需要進行移動或移除。
            this.costTypeTableAdapter.Fill(this.basDS.CostType);
            // TODO:  這行程式碼會將資料載入 'basDS.ACCSAL' 資料表。您可以視需要進行移動或移除。
            this.aCCSALTableAdapter.Fill(this.basDS.ACCSAL);
            cc = new CheckControl();//必要欄位檢查
            cc.AddControl(comboBox1);//必要欄位檢查
            SystemFunction.SetComboBoxItems(comboBox1, CodeFunction.GetMtCode("ACCCDATTR"), true, false, true);
            comboBox1.Enabled = false;
            SystemFunction.CheckCodeConfigRule(btnCodeGroup);//**代碼權限設定**   
            //this.aCCCDATTRTableAdapter.Fill(this.viewDS.ACCCDATTR);
            this.aCCCDTableAdapter.Fill(this.salaryDS.ACCCD, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN);
            BasDataClassesDataContext db = new BasDataClassesDataContext();
            var u_prg = (from c in db.U_PRGID where c.USER_ID.Trim() == MainForm.USER_ID && c.PROG.Trim().ToLower() == this.Name.ToLower() select c).FirstOrDefault();
            if (u_prg != null)
            {
                fullDataCtrl1.bnAddEnable = u_prg.ADD_;
                fullDataCtrl1.bnEditEnable = u_prg.EDIT;
                fullDataCtrl1.bnDelEnable = u_prg.DELE;
                fullDataCtrl1.bnExportEnable = u_prg.PRINT_;
            }

            fullDataCtrl1.CodeColumn = "A.ACCCD";//**代碼權限設定**
            fullDataCtrl1.CodeSource = "ACCCD";//**代碼權限設定**
            fullDataCtrl1.DataAdapter = aCCCDTableAdapter;
            fullDataCtrl1.Init_Ctrls();
            SetGvAcc();//設定gridview顯示費用代碼、費用名稱、借方科目、貸方科目
        }

        private void fullDataCtrl1_AfterAdd(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            textBox1.Focus();
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

            if (fullDataCtrl1.EditType == JBControls.FullDataCtrl.EEditType.Add)//**代碼權限設定**20121017
            {
                e.Values["ACCCD"] = Guid.NewGuid().ToString();
            }
            e.Values["KEY_MAN"] = MainForm.USER_NAME;
            e.Values["KEY_DATE"] = DateTime.Now;
            if (CheckRepeat(e.Values["ACCCD"].ToString(), e.Values["ACCCD_DISP"].ToString()))//**代碼權限設定**20121017
            {
                MessageBox.Show(Resources.Sys.CodeRepeat, "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true;
                return;
            }
        }

        void fdc_AfterEdit(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            textBox2.Focus();
        }

        private void fullDataCtrl1_AfterExport(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            DataView dv = ((sender as JBControls.FullDataCtrl).DataSource.DataSource as DataSet).Tables[(sender as JBControls.FullDataCtrl).DataSource.DataMember].DefaultView;
            dv.RowFilter = (sender as JBControls.FullDataCtrl).DataSource.Filter;

            JBModule.Data.CNPOI.RenderDataViewToExcel(dv, "C:\\TEMP\\" + this.Name + ".xls");
            System.Diagnostics.Process.Start("C:\\TEMP\\" + this.Name + ".xls");
        }

        private void fullDataCtrl1_AfterSave(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            if (!e.Error)
                CDataLog.Save(this.Name, MainForm.USER_ID, DateTime.Now, fullDataCtrl1.BackupDataTable);
            SetGvAcc();//設定gridview顯示費用代碼、費用名稱、借方科目、貸方科目
        }

        private void fullDataCtrl1_AfterDel(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            //if (!e.Error)
                CDataLog.Save(this.Name, MainForm.USER_ID, DateTime.Now, fullDataCtrl1.BackupDataTable);
                SetGvAcc();//設定gridview顯示費用代碼、費用名稱、借方科目、貸方科目
        }

        bool CheckRepeat(string Code, string Disp)//**代碼權限設定**20121017
        {
            var db = new JBModule.Data.Linq.HrDBDataContext();
            var sql = from a in db.ACCCD
                      where a.ACCCD1 != Code && a.ACCCD_DISP == Disp
                     && db.GetCodeFilter("ACCCD", a.ACCCD1, MainForm.USER_ID, MainForm.COMPANY, true).Value//管理者權限設定true,才可以抓到該公司所有代碼
                      select a;
            return sql.Any();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (fullDataCtrl1.EditType == JBControls.FullDataCtrl.EEditType.None)
            {
                if (aCCCDBindingSource.Current == null) return;
                SalaryDS.ACCCDRow r = ((aCCCDBindingSource.Current as DataRowView).Row as SalaryDS.ACCCDRow);
               
                Bas.FRM11Y frm = new Bas.FRM11Y(r.ACCCD);
                frm.Text = frm.Text + "-" + (sender as Button).Text;
                frm.ShowDialog();
                aCCSALTableAdapter.FillByAccCd(basDS.ACCSAL, r.ACCCD);
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            //SetGvAcc();
        }

        private void SetGvAcc() //設定gridview顯示費用代碼、費用名稱、借方科目、貸方科目
        {
            if (aCCCDBindingSource.Current == null) return;
            SalaryDS.ACCCDRow r = ((aCCCDBindingSource.Current as DataRowView).Row as SalaryDS.ACCCDRow);
            aCCSALTableAdapter.FillByAccCd(basDS.ACCSAL, r.ACCCD);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            SetGvAcc();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            SetGvAcc();
        }

        private void btnCodeGroup_Click_1(object sender, EventArgs e)
        {
            if (fullDataCtrl1.EditType == JBControls.FullDataCtrl.EEditType.None)
            {
                if (aCCCDBindingSource.Current == null) return;
                SalaryDS.ACCCDRow r = ((aCCCDBindingSource.Current as DataRowView).Row as SalaryDS.ACCCDRow);
                if (r != null)//**代碼權限設定**20121017
                {
                    Sys.SYS_CODE frm = new Sys.SYS_CODE();
                    frm.Source = "ACCCD";
                    frm.Code = r.ACCCD;
                    frm.Text += "(" + r.ACCNAME + ")";
                    frm.ShowDialog();
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

    }
}
