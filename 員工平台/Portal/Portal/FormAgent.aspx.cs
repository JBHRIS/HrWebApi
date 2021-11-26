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
    public partial class FormAgent : WebPageBase
    {

        private dcFlowDataContext dcFlow = new dcFlowDataContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (CompanySetting != null)
                {
                    dcFlow.Connection.ConnectionString = CompanySetting.ConnFlow;
                }
                _DataBind();
            }
        }
        public void _DataBind()
        {

            var lsPeople = AccessData.GetPeopleList(_User, CompanySetting);
            txtNameAppS.DataSource = lsPeople;
            txtNameAppS.DataTextField = "Text";
            txtNameAppS.DataValueField = "Value";
            txtNameAppS.DataBind();
            if (txtNameAppS.FindItemByValue(_User.EmpId) != null)
                txtNameAppS.FindItemByValue(_User.EmpId).Selected = true;
            if (_User.Role != null && !_User.Role.Contains("Hr"))
            {
                plAppS.Visible = false;
            }
            var rPeople = lsPeople.Where(p => p.Value == txtNameAppS.SelectedValue).FirstOrDefault();
            if (rPeople != null)
                lsPeople.Remove(rPeople);
            txtNameAgent.DataSource = lsPeople;
            txtNameAgent.DataTextField = "Text";
            txtNameAgent.DataValueField = "Value";
            txtNameAgent.DataBind();
            var oRoleData = new RoleDataDao();
            var RoleDataCond = new RoleDataConditions();
            RoleDataCond.AccessToken = _User.AccessToken;
            RoleDataCond.RefreshToken = _User.RefreshToken;
            RoleDataCond.CompanySetting = CompanySetting;
            RoleDataCond.idEmp = txtNameAppS.SelectedValue;
            var rsRoleData = oRoleData.GetData(RoleDataCond);
            if (rsRoleData.Status && rsRoleData.Data != null)
            {
                var rRoleData = rsRoleData.Data as List<RoleDataRow>;
                if (rRoleData != null)
                {
                    txtJobAppS.DataSource = rRoleData;
                    txtJobAppS.DataTextField = "RoleName";
                    txtJobAppS.DataValueField = "RoleId";
                    txtJobAppS.DataBind();
                }
            }
            var FormsItem = (from c in dcFlow.Forms
                             where c.Sort != 0
                             select c).ToList();
            foreach (var Form in FormsItem)
            {
                var Item = new ButtonListItem();
                Item.Text = Form.Name;
                Item.Value = Form.FlowTreeId;
                cblForm.Items.Add(Item);
            }
            cblForm.DataBind();
        }

        protected void txtNameAppS_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            var oRoleData = new RoleDataDao();
            var RoleDataCond = new RoleDataConditions();
            RoleDataCond.AccessToken = _User.AccessToken;
            RoleDataCond.RefreshToken = _User.RefreshToken;
            RoleDataCond.CompanySetting = CompanySetting;
            RoleDataCond.idEmp = txtNameAppS.SelectedValue;
            var rsRoleData = oRoleData.GetData(RoleDataCond);
            if (rsRoleData.Status && rsRoleData.Data != null)
            {
                var rRoleData = rsRoleData.Data as List<RoleDataRow>;
                if (rRoleData != null)
                {
                    txtJobAppS.DataSource = rRoleData;
                    txtJobAppS.DataTextField = "RoleName";
                    txtJobAppS.DataValueField = "RoleId";
                    txtJobAppS.DataBind();
                }
            }
            var lsPeople = AccessData.GetPeopleList(_User, CompanySetting);
            var rPeople = lsPeople.Where(p => p.Value == txtNameAppS.SelectedValue).FirstOrDefault();
            if (rPeople != null)
                lsPeople.Remove(rPeople);
            txtNameAgent.DataSource = lsPeople;
            txtNameAgent.DataTextField = "Text";
            txtNameAgent.DataValueField = "Value";
            txtNameAgent.DataBind();
            lvAgent.Rebind();
            lvAgentDate.Rebind();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtJobAppS.Text == "" || (txtNameAppS.Visible && txtNameAppS.Text == "") || txtNameAgent.Text == "" || txtNumberOrder.Text == "")
            {
                lblMsg.Text = "請確認資料是否輸入正確";
                lblMsg.CssClass = "badge badge-danger animated shake";
                return;
            }

            var rCheckAgent = (from c in dcFlow.CheckAgent
                               where c.Role_idSource == txtJobAppS.SelectedValue
                               && c.Emp_idSource == txtNameAppS.SelectedValue
                               && c.Emp_idTarget == txtNameAgent.SelectedValue
                               select c).FirstOrDefault();
            if (rCheckAgent == null)
            {
                rCheckAgent = new CheckAgent();
                dcFlow.CheckAgent.InsertOnSubmit(rCheckAgent);
            }
            string Role_idTarget = "";
            var oRoleData = new RoleDataDao();
            var RoleDataCond = new RoleDataConditions();
            RoleDataCond.AccessToken = _User.AccessToken;
            RoleDataCond.RefreshToken = _User.RefreshToken;
            RoleDataCond.CompanySetting = CompanySetting;
            RoleDataCond.idEmp = txtNameAgent.SelectedValue;
            var rsRoleData = oRoleData.GetData(RoleDataCond);
            if (rsRoleData.Status && rsRoleData.Data != null)
            {
                var rRoleData = rsRoleData.Data as List<RoleDataRow>;
                if (rRoleData != null && rRoleData.Count > 0)
                    Role_idTarget = rRoleData.First().RoleId;
                else
                {
                    lblMsg.Text = "代理人資料有誤";
                    lblMsg.CssClass = "badge badge-danger animated shake";
                    return;
                }
            }
            else
            {
                lblMsg.Text = "代理人資料有誤";
                lblMsg.CssClass = "badge badge-danger animated shake";
                return;
            }

            rCheckAgent.Role_idSource = txtJobAppS.SelectedValue;
            rCheckAgent.Emp_idSource = txtNameAppS.Visible ? txtNameAppS.SelectedValue : _User.EmpId;
            rCheckAgent.Role_idTarget = Role_idTarget;
            rCheckAgent.Emp_idTarget = txtNameAgent.SelectedValue;
            rCheckAgent.Sort = Convert.ToInt32(txtNumberOrder.Text);
            rCheckAgent.Guid = Guid.NewGuid().ToString();
            rCheckAgent.KeyMan = _User.EmpId;
            rCheckAgent.KeyDate = DateTime.Now;

            dcFlow.SubmitChanges();
            lblMsg.Text = "代理人新增成功";
            lblMsg.CssClass = "badge badge-primary animated shake";
            lvAgent.Rebind();
        }

        protected void lvAgent_NeedDataSource(object sender, Telerik.Web.UI.RadListViewNeedDataSourceEventArgs e)
        {
            var result = (from c in dcFlow.CheckAgent
                          join emp in dcFlow.Emp on c.Emp_idSource equals emp.id
                          join empTarget in dcFlow.Emp on c.Emp_idTarget equals empTarget.id
                          join role in dcFlow.Role on c.Emp_idSource equals role.Emp_id
                          join roleTarget in dcFlow.Role on c.Emp_idTarget equals roleTarget.Emp_id
                          join dept in dcFlow.Dept on role.Dept_id equals dept.id
                          join deptTarget in dcFlow.Dept on roleTarget.Dept_id equals deptTarget.id
                          join Pos in dcFlow.Pos on role.Pos_id equals Pos.id
                          join PosTarget in dcFlow.Pos on roleTarget.Pos_id equals PosTarget.id
                          //join formAgent in dcFlow.CheckAgentFlowTree on c.Guid equals formAgent.CheckAgent_Guid into FormA
                          //join Form in dcFlow.Forms on formAgent.FlowTree_id equals Form.FlowTreeId into FormTree
                          where c.Emp_idSource == txtNameAppS.SelectedValue && c.Role_idSource == role.id
                          select new
                          {
                              Auto = c.auto,
                              Emp_idSource = c.Emp_idSource,
                              Role_idSource = c.Role_idSource,
                              Sort = c.Sort,
                              KeyDate = c.KeyDate,
                              Guid = c.Guid,
                              EmpNameSource = emp.name,
                              EmpNameTarget = empTarget.name,
                              DeptNameSource = dept.name,
                              DeptNameTarget = deptTarget.name,
                              PosNameSource = Pos.name,
                              PosNameTarget = PosTarget.name,
                              //Form = String.Join(",",FormTree.Select(p=>p.Name))
                          }).ToList();
            lvAgent.DataSource = result;
        }

        protected void lvAgent_ItemCommand(object sender, Telerik.Web.UI.RadListViewCommandEventArgs e)
        {
            if (e.CommandName == "Delete")
            {
                var rDeleteData = (from c in dcFlow.CheckAgent
                                   where c.auto == Convert.ToInt32(e.CommandArgument)
                                   select c).FirstOrDefault();
                if (rDeleteData != null)
                    dcFlow.CheckAgent.DeleteOnSubmit(rDeleteData);
                dcFlow.SubmitChanges();
            }
            if (e.CommandName == "Auth")
            {
                lblGuid.Text = e.CommandArgument.ToString();
                var lsTreeId = (from c in dcFlow.CheckAgentFlowTree
                                where c.CheckAgent_Guid == lblGuid.Text
                                select c.FlowTree_id).ToList();
                foreach (ButtonListItem r in cblForm.Items)
                {
                    r.Selected = false;
                    if (lsTreeId.Contains(r.Value))
                    {
                        r.Selected = true;
                    }
                }
            }
        }

        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            foreach (ButtonListItem r in cblForm.Items)
            {

                var Tree = (from c in dcFlow.CheckAgentFlowTree
                            where c.CheckAgent_Guid == lblGuid.Text && c.FlowTree_id == r.Value
                            select c).FirstOrDefault();
                if (r.Selected)
                {
                    if (Tree == null)
                    {
                        var CheckAgentFlow = new CheckAgentFlowTree();
                        CheckAgentFlow.CheckAgent_Guid = lblGuid.Text;
                        CheckAgentFlow.FlowTree_id = r.Value;
                        CheckAgentFlow.KeyMan = _User.EmpName;
                        CheckAgentFlow.KeyDate = DateTime.Now;
                        dcFlow.CheckAgentFlowTree.InsertOnSubmit(CheckAgentFlow);
                    }
                }
                else
                {
                    if (Tree != null)
                    {
                        dcFlow.CheckAgentFlowTree.DeleteOnSubmit(Tree);
                    }
                }
            }
            dcFlow.SubmitChanges();

        }

        protected void btnAgentAdd_Click(object sender, EventArgs e)
        {
            DateTime dDateTimeB = DateTime.Now.Date;
            DateTime dDateTimeE = DateTime.Now.Date;

            string EmpId = txtNameAppS.Visible ? txtNameAppS.SelectedValue : _User.EmpId;
            if (txtDateB.SelectedDate == null || txtDateE.SelectedDate == null)
            {
                lblDateMsg.Text = "請確認時間是否輸入正確";
                lblDateMsg.CssClass = "badge badge-danger animated shake";
                return;
            }

            DateTime DateB = txtDateB.SelectedDate.Value;
            DateTime DateE = txtDateE.SelectedDate.Value;
            string TimeB = txtTimeB.Text;
            string TimeE = txtTimeE.Text;

            if (TimeB.Length != 4 || TimeE.Length != 4)
            {
                lblDateMsg.Text = "請確認時間是否輸入正確";
                lblDateMsg.CssClass = "badge badge-danger animated shake";
                return;
            }

            dDateTimeB = DateB.Date.AddMinutes(Bll.Tools.TimeTrans.ConvertHhMmToMinutes(TimeB));
            dDateTimeE = DateE.Date.AddMinutes(Bll.Tools.TimeTrans.ConvertHhMmToMinutes(TimeE));

            var rEmpAgentDate = (from c in dcFlow.EmpAgentDate
                                 where c.Emp_id == EmpId
                                 && c.dateB == dDateTimeB
                                 && c.dateE == dDateTimeE
                                 && c.IsValid
                                 select c).FirstOrDefault();

            if (rEmpAgentDate == null)
            {
                rEmpAgentDate = new EmpAgentDate();
                dcFlow.EmpAgentDate.InsertOnSubmit(rEmpAgentDate);
            }

            rEmpAgentDate.Emp_id = EmpId;
            rEmpAgentDate.dateB = dDateTimeB;
            rEmpAgentDate.dateE = dDateTimeE;
            rEmpAgentDate.KeyMan = _User.EmpName;
            rEmpAgentDate.KeyDate = DateTime.Now;
            rEmpAgentDate.IsValid = true;

            dcFlow.SubmitChanges();
            lvAgentDate.Rebind();
        }

        protected void lvAgentDate_NeedDataSource(object sender, RadListViewNeedDataSourceEventArgs e)
        {
            string EmpId = txtNameAppS.Visible ? txtNameAppS.SelectedValue : _User.EmpId;
            var result = (from c in dcFlow.EmpAgentDate
                          where c.Emp_id == EmpId
                          select c).ToList();
            lvAgentDate.DataSource = result;
        }

        protected void lvAgentDate_ItemCommand(object sender, RadListViewCommandEventArgs e)
        {
            if (e.CommandName == "Delete")
            {
                string EmpId = txtNameAppS.Visible ? txtNameAppS.SelectedValue : _User.EmpId;
                var Data = (from c in dcFlow.EmpAgentDate
                            where c.Emp_id == EmpId
                            select c).FirstOrDefault();
                if (Data != null)
                {
                    dcFlow.EmpAgentDate.DeleteOnSubmit(Data);
                    dcFlow.SubmitChanges();
                    lvAgentDate.Rebind();
                    lblDateMsg.Text = "刪除成功";
                    lblDateMsg.CssClass = "badge badge-primary animated shake";
                }
            }
        }
    }
}