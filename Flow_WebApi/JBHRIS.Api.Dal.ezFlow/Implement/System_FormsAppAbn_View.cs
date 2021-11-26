using JBHRIS.Api.Dal.ezFlow.Entity.ezFlow;
using JBHRIS.Api.Dal.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using JBHRIS.Api.Dto.FlowMainInte.Vdb;

namespace JBHRIS.Api.Dal.ezFlow.Implement
{
    public class System_FormsAppAbn_View : ISystem_FormsAppAbn_View
    {

        private ezFlowContext _context;


        public System_FormsAppAbn_View(ezFlowContext context)
        {
            this._context = context;
        }



        public List<AbnVdb> GetFormsAppAbnByProcessId(int ProcessFlowID, bool Sign, string SignState, string Status)
        {

            SignState = SignState ?? "";
            Status = Status ?? "";

            List<AbnVdb> result = (from bn in this._context.FormsAppAbns
                                   join m in _context.FormsApps on bn.idProcess equals m.idProcess
                                   where bn.idProcess == ProcessFlowID
                                   && (bn.SignState == SignState || SignState == "")
                                   && (bn.Status == Status || Status == "")
                                   select new AbnVdb
                                   {
                                       AutoKey = bn.AutoKey,
                                       Code = bn.Code,
                                       ProcessId = bn.ProcessId,
                                       idProcess = bn.idProcess,
                                       EmpId = bn.EmpId,
                                       EmpName = bn.EmpName,
                                       DeptCode = bn.DeptCode,
                                       DeptName = bn.DeptName,
                                       JobCode = bn.JobCode,
                                       JobName = bn.JobName,
                                       RoleId = bn.RoleId,
                                       DateB = bn.DateB,
                                       IsEarlyWork = bn.IsEarlyWork,
                                       EarlyWorkMin = bn.EarlyWorkMin ?? 0,
                                       IsLateOut = bn.IsLateOut,
                                       LateOutMin = bn.LateOutMin ?? 0,
                                       AbnCode = bn.AbnCode,
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
            // return result;
        }
    }
}
