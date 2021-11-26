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
    public partial class FRM2_DiversionShift_Import : JBControls.U_IMPORT
    {
        public FRM2_DiversionShift_Import()
        {
            InitializeComponent();
        }
    }

    public class DiversionShiftImport : JBControls.ImportTransfer
    {
        public override bool TransferToRow(DataRow SourceRow, DataRow TargetRow)
        {
            string Msg = string.Empty;
            foreach (DataColumn dc in TargetRow.Table.Columns)
            {
                if (SourceRow.Table.Columns.Contains(dc.ColumnName))
                {
                    TargetRow[dc.ColumnName] = SourceRow[dc.ColumnName];
                    if (!String.IsNullOrWhiteSpace(TargetRow[dc.ColumnName].ToString()) && CheckData.ContainsKey(dc.ColumnName) && !ColumnValidate(TargetRow, dc.ColumnName, TransferCheckDataField.RealCode, out Msg))
                        if (TargetRow.Table.Columns.Contains("錯誤註記"))
                            TargetRow["錯誤註記"] += string.Format("'{0}'", Msg);
                }
            }

            if (!string.IsNullOrWhiteSpace(SourceRow["出勤年月"].ToString()) && !check_YYMM(SourceRow["出勤年月"].ToString(), out Msg))
                if (TargetRow.Table.Columns.Contains("錯誤註記"))
                    TargetRow["錯誤註記"] += string.Format("'{0}'", Msg);

            return true;
        }

        public override bool ImportData(DataRow TransferRow, string RepeatSelectionString, out string Msg)
        {
            try
            {
                Msg = string.Empty;
                JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
                var diversionGroup = TransferRow["分流班別"].ToString();
                var yy = int.Parse(TransferRow["出勤年月"].ToString().Substring(0, 4));
                var mm = int.Parse(TransferRow["出勤年月"].ToString().Substring(4));
                
                for (int i = 1; i <= 31; i++)
                {
                    Msg = "";
                    if (!string.IsNullOrWhiteSpace(TransferRow[string.Format("D{0}", i)].ToString()))
                    {
                        if (ColumnValidate(TransferRow, string.Format("D{0}", i), TransferCheckDataField.RealCode, out Msg))
                        {
                            var atteendDate = new DateTime(yy, mm, i);
                            var sql = db.DiversionShift.Where(p => p.DiversionGroup == diversionGroup && p.AttendDate == atteendDate).FirstOrDefault();
                            if (sql != null)
                            {
                                sql.DiversionAttendType = Msg;
                                sql.KeyDate = DateTime.Now;
                                sql.KeyMan = MainForm.USER_NAME;
                            }
                            else
                            {
                                JBModule.Data.Linq.DiversionShift diversionShift = new JBModule.Data.Linq.DiversionShift();
                                diversionShift.DiversionGroup = diversionGroup;
                                diversionShift.DiversionAttendType = Msg;
                                diversionShift.KeyDate = DateTime.Now;
                                diversionShift.KeyMan = MainForm.USER_NAME;
                                diversionShift.Guid = Guid.NewGuid();
                                diversionShift.AttendDate = atteendDate;
                                db.DiversionShift.InsertOnSubmit(diversionShift);
                            }
                        }
                        else
                        {
                            if (TransferRow.Table.Columns.Contains("錯誤註記"))
                            {
                                TransferRow["錯誤註記"] += string.Format("'{0}'", Msg);
                            }
                        } 
                    }
                }
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Msg = ex.Message;
                return false;
            }
        }
        bool check_YYMM(string YYMM, out string msg)
        {
            msg = "";
            if (YYMM.Length == 6)
            {
                try
                {
                    var yy = int.Parse(YYMM.Substring(0, 4));
                    var mm = int.Parse(YYMM.Substring(4));

                    var d = new DateTime(yy, mm, 1);
                    //msg = msg;
                    return true;
                }
                catch { }
            }
            msg = errorMsg("出勤年月格式YYYYMM");
            return false;
        }
        string errorMsg(string name)
        {
            string msg = "無效的資料[" + name + "]";
            return msg;
        }
    }
}
