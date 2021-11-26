using Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace Portal
{
    public partial class FormShiftShortStd : WebPageBase
    {
        private dcHrDataContext dcHR = new dcHrDataContext();
        private dcFlowDataContext dcFlow = new dcFlowDataContext();
        private string _FormCode = "ShiftShort";


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
                txtDateA.SelectedDate = DateTime.Now.Date;
                txtDateB.SelectedDate = DateTime.Now.Date;
                lblNobrAppM.Text = _User.EmpId;

                SetDefault();
                SetInfoAppM();

                txtNameAppS_DataBind();
                txtRote_DataBind();
                txtDateA_SelectedDateChanged(null, null);
            }
        }
        #region 載入預設值
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
        private void txtRote_DataBind()
        {
            OldDal.Dao.Att.RoteDao oRoteDao = new OldDal.Dao.Att.RoteDao(dcHR.Connection);
            var rs = oRoteDao.GetRote();

            ddlRoteB.DataSource = rs;
            ddlRoteB.DataTextField = "RoteName";
            ddlRoteB.DataValueField = "RoteCode";
            ddlRoteB.DataBind();
        }

        #endregion
        protected void txtDateA_SelectedDateChanged(object sender, Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs e)
        {
            OldDal.Dao.Att.AttendDao oAttendDao = new OldDal.Dao.Att.AttendDao(dcHR.Connection);
            OldDal.Dao.Att.RoteDao oRoteDao = new OldDal.Dao.Att.RoteDao(dcHR.Connection);

            //取得班別資料
            var rAttend = oAttendDao.GetAttend(lblNobrAppS.Text, txtDateA.SelectedDate.GetValueOrDefault(DateTime.Now).Date).FirstOrDefault();
            if (rAttend != null)
            {
                var rRote = oRoteDao.GetRote().Where(p => p.RoteCode == rAttend.RoteCode).FirstOrDefault();
                if (rRote != null)
                {
                    lblRoteA.Text = rRote.RoteName;
                    lblRoteA.ToolTip = rRote.RoteCode;
                }
            }

            txtDateB.SelectedDate = txtDateA.SelectedDate.GetValueOrDefault(DateTime.Now).Date;

            txtDateB_SelectedDateChanged(null, null);
        }

        protected void txtDateB_SelectedDateChanged(object sender, Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs e)
        {
            OldDal.Dao.Att.AttendDao oAttendDao = new OldDal.Dao.Att.AttendDao(dcHR.Connection);
            OldDal.Dao.Att.RoteDao oRoteDao = new OldDal.Dao.Att.RoteDao(dcHR.Connection);

            //取得班別資料
            var rAttend = oAttendDao.GetAttend(lblNobrAppS.Text, txtDateB.SelectedDate.GetValueOrDefault(DateTime.Now).Date).FirstOrDefault();
            if (rAttend != null)
            {
                var rRote = oRoteDao.GetRote().Where(p => p.RoteCode == rAttend.RoteCode).FirstOrDefault();
                if (rRote != null)
                {
                    lblRoteBOld.Text = rRote.RoteCode;

                    if (ddlRoteB.Items.FindItemByValue(rRote.RoteCode) != null)
                        ddlRoteB.Items.FindItemByValue(rRote.RoteCode).Selected = true;
                }
            }
        }

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
                SetName(txtNameAppS.Text);
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

            txtDateA_SelectedDateChanged(null, null);
        }

        protected void gvAppS_NeedDataSource(object sender, Telerik.Web.UI.RadListViewNeedDataSourceEventArgs e)
        {
            var rs = (from c in dcFlow.FormsAppShiftShort
                      where c.ProcessId == lblProcessID.Text
                      select c).ToList();
            gvAppS.DataSource = rs;
        }

        protected void gvAppS_ItemCommand(object sender, Telerik.Web.UI.RadListViewCommandEventArgs e)
        {
            string cn = e.CommandName;
            string ca = e.CommandArgument.ToString();


            var r = (from c in dcFlow.FormsAppShiftShort
                     where c.AutoKey == Convert.ToInt32(ca)
                     select c).FirstOrDefault();


            if (cn == "Del")
            {
                if (r != null)
                {
                    dcFlow.FormsAppShiftShort.DeleteOnSubmit(r);

                    dcFlow.SubmitChanges();
                    lblNotifyMsg.Text = "刪除成功";
                }
            }
            gvAppS.Rebind();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtDateB.SelectedDate == null || txtDateB.SelectedDate == null)
                {
                    lblErrorMsg.Text = "您的開始或結束日期沒有輸入正確";
                    lblErrorMsg.CssClass = "shake";
                    return;
                }

                string Nobr = lblNobrAppS.Text;
                DateTime DateA = txtDateA.SelectedDate.Value.Date;
                DateTime DateB = txtDateB.SelectedDate.Value.Date;
                string RoteA = lblRoteA.ToolTip;//目前班別
                string RoteNameA = lblRoteA.Text;
                string RoteB = ddlRoteB.SelectedItem != null ? ddlRoteB.SelectedItem.Value : "";//要換的班別
                string RoteNameB = ddlRoteB.SelectedItem != null ? ddlRoteB.SelectedItem.Text : "";
                string RoteB_Old = lblRoteBOld.Text;   //原當天的班別
                string Note = txtNote.Text.Trim();

                if (ddlRoteB.Text == "")
                {
                    lblErrorMsg.Text = "請選擇調換班型";
                    lblErrorMsg.CssClass = "shake";
                    return;
                }

                if (lblRoteA.Text == "")
                {
                    lblErrorMsg.Text = "原上班日期無班別資料";
                    lblErrorMsg.CssClass = "shake";
                    return;
                }

                if (Note.Length == 0)
                {
                    lblErrorMsg.Text = "您的原因沒有輸入";
                    lblErrorMsg.CssClass = "shake";
                    return;
                }

                if (RoteA.Length == 0 || RoteB.Length == 0)
                {
                    lblErrorMsg.Text = "有一天沒有班別，請洽人事單位";
                    lblErrorMsg.CssClass = "shake";
                    return;
                }

                if (RoteA == "0Z" || RoteB == "0Z")
                {
                    lblErrorMsg.Text = "例假日不可調換，請洽人事單位";
                    lblErrorMsg.CssClass = "shake";
                    return;
                }

                //if (DateA < DateTime.Now.Date || DateB < DateTime.Now.Date)
                //{
                //    RadWindowManager1.RadAlert("調換日期不可以比今天小", 300, 100, "警告訊息", "", "");
                //    return;
                //}

                //日期不同時，班別不可以調換
                if (DateA != DateB)
                {
                    if (RoteB != RoteB_Old)
                    {
                        lblErrorMsg.Text = "調不同日期時，班別不可以調換";
                        lblErrorMsg.CssClass = "shake";
                        return;
                    }

                    if (RoteA == RoteB)
                    {
                        lblErrorMsg.Text = "調不同日期，但班別相同";
                        lblErrorMsg.CssClass = "shake";
                        return;
                    }
                }
                else
                {
                    if (RoteA == RoteB)
                    {
                        lblErrorMsg.Text = "您沒有做任何更動";
                        lblErrorMsg.CssClass = "shake";
                        return;
                    }
                }

                //檢查重複的資料
                var rsAppS = (from c in dcFlow.FormsAppShiftShort
                              where (c.ProcessId == lblProcessID.Text || (c.idProcess != 0 && c.Status == "1"))
                              && c.EmpId == Nobr
                              && c.DateB == DateA
                              && c.DateE == DateB
                              select c).ToList();

                if (rsAppS.Any())
                {
                    lblErrorMsg.Text = "資料重複或流程正在進行中";
                    lblErrorMsg.CssClass = "shake";
                    return;
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

                OldDal.Dao.Bas.BasDao oBasDao = new OldDal.Dao.Bas.BasDao(dcHR.Connection);
                var rBasS = oBasDao.GetBaseByNobr(Nobr, DateTime.Now.Date).FirstOrDefault();

                var Code = Guid.NewGuid().ToString();

                var rsFormsAppShiftShort = new FormsAppShiftShort()
                {
                    Code = Code,
                    ProcessId = lblProcessID.Text,
                    idProcess = 0,
                    EmpId = rEmpS.EmpNobr,
                    EmpName = rEmpS.EmpName,
                    DeptCode = rEmpS.DeptCode,
                    DeptName = rEmpS.DeptName,
                    JobCode = rEmpS.JobCode,
                    JobName = rEmpS.JobName,
                    RoleId = rEmpS.RoleId,
                    DateB = DateA,
                    RoteCodeB = RoteA,
                    RoteNameB = RoteNameA,
                    DateE = DateB,
                    RoteCodeE = RoteB,
                    RoteNameE = RoteNameB,
                    Sign = true,
                    SignState = "0",
                    Note = txtNote.Text,
                    Status = "1",
                    InsertMan = lblNobrAppM.Text,
                    InsertDate = DateTime.Now,
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
                    InfoSign = rsFormsAppShiftShort.EmpName + "," + rsFormsAppShiftShort.DateB.ToShortDateString() + "," + rsFormsAppShiftShort.RoteNameB + "," + rsFormsAppShiftShort.DateE.ToShortDateString() + "," + rsFormsAppShiftShort.RoteNameE + rsFormsAppShiftShort.Note,
                    InfoMail = MessageSendMail.ShiftShortBody(rsFormsAppShiftShort.EmpId, rsFormsAppShiftShort.EmpName, rsFormsAppShiftShort.DeptName, rsFormsAppShiftShort.RoteNameB, rsFormsAppShiftShort.DateB, rsFormsAppShiftShort.RoteNameE, rsFormsAppShiftShort.DateE, rsFormsAppShiftShort.Note),

                };
                dcFlow.FormsAppShiftShort.InsertOnSubmit(rsFormsAppShiftShort);
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
    }
}