using JBHRIS.Api.Dto.FlowMainInte.Vdb;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Dal.Interface
{
    public interface ISystem_QuestionMain_View
    {
        List<QuestionMainVdb> GetQuestionMain(string User, string CompanyId, string sNobr);
        List<QuestionMainVdb> GetQuestionMainByCode(string Code);
        List<QuestionMainVdb> GetQuestionMainByEmpID(string CompanyId, string sNobr);
        List<QuestionMainVdb> GetQuestionMainByCompany(string CompanyId);
        
        bool InsertQuestionMain(QuestionMainVdb vdb);

        bool UpdateQuestionMain(string Code, QuestionMainVdb vdb);



    }
}
