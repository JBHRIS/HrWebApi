using Bll.Flow.Vdb;
using Bll.WorkFromHome.Vdb;
using Dal;
using Dal.Dao.Flow;
using Dal.Dao.WorkFromHome;
using OldBll.MT.Vdb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace Portal
{
    public partial class FormWorkLog : WebPageBase
    {
        private dcHrDataContext dcHR = new dcHrDataContext();
        private dcFlowDataContext dcFlow = new dcFlowDataContext();
        private string _FormCode = "WorkLog";
        private List<WorkLogVdb> workLogs = new List<WorkLogVdb>();
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
                lblNobrAppM.Text = _User.EmpId;
                SetInfoAppM();
                ddlReason_DataBind();
                UnobtrusiveSession.Session["WorkLog"] = null;
            }
            if (UnobtrusiveSession.Session["WorkLog"] != null)
            { 
                workLogs = UnobtrusiveSession.Session["WorkLog"] as List<WorkLogVdb>;
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

        #region 載入預設資料
        private void ddlReason_DataBind()
        {
            //OldDal.Dao.Att.CardLosdDao oCardLosdDao = new OldDal.Dao.Att.CardLosdDao(dcHR.Connection);
            //var rs = oCardLosdDao.GetData();
            //ddlReason.DataSource = rs;
            //ddlReason.DataTextField = "Name";
            //ddlReason.DataValueField = "Code";
            //ddlReason.DataBind();
        }
        
        #endregion

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            lblErrorMsg.Text = "";
            try
            {
                if (txtDateB.SelectedDate == null)
                {
                    lblErrorMsg.Text = "您的開始或結束日期沒有輸入正確";
                    return;
                }

                string TimeB = txtTimeB.Text;
                string TimeE = txtTimeE.Text;
                DateTime DateB = txtDateB.SelectedDate.Value;

                if (TimeB.Length != 4 || TimeE.Length != 4)
                {
                    lblErrorMsg.Text = "您所輸入的時間不正確";
                    return;
                }

                DateTime DateTimeB = DateB.Date.AddMinutes(Bll.Tools.TimeTrans.ConvertHhMmToMinutes(TimeB));
                DateTime DateTimeE = DateB.Date.AddMinutes(Bll.Tools.TimeTrans.ConvertHhMmToMinutes(TimeE));

                if (DateTimeB >= DateTimeE)
                {
                    lblErrorMsg.Text = "您的開始日期時間不能大於或等於結束日期時間";
                    return;
                }

                var ListEmpId = new List<string>();
                ListEmpId.Add(_User.EmpId);

                var workLogData = (from c in workLogs
                                   where c.DateB == DateB
                                   select c).ToList();
                var oWorkLog = new WorkLogDao();
                var WorkLogCond = new WorkLogConditions();
                WorkLogCond.AccessToken = _User.AccessToken;
                WorkLogCond.RefreshToken = _User.RefreshToken;
                WorkLogCond.CompanySetting = CompanySetting;
                WorkLogCond.employeeList = ListEmpId;
                WorkLogCond.dateBegin = DateB;
                WorkLogCond.dateEnd = DateB;

                var Result = oWorkLog.GetData(WorkLogCond);
                var rs = new List<WorkLogRow>();
                if (Result.Status)
                {
                    if (Result.Data != null)
                    {
                        rs = Result.Data as List<WorkLogRow>;
                    }
                }
                //if (workLogData.Any() || rs.Count > 0)
                //{
                //    lblErrorMsg.Text = "該日期已有資料";
                //    return;
                //}

                var WorkLogData = new WorkLogVdb();
                WorkLogData.EmpId = _User.EmpId;
                WorkLogData.EmpName = _User.EmpName;
                WorkLogData.Note = txtNote.Text;
                WorkLogData.TimeB = TimeB;
                WorkLogData.TimeE = TimeE;
                WorkLogData.DateB = DateB;
                WorkLogData.GUID = Guid.NewGuid().ToString();
                workLogs.Add(WorkLogData);
                UnobtrusiveSession.Session["WorkLog"] = workLogs;
                Session["FormCode"] = _FormCode;
                gvAppS.Rebind();
            }
            catch (Exception)
            {
                lblErrorMsg.Text = "新增失敗";
            }
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            var cn = ((RadButton)sender).CommandName;
            var ca = ((RadButton)sender).CommandArgument;

            UnobtrusiveSession.Session["FormGuidCode"] = ca;

            ucFileManage._lblKey.Text = ca;
            ucFileManage._lvMain.Rebind();
        }

        protected void gvAppS_NeedDataSource(object sender, RadListViewNeedDataSourceEventArgs e)
        {
            
            gvAppS.DataSource = workLogs;

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


            var r = (from c in workLogs
                     where c.GUID == ca
                     select c).FirstOrDefault();

            if (cn == "Del")
            {
                if (r != null)
                {
                    workLogs.Remove(r);
                    UnobtrusiveSession.Session["WorkLog"] = workLogs;
                    lblNotifyMsg.Text = "刪除成功";
                }
            }
            gvAppS.Rebind();
        }
    }
}