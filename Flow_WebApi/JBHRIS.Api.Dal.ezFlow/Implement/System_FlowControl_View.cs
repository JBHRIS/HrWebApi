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
    public class System_FlowControl_View : ISystem_FlowControl_View
    {

        private ezFlowContext _context;

        public System_FlowControl_View(ezFlowContext ezFlowContext)
        {

            this._context = ezFlowContext;
        }

        public List<FlowControlDto> GetFlowControlByCode(List<string> Form, List<string> Code)
        {
            var result = new List<FlowControlDto>();
            result = (from d in _context.FlowControls
                      where Form.Contains(d.sForm) && Code.Contains(d.sFormCode)
                      select new FlowControlDto
                      {
                          FormCode = d.sFormCode,
                          KeyDate = (DateTime)d.dKeydate,
                          AutoKey = d.iAutokey,
                          Form = d.sForm,
                          KeyMan = d.sKeyMan,
                          Value = d.sValue
                      }).ToList();
            return result;
        }

        public List<FlowControlCodeDto> GetFlowControlCodeList()
        {
            var result = new List<FlowControlCodeDto>();
            result = (from d in _context.FlowControlCodes
                      select new FlowControlCodeDto
                      {
                          AutoKey = d.Autokey,
                          Description = d.Description,
                          FCode = d.FCode,
                          Form = d.Form,
                          Type = d.Type,
                          Value = d.Value
                      }).ToList();
            return result;
        }
    }
    
}
