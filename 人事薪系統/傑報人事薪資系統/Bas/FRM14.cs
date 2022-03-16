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
            // TODO: 這行程式碼會將資料載入 'basDS.JOBO' 資料表。您可以視需要進行移動或移除。
            this.jOBOTableAdapter.Fill(this.basDS.JOBO);
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
                JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
                JBHRIS.BLL.Bas.BasettsFixDdateDao basettsDao = new JBHRIS.BLL.Bas.BasettsFixDdateDao(db.Connection);
                basettsDao.FixData(delNobr);

                //if (fullDataCtrl1.RecentQuerySql.Trim().Length > 0)
                //{
                //    try
                //    {
                //        BasDataClassesDataContext dbBas = new BasDataClassesDataContext();
                //        basDS.BASETTS.Load(new JBModule.Data.CSQL(bASETTSTableAdapter.Connection).GetDataTable(fullDataCtrl1.RecentQuerySql).CreateDataReader());
                //        if (!MainForm.MANGSUPER)
                //        {
                //            DataTable dt = (bASETTSBindingSource.DataSource as DataSet).Tables[bASETTSBindingSource.DataMember];
                //            foreach (var row in dt.AsEnumerable())
                //            {
                //                var data = (from c in dbBas.V_BASE where c.NOBR.Trim() == row["nobr"].ToString().Trim() && c.SALADR == MainForm.WORKADR select c).FirstOrDefault();
                //                if (data == null)
                //                {
                //                    row.Delete();
                //                }
                //            }

                //            dt.AcceptChanges();
                //        }
                //    }
                //    catch { }
                //}
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
            JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
            var sql = from a in db.BASETTS where a.NOBR == e.Values["NOBR"].ToString() select a.NOBR;
            if (sql.Count() == 1)
            {
                e.Cancel = true;
                MessageBox.Show(Resources.Bas.DontDelThisTTS, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            delNobr = e.Values["nobr"].ToString().Trim();
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            JBControls.U_IMPORT frm = new JBControls.U_IMPORT();
            JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
            frm.Text = "人事異動資料批次匯入";
            frm.Allow_Repeat_Delete = true;
            frm.Allow_Repeat_Ignore = true;
            frm.Allow_Repeat_Override = true;

            frm.FieldForm = new BASETTSI1();
            frm.DataTransfer = new ImportTransferToBasetts();

            frm.DataTransfer.CheckData = new Dictionary<string, List<JBControls.CheckImportData>>();
            frm.DataTransfer.CheckData.Add("員工編號", this.basDS.V_BASE.Select(p => new JBControls.CheckImportData { DisplayCode = p.NOBR, RealCode = p.NOBR, DisplayName = p.NAME_C }).ToList());
            var TtsFieldList = new List<JBControls.CheckImportData>();

            var cid = new JBControls.CheckImportData { DisplayCode = "公司別", DisplayName = "公司別", RealCode = "COMP" };
            TtsFieldList.Add(cid);
            frm.DataTransfer.CheckData.Add(cid.DisplayName, this.basDS.COMP.Select(p => new JBControls.CheckImportData { DisplayCode = p.COMP, RealCode = p.COMP, DisplayName = p.COMPNAME }).ToList());

            cid = new JBControls.CheckImportData { DisplayCode = "編制部門", DisplayName = "編制部門", RealCode = "DEPT" };
            TtsFieldList.Add(cid);
            frm.DataTransfer.CheckData.Add(cid.DisplayName, this.basDS.DEPT.Select(p => new JBControls.CheckImportData { DisplayCode = p.D_NO_DISP, RealCode = p.D_NO, DisplayName = p.D_NAME }).ToList());

            cid = new JBControls.CheckImportData { DisplayCode = "成本部門", DisplayName = "成本部門", RealCode = "DEPTS" };
            TtsFieldList.Add(cid);
            frm.DataTransfer.CheckData.Add(cid.DisplayName, this.basDS.DEPTS.Select(p => new JBControls.CheckImportData { DisplayCode = p.D_NO_DISP, RealCode = p.D_NO, DisplayName = p.D_NAME }).ToList());

            cid = new JBControls.CheckImportData { DisplayCode = "簽核部門", DisplayName = "簽核部門", RealCode = "DEPTM" };
            TtsFieldList.Add(cid);
            frm.DataTransfer.CheckData.Add(cid.DisplayName, this.basDS.DEPTA.Select(p => new JBControls.CheckImportData { DisplayCode = p.D_NO_DISP, RealCode = p.D_NO, DisplayName = p.D_NAME }).ToList());

            cid = new JBControls.CheckImportData { DisplayCode = "職稱", DisplayName = "職稱", RealCode = "JOB" };
            TtsFieldList.Add(cid);
            frm.DataTransfer.CheckData.Add(cid.DisplayName, this.basDS.JOB.Select(p => new JBControls.CheckImportData { DisplayCode = p.JOB_DISP, RealCode = p.JOB, DisplayName = p.JOB_NAME }).ToList());

            cid = new JBControls.CheckImportData { DisplayCode = "職等", DisplayName = "職等", RealCode = "JOBL" };
            TtsFieldList.Add(cid);
            frm.DataTransfer.CheckData.Add(cid.DisplayName, this.basDS.JOBL.Select(p => new JBControls.CheckImportData { DisplayCode = p.JOBL_DISP, RealCode = p.JOBL, DisplayName = p.JOB_NAME }).ToList());

            cid = new JBControls.CheckImportData { DisplayCode = "職類", DisplayName = "職類", RealCode = "JOBS" };
            TtsFieldList.Add(cid);
            frm.DataTransfer.CheckData.Add(cid.DisplayName, this.basDS.JOBS.Select(p => new JBControls.CheckImportData { DisplayCode = p.JOBS_DISP, RealCode = p.JOBS, DisplayName = p.JOB_NAME }).ToList());

            cid = new JBControls.CheckImportData { DisplayCode = "職級", DisplayName = "職級", RealCode = "JOBO" };
            TtsFieldList.Add(cid);
            frm.DataTransfer.CheckData.Add(cid.DisplayName, this.basDS.JOBO.Select(p => new JBControls.CheckImportData { DisplayCode = p.JOBO, RealCode = p.JOB_NAME, DisplayName = p.JOB_NAME }).ToList());

            cid = new JBControls.CheckImportData { DisplayCode = "行事曆", DisplayName = "行事曆", RealCode = "HOLI_CODE" };
            TtsFieldList.Add(cid);
            frm.DataTransfer.CheckData.Add(cid.DisplayName, db.HOLICD.ToList().Select(p => new JBControls.CheckImportData { DisplayCode = p.HOLI_CODE_DISP, RealCode = p.HOLI_CODE, DisplayName = p.HOLI_NAME }).ToList());

            cid = new JBControls.CheckImportData { DisplayCode = "直間接", DisplayName = "直間接", RealCode = "DI" };
            TtsFieldList.Add(cid);
            frm.DataTransfer.CheckData.Add(cid.DisplayName, CodeFunction.GetMtCode("DI").Select(p => new JBControls.CheckImportData { DisplayCode = p.Key, RealCode = p.Key, DisplayName = p.Value }).ToList());

            cid = new JBControls.CheckImportData { DisplayCode = "輪班別", DisplayName = "輪班別", RealCode = "ROTET" };
            TtsFieldList.Add(cid);
            frm.DataTransfer.CheckData.Add(cid.DisplayName, this.basDS.ROTET.Select(p => new JBControls.CheckImportData { DisplayCode = p.ROTET_DISP, RealCode = p.ROTET, DisplayName = p.ROTETNAME }).ToList());

            //cid = new JBControls.CheckImportData { DisplayCode = "責任區別", DisplayName = "責任區別", RealCode = "CARCD" };
            //TtsFieldList.Add(cid);
            //frm.DataTransfer.CheckData.Add(cid.DisplayName, CodeFunction.GetResponsibilityType().Select(p => new JBControls.CheckImportData { DisplayCode = p.Key, RealCode = p.Key, DisplayName = p.Value }).ToList());

            //cid = new JBControls.CheckImportData { DisplayCode = "成本別", DisplayName = "成本別", RealCode = "OilSubsidy" };
            //TtsFieldList.Add(cid);
            //frm.DataTransfer.CheckData.Add(cid.DisplayName, CodeFunction.GetCostType().Select(p => new JBControls.CheckImportData { DisplayCode = p.Key, RealCode = p.Key, DisplayName = p.Value }).ToList());

            cid = new JBControls.CheckImportData { DisplayCode = "資料群組", DisplayName = "資料群組", RealCode = "SALADR" };
            TtsFieldList.Add(cid);
            frm.DataTransfer.CheckData.Add(cid.DisplayName, CodeFunction.GetDatagroup().Select(p => new JBControls.CheckImportData { DisplayCode = p.Key, RealCode = p.Key, DisplayName = p.Value }).ToList());

            cid = new JBControls.CheckImportData { DisplayCode = "異動原因", DisplayName = "異動原因", RealCode = "TTSCD" };
            TtsFieldList.Add(cid);
            frm.DataTransfer.CheckData.Add(cid.DisplayName, this.basDS.TTSCD.Select(p => new JBControls.CheckImportData { DisplayCode = p.TTSCD_DISP, RealCode = p.TTSCD, DisplayName = p.TTSNAME }).ToList());

            cid = new JBControls.CheckImportData { DisplayCode = "離職原因", DisplayName = "離職原因", RealCode = "OUTCD" };
            TtsFieldList.Add(cid);
            frm.DataTransfer.CheckData.Add(cid.DisplayName, this.basDS.OUTCD.Select(p => new JBControls.CheckImportData { DisplayCode = p.OUTCD, RealCode = p.OUTCD, DisplayName = p.OUTNAME }).ToList());

            cid = new JBControls.CheckImportData { DisplayCode = "加班比率", DisplayName = "加班比率", RealCode = "CALOT" };
            TtsFieldList.Add(cid);
            frm.DataTransfer.CheckData.Add(cid.DisplayName, db.OTRATECD.Select(p => new JBControls.CheckImportData { DisplayCode = p.OTRATE_CODE, RealCode = p.OTRATE_CODE, DisplayName = p.OTRATE_NAME }).ToList());

            cid = new JBControls.CheckImportData { DisplayCode = "退休金制度", DisplayName = "退休金制度", RealCode = "RETCHOO" };
            TtsFieldList.Add(cid);
            frm.DataTransfer.CheckData.Add(cid.DisplayName, db.MTCODE.Where(p=>p.CATEGORY == "RETCHOO").Select(p => new JBControls.CheckImportData { DisplayCode = p.CODE, RealCode = p.CODE, DisplayName = p.NAME }).ToList());

            cid = new JBControls.CheckImportData { DisplayCode = "工作地", DisplayName = "工作地", RealCode = "WORKCD" };
            TtsFieldList.Add(cid);
            frm.DataTransfer.CheckData.Add(cid.DisplayName, db.WORKCD.Select(p => new JBControls.CheckImportData { DisplayCode = p.WORK_ADDR, RealCode = p.WORK_CODE, DisplayName = p.WORK_ADDR }).ToList());


            cid = new JBControls.CheckImportData { DisplayCode = "備註", DisplayName = "備註", RealCode = "MENO" };
            TtsFieldList.Add(cid);
            //frm.DataTransfer.CheckData.Add(cid.DisplayName, null);

            frm.DataTransfer.CheckData.Add("異動欄位", TtsFieldList);

            var TtscodeList = new List<JBControls.CheckImportData>();
            var ttscodeData = CodeFunction.GetMtCode("TTSCODE").Where(p => p.Key.CompareTo("1") > 0).OrderByDescending(p => p.Key).Select(p => new JBControls.CheckImportData { DisplayCode = p.Value, DisplayName = p.Value, RealCode = p.Key }).ToList();
            frm.DataTransfer.CheckData.Add("異動代碼", ttscodeData);

            frm.DataTransfer.ColumnList = new Dictionary<string, Type>();
            frm.DataTransfer.ColumnList.Add("員工編號", typeof(string));
            frm.DataTransfer.ColumnList.Add("員工姓名", typeof(string));
            frm.DataTransfer.ColumnList.Add("異動日期", typeof(DateTime));
            frm.DataTransfer.ColumnList.Add("異動狀態", typeof(string));
            frm.DataTransfer.ColumnList.Add("異動欄位1", typeof(string));
            frm.DataTransfer.ColumnList.Add("異動前資料1", typeof(string));
            frm.DataTransfer.ColumnList.Add("異動後資料1", typeof(string));
            frm.DataTransfer.ColumnList.Add("異動欄位2", typeof(string));
            frm.DataTransfer.ColumnList.Add("異動前資料2", typeof(string));
            frm.DataTransfer.ColumnList.Add("異動後資料2", typeof(string));
            frm.DataTransfer.ColumnList.Add("異動欄位3", typeof(string));
            frm.DataTransfer.ColumnList.Add("異動前資料3", typeof(string));
            frm.DataTransfer.ColumnList.Add("異動後資料3", typeof(string));
            frm.DataTransfer.ColumnList.Add("異動欄位4", typeof(string));
            frm.DataTransfer.ColumnList.Add("異動前資料4", typeof(string));
            frm.DataTransfer.ColumnList.Add("異動後資料4", typeof(string));
            frm.DataTransfer.ColumnList.Add("異動欄位5", typeof(string));
            frm.DataTransfer.ColumnList.Add("異動前資料5", typeof(string));
            frm.DataTransfer.ColumnList.Add("異動後資料5", typeof(string));
            frm.DataTransfer.ColumnList.Add("異動欄位6", typeof(string));
            frm.DataTransfer.ColumnList.Add("異動前資料6", typeof(string));
            frm.DataTransfer.ColumnList.Add("異動後資料6", typeof(string));
            frm.DataTransfer.ColumnList.Add("錯誤註記", typeof(string));

            frm.DataTransfer.UnMustColumnList = new List<string>();


            frm.ShowDialog();
        }
    }
}
