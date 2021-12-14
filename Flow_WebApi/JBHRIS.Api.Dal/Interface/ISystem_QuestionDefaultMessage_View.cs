using JBHRIS.Api.Dto.FlowMainInte.Vdb;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Dal.Interface
{
    public interface ISystem_QuestionDefaultMessage_View
    {

        List<QuestionDefaultMessageVdb> GetQuestionDefaultMessage(string Code);

        List<QuestionDefaultMessageVdb> GetQuestionDefaultMessageByRoleKey(int RoleKey);
        bool InsertQuestionDefaultMessage(QuestionDefaultMessageVdb vdb);

        bool UpdateQuestionDefaultMessage(QuestionDefaultMessageVdb vdb);

        bool DeleteQuestionDefaultMessage(string Code);

       

    }
}
