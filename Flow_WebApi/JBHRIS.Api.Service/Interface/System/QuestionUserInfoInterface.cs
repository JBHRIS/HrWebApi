﻿using JBHRIS.Api.Dto.FlowMainInte.Vdb;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Service.Interface.System
{
    public interface QuestionUserInfoInterFace
    {
        List<QuestionUserInfoVdb> GetQuestionUserInfoByCode(string Code);
        


    }
}