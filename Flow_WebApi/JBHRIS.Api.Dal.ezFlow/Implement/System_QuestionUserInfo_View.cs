using JBHRIS.Api.Dal.ezFlow.Entity.ezFlow;
using JBHRIS.Api.Dal.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using JBHRIS.Api.Dto.FlowMainInte.Vdb;
using JBHRIS.Api.Dal.ezFlow.Entity.Share;

namespace JBHRIS.Api.Dal.ezFlow.Implement
{
    public class System_QuestionUserInfo_View : ISystem_QuestionUserInfo_View
    {

        private ShareContext _context;


        public System_QuestionUserInfo_View(ShareContext context)
        {
            this._context = context;
        }



        public List<QuestionUserInfoVdb> GetQuestionUserInfoByCompanyIdAndAccountCode(string CompnayId,string AccountCode)
        {
            List<QuestionUserInfoVdb> result = (from bn in this._context.QuestionUserInfos
                                                where bn.CompanyId == CompnayId && bn.AccountCode == AccountCode
                                                select new QuestionUserInfoVdb
                                                {
                                                    AutoKey = bn.AutoKey,
                                                    CompanyId = bn.CompanyId,
                                                    Code = bn.Code,
                                                    AccountCode = bn.AccountCode,
                                                    AccountPassword = bn.AccountPassword,
                                                    UserId = bn.UserId,
                                                    UserName = bn.UserName,
                                                    RoleKey = bn.RoleKey,
                                                    Email = bn.Email,
                                                    Content = bn.Content,
                                                    Key1= bn.Key1,
                                                    Key2 = bn.Key2,
                                                    Key3 = bn.Key3,
                                                    DateA = bn.DateA,
                                                    DateD = bn.DateD,
                                                    Note = bn.Note,
                                                    Status = bn.Status,
                                                    InsertMan = bn.InsertMan,
                                                    InsertDate = bn.InsertDate,
                                                    UpdateMan = bn.UpdateMan,
                                                    UpdateDate = bn.UpdateDate


                                                }).ToList();





            return result;
            // return result;
        }
    }
        
}
