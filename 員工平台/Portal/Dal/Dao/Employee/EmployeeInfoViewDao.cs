using Bll.Employee.Vdb;
using Bll.Token.Vdb;
using Bll.Tools;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Dal.Dao.Employee
{
    public class EmployeeInfoViewDao : BaseWebAPI<EmployeeInfoViewApiRow>
    {

        public EmployeeInfoViewDao() : base()
        {
            this.restURL = "/Employee/GetEmployeeInfoView";
            this.ApiSetting = "Hr";
            IsCollectionType = false;
            EncodingType = EnctypeMethod.JSON;
            NeedSaveData = true;
        }

        public async Task<APIResult> PostAsync(EmployeeInfoViewConditions Cond, CancellationToken cancellationToken = default(CancellationToken))
        {
            AuthenticationHeaderBearerTokenValue = Cond.AccessToken;

            //移除敏感資料
            var AccessToken = Cond.AccessToken;
            var RefreshToken = Cond.RefreshToken;
            Cond.AccessToken = "";
            Cond.RefreshToken = "";

            #region 要傳遞的參數
            HTTPPayloadDictionary dic = new HTTPPayloadDictionary();

            dic.Add(Constants.JSONDataKeyName, JsonConvert.SerializeObject(Cond.ListEmpId));
            #endregion

            var mr = await this.SendAsync(dic, HttpMethod.Post,RefreshToken, cancellationToken);

            return mr;
        }

        public APIResult Post(EmployeeInfoViewConditions Cond, CancellationToken cancellationToken = default(CancellationToken))
        {
            AuthenticationHeaderBearerTokenValue = Cond.AccessToken;

            //移除敏感資料
            var AccessToken = Cond.AccessToken;
            var RefreshToken = Cond.RefreshToken;
            Cond.AccessToken = "";
            Cond.RefreshToken = "";

            #region 要傳遞的參數
            HTTPPayloadDictionary dic = new HTTPPayloadDictionary();
            this.CompanySetting = Cond.CompanySetting;
            dic.Add(Constants.JSONDataKeyName, JsonConvert.SerializeObject(Cond.ListEmpId));
            #endregion

            var mr = this.Send(dic, HttpMethod.Post,RefreshToken, cancellationToken);

            return mr;
        }

        public async Task<APIResult> GetDataAsync(EmployeeInfoViewConditions Cond, CancellationToken cancellationToken = default(CancellationToken))
        {
            var Vdb = await PostAsync(Cond, cancellationToken);
            if (Vdb.Status)
            {
                if (Vdb.Payload != null)
                {
                    //實作DTO轉換

                }
            }
            return Vdb;
        }

        public APIResult GetData(EmployeeInfoViewConditions Cond, CancellationToken cancellationToken = default(CancellationToken))
        {
            var Vdb = Post(Cond, cancellationToken);

            if (Vdb.Status)
            {
                if (Vdb.Data != null)
                {
                    if (Vdb.Payload != null && Vdb.Data != null)
                    {
                        //實作DTO轉換
                        var oSource = Vdb.Data as EmployeeInfoViewApiRow;
                        if (oSource != null)
                        {
                            Vdb.Status = oSource.state;
                            Vdb.Message = oSource.message;
                            Vdb.StackTrace = oSource.stackTrace;
                            var rsSource = oSource;
                            var rsTarget = new List<EmployeeInfoViewRow>();

                            foreach (var rSource in rsSource.result)
                            {
                                
                                var rTarget = new EmployeeInfoViewRow();
                                rTarget.Image = rSource.photo;
                                rTarget.EmpId = rSource.employeeId;
                                rTarget.EmpName = rSource.employeeNameC;
                                rTarget.EmpEnglishName = rSource.employeeNameE;
                                rTarget.EmpSex = rSource.sex;
                                rTarget.EmpBirthday = rSource.birthday;
                                rTarget.EmpBlood = rSource.blood;
                                rTarget.EmpIdNumber = rSource.idNo;
                                rTarget.EmpMarried = rSource.marry;

                                rTarget.DeptCode = rSource.deptCode;
                                rTarget.DeptName = rSource.dept;
                                rTarget.DeptaCode = rSource.deptaCode;
                                rTarget.DeptaName = rSource.deptaCodeName;
                                rTarget.CostDept = rSource.depts;
                                rTarget.JobCode = rSource.jobCode;
                                rTarget.JobName = rSource.job;
                                rTarget.JoblCode = rSource.joblCode;
                                rTarget.JoblName = rSource.joblName;
                                rTarget.Salary = rSource.seniority;

                                rTarget.Cellphone = rSource.cellphone;
                                rTarget.ResidencePhone = rSource.residencePhone;
                                rTarget.CommunicationPhone = rSource.communicationPhone;
                                rTarget.EMail = rSource.email;
                                rTarget.ResidenceAddress = rSource.residenceAddress;
                                rTarget.CommunicationAddress = rSource.communicationAddress;

                                var rsWorkState = new List<WorkState>();
                                foreach (var rsTargetWorkState in rSource.workStatusInfo)
                                {
                                    var oWorkState = new WorkState();
                                    oWorkState.JobState = rsTargetWorkState.status;
                                    oWorkState.ADate = rsTargetWorkState.aDate;
                                    rsWorkState.Add(oWorkState);
                                }
                                rTarget.WorkStateList = rsWorkState;
                               

                                var rsFamilyInfo = new List<FamilyInfo>();
                                foreach (var rsTargetFamilyInfo in rSource.familyInfo)
                                {
                                    var oFamilyInfo = new FamilyInfo();
                                    oFamilyInfo.FamilyName = rsTargetFamilyInfo.name;
                                    oFamilyInfo.FamilyBirthday = rsTargetFamilyInfo.birthday;
                                    oFamilyInfo.Relationship = rsTargetFamilyInfo.relationship;
                                    rsFamilyInfo.Add(oFamilyInfo);
                                }
                                rTarget.FamilyInfoList = rsFamilyInfo;

                                var rsContactInfo = new List<ContactInfo>();
                                foreach (var rsTargetContactInfo in rSource.contactPersonInfo)
                                {
                                    var oContactInfo = new ContactInfo();
                                    oContactInfo.ContactName = rsTargetContactInfo.name;
                                    oContactInfo.ContactRelationship = rsTargetContactInfo.relationship;
                                    oContactInfo.ContactTel = rsTargetContactInfo.phone;
                                    oContactInfo.ContactPhone = rsTargetContactInfo.cellphone;
                                    rsContactInfo.Add(oContactInfo);
                                }
                                rTarget.ContactInfoList = rsContactInfo;

                                var rsEducationInfo = new List<EducationInfo>();
                                foreach (var rsTargetEducationInfo in rSource.schoolInfo)
                                {
                                    var oEducationInfo = new EducationInfo();
                                    oEducationInfo.IsEducationLevelTop = rsTargetEducationInfo.IsEducationLevelTop;
                                    oEducationInfo.Education = rsTargetEducationInfo.educationLevel;
                                    oEducationInfo.ADate = rsTargetEducationInfo.adate;
                                    oEducationInfo.SchoolName = rsTargetEducationInfo.schoolName;
                                    
                                    oEducationInfo.ObjectName = rsTargetEducationInfo.department;
                                    oEducationInfo.EnterDate = rsTargetEducationInfo.enrollmentDate;
                                    oEducationInfo.GraduateDate = rsTargetEducationInfo.graduationDate;
                                    var isGrduate = rsTargetEducationInfo.graduation ? "是" : "否";
                                    oEducationInfo.IsGraduated = isGrduate;
                                    rsEducationInfo.Add(oEducationInfo);
                                }
                                rTarget.EducationList = rsEducationInfo;

                                var rsWorksInfo = new List<WorksInfo>();
                                foreach (var rsTargetWorksInfo in rSource.worksInfo)
                                {
                                    var oWorksInfo = new WorksInfo();
                                    oWorksInfo.EmpId = rsTargetWorksInfo.Nobr;
                                    oWorksInfo.Job = rsTargetWorksInfo.Job;
                                    oWorksInfo.Note = rsTargetWorksInfo.Note;
                                    oWorksInfo.Title = rsTargetWorksInfo.Title;
                                    oWorksInfo.BDate = rsTargetWorksInfo.BDate;
                                    oWorksInfo.EDate = rsTargetWorksInfo.EDate;
                                    rsWorksInfo.Add(oWorksInfo);
                                }
                                rTarget.WorksInfoList = rsWorksInfo;

                                rsTarget.Add(rTarget);
                                
                            }
                            Vdb.Data = rsTarget;
                        }
                    }
                }
            }

            return Vdb;
        }
    }
}