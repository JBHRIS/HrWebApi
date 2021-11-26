using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using JBHR.Wel;

namespace JBHR.TRA
{
    public partial class FRM95 : JBControls.JBForm
    {
        CheckControl cc;
        string tr_guid = "";
        public FRM95()
        {
            InitializeComponent();
        }
        List<string> OldNobrList = new List<string>();
        private void FRM95_Load(object sender, EventArgs e)
        {
            // TODO:  這行程式碼會將資料載入 'basDS.BASE' 資料表。您可以視需要進行移動或移除。
            //this.bASETableAdapter.Fill(this.basDS.BASE);
            // TODO:  這行程式碼會將資料載入 'traDS1.TRCOSP' 資料表。您可以視需要進行移動或移除。
            this.tRCOSPTableAdapter.Fill(traDS1.TRCOSP);
            // TODO:  這行程式碼會將資料載入 'traDS1.TRASSCODE' 資料表。您可以視需要進行移動或移除。
            this.tRASSCODETableAdapter.Fill(this.traDS1.TRASSCODE);
            // TODO:  這行程式碼會將資料載入 'traDS.TRCOSC' 資料表。您可以視需要進行移動或移除。
            this.tRCOSCTableAdapter.Fill(this.traDS1.TRCOSC);
            // TODO:  這行程式碼會將資料載入 'traDS.TR_INOUT' 資料表。您可以視需要進行移動或移除。
            this.tR_INOUTTableAdapter.Fill(this.traDS1.TR_INOUT);
            // TODO:  這行程式碼會將資料載入 'traDS.TRCOMP' 資料表。您可以視需要進行移動或移除。
            this.tRCOMPTableAdapter.Fill(this.traDS1.TRCOMP);
            // TODO:  這行程式碼會將資料載入 'traDS.TRTYPE' 資料表。您可以視需要進行移動或移除。
            this.tRTYPETableAdapter.Fill(this.traDS1.TRTYPE);
            this.dEPTTableAdapter.Fill(basDS.DEPT, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN);
            
            SystemFunction.SetComboBoxItems(cbDEPT, CodeFunction.GetDept(), true, false, true);                  //部門
            SystemFunction.SetComboBoxItems(cbTRCOMP, CodeFunction.GetTRCOMP(), true, false, true);              //訓練機構
            SystemFunction.SetComboBoxItems(cbTR_INOUT, CodeFunction.GetMtCode("TR_INOUT"), true, false, true);  //訓練型式
            SystemFunction.SetComboBoxItems(cbTRTYPE, CodeFunction.GetTRTYPE(), true, false, true);              //課程類別
            SystemFunction.SetComboBoxItems(cbTRASSCODE, CodeFunction.GetTRASSCODE(), true, false, true);        //評核方式
            //this.tRCOSFTableAdapter.Fill(this.traDS.TRCOSF);
            #region 必要欄位檢察
            cc = new CheckControl();
            cc.AddControl(cbTRCOMP);      //訓練機構
            cc.AddControl(cbTR_INOUT);    //訓練型式
            cc.AddControl(cbTRTYPE);      //課程類別
            cc.AddControl(cbTRASSCODE);   //評核方式
            cc.AddControl(cbDEPT);        //開課部門

            #endregion         
            //this.tRTYPETableAdapter.Fill(this.traDS.TRTYPE);         
            //this.tRASSCODETableAdapter.Fill(this.traDS.TRASSCODE);         
            //this.tRCOMPTableAdapter.Fill(this.traDS.TRCOMP);         
            //this.tR_INOUTTableAdapter.Fill(this.traDS.TR_INOUT);    
            //this.tRCOSFTableAdapter.Fill(this.traDS.TRCOSF);
            JBModule.Data.Linq.HrDBDataContext db1 = new JBModule.Data.Linq.HrDBDataContext();

            dataGridView1.DataSource = from a in db1.BASE where 1 == 0 select new { 工號 = a.NOBR, 姓名 = a.NAME_C };

            fdc.DataAdapter = tRCOSCTableAdapter;
            WelDataClassesDataContext db = new WelDataClassesDataContext();
            var u_prg = (from c in db.U_PRGID where c.USER_ID.Trim() == MainForm.USER_ID && c.PROG.Trim().ToLower() == this.Name.ToLower() select c).FirstOrDefault();
            if (u_prg != null)
            {
                fdc.bnAddEnable = u_prg.ADD_;
                fdc.bnEditEnable = u_prg.EDIT;
                fdc.bnDelEnable = u_prg.DELE;
                fdc.bnExportEnable = u_prg.PRINT_;
            }

            //fdc.WhereCmd = Sal.Function.GetFilterCmd("TRCOSC");
            fdc.Init_Ctrls();
        }

        private void fdc_AfterDel(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            if (!e.Error)
            {
                JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
                var sql = from a in db.TRCOSP
                          where a.COURSE == tr_guid
                          select a;
                if (sql.Any())
                {
                    db.TRCOSP.DeleteAllOnSubmit(sql);
                    db.SubmitChanges();
                }
                CDataLog.Save(this.Name, MainForm.USER_ID, DateTime.Now, fdc.BackupDataTable);
            }
        }

        private void fdc_BeforeSave(object sender, JBControls.FullDataCtrl.BeforeEventArgs e)
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
            JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
            if (fdc.EditType == JBControls.FullDataCtrl.EEditType.Add)
            {
                var sql = from a in db.TRCOSC where a.CODE == txtCODE.Text select 1;
                if (sql.Any())
                {
                    MessageBox.Show("重複課程代碼。", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    e.Cancel = true;
                    return;
                }
            }
            else if (fdc.EditType == JBControls.FullDataCtrl.EEditType.Modify)
            {
                tr_guid = dgv.CurrentRow.Cells["GUID"].Value.ToString();
                var sql = from a in db.TRCOSC where a.GUID != tr_guid && a.CODE == txtCODE.Text select 1;
                if (sql.Any())
                {
                    MessageBox.Show("重複課程代碼。", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    e.Cancel = true;
                    return;
                }
            }

            if (!e.Cancel)
            {
                if (fdc.EditType == JBControls.FullDataCtrl.EEditType.Add)
                {
                    e.Values["GUID"] = Guid.NewGuid().ToString();
                }
                e.Values["KEY_MAN"] = MainForm.USER_NAME;
                e.Values["KEY_DATE"] = DateTime.Now;
            }
        }

        private void fdc_AfterSave(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            if (!e.Error)
                CDataLog.Save(this.Name, MainForm.USER_ID, DateTime.Now, fdc.BackupDataTable);
        }

        private void fdc_AfterExport(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            //DataView dv = ((sender as JBControls.FullDataCtrl).DataSource.DataSource as DataSet).Tables[(sender as JBControls.FullDataCtrl).DataSource.DataMember].DefaultView;
            //dv.RowFilter = (sender as JBControls.FullDataCtrl).DataSource.Filter;

            //JBModule.Data.CNPOI.RenderDataViewToExcel(dv, "C:\\TEMP\\" + this.Name + ".xls");
            //System.Diagnostics.Process.Start("C:\\TEMP\\" + this.Name + ".xls");
        }

        private void fdc_AfterAdd(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            txtCODE.Focus();
            txtDATE_B.Text = Sal.Function.GetDate();
            txtDATE_E.Text = "9999/12/31";
        }

        private void fdc_BeforeDel(object sender, JBControls.FullDataCtrl.BeforeEventArgs e)
        {
            if (MessageBox.Show("課程及所有受訓人員的資料將一併刪除，刪除後不可復原，是否確定要執行？", "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.No)
            {
                e.Cancel = true;
                return;
            }
            tr_guid = dgv.CurrentRow.Cells["GUID"].Value.ToString();
        }

        private void txtOntime_Validating(object sender, CancelEventArgs e)
        {
            //if (!Sal.Function.ValidateTimeStringFormat(txtOntime.Text))
            //{
            //    errorProvider.SetError((Control)sender, Resources.Att.InputFormatNotCorrect);
            //}
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dgv.SelectedCells.Count > 0)
            {
                //FRM95A _FRM95A = new FRM95A();
                //_FRM95A.tr_corse_auto = int.Parse(dgv.CurrentRow.Cells["auto"].Value.ToString());
                //_FRM95A.ShowDialog();
                setOldNobrList();
                JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
                JBControls.MultiSelectionDialog msd = new JBControls.MultiSelectionDialog();
                var newBaseList = (from a in db.BASE
                                   join b in db.BASETTS on a.NOBR equals b.NOBR into temp1
                                   from b1 in temp1.DefaultIfEmpty()
                                   join c in db.DEPT on b1.DEPT equals c.D_NO
                                   where b1.DDATE >= DateTime.Now && b1.ADATE <= DateTime.Now
                                   //&& db.GetFilterByNobr(a.NOBR, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value
                                   && db.UserReadDataGroupList(MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Select(p => p.DATAGROUP).Contains(b1.SALADR)
                                   && !OldNobrList.Contains(a.NOBR)
                                   select new { 工號 = a.NOBR, 姓名 = a.NAME_C, 編制部門代碼 = c.D_NO_DISP, 編制部門名稱 = c.D_NAME }).ToList();
                msd.Source = newBaseList.CopyToDataTable();
                msd.Text = button1.Text;
                msd.ValueField = "工號";
                msd.ShowDialog();
                List<string> newNobrList = new List<string>();
                newNobrList = msd.SelectedValues;
                addNobrTrP(dgv.CurrentRow.Cells["GUID"].Value.ToString(), newNobrList);
                dgv_CellEnter(null, null);
            }
        }
        public void setOldNobrList()
        {
            OldNobrList = new List<string>();
            foreach (DataGridViewRow item in dataGridView1.Rows)
            {
                OldNobrList.Add(item.Cells["工號"].Value.ToString());
            }
        }
        public void addNobrTrP(string tr_GUID,List<string> nobrList)
        {
            traDS1TableAdapters.TRCOSPTableAdapter ta = new traDS1TableAdapters.TRCOSPTableAdapter();
            foreach (var nobr in nobrList)
            {
                var row = traDS1.TRCOSP.NewTRCOSPRow();

                row.SetRowDefaultValue(new List<string> { "AUTO"});
                row.NOBR = nobr;
                row.COURSE = tr_GUID;
                row.KEY_MAN = MainForm.USER_NAME;
                row.KEY_DATE = DateTime.Now;
                traDS1.TRCOSP.AddTRCOSPRow(row);
            }
            ta.Update(traDS1);
        }
        public void delNobrTrP(string tr_GUID, List<string> nobrList)
        {
            JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
            
            var rows = from a in db.TRCOSP
                        where nobrList.Contains(a.NOBR) && a.COURSE == tr_GUID
                        select a;
            if (rows.Any())
            {
                db.TRCOSP.DeleteAllOnSubmit(rows);
                db.SubmitChanges();
            }
        }

        private void plFV_Paint(object sender, PaintEventArgs e)
        {

        }

        public void filterGridView(string tr_guid)
        {
            //string filter = "課程名稱 = '" + tr_guid + "'";
            //((DataTable)dataGridView1.DataSource).DefaultView.RowFilter = filter;
            JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
            var sql = from a in db.TRCOSP
                      join b in db.BASE on a.NOBR equals b.NOBR
                      join c in db.BASETTS on a.NOBR equals c.NOBR
                      join d in db.DEPT on c.DEPT equals d.D_NO
                      where a.COURSE == tr_guid
                      && c.DDATE >= DateTime.Now && c.ADATE <= DateTime.Now
                      select new { 工號 = a.NOBR, 姓名 = b.NAME_C, 編制部門 = d.D_NAME };

            dataGridView1.DataSource = sql.ToList();
        }


        private void dgv_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            tr_guid = dgv.CurrentRow.Cells["GUID"].Value.ToString();
            filterGridView(tr_guid);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dgv.SelectedCells.Count > 0)
            {
                setOldNobrList();
                JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
                JBControls.MultiSelectionDialog msd = new JBControls.MultiSelectionDialog();
                var delBaseList = (from a in db.BASE
                                   join b in db.BASETTS on a.NOBR equals b.NOBR into temp1
                                   from b1 in temp1.DefaultIfEmpty()
                                   join c in db.DEPT on b1.DEPT equals c.D_NO
                                   where b1.DDATE >= DateTime.Now && b1.ADATE <= DateTime.Now
                                   //&& db.GetFilterByNobr(a.NOBR, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value
                                   && db.UserReadDataGroupList(MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Select(p => p.DATAGROUP).Contains(b1.SALADR)
                                   && OldNobrList.Contains(a.NOBR)
                                   select new { 工號 = a.NOBR, 姓名 = a.NAME_C, 編制部門代碼 = c.D_NO_DISP, 編制部門名稱 = c.D_NAME }).ToList();
                msd.Source = delBaseList.CopyToDataTable();
                msd.Text = button2.Text;
                msd.ValueField = "工號";
                msd.ShowDialog();
                List<string> newNobrList = new List<string>();
                newNobrList = msd.SelectedValues;
                delNobrTrP(dgv.CurrentRow.Cells["GUID"].Value.ToString(), newNobrList);
                dgv_CellEnter(null, null); 
            }
        }

        private void bnIMPORT_Click(object sender, EventArgs e)
        {
            JBControls.U_IMPORT frm = new JBControls.U_IMPORT();
            frm.Allow_Repeat_Delete = true;
            frm.Allow_Repeat_Ignore = true;
            frm.Allow_Repeat_Override = true;

            frm.FieldForm = new FRM95IN();
            frm.DataTransfer = new ImportTransferToTRCOSC();

            frm.DataTransfer.CheckData = new Dictionary<string, List<JBControls.CheckImportData>>();
            frm.DataTransfer.CheckData.Add("承辦單位", traDS1.TRCOMP.Select(p => new JBControls.CheckImportData { DisplayCode = p.TR_COMP_DISP, RealCode = p.TR_COMP, DisplayName = p.TR_COMP_NAME }).ToList());
            frm.DataTransfer.CheckData.Add("開課部門", basDS.DEPT.Select(p => new JBControls.CheckImportData { DisplayCode = p.D_NO_DISP, RealCode = p.D_NO, DisplayName = p.D_NAME }).ToList());
            frm.DataTransfer.CheckData.Add("課程類別", traDS1.TRTYPE.Select(p => new JBControls.CheckImportData { DisplayCode = p.TR_TYPE_DISP, RealCode = p.TR_TYPE, DisplayName = p.DESCR }).ToList());
            frm.DataTransfer.CheckData.Add("評核方式", traDS1.TRASSCODE.Select(p => new JBControls.CheckImportData { DisplayCode = p.TR_ASNO_DISP, RealCode = p.TR_ASNO, DisplayName = p.TR_ASNAME }).ToList());
            frm.DataTransfer.CheckData.Add("訓練型式", traDS1.TR_INOUT.Select(p => new JBControls.CheckImportData { DisplayCode = p.CODE, RealCode = p.CODE, DisplayName = p.NAME }).ToList());

            frm.DataTransfer.ColumnList = new Dictionary<string, Type>();
            frm.DataTransfer.ColumnList.Add("課程代碼", typeof(string));
            frm.DataTransfer.ColumnList.Add("課程名稱", typeof(string));
            frm.DataTransfer.ColumnList.Add("開訓日期", typeof(string));
            frm.DataTransfer.ColumnList.Add("結訓日期", typeof(string));
            frm.DataTransfer.ColumnList.Add("訓練對象", typeof(string));
            frm.DataTransfer.ColumnList.Add("承辦單位", typeof(string));
            frm.DataTransfer.ColumnList.Add("承辦單位名稱", typeof(string));
            frm.DataTransfer.ColumnList.Add("開課部門", typeof(string));
            frm.DataTransfer.ColumnList.Add("開課部門名稱", typeof(string));
            frm.DataTransfer.ColumnList.Add("課程類別", typeof(string));
            frm.DataTransfer.ColumnList.Add("課程類別名稱", typeof(string));
            frm.DataTransfer.ColumnList.Add("評核方式", typeof(string));
            frm.DataTransfer.ColumnList.Add("評核方式名稱", typeof(string));
            frm.DataTransfer.ColumnList.Add("訓練型式", typeof(string));
            frm.DataTransfer.ColumnList.Add("訓練型式名稱", typeof(string));
            frm.DataTransfer.ColumnList.Add("總時數", typeof(string));
            frm.DataTransfer.ColumnList.Add("講師", typeof(string));
            frm.DataTransfer.ColumnList.Add("上課費用", typeof(string));
            frm.DataTransfer.ColumnList.Add("國家", typeof(string));
            frm.DataTransfer.ColumnList.Add("講義", typeof(string));
            frm.DataTransfer.ColumnList.Add("ISO", typeof(string));
            frm.DataTransfer.ColumnList.Add("是否國外", typeof(string));
            frm.DataTransfer.ColumnList.Add("是否計畫內", typeof(string));
            frm.DataTransfer.ColumnList.Add("是否有課後問卷", typeof(string));
            frm.DataTransfer.ColumnList.Add("備註", typeof(string));
            frm.DataTransfer.ColumnList.Add("警告", typeof(string));
            frm.DataTransfer.ColumnList.Add("錯誤註記", typeof(string));

            //frm.DataTransfer.UnMustColumnList = new List<string>();
            //frm.DataTransfer.UnMustColumnList.Add("合同种类代码");
            //frm.DataTransfer.UnMustColumnList.Add("派驻区代码");

            frm.ShowDialog();
        }
    }
}
