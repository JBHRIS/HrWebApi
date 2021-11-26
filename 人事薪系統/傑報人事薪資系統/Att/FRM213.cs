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
    public partial class FRM213 : JBControls.JBForm
    {
        public FRM213()
        {
            InitializeComponent();
        }

        CheckControl cc;//必要欄位檢查
        private void FRM213_Load(object sender, EventArgs e)
        {
            cc = new CheckControl();//必要欄位檢查
            cc.AddControl(comboBox1);//必要欄位檢查
            SystemFunction.CheckCodeConfigRule(btnCodeGroup);//**代碼權限設定** 
            var salcodeDic = CodeFunction.GetSalCode();
            var roteDic = CodeFunction.GetRote();
            SystemFunction.SetComboBoxItems(cbNigSalcode, salcodeDic, true, false, true);
            SystemFunction.SetComboBoxItems(cbFoodSalcode, salcodeDic, true, false, true);
            SystemFunction.SetComboBoxItems(comboBox1, roteDic, true, false, true);
            SystemFunction.SetComboBoxItems(comboBox2, roteDic, true, false, true);
            SystemFunction.SetComboBoxItems(comboBox3, roteDic, true, false, true);
            SystemFunction.SetComboBoxItems(comboBox4, roteDic, true, false, true);
            SystemFunction.SetComboBoxItems(comboBox5, roteDic, true, false, true);
            SystemFunction.SetComboBoxItems(comboBox6, roteDic, true, false, true);
            SystemFunction.SetComboBoxItems(comboBox7, roteDic, true, false, true);
            SystemFunction.SetComboBoxItems(comboBox8, roteDic, true, false, true);
            SystemFunction.SetComboBoxItems(comboBox9, roteDic, true, false, true);
            SystemFunction.SetComboBoxItems(comboBox10, roteDic, true, false, true);
            SystemFunction.SetComboBoxItems(comboBox11, CodeFunction.GetMtCode("FREQ"), true, false, true);
            SystemFunction.SetComboBoxItems(comboBox12, CodeFunction.GetMtCode("FREQ_START"), true, false, true);
            SystemFunction.SetComboBoxItems(comboBox13, CodeFunction.GetMtCode("INHOLI"), true, false, true);
            //this.taINHOLI.Fill(this.dsView.INHOLI);
            //this.taFREQ_START.Fill(this.dsView.FREQ_START);
            //this.taFREQ.Fill(this.dsView.FREQ);
            //this.taROTE.Fill(this.dsAtt.ROTE, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN);
            this.taROTET.Fill(this.dsAtt.ROTET, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN);
            fdc.DataAdapter = taROTET;

            BasDataClassesDataContext db = new BasDataClassesDataContext();
            var u_prg = (from c in db.U_PRGID where c.USER_ID.Trim() == MainForm.USER_ID && c.PROG.Trim().ToLower() == this.Name.ToLower() select c).FirstOrDefault();
            if (u_prg != null)
            {
                fdc.bnAddEnable = u_prg.ADD_;
                fdc.bnEditEnable = u_prg.EDIT;
                fdc.bnDelEnable = u_prg.DELE;
                fdc.bnExportEnable = u_prg.PRINT_;
            }
            fdc.CodeColumn = "ROTET.ROTET";//**代碼權限設定**
            fdc.CodeSource = "ROTET";//**代碼權限設定**
            fdc.Init_Ctrls();
            SetFATTAMTState();
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
                e.Values["ROTET"] = Guid.NewGuid().ToString();
            }
            e.Values["KEY_MAN"] = MainForm.USER_NAME;
            e.Values["KEY_DATE"] = DateTime.Now;
            e.Values["FATTAMT"] = Convert.ToDecimal(txtFATTAMT.Text);
            if (CheckRepeat(e.Values["ROTET"].ToString(), e.Values["ROTET_DISP"].ToString()))//**代碼權限設定**20121017
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
            SetFATTAMTState();
        }

        //private void fdc_BeforeShow(object sender, JBControls.FullDataCtrl.BeforeEventArgs e)
        //{
        //    taROTET.Adapter.Fill(this.dsAtt.ROTET);
        //}

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
            textBox5.Text = "1";
            textBox6.Text = "1";
            textBox7.Text = "1";
            textBox8.Text = "1";
            textBox9.Text = "1";
            textBox10.Text = "1";
            textBox11.Text = "1";
            textBox12.Text = "1";
            textBox13.Text = "1";
            textBox14.Text = "1";
            comboBox12.SelectedValue = "0";
            SetFATTAMTState();
        }

        private void fdc_AfterEdit(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            textBox2.Focus();
            SetFATTAMTState();
        }

        private void btnCodeGroup_Click(object sender, EventArgs e)
        {
            if (fdc.EditType == JBControls.FullDataCtrl.EEditType.None)
            {
                if (bsROTET.Current == null) return;
                dsAtt.ROTETRow r = ((bsROTET.Current as DataRowView).Row as dsAtt.ROTETRow);
                if (r != null)//**代碼權限設定**20121017
                {
                    Sys.SYS_CODE frm = new Sys.SYS_CODE();
                    frm.Source = "ROTET";
                    frm.Code = r.ROTET;
                    frm.Text += "(" + r.ROTETNAME + ")";
                    frm.ShowDialog();
                }
            }
        }
        bool CheckRepeat(string Code, string Disp)//**代碼權限設定**20121017
        {
            var db = new JBModule.Data.Linq.HrDBDataContext();
            var sql = from a in db.ROTET
                      where a.ROTET1 != Code && a.ROTET_DISP == Disp
                     && db.GetCodeFilter("ROTET", a.ROTET1, MainForm.USER_ID, MainForm.COMPANY, true).Value//管理者權限設定true,才可以抓到該公司所有代碼
                      select a;
            return sql.Any();
        }

        private void dgv_SelectionChanged(object sender, EventArgs e)
        {
            if (bsROTET.Current == null)
            {
                txtFATTAMT.Text = "";
                return;
            }
            dsAtt.ROTETRow r = ((bsROTET.Current as DataRowView).Row as dsAtt.ROTETRow);
            if (r != null)//因為UI異常，無法繫結到fattamt，固手動
            {

                txtFATTAMT.Text = r.IsFATTAMTNull() ? "0" : r.FATTAMT.ToString();
            }
        }
        void SetFATTAMTState()
        {
            if (fdc.EditType == JBControls.FullDataCtrl.EEditType.None)
            {
                txtFATTAMT.Enabled = false;
            }
            else
                txtFATTAMT.Enabled = true;
        }

        private void fdc_AfterCancel(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            SetFATTAMTState();
        }

        private void fdc_AfterQuery(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            SetFATTAMTState();
        }
    }
}
