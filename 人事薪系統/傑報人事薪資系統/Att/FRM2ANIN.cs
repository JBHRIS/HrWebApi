using JBHR;
using JBHR.Att.Attendance;
using JBHR.Att.Attendance.Dto;
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
    public partial class FRM2ANIN : JBControls.U_FIELD
    {
        public FRM2ANIN()
        {
            InitializeComponent();
            BindingControls.Add(cbxROTE);
            BindingControls.Add(cbxADATE);
            BindingControls.Add(cbxNOBR);
        }
        private void FRM2ANIN_Load(object sender, EventArgs e)
        {
            cc = new CheckControl();
            cc.AddControl(cbxADATE);
            cc.AddControl(cbxNOBR);
            cc.AddControl(cbxROTE);
        }
        CheckControl cc;//必填欄位
        private void btnImport_Click(object sender, EventArgs e)
        {
            var ctrl = cc.CheckText();//必要欄位檢查
            if (ctrl != null)//必要欄位檢查
            {
                MessageBox.Show("必要欄位未輸入", "警告註記", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

    public class ImportFamilyData : JBControls.ImportTransfer
    {
        #region ImportFamilyData 成員

        public override bool ImportData(DataRow TransferRow, string RepeatSelectionString, out string ErrMsg)
        {
            ErrMsg = "";
            JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();

            try
            {
                JBModule.Data.Dto.ROTECHGDto rOTETCHGDto = new JBModule.Data.Dto.ROTECHGDto
                {
                    ADATE = Convert.ToDateTime(TransferRow["調班日期"].ToString()),
                    ROTE = TransferRow["調班班別"].ToString(),
                    NOBR = TransferRow["員工編號"].ToString(),
                    KEY_MAN = MainForm.USER_NAME,
                    KEY_DATE = DateTime.Now
                };

                JBModule.Data.Repo.ROTETCHGRepo rOTETCHGRepo = new JBModule.Data.Repo.ROTETCHGRepo();
                //JBModule.Data.Linq.DcHelper.JBHR_ConnectionString = Properties.Settings.Default.JBHRConnectionString;

                var OverlapFAMILY = rOTETCHGRepo.GetOverlapROTECHG(rOTETCHGDto);
                if (OverlapFAMILY != null)
                {
                    if (RepeatSelectionString == JBControls.U_IMPORT.Allow_Repeat_Delete_String)
                    {
                        rOTETCHGRepo.DeleteROTECHG(rOTETCHGDto, out ErrMsg);
                    }
                    else if (RepeatSelectionString == JBControls.U_IMPORT.Allow_Repeat_Override_String)
                    {
                        rOTETCHGRepo.UpdateROTECHG(rOTETCHGDto, out ErrMsg);
                    }
                    else
                    {
                        ErrMsg += "已存在相同的調班資料";
                        return false;
                    }
                }
                else
                {
                    rOTETCHGRepo.InsertROTECHG(rOTETCHGDto, out ErrMsg);
                }

            }
            catch (Exception ex)
            {
                ErrMsg += ex.Message + ";";
                return false;
            }
            return true;
        }


        #endregion

        public override bool TransferToRow(DataRow SourceRow, DataRow TargetRow)
        {
            JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();

            string Msg = "";
            if (ColumnValidate(TargetRow, "員工編號", TransferCheckDataField.RealCode, out Msg))
            {
                TargetRow["員工編號"] = Msg;
            }
            else
            {
                if (TargetRow.Table != null && TargetRow.Table.Columns.Contains("錯誤註記"))
                {
                    TargetRow["錯誤註記"] = Msg;
                }
            }

            if (ColumnValidate(TargetRow, "調班班別", TransferCheckDataField.RealCode, out Msg))
            {
                TargetRow["調班班別"] = Msg;
            }
            else
            {
                if (TargetRow.Table != null && TargetRow.Table.Columns.Contains("錯誤註記"))
                {
                    TargetRow["錯誤註記"] = Msg;
                }
            }
            if (SourceRow["調班日期"].ToString() != "" && !check_DateTime(SourceRow["調班日期"].ToString()))
            {
                if (TargetRow.Table != null && TargetRow.Table.Columns.Contains("錯誤註記"))
                {
                    TargetRow["錯誤註記"] = "調班日期格式錯誤";
                }
            }
            JBModule.Data.Dto.ROTECHGDto rOTECHGDto = new JBModule.Data.Dto.ROTECHGDto
            {
                ADATE = Convert.ToDateTime(TargetRow["調班日期"].ToString()),
                NOBR = TargetRow["員工編號"].ToString(),
            };
            JBModule.Data.Repo.ROTETCHGRepo rOTETCHGRepo = new JBModule.Data.Repo.ROTETCHGRepo();

            var OverlapFAMILY = rOTETCHGRepo.GetOverlapROTECHG(rOTECHGDto);
            if (OverlapFAMILY != null)
            {
                if (TargetRow.Table != null && TargetRow.Table.Columns.Contains("警告註記"))
                {
                    TargetRow["警告註記"] = "重複的資料";
                }
            }

            #region 轉換檢核排班規則
            //JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
            //string Msg = "";

            if (TargetRow["錯誤註記"].ToString().Trim().Length == 0)
            {
                WorkScheduleCheckEntry WSCE = new WorkScheduleCheckEntry();
                WSCE.CheckTypes.Add("CIT");
                WSCE.CheckTypes.Add("CW7");

                string Nobr = TargetRow["員工編號"].ToString();
                DateTime DT1 = Convert.ToDateTime(TargetRow["調班日期"]);
                DateTime DT2 = Convert.ToDateTime(TargetRow["調班日期"]);

                string RT = TargetRow["調班班別"].ToString();
                WorkScheduleCheckGenerator WSCG = new WorkScheduleCheckGenerator(Nobr, DT1.AddDays(-7), DT1, DT2.AddDays(7));

                var RoteCHG = db.ROTECHG.Where(p => p.NOBR == Nobr && (p.ADATE >= DT1.AddDays(-7) || p.ADATE <= DT2.AddDays(7))).ToList();
                foreach (var item in RoteCHG)
                {
                    if (WSCG.WSCD.WorkSchedules.Where(p => p.AttendanceDate == item.ADATE).Any())
                        WSCG.WSCD.WorkSchedules.Where(p => p.AttendanceDate == item.ADATE).First().ScheduleType = item.ROTE;
                    else
                        WSCG.WSCD.WorkSchedules.Add(WorkScheduleCheckGenerator.NewWSD(item.ADATE, RT));
                }

                for (DateTime dd = DT1; dd <= DT2; dd = dd.AddDays(1))
                {
                    if (WSCG.WSCD.WorkSchedules.Where(p => p.AttendanceDate == dd).Any())
                        WSCG.WSCD.WorkSchedules.Where(p => p.AttendanceDate == dd).First().ScheduleType = RT;
                    else
                        WSCG.WSCD.WorkSchedules.Add(WorkScheduleCheckGenerator.NewWSD(dd, RT));
                }
                WSCG.WSCE.CheckTypes.Add("CIT");
                WSCG.WSCE.CheckTypes.Add("CW7");
                var result = WSCG.Check();
                if (result.workScheduleIssues.Count > 0)
                {
                    foreach (var item in result.workScheduleIssues)
                        TargetRow["錯誤註記"] += item.ErrorMessage.ToString();
                }
            }
            #endregion
            return true;
        }
        bool check_DateTime(string sDate)
        {
            var d = DateTime.MaxValue;
            return DateTime.TryParse(sDate, out d);
        }

        string errorMsg(string name)
        {
            string msg = "無效的資料[" + name + "]";
            return msg;
        }
    }
}