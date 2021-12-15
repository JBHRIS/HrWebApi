using JBHRIS.Api.Dal.Interface;
using JBHRIS.Api.Dto.FlowMainInte.Vdb;
using JBHRIS.Api.Service.Interface.System;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Service.Implement.System
{
    public class QuestionCategoryService : QuestionCategoryInterFace
    {
        private ISystem_QuestionCategory_View _ISystem_QuestionCategory_View;
        public QuestionCategoryService(ISystem_QuestionCategory_View system_QuestionCategory_View)
        {
            this._ISystem_QuestionCategory_View = system_QuestionCategory_View;
        }

        public List<QuestionCategoryVdb> GetQuestionCategory()
        {
            return this._ISystem_QuestionCategory_View.GetQuestionCategory();
        }
      

       

    }
}
