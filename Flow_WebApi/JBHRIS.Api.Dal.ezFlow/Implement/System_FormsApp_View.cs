using JBHRIS.Api.Dal.ezFlow.Entity.ezFlow;
using JBHRIS.Api.Dal.Interface;
using JBHRIS.Api.Dto;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using JBHRIS.Api.Dto.System;

namespace JBHRIS.Api.Dal.ezFlow.Implement
{
    public class System_FormsApp_View : ISystem_FormsApp_View
    {

        private ezFlowContext _context;

        public System_FormsApp_View(ezFlowContext ezFlowContext)
        {

            this._context = ezFlowContext;
        }


        public List<FormsAppDto> GetFormsAppList()
        {
            var result = (from d in _context.FormsApps
                          select new FormsAppDto
                          { 
                              AutoKey = d.AutoKey,
                              Cond01 = d.Cond01,
                              Cond02 = d.Cond02,
                              Cond03 = d.Cond03,
                              Cond04 = d.Cond04,
                              Cond05 = d.Cond05,
                              Cond06 = d.Cond06,
                              Cond07 = d.Cond07,
                              Cond08 = d.Cond08,
                              Cond09 = d.Cond09,
                              Cond10 = d.Cond10,
                              DateTimeA = (DateTime)d.DateTimeA,
                              DateTimeD = (DateTime)d.DateTimeD,
                              DeptCode = d.DeptCode,
                              DeptName = d.DeptName,
                              DeptTreeB =d.DeptTreeB,
                              DeptTreeE =d.DeptTreeE,
                              InsertDate = (DateTime)d.InsertDate,
                              InsertMan = d.InsertMan,
                              EmpId = d.EmpId,
                              EmpName = d.EmpName,
                              FormsCode = d.FormsCode,
                              JobCode = d.JobCode,
                              JobName = d.JobName,
                              Note = d.Note,
                              ProcessID = d.ProcessID,
                              UpdateDate = (DateTime)d.UpdateDate,
                              UpdateMan = d.UpdateMan,
                              RoleId = d.RoleId,
                              Sign = d.Sign,
                              SignState = d.SignState,
                              Status = d.Status

                          }).ToList();
            return result;
        }

        public List<FormsAppDto> GetFormsAppListById(List<int> ID)
        {
            var result = (from d in _context.FormsApps
                          where ID.Contains(d.idProcess)
                          select new FormsAppDto
                          {
                              AutoKey = d.AutoKey,
                              Cond01 = d.Cond01,
                              Cond02 = d.Cond02,
                              Cond03 = d.Cond03,
                              Cond04 = d.Cond04,
                              Cond05 = d.Cond05,
                              Cond06 = d.Cond06,
                              Cond07 = d.Cond07,
                              Cond08 = d.Cond08,
                              Cond09 = d.Cond09,
                              Cond10 = d.Cond10,
                              DateTimeA = (DateTime)d.DateTimeA,
                              DateTimeD = (DateTime)d.DateTimeD,
                              DeptCode = d.DeptCode,
                              DeptName = d.DeptName,
                              DeptTreeB = d.DeptTreeB,
                              DeptTreeE = d.DeptTreeE,
                              InsertDate = (DateTime)d.InsertDate,
                              InsertMan = d.InsertMan,
                              EmpId = d.EmpId,
                              EmpName = d.EmpName,
                              FormsCode = d.FormsCode,
                              JobCode = d.JobCode,
                              JobName = d.JobName,
                              Note = d.Note,
                              ProcessID = d.ProcessID,
                              UpdateDate = (DateTime)d.UpdateDate,
                              UpdateMan = d.UpdateMan,
                              RoleId = d.RoleId,
                              Sign = d.Sign,
                              SignState = d.SignState,
                              Status = d.Status

                          }).ToList();
            return result;
        }
    }
    
}
