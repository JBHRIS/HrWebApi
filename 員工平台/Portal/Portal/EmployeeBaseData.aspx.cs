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
using Bll.System.Vdb;

namespace Portal
{
    public partial class EmployeeBaseData : WebPageBase
    { 
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                LoadData(_User.UserCode);
                ddlEmp_DataBind();
                Employee_DataBind();
                if (UnobtrusiveSession.Session["SystemPage"] != null)
                {
                    var MenuData = UnobtrusiveSession.Session["SystemPage"] as List<SystemPageRow>;
                    var MenuCode = MenuData.Select(p => p.Code).ToList();
                    if (!MenuCode.Contains("EmployeeBaseDataEdit"))
                    {
                        btnEdit.Visible = false;
                    }
                }
            }
        }
        public void LoadData(string Key = "")
        {
            
        }
        public void ddlEmp_DataBind()
        {
            var rs = AccessData.GetSearchListEmp(_User,CompanySetting);

            if (rs.Count == 0)
            {
                var r = new TextValueRow();
                r.Text = _User.EmpName + "," + _User.EmpId;
                r.Value = _User.EmpId;
                rs.Add(r);
            }
            //按排序 再按照工號
            rs = rs.OrderBy(p => p.Sort).ThenBy(p => p.Value).ToList();

            ddlEmp.DataSource = rs;
            ddlEmp.DataTextField = "Text";
            ddlEmp.DataValueField = "Value";
            ddlEmp.DataBind();

            if (ddlEmp.FindItemByValue(_User.EmpId) != null)
                ddlEmp.FindItemByValue(_User.EmpId).Selected = true;
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Employee_DataBind();
        }
        protected void Employee_DataBind()
        {
            var rs = new List<EmployeeInfoViewRow>();

            var ListEmpid = new List<string>();
            ListEmpid.Add(ddlEmp.SelectedValue);
            var oEmployeeInfoView = new EmployeeInfoViewDao();
            var EmployeeInfoViewCond = new EmployeeInfoViewConditions();
            EmployeeInfoViewCond.AccessToken = _User.AccessToken;
            EmployeeInfoViewCond.RefreshToken = _User.RefreshToken;
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
                if (ddlEmp.SelectedValue == _User.EmpId)
                {
                    btnEdit.Visible = false;
                    var Res = rs[0];
                    if (Res.Image != null && Res.Image != "")
                        ImgPhoto.ImageUrl = "data:image/jpg;base64," + Res.Image;
                    lblEmpName.Text = Res.EmpName;
                    lblEmpId.Text = Res.EmpId;
                    lblEmpEnglishName.Text = Res.EmpEnglishName;
                    lblEmpSex.Text = Res.EmpSex;
                    lblEmpBirthday.Text = Res.EmpBirthday.ToString("yyyy/MM/dd");
                    lblAge.Text = (DateTime.Now.Year - Res.EmpBirthday.Year).ToString();
                    lblConstellation.Text = GetAtomFromBirthday(Res.EmpBirthday);
                    //lblEmpMasked.Text = Res.EmpIdNumber;
                    lblEmpBlood.Text = Res.EmpBlood;
                    lblEmpMarried.Text = Res.EmpMarried;

                    lblDeptName.Text = Res.DeptName;
                    lblDeptS.Text = Res.CostDept;
                    lblJobName.Text = Res.JobName;
                    lblSalary.Text = Res.Salary;
                    lblCellphone.Text = Res.Cellphone;
                    lblResidencePhone.Text = Res.ResidencePhone;
                    lblCommunicationPhone.Text = Res.CommunicationPhone;
                    lblEMail.Text = Res.EMail;
                    lblResidenceAddress.Text = Res.ResidenceAddress;
                    lblCommunicationAddress.Text = Res.CommunicationAddress;


                    if (Res.ContactInfoList.Count > 0)
                    {
                        lblContactName.Text = Res.ContactInfoList[0].ContactName;
                        lblContactPhone.Text = Res.ContactInfoList[0].ContactTel;
                        lblContactRelationship.Text = Res.ContactInfoList[0].ContactRelationship;
                        lblContactCellphone.Text = Res.ContactInfoList[0].ContactPhone;
                    }
                    else
                    {
                        lblContactName.Text = "";
                        lblContactPhone.Text = "";
                        lblContactRelationship.Text = "";
                        lblContactCellphone.Text = "";
                    }
                    if (Res.ContactInfoList.Count > 1)
                    {
                        lblContactName1.Text = Res.ContactInfoList[1].ContactName;
                        lblContactPhone1.Text = Res.ContactInfoList[1].ContactTel;
                        lblContactRelationship1.Text = Res.ContactInfoList[1].ContactRelationship;
                        lblContactCellphone1.Text = Res.ContactInfoList[1].ContactPhone;
                    }
                    else
                    {
                        lblContactName1.Text = "";
                        lblContactPhone1.Text = "";
                        lblContactRelationship1.Text = "";
                        lblContactCellphone1.Text = "";
                    }
                    if (Res.WorkStateList.Count > 0)
                    {
                        Res.WorkStateList = Res.WorkStateList.OrderBy(p => p.ADate).ToList();
                        var JobData = Res.WorkStateList[Res.WorkStateList.Count - 1];
                        lblState.Text = JobData.JobState;
                        lblWorkDate.Text = Convert.ToDateTime(JobData.ADate).ToString("yyyy/MM/dd");
                    }
                    else
                    {
                        lblState.Text = "";
                        lblWorkDate.Text = "";
                    }
                    if (Res.EducationList.Count > 0)
                    {
                        lblEducationLevel.Text = Res.EducationList[0].Education;
                        lblSchoolName.Text = Res.EducationList[0].SchoolName;
                        lblSubject.Text = Res.EducationList[0].ObjectName;
                        lblEntryDate.Text = Res.EducationList[0].EnterDate;
                        lblGraduatedDate.Text = Res.EducationList[0].GraduateDate;
                        lblIsGraduated.Text = Res.EducationList[0].IsGraduated;
                    }
                    else
                    {
                        lblEducationLevel.Text = "";
                        lblSchoolName.Text = "";
                        lblSubject.Text = "";
                        lblEntryDate.Text = "";
                        lblGraduatedDate.Text = "";
                        lblIsGraduated.Text = "";
                    }
                    if (Res.EducationList.Count > 1)
                    {
                        lblEducationLevel1.Text = Res.EducationList[1].Education;
                        lblSchoolName1.Text = Res.EducationList[1].SchoolName;
                        lblSubject1.Text = Res.EducationList[1].ObjectName;
                        lblEntryDate1.Text = Res.EducationList[1].EnterDate;
                        lblGraduatedDate1.Text = Res.EducationList[1].GraduateDate;
                        lblIsGraguated1.Text = Res.EducationList[1].IsGraduated;
                    }
                    else
                    {
                        lblEducationLevel1.Text = "";
                        lblSchoolName1.Text = "";
                        lblSubject1.Text = "";
                        lblEntryDate1.Text = "";
                        lblGraduatedDate1.Text = "";
                        lblIsGraguated1.Text = "";
                    }
                    lvFamily.DataSource = Res.FamilyInfoList;
                    lvFamily.DataBind();
                    //lvEducation.DataSource = Res.EducationList;
                    //lvEducation.DataBind();
                }
                else//看他人的
                {
                    btnEdit.Visible = false;
                    var Res = rs[0];
                    if (Res.Image != null && Res.Image != "")
                        ImgPhoto.ImageUrl = "data:image/jpg;base64," + Res.Image;
                    lblEmpName.Text = Res.EmpName;
                    lblEmpId.Text = Res.EmpId;
                    lblEmpEnglishName.Text = Res.EmpEnglishName;
                    lblEmpSex.Text = Res.EmpSex;
                    lblEmpBirthday.Text = Res.EmpBirthday.ToLongDateString();
                    //lblEmpMasked.Text = "";
                    lblAge.Text = (DateTime.Now.Year - Res.EmpBirthday.Year).ToString();
                    lblConstellation.Text = GetAtomFromBirthday(Res.EmpBirthday);
                    lblEmpBlood.Text = "";
                    lblEmpMarried.Text = "";

                    lblDeptName.Text = Res.DeptName;
                    lblDeptS.Text = Res.CostDept;
                    lblJobName.Text = Res.JobName;
                    lblSalary.Text = Res.Salary;
                    lblCellphone.Text = Res.Cellphone;
                    lblResidencePhone.Text = Res.ResidencePhone;
                    lblCommunicationPhone.Text = Res.CommunicationPhone;
                    lblEMail.Text = Res.EMail;
                    lblResidenceAddress.Text = Res.ResidenceAddress.Substring(0, 3) + "**********";
                    lblCommunicationAddress.Text = Res.CommunicationAddress.Substring(0, 3) + "**********";
                    if (Res.ContactInfoList.Count > 0)
                    {
                        lblContactName.Text = Res.ContactInfoList[0].ContactName;
                        lblContactPhone.Text = Res.ContactInfoList[0].ContactTel;
                        lblContactRelationship.Text = Res.ContactInfoList[0].ContactRelationship;
                        lblContactCellphone.Text = Res.ContactInfoList[0].ContactPhone;
                    }
                    else
                    {
                        lblContactName.Text = "";
                        lblContactPhone.Text = "";
                        lblContactRelationship.Text = "";
                        lblContactCellphone.Text = "";
                    }
                    if (Res.ContactInfoList.Count > 1)
                    {
                        lblContactName1.Text = Res.ContactInfoList[1].ContactName;
                        lblContactPhone1.Text = Res.ContactInfoList[1].ContactTel;
                        lblContactRelationship1.Text = Res.ContactInfoList[1].ContactRelationship;
                        lblContactCellphone1.Text = Res.ContactInfoList[1].ContactPhone;
                    }
                    else
                    {
                        lblContactName1.Text = "";
                        lblContactPhone1.Text = "";
                        lblContactRelationship1.Text = "";
                        lblContactCellphone1.Text = "";
                    }
                    if (Res.WorkStateList.Count > 0)
                    {
                        var JobData = Res.WorkStateList[Res.WorkStateList.Count - 1];
                        lblState.Text = JobData.JobState;
                        lblWorkDate.Text = Convert.ToDateTime(JobData.ADate).ToString("yyyy/MM/dd");
                    }
                    else
                    {
                        lblState.Text = "";
                        lblWorkDate.Text = "";
                    }
                    if (Res.EducationList.Count > 0)
                    {
                        lblEducationLevel.Text = Res.EducationList[0].Education;
                        lblSchoolName.Text = Res.EducationList[0].SchoolName;
                        lblSubject.Text = Res.EducationList[0].ObjectName;
                        lblEntryDate.Text = Res.EducationList[0].EnterDate;
                        lblGraduatedDate.Text = Res.EducationList[0].GraduateDate;
                        lblIsGraduated.Text = Res.EducationList[0].IsGraduated;
                    }
                    else
                    {
                        lblEducationLevel.Text = "";
                        lblSchoolName.Text = "";
                        lblSubject.Text = "";
                        lblEntryDate.Text = "";
                        lblGraduatedDate.Text = "";
                        lblIsGraduated.Text = "";
                    }
                    if (Res.EducationList.Count > 1)
                    {
                        lblEducationLevel1.Text = Res.EducationList[1].Education;
                        lblSchoolName1.Text = Res.EducationList[1].SchoolName;
                        lblSubject1.Text = Res.EducationList[1].ObjectName;
                        lblEntryDate1.Text = Res.EducationList[1].EnterDate;
                        lblGraduatedDate1.Text = Res.EducationList[1].GraduateDate;
                        lblIsGraguated1.Text = Res.EducationList[1].IsGraduated;
                    }
                    else
                    {
                        lblEducationLevel1.Text = "";
                        lblSchoolName1.Text = "";
                        lblSubject1.Text = "";
                        lblEntryDate1.Text = "";
                        lblGraduatedDate1.Text = "";
                        lblIsGraguated1.Text = "";
                    }
                    lvFamily.DataSource = new List<FamilyInfo>();
                    lvFamily.DataBind();
                    //lvFamily.DataSource = new List<FamilyInfo>();
                    //lvFamily.DataBind();
                    //lvJob.DataSource = Res.WorkStateList;
                    //lvJob.DataBind();
                    //lvContact.DataSource = new List<ContactInfo>();
                    //lvContact.DataBind();
                    //lvEducation.DataSource = Res.EducationList;
                    //lvEducation.DataBind();
                }
            }
        }
        protected void ddlEmp_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            Employee_DataBind();
        }

        /// <summary>
        /// 輸入生日取得星座
        /// </summary>
        /// <param name="birthday">生日</param>
        /// <returns>星座</returns>
        public string GetAtomFromBirthday(DateTime dtBirthDay)
        {
            float fBirthDay = Convert.ToSingle(dtBirthDay.ToString("M.dd"));
            float[] atomBound = { 1.20F, 2.20F, 3.21F, 4.21F, 5.21F, 6.22F, 7.23F, 8.23F, 9.23F, 10.23F, 11.21F, 12.22F, 13.20F };
            string[] atoms = { "水瓶座", "雙魚座", "牡羊座", "金牛座", "雙子座", "巨蟹座", "獅子座", "處女座", "天秤座", "天蠍座", "射手座", "魔羯座" };
            string ret = string.Empty;
            for (int i = 0; i < atomBound.Length - 1; i++)
            {
                if (atomBound[i] <= fBirthDay && atomBound[i + 1] > fBirthDay)
                {
                    ret = atoms[i];
                    break;
                }
            }
            if (ret == "")
            {
                ret = "魔羯座";
            }
            return ret;
        }
    }
}