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
    public partial class FRM4LN : JBControls.JBForm
    {
        public FRM4LN()
        {
            InitializeComponent();
        }

        private void jbQuery1_RowInsert(object sender, JBControls.JBQuery.RowInsertEventArgs e)
        {
            FRM4LN_ADD frm = new FRM4LN_ADD();
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
        }

        private void jbQuery1_RowDelete(object sender, JBControls.JBQuery.RowDeleteEventArgs e)
        {
            JBModule.Data.Repo.EnrichRepo rp = new JBModule.Data.Repo.EnrichRepo();
            var instance = rp.GetInstanceByID(Convert.ToInt32(e.PrimaryKey));
            string msg = "";
            if (!rp.DeleteEnrich(instance, out msg))
                MessageBox.Show("刪除失敗，" + msg, "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void jbQuery1_RowUpdate(object sender, JBControls.JBQuery.RowUpdateEventArgs e)
        {
            FRM4LN_EDIT frm = new FRM4LN_EDIT();
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ID = Convert.ToInt32(e.PrimaryKey);
            frm.ShowDialog();
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            //FRM4LIi frm = new FRM4LIi();
            JBControls.U_IMPORT frm = new JBControls.U_IMPORT();
            frm.Allow_Repeat_Delete = true;
            frm.Allow_Repeat_Ignore = true;
            frm.Allow_Repeat_Override = true;
            frm.Allow_Repeat_CoExists = true;

            frm.FieldForm = new FRM4LIN();
            frm.DataTransfer = new ImportTransferToENRICH_N();
            JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
            frm.DataTransfer.CheckData = new Dictionary<string, List<JBControls.CheckImportData>>();
            frm.DataTransfer.CheckData.Add("眷屬身號", db.FAMILY.Select(p => new JBControls.CheckImportData { DisplayCode = p.FA_IDNO, RealCode = p.FA_IDNO, DisplayName = p.FA_NAME }).ToList());
            frm.DataTransfer.CheckData.Add("薪資代碼", db.SALCODE.Where(p => db.GetCodeFilter("SALCODE", p.SAL_CODE, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value).Select(p => new JBControls.CheckImportData { DisplayCode = p.SAL_CODE_DISP, RealCode = p.SAL_CODE, DisplayName = p.SAL_NAME }).ToList());
            frm.DataTransfer.CheckData.Add("員工編號", db.BASE.Select(p => new JBControls.CheckImportData { DisplayCode = p.NOBR, RealCode = p.NOBR, DisplayName = p.NAME_C }).ToList());
            frm.DataTransfer.ColumnList = new Dictionary<string, Type>();
            frm.DataTransfer.ColumnList.Add("計薪年月", typeof(string));
            frm.DataTransfer.ColumnList.Add("期別", typeof(string));
            frm.DataTransfer.ColumnList.Add("員工編號", typeof(string));
            frm.DataTransfer.ColumnList.Add("員工姓名", typeof(string));
            frm.DataTransfer.ColumnList.Add("眷屬身號", typeof(string));
            frm.DataTransfer.ColumnList.Add("眷屬姓名", typeof(string));
            //frm.DataTransfer.ColumnList.Add("異動日期", typeof(DateTime));
            frm.DataTransfer.ColumnList.Add("薪資代碼", typeof(string));
            frm.DataTransfer.ColumnList.Add("薪資名稱", typeof(string));
            frm.DataTransfer.ColumnList.Add("金額", typeof(decimal));
            frm.DataTransfer.ColumnList.Add("備註", typeof(string));
            frm.DataTransfer.ColumnList.Add("警告", typeof(string));
            frm.DataTransfer.ColumnList.Add("錯誤註記", typeof(string));

            frm.DataTransfer.UnMustColumnList = new List<string>();
            frm.DataTransfer.UnMustColumnList.Add("眷屬身號");

            frm.ShowDialog();
        }

        private void FRM4LN_Load(object sender, EventArgs e)
        {
            //jbQuery1.Parameters.Add("UserID", MainForm.USER_ID);
            //jbQuery1.Parameters.Add("Company", MainForm.COMPANY);
            //jbQuery1.Parameters.Add("Admin", MainForm.ADMIN ? "1" : "0");
            //MainForm.SetJBQueryRule(jbQuery1);
        }

        private void buttonImportSalary_Click(object sender, EventArgs e)
        {
            JBControls.U_IMPORT frm = new JBControls.U_IMPORT();
            frm.Allow_Repeat_Delete = true;
            frm.Allow_Repeat_Ignore = true;
            frm.Allow_Repeat_Override = true;
            frm.Allow_Repeat_CoExists = true;
            frm.ColumnStyle = JBTools.IO.LoadExcelColumnNameStyle.DefinedColumn;

            frm.FieldForm = new FRM4LIA();
            frm.DataTransfer = new ImportTransferToENRICH_Wage();
            JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
            frm.DataTransfer.CheckData = new Dictionary<string, List<JBControls.CheckImportData>>();
            frm.DataTransfer.CheckData.Add("薪資代碼", db.SALCODE.Where(p => db.GetCodeFilter("SALCODE",p.SAL_CODE, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value).Select(p => new JBControls.CheckImportData { DisplayCode = p.SAL_CODE_DISP, RealCode = p.SAL_CODE, DisplayName = p.SAL_NAME }).ToList());
            frm.DataTransfer.CheckData.Add("員工編號", db.BASE.Where(p => db.GetFilterByNobr(p.NOBR, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value).Select(p => new JBControls.CheckImportData { DisplayCode = p.NOBR, RealCode = p.NOBR, DisplayName = p.NAME_C }).ToList());
            frm.DataTransfer.ColumnList = new Dictionary<string, Type>();
            frm.DataTransfer.ColumnList.Add("員工編號", typeof(string));
            frm.DataTransfer.ColumnList.Add("員工姓名", typeof(string));
            frm.DataTransfer.ColumnList.Add("計薪年月", typeof(string));
            frm.DataTransfer.ColumnList.Add("期別", typeof(string));
            //frm.DataTransfer.ColumnList.Add("異動日期", typeof(DateTime));
            frm.DataTransfer.ColumnList.Add("薪資代碼", typeof(string));
            frm.DataTransfer.ColumnList.Add("薪資名稱", typeof(string));
            frm.DataTransfer.ColumnList.Add("金額", typeof(decimal));
            frm.DataTransfer.ColumnList.Add("備註", typeof(string));
            frm.DataTransfer.ColumnList.Add("警告", typeof(string));
            frm.DataTransfer.ColumnList.Add("錯誤註記", typeof(string));

            frm.DataTransfer.UnMustColumnList = new List<string>();
            frm.DataTransfer.UnMustColumnList.Add("眷屬身號");

            frm.ShowDialog();
        }
    }
}
