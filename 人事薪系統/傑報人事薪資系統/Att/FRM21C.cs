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
    public partial class FRM21C : JBControls.JBForm
    {
        public FRM21C()
        {
            InitializeComponent();
        }

        CheckControl cc;//必要欄位檢查
        private void FRM21C_Load(object sender, EventArgs e)
        {
            cc = new CheckControl();//必要欄位檢查
            cc.AddControl(comboBox1);//必要欄位檢查
            cc.AddControl(comboBox2);//必要欄位檢查
            cc.AddControl(comboBox3);//必要欄位檢查
            cc.AddControl(comboBox4);//必要欄位檢查
            SystemFunction.SetComboBoxItems(comboBox1, CodeFunction.GetHolicd(), true,false,true);
            SystemFunction.SetComboBoxItems(comboBox2, CodeFunction.GetOthCode(), true, false, true);
            SystemFunction.SetComboBoxItems(comboBox3, CodeFunction.GetRote(), true, false, true);
            SystemFunction.SetComboBoxItems(comboBox4, CodeFunction.GetOtRatecd(), true, false, true);
            //this.oTRATECDTableAdapter.Fill(this.dsAtt.OTRATECD);
            this.taROTE.Fill(this.dsAtt.ROTE, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN);
            this.taHOLICD.Fill(this.dsAtt.HOLICD, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN);
            //this.taOTHCODE.Fill(this.dsAtt.OTHCODE);
            this.taHOL_DAY.Fill(this.dsAtt.HOL_DAY);

            BasDataClassesDataContext db = new BasDataClassesDataContext();
            var u_prg = (from c in db.U_PRGID where c.USER_ID.Trim() == MainForm.USER_ID && c.PROG.Trim().ToLower() == this.Name.ToLower() select c).FirstOrDefault();
            if (u_prg != null)
            {
                fdc.bnAddEnable = u_prg.ADD_;
                fdc.bnEditEnable = u_prg.EDIT;
                fdc.bnDelEnable = u_prg.DELE;
                fdc.bnExportEnable = u_prg.PRINT_;
            }

            fdc.DataAdapter = taHOL_DAY;
            fdc.Init_Ctrls();
        }

        private void fdc_AfterDel(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            if (!e.Error)
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

        private void fdc_AfterAdd(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            textBox1.Focus();
        }

        private void fdc_AfterEdit(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            comboBox3.Focus();
        }

        private void btnBatch_Click(object sender, EventArgs e)
        {
            FRM21CA frm = new FRM21CA();
            frm.ShowDialog();
        }
    }
}
