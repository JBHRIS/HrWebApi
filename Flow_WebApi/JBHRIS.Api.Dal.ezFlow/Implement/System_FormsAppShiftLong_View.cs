using JBHRIS.Api.Dal.ezFlow.Entity.ezFlow;
using JBHRIS.Api.Dal.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using JBHRIS.Api.Dto.FlowMainInte.Vdb;

namespace JBHRIS.Api.Dal.ezFlow.Implement
{
    public class System_FormsAppShiftLong_View : ISystem_FormsAppShiftLong_View
    {

        private ezFlowContext _context;


        public System_FormsAppShiftLong_View(ezFlowContext context)
        {
            this._context = context;
        }



        public List<ShiftLongVdb> GetFormsAppShiftLongByProcessId(int ProcessFlowID, bool Sign, string SignState, string Status)
        {

            SignState = SignState ?? "";
            Status = Status ?? "";

            List<ShiftLongVdb> result = (from bn in this._context.FormsAppShiftLongs
                                          join m in _context.FormsApps on bn.idProcess equals m.idProcess
                                          where bn.idProcess == ProcessFlowID
                                          && (bn.SignState == SignState || SignState == "")
                                          && (bn.Status == Status || Status == "")
                                          select new ShiftLongVdb
                                          {
                                              AutoKey = bn.AutoKey,
                                              Code = bn.Code,
                                              ProcessId = bn.ProcessID,
                                              idProcess = bn.idProcess,
                                              EmpId = bn.EmpId,
                                              EmpName = bn.EmpName,
                                              DeptCode = bn.DeptCode,
                                              DeptName = bn.DeptName,
                                              JobCode = bn.JobCode,
                                              JobName = bn.JobName,
                                              RoleId = bn.RoleId,
                                              Date = bn.Date != null ? Convert.ToDateTime(bn.Date):new DateTime(),
                                              RotetCode = bn.RotetCode,
                                              RotetName = bn.RotetName,
                                              RotetCodeOrigin = bn.RotetCodeOrigin,
                                              RotetNameOrigin = bn.RotetNameOrigin,
                                              Sign = bn.Sign,
                                              SignState = bn.SignState,
                                              Note = bn.Note,
                                              Status = bn.Status,
                                              InsertMan = bn.InsertMan,
                                              InsertDate = bn.InsertDate ?? new DateTime(),
                                              UpdateMan = bn.UpdateMan,
                                              UpdateDate = new DateTime(),
                                          }).ToList();



            return result;
            // return result;
        }
    }
}
