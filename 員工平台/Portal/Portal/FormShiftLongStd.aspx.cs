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
    public partial class FormShiftLongStd : WebPageBase
    {
        private dcHrDataContext dcHR = new dcHrDataContext();
        private dcFlowDataContext dcFlow = new dcFlowDataContext();
        private string _FormCode = "ShiftLong";
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
                lblNobrAppM.Text = _User.EmpId;

                SetDefault();
                SetInfoAppM();

                txtNameAppS_DataBind();
                ddlRotet_DataBind();
                txtDateA_SelectedDateChanged(null, null);
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
        private void ddlRotet_DataBind()
        {
            OldDal.Dao.Att.RotetDao oRotetDao = new OldDal.Dao.Att.RotetDao(dcHR.Connection);

            var rs = oRotetDao.GetRotet();

            ddlRotet.DataSource = rs;
            ddlRotet.DataTextField = "RotetName";
            ddlRotet.DataValueField = "RotetCode";
            ddlRotet.DataBind();

            ddlRotetOrigin.DataSource = rs;
            ddlRotetOrigin.DataTextField = "RotetName";
            ddlRotetOrigin.DataValueField = "RotetCode";
            ddlRotetOrigin.DataBind();
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
        protected void txtDateA_SelectedDateChanged(object sender, Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs e)
        {
            string Nobr = lblNobrAppS.Text;
            DateTime Date = txtDateA.SelectedDate.GetValueOrDefault(DateTime.Now).Date;

            OldDal.Dao.Bas.BasDao oBasDao = new OldDal.Dao.Bas.BasDao(dcHR.Connection);
            var rBase = oBasDao.GetBaseByNobr(Nobr, Date).FirstOrDefault();

            if (rBase != null)
            {
                lblRotetOrigin.ToolTip = rBase.Rotet;

                if (ddlRotet.Items.FindItemByValue(rBase.Rotet) != null)
                {
                    ddlRotet.Items.FindItemByValue(rBase.Rotet).Selected = true;
                    ddlRotetOrigin.Items.FindItemByValue(rBase.Rotet).Selected = true;
                    lblRotetOrigin.Text = ddlRotetOrigin.SelectedItem.Text;
                }
            }
        }

        protected void gvAppS_NeedDataSource(object sender, Telerik.Web.UI.RadListViewNeedDataSourceEventArgs e)
        {
            var rs = (from c in dcFlow.FormsAppShiftLong
                      where c.ProcessID == lblProcessID.Text
                      select c).ToList();
            gvAppS.DataSource = rs;
        }

        protected void gvAppS_ItemCommand(object sender, Telerik.Web.UI.RadListViewCommandEventArgs e)
        {
            string cn = e.CommandName;
            string ca = e.CommandArgument.ToString();


            var r = (from c in dcFlow.FormsAppShiftLong
                     where c.AutoKey == Convert.ToInt32(ca)
                     select c).FirstOrDefault();


            if (cn == "Del")
            {
                if (r != null)
                {
                    dcFlow.FormsAppShiftLong.DeleteOnSubmit(r);

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
                if (txtDateA.SelectedDate == null)
                {
                    lblErrorMsg.Text = "您的開始或結束日期沒有輸入正確";
                    lblErrorMsg.CssClass = "shake";
                    return;
                }

                string Nobr = lblNobrAppS.Text;
                DateTime DateA = txtDateA.SelectedDate.Value.Date;
                string Rotet = ddlRotet.SelectedItem.Value;
                string RotetName = ddlRotet.SelectedItem.Text;
                string RotetOrigin = ddlRotetOrigin.SelectedItem.Value;
                string RotetNameOrigin = ddlRotetOrigin.SelectedItem.Text;
                string Note = txtNote.Text.Trim();

                if (Note.Length == 0)
                {
                    lblErrorMsg.Text = "您的原因沒有輸入";
                    lblErrorMsg.CssClass = "shake";
                    return;
                }

                if (Rotet == lblRotetOrigin.ToolTip)
                {
                    lblErrorMsg.Text = "資料相同，請選擇要換的班別";
                    lblErrorMsg.CssClass = "shake";
                    return;
                }

                OldDal.Dao.Bas.BasDao oBasDao = new OldDal.Dao.Bas.BasDao(dcHR.Connection);

                var rBase = oBasDao.GetBaseByNobr(Nobr, DateA).FirstOrDefault();
                if (rBase == null || !(rBase.DateA <= Convert.ToDateTime("3000/1/1") && rBase.DateD >= Convert.ToDateTime("3000/1/1")))
                {
                    if (rBase != null)
                    {
                        lblErrorMsg.Text = "調班的日期不是正確的，您的調班日期必須大於" + rBase.DateD.AddDays(1).ToShortDateString() + "之後";
                        lblErrorMsg.CssClass = "shake";
                        return;
                    }

                    lblErrorMsg.Text = "調班的日期不是正確的";
                    lblErrorMsg.CssClass = "shake";
                    return;
                }

                //檢查重複的資料
                var rsAppS = (from c in dcFlow.FormsAppShiftLong
                              where (c.ProcessID == lblProcessID.Text || (c.idProcess != 0 && c.SignState == "1"))
                              && c.EmpId == Nobr
                              && c.Date == DateA
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

                var rBasS = oBasDao.GetBaseByNobr(Nobr, DateTime.Now.Date).FirstOrDefault();

                var Code = Guid.NewGuid().ToString();

                var rsFormsAppShifttLong = new FormsAppShiftLong()
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
                    Date = DateA,
                    RotetCode = Rotet,
                    RotetName = RotetName,
                    RotetCodeOrigin = RotetOrigin,
                    RotetNameOrigin = RotetNameOrigin,
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
                    InfoSign = rsFormsAppShifttLong.EmpName + "," + rsFormsAppShifttLong.Date.ToShortDateString() + "," + rsFormsAppShifttLong.RotetNameOrigin + "," + rsFormsAppShifttLong.RotetName + rsFormsAppShifttLong.Note,
                    InfoMail = MessageSendMail.ShiftLongBody(rsFormsAppShifttLong.EmpId, rsFormsAppShifttLong.EmpName, rsFormsAppShifttLong.DeptName, rsFormsAppShifttLong.RotetNameOrigin, rsFormsAppShifttLong.Date, rsFormsAppShifttLong.RotetName, rsFormsAppShifttLong.Note),

                };

                dcFlow.FormsAppShiftLong.InsertOnSubmit(rsFormsAppShifttLong);
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