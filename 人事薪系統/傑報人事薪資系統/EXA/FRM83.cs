using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace JBHR.EXA
{
    public partial class FRM83 : JBControls.JBForm
    {
        CheckControl cc;
        public FRM83()
        {
            InitializeComponent();
        }
        public string Nobr = "";
        private void FRM83_Load(object sender, EventArgs e)
        {
            this.eFFLVLTableAdapter.Fill(this.exa.EFFLVL);
            this.eFFTYPETableAdapter.Fill(this.exa.EFFTYPE);
            this.v_BASETableAdapter.Fill(this.mainDS.V_BASE);
            #region 必要欄位檢察
            cc = new CheckControl();
            cc.AddControl(cbEFFTYPE);   //考核種類
            cc.AddControl(cbEFFLVL);    //考核等級
            //cc.AddControl(cbDEPT);      //部門
            #endregion
            this.eFFEMPLOYTableAdapter.FillByInit(this.exa.EFFEMPLOY);
            fullDataCtrl1.DataAdapter = eFFEMPLOYTableAdapter;
            SystemFunction.SetComboBoxItems(cbEFFTYPE, CodeFunction.GetEFFTYPE(), true, false, true);          //考核種類
            SystemFunction.SetComboBoxItems(cbEFFLVL, CodeFunction.GetEFFLVL(), true, false, true);            //考核等級
            SystemFunction.SetComboBoxItems(cbDEPT, CodeFunction.GetDept(), true, false, true);                //部門

            BasDataClassesDataContext db = new BasDataClassesDataContext();
            var u_prg = (from c in db.U_PRGID where c.USER_ID.Trim() == MainForm.USER_ID && c.PROG.Trim().ToLower() == this.Name.ToLower() select c).FirstOrDefault();
            if (u_prg != null)
            {
                fullDataCtrl1.bnAddEnable = u_prg.ADD_;
                fullDataCtrl1.bnEditEnable = u_prg.EDIT;
                fullDataCtrl1.bnDelEnable = u_prg.DELE;
                fullDataCtrl1.bnExportEnable = u_prg.PRINT_;
            }
            fullDataCtrl1.WhereCmd = Sal.Function.GetFilterCmd("EFFEMPLOY");
            fullDataCtrl1.Init_Ctrls();

            //if (Nobr.Trim().Length == 0)
            //{
            //    dataGridViewEx1.Columns[0].Visible = false;
            //}
        }

        private void fullDataCtrl1_AfterDel(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            if (!e.Error)
            {
                CDataLog.Save(this.Name, MainForm.USER_NAME, DateTime.Now, fullDataCtrl1.BackupDataTable);
            }
        }

        private void fullDataCtrl1_BeforeSave(object sender, JBControls.FullDataCtrl.BeforeEventArgs e)
        {
            #region 必要欄位檢察
            var ctrl = cc.CheckRequiredFields();//必要欄位檢察
            if (ctrl != null)//必要欄位檢察
            {
                MessageBox.Show("必要欄位未輸入", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ctrl.Focus();
                e.Cancel = true;
                return;
            }
            #endregion

            if (!checkSavePower(e.Values["nobr"].ToString()))
            {
                e.Cancel = true;
                MessageBox.Show(Resources.All.WorkadrErr, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            if (string.IsNullOrEmpty(txtYYMM.Text))
            {
                string msg = "請輸入考績年度！";
                MessageBox.Show(msg);
                txtYYMM.Focus();
                e.Cancel = true;
                return;
            }
            else if (string.IsNullOrEmpty(txtNOBR.Text))
            {
                string msg = "請輸入員工編號！";
                MessageBox.Show(msg);
                txtNOBR.Focus();
                e.Cancel = true;
                return;
            }
            else if (string.IsNullOrEmpty(txtEFFSCORE.Text))
            {
                string msg = "請輸入考核分數！";
                MessageBox.Show(msg);
                txtEFFSCORE.Focus();
                e.Cancel = true;
                return;
            }

            if (!e.Cancel)
            {
                e.Values["key_man"] = MainForm.USER_NAME;
                e.Values["key_date"] = DateTime.Now;
            }
        }

        private void fullDataCtrl1_AfterSave(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            if (!e.Error)
            {
                CDataLog.Save(this.Name, MainForm.USER_NAME, DateTime.Now, fullDataCtrl1.BackupDataTable);
            }
        }

        private void fullDataCtrl1_AfterExport(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            DataView dv = ((sender as JBControls.FullDataCtrl).DataSource.DataSource as DataSet).Tables[(sender as JBControls.FullDataCtrl).DataSource.DataMember].DefaultView;
            dv.RowFilter = (sender as JBControls.FullDataCtrl).DataSource.Filter;

            JBModule.Data.CNPOI.RenderDataViewToExcel(dv, "C:\\TEMP\\" + this.Name + ".xls");
            System.Diagnostics.Process.Start("C:\\TEMP\\" + this.Name + ".xls");
        }

        private void dataGridViewEx1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void fullDataCtrl1_AfterShow(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {

        }

        private void fullDataCtrl1_AfterQuery(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {

        }

        private bool checkSavePower(string nobr)
        {
            return Sal.Function.CanModify(nobr);
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            //if (fullDataCtrl1.ModeType == JBControls.FullDataCtrl.EModeType.View) return;
            //if (textBox1.Text.Trim().Length == 0) return;

            //FRM12DataClassesDataContext db = new FRM12DataClassesDataContext();
            //string DataPropertyName = "FA_IDNO";
            //(fAMILYBindingSource.Current as DataRowView).Row.SetColumnError(DataPropertyName, "");

            //if (textBox1.Text.Length >= 2)
            //{
            //    string c1 = textBox1.Text[0].ToString().ToUpper();
            //    string c2 = textBox1.Text[1].ToString().ToUpper();

            //    if (c1.CompareTo("A") >= 0 && c1.CompareTo("Z") <= 0)
            //    {
            //        if (c2.CompareTo("1") >= 0 && c2.CompareTo("2") <= 0)
            //        {
            //            if (!IDChk(textBox1.Text))
            //            {
            //                MessageBox.Show(Resources.Bas.IDNOErr, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //                textBox1.Focus();
            //                (fAMILYBindingSource.Current as DataRowView).Row.SetColumnError(DataPropertyName, Resources.Bas.IDNOErr);
            //            }
            //            else
            //            {
            //                var chkfamily = from c in db.FAMILY
            //                                where c.FA_IDNO.Trim().ToLower() == textBox1.Text.Trim().ToLower()
            //                                select c;
            //                if (chkfamily != null && chkfamily.Count() > 0)
            //                {
            //                    MessageBox.Show(Resources.Bas.FA_IDNO_RPT_Err, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //                    textBox1.Focus();
            //                    (fAMILYBindingSource.Current as DataRowView).Row.SetColumnError(DataPropertyName, Resources.Bas.FA_IDNO_RPT_Err);
            //                }
            //            }
            //        }
            //        else if (c2.CompareTo("3") >= 0 && c2.CompareTo("9") <= 0)
            //        {
            //            MessageBox.Show(Resources.Bas.IDNOErr, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //            textBox1.Focus();
            //            (fAMILYBindingSource.Current as DataRowView).Row.SetColumnError(DataPropertyName, Resources.Bas.IDNOErr);
            //        }
            //        else if (!(c2.CompareTo("A") >= 0 && c2.CompareTo("Z") <= 0))
            //        {
            //            MessageBox.Show(Resources.Bas.IDNOErr, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //            textBox1.Focus();
            //            (fAMILYBindingSource.Current as DataRowView).Row.SetColumnError(DataPropertyName, Resources.Bas.IDNOErr);
            //        }
            //    }
            //}
            //else
            //{
            //    MessageBox.Show(Resources.Bas.IDNOErr, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    textBox1.Focus();
            //    (fAMILYBindingSource.Current as DataRowView).Row.SetColumnError(DataPropertyName, Resources.Bas.IDNOErr);
            //}
        }

        //private bool IDChk(string vid)
        //{
        //    List<string> FirstEng = new List<string> { "A", "B", "C", "D", "E", "F", "G", "H", "J", "K", "L", "M", "N", "P", "Q", "R", "S", "T", "U", "V", "X", "Y", "W", "Z", "I", "O" };
        //    string aa = vid.ToUpper();
        //    bool chackFirstEnd = false;
        //    if (aa.Trim().Length == 10)
        //    {
        //        byte firstNo = Convert.ToByte(aa.Trim().Substring(1, 1));
        //        if (firstNo > 2 || firstNo < 1)
        //        {
        //            return false;
        //        }
        //        else
        //        {
        //            int x;
        //            for (x = 0; x < FirstEng.Count; x++)
        //            {
        //                if (aa.Substring(0, 1) == FirstEng[x])
        //                {
        //                    aa = string.Format("{0}{1}", x + 10, aa.Substring(1, 9));
        //                    chackFirstEnd = true;
        //                    break;
        //                }

        //            }
        //            if (!chackFirstEnd)
        //                return false;

        //            int i = 1;
        //            int ss = int.Parse(aa.Substring(0, 1));
        //            while (aa.Length > i)
        //            {
        //                ss = ss + (int.Parse(aa.Substring(i, 1)) * (10 - i));
        //                i++;
        //            }
        //            aa = ss.ToString();
        //            if (vid.Substring(9, 1) == "0")
        //            {
        //                if (aa.Substring(aa.Length - 1, 1) == "0")
        //                {
        //                    return true;
        //                }
        //                else
        //                {
        //                    return false;
        //                }
        //            }
        //            else
        //            {
        //                if (vid.Substring(9, 1) == (10 - int.Parse(aa.Substring(aa.Length - 1, 1))).ToString())
        //                {

        //                    return true;
        //                }
        //                else
        //                {
        //                    return false;
        //                }
        //            }
        //        }
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}

        //private void dataGridViewEx1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    var cell = dataGridViewEx1.Rows[e.RowIndex].Cells[e.ColumnIndex] as DataGridViewButtonCell;
        //    if (cell != null)
        //    {
        //        Ins.FRM32.ReturnFaIdno = dataGridViewEx1.Rows[e.RowIndex].Cells[3].Value.ToString();
        //        this.Close();
        //    }
        //}

        //private void fullDataCtrl1_BeforeDel(object sender, JBControls.FullDataCtrl.BeforeEventArgs e)
        //{
        //    //if (!Sal.Function.CanModify(txtNOBR.Text))
        //    //{
        //    //    e.Cancel = true;
        //    //    MessageBox.Show(Resources.All.WorkadrErr, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //    //}
        //}

        private void txtNOBR_Validated(object sender, EventArgs e)
        {

        }

        private void txtEFFSCORE_Validated(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtEFFSCORE.Text))
            {
                var db = new JBModule.Data.Linq.HrDBDataContext();
                decimal iScore = decimal.Parse(txtEFFSCORE.Text);
                var effscore = from c in db.EFFLVL
                               where c.EFFB <= iScore && c.EFFE >= iScore
                               select new { c.EFFLVL1 };
                if (effscore.Any())
                {
                    string sEffscore = effscore.FirstOrDefault().EFFLVL1;
                    cbEFFLVL.SelectedValue = sEffscore;
                }
            }
        }

        private void fullDataCtrl1_AfterAdd(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            txtYYMM.Focus();
        }

        private void txtNOBR_QueryCompleted(object sender, JBControls.PopupTextBox.QueryCompletedArgs e)
        {
            if (e.HasData)
            {
                SetDept();
            }
        }
        void SetDept()
        {
            if (txtNOBR.Text.Trim().Length == 0) return;
            var db = new JBModule.Data.Linq.HrDBDataContext();
            var deptNo = from a in db.BASETTS
                         where a.ADATE <= System.DateTime.Today && a.DDATE >= System.DateTime.Today
                               && a.NOBR == txtNOBR.Text
                         select new { a.DEPT };
            if (deptNo.Any())
            {
                string sDeptNo = deptNo.FirstOrDefault().DEPT;
                cbDEPT.SelectedValue = sDeptNo;
            }
            else
            {
                cbDEPT.SelectedIndex = 0;
            }
        }

        private void dataGridViewEx1_SelectionChanged(object sender, EventArgs e)
        {
            SetDept();
        }

        private void bnIMPORT_Click(object sender, EventArgs e)
        {
            JBControls.U_IMPORT frm = new JBControls.U_IMPORT();
            frm.Allow_Repeat_Delete = true;
            frm.Allow_Repeat_Ignore = true;
            frm.Allow_Repeat_Override = true;
            frm.TemplateButtonVisible = true;

            frm.FieldForm = new FRM83IN();
            frm.DataTransfer = new ImportExamineData();

            frm.DataTransfer.CheckData = new Dictionary<string, List<JBControls.CheckImportData>>();
            frm.DataTransfer.CheckData.Add("員工編號", this.mainDS.V_BASE.Select(p => new JBControls.CheckImportData { DisplayCode = p.NOBR, RealCode = p.NOBR, DisplayName = p.NAME_C }).ToList());
            frm.DataTransfer.CheckData.Add("考核等級", this.exa.EFFLVL.Select(p => new JBControls.CheckImportData { DisplayCode = p.EFFLVL_DISP, RealCode = p.EFFLVL, DisplayName = p.EFFLVL_NAME, CheckValue1 = p.EFFLVL_NAME }).ToList());
            frm.DataTransfer.CheckData.Add("考核種類", this.exa.EFFTYPE.Select(p => new JBControls.CheckImportData { DisplayCode = p.EFFTYPE_DISP, RealCode = p.EFFTYPE, DisplayName = p.EFFTYPE_NAME, CheckValue1 = p.EFFTYPE_NAME }).ToList());

            frm.DataTransfer.ColumnList = new Dictionary<string, Type>();
            frm.DataTransfer.ColumnList.Add("績效年度", typeof(string));
            frm.DataTransfer.ColumnList.Add("考核種類", typeof(string));
            frm.DataTransfer.ColumnList.Add("員工編號", typeof(string));
            frm.DataTransfer.ColumnList.Add("考核分數", typeof(decimal));
            frm.DataTransfer.ColumnList.Add("考核等級", typeof(string));
            frm.DataTransfer.ColumnList.Add("備註", typeof(string));
            frm.DataTransfer.ColumnList.Add("警告", typeof(string));
            frm.DataTransfer.ColumnList.Add("錯誤註記", typeof(string));

            frm.DataTransfer.UnMustColumnList = new List<string>();
            frm.DataTransfer.UnMustColumnList.Add("考核種類");
            frm.DataTransfer.UnMustColumnList.Add("考核等級");

            frm.ShowDialog();
        }
    }
}
