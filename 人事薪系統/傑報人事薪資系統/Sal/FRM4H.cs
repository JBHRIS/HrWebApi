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
    public partial class FRM4H : JBControls.JBForm
    {
        public FRM4H()
        {
            InitializeComponent();
        }

        private void FRM4H_Load(object sender, EventArgs e)
        {
            SystemFunction.SetComboBoxItems(cbxComp, CodeFunction.GetComp(), true, false, true);
            cbxComp.Enabled = false;
            SystemFunction.SetComboBoxItems(cbxRote, CodeFunction.GetRote(), true, false, true);
            cbxRote.Enabled = false;
            //// TODO: 這行程式碼會將資料載入 'attendDS.ROTE' 資料表。您可以視需要進行移動或移除。
            //this.rOTETableAdapter.Fill(this.attendDS.ROTE);
            //// TODO: 這行程式碼會將資料載入 'attendDS.COMP' 資料表。您可以視需要進行移動或移除。
            //this.cOMPTableAdapter.Fill(this.attendDS.COMP);
            //// TODO: 這行程式碼會將資料載入 'salaryDS.MA_FOOD' 資料表。您可以視需要進行移動或移除。
            this.mA_FOODTableAdapter.Fill(this.salaryDS.MA_FOOD);
            SetControls(mA_FOODTableAdapter, fullDataCtrl1);
        }
        #region 設定
        void SetControls(object SourceAdapter, JBControls.FullDataCtrl fdc)
        {
            fullDataCtrl1.DataAdapter = SourceAdapter;
            //JBControls.FullDataCtrl fdc = sender as JBControls.FullDataCtrl;
            fdc.AfterEdit += new JBControls.FullDataCtrl.AfterEventHandler(fdc_AfterEdit);
            fdc.AfterCancel += new JBControls.FullDataCtrl.AfterEventHandler(fullDataCtrl1_AfterCancel);
            fdc.AfterAdd += new JBControls.FullDataCtrl.AfterEventHandler(fullDataCtrl1_AfterAdd);
            fdc.BeforeSave += new JBControls.FullDataCtrl.BeforeEventHandler(fullDataCtrl1_BeforeSave);
            fdc.BeforeShow += new JBControls.FullDataCtrl.BeforeEventHandler(fullDataCtrl1_BeforeShow);
            fdc.AfterExport += new JBControls.FullDataCtrl.AfterEventHandler(fullDataCtrl1_AfterExport);
            fdc.AfterQuery += new JBControls.FullDataCtrl.AfterEventHandler(fullDataCtrl1_AfterQuery);
            fdc.AfterSave += new JBControls.FullDataCtrl.AfterEventHandler(fullDataCtrl1_AfterSave);
            InitialState();
        }

        #region 狀態控制
        void InitialState()
        {
            panel1.Enabled = false;
            splitContainer1.Panel1.Enabled = true;
        }
        void EditState()
        {
            splitContainer1.Panel1.Enabled = false;
            panel1.Enabled = true;
        }
        #endregion

        #region 事件
        private void fullDataCtrl1_AfterCancel(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            InitialState();
        }
        private void fullDataCtrl1_AfterAdd(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            //splitContainer1.Panel1.Enabled = false;
            //panel1.Enabled = true;
            EditState();
        }
        private void fullDataCtrl1_BeforeSave(object sender, JBControls.FullDataCtrl.BeforeEventArgs e)
        {
            if (!e.Cancel)
            {
                //e.Values["rOOt"] = false;
                e.Values["kEy_MaN"] = MainForm.USER_NAME;
                e.Values["KeY_dAtE"] = DateTime.Now;
            }
        }
        void fdc_AfterEdit(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            EditState();
        }
        private void fullDataCtrl1_BeforeShow(object sender, JBControls.FullDataCtrl.BeforeEventArgs e)
        {
            mA_FOODTableAdapter.Adapter.Fill(this.salaryDS.MA_FOOD);
        }
        private void fullDataCtrl1_AfterExport(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            JBModule.Data.CNPOI.RenderDataTableToExcel(this.salaryDS.MA_FOOD, "C:\\TEMP\\" + this.Name + ".xls");
            System.Diagnostics.Process.Start("C:\\TEMP\\" + this.Name + ".xls");
        }
        private void fullDataCtrl1_AfterQuery(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
        }
        private void fullDataCtrl1_AfterSave(object sender, JBControls.FullDataCtrl.AfterEventArgs e)
        {
            InitialState();
        }
        #endregion

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        #endregion
    }
}
