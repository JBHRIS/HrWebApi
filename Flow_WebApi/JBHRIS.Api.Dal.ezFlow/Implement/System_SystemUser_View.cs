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
    public class System_SystemUser_View : ISystem_SystemUser_View
    {


        private ShareContext _context;


        public System_SystemUser_View(ShareContext context)
        {
            this._context = context;
        }



        public List<SystemUserVdb> GetSystemUser()
        {
            List<SystemUserVdb> result = (from bn in this._context.SystemUsers
                                          join cn in this._context.SystemUserInfos on bn.Code equals cn.UserCode
                                          select new SystemUserVdb
                                          {
                                              AutoKey = bn.AutoKey,
                                              Code = bn.Code,
                                              CompanyId=bn.CompnayId,
                                              UserName = cn.UserName,
                                              AccountCode = bn.AccountCode,
                                              AccountPassword = bn.AccountPassword,
                                              MoneyPassword = bn.MoneyPassword,
                                              RoleKey = bn.RoleKey,
                                              DateA = bn.DateA,
                                              DateD = bn.DateD,
                                              IsRegistered = bn.IsRegistered.Value,
                                              Note = bn.Note,
                                              Status = bn.Status,
                                              InsertMan = bn.InsertMan,
                                              InsertDate = bn.InsertDate ?? new DateTime(),
                                              UpdateMan = bn.UpdateMan,
                                              UpdateDate = bn.InsertDate ?? new DateTime(),
                                          }).ToList();



            return result;

        }
    }
}
