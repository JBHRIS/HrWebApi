using JBHRIS.Api.Dal.ezFlow.Entity.ezFlow;
using JBHRIS.Api.Dal.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using JBHRIS.Api.Dto.FlowMainInte.Vdb;
using JBHRIS.Api.Dal.ezFlow.Entity.Share;
using JBHRIS.Api.Tools.Tool;

namespace JBHRIS.Api.Dal.ezFlow.Implement
{
    public class System_QuestionCategory_View : ISystem_QuestionCategory_View
    {

        private ShareContext _context;



        public System_QuestionCategory_View(ShareContext context)
        {
            this._context = context;
        }

        public List<QuestionCategoryVdb> GetQuestionCategory()
        {

            List<QuestionCategoryVdb> result = (from bn in this._context.ShareCodes
                                                where bn.GroupCode == "ReplyCode"
                                                orderby bn.Code
                                                select new QuestionCategoryVdb
                                                {
                                                    
                                                    Code = bn.Code,
                                                    Name=bn.Name,
                                                    
                                                }).ToList();
                                                



            return result;
            // return result;
        }



    }
}
