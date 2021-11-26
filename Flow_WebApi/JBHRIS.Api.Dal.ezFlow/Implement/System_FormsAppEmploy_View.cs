using JBHRIS.Api.Dal.ezFlow.Entity.ezFlow;
using JBHRIS.Api.Dal.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using JBHRIS.Api.Dto.FlowMainInte.Vdb;

namespace JBHRIS.Api.Dal.ezFlow.Implement
{
    public class System_FormsAppEmploy_View : ISystem_FormsAppEmploy_View
    {

        private ezFlowContext _context;


        public System_FormsAppEmploy_View(ezFlowContext context)
        {
            this._context = context;
        }



        public List<EmployVdb> GetFormsAppEmployByProcessId(int ProcessFlowID, bool Sign, string SignState, string Status)
        {

            SignState = SignState ?? "";
            Status = Status ?? "";

            List<EmployVdb> result = (from bn in this._context.FormsAppEmploys
                                      join m in _context.FormsApps on bn.idProcess equals m.idProcess
                                      where bn.idProcess == ProcessFlowID
                                      && (bn.SignState == SignState || SignState == "")
                                      && (bn.Status == Status || Status == "")
                                      select new EmployVdb
                                      {
                                          AutoKey = bn.AutoKey,
                                          Code = bn.Code,
                                          ProcessId = bn.ProcessId,
                                          idProcess = bn.idProcess,
                                          EmpId = bn.EmpId,
                                          EmpName = bn.EmpName,
                                          DeptCode = bn.DeptCode,
                                          DeptName = bn.DeptName,
                                          DeptmCode = bn.DeptmCode,
                                          DeptmName = bn.DeptmName,
                                          JobCode = bn.JobCode,
                                          JobName = bn.JobName,
                                          JoblCode = bn.JoblCode,
                                          JoblName = bn.JoblName,
                                          RoleId = bn.RoleId,
                                          Birthday = bn.Birthday,
                                          Sex = bn.Sex,
                                          DateIn = bn.DateIn,
                                          DateA = bn.DateA,
                                          DateD = bn.DateD,
                                          SchoolCode = bn.SchoolCode,
                                          SchoolName = bn.SchoolName,
                                          WorkExperience = bn.WorkExperience,
                                          AttendContent = bn.AttendContent,
                                          DeptCodeChange = bn.DeptCodeChange,
                                          DeptNameChange = bn.DeptNameChange,
                                          DeptmCodeChange = bn.DeptmCodeChange,
                                          DeptmNameChange = bn.DeptmNameChange,
                                          JobCodeChange = bn.JobCodeChange,
                                          JobNameChange = bn.JobNameChange,
                                          JoblCodeChange = bn.JoblCodeChange,
                                          JoblNameChange = bn.JoblNameChange,
                                          ResultAreaCode = bn.ResultAreaCode,
                                          ResultAreaName = bn.ResultAreaName,
                                          DateAppoint = bn.DateAppoint,
                                          AllowSalary = bn.AllowSalary,
                                          AllowSign = bn.AllowSign,
                                          ExtendMonth = bn.ExtendMonth,
                                          Sign = bn.Sign,
                                          SignState = bn.SignState,
                                          Note = bn.Note,
                                          Status = bn.Status,
                                          InsertMan = bn.InsertMan,
                                          InsertDate = bn.InsertDate ?? new DateTime(),
                                          UpdateMan = bn.UpdateMan,
                                          UpdateDate = bn.UpdateDate ?? new DateTime(),
                                      }).ToList();
            foreach (var rs in result)
            {
                var EmpLog = (from c in _context.FormsAppEmployChangeLogs
                              where c.EmployCode == rs.Code
                              select new EmployChangeLog
                              {
                                  EmployCode = c.EmployCode,
                                  DeptCodeChange = c.DeptCodeChange,
                                  DeptNameChange = c.DeptNameChange,
                                  DeptmCodeChange = c.DeptmCodeChange,
                                  DeptmNameChange = c.DeptmNameChange,
                                  JobCodeChange = c.JobCodeChange,
                                  JobNameChange = c.JobNameChange,
                                  JoblCodeChange = c.JoblCodeChange,
                                  JoblNameChange = c.JoblNameChange,
                                  ResultAreaCode = c.ResultAreaCode,
                                  ResultAreaName = c.ResultAreaName,
                                  ExtendMonth = c.ExtendMonth,
                                  DateAppoint = c.DateAppoint,
                                  Performance01 = c.Performance01,
                                  Performance02 = c.Performance02,
                                  Performance03 = c.Performance03,
                                  Performance04 = c.Performance04,
                                  Performance05 = c.Performance05,
                                  SalaryContent = c.SalaryContent,
                                  Note = c.Note,
                                  Status = c.Status,
                                  InsertDate = c.InsertDate ?? new DateTime(),
                                  InsertMan = c.InsertMan,
                                  UpdateDate = c.UpdateDate ?? new DateTime(),
                                  UpdateMan = c.UpdateMan
                              }).ToList();
                rs.EmployChangeLog = EmpLog;
            }


            return result;
        }
    }
}
