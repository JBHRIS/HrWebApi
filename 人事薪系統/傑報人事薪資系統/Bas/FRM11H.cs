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
	public partial class FRM11H : JBControls.JBForm
	{
		public FRM11H()
		{
			InitializeComponent();
		}

		private void FRM11H_Load(object sender, EventArgs e)
		{
			// TODO: 這行程式碼會將資料載入 'mainDS.COUNTCD' 資料表。您可以視需要進行移動或移除。
			this.cOUNTCDTableAdapter.Fill(this.basDS.COUNTCD);

			fullDataCtrl1.DataAdapter = cOUNTCDTableAdapter;

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

		private void fullDataCtrl1_BeforeShow(object sender, JBControls.FullDataCtrl.BeforeEventArgs e)
		{
            //cOUNTCDTableAdapter.Adapter.Fill(this.basDS.COUNTCD);
		}

		private void fullDataCtrl1_AfterExport(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
		{
			DataView dv = ((sender as JBControls.FullDataCtrl).DataSource.DataSource as DataSet).Tables[(sender as JBControls.FullDataCtrl).DataSource.DataMember].DefaultView;
			dv.RowFilter = (sender as JBControls.FullDataCtrl).DataSource.Filter;

			JBModule.Data.CNPOI.RenderDataViewToExcel(dv, "C:\\TEMP\\" + this.Name + ".xls");
			System.Diagnostics.Process.Start("C:\\TEMP\\" + this.Name + ".xls");
		}
	}
}
