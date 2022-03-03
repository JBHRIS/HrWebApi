using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using Bll;
using Dal.Dao.Employee;
using Bll.Employee.Vdb;
using Dal;

namespace Portal
{
    public partial class EmployeeBaseDataEdit : WebPageBase
    {
        private dcFlowDataContext dcFlow = new dcFlowDataContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (CompanySetting != null)
            {
                dcFlow.Connection.ConnectionString = CompanySetting.ConnFlow;
            }
            if (!this.IsPostBack)
            {
                LoadData(_User.UserCode);
                ContactRelation_DataBind();
                Base_DataBind();
                var IsModifyResidenceAddress = (from c in dcFlow.FormsExtend
                                                where c.Active && c.FormsCode == "EmployeeBaseDataEdit" && c.Code == "IsModifyResidenceAddress"
                                                select c).FirstOrDefault();
                if (IsModifyResidenceAddress != null)
                {
                    txtResidenceAddress.Enabled = false;
                }
            }
        }
        public void LoadData(string Key = "")
        {

        }
        protected void ContactRelation_DataBind()
        {
            var rs = new List<RelcodeViewRow>();
            var oRelcodeView = new RelcodeViewDao();
            var RelcodeViewCond = new RelcodeViewConditions();
            RelcodeViewCond.AccessToken = _User.AccessToken;
            RelcodeViewCond.RefreshToken = _User.RefreshToken;
            RelcodeViewCond.CompanySetting = CompanySetting;
            var Result = oRelcodeView.GetData(RelcodeViewCond);
            if (Result.Status)
            {
                if (Result.Data != null)
                {
                    rs = Result.Data as List<RelcodeViewRow>;
                }
            }

            var rsText = new List<TextValueRow>();
            foreach (var RelationData in rs)
            {
                var r = new TextValueRow();
                r.Text = RelationData.RelName;
                r.Value = RelationData.Relcode;
                rsText.Add(r);
            }
            ddlContactRelation.DataSource = rsText;
            ddlContactRelation1.DataSource = rsText;
            ddlContactRelation.DataTextField = "Text";
            ddlContactRelation.DataValueField = "Value";
            ddlContactRelation1.DataTextField = "Text";
            ddlContactRelation1.DataValueField = "Value";
            ddlContactRelation.DataBind();
            ddlContactRelation1.DataBind();
        }

        protected void Base_DataBind()
        {
            var rs = new List<EmployeeInfoViewRow>();

            var ListEmpid = new List<string>();
            ListEmpid.Add(_User.EmpId);
            var oEmployeeInfoView = new EmployeeInfoViewDao();
            var EmployeeInfoViewCond = new EmployeeInfoViewConditions();
            EmployeeInfoViewCond.AccessToken = _User.AccessToken;
            EmployeeInfoViewCond.RefreshToken = _User.RefreshToken;
            EmployeeInfoViewCond.CompanySetting = CompanySetting;
            EmployeeInfoViewCond.ListEmpId = ListEmpid;
            var Result = oEmployeeInfoView.GetData(EmployeeInfoViewCond);

            if (Result.Status)
            {
                if (Result.Data != null)
                {
                    rs = Result.Data as List<EmployeeInfoViewRow>;
                }
            }

            if (rs.Count != 0)
            {
                var Res = rs[0];
                txtCellphone.Text = Res.Cellphone;
                txtResidencePhone.Text = Res.ResidencePhone;
                txtCommunicationPhone.Text = Res.CommunicationPhone;
                txtEMail.Text = Res.EMail;
                txtResidenceAddress.Text = Res.ResidenceAddress;
                txtCommunicationPhone.Text = Res.CommunicationPhone;
                txtCommunicationAddress.Text = Res.CommunicationAddress;
                if (Res.ContactInfoList != null)
                {
                    if (Res.ContactInfoList.Count >= 1)
                    {
                        txtContact.Text = Res.ContactInfoList[0].ContactName;
                        txtContactPhone.Text = Res.ContactInfoList[0].ContactPhone;
                        txtContactTel.Text = Res.ContactInfoList[0].ContactTel;
                        ddlContactRelation.SelectedIndex = ddlContactRelation.FindItemIndexByText(Res.ContactInfoList[0].ContactRelationship);
                    }
                    if (Res.ContactInfoList.Count >= 2)
                    {
                        txtContact1.Text = Res.ContactInfoList[1].ContactName;
                        txtContactPhone1.Text = Res.ContactInfoList[1].ContactPhone;
                        txtContactTel1.Text = Res.ContactInfoList[1].ContactTel;
                        ddlContactRelation1.SelectedIndex = ddlContactRelation.FindItemIndexByText(Res.ContactInfoList[1].ContactRelationship);
                    }
                }
            }
        }
        protected void Update_Click(object sender, EventArgs e)
        {
            //實作資料確認



            var rs = new UpdateEmployeeInfoRow();
            var oUpdateEmployeeInfo = new UpdateEmployeeInfoDao();
            var UpdateEmployeeCond = new UpdateEmployeeInfoConditions();
            UpdateEmployeeCond.AccessToken = _User.AccessToken;
            UpdateEmployeeCond.RefreshToken = _User.RefreshToken;
            UpdateEmployeeCond.CompanySetting = CompanySetting;
            UpdateEmployeeCond.employeeId = _User.EmpId;
            UpdateEmployeeCond.gsm = txtCellphone.Text;
            UpdateEmployeeCond.residencePhone = txtResidencePhone.Text;
            UpdateEmployeeCond.residenceAddress = txtResidenceAddress.Text;
            UpdateEmployeeCond.communicationAddress = txtCommunicationAddress.Text;
            UpdateEmployeeCond.communicationPhone = txtCommunicationPhone.Text;
            UpdateEmployeeCond.email = txtEMail.Text;

            if (txtContact.Text != "")
            {
                UpdateEmployeeCond.contMan = txtContact.Text;
                UpdateEmployeeCond.contTel = txtContactTel.Text;
                UpdateEmployeeCond.contGsm = txtContactPhone.Text;
                UpdateEmployeeCond.contRel = ddlContactRelation.SelectedValue;
            }
            if (txtContact1.Text != "")
            {
                UpdateEmployeeCond.contMan2 = txtContact1.Text;
                UpdateEmployeeCond.contTel2 = txtContactTel1.Text;
                UpdateEmployeeCond.contGsm2 = txtContactPhone1.Text;
                UpdateEmployeeCond.contRel2 = ddlContactRelation1.SelectedValue;
            }
            var Result = oUpdateEmployeeInfo.GetData(UpdateEmployeeCond);
            if (Result.Status)
            {
                if (Result.Data != null)
                {
                    rs = Result.Data as UpdateEmployeeInfoRow;
                }
            }
            if (rs.result)
            {
                ResultText.Text = "資料修改成功";
                ResultText.CssClass = "label-primary";
                Response.Redirect("EmployeeBaseData.aspx");
            }
            else
            {
                ResultText.Text = "資料修改失敗";
            }
        }
    }
}