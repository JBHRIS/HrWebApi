using JBHRIS.Api.Dal.Interface;
using JBHRIS.Api.Dto.FlowMainInte.Vdb;
using JBHRIS.Api.Service.Interface.System;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Service.Implement.System
{
    public class QuestionReplyService : QuestionReplyInterFace
    {
        private ISystem_QuestionReply_View _ISystem_QuestionReply_View;
        public QuestionReplyService(ISystem_QuestionReply_View system_QuestionReply_View)
        {
            this._ISystem_QuestionReply_View = system_QuestionReply_View;
        }

        public List<QuestionReplyVdb> GetQuestionReplyByQuestionMainCode(string QMainCode)
        {
            return this._ISystem_QuestionReply_View.GetQuestionReplyByQuestionMainCode(QMainCode);
        }
        public List<QuestionReplyVdb> GetQuestionReplyByCode(string Code)
        {
            return this._ISystem_QuestionReply_View.GetQuestionReplyByCode(Code);
        }

        public bool InsertQuestionReply(QuestionReplyVdb vdb)
        {
            return this._ISystem_QuestionReply_View.InsertQuestionReply(vdb);
        }

        public bool UpdateQuestionReplySend(string Code, bool QRsend)
        {
            return this._ISystem_QuestionReply_View.UpdateQuestionReplySend(Code,QRsend);
        }

        public bool UpdateQuestionReplyContent(string Code, string QRContent)
        {
            return this._ISystem_QuestionReply_View.UpdateQuestionReplyContent(Code,QRContent);
        }

       

    }
}
