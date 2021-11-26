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
    public partial class BASETTSD : JBControls.JBForm
    {
        public string nobr = "";
        private bool basettsCheckOK = false;
        private bool basettsSaveOK = false;
        string state = "";
        public BASETTSD()
        {
            InitializeComponent();
        }
        CheckControl cc;//必要欄位檢察
        private void BASETTSD_Load(object sender, EventArgs e)
        {
            #region 必要欄位檢察
            cc = new CheckControl();
            cc.AddControl(cbTTSCODE);   //異動狀態
            cc.AddControl(cbTTSCD);     //異動原因
            cc.AddControl(cbRotet);     //班別
            #endregion

            this.rELCODETableAdapter.Fill(this.basDS.RELCODE);
            this.rELISHCDTableAdapter.Fill(this.basDS.RELISHCD);
            this.cOUNTCDTableAdapter.Fill(this.basDS.COUNTCD);
            this.aRMYTableAdapter.Fill(this.basDS.ARMY);
            this.pROVCDTableAdapter.Fill(this.basDS.PROVCD);
            this.eDUCODETableAdapter.Fill(this.basDS.EDUCODE);
          
            SystemFunction.SetComboBoxItems(cbTTSCODE, CodeFunction.GetMtCode("TTSCODE"), true, true);  //異動狀態
            SystemFunction.SetComboBoxItems(cbTTSCD, CodeFunction.GetTtscd(), true, true);       
            SystemFunction.SetComboBoxItems(cbRotet, CodeFunction.GetRotet(), true, true);              //班別

           

            this.MARRYTableAdapter.Fill(this.basDS.MARRY);
            this.BLOODTableAdapter.Fill(this.basDS.BLOOD);
            this.SEXTableAdapter.Fill(this.basDS.SEX);
            this.BASETableAdapter.FillByNOBR(this.basDS.BASE, nobr);
          
            DataTable list = new DataTable();
            list.Columns.Add(new DataColumn("Display", typeof(string)));
            list.Columns.Add(new DataColumn("Id", typeof(string)));
            list.Rows.Add(list.NewRow());
            list.Rows.Add(list.NewRow());
            list.Rows.Add(list.NewRow());
            
            if (this.basDS.BASE.Count > 0)
            {
                this.Text = "(" + nobr + ")" + this.basDS.BASE[0].NAME_C.Trim();
            }
            state = "edit";
            if (basettsFDC.EditType == JBControls.FullDataCtrl.EEditType.Add)
            {
                state = "add";
                BasDS.BASETTSRow dataRow = basDS1.BASETTS[0];
                var ttsData = CodeFunction.GetMtCode("TTSCODE");
                switch (dataRow.TTSCODE)
                {
                    case "1":
                        //TTSCODEBindingSource.Filter = "code in (2,3,6)";
                        ttsData.Remove("1");
                        //ttsData.Remove("2");
                        //ttsData.Remove("3");
                        ttsData.Remove("4");
                        ttsData.Remove("5");
                        //ttsData.Remove("6");
                        SystemFunction.SetComboBoxItems(cbTTSCODE, ttsData, true, true);
                        break;
                    case "2":
                        //TTSCODEBindingSource.Filter = "code in (4)";
                        ttsData.Remove("1");
                        ttsData.Remove("2");
                        ttsData.Remove("3");
                        //ttsData.Remove("4");
                        ttsData.Remove("5");
                        ttsData.Remove("6");
                        SystemFunction.SetComboBoxItems(cbTTSCODE, ttsData, true, true);
                        break;
                    case "3":
                        //TTSCODEBindingSource.Filter = "code in (4,5)";
                        ttsData.Remove("1");
                        ttsData.Remove("2");
                        ttsData.Remove("3");
                        //ttsData.Remove("4");
                        //ttsData.Remove("5");
                        ttsData.Remove("6");
                        SystemFunction.SetComboBoxItems(cbTTSCODE, ttsData, true, true);
                        break;
                    case "4":
                        //TTSCODEBindingSource.Filter = "code in (2,3,6)";
                        ttsData.Remove("1");
                        //ttsData.Remove("2");
                        //ttsData.Remove("3");
                        ttsData.Remove("4");
                        ttsData.Remove("5");
                        //ttsData.Remove("6");
                        SystemFunction.SetComboBoxItems(cbTTSCODE, ttsData, true, true);
                        break;
                    case "5":
                        //TTSCODEBindingSource.Filter = "code in (4)";
                        ttsData.Remove("1");
                        ttsData.Remove("2");
                        ttsData.Remove("3");
                        //ttsData.Remove("4");
                        ttsData.Remove("5");
                        ttsData.Remove("6");
                        SystemFunction.SetComboBoxItems(cbTTSCODE, ttsData, true, true);
                        break;
                    case "6":
                        //TTSCODEBindingSource.Filter = "code in (2,3,6)";
                        ttsData.Remove("1");
                        //ttsData.Remove("2");
                        //ttsData.Remove("3");
                        ttsData.Remove("4");
                        ttsData.Remove("5");
                        //ttsData.Remove("6");
                        SystemFunction.SetComboBoxItems(cbTTSCODE, ttsData, true, true);
                        break;
                }

                cbTTSCODE.Enabled = false;
                txtAdate.Enabled = true;
                cbTTSCD.Enabled = false;
            }
            else
            {
                TTSCODEBindingSource.Filter = "";
                cbTTSCODE.Enabled = false;
                txtAdate.Enabled = true;
                cbTTSCD.Enabled = false;
            }


            basDS.BASETTS.ImportRow(basDS1.BASETTS[0]);//必須後面再import，否則前面combobox Load資料時，會改變Current Binding Value

            baseFDC.DataAdapter = BASETableAdapter;
            basettsFDC.DataAdapter = BASETTSTableAdapter;
       
            if (basettsFDC.EditType == JBControls.FullDataCtrl.EEditType.Add) txtAdate.Enabled = true;
            else txtAdate.Enabled = false;
            txtAdate_Validated(null, null);
            cbTTSCODE.SelectedValue = "6";
            cbTTSCD.SelectedValue = "C11";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            baseFDC.bnSave_Click(null, null);
        }

        private void baseFDC_BeforeSave(object sender, JBControls.FullDataCtrl.BeforeEventArgs e)
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

            if (!Sal.Function.CanModify(nobr))
            {
                e.Cancel = true;
                MessageBox.Show(Resources.All.WorkadrErr, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
         
            basettsFDC.bnSave_Click(null, null);
            if (basettsCheckOK && basettsSaveOK)
            {
                e.Values["nobr"] = this.nobr;
                e.Values["key_man"] = MainForm.USER_NAME;
                e.Values["key_date"] = DateTime.Now;
            }
            else e.Cancel = true;
        }

        private void basettsFDC_BeforeSave(object sender, JBControls.FullDataCtrl.BeforeEventArgs e)
        {

            e.Values["nobr"] = this.nobr;
            e.Values["key_man"] = MainForm.USER_NAME;
            e.Values["key_date"] = DateTime.Now;

            state = "edit";
            BasDS.BASETTSRow dataRow = basDS.BASETTS[0];
            if (basettsFDC.EditType == JBControls.FullDataCtrl.EEditType.Add)
            {

                state = "add";
                if (dataRow.TTSCODE == "2" || dataRow.TTSCODE == "5")
                {
                    if (MessageBox.Show("原本離職的異動資料將修改為留停?按確定繼續，取消略過", Resources.All.DialogTitle, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Cancel)
                        e.Cancel = true;
                }

                if (e.Values["ttscode"].ToString() == "1")
                {
                    e.Values["indt"] = e.Values["adate"];
                }
                if (e.Values["ttscode"].ToString() == "2")
                {
                    e.Values["oudt"] = Convert.ToDateTime(e.Values["adate"]).AddDays(-1);
                }
                if (e.Values["ttscode"].ToString() == "3")
                {
                    e.Values["stdt"] = Convert.ToDateTime(e.Values["adate"]).AddDays(-1);
                }
                if (e.Values["ttscode"].ToString() == "4")
                {
                    if (dataRow.TTSCODE == "2" || dataRow.TTSCODE == "5")
                        e.Values["stdt"] = dataRow.ADATE;
                    e.Values["stindt"] = e.Values["adate"];
                }
                if (e.Values["ttscode"].ToString() == "5")
                {
                    e.Values["stoudt"] = Convert.ToDateTime(e.Values["adate"]).AddDays(-1);
                }
            }
            FRM12DataClassesDataContext db = new FRM12DataClassesDataContext();
            if (basettsFDC.EditType == JBControls.FullDataCtrl.EEditType.Add)
            {
                IEnumerable<BASETTS> basetts1 = from c in db.BASETTS
                                                where c.NOBR.Trim().ToLower() == nobr.Trim().ToLower() && c.ADATE == Convert.ToDateTime(e.Values["adate"])
                                                select c;
                if (basetts1.Count() > 0)
                {
                    MessageBox.Show(Resources.Bas.TTSDateErr, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    e.Cancel = true;
                }

                if (Convert.ToDateTime(e.Values["adate"]) <= basDS.BASETTS[0].ADATE)
                {
                    MessageBox.Show(Resources.Bas.TTSAdateErr, Resources.All.DialogTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    e.Cancel = true;
                }
            }

            if (e.Cancel) basettsCheckOK = false;
            else basettsCheckOK = true;
        }

        private void basettsFDC_AfterAdd(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            BasDS.BASETTSRow dataRow = basDS1.BASETTS[0];

            foreach (DataColumn dc in basDS.BASETTS.Columns)
            {
                if (dc.ColumnName.Trim().ToLower() != "ttscode")
                {
                    e.Values[dc.ColumnName] = dataRow[dc.ColumnName];
                }
            }

            e.Values["adate"] = DateTime.Today;//basDS.BASETTS[0].ADATE.AddDays(1);
            e.Values["ddate"] = DateTime.MaxValue.Date;

        }

        private void basettsFDC_AfterSave(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            if (!e.Error)
            {
                basettsSaveOK = true;
                BasDS.BASETTSRow dataRow = basDS.BASETTS[0];
                FRM12DataClassesDataContext db = new FRM12DataClassesDataContext();
                IEnumerable<BASETTS> basetts = from c in db.BASETTS
                                               where c.NOBR.Trim().ToLower() == nobr
                                               orderby c.ADATE descending
                                               select c;
                for (int i = 0; i < basetts.Count(); i++)
                {
                    if (state == "add")
                    {
                        if (dataRow.TTSCODE == "2" || dataRow.TTSCODE == "5" && dataRow.ADATE == basetts.ElementAt(i).ADATE)//新增才改變
                            db.ExecuteCommand("update basetts set ttscode='3' where nobr={0} and adate={1}", new object[] { nobr, dataRow.ADATE });
                    }

                    if (i == 0) basetts.ElementAt(i).DDATE = Convert.ToDateTime("9999/12/31");
                    else
                    {
                        basetts.ElementAt(i).DDATE = basetts.ElementAt(i - 1).ADATE.AddDays(-1).Date;

                    }
                }

                db.SubmitChanges();
                this.DialogResult = DialogResult.OK;
                Close();
            }
            else basettsSaveOK = false;

            state = "";//初始化
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            Close();
        }

        private void baseFDC_AfterAdd(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
        }

        private void baseFDC_AfterEdit(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
          
        }

        private void basettsFDC_AfterEdit(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
          
        }

        private void cbDepts_MouseClick(object sender, MouseEventArgs e)
        {
            //BasDS.BASETTSRow BASETTSRow = (BasDS.BASETTSRow)((DataRowView)BASETTSbindingSource.Current).Row;
            //SystemFunction.SetComboBoxItems(cbDepts, CodeFunction.GetDepts_effe(), true); //成本部門-過濾失效
            //cbDepts.SelectedValue = BASETTSRow.DEPTS;
        }

        private void txtAdate_Validated(object sender, EventArgs e)
        {
           
        }

        private void cbxAvailableCode_CheckedChanged(object sender, EventArgs e)
        {
            txtAdate_Validated(null, null);
        }
      
    }
}