using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;

namespace JBHR.Performance.HunyaCustom.Code
{
    public partial class Hunya_PAGroupCode : JBControls.JBForm
    {
        public Hunya_PAGroupCode()
        {
            InitializeComponent();
        }

        JBControls.MultiSelectionDialog mdPAFunction = new JBControls.MultiSelectionDialog();
        private void Hunya_PAGroup_Load(object sender, EventArgs e)
        {
            // TODO: 這行程式碼會將資料載入 'hunya_Performance.Hunya_PAGroupCode' 資料表。您可以視需要進行移動或移除。
            this.PAGroupCodeTableAdapter.Fill(this.hunya_Performance.Hunya_PAGroupCode,MainForm.USER_ID,MainForm.COMPANY,MainForm.ADMIN);
            fdc.DataAdapter = PAGroupCodeTableAdapter;

            SystemFunction.SetComboBoxItems(cbxOtherBonusDept, CodeFunction.GetDept(), true, false, true);

            BasDataClassesDataContext db = new BasDataClassesDataContext();
            var u_prg = (from c in db.U_PRGID where c.USER_ID.Trim() == MainForm.USER_ID && c.PROG.Trim().ToLower() == this.Name.ToLower() select c).FirstOrDefault();
            if (u_prg != null)
            {
                fdc.bnAddEnable = u_prg.ADD_;
                fdc.bnEditEnable = u_prg.EDIT;
                fdc.bnDelEnable = u_prg.DELE;
                fdc.bnExportEnable = u_prg.PRINT_;
            }

            fdc.CodeColumn = "Hunya_PAGroupCode.PAGroupCode";//**代碼權限設定**
            fdc.CodeSource = "Hunya_PAGroupCode";//**代碼權限設定**
            fdc.Init_Ctrls();
            btnPAFuntion.Enabled = false;
            SetPAFunctionList();
        }

        private void fdc_AfterDel(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            if (!e.Error)
            {
                CDataLog.Save(this.Name, MainForm.USER_NAME, DateTime.Now, fdc.BackupDataTable);
            }
        }

        private void fdc_BeforeSave(object sender, JBControls.FullDataCtrl.BeforeEventArgs e)
        {
            if (!e.Cancel)
            {
                if (fdc.EditType == JBControls.FullDataCtrl.EEditType.Add)//**代碼權限設定**
                {
                    e.Values["PAGroupCode"] = Guid.NewGuid().ToString();
                }
                e.Values["KEYMAN"] = MainForm.USER_NAME;
                e.Values["KEYDATE"] = DateTime.Now;
                e.Values["GID"] = Guid.NewGuid();
                e.Values["PAFunction"] = string.Join(",", mdPAFunction.SelectedValues.Select(p => string.Format("{0}", p)));
                if (CheckRepeat(e.Values["PAGroupCode"].ToString(), e.Values["PAGroupCode_DISP"].ToString()))//**代碼權限設定**
                {
                    MessageBox.Show(Resources.Sys.CodeRepeat, "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    e.Cancel = true;
                    return;
                }
            }
        }

        private void fdc_AfterSave(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            if (!e.Error)
                CDataLog.Save(this.Name, MainForm.USER_ID, DateTime.Now, fdc.BackupDataTable);
            btnPAFuntion.Enabled = false;
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
            txtPABounsGroup_DISP.Focus();
            btnPAFuntion.Enabled = true;
        }

        private void btnCodeGroup_Click(object sender, EventArgs e)//**代碼權限設定**
        {
            if (fdc.EditType == JBControls.FullDataCtrl.EEditType.None)
            {
                if (PAGroupCodeBindingSource.Current == null) return;
                Hunya_Performance.Hunya_PAGroupCodeRow r = ((PAGroupCodeBindingSource.Current as DataRowView).Row as Hunya_Performance.Hunya_PAGroupCodeRow);
                if (r != null)//**代碼權限設定**
                {
                    Sys.SYS_CODE frm = new Sys.SYS_CODE();
                    frm.Source = "Hunya_PAGroupCode";
                    frm.Code = r.PAGroupCode;
                    frm.Text += "(" + r.PAGroupCode_Name + ")";
                    frm.ShowDialog();
                }
            }
        }
        bool CheckRepeat(string Code, string Disp)//**代碼權限設定**
        {
            var db = new JBModule.Data.Linq.HrDBDataContext();
            var sql = from a in db.Hunya_PAGroupCode
                      where a.PAGroupCode != Code && a.PAGroupCode_Disp == Disp
                     && db.GetCodeFilter("Hunya_PAGroupCode", a.PAGroupCode, MainForm.USER_ID, MainForm.COMPANY, true).Value//管理者權限設定true,才可以抓到該公司所有代碼
                      select a;
            return sql.Any();
        }

        private void dgv_SelectionChanged(object sender, EventArgs e)
        {
            if (fdc.EditType != JBControls.FullDataCtrl.EEditType.Add)
            {
                if (dgv.CurrentRow != null && dgv.CurrentRow.Cells[0].Value.ToString().Trim().Length > 0)
                {
                    int AK = int.Parse(dgv.CurrentRow.Cells[0].Value.ToString());
                    var db = new JBModule.Data.Linq.HrDBDataContext();
                    var PAFunction = db.Hunya_PAGroupCode.FirstOrDefault(p => p.AK == AK).PAFunction.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToList();
                    var PAFunctionList = from a in db.SALFUNCTION
                                         where PAFunction.Contains(a.AUTO.ToString())
                                         select new
                                         {
                                             _key = a.AUTO,
                                             獎金種類 = a.ITEM,
                                             //公式細節 = a.SCRIPT,
                                         };
                    mdPAFunction.SelectedValues = PAFunction;
                    btnPAFuntion.Text = PAFunctionList.Count() == 1 ? PAFunctionList.First().獎金種類 : string.Format("選擇({0})筆", PAFunctionList.Count());
                } 
            }
        }
        void SetPAFunctionList()
        {
            DataTable dt = new DataTable();
            var db = new JBModule.Data.Linq.HrDBDataContext();
            var PAFunctions = from a in db.SALFUNCTION
                              where a.CALCTYPE == "PA"
                              select new { _key = a.AUTO.ToString(), 獎金種類 = a.ITEM, 公式細節 = a.SCRIPT };
            mdPAFunction.SetControl(btnPAFuntion, PAFunctions.CopyToDataTable(), "_key");
            mdPAFunction.SelectedValues.Clear();
            btnPAFuntion.Text = "請選擇需設定的績效獎金公式";
        }

        private void fdc_AfterCancel(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            btnPAFuntion.Enabled = false;
        }

        private void fdc_AfterEdit(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            btnPAFuntion.Enabled = true;
        }
    }
}
