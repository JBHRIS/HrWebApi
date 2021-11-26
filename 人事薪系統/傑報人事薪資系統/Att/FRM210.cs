using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace JBHR.Att
{
    public partial class FRM210 : JBControls.JBForm
    {
        public FRM210()
        {
            InitializeComponent();
        }
        string h_code = "";
        CheckControl cc;//必要欄位檢查

        private void FRM211_Load(object sender, EventArgs e)
        {
            this.hCODETableAdapter.Fill(this.dsAtt.HCODE, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN);
            this.hcodeTypeTableAdapter.Fill(this.dsAtt.HcodeType, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN);
            cc = new CheckControl();//必要欄位檢查
            cc.AddControl(comboBox1);//必要欄位檢查
            SystemFunction.SetComboBoxItems(comboBox1, CodeFunction.GetMtCode("UNIT"), true,false,true,true);
            SystemFunction.SetComboBoxItems(comboBox2, CodeFunction.GetHcode(true), true, false, true, true);
            SystemFunction.SetComboBoxItems(comboBoxExpire, CodeFunction.GetHcode(false), true, false, true, true);
            SystemFunction.SetComboBoxItems(comboBoxExtend, CodeFunction.GetHcode(true), true, false, true, true);

            BasDataClassesDataContext db = new BasDataClassesDataContext();
            var u_prg = (from c in db.U_PRGID where c.USER_ID.Trim() == MainForm.USER_ID && c.PROG.Trim().ToLower() == this.Name.ToLower() select c).FirstOrDefault();
            if (u_prg != null)
            {
                fdc.bnAddEnable = u_prg.ADD_;
                fdc.bnEditEnable = u_prg.EDIT;
                fdc.bnDelEnable = u_prg.DELE;
                fdc.bnExportEnable = u_prg.PRINT_;
            }
            fdc.CodeColumn = "hcodeType.HTYPE";//**代碼權限設定**
            fdc.CodeSource = "hcodeType";//**代碼權限設定**
            fdc.DataAdapter = this.hcodeTypeTableAdapter;
            fdc.Init_Ctrls();
        }
        private void fdc_AfterDel(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            CDataLog.Save(this.Name, MainForm.USER_ID, DateTime.Now, fdc.BackupDataTable);

        }

        private void fdc_BeforeSave(object sender, JBControls.FullDataCtrl.BeforeEventArgs e)
        {
            var ctrl = cc.CheckRequiredFields();//必要欄位檢查
            if (ctrl != null)//必要欄位檢查
            {
                MessageBox.Show("必要欄位未輸入", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ctrl.Focus();
                e.Cancel = true;
                return;
            }
            if (fdc.EditType == JBControls.FullDataCtrl.EEditType.Add)//**代碼權限設定**20121017
            {
                e.Values["HTYPE"] = Guid.NewGuid().ToString();
            }
            e.Values["KEY_MAN"] = MainForm.USER_NAME;
            e.Values["KEY_DATE"] = DateTime.Now;
            if (CheckRepeat(e.Values["HTYPE"].ToString(), e.Values["HTYPE_DISP"].ToString()))//**代碼權限設定**20121017
            {
                MessageBox.Show(Resources.Sys.CodeRepeat, "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true;
                return;
            }
        }

        private void fdc_AfterSave(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            if (!e.Error)
                CDataLog.Save(this.Name, MainForm.USER_ID, DateTime.Now, fdc.BackupDataTable);
        }

        private void fdc_AfterExport(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            DataView dv = ((sender as JBControls.FullDataCtrl).DataSource.DataSource as DataSet).Tables[(sender as JBControls.FullDataCtrl).DataSource.DataMember].DefaultView;
            dv.RowFilter = (sender as JBControls.FullDataCtrl).DataSource.Filter;

            JBModule.Data.CNPOI.RenderDataViewToExcel(dv, "C:\\TEMP\\" + this.Name + ".xls");
            System.Diagnostics.Process.Start("C:\\TEMP\\" + this.Name + ".xls");
        }

        private void fdc_AfterAdd(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            checkBox1.Checked = false;          
            checkBox3.Checked = false;           
            textBox1.Focus();
        }

        private void fdc_AfterEdit(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            textBox1.Focus();
        }

        private void fdc_BeforeDel(object sender, JBControls.FullDataCtrl.BeforeEventArgs e)
        {
            //h_code = textBox1.Text;
        }

        private void btnCodeGroup_Click(object sender, EventArgs e)
        {
            if (fdc.EditType == JBControls.FullDataCtrl.EEditType.None)
            {
                if (hcodeTypeBindingSource.Current == null) return;
                dsAtt.HcodeTypeRow r = ((hcodeTypeBindingSource.Current as DataRowView).Row as dsAtt.HcodeTypeRow);
                if (r != null)//**代碼權限設定**20121017
                {
                    Sys.SYS_CODE frm = new Sys.SYS_CODE();
                    frm.Source = "HcodeType";
                    frm.Code = r.HTYPE;
                    frm.Text += "(" + r.TYPE_NAME + ")";
                    frm.ShowDialog();
                }
            }
        }

        bool CheckRepeat(string Code, string Disp)//**代碼權限設定**20121017
        {
            var db = new JBModule.Data.Linq.HrDBDataContext();
            var sql = from a in db.HcodeType
                      where a.HTYPE != Code && a.HTYPE_DISP == Disp
                     && db.GetCodeFilter("HcodeType", a.HTYPE, MainForm.USER_ID, MainForm.COMPANY, true).Value//管理者權限設定true,才可以抓到該公司所有代碼
                      select a;
            return sql.Any();
        }
    }
}