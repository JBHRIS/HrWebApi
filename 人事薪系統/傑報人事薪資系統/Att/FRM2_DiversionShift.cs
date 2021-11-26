using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace JBHR.Att
{
    public partial class FRM2_DiversionShift : JBControls.JBForm
    {
        public FRM2_DiversionShift()
        {
            InitializeComponent();
        }

        private void JQDiversionShift_RowInsert(object sender, JBControls.JBQuery.RowInsertEventArgs e)
        {
            FRM2_DiversionShift_ADD frm = new FRM2_DiversionShift_ADD();
            frm.ShowDialog();
        }

        private void JQDiversionShift_RowUpdate(object sender, JBControls.JBQuery.RowUpdateEventArgs e)
        {
            FRM2_DiversionShift_ADD frm = new FRM2_DiversionShift_ADD();
            frm.Autokey = Convert.ToInt32(JQDiversionShift.SelectedKey);
            frm.ShowDialog();
        }

        private void JQDiversionShift_RowDelete(object sender, JBControls.JBQuery.RowDeleteEventArgs e)
        {
            JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
            var PrimaryKey = e.PrimaryKey;
            var instance = db.DiversionShift.SingleOrDefault(p => p.AutoKey == Convert.ToInt32(PrimaryKey));
            JBModule.Message.DbLog.WriteLog("Delete", instance, this.Name, instance.AutoKey);
            db.DiversionShift.DeleteOnSubmit(instance);
            db.SubmitChanges();
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            JBControls.U_IMPORT frm = new JBControls.U_IMPORT();
            frm.ColumnStyle = JBTools.IO.LoadExcelColumnNameStyle.DefinedColumn;
            JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
            frm.Text = "分流班別批次匯入";
            //frm.Allow_Repeat_Delete = true;
            //frm.Allow_Repeat_Ignore = true;
            frm.Allow_Repeat_Override = true;
            frm.Allow_MatchField = false;

            frm.AutoMatchMode = true;
            frm.TemplateButtonVisible = true;

            frm.FieldForm = new JBControls.U_FIELD();
            frm.DataTransfer = new DiversionShiftImport();

            frm.DataTransfer.CheckData = new Dictionary<string, List<JBControls.CheckImportData>>();
            var DiversionGroup = CodeFunction.GetMtCode("DiversionGroupType", false).Select(p => new JBControls.CheckImportData { DisplayCode = p.Key, RealCode = p.Key, DisplayName = p.Value }).ToList();
            var DiversionAttendType = db.DiversionAttendType.Select(p => new JBControls.CheckImportData { DisplayCode = p.DiversionAttendType1, RealCode = p.DiversionAttendType1, DisplayName = p.DiversionAttendTypeName }).ToList();
            frm.DataTransfer.CheckData.Add("DiversionGroup", DiversionGroup);
            //frm.DataTransfer.CheckData.Add("DiversionAttendType", DiversionAttendType);
            frm.DataTransfer.CheckData.Add("D1", DiversionAttendType);
            frm.DataTransfer.CheckData.Add("D2", DiversionAttendType);
            frm.DataTransfer.CheckData.Add("D3", DiversionAttendType);
            frm.DataTransfer.CheckData.Add("D4", DiversionAttendType);
            frm.DataTransfer.CheckData.Add("D5", DiversionAttendType);
            frm.DataTransfer.CheckData.Add("D6", DiversionAttendType);
            frm.DataTransfer.CheckData.Add("D7", DiversionAttendType);
            frm.DataTransfer.CheckData.Add("D8", DiversionAttendType);
            frm.DataTransfer.CheckData.Add("D9", DiversionAttendType);
            frm.DataTransfer.CheckData.Add("D10", DiversionAttendType);
            frm.DataTransfer.CheckData.Add("D11", DiversionAttendType);
            frm.DataTransfer.CheckData.Add("D12", DiversionAttendType);
            frm.DataTransfer.CheckData.Add("D13", DiversionAttendType);
            frm.DataTransfer.CheckData.Add("D14", DiversionAttendType);
            frm.DataTransfer.CheckData.Add("D15", DiversionAttendType);
            frm.DataTransfer.CheckData.Add("D16", DiversionAttendType);
            frm.DataTransfer.CheckData.Add("D17", DiversionAttendType);
            frm.DataTransfer.CheckData.Add("D18", DiversionAttendType);
            frm.DataTransfer.CheckData.Add("D19", DiversionAttendType);
            frm.DataTransfer.CheckData.Add("D20", DiversionAttendType);
            frm.DataTransfer.CheckData.Add("D21", DiversionAttendType);
            frm.DataTransfer.CheckData.Add("D22", DiversionAttendType);
            frm.DataTransfer.CheckData.Add("D23", DiversionAttendType);
            frm.DataTransfer.CheckData.Add("D24", DiversionAttendType);
            frm.DataTransfer.CheckData.Add("D25", DiversionAttendType);
            frm.DataTransfer.CheckData.Add("D26", DiversionAttendType);
            frm.DataTransfer.CheckData.Add("D27", DiversionAttendType);
            frm.DataTransfer.CheckData.Add("D28", DiversionAttendType);
            frm.DataTransfer.CheckData.Add("D29", DiversionAttendType);
            frm.DataTransfer.CheckData.Add("D30", DiversionAttendType);
            frm.DataTransfer.CheckData.Add("D31", DiversionAttendType);

            frm.DataTransfer.ColumnList = new Dictionary<string, Type>();
            frm.DataTransfer.ColumnList.Add("分流班別", typeof(string));
            frm.DataTransfer.ColumnList.Add("出勤年月", typeof(string));
            frm.DataTransfer.ColumnList.Add("D1", typeof(string));
            frm.DataTransfer.ColumnList.Add("D2", typeof(string));
            frm.DataTransfer.ColumnList.Add("D3", typeof(string));
            frm.DataTransfer.ColumnList.Add("D4", typeof(string));
            frm.DataTransfer.ColumnList.Add("D5", typeof(string));
            frm.DataTransfer.ColumnList.Add("D6", typeof(string));
            frm.DataTransfer.ColumnList.Add("D7", typeof(string));
            frm.DataTransfer.ColumnList.Add("D8", typeof(string));
            frm.DataTransfer.ColumnList.Add("D9", typeof(string));
            frm.DataTransfer.ColumnList.Add("D10", typeof(string));
            frm.DataTransfer.ColumnList.Add("D11", typeof(string));
            frm.DataTransfer.ColumnList.Add("D12", typeof(string));
            frm.DataTransfer.ColumnList.Add("D13", typeof(string));
            frm.DataTransfer.ColumnList.Add("D14", typeof(string));
            frm.DataTransfer.ColumnList.Add("D15", typeof(string));
            frm.DataTransfer.ColumnList.Add("D16", typeof(string));
            frm.DataTransfer.ColumnList.Add("D17", typeof(string));
            frm.DataTransfer.ColumnList.Add("D18", typeof(string));
            frm.DataTransfer.ColumnList.Add("D19", typeof(string));
            frm.DataTransfer.ColumnList.Add("D20", typeof(string));
            frm.DataTransfer.ColumnList.Add("D21", typeof(string));
            frm.DataTransfer.ColumnList.Add("D22", typeof(string));
            frm.DataTransfer.ColumnList.Add("D23", typeof(string));
            frm.DataTransfer.ColumnList.Add("D24", typeof(string));
            frm.DataTransfer.ColumnList.Add("D25", typeof(string));
            frm.DataTransfer.ColumnList.Add("D26", typeof(string));
            frm.DataTransfer.ColumnList.Add("D27", typeof(string));
            frm.DataTransfer.ColumnList.Add("D28", typeof(string));
            frm.DataTransfer.ColumnList.Add("D29", typeof(string));
            frm.DataTransfer.ColumnList.Add("D30", typeof(string));
            frm.DataTransfer.ColumnList.Add("D31", typeof(string));

            //frm.DataTransfer.ColumnList.Add("警告註記", typeof(string));
            //frm.DataTransfer.ColumnList.Add("錯誤註記", typeof(string));
            frm.DataTransfer.UnMustColumnList = new List<string>();
            frm.DataTransfer.UnMustColumnList.Add("D1");
            frm.DataTransfer.UnMustColumnList.Add("D2");
            frm.DataTransfer.UnMustColumnList.Add("D3");
            frm.DataTransfer.UnMustColumnList.Add("D4");
            frm.DataTransfer.UnMustColumnList.Add("D5");
            frm.DataTransfer.UnMustColumnList.Add("D6");
            frm.DataTransfer.UnMustColumnList.Add("D7");
            frm.DataTransfer.UnMustColumnList.Add("D8");
            frm.DataTransfer.UnMustColumnList.Add("D9");
            frm.DataTransfer.UnMustColumnList.Add("D10");
            frm.DataTransfer.UnMustColumnList.Add("D11");
            frm.DataTransfer.UnMustColumnList.Add("D12");
            frm.DataTransfer.UnMustColumnList.Add("D13");
            frm.DataTransfer.UnMustColumnList.Add("D14");
            frm.DataTransfer.UnMustColumnList.Add("D15");
            frm.DataTransfer.UnMustColumnList.Add("D16");
            frm.DataTransfer.UnMustColumnList.Add("D17");
            frm.DataTransfer.UnMustColumnList.Add("D18");
            frm.DataTransfer.UnMustColumnList.Add("D19");
            frm.DataTransfer.UnMustColumnList.Add("D20");
            frm.DataTransfer.UnMustColumnList.Add("D21");
            frm.DataTransfer.UnMustColumnList.Add("D22");
            frm.DataTransfer.UnMustColumnList.Add("D23");
            frm.DataTransfer.UnMustColumnList.Add("D24");
            frm.DataTransfer.UnMustColumnList.Add("D25");
            frm.DataTransfer.UnMustColumnList.Add("D26");
            frm.DataTransfer.UnMustColumnList.Add("D27");
            frm.DataTransfer.UnMustColumnList.Add("D28");
            frm.DataTransfer.UnMustColumnList.Add("D29");
            frm.DataTransfer.UnMustColumnList.Add("D30");
            frm.DataTransfer.UnMustColumnList.Add("D31");
            frm.ShowDialog();
        }
    }
}