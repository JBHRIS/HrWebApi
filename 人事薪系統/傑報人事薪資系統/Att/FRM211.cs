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
    public partial class FRM211 : JBControls.JBForm
    {
        public FRM211()
        {
            InitializeComponent();
        }
        string h_code = "";
        CheckControl cc;//必要欄位檢查

        private void FRM211_Load(object sender, EventArgs e)
        {
            cc = new CheckControl();//必要欄位檢查
            cc.AddControl(comboBox1);//必要欄位檢查
            cc.AddControl(comboBoxFlag);//必要欄位檢查
            //cc.AddControl(comboBoxHtype);//必要欄位檢查
            Dictionary<string,string> flagDic=new Dictionary<string,string>();
            flagDic.Add("+", "+ 得假");
            flagDic.Add("-", "- 扣假");
            flagDic.Add("X", "X 借假");
            SystemFunction.SetComboBoxItems(comboBox1, CodeFunction.GetMtCode("UNIT"), true, false, true);
            SystemFunction.SetComboBoxItems(comboBoxFlag, flagDic,true, false, true);
            SystemFunction.SetComboBoxItems(comboBox3, CodeFunction.GetHcode(), true, false, true);
            SystemFunction.SetComboBoxItems(comboBox4, CodeFunction.GetMtCode("SEX"), true, false, true);
            SystemFunction.SetComboBoxItems(comboBoxHtype, CodeFunction.GetHcodeType(), true, false, true);

            SystemFunction.CheckCodeConfigRule(btnCodeGroup);//**代碼權限設定**
            SystemFunction.CheckAppConfigRule(btnConfig);
           JBModule.Data.ApplicationConfigSettings AppConfig = new JBModule.Data.ApplicationConfigSettings("FRM211",MainForm.COMPANY);
           AppConfig.CheckParameterAndSetDefault("ComposeLeaveGetCode", "補休得代碼", "", "指定補休得代碼", "ComboBox", "select h_code,h_code_disp+'-'+h_name from hcode where dbo.getcodefilter('HCODE',H_CODE,@userid,@comp,@admin)=1", "String");
            
            
            this.taHCODE.Fill(this.dsAtt.HCODE, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN);
            //this.taSEX.Fill(this.dsView.SEX);
            //this.taYEAR_REST.Fill(this.dsView.YEAR_REST);
            //this.taUNIT.Fill(this.dsView.UNIT);

            BasDataClassesDataContext db = new BasDataClassesDataContext();
            var u_prg = (from c in db.U_PRGID where c.USER_ID.Trim() == MainForm.USER_ID && c.PROG.Trim().ToLower() == this.Name.ToLower() select c).FirstOrDefault();
            if (u_prg != null)
            {
                fdc.bnAddEnable = u_prg.ADD_;
                fdc.bnEditEnable = u_prg.EDIT;
                fdc.bnDelEnable = u_prg.DELE;
                fdc.bnExportEnable = u_prg.PRINT_;
            }
            fdc.CodeColumn = "HCODE.H_CODE";//**代碼權限設定**
            fdc.CodeSource = "HCODE";//**代碼權限設定**
            fdc.DataAdapter = taHCODE;
            fdc.Init_Ctrls();
        }
        private void fdc_AfterDel(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            CDataLog.Save(this.Name, MainForm.USER_ID, DateTime.Now, fdc.BackupDataTable);

            string delCMD = "DELETE HCODES WHERE H_CODE={0}";
            object[] PARA = new object[] { h_code };
            dcAttDataContext db = new dcAttDataContext();
            db.ExecuteCommand(delCMD, PARA);
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
            if (decimal.Parse(textBox8.Text) == 0)
            {
                MessageBox.Show("請假間隔最小數不可為0", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox8.Focus();
                e.Cancel = true;
                return;
            }
            if (fdc.EditType == JBControls.FullDataCtrl.EEditType.Add)//**代碼權限設定**20121017
            {
                e.Values["h_code"] = Guid.NewGuid().ToString();
            }
            e.Values["KEY_MAN"] = MainForm.USER_NAME;
            e.Values["KEY_DATE"] = DateTime.Now;
            if (CheckRepeat(e.Values["H_CODE"].ToString(), e.Values["H_CODE_DISP"].ToString()))//**代碼權限設定**20121017
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
        private void btnFRM211D_Click(object sender, EventArgs e)
        {
            if (bsHCODE.Current == null) return;

            dsAtt.HCODERow r = ((bsHCODE.Current as DataRowView).Row as dsAtt.HCODERow);
            FRM211D frm = new FRM211D();
            frm.Text = frm.Text + "-" + (sender as Button).Text + "(" + r.H_CODE_DISP.Trim() + "-" + r.H_NAME.Trim() + ")";
            frm.sHcode = r.H_CODE.Trim();   //假別代碼
            frm.ShowDialog();
        }

        private void fdc_AfterAdd(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            checkBox4.Checked = false;
            checkBox5.Checked = false;
            checkBox6.Checked = false;
            checkBox7.Checked = false;
            checkBox8.Checked = false;
            checkBox9.Checked = false;
            checkBox10.Checked = false;
            textBox7.Text = "1";
            textBox8.Text = "0.50";
            textBox1.Focus();
        }

        private void fdc_AfterEdit(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            textBox2.Focus();
        }

        private void fdc_BeforeDel(object sender, JBControls.FullDataCtrl.BeforeEventArgs e)
        {
            h_code = textBox1.Text;
        }

        private void btnCodeGroup_Click(object sender, EventArgs e)//**代碼權限設定**
        {
            if (fdc.EditType == JBControls.FullDataCtrl.EEditType.None)
            {
                if (bsHCODE.Current == null) return;
                dsAtt.HCODERow r = ((bsHCODE.Current as DataRowView).Row as dsAtt.HCODERow);
                if (r != null)//**代碼權限設定**20121017
                {
                    Sys.SYS_CODE frm = new Sys.SYS_CODE();
                    frm.Source = "HCODE";
                    frm.Code = r.H_CODE;
                    frm.Text += "(" + r.H_NAME + ")";
                    frm.ShowDialog();
                }
            }
        }
        bool CheckRepeat(string Code, string Disp)//**代碼權限設定**20121017
        {
            var db = new JBModule.Data.Linq.HrDBDataContext();
            var sql = from a in db.HCODE
                      where a.H_CODE != Code && a.H_CODE_DISP == Disp
                     && db.GetCodeFilter("HCODE", a.H_CODE, MainForm.USER_ID, MainForm.COMPANY, true).Value//管理者權限設定true,才可以抓到該公司所有代碼
                      select a;
            return sql.Any();
        }

        private void ButtonLNG_Click(object sender, EventArgs e)
        {
            if (fdc.EditType == JBControls.FullDataCtrl.EEditType.None)
            {
                if (bsHCODE.Current == null) return;
                dsAtt.HCODERow r = ((bsHCODE.Current as DataRowView).Row as dsAtt.HCODERow);
                if (r != null)//**代碼權限設定**20121017
                {
                    JBControls.Fomrs.MTLNG frm = new JBControls.Fomrs.MTLNG();
                    frm.Source = "HCODE";
                    frm.Code = r.H_CODE;
                    frm.Text += "(" + r.H_NAME + ")";
                    frm.ShowDialog();
                }
            }
        }
    }
}