using JBHR.BLL.Att;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace JBHR.Att
{
    public partial class FRM2AN : JBControls.JBForm
    {
        public FRM2AN()
        {
            InitializeComponent();
        }

        private void BnCreateExcel_Click(object sender, EventArgs e)
        {
            //建立Excel 2003檔案
            IWorkbook wb = new HSSFWorkbook();
            ISheet ws = wb.CreateSheet("Class");

            ////建立Excel 2007檔案
            //IWorkbook wb = new XSSFWorkbook();
            //ISheet ws = wb.CreateSheet("Class");

            ws.CreateRow(0);//第一行為欄位名稱
            ws.GetRow(0).CreateCell(0).SetCellValue("員工編號");    //NOBR
            ws.GetRow(0).CreateCell(1).SetCellValue("調班日期");    //ADATE
            ws.GetRow(0).CreateCell(2).SetCellValue("班別");        //NORE


            string path = @"C:\temp\調班資料_樣板.xls";
            FileStream file = new FileStream(path, FileMode.Create);//產生檔案
            wb.Write(file);
            file.Close();
            MessageBox.Show("檔案儲存位址： " + path, "訊息");
        }

        private void BnImport_Click(object sender, EventArgs e)
        {
            Sal.Function.SetAvaliableVBase(this.basDS.V_BASE);
            //FRM2A1 frm2a1 = new FRM2A1();
            //frm2a1.ShowDialog();
            JBControls.U_IMPORT frm = new JBControls.U_IMPORT();
            frm.Allow_Repeat_Delete = true;
            frm.Allow_Repeat_Ignore = true;
            frm.Allow_Repeat_Override = true;
            JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();

            frm.FieldForm = new FRM2ANIN();
            frm.DataTransfer = new ImportFamilyData();

            frm.DataTransfer.CheckData = new Dictionary<string, List<JBControls.CheckImportData>>();
            frm.DataTransfer.CheckData.Add("員工編號", this.basDS.V_BASE.Select(p => new JBControls.CheckImportData { DisplayCode = p.NOBR, RealCode = p.NOBR, DisplayName = p.NAME_C }).ToList());
            frm.DataTransfer.CheckData.Add("調班班別", db.ROTE.Select(p => new JBControls.CheckImportData { DisplayCode = p.ROTE_DISP, RealCode = p.ROTE1, DisplayName = p.ROTE_DISP, CheckValue1 = p.ROTE_SNAME, CheckValue2 = p.ROTENAME }).ToList());

            frm.DataTransfer.ColumnList = new Dictionary<string, Type>();
            frm.DataTransfer.ColumnList.Add("員工編號", typeof(string));
            frm.DataTransfer.ColumnList.Add("調班班別", typeof(string));
            frm.DataTransfer.ColumnList.Add("調班日期", typeof(DateTime));

            frm.DataTransfer.ColumnList.Add("警告註記", typeof(string));
            frm.DataTransfer.ColumnList.Add("錯誤註記", typeof(string));

            frm.ShowDialog();
        }

        private void JbQuery1_RowInsert(object sender, JBControls.JBQuery.RowInsertEventArgs e)
        {
            FRM2AN_ADD frm2nadd = new FRM2AN_ADD();
            if (frm2nadd.ShowDialog()==DialogResult.OK)
            {
                jbQuery1.Query();
            }
        }

        private void JbQuery1_RowDelete(object sender, JBControls.JBQuery.RowDeleteEventArgs e)
        {
            JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
            var PrimaryKey = e.PrimaryKey;
            var instance = db.ROTECHG.SingleOrDefault(p => p.AUTOKEY == Convert.ToInt32(PrimaryKey));
            db.ROTECHG.DeleteOnSubmit(instance);
            db.SubmitChanges();
            AttendanceGenerator ag = new AttendanceGenerator(instance.NOBR, instance.ADATE, instance.ADATE);
            ag.Generate();
            //jbQuery1.Query();
        }

        private void JbQuery1_RowUpdate(object sender, JBControls.JBQuery.RowUpdateEventArgs e)
        {
            FRM2AN_ADD frm2nadd = new FRM2AN_ADD();
            frm2nadd.Autokey = Convert.ToInt32(jbQuery1.SelectedKey);
            frm2nadd.ShowDialog();
            jbQuery1.Query();
        }
    }
}
