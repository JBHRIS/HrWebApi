using JBHRIS.Api.Dal.Interface;
using JBHRIS.Api.Dto.FlowMainInte.Vdb;
using JBHRIS.Api.Service.Interface.System;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Service.Implement.System
{
    public class QuestionMainService : QuestionMainInterFace
    {
        private ISystem_QuestionMain_View _ISystem_QuestionMain_View;
        public QuestionMainService(ISystem_QuestionMain_View system_QuestionMain_View)
        {
            this._ISystem_QuestionMain_View = system_QuestionMain_View;
        }
        public List<QuestionMainVdb> GetQuestionMain(string User, string CompanyId, string sNobr)
        {
            return this._ISystem_QuestionMain_View.GetQuestionMain(User,CompanyId,sNobr);
        }
        public List<QuestionMainVdb> GetQuestionMainByCode(string Code)
        {
            return this._ISystem_QuestionMain_View.GetQuestionMainByCode(Code);
        }
        public List<QuestionMainVdb> GetQuestionMainByEmpID(string CompanyId, string sNobr)
        {
            return this._ISystem_QuestionMain_View.GetQuestionMainByEmpID(CompanyId,sNobr);
        }

        public List<QuestionMainVdb> GetQuestionMainByCompany(string CompanyId)
        {
            return this._ISystem_QuestionMain_View.GetQuestionMainByCompany(CompanyId);
        }

        public bool InsertQuestionMain(QuestionMainVdb vdb)
        {
            return this._ISystem_QuestionMain_View.InsertQuestionMain(vdb);
        }

        public bool UpdateQuestionMain(string Code, QuestionMainVdb vdb)
        {
            return this._ISystem_QuestionMain_View.UpdateQuestionMain(Code,vdb);
        }

        //public bool DeleteQuestionMain(string Code)
        //{
        //    return this._ISystem_QuestionMain_View.DeleteQuestionMain(Code);
        //}



    }
}
