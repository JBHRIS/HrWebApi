using JBHRIS.Api.Dal.Interface;
using JBHRIS.Api.Dto.FlowMainInte.Vdb;
using JBHRIS.Api.Service.Interface.System;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Service.Implement.System
{
    public class QuestionDefaultMessageService : QuestionDefaultMessageInterFace
    {
        private ISystem_QuestionDefaultMessage_View _ISystem_QuestionDefaultMessage_View;
        public QuestionDefaultMessageService(ISystem_QuestionDefaultMessage_View system_QuestionDefaultMessage_View)
        {
            this._ISystem_QuestionDefaultMessage_View = system_QuestionDefaultMessage_View;
        }

        public List<QuestionDefaultMessageVdb> GetQuestionDefaultMessage(string Code)
        {
            return this._ISystem_QuestionDefaultMessage_View.GetQuestionDefaultMessage(Code);
        }
        public List<QuestionDefaultMessageVdb> GetQuestionDefaultMessageByCompanyId(string CompanyId)
        {
            return this._ISystem_QuestionDefaultMessage_View.GetQuestionDefaultMessageByCompanyId(CompanyId);
        }
        public bool InsertQuestionDefaultMessage(QuestionDefaultMessageVdb vdb)
        {
            return this._ISystem_QuestionDefaultMessage_View.InsertQuestionDefaultMessage(vdb);
        }

        public bool UpdateQuestionDefaultMessage(QuestionDefaultMessageVdb vdb)
        {
            return this._ISystem_QuestionDefaultMessage_View.UpdateQuestionDefaultMessage(vdb);
        }

        public bool DeleteQuestionDefaultMessage(string Code)
        {
            return this._ISystem_QuestionDefaultMessage_View.DeleteQuestionDefaultMessage(Code);
        }

       

    }
}
