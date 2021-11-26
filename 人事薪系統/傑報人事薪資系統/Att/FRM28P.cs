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
    public partial class FRM28P : JBControls.U_CONDITION
    {
        public FRM28P()
        {
            InitializeComponent();

            empSelection.Source = new DataTable();
            empSelection.Source = Repo.EmpRepo.GetEmpAllWithDept();
            empSelection.SelectedValues = new List<string>();
            foreach (DataRow r in empSelection.Source.Rows)
            {
                empSelection.SelectedValues.Add(r[0].ToString().Trim());
            }
            buttonEmp.Text = string.Format("選取({0})", empSelection.SelectedValues.Count());

            roteSelection.Source = new DataTable();
            roteSelection.Source = Repo.AttRepo.GetRote(false, true);
            roteSelection.SelectedValues = new List<string>();
            foreach (DataRow r in roteSelection.Source.Rows)
            {
                roteSelection.SelectedValues.Add(r[0].ToString().Trim());
            }
            buttonRote.Text = string.Format("選取({0})", roteSelection.SelectedValues.Count());

            hcodeData = CodeFunction.GetHcode();
            SystemFunction.SetComboBoxItems(comboBox1, hcodeData, true, false, true);
            SystemFunction.SetComboBoxItems(comboBox2, hcodeData, true, false, true);
            SystemFunction.SetComboBoxItems(comboBox3, hcodeData, true, false, true);

            groupBox1.Enabled = checkBoxError.Checked;
            groupBox2.Enabled = chkCheck.Checked;
            textBoxLate.Text = "0";
            textBoxEarily.Text = "0";
            txtBdate.Text = Sal.Core.SalaryDate.DateString(DateTime.Today);
            txtEdate.Text = Sal.Core.SalaryDate.DateString(DateTime.Today);
            txtChkDateB.Text = txtBdate.Text;
            txtChkDateE.Text = txtEdate.Text;
            txtChkTimeB.Text = "0000";
            txtChkTimeE.Text = "2400";
        }
        JBControls.MultiSelectionDialog empSelection = new JBControls.MultiSelectionDialog();
        JBControls.MultiSelectionDialog roteSelection = new JBControls.MultiSelectionDialog();
        Dictionary<string, string> hcodeData = new Dictionary<string, string>();

        private void FRM28P_Load(object sender, EventArgs e)
        {



        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (empSelection.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                buttonEmp.Tag = empSelection.SelectedValues;
                buttonEmp.Text = string.Format("選取({0})", empSelection.SelectedValues.Count());
            }
        }
        private void buttonRote_Click(object sender, EventArgs e)
        {
            if (roteSelection.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                buttonRote.Tag = roteSelection.SelectedValues;
                buttonRote.Text = string.Format("選取({0})", roteSelection.SelectedValues.Count());
            }
        }

        private void checkBoxError_CheckedChanged(object sender, EventArgs e)
        {
            groupBox1.Enabled = checkBoxError.Checked;
        }

        private void chkCheck_CheckedChanged(object sender, EventArgs e)
        {
            groupBox2.Enabled = chkCheck.Checked;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            var data = Repo.AttRepo.GetAttend(empSelection.SelectedValues, Convert.ToDateTime(txtBdate.Text), Convert.ToDateTime(txtEdate.Text), roteSelection.SelectedValues);
            int lateMins, earilyMins;
            lateMins = Convert.ToInt32(textBoxLate.Text);
            earilyMins = Convert.ToInt32(textBoxEarily.Text);
            bool abs = checkBoxABS.Checked;
            if (checkBoxError.Checked)
                data = (from a in data where (a.LateMins > 0 && a.LateMins >= lateMins) || (a.EarilyMins > 0 && a.EarilyMins >= earilyMins) || (abs && a.ABS) select a).ToList();
            DateTime dd1 = DateTime.MinValue, dd2 = DateTime.MaxValue;
            if (chkCheck.Checked)
            {
                dd1 = Convert.ToDateTime(txtChkDateB.Text).AddTime(txtChkTimeB.Text);
                dd2 = Convert.ToDateTime(txtChkDateE.Text).AddTime(txtChkTimeE.Text);
            }
            List<string> hcodeList = new List<string>();
            if (comboBox1.SelectedValue != null && comboBox1.SelectedValue.ToString().Trim().Length > 0) hcodeList.Add(comboBox1.SelectedValue.ToString());
            if (comboBox2.SelectedValue != null && comboBox2.SelectedValue.ToString().Trim().Length > 0) hcodeList.Add(comboBox2.SelectedValue.ToString());
            if (comboBox3.SelectedValue != null && comboBox3.SelectedValue.ToString().Trim().Length > 0) hcodeList.Add(comboBox3.SelectedValue.ToString());
            var hcodeFirst = Repo.AttRepo.GetHcode(comboBox1.SelectedValue.ToString());

            List<FRM28P_RESULT> results = new List<FRM28P_RESULT>();
            var attRepo = new Repo.AttRepo();
            foreach (var it in data)
            {
                var rote = attRepo.GetRote(it.Rote);
                DateTime d1, d2;
                d1 = it.TimeBegin;
                d2 = it.TimeEnd;
                if (d1 < dd1) d1 = dd1;
                if (d2 > dd2) d2 = dd2;
                if (d1 > d2) continue;//未在此區間，略過
                string hcode1, hcode2, hcode3;
                hcode1 = hcodeList.Count() > 0 ? hcodeList[0] : "";
                hcode2 = hcodeList.Count() > 1 ? hcodeList[1] : "";
                hcode3 = hcodeList.Count() > 2 ? hcodeList[2] : "";
                var absRepo = MainForm.RepoHelper.GetAbsRepo();

                if (checkBoxError.Checked)
                {
                    //var attendList = rote.RestTimes.ToDictionary(p => it.AttendDate.AddTime(p.Key), p => it.AttendDate.AddTime(p.Value));
                    //foreach (var rr in it.AttRecords)
                    //{
                    //    if (!attendList.ContainsKey(it.AttendDate.AddTime( rr.Item1)))
                    //        attendList.Add(it.AttendDate.AddTime(rr.Item1), it.AttendDate.AddTime(rr.Item2));
                    //}
                    Dictionary<DateTime, DateTime> workTimes = new Dictionary<DateTime, DateTime>();
                    workTimes.Add(it.AttendDate.AddTime(rote.OnTime), it.AttendDate.AddTime(rote.OffTime));
                    var AbsenteeismList = GetAbsenteeismList(workTimes, it.AttRecords.ToDictionary(p => it.AttendDate.AddTime(p.Item1), p => it.AttendDate.AddTime(p.Item2)));
                    if (it.LateMins > 0 && it.LateMins >= lateMins)
                    {
                        if (AbsenteeismList.Any())
                        {
                            var guid = Guid.NewGuid().ToString();
                            JBHRIS.BLL.Dto.AbsTakenDto taken = new JBHRIS.BLL.Dto.AbsTakenDto
                            {
                                AttendDate = it.AttendDate,
                                BeginTime = AbsenteeismList.First().Key,
                                CreateMan = MainForm.USER_NAME,
                                EmployeeID = it.EmployeeID,
                                EndTime = AbsenteeismList.First().Value,
                                Guid = guid,
                                Hcode = hcode1,
                                PrimaryKey = guid,
                                Remark = "",
                                Serno = Guid.NewGuid().ToString(),
                                Taken = 0,
                                YYMM = "",
                            };

                            var hrs = absRepo.GetAbsHours(taken);
                            FRM28P_RESULT r = new FRM28P_RESULT
                            {
                                EmployeeName = it.EmployeeName,
                                EmployeeID = it.EmployeeID,
                                AttendDate = it.AttendDate,
                                BeginTime = taken.BeginTime,
                                EndTime = taken.EndTime,
                                _Hcode1 = hcode1,
                                HcodeName1 = hcodeData.ContainsKey(hcode1) ? hcodeData[hcode1] : "",
                                _Hcode2 = hcode2,
                                HcodeName2 = hcodeData.ContainsKey(hcode2) ? hcodeData[hcode2] : "",
                                _Hcode3 = hcode3,
                                HcodeName3 = hcodeData.ContainsKey(hcode3) ? hcodeData[hcode3] : "",
                                _Rote = it.Rote,
                                Remark = "",
                                RoteName = it.RoteName,
                                Taken = hrs,
                                Unit = hcodeFirst.Unit,
                            };
                            results.Add(r);
                        }
                    }
                    if (it.EarilyMins > 0 && it.EarilyMins >= earilyMins)
                    {
                        if (AbsenteeismList.Any())
                        {
                            var guid = Guid.NewGuid().ToString();
                            JBHRIS.BLL.Dto.AbsTakenDto taken = new JBHRIS.BLL.Dto.AbsTakenDto
                            {
                                AttendDate = it.AttendDate,
                                BeginTime = AbsenteeismList.Last().Key,
                                CreateMan = MainForm.USER_NAME,
                                EmployeeID = it.EmployeeID,
                                EndTime = AbsenteeismList.Last().Value,
                                Guid = guid,
                                Hcode = hcode1,
                                PrimaryKey = guid,
                                Remark = "",
                                Serno = Guid.NewGuid().ToString(),
                                Taken = 0,
                                YYMM = "",
                            };

                            var hrs = absRepo.GetAbsHours(taken);
                            FRM28P_RESULT r = new FRM28P_RESULT
                            {
                                EmployeeName = it.EmployeeName,
                                EmployeeID = it.EmployeeID,
                                AttendDate = it.AttendDate,
                                BeginTime = taken.BeginTime,
                                EndTime = taken.EndTime,
                                _Hcode1 = hcode1,
                                HcodeName1 = hcodeData.ContainsKey(hcode1) ? hcodeData[hcode1] : "",
                                _Hcode2 = hcode2,
                                HcodeName2 = hcodeData.ContainsKey(hcode2) ? hcodeData[hcode2] : "",
                                _Hcode3 = hcode3,
                                HcodeName3 = hcodeData.ContainsKey(hcode3) ? hcodeData[hcode3] : "",
                                _Rote = it.Rote,
                                Remark = "",
                                RoteName = it.RoteName,
                                Taken = hrs,
                                Unit = hcodeFirst.Unit,
                            };
                            results.Add(r);
                        }
                    }
                    if (abs && it.ABS)
                    {
                        var guid = Guid.NewGuid().ToString();
                        JBHRIS.BLL.Dto.AbsTakenDto taken = new JBHRIS.BLL.Dto.AbsTakenDto
                        {
                            AttendDate = it.AttendDate,
                            BeginTime = d1,
                            CreateMan = MainForm.USER_NAME,
                            EmployeeID = it.EmployeeID,
                            EndTime = d2,
                            Guid = guid,
                            Hcode = hcode1,
                            PrimaryKey = guid,
                            Remark = "",
                            Serno = Guid.NewGuid().ToString(),
                            Taken = 0,
                            YYMM = "",
                        };

                        var hrs = absRepo.GetAbsHours(taken);
                        FRM28P_RESULT r = new FRM28P_RESULT
                        {
                            EmployeeName = it.EmployeeName,
                            EmployeeID = it.EmployeeID,
                            AttendDate = it.AttendDate,
                            BeginTime = d1,
                            EndTime = d2,
                            _Hcode1 = hcode1,
                            HcodeName1 = hcodeData.ContainsKey(hcode1) ? hcodeData[hcode1] : "",
                            _Hcode2 = hcode2,
                            HcodeName2 = hcodeData.ContainsKey(hcode2) ? hcodeData[hcode2] : "",
                            _Hcode3 = hcode3,
                            HcodeName3 = hcodeData.ContainsKey(hcode3) ? hcodeData[hcode3] : "",
                            _Rote = it.Rote,
                            Remark = "",
                            RoteName = it.RoteName,
                            Taken = hrs,
                            Unit = hcodeFirst.Unit,
                        };
                        results.Add(r);
                    }
                }
                else
                {
                    var guid = Guid.NewGuid().ToString();
                    JBHRIS.BLL.Dto.AbsTakenDto taken = new JBHRIS.BLL.Dto.AbsTakenDto
                    {
                        AttendDate = it.AttendDate,
                        BeginTime = d1,
                        CreateMan = MainForm.USER_NAME,
                        EmployeeID = it.EmployeeID,
                        EndTime = d2,
                        Guid = guid,
                        Hcode = hcode1,
                        PrimaryKey = guid,
                        Remark = "",
                        Serno = Guid.NewGuid().ToString(),
                        Taken = 0,
                        YYMM = "",
                    };

                    var hrs = absRepo.GetAbsHours(taken);
                    FRM28P_RESULT r = new FRM28P_RESULT
                    {
                        EmployeeName = it.EmployeeName,
                        EmployeeID = it.EmployeeID,
                        AttendDate = it.AttendDate,
                        BeginTime = d1,
                        EndTime = d2,
                        _Hcode1 = hcode1,
                        HcodeName1 = hcodeData.ContainsKey(hcode1) ? hcodeData[hcode1] : "",
                        _Hcode2 = hcode2,
                        HcodeName2 = hcodeData.ContainsKey(hcode2) ? hcodeData[hcode2] : "",
                        _Hcode3 = hcode3,
                        HcodeName3 = hcodeData.ContainsKey(hcode3) ? hcodeData[hcode3] : "",
                        _Rote = it.Rote,
                        Remark = "",
                        RoteName = it.RoteName,
                        Taken = hrs,
                        Unit = hcodeFirst.Unit,
                        ErrorMsg = "",
                        RoteDisp = rote.RoteDisp,
                        WarningMsg = "",
                    };
                    results.Add(r);
                }
            }
            CombinationData = results.CopyToDataTable();
        }
        public Dictionary<DateTime, DateTime> GetAbsenteeismList(Dictionary<DateTime, DateTime> workTimeList, Dictionary<DateTime, DateTime> AttendList)
        {
            Dictionary<DateTime, DateTime> timeErrList = new Dictionary<DateTime, DateTime>();
            foreach (var work in workTimeList)
            {
                DateTime wBtime = work.Key;
                DateTime wEtime = work.Value;
                DateTime oldEtime = DateTime.MinValue;
                var processTimeList = from a in AttendList where wEtime > a.Key && a.Value > wBtime select a;
                //只處理有交集的資料
                if (processTimeList.Any())
                {
                    foreach (var BEit in processTimeList)
                    {
                        if (BEit.Equals(processTimeList.First()))//處理第一筆資料
                        {
                            if (wBtime < BEit.Key)
                                timeErrList.Add(wBtime, BEit.Key);
                        }
                        else//其餘直接抓前一筆的Etime和此筆的Btime當異常時間
                        {
                            timeErrList.Add(oldEtime, BEit.Key);
                        }

                        if (BEit.Equals(processTimeList.Last()))//處理最後一筆資料
                        {
                            if (wEtime > BEit.Value)
                                timeErrList.Add(BEit.Value, wEtime);
                        }
                        oldEtime = BEit.Value;//計錄此筆的Etime給下次用。
                    }
                }
                else
                {
                    timeErrList.Add(wBtime, wEtime);
                }
            }
            return timeErrList;
        }
        /// <summary>
        /// 抓出不重疊的時段並排序
        /// </summary>
        /// <param name="AttendList"></param>
        /// <returns></returns>
        Dictionary<DateTime, DateTime> ReBindAttend(Dictionary<DateTime, DateTime> AttendList)
        {
            var sortList = AttendList.OrderBy(p => p.Key);
            Tuple<DateTime, DateTime> newTime = new Tuple<DateTime, DateTime>(DateTime.MinValue, DateTime.MinValue);
            Dictionary<DateTime, DateTime> newList = new Dictionary<DateTime, DateTime>();
            foreach (var it in sortList)
            {
                if (newTime.Item1 <= it.Value && newTime.Item2 >= it.Key)//交集
                {
                    if (it.Value > newList.Last().Value)
                        newList[newList.Max(p => p.Key)] = it.Value;
                }
                else
                {
                    newTime = new Tuple<DateTime, DateTime>(it.Key, it.Value);
                    newList.Add(it.Key, it.Value);
                }
            }
            return newList;
        }
        private void txtBdate_Validated(object sender, EventArgs e)
        {
            txtChkDateB.Text = txtBdate.Text;
        }

        private void txtEdate_Validated(object sender, EventArgs e)
        {
            txtChkDateE.Text = txtEdate.Text;
        }
        int GetHour(string HHmm)
        {
            return Convert.ToInt32(HHmm.Substring(0, 2));
        }
        int GetMinute(string HHmm)
        {
            return Convert.ToInt32(HHmm.Substring(2, 2));
        }
        string AddHour(string HHmm, decimal hour)
        {
            var HH = GetHour(HHmm) + Math.Ceiling(hour);
            var mm = GetMinute(HHmm) + (hour % 1M) * 60M;
            if (mm >= 60)
            {
                HH++;
                mm -= 60;
            }
            return HH.ToString("00") + mm.ToString("00");
        }
    }
    public class FRM28P_CONDITION
    {
        public List<string> EmployeeList { get; set; }
        public List<string> RoteList { get; set; }
        public DateTime DateBegin { get; set; }
        public DateTime DateEnd { get; set; }
        public int LateMins { get; set; }
        public int EarilyMins { get; set; }
        public bool ABS { get; set; }
    }
    public class FRM28P_RESULT : JBControls.Patch_Result
    {
        public string EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public DateTime AttendDate { get; set; }
        public DateTime BeginTime { get; set; }
        public DateTime EndTime { get; set; }
        public string _Hcode1 { get; set; }
        public string HcodeName1 { get; set; }
        public string _Hcode2 { get; set; }
        public string HcodeName2 { get; set; }
        public string _Hcode3 { get; set; }
        public string HcodeName3 { get; set; }
        public decimal Taken { get; set; }
        public string Unit { get; set; }
        public string Remark { get; set; }
        public string _Rote { get; set; }
        public string RoteDisp { get; set; }
        public string RoteName { get; set; }
        public string WarningMsg { get; set; }
        public string ErrorMsg { get; set; }

    }

    public class PatchTransferToABS<T> : JBControls.PatchTransfer
    {
        #region IImportTransfer 成員

        public override bool ImportData(DataRow TransferRow, string RepeatSelectionString, out string ErrMsg)
        {
            ErrMsg = "";
            JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();

            try
            {
                JBHRIS.BLL.Dto.AbsTakenDto absTaken = new JBHRIS.BLL.Dto.AbsTakenDto();
                //absTaken.YYMM = TransferRow["YYMM"].ToString();
                absTaken.EmployeeID = TransferRow["EmployeeID"].ToString();
                //string NAME = TransferRow["員工姓名"].ToString();

                absTaken.Taken = Convert.ToDecimal(TransferRow["Taken"]);
                absTaken.AttendDate = Convert.ToDateTime(TransferRow["AttendDate"]);
                absTaken.BeginTime = Convert.ToDateTime(TransferRow["BeginTime"]);
                absTaken.EndTime = Convert.ToDateTime(TransferRow["EndTime"]);
                string hcode1, hcode2, hcode3;
                hcode1 = TransferRow["_Hcode1"].ToString();
                hcode2 = TransferRow["_Hcode2"].ToString();
                hcode3 = TransferRow["_Hcode3"].ToString();
                absTaken.Hcode = hcode1;
                Sal.Core.SalaryDate sd = new Sal.Core.SalaryDate(absTaken.AttendDate);
                DateTime chkDate = absTaken.AttendDate;
                while (Sal.Function.IsAttendLocked(chkDate, absTaken.EmployeeID))
                {
                    sd = sd.GetNextSalaryDate();
                    chkDate = chkDate.AddMonths(1);
                }
                absTaken.YYMM = sd.YYMM;

                string H_CODE = absTaken.Hcode;
                //absTaken.Hcode = H_CODE != "" ? CheckData["假別代碼"].Where(p => p.DisplayCode == H_CODE).First().RealCode : H_CODE;
                absTaken.Remark = TransferRow["Remark"].ToString();
                absTaken.CreateMan = MainForm.USER_NAME;
                absTaken.Guid = Guid.NewGuid().ToString();
                absTaken.Serno = "";
                JBModule.Data.Linq.DcHelper.JBHR_ConnectionString = Properties.Settings.Default.JBHRConnectionString;
                JBHRIS.BLL.Repo.IAbsRepo absRepo = MainForm.RepoHelper.GetAbsRepo();
                var ConflictAbsList = absRepo.GetConflictAbsTaken(absTaken);
                if (ConflictAbsList.Any())
                {
                    var qq = from a in ConflictAbsList where a.EmployeeID == absTaken.EmployeeID && a.AttendDate == absTaken.AttendDate && a.BeginTime == absTaken.BeginTime && a.EndTime == absTaken.EndTime && a.Hcode == absTaken.Hcode select a;
                    if (qq.Any())
                        if (RepeatSelectionString == JBControls.U_IMPORT.Allow_Repeat_Delete_String)
                        {
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
                    string MsgAppend = "";
                    if (!absRepo.Insert(absTaken, out ErrMsg))
                    {
                        MsgAppend += TransferRow["HcodeName1"].ToString() + ":" + ErrMsg + ";";
                        absTaken.Hcode = hcode2;
                        absTaken.Taken = absRepo.GetAbsHours(absTaken);
                        if (!absRepo.Insert(absTaken, out ErrMsg))
                        {
                            MsgAppend += TransferRow["HcodeName2"].ToString() + ":" + ErrMsg + ";";
                            absTaken.Hcode = hcode3;
                            absTaken.Taken = absRepo.GetAbsHours(absTaken);
                            if (!absRepo.Insert(absTaken, out ErrMsg))
                            {
                                MsgAppend += TransferRow["HcodeName3"].ToString() + ":" + ErrMsg + ";";
                                ErrMsg = MsgAppend;
                                return false;
                            }
                        }
                    }
                    ErrMsg = MsgAppend;
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
            var ConfilctData = absRepo.GetConflictAbsTaken(absTaken);
            if (ConfilctData.Any())
            {
                if (TargetRow.Table != null && TargetRow.Table.Columns.Contains("錯誤註記"))
                {
                    TargetRow["錯誤註記"] = "重複的資料";
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
