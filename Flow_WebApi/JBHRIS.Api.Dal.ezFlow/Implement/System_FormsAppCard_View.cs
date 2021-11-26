using JBHRIS.Api.Dal.ezFlow.Entity.ezFlow;
using JBHRIS.Api.Dal.Interface;
using JBHRIS.Api.Dto.FlowMainInte.Vdb;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace JBHRIS.Api.Dal.ezFlow.Implement
{
    public class System_FormsAppCard_View : ISystem_FormsAppCard_View
    {
        private ezFlowContext _context;
        public System_FormsAppCard_View(ezFlowContext context)
        {
            this._context = context;
        }

        public CardFlowAppRow GetFormsAppCardByProcessId(int ProcessFlowID, bool Sign, string SignState, string Status)
        {
            

            List<CardFlowAppsRow> FlowApps = new List<CardFlowAppsRow>();

            SignState = SignState ?? "";
            Status = Status ?? "";

            FlowApps = (from card in this._context.FormsAppCards
                            //join a in this._context.FormsApps on ot.idProcess equals a.idProcess
                        where card.idProcess == ProcessFlowID 
                        && ( card.SignState == SignState || SignState=="")
                        && ( card.Status == Status || Status=="")

                        select new CardFlowAppsRow
                        {
                            AutoKey = card.AutoKey,
                            ProcessID = card.ProcessId,
                            Code = card.Code,
                            EmpID = card.EmpId,
                            EmpCode = card.EmpId,
                            EmpName = card.EmpName,
                            RoteID = card.RoleId,

                            DateTimeB = card.DateTimeB,
                            DateTimeE = card.DateTimeE,
                            DateB = card.DateB,
                            DateE = card.DateE,
                            TimeB = card.TimeB,
                            TimeE = card.TimeE,

                            CardLostCode = card.CardLostCode,
                            CardLostName = card.CardLostName,


                            Sign = card.Sign,
                            SignState = card.SignState,
                            Status = card.Status,
                            Note = card.Note,

                            DeptCode = card.DeptCode,
                            DeptName = card.DeptName,
                            JobCode = card.JobCode,
                            JobName = card.JobName,
                            InsertMan = card.InsertMan ?? "",
                            InsertDate = card.InsertDate ?? DateTime.Now,
                            UpdateMan = card.UpdateMan ?? "",
                            UpdateDate = card.UpdateDate ?? DateTime.Now


                        }).ToList();

            CardFlowAppRow result = new CardFlowAppRow();
            result.FlowApps = new List<CardFlowAppsRow>();
            result.FlowApps.AddRange(FlowApps);
            return result;
        }
    
    }
}
