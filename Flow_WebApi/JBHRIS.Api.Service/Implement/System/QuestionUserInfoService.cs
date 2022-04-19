using JBHRIS.Api.Dal.Interface;
using JBHRIS.Api.Dto.FlowMainInte.Vdb;
using JBHRIS.Api.Service.Interface.System;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Service.Implement.System
{
    public class QuestionUserInfoService : QuestionUserInfoInterFace
    {
        private ISystem_QuestionUserInfo_View _ISystem_QuestionUserInfo_View;
        public QuestionUserInfoService(ISystem_QuestionUserInfo_View system_QuestionUserInfo_View)
        {
            this._ISystem_QuestionUserInfo_View = system_QuestionUserInfo_View;
        }

        public List<QuestionUserInfoVdb> GetQuestionUserInfoByCode(string Code)
        {
            return this._ISystem_QuestionUserInfo_View.GetQuestionUserInfoByCode(Code);
        }
     

    }
}
