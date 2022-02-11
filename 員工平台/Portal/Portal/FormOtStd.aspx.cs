﻿using Bll.Flow.Vdb;
using Bll.OverTime;
using Bll.Salary.Vdb;
using Dal;
using Dal.Dao.Employee;
using Dal.Dao.Flow;
using Dal.Dao.Salary;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace Portal
{
    public partial class FormOtStd : WebPageBase
    {
        private dcHrDataContext dcHR = new dcHrDataContext();

        private dcFlowDataContext dcFlow = new dcFlowDataContext();
        private string _FormCode = "Ot";
        private List<string> arrHoidDay = new List<string> { "00", "0Y", "0X", "0Z" };
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
                txtTimeB.Text = "0000";
                txtTimeE.Text = "0000";
                SetDefault();
                SetInfoAppM();

                txtNameAppS_DataBind();
                ddlDepts_DataBind();
                ddlOtrcd_DataBind();
                ddlOtCat_DataBind();
                ddlRote_DataBind();
                var IsCompensatoryFirst = (from c in dcFlow.FormsExtend
                                           where c.FormsCode == "Ot" && c.Code == "IsCompensatoryFirst" && c.Active == true
                                           select c).FirstOrDefault();

                if (IsCompensatoryFirst != null)
                {
                    if (ddlOtCat.FindItemByValue("2") != null)
                        ddlOtCat.FindItemByValue("2").Selected = true;
                }

                var OtPreset = (from c in dcFlow.FormsExtend
                                where c.FormsCode == "Ot" && c.Code == "OtPreset" && c.Active == true
                                select c).ToList();

                if (OtPreset.Any())
                    SetRoteTime(lblNobrAppM.Text, DateTime.Now.Date);

                SetCardTime(lblNobrAppM.Text, DateTime.Now.Date);
                SetRote(lblNobrAppM.Text, DateTime.Now.Date);
                SetTime(lblNobrAppM.Text, DateTime.Now.Date);
                SetDepts(lblNobrAppM.Text);
                SetTotalOtHours(lblNobrAppM.Text, DateTime.Now.Date);
                var Extend = (from c in dcFlow.FormsExtend
                              where c.Code == "OtRoteChangable" && c.Active == true && c.FormsCode == "Ot"
                              select c).FirstOrDefault();
                var OtInfoExtend = (from c in dcFlow.FormsExtend
                                    where c.Code == "OtInfoVisible" && c.Active == true && c.FormsCode == "Ot"
                                    select c).FirstOrDefault();
                if (Extend != null)
                    ddlRote.Enabled = false;
                if (OtInfoExtend != null)
                    plOtInfo.Visible = false;
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
            if (rEmpM == null)
            {
                //RadWindowManager1.RadAlert("人事資料有誤，請通知人事", 300, 100, "警告訊息", "", "");
                return;
            }
        }

        #region 資料繫結
        private void ddlOtrcd_DataBind()
        {
            OldDal.Dao.Att.OtDao oOtDao = new OldDal.Dao.Att.OtDao(dcHR.Connection);
            var rsOtrcd = oOtDao.GetOtrcd();

            ddlOtrcd.DataSource = rsOtrcd;
            ddlOtrcd.DataTextField = "Name";
            ddlOtrcd.DataValueField = "Code";
            ddlOtrcd.DataBind();
        }
        private void ddlOtCat_DataBind()
        {
            RadComboBoxItem it = new RadComboBoxItem();

            it.Text = "加班費";
            it.Value = "1";

            ddlOtCat.Items.Add(it);

            it = new RadComboBoxItem();

            it.Text = "補休假";
            it.Value = "2";

            ddlOtCat.Items.Add(it);
        }
        private void ddlRote_DataBind()
        {
            OldDal.Dao.Att.RoteDao oRoteDao = new OldDal.Dao.Att.RoteDao(dcHR.Connection);
            var rsRote = oRoteDao.GetRoteByOt();
            OldDal.Dao.Bas.BasDao oBasDao = new OldDal.Dao.Bas.BasDao(dcHR.Connection);
            var rsBas = oBasDao.GetBaseByNobr(lblNobrAppM.Text, DateTime.Now.Date).FirstOrDefault();

            ddlRote.DataSource = rsRote;
            ddlRote.DataTextField = "RoteName";
            ddlRote.DataValueField = "RoteCode";
            ddlRote.DataBind();
        }
        private void ddlDepts_DataBind()
        {
            OldDal.Dao.Bas.DeptDao oDeptDao = new OldDal.Dao.Bas.DeptDao(dcHR.Connection);
            var rsDept = oDeptDao.GetDepts();

            ddlDepts.DataSource = rsDept;
            ddlDepts.DataTextField = "Name";
            ddlDepts.DataValueField = "Code";
            ddlDepts.DataBind();
        }
        public void txtNameAppS_DataBind()
        {
            var OtOnlyShowSelf = (from c in dcFlow.FormsExtend
                                  where c.FormsCode == "Ot" && c.Code == "OtOnlyShowSelf" && c.Active == true
                                  select c).FirstOrDefault();
            if (OtOnlyShowSelf == null)
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
            else
            {
                var result = new List<Bll.TextValueRow>();
                var rs = new Bll.TextValueRow();
                rs.Text = _User.EmpName + "," + _User.EmpId;
                rs.Value = _User.EmpId;
                result.Add(rs);
                txtNameAppS.DataSource = result;
                txtNameAppS.DataTextField = "Text";
                txtNameAppS.DataValueField = "Value";
                txtNameAppS.DataBind();
            }

        }
        #endregion

        #region 載入初始值
        private void SetTotalOtHours(string sNobr, DateTime dDate)
        {
            decimal OtHours = 0;
            decimal OtFlowHours = 0;
            OldDal.Dao.Att.OtDao oOtDao = new OldDal.Dao.Att.OtDao(dcHR.Connection);
            DateTime Date = dDate;
            //判斷記薪週期
            OldDal.Dao.Sal.SalaryLockDao oSalaryLockDao = new OldDal.Dao.Sal.SalaryLockDao(dcHR.Connection);
            var TwoDate = oSalaryLockDao.GetSalDate(Date);
            OtHours = oOtDao.GetHoursSum(sNobr, TwoDate.DateA, TwoDate.DateD, false);

            var rsAppS = (from c in dcFlow.FormsAppOt
                          where ((c.ProcessID == lblProcessID.Text && c.SignState == "1") || (c.idProcess != 0 && c.SignState == "1"))
                          && c.EmpId == sNobr
                          select c).ToList();

            var rsFlow = rsAppS.Where(p => TwoDate.DateA <= p.DateB && p.DateB <= TwoDate.DateD).ToList();
            if (rsFlow.Count > 0)
                OtFlowHours += rsFlow.Sum(p => p.Use); //加班時數

            lblTotalOtHours.Text = OtHours.ToString();
            lblTotalOtGFlowHours.Text = OtFlowHours.ToString();
        }
        private void SetDepts(string sNobr)
        {
            OldDal.Dao.Bas.BasDao oBasDao = new OldDal.Dao.Bas.BasDao(dcHR.Connection);
            var rBasS = oBasDao.GetBaseByNobr(sNobr, DateTime.Now.Date).FirstOrDefault();

            if (rBasS != null)
            {
                if (ddlDepts.Items.FindItemByValue(rBasS.DeptsCode) != null)
                    ddlDepts.Items.FindItemByValue(rBasS.DeptsCode).Selected = true;
            }
        }
        private void SetCardTime(string sNobr, DateTime dDate)
        {
            lblCardTime.Text = "";

            string Card = GetCardTime(sNobr, dDate.AddDays(-1));
            if (Card.Length > 0)
                lblCardTime.Text = Card;

            Card = GetCardTime(sNobr, dDate);
            if (Card.Length > 0)
            {
                if (lblCardTime.Text.Length > 0)
                    lblCardTime.Text += "<BR>";
                lblCardTime.Text += Card;
            }

            Card = GetCardTime(sNobr, dDate.AddDays(1));
            if (Card.Length > 0)
            {
                if (lblCardTime.Text.Length > 0)
                    lblCardTime.Text += "<BR>";
                lblCardTime.Text += Card;
            }
            if (lblCardTime.Text == "")
            {
                lblCardTime.Text = "無出勤資料";
            }
        }
        private string GetCardTime(string sNobr, DateTime dDate)
        {
            string Card = "";

            OldDal.Dao.Att.AttcardDao oAttcardDao = new OldDal.Dao.Att.AttcardDao(dcHR.Connection);

            var rsAttCard = oAttcardDao.GetAttcard(sNobr, dDate.Date);
            if (rsAttCard.Count > 0)
            {
                //Card = dDate.ToString("M/d") + "：";
                Card = dDate.ToShortDateString() + "：";
                foreach (var rCard in rsAttCard)
                {
                    if (rCard.OffCardTime48.CompareTo("2400") > 0)
                    {
                        Card += rCard.OnCardTime24 + " - " + dDate.AddDays(1).ToShortDateString() + "：" + rCard.OffCardTime24;

                    }
                    else
                        Card += rCard.OnCardTime24 + " - " + dDate.ToShortDateString() + "：" + rCard.OffCardTime24;
                    //Card += rCard.OnCardTime24 + "-" + rCard.OffCardTime24;
                }
            }

            return Card;
        }
        private void SetTime(string sNobr, DateTime dDate)
        {
            //txtTimeB.Text = "0000";
            //txtTimeE.Text = "0000";

            //OldDal.Dao.Att.AttendDao oAttendDao = new OldDal.Dao.Att.AttendDao(dcHR.Connection);
            //var rAttend = oAttendDao.GetAttend(sNobr, dDate).FirstOrDefault();

            //OldDal.Dao.Att.AttcardDao oAttcardDao = new OldDal.Dao.Att.AttcardDao(dcHR.Connection);
            //var rAttcard = oAttcardDao.GetAttcard(sNobr, dDate).FirstOrDefault();

            //if (rAttend != null)
            //{
            //    OldDal.Dao.Att.RoteDao oRoteDao = new OldDal.Dao.Att.RoteDao(dcHR.Connection);
            //    var rRote = oRoteDao.GetRoteDetail(new List<string>() { rAttend.RoteCode }).FirstOrDefault();

            //    if (rRote != null)
            //    {
            //        //平日 先帶入下班時間
            //        if (!arrHoidDay.Contains(rRote.RoteCode))
            //        {
            //            txtTimeB.Text = rRote.OtBeginTime;
            //            txtTimeE.Text = rRote.OtBeginTime;
            //        }
            //        else
            //        {
            //            //假日帶入刷卡T1的時間
            //            if (rAttcard != null && rAttcard.OnCardTime48.Length > 0)
            //                txtTimeB.Text = rAttcard.OnCardTime48;
            //        }

            //        //共同帶入刷卡下班時間
            //        if (rAttcard != null && rAttcard.OffCardTime48.Length > 0)
            //            txtTimeE.Text = rAttcard.OffCardTime48;
            //    }
            //}
        }
        private void SetRoteTime(string sNobr, DateTime dDate)
        {
            txtTimeB.Text = "0000";
            txtTimeE.Text = "0000";

            OldDal.Dao.Att.AttendDao oAttendDao = new OldDal.Dao.Att.AttendDao(dcHR.Connection);
            OldDal.Dao.Att.AttcardDao oAttcardDao = new OldDal.Dao.Att.AttcardDao(dcHR.Connection);
            var rAttend = oAttendDao.GetAttend(sNobr, dDate).FirstOrDefault();
            var rAttcard = oAttcardDao.GetAttcard(sNobr, dDate).FirstOrDefault();
            if (rAttend != null)
            {
                OldDal.Dao.Att.RoteDao oRoteDao = new OldDal.Dao.Att.RoteDao(dcHR.Connection);
                var rRote = oRoteDao.GetRoteDetail(new List<string>() { rAttend.RoteCodeH }).FirstOrDefault();

                if (rRote != null)
                {
                    txtTimeB.Text = rRote.OtBeginTime != "" ? rRote.OtBeginTime : rRote.OffTime;
                    if (rAttend.IsHoliDay)
                    {
                        if (rAttcard != null && rAttcard.OnCardTime48 != "")
                        {
                            txtTimeB.Text = rAttcard.OnCardTime48;
                        }
                    }

                    if (rAttcard != null && rAttcard.OffCardTime48 != "")
                    {
                        txtTimeE.Text = rAttcard.OffCardTime48;
                    }
                    else
                    {
                        string TimeE = "";

                        TimeE = rRote.OtBeginTime != "" ? rRote.OtBeginTime : rRote.OffTime;

                        if (TimeE.CompareTo("2400") >= 0)
                        {
                            txtDateE.SelectedDate = txtDateE.SelectedDate.Value.AddDays(1);
                            txtTimeE.Text = (Convert.ToInt32(TimeE) - 2400).ToString("0000");
                        }
                        else
                            txtTimeE.Text = TimeE;
                    }

                }
            }
        }
        private void SetRote(string sNobr, DateTime dDate)
        {
            OldDal.Dao.Att.AttendDao oAttendDao = new OldDal.Dao.Att.AttendDao(dcHR.Connection);
            var rAttend = oAttendDao.GetAttendH(sNobr, dDate).FirstOrDefault();

            string RoteCode = oAttendDao.GetAttendFixedRoteCode(sNobr, dDate);
            if (rAttend != null)
                RoteCode = rAttend.RoteCodeH;

            if (ddlRote.Items.FindItemByValue(RoteCode) != null)
                ddlRote.Items.FindItemByValue(RoteCode).Selected = true;
        }
        #endregion

        #region 姓名載入
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

            var OtKeeptxtTime = (from c in dcFlow.FormsExtend
                                 where c.FormsCode == "Ot" && c.Code == "OtKeeptxtTime" && c.Active == true
                                 select c).ToList();

            if (OtKeeptxtTime.Any())
            {
                string Nobr = lblNobrAppS.Text;
                DateTime Date = txtDateB.SelectedDate.GetValueOrDefault(DateTime.Now).Date;

                //SetTime(Nobr, Date);
                SetCardTime(Nobr, Date);
                SetTotalOtHours(Nobr, Date);
                SetOt1Time();
                SetRote(Nobr, Date);
                SetDepts(lblNobrAppS.Text);
            }
            else
            {
                txtDateB_SelectedDateChanged(null, null);
                SetDepts(lblNobrAppS.Text);
            }
        }

        private void SetOt1Time()
        {
            var oOtDao = new OldDal.Dao.Att.OtDao(dcHR.Connection);

            var Ot1Time = oOtDao.GetOt1(lblNobrAppS.Text, txtDateB.SelectedDate.GetValueOrDefault(), txtDateE.SelectedDate.GetValueOrDefault());
            if (Ot1Time.Count > 0)
            {
                txtTimeB.Text = Ot1Time[0].TimeB;
                txtTimeE.Text = Ot1Time[Ot1Time.Count - 1].TimeE;
            }
        }
        #endregion
        protected void txtDateB_SelectedDateChanged(object sender, Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs e)
        {
            string Nobr = lblNobrAppS.Text;
            DateTime Date = txtDateB.SelectedDate.GetValueOrDefault(DateTime.Now).Date;

            txtDateE.SelectedDate = Date;
            SetTime(Nobr, Date);
            SetCardTime(Nobr, Date);

            var OtPreset = (from c in dcFlow.FormsExtend
                            where c.FormsCode == "Ot" && c.Code == "OtPreset" && c.Active == true
                            select c).ToList();

            if (OtPreset.Any())
                SetRoteTime(Nobr, Date);

            SetTotalOtHours(Nobr, Date);
            SetOt1Time();
            SetRote(Nobr, Date);
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            var rsCount = (from c in dcFlow.FormsAppOt
                           where c.ProcessID == lblProcessID.Text
                           select c).ToList();

            if (txtDateB.SelectedDate == null || txtDateE.SelectedDate == null)
            {
                lblErrorMsg.Text = "您的開始或結束日期沒有輸入正確";
                return;
            }

            string Nobr = lblNobrAppS.Text;
            string OtCat = ddlOtCat.SelectedItem.Value;
            string Otrcd = ddlOtrcd.SelectedItem.Value;
            string Rote = ddlRote.SelectedItem.Value;
            string RoteName = ddlRote.SelectedItem.Text;
            string Depts = ddlDepts.SelectedItem.Value;
            DateTime DateB = txtDateB.SelectedDate.Value;
            DateTime DateE = txtDateE.SelectedDate.Value;
            string TimeB = txtTimeB.Text;
            string TimeE = txtTimeE.Text;
            string Note = txtNote.Text.Trim();
            bool IsNightShift = false;
            OldDal.Dao.Bas.BasDao oBasDao = new OldDal.Dao.Bas.BasDao(dcHR.Connection);
            var rBasS = oBasDao.GetBaseByNobr(Nobr, DateB).FirstOrDefault();

            if (rBasS == null)
            {
                lblErrorMsg.Text = "基本資料不正確，請洽人事單位";
                return;
            }

            if (TimeB.Length != 4 || TimeE.Length != 4)
            {
                lblErrorMsg.Text = "您所輸入的時間不正確";
                return;
            }

            if (Convert.ToInt32(TimeB) >= 2400 || Convert.ToInt32(TimeE) >= 2400)
            {
                lblErrorMsg.Text = "請用24小時制輸入";
                return;

            }

            var RoteH = "";
            var RoteHName = "";
            var rBasM = oBasDao.GetBaseByNobr(lblNobrAppM.Text, DateB).FirstOrDefault();
            OldDal.Dao.Att.AttendDao oAttendDao = new OldDal.Dao.Att.AttendDao(dcHR.Connection);
            OldDal.Dao.Att.RoteDao oRoteDao = new OldDal.Dao.Att.RoteDao(dcHR.Connection);
            OldDal.Dao.Att.AttcardDao oAttcardDao = new OldDal.Dao.Att.AttcardDao(dcHR.Connection);
            DateTime DateTimeB = DateB.Date.AddMinutes(Bll.Tools.TimeTrans.ConvertHhMmToMinutes(TimeB));
            DateTime DateTimeE = DateE.Date.AddMinutes(Bll.Tools.TimeTrans.ConvertHhMmToMinutes(TimeE));
            OldDal.Dao.Att.OtDao oOtDao = new OldDal.Dao.Att.OtDao(dcHR.Connection);

            var OtOver = (from c in dcFlow.FormsExtend
                          where c.FormsCode == "Ot" && c.Code == "OtOver" && c.Active == true
                          select c).FirstOrDefault();
            var rsAttcard = oAttcardDao.GetAttcard(Nobr, DateB.AddDays(-1), DateB);
            foreach (var rAttcard in rsAttcard)
            {
                var bCardTime = false;

                bCardTime = rAttcard.DateTimeB <= DateTimeB && DateTimeB <= rAttcard.DateTimeE;
                bCardTime = bCardTime && (rAttcard.DateTimeB <= DateTimeE && DateTimeE <= rAttcard.DateTimeE);

                if (bCardTime)
                {
                    IsNightShift = DateB != rAttcard.Date;
                    DateB = rAttcard.Date;
                    break;
                }
            }

            //if (oRoteDao.RoteIsNightShift(Rote))//夜班需-1天
            //{
            //    DateB = DateB.AddDays(-1);
            //    IsNightShift = true;
            //}

            DateTime calDateB = new DateTime(DateB.Year, DateB.Month, 1).Date;
            DateTime calDateE = new DateTime(DateB.Year, DateB.Month, DateTime.DaysInMonth(DateB.Year, DateB.Month)).Date;

            var oAttDateCycle = new AttDateCycleDao();
            var AttDateCycleCond = new AttDateCycleConditions();
            AttDateCycleCond.AccessToken = _User.AccessToken;
            AttDateCycleCond.RefreshToken = _User.RefreshToken;
            AttDateCycleCond.CompanySetting = CompanySetting;
            AttDateCycleCond.nobr = _User.EmpId;
            AttDateCycleCond.date = DateB;
            var rsAttDateCycle = oAttDateCycle.GetData(AttDateCycleCond);
            if (rsAttDateCycle.Status && rsAttDateCycle.Data != null)
            {
                var rAttDateCycle = rsAttDateCycle.Data as AttDateCycleRow;
                if (rAttDateCycle != null)
                {
                    calDateB = rAttDateCycle.DateB;
                    calDateE = rAttDateCycle.DateE;
                }

            }


            var calHour = oOtDao.GetHoursSum(Nobr, calDateB, calDateE, false);

            //var rsAppS = (from c in dcFlow.FormsAppOt
            //              where (c.ProcessID == lblProcessID.Text || (c.idProcess != 0 && c.SignState == "1"))
            //              && c.EmpId == Nobr
            //              select c).ToList();


            var rsAppS = (from c in dcFlow.FormsAppOt
                          where ((c.ProcessID == lblProcessID.Text && c.SignState == "1") || (c.idProcess != 0 && c.SignState == "1"))
                          && c.EmpId == Nobr
                          select c).ToList();

            var rsFlow = rsAppS.Where(p => calDateB <= p.DateB && p.DateB <= calDateE).ToList();
            if (rsFlow.Count > 0)
                calHour += rsFlow.Sum(p => p.Use);

            

            var GetAttend = oAttendDao.GetAttendH(lblNobrAppS.Text, DateB).FirstOrDefault();
            if (GetAttend != null)
            {
                RoteH = GetAttend.RoteCodeH;
                var rsRote = oRoteDao.GetRote();
                RoteHName = rsRote.Where(p => p.RoteCode == RoteH).FirstOrDefault().RoteName;
            }
            var RoteDetail = oRoteDao.GetRoteDetail();

            var rAttendDate = oAttendDao.GetAttendH(Nobr, DateB).FirstOrDefault();
            if (rAttendDate == null)
            {
                lblErrorMsg.Text = "出勤資料錯誤，請洽人事單位";
                return;
            }

            var rAttend = oAttendDao.GetAttend(Nobr, DateB.Date).FirstOrDefault();
            var Is0XOt = (from c in dcFlow.FormsExtend
                          where c.FormsCode == "Ot" && c.Active == true && c.Code == "Is0XOt"
                          select c).FirstOrDefault();

            if (Is0XOt != null && rAttend.RoteCode == "0X")
            {
                lblErrorMsg.Text = "休息日無法申請加班";
                return;
            }

            var Is0ZOt = (from c in dcFlow.FormsExtend
                          where c.FormsCode == "Ot" && c.Active == true && c.Code == "Is0ZOt"
                          select c).FirstOrDefault();
            if (Is0ZOt != null && rAttend.RoteCode == "0Z")
            {
                lblErrorMsg.Text = "例假日無法申請加班";
                return;
            }

            if (IsNightShift)//夜班前面判斷需-1天，這邊加回來
            {
                DateB = DateB.AddDays(1);
            }

            var IsPer30Mins = (from c in dcFlow.FormsExtend
                               where c.FormsCode == "Ot" && c.Active == true && c.Code == "IsPer30Mins"
                               select c).FirstOrDefault();

            if (IsPer30Mins != null)
            {

                int iTimeB = Bll.Tools.TimeTrans.ConvertHhMmToMinutes(TimeB);
                int iTimeE = Bll.Tools.TimeTrans.ConvertHhMmToMinutes(TimeE);
                int iTemp;

                iTemp = (30 - (iTimeB % 30));
                iTimeB = iTemp == 30 ? iTimeB : iTimeB + iTemp;
                TimeB = Bll.Tools.TimeTrans.ConvertMinutesToHhMm(iTimeB);

                iTemp = iTimeE % 30;
                iTimeE -= iTemp;
                TimeE = Bll.Tools.TimeTrans.ConvertMinutesToHhMm(iTimeE);
            }
            //DateTimeB = DateB.Date.AddMinutes(Bll.Tools.TimeTrans.ConvertHhMmToMinutes(TimeB));
            //DateTimeE = DateE.Date.AddMinutes(Bll.Tools.TimeTrans.ConvertHhMmToMinutes(TimeE));

            if (DateTimeB >= DateTimeE)
            {
                lblErrorMsg.Text = "您的開始日期時間不能大於或等於結束日期時間";
                return;
            }

            OldDal.Dao.Att.AbsDao oAbsDao = new OldDal.Dao.Att.AbsDao(dcHR.Connection);

            if (DateTimeB.Date < DateTime.Now.Date)
            {

                var rsAbs = oAbsDao.GetAbs(Nobr, DateE, DateE);
                var lsHcode = new List<string>();

                var OtAbs1Hcode = (from c in dcFlow.FormsExtend
                                   where c.FormsCode == "Ot" && c.Active == true && c.Code == "OtAbs1Hcode"
                                   select c).FirstOrDefault();
                if (OtAbs1Hcode != null)
                {
                    var sHcode = OtAbs1Hcode.Column1.Split(';').ToList();
                    lsHcode.AddRange(sHcode);
                }
                else
                {
                    lsHcode.Add("N");
                }
                var lsAbs = rsAbs.Where(p => lsHcode.Contains(p.Hcode)).ToList();
                bool IsAbs = false;
                foreach (var rAbs in lsAbs)
                {
                    if (rAbs != null)
                    {
                        DateTime dDateTimeB, dDateTimeE;
                        dDateTimeB = DateE.Date.AddMinutes(Bll.Tools.TimeTrans.ConvertHhMmToMinutes(TimeB));    //加班開始日期時間
                        dDateTimeE = DateE.Date.AddMinutes(Bll.Tools.TimeTrans.ConvertHhMmToMinutes(TimeE));    //加班結束日期時間

                        DateTime dAbsDateTimeB, dAbsDateTimeE;
                        dAbsDateTimeB = rAbs.DateE.Date.AddMinutes(Bll.Tools.TimeTrans.ConvertHhMmToMinutes(rAbs.TimeB));    //實際開始日期時間
                        dAbsDateTimeE = rAbs.DateE.Date.AddMinutes(Bll.Tools.TimeTrans.ConvertHhMmToMinutes(rAbs.TimeE));    //實際結束日期時間

                        if (dAbsDateTimeB <= dDateTimeB && dDateTimeE <= dAbsDateTimeE)
                        {
                            IsAbs = true;
                        }
                    }
                }

                if (!IsAbs && !oAttcardDao.IsCardTime(Nobr, DateB, DateE, TimeB, TimeE))
                {
                    lblErrorMsg.Text = "您所申請的時間不在刷卡或公出時間裡";
                    return;
                }
            }



            //DateTime AppDate = Convert.ToDateTime(rAttendDate.Text);

            //if (DateB < AppDate)
            //{
            //    RadWindowManager1.RadAlert("您所申請的日期必須是前一次出勤日三日之後，請洽人事單位", 300, 100, "警告訊息", "", "");
            //    return;
            //}

            if (DateTimeB > DateTime.Now)
            {
                lblErrorMsg.Text = "不可申請預估加班單";
                return;
            }

            //var rAttend = oAttendDao.GetAttend(Nobr, DateB.Date).FirstOrDefault();
            //if (rAttend != null)
            //{
            //    if (rAttend.RoteCode == "0Z")
            //    {
            //        lblErrorMsg.Text = "例假日不可申请加班";
            //        return;
            //    }
            //}

            //檢查重複的資料
            foreach (var rAppS in rsAppS)
            {
                var FormCode = "";

                if (rAppS.idProcess != 0)
                {
                    var r = (from c in dcFlow.FormsApp
                             where c.ProcessID == rAppS.ProcessID
                             select c.FormsCode).FirstOrDefault();
                    FormCode = r;
                }

                if (rAppS.DateTimeB < DateTimeE && rAppS.DateTimeE > DateTimeB && FormCode != "Ot1")
                {
                    lblErrorMsg.Text = "資料重複或流程正在進行中";
                    return;
                }
            }

            var rsOt = oOtDao.GetOt(Nobr, DateB.AddDays(-1).Date, DateE.AddDays(1).Date);

            if (rsOt.Where(p => p.DateTimeB < DateTimeE && p.DateTimeE > DateTimeB).Any())
            {
                lblErrorMsg.Text = "人事資料重複";
                return;
            }

            var Calculate = 0M;

            var OtMin = 0.5M;

            bool noCalc = OtrcdnoCalc(Otrcd);//判斷加班原因是否要計算休息時間

            var OtIntervalExtend = (from c in dcFlow.FormsExtend
                                    where c.FormsCode == "Ot" && c.Code == "OtInterval" && c.Active == true
                                    select c).ToList();
            if (OtIntervalExtend.Any())
            {
                OtMin = Convert.ToDecimal(OtIntervalExtend.First().Column1);
                var IntervalTime = Convert.ToDecimal(OtIntervalExtend.First().Column2);
                Calculate = oOtDao.GetCalculate(Nobr, OtCat, DateB, DateE, TimeB, TimeE, Otrcd, 0, Rote, bTime24: true, bCalculateRes: !noCalc, InterVal: IntervalTime);
            }

            else
                Calculate = oOtDao.GetCalculate(Nobr, OtCat, DateB, DateE, TimeB, TimeE, Otrcd, 0, Rote, bTime24: true, bCalculateRes: !noCalc);

            if (Calculate < OtMin)
            {
                lblErrorMsg.Text = "計算時數必須大於" + OtMin.ToString() + "小時";
                return;
            }

            var OtLimit = 46M;//加班上限
            var oEmployeeRuleDao = new EmployeeRuleDao();
            var EmployeeRuleCond = new EmployeeRuleConditions();

            EmployeeRuleCond.AccessToken = _User.AccessToken;
            EmployeeRuleCond.RefreshToken = _User.RefreshToken;
            EmployeeRuleCond.CompanySetting = CompanySetting;
            EmployeeRuleCond.employeeId = Nobr;
            EmployeeRuleCond.ruleType = "OtHrsMonthlyMax";
            EmployeeRuleCond.checkDate = IsNightShift ? DateB.AddDays(-1):DateB;
            var rsEmployeeRule = oEmployeeRuleDao.GetData(EmployeeRuleCond);
            var rEmployeeRule = new List<EmployeeRuleRow>();
            if (rsEmployeeRule.Status)
            {
                if (rsEmployeeRule.Data != null)
                {
                    rEmployeeRule = rsEmployeeRule.Data as List<EmployeeRuleRow>;
                    if (rEmployeeRule != null && rEmployeeRule.Count != 0)
                    {
                        var rAttHrsDailyMax = rEmployeeRule.FirstOrDefault();
                        if (rAttHrsDailyMax != null)
                        {
                            OtLimit = Convert.ToDecimal(rAttHrsDailyMax.value);
                        }
                    }
                }
            }

            //calHour += r.iTotalHour;
            calHour += Calculate;
            if (OtOver == null)
            {
                if (calHour > OtLimit)
                {
                    if ((IsNightShift ? DateB.AddDays(-1) : DateB) > new DateTime(2022, 1, 26))
                    {
                        lblErrorMsg.Text = Nobr + "本月加班時數已超過上限，請洽人事單位";
                        return;
                    }
                }
            }

            decimal AttHrsDailyMax = 12;

            var ExtAttHrsDailyMax = (from c in dcFlow.FormsExtend
                                     where c.FormsCode == "Ot" && c.Code == "AttHrsDailyMax" && c.Active == true
                                     select c).ToList();

            if (ExtAttHrsDailyMax.Any())
            {
                oEmployeeRuleDao = new EmployeeRuleDao();
                EmployeeRuleCond = new EmployeeRuleConditions();

                EmployeeRuleCond.AccessToken = _User.AccessToken;
                EmployeeRuleCond.RefreshToken = _User.RefreshToken;
                EmployeeRuleCond.CompanySetting = CompanySetting;
                EmployeeRuleCond.employeeId = Nobr;
                EmployeeRuleCond.ruleType = "AttHrsDailyMax";
                EmployeeRuleCond.checkDate = IsNightShift ? DateB.AddDays(-1) : DateB; 
                rsEmployeeRule = oEmployeeRuleDao.GetData(EmployeeRuleCond);
                rEmployeeRule = new List<EmployeeRuleRow>();
                if (rsEmployeeRule.Status)
                {
                    if (rsEmployeeRule.Data != null)
                    {
                        rEmployeeRule = rsEmployeeRule.Data as List<EmployeeRuleRow>;
                        if (rEmployeeRule != null && rEmployeeRule.Count != 0)
                        {
                            var rAttHrsDailyMax = rEmployeeRule.FirstOrDefault();
                            if (rAttHrsDailyMax != null)
                            {
                                AttHrsDailyMax = Convert.ToDecimal(rAttHrsDailyMax.value);
                            }
                        }
                    }
                }
                decimal WorkHour = 0;
                if (!GetAttend.IsHoliDay)
                    WorkHour = RoteDetail.Where(p => p.RoteCode == GetAttend.RoteCodeH).FirstOrDefault().WorkHour;
                if (WorkHour + Calculate > AttHrsDailyMax)
                {
                    lblErrorMsg.Text = "單日出勤時數已超過上限";
                    return;
                }
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


            DateTime DateB1 = DateB;
            DateTime DateE1 = DateE;
            string TimeB1 = TimeB;
            string TimeE1 = TimeE;

            var Code = Guid.NewGuid().ToString();

            var rsFormsAppOt = new FormsAppOt();
            rsFormsAppOt.Code = Code;
            rsFormsAppOt.ProcessID = lblProcessID.Text;
            rsFormsAppOt.idProcess = 0;
            rsFormsAppOt.EmpId = Nobr;
            rsFormsAppOt.EmpName = rEmpS.EmpName;
            rsFormsAppOt.DeptCode = rEmpS.DeptCode;
            rsFormsAppOt.DeptName = rEmpS.DeptName;
            rsFormsAppOt.JobCode = rEmpS.JobCode;
            rsFormsAppOt.JobName = rEmpS.JobName;
            rsFormsAppOt.RoleId = rEmpS.RoleId;
            rsFormsAppOt.DateTimeB1 = DateTimeB;
            rsFormsAppOt.DateTimeE1 = DateTimeE;
            rsFormsAppOt.DateB1 = DateB1;
            rsFormsAppOt.DateE1 = DateE1;
            rsFormsAppOt.TimeB1 = TimeB1;
            rsFormsAppOt.TimeE1 = TimeE1;
            rsFormsAppOt.DateTimeB = DateTimeB;
            rsFormsAppOt.DateTimeE = DateTimeE;
            rsFormsAppOt.DateB = DateB;
            rsFormsAppOt.DateE = DateE;
            rsFormsAppOt.TimeB = TimeB;
            rsFormsAppOt.TimeE = TimeE;
            rsFormsAppOt.RoteCode = Rote;
            rsFormsAppOt.RoteName = RoteName;
            rsFormsAppOt.RotehCode = RoteH;
            rsFormsAppOt.RotehName = RoteHName;
            rsFormsAppOt.OtCateCode = OtCat;
            rsFormsAppOt.OtCateName = ddlOtCat.SelectedItem.Text;
            rsFormsAppOt.OtrcdCode = Otrcd;
            rsFormsAppOt.OtrcdName = ddlOtrcd.SelectedItem.Text;
            rsFormsAppOt.DeptsCode = Depts;
            rsFormsAppOt.DeptsName = ddlDepts.SelectedItem.Text;
            rsFormsAppOt.Use = Calculate;
            rsFormsAppOt.UnitCode = "";
            rsFormsAppOt.IsExceptionUse = false;
            rsFormsAppOt.ExceptionUse = 0;
            rsFormsAppOt.Sign = true;
            rsFormsAppOt.SignState = "1";
            rsFormsAppOt.Note = txtNote.Text;
            rsFormsAppOt.Status = "1";
            rsFormsAppOt.InsertDate = DateTime.Now;
            rsFormsAppOt.InsertMan = _User.EmpId;

            var rsFormsAppInfo = new FormsAppInfo()
            {
                Code = Code,
                EmpId = rEmpS.EmpNobr,
                EmpName = rEmpS.EmpName,
                idProcess = 0,
                ProcessId = lblProcessID.Text,
                KeyDate = DateTime.Now,
                SignState = "1",
                InfoSign = rsFormsAppOt.EmpName + "," + rsFormsAppOt.DateB.ToShortDateString() + "," + rsFormsAppOt.TimeB + "~" + rsFormsAppOt.DateE.ToShortDateString() + "," + rsFormsAppOt.TimeE + rsFormsAppOt.Use + "小時," + rsFormsAppOt.Note,
                InfoMail = MessageSendMail.OtBody(rsFormsAppOt.EmpId, rsFormsAppOt.EmpName, rsFormsAppOt.DeptName, RoteName, rsFormsAppOt.DateB, rsFormsAppOt.TimeB, rsFormsAppOt.TimeE, rsFormsAppOt.Use, rsFormsAppOt.OtCateName, rsFormsAppOt.Note)
            };

            dcFlow.FormsAppOt.InsertOnSubmit(rsFormsAppOt);
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
        protected void gvAppS_NeedDataSource(object sender, RadListViewNeedDataSourceEventArgs e)
        {
            var rs = (from c in dcFlow.FormsAppOt
                      where c.ProcessID == lblProcessID.Text
                      select c).ToList();
            gvAppS.DataSource = rs;

            var Script = "$(document).ready(function() {$('.footable').footable();});";
            ScriptManager.RegisterStartupScript(this, typeof(UpdatePanel), "footable", Script, true);
        }
        protected void gvAppS_ItemCommand(object sender, RadListViewCommandEventArgs e)
        {
            string cn = e.CommandName;
            string ca = e.CommandArgument.ToString();


            var r = (from c in dcFlow.FormsAppOt
                     where c.AutoKey == Convert.ToInt32(ca)
                     select c).FirstOrDefault();


            if (cn == "Del")
            {
                if (r != null)
                {
                    dcFlow.FormsAppOt.DeleteOnSubmit(r);

                    dcFlow.SubmitChanges();
                    lblNotifyMsg.Text = "刪除成功";
                }
            }
            gvAppS.Rebind();
        }

        protected void txtDateE_SelectedDateChanged(object sender, Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs e)
        {
            SetOt1Time();
        }
        private bool OtrcdnoCalc(string Otrcd)
        {
            bool noCalc = false;

            var oOverTimeReasonDao = new OvertimeReasonDao();
            var OverTimeReasonCond = new OverTimeReasonConditions();

            OverTimeReasonCond.AccessToken = _User.AccessToken;
            OverTimeReasonCond.RefreshToken = _User.RefreshToken;
            OverTimeReasonCond.CompanySetting = CompanySetting;
            var rsOverTimeReason = oOverTimeReasonDao.GetData(OverTimeReasonCond);
            var rOverTimeReason = new List<OverTimeReasonRow>();
            if (rsOverTimeReason.Status)
            {
                if (rsOverTimeReason.Data != null)
                {
                    rOverTimeReason = rsOverTimeReason.Data as List<OverTimeReasonRow>;
                    if (rOverTimeReason.Count != 0)
                    {
                        noCalc = rOverTimeReason.Where(p => p.otrcd1 == Otrcd).FirstOrDefault().nocalc.Value;
                    }
                }
            }


            return noCalc;
        }

        protected void gvAppS_DataBound(object sender, EventArgs e)
        {
            int count = 0;
            foreach (var item in gvAppS.Items)
            {
                var No = item.FindControl("lblListNumber") as RadLabel;
                if (No != null)
                {
                    count++;
                    No.Text = count.ToString();
                }

            }
            var lblAbsCount = gvAppS.FindControl("lblCount") as RadLabel;
            if (lblAbsCount != null)
                lblAbsCount.Text = count.ToString();
        }
    }
}