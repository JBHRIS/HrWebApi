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
    public partial class FRM43 : JBControls.JBForm
    {
        public FRM43()
        {
            InitializeComponent();
        }

        CheckControl cc;//必要欄位檢查
        private void FRM43_Load(object sender, EventArgs e)
        {
            cc = new CheckControl();//必要欄位檢查
            cc.AddControl(comboBox1);//必要欄位檢查
            cc.AddControl(comboBox2);//必要欄位檢查
            cc.AddControl(comboBox3);//必要欄位檢查
            cc.AddControl(comboBox4);//必要欄位檢查
            cc.AddControl(comboBox5);//必要欄位檢查

            SystemFunction.SetComboBoxItems(comboBox1, CodeFunction.GetSalattr(), true, false, true);
            comboBox1.Enabled = false;
            SystemFunction.SetComboBoxItems(comboBox2, CodeFunction.GetMtCode("sOS_ID"), true, false, true);
            comboBox2.Enabled = false;
            SystemFunction.SetComboBoxItems(comboBox3, CodeFunction.GetMtCode("cAL_FREQ"), true, false, true);
            comboBox3.Enabled = false;
            SystemFunction.SetComboBoxItems(comboBox4, CodeFunction.GetMtCode("mONTH_TYPE"), true, false, true);
            comboBox4.Enabled = false;
            SystemFunction.SetComboBoxItems(comboBox5, CodeFunction.GetAcccd(), true, false, true);
            comboBox5.Enabled = false;
            SystemFunction.SetComboBoxItems(comboBox6, CodeFunction.GetSalFunction("SAL"), true, false, true);
            comboBox6.Enabled = false;
            SystemFunction.SetComboBoxItems(comboBox7,CodeFunction.GetMtCode("CALC_REF_TYPE"),true, false, true);
            comboBox6.Enabled = false;

            SystemFunction.CheckCodeConfigRule(button1);//**代碼權限設定**           
            //this.mONTH_TYPETableAdapter.Fill(this.viewDS.MONTH_TYPE);
            //this.cAL_TYPETableAdapter.Fill(this.viewDS.CAL_TYPE);
            //this.cAL_FREQTableAdapter.Fill(this.viewDS.CAL_FREQ);
            //this.sOS_IDTableAdapter.Fill(this.viewDS.SOS_ID);
            this.aCCCDTableAdapter.Fill(this.salaryDS.ACCCD, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN);
            //this.sALATTRTableAdapter.Fill(this.salaryDS.SALATTR);
            this.sALCODETableAdapter.Fill(this.salaryDS.SALCODE, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN);

            BasDataClassesDataContext db = new BasDataClassesDataContext();
            var u_prg = (from c in db.U_PRGID where c.USER_ID.Trim() == MainForm.USER_ID && c.PROG.Trim().ToLower() == this.Name.ToLower() select c).FirstOrDefault();
            if (u_prg != null)
            {
                fullDataCtrl1.bnAddEnable = u_prg.ADD_;
                fullDataCtrl1.bnEditEnable = u_prg.EDIT;
                fullDataCtrl1.bnDelEnable = u_prg.DELE;
                fullDataCtrl1.bnExportEnable = u_prg.PRINT_;
            }
            fullDataCtrl1.CodeColumn = "SALCODE.SAL_CODE";
            fullDataCtrl1.CodeSource = "SALCODE";
            fullDataCtrl1.DataAdapter = sALCODETableAdapter;
            fullDataCtrl1.Init_Ctrls();
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

            if (!e.Cancel)
            {
                if (fullDataCtrl1.EditType == JBControls.FullDataCtrl.EEditType.Add)//**代碼權限設定**20121017
                {
                    e.Values["SAL_CODE"] = Guid.NewGuid().ToString();
                }
                e.Values["KEY_MAN"] = MainForm.USER_NAME;
                e.Values["KEY_DATE"] = DateTime.Now;
                if (CheckRepeat(e.Values["SAL_CODE"].ToString(), e.Values["SAL_CODE_DISP"].ToString()))//**代碼權限設定**20121017
                {
                    MessageBox.Show(Resources.Sys.CodeRepeat, "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    e.Cancel = true;
                    return;
                }
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
        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void fullDataCtrl1_AfterDel(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            CDataLog.Save(this.Name, MainForm.USER_ID, DateTime.Now, fullDataCtrl1.BackupDataTable);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (fullDataCtrl1.EditType == JBControls.FullDataCtrl.EEditType.None)
            {
                if (sALCODEBindingSource.Current == null) return;
                SalaryDS.SALCODERow r = ((sALCODEBindingSource.Current as DataRowView).Row as SalaryDS.SALCODERow);
                if (r != null)//**代碼權限設定**20121017
                {
                    Sys.SYS_CODE frm = new Sys.SYS_CODE();
                    frm.Source = "SALCODE";
                    frm.Code = r.SAL_CODE;
                    frm.Text += "(" + r.SAL_NAME + ")";
                    frm.ShowDialog();
                }
            }
        }
        bool CheckRepeat(string Code, string Disp)//**代碼權限設定**20121017
        {
            var db = new JBModule.Data.Linq.HrDBDataContext();
            var sql = from a in db.SALCODE
                      where a.SAL_CODE != Code && a.SAL_CODE_DISP == Disp
                     && db.GetCodeFilter("SALCODE", a.SAL_CODE, MainForm.USER_ID, MainForm.COMPANY, true).Value//管理者權限設定true,才可以抓到該公司所有代碼
                      select a;
            return sql.Any();
        }

        private void ButtonLNG_Click(object sender, EventArgs e)
        {
            if (fullDataCtrl1.EditType == JBControls.FullDataCtrl.EEditType.None)
            {
                if (sALCODEBindingSource.Current == null) return;
                SalaryDS.SALCODERow r = ((sALCODEBindingSource.Current as DataRowView).Row as SalaryDS.SALCODERow);
                if (r != null)//**代碼權限設定**20121017
                {
                    JBControls.Fomrs.MTLNG frm = new JBControls.Fomrs.MTLNG();
                    frm.Source = "SALCODE";
                    frm.Code = r.SAL_CODE;
                    frm.Text += "(" + r.SAL_NAME + ")";
                    frm.ShowDialog();
                }
            }
        }
    }
}
