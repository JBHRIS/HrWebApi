using JBHR.Att.Attendance;
using JBHR.Att.Attendance.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace JBHR.Att
{
    public partial class FRM233_IMPORT : JBControls.U_IMPORT
    {
        public FRM233_IMPORT()
        {
            InitializeComponent();
        }

        private void FRM231_Load(object sender, EventArgs e)
        {

        }
    }
    public class TimeTableImport : JBControls.ImportTransfer
    {
        public override bool TransferToRow(DataRow SourceRow, DataRow TargetRow)
        {
            foreach (DataColumn dc in TargetRow.Table.Columns)
            {
                if (SourceRow.Table.Columns.Contains(dc.ColumnName))
                    TargetRow[dc.ColumnName] = SourceRow[dc.ColumnName];
            }

            #region 轉換檢核排班規則
            JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
            string Msg = "";

            if (SourceRow["出勤年月"].ToString() != "" && !check_YYMM(SourceRow["出勤年月"].ToString(), out Msg))
            {
                if (TargetRow.Table != null && TargetRow.Table.Columns.Contains("錯誤註記"))
                {
                    TargetRow["錯誤註記"] = Msg;
                }
            }

            if (TargetRow["錯誤註記"].ToString().Trim().Length == 0)
            {
                string sYear = SourceRow["出勤年月"].ToString().Substring(0, 4);
                string sMonth = SourceRow["出勤年月"].ToString().Substring(4, 2);
                int iYear = int.Parse(sYear);
                int iMonth = int.Parse(sMonth);
                DateTime date = new DateTime(iYear, iMonth, 1);

                WorkScheduleCheckGenerator WSCG = new WorkScheduleCheckGenerator(TargetRow["工號"].ToString(), date.AddDays(-7), date, date.AddMonths(1).AddDays(-1));

                foreach (DataColumn dc in TargetRow.Table.Columns)
                    if (dc.ColumnName.CompareTo("D1") >= 0 && dc.ColumnName.CompareTo("D99") <= 0)
                    {
                        WSCG.WSCD.EndCheckDate = date.AddDays(int.Parse(dc.ColumnName.Remove(0, 1)) - 1);
                        if (ColumnValidate(TargetRow, dc.ColumnName, TransferCheckDataField.RealCode, out Msg) && Msg.Trim().Length > 0)
                        {
                            if (WSCG.WSCD.WorkSchedules.Where(p => p.AttendanceDate == WSCG.WSCD.EndCheckDate).Any())
                                WSCG.WSCD.WorkSchedules.Where(p => p.AttendanceDate == WSCG.WSCD.EndCheckDate).First().ScheduleType = Msg;
                            else
                                WSCG.WSCD.WorkSchedules.Add(WorkScheduleCheckGenerator.NewWSD(WSCG.WSCD.EndCheckDate, Msg));
                        }
                        else
                            TargetRow["錯誤註記"] += Msg;
                    }
                WSCG.WSCE.CheckTypes.Add("CIT");
                WSCG.WSCE.CheckTypes.Add("CW7");
                var result = WSCG.Check();
                foreach (var item in result.workScheduleIssues)
                {
                    TargetRow["錯誤註記"] += item.ErrorMessage.ToString();
                }
            } 
            #endregion

            return true;
        }

        public override bool ImportData(DataRow TransferRow, string RepeatSelectionString, out string ErrorMsg)
        {
            return InsertTmtable(TransferRow, RepeatSelectionString, out ErrorMsg);
        }
        bool InsertTmtable(DataRow row, string RepeatSelection, out string ErrorMsg)
        {
            try
            {
                ErrorMsg = "";
                JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
                var sql = db.BASE.Where(p => p.NAME_C == row["員工姓名"].ToString() && db.GetFilterByNobr(p.NOBR, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value).Select(p => p.NOBR);
                var sqlNobr = db.BASE.Where(p=>p.NOBR == row["工號"].ToString() && db.GetFilterByNobr(p.NOBR, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value);

                if (!sqlNobr.Any() && !sql.Any())
                {
                    ErrorMsg += "工號與員工姓名不存在";
                    return false;
                }
                else
                {
                    if (!sqlNobr.Any())
                        row["工號"] = sql.FirstOrDefault().ToString();
                    else if (row["員工姓名"].ToString().Trim().Length != 0 && (!sql.Any() || !sql.ToList().Contains(row["工號"].ToString())))
                    {
                        ErrorMsg += "工號與員工姓名不符，請確認工號或員工姓名是否輸入正確";
                        return false;
                    }

                    SqlDataAdapter sa = new SqlDataAdapter(string.Format("SELECT * FROM TMTABLE_IMPORT WHERE [NOBR]='{0}' and YYMM='{1}'", row["工號"].ToString(), row["出勤年月"].ToString()), JBHR.Properties.Settings.Default.JBHRConnectionString);
                    SqlCommandBuilder scb = new SqlCommandBuilder(sa);
                    DataTable dt = new DataTable();
                    sa.Fill(dt);
                    var rr = dt.NewRow();
                    foreach (DataColumn dc in dt.Columns)
                        if (row.Table.Columns.Contains(dc.ColumnName))
                        {
                            if (dc.ColumnName.CompareTo("D1") >= 0 && dc.ColumnName.CompareTo("D99") <= 0)
                            {
                                if (ColumnValidate(row, dc.ColumnName, TransferCheckDataField.RealCode, out ErrorMsg))
                                {
                                    row[dc.ColumnName] = ErrorMsg;
                                }
                                else
                                {
                                    if (row.Table != null && row.Table.Columns.Contains("錯誤註記"))
                                    {
                                        row["錯誤註記"] = ErrorMsg;
                                    }
                                }
                                rr[dc.ColumnName] = row[dc.ColumnName];
                            }
                            else
                                rr[dc.ColumnName] = row[dc.ColumnName];
                        }
                    //rr["ADATE"] = row["Effective Date"];
                    //rr["DDATE"] = new DateTime(9999, 12, 31);
                    rr["YYMM"] = row["出勤年月"];
                    rr["NOBR"] = row["工號"];
                    rr["KEY_DATE"] = DateTime.Now;
                    rr["KEY_MAN"] = MainForm.USER_NAME;
                    rr["NO"] = 0;
                    rr["HOLIS"] = 0;
                    rr["FREQ_NO"] = 0;
                    DataRow rCurrent = null;
                    if (dt.Rows.Count > 0)
                        rCurrent = dt.Rows[0];
                    sa.InsertCommand = scb.GetInsertCommand();
                    sa.UpdateCommand = scb.GetUpdateCommand();
                    sa.DeleteCommand = scb.GetDeleteCommand();

                    if (rCurrent != null)
                    {
                        if (RepeatSelection == JBControls.U_IMPORT.Allow_Repeat_Override_String)
                        {
                            foreach (DataColumn dc in dt.Columns)
                                if (row.Table.Columns.Contains(dc.ColumnName))
                                  if (!String.IsNullOrEmpty(row[dc.ColumnName].ToString()))
                                  {
                                     rCurrent[dc.ColumnName] = row[dc.ColumnName];
                                  }
                        }
                        else
                        {
                            ErrorMsg += "重複的資料";
                            return false;
                        }
                    }
                    else//沒有舊資料，直接新增
                        dt.Rows.Add(rr);
                    sa.Update(dt);
                    return true;
                }
            }
            catch (Exception ex)
            {
                ErrorMsg = ex.Message;
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
