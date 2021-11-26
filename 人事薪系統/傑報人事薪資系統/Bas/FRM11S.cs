﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace JBHR.Bas
{
    public partial class FRM11S : JBControls.JBForm
    {
        public FRM11S()
        {
            InitializeComponent();
        }

        private void FRM11M_Load(object sender, EventArgs e)
        {
            this.dOC_ITEMTableAdapter.Fill(this.basDS.DOC_ITEM);
            fullDataCtrl1.DataAdapter = dOC_ITEMTableAdapter;
            Dictionary<string,string> dicCategory=new Dictionary<string,string>();
            dicCategory.Add("PayDoc","應繳資料");
            dicCategory.Add("GiveItem","應發項目");
            SystemFunction.SetJBComboBoxItems(cbxCategory, dicCategory);

            BasDataClassesDataContext db = new BasDataClassesDataContext();
            var u_prg = (from c in db.U_PRGID where c.USER_ID.Trim() == MainForm.USER_ID && c.PROG.Trim().ToLower() == this.Name.ToLower() select c).FirstOrDefault();
            if (u_prg != null)
            {
                fullDataCtrl1.bnAddEnable = u_prg.ADD_;
                fullDataCtrl1.bnEditEnable = u_prg.EDIT;
                fullDataCtrl1.bnDelEnable = u_prg.DELE;
                fullDataCtrl1.bnExportEnable = u_prg.PRINT_;
            }
            fullDataCtrl1.Init_Ctrls();
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
            if (!e.Cancel)
            {
                //if (fullDataCtrl1.EditType == JBControls.FullDataCtrl.EEditType.Add)//**代碼權限設定**20121114
                //{
                //    e.Values["Code"] = Guid.NewGuid().ToString();
                //}
                e.Values["key_man"] = MainForm.USER_NAME;
                e.Values["key_date"] = DateTime.Now;
                //if (CheckRepeat(e.Values["Code"].ToString(), e.Values["CODE_DISP"].ToString()))//**代碼權限設定**20121017
                //{
                //    MessageBox.Show(Resources.Sys.CodeRepeat, "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    e.Cancel = true;
                //    return;
                //}
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

      

        //bool CheckRepeat(string Code, string Disp)//**代碼權限設定**20121114
        //{
        //    var db = new JBModule.Data.Linq.HrDBDataContext();
        //    var sql = from a in db.BankCode
        //              where a.Code != Code && a.CODE_DISP == Disp
        //             && db.GetCodeFilter("BankCode", a.Code, MainForm.USER_ID, MainForm.COMPANY, true).Value//管理者權限設定true,才可以抓到該公司所有代碼
        //              select a;
        //    return sql.Any();
        //}
    }
}