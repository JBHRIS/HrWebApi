﻿using JBHRIS.Api.Dto.FlowMainInte.Vdb;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Service.Interface.System
{
    public interface QuestionReplyInterFace
    {
        List<QuestionReplyVdb> GetQuestionReplyByQuestionMainCode(string QMainCode);
        List<QuestionReplyVdb> GetQuestionReplyByParentCode(string ParentCode);

        bool InsertQuestionReply(QuestionReplyVdb vdb);

        bool UpdateQuestionReplyContent(string Code, string QRContent);
        bool UpdateQuestionReplySend(string Code, bool QRsend);



    }
}
