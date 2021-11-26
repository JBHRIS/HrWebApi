using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace JBHR.Bas
{
    public partial class FRM14 : JBControls.JBForm
    {
        private string delNobr = "";

        public FRM14()
        {
            InitializeComponent();
        }

        private void FRM14_Load(object sender, EventArgs e)
        {
            this.oilSubsidyTypeTableAdapter.Fill(this.basDS.OilSubsidyType);
            this.doorGuardTableAdapter.Fill(this.basDS.DoorGuard);
            this.dATAGROUPTableAdapter.Fill(this.sysDS.DATAGROUP);
            Sal.Function.SetAvaliableVBase(this.basDS.V_BASE);
            this.rETCHOOTableAdapter.Fill(this.basDS.RETCHOO);
            this.dEPTATableAdapter.Fill(this.basDS.DEPTA, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN);
            this.oUTCDTableAdapter.Fill(this.basDS.OUTCD);
            this.hOLICDTableAdapter.Fill(this.basDS.HOLICD,MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN);
            this.oTRATECDTableAdapter.Fill(this.basDS.OTRATECD);
            this.tTSCDTableAdapter.Fill(this.basDS.TTSCD, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN);
            this.eMPCDTableAdapter.Fill(this.basDS.EMPCD);
            this.wORKCDTableAdapter.Fill(this.basDS.WORKCD);
            this.jOBSTableAdapter.Fill(this.basDS.JOBS, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN);
            this.sALTYCDTableAdapter.Fill(this.basDS.SALTYCD);
            this.dITableAdapter.Fill(this.basDS.DI);
            this.rOTETTableAdapter.Fill(this.basDS.ROTET, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN);
            this.jOBLTableAdapter.Fill(this.basDS.JOBL, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN);
            this.jOBTableAdapter.Fill(this.basDS.JOB, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN);
            this.dEPTSTableAdapter.Fill(this.basDS.DEPTS, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN);
            this.dEPTTableAdapter.Fill(this.basDS.DEPT, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN); 
            this.cOMPTableAdapter.Fill(this.basDS.COMP);
            this.tTSCODETableAdapter.Fill(this.basDS.TTSCODE);
            this.bASETTSTableAdapter.FillByNOBR(this.basDS.BASETTS, "");

            //必須經過查詢之後才能新增，因為在有基本資料的情況下，才允許新增異動。
            fullDataCtrl1.bnAddEnable = false;

            BasDataClassesDataContext db = new BasDataClassesDataContext();
            var u_prg = (from c in db.U_PRGID where c.USER_ID.Trim() == MainForm.USER_ID && c.PROG.Trim().ToLower() == this.Name.ToLower() select c).FirstOrDefault();
            if (u_prg != null)
            {
                fullDataCtrl1.bnEditEnable = u_prg.EDIT;
                fullDataCtrl1.bnDelEnable = u_prg.DELE;
                fullDataCtrl1.bnExportEnable = u_prg.PRINT_;
            }
            fullDataCtrl1.WhereCmd = Sal.Function.GetFilterCmdByNobr("BASETTS.NOBR");
            fullDataCtrl1.DataAdapter = bASETTSTableAdapter;
            fullDataCtrl1.Init_Ctrls();
        }

        private void fullDataCtrl1_AfterShow(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            BasDataClassesDataContext db = new BasDataClassesDataContext();
            //經過查詢確定有資料之後，新增功能才會開啟
            if (bASETTSBindingSource.Count > 0) fullDataCtrl1.bnAddEnable = true;
            else fullDataCtrl1.bnAddEnable = false;
            var u_prg = (from c in db.U_PRGID where c.USER_ID.Trim() == MainForm.USER_ID && c.PROG.Trim().ToLower() == this.Name.ToLower() select c).FirstOrDefault();
            if (u_prg != null)
            {
                fullDataCtrl1.bnAddEnable &= u_prg.ADD_;
            }


            //if (!MainForm.MANGSUPER)
            //{
            //    DataTable dt = (bASETTSBindingSource.DataSource as DataSet).Tables[bASETTSBindingSource.DataMember];
            //    foreach (var row in dt.AsEnumerable())
            //    {
            //        var data = (from c in db.V_BASE where c.NOBR.Trim() == row["nobr"].ToString().Trim() && c.SALADR == MainForm.WORKADR select c).FirstOrDefault();
            //        if (data == null)
            //        {
            //            row.Delete();
            //        }
            //    }

            //    dt.AcceptChanges();
            //}

            fullDataCtrl1.Init_Ctrls();
        }

        private void fullDataCtrl1_BeforeAdd(object sender, JBControls.FullDataCtrl.BeforeEventArgs e)
        {
            BASETTSD basettsd = new BASETTSD();
            basettsd.Owner = this;
            basettsd.basDS.BASETTS.Clear();
            basettsd.nobr = (bASETTSBindingSource.Current as DataRowView)["nobr"].ToString();
            BasDS.BASETTSRow dataRow = (from c in basDS.BASETTS where new DateTime(9999, 12, 31) >= c.ADATE && new DateTime(9999, 12, 31) <= c.DDATE && c.NOBR.Trim().ToLower() == basettsd.nobr.Trim().ToLower() select c).FirstOrDefault();
            if (!new string[] { "1", "4", "6" }.Contains(dataRow.TTSCODE))
            {
                MessageBox.Show("此員工的狀態不可異動");
                e.Cancel = true;
                return;
            }
            basettsd.basDS1.BASETTS.ImportRow(dataRow);
            basettsd.baseFDC.bnEdit_Click(null, null);
            basettsd.basettsFDC.bnAdd_Click(null, null);
            if (basettsd.ShowDialog() == DialogResult.OK)
            {
                //存好之後，重新撈過資料來更新 gridview 的顯示
                this.basDS.BASETTS.Clear();
                this.basDS.BASETTS.Load(new JBModule.Data.CSQL(bASETTSTableAdapter.Connection).GetDataTable(fullDataCtrl1.RecentQuerySql).CreateDataReader());
            }

            for (int i = 0; i < bASETTSBindingSource.Count; i++)
            {
                if (((DataRowView)bASETTSBindingSource[i])["nobr"].ToString().ToLower().Trim() == basettsd.nobr.ToLower().Trim())
                {
                    if (Convert.ToDateTime(((DataRowView)bASETTSBindingSource[i])["ddate"]).Date == Convert.ToDateTime("9999/12/31"))
                    {
                        bASETTSBindingSource.Position = i;
                    }
                }
            }

            e.Cancel = true;
        }

        private void fullDataCtrl1_BeforeEdit(object sender, JBControls.FullDataCtrl.BeforeEventArgs e)
        {
            BASETTSD basettsd = new BASETTSD();
            basettsd.Owner = this;
            basettsd.basDS.BASETTS.Clear();
            basettsd.nobr = (bASETTSBindingSource.Current as DataRowView)["nobr"].ToString();
            basettsd.basDS1.BASETTS.ImportRow((bASETTSBindingSource.Current as DataRowView).Row);

            int curr_index = dataGridViewEx1.SelectedRows[0].Index;

            basettsd.baseFDC.bnEdit_Click(null, null);
            basettsd.basettsFDC.bnEdit_Click(null, null);

            if (basettsd.ShowDialog() == DialogResult.OK)
            {
                //存好之後，重新撈過資料來更新 gridview 的顯示
                this.basDS.BASETTS.Clear();
                this.basDS.BASETTS.Load(new JBModule.Data.CSQL(bASETTSTableAdapter.Connection).GetDataTable(fullDataCtrl1.RecentQuerySql).CreateDataReader());
            }
            if (dataGridViewEx1.Rows.Count > curr_index)
                dataGridViewEx1.Rows[curr_index].Selected = true;
            e.Cancel = true;
        }

        private void dataGridViewEx1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void fullDataCtrl1_AfterExport(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            DataView dv = ((sender as JBControls.FullDataCtrl).DataSource.DataSource as DataSet).Tables[(sender as JBControls.FullDataCtrl).DataSource.DataMember].DefaultView;
            dv.RowFilter = (sender as JBControls.FullDataCtrl).DataSource.Filter;

            JBModule.Data.CNPOI.RenderDataViewToExcel(dv, "C:\\TEMP\\" + this.Name + ".xls");
            System.Diagnostics.Process.Start("C:\\TEMP\\" + this.Name + ".xls");
        }

        private void fullDataCtrl1_AfterQuery(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            //BasDataClassesDataContext db = new BasDataClassesDataContext();
            //經過查詢確定有資料之後，新增功能才會開啟
            //if (bASETTSBindingSource.Count > 0) fullDataCtrl1.bnAddEnable = true;
            //else fullDataCtrl1.bnAddEnable = false;
            //var u_prg = (from c in db.U_PRGID where c.USER_ID.Trim() == MainForm.USER_ID && c.PROG.Trim().ToLower() == this.Name.ToLower() select c).FirstOrDefault();
            //if (u_prg != null)
            //{
            //    fullDataCtrl1.bnAddEnable &= u_prg.ADD_;
            //}


            //if (!MainForm.MANGSUPER)
            //{
            //    DataTable dt = (bASETTSBindingSource.DataSource as DataSet).Tables[bASETTSBindingSource.DataMember];
            //    foreach (var row in dt.AsEnumerable())
            //    {
            //        var data = (from c in db.V_BASE where c.NOBR.Trim() == row["nobr"].ToString().Trim() && c.SALADR == MainForm.WORKADR select c).FirstOrDefault();
            //        if (data == null)
            //        {
            //            row.Delete();
            //        }
            //    }

            //    dt.AcceptChanges();
            //}

            //fullDataCtrl1.Init_Ctrls();
        }

        private void fullDataCtrl1_AfterDel(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            if (delNobr.Trim().Length > 0)
            {
                FRM12DataClassesDataContext db = new FRM12DataClassesDataContext();
                IEnumerable<BASETTS> basetts = from c in db.BASETTS
                                               where c.NOBR.Trim().ToLower() == delNobr
                                               orderby c.ADATE descending
                                               select c;

                for (int i = 0; i < basetts.Count(); i++)
                {
                    if (i == 0) basetts.ElementAt(i).DDATE = Convert.ToDateTime("9999/12/31");
                    else
                    {
                        basetts.ElementAt(i).DDATE = basetts.ElementAt(i - 1).ADATE.AddDays(-1).Date;
                    }
                }

                db.SubmitChanges();

                if (fullDataCtrl1.RecentQuerySql.Trim().Length > 0)
                {
                    try
                    {
                        BasDataClassesDataContext dbBas = new BasDataClassesDataContext();
                        basDS.BASETTS.Load(new JBModule.Data.CSQL(bASETTSTableAdapter.Connection).GetDataTable(fullDataCtrl1.RecentQuerySql).CreateDataReader());
                        if (!MainForm.MANGSUPER)
                        {
                            DataTable dt = (bASETTSBindingSource.DataSource as DataSet).Tables[bASETTSBindingSource.DataMember];
                            foreach (var row in dt.AsEnumerable())
                            {
                                var data = (from c in dbBas.V_BASE where c.NOBR.Trim() == row["nobr"].ToString().Trim() && c.SALADR == MainForm.WORKADR select c).FirstOrDefault();
                                if (data == null)
                                {
                                    row.Delete();
                                }
                            }

                            dt.AcceptChanges();
                        }
                    }
                    catch { }
                }
                delNobr = "";
            }
        }

        private void fullDataCtrl1_BeforeDel(object sender, JBControls.FullDataCtrl.BeforeEventArgs e)
        {
            if (!Sal.Function.CanModify(e.Values["nobr"].ToString()))
            {
                e.Cancel = true;
                MessageBox.Show("你沒有刪除該使用者資料的權限", Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (Convert.ToDateTime(e.Values["ddate"]).Date != Convert.ToDateTime("9999/12/31").Date)
            {
                e.Cancel = true;
                MessageBox.Show(Resources.Bas.DontDelThisTTS, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (basDS.BASETTS.Count == 1 && e.Values["ttscode"].ToString() == "1")
            {
                e.Cancel = true;
                MessageBox.Show(Resources.Bas.DontDelThisTTS, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            delNobr = e.Values["nobr"].ToString().Trim();
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            BASETTSI frm = new BASETTSI();
            frm.ShowDialog();
        }
    }
}
