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
    public class System_FormsAppInfo_View : ISystem_FormsAppInfo_View
    {

        private ezFlowContext _context;

        public System_FormsAppInfo_View(ezFlowContext ezFlowContext)
        {

            this._context = ezFlowContext;
        }

        public List<FormsAppInfoDto> GetFormsAppInfoList()
        {
            var result = new List<FormsAppInfoDto>();
            result = (from d in _context.FormsAppInfos
                      select new FormsAppInfoDto
                      {
                          AutoKey = d.AutoKey,
                          ProcessID = d.ProcessId,
                          idProcess = d.idProcess,
                          EmpId = d.EmpId,
                          EmpName = d.EmpName,
                          InfoMail = d.InfoMail,
                          InfoSign = d.InfoSign,
                          Code = d.Code,
                          SignState = d.SignState,
                          KeyDate = (DateTime)d.KeyDate
                      }).ToList();
            return result;
        }

        public List<FormsAppInfoDto> GetFormsAppInfoListByProcessId(List<string> ProcessId)
        {
            var result = new List<FormsAppInfoDto>();
            result = (from d in _context.FormsAppInfos
                      where ProcessId.Contains(d.ProcessId)
                      select new FormsAppInfoDto
                      {
                          AutoKey = d.AutoKey,
                          ProcessID = d.ProcessId,
                          idProcess = d.idProcess,
                          EmpId = d.EmpId,
                          EmpName = d.EmpName,
                          InfoMail = d.InfoMail,
                          InfoSign = d.InfoSign,
                          Code = d.Code,
                          SignState = d.SignState,
                          KeyDate = (DateTime)d.KeyDate
                      }).ToList();
            return result;
        }
    }
    
}
