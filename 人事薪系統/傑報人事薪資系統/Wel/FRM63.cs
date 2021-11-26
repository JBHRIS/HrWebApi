using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace JBHR.Wel
{
	public partial class FRM63 : JBControls.JBForm
	{
		public FRM63()
		{
			InitializeComponent();
		}

		private void FRM63_Load(object sender, EventArgs e)
		{
            SystemFunction.SetComboBoxItems(comboBox1, CodeFunction.GetYRHSN(), true);
            comboBox1.Enabled = false;
            SystemFunction.SetComboBoxItems(comboBox6, CodeFunction.GetYrina(), true);
            comboBox6.Enabled = false;
            SystemFunction.SetComboBoxItems(comboBox2, CodeFunction.GetMtCode("YRFOMAT"), true);
            comboBox2.Enabled = false;
            SystemFunction.SetComboBoxItems(comboBox3, CodeFunction.GetYrid(), true);
            comboBox3.Enabled = false;
            SystemFunction.SetComboBoxItems(comboBox4, CodeFunction.GetYrermak(), true);
            comboBox4.Enabled = false;
            SystemFunction.SetComboBoxItems(comboBox5, CodeFunction.GetYrmark(), true);
            comboBox5.Enabled = false;


            // TODO: 這行程式碼會將資料載入 'mainDS.V_BASE' 資料表。您可以視需要進行移動或移除。
            Sal.Function.SetAvaliableVBase(this.welDS.V_BASE);
			// TODO: 這行程式碼會將資料載入 'mainDS.YRINA' 資料表。您可以視需要進行移動或移除。
            //this.yRINATableAdapter.Fill(this.welDS.YRINA);
			// TODO: 這行程式碼會將資料載入 'mainDS.YRMARK' 資料表。您可以視需要進行移動或移除。
            //this.yRMARKTableAdapter.Fill(this.welDS.YRMARK);
			// TODO: 這行程式碼會將資料載入 'mainDS.YRERMAK' 資料表。您可以視需要進行移動或移除。
            //this.yRERMAKTableAdapter.Fill(this.welDS.YRERMAK);
			// TODO: 這行程式碼會將資料載入 'mainDS.YRID' 資料表。您可以視需要進行移動或移除。
            //this.yRIDTableAdapter.Fill(this.welDS.YRID);
			// TODO: 這行程式碼會將資料載入 'mainDS.YRFOMAT' 資料表。您可以視需要進行移動或移除。
            //this.yRFOMATTableAdapter.Fill(this.welDS.YRFOMAT);
			// TODO: 這行程式碼會將資料載入 'mainDS.YRHSN' 資料表。您可以視需要進行移動或移除。
            //this.yRHSNTableAdapter.Fill(this.welDS.YRHSN);
			// TODO: 這行程式碼會將資料載入 'mainDS.YRWEL' 資料表。您可以視需要進行移動或移除。
			this.yRWELTableAdapter.Fill(this.welDS.YRWEL);
            fullDataCtrl1.WhereCmd = Sal.Function.GetFilterCmdByDataGroupOfWrite("YRWEL.SALADR");
			fullDataCtrl1.DataAdapter = yRWELTableAdapter;

			WelDataClassesDataContext db = new WelDataClassesDataContext();
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
            //if (!MainForm.PROCSUPER)
            //{
            //    WelDataClassesDataContext db = new WelDataClassesDataContext();
            //    var data = (from c in db.V_BASE where c.NOBR.Trim() == e.Values["nobr"].ToString().Trim() && c.SALADR == MainForm.WORKADR select c).FirstOrDefault();
            //    if (data == null)
            //    {
            //        e.Cancel = true;
            //        MessageBox.Show(Resources.All.WorkadrErr, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //        return;
            //    }
            //}
			if (!e.Cancel)
			{
                e.Values["nobr"] = popupTextBoxNOBR.Text;
                e.Values["name_c"] = popupTextBoxNOBR.LabelText;
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

		private void button1_Click(object sender, EventArgs e)
		{
			FRM63BA frm63ba = new FRM63BA();
			frm63ba.Owner = this;
			frm63ba.ShowDialog();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			if (yRWELBindingSource.Count > 0)
			{								
				int y = Convert.ToInt32((yRWELBindingSource[0] as DataRowView)["year"]);
				if (y >= 1912) y -= 1911;


				StreamWriter sw = new StreamWriter(@"c:\temp\" + (yRWELBindingSource[0] as DataRowView)["id1"].ToString().Trim() + "." + y.ToString().PadLeft(3, '0'), false, Encoding.Default);

				foreach (DataRowView row in yRWELBindingSource)
				{
                    if (row["format"].ToString().Trim() == "92" && Convert.ToDecimal(row["rel_amt"]) < 1000) continue;
                    string f0103 = row["f0103"].ToString().Trim().GetFullLenStr(3);
                    string series = row["series"].ToString().Trim().GetFullLenStr(8);
                    string id1 = row["id1"].ToString().Trim().GetFullLenStr(8);
                    string mark = row["mark"].ToString().Trim().GetFullLenStr(1);
                    string format = row["format"].ToString().Trim().GetFullLenStr(2);
                    string id = row["id"].ToString().Trim().GetFullLenStr(10);
                    string idcode = row["idcode"].ToString().Trim().GetFullLenStr(1);
                    string tot_amt = row["tot_amt"].ToString().Trim().PadLeft(10, '0');
                    string tax_amt = row["tax_amt"].ToString().Trim().PadLeft(10, '0');
                    string rel_amt = row["rel_amt"].ToString().Trim().PadLeft(10, '0');
					string f0407 = "";
					if (format == "92") f0407 = "8A";
                    f0407 = f0407.Trim().GetFullLenStr(2);
                    string blank_1 = row["blank_1"].ToString().Trim().GetFullLenStr(1);
                    string err_mark = row["err_mark"].ToString().Trim().GetFullLenStr(11);
					y = Convert.ToInt32(row["year"]);
					if (y >= 1912) y -= 1911;
					string year = y.ToString().PadLeft(3, '0');
					string name_c = row["name_c"].ToString().Trim().GetFullLenStr(12);
                    string addr_2 = "";
                    try
                    {
                        addr_2 = row["addr_2"].ToString().Trim().GetFullLenStr(60);
                    }
                    catch
                    {
                        MessageBox.Show(Resources.Med.NOBR + row["nobr"].ToString().Trim() + Resources.Med.AddrTooLong, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        sw.Close();
                        return;
                    }
                    string space44 = "".GetFullLenStr(44);
					string date = DateTime.Now.Month.ToString().PadLeft(2, '0') + DateTime.Now.Day.ToString().PadLeft(2, '0');

                    sw.WriteLine(f0103 + series + id1 + mark + format + id + idcode + tot_amt + tax_amt + rel_amt + f0407 + blank_1 + err_mark + year + name_c + addr_2 + space44 + date);
				}

				sw.Close();

				MessageBox.Show(Resources.All.ExportCompleted, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.None);
			}
		}

		private void fullDataCtrl1_AfterQuery(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
		{
			filterData();
		}

		private void fullDataCtrl1_AfterShow(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
		{
			filterData();
		}

		private void filterData()
		{
            //if (!MainForm.MANGSUPER)
            //{
            //    WelDataClassesDataContext db = new WelDataClassesDataContext();

            //    DataTable dt = (yRWELBindingSource.DataSource as DataSet).Tables[yRWELBindingSource.DataMember];
            //    foreach (DataRow row in dt.Rows)
            //    {
            //        var data = (from c in db.V_BASE where c.NOBR.Trim() == row["nobr"].ToString().Trim() && c.SALADR == MainForm.WORKADR select c).FirstOrDefault();
            //        if (data == null)
            //        {
            //            row.Delete();
            //        }
            //    }

            //    dt.AcceptChanges();

            //    fullDataCtrl1.Init_Ctrls();
            //}
		}
	}

    static class Ext
    {
        public static string GetFullLenStr(this string str, int len)
        {
            byte[] bytes = System.Text.Encoding.Default.GetBytes(str.Trim());

            string emptyStr = "".PadRight(len - bytes.Length, ' ');
            string ss = str.Trim() + emptyStr;
            return ss;
        }
    }
}
