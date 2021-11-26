using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace JBHR.Med
{
    public partial class FRM71 : JBControls.JBForm
    {
        public FRM71()
        {
            InitializeComponent();
        }
        MedDS.YRFORSUBDataTable dtYRFORSUB = new MedDS.YRFORSUBDataTable();
        private void FRM51_Load(object sender, EventArgs e)
        {
            SystemFunction.SetJBComboBoxItems(comboBox1, MainForm.WriteRules.Where(p => p.COMPANY == MainForm.COMPANY).ToDictionary(p => p.DATAGROUP, p => p.DATAGROUP1.GROUPNAME));
            MedDS.TBASEDataTable tBaseData = new MedDS.TBASEDataTable();
            this.tBASETableAdapter.Fill(tBaseData);
            var data = (from a in tBaseData where MainForm.WriteDataGroups.Contains(a.SALADR) select a).ToList();
            this.medDS.TBASE.Clear();
            foreach (var it in data)
                this.medDS.TBASE.ImportRow(it);
            this.tCODETableAdapter.Fill(this.medDS.TCODE);
            this.yRFORSUBTableAdapter.Fill(dtYRFORSUB);
            //this.v_BASETableAdapter.Fill(this.mainDS.V_BASE);
            this.tWAGEDTableAdapter.FillByInit(this.medDS.TWAGED);
            this.yRFORMATTableAdapter.Fill(this.medDS.YRFORMAT);
            this.cOMPTableAdapter.Fill(this.medDS.COMP);
            this.yRINATableAdapter.Fill(this.medDS.YRINA);
            RefreshForsub(true);
            BasDataClassesDataContext db = new BasDataClassesDataContext();
            var u_prg = (from c in db.U_PRGID where c.USER_ID.Trim() == MainForm.USER_ID && c.PROG.Trim().ToLower() == this.Name.ToLower() select c).FirstOrDefault();
            if (u_prg != null)
            {
                fullDataCtrl1.bnAddEnable = u_prg.ADD_;
                fullDataCtrl1.bnEditEnable = u_prg.EDIT;
                fullDataCtrl1.bnDelEnable = u_prg.DELE;
                fullDataCtrl1.bnExportEnable = u_prg.PRINT_;
            }
            fullDataCtrl1.WhereCmd = Sal.Function.GetFilterCmdByDataGroupOfWrite("TWAGED.SALADR");
            fullDataCtrl1.DataAdapter = tWAGEDTableAdapter;
            fullDataCtrl1.Init_Ctrls();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            FRM71A frm = new FRM71A();
            frm.ShowDialog();
        }

        private void fullDataCtrl1_AfterShow(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            Decrypt();
        }

        private void fullDataCtrl1_AfterQuery(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            Decrypt();
        }

        private void fullDataCtrl1_BeforeSave(object sender, JBControls.FullDataCtrl.BeforeEventArgs e)
        {
            //if (!Sal.Function.CanModify(e.Values["nobr"].ToString()))
            //{
            //    e.Cancel = true;
            //    MessageBox.Show(Resources.All.WorkadrErr, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //}
            comboBox1.Focus();
            if (!e.Cancel)
            {
                e.Values["AMT"] = JBModule.Data.CEncrypt.Number(Convert.ToDecimal(e.Values["AMT"]));
                e.Values["D_AMT"] = JBModule.Data.CEncrypt.Number(Convert.ToDecimal(e.Values["D_AMT"]));
                e.Values["SUP_AMT"] = JBModule.Data.CEncrypt.Number(Convert.ToDecimal(e.Values["SUP_AMT"]));
                e.Values["SALADR"] = comboBox1.SelectedValue;
                e.Values["key_man"] = MainForm.USER_NAME;
                e.Values["key_date"] = DateTime.Now;
            }
        }

        private void fullDataCtrl1_AfterExport(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            DataView dv = ((sender as JBControls.FullDataCtrl).DataSource.DataSource as DataSet).Tables[(sender as JBControls.FullDataCtrl).DataSource.DataMember].DefaultView;
            dv.RowFilter = (sender as JBControls.FullDataCtrl).DataSource.Filter;

            JBModule.Data.CNPOI.RenderDataViewToExcel(dv, "C:\\TEMP\\" + this.Name + ".xls");
            System.Diagnostics.Process.Start("C:\\TEMP\\" + this.Name + ".xls");
        }

        private void fullDataCtrl1_AfterSave(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            if (!e.Error)
            {
                CDataLog.Save(this.Name, MainForm.USER_NAME, DateTime.Now, fullDataCtrl1.BackupDataTable);

                e.Values["AMT"] = JBModule.Data.CDecryp.Number(Convert.ToDecimal(e.Values["AMT"]));
                e.Values["D_AMT"] = JBModule.Data.CDecryp.Number(Convert.ToDecimal(e.Values["D_AMT"]));
                e.Values["SUP_AMT"] = JBModule.Data.CDecryp.Number(Convert.ToDecimal(e.Values["SUP_AMT"]));
            }
        }

        private void fullDataCtrl1_AfterDel(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            if (!e.Error)
            {
                CDataLog.Save(this.Name, MainForm.USER_NAME, DateTime.Now, fullDataCtrl1.BackupDataTable);
            }
        }

        private void fullDataCtrl1_AfterAdd(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            ptxNobr.Focus();
            comboBoxCompany.SelectedValue = MainForm.COMPANY;
        }
        void RefreshForsub(bool GetAll)
        {
            this.medDS.YRFORSUB.Clear();
            var dt = dtYRFORSUB.Where(p => true).Select(p => new { p.M_FORSUB, p.M_SUB_NAME }).Distinct();
            if (!GetAll)
                dt = dtYRFORSUB.Where(p => p.M_FORMAT.Trim() == comboBoxFormat.SelectedValue.ToString()).Select(p => new { p.M_FORSUB, p.M_SUB_NAME });
            SystemFunction.SetJBComboBoxItems(comboBoxForsub, dt.ToDictionary(p => p.M_FORSUB, p => p.M_SUB_NAME));
        }



        void Decrypt()
        {
            foreach (var itm in this.medDS.TWAGED)
            {
                itm.AMT = JBModule.Data.CDecryp.Number(itm.AMT);
                itm.D_AMT = JBModule.Data.CDecryp.Number(itm.D_AMT);
                itm.SUP_AMT = JBModule.Data.CDecryp.Number(itm.SUP_AMT);
            }
            this.medDS.TWAGED.AcceptChanges();
        }
        private void ptxNobr_QueryCompleted(object sender, JBControls.PopupTextBox.QueryCompletedArgs e)
        {
            var db = new JBModule.Data.Linq.HrDBDataContext();
            var sql = from a in db.TBASE
                      where a.NOBR == e.code
                      select a;
            if (sql.Any())
            {
                comboBox1.SelectedValue = sql.First().SALADR;
                comboBox1.Focus();//要先進入combobox1,不然值抓不到
                textBox2.Focus();
            }
        }

        private void textBox4_Validated(object sender, EventArgs e)
        {
            var amt = SuppleInsCalc(comboBoxFormat.SelectedValue, Convert.ToDecimal(txtAmt.Text));
            txtSupAmt.Text = amt.ToString();
            txtSupAmt.Focus();
            txtDAmt.Focus();
        }
        public static decimal SuppleInsCalc(string format, decimal amt)
        {
            var db = new JBModule.Data.Linq.HrDBDataContext();
            var sql = from a in db.YRFORMAT
                      where a.M_FORMAT == format
                      select a;
            decimal supAmt = 0;
            if (sql.Any())
            {

                //decimal amt = Convert.ToDecimal(textBox4.Text);
                if (amt >= sql.First().SUPPLEMAX) amt = sql.First().SUPPLEMAX;
                if (sql.First().SUPPLEMIN <= amt) //必須大於
                {
                    supAmt = decimal.Round(amt * sql.First().FIXRATE, MidpointRounding.AwayFromZero);
                }
            }
            return supAmt;
        }
    }


}
