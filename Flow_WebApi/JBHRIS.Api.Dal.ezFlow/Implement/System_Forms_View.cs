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
    public class System_Forms_View : ISystem_Forms_View
    {

        private ezFlowContext _context;

        public System_Forms_View(ezFlowContext ezFlowContext) {

            this._context = ezFlowContext;
        }

        public List<FormsDto> GetFormsList()
        {
            List<FormsDto> result = new List<FormsDto>();

            result = (from d in _context.Forms
                      select new FormsDto
                      {
                         AutoKey = d.AutoKey,
                         Code = d.Code,
                         Name = d.Name,
                         FlowTreeId = d.FlowTreeId,
                         NoteStd = d.NoteStd,
                         NoteCheck = d.NoteCheck,
                         NoteView = d.NoteView,
                         NoteEtc = d.NoteEtc,
                         AppLimitCount = d.AppLimitCount,
                         CheckNote = d.CheckNote,
                         CheckSignNote = d.CheckSignNote ,
                         DisplaySignProcess = d.DisplaySignProcess ,
                         DisplayUploadFile = d.DisplayUploadFile ,
                         CheckUploadFile = d.CheckUploadFile,
                         TableName = d.TableName ,
                         SaveUrl = d.SaveUrl,
                         SaveMethod = d.SaveMethod,
                         DateA = d.DateA,
                         DateD = d.DateD,
                         Sort = d.Sort,
                         Note = d.Note ,
                         Status = d.Status ,
                         InsertMan = d.InsertMan,
                         InsertDate = d.InsertDate,
                         UpdateMan = d.UpdateMan,
                         UpdateDate = d.UpdateDate,

                      }).ToList();

            return result;
        }

        public List<FormsDto> GetFormsListByCode(List<string> CodeList)
        {
            List<FormsDto> result = new List<FormsDto>();

            result = (from d in _context.Forms
                      where CodeList.Contains(d.Code)
                      select new FormsDto
                      {
                          AutoKey = d.AutoKey,
                          Code = d.Code,
                          Name = d.Name,
                          FlowTreeId = d.FlowTreeId,
                          NoteStd = d.NoteStd,
                          NoteCheck = d.NoteCheck,
                          NoteView = d.NoteView,
                          NoteEtc = d.NoteEtc,
                          AppLimitCount = d.AppLimitCount,
                          CheckNote = d.CheckNote,
                          CheckSignNote = d.CheckSignNote,
                          DisplaySignProcess = d.DisplaySignProcess,
                          DisplayUploadFile = d.DisplayUploadFile,
                          CheckUploadFile = d.CheckUploadFile,
                          TableName = d.TableName,
                          SaveUrl = d.SaveUrl,
                          SaveMethod = d.SaveMethod,
                          DateA = d.DateA,
                          DateD = d.DateD,
                          Sort = d.Sort,
                          Note = d.Note,
                          Status = d.Status,
                          InsertMan = d.InsertMan,
                          InsertDate = d.InsertDate,
                          UpdateMan = d.UpdateMan,
                          UpdateDate = d.UpdateDate,

                      }).ToList();

            return result;
        }
        public int GetProcessID()
        {
            int result = -1;
            result = (from d in _context.Forms
                      orderby d.AutoKey descending
                      select d.AutoKey).FirstOrDefault();
            result += 1;
            return result;
        }
    }
}
