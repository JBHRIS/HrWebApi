﻿using JBHRIS.Api.Dto.FlowMainInte.Vdb;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Dal.Interface
{
    public interface ISystem_QuestionReply_View
    {

        List<QuestionReplyVdb> GetQuestionReplyByQuestionMainCode(string QMainCode);

        List<QuestionReplyVdb> GetQuestionReplyByCode(string Code);

        bool InsertQuestionReply(QuestionReplyVdb vdb);

        bool UpdateQuestionReplyContent(string Code, string QRContent);
        bool UpdateQuestionReplySend(string Code, bool QRsend);




    }
}