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
    public partial class FRM46E : JBControls.JBForm
    {
        SalaryMDDataContext smd = new SalaryMDDataContext();
        string del_nobr = "";
        string del_salcode = "";
        public FRM46E()
        {
            InitializeComponent();
        }

        private void FRM46_Load(object sender, EventArgs e)
        {
            this.sALCODETableAdapter.Fill(this.salaryDS.SALCODE);
            this.sALBASD_TMPTableAdapter.FillByInit(this.salaryDS.SALBASD_TMP);

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

            fullDataCtrl1.DataAdapter = this.sALBASD_TMPTableAdapter;
            fullDataCtrl1.Init_Ctrls();
        }

        private void fullDataCtrl1_AfterDel(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            if (!e.Error)
            {
                CDataLog.Save(this.Name, MainForm.USER_ID, DateTime.Now, fullDataCtrl1.BackupDataTable);
                ReSetSalbasdOfNobrSalcode(del_nobr, del_salcode);
            }
        }

        private void fullDataCtrl1_BeforeDel(object sender, JBControls.FullDataCtrl.BeforeEventArgs e)
        {
            if (!Sal.Function.CanModify(ptxNobr.Text))
            {
                e.Cancel = true;
                MessageBox.Show(Resources.Sal.NonAccessableRule, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                del_nobr = e.Values["nobr"].ToString();
                del_salcode = e.Values["sal_code"].ToString();
                this.salaryDS.SALBASD.AcceptChanges();
            }
        }

        private void fullDataCtrl1_AfterAdd(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            ptxNobr.Focus();
            txtAdate.Text = Sal.Core.SalaryDate.DateString();
            //txtDdate.Text = Sal.Core.SalaryDate.DateString(new DateTime(9999, 12, 31));
        }

        private void fullDataCtrl1_AfterEdit(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            txtAmt.Focus();
            ptxNobr.Enabled = false;
            ptxSalcode.Enabled = false;
        }

        private void fullDataCtrl1_AfterQuery(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            GridBind();
        }

        private void fullDataCtrl1_AfterSave(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            if (!e.Error)//發生錯誤就略過
            {
                ReSetSalbasdOfNobrSalcode(ptxNobr.Text, ptxSalcode.Text);
            }
            e.Values["amt"] = JBModule.Data.CDecryp.Number(Convert.ToDecimal(e.Values["amt"]));

            if (!e.Error)//發生錯誤就略過
            {
                this.salaryDS.SALBASD.AcceptChanges();
            }
        }

        private void fullDataCtrl1_BeforeSave(object sender, JBControls.FullDataCtrl.BeforeEventArgs e)
        {
            if (!Sal.Function.CanModify(ptxNobr.Text))
            {
                e.Cancel = true;
                MessageBox.Show(Resources.Sal.NonAccessableRule, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            if (!e.Cancel)
            {
                e.Values["kEy_MaN"] = MainForm.USER_NAME;
                e.Values["KeY_dAtE"] = DateTime.Now;
                e.Values["amt"] = JBModule.Data.CEncrypt.Number(Convert.ToDecimal(e.Values["amt"]));
            }
        }

        private void fullDataCtrl1_AfterExport(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            DataView dv = ((sender as JBControls.FullDataCtrl).DataSource.DataSource as DataSet).Tables[(sender as JBControls.FullDataCtrl).DataSource.DataMember].DefaultView;
            dv.RowFilter = (sender as JBControls.FullDataCtrl).DataSource.Filter;

            JBModule.Data.CNPOI.RenderDataViewToExcel(dv, "C:\\TEMP\\" + this.Name + ".xls");
            System.Diagnostics.Process.Start("C:\\TEMP\\" + this.Name + ".xls");
        }


        private void ptxNobr_QueryCompleted(object sender, JBControls.PopupTextBox.QueryCompletedArgs e)
        {
            //if (e.HasData) txtAdate.Focus();
        }
        private void ptxSalcode_QueryCompleted(object sender, JBControls.PopupTextBox.QueryCompletedArgs e)
        {

        }
        void ReSetSalbasdOfNobrSalcode(string nobr, string salcode)
        {

            var salbasd_of_NobrSalcode = from salbasd_row in smd.SALBASD
                                         where salbasd_row.NOBR.Trim().Equals(nobr) && salbasd_row.SAL_CODE.Trim().Equals(salcode)
                                         orderby salbasd_row.ADATE descending
                                         select salbasd_row;
            DateTime dt = new DateTime(9999, 12, 31);
            foreach (var itm in salbasd_of_NobrSalcode)
            {
                var dataRow = salaryDS.SALBASD.FindByADATENOBRSAL_CODE(itm.ADATE, itm.NOBR, itm.SAL_CODE);
                itm.DDATE = dt;
                if (dataRow != null) dataRow.DDATE = dt;
                dt = itm.ADATE.AddDays(-1);
            }
            smd.SubmitChanges();
        }
        void GridBind()
        {
            foreach (var itm in this.salaryDS.SALBASD) itm.AMT = JBModule.Data.CDecryp.Number(itm.AMT);
            this.salaryDS.SALBASD.AcceptChanges();
        }

        //bool CanModify(string nobr)
        //{
        //    var sql = from b in smd.BASETTS
        //              where DateTime.Now.Date >= b.ADATE && DateTime.Now.Date <= b.DDATE
        //              && (b.SALADR == MainForm.WORKADR || MainForm.PROCSUPER) && b.NOBR == nobr
        //              select b;
        //    return sql.Any();
        //}

        private void fullDataCtrl1_AfterShow(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            GridBind();
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            FRM46EI frm = new FRM46EI();
            frm.ShowDialog();
        }
    }
}
