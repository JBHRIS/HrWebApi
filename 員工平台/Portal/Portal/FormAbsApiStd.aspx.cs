﻿using Dal;
using Dal.Dao.Share;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using Dal.Dao.Flow;
using Bll.Flow.Vdb;
using Bll.Files.Vdb;
using Dal.Dao.Absence;
using Bll.Absence.Vdb;

namespace Portal
{
    public partial class FormAbsApiStd : WebPageBase
    {
        private dcHrDataContext dcHR = new dcHrDataContext();

        private dcFlowDataContext dcFlow = new dcFlowDataContext();
        private string _FormCode = "Abs";
        protected void Page_Load(object sender, EventArgs e)
        {

            if (CompanySetting != null)
            {
                dcHR.Connection.ConnectionString = CompanySetting.ConnHr;
                dcFlow.Connection.ConnectionString = CompanySetting.ConnFlow;
            }
            if (!IsPostBack)
            {
                lblProcessID.Text = Guid.NewGuid().ToString();  //產生一組暫存的序號
                txtDateB.SelectedDate = DateTime.Now.Date;
                txtDateE.SelectedDate = DateTime.Now.Date;
                lblNobrAppM.Text = _User.EmpId;
                SetDefault();
                SetInfoAppM();
                txtNameAppS_DataBind();
                txtNameAgent_DataBind();
                txtHcode_DataBind();
                SetRoteTime(lblNobrAppM.Text, DateTime.Now.Date);
            }

            //var IsNeedAgentExtend = (from c in dcFlow.FormsExtend
            //                         where c.FormsCode == "Abs" && c.Code == "IsNeedAgent" && c.Active == true
            //                         select c).ToList();

            //if (IsNeedAgentExtend.Any())
            //{
            //    plAgent.Visible = false;
            //    plName.CssClass = "col-md-6";
            //    txtAgent.Text = "";
            //    lblNobrAgent1.Text = "";
            //}

            //ScriptManager.GetCurrent(this.Page).RegisterPostBackControl(UploadQS);
        }
        protected void Page_Init(object sender, EventArgs e)
        {
            ContentPlaceHolder content = (ContentPlaceHolder)Master.Master.FindControl("ContentPlaceHolder1");
            if (content != null)
            {
                RadButton btnSubmit = (RadButton)content.FindControl("btnSubmit");
                if (btnSubmit != null)
                    ((MainFlowFormsStd)Page.Master).Submit_Click += new EventHandler(btnAdd_Click);
            }
        }
        private void SetDefault()
        {
            var rForm = (from c in dcFlow.Forms
                         where c.Code == _FormCode
                         select c).FirstOrDefault();

            if (rForm != null)
            {
                lblFlowTreeID.Text = rForm.FlowTreeId;
                lblFormNoteStd.Text = rForm.NoteStd;
                Title = rForm.Name;
            }
        }
        private void SetInfoAppM()
        {
            var rEmpM = (from role in dcFlow.Role
                         join emp in dcFlow.Emp on role.Emp_id equals emp.id
                         join dept in dcFlow.Dept on role.Dept_id equals dept.id
                         join pos in dcFlow.Pos on role.Pos_id equals pos.id
                         where role.Emp_id == lblNobrAppM.Text
                         select new
                         {
                             RoleId = role.id,
                             EmpNobr = emp.id,
                             EmpName = emp.name,
                             DeptCode = dept.id,
                             DeptName = dept.name,
                             JobCode = pos.id,
                             JobName = pos.name,
                             Auth = role.deptMg.Value,
                         }).FirstOrDefault();

            if (rEmpM != null)
            {
                lblRoleAppM.Text = rEmpM.RoleId;
                lblNobrAppM.Text = rEmpM.EmpNobr;
                lblNameAppM.Text = rEmpM.EmpName;
                lblDeptCodeAppM.Text = rEmpM.DeptCode;
                lblDeptNameAppM.Text = rEmpM.DeptName;
                lblJobNameAppM.Text = rEmpM.JobName;
            }
            //if (rEmpM == null)
            //{
            //    RadWindowManager1.RadAlert("人事資料有誤，請通知人事", 300, 100, "警告訊息", "", "");
            //    return;
            //}
            //Dal.Dao.Bas.BasDao oBasDao = new Dal.Dao.Bas.BasDao(dcHR.Connection);
            //var rsPortalRole = oBasDao.GetPortalRoleByNobr(lblNobrAppM.Text);
            //var PortalRole = rsPortalRole.Where(p => p.RoleCode == "Coordinator").FirstOrDefault();
            //if (PortalRole != null)
            //{
            //    txtChiNameAppS.Enabled = true;
            //    txtChiNameAppS.Visible = true;
            //    lblChiName.Visible = true;
            //    lblChiNamePS.Visible = true;
            //}
        }

        #region 資料繫結
        private void txtHcode_DataBind()
        {

            var oHcodeTypes = new HcodeTypesDao();
            var HcodeTypesCond = new HcodeTypesConditions();
            HcodeTypesCond.AccessToken = _User.AccessToken;
            HcodeTypesCond.RefreshToken = _User.RefreshToken;
            HcodeTypesCond.CompanySetting = CompanySetting;
            var Result = oHcodeTypes.GetData(HcodeTypesCond);
            var rs = new List<HcodeTypesRow>();
            if (Result.Status)
            {
                if (Result.Data != null)
                {
                    rs = Result.Data as List<HcodeTypesRow>;
                }
            }

            var rsHtype = rs.Select(p => p.Htype).ToList();

            var ListFlag = new List<string>();
            ListFlag.Add("-");

            var oHcodeTypesByHcode = new HcodeTypesByHcodeDao();
            var HcodeTypesByHcodeCond = new HcodeTypesByHcodeConditions();
            HcodeTypesByHcodeCond.AccessToken = _User.AccessToken;
            HcodeTypesByHcodeCond.RefreshToken = _User.RefreshToken;
            HcodeTypesByHcodeCond.CompanySetting = CompanySetting;
            HcodeTypesByHcodeCond.htype = rsHtype;
            HcodeTypesByHcodeCond.flag = ListFlag;
            var rsListLeaveCode = oHcodeTypesByHcode.GetData(HcodeTypesByHcodeCond);
            var rs1 = new List<HcodeTypesByHcodeRow>();
            if (rsListLeaveCode.Status)
            {
                if (rsListLeaveCode.Data != null)
                {
                    var ResultList = rsListLeaveCode.Data as List<HcodeTypesByHcodeRow>;
                    if (ResultList != null)
                        rs1 = ResultList;
                }
            }
            OldDal.Dao.Att.HcodeDao oHcodeDao = new OldDal.Dao.Att.HcodeDao(dcHR.Connection);
            var rsHcode = oHcodeDao.GetHocde();
            txtHcode.DataSource = rs1;
            txtHcode.DataTextField = "HcodeName";
            txtHcode.DataValueField = "Hcode";
            txtHcode.DataBind();

            txtHcode_SelectedIndexChanged(txtHcode, null);
        }
        public void txtNameAppS_DataBind()
        {
            var rs = AccessData.GetPeopleByDeptTree(_User, CompanySetting);
            var rs1 = AccessData.GetDeptListEmp(_User, CompanySetting);
            var result = rs.Union(rs1).ToList();
            var key = new Dictionary<string, string>();
            foreach (var r in result.ToArray())
            {
                if (key.ContainsKey(r.Value))
                {
                    result.Remove(r);
                }
                else
                {
                    key.Add(r.Value, r.Value);
                }
            }
            txtNameAppS.DataSource = result;
            txtNameAppS.DataTextField = "Text";
            txtNameAppS.DataValueField = "Value";
            txtNameAppS.DataBind();

        }
        private void txtNameAgent_DataBind()
        {
            var rs = AccessData.GetPeopleByDeptTree(_User, CompanySetting);
            var rs1 = AccessData.GetDeptListEmp(_User, CompanySetting);
            var result = rs.Union(rs1).ToList();
            var key = new Dictionary<string, string>();
            foreach (var r in result.ToArray())
            {
                if (key.ContainsKey(r.Value))
                {
                    result.Remove(r);
                }
                else
                {
                    key.Add(r.Value, r.Value);
                }
            }

            txtNameAgent1.DataSource = result;
            txtNameAgent1.DataTextField = "Text";
            txtNameAgent1.DataValueField = "Value";
            txtNameAgent1.DataBind();
        }
        #endregion

        #region 載入初始值
        private void SetRoteTime(string sNobr, DateTime dDate)
        {
            txtTimeB.Text = "0000";
            txtTimeE.Text = "0000";

            OldDal.Dao.Att.AttendDao oAttendDao = new OldDal.Dao.Att.AttendDao(dcHR.Connection);
            var rAttend = oAttendDao.GetAttend(sNobr, dDate).FirstOrDefault();

            if (rAttend != null)
            {
                OldDal.Dao.Att.RoteDao oRoteDao = new OldDal.Dao.Att.RoteDao(dcHR.Connection);
                var rRote = oRoteDao.GetRoteDetail(new List<string>() { rAttend.RoteCode }).FirstOrDefault();

                if (rRote != null)
                {
                    txtTimeB.Text = rRote.OnTime;

                    if (rRote.OffTime.CompareTo("2400") >= 0)
                    {
                        txtDateE.SelectedDate = txtDateE.SelectedDate.Value.AddDays(1);
                        txtTimeE.Text = (Convert.ToInt32(rRote.OffTime) - 2400).ToString("0000");
                    }
                    else
                        txtTimeE.Text = rRote.OffTime;
                }
            }
        }
        #endregion

        #region 被申請人工號及姓名
        protected void txtNameAppS_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            SetName(e.Text);
        }
        protected void txtNameAppS_DataBound(object sender, EventArgs e)
        {
            if (!IsPostBack)
                SetName(lblNobrAppM.Text);
        }
        protected void txtNameAppS_TextChanged(object sender, EventArgs e)
        {
            RadComboBox txt = sender as RadComboBox;
            RadComboBoxItem li = txt.SelectedItem;

            OldDal.Dao.Bas.BasDao oBasDao = new OldDal.Dao.Bas.BasDao(dcHR.Connection);


            if (li != null)
                SetName(li);
            else if (txtNameAppS.Text.Trim().Length > 0)
            {
                SetName(txtNameAppS.Text);
            }

        }
        private void SetName(RadComboBoxItem li)
        {
            if (li != null)
            {
                txtNameAppS.ClearSelection();
                li.Selected = true;
                SetName(li.Value);
            }
        }
        private void SetName(string sNobr)
        {
            OldDal.Dao.Bas.BasDao oBasDao = new OldDal.Dao.Bas.BasDao(dcHR.Connection);

            var rBas = oBasDao.GetBase(sNobr).FirstOrDefault();
            if (rBas != null)
            {
                lblNobrAppS.Text = rBas.Nobr;
                txtNameAppS.Text = rBas.Name;
                txtNameAppS.ToolTip = rBas.Name;
            }
            else
                txtNameAppS.Text = txtNameAppS.ToolTip;

            txtHcode_SelectedIndexChanged(null, null);

            SetRoteTime(lblNobrAppS.Text, txtDateB.SelectedDate.GetValueOrDefault(DateTime.Now.Date));
        }
        #endregion

        #region 代理人1工號及姓名
        protected void txtNameAgent1_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            SetName1(e.Text);
        }
        protected void txtNameAgent1_DataBound(object sender, EventArgs e)
        {
            OldDal.Dao.Bas.BasDao oBasDao = new OldDal.Dao.Bas.BasDao(dcHR.Connection);

            if (!IsPostBack)
            {
                SetName1(lblNobrAppM.Text);
            }

        }
        protected void txtNameAgent1_TextChanged(object sender, EventArgs e)
        {
            RadComboBox txt = sender as RadComboBox;
            RadComboBoxItem li = txt.SelectedItem;

            if (li != null)
                SetName1(li);
            else if (txtNameAgent1.Text.Trim().Length > 0)
                SetName1(txtNameAgent1.Text);
        }
        private void SetName1(RadComboBoxItem li)
        {
            if (li != null)
            {
                txtNameAgent1.ClearSelection();
                li.Selected = true;
                SetName1(li.Value);
            }
        }
        private void SetName1(string sNobr)
        {
            OldDal.Dao.Bas.BasDao oBasDao = new OldDal.Dao.Bas.BasDao(dcHR.Connection);

            var rBas = oBasDao.GetBase(sNobr, true).FirstOrDefault();

            if (rBas != null)
            {
                lblNobrAgent1.Text = rBas.Nobr;
                txtNameAgent1.Text = rBas.Name;
                txtNameAgent1.ToolTip = rBas.Name;
            }
            else
                txtNameAgent1.Text = txtNameAgent1.ToolTip;
        }

        #endregion 代理人1工號及姓名

        protected void txtHcode_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            lblBalance.Text = "0";
            lblBalanceUnit.Text = "";

            string Nobr = lblNobrAppS.Text;
            DateTime DateB = txtDateB.SelectedDate.Value;
            string Hcode = txtHcode.SelectedItem != null ? txtHcode.SelectedItem.Value : "";

            //計算目前正在進行的流程時數
            var rsAppAbs = (from c in dcFlow.FormsAppAbs
                            where c.EmpId == Nobr
                            && c.HolidayCode == Hcode
                            && (c.ProcessID == lblProcessID.Text || (c.idProcess != 0 && c.SignState == "1"))
                            select new OldBll.Att.Vdb.BalanceAbsRow
                            {
                                DateB = c.DateB.Date,
                                Hcode = c.HolidayCode,
                                Use = c.Use,
                            }).ToList();

            OldDal.Dao.Att.AbsDao oAbsDao = new OldDal.Dao.Att.AbsDao(dcHR.Connection);
            var rBalance = oAbsDao.GetBalanceNew(Nobr, DateB, Hcode, true, rsAppAbs).FirstOrDefault();

            OldDal.Dao.Att.HcodeDao oHcodeDao = new OldDal.Dao.Att.HcodeDao(dcHR.Connection);
            var rHcode = oHcodeDao.GetHocdeDetail(Hcode, false).FirstOrDefault();

            if (rHcode.CheckBalance)
            {
                if (rBalance != null)
                {
                    lblBalance.Text = rBalance.Balance.ToString();
                    lblBalanceUnit.Text = rBalance.HcodeUnit == OldBll.MT.mtEnum.HcodeUnit.Day ? "天" : "小時";
                }
                else
                {
                    lblBalance.Text = "沒有產生得假資料";
                }
            }
            else
                lblBalance.Text = "不用檢查";
        }
        protected void txtDateB_SelectedDateChanged(object sender, Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs e)
        {
            txtDateE.SelectedDate = txtDateB.SelectedDate.GetValueOrDefault(DateTime.Now).Date;
            SetRoteTime(lblNobrAppS.Text, txtDateB.SelectedDate.GetValueOrDefault(DateTime.Now).Date);
            txtHcode_SelectedIndexChanged(null, null);
        }
        public void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                //var rSysVar = (from c in dcFlow.SysVar
                //               select c).FirstOrDefault();

                var oSysVarDao = new SysVarDao();
                var SysVarCond = new SysVarConditions();

                SysVarCond.AccessToken = _User.AccessToken;
                SysVarCond.RefreshToken = _User.RefreshToken;
                SysVarCond.CompanySetting = CompanySetting;
                var rsSysVar = oSysVarDao.GetData(SysVarCond);
                var rSysVar = new SysVarRow();
                if (rsSysVar.Status)
                {
                    if (rsSysVar.Data != null)
                    {
                        rSysVar = rsSysVar.Data as SysVarRow;
                        if (rSysVar.SysClose)
                        {
                            lblErrorMsg.Text = "系統維護中，請稍後再送出表單";
                            return;
                        }
                    }
                }

                if (txtDateB.SelectedDate == null || txtDateE.SelectedDate == null)
                {
                    lblErrorMsg.Text = "您的開始或結束日期沒有輸入正確";
                    return;
                }

                if (txtTimeB.Text.Length != 4 || txtTimeE.Text.Length != 4)
                {
                    lblErrorMsg.Text = "您的開始或結束時間沒有輸入正確";
                    return;
                }

                string Nobr = lblNobrAppS.Text;
                string NobrAgent1 = lblNobrAgent1.Text;
                string Hcode = txtHcode.SelectedItem.Value;
                DateTime DateB = txtDateB.SelectedDate.Value;
                DateTime DateE = txtDateE.SelectedDate.Value;
                string TimeB = txtTimeB.Text;
                string TimeE = txtTimeE.Text;
                string Note = txtNote.Text.Trim();
                DateTime DateTimeB = DateB.Date.AddMinutes(Bll.Tools.TimeTrans.ConvertHhMmToMinutes(TimeB));
                DateTime DateTimeE = DateE.Date.AddMinutes(Bll.Tools.TimeTrans.ConvertHhMmToMinutes(TimeE));

                OldDal.Dao.Att.HcodeDao oHcodeDao = new OldDal.Dao.Att.HcodeDao(dcHR.Connection);
                var rHcode = oHcodeDao.GetHocdeDetail(Hcode).First();

                var IsNeedAgentExtend = (from c in dcFlow.FormsExtend
                                         where c.FormsCode == "Abs" && c.Code == "IsNeedAgent" && c.Active == true
                                         select c).ToList();

                if (txtNameAgent1.Items.Count > 1 && !IsNeedAgentExtend.Any())
                {
                    //二擇一
                    if (lblNobrAgent1.Text.Trim().Length == 0)
                    {
                        lblErrorMsg.Text = "您的代理人沒有輸入正確";
                        return;
                    }

                    if (Nobr == NobrAgent1)
                    {
                        lblErrorMsg.Text = "代理與被申請人不可相同";
                        return;
                    }

                    OldDal.Dao.Att.AbsDao oAbsDaoAgent = new OldDal.Dao.Att.AbsDao(dcHR.Connection);
                    var rsAbsAgent = oAbsDaoAgent.GetAbs(NobrAgent1, DateB, DateE, false);
                    if (rsAbsAgent.Where(c => c.DateTimeB < DateTimeE && c.DateTimeE > DateTimeB).Any())
                    {
                        lblErrorMsg.Text = "代理人已經請假";
                        return;
                    }
                }

                if (DateTimeB >= DateTimeE)
                {
                    lblErrorMsg.Text = "您的開始日期時間不能大於或等於結束日期時間";
                    return;
                }

                OldDal.Dao.Att.AttendDao oAttendDao = new OldDal.Dao.Att.AttendDao(dcHR.Connection);
                var rAttendDate = oAttendDao.GetAttendH(Nobr, DateB).FirstOrDefault();
                if (rAttendDate == null)
                {
                    lblErrorMsg.Text = "出勤資料錯誤，請洽人事單位";
                    return;
                }

                //DateTime AppDate = Convert.ToDateTime(rAttendDate.Text);

                //if (DateB < AppDate)
                //{
                //    RadWindowManager1.RadAlert("您所申請的日期必須是前一次出勤日之後，請洽人事單位", 300, 100, "警告訊息", "", "");
                //    return;
                //}

                //檢查重複的資料
                var rsAppS = (from c in dcFlow.FormsAppAbs
                              where (c.ProcessID == lblProcessID.Text || (c.idProcess != 0 && c.SignState == "1"))
                              && c.EmpId == Nobr
                              select c).ToList();

                if (rsAppS.Where(c => c.DateTimeB < DateTimeE && c.DateTimeE > DateTimeB).Any())
                {
                    lblErrorMsg.Text = "資料重複或流程正在進行中";
                    return;
                }

                OldDal.Dao.Att.AbsDao oAbsDao = new OldDal.Dao.Att.AbsDao(dcHR.Connection);

                var rsAbs = oAbsDao.GetAbs(Nobr, DateB.AddDays(-1), DateE, false);
                if (rsAbs.Where(c => c.DateTimeB < DateTimeE && c.DateTimeE > DateTimeB).Any())
                {
                    lblErrorMsg.Text = "人事資料重複";
                    return;
                }
                var Calculate = oAbsDao.GetCalculate(Nobr, Hcode, DateB, DateE, TimeB, TimeE, false, true, 0, false, "", false);

                var AbsenceDataDetail = new AbsenceDataDetailDao();
                var AbsenceDataDetailCond = new AbsenceDataDetailConditions();
                AbsenceDataDetailCond.AccessToken = _User.AccessToken;
                AbsenceDataDetailCond.RefreshToken = _User.RefreshToken;
                AbsenceDataDetailCond.CompanySetting = CompanySetting;
                AbsenceDataDetailCond.nobr = Nobr;
                AbsenceDataDetailCond.startDateTime = DateTimeB;
                AbsenceDataDetailCond.endDateTime = DateTimeE;
                AbsenceDataDetailCond.hcode = Hcode;
                var AbsenceData = AbsenceDataDetail.GetData(AbsenceDataDetailCond);
                var rAbsenceData = new List<AbsenceDataDetailRow>();
                if (AbsenceData.Status && AbsenceData.Data != null)
                {
                    rAbsenceData = AbsenceData.Data as List<AbsenceDataDetailRow>;
                }

                if (Calculate.TotalUse <= 0)
                {
                    lblErrorMsg.Text = "計算時數不可以為零";
                    return;
                }

                decimal iBalance = 0;

                //檢查剩餘時數
                if (rHcode.CheckBalance)
                {
                    //計算目前正在進行的流程時數
                    var rsAppSWhere = (from c in rsAppS
                                       where c.HolidayCode == Hcode
                                       select new OldBll.Att.Vdb.BalanceAbsRow
                                       {
                                           DateB = c.DateB.Date,
                                           Hcode = c.HolidayCode,
                                           Use = c.Use,
                                       }).ToList();

                    DateTime DateB1 = DateB;
                    DateTime DateE1 = DateB;
                    string TimeB1 = TimeB;
                    string TimeE1 = TimeE;

                    oAbsDao.ConvertTime24To48(Nobr, ref DateB1, ref DateE1, ref TimeB1, ref TimeE1);

                    var rBalance = oAbsDao.GetBalanceNew(Nobr, DateB1, Hcode, true, rsAppSWhere).FirstOrDefault();

                    if (rBalance == null || (rBalance.Balance - Calculate.TotalUse) < 0 || (rBalance.BalanceGroup - Calculate.TotalUse) < 0)
                    {
                        lblErrorMsg.Text = "剩餘時數不足(包含流程進行中)";
                        return;
                    }

                    iBalance = rBalance.Balance;
                }

                var rEmpS = (from role in dcFlow.Role
                             join emp in dcFlow.Emp on role.Emp_id equals emp.id
                             join dept in dcFlow.Dept on role.Dept_id equals dept.id
                             join pos in dcFlow.Pos on role.Pos_id equals pos.id
                             where role.Emp_id == Nobr
                             select new
                             {
                                 RoleId = role.id,
                                 EmpNobr = emp.id,
                                 EmpName = emp.name,
                                 DeptCode = dept.id,
                                 DeptName = dept.name,
                                 JobCode = pos.id,
                                 JobName = pos.name,
                                 Auth = role.deptMg.Value,
                             }).FirstOrDefault();

                var rEmpM = (from role in dcFlow.Role
                             join emp in dcFlow.Emp on role.Emp_id equals emp.id
                             join dept in dcFlow.Dept on role.Dept_id equals dept.id
                             join pos in dcFlow.Pos on role.Pos_id equals pos.id
                             where role.Emp_id == lblNobrAppM.Text
                             select new
                             {
                                 RoleId = role.id,
                                 EmpNobr = emp.id,
                                 EmpName = emp.name,
                                 DeptCode = dept.id,
                                 DeptName = dept.name,
                                 JobCode = pos.id,
                                 JobName = pos.name,
                                 Auth = role.deptMg.Value,
                             }).FirstOrDefault();

                OldDal.Dao.Bas.BasDao oBasDao = new OldDal.Dao.Bas.BasDao(dcHR.Connection);
                var rBasS = oBasDao.GetBaseByNobr(Nobr, DateTime.Now.Date).FirstOrDefault();

                var rBasAgent1 = oBasDao.GetBase(NobrAgent1).FirstOrDefault();

                OldDal.Dao.Sal.SalaryLockDao oSalaryLockDao = new OldDal.Dao.Sal.SalaryLockDao(dcHR.Connection);
                string YYMM = oSalaryLockDao.GetSalaryYymm(Nobr, DateB);

                var Code = Guid.NewGuid().ToString();

                var rsFormsAppAbs = new FormsAppAbs()
                {
                    Code = Code,
                    ProcessID = lblProcessID.Text,
                    idProcess = 0,
                    EmpId = rEmpS.EmpNobr,
                    EmpName = rEmpS.EmpName,
                    DeptCode = rEmpS.DeptCode,
                    DeptName = rEmpS.DeptName,
                    JobCode = rEmpS.JobCode,
                    JobName = rEmpS.JobName,
                    RoleId = rEmpS.RoleId,
                    DateTimeB = DateTimeB,
                    DateTimeE = DateTimeE,
                    DateB = DateB,
                    DateE = DateE,
                    TimeB = TimeB,
                    TimeE = TimeE,
                    HolidayCode = Hcode,
                    HolidayName = rHcode.NameC,
                    Use = Calculate.TotalUse,
                    Balance = iBalance,
                    UnitCode = rHcode.Unit == OldBll.MT.mtEnum.HcodeUnit.Day ? "天" : "小時",
                    IsExceptionUse = false,
                    ExceptionUse = 0,
                    Sign = true,
                    SignState = "0",
                    AgentEmpId = NobrAgent1,
                    AgentEmpName = rBasAgent1 != null ? rBasAgent1.NameC : "",
                    AgentNote = txtAgent.Text,
                    Note = txtNote.Text,
                    Status = "1",
                    InsertMan = lblNobrAppM.Text,
                    InsertDate = DateTime.Now,
                    EventDate = null,
                    EventMan = "",
                    IsCirculate = false,
                    UpdateDate = null,
                    UpdateMan = null,
                };
                var rsFormsAppInfo = new FormsAppInfo()
                {
                    Code = Code,
                    EmpId = rEmpS.EmpNobr,
                    EmpName = rEmpS.EmpName,
                    idProcess = 0,
                    ProcessId = lblProcessID.Text,
                    KeyDate = DateTime.Now,
                    SignState = "1",
                    InfoSign = rsFormsAppAbs.EmpName + "," + rsFormsAppAbs.DateB.ToShortDateString() + "," + rsFormsAppAbs.TimeB + "~" + rsFormsAppAbs.DateE.ToShortDateString() + "," + rsFormsAppAbs.TimeE + ",請" + rsFormsAppAbs.HolidayName + rsFormsAppAbs.Use.ToString() + rsFormsAppAbs.UnitCode + "," + rsFormsAppAbs.Note + "," + rsFormsAppAbs.AgentNote,
                    InfoMail = MessageSendMail.AbsBody(rsFormsAppAbs.EmpId, rsFormsAppAbs.EmpName, rsFormsAppAbs.DeptName, rsFormsAppAbs.HolidayName, rsFormsAppAbs.DateB, rsFormsAppAbs.TimeB, rsFormsAppAbs.DateE, rsFormsAppAbs.TimeE, rsFormsAppAbs.Use, rsFormsAppAbs.UnitCode, rsFormsAppAbs.Note, rsFormsAppAbs.AgentNote)

                };


                dcFlow.FormsAppAbs.InsertOnSubmit(rsFormsAppAbs);
                dcFlow.FormsAppInfo.InsertOnSubmit(rsFormsAppInfo);

                dcFlow.SubmitChanges();


                gvAppS.Rebind();
                var Script = "$(document).ready(function() {$('.footable').footable();});";
                ScriptManager.RegisterStartupScript(this, typeof(UpdatePanel), "footable", Script, true);
                Session["sProcessID"] = lblProcessID.Text;
                Session["FormCode"] = _FormCode;
                Session["FlowTreeID"] = lblFlowTreeID.Text;

                lblNotifyMsg.Text = "新增成功";
                lblErrorMsg.Text = "";
            }
            catch (Exception ex)
            {
                lblNotifyMsg.Text = "新增失敗";
                lblErrorMsg.Text = ex.Message;
            }

        }
        protected void gvAppS_NeedDataSource(object sender, RadListViewNeedDataSourceEventArgs e)
        {
            var rs = (from c in dcFlow.FormsAppAbs
                      where c.ProcessID == lblProcessID.Text
                      select c).ToList();
            gvAppS.DataSource = rs;

            var Script = "$(document).ready(function() {$('.footable').footable();});";
            ScriptManager.RegisterStartupScript(this, typeof(UpdatePanel), "footable", Script, true);
        }
        protected void gvAppS_DataBound(object sender, EventArgs e)
        {
        }
        protected void gvAppS_ItemCommand(object sender, RadListViewCommandEventArgs e)
        {
            string cn = e.CommandName;
            string ca = e.CommandArgument.ToString();


            var r = (from c in dcFlow.FormsAppAbs
                     where c.AutoKey == Convert.ToInt32(ca)
                     select c).FirstOrDefault();

            if (cn == "Del")
            {
                if (r != null)
                {
                    dcFlow.FormsAppAbs.DeleteOnSubmit(r);

                    dcFlow.SubmitChanges();
                    lblNotifyMsg.Text = "刪除成功";
                }
            }
            gvAppS.Rebind();
        }
        protected void btnUpload_Click(object sender, EventArgs e)
        {
            var cn = ((RadButton)sender).CommandName;
            var ca = ((RadButton)sender).CommandArgument;

            var Code = (from c in dcFlow.FormsAppAbs
                        where c.AutoKey.ToString() == ca
                        select c.Code).FirstOrDefault();
            UnobtrusiveSession.Session["FormGuidCode"] = Code;

            ucFileManage._lblKey.Text = ca;
            ucFileManage._lvMain.Rebind();
        }
    }
}