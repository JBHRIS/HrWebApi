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
    public partial class FRM211D : JBControls.JBForm
    {
        public string sHcode;

        public FRM211D()
        {
            InitializeComponent();
        }
        CheckControl cc;//必要欄位檢查
        private void FRM211D_Load(object sender, EventArgs e)
        {
            // TODO: 這行程式碼會將資料載入 'extDS.SALCODE' 資料表。您可以視需要進行移動或移除。
            this.sALCODETableAdapter.Fill(this.extDS.SALCODE);
            //this.taSALCODE.FillByBASIC(this.dsSal.SALCODE, false);
            //this.taSALCODE.FillByBASIC(this.dsSalBasic.SALCODE, true);
            SystemFunction.SetComboBoxItems(comboBox1, CodeFunction.GetSalCode(), true,false,true);//薪資代碼
            SystemFunction.SetComboBoxItems(comboBox2, CodeFunction.GetSalCode(), true, false, true);//扣款薪資代碼
            cc = new CheckControl();//必要欄位檢查
            cc.AddControl(comboBox1);//必要欄位檢查
            cc.AddControl(comboBox2);//必要欄位檢查
            this.taHCODES.FillByH_CODE(this.dsAtt.HCODES, sHcode);
          

            BasDataClassesDataContext db = new BasDataClassesDataContext();
            var u_prg = (from c in db.U_PRGID where c.USER_ID.Trim() == MainForm.USER_ID && c.PROG.Trim().ToLower() == this.Name.ToLower() select c).FirstOrDefault();
            if (u_prg != null)
            {
                fdc.bnAddEnable = u_prg.ADD_;
                fdc.bnEditEnable = u_prg.EDIT;
                fdc.bnDelEnable = u_prg.DELE;
                fdc.bnExportEnable = u_prg.PRINT_;
            }
            fdc.WhereCmd = " H_CODE='" + sHcode + "'";
            fdc.DataAdapter = taHCODES;
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
            JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();

            var salCode = from c in db.SALCODE
                          where c.SAL_CODE == comboBox1.SelectedValue.ToString()
                          select new { c.SAL_NAME };
            string salName = "";
            if (salCode.Any())
            {
                salName = salCode.FirstOrDefault().SAL_NAME;
            }
            e.Values["H_CODE"] = sHcode;
            e.Values["SAL_NAME"] = salName;
            e.Values["KEY_MAN"] = MainForm.USER_NAME;
            e.Values["KEY_DATE"] = DateTime.Now;
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

        private void btnRule_Click(object sender, EventArgs e)
        {
            FRM211DS frm = new FRM211DS();
            frm.sHcode = this.sHcode;
            frm.sSalcode = comboBox1.SelectedValue != null ?  comboBox1.SelectedValue.ToString() : string.Empty;
            frm.Text += "(特殊規則)";
            if (!string.IsNullOrWhiteSpace(frm.sSalcode) && !string.IsNullOrWhiteSpace(frm.sHcode))
                frm.ShowDialog();
        }
    }
}
