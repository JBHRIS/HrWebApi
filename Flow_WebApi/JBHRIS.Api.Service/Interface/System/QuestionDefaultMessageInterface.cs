using JBHRIS.Api.Dto.FlowMainInte.Vdb;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Service.Interface.System
{
    public interface QuestionDefaultMessageInterFace
    {
        List<QuestionDefaultMessageVdb> GetQuestionDefaultMessage(string Code);

        List<QuestionDefaultMessageVdb> GetQuestionDefaultMessageByRoleKey(int RoleKey);

        bool InsertQuestionDefaultMessage(QuestionDefaultMessageVdb vdb);

        bool UpdateQuestionDefaultMessage(QuestionDefaultMessageVdb vdb);

        bool DeleteQuestionDefaultMessage(string Code);

        
    }
}
