﻿using JBHRIS.Api.Dto.FlowMainInte.Vdb;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Service.Interface.System
{
    public interface QuestionMainInterFace
    {
        List<QuestionMainVdb> GetQuestionMain();
        List<QuestionMainVdb> GetQuestionMainByCode(string Code);
        List<QuestionMainVdb> GetQuestionMainByEmpID(string CompanyId, string sNobr);
        List<QuestionMainVdb> GetQuestionMainByCompany(string CompanyId);
        bool InsertQuestionMain(QuestionMainVdb vdb);
        bool UpdateQuestionMain(string Code, QuestionMainVdb vdb);


    }
}