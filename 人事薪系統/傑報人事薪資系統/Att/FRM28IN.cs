using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using JBTools.Extend;

namespace JBHR.Att
{
    public partial class FRM28IN : JBControls.U_FIELD
    {
        public FRM28IN()
        {
            InitializeComponent();
            //cbAmt.Tag = "AMT";
            BindingControls.Add(cbxBDATE);
            BindingControls.Add(cbxBTIME);
            BindingControls.Add(cbxNOTE);
            BindingControls.Add(cbxETIME);
            BindingControls.Add(cbxNOBR);
            BindingControls.Add(cbxH_CODE);
            BindingControls.Add(cbxTOL_HOURS);
            BindingControls.Add(cbxYYMM);

        }
        private void FRM28IN_Load(object sender, EventArgs e)
        {
            cc = new CheckControl();
            cc.AddControl(cbxBDATE);
            cc.AddControl(cbxBTIME);
            cc.AddControl(cbxETIME);
            cc.AddControl(cbxNOBR);
            cc.AddControl(cbxTOL_HOURS);
            cc.AddControl(cbxYYMM);
            cc.AddControl(cbxH_CODE);
        }
        CheckControl cc;//必填欄位
        private void btnImport_Click(object sender, EventArgs e)
        {
            var ctrl = cc.CheckText();//必要欄位檢查
            if (ctrl != null)//必要欄位檢查
            {
                MessageBox.Show("必要欄位未輸入", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ctrl.Focus();
                DialogResult = System.Windows.Forms.DialogResult.None;
                return;
            }
            else
            {
                DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            CombinationData = new DataTable();
            foreach (var it in BindingControls)
            {
                DataColumn dc = new DataColumn();
                dc.ColumnName = it.Tag.ToString();
                CombinationData.Columns.Add(dc);
            }

            //var adate = Convert.ToDateTime(txtAdate.Text);
            foreach (DataRow r in Source.Rows)
            {
                DataRow ri = CombinationData.NewRow();
                SetBindingData(ri, r);
                CombinationData.Rows.Add(ri);
            }
            this.Close();
        }

    }
    public class ImportTransferToABS : JBControls.ImportTransfer
    {
        #region IImportTransfer 成員

        public override bool ImportData(DataRow TransferRow, string RepeatSelectionString, out string ErrMsg)
        {
            ErrMsg = "";
            JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();

            try
            {
                JBHRIS.BLL.Dto.AbsTakenDto absTaken = new JBHRIS.BLL.Dto.AbsTakenDto();
                absTaken.YYMM = TransferRow["計薪年月"].ToString();
                absTaken.EmployeeID = TransferRow["員工編號"].ToString();
                //string NAME = TransferRow["員工姓名"].ToString();

                absTaken.Taken = Convert.ToDecimal(TransferRow["請假時數/天數"]);
                absTaken.AttendDate = Convert.ToDateTime(TransferRow["請假日期"]);
                absTaken.BeginTime = absTaken.AttendDate.AddTime(TransferRow["請假起時"].ToString());
                absTaken.EndTime = absTaken.AttendDate.AddTime(TransferRow["請假迄時"].ToString());
                absTaken.Hcode = TransferRow["假別代碼"].ToString();
                string H_CODE = absTaken.Hcode;
                absTaken.Hcode = H_CODE != "" ? CheckData["假別代碼"].Where(p => p.DisplayCode == H_CODE).First().RealCode : H_CODE;
                absTaken.Remark = TransferRow["備註"].ToString();
                absTaken.CreateMan = MainForm.USER_NAME;
                absTaken.Guid = Guid.NewGuid().ToString();
                absTaken.Serno = "";
                JBModule.Data.Linq.DcHelper.JBHR_ConnectionString = Properties.Settings.Default.JBHRConnectionString;
                JBHRIS.BLL.Repo.IAbsRepo absRepo = MainForm.RepoHelper.GetAbsRepo();
                var ConflictAbsList = GetAbsTakenByEmployeeListDateTime(new List<string> { absTaken.EmployeeID }, absTaken.BeginTime, absTaken.EndTime);
                if (ConflictAbsList.Any())
                {
                    var qq = from a in ConflictAbsList where a.EmployeeID == absTaken.EmployeeID && a.AttendDate == absTaken.AttendDate && a.BeginTime == absTaken.BeginTime && a.EndTime == absTaken.EndTime && a.Hcode == absTaken.Hcode select a;
                    if (qq.Any())
                        if (RepeatSelectionString == JBControls.U_IMPORT.Allow_Repeat_Delete_String)
                        {
                            absTaken.Guid = qq.First().Guid;
                            if (!absRepo.Delete(absTaken, out ErrMsg))
                                return false;
                        }
                        //只允許刪除後重匯
                        //else if (RepeatSelectionString == JBControls.U_IMPORT.Allow_Repeat_Override_String)
                        //{
                        //    if (!absRepo.Update(absTaken, out ErrMsg))
                        //        return false;
                        //}
                        else
                        {
                            ErrMsg += "已存在相同時段的請假資料";
                            return false;
                        }
                    else
                    {
                        ErrMsg += "已存在重疊時段的請假資料";
                        return false;
                    }
                }
                else
                {
                    if (!absRepo.Insert(absTaken, out ErrMsg))
                        return false;
                }
            }
            catch (Exception ex)
            {
                ErrMsg += ex.Message + ";";
                return false;
            }
            return true;
        }
        public List<JBHRIS.BLL.Dto.AbsTakenDto> GetAbsTakenByEmployeeListDateTime(List<string> EmployeeIdList, DateTime TimeBegin, DateTime TimeEnd)
        {
            JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
            List<JBHRIS.BLL.Dto.AbsTakenDto> data = new List<JBHRIS.BLL.Dto.AbsTakenDto>();
            foreach (var item in EmployeeIdList.Split(1000))
            {
                var sql = from a in db.ABS
                          join b in db.HCODE on a.H_CODE equals b.H_CODE
                          where b.FLAG == "-" && !b.MANG
                          && item.Contains(a.NOBR) && a.BDATE >= TimeBegin.Date.AddDays(-1) && a.EDATE <= TimeEnd.Date
                          select new JBHRIS.BLL.Dto.AbsTakenDto
                          {
                              AttendDate = a.BDATE,
                              BeginTime = a.BDATE.AddTime(a.BTIME),
                              EndTime = a.BDATE.AddTime(a.ETIME),
                              CreateMan = a.KEY_MAN,
                              EmployeeID = a.NOBR,
                              Guid = a.Guid,
                              Hcode = a.H_CODE,
                              PrimaryKey = a.Guid,
                              Remark = a.NOTE,
                              Serno = a.SERNO,
                              Taken = a.TOL_HOURS,
                              YYMM = a.YYMM,
                              Syscreate = a.SYSCREATE,
                          };
                var data1 = (from a in sql.ToList()
                             where a.BeginTime < TimeEnd && a.EndTime > TimeBegin
                             select a).ToList();
                data.AddRange(data1);
            }
            return data.ToList();
        }


        #endregion

        public override bool TransferToRow(DataRow SourceRow, DataRow TargetRow)
        {
            JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();

            string Msg = "";
            if (ColumnValidate(TargetRow, "員工編號", TransferCheckDataField.DisplayName, out Msg))
            {
                TargetRow["員工姓名"] = Msg;
            }
            else
            {
                if (TargetRow.Table != null && TargetRow.Table.Columns.Contains("錯誤註記"))
                {
                    TargetRow["錯誤註記"] = Msg;
                }
            }



            if (check_YYMM(TargetRow["計薪年月"].ToString(), out Msg))
            {

            }
            else
            {
                if (TargetRow.Table != null && TargetRow.Table.Columns.Contains("錯誤註記"))
                {
                    TargetRow["錯誤註記"] = Msg;
                }
            }

            if (ColumnValidate(TargetRow, "假別代碼", TransferCheckDataField.DisplayName, out Msg))
            {
                TargetRow["假別名稱"] = Msg;
            }
            else
            {
                if (TargetRow.Table != null && TargetRow.Table.Columns.Contains("錯誤註記"))
                {
                    TargetRow["錯誤註記"] = Msg;
                }
            }
            if (TargetRow["請假時數/天數"].ToString() == "")
            {
                if (TargetRow.Table != null && TargetRow.Table.Columns.Contains("錯誤註記"))
                {
                    TargetRow["錯誤註記"] = errorMsg("請假時數/天數");
                }
            }
            else
            {
                var tol_hours = Convert.ToDecimal(TargetRow["請假時數/天數"].ToString());
                if (tol_hours <= 0)
                {
                    if (TargetRow.Table != null && TargetRow.Table.Columns.Contains("錯誤註記"))
                    {
                        TargetRow["錯誤註記"] = errorMsg("請假時數/天數");
                    }
                }
            }
            JBModule.Data.Linq.DcHelper.JBHR_ConnectionString = Properties.Settings.Default.JBHRConnectionString;
            JBHRIS.BLL.Repo.IAbsRepo absRepo = MainForm.RepoHelper.GetAbsRepo();
            TargetRow["請假起時"] = TargetRow["請假起時"].ToString().Replace(":", "");
            TargetRow["請假迄時"] = TargetRow["請假迄時"].ToString().Replace(":", "");
            string btime = TargetRow["請假起時"].ToString();
            string etime = TargetRow["請假迄時"].ToString();

            var absTaken = new JBHRIS.BLL.Dto.AbsTakenDto
            {
                AttendDate = Convert.ToDateTime(TargetRow["請假日期"]),
                BeginTime = Convert.ToDateTime(TargetRow["請假日期"]).AddTime(btime),
                EndTime = Convert.ToDateTime(TargetRow["請假日期"]).AddTime(etime),
                CreateMan = MainForm.USER_NAME,
                EmployeeID = TargetRow["員工編號"].ToString(),
            };
            var ConflictAbsList = GetAbsTakenByEmployeeListDateTime(new List<string> { absTaken.EmployeeID }, absTaken.BeginTime, absTaken.EndTime);
            if (ConflictAbsList.Any())
            {
                if (TargetRow.Table != null && TargetRow.Table.Columns.Contains("警告"))
                {
                    TargetRow["警告"] = "重複的資料";
                }
            }

            return true;
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
            msg = errorMsg("計薪年月");
            return false;
        }
        string errorMsg(string name)
        {
            string msg = "無效的資料[" + name + "]";
            return msg;
        }
    }

}