using JBHRIS.Api.Dal.ezFlow.Entity.ezFlow;
using JBHRIS.Api.Dal.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using JBHRIS.Api.Dto.FlowMainInte.Vdb;

namespace JBHRIS.Api.Dal.ezFlow.Implement
{
    public class System_FormsAppAppoint_View : ISystem_FormsAppAppoint_View
    {

        private ezFlowContext _context;


        public System_FormsAppAppoint_View(ezFlowContext context)
        {
            this._context = context;
        }



        public List<AppointVdb> GetFormsAppAppointByProcessId(int ProcessFlowID, bool Sign, string SignState, string Status)
        {

            SignState = SignState ?? "";
            Status = Status ?? "";

            List<AppointVdb> result = (from bn in this._context.FormsAppAppoints
                                       join m in _context.FormsApps on bn.idProcess equals m.idProcess
                                      where bn.idProcess == ProcessFlowID
                                      && (bn.SignState == SignState || SignState == "")
                                      && (bn.Status == Status || Status == "")
                                      select new AppointVdb
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
                                          SchoolCode = bn.SchoolCode,
                                          SchoolName = bn.SchoolName,
                                          ChangeItemCode = bn.ChangeItemCode,
                                          ChangeItemName = bn.ChangeItemName,
                                          DeptCodeChange = bn.DeptCodeChange,
                                          DeptNameChange = bn.DeptNameChange,
                                          DeptmCodeChange = bn.DeptmCodeChange,
                                          DeptmNameChange = bn.DeptmNameChange,
                                          JobCodeChange = bn.JobCodeChange,
                                          JobNameChange = bn.JobNameChange,
                                          JoblCodeChange = bn.JoblCodeChange,
                                          JoblNameChange = bn.JoblNameChange,
                                          DateAppoint = bn.DateAppoint,
                                          ReasonChange = bn.ReasonChange,
                                          Qualified = bn.Qualified,
                                          Evaluation = bn.Evaluation,
                                          Performance1 = bn.Performance1,
                                          Performance2 = bn.Performance2,
                                          Performance3 = bn.Performance3,
                                          AllowSalary = bn.AllowSalary,
                                          AllowSign = bn.AllowSign,
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
                var EmpLog = (from c in _context.FormsAppAppointChangeLogs
                              where c.AppointCode == rs.Code
                              select new AppointChangeLog
                              {
                                  AppointCode = c.AppointCode,
                                  DeptCodeChange = c.DeptCodeChange,
                                  DeptNameChange = c.DeptNameChange,
                                  DeptmCodeChange = c.DeptmCodeChange,
                                  DeptmNameChange = c.DeptmNameChange,
                                  JobCodeChange = c.JobCodeChange,
                                  JobNameChange = c.JobNameChange,
                                  JoblCodeChange = c.JoblCodeChange,
                                  JoblNameChange = c.JoblNameChange,
                                  Performance1 = c.Performance1,
                                  Performance2 = c.Performance2,
                                  DateAppoint = c.DateAppoint,
                                  SalaryContent = c.SalaryContent,
                                  Note = c.Note,
                                  Status = c.Status,
                                  InsertDate = c.InsertDate ?? new DateTime(),
                                  InsertMan = c.InsertMan,
                                  UpdateDate = c.UpdateDate ?? new DateTime(),
                                  UpdateMan = c.UpdateMan
                              }).ToList();
                rs.AppointChangeLog = EmpLog;
            }


            return result;
        }
        public List<AppointVdb> GetFormsAppAppointForHR()
        {


            List<AppointVdb> result = (from bn in this._context.FormsAppAppoints
                                       join m in _context.FormsApps on bn.idProcess equals m.idProcess
                                       join pa in _context.ProcessApParms on m.ProcessID equals pa.ProcessFlow_id.ToString()
                                       where bn.SignState == "1"
                                       select new AppointVdb
                                       {
                                           AutoKey = bn.AutoKey,
                                           Code = bn.Code,
                                           ProcessId = bn.ProcessId,
                                           ProcessApParm = pa.auto.ToString(),
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
                                           SchoolCode = bn.SchoolCode,
                                           SchoolName = bn.SchoolName,
                                           ChangeItemCode = bn.ChangeItemCode,
                                           ChangeItemName = bn.ChangeItemName,
                                           DeptCodeChange = bn.DeptCodeChange,
                                           DeptNameChange = bn.DeptNameChange,
                                           DeptmCodeChange = bn.DeptmCodeChange,
                                           DeptmNameChange = bn.DeptmNameChange,
                                           JobCodeChange = bn.JobCodeChange,
                                           JobNameChange = bn.JobNameChange,
                                           JoblCodeChange = bn.JoblCodeChange,
                                           JoblNameChange = bn.JoblNameChange,
                                           DateAppoint = bn.DateAppoint,
                                           ReasonChange = bn.ReasonChange,
                                           Qualified = bn.Qualified,
                                           Evaluation = bn.Evaluation,
                                           Performance1 = bn.Performance1,
                                           Performance2 = bn.Performance2,
                                           Performance3 = bn.Performance3,
                                           AllowSalary = bn.AllowSalary,
                                           AllowSign = bn.AllowSign,
                                           Sign = bn.Sign,
                                           SignState = bn.SignState,
                                           Note = bn.Note,
                                           Status = bn.Status,
                                           InsertMan = bn.InsertMan,
                                           InsertDate = bn.InsertDate ?? new DateTime(),
                                           UpdateMan = bn.UpdateMan,
                                           UpdateDate = bn.UpdateDate ?? new DateTime(),
                                       }).ToList();
            return result;
        }
        }
}
