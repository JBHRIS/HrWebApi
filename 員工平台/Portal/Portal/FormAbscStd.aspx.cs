using Bll.Flow.Vdb;
using Dal;
using Dal.Dao.Flow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace Portal
{
    public partial class FormAbscStd : WebPageBase
    {
        private dcHrDataContext dcHR = new dcHrDataContext();

        private dcFlowDataContext dcFlow = new dcFlowDataContext();
        private string _FormCode = "Absc";
        public static List<OldBll.Att.Vdb.AbsDataTable> result = null;
        //public static List<FormsAppAbscRow> result = null;

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
                //txtDateB.SelectedDate = DateTime.Now.Date;
                //txtDateE.SelectedDate = DateTime.Now.Date;
                lblNobrAppM.Text = _User.EmpId;
                SetInfoAppM();
                txtNameAppS_DataBind();
                SetDefault();
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
        public void txtNameAppS_DataBind()
        {
            var AbscOnlyShowSelf = (from c in dcFlow.FormsExtend
                                  where c.FormsCode == "Absc" && c.Code == "AbscOnlyShowSelf" && c.Active == true
                                  select c).FirstOrDefault();
            if (AbscOnlyShowSelf == null)
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

                if (result.Count == 0)
                {
                    var TextValueData = new Bll.TextValueRow();
                    TextValueData.Text = _User.EmpName + "," + _User.EmpId;
                    TextValueData.Value = _User.EmpId;
                    result.Add(TextValueData);
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
            if (txtNameAppS.FindItemByValue(_User.EmpId) != null)
                txtNameAppS.FindItemByValue(_User.EmpId).Selected = true;
        }

        protected void txtDateB_SelectedDateChanged(object sender, Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs e)
        {
            //txtDateE.SelectedDate = txtDateB.SelectedDate.GetValueOrDefault(DateTime.Now).Date;
        }

        protected void gvAppS_ItemCommand(object sender, RadListViewCommandEventArgs e)
        {
            var lvData = sender as RadListView;
            var Item = e.EventSource as RadCheckBox;
            var lvItem = Item.NamingContainer as RadListViewDataItem;
            var index = lvItem.DataItemIndex;
            var CheckBox = lvData.Items[index].FindControl("isSelected") as RadCheckBox;
            if (CheckBox.Checked == true)
            {
                var DataCheck = (from c in dcFlow.FormsAppAbsc
                                 where c.Code == CheckBox.CommandArgument
                                 select c).FirstOrDefault();
                if (DataCheck == null)
                {
                    var AbscData = result[index];
                    var rsAppS = (from c in dcFlow.FormsAppAbsc
                                  where  c.idProcess != 0 && c.SignState == "1"
                                  && c.EmpId == lblNobrAppS.Text
                                  && c.DateB == AbscData.DateB
                                  && c.TimeB == AbscData.TimeB
                                  select c).ToList();



                    if (rsAppS.Any())
                    {
                        lblNotifyMsg.Text = "單號" + AbscData.Serno + "流程進行中";
                        CheckBox.Checked = false;
                        return;
                    }
                    lblNotifyMsg.Text = "";
                    var oFormsAppAbsc = new FormsAppAbsc();
                    oFormsAppAbsc.Code = CheckBox.CommandArgument;
                    oFormsAppAbsc.ProcessId = lblProcessID.Text;
                    oFormsAppAbsc.idProcess = 0;
                    oFormsAppAbsc.EmpId = lblNobrAppS.Text;
                    oFormsAppAbsc.EmpName = txtNameAppS.Text;
                    oFormsAppAbsc.RoleId = lblRoleAppM.Text;
                    oFormsAppAbsc.DeptCode = lblDeptCodeAppM.Text;
                    oFormsAppAbsc.DeptName = lblDeptNameAppM.Text;
                    oFormsAppAbsc.JobCode = lblJobCodeAppM.Text;
                    oFormsAppAbsc.JobName = lblJobNameAppM.Text;
                    oFormsAppAbsc.DateTimeB = AbscData.DateTimeB;
                    //oFormsAppAbsc.DateTimeB = AbscData.AbscDateB;
                    oFormsAppAbsc.DateB = AbscData.DateB;
                    //oFormsAppAbsc.DateB = AbscData.AbscDateB;
                    oFormsAppAbsc.TimeB = (AbscData.TimeB == null) ? "0000" : AbscData.TimeB;
                    //oFormsAppAbsc.TimeB = (AbscData.AbscTimeB == null) ? "0000" : AbscData.AbscTimeB;
                    oFormsAppAbsc.DateTimeE = AbscData.DateTimeE;
                    //oFormsAppAbsc.DateTimeE = AbscData.AbscDateE;
                    oFormsAppAbsc.DateE = AbscData.DateE;
                    //oFormsAppAbsc.DateE = AbscData.AbscDateE;
                    oFormsAppAbsc.TimeE = (AbscData.TimeE == null) ? "0000" : AbscData.TimeE;
                    //oFormsAppAbsc.TimeE = (AbscData.AbscTimeE == null) ? "0000" : AbscData.AbscTimeE;
                    oFormsAppAbsc.HolidayCode = AbscData.Hcode;
                    //oFormsAppAbsc.HolidayCode = AbscData.HolidayCode;
                    oFormsAppAbsc.HolidayName = AbscData.HcodeName;
                    //oFormsAppAbsc.HolidayName = AbscData.HolidayName;
                    oFormsAppAbsc.AppAbsCode = "";
                    oFormsAppAbsc.Use = AbscData.Use;
                    oFormsAppAbsc.UnitCode = AbscData.HcodeUnit == OldBll.MT.mtEnum.HcodeUnit.Day ? "天" : "小時";
                    oFormsAppAbsc.Sign = true;
                    oFormsAppAbsc.SignState = "1";
                    oFormsAppAbsc.Status = "1";
                    oFormsAppAbsc.InsertMan = _User.EmpName;
                    oFormsAppAbsc.InsertDate = DateTime.Now;
                    oFormsAppAbsc.UpdateMan = _User.EmpName;
                    oFormsAppAbsc.UpdateDate = DateTime.Now;
                    dcFlow.FormsAppAbsc.InsertOnSubmit(oFormsAppAbsc);

                    var oFormsAppInfo = new FormsAppInfo();
                    oFormsAppInfo.Code = CheckBox.CommandArgument;
                    oFormsAppInfo.EmpId = lblNobrAppS.Text;
                    oFormsAppInfo.EmpName = lblNobrAppS.Text;
                    oFormsAppInfo.idProcess = 0;
                    oFormsAppInfo.ProcessId = lblProcessID.Text;
                    oFormsAppInfo.KeyDate = DateTime.Now;
                    oFormsAppInfo.SignState = "1";
                    oFormsAppInfo.InfoSign = oFormsAppAbsc.EmpName + "," + oFormsAppAbsc.HolidayName + "," + oFormsAppAbsc.DateB.ToShortDateString() + "," + oFormsAppAbsc.TimeB + "," + AbscData.Use + "小時";
                    oFormsAppInfo.InfoMail = MessageSendMail.AbscBody(oFormsAppAbsc.EmpId, oFormsAppAbsc.EmpName, oFormsAppAbsc.DeptName, oFormsAppAbsc.HolidayCode, oFormsAppAbsc.DateB, oFormsAppAbsc.TimeB, AbscData.Use, "小時", "");
                    dcFlow.FormsAppInfo.InsertOnSubmit(oFormsAppInfo);

                    dcFlow.SubmitChanges();
                }
            }
            else
            {
                var DataCheck = (from c in dcFlow.FormsAppAbsc
                                 where c.Code == CheckBox.CommandArgument
                                 select c).FirstOrDefault();
                if (DataCheck != null)
                {
                    dcFlow.FormsAppAbsc.DeleteOnSubmit(DataCheck);
                    dcFlow.SubmitChanges();
                }
                var FormsAppInfoCheck = (from c in dcFlow.FormsAppInfo
                                         where c.Code == CheckBox.CommandArgument
                                         select c).FirstOrDefault();
                if (FormsAppInfoCheck != null)
                {
                    dcFlow.FormsAppInfo.DeleteOnSubmit(FormsAppInfoCheck);
                    dcFlow.SubmitChanges();
                }
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            //var oFormsAppAbsc = new FormsAppAbscDao();
            //var FormsAppAbscCond = new FormsAppAbscConditions();
            //FormsAppAbscCond.AccessToken = _User.AccessToken;
            //FormsAppAbscCond.RefreshToken = _User.RefreshToken;
            //FormsAppAbscCond.CompanySetting = CompanySetting;
            //FormsAppAbscCond.Nobr = txtNameAppS.Text;
            //FormsAppAbscCond.BDate = txtDateB.SelectedDate.GetValueOrDefault();
            //FormsAppAbscCond.EDate = txtDateE.SelectedDate.GetValueOrDefault();
            //var Result = oFormsAppAbsc.GetData(FormsAppAbscCond);
            SetName(txtNameAppS.SelectedValue);

            //if (Result.Status)
            //{
            //    if (Result.Data != null)
            //    {
            //        result = Result.Data as List<FormsAppAbscRow>;
            //        gvAppS.DataSource = result;
            //    }
            //}
            if (txtNameAppS.Text == "")
            {
                lblErrorMsg.Text = "請選擇申請人";
                lblErrorMsg.CssClass = "badge badge-danger animated shake";
                return;
            }

            OldDal.Dao.Att.AbsDao oAbsDao = new OldDal.Dao.Att.AbsDao(dcHR.Connection);
            result = oAbsDao.GetAbsByDelete(txtNameAppS.SelectedValue);
            
            foreach (var r in result.ToArray())
            {
                var AbsData = (from c in dcFlow.FormsAppAbs
                               where c.ProcessID == r.Serno
                               select c).ToList();
                if (AbsData.Any())
                {
                    //r.DateB = r.DateTimeB.Date;
                    //r.DateE = r.DateTimeE.Date;
                    //r.TimeB = r.DateTimeB.ToString("HHmm");
                    //r.TimeE = r.DateTimeE.ToString("HHmm");
                    r.HcodeUnitName = r.HcodeUnit == OldBll.MT.mtEnum.HcodeUnit.Day ? "天" : "小時";
                    r.Guid = Guid.NewGuid().ToString();
                }
                else
                {
                    result.Remove(r);
                }
            }

            gvAppS.DataSource = result;

            Session["sProcessID"] = lblProcessID.Text;
            Session["FormCode"] = _FormCode;
            Session["FlowTreeID"] = lblFlowTreeID.Text;
        }

        protected void gvAppS_DataBound(object sender, EventArgs e)
        {

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

            var rEmpS = (from role in dcFlow.Role
                         join emp in dcFlow.Emp on role.Emp_id equals emp.id
                         join dept in dcFlow.Dept on role.Dept_id equals dept.id
                         join pos in dcFlow.Pos on role.Pos_id equals pos.id
                         where role.Emp_id == sNobr
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
            lblDeptNameAppM.Text = rEmpS.DeptName;
            lblDeptCodeAppM.Text = rEmpS.DeptCode;
            lblJobNameAppM.Text = rEmpS.JobName;
            lblJobCodeAppM.Text = rEmpS.JobCode;
            lblRoleAppM.Text = rEmpS.RoleId;
        }
    }
}