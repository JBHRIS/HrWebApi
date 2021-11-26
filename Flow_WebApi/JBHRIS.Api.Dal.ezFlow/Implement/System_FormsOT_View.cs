using JBHRIS.Api.Dal.ezFlow.Entity.ezFlow;
using JBHRIS.Api.Dal.Interface;
using JBHRIS.Api.Dto;
using JBHRIS.Api.Dto.FlowMainInte.Vdb;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace JBHRIS.Api.Dal.ezFlow.Implement
{
    public class System_FormsOT_View : ISystem_FormsOT_View
    {

        private ezFlowContext _context;

        public System_FormsOT_View(ezFlowContext context)
        {
            this._context = context;
        }

        public OTFlowAppsRow GetFormsAppOTByAutoKey(int AutoKey, string SignState, string Status)
        {

            OTFlowAppsRow FlowApp = new OTFlowAppsRow();

            SignState = SignState ?? "";
            Status = Status ?? "";

            FlowApp = (from ot in this._context.FormsAppOts
                           //join a in this._context.FormsApps on ot.idProcess equals a.idProcess
                       where ot.AutoKey == AutoKey
                       && (ot.SignState == SignState || SignState == "")
                       && (ot.Status == Status || Status == "")
                       select new OTFlowAppsRow
                       {
                           AutoKey = ot.AutoKey,
                           ProcessID = ot.ProcessID,

                           EmpID = ot.EmpId,
                           EmpCode = ot.EmpId,
                           EmpName = ot.EmpName,
                           RoteID = ot.RoleId,
                           RoteCode = ot.RoteCode,
                           RoteName = ot.RoteName,
                           RotehCode = ot.RotehCode,
                           RotehName = ot.RotehName,

                           DateTimeB = ot.DateTimeB,
                           DateTimeE = ot.DateTimeE,
                           DateTimeB1 = ot.DateTimeB1,
                           DateTimeE1 = ot.DateTimeE1,
                           DateB = ot.DateB,
                           DateE = ot.DateE,
                           DateB1 = ot.DateB1,
                           DateE1 = ot.DateE1,
                           TimeB = ot.TimeB,
                           TimeE = ot.TimeE,
                           TimeB1 = ot.TimeB1,
                           TimeE1 = ot.TimeE1,

                           Code = ot.Code,
                           OtCateCode = ot.OtCateCode,
                           OtCateName = ot.OtCateName,
                           OtrcdCode = ot.OtrcdCode,
                           OtrcdName = ot.OtrcdName,

                           Use = ot.Use,
                           UnitCode = ot.UnitCode,
                           IsExceptionUse = ot.IsExceptionUse,
                           Sign = ot.Sign,
                           SignState = ot.SignState,
                           Status = ot.Status,
                           Note = ot.Note,

                           DeptCode = ot.DeptCode,
                           DeptName = ot.DeptName,
                           JobCode = ot.JobCode,
                           JobName = ot.JobName,
                           DeptsCode = ot.DeptsCode,
                           DeptsName = ot.DeptsName,
                           InsertMan = ot.InsertMan ?? "",
                           InsertDate = ot.InsertDate ?? DateTime.Now,
                           UpdateMan = ot.UpdateMan ?? "",
                           UpdateDate = ot.UpdateDate ?? DateTime.Now
                       }).FirstOrDefault();

            return FlowApp;
        }

        public OTFlowAppRow GetFormsAppOTByProcessId(int ProcessFlowID, bool Sign, string SignState, string Status)
        {

            OTFlowAppRow result = new OTFlowAppRow();

            List<OTFlowAppsRow> FlowApps = new List<OTFlowAppsRow>();

            SignState = SignState ?? "";
            Status = Status ?? "";

            FlowApps = (from ot in this._context.FormsAppOts
                            //join a in this._context.FormsApps on ot.idProcess equals a.idProcess
                        where ot.idProcess == ProcessFlowID
                        && (ot.SignState == SignState || SignState == "")
                        && (ot.Status == Status || Status == "")

                        select new OTFlowAppsRow
                        {
                            AutoKey = ot.AutoKey,
                            ProcessID = ot.ProcessID,

                            EmpID = ot.EmpId,
                            EmpCode = ot.EmpId,
                            EmpName = ot.EmpName,
                            RoteID = ot.RoleId,
                            RoteCode = ot.RoteCode,
                            RoteName = ot.RoteName,
                            RotehCode = ot.RotehCode,
                            RotehName = ot.RotehName,

                            DateTimeB = ot.DateTimeB,
                            DateTimeE = ot.DateTimeE,
                            DateTimeB1 = ot.DateTimeB1,
                            DateTimeE1 = ot.DateTimeE1,
                            DateB = ot.DateB,
                            DateE = ot.DateE,
                            DateB1 = ot.DateB1,
                            DateE1 = ot.DateE1,
                            TimeB = ot.TimeB,
                            TimeE = ot.TimeE,
                            TimeB1 = ot.TimeB1,
                            TimeE1 = ot.TimeE1,

                            Code = ot.Code,
                            OtCateCode = ot.OtCateCode,
                            OtCateName = ot.OtCateName,
                            OtrcdCode = ot.OtrcdCode,
                            OtrcdName = ot.OtrcdName,

                            Use = ot.Use,
                            UnitCode = ot.UnitCode,
                            IsExceptionUse = ot.IsExceptionUse,
                            Sign = ot.Sign,
                            SignState = ot.SignState,
                            Status = ot.Status,
                            Note = ot.Note,

                            DeptCode = ot.DeptCode,
                            DeptName = ot.DeptName,
                            JobCode = ot.JobCode,
                            JobName = ot.JobName,
                            DeptsCode = ot.DeptsCode,
                            DeptsName = ot.DeptsName,
                            InsertMan = ot.InsertMan ?? "",
                            InsertDate = ot.InsertDate ?? DateTime.Now,
                            UpdateMan = ot.UpdateMan ?? "",
                            UpdateDate = ot.UpdateDate ?? DateTime.Now


                        }).ToList();
            result.FlowApps = new List<OTFlowAppsRow>();
            result.FlowApps.AddRange(FlowApps);
            return result;
        }
        

    }
}
