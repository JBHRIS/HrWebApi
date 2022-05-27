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
    public partial class FRM46C : JBControls.JBForm
    {
        SalaryMDDataContext smd = new SalaryMDDataContext();
        public FRM46C()
        {
            InitializeComponent();
        }

        CheckControl cc;//必要欄位檢查
        private void FRM46C_Load(object sender, EventArgs e)
        {
            cc = new CheckControl();//必要欄位檢查
            cc.AddControl(ptxDept);//必要欄位檢查
            cc.AddControl(ptxSalcode);//必要欄位檢查
            SystemFunction.SetComboBoxItems(ptxDept, CodeFunction.GetDept(), true, false, true);
            ptxDept.Enabled = false;
            SystemFunction.SetComboBoxItems(ptxSalcode, CodeFunction.GetSalCode(), true, false, true);
            ptxSalcode.Enabled = false;
            //this.sALCODETableAdapter.Fill(this.salaryDS.SALCODE, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN); 
            //this.dEPTTableAdapter.Fill(this.baseDS.DEPT);
            this.dEPTTableAdapter1.Fill(this.basDS.DEPT, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN);
            BasDataClassesDataContext db = new BasDataClassesDataContext();
            var u_prg = (from c in db.U_PRGID where c.USER_ID.Trim() == MainForm.USER_ID && c.PROG.Trim().ToLower() == this.Name.ToLower() select c).FirstOrDefault();
            if (u_prg != null)
            {
                fullDataCtrl1.bnAddEnable = u_prg.ADD_;
                fullDataCtrl1.bnEditEnable = u_prg.EDIT;
                fullDataCtrl1.bnDelEnable = u_prg.DELE;
                fullDataCtrl1.bnExportEnable = u_prg.PRINT_;
            }

            Function.SetAvaliableBase(this.salaryDS.BASE);
            fullDataCtrl1.WhereCmd = Sal.Function.GetFilterCmd(this.Name);

            this.sALBASNDTableAdapter.FillByInit(this.salaryDS.SALBASND);
            fullDataCtrl1.DataAdapter = this.wAGEDDTableAdapter;
            fullDataCtrl1.Init_Ctrls();
        }
        /// <summary>
        /// 新增後
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fullDataCtrl1_AfterAdd(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            ptxNobr.Focus();
        }
        private void fullDataCtrl1_BeforeDel(object sender, JBControls.FullDataCtrl.BeforeEventArgs e)
        {
            if (!Function.CanModify(ptxNobr.Text))
            {
                e.Cancel = true;
                MessageBox.Show(Resources.Sal.NonAccessableRule, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void fullDataCtrl1_AfterDel(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            if (!e.Error)
                CDataLog.Save(this.Name, MainForm.USER_ID, DateTime.Now, fullDataCtrl1.BackupDataTable);

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

            if (!Function.CanModify(ptxNobr.Text))
            {
                e.Cancel = true;
                MessageBox.Show(Resources.Sal.NonAccessableRule, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            if (!e.Cancel)
            {
                e.Values["kEy_MaN"] = MainForm.USER_NAME;
                e.Values["KeY_dAtE"] = DateTime.Now;
                e.Values["sal_code"] = ptxSalcode.SelectedValue;
                e.Values["sal_name"] = ptxSalcode.SelectedText;
                e.Values["D_NO"] = ptxDept.SelectedValue;
                e.Values["D_Name"] = ptxDept.SelectedText;
                e.Values["amt"] = JBModule.Data.CEncrypt.Number(Convert.ToDecimal(txtAmt.Text));
            }
        }
        private void fullDataCtrl1_AfterSave(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            e.Values["amt"] = JBModule.Data.CDecryp.Number(Convert.ToDecimal(e.Values["amt"]));
            if (!e.Error)//發生錯誤就略過
                CDataLog.Save(this.Name, MainForm.USER_ID, DateTime.Now, fullDataCtrl1.BackupDataTable);
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

        private void ptxNobr_QueryCompleted(object sender, JBControls.PopupTextBox.QueryCompletedArgs e)
        {
            /*
             *在查詢結束後，決定員工以及銀行代扣的資料範圍 
             */
            if (e.HasData)
            {
                //txtYymm.Focus();
                BASETTS basetts_row = Function.GetCurrentBasetts(ptxNobr.Text);
                if (basetts_row != null)
                {
                    ptxDept.Text = basetts_row.DEPT;
                }
                SetSalbasnd(this.salaryDS.SALBASND);
                foreach (var itm in this.salaryDS.SALBASD)
                    itm.AMT = JBModule.Data.CDecryp.Number(itm.AMT);
            }
        }

        void SetSalbasnd(SalaryDS.SALBASNDDataTable dt)
        {
            try
            {
                if (smd.Connection.State != ConnectionState.Open) smd.Connection.Open();
                var sql = from salbasnd in smd.V_FRM46B where salbasnd.NOBR == ptxNobr.Text select salbasnd;
                dt.Clear();
                dt.Load(smd.GetCommand(sql).ExecuteReader());
                smd.GetCommand(sql).ExecuteReader().Close();
            }
            finally
            {
                smd.Connection.Close();
            }
        }

        private void ptxAcno_QueryCompleted(object sender, JBControls.PopupTextBox.QueryCompletedArgs e)
        {
            if (e.HasData)
            {
                DataRowView r = (DataRowView)sALBASNDBindingSource.Current;
                SalaryDS.SALBASNDRow rs = r.Row as SalaryDS.SALBASNDRow;
                ptxSalcode.Text = rs.SAL_CODE;
                if (rs.A_TYPE) txtAmt.Text = "0";
                else txtAmt.Text = rs.P_AMT.ToString();
                //txtAmt.Focus();
            }
        }

        private void fullDataCtrl1_AfterQuery(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            GridBind();
        }

        private void fullDataCtrl1_AfterShow(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            GridBind();
        }
        void GridBind()
        {
            foreach (var itm in this.salaryDS.WAGEDD)
            {
                itm.AMT = JBModule.Data.CDecryp.Number(itm.AMT);
            }
            this.salaryDS.WAGEDD.AcceptChanges();
        }

    }
}
